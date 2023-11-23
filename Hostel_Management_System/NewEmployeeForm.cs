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
    public partial class NewEmployeeForm : Form
    {
        public NewEmployeeForm()
        {
            InitializeComponent();
        }

        private void NewEmployeeForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(540, 240);
        }

        DatabaseConnection connection = new DatabaseConnection();

        private string query = "INSERT INTO employee_table VALUES (@Employee_id, @Name, @Email, @Address, @Contact_number, @Designation)";

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
            addressTxt.Clear();
            contactNumberTxt.Clear();
            designationTxt.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.CreateDBConnection();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Employee_id", empIdTxt.Text);
            cmd.Parameters.AddWithValue("@Name", nameTxt.Text);
            cmd.Parameters.AddWithValue("@Email", emailTxt.Text);
            cmd.Parameters.AddWithValue("@Address", addressTxt.Text);
            cmd.Parameters.AddWithValue("@Contact_number", contactNumberTxt.Text);
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
                    MessageBox.Show("Success", "Done", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    Clear();
                }
                else
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred while adding the Employee: " + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
