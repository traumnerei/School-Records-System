using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SchoolrecordsPrefinals.Resources;


namespace SchoolrecordsPrefinals
{
    public partial class UC_CoursesOverview : UserControl, IRefreshable
    {
        public void RefreshContent()
        {
            LoadCourses();
        }
        public UC_CoursesOverview()
        {
            InitializeComponent();
            LoadCourses();
            FormatGrid();
        }

        private void LoadCourses()
        {
            string _connectionString = "server=localhost;user=root;database=schoolrecords;password=;";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        c.CourseId,
                        c.CourseCode,           -- Include CourseCode
                        c.CourseName, 
                        c.Credits, 
                        CONCAT(u.FirstName, ' ', u.LastName) AS AssignedTeacher
                    FROM courses c
                    LEFT JOIN courseassignments ca ON c.CourseId = ca.CourseId
                    LEFT JOIN users u ON ca.UserId = u.UserId";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dgvCourses.Columns.Clear();
                dgvCourses.DataSource = table;

                // Add Assign button
                DataGridViewButtonColumn assignButton = new DataGridViewButtonColumn
                {
                    HeaderText = "Action",
                    Name = "AssignTeacher",
                    UseColumnTextForButtonValue = false
                };
                dgvCourses.Columns.Add(assignButton);

                foreach (DataGridViewRow row in dgvCourses.Rows)
                {
                    var teacher = row.Cells["AssignedTeacher"].Value?.ToString();
                    row.Cells["AssignTeacher"].Value = string.IsNullOrEmpty(teacher) ? "Assign Teacher" : "Re-Assign Teacher";
                }

                // Optional: Hide CourseId from view but keep it in DataSource for internal logic
                if (dgvCourses.Columns.Contains("CourseId"))
                    dgvCourses.Columns["CourseId"].Visible = false;
            }
        }

        private void dgvCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCourses.Columns[e.ColumnIndex].Name == "AssignTeacher" && e.RowIndex >= 0)
            {
                int courseId = Convert.ToInt32(dgvCourses.Rows[e.RowIndex].Cells["CourseId"].Value);
                string currentTeacher = dgvCourses.Rows[e.RowIndex].Cells["AssignedTeacher"].Value?.ToString();
                new AssignTeacher(courseId, currentTeacher).ShowDialog();
                LoadCourses(); // Refresh
            }
        }


        private void FormatGrid()
        {
            dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCourses.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvCourses.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvCourses.RowTemplate.Height = 40;
            dgvCourses.ReadOnly = true;
            dgvCourses.AllowUserToAddRows = false;
            dgvCourses.AllowUserToDeleteRows = false;
            dgvCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCourses.Dock = DockStyle.Fill;
            dgvCourses.ClearSelection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView1_Resize(object sender, EventArgs e) { }

        private void UC_CoursesOverview_Load(object sender, EventArgs e)
        {

        }
    }
}
