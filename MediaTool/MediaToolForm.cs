using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MediaTool
{
	public partial class MediaToolForm : Form
	{
		#region shorthands
		// shorthands
		private string SourcePath
		{
			get { return SourcePathTextBox.Text; }
			set { SourcePathTextBox.Text = value; }
		}

		private string TargetPath
		{
			get { return TargetPathTextBox.Text; }
			set { TargetPathTextBox.Text = value; }
		}

		private bool CopyFiles => IsValidPath(TargetPath);
		private bool CreateSubdirs => CreateSubdirsCheckBox.Enabled && CreateSubdirsCheckBox.Checked;
		private bool AddPrefix => PrefixCheckBox.Enabled && PrefixCheckBox.Checked;
		private bool RandomizeNames => RandomizeCheckBox.Enabled && RandomizeCheckBox.Checked;
		private bool UpdateTags => UpdateTagsCheckBox.Enabled && UpdateTagsCheckBox.Checked;

		private int SubDirCount => (int)SubdirUpDown.Value;
		private int RandomNameLength => (int)RandomizeUpDown.Value;

		private string PrefixText => AddPrefix ? PrefixTextBox.Text : "";
		#endregion


		#region construction
		// constructor
		public MediaToolForm()
		{
			InitializeComponent();

			StatusLabel.Text = "";
			ProgressBar.Value = 0;
		}
		#endregion


		#region utility
		//
		// Utility
		//
		private bool IsValidPath(string path)
		{
			try
			{
				Path.GetFullPath(path);
				return !string.IsNullOrWhiteSpace(path);
			}
			catch
			{
				return false;
			}
		}



		private string RandomString(Random rand, int length, string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
		{
			return new string(Enumerable.Repeat(chars, length).Select(s => s[rand.Next(s.Length)]).ToArray());
		}
		#endregion



		#region validation
		//
		// Validate
		//
		private void ValidateOptions(object sender, EventArgs e)
		{
			// enable execute only when source path exists
			ExecuteButton.Enabled = Directory.Exists(SourcePath);

			// enable copy if target path is valid
			CreateSubdirsCheckBox.Enabled = CopyFiles;

			// disable execute if source equals target
			if (SourcePath == TargetPath)
				ExecuteButton.Enabled = false;
		}
		#endregion



		#region folder select
		//
		// Folder select
		//
		private void SelectSourceButton_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();
				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
					SourcePath = fbd.SelectedPath;
			}
		}



		private void SelectTargetButton_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();
				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
					TargetPath = fbd.SelectedPath;
			}
		}



		// drag-drop
		private string GetDragDropPath(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
				if (Directory.Exists(path))
					return path;
			}
			return "";
		}



		private void GenericDragEnter(object sender, DragEventArgs e)
		{
			if(!string.IsNullOrWhiteSpace(GetDragDropPath(sender, e)))
				e.Effect = DragDropEffects.Copy;
		}



		// drag-drop source
		private void Source_DragEnter(object sender, DragEventArgs e)
		{
			GenericDragEnter(sender, e);
		}



		private void Source_DragDrop(object sender, DragEventArgs e)
		{
			string path = GetDragDropPath(sender, e);
			if (!string.IsNullOrWhiteSpace(path))
				SourcePath = path;
			ValidateOptions(sender, e as EventArgs);
		}



		// drag-drop target
		private void Target_DragEnter(object sender, DragEventArgs e)
		{
			GenericDragEnter(sender, e);
		}



		private void Target_DragDrop(object sender, DragEventArgs e)
		{
			string path = GetDragDropPath(sender, e);
			if (!string.IsNullOrWhiteSpace(path))
				TargetPath = path;
			ValidateOptions(sender, e as EventArgs);
		}
		#endregion



		#region options
		//
		// Option select
		//
		private void CreateSubdirsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SubdirUpDown.Enabled = CreateSubdirsCheckBox.Checked && CopyFiles;
			ValidateOptions(sender, e);
		}



		private void PrefixCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			PrefixTextBox.Enabled = PrefixCheckBox.Checked;
			ValidateOptions(sender, e);
		}



		private void RandomizeCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			RandomizeUpDown.Enabled = RandomizeCheckBox.Checked;
			ValidateOptions(sender, e);
		}
		#endregion



		#region execute
		//
		// Execute
		//
		private void ExecuteButton_Click(object sender, EventArgs e)
		{
			ExecuteButton.Enabled = false;
			if (!MainBackgroundWorker.IsBusy)
				MainBackgroundWorker.RunWorkerAsync();
		}



		// Background worker
		private void BackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;

			// random generator
			Random rnd = new Random();

			// check for copy status
			string[] subDirs = Enumerable.Range(0, SubDirCount).Select(x => TargetPath + Path.DirectorySeparatorChar + x.ToString()).ToArray();
			int subdirIx = 0;

			if (CopyFiles && !Directory.Exists(TargetPath))
				Directory.CreateDirectory(TargetPath);

			// do the thing
			string[] sourceFiles = Directory.GetFiles(SourcePath);
			int sourceIx = 0;
			foreach (string sourcePath in sourceFiles)
			{
				worker.ReportProgress((++sourceIx * 100) / sourceFiles.Length, Path.GetFileName(sourcePath));
				string newFilename = Path.GetFileName(Path.GetFileName(sourcePath));

				System.Threading.Thread.Sleep(1000);

				// randomize
				if (RandomizeNames)
					newFilename = RandomString(rnd, RandomNameLength) + Path.GetExtension(newFilename);

				// prefix
				if (AddPrefix)
					newFilename = PrefixText + newFilename;

				// rename or copy
				string targetPath = null;
				if (CopyFiles)
				{
					// copy
					targetPath = TargetPath + Path.DirectorySeparatorChar + newFilename;
					if (CreateSubdirs)
					{
						targetPath = subDirs[subdirIx] + Path.DirectorySeparatorChar + newFilename;
						if (!Directory.Exists(subDirs[subdirIx]))
							Directory.CreateDirectory(subDirs[subdirIx]);
						subdirIx = (subdirIx + 1) % subDirs.Length;
					}
					File.Copy(sourcePath, targetPath);
				}
				else
				{
					// rename
					targetPath = SourcePath + Path.DirectorySeparatorChar + newFilename;
					if(targetPath != sourcePath)
						File.Move(sourcePath, targetPath);
				}

				// ID3 tags
				if (UpdateTags)
				{
					// #TODO
					try
					{
						using (TagLib.File tagFile = TagLib.File.Create(targetPath))
						{
							tagFile.Tag.Title = Path.GetFileNameWithoutExtension(newFilename);
							tagFile.Save();
						}
					}
					catch (Exception ex)
					{
						// was not a media file
					}
				}
			}
		}



		private void BackgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
			ProgressBar.Value = e.ProgressPercentage;
			StatusLabel.Text = e.UserState as string;
			StatusLabel.ToolTipText = e.UserState as string;
		}



		private void BackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			ExecuteButton.Enabled = true;
			ProgressBar.Value = 0;
			StatusLabel.Text = e.Cancelled ? "Cancelled" : (e.Error == null ? "Done" : "Error: " + e.Error.Message);
			StatusLabel.ToolTipText = StatusLabel.Text;
		}



		// Status strip
		private void MainStatusStrip_MouseHover(object sender, EventArgs e)
		{
			HoverToolTip.SetToolTip(sender as StatusStrip, StatusLabel.ToolTipText);
		}
		#endregion
	}
}
