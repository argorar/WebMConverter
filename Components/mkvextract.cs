using System;
using System.Diagnostics;
using System.IO;

namespace WebMConverter.Components
{
    class MkvExtract : Process
    {
        private readonly string _programPath = Path.Combine(Environment.CurrentDirectory, "Binaries", "Win32", "mkvextract.exe");

        public MkvExtract(string argument)
        {
            if (string.IsNullOrEmpty(argument))
                throw new ArgumentNullException(nameof(argument));

            StartInfo.FileName = _programPath;
            StartInfo.Arguments = argument;
            StartInfo.RedirectStandardInput = true;
            StartInfo.RedirectStandardOutput = true;
            StartInfo.RedirectStandardError = true;
            StartInfo.UseShellExecute = false; //Required to redirect IO streams
            StartInfo.CreateNoWindow = true; //Hide console
            EnableRaisingEvents = true;

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
