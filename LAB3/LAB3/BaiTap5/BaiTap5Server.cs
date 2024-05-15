using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Drawing; // Thêm namespace này để sử dụng lớp Image

namespace LAB3
{
    public partial class BaiTap5Server : Form
    {
        // Đường dẫn đến thư mục chứa hình ảnh
        string imagePath = Path.Combine(Application.StartupPath, "Images");

        public BaiTap5Server()
        {
            InitializeComponent();
            treeView1.NodeMouseDoubleClick += treeView1_NodeMouseDoubleClick;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            var createDBSQL = "Data Source = BaiTap5Server.db";
            SQLiteConnection.CreateFile("BaiTap5Server.db");
            using (SQLiteConnection conn = new SQLiteConnection(createDBSQL))
            {
                try
                {
                    conn.Open();
                    CreateTable(conn);
                    InsertData(conn, "Com", "1.jpg", 1, "Nguyen Thanh", "Khong co quyen han");
                    InsertData(conn, "Pho", "2.jpg", 2, "Nguyen Cong Vinh", "Khong co quyen han");
                    InsertData(conn, "Bun", "3.jpg", 3, "Nguyen Duc Tan", "Khong co quyen han");
                    InsertData(conn, "Banh canh", "4.jpg", 4, "Nguyen Trung Hieu", "Khong co quyen han");
                    InsertData(conn, "Banh mi", "5.jpg", 5, "Nguyen Thanh", "Khong co quyen han");
                    SelectData(conn, treeView1);
                    
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

            using (SQLiteCommand cmd1 = new SQLiteCommand(sql1, conn))
            using (SQLiteCommand cmd2 = new SQLiteCommand(sql2, conn))
            {
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
            }
        }

        // Phương thức chèn dữ liệu mẫu vào cơ sở dữ liệu SQLite
        public void InsertData(SQLiteConnection conn, string TenMonAn, string HinhAnh, int IDNCC, string HoTen, string QuyenHan)
        {
            string sql1 = "INSERT INTO MonAn(TenMonAn, HinhAnh, IDNCC) " +
                          "VALUES(@TenMonAn, @HinhAnh, @IDNCC)";
            string sql2 = "INSERT INTO NguoiDung(HoVaTen, QuyenHan) " +
                          "VALUES(@HoTen, @QuyenHan)";

            using (SQLiteCommand cmd1 = new SQLiteCommand(sql1, conn))
            using (SQLiteCommand cmd2 = new SQLiteCommand(sql2, conn))
            {
                cmd1.Parameters.AddWithValue("@TenMonAn", TenMonAn);
                cmd1.Parameters.AddWithValue("@HinhAnh", HinhAnh);
                cmd1.Parameters.AddWithValue("@IDNCC", IDNCC);
                cmd1.ExecuteNonQuery();

                cmd2.Parameters.AddWithValue("@HoTen", HoTen);
                cmd2.Parameters.AddWithValue("@QuyenHan", QuyenHan);
                cmd2.ExecuteNonQuery();
            }
        }
        private void SelectData(SQLiteConnection conn, TreeView treeView1)
        {
            string query = "SELECT MonAn.TenMonAn, MonAn.HinhAnh, NguoiDung.HoVaTen, NguoiDung.QuyenHan FROM MonAn INNER JOIN NguoiDung ON MonAn.IDNCC = NguoiDung.IDNCC";

            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
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
                        parentNode.Tag = Path.Combine(imagePath, HinhAnh); 
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

        // Sự kiện double-click trên TreeView để hiển thị hình ảnh của món ăn
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectedNode = e.Node;

            // Kiểm tra xem nút được double-click có phải là nút món ăn không
            if (selectedNode.Parent != null && selectedNode.Parent.Parent == null) // Nếu nút cha của nút được chọn không phải là một nút món ăn
            {
                // Hiển thị hình ảnh của món ăn
                string hinhAnh = selectedNode.Tag as string;
                if (!string.IsNullOrEmpty(hinhAnh))
                {
                    // Hiển thị hình ảnh của món ăn trong PictureBox
                    pictureBox1.ImageLocation = hinhAnh;
                }
                else
                {
                    MessageBox.Show("Không có hình ảnh cho món ăn này.");
                }
            }
        }

        // Sự kiện click cho nút "Listen" để bắt đầu lắng nghe kết nối từ client
        private void btnListen_Click(object sender, EventArgs e)
        {
            Thread serverThread = new Thread(new ThreadStart(StartListening));
            serverThread.Start();
        }

        // Phương thức để bắt đầu lắng nghe kết nối từ client
        void StartListening()
        {
            try
            {
                // Tạo một socket TCP/IP
                Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Gắn socket với địa chỉ cục bộ và lắng nghe kết nối đến
                IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
                listenerSocket.Bind(localEndPoint);
                listenerSocket.Listen(10);

                // Bắt đầu chấp nhận các kết nối đến
                while (true)
                {
                    Console.WriteLine("Đang chờ kết nối...");
                    Socket clientSocket = listenerSocket.Accept();
                    Console.WriteLine("Đã kết nối với client");

                    // Xử lý giao tiếp với client trong một luồng riêng biệt
                    Thread clientThread = new Thread(() => HandleClient(clientSocket));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        // Phương thức để xử lý giao tiếp với client
        void HandleClient(Socket clientSocket)
        {
            try
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = clientSocket.Receive(buffer)) > 0)
                {
                    // Xử lý dữ liệu nhận được
                    string receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Đã nhận: " + receivedData);

                    // Trả lại dữ liệu cho client
                    clientSocket.Send(buffer, 0, bytesRead, SocketFlags.None);
                }

                // Đóng socket của client
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        
    }
}
