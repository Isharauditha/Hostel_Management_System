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
    public partial class Update_Delete_EmployeeForm : Form
    {
        public Update_Delete_EmployeeForm()
        {
            InitializeComponent();
        }

        private void Update_Delete_EmployeeForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(550, 220);
        }

        DatabaseConnection connection = new DatabaseConnection();

        private string search_query = "SELECT * FROM employee_table WHERE Employee_id = @Employee_id";
        private string update_query = "UPDATE employee_table SET Name = @Name, Email = @Email, Address = @Address, Contact_number = @Contact_number, Designation = @Designation WHERE Employee_id = @Employee_id";
        private string delete_query = "DELETE FROM employee_table WHERE Employee_id = @Employee_id";

        // Data Validation
        public bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(empIdTxt.Text) || !int.TryParse(empIdTxt.Text, out _))
            {
                MessageBox.Show("Please enter a valid Student ID.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(nameTxt.Text))
            {
                MessageBox.Show("Please enter the student's full name.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(emailTxt.Text) || !IsValidEmail(emailTxt.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(addressTxt.Text))
            {
                MessageBox.Show("Please enter the Address.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(contactNumberTxt.Text) || !IsValidPhoneNumber(contactNumberTxt.Text))
            {
                MessageBox.Show("Please enter a valid contact number.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(designationTxt.Text))
            {
                MessageBox.Show("Please enter Designation.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            // Email validation using a regular expression
            string emailPattern = @"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Phone number validation for a basic 10-digit format
            string phonePattern = @"^\d{10}$";
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, phonePattern);
        }

        private void Clear()
        {
            empIdTxt.Clear();
            nameTxt.Clear();
            emailTxt.Clear();
            contactNumberTxt.Clear();
            addressTxt.Clear();
            designationTxt.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.CreateDBConnection();
            SqlCommand cmd = new SqlCommand(search_query, conn);

            cmd.Parameters.AddWithValue("@Employee_id", int.Parse(empIdTxt.Text));

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    nameTxt.Text = reader["Name"].ToString();
                    emailTxt.Text = reader["Email"].ToString();
                    contactNumberTxt.Text = reader["Contact_number"].ToString();
                    addressTxt.Text = reader["Address"].ToString();
                    designationTxt.Text = reader["Designation"].ToString();
                }
                else
                {
                    MessageBox.Show("Employee ID not found.", "Not Found", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(empIdTxt.Text))
            {
                MessageBox.Show("Please enter a Employee ID to update.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            SqlConnection conn = connection.CreateDBConnection();
            SqlCommand cmd = new SqlCommand(update_query, conn);

            cmd.Parameters.AddWithValue("@Employee_id", int.Parse(empIdTxt.Text));
            cmd.Parameters.AddWithValue("@Name", nameTxt.Text);
            cmd.Parameters.AddWithValue("@Email", emailTxt.Text);
            cmd.Parameters.AddWithValue("@Contact_number", contactNumberTxt.Text);
            cmd.Parameters.AddWithValue("@Address", addressTxt.Text);
            cmd.Parameters.AddWithValue("@Designation", designationTxt.Text);

            try
            {
                if (!ValidateInputs())
                {
                    return; // Exit if input validation fails
                }

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Update Successfully!", "Done", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    Clear();
                }
                else
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the employee: " + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(empIdTxt.Text))
            {
                MessageBox.Show("Please enter a Employee ID to delete.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            SqlConnection conn = connection.CreateDBConnection();
            SqlCommand cmd = new SqlCommand(delete_query, conn);

            cmd.Parameters.AddWithValue("@Employee_id", int.Parse(empIdTxt.Text));

            try
            {         
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Successfully Deleted!", "Done", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    Clear();
                }
                else
                {
                    MessageBox.Show("Error!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the employee: " + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
