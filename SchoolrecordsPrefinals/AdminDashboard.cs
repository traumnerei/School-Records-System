using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SchoolrecordsPrefinals.Resources;

namespace SchoolrecordsPrefinals
{
    public partial class AdminDashboard : Form
    {
        private string connection = "server=localhost;user=root;database=schoolrecords;password=;";
        int selectedUserId = -1;
        public AdminDashboard()
        {
            InitializeComponent();
            InitializeComboBoxes();
            LoadDataWithFilter();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void InitializeComboBoxes()
        {
            cbStatus.Items.AddRange(new string[] { "All", "Active", "Inactive" });
            cbRole.Items.AddRange(new string[] { "All", "Admin", "Student", "Academic Staff" });
            cbStatus.SelectedIndex = 0;
            cbRole.SelectedIndex = 0;

            cbStatus.SelectedIndexChanged += (s, e) => LoadDataWithFilter();
            cbRole.SelectedIndexChanged += (s, e) => LoadDataWithFilter();
        }
       
        private void LoadDataWithFilter()
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                string query = "SELECT UserId, CONCAT(FirstName, ' ', LastName) AS Name, " +
                               "CASE WHEN _Role = 'Academic Staff' THEN CONCAT(_Role, ' - ', PermissionLevel) ELSE _Role END AS Role, " +
                               "Status FROM users WHERE 1=1";

                if (cbStatus.SelectedItem.ToString() != "All")
                    query += " AND Status = @status";
                if (cbRole.SelectedItem.ToString() != "All")
                    query += " AND _Role = @role";

                if (!string.IsNullOrWhiteSpace(txtbsearchbar.Text))
                    query += " AND (CAST(UserId AS CHAR) LIKE @search OR FirstName LIKE @search OR LastName LIKE @search)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (cbStatus.SelectedItem.ToString() != "All")
                    cmd.Parameters.AddWithValue("@status", cbStatus.SelectedItem.ToString());
                if (cbRole.SelectedItem.ToString() != "All")
                    cmd.Parameters.AddWithValue("@role", cbRole.SelectedItem.ToString());
                if (!string.IsNullOrWhiteSpace(txtbsearchbar.Text))
                    cmd.Parameters.AddWithValue("@search", txtbsearchbar.Text + "%");

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                if (dataGridView1.Columns.Contains("btnEdit"))
                    dataGridView1.Columns.Remove("btnEdit");
                if (dataGridView1.Columns.Contains("btnStatus"))
                    dataGridView1.Columns.Remove("btnStatus");

                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn
                {
                    Name = "btnEdit",
                    HeaderText = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(btnEdit);

                DataGridViewButtonColumn btnStatus = new DataGridViewButtonColumn
                {
                    Name = "btnStatus",
                    HeaderText = "Status",
                    UseColumnTextForButtonValue = false
                };
                dataGridView1.Columns.Add(btnStatus);

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string status = row.Cells["Status"].Value?.ToString();
                    row.Cells["btnStatus"].Value = (status == "Active") ? "Deactivate" : "Reactivate";
                }

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    if (col.Name != "btnEdit" && col.Name != "btnStatus")
                        col.ReadOnly = true;
                }
            }
        }



        private void btnlogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                selectedUserId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["UserId"].Value);
        }

        private void txtbsearchbar_TextChanged(object sender, EventArgs e)
        {
            LoadDataWithFilter();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "btnEdit")
                {
                    selectedUserId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["UserId"].Value);
                    new AddEditUserform(selectedUserId).ShowDialog();
                    LoadDataWithFilter();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "btnStatus")
                {
                    selectedUserId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["UserId"].Value);
                    string currentStatus = dataGridView1.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                    string action = (currentStatus == "Active") ? "deactivate" : "reactivate";

                    DialogResult confirm = MessageBox.Show(
                        $"You are about to {action} a user. Do you want to proceed?",
                        $"{action.ToUpper()} USER",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirm == DialogResult.Yes)
                    {
                        using (MySqlConnection conn = new MySqlConnection(connection))
                        {
                            conn.Open();
                            string newStatus = (currentStatus == "Active") ? "Inactive" : "Active";
                            string updateQuery = "UPDATE users SET Status = @status WHERE UserId = @id";
                            MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                            cmd.Parameters.AddWithValue("@status", newStatus);
                            cmd.Parameters.AddWithValue("@id", selectedUserId);
                            cmd.ExecuteNonQuery();
                        }

                        LoadDataWithFilter();
                    }
                }

            }
        }


        private void btnadd_Click(object sender, EventArgs e)
        {
            new AddEditUserform().ShowDialog();
            LoadDataWithFilter();
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




        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataWithFilter();
        }

        private void dashboardheader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}