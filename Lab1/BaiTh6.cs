using System;
using System.Windows.Forms;

namespace Lab1
{
    public partial class BaiTh6 : Form
    {
        public BaiTh6()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int day, month, year;
            day = Int32.Parse(textBox1.Text.Trim());
            month = Int32.Parse(textBox2.Text.Trim());
            year = Int32.Parse(textBox3.Text.Trim());

            switch (month)
            {
                case 1:
                    if (day >= 21 && day <= 31)
                        textBox4.Text = "Cung bao binh";
                    else if (day >= 1 && day <= 20)
                        textBox4.Text = "Cung ma ket";
                    break;
                case 2:
                    if (day >= 1 && day <= 19)
                        textBox4.Text = "Cung bao binh";
                    else if (day >= 20 && day <= 29)
                        textBox4.Text = "Cung song ngu";
                    break;
                case 3:
                    if (day >= 1 && day <= 20)
                        textBox4.Text = "Cung song ngu";
                    else if (day >= 21 && day <= 31)
                        textBox4.Text = "Cung bach duong";
                    break;
                case 4:
                    if (day >= 1 && day <= 20)
                        textBox4.Text = "Cung bach duong";
                    else if (day >= 21 && day <= 30)
                        textBox4.Text = "Cung kim nguu";
                    break;
                case 5:
                    if (day >= 1 && day <= 21)
                        textBox4.Text = "Cung kim nguu";
                    else if (day >= 22 && day <= 31)
                        textBox4.Text = "Cung song tu";
                    break;
                case 6:
                    if (day >= 1 && day <= 21)
                        textBox4.Text = "Cung song tu";
                    else if (day >= 22 && day <= 30)
                        textBox4.Text = "Cung cu giai";
                    break;
                case 7:
                    if (day >= 1 && day <= 22)
                        textBox4.Text = "Cung cu giai";
                    else if (day >= 23 && day <= 31)
                        textBox4.Text = "Cung su tu";
                    break;
                case 8:
                    if (day >= 1 && day <= 22)
                        textBox4.Text = "Cung su tu";
                    else if (day >= 23 && day <= 31)
                        textBox4.Text = "Cung xu nu";
                    break;
                case 9:
                    if (day >= 1 && day <= 23)
                        textBox4.Text = "Cung xu nu";
                    else if (day >= 24 && day <= 30)
                        textBox4.Text = "Cung thien binh";
                    break;
                case 10:
                    if (day >= 1 && day <= 23)
                        textBox4.Text = "Cung thien binh";
                    else if (day >= 24 && day <= 31)
                        textBox4.Text = "Cung than nong";
                    break;
                case 11:
                    if (day >= 1 && day <= 22)
                        textBox4.Text = "Cung than nong";
                    else if (day >= 23 && day <= 30)
                        textBox4.Text = "Cung nhan ma";
                    break;
                case 12:
                    if (day >= 1 && day <= 21)
                        textBox4.Text = "Cung nhan ma";
                    else if (day >= 22 && day <= 31)
                        textBox4.Text = "Cung ma ket";
                    break;
                default:
                    textBox4.Text = "Gia tri nhap vao khong hop le";
                    break;
            }
        }

       
    }
}
