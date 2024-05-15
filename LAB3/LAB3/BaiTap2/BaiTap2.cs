using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LAB3
{
    public partial class BaiTap2 : Form
    {
        public BaiTap2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.Start();
        }

        void StartUnsafeThread()
        {
            Socket listenerSocket = null; 

            try
            {
                byte[] buffer = new byte[1024]; 
                Socket clientSocket; 

                
                listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
                listenerSocket.Bind(ipepServer);
                listenerSocket.Listen(10);

                
                clientSocket = listenerSocket.Accept();
                this.Invoke((MethodInvoker)delegate {
                    textBox1.AppendText("New client connected\n");
                   
                });

                
                int bytesReceived;
                StringBuilder receivedText = new StringBuilder();

                while ((bytesReceived = clientSocket.Receive(buffer)) > 0)
                {
                    receivedText.Append(Encoding.ASCII.GetString(buffer, 0, bytesReceived));
                    if (receivedText.ToString().EndsWith("\n"))
                    {
                        string toDisplay = receivedText.ToString().Trim();
                        this.Invoke((MethodInvoker)delegate {
                            textBox1.AppendText(toDisplay + "\n");
                        });
                        receivedText.Clear(); 
                    }
                }
                clientSocket.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                listenerSocket?.Close(); 
            }
        }
    }
}
