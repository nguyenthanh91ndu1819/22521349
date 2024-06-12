namespace LAB5
{
    partial class BT6GuiMail
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
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            tbFrom = new TextBox();
            tbName = new TextBox();
            tbTo = new TextBox();
            tbSubject = new TextBox();
            tbBody = new TextBox();
            tbBrowse = new TextBox();
            btnBrowse = new Button();
            tbSend = new Button();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(90, 50);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 0;
            label1.Text = "From:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(90, 116);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 1;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(90, 182);
            label3.Name = "label3";
            label3.Size = new Size(32, 20);
            label3.TabIndex = 2;
            label3.Text = "To: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(90, 241);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 3;
            label4.Text = "Subject: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(90, 304);
            label5.Name = "label5";
            label5.Size = new Size(43, 20);
            label5.TabIndex = 4;
            label5.Text = "Body";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(90, 612);
            label6.Name = "label6";
            label6.Size = new Size(89, 20);
            label6.TabIndex = 5;
            label6.Text = "Attachment:";
            // 
            // tbFrom
            // 
            tbFrom.Location = new Point(208, 47);
            tbFrom.Name = "tbFrom";
            tbFrom.ReadOnly = true;
            tbFrom.Size = new Size(335, 27);
            tbFrom.TabIndex = 6;
            // 
            // tbName
            // 
            tbName.Location = new Point(208, 113);
            tbName.Name = "tbName";
            tbName.Size = new Size(335, 27);
            tbName.TabIndex = 7;
            // 
            // tbTo
            // 
            tbTo.Location = new Point(208, 175);
            tbTo.Name = "tbTo";
            tbTo.Size = new Size(335, 27);
            tbTo.TabIndex = 8;
            // 
            // tbSubject
            // 
            tbSubject.Location = new Point(208, 234);
            tbSubject.Name = "tbSubject";
            tbSubject.Size = new Size(335, 27);
            tbSubject.TabIndex = 9;
            // 
            // tbBody
            // 
            tbBody.Location = new Point(208, 341);
            tbBody.Multiline = true;
            tbBody.Name = "tbBody";
            tbBody.Size = new Size(349, 237);
            tbBody.TabIndex = 10;
            tbBody.Text = "<h1>Gui mail voi tep dinh kem</h1>\r\n<h2>Phan noi dung nay duoc gui duoi dang HTML</h2>";
            // 
            // tbBrowse
            // 
            tbBrowse.Location = new Point(208, 612);
            tbBrowse.Name = "tbBrowse";
            tbBrowse.ReadOnly = true;
            tbBrowse.Size = new Size(349, 27);
            tbBrowse.TabIndex = 11;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(614, 612);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(94, 29);
            btnBrowse.TabIndex = 12;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += tbBrowse_Click;
            // 
            // tbSend
            // 
            tbSend.Location = new Point(614, 693);
            tbSend.Name = "tbSend";
            tbSend.Size = new Size(94, 29);
            tbSend.TabIndex = 13;
            tbSend.Text = "Send";
            tbSend.UseVisualStyleBackColor = true;
            tbSend.Click += tbSend_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(208, 300);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(70, 24);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "HTML";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // BT6GuiMail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(767, 734);
            Controls.Add(checkBox1);
            Controls.Add(tbSend);
            Controls.Add(btnBrowse);
            Controls.Add(tbBrowse);
            Controls.Add(tbBody);
            Controls.Add(tbSubject);
            Controls.Add(tbTo);
            Controls.Add(tbName);
            Controls.Add(tbFrom);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "BT6GuiMail";
            Text = "BT6GuiMail";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox tbFrom;
        private TextBox tbName;
        private TextBox tbTo;
        private TextBox tbSubject;
        private TextBox tbBody;
        private TextBox tbBrowse;
        private Button btnBrowse;
        private Button tbSend;
        private CheckBox checkBox1;
    }
}