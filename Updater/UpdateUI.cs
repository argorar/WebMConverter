using System;
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
            updateZipPath = Path.Combine(Path.GetTempPath(), "WebM-for-Retards-update.zip");
            updateTempPath = Path.Combine(Path.GetTempPath(), "WebM-for-Retards-update");
            updateExePath = Path.Combine(updateTempPath, "WebMConverter.exe");
            updateCertPath = Path.Combine(updateTempPath, "trusted.cer");

            InitializeComponent();
        }

        private void UpdateUI_Load(object sender, EventArgs e) => Step1_GetLatestVersion();

        private void Step1_GetLatestVersion()
        {
            labelStatus.Text = "Checking latest version...";

            var client = new WebClient();
            client.DownloadStringCompleted += delegate(object sender, DownloadStringCompletedEventArgs args)
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

        private void Step2_DownloadLatestVersion()
        {
            labelStatus.Text = $"Downloading version {latestVersion} (....)";
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Value = 0;

            var client = new WebClient();
            client.DownloadProgressChanged += delegate(object sender, DownloadProgressChangedEventArgs args)
            {
                progressBar.Value = args.ProgressPercentage;

                labelStatus.Text = $"Downloading version {latestVersion} ({args.BytesReceived / 1024 / 1024} MiB / {args.TotalBytesToReceive / 1024 / 1024} MiB)";
            };

            client.DownloadFileCompleted += delegate(object sender, AsyncCompletedEventArgs args)
            {
                if (args.Error != null)
                {
                    Abort(args.Error.Message);
                    Application.Exit();
                }

                Step3_UnzipAndVerify();
            };

            client.DownloadFileAsync(new Uri(string.Format(Program.ProgramUrl, latestVersion)), updateZipPath);
        }

        private async void Step3_UnzipAndVerify()
        {
            labelStatus.Text = string.Format("Verifying integrity...");
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.Value = 30;

            if (Directory.Exists(updateTempPath))
                Directory.Delete(updateTempPath, true);

            Directory.CreateDirectory(updateTempPath);
            await Task.Run(() => ZipFile.ExtractToDirectory(updateZipPath, updateTempPath));
            File.Delete(updateZipPath);

            var trustedCertificate = new X509Certificate2("trusted.cer");
            X509Certificate exeCertificate;

            try
            {
                exeCertificate = X509Certificate.CreateFromSignedFile(updateExePath);
            }
            catch (Exception)
            {
                Abort("The downloaded executable is unsigned and therefore untrusted.");
                return;
            }

            X509Certificate2 updateCertificate;
            try
            {
                updateCertificate = new X509Certificate2(updateCertPath);
            }
            catch (Exception)
            {
                Abort("The downloaded update does not include a valid certificate.");
                return;
            }

            if (!exeCertificate.Equals(trustedCertificate))
            {
                Abort("The downloaded executable is not signed by a trusted developer.");
                return;
            }

            if (!trustedCertificate.Equals(updateCertificate))
            {
                var answer = MessageBox.Show(this,
                    $"The downloaded update contains a different certificate than your current version.{Environment.NewLine}" +
                    $"This is either a sign of foul play, or it means I lost my old certificate and need to ship a new one.{Environment.NewLine}" +
                    $"If you trust this certificate, it will be used in the future to verify that updates are legitimate.{Environment.NewLine}" +
                    "Do you trust this new certificate?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.No)
                {
                    Abort();
                    return;
                }
            }

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
            if (Directory.Exists(target.FullName) == false)
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
