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
    public partial class PasswordResetForm : Form
    {
        public PasswordResetForm()
        {
            InitializeComponent();
        }

        DatabaseConnection connection = new DatabaseConnection();

        private string update_query = "UPDATE signup_Table SET password = @password WHERE email = @email";

        private void btnReset_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.CreateDBConnection();
            SqlCommand cmd = new SqlCommand(update_query, conn);

            cmd.Parameters.AddWithValue("@email", emailTxt.Text);
            cmd.Parameters.AddWithValue("@password", newPwdTxt.Text);

            try
            {
                if (newPwdTxt.Text.Length < 6)
                {
                    MessageBox.Show("Password must be at least 6 characters long.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }

                if (newPwdTxt.Text != confirmPwdTxt.Text)
                {
                    MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }

                int rowsAffected = cmd.ExecuteNonQuery();
                
                if (rowsAffected > 0)
                {
                    this.Hide();

                    MessageBox.Show("Password Reset Successfully!", "Done", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            emailTxt.Clear();
            newPwdTxt.Clear();
            confirmPwdTxt.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                confirmPwdTxt.UseSystemPasswordChar = true;
            }
            else 
            {
                confirmPwdTxt.UseSystemPasswordChar= false;
            }
        }
    }
}
