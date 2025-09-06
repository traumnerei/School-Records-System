using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;


namespace SchoolrecordsPrefinals
{
    public partial class AddCourse1 : UserControl
    {
        public event EventHandler CourseAdded;

        private string _connectionString = "server=localhost;user=root;database=schoolrecords;password=;";

        public AddCourse1()
        {
            InitializeComponent();
        }

        private void AddCourse1_Load(object sender, EventArgs e)
        {
            LoadPrograms();
            LoadSemesters();
        }

        private void LoadPrograms()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error loading programs: " + ex.Message);
            }
        }

        private void LoadSemesters()
        {
            cmbSem.Items.Clear();
            cmbSem.Items.Add("1st Semester");
            cmbSem.Items.Add("2nd Semester");
            cmbSem.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCourseName.Text) || string.IsNullOrWhiteSpace(txtCredits.Text) ||
                    string.IsNullOrWhiteSpace(txtCode.Text) || cmbProgram.SelectedIndex == -1 || cmbSem.SelectedIndex == -1)
                {
                    MessageBox.Show("Please fill out all fields.");
                    return;
                }

                if (!int.TryParse(txtCredits.Text, out int credits))
                {
                    MessageBox.Show("Credits must be a valid number.");
                    return;
                }

                int programId = Convert.ToInt32(cmbProgram.SelectedValue);
                string semester = cmbSem.SelectedItem.ToString();

                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string insertQuery = @"
                        INSERT INTO courses (CourseName, Credits, CourseCode, ProgramId, SemesterOffered) 
                        VALUES (@name, @credits, @code, @programId, @semester)";

                    MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@name", txtCourseName.Text.Trim());
                    cmd.Parameters.AddWithValue("@credits", credits);
                    cmd.Parameters.AddWithValue("@code", txtCode.Text.Trim());
                    cmd.Parameters.AddWithValue("@programId", programId);
                    cmd.Parameters.AddWithValue("@semester", semester);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Course added successfully.");
                CourseAdded?.Invoke(this, EventArgs.Empty);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding course: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            txtCourseName.Clear();
            txtCredits.Clear();
            txtCode.Clear();
            cmbProgram.SelectedIndex = 0;
            cmbSem.SelectedIndex = 0;
        }
    }
}
