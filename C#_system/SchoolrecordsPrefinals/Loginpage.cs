using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SchoolrecordsPrefinals
{
    public partial class loginform : Form
    {
        private string _role;

        public loginform(string role)
        {
            InitializeComponent();
            _role = role;
            ApplyRoleStyle(role);
            UpdateLoginTitle(role);
            txtPassword.PasswordChar = '●';
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ApplyRoleStyle(string role)
        {
            switch (role.ToLower())
            {
                case "admin":
                    centerpanel.BackColor = ColorTranslator.FromHtml("#2C3E50");
                    centerpanel.ForeColor = Color.White;
                    break;
                case "student":
                    centerpanel.BackColor = ColorTranslator.FromHtml("#4AA8E0");
                    centerpanel.ForeColor = Color.White;
                    break;
                case "academic staff":
                case "teacher":
                    centerpanel.BackColor = ColorTranslator.FromHtml("#52B788");
                    centerpanel.ForeColor = Color.White;
                    break;
                default:
                    centerpanel.BackColor = ColorTranslator.FromHtml("#FFA500");
                    centerpanel.ForeColor = Color.White;
                    break;

                 
            }
        }

        private void UpdateLoginTitle(string role)
        {
            lblRoletitle.Text = $"{role} Login";
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string inputId = txtUserID.Text.Trim();
            string password = txtPassword.Text.Trim();


            string connection = "server=localhost;user=root;database=schoolrecords;password=;";
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd = null;
                    string query = "";
                    Form nextForm = null;

                    if (_role.ToLower() == "student")
                    {
                        query = @"SELECT u.UserId, sr.UserId
                                  FROM users u
                                  JOIN studentrecords sr ON u.UserId = sr.UserId
                                  WHERE u.UserId = @UserId AND u.Password = @Password AND u.Status = 'Active' AND u._Role = 'Student'";
                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@UserId", inputId);
                    }
                    else if (_role.ToLower() == "teacher")
                    {
                        query = @"SELECT * FROM users 
                                  WHERE UserId = @UserId AND Password = @Password AND Status = 'Active' AND _Role = 'Teacher'";
                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@UserId", inputId);
                    }
                    else if (_role.ToLower() == "academic staff")
                    {
                        query = @"SELECT * FROM users 
                                  WHERE UserId = @UserId AND Password = @Password AND Status = 'Active' AND _Role = 'AcademicStaff'";
                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@UserId", inputId);
                    }
                    else if (_role.ToLower() == "admin")
                    {
                        query = @"SELECT * FROM users 
                                    WHERE UserId = @UserId AND Password = @Password AND Status = 'Active' AND _Role = 'Admin'";
                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@UserId", inputId);

                    }
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            MessageBox.Show("Login successful!");
                            this.Hide();

                            switch (_role.ToLower())
                            {
                                case "student":
                                    int UserId = Convert.ToInt32(reader["UserId"]);
                                    nextForm = new StudentDashboard(UserId);  // Pass student ID
                                    break;

                                case "teacher":
                                    int teacherUserId = Convert.ToInt32(reader["UserId"]);
                                    nextForm = new TeacherDashboard(teacherUserId);  // Pass teacher ID
                                    break;

                                case "admin":
                                    nextForm = new AdminDashboard();
                                    break;

                                case "academic staff":
                                    string permission = reader["PermissionLevel"].ToString();
                                    if (permission == "Registrar")
                                    {
                                        int userId = Convert.ToInt32(reader["UserId"]);
                                        nextForm = new RegistrarDashboard(userId);
                                    }       
                                    else if (permission == "Dean")
                                    {
                                        int userId = Convert.ToInt32(reader["UserId"]);
                                        nextForm = new DeanDashboard(userId);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid permission level.");
                                        this.Show();
                                        return;
                                    }
                                    break;

                                default:
                                    MessageBox.Show("Unknown role.");
                                    this.Show();
                                    return;
                            }

                            nextForm.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid ID or Password.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void centerpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '●')
            {
                txtPassword.PasswordChar = '\0'; // Show password
                btnTogglePassword.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                txtPassword.PasswordChar = '●'; // Hide password
                btnTogglePassword.FlatStyle = FlatStyle.Flat;
            }
        }


        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblRoletitle_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginform_Load(object sender, EventArgs e)
        {

        }
    }
}
