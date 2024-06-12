using System;
using System.Text;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using MimeKit;

namespace LAB5
{
    public partial class BT6TTMail : Form
    {
        public BT6TTMail(string subject, string from, string date, string body, IEnumerable<MimeEntity> attachments, string email)
        {
            InitializeComponent();

            StringBuilder htmlBuilder = new StringBuilder();
            tbFrom.Text = from;
            tbTo.Text = email;
            htmlBuilder.Append($"<div>{body}</div>");

           
            List<MimePart> attachmentParts = new List<MimePart>();
            foreach (var attachment in attachments)
            {
                if (attachment is MimePart part)
                {
                    attachmentParts.Add(part);
                }
            }

           
            if (attachmentParts.Any())
            {
                htmlBuilder.Append("<h3>Attachments:</h3><ul>");
                foreach (var attachment in attachmentParts)
                {
                    
                    htmlBuilder.Append($"<li>{attachment.FileName}</li>");
                }
                htmlBuilder.Append("</ul>");
            }

            htmlBuilder.Append("</body></html>");

            string html = htmlBuilder.ToString();

            
            byte[] bytes = Encoding.UTF8.GetBytes(html);
            string base64EncodedBody = Convert.ToBase64String(bytes);

            
            string dataUri = $"data:text/html;base64,{base64EncodedBody}";

            
            webView21.Source = new Uri(dataUri);
        }
    }
}
