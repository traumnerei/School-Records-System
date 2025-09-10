using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolrecordsPrefinals
{
    public partial class AddEditUserform : Form
    {
        private string connection = "server=localhost;user=root;database=schoolrecords;password=;";
        private int? userIdToEdit = null;

        public AddEditUserform(int? userId = null)
        {
            InitializeComponent();
            userIdToEdit = userId;

            LoadComboBoxes();
            this.StartPosition = FormStartPosition.CenterScreen;

            if (userIdToEdit.HasValue)
                LoadUserData(userIdToEdit.Value);

            cbRole.SelectedIndexChanged += cbRole_SelectedIndexChanged; 
        }

        private void LoadComboBoxes()
        {
            cbRole.Items.Clear();
            cbRole.Items.AddRange(new string[] { "Admin", "Student", "Academic Staff", "Teacher" });
            cbPermissiolvl.Items.Clear();
            cbPermissiolvl.Items.AddRange(new string[] { "Registrar", "Dean" });

            cbRole.SelectedIndex = 0;
            cbPermissiolvl.Visible = false;
        }

        private int GetNextUserId()
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string query = "SELECT IFNULL(MAX(UserId), 2500) + 1 FROM users";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFirstName.Text) ||
                string.IsNullOrWhiteSpace(tbLastName.Text) ||
                string.IsNullOrWhiteSpace(tbEmail.Text) ||
                string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            string role = cbRole.SelectedItem.ToString();
            string permission = (role == "Academic Staff") ? cbPermissiolvl.SelectedItem?.ToString() : null;

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();

                if (userIdToEdit.HasValue)
                {
                    // Update existing user
                    string updateQuery = @"
                        UPDATE users 
                        SET FirstName=@fname, LastName=@lname, Email=@mail,
                            Password=@pass, _Role=@role, PermissionLevel=@perm
                        WHERE UserId=@id";

                    MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@fname", tbFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@lname", tbLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@mail", tbEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass", tbPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@perm", permission ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", userIdToEdit.Value);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User updated successfully.");
                }
                else
                {
                    // Insert new user with manually generated ID
                    int newUserId = GetNextUserId();

                    string insertQuery = @"
                        INSERT INTO users (UserId, FirstName, LastName, Email, Password, _Role, PermissionLevel, Status)
                        VALUES (@UserId, @FirstName, @LastName, @Email, @Password, @_Role, @PermissionLevel, 'Active')";

                    MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@UserId", newUserId);
                    cmd.Parameters.AddWithValue("@FirstName", tbFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", tbLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", tbEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", tbPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@_Role", role);
                    cmd.Parameters.AddWithValue("@PermissionLevel", permission ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"User added successfully with UserId: {newUserId}");
                }

                this.Close();
            }
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPermissiolvl.Visible = cbRole.SelectedItem.ToString() == "Academic Staff";
        }

        private void LoadUserData(int userId)
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string query = "SELECT * FROM users WHERE UserId = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", userId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tbFirstName.Text = reader["FirstName"].ToString();
                        tbLastName.Text = reader["LastName"].ToString();
                        tbEmail.Text = reader["Email"].ToString();
                        tbPassword.Text = reader["Password"].ToString();
                        cbRole.SelectedItem = reader["_Role"].ToString();

                        if (reader["_Role"].ToString() == "Academic Staff")
                        {
                            cbPermissiolvl.Visible = true;
                            cbPermissiolvl.SelectedItem = reader["PermissionLevel"].ToString();
                        }
                    }
                }
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            tbFirstName.Clear();
            tbLastName.Clear();
            tbEmail.Clear();
            tbPassword.Clear();
            cbRole.SelectedIndex = 0;
            cbPermissiolvl.SelectedIndex = -1;
            cbPermissiolvl.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEditUserform_Load(object sender, EventArgs e)
        {
            // No logic needed here currently
        }
    }
}
