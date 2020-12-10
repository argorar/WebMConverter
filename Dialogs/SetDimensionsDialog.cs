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
    public partial class SetDimensionsDialog : Form
    {
        private float newWidth;
        private float newHight;

        public SetDimensionsDialog()
        {
            InitializeComponent();
            this.numericHeight.Maximum = (decimal)Program.Resolution.Height;
            this.numericWidth.Maximum = (decimal)Program.Resolution.Width;
            this.numericHeight.Value = (decimal)Program.Resolution.Height;
            this.numericWidth.Value = (decimal)Program.Resolution.Width;
            newWidth = 0;
            newHight = 0;
        }

        public float GetWight()
        {
            return newWidth;
        }

        public float GetHeight()
        {
            return newHight;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (numericWidth.Value ==  0 || numericHeight.Value == 0 || (numericHeight.Value == Program.Resolution.Height && numericWidth.Value == Program.Resolution.Width))
                Close();
            else
            {
                newHight = (float)numericHeight.Value / (float)Program.Resolution.Height;
                newWidth = (float)numericWidth.Value / (float)Program.Resolution.Width;
                Close();
            }
        }
    }
}
