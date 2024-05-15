using System;
using System.Collections.Generic; // For Dictionary
using System.Text;
using System.Windows.Forms;
using SuperSimpleTcp;

namespace LAB3
{
    public partial class BaiTap6Server : Form
    {
        SimpleTcpServer server;
        Dictionary<string, string> clientNames = new Dictionary<string, string>(); // Dictionary to map IpPort to client name

        public BaiTap6Server()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            server.Start();
            txtInfo.Text += $"Starting...{Environment.NewLine}";
            btnStart.Enabled = false;
            btnSend.Enabled = true;
        }

        private void BaiTap6Server_Load(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
            server = new SimpleTcpServer(txtIP.Text);
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;
        }

        private void Events_ClientConnected(object sender, ConnectionEventArgs e)
        {
            txtInfo.Text += $"{e.IpPort} connected. Waiting for name...{Environment.NewLine}";
            lstClient.Items.Add(e.IpPort); // Temporarily add by IpPort
        }

        private void Events_ClientDisconnected(object sender, ConnectionEventArgs e)
        {
            if (clientNames.ContainsKey(e.IpPort))
            {
                txtInfo.Text += $"{clientNames[e.IpPort]} disconnected.{Environment.NewLine}";
                lstClient.Items.Remove(e.IpPort);
                clientNames.Remove(e.IpPort);
            }
            else
            {
                txtInfo.Text += $"{e.IpPort} disconnected.{Environment.NewLine}";
            }
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            string incomingMessage = Encoding.UTF8.GetString(e.Data);
            if (incomingMessage.StartsWith("Name:"))
            {
                string clientName = incomingMessage.Split(':')[1].Trim();
                clientNames[e.IpPort] = clientName;
                txtInfo.Text += $"{clientName} connected with IP: {e.IpPort}.{Environment.NewLine}";
                lstClient.Items[lstClient.Items.IndexOf(e.IpPort)] = clientName; // Update display name in list
            }
            else
            {
                string clientName = clientNames.ContainsKey(e.IpPort) ? clientNames[e.IpPort] : e.IpPort;
                string message = $"{clientName}: {incomingMessage}{Environment.NewLine}";
                txtInfo.Text += message; // Display message in the server

                foreach (var client in server.GetClients())
                {
                    server.Send(client, message); // Forward message to each client
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (server.IsListening)
            {
                string selectedClientIpPort = lstClient.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(txtMessage.Text) && lstClient.SelectedItem != null)
                {
                    server.Send(selectedClientIpPort, txtMessage.Text);
                    string displayName = clientNames.ContainsKey(selectedClientIpPort) ? clientNames[selectedClientIpPort] : selectedClientIpPort;
                    txtInfo.Text += $"Server to {displayName}: {txtMessage.Text}{Environment.NewLine}";
                    txtMessage.Text = string.Empty;
                }
            }
        }
    }
}
