using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab1
{
    public partial class BaiTap4 : Form
    {
        public BaiTap4()
        {
            InitializeComponent();
            comboBox1.Items.Add("Đào phở và piano");
            comboBox1.Items.Add("Mai");
            comboBox1.Items.Add("Gặp lại chị bầu");
            comboBox1.Items.Add("Tarot");
            comboBox2.Items.Add("A1");
            comboBox2.Items.Add("A2");
            comboBox2.Items.Add("A3");
            comboBox2.Items.Add("A4");
            comboBox2.Items.Add("A5");
            comboBox2.Items.Add("B1");
            comboBox2.Items.Add("B2");
            comboBox2.Items.Add("B3");
            comboBox2.Items.Add("B4");
            comboBox2.Items.Add("B5");
            comboBox2.Items.Add("C1");
            comboBox2.Items.Add("C2");
            comboBox2.Items.Add("C3");
            comboBox2.Items.Add("C4");
            comboBox2.Items.Add("C5");
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {

                comboBox3.Items.Clear();


                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        comboBox3.Items.AddRange(new string[] { "1", "2", "3" });
                        break;
                    case 1:
                        comboBox3.Items.AddRange(new string[] { "2", "3" });
                        break;
                    case 2:
                        comboBox3.Items.Add("1");
                        break;
                    case 3:
                        comboBox3.Items.Add("3");
                        break;
                    default:
                        break;
                }
            }
        }
        string selectedRoom = "";
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string movie = comboBox1.SelectedItem?.ToString();
            string seat = comboBox2.SelectedItem?.ToString();
            string room = comboBox3.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(movie) || string.IsNullOrEmpty(seat) || string.IsNullOrEmpty(room))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin.");
                return;
            }
            if (!string.IsNullOrEmpty(selectedRoom) && selectedRoom != room)
            {
                MessageBox.Show("Không thể chọn vé ở hai phòng chiếu khác nhau.");
                return;
            }
            string valueToCheck = $"{name}, {movie}, {seat}, {room}";
            if (!checkedListBox1.Items.Contains(valueToCheck))
            {
                checkedListBox1.Items.Add(valueToCheck);
                selectedRoom = room;
                MessageBox.Show("Vé đã được thêm vào danh sách chờ mua.");
            }
            else
            {
                MessageBox.Show("Vé này đã được chọn.");
            }
        }
        HashSet<string> purchasedTickets = new HashSet<string>();

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string movie = comboBox1.SelectedItem?.ToString();
            string seat = comboBox2.SelectedItem?.ToString();
            string room = comboBox3.SelectedItem?.ToString();
            string ticket = $"{name}, {movie}, {seat}, {room}";
            if (purchasedTickets.Contains(ticket))
            {
                MessageBox.Show("Vé này đã được mua.");
            }
            else
            {
                purchasedTickets.Add(ticket);
                MessageBox.Show("Vé đã được mua thành công.");
            }
        }

        Dictionary<string, int> standardTicketPrices = new Dictionary<string, int>()
        {
            { "Đào phở và piano", 45000 },
            { "Mai", 100000 },
            { "Gặp lại chị bầu", 70000 },
            { "Tarot", 90000 }
        };
        private int CalculateTicketPrice(string movie, string seat)
        {
            int basePrice = standardTicketPrices[movie.Trim()];
            if (seat == "A1" || seat == "A5" || seat == "C1" || seat == "C5")
            {
            
                return basePrice / 4;
            }
            else if (seat == "B2" || seat == "B3" || seat == "B4")
            {
                
                return basePrice * 2;
            }
            
            return basePrice;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.Items.Count == 0)
            {
                MessageBox.Show("Chưa có vé nào được đặt.");
                return;
            }
            int totalPrice = 0; 
            StringBuilder ticketInfo = new StringBuilder(); 
            foreach (string item in checkedListBox1.Items)
            {
                string[] ticketDetails = item.Split(new string[] { ", " }, StringSplitOptions.None);
                if (ticketDetails.Length >= 4)
                {
                    string name = ticketDetails[0];
                    string movie = ticketDetails[1];
                    string seat = ticketDetails[2];
                    string room = ticketDetails[3];
                    int price = CalculateTicketPrice(movie.Trim(), seat);
                    totalPrice += price; 
                    ticketInfo.AppendLine($"Họ và tên: {name}");
                    ticketInfo.AppendLine($"Phim: {movie}");
                    ticketInfo.AppendLine($"Ghế: {seat}");
                    ticketInfo.AppendLine($"Phòng chiếu: {room}");
                    ticketInfo.AppendLine($"Giá tiền: {price}");
                    ticketInfo.AppendLine(); 
                }
            }

            
            string message = $"Tổng số tiền đặt vé: {totalPrice}đ\n\n";
            message += "Thông tin chi tiết các vé đã đặt:\n\n";
            message += ticketInfo.ToString();
            MessageBox.Show(message);
        }

    }
}
