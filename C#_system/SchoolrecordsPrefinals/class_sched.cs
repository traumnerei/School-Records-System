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
    public partial class class_sched : UserControl
    {
        private int _userId;
        private string _connectionString = "server=localhost;user=root;database=schoolrecords;password=;";

        public class_sched(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadSchedule();
        }

        private void LoadSchedule()
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"
                SELECT 
                    c.CourseCode AS 'Course Code',
                    c.CourseName AS 'Course Name',
                    s.WeeklySchedule AS 'Schedule',
                    s.Room AS 'Room #'
                FROM class_schedule s
                JOIN courses c ON s.CourseId = c.CourseId
                WHERE s.UserId = @UserId";  // Use s.UserId directly

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", _userId);  // Updated parameter name

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvSchedule.DataSource = dt;
                FormatGrid();
            }
        }


        private void FormatGrid()
        {
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedule.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvSchedule.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvSchedule.RowTemplate.Height = 40;
            dgvSchedule.ReadOnly = true;
            dgvSchedule.AllowUserToAddRows = false;
            dgvSchedule.AllowUserToDeleteRows = false;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedule.Dock = DockStyle.Fill;  
            dgvSchedule.ClearSelection();
        }

        private void UC_ViewSchedule_Load(object sender, EventArgs e)
        {
            // LoadSchedule already called in constructor
        }

        private void class_sched_Load(object sender, EventArgs e)
        {

        }

        private void dgvSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
