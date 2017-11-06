using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAS_STATION
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Confirmed my details", "Guy: Confirm", MessageBoxButtons.YesNo);
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            csb.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\fatex\source\repos\GAS_STATION\GAS_STATION\db_rtp.mdf; Integrated Security = True; Connect Timeout = 30";

            using (SqlConnection conn = new SqlConnection(csb.ConnectionString))
            {
                conn.Open();

                String query = "INSERT INTO dbo.pump ([name], [station], [city], [state], managed, platform) " +
               "VALUES (@Open, @Donnia, @Macauley, @Anita, @Play, @Cree);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@Open", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Donnia", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Macauley", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Anita", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Play", comboBox1.SelectedIndex);
                    cmd.Parameters.AddWithValue("@Cree", comboBox2.SelectedIndex);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Pump Info Registered Successfully", "Guy:Status Bar");

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_rtpDataSet1.managed1' table. You can move, or remove it, as needed.
            this.managed1TableAdapter.Fill(this.db_rtpDataSet1.managed1);
            // TODO: This line of code loads data into the 'db_rtpDataSet1.platform' table. You can move, or remove it, as needed.
            this.platformTableAdapter.Fill(this.db_rtpDataSet1.platform);
            btnAddNew.Enabled = false;
            panel2.Visible = false;
            panel1.Visible = true;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            btnAddNew.Enabled = true;
            btnView.Enabled = false;
            panel2.Visible = true;
            // TODO: This line of code loads data into the 'db_rtpDataSet1.DataTable1' table. You can move, or remove it, as needed.
            this.dataTable1TableAdapter.Fill(this.db_rtpDataSet1.DataTable1);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
            btnView.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
