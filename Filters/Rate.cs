using System;
using System.Windows.Forms;

namespace WebMConverter
{
    public partial class RateForm : Form
    {
        public RateFilter GeneratedFilter { get; set; }

        private TimeSpan _originalDuration;
        private const string PreviewBoxFormat = @"hh\:mm\:ss";
        private readonly RateFilter _filterToEdit;

        public RateForm()
        {
            InitializeComponent();
        }

        public RateForm(RateFilter filterToEdit) : this()
        {
            _filterToEdit = filterToEdit;
        }

        private void RateForm_Load(object sender, EventArgs e)
        {
            if (_filterToEdit != null)
            {
                _originalDuration = new TimeSpan((long)(((MainForm)Owner).GetDuration() * (float)_filterToEdit.Multiplier / 100 * 10000000));
                trackRate.Value = (int)(_filterToEdit.Multiplier * 100);
                numericUpDown.Value = trackRate.Value;
            }
            else
                _originalDuration = new TimeSpan((long)(((MainForm) Owner).GetDuration() * 10000000));

            boxPreviewOriginal.Text = _originalDuration.ToString(PreviewBoxFormat);
            boxPreviewScaled.Text = new TimeSpan((long)(_originalDuration.Ticks / GetValue())).ToString(PreviewBoxFormat);
            trackRate_ValueChanged(sender, e);
            this.Text = string.Format(this.Text, Program.originalFraps);
        }

        private float GetValue()
        {
            float outvalue;
            var value = trackRate.Value;
            var negative = value < 100;

            value -= 100;
            value = Math.Abs(Math.Max(-99, value));
            outvalue = value;

            outvalue = (100 + ((negative ? -1 : 1) * outvalue)) / 100;

            return outvalue;
        }

        private void trackRate_ValueChanged(object sender, EventArgs e)
        {
            var outvalue = GetValue();

            labelPercentIndicator.Text = outvalue.ToString("P");

            boxPreviewScaled.Text = new TimeSpan((long)(_originalDuration.Ticks / outvalue)).ToString(PreviewBoxFormat);
        }

        private void buttonConfirm_Click(object sender, EventArgs e) {
            this.Focus();
            GeneratedFilter = new RateFilter(trackRate.Value);
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            trackRate.Value = Convert.ToInt32(numericUpDown.Value);
        }
    }

    public class RateFilter
    {
        public double Multiplier { get; }
        public double AvisynthMultiplier { get; }

        public RateFilter(int multiplier)
        {
            Multiplier = (double)multiplier / 100;
            AvisynthMultiplier = multiplier;
        }

        public override string ToString() => $"settb=1/9000,setpts=(PTS-STARTPTS)/{Utility.D(Multiplier)}";

        public string Avisynth() => $"AssumeScaledFPS({AvisynthMultiplier}, 100, true)";
    }
}
