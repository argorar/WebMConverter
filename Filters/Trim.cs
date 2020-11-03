using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebMConverter.Dialogs;
using static WebMConverter.Utility;

namespace WebMConverter
{
    public partial class TrimForm : Form
    {
        private int trimStart = -1;
        private int trimEnd = -1;
        private bool play = false;
        public TrimFilter GeneratedFilter;

        public TrimForm(TrimFilter FilterToEdit = null)
        {
            InitializeComponent();

            trackVideoTimeline.Maximum = Program.VideoSource.NumberOfFrames - 1;
            trackVideoTimeline.TickFrequency = trackVideoTimeline.Maximum / 60;
            labelTimeStamp.Text = FrameToTimeStamp(trackVideoTimeline.Value);

            trackVideoTimeline.Focus();

            if (FilterToEdit == null)
            {
                trimStart = 0;
                trimEnd = Program.VideoSource.NumberOfFrames - 1;
            }
            else
            {
                trimStart = FilterToEdit.TrimStart;
                trimEnd = FilterToEdit.TrimEnd;
            }

            labelTrimStart.Text = $"{FrameToTimeStamp(trimStart)} ({trimStart})";
            labelTrimEnd.Text = $"{FrameToTimeStamp(trimEnd)} ({trimEnd})";

            trackVideoTimeline.Value = trimStart;
            previewFrame.Frame = trimStart;
            labelTimeStamp.Text = $"{FrameToTimeStamp(trackVideoTimeline.Value)} ({trackVideoTimeline.Value})";

            checktrims();

            trackVideoTimeline.MouseWheel += trackVideoTimeline_MouseWheel;
        }

        private void buttonTrimStart_Click(object sender, EventArgs e)
        {
            trimStart = trackVideoTimeline.Value;
            labelTrimStart.Text = $"{FrameToTimeStamp(trimStart)} ({trimStart})";
            checktrims();
            trackVideoTimeline_Focus(sender, e);
        }

        private void buttonTrimEnd_Click(object sender, EventArgs e)
        {
            trimEnd = trackVideoTimeline.Value;
            labelTrimEnd.Text = $"{FrameToTimeStamp(trimEnd)} ({trimEnd})";
            checktrims();
            trackVideoTimeline_Focus(sender, e);
        }

        private void checktrims()
        {
            if (trimEnd < trimStart)
            {
                buttonConfirm.Enabled = false;
                return;
            }
            buttonConfirm.Enabled = true;

            int trimLength = trimEnd - trimStart;
            labelTrimDuration.Text = $"{FrameToTimeStamp(trimLength)} ({trimLength})"; // Using trimLength is actually kind of invalid, but meh.
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            GeneratedFilter = new TrimFilter(trimStart, trimEnd);
            DialogResult = DialogResult.OK;
        }

        private void toolStripMenuGoToFrame_Click(object sender, EventArgs e)
        {
            using (var dialog = new InputDialog<int>("Frame", trackVideoTimeline.Value))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SetFrame(dialog.Value);
                }
            }
        }

        private void ToolStripMenuGoToTime_Click(object sender, EventArgs e)
        {
            using (var dialog = new InputDialog<TimeSpan>("Time", FrameToTimeSpan(trackVideoTimeline.Value)))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SetFrame(TimeSpanToFrame(dialog.Value));
                }
            }
        }

        void trackVideoTimeline_MouseWheel(object sender, MouseEventArgs e)
        {
            int modifier = 0;
            if (e.Delta > 0)
                modifier = -1;
            else if (e.Delta < 0)
                modifier = 1;

            if (modifier != 0)
            {
                SetFrame(modifier, true);
            }

            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void TrimForm_KeyDown(object sender, KeyEventArgs e)
        {
            int modifier = 0;
            switch (e.KeyData)
            {
                case Keys.Left:
                    modifier = -1;
                    break;
                case Keys.Right:
                    modifier = 1;
                    break;
            }
            
            if (modifier != 0)
            {
                SetFrame(modifier, true);
                e.Handled = true;
            }
        }
        private async void TrimForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                for (int i = 0; i < 100; i++)
                    SetFrame(1, true);
            }                        
        }


        void SetFrame(int frame, bool modifier = false)
        {
            if (modifier)
                frame += trackVideoTimeline.Value;

            trackVideoTimeline.Value = Math.Max(0, Math.Min(trackVideoTimeline.Maximum, frame)); // Make sure we don't go out of bounds.
            labelTimeStamp.Refresh();
        }

        private void trackVideoTimeline_ValueChanged(object sender, EventArgs e)
        {
            previewFrame.Frame = trackVideoTimeline.Value;
            previewFrame.Refresh();
            labelTimeStamp.Text = string.Format("{0} ({1})", FrameToTimeStamp(trackVideoTimeline.Value), trackVideoTimeline.Value);
        }

        private void trackVideoTimeline_Focus(object sender, EventArgs e) => trackVideoTimeline.Focus();

        
    }

    public class TrimFilter
    {
        public int TrimStart { get; }
        public int TrimEnd { get; }

        public TrimFilter(int trimStart, int trimEnd)
        {
            TrimStart = trimStart;
            TrimEnd = trimEnd;
        }

        public double GetDuration()
        {
            double firsttime, lasttime;

            firsttime = FrameToTimeSpan(TrimStart).TotalSeconds;
            lasttime = FrameToTimeSpan(TrimEnd).TotalSeconds;

            return lasttime - firsttime;
        }

        public override string ToString() => $"Trim({TrimStart}, {TrimEnd})";
    }
}
