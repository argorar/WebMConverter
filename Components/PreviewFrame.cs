using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace WebMConverter
{
    public partial class PreviewFrame : UserControl
    {
        uint framenumber;
        FFMSSharp.Frame frame;
        int cachedframenumber;
        RotateFlipType rotateFlipType;

        [DefaultValue(0)]
        public int Frame
        {
            get { return (int)framenumber; }
            set { framenumber = (uint)value; GeneratePreview(); }
        }

        [DefaultValue(RotateFlipType.RotateNoneFlipNone)]
        public RotateFlipType RotateFlip
        {
            get { return rotateFlipType; }
            set { rotateFlipType = value; GeneratePreview(); }
        }

        public PreviewFrame()
        {
            if (Program.VideoSource != null)
            {
                // Prepare our "list" of accepted pixel formats
                List<int> pixelformat = new List<int>();
                pixelformat.Add(FFMSSharp.FFMS2.GetPixelFormat("bgra"));

                var infoframe = Program.VideoSource.GetFrame((int)framenumber);
                Program.VideoSource.SetOutputFormat(pixelformat, infoframe.EncodedResolution.Width, infoframe.EncodedResolution.Height, FFMSSharp.Resizer.Bilinear);
            }

            cachedframenumber = -1;

            InitializeComponent();
        }

        public void GeneratePreview(bool force = false)
        {
            if (Program.VideoSource == null)
                return;

            if (force)
                cachedframenumber = -1;

            // Load the frame, if we haven't already
            if (cachedframenumber != framenumber)
            {
                cachedframenumber = (int)framenumber;
                frame = Program.VideoSource.GetFrame(cachedframenumber);
            }

            // Calculate width and height
            int width, height;
            float scale;
            scale = Math.Min((float)Size.Width / frame.EncodedResolution.Width, (float)Size.Height / frame.EncodedResolution.Height);
            width = (int)(frame.EncodedResolution.Width * scale);
            height = (int)(frame.EncodedResolution.Height * scale);

            // https://stackoverflow.com/a/24199315/174466
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(frame.EncodedResolution.Width, frame.EncodedResolution.Height);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(frame.Bitmap, destRect, 0, 0, frame.EncodedResolution.Width, frame.EncodedResolution.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            destImage.RotateFlip(rotateFlipType);

            Picture.BackgroundImage = destImage;
            Picture.ClientSize = new Size(width, height);

            // Center the pictureBox in our control
            if (width == Width || width - 1 == Width || width + 1 == Width) // this looks weird but keep in mind we're dealing with an ex float here
            {
                Padding = new Padding(0, (Height - height) / 2, 0, 0);
            }
            else
            {
                Padding = new Padding((Width - width) / 2, 0, 0, 0);
            }
        }

        void pictureBoxFrame_SizeChanged(object sender, EventArgs e)
        {
            GeneratePreview();
        }
    }
}
