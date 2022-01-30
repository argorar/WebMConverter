using System;
using System.Drawing;
using System.Windows.Forms;
using WebMConverter.Dialogs;
using static WebMConverter.Utility;

namespace WebMConverter
{
    public partial class RotateForm : Form
    {
        public RotateFilter GeneratedFilter { get; set; }

        RotateFlipType rotateFlip;

        public RotateForm(RotateFilter filterToEdit)
        {
            InitializeComponent();

            switch (filterToEdit.Mode)
            {
                case RotateFilter.RotateMode.Right:
                    checkTurnRight.Checked = true;
                    break;
                case RotateFilter.RotateMode.Twice:
                    checkTurnTwice.Checked = true;
                    break;
                case RotateFilter.RotateMode.Left:
                    checkTurnLeft.Checked = true;
                    break;
            }
            checkFlipHorizontal.Checked = filterToEdit.FlipHorizontal;
            checkFlipVertical.Checked = filterToEdit.FlipVertical;
        }

        public RotateForm()
        {
            InitializeComponent();
        }

        private void RotateForm_Load(object sender, EventArgs e)
        {
            if ((Owner as MainForm).boxAdvancedScripting.Checked) return;

            if (Filters.Trim != null)
            {
                previewFrame.Frame = Filters.Trim.TrimStart;
                trimTimingToolStripMenuItem.Enabled = true;
            }
            if (Filters.MultipleTrim != null)
            {
                previewFrame.Frame = Filters.MultipleTrim.Trims[0].TrimStart;
            }

            rotatePictureFrame();
        }

