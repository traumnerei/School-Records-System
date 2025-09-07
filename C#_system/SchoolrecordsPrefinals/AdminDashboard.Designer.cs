namespace SchoolrecordsPrefinals
{
    partial class AdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            this.dashboardheader = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtbsearchbar = new System.Windows.Forms.TextBox();
            this.btnadd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.btnlogout = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dashboardheader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dashboardheader
            // 
            this.dashboardheader.BackColor = System.Drawing.Color.White;
            this.dashboardheader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dashboardheader.Controls.Add(this.panel3);
            this.dashboardheader.Controls.Add(this.panel4);
            this.dashboardheader.Dock = System.Windows.Forms.DockStyle.Top;
            this.dashboardheader.Location = new System.Drawing.Point(0, 0);
            this.dashboardheader.Margin = new System.Windows.Forms.Padding(2);
            this.dashboardheader.Name = "dashboardheader";
            this.dashboardheader.Size = new System.Drawing.Size(1028, 81);
            this.dashboardheader.TabIndex = 1;
            this.dashboardheader.Paint += new System.Windows.Forms.PaintEventHandler(this.dashboardheader_Paint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel3.Location = new System.Drawing.Point(-31, -46);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(303, 175);
            this.panel3.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel4.Location = new System.Drawing.Point(712, -39);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(274, 168);
            this.panel4.TabIndex = 8;
            // 
            // txtbsearchbar
            // 
            this.txtbsearchbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbsearchbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbsearchbar.Location = new System.Drawing.Point(712, 24);
            this.txtbsearchbar.Margin = new System.Windows.Forms.Padding(2);
            this.txtbsearchbar.Name = "txtbsearchbar";
            this.txtbsearchbar.Size = new System.Drawing.Size(188, 26);
            this.txtbsearchbar.TabIndex = 2;
            this.txtbsearchbar.TextChanged += new System.EventHandler(this.txtbsearchbar_TextChanged);
            // 
            // btnadd
            // 
            this.btnadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.Location = new System.Drawing.Point(926, 24);
            this.btnadd.Margin = new System.Windows.Forms.Padding(2);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(90, 24);
            this.btnadd.TabIndex = 3;
            this.btnadd.Text = "Add User";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.cbStatus);
            this.panel1.Controls.Add(this.cbRole);
            this.panel1.Controls.Add(this.btnlogout);
            this.panel1.Controls.Add(this.txtbsearchbar);
            this.panel1.Controls.Add(this.btnadd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 81);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 58);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(598, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 24);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbStatus
            // 
            this.cbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(476, 25);
            this.cbStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(92, 25);
            this.cbStatus.TabIndex = 6;
            // 
            // cbRole
            // 
            this.cbRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(354, 25);
            this.cbRole.Margin = new System.Windows.Forms.Padding(2);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(114, 25);
            this.cbRole.TabIndex = 5;
            // 
            // btnlogout
            // 
            this.btnlogout.AutoSize = true;
            this.btnlogout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnlogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogout.Location = new System.Drawing.Point(9, 20);
            this.btnlogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(75, 30);
            this.btnlogout.TabIndex = 4;
            this.btnlogout.Text = "Logout";
            this.btnlogout.UseVisualStyleBackColor = true;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 139);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 470);
            this.panel2.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1028, 470);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(174)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dashboardheader);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AdminDashboard";
            this.Text = "AdminDashboard";
            this.Load += new System.EventHandler(this.AdminDashboard_Load);
            this.dashboardheader.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel dashboardheader;
        private System.Windows.Forms.TextBox txtbsearchbar;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRefresh;
    }
}