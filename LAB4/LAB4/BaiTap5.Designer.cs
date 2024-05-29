namespace LAB4
{
    partial class BaiTap5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbURL = new TextBox();
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            btnLogin = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(63, 39);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 0;
            label1.Text = "URL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 101);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(63, 156);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // tbURL
            // 
            tbURL.Location = new Point(149, 36);
            tbURL.Name = "tbURL";
            tbURL.Size = new Size(304, 27);
            tbURL.TabIndex = 3;
            tbURL.Text = "https://nt106.uitiot.vn/auth/token";
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(149, 101);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(162, 27);
            tbUsername.TabIndex = 4;
            tbUsername.Text = "phatpt";
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(149, 153);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(162, 27);
            tbPassword.TabIndex = 5;
            tbPassword.Text = "123456";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(372, 89);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(128, 87);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(63, 186);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(437, 285);
            richTextBox1.TabIndex = 7;
            richTextBox1.Text = "";
            // 
            // BaiTap5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 493);
            Controls.Add(richTextBox1);
            Controls.Add(btnLogin);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Controls.Add(tbURL);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "BaiTap5";
            Text = "BaiTap5";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbURL;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private Button btnLogin;
        private RichTextBox richTextBox1;
    }
}