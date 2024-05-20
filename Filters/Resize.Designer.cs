namespace WebMConverter
{
    partial class ResizeForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxProportions = new System.Windows.Forms.CheckBox();
            this.textWidthOut = new System.Windows.Forms.TextBox();
            this.textHeightOut = new System.Windows.Forms.TextBox();
            this.labelHeightIn = new System.Windows.Forms.Label();
            this.labelWidthIn = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel1.Controls.Add(this.checkBoxProportions, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.textWidthOut, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.textHeightOut, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelHeightIn, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelWidthIn, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonConfirm, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(347, 84);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // checkBoxProportions
            // 
            this.checkBoxProportions.AutoSize = true;
            this.checkBoxProportions.Checked = true;
            this.checkBoxProportions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxProportions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxProportions.Location = new System.Drawing.Point(253, 3);
            this.checkBoxProportions.Name = "checkBoxProportions";
            this.checkBoxProportions.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.tableLayoutPanel1.SetRowSpan(this.checkBoxProportions, 2);
            this.checkBoxProportions.Size = new System.Drawing.Size(91, 44);
            this.checkBoxProportions.TabIndex = 3;
            this.checkBoxProportions.Text = "Constrain Proportions";
            this.checkBoxProportions.UseVisualStyleBackColor = true;
            // 
            // textWidthOut
            // 
            this.textWidthOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textWidthOut.Location = new System.Drawing.Point(181, 3);
            this.textWidthOut.Name = "textWidthOut";
            this.textWidthOut.Size = new System.Drawing.Size(66, 20);
            this.textWidthOut.TabIndex = 1;
            this.textWidthOut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textWidthOut_KeyPress);
            // 
            // textHeightOut
            // 
            this.textHeightOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textHeightOut.Location = new System.Drawing.Point(181, 28);
            this.textHeightOut.Name = "textHeightOut";
            this.textHeightOut.Size = new System.Drawing.Size(66, 20);
            this.textHeightOut.TabIndex = 2;
            this.textHeightOut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textHeightOut_KeyPress);
            // 
            // labelHeightIn
            // 
            this.labelHeightIn.AutoSize = true;
            this.labelHeightIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHeightIn.Location = new System.Drawing.Point(89, 25);
            this.labelHeightIn.Name = "labelHeightIn";
            this.labelHeightIn.Size = new System.Drawing.Size(66, 25);
            this.labelHeightIn.TabIndex = 1;
            this.labelHeightIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelWidthIn
            // 
            this.labelWidthIn.AutoSize = true;
            this.labelWidthIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWidthIn.Location = new System.Drawing.Point(89, 0);
            this.labelWidthIn.Name = "labelWidthIn";
            this.labelWidthIn.Size = new System.Drawing.Size(66, 25);
            this.labelWidthIn.TabIndex = 2;
            this.labelWidthIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Height:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonCancel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonCancel, 2);
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(161, 53);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(86, 28);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.TabStop = false;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonConfirm.Location = new System.Drawing.Point(253, 53);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(91, 28);
            this.buttonConfirm.TabIndex = 1;
            this.buttonConfirm.TabStop = false;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(161, 0);
            this.label3.Name = "label3";
            this.tableLayoutPanel1.SetRowSpan(this.label3, 2);
            this.label3.Size = new System.Drawing.Size(14, 50);
            this.label3.TabIndex = 3;
            this.label3.Text = ">\r\n\r\n>";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ResizeForm
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(347, 87);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ResizeForm";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resize";
            this.Load += new System.EventHandler(this.ResizeForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxProportions;
        private System.Windows.Forms.TextBox textWidthOut;
        private System.Windows.Forms.TextBox textHeightOut;
        private System.Windows.Forms.Label labelHeightIn;
        private System.Windows.Forms.Label labelWidthIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label label3;
    }
}