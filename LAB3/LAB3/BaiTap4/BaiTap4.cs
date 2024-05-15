using System;
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
    public partial class BaiTap4 : Form
    {
        public BaiTap4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaiTap4Server server = new BaiTap4Server();
            server.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BaiTap4Client client = new BaiTap4Client();
            client.Show();
        }
    }
}
