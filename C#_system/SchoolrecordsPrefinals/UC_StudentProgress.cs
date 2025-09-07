using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolrecordsPrefinals
{
    public partial class UC_StudentProgress : UserControl
    {
        private string connection = "server=localhost;user=root;database=schoolrecords;password=;";

        public UC_StudentProgress()
        {
            InitializeComponent();
            LoadStudentProgress();
        }

        private void LoadStudentProgress()
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT s.StudentId, u.FirstName, u.LastName, s.YearLevel,
                               COUNT(sr.CourseId) AS TotalCourses,
                               SUM(CASE WHEN sr.Status = 'Passed' THEN 1 ELSE 0 END) AS CoursesPassed,
                               SUM(CASE WHEN sr.Status = 'Failed' THEN 1 ELSE 0 END) AS CoursesFailed
                        FROM Students s
                        JOIN Users u ON s.UserId = u.UserId
                        LEFT JOIN StudentRecords sr ON sr.StudentId = s.StudentId
                        GROUP BY s.StudentId";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvProgress.DataSource = dt;
                    dgvProgress.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading student progress: " + ex.Message);
                }
            }
        }
    }
}
