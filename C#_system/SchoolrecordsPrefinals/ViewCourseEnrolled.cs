using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolrecordsPrefinals
{
    public partial class ViewCourseEnrolled : Form
    {
        private int _userId;
        private bool _isRegistrar;
        private readonly string _connectionString = "server=localhost;user=root;database=schoolrecords;password=;";

        public ViewCourseEnrolled(int userId, bool isRegistrar)
        {
            InitializeComponent();
            _userId = userId;
            _isRegistrar = isRegistrar;
            FormatGrid();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void ViewCourseEnrolled_Load(object sender, EventArgs e)
        {
            LoadStudentCourses();
        }

        private void LoadStudentCourses()
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        c.CourseCode,
                        c.CourseName,
                        g.PrelimGrade,
                        g.MidtermGrade,
                        g.FinalsGrade,
                        g.GradeId
                    FROM grades g
                    JOIN courses c ON g.CourseId = c.CourseId
                    WHERE g.UserId = @UserId;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", _userId);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvEnrolledCourses.Columns.Clear();
                dgvEnrolledCourses.DataSource = dt;

                // Hide GradeId (internal use only)
                if (dgvEnrolledCourses.Columns.Contains("GradeId"))
                    dgvEnrolledCourses.Columns["GradeId"].Visible = false;


                if (_isRegistrar)
                {
                    var overrideBtn = new DataGridViewButtonColumn
                    {
                        Name = "btnOverride",
                        HeaderText = "Action",
                        Text = "Override",
                        UseColumnTextForButtonValue = true
                    };
                    dgvEnrolledCourses.Columns.Add(overrideBtn);
                }

                dgvEnrolledCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvEnrolledCourses.AllowUserToAddRows = false;
            }
        }

        private void dgvEnrolledCourses_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Only registrar can click and open override
            if (_isRegistrar &&
                dgvEnrolledCourses.Columns[e.ColumnIndex].Name == "btnOverride" &&
                e.RowIndex >= 0)
            {
                int gradeId = Convert.ToInt32(dgvEnrolledCourses.Rows[e.RowIndex].Cells["GradeId"].Value);
                Override overrideForm = new Override(gradeId);

                if (overrideForm.ShowDialog() == DialogResult.OK)
                {
                    LoadStudentCourses(); // Refresh
                }
            }
        }


        private void FormatGrid()
        {
            dgvEnrolledCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEnrolledCourses.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvEnrolledCourses.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvEnrolledCourses.RowTemplate.Height = 40;
            dgvEnrolledCourses.ReadOnly = true;
            dgvEnrolledCourses.AllowUserToAddRows = false;
            dgvEnrolledCourses.AllowUserToDeleteRows = false;
            dgvEnrolledCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEnrolledCourses.Dock = DockStyle.Fill;
            dgvEnrolledCourses.ClearSelection();
        }
    }
}
