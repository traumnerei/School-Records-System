using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;



namespace SchoolrecordsPrefinals    
{
    public partial class UC_Courses : UserControl
    {

        private string connection = "server=localhost;user=root;database=schoolrecords;password=;";
        private int _userId;

        public UC_Courses()
        {
            InitializeComponent();
        }

        public void LoadCoursesForUser(int userId)
        {
            _userId = userId;
            rbtnEnrolledCourses.Checked = true; // default
            LoadEnrolledCourses();
        }

        private void LoadEnrolledCourses(string search = "")
        {
            string query = @"
                SELECT c.CourseCode AS Course_Code, c.CourseName AS Course_Name, c.Credits
                FROM grades g
                JOIN courses c 
                  ON g.CourseId = c.CourseId
                  AND
                  g.UserId = @UserId ";
                //WHERE g.UserId = @UserId";

            if (!string.IsNullOrWhiteSpace(search))
                query += " AND (c.CourseCode LIKE @search OR c.CourseName LIKE @search)";

            LoadCourses(query, search);
        }

        private void LoadAvailableCourses(string search = "")
        {
            string query = @"
                SELECT c.CourseCode, c.CourseName, c.Credits
                FROM courses c
                WHERE c.CourseId NOT IN (
                    SELECT CourseId FROM grades WHERE UserId = @UserId
                )";

            if (!string.IsNullOrWhiteSpace(search))
                query += " AND (c.CourseCode LIKE @search OR c.CourseName LIKE @search)";

            LoadCourses(query, search);
        }

        private void LoadCourses(string query, string search)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", _userId);
                    if (!string.IsNullOrWhiteSpace(search))
                        cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvCourses.Columns.Clear();
                    dgvCourses.DataSource = dt;

                    dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvCourses.ReadOnly = true;
                    dgvCourses.AllowUserToAddRows = false;
                    dgvCourses.AllowUserToDeleteRows = false;
                    dgvCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvCourses.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                    dgvCourses.RowTemplate.Height = 35;
                    dgvCourses.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
            }
        }
        private void rbtnEnrolledCourses_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnEnrolledCourses.Checked)
            {
                LoadEnrolledCourses(txtSearch.Text.Trim());
            }
        }

        private void rbtnAvailableCourses_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAvailableCourses.Checked)
            {
                LoadAvailableCourses(txtSearch.Text.Trim());
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (rbtnEnrolledCourses.Checked)
                LoadEnrolledCourses(txtSearch.Text.Trim());
            else if (rbtnAvailableCourses.Checked)
                LoadAvailableCourses(txtSearch.Text.Trim());
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            if (rbtnEnrolledCourses.Checked)
                LoadEnrolledCourses();
            else
                LoadAvailableCourses();
        }

        private void dgvCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
