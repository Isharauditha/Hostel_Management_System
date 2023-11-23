using System;
using System.Collections;
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
    public partial class Update_Delete_StudentForm : Form
    {
        public Update_Delete_StudentForm()
        {
            InitializeComponent();
        }

        private void Update_Delete_StudentForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(560, 130);
        }

        DatabaseConnection connection = new DatabaseConnection();

        private string update_query = "UPDATE StudentTable SET Student_name = @Student_name, DOB = @DOB, Email = @Email, Contact_number = @Contact_number, NIC = @NIC, Address = @Address, Guardian_name = @Guardian_name, Degree = @Degree, Room_no = @Room_no WHERE Student_id = @Student_id";
        private string delete_query = "DELETE FROM StudentTable WHERE Student_id = @Student_id";
        private string search_query = "SELECT * FROM StudentTable WHERE Student_id = @Student_id";
        private string gender = ""; // Initialize the gender

        public string CheckGender()
        {
            if (male.Checked)
            {
                gender = "Male";
            }
            if (female.Checked)
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
            // Simple email validation using a regular expression
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
            male.Checked = false;
            female.Checked = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(studentIDTxt.Text) || !int.TryParse(studentIDTxt.Text, out _))
            {
                MessageBox.Show("Please enter a valid Student ID.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            SqlConnection conn = connection.CreateDBConnection();
            SqlCommand cmd = new SqlCommand(search_query, conn);

            cmd.Parameters.AddWithValue("@Student_id", int.Parse(studentIDTxt.Text));

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    fullNameTxt.Text = reader["Student_name"].ToString();
                    emailTxt.Text = reader["Email"].ToString();
                    contactTxt.Text = reader["Contact_number"].ToString();
                    NicTxt.Text = reader["NIC"].ToString();
                    adressTxt.Text = reader["Address"].ToString();
                    guardianTxt.Text = reader["Guardian_name"].ToString();
                    degreeTxt.Text = reader["Degree"].ToString();
                    roomNoTxt.Text = reader["Room_no"].ToString();
                    gender = reader["Gender"].ToString();

                    if (gender == "Male")
                    {
                        male.Checked = true;
                    }
                    else if (gender == "Female")
                    {
                        female.Checked = true;
                    }
                }
                else
                {
                    MessageBox.Show("Student ID not found.", "Not Found", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception ex)
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
            if (string.IsNullOrWhiteSpace(studentIDTxt.Text))
            {
                MessageBox.Show("Please enter a Student ID to update.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            SqlConnection conn = connection.CreateDBConnection();
            SqlCommand cmd = new SqlCommand(update_query, conn);

            cmd.Parameters.AddWithValue("@Student_id", int.Parse(studentIDTxt.Text));
            cmd.Parameters.AddWithValue("@Student_name", fullNameTxt.Text);
            cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value.ToString("yyyy/MM/dd"));
            cmd.Parameters.AddWithValue("@Email", emailTxt.Text);
            cmd.Parameters.AddWithValue("@Contact_number", contactTxt.Text);
            cmd.Parameters.AddWithValue("@NIC", NicTxt.Text);
            cmd.Parameters.AddWithValue("@Address", adressTxt.Text);
            cmd.Parameters.AddWithValue("@Guardian_name", guardianTxt.Text);
            cmd.Parameters.AddWithValue("@Degree", degreeTxt.Text);
            cmd.Parameters.AddWithValue("@Room_no", int.Parse(roomNoTxt.Text));

            try
            { 
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Successfully Updated!", "Done", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    ClearText();
                }
                else
                {
                    MessageBox.Show("Failed!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the student: " + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(studentIDTxt.Text))
            {
                MessageBox.Show("Please enter a Student ID to delete.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            SqlConnection conn = connection.CreateDBConnection();
            SqlCommand cmd = new SqlCommand(delete_query, conn);

            cmd.Parameters.AddWithValue("@Student_id", int.Parse(studentIDTxt.Text));

            try
            {
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Successfully Deleted!", "Done", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    ClearText();
                }
                else
                {
                    MessageBox.Show("Failed!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the student: " + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
