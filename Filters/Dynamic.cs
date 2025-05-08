﻿using System;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WebMConverter.Dialogs;
using static WebMConverter.Utility;
using System.Collections;
using WebMConverter.Objects;
using System.Text;
using System.Collections.Generic;

namespace WebMConverter
{
    public partial class DynamicForm : Form
    {
        private int trimStart;
        private int trimEnd;
        private double initialTime;
        private double finalTime;
        public DynamicFilter GeneratedFilter { get; set; }
        private SortedList points = new SortedList();

        public DynamicForm(TrimFilter FilterToEdit)
        {
            InitializeComponent();
            InitialValues(FilterToEdit);
            InsertInitialPoints(FilterToEdit);
        }

        public DynamicForm(TrimFilter FilterToEdit, DynamicFilter dynamicFilter)
        {
            InitializeComponent();
            InitialValues(FilterToEdit);
            InsertInitialPoints(FilterToEdit, dynamicFilter);
            ShowPoints();
            buttonRemove.Visible = true;
        }

        private void InitialValues(TrimFilter FilterToEdit)
        {
            trackVideoTimeline.TickFrequency = trackVideoTimeline.Maximum / 60;

            var tempFilter = FilterToEdit == null ? Filters.Trim : FilterToEdit;
            trackVideoTimeline.Minimum = tempFilter.TrimStart;
            trackVideoTimeline.Maximum = tempFilter.TrimEnd;
            labelTimeStamp.Text = FrameToTimeStamp(trackVideoTimeline.Value);
            previewFrame.Frame = tempFilter.TrimStart;
            trackVideoTimeline.Value = tempFilter.TrimStart;
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

            
            labelTrimEnd.Text = $"{FrameToTimeStamp(trimEnd)} ({trimEnd})";

            trackVideoTimeline.Value = trimStart;
            previewFrame.Frame = trimStart;
            labelTimeStamp.Text = $"{FrameToTimeStamp(trackVideoTimeline.Value)} ({trackVideoTimeline.Value})";

            checktrims();            

            trackVideoTimeline.MouseWheel += trackVideoTimeline_MouseWheel;
            toolStripMenuSave.Click += ToolStripMenuSave_Click;
            previewFrame.Picture.Paint += new PaintEventHandler(previewPicture_Paint);

            menuStrip1.Visible = false;
            labelTrimEnd.Visible = false;
            label1.Visible = false;
            labelTrimDuration.Visible = false;
            buttonRemove.Visible = false;
        }

        private void ShowPoints()
        {
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < points.Count; i++)
                text.Append((int)points.GetKey(i) + ((i >= 0 && i < points.Count - 1) ? " - " : string.Empty));
            labelPoints.Text = $"Points({text})";
        }

        private void InsertInitialPoints(TrimFilter filterToEdit, DynamicFilter dynamicFilter)
        {
            initialTime = (double)Program.VideoSource.Track.GetFrameInfo(filterToEdit.TrimStart).PTS
                            / (double)Program.VideoSource.Track.TimeBaseDenominator;

            finalTime = (double)Program.VideoSource.Track.GetFrameInfo(filterToEdit.TrimEnd).PTS
                          / (double)Program.VideoSource.Track.TimeBaseDenominator;

            points = dynamicFilter.Points;
        }

        private void InsertInitialPoints(TrimFilter filterToEdit)
        {
            initialTime = (double)Program.VideoSource.Track.GetFrameInfo(filterToEdit.TrimStart).PTS 
                            / (double)Program.VideoSource.Track.TimeBaseDenominator;

            finalTime = (double)Program.VideoSource.Track.GetFrameInfo(filterToEdit.TrimEnd).PTS
                          / (double)Program.VideoSource.Track.TimeBaseDenominator;

            points.Add(filterToEdit.TrimStart, new SpeedPoint(initialTime, 1));
            points.Add(filterToEdit.TrimEnd, new SpeedPoint(finalTime, 1));
        }

        private void previewPicture_Paint(object sender, PaintEventArgs e)
        {

            var g = e.Graphics;
            var edgePen = new Pen(Color.White, 2f);
            var dotBrush = new SolidBrush(Color.Red);
            var outsideBrush = new HatchBrush(HatchStyle.Percent70, Color.Transparent);

            PointF[] drawPoints = new PointF[points.Count];

            var h = previewFrame.Picture.Size.Height;
            var w = previewFrame.Picture.Size.Width;
            List<PointF> polygon = new List<PointF>();
            polygon.Add(new PointF(0, h));

            for (int i = 0; i < points.Count; i++)
            {
                SpeedPoint point = (SpeedPoint)points.GetByIndex(i);
                int keyFrame = (int)points.GetKey(i);
                float x = ((((float)keyFrame - trimStart) * 100) / (trimEnd - trimStart)) / 100 * w;
                float y = (h * (1 - (float)point.Speed)) / 2 + h / 2;
                var pointF = new PointF(x, y);
                drawPoints[i] = pointF;
                polygon.Add(pointF);
            }
            
            polygon.Add(new PointF( w, h));
            polygon.Add(new PointF(0, h));
            
            g.FillPolygon(outsideBrush, polygon.ToArray());
            g.DrawLines(edgePen, drawPoints);

            float diameter = 6;

            foreach(PointF p in drawPoints)
                g.FillEllipse(dotBrush, p.X - 3, p.Y - 3, diameter, diameter);
        }

