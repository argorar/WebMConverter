using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebMConverter.Objects;

namespace WebMConverter
{
    #region Filters

    static class Filters
    {
        internal static CaptionFilter Caption;
        internal static CropFilter Crop;
        internal static DeinterlaceFilter Deinterlace;
        internal static DelayAudio DelayAudio;
        internal static DenoiseFilter Denoise;
        internal static DubFilter Dub;
        internal static FadeFilter Fade;
        internal static MultipleTrimFilter MultipleTrim;
        internal static OverlayFilter Overlay;
        internal static RateFilter Rate;
        internal static ResizeFilter Resize;
        internal static ReverseFilter Reverse;
        internal static RotateFilter Rotate;
        internal static SubtitleFilter Subtitle;
        internal static TrimFilter Trim;

        internal static void ResetFilters()
        {
            Caption = null;
            Crop = null;
            Deinterlace = null;
            DelayAudio = null;
            Denoise = null;
            Dub = null;
            Fade = null;
            MultipleTrim = null;
            Overlay = null;
            Rate = null;
            Resize = null;
            Reverse = null;
            Rotate = null;
            Subtitle = null;
            Trim = null;
        }
    }
    
    #endregion

    static class Program
    {
        public static FFMSSharp.VideoSource VideoSource;
        public static FFMSSharp.ColorRange VideoColorRange;
        public static Size Resolution;
        public static bool VideoInterlaced;
        public static string InputFile;
        public static FileType InputType;
        public static bool InputHasAudio;
        public static bool InputHasWeirdPixelFormat; // for something that xy-VSFilter can't render on
        public static string FileMd5;
        public static string AttachmentDirectory;
        public static Dictionary<int, Tuple<string, SubtitleType, string>> SubtitleTracks; // stream id, <tag:title OR codec_name, textsub/vobsub, extension>
        public static List<string> AttachmentList;
        public static string token;
        public static StabilizationData Stabilization;
        public static readonly string yt_dl = "yt-dlp.exe";
  
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Check for AviSynth
            if (NativeMethods.LoadLibrary("avisynth") == IntPtr.Zero)
            {
                var errorMessage = new Win32Exception(Marshal.GetLastWin32Error()).Message;
                MessageBox.Show(
                   $"Failed to load AviSynth: {errorMessage}.{Environment.NewLine}" + 
                    "I'll open the download page, go ahead and install it.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.Start($"http://avisynth.nl/index.php/Main_Page#Official_builds");
                return;
            }


            if(Utility.CheckVC2010x86())
                Task.Factory.StartNew(VideoDownload.CheckEnabled);
            else
            {
                MessageBox.Show(
                   $"You need Microsoft Visual C++ 2010 (x86) for the full experience.{Environment.NewLine}" +
                    "I'll open the download page, go ahead and install it.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.Start($"https://download.microsoft.com/download/1/6/5/165255E7-1014-4D0A-B094-B6A430A6BFFC/vcredist_x86.exe");
                return;
            }
            Task.Factory.StartNew(ShareXUpload.CheckEnabled);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
