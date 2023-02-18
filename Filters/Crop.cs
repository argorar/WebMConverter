using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebMConverter.Dialogs;
using static WebMConverter.Utility;

namespace WebMConverter
{
    public partial class CropForm : Form
    {
        private Corner heldCorner = Corner.None;
        private bool held;
        private bool insideForm;
        private bool insideRectangle;
        private Point mousePos;
        private Point mouseOffset;
        private const int maxDistance = 6;
        private int newWidth;
        private int newHeight;
        private RectangleF cropPercent;
        private int currentFrame;
        private IDictionary<int, string> cropsList = new Dictionary<int, string>();
        private enum Corner
        {
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight,
            None
        }

        readonly CropFilter InputFilter;
        public CropFilter GeneratedFilter { get; set; }

        public DynamicCropFilter GeneratedCropPanFilter { get; set; }

        public CropForm(CropFilter CropPixels)
        {
            InitializeComponent();
            SetEvents();
            InputFilter = CropPixels;
        }

        public CropForm()
        {
            InitializeComponent();
            SetEvents();
        }

        private void SetEvents()
        {
            trackVideoTimeline.Maximum = Program.VideoSource.NumberOfFrames - 1;
            trackVideoTimeline.TickFrequency = trackVideoTimeline.Maximum / 60;

            previewFrame.Picture.Paint += new PaintEventHandler(previewPicture_Paint);
            previewFrame.Picture.MouseDown += new MouseEventHandler(previewPicture_MouseDown);
            previewFrame.Picture.MouseEnter += new EventHandler(previewPicture_MouseEnter);
            previewFrame.Picture.MouseLeave += new EventHandler(previewPicture_MouseLeave);
            previewFrame.Picture.MouseMove += new MouseEventHandler(previewPicture_MouseMove);
            previewFrame.Picture.MouseUp += new MouseEventHandler(previewPicture_MouseUp);

            trackVideoTimeline.MouseWheel += trackVideoTimeline_MouseWheel;
        }

        void CropForm_Load(object sender, EventArgs e)
        {
            if (InputFilter == null)
            {
                cropPercent = new RectangleF(0.25f, 0.25f, 0.5f, 0.5f);
            }
            else
            {
                currentFrame = 0;
                cropPercent = InputFilter.cropPercent;
                previewFrame.GeneratePreview(true);
            }

            if (Filters.Trim != null)
            {
                currentFrame = Filters.Trim.TrimStart;
                previewFrame.Frame = Filters.Trim.TrimStart;
                trackVideoTimeline.Value = Filters.Trim.TrimStart;
                trackVideoTimeline.Minimum = Filters.Trim.TrimStart;
                trackVideoTimeline.Maximum = Filters.Trim.TrimEnd;
                trimTimingToolStripMenuItem.Enabled = true;
            }
            if (Filters.MultipleTrim != null)
            {
                currentFrame = Filters.MultipleTrim.Trims[0].TrimStart;
                previewFrame.Frame = Filters.MultipleTrim.Trims[0].TrimStart;
                trackVideoTimeline.Value = Filters.MultipleTrim.Trims[0].TrimStart;
                trackVideoTimeline.Minimum = Filters.MultipleTrim.Trims[0].TrimStart;
                trackVideoTimeline.Maximum = Filters.MultipleTrim.Trims[Filters.MultipleTrim.Trims.Count - 1].TrimEnd;
                trimTimingToolStripMenuItem.Enabled = true;
            }
        }

        private void previewPicture_MouseDown(object sender, MouseEventArgs e)
        {
            //This checks the distance from the rectangle corner point to the mouse, and then selects the one with the smallest distance
            //That one will be dragged along with the mouse

            var closest = GetClosestPointDistance(new Point(e.X, e.Y));

            if (closest.Value < maxDistance * maxDistance) //Comparing squared distance
            {
                heldCorner = closest.Key;
                held = true;

            }
            else if (insideRectangle) //Or, if there's no closest dot and the mouse is inside the cropping rectangle, drag the entire rectangle
            {
                mouseOffset = new Point((int)(cropPercent.X * previewFrame.Picture.Width - e.X), (int)(cropPercent.Y * previewFrame.Picture.Height - e.Y));
                heldCorner = Corner.None;
                held = true;
            }

            previewFrame.Invalidate();
        }

