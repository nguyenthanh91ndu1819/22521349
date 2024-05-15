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
    public partial class BaiTap5 : Form
    {
        public BaiTap5()
        {
            InitializeComponent();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            BaiTap5Server baiTap5Server = new BaiTap5Server();
            baiTap5Server.Show();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            BaiTap5Client baiTap5Client = new BaiTap5Client(); 
            baiTap5Client.Show();
        }
    }
}
