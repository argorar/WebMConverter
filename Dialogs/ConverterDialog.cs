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
        private bool _extraArguments;

        private bool _needToPipe;
        private FFmpeg _pipeFFmpeg;

        private double _induration;
        private double _outduration;
        private bool _isloop;
        private TaskbarManager taskbarManager;

        public ConverterDialog(string input, string[] args, string output)
        {
            InitializeComponent();

            if (!ShareXUpload.Enabled)
            {
                buttonShareX.Hide();
                table.SetColumnSpan(buttonCreate, 2);
            }

            pictureStatus.BackgroundImage = StatusImages.Images["Happening"];

            _infile = input;
            _outfile = output;
            _arguments = args;
            _needToPipe = Environment.Is64BitOperatingSystem;
            if (!String.IsNullOrEmpty(_infile))
            {
                for (var i = 0; i < args.Length; i++)
                    AddInputFileToArguments(ref args[i], i);
            }
            _isloop = _arguments[0].Contains("[0]reverse[r];[0][r]concat,loop=2");
            taskbarManager = TaskbarManager.Instance;
        }

        private void ProcessOnErrorDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (args.Data != null && !args.Data.Contains("AVOption"))
            {
                if (DataContainsProgress(args.Data))
                {
                    try
                    { 
                        ParseAndUpdateProgress(args.Data);
                    }
                    catch (Exception ex)
                    {
                        boxOutput.AppendText($"An error happened {ex.Message}");
                    }
                }
                    
                else
                    boxOutput.InvokeIfRequired(() => boxOutput.AppendText(Environment.NewLine + args.Data));
            }
        }

        private void ProcessOnOutputDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (args.Data != null && !args.Data.Contains("Codec") && !args.Data.Contains("[info]"))
                boxOutput.InvokeIfRequired(() => boxOutput.AppendText(Environment.NewLine + args.Data));
        }

        // example ffmpeg line:
        // frame=  121 fps= 48 q=0.0 size=     552kB time=00:00:05.08 bitrate= 888.7kbits/s
        private bool DataContainsProgress(string data)
        {
            return data.StartsWith("frame=");
        }

        private void ParseAndUpdateProgress(string input)
        {
            var r = new Regex(@"time=\d\d:\d\d:\d\d.\d\d");
            var m = r.Match(input);
            if (m.Success)
            {
                var time = TimeSpan.Parse(m.Value.Split('=')[1]); // happens to be the same format as TimeSpan so yay
                var progress = Math.Abs((float)time.TotalSeconds / _induration); // sometimes the progress is negative, breaking the progressBar
                progress = Math.Min(progress, 1); // sometimes progress becomes more than 100%, which breaks the progressBar
                progressBar.InvokeIfRequired(() =>
                {
                    progressBar.Value = (int)(progress * 1000); // progressBar maximum is 1000

                    // find the last new line in the current string log
                    var lastNewLineIndex = boxOutput.Text.LastIndexOf('\n');

                    // and replace it
                    if (lastNewLineIndex >= 0)
                        if (lastNewLineIndex < boxOutput.Text.Length - 5 && string.Compare(boxOutput.Text, lastNewLineIndex + 1, "frame", 0, 5) == 0)
                            boxOutput.Text = boxOutput.Text.Substring(0, lastNewLineIndex + 1) + input;     // replace the previous frame line
                        else
                            boxOutput.Text += "\n" + input;    // previously not a frame line, insert as normal
                    else
                        boxOutput.Text = input;         // no new lines at all, so it's the first line, replace it
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
                for (int i =  0; i < _arguments.Length; i++)
                {
                    boxOutput.AppendText($"Arguments for pass {i + 1}: {_arguments[i]}");
                    boxOutput.AppendText($"{Environment.NewLine}");
                }

                MultiPass(_arguments);
            }
            else
            {
                boxOutput.AppendText($"Arguments: {argument}");
                SinglePass(argument);
            }
        }

        void AddInputFileToArguments(ref string argument, int argumentNumber)
        {
            if (argumentNumber > 1 || argument.Contains("vidstab"))
                return;
            if (_needToPipe)
                argument = $@"-f nut -i pipe:0 {argument}";
            else
                argument = $@"-f avisynth -i ""{_infile}"" {argument}";
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
                    boxOutput.Invoke((Action)(() =>
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
                if (string.IsNullOrEmpty(_infile))
                    _timer.Tick += ExitedMerge;
                else
                    _timer.Tick += Exited;
                _timer.Start();
            }));

            taskbarManager.SetProgressState(TaskbarProgressBarState.Normal);
            _ffmpegProcess.Start();

            if (String.IsNullOrEmpty(_infile))
                MergeVideoFile(_ffmpegProcess);
            else
                StartPipe(_ffmpegProcess);
        }

        private void MergeVideoFile(FFmpeg ffmpeg)
        {
            _pipeFFmpeg = new FFmpeg(_arguments[0], true);
            _pipeFFmpeg.ErrorDataReceived += (o, args) =>
            {
                try
                {
                    boxOutput.Invoke((Action)(() =>
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

        private void PureArguments(string argument)
        {
            int passes = _arguments.Length;
            _ffmpegProcess = new FFmpeg(argument);
            _ffmpegProcess.OutputDataReceived += ProcessOnOutputDataReceived;
            _ffmpegProcess.ErrorDataReceived += ProcessOnErrorDataReceived;
            _ffmpegProcess.Exited += (o, args) => boxOutput.Invoke((Action)(() =>
            {
                if (_panic) return;
                boxOutput.AppendText($"{Environment.NewLine}--- FFMPEG HAS EXITED ---");

                _currentPass++;
                if (_currentPass < passes && !_cancelTwopass)
                {
                    boxOutput.AppendText($"{Environment.NewLine}--- ENTERING PASS {_currentPass + 1} ---");

                    taskbarManager.SetProgressState(TaskbarProgressBarState.Normal);
                    PureArguments(_arguments[_currentPass]);
                    return;
                }

                buttonCancel.Enabled = false;

                _timer = new Timer();
                _timer.Interval = 500;
                _timer.Tick += Exited;
                _timer.Start();
            }));
            _ffmpegProcess.Start(true);
        }

        private void MultiPass(string[] arguments)
        {
            int passes = arguments.Length;

            _ffmpegProcess = new FFmpeg(arguments[_currentPass]);

            _ffmpegProcess.ErrorDataReceived += ProcessOnErrorDataReceived;
            _ffmpegProcess.OutputDataReceived += ProcessOnOutputDataReceived;
            _ffmpegProcess.Exited += (o, args) => boxOutput.Invoke((Action)(() =>
            {
                if (_panic) return; //This should stop that one exception when closing the converter
                boxOutput.AppendText($"{Environment.NewLine}--- FFMPEG HAS EXITED ---");

                _currentPass++;
                if (_currentPass > 1)
                {
                    _needToPipe = false;
                    _extraArguments = true;
                }
                if (_currentPass < passes && !_cancelTwopass)
                {
                    boxOutput.AppendText($"{Environment.NewLine}--- ENTERING PASS {_currentPass + 1} ---");

                    taskbarManager.SetProgressState(TaskbarProgressBarState.Normal);

                    if (!_extraArguments)
                        MultiPass(arguments);
                    else
                        PureArguments(_arguments[_currentPass]);

                    return;
                }

                buttonCancel.Enabled = false;

                _timer = new Timer();
                _timer.Interval = 500;
                _timer.Tick += Exited;
                _timer.Start();
            }));

            _ffmpegProcess.Start();

            if (_extraArguments)
                PureArguments(_arguments[_currentPass]);
            else
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
                    boxOutput.AppendText($"{Environment.NewLine}If you have no idea what went wrong, open an issue on Github and copy paste the output of this window there, also upload test video.");
                }
                taskbarManager.SetProgressState(TaskbarProgressBarState.Error);
                pictureStatus.BackgroundImage = StatusImages.Images["Failure"];

                if (process.ExitCode == -1073741819) //This error keeps happening for me if I set threads to anything above 1, might happen for other people too
                    MessageBox.Show("It appears ffmpeg.exe crashed because of a thread error. Set the amount of threads to 1 in the advanced tab and try again.", "FYI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (Program.Stabilization != null)
                {
                    File.Delete(Program.Stabilization.Name);
                    File.Move(Program.Stabilization.TempName, Program.Stabilization.Name);
                }

                if (Program.Loop != null)
                {
                    File.Delete(Program.Loop.Name);
                    File.Move(Program.Loop.LoopName, Program.Loop.Name);
                }

                _outduration = ProbeDuration(_outfile, false);
                if (_isloop)
                    _induration *= 2;
                if (Math.Abs(_induration - _outduration) > 0.1 && !_arguments[0].Contains("minterpolate") && !_arguments[0].Contains("setpts") && Program.Loop == null)
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
                    GetFileSize();
                    pictureStatus.BackgroundImage = StatusImages.Images["Success"];
                    taskbarManager.SetProgressValue(1000, 1000);
                }

                //only show buttons when is not convert in batch
                if(!String.IsNullOrEmpty(_infile) && !String.IsNullOrEmpty(_outfile))
                {
                    buttonPlay.Enabled = true;
                    buttonCreate.Enabled = true;
                }

            }

            buttonCancel.Text = "Close";
            buttonCancel.Enabled = true;
            _ended = true;

            if (!Program.DisablePop)
                this.Activate();
        }

        private void GetFileSize()
        {
            if (!string.IsNullOrEmpty(_outfile))
            {
                FileInfo fileInfo = new FileInfo(_outfile);
                string fileSize = Utility.SizeSuffix(fileInfo.Length);
                boxOutput.AppendText($"{Environment.NewLine}{Environment.NewLine}--- Final file size is {fileSize} ---");
            }
        }

        private void ExitedMerge(object sender, EventArgs eventArgs)
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
                taskbarManager.SetProgressValue(1000, 1000);
                boxOutput.AppendText($"{Environment.NewLine}{Environment.NewLine}Video converted succesfully!");
                GetFileSize();
                pictureStatus.BackgroundImage = StatusImages.Images["Success"];
            }
            buttonCancel.Text = "Close";
            buttonCancel.Enabled = true;
            buttonPlay.Enabled = true;
            buttonCreate.Enabled = true;
            _ended = true;

            if (!Program.DisablePop)
                this.Activate();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _cancelTwopass = true;

            if (!_ended || _panic) //Prevent stack overflow
            {
                if (_ffmpegProcess != null && !_ffmpegProcess.HasExited)
                    _ffmpegProcess.Kill();

                if (_pipeFFmpeg != null && !_pipeFFmpeg.HasExited)
                    _pipeFFmpeg.Kill();
            }
            else
            {
                if (_pipeFFmpeg != null && !_pipeFFmpeg.HasExited)
                    _pipeFFmpeg.Kill();

                Close();
            }
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
                    boxOutput.AppendText($"{Environment.NewLine}{Environment.NewLine} --- UPLOAD FILE TO GFYCAT---");
                    boxOutput.AppendText($"{Environment.NewLine}Creating request for gfycat name");

                    WebRequest httpWRequest = CreateGfyRequest();

                    boxOutput.AppendText($"{Environment.NewLine}Doing request");

                    GfycatResponse newGfycatResponse = GetGfyResponse((HttpWebResponse)httpWRequest.GetResponse());
                    boxOutput.AppendText($"{Environment.NewLine}Congratulations, your new name is {newGfycatResponse.gfyname}");

                    if (newGfycatResponse.isOk)
                    {
                        _ = Task.Run(() => new GfycatUploader(_outfile, newGfycatResponse.gfyname).ShowDialog());
                        Dispose();
                    }
                    else
                        boxOutput.AppendText($"{Environment.NewLine}Sorry, something happened and I can't upload your file :(");


                }
                catch (WebException ex)
                {
                    boxOutput.AppendText($"{Environment.NewLine}Ups, something happened {ex.Message}");
                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        var response = ex.Response as HttpWebResponse;
                        if (response != null)
                        {
                            boxOutput.AppendText($"{Environment.NewLine}HTTP: {response.StatusCode}");
                            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                            {
                                string responseText = await reader.ReadToEndAsync().ConfigureAwait(false);
                                boxOutput.AppendText($"{Environment.NewLine}Message: {responseText}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    boxOutput.AppendText($"{Environment.NewLine}Ups, something happened {ex.Message}");
                    this.Activate();
                }
            }

        }

        private GfycatResponse GetGfyResponse(HttpWebResponse httpWebResponse)
        {
            Stream strm = httpWebResponse.GetResponseStream();
            StreamReader sr = new StreamReader(strm);
            string textJson = sr.ReadToEnd();
            GfycatResponse newGfycatResponse = JsonConvert.DeserializeObject<GfycatResponse>(textJson);
            return newGfycatResponse;
        }

        private WebRequest CreateGfyRequest()
        {
            WebRequest httpWRequest = WebRequest.Create($"https://api.gfycat.com/v1/gfycats");
            httpWRequest.ContentType = "application/json";
            httpWRequest.Method = "POST";
            httpWRequest.Headers.Add("Authorization", "Bearer " + Program.token);
            var aux = _outfile.Split('\\');
            string tmp = StringTags();
            string postData = " {\"title\":\"" + aux[aux.Length - 1].Split('.')[0] + "\",";
            if (!String.IsNullOrEmpty(tmp))
                postData = postData + "\"tags\": [" + StringTags() + "],";
            postData = postData + "\"nsfw\": 0}";
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] byte1 = encoding.GetBytes(postData);
            httpWRequest.GetRequestStream().Write(byte1, 0, byte1.Length);
            return httpWRequest;
        }

        // manually scroll to bottom cause AppendText doesn't do it if it doesn't have focus
        private void boxOutput_TextChanged(object sender, EventArgs e) => NativeMethods.SendMessage(boxOutput.Handle, 0x115, 7, 0);

        private void buttonShareX_Click(object sender, EventArgs e)
        {
            if (!File.Exists(((MainForm)Owner).textBoxOut.Text))
                MessageBox.Show("Output file not found! Did you move it?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    using (var proc = new ShareX(((MainForm)Owner).textBoxOut.Text)) proc.Start();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string StringTags()
        {
            string[] tags = ((MainForm)Owner).GetGfyTags();

            if (tags == null)
                return string.Empty;

            if (tags.Length == 1)
                return $"\"{tags[0]}\"";

            string text = string.Empty;
            foreach (string tag in tags)
            {
                if (!String.IsNullOrEmpty(text))
                    text = $"{text},\"{tag}\"";
                else
                    text = $"\"{tag}\"";
            }
            return text;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            string newOutput = Utility.IncreaseFileNumber(_outfile);
            (Owner as MainForm).textBoxOut.Text = newOutput;
            Close();
        }
    }
}
