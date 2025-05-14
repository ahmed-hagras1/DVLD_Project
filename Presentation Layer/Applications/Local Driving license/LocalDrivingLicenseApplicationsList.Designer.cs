namespace Presentation_Layer
{
    partial class LocalDrivingLicenseApplicationsList
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
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.txtFilterBy = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLDLApps = new System.Windows.Forms.DataGridView();
            this.cmsApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiApplicationDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiEditApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCancleApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSechduleTests = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSechduleVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSechduleWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSechduleStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiIssueDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewLDLApp = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLApps)).BeginInit();
            this.cmsApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "All",
            "New",
            "Cancelled",
            "Completed"});
            this.cbStatus.Location = new System.Drawing.Point(396, 310);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(217, 24);
            this.cbStatus.TabIndex = 18;
            this.cbStatus.Visible = false;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(47, 667);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(49, 20);
            this.lblRecordsCount.TabIndex = 17;
            this.lblRecordsCount.Text = "label";
            // 
            // txtFilterBy
            // 
            this.txtFilterBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterBy.Location = new System.Drawing.Point(372, 311);
            this.txtFilterBy.Name = "txtFilterBy";
            this.txtFilterBy.Size = new System.Drawing.Size(217, 22);
            this.txtFilterBy.TabIndex = 15;
            this.txtFilterBy.TextChanged += new System.EventHandler(this.txtFilterBy_TextChanged);
            this.txtFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterBy_KeyPress);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "L.D.LAppID",
            "National No",
            "Full Name",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(118, 310);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(217, 24);
            this.cbFilterBy.TabIndex = 9;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Filter by:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(14, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1475, 52);
            this.label1.TabIndex = 12;
            this.label1.Text = "Local Driving license";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvLDLApps
            // 
            this.dgvLDLApps.AllowDrop = true;
            this.dgvLDLApps.AllowUserToAddRows = false;
            this.dgvLDLApps.AllowUserToDeleteRows = false;
            this.dgvLDLApps.BackgroundColor = System.Drawing.Color.White;
            this.dgvLDLApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLDLApps.ContextMenuStrip = this.cmsApplications;
            this.dgvLDLApps.Location = new System.Drawing.Point(14, 353);
            this.dgvLDLApps.Name = "dgvLDLApps";
            this.dgvLDLApps.ReadOnly = true;
            this.dgvLDLApps.RowHeadersWidth = 51;
            this.dgvLDLApps.RowTemplate.Height = 24;
            this.dgvLDLApps.Size = new System.Drawing.Size(1461, 269);
            this.dgvLDLApps.TabIndex = 13;
            // 
            // cmsApplications
            // 
            this.cmsApplications.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiApplicationDetails,
            this.toolStripSeparator1,
            this.tsmiEditApplication,
            this.tsmiDeleteApplication,
            this.toolStripSeparator2,
            this.tsmiCancleApplication,
            this.toolStripSeparator3,
            this.tsmiSechduleTests,
            this.toolStripSeparator4,
            this.tsmiIssueDrivingLicense,
            this.toolStripSeparator5,
            this.tsmiShowLicense,
            this.toolStripSeparator6,
            this.tsmiShowPersonLicenseHistory});
            this.cmsApplications.Name = "cmsApplications";
            this.cmsApplications.Size = new System.Drawing.Size(281, 344);
            this.cmsApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmsApplications_Opening);
            // 
            // tsmiApplicationDetails
            // 
            this.tsmiApplicationDetails.Image = global::Presentation_Layer.Properties.Resources.PersonDetails_32;
            this.tsmiApplicationDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiApplicationDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiApplicationDetails.Name = "tsmiApplicationDetails";
            this.tsmiApplicationDetails.Size = new System.Drawing.Size(280, 38);
            this.tsmiApplicationDetails.Text = "Show Application Details";
            this.tsmiApplicationDetails.Click += new System.EventHandler(this.tsmiApplicationDetails_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(277, 6);
            // 
            // tsmiEditApplication
            // 
            this.tsmiEditApplication.Image = global::Presentation_Layer.Properties.Resources.edit_32;
            this.tsmiEditApplication.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiEditApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiEditApplication.Name = "tsmiEditApplication";
            this.tsmiEditApplication.Size = new System.Drawing.Size(280, 38);
            this.tsmiEditApplication.Text = "Edit Application";
            this.tsmiEditApplication.Click += new System.EventHandler(this.EditApplicationClick);
            // 
            // tsmiDeleteApplication
            // 
            this.tsmiDeleteApplication.Image = global::Presentation_Layer.Properties.Resources.Delete_32_2;
            this.tsmiDeleteApplication.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiDeleteApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiDeleteApplication.Name = "tsmiDeleteApplication";
            this.tsmiDeleteApplication.Size = new System.Drawing.Size(280, 38);
            this.tsmiDeleteApplication.Text = "Delete Application";
            this.tsmiDeleteApplication.Click += new System.EventHandler(this.DeleteApplicationClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(277, 6);
            // 
            // tsmiCancleApplication
            // 
            this.tsmiCancleApplication.Image = global::Presentation_Layer.Properties.Resources.Delete_32;
            this.tsmiCancleApplication.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiCancleApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiCancleApplication.Name = "tsmiCancleApplication";
            this.tsmiCancleApplication.Size = new System.Drawing.Size(280, 38);
            this.tsmiCancleApplication.Text = "Cancle Application";
            this.tsmiCancleApplication.Click += new System.EventHandler(this.CancelApplicationClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(277, 6);
            // 
            // tsmiSechduleTests
            // 
            this.tsmiSechduleTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSechduleVisionTest,
            this.tsmiSechduleWrittenTest,
            this.tsmiSechduleStreetTest});
            this.tsmiSechduleTests.Image = global::Presentation_Layer.Properties.Resources.TestType_32;
            this.tsmiSechduleTests.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiSechduleTests.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiSechduleTests.Name = "tsmiSechduleTests";
            this.tsmiSechduleTests.Size = new System.Drawing.Size(280, 38);
            this.tsmiSechduleTests.Text = "Sechdule Tests";
            this.tsmiSechduleTests.Click += new System.EventHandler(this.tsmiSechduleTests_Click);
            // 
            // tsmiSechduleVisionTest
            // 
            this.tsmiSechduleVisionTest.Image = global::Presentation_Layer.Properties.Resources.Vision_Test_32;
            this.tsmiSechduleVisionTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiSechduleVisionTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiSechduleVisionTest.Name = "tsmiSechduleVisionTest";
            this.tsmiSechduleVisionTest.Size = new System.Drawing.Size(247, 38);
            this.tsmiSechduleVisionTest.Text = "Sechdule Vision Test";
            this.tsmiSechduleVisionTest.Click += new System.EventHandler(this.tsmiScheduleVisionTest_Click);
            // 
            // tsmiSechduleWrittenTest
            // 
            this.tsmiSechduleWrittenTest.Image = global::Presentation_Layer.Properties.Resources.Written_Test_32;
            this.tsmiSechduleWrittenTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiSechduleWrittenTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiSechduleWrittenTest.Name = "tsmiSechduleWrittenTest";
            this.tsmiSechduleWrittenTest.Size = new System.Drawing.Size(247, 38);
            this.tsmiSechduleWrittenTest.Text = "Sechdule Written Test";
            this.tsmiSechduleWrittenTest.Click += new System.EventHandler(this.tsmiScheduleWrittenTest_Click);
            // 
            // tsmiSechduleStreetTest
            // 
            this.tsmiSechduleStreetTest.Image = global::Presentation_Layer.Properties.Resources.Street_Test_32;
            this.tsmiSechduleStreetTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiSechduleStreetTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiSechduleStreetTest.Name = "tsmiSechduleStreetTest";
            this.tsmiSechduleStreetTest.Size = new System.Drawing.Size(247, 38);
            this.tsmiSechduleStreetTest.Text = "Sechdule Street Test";
            this.tsmiSechduleStreetTest.Click += new System.EventHandler(this.tsmiScheduleStreetTest_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(277, 6);
            // 
            // tsmiIssueDrivingLicense
            // 
            this.tsmiIssueDrivingLicense.Image = global::Presentation_Layer.Properties.Resources.IssueDrivingLicense_32;
            this.tsmiIssueDrivingLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiIssueDrivingLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiIssueDrivingLicense.Name = "tsmiIssueDrivingLicense";
            this.tsmiIssueDrivingLicense.Size = new System.Drawing.Size(280, 38);
            this.tsmiIssueDrivingLicense.Text = "Issue Driving License";
            this.tsmiIssueDrivingLicense.Click += new System.EventHandler(this.tsmiIssueDrivingLicense_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(277, 6);
            // 
            // tsmiShowLicense
            // 
            this.tsmiShowLicense.Image = global::Presentation_Layer.Properties.Resources.License_View_32;
            this.tsmiShowLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiShowLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiShowLicense.Name = "tsmiShowLicense";
            this.tsmiShowLicense.Size = new System.Drawing.Size(280, 38);
            this.tsmiShowLicense.Text = "Show License";
            this.tsmiShowLicense.Click += new System.EventHandler(this.tsmiShowLicense_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(277, 6);
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
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Presentation_Layer.Properties.Resources.Local_32;
            this.pictureBox2.Location = new System.Drawing.Point(874, 67);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(66, 52);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Presentation_Layer.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1306, 653);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(169, 45);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddNewLDLApp
            // 
            this.btnAddNewLDLApp.Image = global::Presentation_Layer.Properties.Resources.New_Application_64;
            this.btnAddNewLDLApp.Location = new System.Drawing.Point(1344, 242);
            this.btnAddNewLDLApp.Name = "btnAddNewLDLApp";
            this.btnAddNewLDLApp.Size = new System.Drawing.Size(131, 92);
            this.btnAddNewLDLApp.TabIndex = 11;
            this.btnAddNewLDLApp.UseVisualStyleBackColor = true;
            this.btnAddNewLDLApp.Click += new System.EventHandler(this.AddNewLDLAppClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::Presentation_Layer.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(544, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(396, 159);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // LocalDrivingLicenseApplicationsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1489, 711);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtFilterBy);
            this.Controls.Add(this.btnAddNewLDLApp);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLDLApps);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LocalDrivingLicenseApplicationsList";
            this.Text = "LocalDrivingLicenseApplications";
            this.Load += new System.EventHandler(this.LocalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLApps)).EndInit();
            this.cmsApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtFilterBy;
        private System.Windows.Forms.Button btnAddNewLDLApp;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLDLApps;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip cmsApplications;
        private System.Windows.Forms.ToolStripMenuItem tsmiApplicationDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditApplication;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteApplication;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancleApplication;
        private System.Windows.Forms.ToolStripMenuItem tsmiSechduleTests;
        private System.Windows.Forms.ToolStripMenuItem tsmiIssueDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiSechduleVisionTest;
        private System.Windows.Forms.ToolStripMenuItem tsmiSechduleWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem tsmiSechduleStreetTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}