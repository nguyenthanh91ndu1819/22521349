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
    public partial class BaiTap2 : Form
    {
        public BaiTap2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string content;
            int lineCount = 0; // Khoi tao bien dem so dong
            int wordCount = 0; // Khoi tao bien dem so chu
            int charCount = 0; // Khoi tao bien dem ki tu
            using (FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    content = sr.ReadToEnd();
                    //Dat con tro ve dau file
                    sr.BaseStream.Seek(0, SeekOrigin.Begin);
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lineCount++;
                        //Dem so chu cua moi dong
                        wordCount += line.Split(new char[] { ' ', '.', ',', '!', '?', ';', ':', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
                        charCount += line.Length;
                    }
                }
            }

            richTextBox1.Text = content;
            textBox4.Text = lineCount.ToString();
            textBox5.Text = wordCount.ToString();
            textBox6.Text = charCount.ToString();
            //Hien thi ten file
            string name = ofd.SafeFileName.ToString();
            textBox1.Text = name;
            //Tim do dai cua file
            FileInfo fi = new FileInfo(ofd.FileName);
            textBox2.Text = fi.Length.ToString() + " bytes";
            //Lay duong dan cua file
            textBox3.Text = fi.Directory.ToString();
            
        }

    }
}
