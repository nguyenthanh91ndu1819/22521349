namespace LAB5
{
    partial class BaiTap2
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
            lbEmail = new Label();
            tbEmail = new TextBox();
            lbPassWord = new Label();
            tbPassWord = new TextBox();
            button1 = new Button();
            label3 = new Label();
            tbTotal = new TextBox();
            label4 = new Label();
            tbRecent = new TextBox();
            listView1 = new ListView();
            SuspendLayout();
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Location = new Point(58, 18);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(49, 20);
            lbEmail.TabIndex = 0;
            lbEmail.Text = "Email:";
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(164, 18);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(256, 27);
            tbEmail.TabIndex = 1;
            tbEmail.Text = "chessmasterresetpass@gmail.com";
            // 
            // lbPassWord
            // 
            lbPassWord.AutoSize = true;
            lbPassWord.Location = new Point(59, 82);
            lbPassWord.Name = "lbPassWord";
            lbPassWord.Size = new Size(77, 20);
            lbPassWord.TabIndex = 3;
            lbPassWord.Text = "Mật khẩu: ";
            // 
            // tbPassWord
            // 
            tbPassWord.Location = new Point(164, 82);
            tbPassWord.Name = "tbPassWord";
            tbPassWord.PasswordChar = '*';
            tbPassWord.Size = new Size(256, 27);
            tbPassWord.TabIndex = 4;
            tbPassWord.Text = "qcii qibh gvvr ojtq";
            // 
            // button1
            // 
            button1.Location = new Point(526, 37);
            button1.Name = "button1";
            button1.Size = new Size(144, 72);
            button1.TabIndex = 5;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(59, 162);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 6;
            label3.Text = "Total:";
            // 
            // tbTotal
            // 
            tbTotal.Location = new Point(126, 155);
            tbTotal.Name = "tbTotal";
            tbTotal.ReadOnly = true;
            tbTotal.Size = new Size(60, 27);
            tbTotal.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(276, 162);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 8;
            label4.Text = "Recent";
            // 
            // tbRecent
            // 
            tbRecent.Location = new Point(350, 159);
            tbRecent.Name = "tbRecent";
            tbRecent.ReadOnly = true;
            tbRecent.Size = new Size(60, 27);
            tbRecent.TabIndex = 9;
            // 
            // listView1
            // 
            listView1.Location = new Point(40, 203);
            listView1.Name = "listView1";
            listView1.Size = new Size(714, 224);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // BaiTap2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbRecent);
            Controls.Add(label4);
            Controls.Add(tbTotal);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(tbPassWord);
            Controls.Add(lbPassWord);
            Controls.Add(listView1);
            Controls.Add(tbEmail);
            Controls.Add(lbEmail);
            Name = "BaiTap2";
            Text = "BaiTap2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbEmail;
        private TextBox tbEmail;
        private Label lbPassWord;
        private TextBox tbPassWord;
        private Button button1;
        private Label label3;
        private TextBox tbTotal;
        private Label label4;
        private TextBox tbRecent;
        private ListView listView1;
    }
}