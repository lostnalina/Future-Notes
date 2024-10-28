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

namespace Future_Notes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.MinDate = DateTime.Today;// bu kod bugünden önce tarih seçmemeyi sağlar. Mantıksal hatayı giderir.
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2R3NLJU;Initial Catalog=notes;Integrated Security=True;Encrypt=False");
         private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(conn.State==ConnectionState.Closed)
                {
                    conn.Open();
                    string save = "insert into future(title,message,display_date,create_date) values(@title,@message,@display_date,@create_date)";
                    SqlCommand cmd = new SqlCommand(save, conn);

                    cmd.Parameters.AddWithValue("@title", textBox1.Text);
                    cmd.Parameters.AddWithValue("@message", textBox2.Text);
                    cmd.Parameters.AddWithValue("@display_date",dateTimePicker1.Value );
                    cmd.Parameters.AddWithValue("@create_date",DateTime.Now.Date );
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your message has been saved successfully!");

                    
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("An error was encountered!"+error.Message);
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
    }

}
