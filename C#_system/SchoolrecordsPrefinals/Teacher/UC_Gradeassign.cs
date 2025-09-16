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
    public partial class UC_Gradeassign : Form
    {

        private int _userId;
        private int _courseId;

        public UC_Gradeassign(int userId, int courseId)
        {
            InitializeComponent();
            _userId = userId;
            _courseId = courseId;
            comboTerm.Items.AddRange(new string[] { "Prelim", "Midterm", "Finals" });
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void UC_Gradeassign_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string term = comboTerm.SelectedItem?.ToString();
            string gradeText = txtGrade.Text.Trim();

            if (string.IsNullOrEmpty(term) || string.IsNullOrEmpty(gradeText))
            {
                MessageBox.Show("Please enter grade and select term.");
                return;
            }

            if (!decimal.TryParse(gradeText, out decimal grade))
            {
                MessageBox.Show("Invalid grade value.");
                return;
            }

            string column = "";
            if (term == "Prelim") column = "PrelimGrade";
            else if (term == "Midterm") column = "MidtermGrade";
            else if (term == "Finals") column = "FinalsGrade";

            string connection = "server=localhost;user=root;database=schoolrecords;password=;";
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();

                // Check if a record exists
                string check = "SELECT GradeId FROM grades WHERE UserId = @sid AND CourseId = @cid";
                MySqlCommand checkCmd = new MySqlCommand(check, conn);
                checkCmd.Parameters.AddWithValue("@sid", _userId);
                checkCmd.Parameters.AddWithValue("@cid", _courseId);

                object exists = checkCmd.ExecuteScalar();

                string sql;
                if (exists != null)
                {
                    sql = $"UPDATE grades SET {column} = @grade WHERE UserId = @sid AND CourseId = @cid";
                }
                else
                {
                    sql = $"INSERT INTO grades (UserId, CourseId, {column}) VALUES (@sid, @cid, @grade)";
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@grade", grade);
                cmd.Parameters.AddWithValue("@sid", _userId);
                cmd.Parameters.AddWithValue("@cid", _courseId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show($"{term} grade saved.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtGrade_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
