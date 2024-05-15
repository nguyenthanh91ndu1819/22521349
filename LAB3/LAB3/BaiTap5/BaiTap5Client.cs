using System;
using System.Data.SQLite;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using System.Text;

namespace LAB3
{
    public partial class BaiTap5Client : Form
    {
        public BaiTap5Client()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            var createDBSQL = "Data Source = BaiTap5Client.db";
            SQLiteConnection.CreateFile(createDBSQL);

            using (SQLiteConnection conn = new SQLiteConnection(createDBSQL))
            {
                try
                {
                    conn.Open();
                    CreateTable(conn);
                    InsertData(conn, "1", "Com", "Hinh 1");
                    InsertData(conn, "2", "Pho", "Hinh 2");
                    InsertData(conn, "3", "Bun", "Hinh 3");
                    InsertData(conn, "4", "Banh canh", "Hinh 4");
                    SelectData(conn, treeView1); // Move this line to ensure data is selected after insertion
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
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

        public void InsertData(SQLiteConnection conn, string IDMA, string TenMonAn, string HinhAnh)
        {
            var sql1 = "INSERT INTO MonAn(TenMonAn, HinhAnh) " +
                "VALUES(@TenMonAn, @HinhAnh)";
            var cmd1 = new SQLiteCommand(sql1, conn);
            cmd1.Parameters.AddWithValue("@TenMonAn", TenMonAn);
            cmd1.Parameters.AddWithValue("@HinhAnh", HinhAnh);
            cmd1.ExecuteNonQuery();
        }

        private void SelectData(SQLiteConnection conn, TreeView treeView1)
        {
            string query = "SELECT MonAn.TenMonAn, MonAn.HinhAnh FROM MonAn";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string TenMonAn = reader.GetString(0);
                        string HinhAnh = reader.GetString(1);

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
                    }
                }
            }
        }

        private void txtConnect_Click(object sender, EventArgs e)
        {
            TcpClient tcpClient = new TcpClient();

            try
            {
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8080);

               
                int attempts = 0;
                while (!tcpClient.Connected && attempts < 5)
                {
                    try
                    {
                        tcpClient.Connect(ipEndPoint);
                    }
                    catch (SocketException)
                    {
                        attempts++;
                        Thread.Sleep(1000); 
                    }
                }

                if (tcpClient.Connected)
                {
                    NetworkStream ns = tcpClient.GetStream();
                    byte[] data = Encoding.ASCII.GetBytes("Hello server\n");
                    ns.Write(data, 0, data.Length);

                    byte[] buffer = new byte[1024];
                    int bytesRead = ns.Read(buffer, 0, buffer.Length);
                    string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                    MessageBox.Show(response, "Server Response", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ns.Close();
                    tcpClient.Close();
                }
                else
                {
                    MessageBox.Show("Failed to connect to server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int index = random.Next(treeView1.Nodes.Count);
            TreeNode selectedNode = treeView1.Nodes[index];
            string selectedFood = selectedNode.Text;



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

        private string imagePath = System.IO.Path.Combine(Application.StartupPath, "Images");

        private void tbSelectFromServer_Click(object sender, EventArgs e)
        {
            // Kết nối tới cơ sở dữ liệu SQLite trên server
            string connectionString = "Data Source=BaiTap5Server.db";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Thực hiện truy vấn để lấy danh sách các mục dữ liệu từ cơ sở dữ liệu
                    string query = "SELECT TenMonAn, HinhAnh FROM MonAn";
                    List<string[]> data = new List<string[]>();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tenMonAn = reader.GetString(0);
                            string hinhAnh = reader.GetString(1);
                            data.Add(new string[] { tenMonAn, hinhAnh });
                        }
                    }

                    // Ngẫu nhiên chọn ra một mục từ danh sách
                    Random random = new Random();
                    int index = random.Next(data.Count);
                    string[] selectedData = data[index];
                    string selectedFood = selectedData[0];
                    string selectedImage = selectedData[1];

                    // Hiển thị dữ liệu của mục được chọn lên giao diện của server
                    MessageBox.Show($"Món ăn được chọn: {selectedFood}", "Dữ liệu từ server", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Hiển thị hình ảnh của món ăn trong PictureBox1
                    pictureBox1.ImageLocation = System.IO.Path.Combine(imagePath, selectedImage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Phương thức để đóng góp món ăn vào cơ sở dữ liệu của máy chủ
        private void txtContribute_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            // Kiểm tra xem người dùng đã chọn hình ảnh hay chưa
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Lấy tên người đóng góp và tên món ăn từ các TextBox
                string contributorName = txtName.Text;
                string foodName = txtMonAn.Text;

                // Thêm hình ảnh vào thư mục của ứng dụng và lấy tên file
                string selectedImagePath = openFileDialog1.FileName;
                string fileName = Path.GetFileName(selectedImagePath);
                string destinationPath = Path.Combine(imagePath, fileName);
                File.Copy(selectedImagePath, destinationPath);

                // Thêm thông tin vào cơ sở dữ liệu
                AddContributionToDatabase(contributorName, foodName, fileName);
            }
        }

        // Phương thức để thêm đóng góp hình ảnh vào cơ sở dữ liệu
        private void AddContributionToDatabase(string contributorName, string foodName, string imageName)
        {
            // Kết nối tới cơ sở dữ liệu SQLite trên server
            string connectionString = "Data Source=BaiTap5Server.db";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Thêm dữ liệu vào bảng NguoiDung
                    string insertContributorQuery = "INSERT INTO NguoiDung(HoVaTen, QuyenHan) VALUES(@HoTen, @QuyenHan)";
                    using (SQLiteCommand cmd = new SQLiteCommand(insertContributorQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@HoTen", contributorName);
                        cmd.Parameters.AddWithValue("@QuyenHan", "Đóng góp");
                        cmd.ExecuteNonQuery();
                    }

                    // Lấy ID của người dùng vừa được thêm vào
                    string selectContributorIdQuery = "SELECT last_insert_rowid()";
                    int contributorId;
                    using (SQLiteCommand cmd = new SQLiteCommand(selectContributorIdQuery, conn))
                    {
                        contributorId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Thêm dữ liệu vào bảng MonAn
                    string insertFoodQuery = "INSERT INTO MonAn(TenMonAn, HinhAnh, IDNCC) VALUES(@TenMonAn, @HinhAnh, @IDNCC)";
                    using (SQLiteCommand cmd = new SQLiteCommand(insertFoodQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenMonAn", foodName);
                        cmd.Parameters.AddWithValue("@HinhAnh", imageName);
                        cmd.Parameters.AddWithValue("@IDNCC", contributorId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Đã đóng góp món ăn và hình ảnh thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
