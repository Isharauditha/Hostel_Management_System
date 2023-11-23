using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Hostel_Management_System
{
    public partial class StudentFeesForm : Form
    {
        public StudentFeesForm()
        {
            InitializeComponent();
        }

        private void StudentFeesForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(480,190);
        }

        DatabaseConnection connection = new DatabaseConnection();

        private string search_query = "SELECT * FROM payment_table WHERE Student_id = @Student_id";
        private string query = "INSERT INTO payment_table VALUES (@Student_id, @Student_name, @Email, @Date, @Amount)";

        public void ClearText()
        {
            studentIdTxt.Clear();
            nameTxt.Clear();
            emailTxt.Clear();
            amountTxt.Clear();
            dataGridView1.DataSource = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(studentIdTxt.Text))
            {
                MessageBox.Show("Please enter a Student ID.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(studentIdTxt.Text, out int studentId))
            {
                MessageBox.Show("Invalid Student ID. Please enter a valid integer.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            SqlConnection conn = connection.CreateDBConnection();
            SqlCommand cmd = new SqlCommand(search_query, conn);

            cmd.Parameters.AddWithValue("@Student_id", int.Parse(studentIdTxt.Text));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    nameTxt.Text = reader["Student_name"].ToString();
                    emailTxt.Text = reader["Email"].ToString();
                }
                else
                {
                    MessageBox.Show("Student ID not found.", "Not Found", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Enabled = false;
                    dataGridView1.RowHeadersVisible = false;

                    dataGridView1.FirstDisplayedScrollingRowIndex = 1;

                    /*
                    dataGridView1.Columns[0].Width = 130;
                    dataGridView1.Columns[1].Width = 230;
                    dataGridView1.Columns[2].Width = 230;
                     */
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

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(studentIdTxt.Text) || string.IsNullOrEmpty(amountTxt.Text))
            {
                MessageBox.Show("Please enter Student ID and Amount.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(studentIdTxt.Text, out int studentId) || !decimal.TryParse(amountTxt.Text, out decimal amount))
            {
                MessageBox.Show("Invalid Student ID or Amount. Please enter valid values.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            SqlConnection conn = connection.CreateDBConnection();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Student_id", studentIdTxt.Text);
            cmd.Parameters.AddWithValue("@Student_name", nameTxt.Text);
            cmd.Parameters.AddWithValue("@Email", emailTxt.Text);
            cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy/MM/dd"));
            cmd.Parameters.AddWithValue("@Amount", amountTxt.Text);

            try
            {
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Payment Success!", "Done", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Payment Failed!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void btnRecepit_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("PAID", new Font("Arial", 40, FontStyle.Bold), Brushes.Black, new Point(350, 100));
            e.Graphics.DrawString("Student Id: " + int.Parse(studentIdTxt.Text).ToString(), new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(300, 200));
            e.Graphics.DrawString("Student Name: " + nameTxt.Text.ToString(), new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(300, 250));
            e.Graphics.DrawString("Email: " + emailTxt.Text.ToString(), new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(300, 300));
            e.Graphics.DrawString("Payment Date: " + dateTimePicker1.Value.ToString("yyyy/MM/dd"), new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(300, 350));
            e.Graphics.DrawString("Amount: Rs." + int.Parse(amountTxt.Text).ToString() + ".00", new Font("Arial", 25, FontStyle.Bold), Brushes.Black, new Point(300, 400));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
