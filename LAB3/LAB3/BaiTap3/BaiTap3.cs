﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3
{
    public partial class BaiTap3 : Form
    {
        public BaiTap3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TCPServer tCPServer = new TCPServer();
            tCPServer.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TCPClient tCPClient = new TCPClient();
            tCPClient.Show();
        }
    }

}
