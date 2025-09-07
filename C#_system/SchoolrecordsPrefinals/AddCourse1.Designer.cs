namespace SchoolrecordsPrefinals
{
    partial class AddCourse1
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCredits = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.cmbSem = new System.Windows.Forms.ComboBox();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(397, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Course Code";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(400, 56);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(159, 20);
            this.txtCode.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 43);
            this.button1.TabIndex = 11;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCredits
            // 
            this.txtCredits.Location = new System.Drawing.Point(57, 230);
            this.txtCredits.Name = "txtCredits";
            this.txtCredits.Size = new System.Drawing.Size(78, 20);
            this.txtCredits.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Units";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Course Name";
            // 
            // txtCourseName
            // 
            this.txtCourseName.Location = new System.Drawing.Point(54, 56);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(263, 20);
            this.txtCourseName.TabIndex = 7;
            // 
            // cmbSem
            // 
            this.cmbSem.FormattingEnabled = true;
            this.cmbSem.Location = new System.Drawing.Point(54, 127);
            this.cmbSem.Name = "cmbSem";
            this.cmbSem.Size = new System.Drawing.Size(121, 21);
            this.cmbSem.TabIndex = 14;
            
            // cmbProgram
            // 
            this.cmbProgram.FormattingEnabled = true;
            this.cmbProgram.Location = new System.Drawing.Point(400, 127);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(121, 21);
            this.cmbProgram.TabIndex = 15;
            
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(397, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Program";
           
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Semester";
            // 
            // AddCourse1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbProgram);
            this.Controls.Add(this.cmbSem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCredits);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCourseName);
            this.Name = "AddCourse1";
            this.Size = new System.Drawing.Size(743, 488);
            this.Load += new System.EventHandler(this.AddCourse1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCredits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.ComboBox cmbSem;
        private System.Windows.Forms.ComboBox cmbProgram;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
