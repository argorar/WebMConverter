using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using Timer = System.Windows.Forms.Timer;
using static WebMConverter.Utility;

namespace WebMConverter.Dialogs
{
    public partial class DownloadDialog : Form
    {
        public string Outfile;

        private readonly string _infile;
        private YoutubeDL _filenameGetterProcess;
        private YoutubeDL _downloaderProcess;

        private Timer _timer;
        private bool _ended;
        private bool _panic;
        private bool _gettingFilename;

        private TaskbarManager taskbarManager;

        public DownloadDialog(string url)
        {
            InitializeComponent();
            pictureStatus.BackgroundImage = StatusImages.Images["Happening"];

            _infile = '"' + url.Replace(@"""", @"\""") + '"';
            Outfile = Path.GetTempPath();

            taskbarManager = TaskbarManager.Instance;
        }

        private void ProcessOnErrorDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (args.Data != null)
                boxOutput.Invoke((Action)(() => boxOutput.AppendText(Environment.NewLine + args.Data)));
        }

        private void FilenameGetterOnOutputDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (args.Data != null)
                Outfile = Path.Combine(Outfile, args.Data);
        }

        private void ProcessOnOutputDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (args.Data != null)
            {
                boxOutput.Invoke((Action)(() => boxOutput.AppendText(Environment.NewLine + args.Data)));

                if (DataContainsProgress(args.Data))
                    ParseAndUpdateProgress(args.Data);
            }
        }

        // example youtube-dl line:
        // [download]  51.5% of ~3.85MiB at 20.49MiB/s ETA 00:00

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
            _filenameGetterProcess = new YoutubeDL("--get-filename " + _infile);
            _downloaderProcess = new YoutubeDL(null);

            _gettingFilename = true;

            _filenameGetterProcess.ErrorDataReceived += ProcessOnErrorDataReceived;
            _filenameGetterProcess.OutputDataReceived += FilenameGetterOnOutputDataReceived;
            _filenameGetterProcess.Exited += (o, args) => boxOutput.Invoke((Action) (() =>
            {
                if (_panic) return;
                boxOutput.AppendText($"{Environment.NewLine}Downloading to {Outfile}");
                _downloaderProcess.StartInfo.Arguments = $@"-o ""{Outfile}"" {_infile}";

                _timer = new Timer { Interval = 500 };
                _timer.Tick += Exited;
                _timer.Start();
            }));

            _downloaderProcess.ErrorDataReceived += ProcessOnErrorDataReceived;
            _downloaderProcess.OutputDataReceived += ProcessOnOutputDataReceived;
            _downloaderProcess.Exited += (o, args) => boxOutput.Invoke((Action)(() =>
            {
                if (_panic) return; //This should stop that one exception when closing the converter
                boxOutput.AppendText($"{Environment.NewLine}--- YOUTUBE-DL HAS EXITED ---");
                buttonCancel.Enabled = false;

                _timer = new Timer {Interval = 500};
                _timer.Tick += Exited;
                _timer.Start();
            }));

            taskbarManager.SetProgressState(TaskbarProgressBarState.Indeterminate); // can't get progress for filename getter
            progressBar.Style = ProgressBarStyle.Marquee;
            _filenameGetterProcess.Start();
        }

        private void Exited(object sender, EventArgs eventArgs)
        {
            _timer.Stop();

            if (_gettingFilename)
            {
                if (_filenameGetterProcess.ExitCode != 0)
                {
                    boxOutput.AppendText($"{Environment.NewLine}{Environment.NewLine}youtube-dl.exe exited with exit code {_filenameGetterProcess.ExitCode}. That's usually bad.");
                    boxOutput.AppendText($"{Environment.NewLine}If you have no idea what went wrong, open an issue on GitGud and copy paste the output of this window there.");
                    pictureStatus.BackgroundImage = StatusImages.Images["Failure"];
                    buttonCancel.Enabled = true;
                    _ended = true;
                }
                else
                {
                    _gettingFilename = false;
                    taskbarManager.SetProgressState(TaskbarProgressBarState.Normal);
                    progressBar.Style = ProgressBarStyle.Blocks;
                    _downloaderProcess.Start();
                }
                return;
            }

            if (_downloaderProcess.ExitCode != 0)
            {
                boxOutput.AppendText($"{Environment.NewLine}{Environment.NewLine}youtube-dl.exe exited with exit code {_downloaderProcess.ExitCode}. That's usually bad.");
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

                // workaround for https://github.com/rg3/youtube-dl/issues/11472
                if (!File.Exists(Outfile))
                {
                    Outfile = Path.ChangeExtension(Outfile, "mkv");
                }
            }

            _ended = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (!_ended || _panic) //Prevent stack overflow
            {
                if (!_filenameGetterProcess.HasExited)
                    KillProcessAndChildren(_filenameGetterProcess.Id);

                if (_gettingFilename)
                    return;

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
            _filenameGetterProcess.Dispose();
            _downloaderProcess.Dispose();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void boxOutput_TextChanged(object sender, EventArgs e) => NativeMethods.SendMessage(boxOutput.Handle, 0x115, 7, 0);
    }
}
