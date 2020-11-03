namespace WebMConverter
{
    partial class CaptionForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trimTimingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boxText = new System.Windows.Forms.ToolStripTextBox();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borderColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialogTextColor = new System.Windows.Forms.ColorDialog();
            this.colorDialogBorderColor = new System.Windows.Forms.ColorDialog();
            this.numericBorderThickness = new System.Windows.Forms.NumericUpDown();
            this.previewFrame = new WebMConverter.PreviewFrame();
            this.label1 = new System.Windows.Forms.Label();
            this.numericStartFrame = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericEndFrame = new System.Windows.Forms.NumericUpDown();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBorderThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStartFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEndFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previewToolStripMenuItem,
            this.boxText,
            this.fontToolStripMenuItem,
            this.textColorToolStripMenuItem,
            this.borderColorToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(992, 30);
            this.menuStrip.TabIndex = 0;
            // 
            // previewToolStripMenuItem
            // 
            this.previewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trimTimingToolStripMenuItem,
            this.frameToolStripMenuItem,
            this.timeToolStripMenuItem});
            this.previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            this.previewToolStripMenuItem.Size = new System.Drawing.Size(85, 26);
            this.previewToolStripMenuItem.Text = "Preview...";
            // 
            // trimTimingToolStripMenuItem
            // 
            this.trimTimingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.endToolStripMenuItem});
            this.trimTimingToolStripMenuItem.Enabled = false;
            this.trimTimingToolStripMenuItem.Name = "trimTimingToolStripMenuItem";
            this.trimTimingToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.trimTimingToolStripMenuItem.Text = "Trim timing...";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // endToolStripMenuItem
            // 
            this.endToolStripMenuItem.Name = "endToolStripMenuItem";
            this.endToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.endToolStripMenuItem.Text = "End";
            this.endToolStripMenuItem.Click += new System.EventHandler(this.endToolStripMenuItem_Click);
            // 
            // frameToolStripMenuItem
            // 
            this.frameToolStripMenuItem.Name = "frameToolStripMenuItem";
            this.frameToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.frameToolStripMenuItem.Text = "Frame";
            this.frameToolStripMenuItem.Click += new System.EventHandler(this.frameToolStripMenuItem_Click);
            // 
            // timeToolStripMenuItem
            // 
            this.timeToolStripMenuItem.Name = "timeToolStripMenuItem";
            this.timeToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.timeToolStripMenuItem.Text = "Time";
            this.timeToolStripMenuItem.Click += new System.EventHandler(this.timeToolStripMenuItem_Click);
            // 
            // boxText
            // 
            this.boxText.Font = new System.Drawing.Font("Arial", 8.400001F);
            this.boxText.Name = "boxText";
            this.boxText.Size = new System.Drawing.Size(132, 26);
            this.boxText.Text = "Text goes here";
            this.boxText.TextChanged += new System.EventHandler(this.UpdateTextLayout);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(51, 26);
            this.fontToolStripMenuItem.Text = "Font";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.fontToolStripMenuItem_Click);
            // 
            // textColorToolStripMenuItem
            // 
            this.textColorToolStripMenuItem.Name = "textColorToolStripMenuItem";
            this.textColorToolStripMenuItem.Size = new System.Drawing.Size(84, 26);
            this.textColorToolStripMenuItem.Text = "Text color";
            this.textColorToolStripMenuItem.Click += new System.EventHandler(this.textColorToolStripMenuItem_Click);
            // 
            // borderColorToolStripMenuItem
            // 
            this.borderColorToolStripMenuItem.Name = "borderColorToolStripMenuItem";
            this.borderColorToolStripMenuItem.Size = new System.Drawing.Size(102, 26);
            this.borderColorToolStripMenuItem.Text = "Border color";
            this.borderColorToolStripMenuItem.Click += new System.EventHandler(this.borderColorToolStripMenuItem_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConfirm.Location = new System.Drawing.Point(888, 638);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(4);
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
            this.buttonCancel.Location = new System.Drawing.Point(785, 638);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 28);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // fontDialog1
            // 
            this.fontDialog1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.fontDialog1.Font = new System.Drawing.Font("Impact", 63.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // colorDialogTextColor
            // 
            this.colorDialogTextColor.Color = System.Drawing.Color.White;
            // 
            // numericBorderThickness
            // 
            this.numericBorderThickness.Location = new System.Drawing.Point(505, 5);
            this.numericBorderThickness.Margin = new System.Windows.Forms.Padding(4);
            this.numericBorderThickness.Name = "numericBorderThickness";
            this.numericBorderThickness.Size = new System.Drawing.Size(81, 22);
            this.numericBorderThickness.TabIndex = 4;
            this.numericBorderThickness.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericBorderThickness.ValueChanged += new System.EventHandler(this.UpdateTextLayout);
            // 
            // previewFrame
            // 
            this.previewFrame.BackColor = System.Drawing.SystemColors.ControlDark;
            this.previewFrame.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.previewFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewFrame.Location = new System.Drawing.Point(0, 30);
            this.previewFrame.Margin = new System.Windows.Forms.Padding(5);
            this.previewFrame.Name = "previewFrame";
            this.previewFrame.Size = new System.Drawing.Size(992, 640);
            this.previewFrame.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(603, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Start Frame";
            // 
            // numericStartFrame
            // 
            this.numericStartFrame.Location = new System.Drawing.Point(701, 5);
            this.numericStartFrame.Name = "numericStartFrame";
            this.numericStartFrame.Size = new System.Drawing.Size(76, 22);
            this.numericStartFrame.TabIndex = 6;
            this.numericStartFrame.ValueChanged += new System.EventHandler(this.numericStartFrame_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(792, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "End Frame";
            // 
            // numericEndFrame
            // 
            this.numericEndFrame.Enabled = false;
            this.numericEndFrame.Location = new System.Drawing.Point(884, 5);
            this.numericEndFrame.Name = "numericEndFrame";
            this.numericEndFrame.Size = new System.Drawing.Size(72, 22);
            this.numericEndFrame.TabIndex = 8;
            this.numericEndFrame.ValueChanged += new System.EventHandler(this.numericEndFrame_ValueChanged);
            // 
            // CaptionForm
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(992, 670);
            this.ControlBox = false;
            this.Controls.Add(this.numericEndFrame);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericStartFrame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericBorderThickness);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.previewFrame);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(615, 372);
            this.Name = "CaptionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Caption";
            this.Load += new System.EventHandler(this.CaptionForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBorderThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStartFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEndFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private PreviewFrame previewFrame;
        private System.Windows.Forms.ToolStripMenuItem trimTimingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripTextBox boxText;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialogTextColor;
        private System.Windows.Forms.ColorDialog colorDialogBorderColor;
        private System.Windows.Forms.ToolStripMenuItem textColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borderColorToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numericBorderThickness;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericStartFrame;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericEndFrame;
    }
}