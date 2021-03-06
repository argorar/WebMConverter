﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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
        private int newWidth = 0;
        private int newHeight = 0;
        private RectangleF cropPercent;
        private enum Corner
        {
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight,
            None
        }

        readonly CropFilter InputFilter;
        public CropFilter GeneratedFilter;

        public CropForm(CropFilter CropPixels = null)
        {
            InitializeComponent();

            InputFilter = CropPixels;
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
                int width, height;
                if ((Owner as MainForm).SarCompensate)
                {
                    width = (Owner as MainForm).SarWidth;
                    height = (Owner as MainForm).SarHeight;
                }
                else
                {
                    // Note that because we call this, the frame used by the PreviewFrame gets disposed. We need to call GeneratePreview after we're done with this.
                    FFMSSharp.Frame frame = Program.VideoSource.GetFrame(previewFrame.Frame);
                    width = frame.EncodedResolution.Width;
                    height = frame.EncodedResolution.Height;
                }

                cropPercent = new RectangleF(
                    (float)InputFilter.Left / width,
                    (float)InputFilter.Top / height,
                    (float)(width - InputFilter.Left + InputFilter.Right) / width,
                    (float)(height - InputFilter.Top + InputFilter.Bottom) / height
                );

                previewFrame.GeneratePreview(true);
            }

            if ((Owner as MainForm).boxAdvancedScripting.Checked) return;

            if (Filters.Trim != null)
            {
                previewFrame.Frame = Filters.Trim.TrimStart;
                trackVideoTimeline.Value = Filters.Trim.TrimStart;
                trimTimingToolStripMenuItem.Enabled = true;
            }
            if (Filters.MultipleTrim != null)
            {
                previewFrame.Frame = Filters.MultipleTrim.Trims[0].TrimStart;
                trackVideoTimeline.Value = Filters.MultipleTrim.Trims[0].TrimStart;
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
                float clampedMouseX = Math.Max(min.X, Math.Min(max.X, e.X));
                float clampedMouseY = Math.Max(min.Y, Math.Min(max.Y, e.Y));

                float newWidth = 0;
                float newHeight = 0;
                switch (heldCorner)
                {
                    case Corner.TopLeft:
                        newWidth = cropPercent.Width - (clampedMouseX / previewFrame.Picture.Width - cropPercent.X);
                        newHeight = cropPercent.Height - (clampedMouseY / previewFrame.Picture.Height - cropPercent.Y);
                        cropPercent.X = clampedMouseX / previewFrame.Picture.Width;
                        cropPercent.Y = clampedMouseY / previewFrame.Picture.Height;
                        break;

                    case Corner.TopRight:
                        newWidth = cropPercent.Width + (clampedMouseX / previewFrame.Picture.Width - cropPercent.Right);
                        newHeight = cropPercent.Height - (clampedMouseY / previewFrame.Picture.Height - cropPercent.Y);
                        cropPercent.Y = clampedMouseY / previewFrame.Picture.Height;
                        break;

                    case Corner.BottomLeft:
                        newWidth = cropPercent.Width - (clampedMouseX / previewFrame.Picture.Width - cropPercent.X);
                        newHeight = cropPercent.Height + (clampedMouseY / previewFrame.Picture.Height - cropPercent.Bottom);
                        cropPercent.X = clampedMouseX / previewFrame.Picture.Width;
                        break;

                    case Corner.BottomRight:
                        newWidth = cropPercent.Width + (clampedMouseX / previewFrame.Picture.Width - cropPercent.Right);
                        newHeight = cropPercent.Height + (clampedMouseY / previewFrame.Picture.Height - cropPercent.Bottom);
                        break;

                    case Corner.None: //Drag entire rectangle
                        //This is a special case, because the mouse needs to be clamped according to rectangle size too!
                        float actualRectW = cropPercent.Width * previewFrame.Picture.Width;
                        float actualRectH = cropPercent.Height * previewFrame.Picture.Height;
                        clampedMouseX = Math.Max(min.X - mouseOffset.X, Math.Min(max.X - mouseOffset.X - actualRectW, e.X));
                        clampedMouseY = Math.Max(min.Y - mouseOffset.Y, Math.Min(max.Y - mouseOffset.Y - actualRectH, e.Y));
                        cropPercent.X = (clampedMouseX + mouseOffset.X) / previewFrame.Picture.Width;
                        cropPercent.Y = (clampedMouseY + mouseOffset.Y) / previewFrame.Picture.Height;
                        break;
                }

                if (newWidth != 0)
                    cropPercent.Width = newWidth;
                if (newHeight != 0)
                    cropPercent.Height = newHeight;

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
                FFMSSharp.Frame frame = Program.VideoSource.GetFrame(previewFrame.Frame);
                width = frame.EncodedResolution.Width;
                height = frame.EncodedResolution.Height;
            }

            GenerateFilter(width , height);            

            DialogResult = DialogResult.OK;

            Close();
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
                newHeight == 0 ? cropBottom : CorrectCrop(cropTop, cropBottom, newHeight, height)
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

        private const float arrowKeyIncrement = 0.001f;
        private const float arrowKeyShiftIncrement = 0.01f;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    cropPercent.Y -= arrowKeyIncrement;
                    break;
                case Keys.Left:
                    cropPercent.X -= arrowKeyIncrement;
                    break;
                case Keys.Right:
                    cropPercent.X += arrowKeyIncrement;
                    break;
                case Keys.Down:
                    cropPercent.Y += arrowKeyIncrement;
                    break;
                case Keys.Shift | Keys.Up:
                    cropPercent.Y -= arrowKeyShiftIncrement;
                    break;
                case Keys.Shift | Keys.Left:
                    cropPercent.X -= arrowKeyShiftIncrement;
                    break;
                case Keys.Shift | Keys.Right:
                    cropPercent.X += arrowKeyShiftIncrement;
                    break;
                case Keys.Shift | Keys.Down:
                    cropPercent.Y += arrowKeyShiftIncrement;
                    break;
                case Keys.Alt | Keys.Up:
                    cropPercent.Height = Math.Max(0, cropPercent.Height - arrowKeyIncrement);
                    break;
                case Keys.Alt | Keys.Left:
                    cropPercent.Width = Math.Max(0, cropPercent.Width - arrowKeyIncrement);
                    break;
                case Keys.Alt | Keys.Right:
                    cropPercent.Width += arrowKeyIncrement;
                    break;
                case Keys.Alt | Keys.Down:
                    cropPercent.Height += arrowKeyIncrement;
                    break;
                case Keys.Alt | Keys.Shift | Keys.Up:
                    cropPercent.Height = Math.Max(0, cropPercent.Height - arrowKeyShiftIncrement);
                    break;
                case Keys.Alt | Keys.Shift | Keys.Left:
                    cropPercent.Width = Math.Max(0, cropPercent.Width - arrowKeyShiftIncrement);
                    break;
                case Keys.Alt | Keys.Shift | Keys.Right:
                    cropPercent.Width += arrowKeyShiftIncrement;
                    break;
                case Keys.Alt | Keys.Shift | Keys.Down:
                    cropPercent.Height += arrowKeyShiftIncrement;
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            ShowNewSize();
            previewFrame.Picture.Invalidate();
            return true;
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

        private void ShowNewSize()
        {
            float newWidth = Program.Resolution.Width * cropPercent.Width;
            float newHeight = Program.Resolution.Height * cropPercent.Height;
            if(newWidth > 0 && newHeight > 0)
                labelNewResolution.Text = $"New resolution: {newWidth.ToString("#.#")} x {newHeight.ToString("#.#")}";
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
                    cropPercent.Height = heightPercent;
                    cropPercent.Width = widhtPercent;
                    newWidth = dialog.GetWight();
                    newHeight = dialog.GetHeight();
                    previewFrame.GeneratePreview(true);
                }
            }
        }
    }

    public class CropFilter
    {
        public int Left { get; }
        public int Top { get; }
        public int Right { get; }
        public int Bottom { get; }

        public CropFilter(int left, int top, int right, int bottom)
        {
            int[] tempArray;
            tempArray = CorrectCrop(left, right);
            left = tempArray[0];
            right = tempArray[1];

            tempArray = CorrectCrop(top, bottom);
            top = tempArray[0];
            bottom = tempArray[1];

            Left = (left / 2) * 2;
            Top = (top / 2) * 2;
            Right = (right / 2) * 2;
            Bottom = (bottom / 2) * 2;
        }

        public override string ToString() => $"Crop({Left}, {Top}, {Right}, {Bottom})";
    }
}
