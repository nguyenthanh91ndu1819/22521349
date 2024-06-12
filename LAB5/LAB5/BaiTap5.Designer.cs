namespace LAB5
{
    partial class BaiTap5
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
            btnConnect = new Button();
            txtResult = new TextBox();
            treeView1 = new TreeView();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(104, 97);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(149, 29);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Download mail";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(47, 189);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(287, 249);
            txtResult.TabIndex = 1;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(361, 43);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(404, 357);
            treeView1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(819, 203);
            button1.Name = "button1";
            button1.Size = new Size(174, 29);
            button1.TabIndex = 3;
            button1.Text = "Tìm ngẫu nhiên";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1039, 77);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(226, 27);
            textBox1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(844, 84);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 5;
            label1.Text = "Món ăn hôm nay là ";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaptionText;
            pictureBox1.Location = new Point(1039, 157);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(322, 281);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // BaiTap5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1395, 450);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(treeView1);
            Controls.Add(txtResult);
            Controls.Add(btnConnect);
            Name = "BaiTap5";
            Text = "BaiTap5";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConnect;
        private TextBox txtResult;
        private TreeView treeView1;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private PictureBox pictureBox1;
    }
}