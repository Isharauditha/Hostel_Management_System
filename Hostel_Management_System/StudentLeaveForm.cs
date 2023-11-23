using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management_System
{
    public partial class StudentLeaveForm : Form
    {
        private Timer refresh = new Timer();

        public StudentLeaveForm()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            refresh.Interval = 2000; 
            refresh.Tick += RefreshTimer_Tick;
            refresh.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            AllStudentsRecords();
        }
        
        private void StudentLeaveForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(290, 230);
            AllStudentsRecords();
        }

        private void AllStudentsRecords()
        {
            string query = "SELECT * FROM StudentLeave_table";

            SqlConnection conn = connection.CreateDBConnection();
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        DatabaseConnection connection = new DatabaseConnection();

        private string search_query = "SELECT Student_name FROM StudentTable WHERE Student_id = @Student_id";
        private string insert_query = "INSERT INTO StudentLeave_table VALUES (@Student_id, @Student_name, @Purpose, @Leave_time, @Arrival_time)";
        private string update_query = "UPDATE StudentLeave_table SET Arrival_time = @Arrival_time WHERE Student_id = @Student_id";

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idTxt.Text))
            {
                MessageBox.Show("Please enter a Student ID.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(idTxt.Text, out int studentId))
            {
                MessageBox.Show("Invalid Student ID. Please enter a valid integer.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            SqlConnection conn = connection.CreateDBConnection();
            SqlCommand cmd = new SqlCommand(search_query, conn);

            cmd.Parameters.AddWithValue("@Student_id", int.Parse(idTxt.Text));

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    nameTxt.Text = reader["Student_name"].ToString();
                }
                else
                {
                    MessageBox.Show("Student ID not found.", "Not Found", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idTxt.Text) || string.IsNullOrEmpty(dateTimePicker3.Value.ToString()))
            {
                MessageBox.Show("Please enter Student ID and Arrival Time.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(idTxt.Text, out int studentId) || !DateTime.TryParse(dateTimePicker3.Value.ToString(), out DateTime arrivalTime))
            {
                MessageBox.Show("Invalid Student ID or Arrival Time. Please enter valid values.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            SqlConnection conn = connection.CreateDBConnection();
            SqlCommand cmd = new SqlCommand(insert_query, conn);

            cmd.Parameters.AddWithValue("@Student_id", idTxt.Text);
            cmd.Parameters.AddWithValue("@Student_name", nameTxt.Text);
            cmd.Parameters.AddWithValue("@Purpose", purposeTxt.Text);
            cmd.Parameters.AddWithValue("@Leave_time", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Arrival_time", dateTimePicker3.Value);

            try
            {
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Done!", "Done", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    idTxt.Clear();
                    nameTxt.Clear();
                    purposeTxt.Clear();
                }
                else
                {
                    MessageBox.Show("Error!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idTxt.Text) || string.IsNullOrEmpty(dateTimePicker3.Value.ToString()))
            {
                MessageBox.Show("Please enter Student ID and Arrival Time.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(idTxt.Text, out int studentId) || !DateTime.TryParse(dateTimePicker3.Value.ToString(), out DateTime arrivalTime))
            {
                MessageBox.Show("Invalid Student ID or Arrival Time. Please enter valid values.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            SqlConnection conn = connection.CreateDBConnection();
            SqlCommand cmd = new SqlCommand(update_query, conn);

            cmd.Parameters.AddWithValue("@Student_id", idTxt.Text);
            cmd.Parameters.AddWithValue("@Student_name", nameTxt.Text);
            cmd.Parameters.AddWithValue("@Arrival_time", dateTimePicker3.Value);

            try
            {
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Done!", "Done", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    idTxt.Clear();
                    nameTxt.Clear();
                    purposeTxt.Clear();
                }
                else
                {
                    MessageBox.Show("Error!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
