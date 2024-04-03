using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LAB2
{
    public partial class BaiTap3 : Form
    {
        public BaiTap3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.Title = "Select a Text File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string[] lines = File.ReadAllLines(filePath);
                List<string> results = new List<string>();

                foreach (string line in lines)
                {
                    string trimmedLine = line.Trim();
                    if (!string.IsNullOrWhiteSpace(trimmedLine))
                    {
                        try
                        {
                            double result = EvaluateExpression(trimmedLine);
                            results.Add($"{trimmedLine} = {result}");
                        }
                        catch (Exception ex)
                        {
                            results.Add($"{trimmedLine} : {ex.Message}");
                        }
                    }
                }

                File.WriteAllLines("output3.txt", results);
                MessageBox.Show("File đã được xử lý và kết quả đã được ghi vào file output3.txt");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.Title = "Select a Text File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                richTextBox1.Text = File.ReadAllText(filePath);
            }
        }

        private double EvaluateExpression(string expression)
        {
            // Tạm thời, chúng ta chỉ hỗ trợ một số phép toán cơ bản: +, -, *, /
            char[] operators = { '+', '-', '*', '/' };
            string[] tokens = expression.Split(operators, StringSplitOptions.RemoveEmptyEntries);

            // Kiểm tra xem biểu thức có chứa đủ 2 toán hạng không
            if (tokens.Length != 2)
                throw new InvalidOperationException("Invalid expression: Not enough operands for operator.");

            double operand1, operand2;
            if (!double.TryParse(tokens[0], out operand1) || !double.TryParse(tokens[1], out operand2))
                throw new InvalidOperationException("Invalid expression: Operands are not valid numbers.");

            char operation = expression[tokens[0].Length];
            switch (operation)
            {
                case '+':
                    return operand1 + operand2;
                case '-':
                    return operand1 - operand2;
                case '*':
                    return operand1 * operand2;
                case '/':
                    if (operand2 == 0)
                        throw new InvalidOperationException("Cannot divide by zero.");
                    return operand1 / operand2;
                default:
                    throw new InvalidOperationException("Invalid expression: Unknown operator.");
            }
        }

    }
}
