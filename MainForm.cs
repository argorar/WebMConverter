using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using Microsoft.WindowsAPICodePack.Taskbar;
using StopWatch = System.Timers.Timer;
using WebMConverter.Components;
using WebMConverter.Dialogs;
using static WebMConverter.Utility;
using WebMConverter.Objects;
using Newtonsoft.Json;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace WebMConverter
{
    public partial class MainForm : Form
    {
        #region FFmpeg argument base strings

        /// <summary>
        /// {0} is output file
        /// {1} is TemplateArguments
        /// {2} is PassArgument if HQ mode enabled, otherwise blank
        /// {3} is format, can be mp4 and webm
        /// </summary>
        private const string Template = " {1}{2} -f {3} -y \"{0}\"";

        /// <summary>
        /// {0} is pass number (1 or 2)
        /// {1} is the prefix for the pass .log file
        /// </summary>
        private const string PassArgument = " -pass {0} -passlogfile \"{1}\" ";

        /// <summary>
        /// {0} is '-an' if no audio, otherwise blank
        /// {1} is amount of threads to use
        /// {2} is amount of slices to split the frame into
        /// {3} is ' -metadata title="TITLE"' when specifying a title, otherwise blank
        /// {4} is ' -lag-in-frames 16 -auto-alt-ref 1' when using HQ mode, otherwise blank
        /// {5} is 'libvpx(-vp9)' changing depending on NGOV mode
        /// {6} is ' -ac 2 -c:a libopus/libvorbis' if audio is enabled, changing depending on NGOV mode
        /// {7} is ' -r XX' if frame rate is modified, otherwise blank
        /// {8} is encoding mode-dependent arguments
        /// {9} is '-tile-columns 1 -row-mt 1' if VP9 is selectec, otherwise blank
        /// {10} is 'yuv420p' or 'yuva420p' when alpha is selected in advanced setings
        /// {11} is frame goal, just in case to decrease original frame rate
        /// </summary>
        private const string TemplateArguments = "{0} -c:v {5} -pix_fmt {10} -threads {1} -slices {2}{3}{4}{6}{7}{8}{9}{11}";

        /// <summary>
        /// {0} is video bitrate
        /// {1} is ' -fs XM' if X MB limit enabled otherwise blank
        /// </summary>
        private const string ConstantVideoArgumentsWebm = " -b:v {0}k -qcomp 0{1}";
        private const string ConstantVideoArgumentsMp4 = " -b:v {0}k{1}";
        /// <summary>
        /// {0} is audio bitrate
        /// </summary>
        private const string ConstantAudioArguments = " -b:a {0}k";

        /// <summary>
        /// {0} is qmin
        /// {1} is crf
        /// {2} is qmax
        /// </summary>
        private const string VariableVideoArguments = " -qmin {0} -crf {1} -qmax {2} -qcomp 1 -b:v 0";
        /// <summary>
        /// {0} is audio quality scale
        /// </summary>
        private const string VariableAudioArguments = " -qscale:a {0}";
        private const string AdvancedFilter = "eq=gamma={0}:saturation={1}:contrast={2}";
        private const string DarkFilter = "eq=gamma=0.6:saturation=2";
        private const string LightFilter = "eq=gamma=1.4:saturation=1.6";
        private const string LoopFilter = "[0]reverse[r];[0][r]concat,loop=2";
        private const string StabilizationFilter1 = @"-y -i ""{0}"" -vf vidstabdetect=stepsize=2:shakiness={1}:accuracy=15:result=transforms.trf -f null -";
        private const string StabilizationFilter2 = @"-y -i ""{0}"" -crf 16 -vf vidstabtransform=input=transforms.trf:interpol={1}:zoomspeed={2}:smoothing={3}:maxangle=0.0:maxshift=-1,unsharp=5:5:0.8:3:3:0.4 ""{4}""";
        private const string GridHorizontal = @"-i ""{0}"" -i ""{1}"" -filter_complex hstack  ""{2}"" -crf 16 -qcomp 1 -b:v 0";
        private const string GridVertical = @"-i ""{0}"" -i ""{1}"" -filter_complex vstack  ""{2}"" -crf 16 -qcomp 1 -b:v 0";

        #endregion

        private string _indexFile;
        private string _autoOutput;
        private string _autoTitle;
        private string _autoArguments;
        private bool _argumentError;
        private readonly string client_id = "2_yqoPwt";
        private readonly string client_secret = "ueECdMt4wIn6L7TybyqcUaTXbcZ2pBcs-EERURkI5ey00p6KxHYWmXLs8h6Mr7Lv";
        private readonly string prefixe = "http://127.0.0.1:57585/";
        public static readonly string VersionUrl = $"https://argorar.github.io/WebMConverter/NewUpdate/latest";
        private readonly Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        bool indexing;
        BackgroundWorker indexbw;

        StopWatch toolTipTimer;
        string avsScriptInfo;
        FileStream inputFile;

        int videotrack = -1;
        int audiotrack = -1;
        bool audioDisabled;
        bool yuvj420p;

        private List<string> _temporaryFilesList;

        public bool SarCompensate { get; set; }
        public int SarWidth { get; set; }
        public int SarHeight { get; set; }

        private TaskbarManager taskbarManager;
        private ToolTip toolTip = new ToolTip();

        public static ConcurrentDictionary<int, Bitmap> cache { get; set; }
        public static readonly int MAX_CAPACITY = 200;
        private const int MAX_PROCESS = 2;
        public static AspectRatio aspectRatio { get; set; }
        #region MainForm

        public MainForm()
        {
            FFMSSharp.FFMS2.Initialize(Path.Combine(Environment.CurrentDirectory, "Binaries", "Win64"));
            _temporaryFilesList = new List<string>();
            cache = new ConcurrentDictionary<int, Bitmap>(MAX_PROCESS, MAX_CAPACITY);
            aspectRatio = AspectRatio.None;
            InitializeComponent();
            this.KeyPreview = true;
            taskbarManager = TaskbarManager.Instance;
            groupGfycat.Visible = false;
            CheckAppSettings();
            CheckProccess();
            LoadConfiguration();
            ToolTip();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            ArrayList vidstabList = new ArrayList();
            vidstabList.Add(new Vidstab("2", "0.05", "2", "Very Weak"));
            vidstabList.Add(new Vidstab("4", "0.1", "4", "Weak"));
            vidstabList.Add(new Vidstab("6", "0.2", "6", "Medium"));
            vidstabList.Add(new Vidstab("8", "0.3", "10", "Strong"));
            vidstabList.Add(new Vidstab("10", "0.4", "16", "Very Strong"));
            vidstabList.Add(new Vidstab("10", "0.5", "22", "Strongest"));
            comboBoxLevels.DisplayMember = "desc";
            comboBoxLevels.DataSource = vidstabList;
            comboBoxLevels.SelectedIndex = 3;
            comboBoxLevels.Enabled = boxStabilization.Checked;
            comboStabType.Enabled = boxStabilization.Checked;
            comboStabType.SelectedIndex = 0;
        }

        private void CheckAppSettings()
        {
            if (!configuration.AppSettings.Settings.AllKeys.Contains("CRF4k"))
                configuration.AppSettings.Settings.Add("CRF4k", "16");

            if (!configuration.AppSettings.Settings.AllKeys.Contains("CRFother"))
                configuration.AppSettings.Settings.Add("CRFother", "30");

            if (!configuration.AppSettings.Settings.AllKeys.Contains("AllowMultiInstances"))
                configuration.AppSettings.Settings.Add("AllowMultiInstances", "False");

            if (!configuration.AppSettings.Settings.AllKeys.Contains("MP4"))
                configuration.AppSettings.Settings.Add("MP4", "False");

            if (!configuration.AppSettings.Settings.AllKeys.Contains("HAMP4"))
                configuration.AppSettings.Settings.Add("HAMP4", "False");

            if (!configuration.AppSettings.Settings.AllKeys.Contains("YTDLV"))
                configuration.AppSettings.Settings.Add("YTDLV", "20210505");

            if (!configuration.AppSettings.Settings.AllKeys.Contains("POP"))
                configuration.AppSettings.Settings.Add("POP", "False");

            if (!configuration.AppSettings.Settings.AllKeys.Contains("DWO"))
                configuration.AppSettings.Settings.Add("DWO", "False");

            if (!configuration.AppSettings.Settings.AllKeys.Contains("DisableUpdates"))
                configuration.AppSettings.Settings.Add("DisableUpdates", "False");
            
            if (!configuration.AppSettings.Settings.AllKeys.Contains("DisableSubtitles"))
                configuration.AppSettings.Settings.Add("DisableSubtitles", "False");

            if (!configuration.AppSettings.Settings.AllKeys.Contains("DisableMetadata"))
                configuration.AppSettings.Settings.Add("DisableMetadata", "False");
        }

        private void ToolTip()
        {
            toolTip.SetToolTip(comboLevels, "Apply differents filters to your video");
            toolTip.SetToolTip(boxDeinterlace, "Deinterlace an interlaced input video. Use trim to process only the important");
            toolTip.SetToolTip(boxDenoise, "Denoise the video, resulting in less detailed video but more bang for your buck when it comes to bitrate");
            toolTip.SetToolTip(boxLoop, "Forward and reverse effect merged");
            toolTip.SetToolTip(numericDelay, "Delay audio in your video, can be positive and negative. The value represent seconds");
            toolTip.SetToolTip(boxHQ, "Enables two-pass encoding and adds some extra encoding arguments, increasing output quality, but increases the time it takes to encode your file.");
        }

        private void CheckProccess()
        {
            if (configuration.AppSettings.Settings["AllowMultiInstances"].Value.Equals("false"))
            {
                Process thisProc = Process.GetCurrentProcess();
                if (Process.GetProcessesByName(thisProc.ProcessName).Length > 1)
                {
                    var result = MessageBox.Show(
                       $"Application is already running. If you continue, you can get errors.{Environment.NewLine}" +
                        "Do you want to disable this warning?",
                        "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        UpdateConfiguration("AllowMultiInstances", "true");
                        Dispose();
                    }
                    else if (result == DialogResult.Cancel)
                        Dispose();
                }
            }
        }

        private void LoadConfiguration()
        {
            if (configuration.AppSettings.Settings["HighQuality"].Value.Equals("true") || configuration.AppSettings.Settings["HighQuality"].Value.Equals("True"))
                boxHQ.Checked = true;
            else
                boxHQ.Checked = false;

            if (configuration.AppSettings.Settings["EncodingMode"].Value == EncodingMode.Constant.ToString())
                boxConstant.Checked = true;
            else
                boxVariable.Checked = true;

            if (configuration.AppSettings.Settings["AudioEnabled"].Value.Equals("true") || configuration.AppSettings.Settings["AudioEnabled"].Value.Equals("True"))
                boxAudio.Checked = true;
            else
                boxAudio.Checked = false;

            if (configuration.AppSettings.Settings["VP9"].Value.Equals("true") || configuration.AppSettings.Settings["VP9"].Value.Equals("True"))
                boxNGOV.Checked = true;
            else
                boxNGOV.Checked = false;

            if (configuration.AppSettings.Settings["MP4"].Value.Equals("True"))
                checkMP4.Checked = true;
            else
                checkMP4.Checked = false;

            if (configuration.AppSettings.Settings["HAMP4"].Value.Equals("True"))
                checkHWAcceleration.Checked = true;
            else
                checkHWAcceleration.Checked = false;

            if (configuration.AppSettings.Settings["POP"].Value.Equals("True"))
                boxDisablePop.Checked = true;
            else
                boxDisablePop.Checked = false;

            if (configuration.AppSettings.Settings["DisableUpdates"].Value.Equals("True"))
                boxDisableUpdates.Checked = true;
            else
                boxDisableUpdates.Checked = false;

            if (configuration.AppSettings.Settings["DWO"].Value.Equals("True"))
                boxDownloadOptions.Checked = true;
            else
                boxDownloadOptions.Checked = false;

            if (configuration.AppSettings.Settings["DisableSubtitles"].Value.Equals("True"))
                boxDisableExtractSubtitles.Checked = true;
            else
                boxDisableExtractSubtitles.Checked = false;

            if (configuration.AppSettings.Settings["DisableMetadata"].Value.Equals("True"))
                boxDisableMetadata.Checked = true;
            else
                boxDisableMetadata.Checked = false;

            if (!String.IsNullOrEmpty(configuration.AppSettings.Settings["PathDownload"].Value))
                textPathDownloaded.Text = configuration.AppSettings.Settings["PathDownload"].Value;

            CRF4k.Value = Decimal.Parse(configuration.AppSettings.Settings["CRF4k"].Value);
            CRFother.Value = Decimal.Parse(configuration.AppSettings.Settings["CRFother"].Value);
            checkBoxAlpha.Enabled = boxNGOV.Checked && !checkMP4.Checked;
            checkFixAudio.Enabled = boxAudio.Checked;
            Program.DisablePop = boxDisablePop.Checked;
            Program.DisableUpdates = boxDisableUpdates.Checked;
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            int threads = Environment.ProcessorCount;
            trackThreads.Value = Math.Min(trackThreads.Maximum, Math.Max(trackThreads.Minimum, threads));
            this.Text = string.Format(this.Text, Utility.GetVersion());
        }

        void HandleDragEnter(object sender, DragEventArgs e)
        {
            bool dataPresent = e.Data.GetDataPresent(DataFormats.FileDrop);
            e.Effect = dataPresent ? DragDropEffects.Copy : DragDropEffects.None;
        }

        void HandleDragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 1)
            {
                DropDialog dropDialog = new DropDialog();
                dropDialog.ShowDialog(this);
                if (dropDialog.option == DropOptions.Merge)
                    MergeVideoFile(files);
                else if (dropDialog.option == DropOptions.Convert)
                    ConvertBatch(files);

                return;
            }

            if (inputFile != null) // we have a file loaded already, so this might be a subtitle or something
            {
                switch (Path.GetExtension(files[0]))
                {
                    case ".srt":
                    case ".ass":
                        var filter = new SubtitleFilter(files[0], SubtitleType.TextSub);

                        if (boxAdvancedScripting.Checked)
                        {
                            textBoxProcessingScript.AppendText(Environment.NewLine + filter);
                        }
                        else
                        {
                            Filters.Subtitle = filter;
                            listViewProcessingScript.Items.Cast<ListViewItem>().Where(x => x.Text == "Subtitle").ToList().ForEach(listViewProcessingScript.Items.Remove);
                            listViewProcessingScript.Items.Add("Subtitle", "subtitles");
                            buttonSubtitle.Enabled = false;
                        }
                        return;
                    case ".png":
                    case ".jpeg":
                    case ".jpg":
                        using (var form = new OverlayForm(new OverlayFilter(new Point(0, 0), files[0])))
                        {
                            if (form.ShowDialog(this) != DialogResult.OK) return;

                            if (boxAdvancedScripting.Checked)
                            {
                                textBoxProcessingScript.AppendText(Environment.NewLine + form.GeneratedFilter);
                            }
                            else
                            {
                                Filters.Overlay = form.GeneratedFilter;
                                listViewProcessingScript.Items.Cast<ListViewItem>().Where(x => x.Text == "Overlay").ToList().ForEach(listViewProcessingScript.Items.Remove);
                                listViewProcessingScript.Items.Add("Overlay", "overlay");
                                buttonOverlay.Enabled = false;
                            }
                        }
                        return;
                    case ".wav":
                    case ".mp3":
                    case ".ogg":
                        using (var form = new DubForm(new DubFilter(files[0], null, DubMode.TrimAudio)))
                        {
                            if (form.ShowDialog(this) != DialogResult.OK) return;

                            if (boxAdvancedScripting.Checked)
                            {
                                textBoxProcessingScript.AppendText(Environment.NewLine + form.GeneratedFilter);
                            }
                            else
                            {
                                Filters.Dub = form.GeneratedFilter;
                                listViewProcessingScript.Items.Cast<ListViewItem>().Where(x => x.Text == "Dub").ToList().ForEach(listViewProcessingScript.Items.Remove);
                                listViewProcessingScript.Items.Add("Dub", "dub");

                                if (Filters.Dub.Mode != DubMode.TrimAudio) // the video duration may have changed
                                    UpdateArguments(sender, e);

                                buttonDub.Enabled = false;
                            }
                            boxAudio.Checked = boxAudio.Enabled = true;
                        }
                        return;
                    case ".mp4":
                    case ".avi":
                    case ".mkv":
                    case ".flv":
                    case ".mov":
                    case ".webm":
                        string path = files[0];
                        string fullPath = Path.GetDirectoryName(path);
                        string name = Path.GetFileNameWithoutExtension(path);
                        string format = checkMP4.Checked ? @".mp4" : @".webm";
                        textBoxOut.Text = Path.Combine(string.IsNullOrWhiteSpace(Properties.Settings.Default.RememberedFolderOut) ? fullPath : Properties.Settings.Default.RememberedFolderOut, name + format);
                        break;
                }
            }

            SetFile(files[0]);
        }

        private void ConvertBatch(string[] files)
        {

            string options = GenerateArguments();

            string format = checkMP4.Checked ? "mp4" : "webm";
            List<string> arguments = new List<string>();

            foreach (string file in files)
            {
                string directory = Path.GetDirectoryName(file);
                string auxName = Path.GetFileNameWithoutExtension(file);
                string output = $"{ directory }\\{ auxName}-converted.{ format}";
                string optionsWithInput = $@" -i ""{file}"" {options}";

                if (!boxHQ.Checked || checkHWAcceleration.Checked)
                    arguments.Add(string.Format(Template, output, optionsWithInput, "", format));
                else
                {
                    var passlogfile = GetTemporaryLogFile();
                    arguments.Add(string.Format(Template, "NUL", optionsWithInput, string.Format(PassArgument, 1, passlogfile), format));
                    arguments.Add(string.Format(Template, output, optionsWithInput, string.Format(PassArgument, 2, passlogfile), format));

                    if (!arguments[0].Contains("-an")) // skip audio encoding on the first pass
                        arguments[0] = arguments[0].Replace("-c:v libvpx", "-an -c:v libvpx");
                }
            }

            Program.Stabilization = null;
            Program.Loop = null;
            _ = new ConverterDialog(string.Empty, arguments.ToArray(), string.Empty).ShowDialog(this);
        }

        private void MergeVideoFile(string[] files)
        {
            string list = "Deus";
            StringBuilder content = new StringBuilder();
            string tempExtension = string.Empty;
            Dictionary<string, string> extensions = new Dictionary<string, string>();
            Array.Sort(files);
            foreach (string fileName in files)
            {
                content.Append($"file '{fileName.Replace("'", "\'")}'\n");
                tempExtension = Path.GetExtension(fileName);
                if (!extensions.ContainsKey(tempExtension))
                    extensions.Add(tempExtension, "");
            }

            // all the files need the same extension
            if (extensions.Count > 1)
            {
                MessageBox.Show("All the files must have the same extension", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            if (File.Exists(list))
                File.Delete(list);

            File.WriteAllText(list, content.ToString());

            string[] arguments = new string[1];
            string directory = Path.GetDirectoryName(files[0]);
            string auxName = Path.GetFileNameWithoutExtension(files[0]);
            string output = $"{ directory }\\{ auxName}-merged{ tempExtension}";
            arguments[0] = $" -f concat -safe 0 -i {list} -c:v copy -y \"{output}\"";
            new ConverterDialog(string.Empty, arguments, output).ShowDialog(this);
        }


        void MainForm_Shown(object sender, EventArgs e)
        {
            clearToolTip();

            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1) // We were "Open with..."ed with a file
                SetFile(args[1]);
            SendMessage(textBoxIn.Handle, EM_SETCUEBANNER, 0, "Paste URL here if you want to download a video");
            SendMessage(boxTags.Handle, EM_SETCUEBANNER, 0, "tag1,tag2,tag3...");
            this.ActiveControl = buttonBrowseIn;
            if (!Program.DisableUpdates)
            {
                CheckUpdate();
                CheckUpdateBinaries();
            }
        }

        private void CheckUpdateBinaries()
        {
            if (IsConnectedToInternet())
            {
                string installedVersion = configuration.AppSettings.Settings["YTDLV"].Value;
                UpdateBinaries updateBinaries = new UpdateBinaries(installedVersion);
                updateBinaries.GetLatestVersion();
            }
        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            inputFile?.Close();
            UnloadFonts();

            foreach (var temporaryFile in _temporaryFilesList)
            {
                if (File.Exists(temporaryFile))
                {
                    try
                    {
                        File.Delete(temporaryFile);
                    }
                    catch (Exception)
                    { //avoided
                    }
                }
            }
        }

        void boxIndexingProgressDetails_CheckedChanged(object sender, EventArgs e)
        {
            boxIndexingProgress.Visible = (sender as CheckBox).Checked;
            panelContainTheProgressBar.Location = new Point(
                panelHideTheOptions.ClientSize.Width / 2 - panelContainTheProgressBar.Size.Width / 2,
                panelHideTheOptions.ClientSize.Height / 2 - panelContainTheProgressBar.Size.Height / 2);
        }

        const int _boxIndexingProgressMaxLines = 11;
        void logIndexingProgress(string message)
        {
#if DEBUG
            Console.WriteLine(message);
#endif
            this.InvokeIfRequired(() =>
            {
                boxIndexingProgress.Text += message + Environment.NewLine;
                var indexingProgressLines = boxIndexingProgress.Text.Split('\n');
                if (indexingProgressLines.Length > _boxIndexingProgressMaxLines)
                    boxIndexingProgress.Text = string.Join(Environment.NewLine, indexingProgressLines.Skip(1));
            });
        }

        async void CheckUpdate()
        {
            try
            {
                string latestVersion;
                using (var updateChecker = new WebClient())
                    latestVersion = updateChecker.DownloadString(VersionUrl);

                var checker = new Updater();

                await Task.Run(() =>
                {
                    var checkerResult = checker.Check(Application.ProductVersion);

                    var success = checkerResult.Item1;
                    var updateAvailable = checkerResult.Item2;
                    var changelog = checkerResult.Item4;

                    if (!updateAvailable)
                    {
                        this.InvokeIfRequired(() =>
                        {
                            showToolTip("Up to date!", 1000);
                        });
                        return;
                    }

                    if (!success)
                    {
                        this.InvokeIfRequired(() =>
                        {
                            showToolTip("Update checking failed! ", 2000);
                        });
                        return;
                    }
                    this.InvokeIfRequired(() =>
                    {
                        var result = new UpdateNotifyDialog(latestVersion, changelog).ShowDialog(this);
                        if (result == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(checker.UpdaterPath, @"update");
                            Application.Exit();
                        }
                    });
                });
            }
            catch
            {
                // ignored
            }
        }

        [System.Diagnostics.DebuggerStepThrough]
        void setToolTip(string message)
        {
            if (this.IsDisposed || toolStripStatusLabel.IsDisposed)
                return;

            this.InvokeIfRequired(() =>
            {
                toolStripStatusLabel.Text = message;
            });
        }

        [System.Diagnostics.DebuggerStepThrough]
        void showToolTip(string message, int timer = 0)
        {
            clearToolTip();

            setToolTip(message);

            if (timer > 0)
            {
                toolTipTimer = new StopWatch(timer);
                toolTipTimer.Elapsed += (sender, e) => clearToolTip();
                toolTipTimer.AutoReset = false;
                toolTipTimer.Enabled = true;
            }
        }

        [System.Diagnostics.DebuggerStepThrough]
        void clearToolTip(object sender = null, EventArgs e = null)
        {
            if (toolTipTimer != null)
                toolTipTimer.Close();

            setToolTip("");
        }

        [System.Diagnostics.DebuggerStepThrough]
        void ToolStripItemTooltip(object sender, EventArgs e)
        {
            showToolTip((sender as ToolStripItem).AccessibleDescription);
        }

        [System.Diagnostics.DebuggerStepThrough]
        void ControlTooltip(object sender, EventArgs e)
        {
            showToolTip((sender as Control).AccessibleDescription);
        }

        private void opusQualityScalingTooltip()
        {
            if (boxNGOV.Checked && boxAudio.Checked && boxVariable.Checked)
                showToolTip("Audio quality scaling disabled -- Opus doesn't support it!", 5000);
        }

        #endregion

        #region groupMain

        void textBoxIn_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(textBoxIn.Text))
                    return;

                if (textBoxIn.Text.StartsWith("http"))
                {
                    buttonBrowseIn_Click(sender, null);
                    return;
                }

                SetFile(textBoxIn.Text);
            }
        }

        void buttonBrowseIn_Click(object sender, EventArgs e)
        {
            if (textBoxIn.Text.StartsWith("http"))
            {
                // we're a download button right now
                if (!VideoDownload.Enabled)
                {
                    var result = MessageBox.Show(
                       $"Couldn't find {Program.yt_dl}. Either download it and put it somewhere in your %PATH%, or place it inside Binaries/Win64.{Environment.NewLine}",
                        "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Retry)
                    {
                        VideoDownload.CheckEnabled();
                        buttonBrowseIn_Click(sender, e);
                        return;
                    }
                }

                if (!IsConnectedToInternet())
                {
                    var result = MessageBox.Show(
                       $"Make sure you are connected to internet.{Environment.NewLine}",
                        "ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Retry)
                    {
                        VideoDownload.CheckEnabled();
                        buttonBrowseIn_Click(sender, e);
                        return;
                    }
                    else
                        return;
                }

                if (String.IsNullOrEmpty(textPathDownloaded.Text))
                    FolderDownloads();

                if (boxDownloadOptions.Checked) {
                    using (var dialog = new DownloadOptionsDialog(textBoxIn.Text, textPathDownloaded.Text))
                    {
                        var result = dialog.ShowDialog(this);

                        if (result == DialogResult.OK)
                        {
                            var url = textBoxIn.Text;
                            textBoxIn.Text = dialog.GetOutfile();
                            buttonBrowseIn.Text = "Browse";
                            SetFile(textBoxIn.Text);
                            boxTitle.Text = url;
                        }
                    }
                }
                else
                {
                    using (var dialog = new DownloadDialog(textBoxIn.Text, textPathDownloaded.Text))
                    {
                        var result = dialog.ShowDialog(this);

                        if (result == DialogResult.OK)
                        {
                            var url = textBoxIn.Text;
                            textBoxIn.Text = dialog.GetOutfile();
                            buttonBrowseIn.Text = "Browse";
                            SetFile(textBoxIn.Text);
                            boxTitle.Text = url;
                        }
                    }
                }

            }
            else
            {
                using (var dialog = new OpenFileDialog())
                {
                    dialog.CheckFileExists = true;
                    dialog.CheckPathExists = true;
                    dialog.ValidateNames = true;
                    dialog.InitialDirectory = Properties.Settings.Default.RememberedFolderIn;

                    if (dialog.ShowDialog(this) != DialogResult.OK || string.IsNullOrWhiteSpace(dialog.FileName))
                        return;

                    SetFile(dialog.FileName);
                    Properties.Settings.Default.RememberedFolderIn = Path.GetDirectoryName(dialog.FileName);
                    Properties.Settings.Default.Save();
                }
            }
        }

        void buttonBrowseOut_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                string format = checkMP4.Checked ? ".mp4" : ".webm";
                dialog.OverwritePrompt = true;
                dialog.ValidateNames = true;
                dialog.Filter = $"WebM files|*{format}";
                dialog.InitialDirectory = Properties.Settings.Default.RememberedFolderOut;
                dialog.FileName = Path.ChangeExtension(Path.GetFileName(Program.InputFile), format);

                if (dialog.ShowDialog(this) != DialogResult.OK || string.IsNullOrWhiteSpace(dialog.FileName))
                    return;

                textBoxOut.Text = dialog.FileName;
                Properties.Settings.Default.RememberedFolderOut = Path.GetDirectoryName(dialog.FileName);
                Properties.Settings.Default.Save();
            }
        }

        void buttonGo_Click(object sender, EventArgs e)
        {
            if (indexing) // We are actually a cancel button right now.
            {
                indexbw.CancelAsync();
                (sender as Button).Enabled = false;
                return;
            }

            try
            {
                Convert();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void buttonPreview_Click(object sender, EventArgs e)
        {
            try
            {
                Preview();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region tabProcessing

        void buttonCaption_Click(object sender, EventArgs e)
        {
            using (var form = new CaptionForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (boxAdvancedScripting.Checked)
                    {
                        textBoxProcessingScript.AppendText(Environment.NewLine + form.GeneratedFilter.ToString());
                    }
                    else
                    {
                        Filters.Caption = form.GeneratedFilter;
                        listViewProcessingScript.Items.Add("Caption", "caption");
                        (sender as ToolStripItem).Enabled = false;
                    }
                }
            }
        }

        void buttonCrop_Click(object sender, EventArgs e)
        {
            using (var form = new CropForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (boxAdvancedScripting.Checked && form.GeneratedFilter != null)
                        textBoxProcessingScript.AppendText(Environment.NewLine + form.GeneratedFilter.ToString());

                    else if (boxAdvancedScripting.Checked && form.GeneratedCropPanFilter != null)
                        textBoxProcessingScript.AppendText(Environment.NewLine + form.GeneratedCropPanFilter.ToString());

                    else if (form.GeneratedFilter != null)
                        Filters.Crop = form.GeneratedFilter;

                    else
                    {
                        Filters.DynamicCrop = form.GeneratedCropPanFilter;
                        boxStabilization.Checked = true;
                    }


                    listViewProcessingScript.Items.Add("Crop", "crop");
                    SetSlices();
                    buttonCrop.Enabled = false;
                }
            }
        }

        private void buttonDub_Click(object sender, EventArgs e)
        {
            using (var form = new DubForm())
            {
                if (form.ShowDialog(this) != DialogResult.OK) return;

                if (boxAdvancedScripting.Checked)
                {
                    textBoxProcessingScript.AppendText(Environment.NewLine + form.GeneratedFilter);
                }
                else
                {
                    Filters.Dub = form.GeneratedFilter;
                    listViewProcessingScript.Items.Add("Dub", "dub");

                    if (Filters.Dub.Mode != DubMode.TrimAudio) // the video duration may have changed
                        UpdateArguments(sender, e);

                    ((ToolStripItem)sender).Enabled = false;
                }
                boxAudio.Checked = boxAudio.Enabled = true;
            }
        }

        void buttonFade_Click(object sender, EventArgs e)
        {
            using (var form = new FadeForm())
            {
                if (form.ShowDialog(this) != DialogResult.OK) return;

                if (boxAdvancedScripting.Checked)
                {
                    textBoxProcessingScript.AppendText(Environment.NewLine + form.GeneratedFilter);
                }
                else
                {
                    Filters.Fade = form.GeneratedFilter;
                    listViewProcessingScript.Items.Add("Fade", "fade");

                    ((ToolStripItem)sender).Enabled = false;
                }
            }
        }

        void buttonMultipleTrim_Click(object sender, EventArgs e)
        {
            using (var form = new MultipleTrimForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (boxAdvancedScripting.Checked)
                    {
                        textBoxProcessingScript.AppendText(Environment.NewLine + form.GeneratedFilter.ToString());
                    }
                    else
                    {
                        Filters.MultipleTrim = form.GeneratedFilter;
                        listViewProcessingScript.Items.Add("Multiple Trim", "trim");
                        UpdateArguments(sender, e);
                        buttonTrim.Enabled = false;
                    }
                }
            }
        }

        void buttonOverlay_Click(object sender, EventArgs e)
        {
            using (var form = new OverlayForm())
            {
                if (form.IsDisposed) // The user cancelled the file picker
                    return;

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (boxAdvancedScripting.Checked)
                    {
                        textBoxProcessingScript.AppendText(Environment.NewLine + form.GeneratedFilter.ToString());
                    }
                    else
                    {
                        Filters.Overlay = form.GeneratedFilter;
                        listViewProcessingScript.Items.Add("Overlay", "overlay");
                        (sender as ToolStripItem).Enabled = false;
                    }
                }
            }
        }

        private void buttonRate_Click(object sender, EventArgs e)
        {
            using (var form = new RateForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (boxAdvancedScripting.Checked)
                    {
                        textBoxProcessingScript.AppendText(Environment.NewLine + form.GeneratedFilter.ToString());
                    }
                    else
                    {
                        Filters.Rate = form.GeneratedFilter;
                        listViewProcessingScript.Items.Add("Rate", "rate");
                        UpdateArguments(sender, e);
                        buttonRate.Enabled = false;
                    }
                }
            }
        }

        void buttonResize_Click(object sender, EventArgs e)
        {
            using (var form = new ResizeForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (boxAdvancedScripting.Checked)
                    {
                        textBoxProcessingScript.AppendText(Environment.NewLine + form.GeneratedFilter.ToString());
                    }
                    else
                    {
                        Filters.Resize = form.GeneratedFilter;
                        listViewProcessingScript.Items.Add("Resize", "resize");
                        SetSlices();
                        (sender as ToolStripItem).Enabled = false;
                    }
                }
            }
        }

        void buttonReverse_Click(object sender, EventArgs e)
        {
            if (boxAdvancedScripting.Checked)
            {
                textBoxProcessingScript.AppendText(Environment.NewLine + new ReverseFilter().ToString());
            }
            else
            {
                Filters.Reverse = new ReverseFilter();
                listViewProcessingScript.Items.Add("Reverse", "reverse");
                (sender as ToolStripItem).Enabled = false;
            }
        }

        void buttonRotate_Click(object sender, EventArgs e)
        {
            using (var form = new RotateForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (boxAdvancedScripting.Checked)
                    {
                        textBoxProcessingScript.AppendText(Environment.NewLine + form.GeneratedFilter);
                    }
                    else
                    {
                        Filters.Rotate = form.GeneratedFilter;
                        listViewProcessingScript.Items.Add("Rotate", "rotate");
                        (sender as ToolStripItem).Enabled = false;
                    }
                }
            }
        }

        void buttonSubtitle_Click(object sender, EventArgs e)
        {
            using (var form = new SubtitleForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (boxAdvancedScripting.Checked)
                    {
                        textBoxProcessingScript.AppendText(Environment.NewLine + form.GeneratedFilter.ToString());
                    }
                    else
                    {
                        Filters.Subtitle = form.GeneratedFilter;
                        listViewProcessingScript.Items.Add("Subtitle", "subtitles");
                    }
                }
            }
        }

        void buttonTrim_Click(object sender, EventArgs e)
        {
            using (var form = new TrimForm(Filters.Trim != null ? Filters.Trim : null))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    Filters.Trim = form.GeneratedFilter;
                    if (boxAdvancedScripting.Checked)
                    {
                        textBoxProcessingScript.AppendText(Environment.NewLine + form.GeneratedFilter.ToString());
                    }
                    else
                    {
                        listViewProcessingScript.Items.Add("Trim", "trim");
                        UpdateArguments(sender, e);
                        buttonTrim.Enabled = false;
                    }
                }
            }
        }

        void buttonExportProcessing_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "AviSynth script (*.avs)|*.avs";
            dialog.FileName = Path.GetFileName(Path.ChangeExtension(Program.InputFile, "avs"));

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Generate the script if we're in simple mode
                if (!boxAdvancedScripting.Checked)
                    GenerateAvisynthScript();

                WriteAvisynthScript(dialog.FileName, Program.InputFile);
            }
        }

        void boxAdvancedScripting_Click(object sender, EventArgs e)
        {
            ProbeScript();
            (sender as ToolStripButton).Checked = !(sender as ToolStripButton).Checked;

            listViewProcessingScript.Hide();
            GenerateAvisynthScript();
            textBoxProcessingScript.Show();
            toolStripFilterButtonsEnabled(true);
            boxAudio.Enabled = true;

            (sender as ToolStripButton).Enabled = false;
            clearToolTip(sender, e);
        }

        void toolStripFilterButtonsEnabled(bool enabled)
        {
            buttonCaption.Enabled =
            buttonCrop.Enabled =
            buttonDub.Enabled =
            buttonFade.Enabled =
            buttonOverlay.Enabled =
            buttonRate.Enabled =
            buttonResize.Enabled =
            buttonReverse.Enabled =
            buttonRotate.Enabled =
            buttonSubtitle.Enabled =
            buttonTrim.Enabled =
            buttonExportProcessing.Enabled =
            buttonDynamic.Enabled =
                enabled;
        }

        void listViewProcessingScript_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem item in (sender as ListView).SelectedItems)
                {
                    removeFilter(item);
                }
            }
        }

        void listViewProcessingScript_ItemActivate(object sender, EventArgs e)
        {
            switch ((sender as ListView).FocusedItem.Text)
            {
                case "Caption":
                    using (var form = new CaptionForm(Filters.Caption))
                    {
                        if (form.ShowDialog(this) == DialogResult.OK)
                        {
                            Filters.Caption = form.GeneratedFilter;
                        }
                    }
                    break;
                case "Crop":
                    EditCropFilter(sender, e);
                    break;
                case @"Dub":
                    using (var form = new DubForm(Filters.Dub))
                    {
                        if (form.ShowDialog(this) == DialogResult.OK)
                        {
                            var oldfilter = Filters.Dub;
                            Filters.Dub = form.GeneratedFilter;
                            if (oldfilter.Mode != DubMode.TrimAudio || Filters.Dub.Mode != DubMode.TrimAudio) // the video duration may have changed
                                UpdateArguments(sender, e);
                        }
                    }
                    break;
                case "Fade":
                    using (var form = new FadeForm(Filters.Fade))
                    {
                        if (form.ShowDialog(this) == DialogResult.OK)
                        {
                            Filters.Fade = form.GeneratedFilter;
                        }
                    }
                    break;
                case "Multiple Trim":
                    EditMultiTrimFilter(sender, e);
                    break;
                case "Overlay":
                    using (var form = new OverlayForm(Filters.Overlay))
                    {
                        if (form.ShowDialog(this) == DialogResult.OK)
                        {
                            Filters.Overlay = form.GeneratedFilter;
                        }
                    }
                    break;
                case "Rate":
                    EditRateFilter(sender, e);
                    break;
                case "Resize":
                    using (var form = new ResizeForm(Filters.Resize))
                    {
                        if (form.ShowDialog(this) == DialogResult.OK)
                        {
                            Filters.Resize = form.GeneratedFilter;
                            SetSlices();
                        }
                    }
                    break;
                case "Rotate":
                    using (var form = new RotateForm(Filters.Rotate))
                    {
                        if (form.ShowDialog(this) == DialogResult.OK)
                        {
                            Filters.Rotate = form.GeneratedFilter;
                        }
                    }
                    break;
                case "Subtitle":
                    using (var form = new SubtitleForm(Filters.Subtitle))
                    {
                        if (form.ShowDialog(this) == DialogResult.OK)
                        {
                            Filters.Subtitle = form.GeneratedFilter;
                        }
                    }
                    break;
                case "Trim":
                    EditTrimFilter(sender, e);
                    break;
                case "Dynamic":
                    var filter = Filters.Trim == null ? new TrimFilter(0, Program.VideoSource.NumberOfFrames - 1) : Filters.Trim;
                    using (var form = new DynamicForm(filter, Filters.Dynamic))
                    {
                        if (form.ShowDialog(this) == DialogResult.OK)
                        {
                            Filters.Dynamic = form.GeneratedFilter;
                        }
                    }
                    break;
                default:
                    MessageBox.Show("This filter has no options.");
                    break;
            }
        }

        private void listViewProcessingScript_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listViewProcessingScript.FocusedItem.Bounds.Contains(e.Location))
                listViewContextMenu.Show(listViewProcessingScript, e.Location);
        }

        private void listViewContextMenuEdit_Click(object sender, EventArgs e)
        {
            listViewProcessingScript_ItemActivate(listViewProcessingScript, e);
        }

        private void listViewContextMenuDelete_Click(object sender, EventArgs e)
        {
            removeFilter(listViewProcessingScript.FocusedItem);
        }

        void removeFilter(ListViewItem filterListViewItem)
        {
            listViewProcessingScript.Items.Remove(filterListViewItem);
            switch (filterListViewItem.Text)
            {
                case "Caption":
                    Filters.Caption = null;
                    buttonCaption.Enabled = true;
                    break;
                case "Crop":
                    Filters.Crop = null;
                    Filters.DynamicCrop = null;
                    buttonCrop.Enabled = true;
                    boxStabilization.Checked = false;
                    SetSlices();
                    break;
                case @"Dub":
                    var oldfilter = Filters.Dub;
                    Filters.Dub = null;
                    buttonDub.Enabled = true;
                    if (oldfilter.Mode != DubMode.TrimAudio) // the video duration may have changed
                        UpdateArguments();
                    if (!Program.InputHasAudio)
                        boxAudio.Checked = boxAudio.Enabled = false;
                    break;
                case "Fade":
                    Filters.Fade = null;
                    buttonFade.Enabled = true;
                    break;
                case "Multiple Trim":
                    Filters.MultipleTrim = null;
                    buttonTrim.Enabled = true;
                    UpdateArguments();
                    break;
                case "Overlay":
                    Filters.Overlay = null;
                    buttonOverlay.Enabled = true;
                    break;
                case "Rate":
                    Filters.Rate = null;
                    buttonRate.Enabled = true;
                    UpdateArguments();
                    break;
                case "Resize":
                    Filters.Resize = null;
                    buttonResize.Enabled = true;
                    SetSlices();
                    break;
                case "Rotate":
                    Filters.Rotate = null;
                    buttonRotate.Enabled = true;
                    break;
                case "Reverse":
                    Filters.Reverse = null;
                    buttonReverse.Enabled = true;
                    break;
                case "Subtitle":
                    Filters.Subtitle = null;
                    buttonSubtitle.Enabled = true;
                    break;
                case "Trim":
                    Filters.Trim = null;
                    buttonTrim.Enabled = true;
                    GenerateArguments();
                    break;
                case "Dynamic":
                    Filters.Dynamic = null;
                    buttonDynamic.Enabled = true;
                    UpdateArguments();
                    break;
            }
        }

        void textBoxProcessingScript_Leave(object sender, EventArgs e)
        {
            ProbeScript();
            SetSlices();
            UpdateArguments(sender, e);
        }

        #endregion

        #region tabEncoding

        void textBoxNumbersOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
                e.Handled = true;
        }

        EncodingMode encodingMode = EncodingMode.Constant;

        void boxConstant_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as RadioButton).Checked) return;

            tableVideoConstantOptions.BringToFront();
            tableAudioConstantOptions.BringToFront();
            encodingMode = EncodingMode.Constant;
            boxLimit.TabStop = boxBitrate.TabStop = boxAudioBitrate.TabStop = true;
            numericCrf.TabStop = numericCrfTolerance.TabStop = numericAudioQuality.TabStop = false;

            buttonVariableDefault.Visible = false;
            if (boxConstant.Checked)
                UpdateConfiguration("EncodingMode", EncodingMode.Constant.ToString());

            UpdateArguments(sender, e);
        }

        private void BoxHighQuality_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConfiguration("HighQuality", boxHQ.Checked.ToString());
            UpdateArguments(sender, e);
        }

        void buttonConstantDefault_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.EncodingMode = EncodingMode.Constant;
            Properties.Settings.Default.Save();
            buttonConstantDefault.Visible = false;

            showToolTip("Saved!", 1000);
        }

        void boxVariable_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as RadioButton).Checked) return;

            tableVideoVariableOptions.BringToFront();
            tableAudioVariableOptions.BringToFront();
            encodingMode = EncodingMode.Variable;
            numericCrf.TabStop = numericCrfTolerance.TabStop = numericAudioQuality.TabStop = true;
            boxLimit.TabStop = boxBitrate.TabStop = boxAudioBitrate.TabStop = false;

            buttonConstantDefault.Visible = false;

            if (boxVariable.Checked)
                UpdateConfiguration("EncodingMode", EncodingMode.Variable.ToString());

            UpdateArguments(sender, e);

            opusQualityScalingTooltip();
        }

        void buttonVariableDefault_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.EncodingMode = EncodingMode.Variable;
            Properties.Settings.Default.Save();
            buttonVariableDefault.Visible = false;

            showToolTip("Saved!", 1000);
        }

        void boxAudio_CheckedChanged(object sender, EventArgs e)
        {
            numericAudioQuality.Enabled = boxAudioBitrate.Enabled = numericDelay.Enabled = ((CheckBox)sender).Checked ;
            checkFixAudio.Enabled = boxAudio.Checked;
            numericNormalization.Enabled = boxAudio.Checked;

            if (boxNGOV.Checked)
                numericAudioQuality.Enabled = false;

            UpdateConfiguration("AudioEnabled", boxAudio.Checked.ToString());
            UpdateArguments(sender, e);
            opusQualityScalingTooltip();
        }

        #endregion

        #region tabAdvanced

        void trackThreads_ValueChanged(object sender, EventArgs e)
        {
            labelThreads.Text = (sender as TrackBar).Value.ToString();
            UpdateArguments(sender, e);
        }

        void trackSlices_ValueChanged(object sender, EventArgs e)
        {
            labelSlices.Text = GetSlices().ToString();
            UpdateArguments(sender, e);
        }

        private void boxNGOV_CheckedChanged(object sender, EventArgs e)
        {
            numericAudioQuality.Enabled = !(sender as CheckBox).Checked;
            checkBoxAlpha.Enabled = (sender as CheckBox).Checked;
            UpdateArguments(sender, e);
            UpdateConfiguration("VP9", boxNGOV.Checked.ToString());
            opusQualityScalingTooltip();
        }

        #endregion

        #region Functions

        private void DefaultSettings()
        {
            boxTitle.Text =
            boxLimit.Text =
            boxBitrate.Text =
            boxAudioBitrate.Text =
            boxFrameRate.Text =
            boxArguments.Text =
                string.Empty;

            boxDeinterlace.Checked =
            boxDenoise.Checked =
                false;

            numericCrf.Value = 30;
            numericCrfTolerance.Value = 2;
            numericAudioQuality.Value = 10;
            numericGamma.Value = 1;
            numericSaturation.Value = 1;
            numericContrast.Value = 1;
            numericDelay.Value = 0;
            numericNormalization.Value = 1;
            comboLevels.SelectedIndex = 0;

            var threads = Environment.ProcessorCount;
            trackThreads.Value = Math.Min(trackThreads.Maximum, Math.Max(trackThreads.Minimum, threads));
            cache.Clear();
            aspectRatio = AspectRatio.None;
        }

        char[] invalidChars = Path.GetInvalidPathChars();

        void SetFile(string path)
        {
            Utility.FlushMem();
            try
            {
                ValidateInputFile(path);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            inputFile?.Close();
            UnloadFonts();

            textBoxIn.Text = path;
            string fullPath = Path.GetDirectoryName(path);
            string name = Path.GetFileNameWithoutExtension(path);
            string title = name;
            string format = checkMP4.Checked ? @".mp4" : @".webm";
            if (textBoxOut.Text == _autoOutput || textBoxOut.Text == "")
                textBoxOut.Text = _autoOutput = Path.Combine(string.IsNullOrWhiteSpace(Properties.Settings.Default.RememberedFolderOut) ? fullPath : Properties.Settings.Default.RememberedFolderOut, name + format);
            audioDisabled = false;

            progressBarIndexing.Style = ProgressBarStyle.Marquee;
            taskbarManager.SetProgressState(TaskbarProgressBarState.Indeterminate);
            boxIndexingProgress.Text = "";
            panelHideTheOptions.BringToFront();

            buttonGo.Enabled = false;
            buttonPreview.Enabled = false;
            buttonPreview2.Enabled = false;
            buttonBrowseIn.Enabled = false;
            textBoxIn.Enabled = false;

            inputFile = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);

            // Reset filters
            Filters.ResetFilters();
            DefaultSettings();
            listViewProcessingScript.Clear();
            boxAdvancedScripting.Checked = false; // STUB: this part is weak
            boxAdvancedScripting.Enabled = true;
            textBoxProcessingScript.Hide();
            listViewProcessingScript.Show();
            SarCompensate = false;

            if (Path.GetExtension(path) == ".avs")
            {
                Program.InputFile = path;
                Program.InputType = FileType.Avisynth;

                BackgroundWorker probebw = new BackgroundWorker();
                probebw.DoWork += delegate (object sender, DoWorkEventArgs e)
                {
                    ProbeScript();
                };
                probebw.RunWorkerCompleted += delegate (object sender, RunWorkerCompletedEventArgs e)
                {
                    boxAdvancedScripting.Enabled = false;
                    listViewProcessingScript.Enabled = false;
                    showToolTip("You're loading an AviSynth script, so Processing is disabled!", 3000);

                    comboLevels.Enabled = boxDeinterlace.Enabled = boxDenoise.Enabled = false;
                    buttonGo.Enabled = buttonBrowseIn.Enabled = textBoxIn.Enabled = true;
                    toolStripFilterButtonsEnabled(false);
                    panelHideTheOptions.SendToBack();
                };

                labelIndexingProgress.Text = "Probing script...";
                probebw.RunWorkerAsync();
                return;
            }
            else
            {
                Program.InputFile = path;
                Program.InputType = FileType.Video;
                Program.FileMd5 = null;
                listViewProcessingScript.Enabled = true;
                comboLevels.Enabled = boxDeinterlace.Enabled = boxDenoise.Enabled = true;
            }

            GenerateAvisynthScript();

            // Hash some of the file to make sure we didn't index it already
            labelIndexingProgress.Text = "Hashing...";
            logIndexingProgress("Hashing...");
            using (MD5 md5 = MD5.Create())
            using (FileStream stream = File.OpenRead(path))
            {
                var filename = new UTF8Encoding().GetBytes(name);
                var buffer = new byte[4096];

                filename.CopyTo(buffer, 0);
                stream.Read(buffer, filename.Length, 4096 - filename.Length);

                Program.FileMd5 = BitConverter.ToString(md5.ComputeHash(buffer));
                logIndexingProgress("File hash is " + Program.FileMd5.Replace("-", ""));
                _indexFile = Path.Combine(Path.GetTempPath(), Program.FileMd5 + ".ffindex");
            }

            FFMSSharp.Index index = null;
            indexbw = new BackgroundWorker();
            BackgroundWorker extractbw = new BackgroundWorker();

            indexbw.WorkerSupportsCancellation = true;
            indexbw.WorkerReportsProgress = true;
            indexbw.ProgressChanged += new ProgressChangedEventHandler(delegate (object sender, ProgressChangedEventArgs e)
            {
                this.progressBarIndexing.Value = e.ProgressPercentage;
                if(e.ProgressPercentage != 1)
                    taskbarManager.SetProgressValue(e.ProgressPercentage, 100);
            });
            indexbw.DoWork += delegate (object sender, DoWorkEventArgs e)
            {
                logIndexingProgress("Indexing starting...");
                using (FFMSSharp.Indexer indexer = new FFMSSharp.Indexer(path, FFMSSharp.Source.Lavf))
                {

                    indexer.UpdateIndexProgress += delegate (object sendertwo, FFMSSharp.IndexingProgressChangeEventArgs etwo)
                    {
                        indexbw.ReportProgress((int)(etwo.Current / (double)etwo.Total * 100));
                        indexer.CancelIndexing = indexbw.CancellationPending;
                    };

                    try
                    {
                        if (!audioDisabled) // Indexing failed because of the audio, so the user disabled it.
                            indexer.SetTrackTypeIndexSettings(FFMSSharp.TrackType.Audio, true);

                        index = indexer.Index();
                    }
                    catch (OperationCanceledException)
                    {
                        audioDisabled = false; // This enables us to cancel the bw even if audio was disabled by the user.
                        e.Cancel = true;
                        return;
                    }
                    catch (Exception error)
                    {
                        logIndexingProgress(error.Message);

                        if (error.Message.StartsWith("Audio format change detected") || error.Message.StartsWith("Audio decoding error"))
                        {
                            DialogResult result = DialogResult.Cancel;

                            this.InvokeIfRequired(() =>
                            {
                                result = MessageBox.Show(
                                    $"Indexing error: {error.Message}{Environment.NewLine}" +
                                    $"If you were planning on making a WebM with audio, I'm afraid that's not going to happen.{Environment.NewLine}" +
                                    "Would you like to index the file without audio?",
                                    "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            });

                            audioDisabled = (result == DialogResult.OK);
                        }
                        else
                        {
                            MessageBox.Show(error.Message);
                        }
                        e.Cancel = true;
                        return;
                    }

                    index.WriteIndex(_indexFile);
                }
            };
            extractbw.DoWork += new DoWorkEventHandler(delegate
            {
                logIndexingProgress("Extraction starting...");

                List<int> videoTracks = new List<int>(), audioTracks = new List<int>();
                for (int i = 0; i < index.NumberOfTracks; i++)
                {
                    if (index.GetTrack(i).TrackType == FFMSSharp.TrackType.Video)
                        videoTracks.Add(i);
                    else if (index.GetTrack(i).TrackType == FFMSSharp.TrackType.Audio)
                        audioTracks.Add(i);
                }

                if (videoTracks.Count == 0)
                    throw new Exception("No video tracks found!");

                else if (videoTracks.Count == 1)
                {
                    videotrack = videoTracks[0];
                }
                else
                {
                    this.InvokeIfRequired(() =>
                    {
                        var dialog = new TrackSelectDialog("Video", videoTracks);
                        logIndexingProgress("Waiting for user input...");
                        dialog.ShowDialog(this);
                        videotrack = dialog.SelectedTrack;
                    });
                }

                if (!audioDisabled)
                {
                    if (audioTracks.Count == 0)
                    {
                        audioDisabled = true;
                    }
                    else if (audioTracks.Count == 1)
                    {
                        audiotrack = audioTracks[0];
                        audioDisabled = false;
                    }
                    else
                    {
                        this.InvokeIfRequired(() =>
                        {
                            var dialog = new TrackSelectDialog("Audio", audioTracks);
                            logIndexingProgress("Waiting for user input...");
                            dialog.ShowDialog(this);
                            audiotrack = dialog.SelectedTrack;
                        });
                        audioDisabled = false;
                    }
                }

                Program.AttachmentDirectory = Path.Combine(Path.GetTempPath(), Program.FileMd5 + ".attachments");
                Directory.CreateDirectory(Program.AttachmentDirectory);

                logIndexingProgress("Probing input file...");
                using (var prober = new FFprobe(Program.InputFile, format: "", argument: "-show_streams -show_format"))
                {
                    string streamInfo = prober.Probe();
                    Program.SubtitleTracks = new Dictionary<int, Tuple<string, SubtitleType, string>>();
                    Program.AttachmentList = new List<string>();

                    using (var s = new StringReader(streamInfo))
                    {
                        var doc = new XPathDocument(s);
                        var attachindex = 0; // mkvextract separates track and attachment indices

                        foreach (XPathNavigator nav in doc.CreateNavigator().Select("//ffprobe/streams/stream"))
                        {
                            int streamindex;
                            string streamtitle;
                            string file;

                            streamindex = int.Parse(nav.GetAttribute("index", ""));

                            switch (nav.GetAttribute("codec_type", ""))
                            {
                                case "video":
                                    if (streamindex != videotrack) break;

                                    if (nav.GetAttribute("pix_fmt", "") == "yuvj420p")
                                    {
                                        logIndexingProgress("Detected yuvj420p video, the Color Level fixing setting has been set for you.");
                                        yuvj420p = true;
                                    }
                                    else
                                    {
                                        yuvj420p= false;    
                                    }

                                    // Check if this is a Hi444p video - if so, we'll need to do something weird if you wanna add subs later.
                                    Program.InputHasWeirdPixelFormat = nav.GetAttribute("pix_fmt", "").StartsWith("yuv444p");

                                    // Probe for sample aspect ratio
                                    string[] sar = null, dar = null;

                                    sar = nav.GetAttribute("sample_aspect_ratio", "").Split(':');
                                    if ((sar[0] == "1" && sar[1] == "1") || (sar[0] == "0" || sar[1] == "0")) break;

                                    dar = nav.GetAttribute("display_aspect_ratio", "").Split(':');

                                    float SarNum, SarDen, DarNum, DarDen;
                                    SarNum = float.Parse(sar[0]);
                                    SarDen = float.Parse(sar[1]);
                                    DarNum = float.Parse(dar[0]);
                                    DarDen = float.Parse(dar[1]);

                                    SarWidth = int.Parse(nav.GetAttribute("width", ""));
                                    SarHeight = int.Parse(nav.GetAttribute("height", ""));

                                    if (DarNum < DarDen)
                                        SarHeight = (int)(SarHeight / (SarNum / SarDen));

                                    else
                                        SarWidth = (int)(SarWidth * (SarNum / SarDen));

                                    SarCompensate = true;
                                    logIndexingProgress("We need to compensate for Sample Aspect Ratio, it seems.");

                                    break;
                                case "subtitle": // Extract the subtitle file
                                    if (boxDisableExtractSubtitles.Checked)
                                        break;
                                    // Get a title
                                    streamtitle = nav.GetAttribute("codec_name", "");
                                    SubtitleType type;
                                    string extension;

                                     switch (streamtitle)
                                    {
                                        case "dvdsub":
                                            type = SubtitleType.VobSub;
                                            extension = ".idx";
                                            break;
                                        case "pgssub":
                                            type = SubtitleType.PgsSub;
                                            extension = ".sup";
                                            break;
                                        case "webvtt":
                                            type = SubtitleType.VTTSub;
                                            extension = ".srt";
                                            break;
                                        default:
                                            type = SubtitleType.TextSub;
                                            extension = "." + streamtitle;
                                            break;
                                    }

                                    file = Path.Combine(Program.AttachmentDirectory, $"sub{streamindex}{extension}");
                                    logIndexingProgress($"Found subtitle track #{streamindex}");

                                    if (type == SubtitleType.VTTSub && !File.Exists(file))
                                    {
                                        logIndexingProgress("Extracting vtt...");
                                        ExecuteFFmpegCommand($@" -i ""{Program.InputFile}"" -map 0:{streamindex} ""{file}""");
                                    }                                    
                                    else if (!File.Exists(file)) // If we didn't extract it already
                                    {
                                        logIndexingProgress("Extracting...");
                                        using (var mkvextract = new MkvExtract($@"tracks ""{Program.InputFile}"" ""{streamindex}:{file}"""))
                                        {
                                            mkvextract.Start();
                                            mkvextract.WaitForExit();
                                        }
                                    }
                                    else
                                    {
                                        logIndexingProgress("Already extracted! Skipping...");
                                    }

                                    if (!File.Exists(file))
                                        break;

                                    if (!nav.IsEmptyElement) // There might be a tag element
                                    {
                                        nav.MoveTo(nav.SelectSingleNode(".//tag[@key='title']"));
                                        var titleTag = nav.GetAttribute("value", "");

                                        streamtitle = titleTag == "" ? streamtitle : titleTag;
                                    }

                                    Program.SubtitleTracks.Add(streamindex, new Tuple<string, SubtitleType, string>(streamtitle, type, extension));
                                    break;
                                case @"attachment": // Extract the attachment using mkvmerge
                                    nav.MoveTo(nav.SelectSingleNode(".//tag[@key='filename']"));
                                    var filename = nav.GetAttribute("value", "");

                                    nav.MoveToNext();
                                    var mimetype = nav.GetAttribute("value", "");

                                    file = Path.Combine(Program.AttachmentDirectory, filename);
                                    logIndexingProgress($"Found attachment '{filename}'");

                                    attachindex += 1;

                                    if (!mimetype.Contains(@"font"))
                                    {
                                        logIndexingProgress("Not a font! Skipping...");
                                        break;
                                    }

                                    Program.AttachmentList.Add(filename);

                                    if (File.Exists(file)) // Did we extract it already?
                                    {
                                        logIndexingProgress("Already extracted! Skipping...");
                                        break;
                                    }

                                    logIndexingProgress("Extracting...");
                                    using (var mkvextract = new MkvExtract($@"attachments ""{Program.InputFile}"" ""{attachindex}:{file}"""))
                                    {
                                        mkvextract.Start();
                                        mkvextract.WaitForExit();
                                    }
                                    break;
                            }
                        }

                        var selectSingleNode = doc.CreateNavigator().SelectSingleNode("//ffprobe/format/tag[@key='title']");
                        if (selectSingleNode != null)
                        {
                            title = selectSingleNode.GetAttribute("value", "");
                            logIndexingProgress("Found title " + title);
                        }
                    }
                }

                Program.VideoSource = index.VideoSource(path, videotrack, Environment.ProcessorCount);
                index.Dispose();
                var frame = Program.VideoSource.GetFrame(0); // We're assuming that the entire video has the same settings here, which should be fine. (These options usually don't vary, I hope.)
                Program.VideoColorRange = frame.ColorRange;
                Program.VideoInterlaced = frame.InterlacedFrame;
                Program.Resolution = frame.EncodedResolution;
                SetCRF(frame.EncodedResolution);
                SetSlices(frame.EncodedResolution);
                SetFPS();
                LoadFonts(msg => logIndexingProgress((string)msg));
            });
            indexbw.RunWorkerCompleted += delegate (object sender, RunWorkerCompletedEventArgs e)
            {
                if (audioDisabled && e.Cancelled)
                {
                    logIndexingProgress("Restarting indexing without audio");
                    indexbw.RunWorkerAsync();
                    return;
                }

                indexing = false;
                buttonGo.Enabled = false;
                buttonGo.Text = "Convert";

                if (e.Cancelled)
                    CancelIndexing();
                else
                {
                    labelIndexingProgress.Text = "Extracting subtitle tracks and attachments...";
                    progressBarIndexing.Style = ProgressBarStyle.Marquee;
                    taskbarManager.SetProgressState(TaskbarProgressBarState.Indeterminate);

                    extractbw.RunWorkerAsync();
                }
            };
            extractbw.RunWorkerCompleted += delegate (object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Error != null)
                {
                    CancelIndexing();
                    MessageBox.Show($"We couldn't find any video tracks!{Environment.NewLine}Please use another input file.{e.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                boxAudio.Enabled = Program.InputHasAudio = true;
                if (audioDisabled)
                    boxAudio.Checked = boxAudio.Enabled = Program.InputHasAudio = false;

                buttonGo.Enabled = true;
                buttonPreview.Enabled = true;
                buttonPreview2.Enabled = true;
                buttonBrowseIn.Enabled = true;
                textBoxIn.Enabled = true;
                toolStripFilterButtonsEnabled(true);

                if ((boxTitle.Text == _autoTitle || boxTitle.Text == "") && !boxDisableMetadata.Checked)
                    boxTitle.Text = _autoTitle = title;

                if (Program.VideoColorRange == FFMSSharp.ColorRange.MPEG && Program.VideoInterlaced)
                    boxDeinterlace.Checked = true;

                panelHideTheOptions.SendToBack();
                taskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
                ValidateInOutput();
            };

            if (File.Exists(_indexFile))
            {
                try
                {
                    index = new FFMSSharp.Index(_indexFile);

                    if (index.BelongsToFile(path))
                    {
                        try
                        {
                            index.GetFirstIndexedTrackOfType(FFMSSharp.TrackType.Audio);
                        }
                        catch (KeyNotFoundException)
                        {
                            audioDisabled = true;
                        }

                        labelIndexingProgress.Text = "Extracting subtitle tracks and attachments...";
                        progressBarIndexing.Style = ProgressBarStyle.Marquee;
                        taskbarManager.SetProgressState(TaskbarProgressBarState.Indeterminate);

                        extractbw.RunWorkerAsync();
                        return;
                    }
                }
                catch
                {
                    File.Delete(_indexFile);
                }
            }

            indexing = true;
            buttonGo.Enabled = true;
            buttonGo.Text = "Cancel";
            progressBarIndexing.Value = 0;
            progressBarIndexing.Style = ProgressBarStyle.Continuous;
            taskbarManager.SetProgressState(TaskbarProgressBarState.Normal);
            labelIndexingProgress.Text = "Indexing...";
            indexbw.RunWorkerAsync();
        }

        private void ValidateInOutput()
        {
            if (textBoxIn.Text.Equals(textBoxOut.Text))
            {
                string filename = Path.GetFileNameWithoutExtension(textBoxOut.Text);
                string extension = Path.GetExtension(textBoxOut.Text);
                string directory = Path.GetDirectoryName(textBoxOut.Text);
                textBoxOut.Text = $"{directory}\\{filename}-1{extension}";
            }
        }

        private void SetFPS()
        {
            int originalFPS = (int)(Program.VideoSource.NumberOfFrames / Program.VideoSource.LastTime);
            Program.originalFraps = originalFPS;
            this.InvokeIfRequired(() =>
            {
                SendMessage(boxFrameRate.Handle, EM_SETCUEBANNER, 0, $"Original FPS {originalFPS}");
            });
        }

        private void SetCRF(Size resolution)
        {
            if (resolution.Width > 2000)
                this.InvokeIfRequired(() =>
                {
                    numericCrf.Value = Decimal.Parse(configuration.AppSettings.Settings["CRF4k"].Value);
                });
            else
                this.InvokeIfRequired(() =>
                {
                    numericCrf.Value = Decimal.Parse(configuration.AppSettings.Settings["CRFother"].Value);
                });
        }

        void CancelIndexing()
        {
            textBoxIn.Text = "";
            textBoxOut.Text = "";
            Program.InputFile = null;
            Program.FileMd5 = null;
            buttonBrowseIn.Enabled = true;
            textBoxIn.Enabled = true;
            taskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
            panelHideTheOptions.SendToBack();
        }

        void ValidateInputFile(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new Exception("No input file!");

            if (invalidChars.Any(input.Contains))
                throw new Exception($"Input path contains invalid characters!{Environment.NewLine}Invalid characters: " + string.Join(" ", invalidChars));

            if (!File.Exists(input))
                throw new Exception("Input file doesn't exist!");
        }

        void ValidateOutputFile(string output)
        {
            if (string.IsNullOrWhiteSpace(output))
                throw new Exception("No output file!");

            if (invalidChars.Any(output.Contains))
                throw new Exception("Output path contains invalid characters!\nInvalid characters: " + string.Join(" ", invalidChars));
        }

        void UpdateArguments(object sender, EventArgs e) => UpdateArguments();
        void UpdateArguments()
        {
            if (Program.InputFile == null)
                return;

            try
            {
                string arguments = GenerateArguments();
                if (arguments != _autoArguments || _argumentError)
                {
                    boxArguments.Text = _autoArguments = arguments;
                    showToolTip(arguments, 5000);
                    _argumentError = false;
                }
            }
            catch (ArgumentException argExc)
            {
                boxArguments.Text = "ERROR: " + argExc.Message;
                showToolTip("ERROR: " + argExc.Message, 5000);
                _argumentError = true;
            }
        }

        void WriteAvisynthScript(string avsFileName, string avsInputFile)
        {
            using (StreamWriter avscript = new StreamWriter(avsFileName, false))
            {
                var pluginPath = Path.Combine(Environment.CurrentDirectory, "Binaries", "Win32");
                var shortPluginPath = GetCompatiblePath(pluginPath);

                string version = checkFixAudio.Checked ? "1" : "2";
                avscript.WriteLine($@"PluginPath = ""{shortPluginPath}\""");
                avscript.WriteLine(@"try { LoadPlugin(PluginPath+""ffms"+version+@".dll"") } catch (_) { LoadCPlugin(PluginPath+""ffms"+version+@".dll"") }");

                if (Filters.Subtitle != null)
                {
                    string plugin;
                    switch (Filters.Subtitle.Type)
                    {
                        case SubtitleType.TextSub:
                        case SubtitleType.VobSub:
                        case SubtitleType.VTTSub:
                            plugin = "VSFilter.dll";
                            break;
                        case SubtitleType.PgsSub:
                            plugin = "SupTitle.dll";
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    avscript.WriteLine($@"LoadPlugin(PluginPath+""{plugin}"")");
                }

                if (Program.InputHasAudio)
                {
                    var audioScript = $@"AudioDub(FFVideoSource(""{avsInputFile}"",cachefile=""{_indexFile}"",track={videotrack}), FFAudioSource(""{avsInputFile}"",cachefile=""{_indexFile}"",track={audiotrack}))";
                    if (numericNormalization.Enabled && numericNormalization.Value != new decimal(1.00))
                        avscript.WriteLine($@"{audioScript}.Normalize({Dot(numericNormalization.Value)})");
                    else
                        avscript.WriteLine(audioScript);
                }                    
                else
                    avscript.WriteLine($@"FFVideoSource(""{avsInputFile}"",cachefile=""{_indexFile}"",track={videotrack})");

                if (Filters.Deinterlace != null)
                {
                    avscript.WriteLine(@"LoadPlugin(PluginPath+""dgbob.dll"")");
                    avscript.WriteLine(Filters.Deinterlace);
                }

                if (Filters.Denoise != null)
                {
                    avscript.WriteLine(@"LoadPlugin(PluginPath+""hqdn3d.dll"")");
                    avscript.WriteLine(Filters.Denoise);
                }

                if (SarCompensate)
                    avscript.WriteLine(new ResizeFilter(SarWidth, SarHeight));
                avscript.Write(textBoxProcessingScript.Text);
            }
        }

        void Preview()
        {
            string input = textBoxIn.Text;
            buttonPreview.Enabled = false;
            buttonPreview2.Enabled = false;

            ValidateInputFile(input);

            // Generate the script if we're in simple mode
            if (!boxAdvancedScripting.Checked)
                GenerateAvisynthScript();

            // Make our temporary file for the AviSynth script
            string avsFileName = GetTemporaryFile();
            WriteAvisynthScript(avsFileName, input);

            string levels = string.Empty;
            switch (comboLevels.SelectedIndex)
            {
                case 1:
                    levels = LightFilter;
                    break;
                case 2:
                    levels = DarkFilter;
                    break;
                case 3:
                    levels = string.Format(AdvancedFilter, Dot(numericGamma.Value), Dot(numericSaturation.Value), Dot(numericContrast.Value));
                    break;
            }

            if (!string.IsNullOrEmpty(levels))
                levels = " -vf " + levels;

            var disableAudio = boxAudio.Checked ? "" : "-an";
            var ffplay = new FFplay($@"-window_title Preview -loop 0 -f avisynth -v error {disableAudio}{levels} ""{avsFileName}""");
            ffplay.Exited += delegate
            {
                string error = ffplay.ErrorLog;

                this.InvokeIfRequired(() =>
                {
                    if (error.Length > 0)
                        MessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    buttonPreview.Enabled = true;
                    buttonPreview2.Enabled = true;
                });
            };
            ffplay.Start();
        }

        void Convert()
        {
            string input = textBoxIn.Text;
            string output = textBoxOut.Text;

            if (input == output)
                throw new Exception("Input and output files are the same!");

            string options = boxArguments.Text;

            ValidateInputFile(input);
            ValidateOutputFile(output);

            string avsFileName = null;
            switch (Program.InputType)
            {
                case FileType.Video:
                    // Generate the script if we're in simple mode
                    if (!boxAdvancedScripting.Checked)
                        GenerateAvisynthScript();

                    // Make our temporary file for the AviSynth script
                    avsFileName = GetTemporaryFile();
                    WriteAvisynthScript(avsFileName, input);
                    break;
                case FileType.Avisynth:
                    avsFileName = Program.InputFile;
                    break;
            }

            string format = checkMP4.Checked ? "mp4" : "webm";
            string tempName = String.Empty;

            List<string> arguments = new List<string>();
            if (!boxHQ.Checked || checkHWAcceleration.Checked)
                arguments.Add(string.Format(Template, output, options, "", format));
            else
            {
                var passlogfile = GetTemporaryLogFile();
                arguments.Add(string.Format(Template, "NUL", options, string.Format(PassArgument, 1, passlogfile), format));
                arguments.Add(string.Format(Template, output, options, string.Format(PassArgument, 2, passlogfile), format));

                if (!arguments[0].Contains("-an")) // skip audio encoding on the first pass
                    arguments[0] = arguments[0].Replace("-c:v libvpx", "-an -c:v libvpx");
            }
            
            if (boxStabilization.Checked)
            {
                string filename = Path.GetFileNameWithoutExtension(textBoxOut.Text);
                string extension = Path.GetExtension(textBoxOut.Text);
                string directory = Path.GetDirectoryName(textBoxOut.Text);
                tempName = $"{directory}\\{filename}-1{extension}";
                Vidstab selected = (Vidstab)comboBoxLevels.SelectedItem;

                arguments.Add(String.Format(StabilizationFilter1, textBoxOut.Text, selected.shakiness));
                arguments.Add(String.Format(StabilizationFilter2, textBoxOut.Text, comboStabType.SelectedItem,
                    selected.zoom, selected.smoothing, tempName));

                Program.Stabilization = new StabilizationData(textBoxOut.Text, tempName);
            }
            else
                Program.Stabilization = null;

            if (boxLoop.Checked)
            {
                string filename = Path.GetFileNameWithoutExtension(textBoxOut.Text);
                string extension = Path.GetExtension(textBoxOut.Text);
                string directory = Path.GetDirectoryName(textBoxOut.Text);

                var audio = string.Empty;
                if (!boxAudio.Checked)
                    audio = " -an ";
                tempName = $"{directory}\\{filename}-loop{extension}";
                arguments.Add(string.Format(Template, tempName, $" -i \"{output}\" {audio} -filter_complex {LoopFilter} ", string.Empty, format));

                Program.Loop = new LoopFileNames(textBoxOut.Text, tempName);
            }
            else
                Program.Loop = null;

            new ConverterDialog(avsFileName, arguments.ToArray(), output).ShowDialog(this);
        }

        string GenerateArguments()
        {
            string qualityarguments = null;
            if (encodingMode == EncodingMode.Constant)
            {
                float limit = 0;
                var limitTo = string.Empty;
                if (!string.IsNullOrWhiteSpace(boxLimit.Text))
                {
                    if (!float.TryParse(boxLimit.Text.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out limit))
                        throw new ArgumentException("Invalid size limit!");

                    limit = limit * 1024 * 1024;

                    limitTo = $@" -fs {(int)limit}";
                }

                var audiobitrate = -1;
                if (boxAudio.Checked)
                    audiobitrate = 64;

                if (!string.IsNullOrWhiteSpace(boxAudioBitrate.Text))
                {
                    if (!int.TryParse(boxAudioBitrate.Text, out audiobitrate))
                        throw new ArgumentException("Invalid audio bitrate!");

                    if (audiobitrate < 45)
                        throw new ArgumentException("Audio bitrate is too low! It has to be at least 45Kb/s");

                    if (audiobitrate > 500)
                        throw new ArgumentException("Audio bitrate is too high! It can not be higher than 500Kb/s");
                }

                var videobitrate = 900;
                if (!string.IsNullOrWhiteSpace(boxBitrate.Text))
                {
                    if (!int.TryParse(boxBitrate.Text, out videobitrate))
                        throw new ArgumentException("Invalid video bitrate!");
                }
                else if (limitTo != string.Empty)
                {
                    var duration = GetDuration();

                    if (duration > 0)
                        videobitrate = (int)(limit / duration / 1024 * 8) - audiobitrate;

                    if (videobitrate < 0)
                        throw new ArgumentException("Your size constraints are too tight! Trim your video or lower your audio bitrate.");
                }

                var ConstantVideoArguments = checkMP4.Checked ? ConstantVideoArgumentsMp4 : ConstantVideoArgumentsWebm;
                qualityarguments = string.Format(ConstantVideoArguments, videobitrate, limitTo);
                if (audiobitrate != -1)
                    qualityarguments += string.Format(ConstantAudioArguments, audiobitrate);

            }
            else if (encodingMode == EncodingMode.Variable)
            {
                var qmin = Math.Max(0, (int)(numericCrf.Value - numericCrfTolerance.Value));
                var qmax = Math.Min(63, (int)(numericCrf.Value + numericCrfTolerance.Value));

                qualityarguments = string.Format(VariableVideoArguments, qmin, numericCrf.Value, qmax);
                if (boxAudio.Checked & !boxNGOV.Checked) // only for vorbis
                    qualityarguments += string.Format(VariableAudioArguments, numericAudioQuality.Value);
            }

            var pixelFormat = checkBoxAlpha.Checked && checkBoxAlpha.Enabled ? "yuva420p" : "yuv420p";
            var threads = trackThreads.Value;
            var slices = GetSlices();

            var metadataTitle = "";
            if (!string.IsNullOrWhiteSpace(boxTitle.Text))
                metadataTitle = string.Format(@" -metadata title=""{0}""", boxTitle.Text.Replace("\"", "\\\""));

            var hq = boxHQ.Checked ? @" -lag-in-frames 16 -auto-alt-ref 1" : string.Empty;

            var vcodec = boxNGOV.Checked ? @"libvpx-vp9" : @"libvpx";
            var extraArguments = boxNGOV.Checked && boxNGOV.Enabled ? @" -aq-mode 4 -row-mt 1 -tile-columns 6 -tile-rows 2" : @"";
            extraArguments = yuvj420p ? extraArguments + @" -color_range 2" : extraArguments;

            if (checkMP4.Checked && checkHWAcceleration.Checked)
                vcodec = @"h264_nvenc";
            else
                vcodec = checkMP4.Checked ? @"libx265" : vcodec;

            string webmAcodec = (boxNGOV.Checked ? @"libopus" : @"libvorbis");
            var acodec = checkMP4.Checked ? @"aac" : webmAcodec;

            string audio;
            if (boxAudio.Checked)
            {
                audio = "";
                acodec = " -ac 2 -c:a " + acodec;
            }
            else
            {
                audio = " -an";
                acodec = "";
            }
            List<string> listVF = new List<string>();

            string levels = string.Empty;
            switch (comboLevels.SelectedIndex)
            {
                case 1:
                    levels = LightFilter;
                    break;
                case 2:
                    levels = DarkFilter;
                    break;
                case 3:
                    levels = string.Format(AdvancedFilter, Dot(numericGamma.Value), Dot(numericSaturation.Value), Dot(numericContrast.Value));
                    break;
            }
            if (!String.IsNullOrEmpty(levels))
                listVF.Add(levels);

            if (Filters.Dynamic != null)
                listVF.Add(Filters.Dynamic.Argument());

            var framerate = string.Empty;
            var valueR = string.Empty;
            bool hasValue = int.TryParse(boxFrameRate.Text, out int desiredFrame);
            if (hasValue && desiredFrame > (int)(Program.VideoSource.NumberOfFrames / Program.VideoSource.LastTime))
            {
                framerate = $"minterpolate=mi_mode=mci:me_mode=bidir:mc_mode=aobmc:vsbmc=1:fps={boxFrameRate.Text}";
                listVF.Add(framerate);
            }
            else if (hasValue)
            {
                valueR = $" -r {boxFrameRate.Text}";
            }
                
            string filter = string.Empty;

            if(listVF.Count > 0)
                filter = $" -vf \"{UnionVF(listVF)}\"";

            return string.Format(TemplateArguments, audio, threads, slices, metadataTitle, hq,
                                vcodec, acodec, filter, qualityarguments, extraArguments, pixelFormat, valueR);
        }

        /// <summary>
        /// Attempt to calculate the duration of the Avisynth script.
        /// </summary>
        /// <returns>The duration or -1 if automatic detection was unsuccessful.</returns>
        public double GetDuration()
        {
            if (boxAdvancedScripting.Checked || Program.InputType == FileType.Avisynth)
            {
                try
                {
                    using (XmlReader reader = XmlReader.Create(new StringReader(avsScriptInfo)))
                    {
                        reader.ReadToFollowing("stream");

                        while (reader.MoveToNextAttribute())
                        {
                            if (reader.Name == "duration")
                                return double.Parse(reader.Value, CultureInfo.InvariantCulture);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to get duration from Avisynth script. Error: ${ex.Message}\navsScriptInfo: ${avsScriptInfo}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                return -1;
            }
            else
            {
                double duration;

                if (Filters.Trim != null)
                    duration = Filters.Trim.GetDuration();
                else if (Filters.MultipleTrim != null)
                    duration = Filters.MultipleTrim.GetDuration();
                else
                    duration = FrameToTimeSpan(Program.VideoSource.NumberOfFrames - 1).TotalSeconds;

                if (Filters.Rate != null)
                    duration = duration / ((float)Filters.Rate.Multiplier / 100);

                return duration;
            }
        }

        public Size GetResolution()
        {
            if (boxAdvancedScripting.Checked || Program.InputType == FileType.Avisynth)
            {
                int width = -1, height = -1;

                try
                {
                    using (XmlReader reader = XmlReader.Create(new StringReader(avsScriptInfo)))
                    {
                        reader.ReadToFollowing("stream");

                        while (reader.MoveToNextAttribute())
                        {
                            if (reader.Name == "width")
                                width = int.Parse(reader.Value);

                            if (reader.Name == "height")
                                height = int.Parse(reader.Value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to get resolution from Avisynth script. Error: ${ex.Message}\navsScriptInfo: ${avsScriptInfo}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                return new Size(width, height);
            }
            else
            {
                if (Filters.Resize != null)
                    return new Size(Filters.Resize.TargetWidth, Filters.Resize.TargetHeight);

                var frame = Program.VideoSource.GetFrame((Filters.Trim == null) ? 0 : Filters.Trim.TrimStart);

                if (Filters.Crop != null)
                {
                    int width = frame.EncodedResolution.Width - Filters.Crop.Left + Filters.Crop.Right;
                    int height = frame.EncodedResolution.Height - Filters.Crop.Top + Filters.Crop.Bottom;

                    return new Size(width, height);
                }

                return frame.EncodedResolution;
            }
        }

        void GenerateAvisynthScript()
        {
            StringBuilder script = new StringBuilder();
            script.AppendLine("# This is an AviSynth script. You may write advanced commands below, or just press the buttons above for smooth sailing.");

            if (Filters.Dub != null)
                script.AppendLine(Filters.Dub.ToString());
            if (Filters.Crop != null && boxFixSubs.Checked)
            {
                script.AppendLine(Filters.Crop.ToString());
                script.AppendLine(new ResizeFilter(Filters.Crop.finalWidth, Filters.Crop.finalHeight).ToString());
            }
            if (Filters.Subtitle != null)
                script.AppendLine(Filters.Subtitle.ToString());
            if (Filters.Caption != null)
            {
                Filters.Caption.BeforeEncode(Program.VideoSource.GetFrame(0).EncodedResolution);
                script.AppendLine(Filters.Caption.ToString());
            }
            if (Filters.Overlay != null)
                script.AppendLine(Filters.Overlay.ToString());
            if (Filters.Trim != null && Filters.DynamicCrop == null)
                script.AppendLine(Filters.Trim.ToString());
            if (Filters.MultipleTrim != null)
                script.AppendLine(Filters.MultipleTrim.ToString());
            if (Filters.Rate != null)
                script.AppendLine(Filters.Rate.ToString());
            if (Filters.Crop != null && !boxFixSubs.Checked)
            {
                script.AppendLine(Filters.Crop.ToString());
                script.AppendLine(new ResizeFilter(Filters.Crop.finalWidth, Filters.Crop.finalHeight).ToString());
            }
            if (Filters.Resize != null)
                script.AppendLine(Filters.Resize.ToString());
            if (Filters.Reverse != null)
                script.AppendLine(Filters.Reverse.ToString());
            if (Filters.Fade != null)
                script.AppendLine(Filters.Fade.ToString());
            if (Filters.Rotate != null)
                script.AppendLine(Filters.Rotate.ToString());
            if (Filters.DelayAudio != null)
                script.AppendLine(Filters.DelayAudio.ToString());
            if (Filters.DynamicCrop != null)
                script.AppendLine(Filters.DynamicCrop.ToString());

            textBoxProcessingScript.Text = script.ToString();
        }

        void ProbeScript()
        {
            string avsFileName = null;

            if (Program.InputType == FileType.Video)
            {
                avsFileName = GetTemporaryFile();
                WriteAvisynthScript(avsFileName, textBoxIn.Text);
            }
            else if (Program.InputType == FileType.Avisynth)
            {
                avsFileName = Program.InputFile;
            }

            var ffprobe = new FFprobe(avsFileName);
            avsScriptInfo = ffprobe.Probe();
        }

        int GetSlices() => (int)Math.Pow(2, trackSlices.Value - 1);

        void SetSlices() => SetSlices(GetResolution());
        void SetSlices(Size resolution)
        {
            int slices;

            if (resolution.Width * resolution.Height >= 2073600) // 1080p (1920*1080)
                slices = 4;

            else if (resolution.Width * resolution.Height >= 921600) // 720p (1280*720)
                slices = 3;

            else if (resolution.Width * resolution.Height >= 307200) // 480p (640*480)
                slices = 2;

            else
                slices = 1;

            this.InvokeIfRequired(() =>
            {
                trackSlices.Value = slices;
            });
        }

        private void LoadFonts(Action<object> action = null)
        {
            Program.AttachmentList.ForEach(filename =>
            {
                action?.Invoke($"Loading font {filename}");

                var ret = NativeMethods.AddFontResourceEx(Path.Combine(Program.AttachmentDirectory, filename), 0, IntPtr.Zero);

                if (ret == 0)
                    action?.Invoke("Failed!");
            });
        }

        private void UnloadFonts()
        {
            Program.AttachmentList?.ForEach(filename =>
            {
                NativeMethods.RemoveFontResourceEx(Path.Combine(Program.AttachmentDirectory, filename), 0, IntPtr.Zero);
            });
            Program.AttachmentList = null;
        }

        private string GetTemporaryLogFile()
        {
            var temporaryFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            var temporaryFileRealName = temporaryFile + "-0.log";
            _temporaryFilesList.Add(temporaryFileRealName);
            return temporaryFile;
        }

        private string GetTemporaryFile()
        {
            var temporaryFile = Path.GetTempFileName();
            _temporaryFilesList.Add(temporaryFile);
            return temporaryFile;
        }

        #endregion

        private void UpdateConfiguration(string key, string value)
        {
            configuration.AppSettings.Settings[key].Value = value;
            try
            {
                configuration.Save();
            }
            catch (Exception ex) { 
                //skipped
            }
            ConfigurationManager.RefreshSection("userSettings");
            showToolTip("Saved!", 1000);
        }

        private void textBoxIn_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIn.Text.StartsWith("http"))
                buttonBrowseIn.Text = "Download";
            else
                buttonBrowseIn.Text = "Browse";
        }

        private void buttonPathChange_Click(object sender, EventArgs e)
        {
            FolderDownloads();
        }

        private void FolderDownloads()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;

                if (dialog.ShowDialog(this) != DialogResult.OK || string.IsNullOrWhiteSpace(dialog.SelectedPath))
                    return;

                textPathDownloaded.Text = dialog.SelectedPath;
                UpdateConfiguration("PathDownload", dialog.SelectedPath);
            }
        }

        private String VideoPathDialog()
        {
            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog(this) != DialogResult.OK || string.IsNullOrEmpty(dialog.FileName))
                    return string.Empty;

                return dialog.FileName;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ = Process.Start($"https://argorar.github.io/WebMConverter/");
        }

        private void boxLoop_CheckedChanged(object sender, EventArgs e)
        {
            UpdateArguments(sender, e);
        }

        private void comboLevels_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboLevels.SelectedIndex == 3)
            {
                numericContrast.Enabled = true;
                numericGamma.Enabled = true;
                numericSaturation.Enabled = true;
            }
            else
            {
                numericContrast.Enabled = false;
                numericGamma.Enabled = false;
                numericSaturation.Enabled = false;
            }
            UpdateArguments(sender, e);
        }

        private void boxFrameRate_Leave(object sender, EventArgs e)
        {
            if (boxFrameRate.Text.Equals("0"))
                boxFrameRate.Text = string.Empty;
            UpdateArguments(sender, e);
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            UpdateConfiguration("RefreshToken", string.Empty);
            Program.token = string.Empty;
            groupGfycat.Visible = false;
        }

        public string[] GetGfyTags()
        {
            return String.IsNullOrEmpty(boxTags.Text) ? null : boxTags.Text.Split(',');
        }

        private void listViewProcessingScript_KeyDown(object sender, KeyEventArgs e)
        {
            if (buttonGo.Enabled)
            {
                if (e.Alt && !e.Shift && e.KeyCode == Keys.T)
                {
                    if (Filters.Trim == null)
                        buttonTrim_Click(sender, e);
                    else
                        EditTrimFilter(sender, e);
                }
                if (e.Alt && e.Shift && e.KeyCode == Keys.T)
                {
                    if (Filters.MultipleTrim == null)
                        buttonMultipleTrim_Click(sender, e);
                    else
                        EditMultiTrimFilter(sender, e);
                }
                if (e.Alt && !e.Shift && e.KeyCode == Keys.C)
                {
                    if (Filters.Crop == null)
                        buttonCrop_Click(sender, e);
                    else
                        EditCropFilter(sender, e);
                }
                if (e.Alt && e.Shift && e.KeyCode == Keys.C)
                {
                    if (Filters.Rate == null)
                        buttonRate_Click(sender, e);
                    else
                        EditRateFilter(sender, e);
                }
            }
        }

        private void EditTrimFilter(object sender, EventArgs e)
        {
            using (var form = new TrimForm(Filters.Trim))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    Filters.Trim = form.GeneratedFilter;
                    UpdateArguments(sender, e);
                }
            }
        }
        private void EditMultiTrimFilter(object sender, EventArgs e)
        {
            using (var form = new MultipleTrimForm(Filters.MultipleTrim))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    Filters.MultipleTrim = form.GeneratedFilter;
                    UpdateArguments(sender, e);
                }
            }
        }

        private void EditCropFilter(object sender, EventArgs e)
        {
            using (var form = new CropForm(Filters.Crop))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    Filters.Crop = form.GeneratedFilter;
                    SetSlices();
                }
            }
        }

        private void EditRateFilter(object sender, EventArgs e)
        {
            using (var form = new RateForm(Filters.Rate))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    Filters.Rate = form.GeneratedFilter;
                    UpdateArguments(sender, e);
                }
            }
        }

        private void CRF4k_ValueChanged(object sender, EventArgs e)
        {
            UpdateConfiguration("CRF4k", CRF4k.Value.ToString());
        }

        private void CRFother_ValueChanged(object sender, EventArgs e)
        {
            UpdateConfiguration("CRFother", CRFother.Value.ToString());
        }

        private void buttonPreview2_Click(object sender, EventArgs e)
        {
            try
            {
                Preview();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOpenPath_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textPathDownloaded.Text))
                Process.Start(@textPathDownloaded.Text);
        }

        private void numericDelay_ValueChanged(object sender, EventArgs e)
        {
            Filters.DelayAudio = numericDelay.Value != 0 ? new DelayAudio(numericDelay.Value.ToString().Replace(',', '.')) : null;
            UpdateArguments(sender, e);
        }

        private void checkMP4_CheckedChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxOut.Text) && checkMP4.Checked)
                textBoxOut.Text = $"{Path.GetDirectoryName(textBoxOut.Text)}\\{Path.GetFileNameWithoutExtension(textBoxOut.Text)}.mp4";
            else if (!String.IsNullOrEmpty(textBoxOut.Text))
                textBoxOut.Text = $"{Path.GetDirectoryName(textBoxOut.Text)}\\{Path.GetFileNameWithoutExtension(textBoxOut.Text)}.webm";

            if (checkMP4.Checked)
            {
                boxNGOV.Enabled = false;
                checkBoxAlpha.Enabled = false;
                checkHWAcceleration.Enabled = true;
            }
            else
            {
                boxNGOV.Enabled = true;
                checkBoxAlpha.Enabled = true;
                checkHWAcceleration.Enabled = false;
                checkHWAcceleration.Checked = false;
            }

            UpdateArguments(sender, e);
            UpdateConfiguration("MP4", checkMP4.Checked.ToString());

        }

        private void checkHWAcceleration_CheckedChanged(object sender, EventArgs e)
        {
            UpdateArguments(sender, e);
            UpdateConfiguration("HAMP4", checkHWAcceleration.Checked.ToString());
        }

        private void boxStabilization_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxLevels.Enabled = boxStabilization.Checked;
            comboStabType.Enabled = boxStabilization.Checked;
            UpdateArguments(sender, e);
        }

        private void valueChanged(object sender, EventArgs e)
        {
            UpdateArguments(sender, e);
        }

        private void checkBoxAlpha_CheckedChanged(object sender, EventArgs e)
        {
            UpdateArguments(sender, e);
        }

        private void checkFixAudio_CheckedChanged(object sender, EventArgs e)
        {
            UpdateArguments(sender, e);
        }

        private void buttonVideo1_Click(object sender, EventArgs e)
        {
            string videoPath = VideoPathDialog();
            textVideo1.Text = videoPath;
        }

        private void buttonVideo2_Click(object sender, EventArgs e)
        {
            string videoPath = VideoPathDialog();
            textVideo2.Text = videoPath;
        }

        private void tableLayoutPanel1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textVideo1.Text) && !string.IsNullOrEmpty(textVideo2.Text))
                GridConvert(GridVertical, "_grid_vertical");
        }

        private void tableLayoutPanel2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textVideo1.Text) && !string.IsNullOrEmpty(textVideo2.Text))
                GridConvert(GridHorizontal, "_grid_horizontal");
        }

        private void GridConvert(string gridArgument, string gridMethod)
        {
            List<string> arguments = new List<string>();
            string path = Path.GetDirectoryName(textVideo1.Text);
            string extension = Path.GetExtension(textVideo1.Text);
            string name = Path.GetFileNameWithoutExtension(textVideo1.Text);
            string output = $"{path}\\{name}{gridMethod}{extension}";    
            arguments.Add(string.Format(gridArgument, textVideo1.Text, textVideo2.Text, output));
            new ConverterDialog(string.Empty, arguments.ToArray(), output).ShowDialog(this);
        }

        private void boxDisablePop_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConfiguration("POP", boxDisablePop.Checked.ToString());
            Program.DisablePop = boxDisablePop.Checked;
        }

        private void numericGamma_ValueChanged(object sender, EventArgs e)
        {
            UpdateArguments(sender, e);
        }

        private void checkBoxDownloadOptions_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConfiguration("DWO", boxDownloadOptions.Checked.ToString());
        }


        private void boxDisableUpdates_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConfiguration("DisableUpdates", boxDisableUpdates.Checked.ToString());
            Program.DisableUpdates = boxDisableUpdates.Checked;
        }

        private void boxDisableExtractSubtitles_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConfiguration("DisableSubtitles", boxDisableExtractSubtitles.Checked.ToString());
        }

        private void boxDisableMetadata_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConfiguration("DisableMetadata", boxDisableMetadata.Checked.ToString());
        }

        private void buttonDynamic_Click_1(object sender, EventArgs e)
        {
            var filter = Filters.Trim == null ? new TrimFilter(0, Program.VideoSource.NumberOfFrames - 1) : Filters.Trim;
            using (var form = new DynamicForm(filter))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Filters.Dynamic = form.GeneratedFilter;
                    if (!boxAdvancedScripting.Checked)
                    {
                        listViewProcessingScript.Items.Add("Dynamic", "Dynamic");
                        buttonDynamic.Enabled = false;
                    }
                    UpdateArguments(sender, e);

                }
            }            
        }
    }
}
