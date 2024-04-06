using System;
using System.Windows.Forms;

namespace WebMConverter.Dialogs
{
    public partial class UpdateNotifyDialog : Form
    {
        string _newVersion;

        public UpdateNotifyDialog(string newVersion)
        {            
            _newVersion = newVersion.Replace(".", string.Empty);
            InitializeComponent();

            label1.Text = string.Format(label1.Text, "WebM for Lazys");
        }

        void panel1_Resize(object sender, EventArgs e)
        {
            label1.Left = (panel1.ClientSize.Width - label1.Width) / 2;
            label2.Left = (panel1.ClientSize.Width - label2.Width) / 2;
        }

        void boxReleaseNotes_CheckedChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start($"https://argorar.github.io/WebMConverter/#version-{_newVersion}");
        }
    }
}
