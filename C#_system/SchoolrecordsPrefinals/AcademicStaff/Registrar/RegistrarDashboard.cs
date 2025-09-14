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
    public partial class RegistrarDashboard : Form
    {
        private EnrollStudent ucEnrollStudent;
        private int _userId;
        private ManageStudent ucGradesMonitor;
        private UC_Assign Uc_assign;


        public RegistrarDashboard(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadDeanInfo();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
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

        private void btnMonitorGrades_Click(object sender, EventArgs e)
        {
            if (ucEnrollStudent == null) ucEnrollStudent = new EnrollStudent();
            LoadUserControl(ucEnrollStudent);
        }
        private void LoadUserControl(UserControl control)
        {
            splitContainer1.Panel2.Controls.Clear();
            control.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(control);
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }
        private void LoadDeanInfo()
        {
            string connStr = "server=localhost;user=root;database=schoolrecords;password=;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT FirstName, LastName FROM users WHERE UserId = @UserId AND _Role = 'AcademicStaff' AND PermissionLevel = 'Registrar'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", _userId);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string fullName = reader["FirstName"] + " " + reader["LastName"];
                    lblName.Text = fullName;
                    lblUserID.Text = "User ID: " + _userId.ToString();
                }
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnViewCourses_Click(object sender, EventArgs e)
        {
           
            if (ucGradesMonitor == null) ucGradesMonitor = new ManageStudent();
            LoadUserControl(ucGradesMonitor);

        }

        private void btnAssignSchedule_Click(object sender, EventArgs e)
        {
            if (Uc_assign == null) Uc_assign = new UC_Assign();
            LoadUserControl(Uc_assign);
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

        private void dashboardheader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

