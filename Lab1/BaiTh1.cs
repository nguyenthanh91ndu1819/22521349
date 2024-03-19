using System;
using System.Windows.Forms;

namespace Lab1
{
    public partial class BaiTh1 : Form
    {
        public BaiTh1()
        {
            InitializeComponent();
            textBox1.TextChanged += TextBox1_TextChanged;
            textBox2.TextChanged += TextBox1_TextChanged;
            textBox3.TextChanged += TextBox3_TextChanged;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            CheckDigits1();
            CalculateResult();
        }
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            CheckDigits2();
            CalculateResult();
        }
        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void CheckDigits1()
        {
            string input = textBox1.Text.Trim(); 

            bool isAllDigits = true;
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    isAllDigits = false;
                    break;
                }
            }

            if (!isAllDigits)
            {
                MessageBox.Show("Kí tự bạn vừa nhập không phải là số.");
                return;
            }
        }
        private void CheckDigits2()
        {
            string input = textBox2.Text.Trim();

            bool isAllDigits = true;
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    isAllDigits = false;
                    break;
                }
            }

            if (!isAllDigits)
            {
                MessageBox.Show("Kí tự bạn vừa nhập không phải là số.");
                return;
            }
        }
         private void CalculateResult()
        {
            int number1, number2;
            if (int.TryParse(textBox1.Text, out number1) && int.TryParse(textBox2.Text, out number2))
            {
                int result = number1 + number2;
                textBox3.Text = result.ToString();
            }
            else
            {
                textBox3.Text = ""; 
            }
        }

    }
}
