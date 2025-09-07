namespace SchoolrecordsPrefinals
{
    partial class EnrollStudent
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
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbYearLevel = new System.Windows.Forms.ComboBox();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSchoolYear = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(77, 43);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(183, 20);
            this.txtFirstName.TabIndex = 0;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(360, 46);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(183, 20);
            this.txtLastName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last Name:";
            // 
            // cmbProgram
            // 
            this.cmbProgram.FormattingEnabled = true;
            this.cmbProgram.Location = new System.Drawing.Point(77, 100);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(183, 21);
            this.cmbProgram.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Program:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Year Level:";
            // 
            // cmbYearLevel
            // 
            this.cmbYearLevel.FormattingEnabled = true;
            this.cmbYearLevel.Location = new System.Drawing.Point(360, 100);
            this.cmbYearLevel.Name = "cmbYearLevel";
            this.cmbYearLevel.Size = new System.Drawing.Size(130, 21);
            this.cmbYearLevel.TabIndex = 7;
            // 
            // cmbSemester
            // 
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Location = new System.Drawing.Point(77, 153);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(169, 21);
            this.cmbSemester.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Semester:";
            // 
            // txtSchoolYear
            // 
            this.txtSchoolYear.Location = new System.Drawing.Point(360, 153);
            this.txtSchoolYear.Name = "txtSchoolYear";
            this.txtSchoolYear.Size = new System.Drawing.Size(152, 20);
            this.txtSchoolYear.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(286, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "School Year:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(449, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 42);
            this.button1.TabIndex = 12;
            this.button1.Text = "Enroll";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(77, 310);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 42);
            this.button2.TabIndex = 13;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EnrollStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSchoolYear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSemester);
            this.Controls.Add(this.cmbYearLevel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbProgram);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Name = "EnrollStudent";
            this.Size = new System.Drawing.Size(620, 401);
            this.Load += new System.EventHandler(this.EnrollStudent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbProgram;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbYearLevel;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSchoolYear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
