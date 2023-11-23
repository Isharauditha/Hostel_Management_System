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

namespace Hostel_Management_System
{
    public partial class StudentRecordsForm : Form
    {
        public StudentRecordsForm()
        {
            InitializeComponent();
        }

        DatabaseConnection connection = new DatabaseConnection();

        private string query = "SELECT * FROM StudentTable WHERE Student_id = @Student_id";

        private void StudentRecordsForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(235, 220);
            AllStudentRecords();
        }

        private void AllStudentRecords()
        {
            string query = "SELECT * FROM StudentTable";

            using (SqlConnection conn = connection.CreateDBConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter a Student ID.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox1.Text, out int studentId))
            {
                MessageBox.Show("Invalid Student ID. Please enter a valid integer.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            } 

            SqlConnection conn = connection.CreateDBConnection();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Student_id", int.Parse(textBox1.Text));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adapter.Fill(dt);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Enabled = false;
                    dataGridView1.RowHeadersVisible = false;

                    /*
                    dataGridView1.Columns[0].Width = 100;
                    dataGridView1.Columns[1].Width = 200;
                    dataGridView1.Columns[2].Width = 200;
 
                     */

                    textBox1.Clear();
                }
                else
                {
                    MessageBox.Show("ID not found!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        } 
    }

}
