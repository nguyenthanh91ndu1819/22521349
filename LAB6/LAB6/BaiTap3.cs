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
    public partial class BaiTap3 : Form
    {
        public BaiTap3()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            BaiTap3Client client = new BaiTap3Client();
            client.Show();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            BaiTap3Server server = new BaiTap3Server();
            server.Show();
        }
    }
}
