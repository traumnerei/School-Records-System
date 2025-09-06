using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolrecordsPrefinals
{
    public partial class AssignScheduleForm : Form
    {
        private int _studentId;
        private int _courseId;
        private int _userId;
        private string _connectionString = "server=localhost;user=root;database=schoolrecords;password=;";

        public AssignScheduleForm(int userId, int courseId)
        {
            InitializeComponent();
            _courseId = courseId;
            _userId = userId;
            LoadRoomOptions();
            LoadDayOptions();
            LoadTimeOptions();
            LoadUserIdFromStudentId();
            
        }

        private void LoadRoomOptions()
        {
            cmbRoom.Items.AddRange(new string[] { "B306", "B204", "B202", "MN323", "LAB6" });
        }

        private void LoadDayOptions()
        {
            cmbDay.Items.AddRange(new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" });
        }

        private void LoadTimeOptions()
        {
            cmbTime.Items.AddRange(new string[]
            {
                "7:00am - 9:00am",
                "9:00am - 11:00am",
                "1:00pm - 3:00pm",
                "3:00pm - 5:00pm",
                "5:00pm - 7:00pm"
            });
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedRoom = cmbRoom.SelectedItem?.ToString();
            string selectedDay = cmbDay.SelectedItem?.ToString();
            string selectedTime = cmbTime.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(selectedRoom) || string.IsNullOrWhiteSpace(selectedDay) || string.IsNullOrWhiteSpace(selectedTime))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string schedule = $"{selectedDay} {selectedTime}";

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
            INSERT INTO class_schedule (Room, WeeklySchedule, CourseId, UserId)
            VALUES (@Room, @WeeklySchedule, @CourseId, @UserId)
            ON DUPLICATE KEY UPDATE
                Room = VALUES(Room),
                WeeklySchedule = VALUES(WeeklySchedule);";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Room", selectedRoom);
                    cmd.Parameters.AddWithValue("@WeeklySchedule", schedule);
                    cmd.Parameters.AddWithValue("@CourseId", _courseId);
                    cmd.Parameters.AddWithValue("@UserId", _userId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Schedule assigned successfully.");
            this.Close();
        }

        private void LoadUserIdFromStudentId()
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT UserId FROM studentrecords WHERE UserId = @StudentId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", _userId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        _userId = Convert.ToInt32(result);
                    else
                        throw new Exception("User ID for this student not found.");
                }
            }
        }

        private void AssignScheduleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
