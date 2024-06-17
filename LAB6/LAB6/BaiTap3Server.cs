using Microsoft.VisualBasic;
using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace LAB6
{
    public partial class BaiTap3Server : Form
    {
        public BaiTap3Server()
        {
            InitializeComponent();
        }

        SimpleTcpServer server;
        Dictionary<string, string> clientNames = new Dictionary<string, string>();
        string fileStorageDirectory = "D:\\StoredFiles";

        private void btnStart_Click(object sender, EventArgs e)
        {
            server.Start();
            txtInfo.Text += $"Server started...{Environment.NewLine}";
            btnStart.Enabled = false;
        }

        private void BaiTap3Server_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer(txtIP.Text);
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;

            if (!Directory.Exists(fileStorageDirectory))
                Directory.CreateDirectory(fileStorageDirectory);
        }

        private void Events_ClientConnected(object sender, ConnectionEventArgs e)
        {
            txtInfo.Text += $"{e.IpPort} connected. Waiting for name...{Environment.NewLine}";
            lstClient.Items.Add(e.IpPort); 
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

            if (incomingMessage.StartsWith("EncryptedFile:"))
            {
                string encryptedFileData = incomingMessage.Split(':')[1].Trim();
                string[] parts = encryptedFileData.Split('\\');
                string subfolderName = parts[0].Trim();
                string encryptedFileName = parts[1].Trim();
                byte[] encryptedFileBytes = Convert.FromBase64String(encryptedFileName);

               
                string aesKeyBase64 = clientNames[e.IpPort];
                byte[] aesKey = Convert.FromBase64String(aesKeyBase64);

                string encryptedFolderPath = Path.Combine(fileStorageDirectory, subfolderName);
                Directory.CreateDirectory(encryptedFolderPath);
                string encryptedFilePath = Path.Combine(encryptedFolderPath, "encryptedFile.dat");

                File.WriteAllBytes(encryptedFilePath, encryptedFileBytes);

            }
            else if (incomingMessage.StartsWith("DownloadDecryptedFile:"))
            {
                string[] parts = incomingMessage.Split(':');
                string requestedFileName = parts[1].Trim();
                string aesKeyBase64 = parts[2].Trim();

               
                byte[] aesKey = Convert.FromBase64String(aesKeyBase64);

                string filePath = FindEncryptedFile(fileStorageDirectory, requestedFileName);
                if (!string.IsNullOrEmpty(filePath))
                {
                   
                    byte[] encryptedFileData = File.ReadAllBytes(filePath);

                  
                    byte[] decryptedFileData = DecryptData(encryptedFileData, aesKey);

                    
                    File.WriteAllBytes(Path.Combine(fileStorageDirectory, requestedFileName), decryptedFileData);

                    MessageBox.Show($"Decrypted file downloaded successfully: {requestedFileName}", "Download Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Decrypted file not found on server.", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (incomingMessage.StartsWith("Name:"))
            {
                string clientName = incomingMessage.Split(':')[1].Trim();
                clientNames[e.IpPort] = clientName;
                txtInfo.Text += $"{clientName} connected with IP: {e.IpPort}.{Environment.NewLine}";
                lstClient.Items[lstClient.Items.IndexOf(e.IpPort)] = clientName;
            }
            else
            {
                string clientName = clientNames.ContainsKey(e.IpPort) ? clientNames[e.IpPort] : e.IpPort;
                string message = $"{clientName}: {incomingMessage}{Environment.NewLine}";
                txtInfo.Text += message; 

                foreach (var client in server.GetClients())
                {
                    server.Send(client, message); 
                }
            }
        }
        private byte[] DecryptData(byte[] encryptedData, byte[] aesKey)
        {
            using (AesCryptoServiceProvider decryptor = new AesCryptoServiceProvider())
            {
                decryptor.Mode = CipherMode.CFB;
                decryptor.Key = aesKey;
                decryptor.IV = new byte[decryptor.BlockSize / 8];

                using (MemoryStream inputStream = new MemoryStream(encryptedData))
                using (MemoryStream outputStream = new MemoryStream())
                using (CryptoStream cryptoStream = new CryptoStream(inputStream, decryptor.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    cryptoStream.CopyTo(outputStream);
                    return outputStream.ToArray();
                }
            }
        }

        private string FindEncryptedFile(string directory, string fileName)
        {
            var files = Directory.GetFiles(directory, "*.dat", SearchOption.TopDirectoryOnly)
                                 .Where(file => Path.GetFileName(file) == fileName);

            return files.FirstOrDefault();
        }

    }
}
