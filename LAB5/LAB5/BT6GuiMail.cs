using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace LAB5
{
    public partial class BT6GuiMail : Form
    {
        private string username;
        private string password;
        private string filePath = "";
        public BT6GuiMail(string userLogin, string passwordLogin)
        {
            InitializeComponent();
            username = userLogin;
            password = passwordLogin; 
            tbFrom.Text = username;
        }

        private void tbBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName; 
                tbBrowse.Text = filePath; 
            }
        }

        private void tbSend_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new System.Net.NetworkCredential(username, password),
                    EnableSsl = true
                };

                var message = new MailMessage
                {
                    From = new MailAddress(username, tbName.Text),
                    Subject = tbSubject.Text,
                    Body = tbBody.Text
                };
                message.To.Add(tbTo.Text);

               
                if (checkBox1.Checked)
                {
                    message.IsBodyHtml = true;
                    
                }
                if (!string.IsNullOrEmpty(filePath))
                {
                    Attachment attachment = new Attachment(filePath);
                    message.Attachments.Add(attachment);
                }

                client.Send(message);
                MessageBox.Show("Email sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email: {ex.Message}");
            }
        }

    }
}
