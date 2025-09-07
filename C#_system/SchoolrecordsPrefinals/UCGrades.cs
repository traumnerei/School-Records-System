using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolrecordsPrefinals
{
    public partial class UCGrades : UserControl
    {
        private string connectionString = "server=localhost;database=schoolrecords;uid=root;pwd=;";
        private int _userId;

        public UCGrades(int userId)
        {
            InitializeComponent();
            _userId = userId;
            FormatGrid();

            LoadStudentGrades();
        }

        private void FormatGrid()
        {
            dgvGrades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGrades.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvGrades.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvGrades.RowTemplate.Height = 40;
            dgvGrades.ReadOnly = true;
            dgvGrades.AllowUserToAddRows = false;
            dgvGrades.AllowUserToDeleteRows = false;
            dgvGrades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGrades.Dock = DockStyle.Fill;
            dgvGrades.ClearSelection();
        }

        private void LoadStudentGrades()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            c.CourseName AS 'Subject Name',
                            c.Credits,
                            CONCAT(tu.FirstName, ' ', tu.LastName) AS 'Teacher Name',
                            g.PrelimGrade,
                            g.MidtermGrade,
                            g.FinalsGrade,
                            g.Status
                        FROM grades g
                        JOIN courses c ON g.CourseId = c.CourseId
                        LEFT JOIN courseassignments ca ON ca.CourseId = c.CourseId
                        LEFT JOIN users tu ON tu.UserId = ca.UserId
                        WHERE g.UserId = @UserId
                        ORDER BY c.CourseName ASC;";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", _userId);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dgvGrades.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("No grades found for this student.");
                        dgvGrades.DataSource = null;
                    }

                    dgvGrades.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading grades: " + ex.Message);
                }
            }
        }

        private void dgvGrades_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void UCGrades_Load(object sender, EventArgs e) { }
    }
}
