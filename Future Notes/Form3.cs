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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2R3NLJU;Initial Catalog=notes;Integrated Security=True;Encrypt=False");
        public void List_now(DataGridView dataGridView)
        {
            conn.Open();
            string bring = "SELECT * FROM future where display_date = @today";// bugünün tarihinde olan notları getirmeyi sağlayan kod

            SqlCommand cmd = new SqlCommand(bring, conn);
            cmd.Parameters.AddWithValue("@today", DateTime.Today);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            conn.Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            List_now(dataGridView1);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();//formu kapatır .

        }
    }
}
