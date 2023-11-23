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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void DB_Connection()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=isharaPC\SQLEXPRESS;Initial Catalog=HostelDB;Integrated Security=True"))
            {
                try
                {
                    string user_name = unameTxt.Text.Trim();
                    string password = pwdTxt.Text;

                    if (string.IsNullOrEmpty(user_name) || string.IsNullOrEmpty(password))
                    {
                        MessageBox.Show("Username or password can't be empty!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        return;
                    }

                    string sql = "SELECT * FROM signup_Table WHERE username = @username AND password = @password";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", user_name);
                    cmd.Parameters.AddWithValue("@password", password);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        this.Hide();
                        DashBoardForm dashboard = new DashBoardForm();
                        dashboard.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        unameTxt.Clear();
                        pwdTxt.Clear();
                        unameTxt.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DB_Connection();
        }

        private void pwdTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                DB_Connection();
            }
        }

        private void signupLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();

            SignUpForm signupForm = new SignUpForm();
            signupForm.Show();
        }

        private void forgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PasswordResetForm passwordResetForm = new PasswordResetForm();
            passwordResetForm.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) 
            {
                pwdTxt.UseSystemPasswordChar = true;
            }
            else
            {
                pwdTxt.UseSystemPasswordChar = false;
            }
        }
    }
}
