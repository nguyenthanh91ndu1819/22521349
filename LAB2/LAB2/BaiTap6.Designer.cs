﻿namespace LAB2
{
    partial class BaiTap6
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
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(52, 54);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(404, 357);
            treeView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(573, 206);
            button1.Name = "button1";
            button1.Size = new Size(174, 29);
            button1.TabIndex = 1;
            button1.Text = "Tìm ngẫu nhiên";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(689, 81);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 2;
            label1.Text = "Món ăn hôm nay là ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(866, 78);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(226, 27);
            textBox1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaptionText;
            pictureBox1.Location = new Point(838, 169);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(322, 281);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // BaiTap6
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1248, 566);
            Controls.Add(pictureBox1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(treeView1);
            Name = "BaiTap6";
            Text = "BaiTap6";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeView1;
        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private PictureBox pictureBox1;
    }
}