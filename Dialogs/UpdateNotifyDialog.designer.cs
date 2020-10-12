namespace WebMConverter.Dialogs
{
    partial class UpdateNotifyDialog
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
            this.buttonNo = new System.Windows.Forms.Button();
            this.buttonYes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.boxReleaseNotes = new System.Windows.Forms.CheckBox();
            this.ReleaseNotesPanel = new System.Windows.Forms.Panel();
            this.ReleaseNotes = new System.Windows.Forms.WebBrowser();
            this.panel1.SuspendLayout();
            this.ReleaseNotesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNo
            // 
            this.buttonNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.buttonNo.Location = new System.Drawing.Point(273, 68);
            this.buttonNo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(100, 28);
            this.buttonNo.TabIndex = 2;
            this.buttonNo.Text = "No";
            this.buttonNo.UseVisualStyleBackColor = true;
            // 
            // buttonYes
            // 
            this.buttonYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.buttonYes.Location = new System.Drawing.Point(381, 68);
            this.buttonYes.Margin = new System.Windows.Forms.Padding(4);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(100, 28);
            this.buttonYes.TabIndex = 1;
            this.buttonYes.Text = "Yes";
            this.buttonYes.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "There is a new version of {0} available!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Would you like to download it now?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.boxReleaseNotes);
            this.panel1.Controls.Add(this.buttonNo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonYes);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 140);
            this.panel1.TabIndex = 5;
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // boxReleaseNotes
            // 
            this.boxReleaseNotes.Appearance = System.Windows.Forms.Appearance.Button;
            this.boxReleaseNotes.AutoSize = true;
            this.boxReleaseNotes.Location = new System.Drawing.Point(13, 70);
            this.boxReleaseNotes.Margin = new System.Windows.Forms.Padding(4);
            this.boxReleaseNotes.Name = "boxReleaseNotes";
            this.boxReleaseNotes.Size = new System.Drawing.Size(98, 27);
            this.boxReleaseNotes.TabIndex = 3;
            this.boxReleaseNotes.Text = "What\'s new?";
            this.boxReleaseNotes.UseVisualStyleBackColor = true;
            this.boxReleaseNotes.CheckedChanged += new System.EventHandler(this.boxReleaseNotes_CheckedChanged);
            // 
            // ReleaseNotesPanel
            // 
            this.ReleaseNotesPanel.Controls.Add(this.ReleaseNotes);
            this.ReleaseNotesPanel.Location = new System.Drawing.Point(-1, 110);
            this.ReleaseNotesPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ReleaseNotesPanel.Name = "ReleaseNotesPanel";
            this.ReleaseNotesPanel.Size = new System.Drawing.Size(532, 230);
            this.ReleaseNotesPanel.TabIndex = 6;
            this.ReleaseNotesPanel.Visible = false;
            // 
            // ReleaseNotes
            // 
            this.ReleaseNotes.AllowNavigation = false;
            this.ReleaseNotes.AllowWebBrowserDrop = false;
            this.ReleaseNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReleaseNotes.IsWebBrowserContextMenuEnabled = false;
            this.ReleaseNotes.Location = new System.Drawing.Point(0, 0);
            this.ReleaseNotes.Margin = new System.Windows.Forms.Padding(4);
            this.ReleaseNotes.MinimumSize = new System.Drawing.Size(27, 25);
            this.ReleaseNotes.Name = "ReleaseNotes";
            this.ReleaseNotes.ScriptErrorsSuppressed = true;
            this.ReleaseNotes.Size = new System.Drawing.Size(532, 230);
            this.ReleaseNotes.TabIndex = 0;
            this.ReleaseNotes.WebBrowserShortcutsEnabled = false;
            // 
            // UpdateNotifyDialog
            // 
            this.AcceptButton = this.buttonYes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.buttonNo;
            this.ClientSize = new System.Drawing.Size(499, 139);
            this.ControlBox = false;
            this.Controls.Add(this.ReleaseNotesPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(421, 43);
            this.Name = "UpdateNotifyDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update available!";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ReleaseNotesPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ReleaseNotesPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox boxReleaseNotes;
        private System.Windows.Forms.WebBrowser ReleaseNotes;
        private System.Windows.Forms.Button buttonNo;
        private System.Windows.Forms.Button buttonYes;
    }
}