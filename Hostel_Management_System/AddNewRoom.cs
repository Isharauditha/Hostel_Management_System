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
    public partial class AddNewRoom : Form
    {
        private Timer refresh = new Timer();

        public AddNewRoom()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            refresh.Interval = 10000;
            refresh.Tick += RefreshTimer_Tick;
            refresh.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            AllRoomRecords();
        }

        private void AddNewRoom_Load(object sender, EventArgs e)
        {
            this.Location = new Point(530, 220);
            AllRoomRecords();
        }

        private void AllRoomRecords()
        {
            string query = "SELECT * FROM room_table";

            SqlConnection conn = connection.CreateDBConnection();
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].Width = 130;
            dataGridView1.Columns[1].Width = 230;
            dataGridView1.Columns[2].Width = 230;
        }

        DatabaseConnection connection = new DatabaseConnection();

        private string insert_query = "INSERT INTO room_table VALUES (@Room_no, @Available, @Booked)";
        private string update_query = "UPDATE room_table SET available = @Available, Booked = @Booked WHERE Room_no = @Room_no";
        private string delete_query = "DELETE FROM room_table WHERE Room_no = @Room_no";
        private string search_query = "SELECT * FROM room_table WHERE Room_no = @Room_no";

        private string availableStatus;
        private string bookStatus;

        private void CheckStatus1()
        {
            if (available.Checked && book.Checked)
            {
                availableStatus = "No";
                bookStatus = "Yes";
            }
            else if (available.Checked)
            {
                availableStatus = "Yes";
                bookStatus = "No";
            }
            else if (book.Checked)
            {
                availableStatus = "No";
                bookStatus = "Yes";
            }
            else
            {
                availableStatus = "No";
                bookStatus = "No";
            }
        }

        private void CheckStatus2()
        {
            if (available2.Checked && book2.Checked)
            {
                availableStatus = "No";
                bookStatus = "Yes";
            }
            else if (available2.Checked)
            {
                availableStatus = "Yes";
                bookStatus = "No";
            }
            else if (book2.Checked)
            {
                availableStatus = "No";
                bookStatus = "Yes";
            }
            else
            {
                availableStatus = "No";
                bookStatus = "No";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CheckStatus1();
            
            if (roomNoTxt.Text.Equals(null))
            {
                MessageBox.Show("Please Enter room no", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            SqlConnection conn = connection.CreateDBConnection();
            SqlCommand cmd = new SqlCommand(insert_query, conn);

            cmd.Parameters.AddWithValue("@Room_no", int.Parse(roomNoTxt.Text));
            cmd.Parameters.AddWithValue("@Available", availableStatus);
            cmd.Parameters.AddWithValue("@Booked", bookStatus);

            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Room Added!", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    roomNoTxt.Clear();
                    available.Checked = false;
                    book.Checked = false;
                }
                else
                {
                    MessageBox.Show("Failed!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.CreateDBConnection();
            SqlCommand cmd = new SqlCommand(search_query, conn);

            cmd.Parameters.AddWithValue("@Room_no", int.Parse(roomNotxt2.Text));

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

                    dataGridView1.Columns[0].Width = 130;
                    dataGridView1.Columns[1].Width = 230;
                    dataGridView1.Columns[2].Width = 230;
                }
                else
                {
                    MessageBox.Show("Room No not found!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CheckStatus2();

            SqlConnection conn = connection.CreateDBConnection();
            SqlCommand cmd = new SqlCommand(update_query, conn);

            cmd.Parameters.AddWithValue("@Room_no", int.Parse(roomNotxt2.Text));
            cmd.Parameters.AddWithValue("@Available", availableStatus);
            cmd.Parameters.AddWithValue("@Booked", bookStatus);

            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Successfully Updated!", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Update Failed!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.CreateDBConnection();
            SqlCommand cmd = new SqlCommand(delete_query, conn);

            cmd.Parameters.AddWithValue("@Room_no", int.Parse(roomNotxt2.Text));

            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Successfully Deleted!", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
