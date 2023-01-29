using System;
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

        public float GetWightPercent()
        {
            return newWidth;
        }

        public float GetHeightPercent()
        {
            return newHight;
        }

        public int GetWight()
        {
            return (int) numericWidth.Value;
        }

        public int GetHeight()
        {
            return (int) numericHeight.Value;
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

        private void numericWidth_Leave(object sender, EventArgs e)
        {
            checkNumbers();
        }

        private void numericHeight_Leave(object sender, EventArgs e)
        {
            checkNumbers();
        }

        private void checkNumbers()
        {
            if (numericHeight.Value % 2 != 0 || numericWidth.Value % 2 != 0)
                MessageBox.Show("Only even numbers allowed", "Don't too fast", MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
    }
}
