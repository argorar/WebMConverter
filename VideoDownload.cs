using System;
using System.Diagnostics;

namespace WebMConverter
{
    static class VideoDownload
    {
        public static bool Enabled { get; private set; }

        public static void CheckEnabled()
        {
            try
            {
                var proc = new YoutubeDL("");
                proc.Start(false);
            }
            catch (Exception)
            {
                Enabled = false;
                return;
            }
            Enabled = true;
        }
    }

    class YoutubeDL : Process
    {
        public YoutubeDL(string arguments)
        {
            StartInfo.FileName = "Binaries//Win64//youtube-dl.exe";
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
