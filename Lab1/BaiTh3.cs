﻿using System;
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
    public partial class BaiTh3 : Form
    {
        public BaiTh3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int a;
            string[] b = { "Không", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };
            a = Int32.Parse(textBox1.Text);
            for(int i = 0; i < b.Length; i++)
            {
                if(a == i)
                {
                    textBox2.Text = b[i];
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string t = null ;
            textBox1.Text = t;
            textBox2.Text = t;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}