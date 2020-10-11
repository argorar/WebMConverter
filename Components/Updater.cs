using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace WebMConverter.Components
{
    public class Updater : Process
    {
        public readonly string UpdaterPath;
        private readonly string UpdatedUpdaterPath;

        public Updater()
        {
            UpdaterPath = Path.Combine(Environment.CurrentDirectory, "WebMConverter.Updater.exe");
            UpdatedUpdaterPath = Path.Combine(Environment.CurrentDirectory, "WebMConverter.Updater.update.exe");

            if (File.Exists(UpdatedUpdaterPath))
            {
                if (File.Exists(UpdaterPath))
                    File.Delete(UpdaterPath);

                File.Move(UpdatedUpdaterPath, UpdaterPath);
            }

            StartInfo.FileName = UpdaterPath;
            StartInfo.RedirectStandardInput = true;
            StartInfo.RedirectStandardOutput = true;
            StartInfo.RedirectStandardError = true;
            StartInfo.UseShellExecute = false; //Required to redirect IO streams
            StartInfo.CreateNoWindow = false; //Hide console
            EnableRaisingEvents = true; 
        }

        new public void Start()
        {
            base.Start();
            BeginErrorReadLine();
            BeginOutputReadLine();
        }

        // success, new version available, version string OR error, changelog
        public Tuple<bool, bool, string, string> Check(string currentVersion)
        {
            if (!File.Exists(UpdaterPath))
                return new Tuple<bool, bool, string, string>(false, false, "Updater has been removed.", null);

            currentVersion = currentVersion.Substring(0, currentVersion.LastIndexOf('.'));
            StartInfo.Arguments = "check " + currentVersion;

            var output = new StringBuilder();
            OutputDataReceived += (sender, args) => output.AppendLine(args.Data);

            Start();
            WaitForExit();

            var outputString = output.ToString().Trim();

            if (ExitCode != 0)
                return new Tuple<bool, bool, string, string>(false, false, output.ToString(), null);

            if (outputString.Length == 0)
                return new Tuple<bool, bool, string, string>(true, false, null, null);

            var versionAndChangelog = outputString.Split(new[] { '\n' }, 2);

            return new Tuple<bool, bool, string, string>(true, true, versionAndChangelog[0], versionAndChangelog[0]);
        }
    }
}