        private void buttonAddPoint_Click(object sender, EventArgs e)
        {
            using (var dialog = new RateDynamicForm())
            {
                if (points.ContainsKey(trackVideoTimeline.Value))
                {
                    SpeedPoint s = (SpeedPoint)points[trackVideoTimeline.Value];
                    dialog.speed = (int)(s.Speed * 100);
                }

                dialog.ShowDialog();

                if(dialog.speed > 0 && dialog.general)
                {
                    var initialFrame = trackVideoTimeline.Minimum;
                    var lastFrame = trackVideoTimeline.Maximum;

                    var initialTime = (double)Program.VideoSource.Track.GetFrameInfo(initialFrame).PTS
                                    / (double)Program.VideoSource.Track.TimeBaseDenominator;
                    var lastTime = (double)Program.VideoSource.Track.GetFrameInfo(lastFrame).PTS
                                    / (double)Program.VideoSource.Track.TimeBaseDenominator;

                    if (points.ContainsKey(initialFrame))
                        points.Remove(initialFrame);

                    if (points.ContainsKey(lastFrame))
                        points.Remove(lastFrame);

                    points.Add(initialFrame, new SpeedPoint(initialTime, (double)dialog.speed / 100));
                    points.Add(lastFrame, new SpeedPoint(lastTime, (double)dialog.speed / 100));
                        
                }
                else if(dialog.speed > 0)
                {
                    var currentFrame = trackVideoTimeline.Value;

                    var currentTime = (double)Program.VideoSource.Track.GetFrameInfo(currentFrame).PTS
                                    / (double)Program.VideoSource.Track.TimeBaseDenominator;

                    if (points.ContainsKey(trackVideoTimeline.Value))
                    {
                        points.Remove(trackVideoTimeline.Value);
                        points.Add(trackVideoTimeline.Value, new SpeedPoint(currentTime, (double)dialog.speed / 100));
                    }
                    else
                        points.Add(trackVideoTimeline.Value, new SpeedPoint(currentTime, (double)dialog.speed / 100));

                }
                ShowPoints();
                buttonRemove.Visible = true;
                previewFrame.Picture.Invalidate();
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            using (var dialog = new PointsListForm(points))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    points = dialog.newList;
                    previewFrame.Picture.Refresh();
                    ShowPoints();
                }
            }
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
            GeneratedFilter = new DynamicFilter(points);
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

            previewFrame.Picture.Invalidate();
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

    public class DynamicFilter
    {
        public SortedList Points { get; }

        public DynamicFilter(SortedList list)
        {
            Points = list;
        }

        public String Argument()
        {
            StringBuilder setpts = new StringBuilder();
            SpeedPoint point = (SpeedPoint)Points.GetByIndex(0);
            double speedMapStartTime = point.Time;
            double startSpeed, endSpeed, sectionStart, sectionEnd, sectionDuration;

            SpeedPoint left;
            SpeedPoint right;

            for (int i = 0; i < Points.Count - 1; i += 1)
            {
                left = (SpeedPoint)Points.GetByIndex(i);
                right = (SpeedPoint)Points.GetByIndex(i + 1);

                startSpeed = left.Speed;
                endSpeed = right.Speed;
                double speedChange = endSpeed - startSpeed;

                sectionStart = left.Time - speedMapStartTime;
                sectionEnd = right.Time - speedMapStartTime;
                sectionDuration = sectionEnd - sectionStart;

                var x = speedChange / sectionDuration;
                var y = startSpeed - x * sectionStart;

                var sliceDuration = string.Empty;
                if (speedChange == 0)
                {
                    sliceDuration = $"(min((T-STARTT-({D(sectionStart)})),{D(sectionDuration)})/{D(endSpeed)})";
                }
                else
                {
                    sliceDuration = $"(1/{D(x)})*(log(abs({D(x)}*min((T-STARTT),{D(sectionEnd)})" +
                                    $"+({D(y)})))-log(abs({D(x)}*{D(sectionStart)}+({D(y)}))))";
                }

                sliceDuration = $"if(gte((T-STARTT),{D(sectionStart)}), {sliceDuration},0)";

                if (i == 0)
                {
                    setpts.Append($"(if(eq(N,0),0,{sliceDuration}))");
                }
                else
                {
                    setpts.Append($"+({sliceDuration})");
                }
            }
            return $"setpts='({setpts})/TB'";
        }
    }
}
