namespace LAB3
{
    partial class TCPClient
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
            txtConnect = new Button();
            txtSend = new Button();
            txtDisconnect = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // txtConnect
            // 
            txtConnect.Location = new Point(477, 39);
            txtConnect.Name = "txtConnect";
            txtConnect.Size = new Size(94, 29);
            txtConnect.TabIndex = 0;
            txtConnect.Text = "Connect";
            txtConnect.UseVisualStyleBackColor = true;
            txtConnect.Click += txtConnect_Click;
            // 
            // txtSend
            // 
            txtSend.Location = new Point(477, 124);
            txtSend.Name = "txtSend";
            txtSend.Size = new Size(94, 29);
            txtSend.TabIndex = 1;
            txtSend.Text = "Send";
            txtSend.UseVisualStyleBackColor = true;
            txtSend.Click += txtSend_Click;
            // 
            // txtDisconnect
            // 
            txtDisconnect.Location = new Point(477, 206);
            txtDisconnect.Name = "txtDisconnect";
            txtDisconnect.Size = new Size(94, 29);
            txtDisconnect.TabIndex = 2;
            txtDisconnect.Text = "Disconnect";
            txtDisconnect.UseVisualStyleBackColor = true;
            txtDisconnect.Click += txtDisconnect_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(77, 40);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(350, 211);
            textBox1.TabIndex = 3;
            // 
            // TCPClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 326);
            Controls.Add(textBox1);
            Controls.Add(txtDisconnect);
            Controls.Add(txtSend);
            Controls.Add(txtConnect);
            Name = "TCPClient";
            Text = "TCPClient";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button txtConnect;
        private Button txtSend;
        private Button txtDisconnect;
        private TextBox textBox1;
    }
}