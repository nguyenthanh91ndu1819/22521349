namespace LAB4
{
    partial class BaiTap3
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
            webView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            btnLoad = new Button();
            btnReload = new Button();
            btnViewSource = new Button();
            btnDownSource = new Button();
            tbURL = new TextBox();
            ((System.ComponentModel.ISupportInitialize)webView2).BeginInit();
            SuspendLayout();
            // 
            // webView2
            // 
            webView2.AllowExternalDrop = true;
            webView2.CreationProperties = null;
            webView2.DefaultBackgroundColor = Color.White;
            webView2.Location = new Point(61, 99);
            webView2.Name = "webView2";
            webView2.Size = new Size(632, 339);
            webView2.TabIndex = 0;
            webView2.ZoomFactor = 1D;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(28, 22);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(599, 22);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(94, 29);
            btnReload.TabIndex = 2;
            btnReload.Text = "Reload";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // btnViewSource
            // 
            btnViewSource.Location = new Point(462, 64);
            btnViewSource.Name = "btnViewSource";
            btnViewSource.Size = new Size(131, 29);
            btnViewSource.TabIndex = 3;
            btnViewSource.Text = "View Source";
            btnViewSource.UseVisualStyleBackColor = true;
            btnViewSource.Click += btnViewSource_Click;
            // 
            // btnDownSource
            // 
            btnDownSource.Location = new Point(599, 64);
            btnDownSource.Name = "btnDownSource";
            btnDownSource.Size = new Size(120, 29);
            btnDownSource.TabIndex = 4;
            btnDownSource.Text = "Down Source";
            btnDownSource.UseVisualStyleBackColor = true;
            btnDownSource.Click += btnDownSource_Click;
            // 
            // tbURL
            // 
            tbURL.Location = new Point(143, 24);
            tbURL.Name = "tbURL";
            tbURL.Size = new Size(440, 27);
            tbURL.TabIndex = 5;
            tbURL.Text = "https://uit.edu.vn";
            // 
            // BaiTap3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbURL);
            Controls.Add(btnDownSource);
            Controls.Add(btnViewSource);
            Controls.Add(btnReload);
            Controls.Add(btnLoad);
            Controls.Add(webView2);
            Name = "BaiTap3";
            Text = "BaiTap3";
            ((System.ComponentModel.ISupportInitialize)webView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView2;
        private Button btnLoad;
        private Button btnReload;
        private Button btnViewSource;
        private Button btnDownSource;
        private TextBox tbURL;
    }
}