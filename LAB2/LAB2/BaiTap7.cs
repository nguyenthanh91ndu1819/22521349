using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    public partial class BaiTap7 : Form
    {
        string path = @"D:\";

        public BaiTap7()
        {
            InitializeComponent();
            if (Directory.Exists(path))
            {
                TreeNode root = new TreeNode()
                {
                    Text = path
                };
                treeView1.Nodes.Add(root);
                LoadExplorer(root);
            }
        }

        void LoadExplorer(TreeNode root)
        {
            if (root == null)
                return;
            try
            {
                var folderlist = new DirectoryInfo(root.Text).GetFileSystemInfos();
                if (folderlist.Length == 0)
                    return;
                foreach (var item in folderlist)
                {
                    TreeNode node = new TreeNode()
                    {
                        Text = item.FullName
                    };
                    if (item is DirectoryInfo)
                    {
                        node.ImageIndex = 0; 
                        node.SelectedImageIndex = 0;
                        root.Nodes.Add(node);
                        LoadExplorer(node);
                    }
                    else if (item is FileInfo)
                    {
                        node.ImageIndex = 1;
                        node.SelectedImageIndex = 1;
                        root.Nodes.Add(node);
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.ImageIndex == 1 && e.Button == MouseButtons.Left) 
            {
                string filePath = e.Node.Text;
                try
                {
                    if (IsImageFile(filePath))
                    {
                        // Hiển thị hình ảnh trong PictureBox
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox1.Image = Image.FromFile(filePath);

                        // Xóa nội dung trong RichTextBox
                        richTextBox1.Clear();
                    }
                    else
                    {
                        // Hiển thị nội dung của file văn bản trong RichTextBox
                        richTextBox1.Text = File.ReadAllText(filePath);

                        pictureBox1.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
                }
            }
        }

        private bool IsImageFile(string filePath)
        {
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
            return imageExtensions.Contains(Path.GetExtension(filePath).ToLower());
        }
    }
}
