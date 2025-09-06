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
    public partial class SelectRole : Form
    {
        public SelectRole()
        {
            InitializeComponent();
            StyleRoleButtons();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnadmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginform login = new loginform("Admin");
            login.ShowDialog();
            this.Show();
        }

        private void btnstaff_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginform login = new loginform("Academic Staff");
            login.ShowDialog();
            this.Show();
        }
        private void btnstudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginform login = new loginform("Student");
            login.ShowDialog();
            this.Show();
        }
        private void btnteacher_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginform login = new loginform("Teacher");
            login.ShowDialog();
            this.Show();
        }

        private void StyleRoleButtons()
        {
            // STUDENT Button
            btnStudent.BackColor = ColorTranslator.FromHtml("#4AA8E0"); 
            btnStudent.ForeColor = Color.White;
            btnStudent.FlatStyle = FlatStyle.Flat;
            btnStudent.FlatAppearance.BorderSize = 0;
           

            // TEACHER Button
            btnTeacher.BackColor = ColorTranslator.FromHtml("#52B788"); 
            btnTeacher.ForeColor = Color.White;
            btnTeacher.FlatStyle = FlatStyle.Flat;
            btnTeacher.FlatAppearance.BorderSize = 0;
          

            // STAFF Button
            btnstaff.BackColor = ColorTranslator.FromHtml("#FFA500"); 
            btnstaff.ForeColor = Color.White;
            btnstaff.FlatStyle = FlatStyle.Flat;
            btnstaff.FlatAppearance.BorderSize = 0;

            //ADMIN Button
            btnadmin.BackColor = ColorTranslator.FromHtml("#2C3E50"); 
            btnadmin.ForeColor = Color.White;
            btnadmin.FlatStyle = FlatStyle.Flat;
            btnadmin.FlatAppearance.BorderSize = 0;

            panel1.BackColor = ColorTranslator.FromHtml("#D9E4EC");
            Centerpanel.BackColor = ColorTranslator.FromHtml("#EDEDED"); 
            
        }


        private void Centerpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RoleselectionHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rolesbox_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
