using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace LAB2
{
    public partial class BaiTap6 : Form
    {
        public BaiTap6()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            var createDBSQL = "Data Source = BaiTap7.db";
            SQLiteConnection.CreateFile(createDBSQL);

            using (SQLiteConnection conn = new SQLiteConnection(createDBSQL))
                try
                {
                    conn.Open();
                    CreateTable(conn);
                    InsertData(conn, "1", "Com", "Hinh 1", "1", "Nguyen Thanh", "Khong co quyen han");
                    InsertData(conn, "2", "Pho", "Hinh 2", "2", "Nguyen Cong Vinh", "Khong co quyen han");
                    InsertData(conn, "3", "Bun", "Hinh 3", "3", "Nguyen Duc Tan", "Khong co quyen han");
                    InsertData(conn, "4", "Banh canh", "Hinh 4", "4", "Nguyen Trung Hieu", "Khong co quyen han");
                    SelectData(conn, treeView1); // Move this line to ensure data is selected after insertion
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }

        public void CreateTable(SQLiteConnection conn)
        {
            string sql1 = "CREATE TABLE IF NOT EXISTS NguoiDung(" +
                          "IDNCC INTEGER PRIMARY KEY AUTOINCREMENT, " +
                          "HoVaTen VARCHAR(30), " +
                          "QuyenHan VARCHAR(30))";

            string sql2 = "CREATE TABLE IF NOT EXISTS MonAn(" +
                          "IDMA INTEGER PRIMARY KEY AUTOINCREMENT, " +
                          "TenMonAn VARCHAR(30)," +
                          "HinhAnh VARCHAR(40)," +
                          "IDNCC INTEGER, " +
                          "FOREIGN KEY(IDNCC) REFERENCES NguoiDung(IDNCC))";

            var cmd1 = new SQLiteCommand(sql1, conn);
            var cmd2 = new SQLiteCommand(sql2, conn);
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
        }

        public void InsertData(SQLiteConnection conn, string IDMA, string TenMonAn, String HinhAnh, String IDNCC, String HoTen, String QuyenHan)
        {
            var sql1 = "INSERT INTO MonAn(TenMonAn, HinhAnh, IDNCC) " +
                "VALUES(@TenMonAn, @HinhAnh, @IDNCC)";
            var cmd1 = new SQLiteCommand(sql1, conn);
            cmd1.Parameters.AddWithValue("@TenMonAn", TenMonAn);
            cmd1.Parameters.AddWithValue("@HinhAnh", HinhAnh);
            cmd1.Parameters.AddWithValue("@IDNCC", IDNCC);
            cmd1.ExecuteNonQuery();

            var sql2 = "INSERT INTO NguoiDung(HoVaTen, QuyenHan) " +
                "VALUES(@HoTen, @QuyenHan)";
            var cmd2 = new SQLiteCommand(sql2, conn);
            cmd2.Parameters.AddWithValue("@HoTen", HoTen);
            cmd2.Parameters.AddWithValue("@QuyenHan", QuyenHan);
            cmd2.ExecuteNonQuery();
        }

        private void SelectData(SQLiteConnection conn, TreeView treeView1)
        {
            string query = "SELECT MonAn.TenMonAn, MonAn.HinhAnh, NguoiDung.HoVaTen, NguoiDung.QuyenHan FROM MonAn INNER JOIN NguoiDung ON MonAn.IDNCC = NguoiDung.IDNCC";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string TenMonAn = reader.GetString(0);
                        string HinhAnh = reader.GetString(1);
                        string HoVaTen = reader.GetString(2);
                        string QuyenHan = reader.GetString(3);

                        TreeNode parentNode = null;
                        foreach (TreeNode node in treeView1.Nodes)
                        {
                            if (node.Text == TenMonAn)
                            {
                                parentNode = node;
                                break;
                            }
                        }

                        if (parentNode == null)
                        {
                            parentNode = new TreeNode(TenMonAn);
                            parentNode.Tag = HinhAnh;
                            treeView1.Nodes.Add(parentNode);
                        }

                        bool contributorExists = false;
                        foreach (TreeNode childNode in parentNode.Nodes)
                        {
                            if (childNode.Text == "Người đóng góp: " + HoVaTen)
                            {
                                contributorExists = true;
                                break;
                            }
                        }

                        if (!contributorExists)
                        {
                            TreeNode childNode1 = new TreeNode("Người đóng góp: " + HoVaTen);
                            parentNode.Nodes.Add(childNode1);
                        }

                        bool roleExists = false;
                        foreach (TreeNode childNode in parentNode.Nodes)
                        {
                            if (childNode.Text == "Quyền hạn: " + QuyenHan)
                            {
                                roleExists = true;
                                break;
                            }
                        }

                        if (!roleExists)
                        {
                            TreeNode childNode2 = new TreeNode("Quyền hạn: " + QuyenHan);
                            parentNode.Nodes.Add(childNode2);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int index = random.Next(treeView1.Nodes.Count);
            TreeNode selectedNode = treeView1.Nodes[index];
            string selectedFood = selectedNode.Text;

            textBox1.Text = selectedFood;

            // Tạo đường dẫn đầy đủ đến thư mục chứa hình ảnh trong thư mục của dự án
            string imagePath = System.IO.Path.Combine(Application.StartupPath, "Images");


            // Kiểm tra và hiển thị hình ảnh dựa trên tên món ăn
            switch (selectedFood)
            {
                case "Com":
                    pictureBox1.Image = Image.FromFile(System.IO.Path.Combine(imagePath, "1.jpg"));
                    break;
                case "Pho":
                    pictureBox1.Image = Image.FromFile(System.IO.Path.Combine(imagePath, "2.jpg"));
                    break;
                case "Bun":
                    pictureBox1.Image = Image.FromFile(System.IO.Path.Combine(imagePath, "3.jpg"));
                    break;
                case "Banh canh":
                    pictureBox1.Image = Image.FromFile(System.IO.Path.Combine(imagePath, "4.jpg"));
                    break;
                default:
                    pictureBox1.Image = null; // Nếu không tìm thấy hình ảnh, hiển thị null
                    break;
            }
        }       
    }
}
