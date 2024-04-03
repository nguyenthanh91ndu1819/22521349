using Lab2;

namespace LAB2
{
    public partial class LAB2_FORM : Form
    {
        public LAB2_FORM()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            BaiTap1 baiTap1 = new BaiTap1();
            baiTap1.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            BaiTap2 baiTap2 = new BaiTap2();
            baiTap2.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            BaiTap3 baiTap3 = new BaiTap3();
            baiTap3.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            BaiTap4 baiTap4 = new BaiTap4();
            baiTap4.Show();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            BaiTap7 baiTap7 = new BaiTap7();
            baiTap7.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            BaiTap6 baiTap6 = new BaiTap6();
            baiTap6.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            BaiTap5 baiTap5 = new BaiTap5();
            baiTap5.Show();
        }
    }
}
