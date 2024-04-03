using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Lab2
{
    public partial class BaiTap5 : Form
    {
        string[] veVot = { "A1", "A5", "C1", "C5" };
        string[] veVip = { "B2", "B3", "B4" };
        List<ThanhToanInfo> danhSachKhachHang = new List<ThanhToanInfo>();
        List<Phim> danhsachPhim = new List<Phim>();
        class Phim
        {
            public string TenPhim { get; set; }
            public int GiaVeChuan { get; set; }
            public int[] PhongChieu { get; set; }
        }

        class ThanhToanInfo
        {
            public string HoTen { get; set; }
            public string[] VeDaChon { get; set; }
            public string TenPhim { get; set; }
            public string PhongChieu { get; set; }
            public double SoTienTT { get; set; }

            public override string ToString()
            {
                return $"Họ tên: {HoTen}\nVé đã chọn: {string.Join(", ", VeDaChon)}\nTên phim: {TenPhim}\nPhòng chiếu: {PhongChieu}\nTổng tiền thanh toán: {SoTienTT}";
            }
        }
        public BaiTap5()
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        public void buy_btn_Click(object sender, EventArgs e)
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
            }
        }

        private ThanhToanInfo buyTicket()
        {
            Phim phimDuocChon = comboBox1.SelectedItem as Phim;
            string phongChieu = comboBox2.SelectedItem.ToString();

            List<string> VeDaChon = new List<string>();
            double tongTien = 0;

            foreach (System.Windows.Forms.CheckBox checkBox in groupBox1.Controls.OfType<System.Windows.Forms.CheckBox>())
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


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Phim phimDuocChon = comboBox1.SelectedItem as Phim;
            if (phimDuocChon != null)
            {
                comboBox2.DataSource = phimDuocChon.PhongChieu.Select(p => p.ToString()).ToList();
            }
        }

        private void check_btn_Click(object sender, EventArgs e)
        {
            ticketInfo_richtextbox.Clear();
            foreach (var khachhang in danhSachKhachHang)
            {
                ticketInfo_richtextbox.Text += khachhang.ToString() + Environment.NewLine + "---------------" + Environment.NewLine;
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
  
        public class MovieStatistics
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
                    int totalProgress = 100; // Tổng số bước tiến trình
                    int currentProgress = 0; // Bước tiến trình hiện tại

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

                // Khởi động BackgroundWorker
                backgroundWorkerExport.RunWorkerAsync(filePath);
            }
        }

    }
}
