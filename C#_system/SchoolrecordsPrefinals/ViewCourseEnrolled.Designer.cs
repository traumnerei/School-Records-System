namespace SchoolrecordsPrefinals
{
    partial class ViewCourseEnrolled
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvEnrolledCourses = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnrolledCourses)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEnrolledCourses
            // 
            this.dgvEnrolledCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnrolledCourses.Location = new System.Drawing.Point(12, 12);
            this.dgvEnrolledCourses.Name = "dgvEnrolledCourses";
            this.dgvEnrolledCourses.Size = new System.Drawing.Size(776, 389);
            this.dgvEnrolledCourses.TabIndex = 0;
            this.dgvEnrolledCourses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEnrolledCourses_CellContentClick_1);
            // 
            // ViewCourseEnrolled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 413);
            this.Controls.Add(this.dgvEnrolledCourses);
            this.Name = "ViewCourseEnrolled";
            this.Text = "ViewCourseEnrolled";
            this.Load += new System.EventHandler(this.ViewCourseEnrolled_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnrolledCourses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEnrolledCourses;
    }
}