namespace LAB5
{
    partial class BT6TTMail
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
            label1 = new Label();
            label2 = new Label();
            tbFrom = new TextBox();
            tbTo = new TextBox();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 26);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 0;
            label1.Text = "From:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(83, 80);
            label2.Name = "label2";
            label2.Size = new Size(32, 20);
            label2.TabIndex = 1;
            label2.Text = "To: ";
            // 
            // tbFrom
            // 
            tbFrom.Location = new Point(197, 26);
            tbFrom.Name = "tbFrom";
            tbFrom.Size = new Size(514, 27);
            tbFrom.TabIndex = 2;
            // 
            // tbTo
            // 
            tbTo.Location = new Point(197, 80);
            tbTo.Name = "tbTo";
            tbTo.Size = new Size(514, 27);
            tbTo.TabIndex = 3;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(161, 159);
            webView21.Name = "webView21";
            webView21.Size = new Size(569, 261);
            webView21.TabIndex = 4;
            webView21.ZoomFactor = 1D;
            // 
            // BT6TTMail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(webView21);
            Controls.Add(tbTo);
            Controls.Add(tbFrom);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "BT6TTMail";
            Text = "BT6TTMail";
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tbFrom;
        private TextBox tbTo;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}