namespace LAB6
{
    partial class BaiTap1
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
            btnEncrypt = new Button();
            btnDencrypt = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tbData = new TextBox();
            tbEncryptedData = new TextBox();
            tbDencryptedData = new TextBox();
            tbShift = new TextBox();
            SuspendLayout();
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(419, 28);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(94, 29);
            btnEncrypt.TabIndex = 0;
            btnEncrypt.Text = "MÃ HÓA";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // btnDencrypt
            // 
            btnDencrypt.Location = new Point(597, 28);
            btnDencrypt.Name = "btnDencrypt";
            btnDencrypt.Size = new Size(94, 29);
            btnDencrypt.TabIndex = 1;
            btnDencrypt.Text = "GIẢI MÃ";
            btnDencrypt.UseVisualStyleBackColor = true;
            btnDencrypt.Click += btnDencrypt_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 66);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 2;
            label1.Text = "Dịch(Shift)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 125);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 3;
            label2.Text = "Dữ liệu (Input)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(62, 348);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 4;
            label3.Text = "Mã hóa ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(62, 604);
            label4.Name = "label4";
            label4.Size = new Size(60, 20);
            label4.TabIndex = 5;
            label4.Text = "Giải Mã";
            // 
            // tbData
            // 
            tbData.Location = new Point(62, 159);
            tbData.Multiline = true;
            tbData.Name = "tbData";
            tbData.Size = new Size(663, 186);
            tbData.TabIndex = 6;
            // 
            // tbEncryptedData
            // 
            tbEncryptedData.Location = new Point(62, 380);
            tbEncryptedData.Multiline = true;
            tbEncryptedData.Name = "tbEncryptedData";
            tbEncryptedData.Size = new Size(663, 186);
            tbEncryptedData.TabIndex = 7;
            // 
            // tbDencryptedData
            // 
            tbDencryptedData.Location = new Point(62, 627);
            tbDencryptedData.Multiline = true;
            tbDencryptedData.Name = "tbDencryptedData";
            tbDencryptedData.Size = new Size(663, 306);
            tbDencryptedData.TabIndex = 8;
            // 
            // tbShift
            // 
            tbShift.Location = new Point(62, 95);
            tbShift.Name = "tbShift";
            tbShift.Size = new Size(125, 27);
            tbShift.TabIndex = 9;
            // 
            // BaiTap1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 1046);
            Controls.Add(tbShift);
            Controls.Add(tbDencryptedData);
            Controls.Add(tbEncryptedData);
            Controls.Add(tbData);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDencrypt);
            Controls.Add(btnEncrypt);
            Name = "BaiTap1";
            Text = "BaiTap1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEncrypt;
        private Button btnDencrypt;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tbData;
        private TextBox tbEncryptedData;
        private TextBox tbDencryptedData;
        private TextBox tbShift;
    }
}