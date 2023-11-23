using System;

namespace Hostel_Management_System
{
    partial class DashBoardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNewStudent = new System.Windows.Forms.Button();
            this.btnEmployeeRecords = new System.Windows.Forms.Button();
            this.btnUpdateDeleteEmployee = new System.Windows.Forms.Button();
            this.btnNewEmployee = new System.Windows.Forms.Button();
            this.btnStudentRecords = new System.Windows.Forms.Button();
            this.btnStudentFees = new System.Windows.Forms.Button();
            this.btnManageRooms = new System.Windows.Forms.Button();
            this.btnUpdateDeleteStudent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnStudentLeave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewStudent
            // 
            this.btnNewStudent.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnNewStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewStudent.Location = new System.Drawing.Point(12, 193);
            this.btnNewStudent.Name = "btnNewStudent";
            this.btnNewStudent.Size = new System.Drawing.Size(262, 43);
            this.btnNewStudent.TabIndex = 0;
            this.btnNewStudent.Text = "New Student";
            this.btnNewStudent.UseVisualStyleBackColor = false;
            this.btnNewStudent.Click += new System.EventHandler(this.btnNewStudent_Click);
            // 
            // btnEmployeeRecords
            // 
            this.btnEmployeeRecords.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnEmployeeRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployeeRecords.Location = new System.Drawing.Point(12, 760);
            this.btnEmployeeRecords.Name = "btnEmployeeRecords";
            this.btnEmployeeRecords.Size = new System.Drawing.Size(262, 43);
            this.btnEmployeeRecords.TabIndex = 1;
            this.btnEmployeeRecords.Text = "Emoloyee Records";
            this.btnEmployeeRecords.UseVisualStyleBackColor = false;
            this.btnEmployeeRecords.Click += new System.EventHandler(this.btnEmployeeRecords_Click);
            // 
            // btnUpdateDeleteEmployee
            // 
            this.btnUpdateDeleteEmployee.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnUpdateDeleteEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateDeleteEmployee.Location = new System.Drawing.Point(12, 690);
            this.btnUpdateDeleteEmployee.Name = "btnUpdateDeleteEmployee";
            this.btnUpdateDeleteEmployee.Size = new System.Drawing.Size(262, 43);
            this.btnUpdateDeleteEmployee.TabIndex = 2;
            this.btnUpdateDeleteEmployee.Text = "Update/Delete Employee";
            this.btnUpdateDeleteEmployee.UseVisualStyleBackColor = false;
            this.btnUpdateDeleteEmployee.Click += new System.EventHandler(this.btnUpdateDeleteEmployee_Click);
            // 
            // btnNewEmployee
            // 
            this.btnNewEmployee.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnNewEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewEmployee.Location = new System.Drawing.Point(12, 619);
            this.btnNewEmployee.Name = "btnNewEmployee";
            this.btnNewEmployee.Size = new System.Drawing.Size(262, 43);
            this.btnNewEmployee.TabIndex = 3;
            this.btnNewEmployee.Text = "New Employee";
            this.btnNewEmployee.UseVisualStyleBackColor = false;
            this.btnNewEmployee.Click += new System.EventHandler(this.btnNewEmployee_Click);
            // 
            // btnStudentRecords
            // 
            this.btnStudentRecords.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnStudentRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentRecords.Location = new System.Drawing.Point(12, 477);
            this.btnStudentRecords.Name = "btnStudentRecords";
            this.btnStudentRecords.Size = new System.Drawing.Size(262, 43);
            this.btnStudentRecords.TabIndex = 4;
            this.btnStudentRecords.Text = "Student Records";
            this.btnStudentRecords.UseVisualStyleBackColor = false;
            this.btnStudentRecords.Click += new System.EventHandler(this.btnStudentRecords_Click);
            // 
            // btnStudentFees
            // 
            this.btnStudentFees.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnStudentFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentFees.Location = new System.Drawing.Point(12, 406);
            this.btnStudentFees.Name = "btnStudentFees";
            this.btnStudentFees.Size = new System.Drawing.Size(262, 43);
            this.btnStudentFees.TabIndex = 5;
            this.btnStudentFees.Text = "Student Fees";
            this.btnStudentFees.UseVisualStyleBackColor = false;
            this.btnStudentFees.Click += new System.EventHandler(this.btnStudentFees_Click);
            // 
            // btnManageRooms
            // 
            this.btnManageRooms.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnManageRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageRooms.Location = new System.Drawing.Point(12, 335);
            this.btnManageRooms.Name = "btnManageRooms";
            this.btnManageRooms.Size = new System.Drawing.Size(262, 43);
            this.btnManageRooms.TabIndex = 6;
            this.btnManageRooms.Text = "Manage Rooms";
            this.btnManageRooms.UseVisualStyleBackColor = false;
            this.btnManageRooms.Click += new System.EventHandler(this.btnManageRooms_Click);
            // 
            // btnUpdateDeleteStudent
            // 
            this.btnUpdateDeleteStudent.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnUpdateDeleteStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateDeleteStudent.Location = new System.Drawing.Point(12, 264);
            this.btnUpdateDeleteStudent.Name = "btnUpdateDeleteStudent";
            this.btnUpdateDeleteStudent.Size = new System.Drawing.Size(262, 43);
            this.btnUpdateDeleteStudent.TabIndex = 7;
            this.btnUpdateDeleteStudent.Text = "Update/Delete Students";
            this.btnUpdateDeleteStudent.UseVisualStyleBackColor = false;
            this.btnUpdateDeleteStudent.Click += new System.EventHandler(this.btnUpdateDeleteStudent_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Navigation Bar";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(280, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1640, 800);
            this.panel1.TabIndex = 9;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(1720, 63);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(92, 29);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "LogOut";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnStudentLeave
            // 
            this.btnStudentLeave.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnStudentLeave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentLeave.Location = new System.Drawing.Point(12, 548);
            this.btnStudentLeave.Name = "btnStudentLeave";
            this.btnStudentLeave.Size = new System.Drawing.Size(262, 43);
            this.btnStudentLeave.TabIndex = 11;
            this.btnStudentLeave.Text = "Students Leave";
            this.btnStudentLeave.UseVisualStyleBackColor = false;
            this.btnStudentLeave.Click += new System.EventHandler(this.btnStudentLeave_Click);
            // 
            // DashBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1664, 752);
            this.Controls.Add(this.btnStudentLeave);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdateDeleteStudent);
            this.Controls.Add(this.btnManageRooms);
            this.Controls.Add(this.btnStudentFees);
            this.Controls.Add(this.btnStudentRecords);
            this.Controls.Add(this.btnNewEmployee);
            this.Controls.Add(this.btnUpdateDeleteEmployee);
            this.Controls.Add(this.btnEmployeeRecords);
            this.Controls.Add(this.btnNewStudent);
            this.Name = "DashBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dash Board";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion

        private System.Windows.Forms.Button btnNewStudent;
        private System.Windows.Forms.Button btnEmployeeRecords;
        private System.Windows.Forms.Button btnUpdateDeleteEmployee;
        private System.Windows.Forms.Button btnNewEmployee;
        private System.Windows.Forms.Button btnStudentRecords;
        private System.Windows.Forms.Button btnStudentFees;
        private System.Windows.Forms.Button btnManageRooms;
        private System.Windows.Forms.Button btnUpdateDeleteStudent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnStudentLeave;
    }
}