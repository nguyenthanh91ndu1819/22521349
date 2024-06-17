namespace LAB6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaiTap1 baiTap1 = new BaiTap1();
            baiTap1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BaiTap2 baiTap2 = new BaiTap2();
            baiTap2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BaiTap3 baiTap3 = new BaiTap3();
            baiTap3.ShowDialog();
        }
    }
}
