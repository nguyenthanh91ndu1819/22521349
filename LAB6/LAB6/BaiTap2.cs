using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB6
{
    public partial class BaiTap2 : Form
    {
        public BaiTap2()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string keyword = tbKeyWord.Text.ToUpper();
            if (!string.IsNullOrEmpty(keyword))
            {
                string generatedKey = generateKey(tbData.Text.ToUpper(), keyword);
                string encryptedText = Encrypt(tbData.Text.ToUpper(), generatedKey);
                tbEncryptedData.Text = encryptedText;
            }
            else
            {
                MessageBox.Show("Vui long nhap KEY WORD hop le");
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string keyword = tbKeyWord.Text.ToUpper(); 
            if (!string.IsNullOrEmpty(keyword))
            {
                string generatedKey = generateKey(tbEncryptedData.Text.ToUpper(), keyword);
                string decryptedText = Decrypt(tbEncryptedData.Text.ToUpper(), generatedKey);
                tbDecryptedData.Text = decryptedText;
            }
            else
            {
                MessageBox.Show("Vui long nhap KEY WORD hop le.");
            }
        }

        static string generateKey(string input, string key)
        {
            int x = input.Length;

            for (int i = 0; key.Length < x; i++)
            {
                key += key[i % key.Length];
            }
            return key;
        }

        static string Encrypt(string input, string key)
        {
            string cipher_text = "";
            for (int i = 0; i < input.Length; i++)
            {
               
                if (char.IsLetter(input[i]))
                {
                    int x = (input[i] + key[i]) % 26;
                    x += 'A';
                    cipher_text += (char)x;
                }
                else
                {
                    cipher_text += input[i]; 
                }
            }
            return cipher_text;
        }

        static string Decrypt(string cipher_text, string key)
        {
            string orig_text = "";
            for (int i = 0; i < cipher_text.Length; i++)
            {
                
                if (char.IsLetter(cipher_text[i]))
                {
                    int x = (cipher_text[i] - key[i] + 26) % 26;
                    x += 'A';
                    orig_text += (char)x;
                }
                else
                {
                    orig_text += cipher_text[i];
                }
            }
            return orig_text;
        }
    }
}
