namespace MediaTool
{
	partial class MediaToolForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.SelectSourceButton = new System.Windows.Forms.Button();
			this.SelectTargetButton = new System.Windows.Forms.Button();
			this.SourcePathTextBox = new System.Windows.Forms.TextBox();
			this.TargetPathTextBox = new System.Windows.Forms.TextBox();
			this.SourceSelectLabel = new System.Windows.Forms.Label();
			this.TargetSelectLabel = new System.Windows.Forms.Label();
			this.ExecuteButton = new System.Windows.Forms.Button();
			this.PrefixCheckBox = new System.Windows.Forms.CheckBox();
			this.UpdateTagsCheckBox = new System.Windows.Forms.CheckBox();
			this.RandomizeCheckBox = new System.Windows.Forms.CheckBox();
			this.CreateSubdirsCheckBox = new System.Windows.Forms.CheckBox();
			this.SubdirUpDown = new System.Windows.Forms.NumericUpDown();
			this.PrefixTextBox = new System.Windows.Forms.TextBox();
			this.RandomizeUpDown = new System.Windows.Forms.NumericUpDown();
			this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
			this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.MainBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.HoverToolTip = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.SubdirUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RandomizeUpDown)).BeginInit();
			this.MainStatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// SelectSourceButton
			// 
			this.SelectSourceButton.AllowDrop = true;
			this.SelectSourceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SelectSourceButton.Location = new System.Drawing.Point(814, 25);
			this.SelectSourceButton.Margin = new System.Windows.Forms.Padding(6);
			this.SelectSourceButton.Name = "SelectSourceButton";
			this.SelectSourceButton.Size = new System.Drawing.Size(56, 44);
			this.SelectSourceButton.TabIndex = 2;
			this.SelectSourceButton.Text = "...";
			this.SelectSourceButton.UseVisualStyleBackColor = true;
			this.SelectSourceButton.Click += new System.EventHandler(this.SelectSourceButton_Click);
			this.SelectSourceButton.DragDrop += new System.Windows.Forms.DragEventHandler(this.Source_DragDrop);
			this.SelectSourceButton.DragEnter += new System.Windows.Forms.DragEventHandler(this.Source_DragEnter);
			// 
			// SelectTargetButton
			// 
			this.SelectTargetButton.AllowDrop = true;
			this.SelectTargetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SelectTargetButton.Location = new System.Drawing.Point(814, 81);
			this.SelectTargetButton.Margin = new System.Windows.Forms.Padding(6);
			this.SelectTargetButton.Name = "SelectTargetButton";
			this.SelectTargetButton.Size = new System.Drawing.Size(56, 44);
			this.SelectTargetButton.TabIndex = 5;
			this.SelectTargetButton.Text = "...";
			this.SelectTargetButton.UseVisualStyleBackColor = true;
			this.SelectTargetButton.Click += new System.EventHandler(this.SelectTargetButton_Click);
			this.SelectTargetButton.DragDrop += new System.Windows.Forms.DragEventHandler(this.Target_DragDrop);
			this.SelectTargetButton.DragEnter += new System.Windows.Forms.DragEventHandler(this.Target_DragEnter);
			// 
			// SourcePathTextBox
			// 
			this.SourcePathTextBox.AllowDrop = true;
			this.SourcePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SourcePathTextBox.Location = new System.Drawing.Point(118, 29);
			this.SourcePathTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.SourcePathTextBox.Name = "SourcePathTextBox";
			this.SourcePathTextBox.Size = new System.Drawing.Size(676, 31);
			this.SourcePathTextBox.TabIndex = 1;
			this.SourcePathTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.Source_DragDrop);
			this.SourcePathTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.Source_DragEnter);
			this.SourcePathTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateOptions);
			// 
			// TargetPathTextBox
			// 
			this.TargetPathTextBox.AllowDrop = true;
			this.TargetPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TargetPathTextBox.Location = new System.Drawing.Point(118, 85);
			this.TargetPathTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.TargetPathTextBox.Name = "TargetPathTextBox";
			this.TargetPathTextBox.Size = new System.Drawing.Size(676, 31);
			this.TargetPathTextBox.TabIndex = 4;
			this.TargetPathTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.Target_DragDrop);
			this.TargetPathTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.Target_DragEnter);
			this.TargetPathTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateOptions);
			// 
			// SourceSelectLabel
			// 
			this.SourceSelectLabel.AutoSize = true;
			this.SourceSelectLabel.Location = new System.Drawing.Point(24, 35);
			this.SourceSelectLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.SourceSelectLabel.Name = "SourceSelectLabel";
			this.SourceSelectLabel.Size = new System.Drawing.Size(80, 25);
			this.SourceSelectLabel.TabIndex = 0;
			this.SourceSelectLabel.Text = "Source";
			// 
			// TargetSelectLabel
			// 
			this.TargetSelectLabel.AutoSize = true;
			this.TargetSelectLabel.Location = new System.Drawing.Point(24, 92);
			this.TargetSelectLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.TargetSelectLabel.Name = "TargetSelectLabel";
			this.TargetSelectLabel.Size = new System.Drawing.Size(74, 25);
			this.TargetSelectLabel.TabIndex = 3;
			this.TargetSelectLabel.Text = "Target";
			// 
			// ExecuteButton
			// 
			this.ExecuteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ExecuteButton.Enabled = false;
			this.ExecuteButton.Location = new System.Drawing.Point(720, 490);
			this.ExecuteButton.Margin = new System.Windows.Forms.Padding(6);
			this.ExecuteButton.Name = "ExecuteButton";
			this.ExecuteButton.Size = new System.Drawing.Size(150, 44);
			this.ExecuteButton.TabIndex = 13;
			this.ExecuteButton.Text = "Execute";
			this.ExecuteButton.UseVisualStyleBackColor = true;
			this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
			// 
			// PrefixCheckBox
			// 
			this.PrefixCheckBox.AutoSize = true;
			this.PrefixCheckBox.Location = new System.Drawing.Point(29, 209);
			this.PrefixCheckBox.Margin = new System.Windows.Forms.Padding(6);
			this.PrefixCheckBox.Name = "PrefixCheckBox";
			this.PrefixCheckBox.Size = new System.Drawing.Size(141, 29);
			this.PrefixCheckBox.TabIndex = 8;
			this.PrefixCheckBox.Text = "Add prefix";
			this.PrefixCheckBox.UseVisualStyleBackColor = true;
			this.PrefixCheckBox.CheckedChanged += new System.EventHandler(this.PrefixCheckBox_CheckedChanged);
			// 
			// UpdateTagsCheckBox
			// 
			this.UpdateTagsCheckBox.AutoSize = true;
			this.UpdateTagsCheckBox.Location = new System.Drawing.Point(29, 301);
			this.UpdateTagsCheckBox.Margin = new System.Windows.Forms.Padding(6);
			this.UpdateTagsCheckBox.Name = "UpdateTagsCheckBox";
			this.UpdateTagsCheckBox.Size = new System.Drawing.Size(217, 29);
			this.UpdateTagsCheckBox.TabIndex = 12;
			this.UpdateTagsCheckBox.Text = "Update media title";
			this.UpdateTagsCheckBox.UseVisualStyleBackColor = true;
			// 
			// RandomizeCheckBox
			// 
			this.RandomizeCheckBox.AutoSize = true;
			this.RandomizeCheckBox.Location = new System.Drawing.Point(29, 257);
			this.RandomizeCheckBox.Margin = new System.Windows.Forms.Padding(6);
			this.RandomizeCheckBox.Name = "RandomizeCheckBox";
			this.RandomizeCheckBox.Size = new System.Drawing.Size(250, 29);
			this.RandomizeCheckBox.TabIndex = 10;
			this.RandomizeCheckBox.Text = "Randomize filenames";
			this.RandomizeCheckBox.UseVisualStyleBackColor = true;
			this.RandomizeCheckBox.CheckedChanged += new System.EventHandler(this.RandomizeCheckBox_CheckedChanged);
			// 
			// CreateSubdirsCheckBox
			// 
			this.CreateSubdirsCheckBox.AutoSize = true;
			this.CreateSubdirsCheckBox.Enabled = false;
			this.CreateSubdirsCheckBox.Location = new System.Drawing.Point(29, 157);
			this.CreateSubdirsCheckBox.Margin = new System.Windows.Forms.Padding(6);
			this.CreateSubdirsCheckBox.Name = "CreateSubdirsCheckBox";
			this.CreateSubdirsCheckBox.Size = new System.Drawing.Size(249, 29);
			this.CreateSubdirsCheckBox.TabIndex = 6;
			this.CreateSubdirsCheckBox.Text = "Create subdirectories";
			this.CreateSubdirsCheckBox.UseVisualStyleBackColor = true;
			this.CreateSubdirsCheckBox.CheckedChanged += new System.EventHandler(this.CreateSubdirsCheckBox_CheckedChanged);
			// 
			// SubdirUpDown
			// 
			this.SubdirUpDown.Enabled = false;
			this.SubdirUpDown.Location = new System.Drawing.Point(347, 155);
			this.SubdirUpDown.Margin = new System.Windows.Forms.Padding(6);
			this.SubdirUpDown.Name = "SubdirUpDown";
			this.SubdirUpDown.Size = new System.Drawing.Size(152, 31);
			this.SubdirUpDown.TabIndex = 7;
			this.SubdirUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// PrefixTextBox
			// 
			this.PrefixTextBox.Enabled = false;
			this.PrefixTextBox.Location = new System.Drawing.Point(347, 205);
			this.PrefixTextBox.Margin = new System.Windows.Forms.Padding(6);
			this.PrefixTextBox.Name = "PrefixTextBox";
			this.PrefixTextBox.Size = new System.Drawing.Size(196, 31);
			this.PrefixTextBox.TabIndex = 9;
			// 
			// RandomizeUpDown
			// 
			this.RandomizeUpDown.Enabled = false;
			this.RandomizeUpDown.Location = new System.Drawing.Point(347, 255);
			this.RandomizeUpDown.Margin = new System.Windows.Forms.Padding(6);
			this.RandomizeUpDown.Name = "RandomizeUpDown";
			this.RandomizeUpDown.Size = new System.Drawing.Size(152, 31);
			this.RandomizeUpDown.TabIndex = 11;
			this.RandomizeUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// MainStatusStrip
			// 
			this.MainStatusStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar,
            this.StatusLabel});
			this.MainStatusStrip.Location = new System.Drawing.Point(0, 540);
			this.MainStatusStrip.Name = "MainStatusStrip";
			this.MainStatusStrip.Size = new System.Drawing.Size(894, 42);
			this.MainStatusStrip.TabIndex = 14;
			this.MainStatusStrip.Text = "statusStrip1";
			this.MainStatusStrip.MouseHover += new System.EventHandler(this.MainStatusStrip_MouseHover);
			// 
			// ProgressBar
			// 
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(100, 30);
			// 
			// StatusLabel
			// 
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(135, 32);
			this.StatusLabel.Text = "StatusLabel";
			// 
			// MainBackgroundWorker
			// 
			this.MainBackgroundWorker.WorkerReportsProgress = true;
			this.MainBackgroundWorker.WorkerSupportsCancellation = true;
			this.MainBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
			this.MainBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_ProgressChanged);
			this.MainBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
			// 
			// MediaToolForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(894, 582);
			this.Controls.Add(this.MainStatusStrip);
			this.Controls.Add(this.RandomizeUpDown);
			this.Controls.Add(this.PrefixTextBox);
			this.Controls.Add(this.SubdirUpDown);
			this.Controls.Add(this.CreateSubdirsCheckBox);
			this.Controls.Add(this.RandomizeCheckBox);
			this.Controls.Add(this.UpdateTagsCheckBox);
			this.Controls.Add(this.PrefixCheckBox);
			this.Controls.Add(this.ExecuteButton);
			this.Controls.Add(this.TargetSelectLabel);
			this.Controls.Add(this.SourceSelectLabel);
			this.Controls.Add(this.TargetPathTextBox);
			this.Controls.Add(this.SourcePathTextBox);
			this.Controls.Add(this.SelectTargetButton);
			this.Controls.Add(this.SelectSourceButton);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MediaToolForm";
			this.Text = "Media Tool";
			this.Load += new System.EventHandler(this.ValidateOptions);
			((System.ComponentModel.ISupportInitialize)(this.SubdirUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RandomizeUpDown)).EndInit();
			this.MainStatusStrip.ResumeLayout(false);
			this.MainStatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button SelectSourceButton;
		private System.Windows.Forms.Button SelectTargetButton;
		private System.Windows.Forms.TextBox SourcePathTextBox;
		private System.Windows.Forms.TextBox TargetPathTextBox;
		private System.Windows.Forms.Label SourceSelectLabel;
		private System.Windows.Forms.Label TargetSelectLabel;
		private System.Windows.Forms.Button ExecuteButton;
		private System.Windows.Forms.CheckBox PrefixCheckBox;
		private System.Windows.Forms.CheckBox UpdateTagsCheckBox;
		private System.Windows.Forms.CheckBox RandomizeCheckBox;
		private System.Windows.Forms.CheckBox CreateSubdirsCheckBox;
		private System.Windows.Forms.NumericUpDown SubdirUpDown;
		private System.Windows.Forms.TextBox PrefixTextBox;
		private System.Windows.Forms.NumericUpDown RandomizeUpDown;
		private System.Windows.Forms.StatusStrip MainStatusStrip;
		private System.Windows.Forms.ToolStripProgressBar ProgressBar;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
		private System.ComponentModel.BackgroundWorker MainBackgroundWorker;
		private System.Windows.Forms.ToolTip HoverToolTip;
	}
}

