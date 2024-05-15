namespace LAB3
{
    partial class BaiTap6Server
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
            label2 = new Label();
            txtMessage = new TextBox();
            txtInfo = new TextBox();
            btnSend = new Button();
            btnStart = new Button();
            txtIP = new TextBox();
            label1 = new Label();
            lstClient = new ListBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 377);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 18;
            label2.Text = "Message";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(152, 370);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(481, 27);
            txtMessage.TabIndex = 17;
            // 
            // txtInfo
            // 
            txtInfo.Location = new Point(152, 76);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ReadOnly = true;
            txtInfo.ScrollBars = ScrollBars.Both;
            txtInfo.Size = new Size(481, 288);
            txtInfo.TabIndex = 16;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(423, 412);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 14;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(539, 412);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 15;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(152, 27);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(481, 27);
            txtIP.TabIndex = 13;
            txtIP.Text = "127.0.0.1:9000";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 30);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 12;
            label1.Text = "Server: ";
            // 
            // lstClient
            // 
            lstClient.FormattingEnabled = true;
            lstClient.Location = new Point(639, 76);
            lstClient.Name = "lstClient";
            lstClient.Size = new Size(172, 264);
            lstClient.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(639, 34);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 20;
            label3.Text = "Client IP:";
            // 
            // BaiTap6Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 478);
            Controls.Add(label3);
            Controls.Add(lstClient);
            Controls.Add(label2);
            Controls.Add(txtMessage);
            Controls.Add(txtInfo);
            Controls.Add(btnSend);
            Controls.Add(btnStart);
            Controls.Add(txtIP);
            Controls.Add(label1);
            Name = "BaiTap6Server";
            Text = "BaiTap6Server";
            Load += BaiTap6Server_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox txtMessage;
        private TextBox txtInfo;
        private Button btnSend;
        private Button btnStart;
        private TextBox txtIP;
        private Label label1;
        private ListBox lstClient;
        private Label label3;
    }
}