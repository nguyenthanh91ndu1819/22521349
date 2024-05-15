using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LAB3
{
    public partial class TCPServer : Form
    {
        public TCPServer()
        {
            InitializeComponent();
        }

        private void StartListen_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.Start();
        }

        private void StartUnsafeThread()
        {
            try
            {
                int bytesReceived = 0;
                byte[] recv = new byte[1024];
                Socket clientSocket;
                Socket listenerSocket = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp
                );
                IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
                listenerSocket.Bind(ipepServer);
                listenerSocket.Listen(-1);

                listViewCommand.View = View.Details; 
                listViewCommand.Columns.Add("Message", 300); 

                listViewCommand.Items.Add("Server started, listening on port 8080");

                clientSocket = listenerSocket.Accept();
                listViewCommand.Items.Add("New client connected");

                while (clientSocket.Connected)
                {
                    string text = "";
                    do
                    {
                        bytesReceived = clientSocket.Receive(recv);
                        if (bytesReceived > 0) 
                            text += Encoding.ASCII.GetString(recv, 0, bytesReceived);
                    } while (bytesReceived == recv.Length && recv[bytesReceived - 1] != '\n'); 

                    if (!string.IsNullOrEmpty(text)) 
                    {
                        
                        Invoke((MethodInvoker)delegate {
                            ListViewItem item = new ListViewItem(text);
                            listViewCommand.Items.Add(item);
                        });
                    }
                }

                
                Invoke((MethodInvoker)delegate {
                    ListViewItem item = new ListViewItem("Client disconnected");
                    listViewCommand.Items.Add(item);
                });

                listenerSocket.Close();
            }
            catch (Exception ex)
            {
                
                Invoke((MethodInvoker)delegate {
                    listViewCommand.Items.Add("Error: " + ex.Message);
                });
            }
        }
    }
}
