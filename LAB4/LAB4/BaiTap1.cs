﻿using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace LAB4
{
    public partial class BaiTap1 : Form
    {
        public BaiTap1()
        {
            InitializeComponent();
        }

        private string getHTML(string szUrl)
        {
            try
            {
                // Create a request for the URL.
                WebRequest request = WebRequest.Create(szUrl);
                // Get the response.
                WebResponse response = request.GetResponse();
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Close the response.
                reader.Close();
                response.Close();
                return responseFromServer;
            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred
                return "Error: " + ex.Message;
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            
            string url = szUrl.Text;
            string htmlContent = getHTML(url);
            textBox1.Text = htmlContent;
        }
    }
}