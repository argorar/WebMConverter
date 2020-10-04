namespace WebMConverter
{
    partial class SubtitleForm
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
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxInternalSubs = new System.Windows.Forms.CheckBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBoxVideoTracks = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelSubtitleFileSelector = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSelectSubtitleFile = new System.Windows.Forms.Button();
            this.textBoxSubtitleFile = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelMain.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelSubtitleFileSelector.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 4;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.69909F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.96353F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.2766F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.66869F));
            this.tableLayoutPanelMain.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.checkBoxInternalSubs, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.buttonConfirm, 3, 2);
            this.tableLayoutPanelMain.Controls.Add(this.buttonCancel, 2, 2);
            this.tableLayoutPanelMain.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(329, 87);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Use internal subs:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Subtitle track:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxInternalSubs
            // 
            this.checkBoxInternalSubs.AutoSize = true;
            this.checkBoxInternalSubs.Checked = true;
            this.checkBoxInternalSubs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxInternalSubs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxInternalSubs.Location = new System.Drawing.Point(103, 3);
            this.checkBoxInternalSubs.Name = "checkBoxInternalSubs";
            this.checkBoxInternalSubs.Size = new System.Drawing.Size(85, 20);
            this.checkBoxInternalSubs.TabIndex = 1;
            this.checkBoxInternalSubs.Text = "Yes";
            this.checkBoxInternalSubs.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.checkBoxInternalSubs.UseVisualStyleBackColor = true;
            this.checkBoxInternalSubs.CheckedChanged += new System.EventHandler(this.checkBoxInternalSubs_CheckedChanged);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonConfirm.Location = new System.Drawing.Point(263, 55);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(63, 29);
            this.buttonConfirm.TabIndex = 5;
            this.buttonConfirm.TabStop = false;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(194, 55);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(63, 29);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.TabStop = false;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanelMain.SetColumnSpan(this.flowLayoutPanel1, 3);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxVideoTracks);
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanelSubtitleFileSelector);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(100, 26);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(229, 26);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // comboBoxVideoTracks
            // 
            this.comboBoxVideoTracks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxVideoTracks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVideoTracks.FormattingEnabled = true;
            this.comboBoxVideoTracks.Location = new System.Drawing.Point(3, 3);
            this.comboBoxVideoTracks.Name = "comboBoxVideoTracks";
            this.comboBoxVideoTracks.Size = new System.Drawing.Size(223, 21);
            this.comboBoxVideoTracks.TabIndex = 9;
            // 
            // tableLayoutPanelSubtitleFileSelector
            // 
            this.tableLayoutPanelSubtitleFileSelector.AutoSize = true;
            this.tableLayoutPanelSubtitleFileSelector.ColumnCount = 2;
            this.tableLayoutPanelSubtitleFileSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.17544F));
            this.tableLayoutPanelSubtitleFileSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.82456F));
            this.tableLayoutPanelSubtitleFileSelector.Controls.Add(this.buttonSelectSubtitleFile, 1, 0);
            this.tableLayoutPanelSubtitleFileSelector.Controls.Add(this.textBoxSubtitleFile, 0, 0);
            this.tableLayoutPanelSubtitleFileSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSubtitleFileSelector.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanelSubtitleFileSelector.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelSubtitleFileSelector.Name = "tableLayoutPanelSubtitleFileSelector";
            this.tableLayoutPanelSubtitleFileSelector.RowCount = 1;
            this.tableLayoutPanelSubtitleFileSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSubtitleFileSelector.Size = new System.Drawing.Size(229, 26);
            this.tableLayoutPanelSubtitleFileSelector.TabIndex = 1;
            this.tableLayoutPanelSubtitleFileSelector.Visible = false;
            // 
            // buttonSelectSubtitleFile
            // 
            this.buttonSelectSubtitleFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSelectSubtitleFile.Location = new System.Drawing.Point(163, 3);
            this.buttonSelectSubtitleFile.Name = "buttonSelectSubtitleFile";
            this.buttonSelectSubtitleFile.Size = new System.Drawing.Size(63, 20);
            this.buttonSelectSubtitleFile.TabIndex = 7;
            this.buttonSelectSubtitleFile.Text = "Browse...";
            this.buttonSelectSubtitleFile.UseVisualStyleBackColor = true;
            this.buttonSelectSubtitleFile.Click += new System.EventHandler(this.buttonSelectSubtitleFile_Click);
            // 
            // textBoxSubtitleFile
            // 
            this.textBoxSubtitleFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSubtitleFile.Location = new System.Drawing.Point(3, 3);
            this.textBoxSubtitleFile.Name = "textBoxSubtitleFile";
            this.textBoxSubtitleFile.Size = new System.Drawing.Size(154, 20);
            this.textBoxSubtitleFile.TabIndex = 6;
            // 
            // SubtitleForm
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(329, 87);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SubtitleForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Subtitles";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.SubtitleForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.SubtitleForm_DragEnter);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanelSubtitleFileSelector.ResumeLayout(false);
            this.tableLayoutPanelSubtitleFileSelector.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxInternalSubs;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSubtitleFileSelector;
        private System.Windows.Forms.Button buttonSelectSubtitleFile;
        private System.Windows.Forms.TextBox textBoxSubtitleFile;
        private System.Windows.Forms.ComboBox comboBoxVideoTracks;
    }
}