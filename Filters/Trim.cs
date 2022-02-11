using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WebMConverter.Dialogs;
using static WebMConverter.Utility;

namespace WebMConverter
{
    public partial class TrimForm : Form
    {
        private int trimStart;
        private int trimEnd;
        public TrimFilter GeneratedFilter { get; set; }

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

            if (Filters.Rotate != null)
            {
                previewFrame.RotateFlip = Filters.Rotate.rotation;
                if (Filters.Rotate.Mode == RotateFilter.RotateMode.Left || Filters.Rotate.Mode == RotateFilter.RotateMode.Right)
                    previewFrame.Size = new System.Drawing.Size(previewFrame.Size.Height, previewFrame.Size.Width);
            }

            trackVideoTimeline.MouseWheel += trackVideoTimeline_MouseWheel;
            toolStripMenuSave.Click += ToolStripMenuSave_Click;
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
                    SetFrame(dialog.Value);
            }
        }

        private void ToolStripMenuGoToTime_Click(object sender, EventArgs e)
        {
            using (var dialog = new InputDialog<TimeSpan>("Time", FrameToTimeSpan(trackVideoTimeline.Value)))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    SetFrame(TimeSpanToFrame(dialog.Value));
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
                SetFrame(modifier, true);

            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void TrimForm_KeyDown(object sender, KeyEventArgs e)
        {
            int modifier = 0;
            if (e.KeyData == Keys.Left)
                modifier = -1;
            else if (e.KeyData == Keys.Right)
                modifier = 1;

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

        private void ToolStripMenuSave_Click(object sender, EventArgs e)
        {
            string output = ((MainForm)Owner).textBoxOut.Text;
            string filename = previewFrame.SavePreview(Path.GetDirectoryName(output), Path.GetFileNameWithoutExtension(output));
            
            if (!File.Exists(filename))
                MessageBox.Show("The image doesn't exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                Process.Start(filename);
        }
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
