namespace WebMConverter
{
    partial class CropForm
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
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.previewFrame = new WebMConverter.PreviewFrame();
            this.goToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trimTimingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setNewSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackVideoTimeline = new System.Windows.Forms.TrackBar();
            this.labelNewResolution = new System.Windows.Forms.Label();
            this.dynamicCropActive = new System.Windows.Forms.CheckBox();
            this.labelAspectRatio = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackVideoTimeline)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConfirm.Location = new System.Drawing.Point(932, 662);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(100, 28);
            this.buttonConfirm.TabIndex = 1;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(824, 662);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 28);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToToolStripMenuItem,
            this.setNewSizeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1045, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // goToToolStripMenuItem
            // 
            this.goToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trimTimingToolStripMenuItem,
            this.frameToolStripMenuItem,
            this.timeToolStripMenuItem});
            this.goToToolStripMenuItem.Name = "goToToolStripMenuItem";
            this.goToToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.goToToolStripMenuItem.Text = "Preview";
            // 
            // trimTimingToolStripMenuItem
            // 
            this.trimTimingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.endToolStripMenuItem});
            this.trimTimingToolStripMenuItem.Enabled = false;
            this.trimTimingToolStripMenuItem.Name = "trimTimingToolStripMenuItem";
            this.trimTimingToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.trimTimingToolStripMenuItem.Text = "Trim timing...";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // endToolStripMenuItem
            // 
            this.endToolStripMenuItem.Name = "endToolStripMenuItem";
            this.endToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.endToolStripMenuItem.Text = "End";
            this.endToolStripMenuItem.Click += new System.EventHandler(this.endToolStripMenuItem_Click);
            // 
            // frameToolStripMenuItem
            // 
            this.frameToolStripMenuItem.Name = "frameToolStripMenuItem";
            this.frameToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.frameToolStripMenuItem.Text = "Frame";
            this.frameToolStripMenuItem.Click += new System.EventHandler(this.frameToolStripMenuItem_Click);
            // 
            // timeToolStripMenuItem
            // 
            this.timeToolStripMenuItem.Name = "timeToolStripMenuItem";
            this.timeToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.timeToolStripMenuItem.Text = "Time";
            this.timeToolStripMenuItem.Click += new System.EventHandler(this.timeToolStripMenuItem_Click);
            // 
            // setNewSizeToolStripMenuItem
            // 
            this.setNewSizeToolStripMenuItem.Name = "setNewSizeToolStripMenuItem";
            this.setNewSizeToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.setNewSizeToolStripMenuItem.Text = "Set dimensions";
            this.setNewSizeToolStripMenuItem.Click += new System.EventHandler(this.setNewSizeToolStripMenuItem_Click);
            // 
            // trackVideoTimeline
            // 
            this.trackVideoTimeline.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackVideoTimeline.Location = new System.Drawing.Point(0, 645);
            this.trackVideoTimeline.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackVideoTimeline.Name = "trackVideoTimeline";
            this.trackVideoTimeline.Size = new System.Drawing.Size(1045, 45);
            this.trackVideoTimeline.TabIndex = 5;
            this.trackVideoTimeline.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackVideoTimeline.ValueChanged += new System.EventHandler(this.trackVideoTimeline_ValueChanged);
            this.trackVideoTimeline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trackVideoTimeline_KeyDown);
            // 
            // labelNewResolution
            // 
            this.labelNewResolution.AutoSize = true;
            this.labelNewResolution.Location = new System.Drawing.Point(743, 7);
            this.labelNewResolution.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNewResolution.Name = "labelNewResolution";
            this.labelNewResolution.Size = new System.Drawing.Size(0, 16);
            this.labelNewResolution.TabIndex = 6;
            // 
            // dynamicCropActive
            // 
            this.dynamicCropActive.AutoSize = true;
            this.dynamicCropActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dynamicCropActive.Location = new System.Drawing.Point(227, 5);
            this.dynamicCropActive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dynamicCropActive.Name = "dynamicCropActive";
            this.dynamicCropActive.Size = new System.Drawing.Size(92, 17);
            this.dynamicCropActive.TabIndex = 9;
            this.dynamicCropActive.Text = "Dynamic Crop";
            this.dynamicCropActive.UseVisualStyleBackColor = true;
            this.dynamicCropActive.CheckedChanged += new System.EventHandler(this.dynamicCropActive_CheckedChanged);
            // 
            // labelAspectRatio
            // 
            this.labelAspectRatio.AutoSize = true;
            this.labelAspectRatio.Location = new System.Drawing.Point(364, 6);
            this.labelAspectRatio.Name = "labelAspectRatio";
            this.labelAspectRatio.Size = new System.Drawing.Size(124, 16);
            this.labelAspectRatio.TabIndex = 10;
            this.labelAspectRatio.Text = "Aspect Ratio Active";
            this.labelAspectRatio.Click += new System.EventHandler(this.labelAspectRatio_Click);
            // previewFrame
            // 
            this.previewFrame.BackColor = System.Drawing.SystemColors.ControlDark;
            this.previewFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewFrame.Location = new System.Drawing.Point(0, 30);
            this.previewFrame.Margin = new System.Windows.Forms.Padding(5);
            this.previewFrame.Name = "previewFrame";
            this.previewFrame.Size = new System.Drawing.Size(1000, 600);
            this.previewFrame.TabIndex = 0;
            // 
            // CropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 690);
            this.ControlBox = false;
            this.Controls.Add(this.labelAspectRatio);
            this.Controls.Add(this.dynamicCropActive);
            this.Controls.Add(this.labelNewResolution);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.previewFrame);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.trackVideoTimeline);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(589, 357);
            this.Name = "CropForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Crop";
            this.Load += new System.EventHandler(this.CropForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackVideoTimeline)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PreviewFrame previewFrame;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem goToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trimTimingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackVideoTimeline;
        private System.Windows.Forms.Label labelNewResolution;
        private System.Windows.Forms.ToolStripMenuItem setNewSizeToolStripMenuItem;
        private System.Windows.Forms.CheckBox dynamicCropActive;
        private System.Windows.Forms.Label labelAspectRatio;
    }
}