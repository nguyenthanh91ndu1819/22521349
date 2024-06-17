using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB6
{
    public partial class BaiTap1 : Form
    {
        public BaiTap1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbShift.Text, out int shift))
            {
                string encryptedText = Encrypt(tbData.Text, shift);
                tbEncryptedData.Text = encryptedText;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập giá trị Dịch hơp lệ");
            }
        }

        static string Encrypt(string input, int shift)
        {
            StringBuilder cipherText = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    if (char.IsLower(c))
                    {
                        char shifted = (char)(((c - 'a' + shift) % 26) + 'a');
                        cipherText.Append(shifted);
                    }
                    else if (char.IsUpper(c))
                    {
                        char shifted = (char)(((c - 'A' + shift) % 26) + 'A');
                        cipherText.Append(shifted);
                    }
                }
                else
                {
                    cipherText.Append(c);
                }
            }
            return cipherText.ToString();
        }
        static string Decrypt(string input, int shift)
        {
            StringBuilder plainText = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    if (char.IsLower(c))
                    {
                        char shifted = (char)(((c - 'a' - shift + 26) % 26) + 'a');
                        plainText.Append(shifted);
                    }
                    else if (char.IsUpper(c))
                    {
                        char shifted = (char)(((c - 'A' - shift + 26) % 26) + 'A');
                        plainText.Append(shifted);
                    }
                }
                else
                {
                    plainText.Append(c);
                }
            }
            return plainText.ToString();
        }
        private void btnDencrypt_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbShift.Text, out int shift))
            {
                string decryptedText = Decrypt(tbEncryptedData.Text, shift);
                tbDencryptedData.Text = decryptedText;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập giá trị Dịch hơp lệ");
            }
        }
    }
}
