using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using WebMConverter.Objects;

namespace WebMConverter.Dialogs
{
    public partial class UpdateBinaries : Form
    {
        private readonly Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        private static readonly string repository = @"https://api.github.com/repos/ytdl-org/youtube-dl/releases/latest";
        private static string updateExePath = Path.Combine(Path.GetTempPath(), "youtube-dl.exe");
        private int installedVersion;
        private int latestVersion;


        public UpdateBinaries(int installedVersion)
        {
            this.installedVersion = installedVersion;
            InitializeComponent();
        }

        public void GetLatestVersion()
        {
            ReleaseInfo releaseInfo;
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add(HttpRequestHeader.UserAgent,"request");
                var json = wc.DownloadString(repository);
                releaseInfo = JsonConvert.DeserializeObject<ReleaseInfo>(json);
            }

            if(releaseInfo != null)
            {
                latestVersion = Int32.Parse(releaseInfo.tag_name.Replace(".", string.Empty));
                if (installedVersion < latestVersion)
                {
                    this.Show();
                    DownloadRelease(releaseInfo.assets.FirstOrDefault(x => x.name.Equals("youtube-dl.exe")).browser_download_url);
                }

            }
        }

        private void DownloadRelease(string browser_download_url)
        {
            labelStatus.Text = $"Downloading version {latestVersion} (....)";
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Value = 0;

            using (var client = new WebClient())
            {
                client.DownloadProgressChanged += delegate (object sender, DownloadProgressChangedEventArgs args)
                {
                    progressBar.Value = args.ProgressPercentage;

                    labelStatus.Text = $"Downloading version {latestVersion} ({args.BytesReceived / 1024 / 1024} MiB / {args.TotalBytesToReceive / 1024 / 1024} MiB)";
                };

                client.DownloadFileCompleted += delegate (object sender, AsyncCompletedEventArgs args)
                {
                    if (args.Error != null)
                    {
                        Abort();
                        Application.Exit();
                    }

                    MoveNewFile();
                };

                client.DownloadFileAsync(new Uri(browser_download_url), updateExePath);
            }
        }

        private void MoveNewFile()
        {
            try
            {
                labelStatus.Text = $"Moving file ....";
                var source = new FileInfo(updateExePath);
                source.CopyTo(Path.Combine(Path.Combine(Environment.CurrentDirectory, "Binaries\\Win64"), source.Name), true);
            }
            catch (Exception)
            {
                Abort();
            }

            File.Delete(updateExePath);
            configuration.AppSettings.Settings["YTDLV"].Value = latestVersion.ToString();
            configuration.Save();
            ConfigurationManager.RefreshSection("userSettings");
            this.Dispose();
        }

        private void Abort()
        {
            if (File.Exists(updateExePath))
                File.Delete(updateExePath);
        }

    }
}
