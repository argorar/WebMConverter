namespace WebMConverter
{
    partial class RateForm
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
            System.Windows.Forms.Label labelArrow;
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.boxPreviewOriginal = new System.Windows.Forms.TextBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.trackRate = new System.Windows.Forms.TrackBar();
            this.labelPercentIndicator = new System.Windows.Forms.Label();
            this.boxPreviewScaled = new System.Windows.Forms.TextBox();
            labelArrow = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackRate)).BeginInit();
            this.SuspendLayout();
            // 
            // labelArrow
            // 
            labelArrow.AutoSize = true;
            labelArrow.Dock = System.Windows.Forms.DockStyle.Fill;
            labelArrow.Location = new System.Drawing.Point(152, 26);
            labelArrow.Name = "labelArrow";
            labelArrow.Size = new System.Drawing.Size(20, 26);
            labelArrow.TabIndex = 0;
            labelArrow.Text = "->";
            labelArrow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 7;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.74257F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.80198F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.920792F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.960396F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.84158F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.940594F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.79208F));
            this.tableLayoutPanelMain.Controls.Add(this.boxPreviewOriginal, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.buttonConfirm, 6, 2);
            this.tableLayoutPanelMain.Controls.Add(this.buttonCancel, 4, 2);
            this.tableLayoutPanelMain.Controls.Add(this.trackRate, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelPercentIndicator, 6, 0);
            this.tableLayoutPanelMain.Controls.Add(labelArrow, 2, 1);
            this.tableLayoutPanelMain.Controls.Add(this.boxPreviewScaled, 3, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(329, 87);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // boxPreviewOriginal
            // 
            this.boxPreviewOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.boxPreviewOriginal.Enabled = false;
            this.boxPreviewOriginal.Location = new System.Drawing.Point(87, 29);
            this.boxPreviewOriginal.Name = "boxPreviewOriginal";
            this.boxPreviewOriginal.Size = new System.Drawing.Size(59, 20);
            this.boxPreviewOriginal.TabIndex = 0;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonConfirm.Location = new System.Drawing.Point(262, 55);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(64, 29);
            this.buttonConfirm.TabIndex = 5;
            this.buttonConfirm.TabStop = false;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.tableLayoutPanelMain.SetColumnSpan(this.buttonCancel, 2);
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(191, 55);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(65, 29);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.TabStop = false;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // trackRate
            // 
            this.tableLayoutPanelMain.SetColumnSpan(this.trackRate, 6);
            this.trackRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackRate.LargeChange = 40;
            this.trackRate.Location = new System.Drawing.Point(3, 3);
            this.trackRate.Maximum = 400;
            this.trackRate.Name = "trackRate";
            this.trackRate.Size = new System.Drawing.Size(253, 20);
            this.trackRate.TabIndex = 1;
            this.trackRate.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackRate.Value = 100;
            this.trackRate.ValueChanged += new System.EventHandler(this.trackRate_ValueChanged);
            // 
            // labelPercentIndicator
            // 
            this.labelPercentIndicator.AutoSize = true;
            this.labelPercentIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPercentIndicator.Location = new System.Drawing.Point(262, 0);
            this.labelPercentIndicator.Name = "labelPercentIndicator";
            this.labelPercentIndicator.Size = new System.Drawing.Size(64, 26);
            this.labelPercentIndicator.TabIndex = 0;
            this.labelPercentIndicator.Text = "0%";
            this.labelPercentIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // boxPreviewScaled
            // 
            this.boxPreviewScaled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.SetColumnSpan(this.boxPreviewScaled, 2);
            this.boxPreviewScaled.Enabled = false;
            this.boxPreviewScaled.Location = new System.Drawing.Point(178, 29);
            this.boxPreviewScaled.Name = "boxPreviewScaled";
            this.boxPreviewScaled.Size = new System.Drawing.Size(59, 20);
            this.boxPreviewScaled.TabIndex = 0;
            // 
            // RateForm
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(329, 87);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RateForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rate";
            this.Load += new System.EventHandler(this.RateForm_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TrackBar trackRate;
        private System.Windows.Forms.Label labelPercentIndicator;
        private System.Windows.Forms.TextBox boxPreviewScaled;
        private System.Windows.Forms.TextBox boxPreviewOriginal;
    }
}