using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace LAB3
{
    public partial class TCPClient : Form
    {
        public TCPClient()
        {
            InitializeComponent();
        }

       
        private TcpClient tcpClient;
        private NetworkStream ns;

        
        private void ConnectToServer()
        {
            try
            {
                tcpClient = new TcpClient();
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8080);
                tcpClient.Connect(ipEndPoint);
                ns = tcpClient.GetStream();
                MessageBox.Show("Connected to server successfully."); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        
        private void SendData(string message)
        {
            try
            {
                byte[] data = Encoding.ASCII.GetBytes(message + "\n");
                ns.Write(data, 0, data.Length);
                MessageBox.Show("Data sent successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending data: " + ex.Message);
            }
        }

        
        private void txtConnect_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }

       
        private void txtSend_Click(object sender, EventArgs e)
        {
            string message = textBox1.Text; 
            SendData(message);
        }

        
        private void txtDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                ns.Close();
                tcpClient.Close();
                MessageBox.Show("Connection closed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error closing connection: " + ex.Message);
            }
        }
    }
}
