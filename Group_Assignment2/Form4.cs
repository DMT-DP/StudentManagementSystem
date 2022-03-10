using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Group_Assignment2
{
    public partial class Form4 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shivansh\Documents\StudentRegister.mdf;Integrated Security=True;Connect Timeout=30");

        string user;
        string address;
        string email;
        string contact;

        public Form4(string username)
        {
            user = username;
            InitializeComponent();

            conn.Open();


            string sql1 = $"SELECT * from [Table] where username={user} ";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            cmd1.ExecuteNonQuery();
            using (SqlDataReader reader = cmd1.ExecuteReader())
            {
                if (reader.Read())
                {
                    ReadSingleRow((IDataRecord)reader);


                }



            }
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();


            string sql1 = $"UPDATE [Table] SET address = '{textBox1.Text}', email = '{textBox2.Text}', contact = '{textBox3.Text}' where username={user} ";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            cmd1.ExecuteNonQuery();
            
            MessageBox.Show("Data Edited");
            conn.Close();
            new Form3(user).Show();
            this.Hide();
        }


        private void ReadSingleRow(IDataRecord dataRecord)
        {
            textBox1.Text = dataRecord[4].ToString();
            textBox2.Text = dataRecord[5].ToString();
            textBox3.Text = dataRecord[6].ToString();
            

        }
        private void button2_Click(object sender, EventArgs e)
        {

            new Form3(user).Show();
            this.Hide();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
