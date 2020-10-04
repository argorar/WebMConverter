using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace WebMConverter
{
    class FFplay : Process
    {
        public string FFplayPath = Path.Combine(Environment.CurrentDirectory, "Binaries", "Win32", "ffplay.exe");

        StringBuilder errorLog;
        public string ErrorLog => errorLog.ToString().Trim();

        public FFplay(string argument)
        {
            StartInfo.FileName = FFplayPath;
            StartInfo.Arguments = argument;
            StartInfo.RedirectStandardInput = true;
            StartInfo.RedirectStandardOutput = true;
            StartInfo.RedirectStandardError = true;
            StartInfo.UseShellExecute = false; //Required to redirect IO streams
            StartInfo.CreateNoWindow = true; //Hide console
            EnableRaisingEvents = true;

            errorLog = new StringBuilder();
            ErrorDataReceived += (sender, args) => errorLog.AppendLine(args.Data);

#if DEBUG
            OutputDataReceived += (sender, args) => Console.WriteLine(args.Data);
            ErrorDataReceived += (sender, args) => Console.WriteLine(args.Data);
#endif
        }

        new public void Start()
        {
            base.Start();
            BeginErrorReadLine();
            BeginOutputReadLine();
        }
    }
}
