using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebMConverter
{
    #region Filters

    static class Filters
    {
        internal static CaptionFilter Caption;
        internal static CropFilter Crop;
        internal static DeinterlaceFilter Deinterlace;
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
        private const string AppId = "c1d3hdb1-50ad-4c32-bdb2-688f7fd10155";
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
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Process thisProc = Process.GetCurrentProcess();
            //if (Process.GetProcessesByName(thisProc.ProcessName).Length > 1)
            //{
            //    MessageBox.Show("Application is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
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
                Process.Start($"https://www.microsoft.com/en-us/download/details.aspx?id=8328");
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
