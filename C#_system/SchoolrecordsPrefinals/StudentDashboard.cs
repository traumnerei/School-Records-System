using MySql.Data.MySqlClient;
using SchoolrecordsPrefinals.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolrecordsPrefinals
{
    public partial class StudentDashboard : Form
    {
        private UC_Courses ucCourses;
        private int _userId;
        private UC_Home  ucHome;
        private UCGrades UCGrades;
        private class_sched UC_sched;
       

        public StudentDashboard(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadStudentDetails();
            this.StartPosition = FormStartPosition.CenterScreen;


            ucHome = new UC_Home(lblStudentName.Text);
            ucHome.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(ucHome);
        }

        // student details 
        private void LoadStudentDetails()
        {
            string connection = "server=localhost;user=root;database=schoolrecords;password=;";
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                try
                {   
                    conn.Open();
                    string query = @"
                SELECT u.FirstName, u.LastName, sr.YearLevel, sr.UserId,
                       er.Semester, er.SchoolYear
                FROM studentrecords sr
                INNER JOIN users u ON sr.UserId = u.UserId
                LEFT JOIN enrollmentrecords er ON sr.UserId = er.UserId
                WHERE sr.UserID = @UserId
                ORDER BY er.SchoolYear DESC, er.Semester DESC
                LIMIT 1"; // Get the most recent semester

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", _userId);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string fullName = $"{reader["FirstName"]} {reader["LastName"]}";
                        string yearLevel = reader["YearLevel"].ToString();
                        string semester = reader["Semester"]?.ToString() ?? "N/A";
                        string schoolYear = reader["SchoolYear"]?.ToString() ?? "N/A";
                        string studentId = reader["UserId"].ToString();

                        lblStudentName.Text = fullName;
                        lblYearLevel.Text = ("Year Lvl: ") + yearLevel;
                        lblStudentID.Text = ("Student ID: ") + studentId;
                        lblSchoolYear.Text = ("SY:") + schoolYear;
                        lblSem.Text = ("Sem:") + semester; 

                    }
                    else
                    {
                        MessageBox.Show("Student record not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading student data: " + ex.Message);
                }
            }
        }


        private void panelMainContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            if (ucCourses == null)
            {
                ucCourses = new UC_Courses();    
                ucCourses.Dock = DockStyle.Fill;
            }
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(ucCourses);
        }


        private void dashboardheader_Click(object sender, EventArgs e)
        {
            if (ucHome == null)
            {
                ucHome = new UC_Home(lblStudentName.Text);
                ucHome.Dock = DockStyle.Fill;
            }

            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(ucHome);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGrades_Click(object sender, EventArgs e)
        {
            if (UCGrades == null)
            {
                UCGrades = new UCGrades(_userId); // Pass the studentId from constructor
                UCGrades.Dock = DockStyle.Fill;
            }

            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(UCGrades);
        }

        private void lblStudentID_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            if (UC_sched == null)
            {
                UC_sched = new class_sched(_userId);
                UC_sched.Dock = DockStyle.Fill;
               
            }
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(UC_sched);
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void lblStudentName_Click(object sender, EventArgs e)
        {

        }

        private void lblSemesterSchoolYear_Click(object sender, EventArgs e)
        {

        }

        private void lblYearLevel_Click(object sender, EventArgs e)
        {

        }

        private void dashboardheader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StudentDashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2.Controls.Count > 0)
            {
                var control = splitContainer1.Panel2.Controls[0];
                if (control is IRefreshable refreshable)
                {
                    refreshable.RefreshContent();
                    MessageBox.Show("Panel refreshed successfully.", "Refreshed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("This panel does not support refreshing.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
