    using System;
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
        public partial class BaiTh8 : Form
        {
            public BaiTh8()
            {
                InitializeComponent();
                string[] DefaultItems = new string[] { "Bún riêu", "Bún thịt nướng", "Cơm tấm sườn trứng", "Phở", "Gỏi cuốn" };
                listBox1.Items.AddRange(DefaultItems);
        }

            private void button1_Click(object sender, EventArgs e)
            {
                string t = textBox1.Text.Trim();
                listBox1.Items.Add(t);
            }

            private void button2_Click(object sender, EventArgs e)
            {
                Random random = new Random();
                int index = random.Next(listBox1.Items.Count);
                string selectedFood = listBox1.Items[index].ToString();
                textBox3.Text = selectedFood;
            }
            private void button3_Click(object sender, EventArgs e)
            {
                if (listBox1.SelectedIndex != -1)
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
                else
                {
                    MessageBox.Show("Please select an item to delete.");
                }
            }
            private void button4_Click(object sender, EventArgs e)
            {
                this.Close();
            }



    }
}
