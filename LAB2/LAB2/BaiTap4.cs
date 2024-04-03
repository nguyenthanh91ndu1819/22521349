using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LAB2
{
    public partial class BaiTap4 : Form
    {
        private List<Person> people = new List<Person>();

        public BaiTap4()
        {
            InitializeComponent();
        }

        class Person
        {
            public string Name { get; set; }
            public long ID { get; set; }
            public long Phone { get; set; }
            public float Course1 { get; set; }
            public float Course2 { get; set; }
            public float Course3 { get; set; }
            public float Average { get; set; }

            public Person(string name, long id, long phone, float course1, float course2, float course3)
            {
                Name = name;
                ID = id;
                Phone = phone;
                Course1 = course1;
                Course2 = course2;
                Course3 = course3;
                Average = 0;
            }

            public override string ToString()
            {
                return $"Name: {Name}\nID: {ID}\nPhone: {Phone}\nCourse1: {Course1}\nCourse2: {Course2}\nCourse3: {Course3}\nAverage: {Average}";
            }
        };

        static void SerializeToFileJson(string filePath, List<Person> people)
        {
            try
            {
                string json = JsonSerializer.Serialize(people);
                File.WriteAllText(filePath, json);
                Console.WriteLine($"Serialized data successfully written to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while serializing data: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                long id = Convert.ToInt64(textBox2.Text);
                long phone = Convert.ToInt64(textBox3.Text);
                float course1 = float.Parse(textBox4.Text);
                float course2 = float.Parse(textBox5.Text);
                float course3 = float.Parse(textBox6.Text);
                float average = 0;
                textBox7.Text = average.ToString(); 
                Person person = new Person(name, id, phone, course1, course2, course3);
                people.Add(person);
                DisplayPerson(person);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm người: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayPerson(Person person)
        {
            // Hiển thị thông tin của Person trong RichTextBox
            richTextBox1.AppendText(person.ToString() + "\n\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();

            // Kiểm tra xem người dùng đã chọn tệp hay chưa
            if (!string.IsNullOrEmpty(ofd.FileName))
            {
                // Lấy đường dẫn của file được chọn
                string inputFilePath = ofd.FileName;

                try
                {
                    // Ghi dữ liệu từ RichTextBox vào file được chọn
                    File.WriteAllText(inputFilePath, richTextBox1.Text);
                    MessageBox.Show("Data successfully written to input file.");

                    // Ghi dữ liệu từ input4 vào output4
                    string outputFilePath = "output4.txt"; // Đường dẫn file output4
                    File.WriteAllText(outputFilePath, File.ReadAllText(inputFilePath));
                    MessageBox.Show("Data successfully written to output file.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred while writing data to file: {ex.Message}");
                }
            }
        }

        private int currentPage = 1;
        private int totalPages = 1;
        private int startPage = 1;

        private void AddPersonFromData(List<string> personData)
        {
            if (personData.Count == 7)
            {
                string[] parts = personData.ToArray();
                string name = GetValue(parts, 0);
                long id = GetLongValue(parts, 1);
                long phone = GetLongValue(parts, 2);
                float course1 = GetFloatValue(parts, 3);
                float course2 = GetFloatValue(parts, 4);
                float course3 = GetFloatValue(parts, 5);
          
                float average = course1 + course2 + course3;
                if (float.TryParse(parts[6].Substring(parts[6].IndexOf(':') + 1).Trim(), out average))
                {
                    Person person = new Person(name, id, phone, course1, course2, course3);
                    person.Average = average;
                    people.Add(person);
                }
                else
                {
                    
                    MessageBox.Show("Invalid average value. Using default 0.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    average = 0;
                    Person person = new Person(name, id, phone, course1, course2, course3);
                    person.Average = average;
                    people.Add(person);
                }
            }
            else
            {
                MessageBox.Show("Invalid data format for a Person object.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetValue(string[] parts, int index)
        {
            if (index < parts.Length)
            {
                return parts[index].Substring(parts[index].IndexOf(':') + 1).Trim();
            }
            else
            {
                MessageBox.Show($"Index {index} is outside the bound of array.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private long GetLongValue(string[] parts, int index)
        {
            if (index < parts.Length)
            {
                long value;
                if (long.TryParse(parts[index].Substring(parts[index].IndexOf(':') + 1).Trim(), out value))
                {
                    return value;
                }
                else
                {
                    MessageBox.Show($"Value is not in correct format for field: {parts[index]}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            else
            {
                MessageBox.Show($"Index {index} is outside the bound of array.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private float GetFloatValue(string[] parts, int index)
        {
            if (index < parts.Length)
            {
                float value;
                if (float.TryParse(parts[index].Substring(parts[index].IndexOf(':') + 1).Trim(), out value))
                {
                    return value;
                }
                else
                {
                    MessageBox.Show($"Value is not in correct format for field: {parts[index]}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            else
            {
                MessageBox.Show($"Index {index} is outside the bound of array.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }



        private void DisplayPage(int page)
        {
            
            if (page > 0 && page <= people.Count)
            {
                Person person = people[page - 1]; 
                richTextBox1.Clear(); 
                richTextBox1.AppendText(person.ToString() + "\n\n");
                textBox15.Text = $"{currentPage}/{totalPages}";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    people.Clear();
                    string[] fileLines = File.ReadAllLines(ofd.FileName);
                    List<string> personData = new List<string>();

                    foreach (string line in fileLines)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            if (personData.Count >= 7)
                            {
                                AddPersonFromData(personData);
                                personData.Clear();
                            }
                        }
                        else
                        {
                            personData.Add(line);
                        }
                    }

                    if (personData.Count >= 7)
                    {
                        AddPersonFromData(personData);
                    }

                    totalPages = people.Count; 
                    currentPage = 1;
                    if (people.Count > 0)
                    {
                        SetTextBoxValues(people[currentPage - 1]); 
                    }
                    else
                    {
                        MessageBox.Show("Du lieu ban nhap vao chu du","Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Co loi xay ra:  {ex.Message}");
                }
            }
        }


        private void SetTextBoxValues(Person person)
        {
            textBox8.Text = person.Name;
            textBox9.Text = person.ID.ToString();
            textBox10.Text = person.Phone.ToString();
            textBox11.Text = person.Course1.ToString();
            textBox12.Text = person.Course2.ToString();
            textBox13.Text = person.Course3.ToString();
            float average = (person.Course1 + person.Course2 + person.Course3) / 3;
            textBox14.Text = average.ToString();
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            if (currentPage > 1) 
            {
                currentPage--;
                DisplayPage(currentPage); 
                SetTextBoxValues(people[currentPage - 1]); 
                UpdatePageNumber(); 
            }
        }


        private void nextButton_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                DisplayPage(currentPage); 
                SetTextBoxValues(people[currentPage - 1]);
                UpdatePageNumber(); 
            }
        }
        private void UpdatePageNumber()
        {
            textBox15.Text = $"{currentPage}/{totalPages}";
        }
    }
}
