using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using Timer = System.Windows.Forms.Timer;
using static WebMConverter.Utility;
using System.Linq;

namespace WebMConverter.Dialogs
{
    public partial class DownloadDialog : Form
    {
        public string Outfile { get; set; }
        public string OutputPath { get; set; }

        private readonly string _infile;
        private YoutubeDL _downloaderProcess;

        private Timer _timer;
        private bool _ended;
        private bool _panic;

        private TaskbarManager taskbarManager;

        public DownloadDialog(string url, string outputPath)
        {
            InitializeComponent();
            pictureStatus.BackgroundImage = StatusImages.Images["Happening"];

            _infile = '"' + url.Replace(@"""", @"\""") + '"';
            OutputPath = outputPath;

            taskbarManager = TaskbarManager.Instance;
        }

        private void ProcessOnErrorDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (args.Data != null)
                boxOutput.Invoke((Action)(() => boxOutput.AppendText(Environment.NewLine + args.Data)));
        }

        private void ProcessOnOutputDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (args.Data != null)
            {
                boxOutput.Invoke((Action)(() => boxOutput.AppendText(Environment.NewLine + args.Data)));

                if (DataContainsProgress(args.Data))
                {
                    ParseAndUpdateProgress(args.Data);
                    if(String.IsNullOrEmpty(Outfile))
                        GetId(args.Data);
                }

            }
        }

        private void GetId(string data)
        {
            if(data.Contains("Destination:"))
                Outfile = data.Split('[').LastOrDefault().Split(']')[0];
        }

        // example youtube-dl line:
        // [download]  51.5% of ~3.85MiB at 20.49MiB/s ETA 00:00

        private bool DataContainsFFMPEG(string data) => data.StartsWith("[ffmpeg]");
        private bool DataContainsProgress(string data) => data.StartsWith("[download]");

        private void ParseAndUpdateProgress(string input)
        {
            var r = new Regex(@"([0-9.]+)%");
            var m = r.Match(input);
            if (m.Success)
            {
                var progress = float.Parse(m.Groups[1].Value, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                progressBar.InvokeIfRequired(() =>
                {
                    progressBar.Value = (int)(progress * 10); // progressBar maximum is 1000
                });
                taskbarManager.SetProgressValue((int)(progress * 10), 1000);
            }
        }

        private void DownloadDialog_Load(object sender, EventArgs e)
        {
            boxOutput.AppendText($"{Environment.NewLine}Starting Process");
            _downloaderProcess = new YoutubeDL(null);

            if(_infile.Contains("youtu"))
                _downloaderProcess.StartInfo.Arguments = $@"-f bestvideo+bestaudio  {_infile}";
            else
                _downloaderProcess.StartInfo.Arguments = $@"-f best { _infile}";

            _downloaderProcess.ErrorDataReceived += ProcessOnErrorDataReceived;
            _downloaderProcess.OutputDataReceived += ProcessOnOutputDataReceived;
            _downloaderProcess.Exited += (o, args) => boxOutput.Invoke((Action)(() =>
            {
                boxOutput.AppendText($"{Environment.NewLine}--- YT-DLP HAS EXITED ---");
                buttonCancel.Enabled = false;

                _timer = new Timer {Interval = 500};
                _timer.Tick += Exited;
                _timer.Start();
            }));

            taskbarManager.SetProgressState(TaskbarProgressBarState.Normal);
            progressBar.Style = ProgressBarStyle.Blocks;
            _downloaderProcess.Start();
        }

        private void Exited(object sender, EventArgs eventArgs)
        {
            _timer.Stop();

            if (_downloaderProcess.ExitCode != 0)
            {
                boxOutput.AppendText($"{Environment.NewLine}{Environment.NewLine}{Program.yt_dl} exited with exit code {_downloaderProcess.ExitCode}. That's usually bad.");
                boxOutput.AppendText($"{Environment.NewLine}If you have no idea what went wrong, open an issue on GitGud and copy paste the output of this window there.");
                pictureStatus.BackgroundImage = StatusImages.Images["Failure"];
                buttonCancel.Enabled = true;
                taskbarManager.SetProgressState(TaskbarProgressBarState.Error);
            }
            else
            {
                boxOutput.AppendText($"{Environment.NewLine}{Environment.NewLine}Video downloaded succesfully!");
                pictureStatus.BackgroundImage = StatusImages.Images["Success"];
                buttonLoad.Enabled = true;
                buttonCancel.Enabled = true;
                buttonCancel.Text = "Close";
                MoveNewFile();
                this.Activate();
            }

            _ended = true;
        }

        private void MoveNewFile()
        {
            if (String.IsNullOrEmpty(Outfile))
                return;

            string[] fileEntries = Directory.GetFiles(".");
            foreach (string fileName in fileEntries) 
            {
                if (fileName.Contains(Outfile))
                {
                    Outfile = fileName;
                    break;
                }
            }
            File.Move(Outfile, Path.Combine(OutputPath, Outfile));
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (buttonCancel.Text.Equals("Close"))
            {
                if(!_downloaderProcess.HasExited)
                    KillProcessAndChildren(_downloaderProcess.Id);

                Dispose();
                return;
            }

            if (!_ended || _panic) //Prevent stack overflow
            {
                if (!_downloaderProcess.HasExited)
                    KillProcessAndChildren(_downloaderProcess.Id);
            }
            else
                Close();
        }

        private void ConverterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _panic = true; //Shut down while avoiding exceptions
            buttonCancel_Click(sender, e);
            taskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
        }

        private void ConverterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _downloaderProcess.Dispose();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void boxOutput_TextChanged(object sender, EventArgs e) => NativeMethods.SendMessage(boxOutput.Handle, 0x115, 7, 0);

        internal string GetOutfile()
        {
            if (String.IsNullOrEmpty(Outfile))
                return String.Empty;

            return OutputPath + Outfile.Substring(1);
        }
    }
}
