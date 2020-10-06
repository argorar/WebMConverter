namespace WebMConverter
{
    partial class TrimForm
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flowTrimButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonTrimStart = new System.Windows.Forms.Button();
            this.labelTrimStart = new System.Windows.Forms.Label();
            this.buttonTrimEnd = new System.Windows.Forms.Button();
            this.labelTrimEnd = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTrimDuration = new System.Windows.Forms.Label();
            this.previewFrame = new WebMConverter.PreviewFrame();
            this.trackVideoTimeline = new System.Windows.Forms.TrackBar();
            this.flowDialogButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelTimeStamp = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuGoTo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuGoToFrame = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuGoToTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel.SuspendLayout();
            this.flowTrimButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackVideoTimeline)).BeginInit();
            this.flowDialogButtons.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel.Controls.Add(this.flowTrimButtons, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.previewFrame, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.trackVideoTimeline, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.flowDialogButtons, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.labelTimeStamp, 2, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(992, 670);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // flowTrimButtons
            // 
            this.flowTrimButtons.Controls.Add(this.buttonTrimStart);
            this.flowTrimButtons.Controls.Add(this.labelTrimStart);
            this.flowTrimButtons.Controls.Add(this.buttonTrimEnd);
            this.flowTrimButtons.Controls.Add(this.labelTrimEnd);
            this.flowTrimButtons.Controls.Add(this.label1);
            this.flowTrimButtons.Controls.Add(this.labelTrimDuration);
            this.flowTrimButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowTrimButtons.Location = new System.Drawing.Point(0, 633);
            this.flowTrimButtons.Margin = new System.Windows.Forms.Padding(0);
            this.flowTrimButtons.Name = "flowTrimButtons";
            this.flowTrimButtons.Size = new System.Drawing.Size(752, 37);
            this.flowTrimButtons.TabIndex = 4;
            // 
            // buttonTrimStart
            // 
            this.buttonTrimStart.Location = new System.Drawing.Point(4, 4);
            this.buttonTrimStart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTrimStart.Name = "buttonTrimStart";
            this.buttonTrimStart.Size = new System.Drawing.Size(100, 28);
            this.buttonTrimStart.TabIndex = 0;
            this.buttonTrimStart.TabStop = false;
            this.buttonTrimStart.Text = "Set Start:";
            this.buttonTrimStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonTrimStart.UseVisualStyleBackColor = true;
            this.buttonTrimStart.Click += new System.EventHandler(this.buttonTrimStart_Click);
            // 
            // labelTrimStart
            // 
            this.labelTrimStart.AutoSize = true;
            this.labelTrimStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTrimStart.Location = new System.Drawing.Point(112, 0);
            this.labelTrimStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTrimStart.MaximumSize = new System.Drawing.Size(133, 0);
            this.labelTrimStart.MinimumSize = new System.Drawing.Size(133, 0);
            this.labelTrimStart.Name = "labelTrimStart";
            this.labelTrimStart.Size = new System.Drawing.Size(133, 36);
            this.labelTrimStart.TabIndex = 2;
            this.labelTrimStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonTrimEnd
            // 
            this.buttonTrimEnd.Location = new System.Drawing.Point(253, 4);
            this.buttonTrimEnd.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTrimEnd.Name = "buttonTrimEnd";
            this.buttonTrimEnd.Size = new System.Drawing.Size(100, 28);
            this.buttonTrimEnd.TabIndex = 1;
            this.buttonTrimEnd.TabStop = false;
            this.buttonTrimEnd.Text = "Set End:";
            this.buttonTrimEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonTrimEnd.UseVisualStyleBackColor = true;
            this.buttonTrimEnd.Click += new System.EventHandler(this.buttonTrimEnd_Click);
            // 
            // labelTrimEnd
            // 
            this.labelTrimEnd.AutoSize = true;
            this.labelTrimEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTrimEnd.Location = new System.Drawing.Point(361, 0);
            this.labelTrimEnd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTrimEnd.MaximumSize = new System.Drawing.Size(133, 0);
            this.labelTrimEnd.MinimumSize = new System.Drawing.Size(133, 0);
            this.labelTrimEnd.Name = "labelTrimEnd";
            this.labelTrimEnd.Size = new System.Drawing.Size(133, 36);
            this.labelTrimEnd.TabIndex = 3;
            this.labelTrimEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(502, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.MinimumSize = new System.Drawing.Size(100, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "Duration:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTrimDuration
            // 
            this.labelTrimDuration.AutoSize = true;
            this.labelTrimDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTrimDuration.Location = new System.Drawing.Point(610, 0);
            this.labelTrimDuration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTrimDuration.MaximumSize = new System.Drawing.Size(133, 0);
            this.labelTrimDuration.MinimumSize = new System.Drawing.Size(133, 0);
            this.labelTrimDuration.Name = "labelTrimDuration";
            this.labelTrimDuration.Size = new System.Drawing.Size(133, 36);
            this.labelTrimDuration.TabIndex = 4;
            this.labelTrimDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previewFrame
            // 
            this.previewFrame.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel.SetColumnSpan(this.previewFrame, 3);
            this.previewFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewFrame.Location = new System.Drawing.Point(0, 0);
            this.previewFrame.Margin = new System.Windows.Forms.Padding(0);
            this.previewFrame.Name = "previewFrame";
            this.previewFrame.Size = new System.Drawing.Size(992, 594);
            this.previewFrame.TabIndex = 0;
            this.previewFrame.TabStop = false;
            // 
            // trackVideoTimeline
            // 
            this.tableLayoutPanel.SetColumnSpan(this.trackVideoTimeline, 2);
            this.trackVideoTimeline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackVideoTimeline.Location = new System.Drawing.Point(4, 598);
            this.trackVideoTimeline.Margin = new System.Windows.Forms.Padding(4);
            this.trackVideoTimeline.Name = "trackVideoTimeline";
            this.trackVideoTimeline.Size = new System.Drawing.Size(851, 31);
            this.trackVideoTimeline.TabIndex = 0;
            this.trackVideoTimeline.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackVideoTimeline.ValueChanged += new System.EventHandler(this.trackVideoTimeline_ValueChanged);
            // 
            // flowDialogButtons
            // 
            this.tableLayoutPanel.SetColumnSpan(this.flowDialogButtons, 2);
            this.flowDialogButtons.Controls.Add(this.buttonConfirm);
            this.flowDialogButtons.Controls.Add(this.buttonCancel);
            this.flowDialogButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowDialogButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowDialogButtons.Location = new System.Drawing.Point(752, 633);
            this.flowDialogButtons.Margin = new System.Windows.Forms.Padding(0);
            this.flowDialogButtons.Name = "flowDialogButtons";
            this.flowDialogButtons.Size = new System.Drawing.Size(240, 37);
            this.flowDialogButtons.TabIndex = 5;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonConfirm.Enabled = false;
            this.buttonConfirm.Location = new System.Drawing.Point(136, 4);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(100, 28);
            this.buttonConfirm.TabIndex = 0;
            this.buttonConfirm.TabStop = false;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(28, 4);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 28);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.TabStop = false;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelTimeStamp
            // 
            this.labelTimeStamp.AutoSize = true;
            this.labelTimeStamp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTimeStamp.Location = new System.Drawing.Point(863, 594);
            this.labelTimeStamp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTimeStamp.Name = "labelTimeStamp";
            this.labelTimeStamp.Size = new System.Drawing.Size(125, 39);
            this.labelTimeStamp.TabIndex = 6;
            this.labelTimeStamp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuGoTo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(992, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuGoTo
            // 
            this.toolStripMenuGoTo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuGoToFrame,
            this.ToolStripMenuGoToTime});
            this.toolStripMenuGoTo.Name = "toolStripMenuGoTo";
            this.toolStripMenuGoTo.Size = new System.Drawing.Size(69, 24);
            this.toolStripMenuGoTo.Text = "Go to...";
            // 
            // toolStripMenuGoToFrame
            // 
            this.toolStripMenuGoToFrame.Name = "toolStripMenuGoToFrame";
            this.toolStripMenuGoToFrame.Size = new System.Drawing.Size(224, 26);
            this.toolStripMenuGoToFrame.Text = "Frame";
            this.toolStripMenuGoToFrame.Click += new System.EventHandler(this.toolStripMenuGoToFrame_Click);
            // 
            // ToolStripMenuGoToTime
            // 
            this.ToolStripMenuGoToTime.Name = "ToolStripMenuGoToTime";
            this.ToolStripMenuGoToTime.Size = new System.Drawing.Size(224, 26);
            this.ToolStripMenuGoToTime.Text = "Time";
            this.ToolStripMenuGoToTime.Click += new System.EventHandler(this.ToolStripMenuGoToTime_Click);
            // 
            // TrimForm
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(992, 698);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1007, 708);
            this.Name = "TrimForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trim";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TrimForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TrimForm_KeyPress);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.flowTrimButtons.ResumeLayout(false);
            this.flowTrimButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackVideoTimeline)).EndInit();
            this.flowDialogButtons.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private PreviewFrame previewFrame;
        private System.Windows.Forms.TrackBar trackVideoTimeline;
        private System.Windows.Forms.FlowLayoutPanel flowTrimButtons;
        private System.Windows.Forms.Button buttonTrimStart;
        private System.Windows.Forms.Button buttonTrimEnd;
        private System.Windows.Forms.FlowLayoutPanel flowDialogButtons;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuGoTo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuGoToFrame;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuGoToTime;
        private System.Windows.Forms.Label labelTimeStamp;
        private System.Windows.Forms.Label labelTrimStart;
        private System.Windows.Forms.Label labelTrimEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTrimDuration;
    }
}