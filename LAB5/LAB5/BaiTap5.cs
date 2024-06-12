using System;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MailKit.Net.Pop3;
using MimeKit;

namespace LAB5
{
    public partial class BaiTap5 : Form
    {
        private string login = "chessmasterresetpass@gmail.com";
        private string password = "qcii qibh gvvr ojtq";
        private string server = "pop.gmail.com";
        private string databasePath = "data source=NguoiDongGop.db";

        public BaiTap5()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            using (SQLiteConnection conn = new SQLiteConnection(databasePath))
            {
                conn.Open();
                CreateTable(conn);
            }
            LoadTreeViewFromDatabase();
        }

        private void CreateTable(SQLiteConnection conn)
        {
            string sql = "CREATE TABLE IF NOT EXISTS NguoiDongGop(" +
                         "ID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                         "HoVaTen VARCHAR(30), " +
                         "TenMonAn VARCHAR(30), " +
                         "HinhAnh VARCHAR(40))";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private void InsertData(SQLiteConnection conn, string TenMonAn, string HinhAnh, string HoTen)
        {
            string insertDataQuery = "INSERT INTO NguoiDongGop (HoVaTen, TenMonAn, HinhAnh) VALUES (@HoVaTen, @TenMonAn, @HinhAnh)";
            using (SQLiteCommand cmd = new SQLiteCommand(insertDataQuery, conn))
            {
                cmd.Parameters.AddWithValue("@HoVaTen", HoTen);
                cmd.Parameters.AddWithValue("@TenMonAn", TenMonAn);
                cmd.Parameters.AddWithValue("@HinhAnh", HinhAnh);
                cmd.ExecuteNonQuery();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(databasePath))
            {
                conn.Open();

                string query = "SELECT TenMonAn, HinhAnh FROM NguoiDongGop";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("No images found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var imagePaths = new List<string>();
                    var subjects = new List<string>();

                    while (reader.Read())
                    {
                        imagePaths.Add(reader.GetString(1));
                        subjects.Add(reader.GetString(0));
                    }

                    Random random = new Random();
                    int selectedIndex = random.Next(imagePaths.Count);

                    pictureBox1.Image = Image.FromFile(imagePaths[selectedIndex]);
                    textBox1.Text = subjects[selectedIndex];
                }
            }
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            string result = ConnectEmail();
            txtResult.Text = result;
        }

        public string ConnectEmail()
        {
            string res = "";
            try
            {
                using (Pop3Client email = new Pop3Client())
                {
                    email.Connect(server, 995, true);
                    email.Authenticate(login, password);

                    int emailCount = email.Count;

                    string appFolderPath = Application.StartupPath;
                    string attachmentFolderPath = Path.Combine(appFolderPath, "DownloadedEmails");
                    Directory.CreateDirectory(attachmentFolderPath);

                    using (SQLiteConnection conn = new SQLiteConnection(databasePath))
                    {
                        conn.Open();
                        CreateTable(conn);

                        for (int i = 0; i < emailCount; i++)
                        {
                            MimeMessage emailMessage = email.GetMessage(i);

                            if (!emailMessage.Attachments.Any())
                            {
                                continue;
                            }

                            InternetAddressList fromAddresses = emailMessage.From;
                            string senderName = fromAddresses.FirstOrDefault()?.Name ?? "Ẩn danh";
                            string subject = emailMessage.Subject;

                           
                            string checkSubjectQuery = "SELECT COUNT(*) FROM NguoiDongGop WHERE TenMonAn = @Subject";
                            using (SQLiteCommand checkCmd = new SQLiteCommand(checkSubjectQuery, conn))
                            {
                                checkCmd.Parameters.AddWithValue("@Subject", subject);
                                int existingSubjectCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                                if (existingSubjectCount > 0)
                                {
                                   
                                    continue;
                                }
                            }

                            string emailFolderPath = Path.Combine(attachmentFolderPath, $"{subject}");
                            Directory.CreateDirectory(emailFolderPath);

                            foreach (var attachment in emailMessage.Attachments)
                            {
                                var fileName = attachment.ContentDisposition?.FileName ?? "Unknown";
                                string extension = Path.GetExtension(fileName);
                                string filePath = Path.Combine(emailFolderPath, $"{Path.GetFileNameWithoutExtension(fileName)}.jpg");

                                if (extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                    extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                    extension.Equals(".png", StringComparison.OrdinalIgnoreCase))
                                {
                                    using (var stream = File.Create(filePath))
                                    {
                                        var content = (MimePart)attachment;
                                        content.Content.DecodeTo(stream);
                                    }

                                    InsertData(conn, subject, filePath, senderName);
                                }
                            }
                        }
                    }

                    res = "Đã tải xuống và chuyển đổi các tệp đính kèm thành JPG thành công!";
                }
            }
            catch (Exception ex)
            {
                res = $"Đã xảy ra lỗi: {ex.Message}";
            }
            return res;
        }


        private void LoadTreeViewFromDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(databasePath))
            {
                conn.Open();

                string query = "SELECT * FROM NguoiDongGop";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tenMonAn = reader.GetString(2);
                        string hinhAnh = reader.GetString(3);
                        string nguoiDung = reader.GetString(1);

                        TreeNode parentNode = new TreeNode($"{tenMonAn} - Người đóng góp: {nguoiDung}");
                        parentNode.Tag = hinhAnh;

                        treeView1.Nodes.Add(parentNode);

                     

                        TreeNode senderNode = new TreeNode("Người gửi: " + nguoiDung);
                        parentNode.Nodes.Add(senderNode);

                        TreeNode contributorNode = new TreeNode("Người đóng góp: " + nguoiDung);
                        parentNode.Nodes.Add(contributorNode);
                    }
                }
            }
        }
    }
}
