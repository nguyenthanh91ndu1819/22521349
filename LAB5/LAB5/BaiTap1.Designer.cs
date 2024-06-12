namespace LAB5
{
    partial class BaiTap1
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
            label2 = new Label();
            tbFrom = new TextBox();
            tbTo = new TextBox();
            tbSubject = new TextBox();
            tbBody = new TextBox();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(68, 57);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(213, 57);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 1;
            label1.Text = "From:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(213, 114);
            label2.Name = "label2";
            label2.Size = new Size(28, 20);
            label2.TabIndex = 2;
            label2.Text = "To:";
            // 
            // tbFrom
            // 
            tbFrom.Location = new Point(265, 59);
            tbFrom.Name = "tbFrom";
            tbFrom.Size = new Size(354, 27);
            tbFrom.TabIndex = 3;
            tbFrom.Text = "chessmasterresetpass@gmail.com";
            // 
            // tbTo
            // 
            tbTo.Location = new Point(265, 114);
            tbTo.Name = "tbTo";
            tbTo.Size = new Size(354, 27);
            tbTo.TabIndex = 4;
            tbTo.Text = "22521349@gm.uit.edu.vn";
            // 
            // tbSubject
            // 
            tbSubject.Location = new Point(213, 165);
            tbSubject.Name = "tbSubject";
            tbSubject.Size = new Size(502, 27);
            tbSubject.TabIndex = 5;
            tbSubject.Text = "LAB5";
            // 
            // tbBody
            // 
            tbBody.Location = new Point(213, 198);
            tbBody.Multiline = true;
            tbBody.Name = "tbBody";
            tbBody.Size = new Size(502, 280);
            tbBody.TabIndex = 6;
            tbBody.Text = "Hello";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(100, 165);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 7;
            label3.Text = "Subject:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(100, 201);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 8;
            label4.Text = "Body:";
            // 
            // BaiTap1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(809, 490);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(tbBody);
            Controls.Add(tbSubject);
            Controls.Add(tbTo);
            Controls.Add(tbFrom);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "BaiTap1";
            Text = "BaiTap1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private TextBox tbFrom;
        private TextBox tbTo;
        private TextBox tbSubject;
        private TextBox tbBody;
        private Label label3;
        private Label label4;
    }
}