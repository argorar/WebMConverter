using System;
using System.Diagnostics;
using System.IO;

namespace WebMConverter
{
    static class VideoDownload
    {
        public static bool Enabled { get; private set; }

        public static void CheckEnabled()
        {
            String exePath = "Binaries//Win64//" + Program.yt_dl;
            if(File.Exists(exePath))
                Enabled = true;
            else
                Enabled = false;
        }
    }

    class YoutubeDL : Process
    {
        public YoutubeDL(string arguments)
        {
            StartInfo.FileName = "Binaries//Win64//" + Program.yt_dl;
            StartInfo.Arguments = arguments;
            StartInfo.RedirectStandardInput = true;
            StartInfo.RedirectStandardOutput = true;
            StartInfo.RedirectStandardError = true;
            StartInfo.UseShellExecute = false; //Required to redirect IO streams
            StartInfo.CreateNoWindow = true; //Hide console
            EnableRaisingEvents = true;
        }

        new public void Start()
        {
            Start(true);
        }

        public void Start(bool OutputReadLine)
        {
            base.Start();
            BeginErrorReadLine();
            if (OutputReadLine)
                BeginOutputReadLine();
        }
    }
}
