using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FFMSSharp;

namespace WebMConverter
{
    public partial class DubForm : Form
    {
        public DubFilter GeneratedFilter { get; set; }

        private BackgroundWorker _worker;

        public DubForm()
        {
            InitializeComponent();
            comboDubMode.SelectedIndex = 0;
        }

        public DubForm(DubFilter dubFilter) : this()
        {
            SetFile(dubFilter.AudioFileName);
            comboDubMode.SelectedIndex = (int)dubFilter.Mode;
        }

        private void DubForm_DragEnter(object sender, DragEventArgs e)
        {
            var dataPresent = e.Data.GetDataPresent(DataFormats.FileDrop);
            e.Effect = dataPresent ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void DubForm_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[]) e.Data.GetData(DataFormats.FileDrop);
            SetFile(files[0]);
        }

        private void buttonBrowse_Click(object sender, EventArgs e) => openAudioFile.ShowDialog(this);
        private void openAudioFile_FileOk(object sender, CancelEventArgs e) => SetFile(((OpenFileDialog) sender).FileName);

        private void SetFile(string audioFileName)
        {
            boxAudioFile.Text = audioFileName;
            openAudioFile.FileName = audioFileName;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            var audioFile = boxAudioFile.Text;
            string indexFile;

            try
            {
                if (!File.Exists(audioFile))
                    throw new FileNotFoundException();

                panelIndexingProgress.BringToFront();
                labelIndexingProgress.Text = "Hashing...";

                using (var md5 = MD5.Create())
                using (var stream = File.OpenRead(audioFile))
                {
                    var filename = new UTF8Encoding().GetBytes(Path.GetFileNameWithoutExtension(audioFile));
                    var buffer = new byte[4096];

                    filename.CopyTo(buffer, 0);
                    stream.Read(buffer, filename.Length, 4096 - filename.Length);

                    var hash = BitConverter.ToString(md5.ComputeHash(buffer));
                    indexFile = Path.Combine(Path.GetTempPath(), hash + ".ffindex");
                }

                if (File.Exists(indexFile))
                {
                    try
                    {
                        var index = new Index(indexFile);

                        if (index.BelongsToFile(audioFile))
                        {
                            DialogResult = DialogResult.OK;
                            GeneratedFilter = new DubFilter(audioFile, indexFile, (DubMode)comboDubMode.SelectedIndex);
                            Close();
                            return;
                        }
                    }
                    catch
                    {
                        // ignored
                    }

                    File.Delete(indexFile);
                }

                labelIndexingProgress.Text = "Indexing...";
                progressIndexingProgress.Value = 0;
                progressIndexingProgress.Style = ProgressBarStyle.Continuous;
                _worker = new BackgroundWorker
                {
                    WorkerSupportsCancellation = true,
                    WorkerReportsProgress = true
                };
                _worker.ProgressChanged += (o, args) =>
                {
                    progressIndexingProgress.Value = args.ProgressPercentage;
                };
                _worker.DoWork += (bw, workArgs) =>
                {
                    var indexer = new Indexer(audioFile);
                    indexer.SetTrackTypeIndexSettings(TrackType.Audio, true);

                    indexer.UpdateIndexProgress += (ind, updateArgs) =>
                    {
                        _worker.ReportProgress((int) (((double) updateArgs.Current/updateArgs.Total)*100));
                        indexer.CancelIndexing = _worker.CancellationPending;
                    };

                    try
                    {
                        var index = indexer.Index();

                        try
                        {
                            index.GetFirstIndexedTrackOfType(TrackType.Audio);
                        }
                        catch (KeyNotFoundException)
                        {
                            throw new InvalidDataException("That file doesn't have any audio!");
                        }

                        index.WriteIndex(indexFile);

                    }
                    catch (OperationCanceledException)
                    {
                        workArgs.Cancel = true;
                    }
                };
                _worker.RunWorkerCompleted += (o, args) =>
                {
                    this.InvokeIfRequired(() =>
                    {
                        panelIndexingProgress.SendToBack();
                    });

                    if (args.Error != null)
                    {
                        this.InvokeIfRequired(() =>
                        {
                            SetFile(string.Empty);

                            if (
                                MessageBox.Show(args.Error.Message, "ERROR", MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Error) == DialogResult.Cancel)
                                Close();
                        });
                        return;
                    }

                    if (args.Cancelled)
                    {
                        DialogResult = DialogResult.Cancel;
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                        GeneratedFilter = new DubFilter(audioFile, indexFile, (DubMode)comboDubMode.SelectedIndex);
                    }

                    this.InvokeIfRequired(Close);
                };
                _worker.RunWorkerAsync();
            }
            catch (Exception err)
            {
                if (MessageBox.Show(err.Message, "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) ==
                    DialogResult.Cancel)
                    Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (_worker != null && _worker.IsBusy)
                _worker.CancelAsync();
        }

        private void comboDubMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((DubMode)comboDubMode.SelectedIndex)
            {
                case DubMode.TrimAudio:
                    labelDubModeHint.Text = "When you want to dub a video.";
                    break;
                case DubMode.LoopVideo:
                    labelDubModeHint.Text = "When you want to dub a picture.";
                    break;
                case DubMode.JustDub:
                    labelDubModeHint.Text = "Just dub it without additional processing.";
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    public class DubFilter
    {
        public string AudioFileName { get; }
        public string IndexFileName { get; }
        public DubMode Mode { get; }

        public DubFilter(string audioFileName, string indexFileName, DubMode mode)
        {
            AudioFileName = audioFileName;
            IndexFileName = indexFileName;
            Mode = mode;
        }

        public override string ToString()
        {
            switch (Mode)
            {
                case DubMode.TrimAudio:
                    return $@"Trim(AudioDub(FFAudioSource(""{AudioFileName}"",cachefile=""{IndexFileName}"")), 0, last.FrameCount)";
                case DubMode.LoopVideo:
                    return $@"dub = FFAudioSource(""{AudioFileName}"",cachefile=""{IndexFileName}""){Environment.NewLine}" + 
                             "Loop(-1).AudioDub(dub).Trim(0,int(dub.AudioLength / dub.AudioRate * last.FrameRate))";
                case DubMode.JustDub:
                    return $@"AudioDub(FFAudioSource(""{AudioFileName}"",cachefile=""{IndexFileName}""))";
                default:
                    throw new NotImplementedException();
            }
        }
    }

    public enum DubMode
    {
        TrimAudio,
        LoopVideo,
        JustDub
    }
}