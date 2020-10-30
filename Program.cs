using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebMConverter
{
    #region Filters

    static class Filters
    {
        internal static CaptionFilter Caption = null;
        internal static CropFilter Crop = null;
        internal static DeinterlaceFilter Deinterlace = null;
        internal static DenoiseFilter Denoise = null;
        internal static DubFilter Dub;
        internal static FadeFilter Fade;
        internal static LevelsFilter Levels = null;
        internal static MultipleTrimFilter MultipleTrim = null;
        internal static OverlayFilter Overlay = null;
        internal static RateFilter Rate = null;
        internal static ResizeFilter Resize = null;
        internal static ReverseFilter Reverse = null;
        internal static RotateFilter Rotate;
        internal static SubtitleFilter Subtitle = null;
        internal static TrimFilter Trim = null;

        internal static void ResetFilters()
        {
            Caption = null;
            Crop = null;
            Deinterlace = null;
            Denoise = null;
            Dub = null;
            Fade = null;
            Levels = null;
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
                Process.Start("http://avisynth.nl/index.php/Main_Page#Official_builds");
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
                Process.Start("https://www.microsoft.com/en-us/download/details.aspx?id=8328");
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
