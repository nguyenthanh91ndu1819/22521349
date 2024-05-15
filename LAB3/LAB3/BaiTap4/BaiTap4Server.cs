using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3
{
    public partial class BaiTap4Server : Form
    {
        string[] veVot = { "A1", "A5", "C1", "C5" };
        string[] veVip = { "B2", "B3", "B4" };
        List<ThanhToanInfo> danhSachKhachHang = new List<ThanhToanInfo>();
        List<Phim> danhsachPhim = new List<Phim>();
        List<Socket> clientSockets = new List<Socket>();

        class Phim
        {
            public string TenPhim { get; set; }
            public int GiaVeChuan { get; set; }
            public int[] PhongChieu { get; set; }
        }

        public BaiTap4Server()
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
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

                // Gửi danh sách phim mới tới các client
                BroadcastMovieList();
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




        private void btnListen_Click(object sender, EventArgs e)
        {
            Thread serverThread = new Thread(new ThreadStart(StartListening));
            serverThread.Start();
        }

        void StartListening()
        {
            try
            {
                Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
                listenerSocket.Bind(localEndPoint);
                listenerSocket.Listen(10);

                while (true)
                {
                    Console.WriteLine("Đang chờ kết nối...");
                    Socket clientSocket = listenerSocket.Accept();
                    Console.WriteLine("Đã kết nối với client");

                    lock (clientSockets)
                    {
                        clientSockets.Add(clientSocket);
                    }

                    Thread clientThread = new Thread(() => HandleClient(clientSocket));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void HandleClient(Socket clientSocket)
        {
            try
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = clientSocket.Receive(buffer)) > 0)
                {
                    string receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    ThanhToanInfo tickets = JsonSerializer.Deserialize<ThanhToanInfo>(receivedData);

                    string response;

                    bool isTicketSold = danhSachKhachHang.Any(kh => kh.TenPhim == tickets.TenPhim && kh.PhongChieu == tickets.PhongChieu && kh.VeDaChon.Intersect(tickets.VeDaChon).Any());

                    if (isTicketSold)
                    {
                        response = "Fail";
                    }
                    else
                    {
                        danhSachKhachHang.Add(tickets);
                        response = "Success";
                    }

                    byte[] responseData = Encoding.ASCII.GetBytes(response);
                    clientSocket.Send(responseData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();

                lock (clientSockets)
                {
                    clientSockets.Remove(clientSocket);
                }
            }
        }

        void BroadcastMovieList()
        {
            string movieListJson = JsonSerializer.Serialize(danhsachPhim);
            byte[] movieListData = Encoding.ASCII.GetBytes(movieListJson);

            lock (clientSockets)
            {
                foreach (Socket clientSocket in clientSockets)
                {
                    clientSocket.Send(movieListData);
                }
            }
        }
    }
}

