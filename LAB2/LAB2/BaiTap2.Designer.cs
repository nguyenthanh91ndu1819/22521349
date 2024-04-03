namespace LAB2
{
    partial class BaiTap2
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
            label1 = new Label();
            textBox1 = new TextBox();
            richTextBox1 = new RichTextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label6 = new Label();
            textBox6 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(26, 12);
            button1.Name = "button1";
            button1.Size = new Size(245, 29);
            button1.TabIndex = 0;
            button1.Text = "Read from File";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 83);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 1;
            label1.Text = "File name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(168, 80);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(190, 27);
            textBox1.TabIndex = 2;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(473, 80);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(286, 351);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 131);
            label2.Name = "label2";
            label2.Size = new Size(36, 20);
            label2.TabIndex = 4;
            label2.Text = "Size";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 188);
            label3.Name = "label3";
            label3.Size = new Size(35, 20);
            label3.TabIndex = 5;
            label3.Text = "URL";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 250);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 6;
            label4.Text = "Line count";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 311);
            label5.Name = "label5";
            label5.Size = new Size(88, 20);
            label5.TabIndex = 7;
            label5.Text = "Word Count";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(168, 131);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(190, 27);
            textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(168, 188);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(190, 27);
            textBox3.TabIndex = 9;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(168, 243);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(190, 27);
            textBox4.TabIndex = 10;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(168, 311);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(190, 27);
            textBox5.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 370);
            label6.Name = "label6";
            label6.Size = new Size(115, 20);
            label6.TabIndex = 12;
            label6.Text = "Character Count";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(168, 370);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(190, 27);
            textBox6.TabIndex = 13;
            // 
            // BaiTap2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox6);
            Controls.Add(label6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(richTextBox1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "BaiTap2";
            Text = "BaiTap2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private RichTextBox richTextBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label6;
        private TextBox textBox6;
    }
}