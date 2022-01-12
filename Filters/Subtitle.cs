using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static WebMConverter.Utility;

namespace WebMConverter
{
    public partial class SubtitleForm : Form
    {
        public SubtitleFilter GeneratedFilter { get; set; }

        public SubtitleForm()
        {
            InitializeComponent();

            if (Program.InputHasWeirdPixelFormat)
            {
                MessageBox.Show(
                    $"Your input video is Hi444p! That's cool, but the subtitle renderer can't deal with that pixel format.{Environment.NewLine}" + 
                    $"If you add subtitles to your webm, we'll have to convert it to something a bit less cool.{Environment.NewLine}" + 
                    "It's handed automatically, though. Don't worry.",
                    "FYI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (Program.SubtitleTracks.Count == 0)
            {
                checkBoxInternalSubs.Checked = false;
                checkBoxInternalSubs.Enabled = false;
            }
            else
            {
                Dictionary<int, string> subtitleTracks = new Dictionary<int, string>();
                foreach (var track in Program.SubtitleTracks)
                {
                    subtitleTracks.Add(track.Key, $"#{track.Key}: {track.Value.Item1}");
                }
                comboBoxVideoTracks.DataSource = new BindingSource(subtitleTracks, null);
                comboBoxVideoTracks.ValueMember = "Key";
                comboBoxVideoTracks.DisplayMember = "Value";
            }
        }

        public SubtitleForm(SubtitleFilter SubtitleFilter) : this()
        {
            if (SubtitleFilter.FileName == Program.InputFile)
            {
                comboBoxVideoTracks.SelectedValue = SubtitleFilter.Track;
            }
            else
            {
                checkBoxInternalSubs.Checked = false;
                textBoxSubtitleFile.Text = SubtitleFilter.FileName;
                if (Program.SubtitleTracks.Count == 0)
                    checkBoxInternalSubs.Enabled = false;
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (checkBoxInternalSubs.Checked)
            {
                SubtitleType type = Program.SubtitleTracks[(int)comboBoxVideoTracks.SelectedValue].Item2;
                string extension = Program.SubtitleTracks[(int)comboBoxVideoTracks.SelectedValue].Item3;
                string filename = Path.Combine(Program.AttachmentDirectory, $"sub{(int)comboBoxVideoTracks.SelectedValue}{extension}");
                GeneratedFilter = new SubtitleFilter(filename, type, (int)comboBoxVideoTracks.SelectedValue);
            }
            else
            {
                string filename = textBoxSubtitleFile.Text;
                SubtitleType type;
                switch (Path.GetExtension(filename))
                {
                    case ".sub":
                        type = SubtitleType.VobSub;
                        break;
                    case ".sup":
                        type = SubtitleType.PgsSub;
                        break;
                    default:
                        type = SubtitleType.TextSub;
                        break;
                }
                GeneratedFilter = new SubtitleFilter(filename, type);
            }
        }

        private void checkBoxInternalSubs_CheckedChanged(object sender, EventArgs e)
        {
            tableLayoutPanelSubtitleFileSelector.Visible = !checkBoxInternalSubs.Checked;
            comboBoxVideoTracks.Visible = checkBoxInternalSubs.Checked;
            label2.Text = checkBoxInternalSubs.Checked ? "Subtitle track:" : "Subtitle file:";
            checkBoxInternalSubs.Text = checkBoxInternalSubs.Checked ? "Yes" : "No";
        }

        private void buttonSelectSubtitleFile_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = Path.GetDirectoryName(Program.InputFile);
                dialog.Filter = "Text subtitles (*.ass, *.srt, *.ssa)|*.ass;*.srt;*.ssa|DVD subtitles (*.sub)|*.sub|Blu-Ray subtitles (*.sup)|*.sup";
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxSubtitleFile.Text = dialog.FileName;
                }
            }
        }

        private void SubtitleForm_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            checkBoxInternalSubs.Checked = false;
            textBoxSubtitleFile.Text = files[0];
        }

        private void SubtitleForm_DragEnter(object sender, DragEventArgs e)
        {
            var dataPresent = e.Data.GetDataPresent(DataFormats.FileDrop);
            e.Effect = dataPresent ? DragDropEffects.Copy : DragDropEffects.None;
        }
    }

    public class SubtitleFilter
    {
        public string FileName { get; }
        public SubtitleType Type { get; }
        public int Track { get; }

        public SubtitleFilter(string fileName, SubtitleType type, int track = -1)
        {
            FileName = fileName;
            Type = type;
            Track = track;
        }

        public override string ToString()
        {
            var conversion = Program.InputHasWeirdPixelFormat ? "ConvertToYV12() " : "";
            var shortFileName = GetCompatiblePath(FileName);

            switch (Type)
            {
                case SubtitleType.TextSub:
                    return conversion + $@"textsub(""{shortFileName}"")";
                case SubtitleType.VobSub:
                    return conversion + $@"vobsub(""{shortFileName}"")";
                case SubtitleType.PgsSub:
                    return conversion + $@"suptitle(""{FileName}"")";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
