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
    public partial class Form3 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shivansh\Documents\StudentRegister.mdf;Integrated Security=True;Connect Timeout=30");

        string user;
        
        public Form3(string username)
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
        }

        private  void ReadSingleRow(IDataRecord dataRecord)
        {
            textBox1.Text = dataRecord[1].ToString();

            textBox2.Text = dataRecord[2].ToString();
            textBox3.Text = dataRecord[4].ToString();
            textBox4.Text = dataRecord[5].ToString();
            textBox5.Text = dataRecord[6].ToString();

        }

        
        
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new Form4(user).Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
