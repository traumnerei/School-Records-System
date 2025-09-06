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
    public partial class Override : Form
    {
        private int _gradeId;
        private string _connectionString = "server=localhost;user=root;database=schoolrecords;password=;";

        public Override(int gradeId)
        {
            InitializeComponent();
            _gradeId = gradeId;
            LoadGradeDetails();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Override_Load(object sender, EventArgs e)
        {

        }

        private void LoadGradeDetails()
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT PrelimGrade, MidtermGrade, FinalsGrade FROM grades WHERE GradeId = @GradeId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@GradeId", _gradeId);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtPrelim.Text = reader["PrelimGrade"].ToString();
                        txtMidterm.Text = reader["MidtermGrade"].ToString();
                        txtFinal.Text = reader["FinalsGrade"].ToString();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double prelim = Convert.ToDouble(txtPrelim.Text);
                double midterm = Convert.ToDouble(txtMidterm.Text);
                double finals = Convert.ToDouble(txtFinal.Text);

                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string updateQuery = @"UPDATE grades 
                                           SET PrelimGrade = @Prelim, MidtermGrade = @Midterm, FinalsGrade = @Finals 
                                           WHERE GradeId = @GradeId";
                    MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@Prelim", prelim);
                    cmd.Parameters.AddWithValue("@Midterm", midterm);
                    cmd.Parameters.AddWithValue("@Finals", finals);
                    cmd.Parameters.AddWithValue("@GradeId", _gradeId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Grades successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating grades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
   
