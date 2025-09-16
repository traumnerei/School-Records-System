namespace SchoolrecordsPrefinals
{
    partial class UC_Assign
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
            this.dgvAssignSchedule = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAssignSchedule
            // 
            this.dgvAssignSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssignSchedule.Location = new System.Drawing.Point(18, 72);
            this.dgvAssignSchedule.Name = "dgvAssignSchedule";
            this.dgvAssignSchedule.Size = new System.Drawing.Size(583, 309);
            this.dgvAssignSchedule.TabIndex = 0;
            this.dgvAssignSchedule.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAssignSchedule_CellContentClick);
            // 
            // UC_Assign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvAssignSchedule);
            this.Name = "UC_Assign";
            this.Size = new System.Drawing.Size(620, 401);
            this.Load += new System.EventHandler(this.UC_Assign_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignSchedule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAssignSchedule;
    }
}
