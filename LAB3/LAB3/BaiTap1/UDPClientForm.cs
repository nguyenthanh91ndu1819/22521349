using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace LAB3
{
    public partial class UDPClientForm : Form
    {
        public UDPClientForm()
        {
            InitializeComponent();
        }

        UdpClient client;
        IPEndPoint ip_end_point;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int port = int.Parse(textBox2.Text);
                client = new UdpClient();
                ip_end_point = new IPEndPoint(IPAddress.Parse(textBox1.Text), port);
                client.Connect(ip_end_point);
                client.BeginReceive(new AsyncCallback(onReceive), client);
                MessageBox.Show("Client connected!", "Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void onReceive(IAsyncResult AR)
        {
            IPEndPoint remoteEP = null;
            byte[] buff = client.EndReceive(AR, ref remoteEP);
            client.BeginReceive(new AsyncCallback(onReceive), client);
            ControlInvoke(textBox3, () => textBox3.AppendText("Server: " + Encoding.UTF8.GetString(buff) + Environment.NewLine));
        }

        delegate void UniversalVoidDelegate();

        public static void ControlInvoke(Control control, Action function)
        {
            if (control.IsDisposed || control.Disposing)
                return;
            if (control.InvokeRequired)
            {
                control.Invoke(new UniversalVoidDelegate(() => ControlInvoke(control, function)));
                return;
            }
            function();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string message = textBox3.Text;
                byte[] data = Encoding.UTF8.GetBytes(message);
                client.Send(data, data.Length);
                textBox3.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send failed! Please send again! " + ex.Message, "Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
