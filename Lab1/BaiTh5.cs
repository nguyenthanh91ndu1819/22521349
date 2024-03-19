using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class BaiTh5 : Form
    {
        public BaiTh5()
        {
            InitializeComponent();
            comboBox1.Items.Add("Bảng cửu chương");
            comboBox1.Items.Add("Tính toán giá trị");
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {
                int a, b;
                a = Int32.Parse(textBox1.Text.Trim());
                b = Int32.Parse(textBox2.Text.Trim());
                int c = Math.Abs(b - a);
                for (int i = 1; i <= 10; i++) {
                    int d = c * i;
                    listBox1.Items.Add($" {c} * {i} = {d}");
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                int a, b;
                a = Int32.Parse(textBox1.Text.Trim());
                b = Int32.Parse(textBox2.Text.Trim());
                int d = a - b;
                if (a - b < 0)
                {
                    listBox1.Items.Add($"Không thể tính giai thừa của một số âm vì {a} - {b} < 0");
                }
                else
                {
                    long result = TinhGiaiThua(d);
                    listBox1.Items.Add($"Giai thừa của ({a} - {b})! = {d}");
                }
                static long TinhGiaiThua(int number)
                {
                    if (number <= 1) return 1;

                    long result = 1;
                    for (int i = 2; i <= number; i++)
                    {
                        result *= i;
                    }
                    return result;
                }
                double S = Math.Pow(a, b + 1) - a;
                S /= (a - 1);
                listBox1.Items.Add($"A^1 + A ^2 + ... A^B = {S}");


            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.Clear();
            }
            else
            {
                MessageBox.Show("Please select an item to delete.");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
