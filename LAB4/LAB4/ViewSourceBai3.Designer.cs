namespace LAB4
{
    partial class ViewSourceBai3
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
            szURL = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(36, 48);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(643, 430);
            textBox1.TabIndex = 1;
            // 
            // szURL
            // 
            szURL.Location = new Point(36, 12);
            szURL.Name = "szURL";
            szURL.Size = new Size(643, 27);
            szURL.TabIndex = 2;
            // 
            // ViewSourceBai3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(762, 510);
            Controls.Add(szURL);
            Controls.Add(textBox1);
            Name = "ViewSourceBai3";
            Text = "ViewSourceBai3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox tbURL;
        private TextBox szURL;
    }
}