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
    public partial class ManageStudent : UserControl, IRefreshable
    {
        public void RefreshContent()
        {
            LoadStudents();
        }

        private string _connectionString = "server=localhost;user=root;database=schoolrecords;password=;";
        public ManageStudent()
        {
            InitializeComponent();
            FormatGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStudents.Columns[e.ColumnIndex].Name == "ViewCourses" && e.RowIndex >= 0)
            {
                int userId = Convert.ToInt32(dgvStudents.Rows[e.RowIndex].Cells["UserId"].Value);
                string fullName = dgvStudents.Rows[e.RowIndex].Cells["FullName"].Value.ToString();

                // Open a new form or control with course info
                new ViewCourseEnrolled(userId,true).ShowDialog();
            }
        }

        private void ManageStudent_Load(object sender, EventArgs e)
        {

            LoadStudents();
        }

        private void LoadStudents()
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
            SELECT 
                sr.UserId,
                CONCAT(u.FirstName, ' ', u.LastName) AS FullName,
                p.ProgramName,
                sr.YearLevel
            FROM studentrecords sr
            LEFT JOIN users u ON sr.UserId = u.UserId
            LEFT JOIN programs p ON sr.ProgramId = p.ProgramId";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvStudents.Columns.Clear();
                dgvStudents.DataSource = dt;

                // Add View Courses button
                DataGridViewButtonColumn viewBtn = new DataGridViewButtonColumn();
                viewBtn.HeaderText = "Action";
                viewBtn.Text = "View Enrolled Courses";
                viewBtn.UseColumnTextForButtonValue = true;
                viewBtn.Name = "ViewCourses";
                dgvStudents.Columns.Add(viewBtn);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void FormatGrid()
        {
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvStudents.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvStudents.RowTemplate.Height = 40;
            dgvStudents.ReadOnly = true;
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Dock = DockStyle.Fill;
            dgvStudents.ClearSelection();
        }
    }
}