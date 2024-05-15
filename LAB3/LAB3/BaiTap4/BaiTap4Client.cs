using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Text.Json;

namespace LAB3
{
    public partial class BaiTap4Client : Form
    {
        private ThanhToanInfo thanhToanHienTai;

        public BaiTap4Client()
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            buy_btn.Click += buy_btn_Click;
            
        }
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Phim phimDuocChon = comboBox1.SelectedItem as Phim;
            if (phimDuocChon != null)
            {
                comboBox2.DataSource = phimDuocChon.PhongChieu.Select(p => p.ToString()).ToList();
            }
        }

        public void buy_btn_Click(object sender, EventArgs e)
        {
            ThanhToanInfo tickets = buyTicket();
            bool isTicketSold = false;

            try
            {
                TcpClient tcpClient = new TcpClient("127.0.0.1", 8080);
                NetworkStream ns = tcpClient.GetStream();

                string json = JsonSerializer.Serialize(tickets);
                byte[] data = Encoding.ASCII.GetBytes(json);
                ns.Write(data, 0, data.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = ns.Read(buffer, 0, buffer.Length);
                string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                if (response == "Success")
                {
                    MessageBox.Show("Mua vé thành công!");
                }
                else if (response == "Fail")
                {
                    MessageBox.Show("Vé đã có người mua");
                } 
                    
                

                ns.Close();
                tcpClient.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (thanhToanHienTai != null)
            {
                ticketInfo_richtextbox.Text = thanhToanHienTai.ToString() + Environment.NewLine + "---------------" + Environment.NewLine;
            }
            else
            {
                ticketInfo_richtextbox.Text = "Chưa có thông tin mua vé.";
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            TcpClient tcpClient = new TcpClient();

            try
            {
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8080);

                int attempts = 0;
                while (!tcpClient.Connected && attempts < 5)
                {
                    try
                    {
                        tcpClient.Connect(ipEndPoint);
                    }
                    catch (SocketException)
                    {
                        attempts++;
                        Thread.Sleep(1000);
                    }
                }

                if (tcpClient.Connected)
                {
                    Thread receiveThread = new Thread(() => ReceiveData(tcpClient));
                    MessageBox.Show("Connect to server successfully");
                    receiveThread.Start();
                }
                else
                {
                    MessageBox.Show("Failed to connect to server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReceiveData(TcpClient tcpClient)
        {
            NetworkStream ns = tcpClient.GetStream();
            byte[] buffer = new byte[1024];

            try
            {
                while (true)
                {
                    int bytesRead = ns.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                        break;
                    string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    UpdateMovies(response);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection to server lost: " + ex.Message);
            }
            finally
            {
                ns.Close();
                tcpClient.Close();
            }
        }

        private void UpdateMovies(string jsonData)
        {
            List<Phim> updatedMovies = JsonSerializer.Deserialize<List<Phim>>(jsonData);
            Invoke((MethodInvoker)delegate
            {
                danhsachPhim = updatedMovies;
                comboBox1.DataSource = null;
                comboBox1.DataSource = danhsachPhim;
                comboBox1.DisplayMember = "TenPhim";
            });
        }

    }
}
