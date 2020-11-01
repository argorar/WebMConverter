using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebMConverter.Dialogs
{
    public partial class GfycatUploader : Form
    {
        private string filePath;
        private string gfyName;


        public GfycatUploader(string filePath, string gfyName)
        {
            this.filePath = filePath;
            this.gfyName = gfyName;
            InitializeComponent();
        }

        private void UpdateUI_Load(object sender, EventArgs e) => UploadFileAsync();

        private async void UploadFileAsync()
        {
            try
            {
                this.Activate();
                var file = File.ReadAllBytes(filePath);
                using (var client = new HttpClient())
                {
                    using (var content = new MultipartFormDataContent())
                    {
                        content.Add(new StringContent(gfyName), "key");
                        content.Add(new ByteArrayContent(file), "file", gfyName);
                        labelStatus.Text = "Uploading file..";
                        progressBar.Style = ProgressBarStyle.Marquee;
                        using ( await client.PostAsync("https://filedrop.gfycat.com", content))
                        {
                            labelStatus.Text = $"Everything is great, now wait until gfycat encode the video :)";
                        }
                    }
                }
                await CheckStatus();
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            // reads response body
                            string responseText = await reader.ReadToEndAsync();
                            labelStatus.Text = $"Ups {responseText}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                labelStatus.Text = $"Something bad happened, sorry :(";
                progressBar.Style = ProgressBarStyle.Continuous;
                progressBar.Value = 100;
                MessageBox.Show( ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Activate();
            }            
        }

        private async Task CheckStatus()
        {
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Value = 30;
            string text;
            bool isDone = false;
            string cUrl = $"https://api.gfycat.com/v1/gfycats/fetch/status/{gfyName}";
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
                            if(progressBar.Value < 90)
                                progressBar.Value += 1;
                            labelStatus.Text = $"Encoding..";
                        }
                        if (text.Contains("complete"))
                        {
                            isDone = true;
                            labelStatus.Text = "Your video is up!";
                            System.Diagnostics.Process.Start($"https://gfycat.com/{gfyName}");
                            Dispose();
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
}
