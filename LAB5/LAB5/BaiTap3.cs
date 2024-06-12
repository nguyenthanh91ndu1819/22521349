using System;
using System.Windows.Forms;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Net.Smtp;
using MailKit.Net.Pop3;
using MimeKit;

namespace LAB5
{
    public partial class BaiTap3 : Form
    {
        public BaiTap3()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 0) 
                {
                    listView1.Items.Clear();
                    using (var client = new ImapClient())
                    {
                        await client.ConnectAsync("imap.gmail.com", 993, true);
                        await client.AuthenticateAsync(tbEmail.Text, tbPassWord.Text);

                        var inbox = client.Inbox;
                        await inbox.OpenAsync(FolderAccess.ReadOnly);

                        var query = SearchQuery.DeliveredAfter(DateTime.Now.AddDays(-7));
                        var results = await inbox.SearchAsync(query);

                        tbTotal.Text = results.Count.ToString();

                        listView1.View = View.Details;
                        listView1.Columns.Add("Subject", 250);
                        listView1.Columns.Add("From", 250);
                        listView1.Columns.Add("Date", 250);

                        foreach (var uniqueId in results)
                        {
                            var message = await inbox.GetMessageAsync(uniqueId);
                            ListViewItem item = new ListViewItem();
                            item.Text = message.Subject;
                            item.SubItems.Add(message.From.ToString());
                            item.SubItems.Add(message.Date.ToString());
                            listView1.Items.Add(item);
                        }
                    }
                }
               
                else if (comboBox1.SelectedIndex == 1)
                {
                    listView1.Items.Clear();
                    using (var client = new Pop3Client())
                    {
                        await client.ConnectAsync("pop.gmail.com", 995, true);
                        await client.AuthenticateAsync(tbEmail.Text, tbPassWord.Text);

                        var count = client.Count;
                        tbTotal.Text = count.ToString();

                        listView1.View = View.Details;
                        listView1.Columns.Add("Subject", 250);
                        listView1.Columns.Add("From", 250);
                        listView1.Columns.Add("Date", 250);

                        var fromDate = DateTime.Now.AddDays(-7);
                        for (int i = count - 1; i >= 0; i--)
                        {
                            var message = await client.GetMessageAsync(i);
                            if (message.Date.DateTime >= fromDate)
                            {
                                ListViewItem item = new ListViewItem();
                                item.Text = message.Subject;
                                item.SubItems.Add(message.From.ToString());
                                item.SubItems.Add(message.Date.ToString());
                                listView1.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
