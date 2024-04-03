namespace LAB2
{
    partial class BaiTap7
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
            treeView1 = new TreeView();
            richTextBox1 = new RichTextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(45, 64);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(368, 414);
            treeView1.TabIndex = 0;
            treeView1.NodeMouseClick += TreeView1_NodeMouseClick;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(526, 77);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(284, 144);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlLightLight;
            pictureBox1.Location = new Point(526, 286);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(391, 311);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // BaiTap7
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1025, 609);
            Controls.Add(pictureBox1);
            Controls.Add(richTextBox1);
            Controls.Add(treeView1);
            Name = "BaiTap7";
            ShowIcon = false;
            Text = "BaiTap7";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView1;
        private RichTextBox richTextBox1;
        private PictureBox pictureBox1;
    }
}