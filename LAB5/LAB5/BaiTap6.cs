using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using System;
using System.Windows.Forms;

namespace LAB5
{
    public partial class BaiTap6 : Form
    {
        private bool loggedIn = false;

        public BaiTap6()
        {
            InitializeComponent();
            HideButtons();

        }

        private void HideButtons()
        {
            button2.Hide();
            button3.Hide();
        }

        private void ShowButtons()
        {
            button2.Visible = true;
            button3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!loggedIn)
            {
                using (var client = new ImapClient())
                {
                    client.Connect("imap.gmail.com", 993, true);

                    loggedIn = true;
                    ShowButtons();
                    button1.Text = "Đăng xuất";
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
                    listView1.Columns.Add("Body", 250);


                    foreach (var uniqueId in results)
                    {
                        var message = inbox.GetMessage(uniqueId);


                        ListViewItem item = new ListViewItem();


                        item.Text = message.Subject;
                        item.SubItems.Add(message.From.ToString());
                        item.SubItems.Add(message.Date.ToString());
                        item.SubItems.Add(message.Body.ToString());


                        listView1.Items.Add(item);
                    }
                }
            }
            else
            {

                loggedIn = false;
                HideButtons();
                button1.Text = "Đăng nhập";
                tbEmail.Text = "";
                tbPassWord.Text = "";
                tbTotal.Text = "";
                tbRecent.Text = "";
                listView1.Items.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (loggedIn)
            {
                BT6GuiMail bT6GuiMail = new BT6GuiMail(tbEmail.Text, tbPassWord.Text);
                bT6GuiMail.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng đăng nhập trước", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (loggedIn)
            {
                using (var client = new ImapClient())
                {
                    try
                    {
                        client.Connect("imap.gmail.com", 993, true);
                        client.Authenticate(tbEmail.Text, tbPassWord.Text);

                        var inbox = client.Inbox;
                        inbox.Open(FolderAccess.ReadOnly);
                        var query1 = SearchQuery.DeliveredAfter(DateTime.Now.AddDays(-7));
                        var results = inbox.Search(query1);

                        int totalEmails = results.Count;
                        tbTotal.Text = totalEmails.ToString();

                        listView1.Items.Clear();
                        foreach (var uniqueId in results)
                        {
                            var message = inbox.GetMessage(uniqueId);
                            ListViewItem item = new ListViewItem();
                            item.Text = message.Subject;
                            item.SubItems.Add(message.From.ToString());
                            item.SubItems.Add(message.Date.ToString());
                            listView1.Items.Add(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng đăng nhập trước.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                if (selectedItem != null)
                {
                    string subject = selectedItem.SubItems[0].Text;
                    string from = selectedItem.SubItems[1].Text;
                    string date = selectedItem.SubItems[2].Text;
                    int selectedIndex = listView1.SelectedItems[0].Index;

                    using (var client = new ImapClient())
                    {
                        try
                        {
                            client.Connect("imap.gmail.com", 993, true);
                            client.Authenticate(tbEmail.Text, tbPassWord.Text);

                            var inbox = client.Inbox;
                            inbox.Open(FolderAccess.ReadOnly);

                            var message = inbox.GetMessage(selectedIndex);


                            string body = message.TextBody;


                            var attachments = message.Attachments;

                           
                            BT6TTMail bT6TTMail = new BT6TTMail(subject, from, date, body, attachments, tbEmail.Text);
                            bT6TTMail.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


    }
}
