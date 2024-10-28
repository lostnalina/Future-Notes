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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2R3NLJU;Initial Catalog=notes;Integrated Security=True;Encrypt=False");
        public void List(DataGridView dataGridView)
        {
            conn.Open();
            string bring = "SELECT * FROM future";
            SqlCommand cmd = new SqlCommand(bring, conn);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            conn.Close();
        }
        public void List_past(DataGridView dataGridView)
        {
            conn.Open();
            string bring = "SELECT * FROM future where display_date < @today";

            SqlCommand cmd = new SqlCommand(bring, conn);
            cmd.Parameters.AddWithValue("@today", DateTime.Now.Date);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            conn.Close();
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List(dataGridView2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List_past(dataGridView1);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
