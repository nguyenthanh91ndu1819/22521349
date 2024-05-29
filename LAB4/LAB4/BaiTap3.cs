using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using HtmlAgilityPack;
using Microsoft.Web.WebView2.WinForms;

namespace LAB4
{
    public partial class BaiTap3 : Form
    {
        public BaiTap3()
        {
            InitializeComponent();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await webView2.EnsureCoreWebView2Async(null);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string url = tbURL.Text;
                webView2.Source = new Uri(url);
            }
            catch (UriFormatException)
            {
                MessageBox.Show("Please enter a valid URL.");
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            webView2.Reload();
        }

        private void btnViewSource_Click(object sender, EventArgs e)
        {
            ViewSourceBai3 viewSourceBai3 = new ViewSourceBai3();
            string url = tbURL.Text;
            viewSourceBai3.SetURL(url);
            viewSourceBai3.Show();
        }

        private void btnDownSource_Click(object sender, EventArgs e)
        {
            string url = tbURL.Text;

            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Please enter a URL.");
                return;
            }

            // Đường dẫn thư mục tải xuống trong thư mục dự án
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string downloadPath = Path.Combine(projectPath, "Downloads");

            if (!Directory.Exists(downloadPath))
            {
                Directory.CreateDirectory(downloadPath);
            }

            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = web.Load(url);

            var imageNodes = document.DocumentNode.SelectNodes("//img");

            if (imageNodes != null)
            {
                using (WebClient webClient = new WebClient())
                {
                    foreach (var node in imageNodes)
                    {
                        string imageUrl = node.GetAttributeValue("src", null);

                        if (!string.IsNullOrEmpty(imageUrl))
                        {
                            if (!Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute))
                            {
                                Uri baseUri = new Uri(url);
                                Uri fullUri = new Uri(baseUri, imageUrl);
                                imageUrl = fullUri.ToString();
                            }

                            try
                            {
                                Uri uri = new Uri(imageUrl);
                                string fileName = Path.GetFileName(uri.LocalPath);
                                string localFilePath = Path.Combine(downloadPath, fileName);

                                webClient.DownloadFile(uri, localFilePath);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Failed to download {imageUrl}: {ex.Message}");
                            }
                        }
                    }
                }
                // Thông báo sau khi hoàn tất tải tất cả hình ảnh
                MessageBox.Show($"Download successfully. Images saved to: {downloadPath}");
            }
            else
            {
                MessageBox.Show("No images found.");
            }
        }
    }
}
