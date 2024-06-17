using Microsoft.VisualBasic;
using SuperSimpleTcp;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace LAB6
{
    public partial class BaiTap3Client : Form
    {
        SimpleTcpClient client;
        AesCryptoServiceProvider aes;
        private string fileStorageDirectory = "D:\\StoredFiles";

        public BaiTap3Client()
        {
            InitializeComponent();
            aes = new AesCryptoServiceProvider();
            aes.Mode = CipherMode.CFB;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client.Connect();
                btnSend.Enabled = true;
                btnConnect.Enabled = false;
                btnSendFile.Enabled = true;
                btnDownloadFile.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMessage.Text))
            {
                client.Send(txtMessage.Text);
                txtInfo.Text += $"{txtName.Text}: {txtMessage.Text}{Environment.NewLine}";
                txtMessage.Text = string.Empty;
            }
        }

        private void BaiTap6Client_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient(txtIP.Text);
            client.Events.DataReceived += Events_DataReceived;
            client.Events.Connected += Events_Connected;
            client.Events.Disconnected += Events_Disconnected;
            btnSend.Enabled = false;
            btnSendFile.Enabled = false;
            btnDownloadFile.Enabled = false;
        }

        private void Events_Disconnected(object sender, ConnectionEventArgs e)
        {
            txtInfo.Text += $"Server disconnected.{Environment.NewLine}";
            btnConnect.Enabled = true;
            btnSend.Enabled = false;
            btnSendFile.Enabled = false;
            btnDownloadFile.Enabled = false;
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
           
            string message = Encoding.UTF8.GetString(e.Data);

            
            this.Invoke((MethodInvoker)delegate
            {
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

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "All Files (*.*)|*.*"; 

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(filePath);

                    
                    string folderPath = Path.Combine(fileStorageDirectory, Path.GetFileNameWithoutExtension(fileName));
                    Directory.CreateDirectory(folderPath);  

                    string encryptedFilePath = EncryptFile(filePath); 

                    
                    client.Send($"EncryptedFile:{Path.GetFileName(folderPath)}\\{Path.GetFileName(encryptedFilePath)}");

                   
                    byte[] fileData = File.ReadAllBytes(encryptedFilePath);
                    client.Send(fileData);

                    MessageBox.Show($"File uploaded successfully.", "Upload Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending file: {ex.Message}", "File Sending Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string EncryptFile(string inputFile)
        {
            try
            {
                string fileName = Path.GetFileName(inputFile);
                string folderPath = Path.Combine(fileStorageDirectory, Path.GetFileNameWithoutExtension(fileName));
                Directory.CreateDirectory(folderPath);  

                string encryptedFilePath = Path.Combine(folderPath, "encryptedFile.dat");

               
                aes.GenerateKey();
                aes.GenerateIV();

                
                string aesKeyBase64 = Convert.ToBase64String(aes.Key);
                string aesIVBase64 = Convert.ToBase64String(aes.IV);

               
                using (StreamWriter sw = new StreamWriter(Path.Combine(folderPath, "aesKey.txt")))
                {
                    sw.WriteLine(aesKeyBase64);
                    sw.WriteLine(aesIVBase64);
                }
 
                // Encrypt the file
                using (FileStream inputStream = new FileStream(inputFile, FileMode.Open))
                using (FileStream outputStream = new FileStream(encryptedFilePath, FileMode.Create))
                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                using (CryptoStream cryptoStream = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
                {
                    inputStream.CopyTo(cryptoStream);
                }

                return encryptedFilePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error encrypting file: {ex.Message}", "Encryption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private void btnDownloadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string aesKeyString = Interaction.InputBox("Enter Encryption Key:", "Download Decrypted File", "");
                if (string.IsNullOrEmpty(aesKeyString))
                {
                    MessageBox.Show("Encryption key cannot be empty.", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                byte[] aesKey = Convert.FromBase64String(aesKeyString);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "All Files (*.*)|*.*"; 

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string saveFilePath = saveFileDialog.FileName;

                    string filePath = FindEncryptedFile(fileStorageDirectory, aesKeyString);
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        byte[] encryptedFileData = File.ReadAllBytes(filePath);

                        byte[] decryptedFileData = DecryptData(encryptedFileData, aesKey);

                       
                        File.WriteAllBytes(saveFilePath, decryptedFileData);

                        MessageBox.Show($"Decrypted file downloaded successfully: {saveFilePath}", "Download Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Encrypted file not found or decryption key incorrect.", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading file: {ex.Message}", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FindEncryptedFile(string directoryPath, string keyFileName)
        {
            try
            {
                string[] directories = Directory.GetDirectories(directoryPath);
                foreach (string dir in directories)
                {
                    string keyFilePath = Path.Combine(dir, "aesKey.txt");
                    if (File.Exists(keyFilePath))
                    {
                        string[] lines = File.ReadAllLines(keyFilePath);
                        if (lines.Length >= 2)
                        {
                            string aesKeyBase64 = lines[0];
                            string aesIVBase64 = lines[1];
                            if (aesKeyBase64 == keyFileName)
                            {
                                string encryptedFilePath = Path.Combine(dir, "encryptedFile.dat");
                                if (File.Exists(encryptedFilePath))
                                {
                                    return encryptedFilePath;
                                }
                            }
                        }
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error finding encrypted file: {ex.Message}", "File Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private byte[] DecryptData(byte[] dataToDecrypt, byte[] aesKey)
        {
            try
            {
                aes.Key = aesKey;

                
                using (MemoryStream ms = new MemoryStream(dataToDecrypt))
                using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                using (CryptoStream cryptoStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (MemoryStream outputStream = new MemoryStream())
                {
                    cryptoStream.CopyTo(outputStream);
                    return outputStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error decrypting data: {ex.Message}", "Decryption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
