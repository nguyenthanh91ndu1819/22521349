using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    public partial class BaiTap1 : Form
    {
        public BaiTap1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
            {
                    string content;
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        content = sr.ReadToEnd();
                    }
                    richTextBox1.Text = content;
            }
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.ShowDialog();
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    sw.Write(richTextBox1.Text.ToUpper());
                }
                MessageBox.Show($"Đã ghi file thành công!");
        }
    }
}
