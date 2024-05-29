namespace LAB4
{
    partial class BaiTap6
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
            richTextBox1 = new RichTextBox();
            btnLogin = new Button();
            tbPassword = new TextBox();
            tbUsername = new TextBox();
            tbURL = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(59, 153);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(437, 285);
            richTextBox1.TabIndex = 15;
            richTextBox1.Text = "";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(368, 56);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(128, 87);
            btnLogin.TabIndex = 14;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(145, 120);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(162, 27);
            tbPassword.TabIndex = 13;
            tbPassword.Text = "123456";
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(145, 68);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(162, 27);
            tbUsername.TabIndex = 12;
            tbUsername.Text = "phatpt";
            // 
            // tbURL
            // 
            tbURL.Location = new Point(145, 3);
            tbURL.Name = "tbURL";
            tbURL.Size = new Size(304, 27);
            tbURL.TabIndex = 11;
            tbURL.Text = "https://nt106.uitiot.vn/auth/token";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(59, 123);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 10;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 68);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 9;
            label2.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 6);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 8;
            label1.Text = "URL";
            // 
            // BaiTap6
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 466);
            Controls.Add(richTextBox1);
            Controls.Add(btnLogin);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Controls.Add(tbURL);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "BaiTap6";
            Text = "BaiTap6";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private Button btnLogin;
        private TextBox tbPassword;
        private TextBox tbUsername;
        private TextBox tbURL;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}