using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
namespace LAB5
{
    public partial class BaiTap4 : Form
    {

        public BaiTap4()
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            buy_btn.Click += buy_btn_Click;
            check_btn.Click += check_btn_Click;
            add_btn.Click += add_btn_Click;
            rcheck_btn.Click += rcheck_btn_Click;
            write_btn.Click += write_btn_Click;
            backgroundWorkerExport.DoWork += backgroundWorkerExport_DoWork;
            backgroundWorkerExport.ProgressChanged += backgroundWorkerExport_ProgressChanged;
            backgroundWorkerExport.RunWorkerCompleted += backgroundWorkerExport_RunWorkerCompleted;
        }
        private string selectedPosterUrl;


        string[] veVot = { "A1", "A5", "C1", "C5" };
        string[] veVip = { "B2", "B3", "B4" };
        List<ThanhToanInfo> danhSachKhachHang = new List<ThanhToanInfo>();
        List<Phim> danhsachPhim = new List<Phim>();
        private int panelTopPosition = 10;

        private async Task<string> DownloadPoster(string posterUrl, string savePath)
        {
            using (var client = new WebClient())
            {
                try
                {
                    await client.DownloadFileTaskAsync(posterUrl, savePath);
                    return savePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải và lưu poster từ URL: " + ex.Message);
                    return string.Empty;
                }
            }
        }

