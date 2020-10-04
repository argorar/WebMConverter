using System;
using System.Windows.Forms;

namespace WebMConverter
{
    public partial class FadeForm : Form
    {
        public FadeFilter GeneratedFilter;

        public FadeForm()
        {
            InitializeComponent();
        }

        public FadeForm(FadeFilter fadeFilter) : this()
        {
            checkFadeIn.Checked = fadeFilter.Start;
            checkFadeOut.Checked = fadeFilter.End;
            numericFrames.Value = fadeFilter.Frames;
            checkKeepAudio.Checked = fadeFilter.KeepAudio;
        }

        private void buttonConfirm_Click(object sender, EventArgs e) => GeneratedFilter = new FadeFilter(
            checkFadeIn.Checked,
            checkFadeOut.Checked,
            (int)numericFrames.Value,
            checkKeepAudio.Checked);
    }

    public class FadeFilter
    {
        public bool Start { get; }
        public bool End { get; }
        public int Frames { get; }
        public bool KeepAudio { get; }

        public FadeFilter(bool start, bool end, int frames, bool keepAudio)
        {
            Start = start;
            End = end;
            Frames = frames;
            KeepAudio = keepAudio;
        }

        public override string ToString()
        {
            var blankClip = KeepAudio ? $"AudioDub(BlankClip(last, {Frames}), last)" : $"BlankClip(last, {Frames})";
            var fadeIn = Start ? $"Dissolve({blankClip}, last, {Frames}) " : "";
            var fadeOut = End ? $"Dissolve(last, {blankClip}, {Frames})" : "";
            return fadeIn + fadeOut;
        }
    }
}
