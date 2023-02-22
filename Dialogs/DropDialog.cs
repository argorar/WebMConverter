using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebMConverter.Dialogs
{

    public partial class DropDialog : Form
    {
        public DropOptions option;

        public DropDialog()
        {
            option = DropOptions.None;
            InitializeComponent();
            this.Activate();
        }

        private void buttonMerge_Click(object sender, EventArgs e)
        {
            option = DropOptions.Merge;
            Close();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            option = DropOptions.Convert;
            Close();
        }
    }
}
