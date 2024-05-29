namespace LAB4
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
            btnDown = new Button();
            szUrl = new TextBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // btnDown
            // 
            btnDown.Location = new Point(601, 46);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(94, 29);
            btnDown.TabIndex = 5;
            btnDown.Text = "Download";
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += btnDown_Click;
            // 
            // szUrl
            // 
            szUrl.Location = new Point(62, 48);
            szUrl.Name = "szUrl";
            szUrl.Size = new Size(518, 27);
            szUrl.TabIndex = 4;
            szUrl.Text = "https://uit.edu.vn/";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(62, 115);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(643, 430);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(62, 81);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(308, 27);
            textBox2.TabIndex = 6;
            textBox2.Text = "D:\\uit.html";
            // 
            // BaiTap2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(767, 557);
            Controls.Add(textBox2);
            Controls.Add(btnDown);
            Controls.Add(szUrl);
            Controls.Add(textBox1);
            Name = "BaiTap2";
            Text = "BaiTap2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDown;
        private TextBox szUrl;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}