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

namespace Hostel_Management_System
{
    public partial class EmployeeRecordsForm : Form
    {
        public EmployeeRecordsForm()
        {
            InitializeComponent();
        }
        
        private SqlConnection ConnectDB()
        {
            SqlConnection conn = new SqlConnection("Data Source=isharaPC\\SQLEXPRESS;Initial Catalog=HostelDB;Integrated Security=True");
            conn.Open();
            return conn;
        }

        private void EmployeeRecordsForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(450, 200);

            string query = "SELECT * FROM employee_table";

            SqlConnection conn = ConnectDB();
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();

            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM employee_table WHERE Employee_id = @Employee_id";

            SqlConnection conn = ConnectDB();
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                cmd.Parameters.AddWithValue("@Employee_id", int.Parse(textBox1.Text));

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                adapter.Fill(dt);

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
                MessageBox.Show("Error", ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
