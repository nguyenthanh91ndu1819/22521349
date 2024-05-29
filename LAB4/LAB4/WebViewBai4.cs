using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;

namespace LAB4
{
    public partial class WebViewBai4 : Form
    {
        public WebViewBai4(string url)
        {
            InitializeComponent();
            webView21.Source = new Uri(url);
        }
    }
}
