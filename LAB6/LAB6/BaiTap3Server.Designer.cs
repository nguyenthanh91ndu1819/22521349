namespace LAB6
{
    partial class BaiTap3Server
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
            label3 = new Label();
            lstClient = new ListBox();
            label2 = new Label();
            txtMessage = new TextBox();
            txtInfo = new TextBox();
            btnStart = new Button();
            txtIP = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(608, 25);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 29;
            label3.Text = "Client IP:";
            // 
            // lstClient
            // 
            lstClient.FormattingEnabled = true;
            lstClient.Location = new Point(608, 67);
            lstClient.Name = "lstClient";
            lstClient.Size = new Size(172, 264);
            lstClient.TabIndex = 28;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 368);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 27;
            label2.Text = "Message";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(121, 361);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(481, 27);
            txtMessage.TabIndex = 26;
            // 
            // txtInfo
            // 
            txtInfo.Location = new Point(121, 67);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ReadOnly = true;
            txtInfo.ScrollBars = ScrollBars.Both;
            txtInfo.Size = new Size(481, 288);
            txtInfo.TabIndex = 25;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(508, 403);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 24;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(121, 18);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(481, 27);
            txtIP.TabIndex = 22;
            txtIP.Text = "127.0.0.1:9000";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 21);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 21;
            label1.Text = "Server: ";
            // 
            // BaiTap3Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtMessage);
            Controls.Add(txtInfo);
            Controls.Add(btnStart);
            Controls.Add(txtIP);
            Controls.Add(label1);
            Controls.Add(lstClient);
            Name = "BaiTap3Server";
            Text = "BaiTap3Server";
            Load += BaiTap3Server_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private ListBox lstClient;
        private Label label2;
        private TextBox txtMessage;
        private TextBox txtInfo;
        private Button btnStart;
        private TextBox txtIP;
        private Label label1;
    }
}