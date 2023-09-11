using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebMConverter
{
    public partial class PreviewFrame : UserControl
    {
        uint framenumber;
        FFMSSharp.Frame frame;
        int cachedframenumber;
        RotateFlipType rotateFlipType;
        Bitmap destImage;
        Rectangle destRect;
        int width, height, sizeW, sizeH, encodeW, encodeH;

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

                frame = Program.VideoSource.GetFrame((int)framenumber);

                if (frame.EncodedResolution.Width * frame.EncodedResolution.Height > 2073600) // 1080p (1920*1080)
                {
                    encodeW = frame.EncodedResolution.Width / 2;
                    encodeH = frame.EncodedResolution.Height / 2;
                }
                else
                {
                    encodeW = frame.EncodedResolution.Width;
                    encodeH = frame.EncodedResolution.Height;
                }
                               
                Program.VideoSource.SetOutputFormat(pixelformat, encodeW, encodeH, FFMSSharp.Resizer.BilinearFast);
            }

            cachedframenumber = -1;
            InitializeComponent();
        }

        protected void OnResize()
        {
            sizeW = Size.Width;
            sizeH = Size.Height;

            float scale = Math.Min((float)sizeW / encodeW, (float)sizeH / encodeH);
            width = FixValue((int)(encodeW * scale));
            height = FixValue((int)(encodeH * scale));
            // https://stackoverflow.com/a/24199315/174466
            destRect = new Rectangle(0, 0, width, height);
            destImage = new Bitmap(width, height);
        }


        public void GeneratePreview()
        {
            GeneratePreview(false);
        }


        private int FixValue(int number)
        {
            if (number % 2 == 0)
                return number;
            else
                return number - 1;
        }

        public void GeneratePreview(bool force)
        {

            if (Program.VideoSource == null)
                return;

            if (force)
                cachedframenumber = -1;

            if (MainForm.cache.ContainsKey((int)framenumber))
            {
                Picture.BackgroundImage = MainForm.cache[(int)framenumber];
                Picture.ClientSize = new Size(width, height);
                Picture.Refresh();
                SetPadding();
                return;
            }

            frame = Program.VideoSource.GetFrame((int)framenumber);

            if (destImage == null)
                OnResize();

            using (var graphics = Graphics.FromImage(destImage))
            {

                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighSpeed;
                graphics.InterpolationMode = InterpolationMode.Bilinear;
                graphics.SmoothingMode = SmoothingMode.HighSpeed;
                graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;                

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(frame.Bitmap, destRect, 0, 0, encodeW, encodeH, GraphicsUnit.Pixel, wrapMode);
                }
            }

            Purgecache();
            if (!MainForm.cache.ContainsKey((int)framenumber))
                MainForm.cache.TryAdd((int)framenumber, (Bitmap)destImage.Clone());

            Picture.BackgroundImage = destImage;
            Picture.Refresh();
            SetPadding();
            cachedframenumber = (int)framenumber;
        }

        async private void Purgecache()
        {
            await Task.Run(() =>
            {
                if (MainForm.cache.Count > MainForm.MAX_CAPACITY)
                {
                    MainForm.cache.TryRemove(MainForm.cache.Min(kvp => kvp.Key), out Bitmap old);
                }
            });
        }


        private void SetPadding()
        {
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
            if (Size.Width != sizeW || Size.Height != sizeH)
                OnResize();

            GeneratePreview();
        }

        public string SavePreview(string directory, string name)
        {
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            Encoder myEncoder = Encoder.Quality;
            ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            string filename = $"{directory}//{name}-{framenumber}.jpg";
            frame = Program.VideoSource.GetFrame((int)framenumber);
            frame.Bitmap.Save(filename, myImageCodecInfo, myEncoderParameters);
            return filename;
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
    }
}
