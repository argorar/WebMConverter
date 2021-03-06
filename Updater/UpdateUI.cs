﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebMConverter.Updater
{
    public partial class UpdateUI : Form
    {
        private string latestVersion;
        private string updateZipPath;
        private string updateTempPath;
        private string updateExePath;
        private string updateCertPath;

        public UpdateUI()
        {
            updateZipPath = Path.Combine(Path.GetTempPath(), "WebM-for-Lazys-update.zip");
            updateTempPath = Path.Combine(Path.GetTempPath(), "WebM-for-Lazys-update");
            updateExePath = Path.Combine(updateTempPath, "WebMConverter.exe");
            updateCertPath = Path.Combine(updateTempPath, "trusted.cer");

            InitializeComponent();
        }

        private void UpdateUI_Load(object sender, EventArgs e) => Step1_GetLatestVersion();

        private void Step1_GetLatestVersion()
        {
            labelStatus.Text = "Checking latest version...";

            using (var client = new WebClient()) {
                client.DownloadStringCompleted += delegate (object sender, DownloadStringCompletedEventArgs args)
                {
                    if (args.Error != null)
                    {
                        Abort(args.Error.Message);
                        Application.Exit();
                    }

                    latestVersion = args.Result.Trim();
                    Step2_DownloadLatestVersion();
                };

                client.DownloadStringAsync(new Uri(Program.VersionUrl));
            }            
        }

        private void Step2_DownloadLatestVersion()
        {
            labelStatus.Text = $"Downloading version {latestVersion} (....)";
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Value = 0;

            using (var client = new WebClient()) {
                client.DownloadProgressChanged += delegate (object sender, DownloadProgressChangedEventArgs args)
                {
                    progressBar.Value = args.ProgressPercentage;

                    labelStatus.Text = $"Downloading version {latestVersion} ({args.BytesReceived / 1024 / 1024} MiB / {args.TotalBytesToReceive / 1024 / 1024} MiB)";
                };

                client.DownloadFileCompleted += delegate (object sender, AsyncCompletedEventArgs args)
                {
                    if (args.Error != null)
                    {
                        Abort(args.Error.Message);
                        Application.Exit();
                    }

                    Step3_Unzip();
                };

                client.DownloadFileAsync(new Uri(string.Format(Program.ProgramUrl, latestVersion)), updateZipPath);
            }           
            
        }

        private async void Step3_Unzip()
        {
            labelStatus.Text = "Verifying integrity...";
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.Value = 30;

            if (Directory.Exists(updateTempPath))
                Directory.Delete(updateTempPath, true);

            Directory.CreateDirectory(updateTempPath);
            await Task.Run(() => ZipFile.ExtractToDirectory(updateZipPath, updateTempPath));
            File.Delete(updateZipPath);

            Step4_OverwriteAndRestart();
        }

        private void Step4_OverwriteAndRestart()
        {
            try
            {
                var source = new DirectoryInfo(updateTempPath);
                var target = new DirectoryInfo(Environment.CurrentDirectory);

                CopyAll(source, target);
            }
            catch (Exception e)
            {
                Abort(e.Message);
            }

            Directory.Delete(updateTempPath, true);
            Process.Start("WebMConverter.exe");
            Application.Exit();
        }

        private void Abort(string message = null)
        {
            if (File.Exists(updateZipPath))
                File.Delete(updateZipPath);

            if (Directory.Exists(updateTempPath))
                Directory.Delete(updateTempPath, true);

            if (!string.IsNullOrEmpty(message))
                MessageBox.Show(message, "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Application.Exit();
        }

        private static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            if (!Directory.Exists(target.FullName))
            {
                Directory.CreateDirectory(target.FullName);
            }

            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }

            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}
