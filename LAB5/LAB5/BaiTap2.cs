using System;
using System.Windows.Forms;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;

namespace LAB5
{
    public partial class BaiTap2 : Form
    {
        public BaiTap2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var client = new ImapClient())
            {
                client.Connect("imap.gmail.com", 993, true);

                client.Authenticate(tbEmail.Text, tbPassWord.Text);

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                var query1 = SearchQuery.DeliveredAfter(DateTime.Now.AddDays(-7));
                var query2 = SearchQuery.DeliveredAfter(DateTime.Now.AddDays(-1));
                var results = inbox.Search(query1);
                var RecentEmail = inbox.Search(query2);
                int totalEmails = results.Count;
                tbTotal.Text = totalEmails.ToString();
                int recentEmails = RecentEmail.Count;
                tbRecent.Text = recentEmails.ToString();

               
                listView1.View = View.Details;

                
                listView1.Columns.Add("Subject", 250); 
                listView1.Columns.Add("From", 250);  
                listView1.Columns.Add("Date", 250);  

                
                foreach (var uniqueId in results)
                {
                    var message = inbox.GetMessage(uniqueId);

                  
                    ListViewItem item = new ListViewItem();

                   
                    item.Text = message.Subject;        
                    item.SubItems.Add(message.From.ToString()); 
                    item.SubItems.Add(message.Date.ToString()); 

                    
                    listView1.Items.Add(item);
                }


                client.Disconnect(true);
            }
        }
    }
}
