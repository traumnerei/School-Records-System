namespace SchoolrecordsPrefinals
{
    partial class class_sched
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
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.AllowUserToResizeColumns = false;
            this.dgvSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Location = new System.Drawing.Point(19, 47);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.Size = new System.Drawing.Size(593, 307);
            this.dgvSchedule.TabIndex = 0;
            this.dgvSchedule.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSchedule_CellContentClick);
            // 
            // class_sched
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvSchedule);
            this.Name = "class_sched";
            this.Size = new System.Drawing.Size(628, 409);
            this.Load += new System.EventHandler(this.class_sched_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSchedule;
    }
}
