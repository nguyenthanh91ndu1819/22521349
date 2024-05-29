using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace LAB4
{
    public partial class BaiTap6 : Form
    {
        public BaiTap6()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var url = tbURL.Text;
            var username = tbUsername.Text;
            var password = tbPassword.Text;

            using (var client = new HttpClient())
            {
                try
                {

                    var content = new MultipartFormDataContent
                    {
                        { new StringContent(username), "username" },
                        { new StringContent(password), "password" }
                    };
                    var response = await client.PostAsync(url, content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JObject.Parse(responseString);

                    if (!response.IsSuccessStatusCode)
                    {
                        var detail = responseObject["detail"].ToString();
                        richTextBox1.AppendText($"Detail: {detail}\n");
                        return;
                    }

                    var tokenType = responseObject["token_type"].ToString();
                    var accessToken = responseObject["access_token"].ToString();
                    richTextBox1.AppendText($"{tokenType} {accessToken}\n");


                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                    var getUserUrl = "https://nt106.uitiot.vn/api/v1/user/me";
                    var getUserResponse = await client.GetAsync(getUserUrl);
                    var getUserResponseString = await getUserResponse.Content.ReadAsStringAsync();
                    if (getUserResponse.IsSuccessStatusCode)
                    {
                        var userObject = JObject.Parse(getUserResponseString);
                        var userId = userObject["id"]?.ToString();
                        var fullName = userObject["full_name"]?.ToString();
                        var email = userObject["email"]?.ToString();

                        if (userId != null)
                        {
                            richTextBox1.AppendText($"User ID: {userId}\n");
                        }
                        if (fullName != null)
                        {
                            richTextBox1.AppendText($"Full Name: {fullName}\n");
                        }
                        if (email != null)
                        {
                            richTextBox1.AppendText($"Email: {email}\n");
                        }

                        richTextBox1.AppendText("\nĐăng nhập thành công!\n");
                    }
                    else
                    {
                        richTextBox1.AppendText($"Error retrieving user information: {getUserResponse.StatusCode}\n");
                    }
                    
                }
                catch (Exception ex)
                {
                    richTextBox1.AppendText($"Error: {ex.Message}\n");
                }
            }
        }
    }
}
