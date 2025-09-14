using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolrecordsPrefinals
{
    public partial class TeacherDashboard : Form
    {
        private int _teacherId;
        private string _connectionString = "server=localhost;user=root;database=schoolrecords;password=;";
        private CourseItem selectedCourse;

        public TeacherDashboard(int teacherId)
        {
            InitializeComponent();
            _teacherId = teacherId;
            LoadTeacherDetails();
            LoadAssignedCourses();
            FormatGrid();
            this.StartPosition = FormStartPosition.CenterScreen;

            dgvEnrolledStudents.CellFormatting += dgvEnrolledStudents_CellFormatting;
        }

        private void LoadTeacherDetails()
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT FirstName, LastName FROM Users WHERE UserId = @UserId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", _teacherId);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string fullName = $"{reader["FirstName"]} {reader["LastName"]}";
                    lblWelcome.Text = $"Welcome, {fullName}";
                }
            }
        }

        public class CourseItem
        {
            public int CourseId { get; set; }
            public string CourseName { get; set; }

            public override string ToString() => CourseName;
        }

        private void LoadAssignedCourses()
        {
            cmbCourses.Items.Clear();
            cmbCourses.SelectedIndex = -1;

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT c.CourseId, c.CourseName
                    FROM courseassignments ca
                    JOIN courses c ON ca.CourseId = c.CourseId
                    WHERE ca.UserId = @UserId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", _teacherId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbCourses.Items.Add(new CourseItem
                        {
                            CourseId = Convert.ToInt32(reader["CourseId"]),
                            CourseName = reader["CourseName"].ToString()
                        });
                    }
                }
            }

            if (cmbCourses.Items.Count > 0)
                cmbCourses.SelectedIndex = 0;
        }

        private void cmbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCourses.SelectedItem is CourseItem course)
            {
                selectedCourse = course;
                LoadEnrolledStudents(course.CourseId);
            }
        }

        private void LoadEnrolledStudents(int courseId)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        er.UserId, 
                        CONCAT(u.FirstName, ' ', u.LastName) AS FullName, 
                        sr.YearLevel,
                        g.PrelimGrade, 
                        g.MidtermGrade, 
                        g.FinalsGrade,
                        g.Status
                    FROM enrollmentrecords er
                    INNER JOIN studentrecords sr ON sr.UserId = er.UserId
                    INNER JOIN users u ON u.UserId = sr.UserId
                    INNER JOIN grades g ON g.UserId = er.UserId AND g.CourseId = @CourseId
                    WHERE er.ProgramId = (
                        SELECT ProgramId FROM courses WHERE CourseId = @CourseId
                    ) AND g.Status != 'Dropped'";


                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CourseId", courseId);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable studentsTable = new DataTable();
                adapter.Fill(studentsTable);

                dgvEnrolledStudents.CellFormatting -= dgvEnrolledStudents_CellFormatting;
                dgvEnrolledStudents.Columns.Clear();
                dgvEnrolledStudents.DataSource = studentsTable;

                if (!dgvEnrolledStudents.Columns.Contains("AddGradeButton"))
                {
                    DataGridViewButtonColumn addGradeButton = new DataGridViewButtonColumn
                    {
                        HeaderText = "",
                        Name = "AddGradeButton",
                        Text = "Add Grade",
                        UseColumnTextForButtonValue = true
                    };
                    dgvEnrolledStudents.Columns.Add(addGradeButton);
                }

                if (!dgvEnrolledStudents.Columns.Contains("DropButton"))
                {
                    DataGridViewButtonColumn dropButton = new DataGridViewButtonColumn
                    {
                        HeaderText = "",
                        Name = "DropButton",
                        Text = "Drop",
                        UseColumnTextForButtonValue = true
                    };
                    dgvEnrolledStudents.Columns.Add(dropButton);
                }

                dgvEnrolledStudents.CellFormatting += dgvEnrolledStudents_CellFormatting;
            }
        }

        private void dgvEnrolledStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int userId = Convert.ToInt32(dgvEnrolledStudents.Rows[e.RowIndex].Cells["UserId"].Value);

            if (dgvEnrolledStudents.Columns[e.ColumnIndex].Name == "DropButton")
            {
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to drop this student?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                { 
                    using (MySqlConnection conn = new MySqlConnection(_connectionString))
                    {
                        conn.Open();
                        string updateQuery = "UPDATE grades SET Status = 'Dropped' WHERE UserId = @UserId AND CourseId = @CourseId";
                        MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@CourseId", selectedCourse.CourseId);
                        cmd.ExecuteNonQuery();

                    }

                    // Remove the dropped student row
                    dgvEnrolledStudents.Rows.RemoveAt(e.RowIndex);
                }
            }
            else if (dgvEnrolledStudents.Columns[e.ColumnIndex].Name == "AddGradeButton")
            {
                UC_Gradeassign gradeForm = new UC_Gradeassign(userId, selectedCourse.CourseId);
                if (gradeForm.ShowDialog() == DialogResult.OK)
                {
                    UpdateGradeStatus(userId, selectedCourse.CourseId);
                    LoadEnrolledStudents(selectedCourse.CourseId);
                }
            }
        }

        private void UpdateGradeStatus(int userId, int courseId)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT PrelimGrade, MidtermGrade, FinalsGrade FROM grades WHERE UserId = @UserId AND CourseId = @CourseId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@CourseId", courseId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read() && reader["PrelimGrade"] != DBNull.Value && reader["MidtermGrade"] != DBNull.Value && reader["FinalsGrade"] != DBNull.Value)
                    {
                        decimal prelim = Convert.ToDecimal(reader["PrelimGrade"]);
                        decimal midterm = Convert.ToDecimal(reader["MidtermGrade"]);
                        decimal finals = Convert.ToDecimal(reader["FinalsGrade"]);
                        decimal average = (prelim + midterm + finals) / 3;
                        string status = average >= 75 ? "Passed" : "Failed";

                        reader.Close();

                        string updateStatus = "UPDATE grades SET Status = @Status WHERE UserId = @UserId AND CourseId = @CourseId";
                        MySqlCommand updateCmd = new MySqlCommand(updateStatus, conn);
                        updateCmd.Parameters.AddWithValue("@Status", status);
                        updateCmd.Parameters.AddWithValue("@UserId", userId);
                        updateCmd.Parameters.AddWithValue("@CourseId", courseId);
                        updateCmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void dgvEnrolledStudents_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvEnrolledStudents.Columns[e.ColumnIndex].Name == "DropButton" && e.RowIndex >= 0)
            {
                dgvEnrolledStudents.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Drop";
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FormatGrid()
        {
            dgvEnrolledStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEnrolledStudents.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvEnrolledStudents.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvEnrolledStudents.RowTemplate.Height = 40;
            dgvEnrolledStudents.ReadOnly = true;
            dgvEnrolledStudents.AllowUserToAddRows = false;
            dgvEnrolledStudents.AllowUserToDeleteRows = false;
            dgvEnrolledStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEnrolledStudents.Dock = DockStyle.Fill;
            dgvEnrolledStudents.ClearSelection();
        }

        private void TeacherDashboard_Load(object sender, EventArgs e) { }

        private void lblWelcome_Click(object sender, EventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}
