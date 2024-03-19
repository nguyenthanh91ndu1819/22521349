namespace Lab1
{
    partial class BaiTh4
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
            checkedListBox1 = new CheckedListBox();
            comboBox1 = new ComboBox();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            comboBox2 = new ComboBox();
            label4 = new Label();
            comboBox3 = new ComboBox();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(12, 268);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(343, 180);
            checkedListBox1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(226, 126);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(125, 28);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 55);
            label1.Name = "label1";
            label1.Size = new Size(188, 20);
            label1.TabIndex = 2;
            label1.Text = "Nhập thông tin khách hàng";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(226, 55);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 134);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 4;
            label2.Text = "Chọn phim";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 196);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 5;
            label3.Text = "Chọn ghế";
            // 
            // button1
            // 
            button1.Location = new Point(538, 55);
            button1.Name = "button1";
            button1.Size = new Size(138, 36);
            button1.TabIndex = 7;
            button1.Text = "Chọn";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(226, 188);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(129, 28);
            comboBox2.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 235);
            label4.Name = "label4";
            label4.Size = new Size(108, 20);
            label4.TabIndex = 9;
            label4.Text = "Chọn rạp chiếu";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(226, 234);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(125, 28);
            comboBox3.TabIndex = 10;
            // 
            // button2
            // 
            button2.Location = new Point(546, 140);
            button2.Name = "button2";
            button2.Size = new Size(130, 29);
            button2.TabIndex = 11;
            button2.Text = "Mua";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(546, 215);
            button3.Name = "button3";
            button3.Size = new Size(130, 29);
            button3.TabIndex = 12;
            button3.Text = "Xuất hóa đơn";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // BaiTh4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(comboBox3);
            Controls.Add(label4);
            Controls.Add(comboBox2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(checkedListBox1);
            Name = "BaiTh4";
            Text = "BaiTh4";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedListBox1;
        private ComboBox comboBox1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private Button button1;
        private ComboBox comboBox2;
        private Label label4;
        private ComboBox comboBox3;
        private Button button2;
        private Button button3;
    }
}