        private async void LoadMovieDataFromHTML(string filePath)
        {
            try
            {
                string htmlContent = File.ReadAllText(filePath);

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(htmlContent);

                var movieNodes = doc.DocumentNode.SelectNodes("//div[@class='col-lg-4 col-md-4 col-sm-8 col-xs-16 padding-right-30 padding-left-30 padding-bottom-30']");
                if (movieNodes != null)
                {
                    foreach (var movieNode in movieNodes)
                    {
                        var bannerNode = movieNode.SelectSingleNode(".//img[@class='img-responsive border-radius-20']");
                        var titleNode = movieNode.SelectSingleNode(".//h3[@class='text-center text-sm-left text-xs-left bold margin-top-5 font-sm-18 font-xs-14']/a");
                        var linkNode = movieNode.SelectSingleNode(".//a[@class='fancybox-fast-view']");

                        if (bannerNode != null && titleNode != null && linkNode != null)
                        {
                            string bannerUrl = bannerNode.GetAttributeValue("src", "");
                            string movieTitle = titleNode.InnerText;
                            string movieUrl = linkNode.GetAttributeValue("href", "");

                            // Download poster and get saved path
                            string savedPosterPath = await DownloadPoster(bannerUrl, Path.Combine(Application.StartupPath, $"{movieTitle}_poster.jpg"));

                            DisplayMovieInfoInPanel(savedPosterPath, movieTitle, movieUrl);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin phim trong tệp HTML.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }


        private void DisplayMovieInfoInPanel(string bannerUrl, string movieTitle, string movieUrl)
        {
            try
            {
                Panel panel = new Panel();
                panel.Width = 220;
                panel.Height = 350;
                panel.Top = panelTopPosition;

                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Load(bannerUrl);
                pictureBox.Width = 200;
                pictureBox.Height = 250;
                pictureBox.Location = new Point(10, 10);

                Label titleLabel = new Label();
                titleLabel.Text = movieTitle;
                titleLabel.AutoSize = true;
                titleLabel.Location = new Point(10, 270);

                panel.Controls.Add(pictureBox);
                panel.Controls.Add(titleLabel);

                panelMovies.Controls.Add(panel);

                panelTopPosition += panel.Height + 10;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị thông tin phim: " + ex.Message);
            }
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Phim phimDuocChon = comboBox1.SelectedItem as Phim;
            if (phimDuocChon != null)
            {
                comboBox2.DataSource = phimDuocChon.PhongChieu.Select(p => p.ToString()).ToList();
            }
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
                danhsachPhim = JsonSerializer.Deserialize<List<Phim>>(fileStream);
                comboBox1.DataSource = danhsachPhim;
                comboBox1.DisplayMember = "TenPhim";
            }
        }


        private async void buy_btn_Click(object sender, EventArgs e)
        {
            ThanhToanInfo tickets = buyTicket();
            bool isTicketSold = false;

            foreach (var kh in danhSachKhachHang)
            {
                if (kh.TenPhim == tickets.TenPhim && kh.PhongChieu == tickets.PhongChieu)
                {
                    // Kiểm tra trùng lặp vé
                    foreach (var vedamua in kh.VeDaChon)
                    {
                        foreach (var ve in tickets.VeDaChon)
                        {
                            if (ve == vedamua)
                            {
                                MessageBox.Show($"Ve {ve} đã có người mua!");
                                isTicketSold = true;
                                break;
                            }
                        }
                        if (isTicketSold)
                            break;
                    }
                }
            }
            if (!isTicketSold)
            {
                danhSachKhachHang.Add(tickets);

                
                string posterFileName = $"{tickets.TenPhim}_poster.jpg";
                string posterFilePath = Path.Combine(Application.StartupPath, posterFileName);
                await DownloadPoster(tickets.posterFilePath, posterFilePath);

                
                SendEmail(tickets.TenPhim, tickets.VeDaChon, posterFilePath);
            }
        }


        

        private void SendEmail(string code, string[] veDaChon, string posterFilePath)
        {
            string from = "chessmasterresetpass@gmail.com";
            string pass = "qcii qibh gvvr ojtq";

            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(from);
                message.To.Add(tbEmail.Text.Trim());
                message.Subject = "Chúc quý khách có một ngày xem phim vui vẻ";

               
                string emailContent = $"Thông tin vé xem phim<br><br>" +
                                      $"Họ và tên: {fname_textbox.Text}<br>" +
                                      $"Tên phim: {code}<br>" +
                                      $"Số ghế: {string.Join(", ", veDaChon)}<br><br>" +
                                      $"Chúc quý khách có một ngày xem phim vui vẻ!";

                
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(emailContent, null, "text/html");
                LinkedResource linkedPoster = new LinkedResource(posterFilePath, "image/jpeg");
                linkedPoster.ContentId = "PosterImage";
                linkedPoster.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                htmlView.LinkedResources.Add(linkedPoster);
                message.AlternateViews.Add(htmlView);

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(from, pass);

                
                smtp.Send(message);

                MessageBox.Show("Email đã được gửi thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi email: " + ex.Message);
            }
        }



        private ThanhToanInfo buyTicket()
        {
            Phim phimDuocChon = comboBox1.SelectedItem as Phim;
            string phongChieu = comboBox2.SelectedItem.ToString();

            List<string> VeDaChon = new List<string>();
            double tongTien = 0;

            foreach (CheckBox checkBox in groupBox1.Controls.OfType<CheckBox>())
            {
                if (checkBox.Checked)
                {
                    string ghe = checkBox.Text;
                    VeDaChon.Add(ghe);

                    if (veVot.Contains(ghe))
                        tongTien += 0.25 * phimDuocChon.GiaVeChuan;
                    else if (veVip.Contains(ghe))
                        tongTien += 2 * phimDuocChon.GiaVeChuan;
                    else
                        tongTien += phimDuocChon.GiaVeChuan;
                }
            }
            return new ThanhToanInfo
            {
                HoTen = fname_textbox.Text,
                VeDaChon = VeDaChon.ToArray(),
                TenPhim = phimDuocChon.TenPhim,
                PhongChieu = phongChieu,
                SoTienTT = tongTien
            };
        }

        private void check_btn_Click(object sender, EventArgs e)
        {
            ticketInfo_richtextbox.Clear();
            foreach (var khachhang in danhSachKhachHang)
            {
                ticketInfo_richtextbox.Text += khachhang.ToString() + Environment.NewLine + "---------------" + Environment.NewLine;
            }
        }

        private void rcheck_btn_Click(object sender, EventArgs e)
        {
            List<MovieStatistics> movieStatisticsList = new List<MovieStatistics>();
            foreach (var phim in danhsachPhim)
            {
                int soVeBanRa = 0;
                double doanhThu = 0;
                foreach (var khachhang in danhSachKhachHang)
                {
                    if (khachhang.TenPhim == phim.TenPhim)
                    {
                        soVeBanRa += khachhang.VeDaChon.Length;
                        doanhThu += khachhang.SoTienTT;
                    }
                }
                movieStatisticsList.Add(new MovieStatistics { TenPhim = phim.TenPhim, SoVeBanRa = soVeBanRa, SoVeTon = 500 - soVeBanRa, TiLeVeBanRa = (double)soVeBanRa / 500, DoanhThu = doanhThu });
            }
            movieStatisticsList = movieStatisticsList.OrderByDescending(x => x.DoanhThu).ToList();
            richTextBox1.Clear();
            richTextBox1.Text = "** Xếp hạng danh thu từ cao đến thấp " + Environment.NewLine + "-------------------------------" + Environment.NewLine;
            foreach (var movieStatistics in movieStatisticsList)
            {
                AppendTextToRichTextBox(richTextBox1, movieStatistics.ToString() + "\n");
            }
        }

        private void AppendTextToRichTextBox(RichTextBox richTextBox, string text)
        {
            if (richTextBox.InvokeRequired)
            {
                richTextBox.Invoke(new Action<RichTextBox, string>(AppendTextToRichTextBox), new object[] { richTextBox, text });
            }
            else
            {
                richTextBox.AppendText(text);
            }
        }

        private void backgroundWorkerExport_DoWork(object sender, DoWorkEventArgs e)
        {
            string filePath = e.Argument as string;

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                using (StreamWriter sr = new StreamWriter(fs))
                {
                    int totalProgress = 100; 
                    int currentProgress = 0; 

                    for (int i = 0; i < totalProgress; i++)
                    {
                        currentProgress++;

                        int percentage = (int)((double)currentProgress / totalProgress * 100);
                        backgroundWorkerExport.ReportProgress(percentage);

                        Thread.Sleep(50);
                    }

                    string contentToWrite = GetRichTextBoxText(richTextBox1);
                    sr.Write(contentToWrite);
                }
            }
        }

        private string GetRichTextBoxText(RichTextBox richTextBox)
        {
            string text = string.Empty;
            if (richTextBox.InvokeRequired)
            {
                richTextBox.Invoke(new Action(() => { text = richTextBox.Text; }));
            }
            else
            {
                text = richTextBox.Text;
            }
            return text;
        }

        private void backgroundWorkerExport_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarExport.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerExport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
               
            }
            else if (e.Cancelled)
            {
                
            }
            else
            {
                MessageBox.Show("Xuất file thành công!");
            }
        }

        private void write_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filePath = sfd.FileName;

                
                backgroundWorkerExport.RunWorkerAsync(filePath);
            }
        }

        class Phim
        {
            public string TenPhim { get; set; }
            public int GiaVeChuan { get; set; }
            public List<int> PhongChieu { get; set; }
            

        }

        class ThanhToanInfo
        {
            public string HoTen { get; set; }
            public string[] VeDaChon { get; set; }
            public string TenPhim { get; set; }
            public string PhongChieu { get; set; }
            public double SoTienTT { get; set; }
            public string posterFilePath { get; set; }

            public override string ToString()
            {
                return $"Họ tên: {HoTen}\nVé đã chọn: {string.Join(", ", VeDaChon)}\nTên phim: {TenPhim}\nPhòng chiếu: {PhongChieu}\nTổng tiền thanh toán: {SoTienTT}";
            }
        }

        class MovieStatistics
        {
            public string TenPhim { get; set; }
            public int SoVeBanRa { get; set; }
            public double DoanhThu { get; set; }
            public int SoVeTon { get; set; }
            public double TiLeVeBanRa { get; set; }

            public override string ToString()
            {
                return $"Phim: {TenPhim}, Số vé bán ra: {SoVeBanRa}, Số vé tồn: {SoVeTon}, Tỉ lệ vé bán ra: {TiLeVeBanRa}, Doanh thu: {DoanhThu}";
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {

            string url = szUrl.Text;
            string htmlContent = getHTML(url);
            WebClient myClient = new WebClient();
            Stream response = myClient.OpenRead(url);

            string filePath = textBox2.Text;
            try
            {
                myClient.DownloadFile(url, filePath);
                MessageBox.Show("Nội dung từ URL đã được tải và lưu thành công vào: " + filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải và lưu tệp tin từ URL: " + ex.Message);
            }
        }
        private string getHTML(string szUrl)
        {
            try
            {
                // Create a request for the URL.
                WebRequest request = WebRequest.Create(szUrl);
                // Get the response.
                WebResponse response = request.GetResponse();
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Close the response.
                reader.Close();
                response.Close();
                return responseFromServer;
            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred
                return "Error: " + ex.Message;
            }
        }

        private async void add_HTML_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "HTML Files|*.html";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string htmlFilePath = openFileDialog.FileName;
                
                LoadMovieDataFromHTML(htmlFilePath);
                string jsonFilePath = Path.Combine(Application.StartupPath, "danhsach_phim.json");
                await CreateAndSaveMovieDataToJson(htmlFilePath, jsonFilePath);
            }
        }


        private async Task CreateAndSaveMovieDataToJson(string htmlFilePath, string jsonFilePath)
        {
            try
            {
                
                List<string> movieNames = await ExtractMovieNamesFromHTML(htmlFilePath);

                
                Random random = new Random();
                List<Phim> phimList = new List<Phim>();
                foreach (string movieName in movieNames)
                {
                    int giaVeChuan = random.Next(90000, 150000); 
                    List<int> phongChieu = new List<int> { random.Next(1, 11), random.Next(1, 11) }; 
                    Phim phim = new Phim { TenPhim = movieName, GiaVeChuan = giaVeChuan, PhongChieu = phongChieu };
                    phimList.Add(phim);
                }

                // Serialize Phim list to JSON and save to file
                string jsonData = JsonSerializer.Serialize(phimList);
                await File.WriteAllTextAsync(jsonFilePath, jsonData);

                MessageBox.Show("Danh sách phim đã được lưu vào tệp JSON thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tạo và lưu danh sách phim vào tệp JSON: " + ex.Message);
            }
        }

        private async Task<List<string>> ExtractMovieNamesFromHTML(string htmlFilePath)
        {
            List<string> movieNames = new List<string>();

            try
            {
                string htmlContent = await File.ReadAllTextAsync(htmlFilePath);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(htmlContent);

                var titleNodes = doc.DocumentNode.SelectNodes("//h3[@class='text-center text-sm-left text-xs-left bold margin-top-5 font-sm-18 font-xs-14']/a");
                if (titleNodes != null)
                {
                    foreach (var titleNode in titleNodes)
                    {
                        string movieName = titleNode.InnerText.Trim();
                        movieNames.Add(movieName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi trích xuất tên phim từ tệp HTML: " + ex.Message);
            }

            return movieNames;
        }

    }
}

