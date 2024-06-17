namespace LAB6
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
            tbKeyWord = new TextBox();
            tbDecryptedData = new TextBox();
            tbEncryptedData = new TextBox();
            tbData = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnDencrypt = new Button();
            btnEncrypt = new Button();
            SuspendLayout();
            // 
            // tbKeyWord
            // 
            tbKeyWord.Location = new Point(61, 84);
            tbKeyWord.Name = "tbKeyWord";
            tbKeyWord.Size = new Size(125, 27);
            tbKeyWord.TabIndex = 19;
            // 
            // tbDecryptedData
            // 
            tbDecryptedData.Location = new Point(61, 616);
            tbDecryptedData.Multiline = true;
            tbDecryptedData.Name = "tbDecryptedData";
            tbDecryptedData.Size = new Size(663, 306);
            tbDecryptedData.TabIndex = 18;
            // 
            // tbEncryptedData
            // 
            tbEncryptedData.Location = new Point(61, 369);
            tbEncryptedData.Multiline = true;
            tbEncryptedData.Name = "tbEncryptedData";
            tbEncryptedData.Size = new Size(663, 186);
            tbEncryptedData.TabIndex = 17;
            // 
            // tbData
            // 
            tbData.Location = new Point(61, 150);
            tbData.Multiline = true;
            tbData.Name = "tbData";
            tbData.Size = new Size(663, 186);
            tbData.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(61, 593);
            label4.Name = "label4";
            label4.Size = new Size(60, 20);
            label4.TabIndex = 15;
            label4.Text = "Giải Mã";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(61, 337);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 14;
            label3.Text = "Mã hóa ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 114);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 13;
            label2.Text = "Dữ liệu (Input)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 55);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 12;
            label1.Text = "Key Word";
            // 
            // btnDencrypt
            // 
            btnDencrypt.Location = new Point(596, 17);
            btnDencrypt.Name = "btnDencrypt";
            btnDencrypt.Size = new Size(94, 29);
            btnDencrypt.TabIndex = 11;
            btnDencrypt.Text = "GIẢI MÃ";
            btnDencrypt.UseVisualStyleBackColor = true;
            btnDencrypt.Click += btnDecrypt_Click;
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(418, 17);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(94, 29);
            btnEncrypt.TabIndex = 10;
            btnEncrypt.Text = "MÃ HÓA";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // BaiTap2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 961);
            Controls.Add(tbKeyWord);
            Controls.Add(tbDecryptedData);
            Controls.Add(tbEncryptedData);
            Controls.Add(tbData);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDencrypt);
            Controls.Add(btnEncrypt);
            Name = "BaiTap2";
            Text = "BaiTap2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbKeyWord;
        private TextBox tbDecryptedData;
        private TextBox tbEncryptedData;
        private TextBox tbData;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnDencrypt;
        private Button btnEncrypt;
    }
}