namespace WebMConverter
{
    partial class RateDynamicForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RateDynamicForm));
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.trackRate = new System.Windows.Forms.TrackBar();
            this.labelPercentIndicator = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.buttonAllDynamic = new System.Windows.Forms.Button();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 6;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.28474F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.51253F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.961276F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.733485F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.09567F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.79208F));
            this.tableLayoutPanelMain.Controls.Add(this.buttonAllDynamic, 4, 2);
            this.tableLayoutPanelMain.Controls.Add(this.buttonConfirm, 5, 2);
            this.tableLayoutPanelMain.Controls.Add(this.trackRate, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelPercentIndicator, 5, 0);
            this.tableLayoutPanelMain.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.numericUpDown, 1, 2);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.21739F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.69565F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(439, 114);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonConfirm.Location = new System.Drawing.Point(349, 62);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(86, 48);
            this.buttonConfirm.TabIndex = 5;
            this.buttonConfirm.TabStop = false;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // trackRate
            // 
            this.tableLayoutPanelMain.SetColumnSpan(this.trackRate, 5);
            this.trackRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackRate.LargeChange = 20;
            this.trackRate.Location = new System.Drawing.Point(4, 16);
            this.trackRate.Margin = new System.Windows.Forms.Padding(4, 16, 4, 4);
            this.trackRate.Maximum = 200;
            this.trackRate.Name = "trackRate";
            this.trackRate.Size = new System.Drawing.Size(337, 31);
            this.trackRate.TabIndex = 1;
            this.trackRate.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackRate.Value = 100;
            this.trackRate.ValueChanged += new System.EventHandler(this.trackRate_ValueChanged);
            // 
            // labelPercentIndicator
            // 
            this.labelPercentIndicator.AutoSize = true;
            this.labelPercentIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPercentIndicator.Location = new System.Drawing.Point(349, 0);
            this.labelPercentIndicator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPercentIndicator.Name = "labelPercentIndicator";
            this.labelPercentIndicator.Size = new System.Drawing.Size(86, 51);
            this.labelPercentIndicator.TabIndex = 0;
            this.labelPercentIndicator.Text = "0%";
            this.labelPercentIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(31, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 56);
            this.label1.TabIndex = 7;
            this.label1.Text = "       Set to %";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(114, 76);
            this.numericUpDown.Margin = new System.Windows.Forms.Padding(3, 18, 3, 2);
            this.numericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(95, 22);
            this.numericUpDown.TabIndex = 8;
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // buttonAllDynamic
            // 
            this.buttonAllDynamic.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAllDynamic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAllDynamic.Location = new System.Drawing.Point(252, 62);
            this.buttonAllDynamic.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAllDynamic.Name = "buttonAllDynamic";
            this.buttonAllDynamic.Size = new System.Drawing.Size(89, 48);
            this.buttonAllDynamic.TabIndex = 9;
            this.buttonAllDynamic.TabStop = false;
            this.buttonAllDynamic.Text = "General";
            this.buttonAllDynamic.UseVisualStyleBackColor = true;
            this.buttonAllDynamic.Click += new System.EventHandler(this.buttonAllDynamic_Click);
            // 
            // RateDynamicForm
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 114);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RateDynamicForm";
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
        private System.Windows.Forms.TrackBar trackRate;
        private System.Windows.Forms.Label labelPercentIndicator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Button buttonAllDynamic;
    }
}