        private void frameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new InputDialog<int>("Frame", previewFrame.Frame))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    previewFrame.Frame = Math.Max(0, Math.Min(Program.VideoSource.NumberOfFrames - 1, dialog.Value)); // Make sure we don't go out of bounds.
                }
            }
        }

        private void timeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new InputDialog<TimeSpan>("Time", FrameToTimeSpan(previewFrame.Frame)))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    int i = TimeSpanToFrame(dialog.Value);
                    i = Math.Max(0, Math.Min(Program.VideoSource.NumberOfFrames - 1, i)); // Make sure we don't go out of bounds.
                    previewFrame.Frame = i;
                }
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e) => previewFrame.Frame = Filters.Trim.TrimStart;
        private void endToolStripMenuItem_Click(object sender, EventArgs e) => previewFrame.Frame = Filters.Trim.TrimEnd;

        private void checkUpdate(object sender, EventArgs e)
        {
            if (ReferenceEquals(sender, checkTurnNormal) ||
                ReferenceEquals(sender, checkTurnRight) ||
                ReferenceEquals(sender, checkTurnTwice) ||
                ReferenceEquals(sender, checkTurnLeft))
            {
                checkTurnOnlyOne(sender, e);
            }

            rotatePictureFrame();
        }

        private void checkTurnOnlyOne(object sender, EventArgs e)
        {
            checkTurnNormal.CheckedChanged -= checkUpdate;
            checkTurnRight.CheckedChanged -= checkUpdate;
            checkTurnTwice.CheckedChanged -= checkUpdate;
            checkTurnLeft.CheckedChanged -= checkUpdate;

            if (!ReferenceEquals(sender, checkTurnNormal))
                checkTurnNormal.Checked = false;

            if (!ReferenceEquals(sender, checkTurnRight))
                checkTurnRight.Checked = false;

            if (!ReferenceEquals(sender, checkTurnTwice))
                checkTurnTwice.Checked = false;

            if (!ReferenceEquals(sender, checkTurnLeft))
                checkTurnLeft.Checked = false;

            if (!checkTurnNormal.Checked &&
                !checkTurnRight.Checked &&
                !checkTurnTwice.Checked &&
                !checkTurnLeft.Checked)
                checkTurnNormal.Checked = true;

            checkTurnNormal.CheckedChanged += checkUpdate;
            checkTurnRight.CheckedChanged += checkUpdate;
            checkTurnTwice.CheckedChanged += checkUpdate;
            checkTurnLeft.CheckedChanged += checkUpdate;
        }

        private void rotatePictureFrame()
        {
            rotateFlip = RotateFlipType.RotateNoneFlipNone;

            if (checkTurnRight.Checked)
                rotateFlip = RotateFlipType.Rotate90FlipNone;
            if (checkTurnTwice.Checked)
                rotateFlip = RotateFlipType.Rotate180FlipNone;
            if (checkTurnLeft.Checked)
                rotateFlip = RotateFlipType.Rotate270FlipNone;

            switch (rotateFlip)
            {
                case RotateFlipType.RotateNoneFlipNone:
                    if (checkFlipHorizontal.Checked && checkFlipVertical.Checked)
                        rotateFlip = RotateFlipType.RotateNoneFlipXY;
                    else if (checkFlipHorizontal.Checked)
                        rotateFlip = RotateFlipType.RotateNoneFlipX;
                    else if (checkFlipVertical.Checked)
                        rotateFlip = RotateFlipType.RotateNoneFlipY;
                    break;
                case RotateFlipType.Rotate90FlipNone:
                    if (checkFlipHorizontal.Checked && checkFlipVertical.Checked)
                        rotateFlip = RotateFlipType.Rotate90FlipXY;
                    else if(checkFlipHorizontal.Checked)
                        rotateFlip = RotateFlipType.Rotate90FlipX;
                    else if(checkFlipVertical.Checked)
                        rotateFlip = RotateFlipType.Rotate90FlipY;
                    break;
                case RotateFlipType.Rotate180FlipNone:
                    if (checkFlipHorizontal.Checked && checkFlipVertical.Checked)
                        rotateFlip = RotateFlipType.Rotate180FlipXY;
                    else if (checkFlipHorizontal.Checked)
                        rotateFlip = RotateFlipType.Rotate180FlipX;
                    else if (checkFlipVertical.Checked)
                        rotateFlip = RotateFlipType.Rotate180FlipY;
                    break;
                case RotateFlipType.Rotate270FlipNone:
                    if (checkFlipHorizontal.Checked && checkFlipVertical.Checked)
                        rotateFlip = RotateFlipType.Rotate270FlipXY;
                    else if (checkFlipHorizontal.Checked)
                        rotateFlip = RotateFlipType.Rotate270FlipX;
                    else if (checkFlipVertical.Checked)
                        rotateFlip = RotateFlipType.Rotate270FlipY;
                    break;
            }

            previewFrame.RotateFlip = rotateFlip;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            var mode = RotateFilter.RotateMode.None;

            if (checkTurnRight.Checked)
                mode = RotateFilter.RotateMode.Right;
            if (checkTurnTwice.Checked)
                mode = RotateFilter.RotateMode.Twice;
            if (checkTurnLeft.Checked)
                mode = RotateFilter.RotateMode.Left;

            GeneratedFilter = new RotateFilter(mode, checkFlipHorizontal.Checked, checkFlipVertical.Checked, rotateFlip);
            DialogResult = DialogResult.OK;
        }
    }

    public class RotateFilter
    {
        public RotateMode Mode { get; }
        public bool FlipHorizontal { get; }
        public bool FlipVertical { get; }
        public RotateFlipType rotation { get; }

        public RotateFilter(RotateMode mode, bool flipHorizontal, bool flipVertical, RotateFlipType rotateFlip)
        {
            Mode = mode;
            FlipHorizontal = flipHorizontal;
            FlipVertical = flipVertical;
            rotation = rotateFlip;
        }

        public override string ToString()
        {
            string command;

            switch (Mode)
            {
                default:
                    command = "";
                    break;
                case RotateMode.Right:
                    command = "TurnRight() ";
                    break;
                case RotateMode.Twice:
                    command = "TurnRight() TurnRight() ";
                    break;
                case RotateMode.Left:
                    command = "TurnLeft() ";
                    break;
            }

            if (FlipHorizontal)
            {
                command += "FlipHorizontal() ";
            }

            if (FlipVertical)
            {
                command += "FlipVertical()";
            }

            return command;
        }

        public enum RotateMode
        {
            None,
            Right,
            Twice,
            Left
        }
    }
}
