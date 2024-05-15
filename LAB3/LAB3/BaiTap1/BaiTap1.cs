using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3
{
    public partial class BaiTap1 : Form
    {
        public BaiTap1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UDPServerForm uDPServerForm = new UDPServerForm();
            uDPServerForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UDPClientForm uDPClientForm = new UDPClientForm();
            uDPClientForm.Show();
        }
    }
}
