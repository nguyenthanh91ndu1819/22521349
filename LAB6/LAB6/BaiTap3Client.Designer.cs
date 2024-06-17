namespace LAB6
{
    partial class BaiTap3Client
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
            txtName = new TextBox();
            label3 = new Label();
            txtInfo = new TextBox();
            btnSend = new Button();
            btnConnect = new Button();
            txtIP = new TextBox();
            label1 = new Label();
            btnSendFile = new Button();
            btnDownloadFile = new Button();
            label2 = new Label();
            txtMessage = new TextBox();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(181, 362);
            txtName.Name = "txtName";
            txtName.Size = new Size(207, 27);
            txtName.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(71, 364);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 21;
            label3.Text = "Your Name:";
            // 
            // txtInfo
            // 
            txtInfo.Location = new Point(181, 76);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ReadOnly = true;
            txtInfo.ScrollBars = ScrollBars.Both;
            txtInfo.Size = new Size(481, 268);
            txtInfo.TabIndex = 18;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(535, 477);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 16;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(579, 360);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(94, 29);
            btnConnect.TabIndex = 17;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(181, 27);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(481, 27);
            txtIP.TabIndex = 15;
            txtIP.Text = "127.0.0.1:9000";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(81, 30);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 14;
            label1.Text = "Server: ";
            // 
            // btnSendFile
            // 
            btnSendFile.Location = new Point(157, 477);
            btnSendFile.Name = "btnSendFile";
            btnSendFile.Size = new Size(119, 29);
            btnSendFile.TabIndex = 23;
            btnSendFile.TabStop = false;
            btnSendFile.Text = "Send file";
            btnSendFile.UseVisualStyleBackColor = true;
            btnSendFile.Click += btnSendFile_Click;
            // 
            // btnDownloadFile
            // 
            btnDownloadFile.Location = new Point(336, 477);
            btnDownloadFile.Name = "btnDownloadFile";
            btnDownloadFile.Size = new Size(140, 29);
            btnDownloadFile.TabIndex = 24;
            btnDownloadFile.Text = "Download file";
            btnDownloadFile.UseVisualStyleBackColor = true;
            btnDownloadFile.Click += btnDownloadFile_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 430);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 20;
            label2.Text = "Message";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(157, 423);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(481, 27);
            txtMessage.TabIndex = 19;
            // 
            // BaiTap3Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(812, 585);
            Controls.Add(btnDownloadFile);
            Controls.Add(btnSendFile);
            Controls.Add(txtName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtMessage);
            Controls.Add(txtInfo);
            Controls.Add(btnSend);
            Controls.Add(btnConnect);
            Controls.Add(txtIP);
            Controls.Add(label1);
            Name = "BaiTap3Client";
            Text = "BaiTap3Client";
            Load += BaiTap6Client_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private Label label3;
        private TextBox txtInfo;
        private Button btnSend;
        private Button btnConnect;
        private TextBox txtIP;
        private Label label1;
        private Button btnSendFile;
        private Button btnDownloadFile;
        private Label label2;
        private TextBox txtMessage;
    }
}