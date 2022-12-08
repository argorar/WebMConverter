namespace WebMConverter.Dialogs
{
    partial class DownloadOptionsDialog
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
            System.Windows.Forms.TableLayoutPanel table;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadOptionsDialog));
            this.boxOutput = new System.Windows.Forms.RichTextBox();
            this.pictureStatus = new System.Windows.Forms.PictureBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelWriteFormat = new System.Windows.Forms.Label();
            this.txtFormatNumber = new System.Windows.Forms.TextBox();
            this.StatusImages = new System.Windows.Forms.ImageList(this.components);
            table = new System.Windows.Forms.TableLayoutPanel();
            table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // table
            // 
            table.ColumnCount = 5;
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.48193F));
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.51807F));
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            table.Controls.Add(this.boxOutput, 0, 0);
            table.Controls.Add(this.pictureStatus, 0, 2);
            table.Controls.Add(this.buttonLoad, 3, 2);
            table.Controls.Add(this.buttonCancel, 4, 2);
            table.Controls.Add(this.progressBar, 0, 1);
            table.Controls.Add(this.labelWriteFormat, 1, 2);
            table.Controls.Add(this.txtFormatNumber, 2, 2);
            table.Dock = System.Windows.Forms.DockStyle.Fill;
            table.Location = new System.Drawing.Point(3, 3);
            table.Name = "table";
            table.RowCount = 3;
            table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            table.Size = new System.Drawing.Size(773, 435);
            table.TabIndex = 0;
            // 
            // boxOutput
            // 
            this.boxOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            table.SetColumnSpan(this.boxOutput, 5);
            this.boxOutput.DetectUrls = false;
            this.boxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxOutput.Location = new System.Drawing.Point(3, 3);
            this.boxOutput.Name = "boxOutput";
            this.boxOutput.ReadOnly = true;
            this.boxOutput.Size = new System.Drawing.Size(767, 367);
            this.boxOutput.TabIndex = 0;
            this.boxOutput.Text = "";
            this.boxOutput.TextChanged += new System.EventHandler(this.boxOutput_TextChanged);
            // 
            // pictureStatus
            // 
            this.pictureStatus.BackColor = System.Drawing.SystemColors.Control;
            this.pictureStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureStatus.Location = new System.Drawing.Point(3, 407);
            this.pictureStatus.Name = "pictureStatus";
            this.pictureStatus.Size = new System.Drawing.Size(25, 25);
            this.pictureStatus.TabIndex = 4;
            this.pictureStatus.TabStop = false;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLoad.Enabled = false;
            this.buttonLoad.Location = new System.Drawing.Point(439, 407);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(158, 25);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Download";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(603, 407);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(167, 25);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // progressBar
            // 
            table.SetColumnSpan(this.progressBar, 5);
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(3, 376);
            this.progressBar.Maximum = 1000;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(767, 25);
            this.progressBar.TabIndex = 0;
            // 
            // labelWriteFormat
            // 
            this.labelWriteFormat.AutoSize = true;
            this.labelWriteFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWriteFormat.Location = new System.Drawing.Point(33, 404);
            this.labelWriteFormat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWriteFormat.Name = "labelWriteFormat";
            this.labelWriteFormat.Size = new System.Drawing.Size(322, 31);
            this.labelWriteFormat.TabIndex = 5;
            this.labelWriteFormat.Text = "Write ID of format in the next box";
            this.labelWriteFormat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFormatNumber
            // 
            this.txtFormatNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFormatNumber.Location = new System.Drawing.Point(360, 407);
            this.txtFormatNumber.Name = "txtFormatNumber";
            this.txtFormatNumber.Size = new System.Drawing.Size(73, 20);
            this.txtFormatNumber.TabIndex = 6;
            // 
            // StatusImages
            // 
            this.StatusImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("StatusImages.ImageStream")));
            this.StatusImages.TransparentColor = System.Drawing.Color.Transparent;
            this.StatusImages.Images.SetKeyName(0, "Happening");
            this.StatusImages.Images.SetKeyName(1, "Failure");
            this.StatusImages.Images.SetKeyName(2, "Success");
            // 
            // DownloadOptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 441);
            this.ControlBox = false;
            this.Controls.Add(table);
            this.Name = "DownloadOptionsDialog";
            this.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Download Progress";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConverterForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConverterForm_FormClosed);
            this.Load += new System.EventHandler(this.DownloadDialog_Load);
            table.ResumeLayout(false);
            table.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.PictureBox pictureStatus;
        private System.Windows.Forms.ImageList StatusImages;
        private System.Windows.Forms.RichTextBox boxOutput;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelWriteFormat;
        private System.Windows.Forms.TextBox txtFormatNumber;
    }
}