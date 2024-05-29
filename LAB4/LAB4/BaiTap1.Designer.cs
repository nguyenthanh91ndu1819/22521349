namespace LAB4
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
            textBox1 = new TextBox();
            szUrl = new TextBox();
            btnGet = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(25, 61);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(643, 430);
            textBox1.TabIndex = 0;
            // 
            // szUrl
            // 
            szUrl.Location = new Point(25, 28);
            szUrl.Name = "szUrl";
            szUrl.Size = new Size(518, 27);
            szUrl.TabIndex = 1;
            szUrl.Text = "https://uit.edu.vn/";
            // 
            // btnGet
            // 
            btnGet.Location = new Point(564, 26);
            btnGet.Name = "btnGet";
            btnGet.Size = new Size(94, 29);
            btnGet.TabIndex = 2;
            btnGet.Text = "Get";
            btnGet.UseVisualStyleBackColor = true;
            btnGet.Click += btnGet_Click;
            // 
            // BaiTap1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(709, 492);
            Controls.Add(btnGet);
            Controls.Add(szUrl);
            Controls.Add(textBox1);
            Name = "BaiTap1";
            Text = "BaiTap1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox szUrl;
        private Button btnGet;
    }
}