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
            this.textBoxFPS = new System.Windows.Forms.TextBox();
            this.labelFPS = new System.Windows.Forms.Label();
            this.boxPreviewOriginal = new System.Windows.Forms.TextBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.trackRate = new System.Windows.Forms.TrackBar();
            this.labelPercentIndicator = new System.Windows.Forms.Label();
            this.boxPreviewScaled = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            labelArrow = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // labelArrow
            // 
            labelArrow.AutoSize = true;
            labelArrow.Dock = System.Windows.Forms.DockStyle.Fill;
            labelArrow.Location = new System.Drawing.Point(209, 44);
            labelArrow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelArrow.Name = "labelArrow";
            labelArrow.Size = new System.Drawing.Size(32, 52);
            labelArrow.TabIndex = 0;
            labelArrow.Text = "->";
            labelArrow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 7;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.04979F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.48133F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.298756F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.99585F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.55556F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanelMain.Controls.Add(this.textBoxFPS, 4, 2);
            this.tableLayoutPanelMain.Controls.Add(this.labelFPS, 3, 2);
            this.tableLayoutPanelMain.Controls.Add(this.boxPreviewOriginal, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.buttonConfirm, 6, 2);
            this.tableLayoutPanelMain.Controls.Add(this.buttonCancel, 6, 1);
            this.tableLayoutPanelMain.Controls.Add(this.trackRate, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelPercentIndicator, 6, 0);
            this.tableLayoutPanelMain.Controls.Add(labelArrow, 2, 1);
            this.tableLayoutPanelMain.Controls.Add(this.boxPreviewScaled, 3, 1);
            this.tableLayoutPanelMain.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.numericUpDown, 1, 2);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.48387F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.67742F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(482, 147);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // textBoxFPS
            // 
            this.textBoxFPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFPS.Location = new System.Drawing.Point(302, 110);
            this.textBoxFPS.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFPS.Name = "textBoxFPS";
            this.textBoxFPS.Size = new System.Drawing.Size(57, 22);
            this.textBoxFPS.TabIndex = 10;
            this.textBoxFPS.TextChanged += new System.EventHandler(this.textBoxFPS_TextChanged);
            this.textBoxFPS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFPS_KeyPress);
            // 
            // labelFPS
            // 
            this.labelFPS.AutoSize = true;
            this.labelFPS.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelFPS.Location = new System.Drawing.Point(262, 96);
            this.labelFPS.Name = "labelFPS";
            this.labelFPS.Size = new System.Drawing.Size(33, 51);
            this.labelFPS.TabIndex = 9;
            this.labelFPS.Text = "FPS";
            this.labelFPS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // boxPreviewOriginal
            // 
            this.boxPreviewOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.boxPreviewOriginal.Enabled = false;
            this.boxPreviewOriginal.Location = new System.Drawing.Point(91, 59);
            this.boxPreviewOriginal.Margin = new System.Windows.Forms.Padding(4);
            this.boxPreviewOriginal.Name = "boxPreviewOriginal";
            this.boxPreviewOriginal.Size = new System.Drawing.Size(110, 22);
            this.boxPreviewOriginal.TabIndex = 0;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonConfirm.Location = new System.Drawing.Point(376, 100);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(102, 43);
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
            this.buttonCancel.Location = new System.Drawing.Point(376, 48);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(102, 44);
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
            this.trackRate.Location = new System.Drawing.Point(4, 4);
            this.trackRate.Margin = new System.Windows.Forms.Padding(4);
            this.trackRate.Maximum = 400;
            this.trackRate.Name = "trackRate";
            this.trackRate.Size = new System.Drawing.Size(364, 36);
            this.trackRate.TabIndex = 1;
            this.trackRate.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackRate.Value = 100;
            this.trackRate.ValueChanged += new System.EventHandler(this.trackRate_ValueChanged);
            // 
            // labelPercentIndicator
            // 
            this.labelPercentIndicator.AutoSize = true;
            this.labelPercentIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPercentIndicator.Location = new System.Drawing.Point(376, 0);
            this.labelPercentIndicator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPercentIndicator.Name = "labelPercentIndicator";
            this.labelPercentIndicator.Size = new System.Drawing.Size(102, 44);
            this.labelPercentIndicator.TabIndex = 0;
            this.labelPercentIndicator.Text = "0%";
            this.labelPercentIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // boxPreviewScaled
            // 
            this.boxPreviewScaled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.SetColumnSpan(this.boxPreviewScaled, 2);
            this.boxPreviewScaled.Enabled = false;
            this.boxPreviewScaled.Location = new System.Drawing.Point(249, 59);
            this.boxPreviewScaled.Margin = new System.Windows.Forms.Padding(4);
            this.boxPreviewScaled.Name = "boxPreviewScaled";
            this.boxPreviewScaled.Size = new System.Drawing.Size(110, 22);
            this.boxPreviewScaled.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(19, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 51);
            this.label1.TabIndex = 7;
            this.label1.Text = "   Set to %";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown
            // 
            this.numericUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDown.Location = new System.Drawing.Point(106, 110);
            this.numericUpDown.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(80, 22);
            this.numericUpDown.TabIndex = 8;
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // RateForm
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(482, 147);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RateForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Original Frame Per Second {0}";
            this.Load += new System.EventHandler(this.RateForm_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Label labelFPS;
        private System.Windows.Forms.TextBox textBoxFPS;
    }
}