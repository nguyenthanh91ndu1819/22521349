using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LAB3
{
    public partial class UDPServerForm : Form
    {
        private UdpClient udpClient;
        public UDPServerForm()
        {
            InitializeComponent();
            listViewMessages.View = View.Details;
            listViewMessages.Columns.Add("Client IP", 120); // Adjust width as needed
            listViewMessages.Columns.Add("Message", 250); // Adjust width as needed
        }

        public void ServerThread()
        {
            udpClient = new UdpClient(8080);
            while (true)
            {
                IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] receiveBytes = udpClient.Receive(ref remoteIpEndPoint);
                string returnData = Encoding.UTF8.GetString(receiveBytes);
                string message = remoteIpEndPoint.Address.ToString() + ": " + returnData;
                Invoke(new MethodInvoker(delegate {
                    InfoMessage(remoteIpEndPoint.Address.ToString(), returnData);
                }));
            }
        }

        private void InfoMessage(string clientIP, string message)
        {
            // Ensure thread-safe call to Windows Forms controls
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate { InfoMessage(clientIP, message); }));
                return;
            }

            ListViewItem item = new ListViewItem(clientIP);
            item.SubItems.Add(message);
            listViewMessages.Items.Add(item);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread thdUDPServer = new Thread(new ThreadStart(ServerThread));
            thdUDPServer.Start();
            MessageBox.Show("Server started!", "Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
