using System;
using System.Windows.Forms;

namespace Lab1
{
    public partial class BaiTap6 : Form
    {
        public BaiTap6()
        {
            InitializeComponent();
        }

        bool IsValidDate(int day, int month, int year)
        {
            bool isLeapYear = (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
            if (month < 1 || month > 12)
                return false;
            switch (month)
            {
                case 2:
                    if (isLeapYear)
                    {
                        if (day < 1 || day > 29)
                            return false;
                    }
                    else
                    {
                        if (day < 1 || day > 28)
                            return false;
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    if (day < 1 || day > 30)
                        return false;
                    break;
                default:
                    if (day < 1 || day > 31)
                        return false;
                    break;
            }

            return true;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            int day, month, year;
            if (!Int32.TryParse(textBox1.Text.Trim(), out day) ||
                !Int32.TryParse(textBox2.Text.Trim(), out month) ||
                !Int32.TryParse(textBox3.Text.Trim(), out year))
            {
                textBox4.Text = "Ngày tháng năm phải là số nguyên";
                return;
            }

            if (!IsValidDate(day, month, year))
            {
                textBox4.Text = "Ngày tháng không hợp lệ";
                return;
            }
            switch (month)
            {
                case 1:
                    if (day >= 21 && day <= 31)
                        textBox4.Text = "Cung bảo bình";
                    else if (day >= 1 && day <= 20)
                        textBox4.Text = "Cung ma kết";
                    break;
                case 2:
                    if (day >= 1 && day <= 19)
                        textBox4.Text = "Cung bảo bình";
                    else if (day >= 20 && day <= 29)
                        textBox4.Text = "Cung song ngư";
                    break;
                case 3:
                    if (day >= 1 && day <= 20)
                        textBox4.Text = "Cung song ngư";
                    else if (day >= 21 && day <= 31)
                        textBox4.Text = "Cung bạch dương";
                    break;
                case 4:
                    if (day >= 1 && day <= 20)
                        textBox4.Text = "Cung bạch dương";
                    else if (day >= 21 && day <= 30)
                        textBox4.Text = "Cung kim ngưu";
                    break;
                case 5:
                    if (day >= 1 && day <= 21)
                        textBox4.Text = "Cung kim ngưu";
                    else if (day >= 22 && day <= 31)
                        textBox4.Text = "Cung song tử";
                    break;
                case 6:
                    if (day >= 1 && day <= 21)
                        textBox4.Text = "Cung song tử";
                    else if (day >= 22 && day <= 30)
                        textBox4.Text = "Cung cự giải";
                    break;
                case 7:
                    if (day >= 1 && day <= 22)
                        textBox4.Text = "Cung cự giải";
                    else if (day >= 23 && day <= 31)
                        textBox4.Text = "Cung sư tử";
                    break;
                case 8:
                    if (day >= 1 && day <= 22)
                        textBox4.Text = "Cung sư tử";
                    else if (day >= 23 && day <= 31)
                        textBox4.Text = "Cung xử nữ";
                    break;
                case 9:
                    if (day >= 1 && day <= 23)
                        textBox4.Text = "Cung xử nữ";
                    else if (day >= 24 && day <= 30)
                        textBox4.Text = "Cung thiên bình";
                    break;
                case 10:
                    if (day >= 1 && day <= 23)
                        textBox4.Text = "Cung thiên bình";
                    else if (day >= 24 && day <= 31)
                        textBox4.Text = "Cung thần Nông";
                    break;
                case 11:
                    if (day >= 1 && day <= 22)
                        textBox4.Text = "Cung thần Nông";
                    else if (day >= 23 && day <= 30)
                        textBox4.Text = "Cung nhân Mã";
                    break;
                case 12:
                    if (day >= 1 && day <= 21)
                        textBox4.Text = "Cung nhân Mã";
                    else if (day >= 22 && day <= 31)
                        textBox4.Text = "Cung ma kết";
                    break;
                default:
                    textBox4.Text = "Giá trị nhập vào không hợp lệ";
                    break;
            }
        }
    }
}
