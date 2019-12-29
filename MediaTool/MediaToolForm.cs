using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MediaTool
{
	public partial class MediaToolForm : Form
	{
		// command line specific
		private bool QuitOnDone = false;

		// source/target
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

		// status
		private bool CopyFiles => IsValidPath(TargetPath);
		private bool CanExecute => ExecuteButton.Enabled;

		// checkboxes
		private bool CreateSubdirs
		{
			get { return CreateSubdirsCheckBox.Enabled && CreateSubdirsCheckBox.Checked; }
			set { CreateSubdirsCheckBox.Checked = value; }
		}


		private bool AddPrefix
		{
			get { return PrefixCheckBox.Enabled && PrefixCheckBox.Checked; }
			set { PrefixCheckBox.Checked = value; }
		}


		private bool RandomizeNames
		{
			get { return RandomizeCheckBox.Enabled && RandomizeCheckBox.Checked; }
			set { RandomizeCheckBox.Checked = value; }
		}

		private bool UpdateTags
		{
			get { return UpdateTagsCheckBox.Enabled && UpdateTagsCheckBox.Checked; }
			set { UpdateTagsCheckBox.Checked = value; }
		}


		// tickers
		private int SubDirCount
		{
			get { return (int)SubdirUpDown.Value; }
			set { SubdirUpDown.Value = (decimal)value; }
		}
		private int RandomNameLength
		{
			get { return (int)RandomizeUpDown.Value; }
			set { RandomizeUpDown.Value = (decimal)value; }
		}

		// strings
		private string PrefixText
		{
			get { return PrefixTextBox.Text; }
			set { PrefixTextBox.Text = value; }
		}



		//
		// construction
		//
		public MediaToolForm()
		{
			InitializeComponent();

			StatusLabel.Text = "";
			ProgressBar.Value = 0;

			// command line
			string[] commandLine = Environment.GetCommandLineArgs();
			if (commandLine.Length > 1)
			{
				for (int i = 1; i < commandLine.Length; i++)
				{
					string cmd = commandLine[i];
					string cmdVal = "";
					if (GetCommandValue(cmd, "-i", ref cmdVal))
					{
						SourcePath = cmdVal;
					}
					else if (GetCommandValue(cmd, "-o", ref cmdVal))
					{
						TargetPath = cmdVal;
					}
					else if (GetCommandValue(cmd, "-p", ref cmdVal))
					{
						AddPrefix = true;
						PrefixText = cmdVal;
					}
					else if (GetCommandValue(cmd, "-q", ref cmdVal))
					{
						QuitOnDone = true;
					}
					else if (GetCommandValue(cmd, "-r", ref cmdVal))
					{
						RandomizeNames = true;
						if (int.TryParse(cmdVal, out int len))
							RandomNameLength = len;
					}
					else if (GetCommandValue(cmd, "-s", ref cmdVal))
					{
						CreateSubdirs = true;
						if (int.TryParse(cmdVal, out int cnt))
							SubDirCount = cnt;
					}
					else if (GetCommandValue(cmd, "-t", ref cmdVal))
					{
						UpdateTags = true;
					}
				}
				ValidateOptions(null, null);
				if (CanExecute)
					ExecuteButton_Click(null, null);
			}
		}



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



		private bool GetCommandValue(string source, string command, ref string result)
		{
			result = "";
			if (source.IndexOf(command, StringComparison.CurrentCultureIgnoreCase) != 0)
				return false;

			result = source.Substring(command.Length);
			return true;
		}



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
			string numberOfLeadingZeroes = new string('0', (int)Math.Ceiling(Math.Log10(SubDirCount)));
			string[] subDirs = Enumerable.Range(0, SubDirCount).Select(x => TargetPath + Path.DirectorySeparatorChar + x.ToString(numberOfLeadingZeroes)).ToArray();
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
					File.Copy(sourcePath, targetPath, true);
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
					catch (Exception)
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

			if (QuitOnDone)
				Close();
		}



		// Status strip
		private void MainStatusStrip_MouseHover(object sender, EventArgs e)
		{
			HoverToolTip.SetToolTip(sender as StatusStrip, StatusLabel.ToolTipText);
		}
	}
}
