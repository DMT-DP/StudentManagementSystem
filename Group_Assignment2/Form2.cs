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
using System.Data.SqlClient;

namespace Group_Assignment2
{
    public partial class Form2 : Form
    {
        SqlConnection conn =new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shivansh\Documents\StudentRegister.mdf;Integrated Security=True;Connect Timeout=30") ;
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
            Boolean exists = false;
            string fname = textBox1.Text;
            string lname =textBox2.Text;
            string username = textBox3.Text;
            string password = textBox4.Text;

            conn.Open();


            string sql1 = $"SELECT username from [Table] where username={username}";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            cmd1.ExecuteNonQuery();
            using (SqlDataReader reader = cmd1.ExecuteReader())
            {
                if (reader.Read())
                {
                    exists = true;
                    MessageBox.Show("Already Exists");
                }
            }


            if (!exists)
            {


                string sql = "INSERT INTO [Table] VALUES(@param1,@param2,@param3,@param4,'','','')";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@param1", SqlDbType.VarChar,50).Value = username;
                    cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = fname;
                    cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = lname;
                    cmd.Parameters.Add("@param4", SqlDbType.VarChar, 50).Value = password;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Registered ");



                new Form1().Show();
                this.Hide();

            }    
        }
    }
}
