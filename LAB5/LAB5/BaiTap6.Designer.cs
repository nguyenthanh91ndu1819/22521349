﻿namespace LAB5
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
            tbRecent = new TextBox();
            label4 = new Label();
            tbTotal = new TextBox();
            label3 = new Label();
            button1 = new Button();
            tbPassWord = new TextBox();
            lbPassWord = new Label();
            listView1 = new ListView();
            tbEmail = new TextBox();
            lbEmail = new Label();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // tbRecent
            // 
            tbRecent.Location = new Point(353, 162);
            tbRecent.Name = "tbRecent";
            tbRecent.ReadOnly = true;
            tbRecent.Size = new Size(60, 27);
            tbRecent.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(279, 165);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 18;
            label4.Text = "Recent";
            // 
            // tbTotal
            // 
            tbTotal.Location = new Point(129, 158);
            tbTotal.Name = "tbTotal";
            tbTotal.ReadOnly = true;
            tbTotal.Size = new Size(60, 27);
            tbTotal.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(62, 165);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 16;
            label3.Text = "Total:";
            // 
            // button1
            // 
            button1.Location = new Point(527, 132);
            button1.Name = "button1";
            button1.Size = new Size(146, 32);
            button1.TabIndex = 15;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tbPassWord
            // 
            tbPassWord.Location = new Point(167, 85);
            tbPassWord.Name = "tbPassWord";
            tbPassWord.Size = new Size(256, 27);
            tbPassWord.TabIndex = 14;
            tbPassWord.Text = "qcii qibh gvvr ojtq";
            // 
            // lbPassWord
            // 
            lbPassWord.AutoSize = true;
            lbPassWord.Location = new Point(62, 85);
            lbPassWord.Name = "lbPassWord";
            lbPassWord.Size = new Size(77, 20);
            lbPassWord.TabIndex = 13;
            lbPassWord.Text = "Mật khẩu: ";
            // 
            // listView1
            // 
            listView1.Location = new Point(43, 206);
            listView1.Name = "listView1";
            listView1.Size = new Size(714, 224);
            listView1.TabIndex = 12;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(167, 21);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(256, 27);
            tbEmail.TabIndex = 11;
            tbEmail.Text = "chessmasterresetpass@gmail.com";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Location = new Point(61, 21);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(49, 20);
            lbEmail.TabIndex = 10;
            lbEmail.Text = "Email:";
            // 
            // button2
            // 
            button2.Location = new Point(527, 12);
            button2.Name = "button2";
            button2.Size = new Size(146, 32);
            button2.TabIndex = 20;
            button2.Text = "Gửi mail";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(527, 73);
            button3.Name = "button3";
            button3.Size = new Size(146, 32);
            button3.TabIndex = 21;
            button3.Text = "Refresh";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // BaiTap6
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
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
            Name = "BaiTap6";
            Text = "BaiTap6";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbRecent;
        private Label label4;
        private TextBox tbTotal;
        private Label label3;
        private Button button1;
        private TextBox tbPassWord;
        private Label lbPassWord;
        private ListView listView1;
        private TextBox tbEmail;
        private Label lbEmail;
        private Button button2;
        private Button button3;
    }
}