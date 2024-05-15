namespace LAB3
{
    partial class BaiTap5Client
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
            txtName = new TextBox();
            txtConnect = new Button();
            treeView1 = new TreeView();
            button1 = new Button();
            tbSelectFromServer = new Button();
            pictureBox1 = new PictureBox();
            txtContribute = new Button();
            label2 = new Label();
            txtMonAn = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(159, 46);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên: ";
            // 
            // txtName
            // 
            txtName.Location = new Point(301, 44);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 1;
            // 
            // txtConnect
            // 
            txtConnect.Location = new Point(586, 46);
            txtConnect.Name = "txtConnect";
            txtConnect.Size = new Size(94, 29);
            txtConnect.TabIndex = 6;
            txtConnect.Text = "Connect";
            txtConnect.UseVisualStyleBackColor = true;
            txtConnect.Click += txtConnect_Click;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(159, 164);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(316, 242);
            treeView1.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(553, 198);
            button1.Name = "button1";
            button1.Size = new Size(158, 29);
            button1.TabIndex = 8;
            button1.Text = "Tìm ngẫu nhiên ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tbSelectFromServer
            // 
            tbSelectFromServer.Location = new Point(553, 292);
            tbSelectFromServer.Name = "tbSelectFromServer";
            tbSelectFromServer.Size = new Size(197, 29);
            tbSelectFromServer.TabIndex = 9;
            tbSelectFromServer.Text = "Tìm ngẫu nhiên từ Server";
            tbSelectFromServer.UseVisualStyleBackColor = true;
            tbSelectFromServer.Click += tbSelectFromServer_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(834, 164);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(249, 228);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // txtContribute
            // 
            txtContribute.Location = new Point(706, 437);
            txtContribute.Name = "txtContribute";
            txtContribute.Size = new Size(197, 29);
            txtContribute.TabIndex = 11;
            txtContribute.Text = "Đóng góp cho server";
            txtContribute.UseVisualStyleBackColor = true;
            txtContribute.Click += txtContribute_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(439, 439);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 12;
            label2.Text = "Tên món ăn";
            // 
            // txtMonAn
            // 
            txtMonAn.Location = new Point(543, 437);
            txtMonAn.Name = "txtMonAn";
            txtMonAn.Size = new Size(137, 27);
            txtMonAn.TabIndex = 13;
            // 
            // BaiTap5Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1168, 486);
            Controls.Add(txtMonAn);
            Controls.Add(label2);
            Controls.Add(txtContribute);
            Controls.Add(pictureBox1);
            Controls.Add(tbSelectFromServer);
            Controls.Add(button1);
            Controls.Add(treeView1);
            Controls.Add(txtConnect);
            Controls.Add(txtName);
            Controls.Add(label1);
            Name = "BaiTap5Client";
            Text = "BaiTap5Client";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private Button txtConnect;
        private TreeView treeView1;
        private Button button1;
        private Button tbSelectFromServer;
        private PictureBox pictureBox1;
        private Button txtContribute;
        private Label label2;
        private TextBox txtMonAn;
    }
}