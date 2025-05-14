namespace Presentation_Layer
{
    partial class InternationalLicenseApplicationsList
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            this.txtFilterBy = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddNewILDLApp = new System.Windows.Forms.Button();
            this.dgvInternationalLicenseApplications = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblInternatioanlLicenseApplicationsCount = new System.Windows.Forms.Label();
            this.cmInternationalLicenseApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenseApplications)).BeginInit();
            this.cmInternationalLicenseApplications.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(441, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(458, 32);
            this.label1.TabIndex = 14;
            this.label1.Text = "International License Applicatios";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::Presentation_Layer.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(549, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(215, 159);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // cbIsActive
            // 
            this.cbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActive.FormattingEnabled = true;
            this.cbIsActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsActive.Location = new System.Drawing.Point(382, 227);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(217, 24);
            this.cbIsActive.TabIndex = 22;
            this.cbIsActive.Visible = false;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // txtFilterBy
            // 
            this.txtFilterBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterBy.Location = new System.Drawing.Point(358, 228);
            this.txtFilterBy.Name = "txtFilterBy";
            this.txtFilterBy.Size = new System.Drawing.Size(217, 22);
            this.txtFilterBy.TabIndex = 21;
            this.txtFilterBy.TextChanged += new System.EventHandler(this.txtFilterBy_TextChanged);
            this.txtFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterBy_KeyPress);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "International License ID",
            "Application ID",
            "Driver ID",
            "Local License ID",
            "Is Active"});
            this.cbFilterBy.Location = new System.Drawing.Point(104, 227);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(217, 24);
            this.cbFilterBy.TabIndex = 19;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Filter by:";
            // 
            // btnAddNewILDLApp
            // 
            this.btnAddNewILDLApp.Image = global::Presentation_Layer.Properties.Resources.New_Application_64;
            this.btnAddNewILDLApp.Location = new System.Drawing.Point(1142, 158);
            this.btnAddNewILDLApp.Name = "btnAddNewILDLApp";
            this.btnAddNewILDLApp.Size = new System.Drawing.Size(131, 92);
            this.btnAddNewILDLApp.TabIndex = 23;
            this.btnAddNewILDLApp.UseVisualStyleBackColor = true;
            this.btnAddNewILDLApp.Click += new System.EventHandler(this.btnAddNewILDLApp_Click);
            // 
            // dgvInternationalLicenseApplications
            // 
            this.dgvInternationalLicenseApplications.AllowDrop = true;
            this.dgvInternationalLicenseApplications.AllowUserToAddRows = false;
            this.dgvInternationalLicenseApplications.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenseApplications.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternationalLicenseApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenseApplications.ContextMenuStrip = this.cmInternationalLicenseApplications;
            this.dgvInternationalLicenseApplications.Location = new System.Drawing.Point(17, 257);
            this.dgvInternationalLicenseApplications.Name = "dgvInternationalLicenseApplications";
            this.dgvInternationalLicenseApplications.ReadOnly = true;
            this.dgvInternationalLicenseApplications.RowHeadersWidth = 51;
            this.dgvInternationalLicenseApplications.RowTemplate.Height = 24;
            this.dgvInternationalLicenseApplications.Size = new System.Drawing.Size(1256, 326);
            this.dgvInternationalLicenseApplications.TabIndex = 24;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Presentation_Layer.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1104, 589);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(169, 45);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 606);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "# Records:  ";
            // 
            // lblInternatioanlLicenseApplicationsCount
            // 
            this.lblInternatioanlLicenseApplicationsCount.AutoSize = true;
            this.lblInternatioanlLicenseApplicationsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternatioanlLicenseApplicationsCount.Location = new System.Drawing.Point(133, 606);
            this.lblInternatioanlLicenseApplicationsCount.Name = "lblInternatioanlLicenseApplicationsCount";
            this.lblInternatioanlLicenseApplicationsCount.Size = new System.Drawing.Size(29, 20);
            this.lblInternatioanlLicenseApplicationsCount.TabIndex = 27;
            this.lblInternatioanlLicenseApplicationsCount.Text = "??";
            // 
            // cmInternationalLicenseApplications
            // 
            this.cmInternationalLicenseApplications.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmInternationalLicenseApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowPersonDetails,
            this.toolStripSeparator1,
            this.tsmiShowLicenseDetails,
            this.toolStripSeparator2,
            this.tsmiShowPersonLicenseHistory});
            this.cmInternationalLicenseApplications.Name = "cmInternationalLicenseApplications";
            this.cmInternationalLicenseApplications.Size = new System.Drawing.Size(281, 130);
            // 
            // tsmiShowPersonDetails
            // 
            this.tsmiShowPersonDetails.Image = global::Presentation_Layer.Properties.Resources.PersonDetails_32;
            this.tsmiShowPersonDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiShowPersonDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiShowPersonDetails.Name = "tsmiShowPersonDetails";
            this.tsmiShowPersonDetails.Size = new System.Drawing.Size(280, 38);
            this.tsmiShowPersonDetails.Text = "Show Person Details";
            this.tsmiShowPersonDetails.Click += new System.EventHandler(this.tsmiShowPersonDetails_Click);
            // 
            // tsmiShowLicenseDetails
            // 
            this.tsmiShowLicenseDetails.Image = global::Presentation_Layer.Properties.Resources.License_View_32;
            this.tsmiShowLicenseDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiShowLicenseDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiShowLicenseDetails.Name = "tsmiShowLicenseDetails";
            this.tsmiShowLicenseDetails.Size = new System.Drawing.Size(280, 38);
            this.tsmiShowLicenseDetails.Text = "Show License Details";
            this.tsmiShowLicenseDetails.Click += new System.EventHandler(this.tsmiShowLicenseDetails_Click);
            // 
            // tsmiShowPersonLicenseHistory
            // 
            this.tsmiShowPersonLicenseHistory.Image = global::Presentation_Layer.Properties.Resources.PersonLicenseHistory_32;
            this.tsmiShowPersonLicenseHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiShowPersonLicenseHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiShowPersonLicenseHistory.Name = "tsmiShowPersonLicenseHistory";
            this.tsmiShowPersonLicenseHistory.Size = new System.Drawing.Size(280, 38);
            this.tsmiShowPersonLicenseHistory.Text = "Show Person License History";
            this.tsmiShowPersonLicenseHistory.Click += new System.EventHandler(this.tsmiShowPersonLicenseHistory_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(277, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(277, 6);
            // 
            // InternationalLicenseApplicationsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 644);
            this.Controls.Add(this.lblInternatioanlLicenseApplicationsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvInternationalLicenseApplications);
            this.Controls.Add(this.btnAddNewILDLApp);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.txtFilterBy);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InternationalLicenseApplicationsList";
            this.Text = "InternationalLicenseApplications";
            this.Load += new System.EventHandler(this.InternationalLicenseApplicationsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenseApplications)).EndInit();
            this.cmInternationalLicenseApplications.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbIsActive;
        private System.Windows.Forms.TextBox txtFilterBy;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNewILDLApp;
        private System.Windows.Forms.DataGridView dgvInternationalLicenseApplications;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblInternatioanlLicenseApplicationsCount;
        private System.Windows.Forms.ContextMenuStrip cmInternationalLicenseApplications;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPersonDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowLicenseDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPersonLicenseHistory;
    }
}