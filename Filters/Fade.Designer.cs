namespace WebMConverter
{
    partial class FadeForm
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
            System.Windows.Forms.Label labelFadeIn;
            System.Windows.Forms.Label labelFadeOut;
            System.Windows.Forms.Label labelFrames;
            System.Windows.Forms.Label labelKeepAudio;
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.checkFadeIn = new System.Windows.Forms.CheckBox();
            this.checkFadeOut = new System.Windows.Forms.CheckBox();
            this.numericFrames = new System.Windows.Forms.NumericUpDown();
            this.checkKeepAudio = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            labelFadeIn = new System.Windows.Forms.Label();
            labelFadeOut = new System.Windows.Forms.Label();
            labelFrames = new System.Windows.Forms.Label();
            labelKeepAudio = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFrames)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFadeIn
            // 
            labelFadeIn.AutoSize = true;
            labelFadeIn.Dock = System.Windows.Forms.DockStyle.Fill;
            labelFadeIn.Location = new System.Drawing.Point(3, 0);
            labelFadeIn.Name = "labelFadeIn";
            labelFadeIn.Size = new System.Drawing.Size(88, 30);
            labelFadeIn.TabIndex = 0;
            labelFadeIn.Text = "Fade in:";
            labelFadeIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelFadeOut
            // 
            labelFadeOut.AutoSize = true;
            labelFadeOut.Dock = System.Windows.Forms.DockStyle.Fill;
            labelFadeOut.Location = new System.Drawing.Point(3, 30);
            labelFadeOut.Name = "labelFadeOut";
            labelFadeOut.Size = new System.Drawing.Size(88, 30);
            labelFadeOut.TabIndex = 0;
            labelFadeOut.Text = "Fade out:";
            labelFadeOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelFrames
            // 
            labelFrames.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(labelFrames, 2);
            labelFrames.Dock = System.Windows.Forms.DockStyle.Fill;
            labelFrames.Location = new System.Drawing.Point(134, 0);
            labelFrames.Name = "labelFrames";
            labelFrames.Size = new System.Drawing.Size(88, 30);
            labelFrames.TabIndex = 0;
            labelFrames.Text = "Frames:";
            labelFrames.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelKeepAudio
            // 
            labelKeepAudio.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(labelKeepAudio, 2);
            labelKeepAudio.Dock = System.Windows.Forms.DockStyle.Fill;
            labelKeepAudio.Location = new System.Drawing.Point(134, 30);
            labelKeepAudio.Name = "labelKeepAudio";
            labelKeepAudio.Size = new System.Drawing.Size(88, 30);
            labelKeepAudio.TabIndex = 0;
            labelKeepAudio.Text = "Keep audio:";
            labelKeepAudio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 5;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.71429F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.85714F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.85714F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Controls.Add(labelFadeIn, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.checkFadeIn, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(labelFadeOut, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.checkFadeOut, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(labelFrames, 2, 0);
            this.tableLayoutPanelMain.Controls.Add(this.numericFrames, 4, 0);
            this.tableLayoutPanelMain.Controls.Add(this.checkKeepAudio, 4, 1);
            this.tableLayoutPanelMain.Controls.Add(labelKeepAudio, 2, 1);
            this.tableLayoutPanelMain.Controls.Add(this.buttonCancel, 1, 2);
            this.tableLayoutPanelMain.Controls.Add(this.buttonConfirm, 3, 2);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(265, 90);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // checkFadeIn
            // 
            this.checkFadeIn.AutoSize = true;
            this.checkFadeIn.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkFadeIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkFadeIn.Location = new System.Drawing.Point(97, 3);
            this.checkFadeIn.Name = "checkFadeIn";
            this.checkFadeIn.Size = new System.Drawing.Size(31, 24);
            this.checkFadeIn.TabIndex = 1;
            this.checkFadeIn.UseVisualStyleBackColor = true;
            // 
            // checkFadeOut
            // 
            this.checkFadeOut.AutoSize = true;
            this.checkFadeOut.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkFadeOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkFadeOut.Location = new System.Drawing.Point(97, 33);
            this.checkFadeOut.Name = "checkFadeOut";
            this.checkFadeOut.Size = new System.Drawing.Size(31, 24);
            this.checkFadeOut.TabIndex = 2;
            this.checkFadeOut.UseVisualStyleBackColor = true;
            // 
            // numericFrames
            // 
            this.numericFrames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericFrames.Location = new System.Drawing.Point(228, 3);
            this.numericFrames.Name = "numericFrames";
            this.numericFrames.Size = new System.Drawing.Size(34, 20);
            this.numericFrames.TabIndex = 3;
            this.numericFrames.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // checkKeepAudio
            // 
            this.checkKeepAudio.AutoSize = true;
            this.checkKeepAudio.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkKeepAudio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkKeepAudio.Location = new System.Drawing.Point(228, 33);
            this.checkKeepAudio.Name = "checkKeepAudio";
            this.checkKeepAudio.Size = new System.Drawing.Size(34, 24);
            this.checkKeepAudio.TabIndex = 4;
            this.checkKeepAudio.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.tableLayoutPanelMain.SetColumnSpan(this.buttonCancel, 2);
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(97, 63);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(78, 24);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonConfirm
            // 
            this.tableLayoutPanelMain.SetColumnSpan(this.buttonConfirm, 2);
            this.buttonConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonConfirm.Location = new System.Drawing.Point(181, 63);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(81, 24);
            this.buttonConfirm.TabIndex = 6;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // FadeForm
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(265, 90);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FadeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fade";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFrames)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.CheckBox checkFadeIn;
        private System.Windows.Forms.CheckBox checkFadeOut;
        private System.Windows.Forms.CheckBox checkKeepAudio;
        private System.Windows.Forms.NumericUpDown numericFrames;
    }
}