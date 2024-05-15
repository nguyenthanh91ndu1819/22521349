namespace LAB3
{
    partial class TCPServer
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
            StartListen = new Button();
            listViewCommand = new ListView();
            SuspendLayout();
            // 
            // StartListen
            // 
            StartListen.Location = new Point(651, 46);
            StartListen.Name = "StartListen";
            StartListen.Size = new Size(94, 29);
            StartListen.TabIndex = 0;
            StartListen.Text = "Listen";
            StartListen.UseVisualStyleBackColor = true;
            StartListen.Click += StartListen_Click;
            // 
            // listViewCommand
            // 
            listViewCommand.Location = new Point(51, 125);
            listViewCommand.Name = "listViewCommand";
            listViewCommand.Size = new Size(669, 313);
            listViewCommand.TabIndex = 1;
            listViewCommand.UseCompatibleStateImageBehavior = false;
            // 
            // TCPServer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listViewCommand);
            Controls.Add(StartListen);
            Name = "TCPServer";
            Text = "TCPServer";
            ResumeLayout(false);
        }

        #endregion

        private Button StartListen;
        private ListView listViewCommand;
    }
}