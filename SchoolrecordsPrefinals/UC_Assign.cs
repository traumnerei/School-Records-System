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
using SchoolrecordsPrefinals.Resources;


namespace SchoolrecordsPrefinals
{
    public partial class UC_Assign : UserControl, IRefreshable
    {
        public void RefreshContent()
        {
            LoadEnrolledStudents();
        }

        public UC_Assign()
        {
            InitializeComponent();
            FormatGrid();
        }
            
        private string connectionString = "server=localhost;user=root;database=schoolrecords;password=;";

        private void LoadEnrolledStudents()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
        SELECT 
            sr.UserId,
            CONCAT(u.FirstName, ' ', u.LastName) AS FullName,
            p.ProgramName,
            sr.YearLevel,
            ca.CourseId,
            c.CourseName
        FROM studentrecords sr
        JOIN users u ON sr.UserId = u.UserId
        JOIN programs p ON sr.ProgramId = p.ProgramId
        JOIN enrollmentrecords er ON sr.UserId = er.UserId
        JOIN courses c ON er.ProgramId = c.ProgramId
        JOIN courseassignments ca ON ca.CourseId = c.CourseId
        WHERE er.Status = 'Active'
        AND NOT EXISTS (
            SELECT 1 FROM class_schedule cs
            WHERE cs.UserId = sr.UserId AND cs.CourseId = ca.CourseId
        )";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvAssignSchedule.Columns.Clear();
                dgvAssignSchedule.DataSource = dt;

                // Optional: Hide CourseId column
                if (dgvAssignSchedule.Columns.Contains("CourseId"))
                    dgvAssignSchedule.Columns["CourseId"].Visible = false;

                // Add Assign Schedule button
                DataGridViewButtonColumn assignBtn = new DataGridViewButtonColumn
                {
                    HeaderText = "Action",
                    Name = "AssignSchedule",
                    Text = "Assign Schedule",
                    UseColumnTextForButtonValue = true
                };
                dgvAssignSchedule.Columns.Add(assignBtn);

                dgvAssignSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvAssignSchedule.ReadOnly = true;
                dgvAssignSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvAssignSchedule.AllowUserToAddRows = false;
            }
        }


        private void dgvAssignSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAssignSchedule.Columns[e.ColumnIndex].Name == "AssignSchedule" && e.RowIndex >= 0)
            {
                int userId = Convert.ToInt32(dgvAssignSchedule.Rows[e.RowIndex].Cells["UserId"].Value);
                int courseId = Convert.ToInt32(dgvAssignSchedule.Rows[e.RowIndex].Cells["CourseId"].Value);

                AssignScheduleForm form = new AssignScheduleForm(userId, courseId);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadEnrolledStudents(); // Refresh to remove the newly assigned student
                }
            }
        }



        private void UC_Assign_Load(object sender, EventArgs e)
        {
            LoadEnrolledStudents();
        }
        private void FormatGrid()
        {
            dgvAssignSchedule.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvAssignSchedule.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvAssignSchedule.RowTemplate.Height = 40;
            dgvAssignSchedule.ReadOnly = true;
            dgvAssignSchedule.AllowUserToAddRows = false;
            dgvAssignSchedule.AllowUserToDeleteRows = false;
            dgvAssignSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAssignSchedule.Dock = DockStyle.Fill;
            dgvAssignSchedule.ClearSelection();
        }
    }
}