        private KeyValuePair<Corner, float> GetClosestPointDistance(Point e)
        {
            var distances = new Dictionary<Corner, float>();
            distances[Corner.TopLeft] = (float)(Math.Pow(e.X - cropPercent.Left * previewFrame.Picture.Width, 2) + Math.Pow(e.Y - cropPercent.Top * previewFrame.Picture.Height, 2));
            distances[Corner.TopRight] = (float)(Math.Pow(e.X - cropPercent.Right * previewFrame.Picture.Width, 2) + Math.Pow(e.Y - cropPercent.Top * previewFrame.Picture.Height, 2));
            distances[Corner.BottomLeft] = (float)(Math.Pow(e.X - cropPercent.Left * previewFrame.Picture.Width, 2) + Math.Pow(e.Y - cropPercent.Bottom * previewFrame.Picture.Height, 2));
            distances[Corner.BottomRight] = (float)(Math.Pow(e.X - cropPercent.Right * previewFrame.Picture.Width, 2) + Math.Pow(e.Y - cropPercent.Bottom * previewFrame.Picture.Height, 2));

            return distances.OrderBy(a => a.Value).First();

        }

        private void previewPicture_MouseUp(object sender, MouseEventArgs e)
        {
            held = false;
            heldCorner = Corner.None;
            previewFrame.Picture.Invalidate();
        }

        private void previewPicture_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos = new Point(e.X, e.Y);
            insideRectangle = cropPercent.Contains((float)e.X / previewFrame.Picture.Width, (float)e.Y / previewFrame.Picture.Height);

            if (held)
            {
                //Here we change the size of the rectangle if the mouse is actually held down

                //Clamp mouse pos to picture box, that way you shouldn't be able to move the cropping rectangle out of bounds
                Point min = new Point(0, 0);
                Point max = new Point(previewFrame.Picture.Size);
                float clampedMouseX = Mod2(Math.Max(min.X, Math.Min(max.X, e.X)));
                float clampedMouseY = Mod2(Math.Max(min.Y, Math.Min(max.Y, e.Y)));

                if (dynamicCropActive.Checked)
                    GetCropPan();

                float tempWidth = 0;
                float tempHeight = 0;

                if (heldCorner == Corner.TopLeft)
                {
                    tempWidth = cropPercent.Width - (clampedMouseX / previewFrame.Picture.Width - cropPercent.X);
                    tempHeight = cropPercent.Height - (clampedMouseY / previewFrame.Picture.Height - cropPercent.Y);
                    cropPercent.X = clampedMouseX / previewFrame.Picture.Width;
                    cropPercent.Y = clampedMouseY / previewFrame.Picture.Height;
                }
                else if (heldCorner == Corner.TopRight)
                {
                    tempWidth = cropPercent.Width + (clampedMouseX / previewFrame.Picture.Width - cropPercent.Right);
                    tempHeight = cropPercent.Height - (clampedMouseY / previewFrame.Picture.Height - cropPercent.Y);
                    cropPercent.Y = clampedMouseY / previewFrame.Picture.Height;
                }
                else if (heldCorner == Corner.BottomLeft)
                {
                    tempWidth = cropPercent.Width - (clampedMouseX / previewFrame.Picture.Width - cropPercent.X);
                    tempHeight = cropPercent.Height + (clampedMouseY / previewFrame.Picture.Height - cropPercent.Bottom);
                    cropPercent.X = clampedMouseX / previewFrame.Picture.Width;
                }
                else if (heldCorner == Corner.BottomRight)
                {
                    tempWidth = cropPercent.Width + (clampedMouseX / previewFrame.Picture.Width - cropPercent.Right);
                    tempHeight = cropPercent.Height + (clampedMouseY / previewFrame.Picture.Height - cropPercent.Bottom);
                }
                else if (heldCorner == Corner.None)//Drag entire rectangle
                {
                    //This is a special case, because the mouse needs to be clamped according to rectangle size too!
                    float actualRectW = cropPercent.Width * previewFrame.Picture.Width;
                    float actualRectH = cropPercent.Height * previewFrame.Picture.Height;
                    clampedMouseX = Math.Max(min.X - mouseOffset.X, Math.Min(max.X - mouseOffset.X - actualRectW, e.X));
                    clampedMouseY = Math.Max(min.Y - mouseOffset.Y, Math.Min(max.Y - mouseOffset.Y - actualRectH, e.Y));
                    cropPercent.X = (clampedMouseX + mouseOffset.X) / previewFrame.Picture.Width;
                    cropPercent.Y = (clampedMouseY + mouseOffset.Y) / previewFrame.Picture.Height;
                }

                if (tempWidth > 0)
                    cropPercent.Width = tempWidth;
                if (tempHeight > 0)
                    cropPercent.Height = tempHeight;

                ShowNewSize();
            }
            previewFrame.Picture.Invalidate();
        }

