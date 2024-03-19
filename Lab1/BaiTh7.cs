using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab1
{
    public partial class BaiTh7 : Form
    {
        private string[] information;
        private string input;
        public BaiTh7()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            input = textBox1.Text;
            information = input.Split(',');
            if (information.Length > 0 && !string.IsNullOrWhiteSpace(information[0]))
            {
                string s = information[0].Trim();
                MessageBox.Show($"Họ và tên : {information[0]} ");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            input = textBox1.Text;
            information = input.Split(',');
            if (information.Length > 0)
            {
                for (int i = 1; i < information.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(information[i]))
                    {
                        listBox1.Items.Add($"Môn {i} : {information[i].Trim()}");
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            input = textBox1.Text;
            information = input.Split(',');
            double S = 0;
            int count = 0;
            if (information.Length > 2)
            {
                for (int i = 1; i < information.Length; i++)
                {
                    if (double.TryParse(information[i], out double num))
                    {
                        S += num;
                        count++;
                    }
                }
                double kq = S / count;
                MessageBox.Show($"Điểm trung bình của {information[0]} là: {kq}");

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            input = textBox1.Text;
            information = input.Split(',');
            if (information.Length >= 2)
            {
                double max = double.Parse(information[1]);
                double min = double.Parse(information[1]);
                double c = 1, d = 1;
                for (int i = 2; i < information.Length; i++)
                {
                    double a = double.Parse(information[i]);
                    if (a > max)
                    {
                        max = a;
                        c = i;
                    }
                    if (a < min)
                    {
                        min = a;
                        d = i;
                    }
                }
                MessageBox.Show($"Môn có điểm cao nhất là : môn {c} với số điểm {max} \nMôn có điểm thấp nhất là : môn {d} với số điểm {min} ");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            input = textBox1.Text;
            information = input.Split(',');
            int MonDau = 0;
            int MonRot = 0;
            if (information.Length >= 2)
            {
                for (int i = 1; i < information.Length; i++)
                {
                    double a = double.Parse(information[i]);
                    if (a >= 5)
                    {
                        MonDau++;
                    }
                    else if (a < 5)
                    {
                        MonRot++;
                    }
                }
                MessageBox.Show($"Số môn đậu là: {MonDau} \nSố môn rớt là: {MonRot}");
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            input = textBox1.Text;
            information = input.Split(',');
            double S = 0;
            int count = 0;
            if (information.Length > 2)
            {
                for (int i = 1; i < information.Length; i++)
                {
                    if (double.TryParse(information[i], out double num))
                    {
                        S += num;
                        count++;
                    }
                }
                double kq = S / count;
                for (int i = 1; i < information.Length; i++)
                {
                    double a = double.Parse(information[i]);
                    if (kq >= 8 && a >= 6.5)
                    {
                        MessageBox.Show("Bạn đạt loại Giỏi");
                        break;
                    }
                    else if (kq >= 6.5 && a >= 5)
                    {
                        MessageBox.Show("Bạn đạt loại Khá");
                        break;
                    }
                    else if (kq >= 5 && a >= 3.5)
                    {
                        MessageBox.Show("Bạn đạt loại Trung Bình");
                        break;
                    }
                    else if (kq >= 3.5 && a >= 2)
                    {
                        MessageBox.Show("Bạn đạt loại Yếu");
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Bạn đạt loại Kém");
                        break;
                    }
                }
            }
        }
    }
}
