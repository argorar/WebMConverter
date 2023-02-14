namespace WebMConverter
{
    partial class PreviewFrameRotate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Picture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // Picture
            // 
            this.Picture.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Picture.Location = new System.Drawing.Point(0, 0);
            this.Picture.Margin = new System.Windows.Forms.Padding(0);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(150, 150);
            this.Picture.TabIndex = 1;
            this.Picture.TabStop = false;
            this.Picture.SizeChanged += new System.EventHandler(this.pictureBoxFrame_SizeChanged);
            // 
            // PreviewFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.Picture);
            this.Name = "PreviewFrame";
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox Picture;


    }
}
