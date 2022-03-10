using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Group_Assignment2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.PasswordChar = '*';
            textBox4.MaxLength = 14;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean first_data = false;
            string fname = textBox1.Text;
            string lname =textBox2.Text;
            string username = textBox3.Text;
            string password = textBox4.Text;
            List<Student> students = new List<Student>();
            string file_path = @"D:\Georgian Data\BDAT PROGRAMMING\Group Assignment 2\Group_Assignment2\Group_Assignment2\DBFiles\Register.json";

            if (File.Exists(file_path))
            {
                string read = File.ReadAllText(file_path);
                if (read == "")
                {
                    first_data = true;
                }
               
                if (!first_data)
                {
                    var data_read = JsonConvert.DeserializeObject<List<Student>>(read);
                    
                    foreach (var data in data_read)
                    {
                        students.Append(data);
                        if (data.RollNum == username)
                        {
                            MessageBox.Show("Username already exists");
                        }
                    }
                }

            }

            Student student = new Student()
            {
                Id= 1,
                FirstName = fname,
                LastName = lname,
                RollNum = username,
                Password = password
            };

            students.Append(student);
            MessageBox.Show(students.ToString());
            MessageBox.Show(student.ToString() );
            string result = JsonConvert.SerializeObject(students);
            
            File.WriteAllText(file_path, result);
            
            





            new Form1().Show();
            this.Hide();
        }
    }
}
