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
        internal static CaptionFilter Caption { get; set; }
        internal static CropFilter Crop { get; set; }
        internal static DynamicCropFilter DynamicCrop { get; set; }
        internal static DeinterlaceFilter Deinterlace { get; set; }
        internal static DelayAudio DelayAudio { get; set; }
        internal static DenoiseFilter Denoise { get; set; }
        internal static DubFilter Dub { get; set; }
        internal static FadeFilter Fade { get; set; }
        internal static MultipleTrimFilter MultipleTrim { get; set; }
        internal static OverlayFilter Overlay { get; set; }
        internal static RateFilter Rate { get; set; }
        internal static ResizeFilter Resize { get; set; }
        internal static ReverseFilter Reverse { get; set; }
        internal static RotateFilter Rotate { get; set; }
        internal static SubtitleFilter Subtitle { get; set; }
        internal static TrimFilter Trim { get; set; }

        internal static void ResetFilters()
        {
            Caption = null;
            Crop = null;
            DynamicCrop = null;
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
        public static FFMSSharp.VideoSource VideoSource { get; set; }
        public static FFMSSharp.ColorRange VideoColorRange { get; set; }
        public static Size Resolution { get; set; }
        public static bool VideoInterlaced { get; set; }
        public static bool DisablePop { get; set; }
        public static string InputFile { get; set; }
        public static bool DisableUpdates { get; set; }
        public static FileType InputType { get; set; }
        public static bool InputHasAudio { get; set; }
        public static bool InputHasWeirdPixelFormat { get; set; } // for something that xy-VSFilter can't render on
        public static string FileMd5 { get; set; }
        public static string AttachmentDirectory { get; set; }
        public static Dictionary<int, Tuple<string, SubtitleType, string>> SubtitleTracks { get; set; } // stream id, <tag:title OR codec_name, textsub/vobsub, extension>
        public static List<string> AttachmentList { get; set; }
        public static string token { get; set; }
        public static StabilizationData Stabilization { get; set; }
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
            
            Task.Factory.StartNew(VideoDownload.CheckEnabled);
            Task.Factory.StartNew(ShareXUpload.CheckEnabled);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
