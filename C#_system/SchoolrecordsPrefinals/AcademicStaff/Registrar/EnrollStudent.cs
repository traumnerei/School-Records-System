using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolrecordsPrefinals
{
    public partial class EnrollStudent : UserControl
    {
        private string _connectionString = "server=localhost;user=root;database=schoolrecords;password=;";

        public EnrollStudent()
        {
            InitializeComponent();
            LoadPrograms();
            LoadYearLevels();
            LoadSemesters();
        }

        private void LoadPrograms()
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT ProgramId, ProgramName FROM programs";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cmbProgram.DisplayMember = "ProgramName";
                cmbProgram.ValueMember = "ProgramId";
                cmbProgram.DataSource = dt;
            }
        }

        private void LoadYearLevels()
        {
            cmbYearLevel.Items.AddRange(new string[] { "1st Year", "2nd Year", "3rd Year", "4th Year" });
        }

        private void LoadSemesters()
        {
            cmbSemester.Items.AddRange(new string[] { "1st Semester", "2nd Semester" });
        }

        private int GetNextUserId(MySqlConnection conn, MySqlTransaction transaction)
        {
            string query = "SELECT IFNULL(MAX(UserId), 2500) + 1 FROM users";
            MySqlCommand cmd = new MySqlCommand(query, conn, transaction);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string schoolYear = txtSchoolYear.Text.Trim();
            string yearLevel = cmbYearLevel.SelectedItem?.ToString();
            string semester = cmbSemester.SelectedItem?.ToString();
            int programId = Convert.ToInt32(cmbProgram.SelectedValue);

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(schoolYear) || string.IsNullOrEmpty(yearLevel) ||
                string.IsNullOrEmpty(semester) || programId == 0)
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    int userId = GetNextUserId(conn, transaction);

                    // Insert into users
                    string userQuery = "INSERT INTO users (UserId, FirstName, LastName, _Role, Status) VALUES (@UserId, @FirstName, @LastName, 'Student', 'Active')";
                    MySqlCommand cmd = new MySqlCommand(userQuery, conn, transaction);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.ExecuteNonQuery();

                    // Insert into studentrecords
                    string studentQuery = "INSERT INTO studentrecords (UserId, ProgramId, YearLevel) VALUES (@UserId, @ProgramId, @YearLevel)";
                    cmd = new MySqlCommand(studentQuery, conn, transaction);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@ProgramId", programId);
                    cmd.Parameters.AddWithValue("@YearLevel", yearLevel);
                    cmd.ExecuteNonQuery();

                    // Insert into enrollmentrecords
                    string enrollQuery = "INSERT INTO enrollmentrecords (UserId, SchoolYear, Semester, ProgramId, Status) VALUES (@UserId, @SchoolYear, @Semester, @ProgramId, 'Active')";
                    cmd = new MySqlCommand(enrollQuery, conn, transaction);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@SchoolYear", schoolYear);
                    cmd.Parameters.AddWithValue("@Semester", semester);
                    cmd.Parameters.AddWithValue("@ProgramId", programId);
                    cmd.ExecuteNonQuery();

                    string gradesInsertQuery = @"
                        INSERT INTO grades (UserId, CourseId, Status)
                        SELECT @UserId, c.CourseId, 'Enrolled'
                        FROM courses c
                        WHERE c.ProgramId = @ProgramId
                        AND (c.SemesterOffered = @Semester OR c.SemesterOffered IS NULL);";

                    MySqlCommand gradesCmd = new MySqlCommand(gradesInsertQuery, conn, transaction);
                    gradesCmd.Parameters.AddWithValue("@UserId", userId); 
                    gradesCmd.Parameters.AddWithValue("@ProgramId", programId);
                    gradesCmd.Parameters.AddWithValue("@Semester", semester);  
                    gradesCmd.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Student enrolled successfully!");
                    ClearFields();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Enrollment failed: " + ex.Message);
                }
            }
        }

        private void ClearFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtSchoolYear.Clear();
            cmbProgram.SelectedIndex = -1;
            cmbYearLevel.SelectedIndex = -1;
            cmbSemester.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void EnrollStudent_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
