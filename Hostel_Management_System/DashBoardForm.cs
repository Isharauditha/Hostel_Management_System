using System;
using System.Windows.Forms;

namespace Hostel_Management_System
{
    public partial class DashBoardForm : Form
    {
        public DashBoardForm()
        {
            InitializeComponent();
        }
        private void btnNewStudent_Click(object sender, EventArgs e)
        {
            NewStudentForm newStudentForm = new NewStudentForm();
            newStudentForm.Show();
        }
        private void btnUpdateDeleteStudent_Click(object sender, EventArgs e)
        {
            Update_Delete_StudentForm update_Delete_StudentForm = new Update_Delete_StudentForm();
            update_Delete_StudentForm.Show();
        }

        private void btnManageRooms_Click(object sender, EventArgs e)
        {
            AddNewRoom addNewRoom = new AddNewRoom();
            addNewRoom.Show();
        }

        private void btnStudentFees_Click(object sender, EventArgs e)
        {
            StudentFeesForm studentFeesForm = new StudentFeesForm();
            studentFeesForm.Show();
        }

        private void btnStudentRecords_Click(object sender, EventArgs e)
        {
            StudentRecordsForm studentRecordsForm = new StudentRecordsForm();
            studentRecordsForm.Show();
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            NewEmployeeForm newEmployeeForm = new NewEmployeeForm();
            newEmployeeForm.Show();
        }

        private void btnUpdateDeleteEmployee_Click(object sender, EventArgs e)
        {
            Update_Delete_EmployeeForm update_Delete_EmployeeForm = new Update_Delete_EmployeeForm();
            update_Delete_EmployeeForm.Show();
        }

        private void btnEmployeeRecords_Click(object sender, EventArgs e)
        {
            EmployeeRecordsForm employeeRecordsForm = new EmployeeRecordsForm();
            employeeRecordsForm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();

            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btnStudentLeave_Click(object sender, EventArgs e)
        {
            StudentLeaveForm studentLeaveForm = new StudentLeaveForm();
            studentLeaveForm.Show();
        }
    }
}
