using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using Timer = System.Windows.Forms.Timer;
using static WebMConverter.Utility;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using WebMConverter.Objects;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebMConverter.Dialogs
{
    public partial class ConverterDialog : Form
    {
        private readonly string _infile;
        private readonly string _outfile;
        private readonly string[] _arguments;
        private FFmpeg _ffmpegProcess;

        private Timer _timer;
        private bool _ended;
        private bool _panic;

        private int _currentPass;
        private bool _twopass;
        private bool _cancelTwopass;

        private readonly bool _needToPipe;
        private FFmpeg _pipeFFmpeg;

        private double _induration;
        private double _outduration;

        private TaskbarManager taskbarManager;

        public ConverterDialog(string input, string[] args, string output)
        {
            InitializeComponent();

            //if (!ShareXUpload.Enabled)
            //{
            //    table.SetColumnSpan(buttonPlay, 3);
            //    table.SetColumnSpan(buttonCancel, 3);
            //    buttonUpload.Hide();
            //    table.SetColumn(buttonCancel, 4);
            //}

            pictureStatus.BackgroundImage = StatusImages.Images["Happening"];

            _infile = input;
            _outfile = output;
            _arguments = args;
            _needToPipe = Environment.Is64BitOperatingSystem;

            for (var i = 0; i < args.Length; i++)
            {
                AddInputFileToArguments(ref args[i]);
            }

            taskbarManager = TaskbarManager.Instance;
        }

        private void ProcessOnErrorDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (args.Data != null)
            {
                boxOutput.Invoke((Action)(() => boxOutput.AppendText(Environment.NewLine + args.Data)));

                if (DataContainsProgress(args.Data))
                    ParseAndUpdateProgress(args.Data);
            }
        }

        private void ProcessOnOutputDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (args.Data != null)
                boxOutput.Invoke((Action)(() => boxOutput.AppendText(Environment.NewLine + args.Data)));
        }

        // example ffmpeg line:
        // frame=  121 fps= 48 q=0.0 size=     552kB time=00:00:05.08 bitrate= 888.7kbits/s

        private bool dontUpdateProgress = false;
        private bool DataContainsProgress(string data)
        {
            if (dontUpdateProgress)
                return false;

            return data.StartsWith("frame=");
        }

        private void ParseAndUpdateProgress(string input)
        {
            var r = new Regex(@"time=([^ ]+)");
            var m = r.Match(input);
            if (m.Success)
            {
                var time = TimeSpan.Parse(m.Groups[1].Value); // happens to be the same format as TimeSpan so yay
                var progress = (float)time.TotalSeconds/_induration;
                progress = Math.Min(progress, 1); // sometimes progress becomes more than 100%, which breaks the progressBar
                progressBar.InvokeIfRequired(() =>
                {
                    progressBar.Value = (int)(progress * 1000); // progressBar maximum is 1000
                });
                taskbarManager.SetProgressValue((int)(progress * 1000), 1000);
            }
        }

        private void ConverterForm_Load(object sender, EventArgs e)
        {
            taskbarManager.SetProgressState(TaskbarProgressBarState.Indeterminate);

            string argument = null;
            _twopass = true;
            if (_arguments.Length == 1)
            {
                _twopass = false;
                argument = _arguments[0];
            }

            _induration = ProbeDuration(_infile, true);

            if (_twopass)
            {
                boxOutput.AppendText($"Arguments for pass 1: {_arguments[0]}");
                boxOutput.AppendText($"{Environment.NewLine}Arguments for pass 2: {_arguments[1]}");
            }
            else
                boxOutput.AppendText($"Arguments: {argument}");

            if (_twopass)
                MultiPass(_arguments);
            else
                SinglePass(argument);
        }

        void AddInputFileToArguments(ref string argument)
        {
            if (_needToPipe)
            {
                argument = $@"-f nut -i pipe:0 {argument}";
            }
            else
            {
                argument = $@"-f avisynth -i ""{_infile}"" {argument}";
            }
        }

        void StartPipe(FFmpeg ffmpeg)
        {
            if (!_needToPipe)
                return;

            string proxyargs = $@"-f avisynth -i ""{_infile}"" -f nut -c copy -v error pipe:1";
            boxOutput.AppendText($"{Environment.NewLine}--- CREATING AVISYNTH PROXY --- ");

            _pipeFFmpeg = new FFmpeg(proxyargs, true);
            _pipeFFmpeg.ErrorDataReceived += (o, args) =>
            {
                try
                {
                    boxOutput.Invoke((Action) (() =>
                    {
                        boxOutput.AppendText(Environment.NewLine + args.Data);
                    }));
                }
                catch
                {
                    // ignored
                }
            };
            _pipeFFmpeg.Start(false);
            var bw = new BackgroundWorker();
            bw.DoWork += delegate
            {
                try
                {
                    _pipeFFmpeg.StandardOutput.BaseStream.CopyTo(ffmpeg.StandardInput.BaseStream);
                }
                catch
                {
                    // ignored
                }
            };
            _pipeFFmpeg.Exited += delegate
            {
                try
                {
                    _ffmpegProcess.StandardInput.Close();
                }
                catch
                {
                    // ignored
                }
            };
            bw.RunWorkerAsync();
        }

        private void SinglePass(string argument)
        {
            _ffmpegProcess = new FFmpeg(argument);

            _ffmpegProcess.ErrorDataReceived += ProcessOnErrorDataReceived;
            _ffmpegProcess.OutputDataReceived += ProcessOnOutputDataReceived;
            _ffmpegProcess.Exited += (o, args) => boxOutput.Invoke((Action)(() =>
            {
                if (_panic) return; //This should stop that one exception when closing the converter
                boxOutput.AppendText($"{Environment.NewLine}--- FFMPEG HAS EXITED ---");
                buttonCancel.Enabled = false;

                _timer = new Timer();
                _timer.Interval = 500;
                _timer.Tick += Exited;
                _timer.Start();
            }));

            taskbarManager.SetProgressState(TaskbarProgressBarState.Normal);
            _ffmpegProcess.Start();
            StartPipe(_ffmpegProcess);
        }

        private void MultiPass(string[] arguments)
        {
            int passes = arguments.Length;
            dontUpdateProgress = passes != _currentPass + 1;

            _ffmpegProcess = new FFmpeg(arguments[_currentPass]);

            _ffmpegProcess.ErrorDataReceived += ProcessOnErrorDataReceived;
            _ffmpegProcess.OutputDataReceived += ProcessOnOutputDataReceived;
            _ffmpegProcess.Exited += (o, args) => boxOutput.Invoke((Action)(() =>
            {
                if (_panic) return; //This should stop that one exception when closing the converter
                boxOutput.AppendText($"{Environment.NewLine}--- FFMPEG HAS EXITED ---");

                _currentPass++;
                if (_currentPass < passes && !_cancelTwopass)
                {
                    boxOutput.AppendText($"{Environment.NewLine}--- ENTERING PASS {_currentPass + 1} ---");

                    taskbarManager.SetProgressState(TaskbarProgressBarState.Normal);
                    MultiPass(arguments); //Sort of recursion going on here, be careful with stack overflows and shit
                    return;
                }

                buttonCancel.Enabled = false;

                _timer = new Timer();
                _timer.Interval = 500;
                _timer.Tick += Exited;
                _timer.Start();
            }));

            _ffmpegProcess.Start();
            StartPipe(_ffmpegProcess);
        }

        private void Exited(object sender, EventArgs eventArgs)
        {
            _timer.Stop();

            var process = _ffmpegProcess;

            if (process.ExitCode != 0)
            {
                if (_cancelTwopass)
                    boxOutput.AppendText($"{Environment.NewLine}{Environment.NewLine}Conversion cancelled.");
                else
                {
                    boxOutput.AppendText($"{Environment.NewLine}{Environment.NewLine}ffmpeg.exe exited with exit code {process.ExitCode}. That's usually bad.");
                    boxOutput.AppendText($"{Environment.NewLine}If you have no idea what went wrong, open an issue on GitGud and copy paste the output of this window there.");
                }
                taskbarManager.SetProgressState(TaskbarProgressBarState.Error);
                pictureStatus.BackgroundImage = StatusImages.Images["Failure"];

                if (process.ExitCode == -1073741819) //This error keeps happening for me if I set threads to anything above 1, might happen for other people too
                    MessageBox.Show("It appears ffmpeg.exe crashed because of a thread error. Set the amount of threads to 1 in the advanced tab and try again.", "FYI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _outduration = ProbeDuration(_outfile, false);
                if (Math.Abs(_induration - _outduration) > 0.01)
                {
                    boxOutput.AppendText($"{Environment.NewLine}{Environment.NewLine}Restraints are too high!");

                    boxOutput.AppendText($"{Environment.NewLine}Your output file was encoded successfully, but because of your filesize constraints, it's missing a bit at the end.");
                    boxOutput.AppendText($"{Environment.NewLine}Either raise your limit, or lower your resolution and/or bitrate.");

                    boxOutput.AppendText($"{Environment.NewLine}Amount of video lost: {Math.Abs(_induration - _outduration)}s");

                    taskbarManager.SetProgressState(TaskbarProgressBarState.Error);
                    pictureStatus.BackgroundImage = StatusImages.Images["Failure"];
                }
                else
                {
                    boxOutput.AppendText($"{Environment.NewLine}{Environment.NewLine}Video converted succesfully!");
                    pictureStatus.BackgroundImage = StatusImages.Images["Success"];
                }

                buttonPlay.Enabled = true;
                buttonUpload.Enabled = true;
            }

            buttonCancel.Text = "Close";
            buttonCancel.Enabled = true;
            _ended = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _cancelTwopass = true;

            if (!_ended || _panic) //Prevent stack overflow
            {
                if (!_ffmpegProcess.HasExited)
                    _ffmpegProcess.Kill();

                if (!_needToPipe)
                    return;

                if (!_pipeFFmpeg.HasExited)
                    _pipeFFmpeg.Kill();
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
            _ffmpegProcess.Dispose();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (!File.Exists(_outfile))
                MessageBox.Show("Output file not found! Did you move it?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                Process.Start(_outfile); //Play result video
        }

        private async void buttonUpload_ClickAsync(object sender, EventArgs e)
        {
            if (!File.Exists(_outfile))
                MessageBox.Show("Output file not found! Did you move it?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    if (String.IsNullOrEmpty(((MainForm)Owner).token))
                        ((MainForm)Owner).BrowserAuthentication();

                    boxOutput.AppendText($"{Environment.NewLine}{Environment.NewLine} --- UPLOAD FILE TO GFYCAT---");
                    boxOutput.AppendText($"{Environment.NewLine}Creating request for gfycat name");

                    WebRequest httpWRequest = WebRequest.Create("https://api.gfycat.com/v1/gfycats");
                    httpWRequest.ContentType = "application/json";
                    httpWRequest.Method = "POST";
                    httpWRequest.Headers.Add("Authorization", "Bearer " + ((MainForm)Owner).token);
                    var aux = _outfile.Split('\\');
                    string postData = " {\"title\":\"" + aux[aux.Length-1].Split('.')[0] + "\"}";
                    UTF8Encoding encoding = new UTF8Encoding();
                    byte[] byte1 = encoding.GetBytes(postData);
                    httpWRequest.GetRequestStream().Write(byte1, 0, byte1.Length);

                    boxOutput.AppendText($"{Environment.NewLine}Doing request");
                    HttpWebResponse httpWResponse = (HttpWebResponse)httpWRequest.GetResponse();
                    Stream strm = httpWResponse.GetResponseStream();
                    StreamReader sr = new StreamReader(strm);
                    string textJson = sr.ReadToEnd();
                    GfycatResponse newGfycatResponse = JsonConvert.DeserializeObject<GfycatResponse>(textJson);
                    boxOutput.AppendText($"{Environment.NewLine}Congratulations, your new name is {newGfycatResponse.gfyname}");

                    var filePath = _outfile;
                    var file = File.ReadAllBytes(filePath);
                    using (var client = new HttpClient())
                    {
                        using (var content = new MultipartFormDataContent())
                        {
                            content.Add(new StringContent(newGfycatResponse.gfyname), "key");
                            content.Add(new ByteArrayContent(file), "file", newGfycatResponse.gfyname);
                            boxOutput.AppendText($"{Environment.NewLine}Starting to upload file");
                            //progressBar.Style = ProgressBarStyle.Marquee;
                            using (var message = await client.PostAsync("https://filedrop.gfycat.com", content))
                            {
                                boxOutput.AppendText($"{Environment.NewLine}Everything is great, now wait until gfycat encode the video :)");
                            }
                        }
                    }

                    if (newGfycatResponse.isOk)
                    {
                        string text;
                        bool isDone = false;
                        string cUrl = $"https://api.gfycat.com/v1/gfycats/fetch/status/{newGfycatResponse.gfyname}";
                        while (!isDone)
                        {
                            HttpWebRequest r = (HttpWebRequest)WebRequest.Create(cUrl);
                            using (HttpWebResponse k = (HttpWebResponse)r.GetResponse())
                            {
                                if (k.StatusCode == HttpStatusCode.OK)
                                {
                                    using (var sr2 = new StreamReader(k.GetResponseStream()))
                                    {
                                        text = sr2.ReadToEnd();
                                        boxOutput.AppendText($"{Environment.NewLine}{text}");
                                    }
                                    if (text.Contains("complete"))
                                    {
                                        isDone = true;
                                        boxOutput.AppendText($"{Environment.NewLine}Your video is up!");
                                        taskbarManager.SetProgressValue(100,100);
                                        System.Diagnostics.Process.Start($"https://gfycat.com/{newGfycatResponse.gfyname}");
                                    }
                                    else
                                    {
                                        await Task.Delay(500);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        var response = ex.Response as HttpWebResponse;
                        if (response != null)
                        {
                            MessageBox.Show("HTTP: " + response.StatusCode);
                            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                            {
                                // reads response body
                                string responseText = await reader.ReadToEndAsync();
                                MessageBox.Show(responseText);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
                
        }

        // manually scroll to bottom cause AppendText doesn't do it if it doesn't have focus
        private void boxOutput_TextChanged(object sender, EventArgs e) => NativeMethods.SendMessage(boxOutput.Handle, 0x115, 7, 0);
        // 0x115: WM_VSCROLL, 7: SB_BOTTOM
    }
}
