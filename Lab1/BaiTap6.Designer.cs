namespace Lab1
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
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(360, 186);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Tìm cung";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(89, 91);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(360, 94);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(647, 92);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(266, 295);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(271, 27);
            textBox4.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(2, 94);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 5;
            label1.Text = "Nhập ngày";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(266, 94);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 6;
            label2.Text = "Nhập tháng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(569, 98);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 7;
            label3.Text = "Nhập năm";
            // 
            // BaiTh6
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "BaiTh6";
            Text = "BaiTh6";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}