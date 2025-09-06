using System.Drawing;
using System.Windows.Forms;
using System;

namespace SchoolrecordsPrefinals
{
    partial class TeacherDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblWelcome;
        private ComboBox cmbCourses;
        private Label lblSelectCourse;
        private DataGridView dgvEnrolledStudents;
        private Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.cmbCourses = new System.Windows.Forms.ComboBox();
            this.lblSelectCourse = new System.Windows.Forms.Label();
            this.dgvEnrolledStudents = new System.Windows.Forms.DataGridView();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnrolledStudents)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(20, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(241, 25);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome, [Teacher Name]";
            this.lblWelcome.Click += new System.EventHandler(this.lblWelcome_Click);
            // 
            // cmbCourses
            // 
            this.cmbCourses.AllowDrop = true;
            this.cmbCourses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourses.Items.AddRange(new object[] {
            "Programming 101",
            "Data Structures"});
            this.cmbCourses.Location = new System.Drawing.Point(130, 65);
            this.cmbCourses.Name = "cmbCourses";
            this.cmbCourses.Size = new System.Drawing.Size(300, 21);
            this.cmbCourses.TabIndex = 2;
            this.cmbCourses.SelectedIndexChanged += new System.EventHandler(this.cmbCourses_SelectedIndexChanged);
            // 
            // lblSelectCourse
            // 
            this.lblSelectCourse.AutoSize = true;
            this.lblSelectCourse.Location = new System.Drawing.Point(20, 70);
            this.lblSelectCourse.Name = "lblSelectCourse";
            this.lblSelectCourse.Size = new System.Drawing.Size(85, 13);
            this.lblSelectCourse.TabIndex = 1;
            this.lblSelectCourse.Text = "Select a Course:";
            // 
            // dgvEnrolledStudents
            // 
            this.dgvEnrolledStudents.AllowUserToAddRows = false;
            this.dgvEnrolledStudents.AllowUserToDeleteRows = false;
            this.dgvEnrolledStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEnrolledStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnrolledStudents.Location = new System.Drawing.Point(13, 21);
            this.dgvEnrolledStudents.Name = "dgvEnrolledStudents";
            this.dgvEnrolledStudents.ReadOnly = true;
            this.dgvEnrolledStudents.Size = new System.Drawing.Size(880, 384);
            this.dgvEnrolledStudents.TabIndex = 3;
            this.dgvEnrolledStudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEnrolledStudents_CellContentClick);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(837, 59);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(79, 30);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvEnrolledStudents);
            this.panel1.Location = new System.Drawing.Point(3, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(913, 439);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // TeacherDashboard
            // 
            this.ClientSize = new System.Drawing.Size(918, 555);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblSelectCourse);
            this.Controls.Add(this.cmbCourses);
            this.Controls.Add(this.btnLogout);
            this.Name = "TeacherDashboard";
            this.Text = "Teacher Dashboard";
            this.Load += new System.EventHandler(this.TeacherDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnrolledStudents)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Panel panel1;
    }
}
