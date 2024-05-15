namespace LAB3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaiTap1 baitap1 = new BaiTap1();
            baitap1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BaiTap2 baiTap2 = new BaiTap2();
            baiTap2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BaiTap5 baiTap5 = new BaiTap5();
            baiTap5.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BaiTap3 baiTap3 = new BaiTap3();
            baiTap3.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BaiTap6 baiTap6 = new BaiTap6();
            baiTap6.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BaiTap4 baiTap4 = new BaiTap4();
            baiTap4.Show();
        }
    }
}
