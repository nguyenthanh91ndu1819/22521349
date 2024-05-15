namespace LAB3
{
    partial class BaiTap6Client
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
            txtMessage = new TextBox();
            txtInfo = new TextBox();
            btnSend = new Button();
            btnConnect = new Button();
            txtIP = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtName = new TextBox();
            SuspendLayout();
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(142, 415);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(481, 27);
            txtMessage.TabIndex = 10;
            // 
            // txtInfo
            // 
            txtInfo.Location = new Point(166, 68);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ReadOnly = true;
            txtInfo.ScrollBars = ScrollBars.Both;
            txtInfo.Size = new Size(481, 268);
            txtInfo.TabIndex = 9;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(520, 469);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 7;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(564, 352);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(94, 29);
            btnConnect.TabIndex = 8;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(166, 19);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(481, 27);
            txtIP.TabIndex = 6;
            txtIP.Text = "127.0.0.1:9000";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 22);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 5;
            label1.Text = "Server: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 422);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 11;
            label2.Text = "Message";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(56, 356);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 12;
            label3.Text = "Your Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(166, 354);
            txtName.Name = "txtName";
            txtName.Size = new Size(207, 27);
            txtName.TabIndex = 13;
            // 
            // BaiTap6Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 510);
            Controls.Add(txtName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtMessage);
            Controls.Add(txtInfo);
            Controls.Add(btnSend);
            Controls.Add(btnConnect);
            Controls.Add(txtIP);
            Controls.Add(label1);
            Name = "BaiTap6Client";
            Text = "BaiTap6Client";
            Load += BaiTap6Client_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMessage;
        private TextBox txtInfo;
        private Button btnSend;
        private Button btnConnect;
        private TextBox txtIP;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtName;
    }
}