namespace WebMConverter.Dialogs
{
    partial class SetDimensionsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetDimensionsDialog));
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.numericWidth = new System.Windows.Forms.NumericUpDown();
            this.numericHeight = new System.Windows.Forms.NumericUpDown();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.comboBoxAspectRatio = new System.Windows.Forms.ComboBox();
            this.labelAspectRatio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(13, 13);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(35, 13);
            this.labelWidth.TabIndex = 0;
            this.labelWidth.Text = "Width";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(12, 39);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(38, 13);
            this.labelHeight.TabIndex = 1;
            this.labelHeight.Text = "Height";
            // 
            // numericWidth
            // 
            this.numericWidth.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericWidth.Location = new System.Drawing.Point(78, 10);
            this.numericWidth.Name = "numericWidth";
            this.numericWidth.Size = new System.Drawing.Size(63, 20);
            this.numericWidth.TabIndex = 2;
            this.numericWidth.Leave += new System.EventHandler(this.numericWidth_Leave);
            // 
            // numericHeight
            // 
            this.numericHeight.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericHeight.Location = new System.Drawing.Point(78, 38);
            this.numericHeight.Name = "numericHeight";
            this.numericHeight.Size = new System.Drawing.Size(63, 20);
            this.numericHeight.TabIndex = 3;
            this.numericHeight.Leave += new System.EventHandler(this.numericHeight_Leave);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(157, 10);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(90, 48);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // comboBoxAspectRatio
            // 
            this.comboBoxAspectRatio.FormattingEnabled = true;
            this.comboBoxAspectRatio.Items.AddRange(new object[] {
            "16:9",
            "9:16"});
            this.comboBoxAspectRatio.Location = new System.Drawing.Point(78, 74);
            this.comboBoxAspectRatio.Name = "comboBoxAspectRatio";
            this.comboBoxAspectRatio.Size = new System.Drawing.Size(63, 21);
            this.comboBoxAspectRatio.TabIndex = 5;
            this.comboBoxAspectRatio.SelectedValueChanged += new System.EventHandler(this.comboBoxAspectRatio_SelectedValueChanged);
            // 
            // labelAspectRatio
            // 
            this.labelAspectRatio.AutoSize = true;
            this.labelAspectRatio.Location = new System.Drawing.Point(12, 77);
            this.labelAspectRatio.Name = "labelAspectRatio";
            this.labelAspectRatio.Size = new System.Drawing.Size(63, 13);
            this.labelAspectRatio.TabIndex = 6;
            this.labelAspectRatio.Text = "Aspect ratio";
            // 
            // SetDimensionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 103);
            this.Controls.Add(this.labelAspectRatio);
            this.Controls.Add(this.comboBoxAspectRatio);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.numericHeight);
            this.Controls.Add(this.numericWidth);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.labelWidth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetDimensionsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set dimensions";
            ((System.ComponentModel.ISupportInitialize)(this.numericWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.NumericUpDown numericWidth;
        private System.Windows.Forms.NumericUpDown numericHeight;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ComboBox comboBoxAspectRatio;
        private System.Windows.Forms.Label labelAspectRatio;
    }
}