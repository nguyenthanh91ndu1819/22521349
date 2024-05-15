using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperSimpleTcp;
namespace LAB3
{
    public partial class BaiTap6Client : Form
    {
        SimpleTcpClient client;
        public BaiTap6Client()
        {
            InitializeComponent();
        }
        StringBuilder messageHistory = new StringBuilder();

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client.Connect();
                btnSend.Enabled = true;
                btnConnect.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);   
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMessage.Text))
            {
                client.Send(txtMessage.Text);
                txtInfo.Text += $"{txtName.Text}: {txtMessage.Text}{Environment.NewLine}";
                txtMessage.Text = string.Empty; // Xóa tin nhắn sau khi gửi
            }
        }


        private void BaiTap6Client_Load(object sender, EventArgs e)
        {
            client = new(txtIP.Text);
            client.Events.DataReceived += Events_DataReceived;
            client.Events.Connected += Events_Connected;
            client.Events.Disconnected += Events_Disconnected;
            btnSend.Enabled = false;
        }
        private void Events_Disconnected(object sender, ConnectionEventArgs e)
        {
            txtInfo.Text += $"Server disconnected.{Environment.NewLine}";
        }
        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            string message = $"{Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
            this.Invoke((MethodInvoker)delegate {
                // Kiểm tra nếu tin nhắn đến không phải từ chính mình (nếu cần)
                if (!message.StartsWith($"{txtName.Text}:"))
                {
                    txtInfo.Text += message;
                }
            });
        }



        private void Events_Connected(object sender, ConnectionEventArgs e)
        {
            txtInfo.Text += $"Server connected.{Environment.NewLine}";
            client.Send($"Name:{txtName.Text}");
        }

    }
}
