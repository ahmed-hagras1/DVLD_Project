namespace Presentation_Layer
{
    partial class MainScreen
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDrivingLicensesServices = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLocalLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInternationalLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRenewDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiReplacementForLostOrDamagedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiReleaseDetainedDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRetakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiManageApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLocalDrivingLicenseApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInternationalLicenseApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDetainLicenses = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManageDetainLicenses = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDetainLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReleaseDetainedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManageApplicationTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManageTestTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPeople = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDrivers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAccountSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCurrentUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSignOut = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(60, 60);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiApplications,
            this.tsmiPeople,
            this.tsmiDrivers,
            this.tsmiUsers,
            this.tsmiAccountSetting});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1075, 97);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiApplications
            // 
            this.tsmiApplications.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDrivingLicensesServices,
            this.toolStripSeparator2,
            this.tsmiManageApplications,
            this.toolStripSeparator3,
            this.tsmiDetainLicenses,
            this.tsmiManageApplicationTypes,
            this.tsmiManageTestTypes});
            this.tsmiApplications.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiApplications.Image = global::Presentation_Layer.Properties.Resources.Applications_64;
            this.tsmiApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiApplications.Name = "tsmiApplications";
            this.tsmiApplications.Size = new System.Drawing.Size(193, 93);
            this.tsmiApplications.Text = "Applications";
            // 
            // tsmiDrivingLicensesServices
            // 
            this.tsmiDrivingLicensesServices.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewDrivingLicense,
            this.tsmiRenewDrivingLicense,
            this.toolStripSeparator4,
            this.tsmiReplacementForLostOrDamagedLicense,
            this.toolStripSeparator5,
            this.tsmiReleaseDetainedDrivingLicense,
            this.tsmiRetakeTest});
            this.tsmiDrivingLicensesServices.Image = global::Presentation_Layer.Properties.Resources.Driver_License_48;
            this.tsmiDrivingLicensesServices.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiDrivingLicensesServices.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiDrivingLicensesServices.Name = "tsmiDrivingLicensesServices";
            this.tsmiDrivingLicensesServices.Size = new System.Drawing.Size(357, 70);
            this.tsmiDrivingLicensesServices.Text = "Driving licenses services";
            // 
            // tsmiNewDrivingLicense
            // 
            this.tsmiNewDrivingLicense.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLocalLicense,
            this.tsmiInternationalLicense});
            this.tsmiNewDrivingLicense.Image = global::Presentation_Layer.Properties.Resources.New_Driving_License_32;
            this.tsmiNewDrivingLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiNewDrivingLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiNewDrivingLicense.Name = "tsmiNewDrivingLicense";
            this.tsmiNewDrivingLicense.Size = new System.Drawing.Size(455, 38);
            this.tsmiNewDrivingLicense.Text = "New driving license";
            // 
            // tsmiLocalLicense
            // 
            this.tsmiLocalLicense.Image = global::Presentation_Layer.Properties.Resources.Local_32;
            this.tsmiLocalLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiLocalLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiLocalLicense.Name = "tsmiLocalLicense";
            this.tsmiLocalLicense.Size = new System.Drawing.Size(280, 38);
            this.tsmiLocalLicense.Text = "Local license";
            this.tsmiLocalLicense.Click += new System.EventHandler(this.tsmiLocalLicense_Click);
            // 
            // tsmiInternationalLicense
            // 
            this.tsmiInternationalLicense.Image = global::Presentation_Layer.Properties.Resources.International_32;
            this.tsmiInternationalLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiInternationalLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiInternationalLicense.Name = "tsmiInternationalLicense";
            this.tsmiInternationalLicense.Size = new System.Drawing.Size(280, 38);
            this.tsmiInternationalLicense.Text = "International license";
            this.tsmiInternationalLicense.Click += new System.EventHandler(this.tsmiInternationalLicense_Click);
            // 
            // tsmiRenewDrivingLicense
            // 
            this.tsmiRenewDrivingLicense.Image = global::Presentation_Layer.Properties.Resources.Renew_Driving_License_32;
            this.tsmiRenewDrivingLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiRenewDrivingLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiRenewDrivingLicense.Name = "tsmiRenewDrivingLicense";
            this.tsmiRenewDrivingLicense.Size = new System.Drawing.Size(455, 38);
            this.tsmiRenewDrivingLicense.Text = "Renew driving license";
            this.tsmiRenewDrivingLicense.Click += new System.EventHandler(this.tsmiRenewDrivingLicense_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(452, 6);
            // 
            // tsmiReplacementForLostOrDamagedLicense
            // 
            this.tsmiReplacementForLostOrDamagedLicense.Image = global::Presentation_Layer.Properties.Resources.Damaged_Driving_License_32;
            this.tsmiReplacementForLostOrDamagedLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiReplacementForLostOrDamagedLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiReplacementForLostOrDamagedLicense.Name = "tsmiReplacementForLostOrDamagedLicense";
            this.tsmiReplacementForLostOrDamagedLicense.Size = new System.Drawing.Size(455, 38);
            this.tsmiReplacementForLostOrDamagedLicense.Text = "Replacement for lost or damaged license ";
            this.tsmiReplacementForLostOrDamagedLicense.Click += new System.EventHandler(this.tsmiReplacementForLostOrDamagedLicense_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(452, 6);
            // 
            // tsmiReleaseDetainedDrivingLicense
            // 
            this.tsmiReleaseDetainedDrivingLicense.Image = global::Presentation_Layer.Properties.Resources.Detained_Driving_License_32;
            this.tsmiReleaseDetainedDrivingLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiReleaseDetainedDrivingLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiReleaseDetainedDrivingLicense.Name = "tsmiReleaseDetainedDrivingLicense";
            this.tsmiReleaseDetainedDrivingLicense.Size = new System.Drawing.Size(455, 38);
            this.tsmiReleaseDetainedDrivingLicense.Text = "Release detained driving license";
            this.tsmiReleaseDetainedDrivingLicense.Click += new System.EventHandler(this.tsmiReleaseDetainedDrivingLicense_Click);
            // 
            // tsmiRetakeTest
            // 
            this.tsmiRetakeTest.Image = global::Presentation_Layer.Properties.Resources.Retake_Test_32;
            this.tsmiRetakeTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiRetakeTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiRetakeTest.Name = "tsmiRetakeTest";
            this.tsmiRetakeTest.Size = new System.Drawing.Size(455, 38);
            this.tsmiRetakeTest.Text = "Retake test";
            this.tsmiRetakeTest.Click += new System.EventHandler(this.tsmiRetakeTest_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(354, 6);
            // 
            // tsmiManageApplications
            // 
            this.tsmiManageApplications.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLocalDrivingLicenseApplications,
            this.tsmiInternationalLicenseApplications});
            this.tsmiManageApplications.Image = global::Presentation_Layer.Properties.Resources.Manage_Applications_64;
            this.tsmiManageApplications.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiManageApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiManageApplications.Name = "tsmiManageApplications";
            this.tsmiManageApplications.Size = new System.Drawing.Size(357, 70);
            this.tsmiManageApplications.Text = "Manage Applications";
            this.tsmiManageApplications.Click += new System.EventHandler(this.tsmiManageApplications_Click);
            // 
            // tsmiLocalDrivingLicenseApplications
            // 
            this.tsmiLocalDrivingLicenseApplications.Image = global::Presentation_Layer.Properties.Resources.Local_32;
            this.tsmiLocalDrivingLicenseApplications.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiLocalDrivingLicenseApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiLocalDrivingLicenseApplications.Name = "tsmiLocalDrivingLicenseApplications";
            this.tsmiLocalDrivingLicenseApplications.Size = new System.Drawing.Size(385, 38);
            this.tsmiLocalDrivingLicenseApplications.Text = "Local driving license applications";
            this.tsmiLocalDrivingLicenseApplications.Click += new System.EventHandler(this.tsmiLocalDrivingLicenseApplications_Click);
            // 
            // tsmiInternationalLicenseApplications
            // 
            this.tsmiInternationalLicenseApplications.Image = global::Presentation_Layer.Properties.Resources.International_32;
            this.tsmiInternationalLicenseApplications.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiInternationalLicenseApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiInternationalLicenseApplications.Name = "tsmiInternationalLicenseApplications";
            this.tsmiInternationalLicenseApplications.Size = new System.Drawing.Size(385, 38);
            this.tsmiInternationalLicenseApplications.Text = "International license applications";
            this.tsmiInternationalLicenseApplications.Click += new System.EventHandler(this.tsmiInternationalLicenseApplications_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(354, 6);
            // 
            // tsmiDetainLicenses
            // 
            this.tsmiDetainLicenses.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiManageDetainLicenses,
            this.tsmiDetainLicense,
            this.tsmiReleaseDetainedLicense});
            this.tsmiDetainLicenses.Image = global::Presentation_Layer.Properties.Resources.Detain_64;
            this.tsmiDetainLicenses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiDetainLicenses.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiDetainLicenses.Name = "tsmiDetainLicenses";
            this.tsmiDetainLicenses.Size = new System.Drawing.Size(357, 70);
            this.tsmiDetainLicenses.Text = "Detain licenses";
            // 
            // tsmiManageDetainLicenses
            // 
            this.tsmiManageDetainLicenses.Image = global::Presentation_Layer.Properties.Resources.Detain_32;
            this.tsmiManageDetainLicenses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiManageDetainLicenses.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiManageDetainLicenses.Name = "tsmiManageDetainLicenses";
            this.tsmiManageDetainLicenses.Size = new System.Drawing.Size(315, 38);
            this.tsmiManageDetainLicenses.Text = "Manage detain licenses";
            this.tsmiManageDetainLicenses.Click += new System.EventHandler(this.tsmiManageDetainLicenses_Click);
            // 
            // tsmiDetainLicense
            // 
            this.tsmiDetainLicense.Image = global::Presentation_Layer.Properties.Resources.Detain_32;
            this.tsmiDetainLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiDetainLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiDetainLicense.Name = "tsmiDetainLicense";
            this.tsmiDetainLicense.Size = new System.Drawing.Size(315, 38);
            this.tsmiDetainLicense.Text = "Detain license";
            this.tsmiDetainLicense.Click += new System.EventHandler(this.tsmiDetainLicense_Click);
            // 
            // tsmiReleaseDetainedLicense
            // 
            this.tsmiReleaseDetainedLicense.Image = global::Presentation_Layer.Properties.Resources.Release_Detained_License_32;
            this.tsmiReleaseDetainedLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiReleaseDetainedLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiReleaseDetainedLicense.Name = "tsmiReleaseDetainedLicense";
            this.tsmiReleaseDetainedLicense.Size = new System.Drawing.Size(315, 38);
            this.tsmiReleaseDetainedLicense.Text = "Release detained license";
            this.tsmiReleaseDetainedLicense.Click += new System.EventHandler(this.tsmiReleaseDetainedLicense_Click);
            // 
            // tsmiManageApplicationTypes
            // 
            this.tsmiManageApplicationTypes.Image = global::Presentation_Layer.Properties.Resources.Application_Types_64;
            this.tsmiManageApplicationTypes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiManageApplicationTypes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiManageApplicationTypes.Name = "tsmiManageApplicationTypes";
            this.tsmiManageApplicationTypes.Size = new System.Drawing.Size(357, 70);
            this.tsmiManageApplicationTypes.Text = "Manage application types";
            this.tsmiManageApplicationTypes.Click += new System.EventHandler(this.tsmiManageApplicationTypes_Click);
            // 
            // tsmiManageTestTypes
            // 
            this.tsmiManageTestTypes.Image = global::Presentation_Layer.Properties.Resources.Test_Type_64;
            this.tsmiManageTestTypes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiManageTestTypes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiManageTestTypes.Name = "tsmiManageTestTypes";
            this.tsmiManageTestTypes.Size = new System.Drawing.Size(357, 70);
            this.tsmiManageTestTypes.Text = "Manage test types";
            this.tsmiManageTestTypes.Click += new System.EventHandler(this.tsmiManageTestTypes_Click);
            // 
            // tsmiPeople
            // 
            this.tsmiPeople.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiPeople.Image = global::Presentation_Layer.Properties.Resources.People_64;
            this.tsmiPeople.Name = "tsmiPeople";
            this.tsmiPeople.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.tsmiPeople.Size = new System.Drawing.Size(177, 93);
            this.tsmiPeople.Text = "People";
            this.tsmiPeople.Click += new System.EventHandler(this.tsmiPeople_Click);
            // 
            // tsmiDrivers
            // 
            this.tsmiDrivers.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiDrivers.Image = global::Presentation_Layer.Properties.Resources.Drivers_64;
            this.tsmiDrivers.Name = "tsmiDrivers";
            this.tsmiDrivers.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.tsmiDrivers.Size = new System.Drawing.Size(179, 93);
            this.tsmiDrivers.Text = "Drivers";
            this.tsmiDrivers.Click += new System.EventHandler(this.tsmiDrivers_Click);
            // 
            // tsmiUsers
            // 
            this.tsmiUsers.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiUsers.Image = global::Presentation_Layer.Properties.Resources.Users_2_64;
            this.tsmiUsers.Name = "tsmiUsers";
            this.tsmiUsers.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.tsmiUsers.Size = new System.Drawing.Size(160, 93);
            this.tsmiUsers.Text = "Users";
            this.tsmiUsers.Click += new System.EventHandler(this.tsmiUsers_Click);
            // 
            // tsmiAccountSetting
            // 
            this.tsmiAccountSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCurrentUserInfo,
            this.tsmiChangePassword,
            this.toolStripSeparator1,
            this.tsmiSignOut});
            this.tsmiAccountSetting.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiAccountSetting.Image = global::Presentation_Layer.Properties.Resources.account_settings_64;
            this.tsmiAccountSetting.Name = "tsmiAccountSetting";
            this.tsmiAccountSetting.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiAccountSetting.Size = new System.Drawing.Size(302, 93);
            this.tsmiAccountSetting.Text = "Account settings";
            // 
            // tsmiCurrentUserInfo
            // 
            this.tsmiCurrentUserInfo.Image = global::Presentation_Layer.Properties.Resources.PersonDetails_32;
            this.tsmiCurrentUserInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiCurrentUserInfo.Name = "tsmiCurrentUserInfo";
            this.tsmiCurrentUserInfo.Size = new System.Drawing.Size(333, 42);
            this.tsmiCurrentUserInfo.Text = "Current user info";
            this.tsmiCurrentUserInfo.Click += new System.EventHandler(this.tsmiCurrentUserInfo_Click);
            // 
            // tsmiChangePassword
            // 
            this.tsmiChangePassword.Image = global::Presentation_Layer.Properties.Resources.Password_32;
            this.tsmiChangePassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiChangePassword.Name = "tsmiChangePassword";
            this.tsmiChangePassword.Size = new System.Drawing.Size(333, 42);
            this.tsmiChangePassword.Text = "Change password";
            this.tsmiChangePassword.Click += new System.EventHandler(this.tsmiChangePassword_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(330, 6);
            // 
            // tsmiSignOut
            // 
            this.tsmiSignOut.Image = global::Presentation_Layer.Properties.Resources.sign_out_32__2;
            this.tsmiSignOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiSignOut.Name = "tsmiSignOut";
            this.tsmiSignOut.Size = new System.Drawing.Size(333, 42);
            this.tsmiSignOut.Text = "Sign out";
            this.tsmiSignOut.Click += new System.EventHandler(this.tsmiSignOut_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Presentation_Layer.Properties.Resources.closeBlack32;
            this.btnClose.Location = new System.Drawing.Point(1018, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 36);
            this.btnClose.TabIndex = 8;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1075, 489);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainScreen";
            this.Text = "MainScreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiPeople;
        private System.Windows.Forms.ToolStripMenuItem tsmiDrivers;
        private System.Windows.Forms.ToolStripMenuItem tsmiUsers;
        private System.Windows.Forms.ToolStripMenuItem tsmiAccountSetting;
        private System.Windows.Forms.ToolStripMenuItem tsmiApplications;
        private System.Windows.Forms.ToolStripMenuItem tsmiCurrentUserInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePassword;
        private System.Windows.Forms.ToolStripMenuItem tsmiSignOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDrivingLicensesServices;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageApplications;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiDetainLicenses;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageApplicationTypes;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageTestTypes;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiLocalLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiInternationalLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiRenewDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiReplacementForLostOrDamagedLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiReleaseDetainedDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiRetakeTest;
        private System.Windows.Forms.ToolStripMenuItem tsmiLocalDrivingLicenseApplications;
        private System.Windows.Forms.ToolStripMenuItem tsmiInternationalLicenseApplications;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageDetainLicenses;
        private System.Windows.Forms.ToolStripMenuItem tsmiDetainLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiReleaseDetainedLicense;
        private System.Windows.Forms.Button btnClose;
    }
}