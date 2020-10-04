namespace WebMConverter
{
    partial class DubForm
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
            System.Windows.Forms.Label labelAudioFile;
            System.Windows.Forms.TableLayoutPanel tableLayout;
            System.Windows.Forms.Label labelDubMode;
            this.labelDubModeHint = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.comboDubMode = new System.Windows.Forms.ComboBox();
            this.boxAudioFile = new System.Windows.Forms.TextBox();
            this.panelIndexingProgress = new System.Windows.Forms.Panel();
            this.progressIndexingProgress = new System.Windows.Forms.ProgressBar();
            this.labelIndexingProgress = new System.Windows.Forms.Label();
            this.openAudioFile = new System.Windows.Forms.OpenFileDialog();
            labelAudioFile = new System.Windows.Forms.Label();
            tableLayout = new System.Windows.Forms.TableLayoutPanel();
            labelDubMode = new System.Windows.Forms.Label();
            tableLayout.SuspendLayout();
            this.panelIndexingProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAudioFile
            // 
            labelAudioFile.AutoSize = true;
            labelAudioFile.Dock = System.Windows.Forms.DockStyle.Fill;
            labelAudioFile.Location = new System.Drawing.Point(3, 0);
            labelAudioFile.Name = "labelAudioFile";
            labelAudioFile.Size = new System.Drawing.Size(94, 28);
            labelAudioFile.TabIndex = 0;
            labelAudioFile.Text = "Audio file:";
            labelAudioFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayout
            // 
            tableLayout.ColumnCount = 5;
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayout.Controls.Add(this.labelDubModeHint, 2, 1);
            tableLayout.Controls.Add(labelDubMode, 0, 1);
            tableLayout.Controls.Add(this.buttonConfirm, 4, 2);
            tableLayout.Controls.Add(this.buttonCancel, 3, 2);
            tableLayout.Controls.Add(labelAudioFile, 0, 0);
            tableLayout.Controls.Add(this.buttonBrowse, 4, 0);
            tableLayout.Controls.Add(this.comboDubMode, 1, 1);
            tableLayout.Controls.Add(this.boxAudioFile, 1, 0);
            tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayout.Location = new System.Drawing.Point(0, 0);
            tableLayout.Name = "tableLayout";
            tableLayout.RowCount = 3;
            tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            tableLayout.Size = new System.Drawing.Size(401, 85);
            tableLayout.TabIndex = 1;
            // 
            // labelDubModeHint
            // 
            this.labelDubModeHint.AutoSize = true;
            tableLayout.SetColumnSpan(this.labelDubModeHint, 3);
            this.labelDubModeHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDubModeHint.Location = new System.Drawing.Point(193, 28);
            this.labelDubModeHint.Name = "labelDubModeHint";
            this.labelDubModeHint.Size = new System.Drawing.Size(205, 28);
            this.labelDubModeHint.TabIndex = 0;
            this.labelDubModeHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDubMode
            // 
            labelDubMode.AutoSize = true;
            labelDubMode.Dock = System.Windows.Forms.DockStyle.Fill;
            labelDubMode.Location = new System.Drawing.Point(3, 28);
            labelDubMode.Name = "labelDubMode";
            labelDubMode.Size = new System.Drawing.Size(94, 28);
            labelDubMode.TabIndex = 0;
            labelDubMode.Text = "Dubbing mode:";
            labelDubMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonConfirm.Location = new System.Drawing.Point(328, 59);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(70, 23);
            this.buttonConfirm.TabIndex = 4;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(253, 59);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(69, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBrowse.Location = new System.Drawing.Point(328, 3);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(70, 22);
            this.buttonBrowse.TabIndex = 1;
            this.buttonBrowse.Text = "Browse...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // comboDubMode
            // 
            this.comboDubMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboDubMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDubMode.FormattingEnabled = true;
            this.comboDubMode.Items.AddRange(new object[] {
            "Trim audio",
            "Loop video",
            "Just dub"});
            this.comboDubMode.Location = new System.Drawing.Point(103, 31);
            this.comboDubMode.Name = "comboDubMode";
            this.comboDubMode.Size = new System.Drawing.Size(84, 21);
            this.comboDubMode.TabIndex = 2;
            this.comboDubMode.SelectedIndexChanged += new System.EventHandler(this.comboDubMode_SelectedIndexChanged);
            // 
            // boxAudioFile
            // 
            this.boxAudioFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.boxAudioFile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            tableLayout.SetColumnSpan(this.boxAudioFile, 3);
            this.boxAudioFile.Location = new System.Drawing.Point(103, 4);
            this.boxAudioFile.Name = "boxAudioFile";
            this.boxAudioFile.Size = new System.Drawing.Size(219, 20);
            this.boxAudioFile.TabIndex = 0;
            this.boxAudioFile.TabStop = false;
            // 
            // panelIndexingProgress
            // 
            this.panelIndexingProgress.Controls.Add(this.progressIndexingProgress);
            this.panelIndexingProgress.Controls.Add(this.labelIndexingProgress);
            this.panelIndexingProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelIndexingProgress.Location = new System.Drawing.Point(0, 0);
            this.panelIndexingProgress.Name = "panelIndexingProgress";
            this.panelIndexingProgress.Size = new System.Drawing.Size(401, 85);
            this.panelIndexingProgress.TabIndex = 0;
            // 
            // progressIndexingProgress
            // 
            this.progressIndexingProgress.Location = new System.Drawing.Point(3, 3);
            this.progressIndexingProgress.Name = "progressIndexingProgress";
            this.progressIndexingProgress.Size = new System.Drawing.Size(395, 23);
            this.progressIndexingProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressIndexingProgress.TabIndex = 0;
            this.progressIndexingProgress.Value = 30;
            // 
            // labelIndexingProgress
            // 
            this.labelIndexingProgress.Location = new System.Drawing.Point(3, 28);
            this.labelIndexingProgress.Name = "labelIndexingProgress";
            this.labelIndexingProgress.Size = new System.Drawing.Size(395, 25);
            this.labelIndexingProgress.TabIndex = 1;
            this.labelIndexingProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openAudioFile
            // 
            this.openAudioFile.Title = "Select Audio file";
            this.openAudioFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openAudioFile_FileOk);
            // 
            // DubForm
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(401, 85);
            this.ControlBox = false;
            this.Controls.Add(tableLayout);
            this.Controls.Add(this.panelIndexingProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DubForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dub";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.DubForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.DubForm_DragEnter);
            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
            this.panelIndexingProgress.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelIndexingProgress;
        private System.Windows.Forms.Label labelIndexingProgress;
        private System.Windows.Forms.ProgressBar progressIndexingProgress;
        private System.Windows.Forms.TextBox boxAudioFile;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.OpenFileDialog openAudioFile;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboDubMode;
        private System.Windows.Forms.Label labelDubModeHint;
    }
}