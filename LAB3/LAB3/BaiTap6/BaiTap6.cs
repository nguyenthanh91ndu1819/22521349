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
    public partial class BaiTap6 : Form
    {
        public BaiTap6()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BaiTap6Client client = new BaiTap6Client();
            client.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaiTap6Server server = new BaiTap6Server();
            server.Show();
        }
    }
}
