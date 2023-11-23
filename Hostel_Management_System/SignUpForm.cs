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
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        DatabaseConnection connection = new DatabaseConnection();

        private string insert_query = "INSERT INTO signup_Table VALUES (@first_name, @last_name, @email, @phone, @username, @password)";

        private void btnSignup_Click(object sender, EventArgs e)
        {
            try
            {
                if (pwdTxt.Text.Length < 6)
                {
                    MessageBox.Show("Password must be at least 6 characters long.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }

                SqlConnection conn = connection.CreateDBConnection();
                SqlCommand cmd = new SqlCommand(insert_query, conn);

                cmd.Parameters.AddWithValue("@first_name", fnameTxt.Text);
                cmd.Parameters.AddWithValue("@last_name", lnameTxt.Text);
                cmd.Parameters.AddWithValue("@email", emailTxt.Text);
                cmd.Parameters.AddWithValue("@phone", phoneTxt.Text);
                cmd.Parameters.AddWithValue("@username", unameTxt.Text);
                cmd.Parameters.AddWithValue("@password", pwdTxt.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    this.Close();

                    DashBoardForm dashboardForm = new DashBoardForm();
                    dashboardForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Failed!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}
