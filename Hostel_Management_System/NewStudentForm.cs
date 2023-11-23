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
    public partial class NewStudentForm : Form
    {
        public NewStudentForm()
        {
            InitializeComponent();
        }

        private void NewStudentForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(560, 130);
        }

        DatabaseConnection connection = new DatabaseConnection();

        private string query = "INSERT INTO StudentTable VALUES (@Student_id, @Student_name, @DOB, @Gender, @Email, @Contact_number, @NIC, @Address, @Guardian_name, @Degree, @Room_no)";
        private string gender = ""; // Initialize the gender

        public string CheckGender()
        {
            if (male.Checked)
            {
                gender = "Male";
            }
            else if (female.Checked)
            {
                gender = "Female";
            }

            return gender;
        }

        public bool ValidateInputs()
        {
            // Data validation 
            if (string.IsNullOrWhiteSpace(studentIDTxt.Text) || !int.TryParse(studentIDTxt.Text, out _))
            {
                MessageBox.Show("Please enter a valid Student ID.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(fullNameTxt.Text))
            {
                MessageBox.Show("Please enter the student's full name.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(emailTxt.Text) || !IsValidEmail(emailTxt.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(contactTxt.Text) || !IsValidPhoneNumber(contactTxt.Text))
            {
                MessageBox.Show("Please enter a valid contact number.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(NicTxt.Text) || !IsValidNIC(NicTxt.Text))
            {
                MessageBox.Show("Please enter a valid NIC number.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(adressTxt.Text))
            {
                MessageBox.Show("Please enter the student's address.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(guardianTxt.Text))
            {
                MessageBox.Show("Please enter the guardian's name.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(degreeTxt.Text))
            {
                MessageBox.Show("Please enter the degree.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(roomNoTxt.Text) || !int.TryParse(roomNoTxt.Text, out _))
            {
                MessageBox.Show("Please enter a valid room number.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            if (!male.Checked && !female.Checked)
            {
                MessageBox.Show("Please select the student's gender.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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

        private bool IsValidNIC(string nic)
        {
            // NIC validation for either 10-digit or 12-digit format
            string nicPattern10Digit = @"^\d{9}[vV]$";
            string nicPattern12Digit = @"^\d{12}$"; 

            return System.Text.RegularExpressions.Regex.IsMatch(nic, nicPattern10Digit) || System.Text.RegularExpressions.Regex.IsMatch(nic, nicPattern12Digit);
        }

        public void ClearText()
        {
            studentIDTxt.Clear();
            fullNameTxt.Clear();
            emailTxt.Clear();
            contactTxt.Clear();
            NicTxt.Clear();
            adressTxt.Clear();
            guardianTxt.Clear();
            degreeTxt.Clear();
            roomNoTxt.Clear();

            male.Checked = false; // Clear radio button selection
            female.Checked = false;
            dateTimePicker1.Value = DateTime.Now; // Reset DateTimePicker to the current date
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.CreateDBConnection();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Student_id", int.Parse(studentIDTxt.Text));
            cmd.Parameters.AddWithValue("@Student_name", fullNameTxt.Text);
            cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value.ToString("yyyy/MM/dd"));
            cmd.Parameters.AddWithValue("@Gender", CheckGender());
            cmd.Parameters.AddWithValue("@Email", emailTxt.Text);
            cmd.Parameters.AddWithValue("@Contact_number", contactTxt.Text);
            cmd.Parameters.AddWithValue("@NIC", NicTxt.Text);
            cmd.Parameters.AddWithValue("@Address", adressTxt.Text);
            cmd.Parameters.AddWithValue("@Guardian_name", guardianTxt.Text);
            cmd.Parameters.AddWithValue("@Degree", degreeTxt.Text);
            cmd.Parameters.AddWithValue("@Room_no", int.Parse(roomNoTxt.Text));

            try
            {
                if (!ValidateInputs())
                {
                    return; // Exit if input validation fails
                }

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Successfully Added!", "Done", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    ClearText();
                }
                else
                {
                    MessageBox.Show("Failed to add student.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the student: " + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
