
using System.Data.SqlClient;
namespace Group_Assignment2
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shivansh\Documents\StudentRegister.mdf;Integrated Security=True;Connect Timeout=30");
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            textBox2.PasswordChar = '*';
            textBox1.MaxLength = 14;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Error ");
            }
            else
            {


                
                conn.Open();


                string sql1 = $"SELECT username from [Table] where username={textBox1.Text} AND password={textBox2.Text} ";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.ExecuteNonQuery();
                using (SqlDataReader reader = cmd1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        
                        MessageBox.Show("Logged In");
                       
                        new Form3(textBox1.Text).Show();
                        this.Hide();
                        conn.Close();

                    }
                    else
                    {
                        MessageBox.Show("Credentials dont match");
                        conn.Close();
                    }
                }


                

            }    
        }
    }
}