using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab1
{
    public partial class BaiNangCao : Form
    {
        public BaiNangCao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long n = 1;
            long input = long.Parse(textBox1.Text);
            int count = -1;
            long[] digits = new long[13];
            string[] digitsText = { null, "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };
            string message = "";
            bool isPreviousZero = false;

            while (n < 1000000000000)
            {
                long b = input / n;
                if (b > 0)
                {
                    for (int i = 0; i < 13; i++)
                    {
                        count++;
                        digits[i] = b % 10;
                        b /= 10;
                    }
                }

                input %= n;
                n *= 10;
            }
            for (int i = count; i >= 0; i--)
            {
                int max = count;
                if (i == 13)
                {
                    if (digits[i] != 0)
                    {
                        message += $"{digitsText[digits[i]]} mươi ";
                        isPreviousZero = false;
                    }
                }
                else if (i == 12)
                {
                    if (digits[i] != 0)
                    {
                        message += $"{digitsText[digits[i]]} nghìn ";
                        isPreviousZero = false;
                    }
                    else if (!isPreviousZero && digits[max] != 0)
                    {
                        message += "linh ";
                        isPreviousZero = true;
                    }

                }
                else if (i == 11)
                {
                    if (digits[i] != 0)
                    {
                        message += $"{digitsText[digits[i]]} trăm ";
                        isPreviousZero = false;
                    }
                    else if (!isPreviousZero && digits[max] != 0)
                    {
                        message += "linh ";
                        isPreviousZero = true;
                    }
                }
                else if (i == 10)
                {
                    if (digits[i] != 0)
                    {
                        message += $"{digitsText[digits[i]]} mươi ";
                        isPreviousZero = false;
                    }
                }
                else if (i == 9)
                {
                    if (digits[i] != 0)
                    {
                        message += $"{digitsText[digits[i]]} tỷ ";
                        isPreviousZero = false;
                    }
                    else if (!isPreviousZero && digits[max] != 0)
                    {
                        message += "linh ";
                        isPreviousZero = true;
                    }
                }
                else if (i == 8)
                {
                    if (digits[i] != 0)
                    {
                        message += $"{digitsText[digits[i]]} trăm ";
                        isPreviousZero = false;
                    }
                    else if (!isPreviousZero && digits[max] != 0)
                    {
                        message += "linh ";
                        isPreviousZero = true;
                    }
                }
                else if (i == 7) 
                {
                    if (digits[i] != 0)
                    {
                        message += $"{digitsText[digits[i]]} mươi ";
                        isPreviousZero = false;
                    }
                    else if (!isPreviousZero && digits[max] != 0)
                    {
                        message += "linh ";
                        isPreviousZero = true;
                    }
                }

                else if (i == 6)
                {
                    if (digits[i] != 0)
                    {
                        message += $"{digitsText[digits[i]]} triệu ";
                        isPreviousZero = false;
                    }
                    else if (!isPreviousZero && digits[max] != 0)
                    {
                        message += "linh ";
                        isPreviousZero = true;
                    }
                }
                else if (i == 5)
                {
                    if (digits[i] != 0)
                    {
                        message += $"{digitsText[digits[i]]} trăm ";
                        isPreviousZero = false;
                    }
                    else if (!isPreviousZero && digits[max] != 0)
                    {
                        message += "linh ";
                        isPreviousZero = true;
                    }
                }
                else if (i == 4)
                {
                    if (digits[i] != 0)
                    {
                        message += $"{digitsText[digits[i]]} mươi ";
                        isPreviousZero = false;
                    }
                    else if (!isPreviousZero && digits[max] != 0)
                    {
                        message += "linh ";
                        isPreviousZero = true;
                    }
                }
                else if (i == 3)
                {
                    if (digits[i] != 0)
                    {
                        message += $"{digitsText[digits[i]]} nghìn ";
                        isPreviousZero = false;
                    }
                    else if (!isPreviousZero && digits[max] != 0)
                    {
                        message += "linh ";
                        isPreviousZero = true;
                    }

                }
                else if (i == 2)
                {
                    if (digits[i] != 0)
                    {
                        message += $"{digitsText[digits[i]]} trăm  ";
                        isPreviousZero = false;
                    }
                    else if (!isPreviousZero && digits[max] != 0)
                    {
                        message += "linh ";
                        isPreviousZero = true;
                    }
                }
                else if (i == 1)
                {
                    if (digits[i] != 0)
                    {
                        message += $"{digitsText[digits[i]]} mươi ";
                        isPreviousZero = false;
                    }
                    else if (!isPreviousZero && digits[max] != 0)
                    {
                        message += "linh ";
                        isPreviousZero = true;
                    }
                }
                else
                {
                    message += $"{digitsText[digits[i]]} ";
                }
            }

            MessageBox.Show(message.Trim());
        }
    }
}

