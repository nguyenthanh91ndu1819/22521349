﻿namespace LAB6
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
            button2 = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(327, 246);
            button2.Name = "button2";
            button2.Size = new Size(146, 29);
            button2.TabIndex = 3;
            button2.Text = "Client";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(327, 175);
            button1.Name = "button1";
            button1.Size = new Size(146, 29);
            button1.TabIndex = 2;
            button1.Text = "Server";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // BaiTap3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "BaiTap3";
            Text = "BaiTap3";
            ResumeLayout(false);
        }

        #endregion

        private Button button2;
        private Button button1;
    }
}