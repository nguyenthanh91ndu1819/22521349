using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB4
{
    public partial class ViewSourceBai3 : Form
    {
        public ViewSourceBai3()
        {
            InitializeComponent();
        }
        public void SetURL(string url)
        {
            szURL.Text = url;
            string htmlContent = getHTML(url);
            textBox1.Text = htmlContent;
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
    }
}
