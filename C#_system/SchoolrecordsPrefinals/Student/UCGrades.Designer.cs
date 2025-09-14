using System.Windows.Forms;

namespace SchoolrecordsPrefinals
{
    partial class UCGrades
    {
        private DataGridView dgvGrades;

        private void InitializeComponent()
        {
            this.dgvGrades = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGrades
            // 
            this.dgvGrades.AllowUserToAddRows = false;
            this.dgvGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrades.Location = new System.Drawing.Point(30, 79);
            this.dgvGrades.Name = "dgvGrades";
            this.dgvGrades.Size = new System.Drawing.Size(750, 322);
            this.dgvGrades.TabIndex = 5;
            this.dgvGrades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrades_CellContentClick);
            // 
            // UCGrades
            // 
            this.Controls.Add(this.dgvGrades);
            this.Name = "UCGrades";
            this.Size = new System.Drawing.Size(820, 480);
            this.Load += new System.EventHandler(this.UCGrades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
