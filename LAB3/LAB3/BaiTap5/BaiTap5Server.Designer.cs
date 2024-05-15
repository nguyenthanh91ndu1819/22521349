namespace LAB3
{
    partial class BaiTap5Server
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
            btnListen = new Button();
            treeView1 = new TreeView();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(146, 73);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 0;
            // 
            // btnListen
            // 
            btnListen.Location = new Point(639, 38);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(94, 29);
            btnListen.TabIndex = 1;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += btnListen_Click;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(55, 194);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(395, 218);
            treeView1.TabIndex = 2;
            treeView1.NodeMouseDoubleClick += treeView1_NodeMouseDoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(55, 128);
            label2.Name = "label2";
            label2.Size = new Size(648, 38);
            label2.TabIndex = 3;
            label2.Text = "Danh sách món ăn được đóng góp hoặc có sẵn: ";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(539, 194);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(240, 218);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // BaiTap5Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(treeView1);
            Controls.Add(btnListen);
            Controls.Add(label1);
            Name = "BaiTap5Server";
            Text = "BaiTap5Server";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnListen;
        private TreeView treeView1;
        private Label label2;
        private PictureBox pictureBox1;
    }
}