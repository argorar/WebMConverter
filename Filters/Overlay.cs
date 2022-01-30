using System;
using System.Drawing;
using System.Windows.Forms;
using WebMConverter.Dialogs;
using static WebMConverter.Utility;

namespace WebMConverter
{
    public partial class OverlayForm : Form
    {
        readonly OverlayFilter InputFilter;
        public OverlayFilter GeneratedFilter { get; set; }

        Point point;
        string filename;

        Size videoResolution;
        Point held;
        Point beforeheld;
        Bitmap picture;

        public OverlayForm(OverlayFilter filterToEdit)
        {
            InitializeComponent();

            InputFilter = filterToEdit;

            SetEvents();
        }

        public OverlayForm()
        {
            InitializeComponent();
            SetEvents();
        }

        private void SetEvents()
        {
            previewFrame.Picture.Paint += new PaintEventHandler(previewPicture_Paint);
            previewFrame.Picture.MouseDown += new MouseEventHandler(previewPicture_MouseDown);
            previewFrame.Picture.MouseMove += new MouseEventHandler(previewPicture_MouseMove);
        }

        void OverlayForm_Load(object sender, EventArgs e)
        {
            if (InputFilter == null)
            {
                if (filePicker.ShowDialog(this) == DialogResult.Cancel)
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }
                filename = filePicker.FileName;
                point = new Point(0, 0);
            }
            else
            {
                filename = InputFilter.FileName;
                point = InputFilter.Placement;
            }
            picture = new Bitmap(filename);

            if ((Owner as MainForm).SarCompensate)
            {
                videoResolution = new Size((Owner as MainForm).SarWidth, (Owner as MainForm).SarHeight);
            }
            else
            {
                FFMSSharp.Frame frame = Program.VideoSource.GetFrame(previewFrame.Frame);
                videoResolution = frame.EncodedResolution;
                previewFrame.GeneratePreview(true);
            }

            if ((Owner as MainForm).boxAdvancedScripting.Checked) return;

            if (Filters.Trim != null)
            {
                previewFrame.Frame = Filters.Trim.TrimStart;
                trimTimingToolStripMenuItem.Enabled = true;
            }
            if (Filters.MultipleTrim != null)
            {
                previewFrame.Frame = Filters.MultipleTrim.Trims[0].TrimStart;
                trimTimingToolStripMenuItem.Enabled = true;
            }
        }

        Point getBasePoint(PictureBox pictureBox)
        {
            int basex = pictureBox.Size.Width == pictureBox.ClientSize.Width ? 0 : pictureBox.Size.Width - pictureBox.ClientSize.Width / 2;
            int basey = pictureBox.Size.Height == pictureBox.ClientSize.Height ? 0 : pictureBox.Size.Height - pictureBox.ClientSize.Height / 2;

            return new Point(basex, basey);
        }

        float getPictureScale(PictureBox pictureBox)
        {
            return (float)pictureBox.ClientSize.Width / videoResolution.Width;
        }

        void previewPicture_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            var pictureBox = sender as PictureBox;

            var basePoint = getBasePoint(pictureBox);
            var scale = getPictureScale(pictureBox);

            var scaledPoint = new Point(basePoint.X + (int)(point.X * scale), basePoint.Y + (int)(point.Y * scale));

            g.DrawImage(picture, scaledPoint.X, scaledPoint.Y, picture.Width * scale, picture.Height * scale);
        }

        void previewPicture_MouseDown(object sender, MouseEventArgs e)
        {
            held = e.Location;
            beforeheld = point;

            previewPicture_MouseMove(sender, e);
        }

        void previewPicture_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.None)
                return;

            var scale = getPictureScale(previewFrame.Picture);

            point.X = beforeheld.X + (int)((e.X - held.X) / scale);
            point.Y = beforeheld.Y + (int)((e.Y - held.Y) / scale);

            previewFrame.Picture.Invalidate();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            GeneratedFilter = new OverlayFilter(point, filename);

            DialogResult = DialogResult.OK;
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            previewFrame.Frame = Filters.Trim.TrimStart;
        }

        private void endToolStripMenuItem_Click(object sender, EventArgs e)
        {
            previewFrame.Frame = Filters.Trim.TrimEnd;
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

        private const int arrowKeyIncrement = 1;
        private const int arrowKeyShiftIncrement = 10;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    point.Y -= arrowKeyIncrement;
                    break;
                case Keys.Left:
                    point.X -= arrowKeyIncrement;
                    break;
                case Keys.Right:
                    point.X += arrowKeyIncrement;
                    break;
                case Keys.Down:
                    point.Y += arrowKeyIncrement;
                    break;
                case Keys.Shift | Keys.Up:
                    point.Y -= arrowKeyShiftIncrement;
                    break;
                case Keys.Shift | Keys.Left:
                    point.X -= arrowKeyShiftIncrement;
                    break;
                case Keys.Shift | Keys.Right:
                    point.X += arrowKeyShiftIncrement;
                    break;
                case Keys.Shift | Keys.Down:
                    point.Y += arrowKeyShiftIncrement;
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }

            previewFrame.Picture.Invalidate();
            return true;
        }
    }

    public class OverlayFilter
    {
        public Point Placement { get; }
        public string FileName { get; }

        public OverlayFilter(Point placement, string fileName)
        {
            Placement = placement;
            FileName = fileName;
        }

        public override string ToString()
        {
            var shortFileName = GetCompatiblePath(FileName);
            return $"Overlay(ImageSource(\"{shortFileName}\"), x={Placement.X}, y={Placement.Y}, mask=ImageSource(\"{shortFileName}\",pixel_type=\"RGB32\").ShowAlpha(pixel_type=\"RGB32\"))";
        }
    }
}
