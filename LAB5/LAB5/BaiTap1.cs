using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace LAB5
{
    public partial class BaiTap1 : Form
    {
        public BaiTap1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587; 
            client.EnableSsl = true;

            
            client.Credentials = new System.Net.NetworkCredential("chessmasterresetpass@gmail.com", "qcii qibh gvvr ojtq");

            var message = new MailMessage();
            message.From = new MailAddress(tbFrom.Text);
            message.To.Add(tbTo.Text);
            message.Subject = tbSubject.Text;
            message.Body = tbBody.Text;

            try
            {
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
