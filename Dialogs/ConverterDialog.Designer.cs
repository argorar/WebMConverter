namespace WebMConverter.Dialogs
{
    partial class ConverterDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConverterDialog));
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.boxOutput = new System.Windows.Forms.RichTextBox();
            this.pictureStatus = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonShareX = new System.Windows.Forms.Button();
            this.StatusImages = new System.Windows.Forms.ImageList(this.components);
            this.table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.ColumnCount = 7;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.45423F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.5701F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.80185F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.table.Controls.Add(this.boxOutput, 0, 0);
            this.table.Controls.Add(this.pictureStatus, 0, 2);
            this.table.Controls.Add(this.progressBar, 0, 1);
            this.table.Controls.Add(this.buttonPlay, 1, 2);
            this.table.Controls.Add(this.buttonUpload, 3, 2);
            this.table.Controls.Add(this.buttonCancel, 5, 2);
            this.table.Controls.Add(this.buttonShareX, 4, 2);
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(4, 4);
            this.table.Margin = new System.Windows.Forms.Padding(4);
            this.table.Name = "table";
            this.table.RowCount = 3;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.table.Size = new System.Drawing.Size(904, 535);
            this.table.TabIndex = 0;
            // 
            // boxOutput
            // 
            this.boxOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.table.SetColumnSpan(this.boxOutput, 7);
            this.boxOutput.DetectUrls = false;
            this.boxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxOutput.Location = new System.Drawing.Point(4, 4);
            this.boxOutput.Margin = new System.Windows.Forms.Padding(4);
            this.boxOutput.Name = "boxOutput";
            this.boxOutput.ReadOnly = true;
            this.boxOutput.Size = new System.Drawing.Size(896, 451);
            this.boxOutput.TabIndex = 0;
            this.boxOutput.Text = "";
            this.boxOutput.TextChanged += new System.EventHandler(this.boxOutput_TextChanged);
            // 
            // pictureStatus
            // 
            this.pictureStatus.BackColor = System.Drawing.SystemColors.Control;
            this.pictureStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureStatus.Location = new System.Drawing.Point(4, 501);
            this.pictureStatus.Margin = new System.Windows.Forms.Padding(4);
            this.pictureStatus.Name = "pictureStatus";
            this.pictureStatus.Size = new System.Drawing.Size(33, 30);
            this.pictureStatus.TabIndex = 4;
            this.pictureStatus.TabStop = false;
            // 
            // progressBar
            // 
            this.table.SetColumnSpan(this.progressBar, 7);
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(4, 463);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar.Maximum = 1000;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(896, 30);
            this.progressBar.TabIndex = 0;
            // 
            // buttonPlay
            // 
            this.table.SetColumnSpan(this.buttonPlay, 2);
            this.buttonPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPlay.Enabled = false;
            this.buttonPlay.Location = new System.Drawing.Point(45, 501);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(278, 30);
            this.buttonPlay.TabIndex = 1;
            this.buttonPlay.Text = "Play result";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonUpload
            // 
            this.buttonUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUpload.Enabled = false;
            this.buttonUpload.Location = new System.Drawing.Point(331, 501);
            this.buttonUpload.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(135, 30);
            this.buttonUpload.TabIndex = 2;
            this.buttonUpload.Text = "Upload to Gfycat";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Visible = false;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_ClickAsync);
            // 
            // buttonCancel
            // 
            this.table.SetColumnSpan(this.buttonCancel, 2);
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(619, 501);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(281, 30);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonShareX
            // 
            this.buttonShareX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShareX.Location = new System.Drawing.Point(473, 500);
            this.buttonShareX.Name = "buttonShareX";
            this.buttonShareX.Size = new System.Drawing.Size(139, 32);
            this.buttonShareX.TabIndex = 5;
            this.buttonShareX.Text = "Upload ShareX";
            this.buttonShareX.UseVisualStyleBackColor = true;
            this.buttonShareX.Click += new System.EventHandler(this.buttonShareX_Click);
            // 
            // StatusImages
            // 
            this.StatusImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("StatusImages.ImageStream")));
            this.StatusImages.TransparentColor = System.Drawing.Color.Transparent;
            this.StatusImages.Images.SetKeyName(0, "Happening");
            this.StatusImages.Images.SetKeyName(1, "Failure");
            this.StatusImages.Images.SetKeyName(2, "Success");
            // 
            // ConverterDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 543);
            this.ControlBox = false;
            this.Controls.Add(this.table);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConverterDialog";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conversion Progress";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConverterForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConverterForm_FormClosed);
            this.Load += new System.EventHandler(this.ConverterForm_Load);
            this.table.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.PictureBox pictureStatus;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.ImageList StatusImages;
        private System.Windows.Forms.RichTextBox boxOutput;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Button buttonShareX;
    }
}