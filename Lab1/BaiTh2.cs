using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class BaiTh2 : Form
    {
        public BaiTh2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            float a, b, c;
            float max, min;
            a = float.Parse(textBox1.Text);
            b = float.Parse(textBox2.Text);
            c = float.Parse(textBox3.Text);
            if (a >= b && a >= c)
            {
                max = a;
            }
            else if (b >= a && b >= c)
            {
                max = b;
            }
            else
            {
                max = c;
            }
            if (a <= b && a <= c)
            {
                min = a;
            }
            else if (b <= a && b <= c)
            {
                min = b;
            }
            else
            {
                min = c;
            }
            textBox4.Text = max.ToString();
            textBox5.Text = min.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string t = null;
            textBox1.Text = t;
            textBox2.Text = t;
            textBox3.Text = t;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
