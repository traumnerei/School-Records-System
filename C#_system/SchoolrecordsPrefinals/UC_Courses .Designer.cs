namespace SchoolrecordsPrefinals
{
    partial class UC_Courses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCourses = new System.Windows.Forms.DataGridView();
            this.panelLegend = new System.Windows.Forms.Panel();
            this.top = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.rbtnAvailableCourses = new System.Windows.Forms.RadioButton();
            this.rbtnEnrolledCourses = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            this.panelLegend.SuspendLayout();
            this.top.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(213, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Course List";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvCourses
            // 
            this.dgvCourses.AllowUserToAddRows = false;
            this.dgvCourses.AllowUserToDeleteRows = false;
            this.dgvCourses.AllowUserToResizeColumns = false;
            this.dgvCourses.AllowUserToResizeRows = false;
            this.dgvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCourses.Location = new System.Drawing.Point(0, 41);
            this.dgvCourses.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.ReadOnly = true;
            this.dgvCourses.RowHeadersWidth = 51;
            this.dgvCourses.RowTemplate.Height = 30;
            this.dgvCourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCourses.Size = new System.Drawing.Size(562, 365);
            this.dgvCourses.TabIndex = 1;
            this.dgvCourses.TabStop = false;
            this.dgvCourses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCourses_CellContentClick);
            // 
            // panelLegend
            // 
            this.panelLegend.Controls.Add(this.rbtnAvailableCourses);
            this.panelLegend.Controls.Add(this.rbtnEnrolledCourses);
            this.panelLegend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLegend.Location = new System.Drawing.Point(0, 365);
            this.panelLegend.Margin = new System.Windows.Forms.Padding(2);
            this.panelLegend.Name = "panelLegend";
            this.panelLegend.Size = new System.Drawing.Size(562, 41);
            this.panelLegend.TabIndex = 2;
            // 
            // top
            // 
            this.top.Controls.Add(this.txtSearch);
            this.top.Controls.Add(this.label3);
            this.top.Controls.Add(this.btnReload);
            this.top.Controls.Add(this.label1);
            this.top.Dock = System.Windows.Forms.DockStyle.Top;
            this.top.Location = new System.Drawing.Point(0, 0);
            this.top.Margin = new System.Windows.Forms.Padding(2);
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(562, 41);
            this.top.TabIndex = 3;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(65, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Search:";
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReload.AutoSize = true;
            this.btnReload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReload.Location = new System.Drawing.Point(473, 12);
            this.btnReload.Margin = new System.Windows.Forms.Padding(2);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(60, 23);
            this.btnReload.TabIndex = 1;
            this.btnReload.Text = "Referesh";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // rbtnAvailableCourses
            // 
            this.rbtnAvailableCourses.AutoSize = true;
            this.rbtnAvailableCourses.Location = new System.Drawing.Point(96, 13);
            this.rbtnAvailableCourses.Name = "rbtnAvailableCourses";
            this.rbtnAvailableCourses.Size = new System.Drawing.Size(109, 17);
            this.rbtnAvailableCourses.TabIndex = 6;
            this.rbtnAvailableCourses.TabStop = true;
            this.rbtnAvailableCourses.Text = "Available Courses";
            this.rbtnAvailableCourses.UseVisualStyleBackColor = true;
            this.rbtnAvailableCourses.CheckedChanged += new System.EventHandler(this.rbtnAvailableCourses_CheckedChanged);
            // 
            // rbtnEnrolledCourses
            // 
            this.rbtnEnrolledCourses.AutoSize = true;
            this.rbtnEnrolledCourses.Location = new System.Drawing.Point(362, 13);
            this.rbtnEnrolledCourses.Name = "rbtnEnrolledCourses";
            this.rbtnEnrolledCourses.Size = new System.Drawing.Size(107, 17);
            this.rbtnEnrolledCourses.TabIndex = 7;
            this.rbtnEnrolledCourses.TabStop = true;
            this.rbtnEnrolledCourses.Text = "Currently Enrolled";
            this.rbtnEnrolledCourses.UseVisualStyleBackColor = true;
            this.rbtnEnrolledCourses.CheckedChanged += new System.EventHandler(this.rbtnEnrolledCourses_CheckedChanged);
            // 
            // UC_Courses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelLegend);
            this.Controls.Add(this.dgvCourses);
            this.Controls.Add(this.top);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UC_Courses";
            this.Size = new System.Drawing.Size(562, 406);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            this.panelLegend.ResumeLayout(false);
            this.panelLegend.PerformLayout();
            this.top.ResumeLayout(false);
            this.top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCourses;
        private System.Windows.Forms.Panel panelLegend;
        private System.Windows.Forms.Panel top;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtnAvailableCourses;
        private System.Windows.Forms.RadioButton rbtnEnrolledCourses;
    }
}