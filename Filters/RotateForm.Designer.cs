namespace WebMConverter
{
    partial class RotateForm
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.goToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trimTimingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.previewFrame = new WebMConverter.PreviewFrameRotate();
            this.checkTurnNormal = new System.Windows.Forms.CheckBox();
            this.checkTurnRight = new System.Windows.Forms.CheckBox();
            this.checkTurnTwice = new System.Windows.Forms.CheckBox();
            this.checkTurnLeft = new System.Windows.Forms.CheckBox();
            this.checkFlipHorizontal = new System.Windows.Forms.CheckBox();
            this.checkFlipVertical = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Wingdings", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            label1.Location = new System.Drawing.Point(90, 511);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(37, 30);
            label1.TabIndex = 0;
            label1.Text = "Ã";
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Wingdings", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            label2.Location = new System.Drawing.Point(16, 455);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(41, 30);
            label2.TabIndex = 0;
            label2.Text = "É";
            // 
            // label3
            // 
            label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Wingdings", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            label3.Location = new System.Drawing.Point(90, 455);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(41, 30);
            label3.TabIndex = 0;
            label3.Text = "Ê";
            // 
            // label4
            // 
            label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Wingdings", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            label4.Location = new System.Drawing.Point(16, 511);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(37, 30);
            label4.TabIndex = 0;
            label4.Text = "Ä";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(744, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // goToToolStripMenuItem
            // 
            this.goToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trimTimingToolStripMenuItem,
            this.frameToolStripMenuItem,
            this.timeToolStripMenuItem});
            this.goToToolStripMenuItem.Name = "goToToolStripMenuItem";
            this.goToToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.goToToolStripMenuItem.Text = "Preview...";
            // 
            // trimTimingToolStripMenuItem
            // 
            this.trimTimingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.endToolStripMenuItem});
            this.trimTimingToolStripMenuItem.Enabled = false;
            this.trimTimingToolStripMenuItem.Name = "trimTimingToolStripMenuItem";
            this.trimTimingToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
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
            this.frameToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.frameToolStripMenuItem.Text = "Frame";
            this.frameToolStripMenuItem.Click += new System.EventHandler(this.frameToolStripMenuItem_Click);
            // 
            // timeToolStripMenuItem
            // 
            this.timeToolStripMenuItem.Name = "timeToolStripMenuItem";
            this.timeToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.timeToolStripMenuItem.Text = "Time";
            this.timeToolStripMenuItem.Click += new System.EventHandler(this.timeToolStripMenuItem_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(589, 519);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConfirm.Location = new System.Drawing.Point(667, 519);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 9;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.previewFrame, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(744, 544);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // previewFrame
            // 
            this.previewFrame.BackColor = System.Drawing.SystemColors.ControlDark;
            this.previewFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewFrame.Location = new System.Drawing.Point(3, 3);
            this.previewFrame.Name = "previewFrame";
            this.previewFrame.RotateFlip = System.Drawing.RotateFlipType.Rotate90FlipXY;
            this.previewFrame.Size = new System.Drawing.Size(738, 438);
            this.previewFrame.TabIndex = 0;
            // 
            // checkTurnNormal
            // 
            this.checkTurnNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkTurnNormal.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkTurnNormal.Checked = true;
            this.checkTurnNormal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkTurnNormal.Font = new System.Drawing.Font("Wingdings", 12F);
            this.checkTurnNormal.Location = new System.Drawing.Point(57, 448);
            this.checkTurnNormal.Name = "checkTurnNormal";
            this.checkTurnNormal.Size = new System.Drawing.Size(30, 30);
            this.checkTurnNormal.TabIndex = 2;
            this.checkTurnNormal.Text = "é";
            this.checkTurnNormal.UseVisualStyleBackColor = true;
            this.checkTurnNormal.CheckedChanged += new System.EventHandler(this.checkUpdate);
            // 
            // checkTurnRight
            // 
            this.checkTurnRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkTurnRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkTurnRight.Font = new System.Drawing.Font("Wingdings", 12F);
            this.checkTurnRight.Location = new System.Drawing.Point(97, 480);
            this.checkTurnRight.Name = "checkTurnRight";
            this.checkTurnRight.Size = new System.Drawing.Size(30, 30);
            this.checkTurnRight.TabIndex = 3;
            this.checkTurnRight.Text = "è";
            this.checkTurnRight.UseVisualStyleBackColor = true;
            this.checkTurnRight.CheckedChanged += new System.EventHandler(this.checkUpdate);
            // 
            // checkTurnTwice
            // 
            this.checkTurnTwice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkTurnTwice.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkTurnTwice.Font = new System.Drawing.Font("Wingdings", 12F);
            this.checkTurnTwice.Location = new System.Drawing.Point(57, 511);
            this.checkTurnTwice.Name = "checkTurnTwice";
            this.checkTurnTwice.Size = new System.Drawing.Size(30, 30);
            this.checkTurnTwice.TabIndex = 4;
            this.checkTurnTwice.Text = "ê";
            this.checkTurnTwice.UseVisualStyleBackColor = true;
            this.checkTurnTwice.CheckedChanged += new System.EventHandler(this.checkUpdate);
            // 
            // checkTurnLeft
            // 
            this.checkTurnLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkTurnLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkTurnLeft.Font = new System.Drawing.Font("Wingdings", 12F);
            this.checkTurnLeft.Location = new System.Drawing.Point(17, 480);
            this.checkTurnLeft.Name = "checkTurnLeft";
            this.checkTurnLeft.Size = new System.Drawing.Size(30, 30);
            this.checkTurnLeft.TabIndex = 5;
            this.checkTurnLeft.Text = "ç";
            this.checkTurnLeft.UseVisualStyleBackColor = true;
            this.checkTurnLeft.CheckedChanged += new System.EventHandler(this.checkUpdate);
            // 
            // checkFlipHorizontal
            // 
            this.checkFlipHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkFlipHorizontal.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkFlipHorizontal.Font = new System.Drawing.Font("Wingdings", 12F);
            this.checkFlipHorizontal.Location = new System.Drawing.Point(180, 456);
            this.checkFlipHorizontal.Name = "checkFlipHorizontal";
            this.checkFlipHorizontal.Size = new System.Drawing.Size(30, 30);
            this.checkFlipHorizontal.TabIndex = 6;
            this.checkFlipHorizontal.Text = "ó";
            this.checkFlipHorizontal.UseVisualStyleBackColor = true;
            this.checkFlipHorizontal.CheckedChanged += new System.EventHandler(this.checkUpdate);
            // 
            // checkFlipVertical
            // 
            this.checkFlipVertical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkFlipVertical.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkFlipVertical.Font = new System.Drawing.Font("Wingdings", 12F);
            this.checkFlipVertical.Location = new System.Drawing.Point(180, 501);
            this.checkFlipVertical.Name = "checkFlipVertical";
            this.checkFlipVertical.Size = new System.Drawing.Size(30, 30);
            this.checkFlipVertical.TabIndex = 7;
            this.checkFlipVertical.Text = "ô";
            this.checkFlipVertical.UseVisualStyleBackColor = true;
            this.checkFlipVertical.CheckedChanged += new System.EventHandler(this.checkUpdate);
            // 
            // RotateForm
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(744, 544);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.checkTurnNormal);
            this.Controls.Add(this.checkTurnRight);
            this.Controls.Add(this.checkTurnTwice);
            this.Controls.Add(this.checkTurnLeft);
            this.Controls.Add(this.checkFlipHorizontal);
            this.Controls.Add(this.checkFlipVertical);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(label1);
            this.Controls.Add(label2);
            this.Controls.Add(label3);
            this.Controls.Add(label4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(446, 299);
            this.Name = "RotateForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rotate";
            this.Load += new System.EventHandler(this.RotateForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem goToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trimTimingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeToolStripMenuItem;
        private PreviewFrameRotate previewFrame;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkTurnNormal;
        private System.Windows.Forms.CheckBox checkTurnRight;
        private System.Windows.Forms.CheckBox checkTurnTwice;
        private System.Windows.Forms.CheckBox checkTurnLeft;
        private System.Windows.Forms.CheckBox checkFlipHorizontal;
        private System.Windows.Forms.CheckBox checkFlipVertical;
    }
}