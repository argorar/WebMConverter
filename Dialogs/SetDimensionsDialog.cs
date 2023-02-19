using System;
using System.Windows.Forms;

namespace WebMConverter.Dialogs
{
    public partial class SetDimensionsDialog : Form
    {
        private float newWidth;
        private float newHight;

        private static float MAGIC_NUMBER_16_9 = 0.5625f;
        private static float MAGIC_NUMBER_4_3 = 0.75f;
        private static float MAGIC_NUMBER_21_9 = 0.4186f;

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
                CalculatePercent();
                Close();
            }
        }

        private void CalculatePercent()
        {
            newHight = (float)numericHeight.Value / (float)Program.Resolution.Height;
            newWidth = (float)numericWidth.Value / (float)Program.Resolution.Width;
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

        private void comboBoxAspectRatio_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxAspectRatio.SelectedItem.Equals("16:9"))
            {
                var newValue = (int)(MAGIC_NUMBER_16_9 * (float)Program.Resolution.Width);
                numericHeight.Value = newValue > numericHeight.Maximum ? numericHeight.Maximum : newValue;
                MainForm.aspectRatio = AspectRatio.SixteenNine;
            }
            else if (comboBoxAspectRatio.SelectedItem.Equals("9:16"))
            {
                var newValue = (int)(MAGIC_NUMBER_16_9 * (float)Program.Resolution.Height);
                numericWidth.Value = newValue > numericWidth.Maximum ? numericWidth.Maximum : newValue;
                MainForm.aspectRatio = AspectRatio.NineSixteen;
            }
            else if (comboBoxAspectRatio.SelectedItem.Equals("1:1"))
            {
                var newValue = Math.Min(Program.Resolution.Width, Program.Resolution.Height);
                numericHeight.Value = newValue;
                numericWidth.Value = newValue;
                MainForm.aspectRatio = AspectRatio.OneOne;
            }
            else if (comboBoxAspectRatio.SelectedItem.Equals("4:3"))
            {
                var newValue = (int)(MAGIC_NUMBER_4_3 * (float)Program.Resolution.Width);
                numericHeight.Value = newValue > numericHeight.Maximum ? numericHeight.Maximum : newValue;
                MainForm.aspectRatio = AspectRatio.FourThree;
            }
            if (comboBoxAspectRatio.SelectedItem.Equals("21:9"))
            {
                var newValue = (int)(MAGIC_NUMBER_21_9 * (float)Program.Resolution.Width);
                numericHeight.Value = newValue > numericHeight.Maximum ? numericHeight.Maximum : newValue;
                MainForm.aspectRatio = AspectRatio.TwentyoneNine;
            }
            CalculatePercent();
            Close();

        }
    }
}
