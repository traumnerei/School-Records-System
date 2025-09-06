using MySql.Data.MySqlClient;
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
    public partial class AssignTeacher : Form
    {
        private int _courseId;
        private string _currentTeacher;
        private string _connectionString = "server=localhost;user=root;database=schoolrecords;password=;";
        public AssignTeacher(int courseId, string currentTeacher)
        {
            InitializeComponent();
            _courseId = courseId;
            _currentTeacher = currentTeacher;
        }

        private void AssignTeacher_Load(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT UserId, CONCAT(FirstName, ' ', LastName) AS FullName FROM users WHERE _Role = 'Teacher'";
                if (!string.IsNullOrEmpty(_currentTeacher))
                {
                    query += " AND CONCAT(FirstName, ' ', LastName) <> @CurrentTeacher";
                }

                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (!string.IsNullOrEmpty(_currentTeacher))
                {
                    cmd.Parameters.AddWithValue("@CurrentTeacher", _currentTeacher);
                }

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable teacherTable = new DataTable();
                    teacherTable.Load(reader);
                    cmbTeachers.DataSource = teacherTable;
                    cmbTeachers.DisplayMember = "FullName";
                    cmbTeachers.ValueMember = "UserId";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedTeacherId = Convert.ToInt32(cmbTeachers.SelectedValue);

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                // If already assigned, update
                string checkQuery = "SELECT COUNT(*) FROM courseassignments WHERE CourseId = @CourseId";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@CourseId", _courseId);
                int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (exists > 0)
                {
                    DialogResult result = MessageBox.Show(
                        "You are about to change the assigned teacher to this course. Do you want to proceed?",
                        "Reassign Teacher",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result != DialogResult.Yes) return;

                    string update = "UPDATE courseassignments SET UserId = @UserId WHERE CourseId = @CourseId";
                    MySqlCommand updateCmd = new MySqlCommand(update, conn);
                    updateCmd.Parameters.AddWithValue("@UserId", selectedTeacherId);
                    updateCmd.Parameters.AddWithValue("@CourseId", _courseId);
                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    string insert = "INSERT INTO courseassignments (CourseId, UserId) VALUES (@CourseId, @UserId)";
                    MySqlCommand insertCmd = new MySqlCommand(insert, conn);
                    insertCmd.Parameters.AddWithValue("@CourseId", _courseId);
                    insertCmd.Parameters.AddWithValue("@UserId", selectedTeacherId);
                    insertCmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Teacher assignment updated.");
            this.Close();
        }
    }
}