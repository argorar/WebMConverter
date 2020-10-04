using System;
using System.Diagnostics;
using System.IO;

namespace WebMConverter
{
    class FFmpeg : Process //Refactoring, faggots.
    {
        public string FFmpegPath;

        public FFmpeg(string argument, bool win32 = false)
        {
            string folder;
            if (win32)
                folder = "Win32";
            else
                if (Environment.Is64BitOperatingSystem)
                    folder = "Win64";
                else
                    folder = "Win32";

            FFmpegPath = Path.Combine(Environment.CurrentDirectory, "Binaries", folder, "ffmpeg.exe");

            StartInfo.FileName = FFmpegPath;
            StartInfo.Arguments = "-hide_banner " + argument;
            StartInfo.RedirectStandardInput = true;
            StartInfo.RedirectStandardOutput = true;
            StartInfo.RedirectStandardError = true;
            StartInfo.UseShellExecute = false; //Required to redirect IO streams
            StartInfo.CreateNoWindow = true; //Hide console
            EnableRaisingEvents = true; 
        }

        new public void Start() => Start(true);
        public void Start(bool outputReadLine)
        {
            base.Start();
            BeginErrorReadLine();
            if (outputReadLine)
                BeginOutputReadLine();
        }
    }
}
