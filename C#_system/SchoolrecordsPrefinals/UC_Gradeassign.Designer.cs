namespace SchoolrecordsPrefinals
{
    partial class UC_Gradeassign
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
            this.button1 = new System.Windows.Forms.Button();
            this.comboTerm = new System.Windows.Forms.ComboBox();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.Status = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(216, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboTerm
            // 
            this.comboTerm.FormattingEnabled = true;
            this.comboTerm.Location = new System.Drawing.Point(23, 47);
            this.comboTerm.Name = "comboTerm";
            this.comboTerm.Size = new System.Drawing.Size(119, 21);
            this.comboTerm.TabIndex = 1;
            // 
            // txtGrade
            // 
            this.txtGrade.Location = new System.Drawing.Point(206, 48);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(109, 20);
            this.txtGrade.TabIndex = 2;
            this.txtGrade.TextChanged += new System.EventHandler(this.txtGrade_TextChanged);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(379, 83);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 13);
            this.Status.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Term";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(202, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Grade";
            // 
            // UC_Gradeassign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 315);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.txtGrade);
            this.Controls.Add(this.comboTerm);
            this.Controls.Add(this.button1);
            this.Name = "UC_Gradeassign";
            this.Load += new System.EventHandler(this.UC_Gradeassign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboTerm;
        private System.Windows.Forms.TextBox txtGrade;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