        private void previewPicture_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var edgePen = new Pen(Color.White, 1f);
            var dotBrush = new SolidBrush(Color.White);
            var outsideBrush = new HatchBrush(HatchStyle.Percent50, Color.Transparent);

            var maxW = previewFrame.Picture.Width;
            var maxH = previewFrame.Picture.Height;
            var x = cropPercent.X * previewFrame.Picture.Width;
            var y = cropPercent.Y * previewFrame.Picture.Height;
            var w = cropPercent.Width * maxW;
            var h = cropPercent.Height * maxH;

            //Darken background
            g.FillRectangle(outsideBrush, 0, 0, maxW, y);
            g.FillRectangle(outsideBrush, 0, y, x, h);
            g.FillRectangle(outsideBrush, x + w, y, maxW - (x + w), h);
            g.FillRectangle(outsideBrush, 0, y + h, maxW, maxH);

            //Edge
            g.DrawRectangle(edgePen, x, y, w, h);

            if (insideForm) //Draw corner dots if mouse is inside the picture box
            {
                float diameter = 6;
                float diameterEdge = diameter * 2;

                g.FillEllipse(dotBrush, x - diameter / 2, y - diameter / 2, diameter, diameter);
                g.FillEllipse(dotBrush, x + w - diameter / 2, y - diameter / 2, diameter, diameter);
                g.FillEllipse(dotBrush, x - diameter / 2, y + h - diameter / 2, diameter, diameter);
                g.FillEllipse(dotBrush, x + w - diameter / 2, y + h - diameter / 2, diameter, diameter);

                var closest = GetClosestPointDistance(mousePos);
                if (closest.Value < maxDistance * maxDistance)  //Comparing squared distance to avoid worthless square roots
                {
                    Cursor = Cursors.Hand;
                    //Draw outlines on the dots to indicate they can be selected and moved
                    if (closest.Key == Corner.TopLeft) g.DrawEllipse(edgePen, x - diameterEdge / 2, y - diameterEdge / 2, diameterEdge, diameterEdge);
                    if (closest.Key == Corner.TopRight) g.DrawEllipse(edgePen, x + w - diameterEdge / 2, y - diameterEdge / 2, diameterEdge, diameterEdge);
                    if (closest.Key == Corner.BottomLeft) g.DrawEllipse(edgePen, x - diameterEdge / 2, y + h - diameterEdge / 2, diameterEdge, diameterEdge);
                    if (closest.Key == Corner.BottomRight) g.DrawEllipse(edgePen, x + w - diameterEdge / 2, y + h - diameterEdge / 2, diameterEdge, diameterEdge);
                }
                else if (insideRectangle)
                    Cursor = Cursors.SizeAll;
                else if (Cursor != Cursors.Default) //Reduntant???
                    Cursor = Cursors.Default;
            }
        }

        private void previewPicture_MouseEnter(object sender, EventArgs e)
        {
            insideForm = true;
            previewFrame.Picture.Invalidate();
        }

        private void previewPicture_MouseLeave(object sender, EventArgs e)
        {
            insideForm = false;
            previewFrame.Picture.Invalidate();
        }

        private void GetCropPan()
        {
            int width, height;
            if ((Owner as MainForm).SarCompensate)
            {
                width = (Owner as MainForm).SarWidth;
                height = (Owner as MainForm).SarHeight;
            }
            else
            {
                width = Program.Resolution.Width;
                height = Program.Resolution.Height;
            }
            AddCropPan(width, height);
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (cropPercent.Left >= cropPercent.Right || cropPercent.Top >= cropPercent.Bottom)
            {
                MessageBox.Show("You messed up your crop! Please try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cropPercent = new RectangleF(0.25f, 0.25f, 0.5f, 0.5f);
                return;
            }

            float tolerance = 0.1f; //Account for float inprecision

            if (cropPercent.Left < 0 - tolerance || cropPercent.Top < 0 - tolerance || cropPercent.Right > 1 + tolerance || cropPercent.Bottom > 1 + tolerance)
            {
                MessageBox.Show("Your crop is outside the valid range! Please try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cropPercent = new RectangleF(0.25f, 0.25f, 0.5f, 0.5f);
                return;
            }

            if (dynamicCropActive.Checked)
            {
                float finalWidth = Program.Resolution.Width * cropPercent.Width;
                float finalHeight = Program.Resolution.Height * cropPercent.Height;

                if (Math.Abs(finalHeight % 2) > 0.0001 && Math.Abs(finalWidth % 2) > 0.0001)
                {
                    MessageBox.Show("Fix your crop resolution, must be an even number.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
            cropPercent.X = Math.Max(0, cropPercent.X);
            cropPercent.Y = Math.Max(0, cropPercent.Y);
            if (cropPercent.Right > 1)
                cropPercent.Width = 1 - cropPercent.X;
            if (cropPercent.Bottom > 1)
                cropPercent.Height = 1 - cropPercent.Y;

            int width, height;
            if ((Owner as MainForm).SarCompensate)
            {
                width = (Owner as MainForm).SarWidth;
                height = (Owner as MainForm).SarHeight;
            }
            else
            {
                width = Program.Resolution.Width;
                height = Program.Resolution.Height;
            }

            if (dynamicCropActive.Checked)
                GenerateFilter(cropsList);
            else
                GenerateFilter(width , height);            

            DialogResult = DialogResult.OK;

            Close();
        }

        private void AddCropPan(int width, int height)
        {
            if (currentFrame + 1 > trackVideoTimeline.Maximum)
                return;

            int cropLeft = (int)(width * cropPercent.Left);
            int cropTop = (int)(height * cropPercent.Top);
            int cropRight = -(int)(width - width * cropPercent.Right);
            int cropBottom = -(int)(height - height * cropPercent.Bottom);

            cropLeft = (cropLeft / 2) * 2;
            cropRight = (cropRight / 2) * 2;
            cropTop = (cropTop / 2) * 2;
            cropBottom = (cropBottom / 2) * 2;

            int endFrame = Filters.Trim != null ? Filters.Trim.TrimEnd : currentFrame;

            bool initialFrame = Filters.Trim != null && Filters.Trim.TrimStart == currentFrame;

            string commands = $"Trim({currentFrame + ((currentFrame == 0) || initialFrame ? 0 : 1)}," +
                $"{(trackVideoTimeline.Value == currentFrame ? endFrame : trackVideoTimeline.Value)})" +
                $".Crop({cropLeft},{cropTop},{(newWidth == 0 ? cropRight : CorrectCrop(cropLeft, cropRight, newWidth, width))}," +
                $"{(newHeight == 0 ? cropBottom : CorrectCrop(cropTop, cropBottom, newHeight, height))})" +
                $".Spline64Resize({Mod2((int)(Program.Resolution.Width * cropPercent.Width))}," +
                $"{Mod2((int)(Program.Resolution.Height * cropPercent.Height))})";

            if (!cropsList.ContainsKey(currentFrame))
                cropsList.Add(currentFrame, commands);
            else
                cropsList[currentFrame] = commands;

            currentFrame = trackVideoTimeline.Value;
        }

        private void GenerateFilter(IDictionary<int, string> cropsList)
        {
            GeneratedCropPanFilter = new DynamicCropFilter(cropsList);
        }
        private void GenerateFilter(int width, int height)
        {
            int cropLeft = (int)(width * cropPercent.Left);
            int cropTop = (int)(height * cropPercent.Top);
            int cropRight = -(int)(width - width * cropPercent.Right);
            int cropBottom = -(int)(height - height * cropPercent.Bottom);

            GeneratedFilter = new CropFilter(
                cropLeft,
                cropTop,
                newWidth == 0 ? cropRight : CorrectCrop(cropLeft, cropRight, newWidth, width),
                newHeight == 0 ? cropBottom : CorrectCrop(cropTop, cropBottom, newHeight, height),
                cropPercent
            );
        }

        private void frameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new InputDialog<int>("Frame", previewFrame.Frame))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    int temp = Math.Max(0, Math.Min(Program.VideoSource.NumberOfFrames - 1, dialog.Value)); // Make sure we don't go out of bounds.
                    previewFrame.Frame = temp;
                    trackVideoTimeline.Value = temp;
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
                    trackVideoTimeline.Value = i;
                }
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e) => previewFrame.Frame = Filters.Trim.TrimStart;
        private void endToolStripMenuItem_Click(object sender, EventArgs e) => previewFrame.Frame = Filters.Trim.TrimEnd;

        private float GetTwoPixelsPercentWidth()
        {
            float width = (float)previewFrame.Picture.Size.Width;
            float encodeWidth = (float)Program.Resolution.Width;
            return ((width / encodeWidth / width) * 200) / 100;
        }

        private float GetTwoPixelsPercentHeight()
        {
            float height = (float)previewFrame.Picture.Size.Height;
            float encodeHeight = (float)Program.Resolution.Height;
            return ((height / encodeHeight / height) * 200) / 100;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            float keyIncrementWidth = GetTwoPixelsPercentWidth();
            float keyIncrementHeight = GetTwoPixelsPercentHeight();

            switch (keyData)
            {
                case Keys.Up:
                    cropPercent.Y -= keyIncrementHeight;
                    break;
                case Keys.Left:
                    cropPercent.X -= keyIncrementWidth;
                    break;
                case Keys.Right:
                    if (cropPercent.Width + keyIncrementWidth + cropPercent.X < 1)
                        cropPercent.X += keyIncrementWidth;
                    break;
                case Keys.Down:
                    if (cropPercent.Height + keyIncrementHeight + cropPercent.Y < 1)
                        cropPercent.Y += keyIncrementHeight;
                    break;
                case Keys.Shift | Keys.Up:
                    cropPercent.Y -= keyIncrementHeight * 2;
                    break;
                case Keys.Shift | Keys.Left:
                    cropPercent.X -= keyIncrementWidth * 2;
                    break;
                case Keys.Shift | Keys.Right:
                    if (cropPercent.Width + (keyIncrementWidth * 2) + cropPercent.X < 1)
                        cropPercent.X += keyIncrementWidth * 2;
                    break;
                case Keys.Shift | Keys.Down:
                    if (cropPercent.Height + (keyIncrementHeight * 2) + cropPercent.Y < 1)
                        cropPercent.Y += keyIncrementHeight;
                    break;
                case Keys.Alt | Keys.Up:
                    cropPercent.Height = Math.Max(0, cropPercent.Height - keyIncrementHeight);
                    break;
                case Keys.Alt | Keys.Left:
                    cropPercent.Width = Math.Max(0, cropPercent.Width - keyIncrementWidth);
                    break;
                case Keys.Alt | Keys.Right:
                    if (cropPercent.Width + keyIncrementWidth + cropPercent.X < 1)
                        cropPercent.Width += keyIncrementWidth;
                    break;
                case Keys.Alt | Keys.Down:
                    if (cropPercent.Height + keyIncrementHeight + cropPercent.Y < 1)
                        cropPercent.Height += keyIncrementHeight;
                    break;
                case Keys.Alt | Keys.Shift | Keys.Up:
                    cropPercent.Height = Math.Max(0, cropPercent.Height - (keyIncrementHeight * 2));
                    break;
                case Keys.Alt | Keys.Shift | Keys.Left:
                    cropPercent.Width = Math.Max(0, cropPercent.Width - (keyIncrementWidth * 2));
                    break;
                case Keys.Alt | Keys.Shift | Keys.Right:
                    if (cropPercent.Width + (keyIncrementWidth * 2) + cropPercent.X < 1)
                        cropPercent.Width += (keyIncrementWidth * 2);
                    break;
                case Keys.Alt | Keys.Shift | Keys.Down:
                    if(cropPercent.Height + (keyIncrementHeight * 2) + cropPercent.Y < 1 )
                        cropPercent.Height += (keyIncrementHeight * 2);
                    break;
                case Keys.Control | Keys.Left:
                    KeepAspectRatioDecrease(keyIncrementWidth, keyIncrementHeight);
                    break;
                case Keys.Control | Keys.Up:
                    KeepAspectRatioDecrease(keyIncrementWidth, keyIncrementHeight);
                    break;
                case Keys.Control | Keys.Right:
                    KeepAspectRatioIncrease(keyIncrementWidth, keyIncrementHeight);
                    break;
                case Keys.Control | Keys.Down:
                    KeepAspectRatioIncrease(keyIncrementWidth, keyIncrementHeight);
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }

            cropPercent.X = Math.Max(0, cropPercent.X);
            cropPercent.Y = Math.Max(0, cropPercent.Y);

            ShowNewSize();
            previewFrame.Picture.Invalidate();

            if (dynamicCropActive.Checked)
                GetCropPan();

            return true;
        }

        private void KeepAspectRatioIncrease(float keyIncrementWidth, float keyIncrementHeight)
        {
            if (MainForm.aspectRatio == AspectRatio.NineSixteen)
            {
                var tempW = (keyIncrementWidth / 2) * 9;
                var tempH = (keyIncrementHeight / 2) * 16;

                if (cropPercent.Width + tempW + cropPercent.X < 1 && cropPercent.Height + tempH + cropPercent.Y < 1)
                {
                    cropPercent.Width += tempW;
                    cropPercent.Height += tempH;
                }
            }
            else if (MainForm.aspectRatio == AspectRatio.SixteenNine)
            {
                var tempW = (keyIncrementWidth / 2) * 16;
                var tempH = (keyIncrementHeight / 2) * 9;

                if (cropPercent.Width + tempW + cropPercent.X < 1 && cropPercent.Height + tempH + cropPercent.Y < 1)
                {
                    cropPercent.Width += tempW;
                    cropPercent.Height += tempH;
                }
            }
            else if ((MainForm.aspectRatio == AspectRatio.OneOne || MainForm.aspectRatio == AspectRatio.None) 
                                                    && cropPercent.Width + keyIncrementWidth + cropPercent.X < 1
                                                    && cropPercent.Height + keyIncrementHeight + cropPercent.Y < 1)
            {
                cropPercent.Width += keyIncrementWidth;
                cropPercent.Height += keyIncrementHeight;
            }
        }

        private void KeepAspectRatioDecrease(float keyIncrementWidth, float keyIncrementHeight)
        {
            if(MainForm.aspectRatio == AspectRatio.NineSixteen)
            {
                var tempW = (keyIncrementWidth / 2) * 9;
                var tempH = (keyIncrementHeight / 2) * 16;

                if (cropPercent.Width - tempW > 0 && cropPercent.Height - tempH > 0)
                {
                    cropPercent.Width -= tempW;
                    cropPercent.Height -= tempH;
                }
            }
            else if (MainForm.aspectRatio == AspectRatio.SixteenNine)
            {
                var tempW = (keyIncrementWidth / 2) * 16;
                var tempH = (keyIncrementHeight / 2) * 9;

                if (cropPercent.Width - tempW > 0 && cropPercent.Height - tempH > 0)
                {
                    cropPercent.Width -= tempW;
                    cropPercent.Height -= tempH;
                }
            }
            else if ((MainForm.aspectRatio == AspectRatio.OneOne || MainForm.aspectRatio == AspectRatio.None)
                                                                && cropPercent.Width - keyIncrementWidth > 0 
                                                                && cropPercent.Height - keyIncrementHeight > 0)
            {
                cropPercent.Width -= keyIncrementWidth;
                cropPercent.Height -= keyIncrementHeight;
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

        void SetFrame(int frame, bool modifier = false)
        {
            if (modifier)
                frame += trackVideoTimeline.Value;

            trackVideoTimeline.Value = Math.Max(0, Math.Min(trackVideoTimeline.Maximum, frame)); // Make sure we don't go out of bounds.
        }

        private void trackVideoTimeline_ValueChanged(object sender, EventArgs e)
        {
            previewFrame.Frame = trackVideoTimeline.Value;
            previewFrame.Refresh();
        }

        private void trackVideoTimeline_KeyDown(object sender, KeyEventArgs e)
        {
            int modifier = 0;

            if(e.KeyData == Keys.Left)
                modifier = -1;

            else if (e.KeyData == Keys.Right)
                modifier = 1;

            if (modifier != 0)
            {
                SetFrame(modifier, true);
                e.Handled = true;
            }
        }

        private void ShowNewSize()
        {
            float finalWidth = Program.Resolution.Width * cropPercent.Width;
            float finalHeight = Program.Resolution.Height * cropPercent.Height;
            if(finalWidth > 0 && finalHeight > 0)
                labelNewResolution.Text = $"New resolution: {finalWidth.ToString("#.#")} x {finalHeight.ToString("#.#")}";
        }

        private void setNewSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SetDimensionsDialog())
            {
                dialog.ShowDialog();
                var widhtPercent = dialog.GetWightPercent();
                var heightPercent = dialog.GetHeightPercent();
                if (widhtPercent != 0 && heightPercent != 0)
                {
                    cropPercent.X = 0;
                    cropPercent.Y = 0;
                    cropPercent.Height = heightPercent;
                    cropPercent.Width = widhtPercent;
                    newWidth = dialog.GetWight();
                    newHeight = dialog.GetHeight();
                    previewFrame.GeneratePreview(true);
                }
            }
        }

        private void dynamicCropActive_CheckedChanged(object sender, EventArgs e)
        {
            dynamicCropActive.ForeColor = dynamicCropActive.Checked ? Color.Green : Color.Black;

        }

    }

    public class CropFilter
    {
        public int Left { get; }
        public int Top { get; }
        public int Right { get; }
        public int Bottom { get; }
        public RectangleF cropPercent { get; }
        public int finalHeight { get; } 
        public int finalWidth { get; } 

        public CropFilter(int left, int top, int right, int bottom, RectangleF cropPercentFilter)
        {
            cropPercent = cropPercentFilter;

            finalWidth = (int)(Program.Resolution.Width* cropPercent.Width);
            finalHeight = (int)(Program.Resolution.Height * cropPercent.Height);

            int[] tempArray;
            tempArray = CorrectCrop(left, right);
            left = tempArray[0];
            right = tempArray[1];

            tempArray = CorrectCrop(top, bottom);
            top = tempArray[0] < 0 ? 0 : tempArray[0];
            bottom = tempArray[1];

            Left = left < 0 ? 0 : (left > 0 && left % 2 != 0 ? left - 1 : left);
            Top = top < 0 ? 0 : (top > 0 && top % 2 != 0 ? top - 1 : top);
            Right = right < 0 && right % 2 != 0 ? right - 1 : right;
            Bottom = bottom < 0 && bottom % 2 != 0 ? bottom - 1 : bottom;
        }

        public override string ToString() => $"Crop({Left}, {Top}, {Right}, {Bottom})";
    }

    public class DynamicCropFilter
    {
        private readonly StringBuilder fragments = new StringBuilder();
        private readonly StringBuilder alignFragments = new StringBuilder();

        public DynamicCropFilter(IDictionary<int, string> cropsList)
        {
            alignFragments.Append("UnalignedSplice(");
            foreach (KeyValuePair<int, string> entry in cropsList)
            {
                fragments.AppendLine($"D{entry.Key}={entry.Value}");
                alignFragments.Append($"D{entry.Key},");
            }

            alignFragments.Append(")").Replace(",)",")");
        }

        public override string ToString() => $"{fragments} \n {alignFragments}";
    }
}
