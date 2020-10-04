namespace WebMConverter.Dialogs
{
    partial class TrackSelectDialog
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelSelect = new System.Windows.Forms.Label();
            this.comboBoxTracks = new System.Windows.Forms.ComboBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelSelect);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxTracks);
            this.flowLayoutPanel1.Controls.Add(this.buttonConfirm);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(310, 28);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // labelSelect
            // 
            this.labelSelect.Location = new System.Drawing.Point(3, 0);
            this.labelSelect.Name = "labelSelect";
            this.labelSelect.Size = new System.Drawing.Size(88, 28);
            this.labelSelect.TabIndex = 0;
            this.labelSelect.Text = "Video track:";
            this.labelSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxTracks
            // 
            this.comboBoxTracks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTracks.FormattingEnabled = true;
            this.comboBoxTracks.Location = new System.Drawing.Point(97, 3);
            this.comboBoxTracks.Name = "comboBoxTracks";
            this.comboBoxTracks.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTracks.TabIndex = 1;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonConfirm.Location = new System.Drawing.Point(224, 2);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(83, 23);
            this.buttonConfirm.TabIndex = 2;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            // 
            // TrackSelectDialog
            // 
            this.AcceptButton = this.buttonConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 28);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TrackSelectDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Track";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelSelect;
        private System.Windows.Forms.ComboBox comboBoxTracks;
        private System.Windows.Forms.Button buttonConfirm;
    }
}