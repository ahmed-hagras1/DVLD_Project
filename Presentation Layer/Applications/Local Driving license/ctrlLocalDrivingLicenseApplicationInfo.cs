using Business_Layer;
using System;
using System.Windows.Forms;

namespace Presentation_Layer
{
    public partial class ctrlLocalDrivingLicenseApplicationInfo : UserControl
    {
        LocalDrivingLicenseApplication localDrivingLicenseApplication;
        int localDrivingLicenseApplicationID = -1;
        public int LocalDrivingLicenseApplicationID
        {
            get
            {
                return localDrivingLicenseApplicationID;
            }
        }

        public bool EnableShowLicenseInfoLink
        {
            set
            {
                llShowLicenseInfo.Enabled = value;
            }
            get
            {
                return llShowLicenseInfo.Enabled;
            }
        }
        public ctrlLocalDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void LocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {

        }
        public void LoadLocalDrivingLicenseApplicationInfo(int localDrivingLicenseApplicationID)
        {
            this.localDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            localDrivingLicenseApplication = LocalDrivingLicenseApplication.FindLocalDrivingLicenseApplication(localDrivingLicenseApplicationID);

            if (localDrivingLicenseApplication == null)
            {
                _ResetLocalDrivingApplicationInfo();
                MessageBox.Show("Error: No local driving license application with ApplicationID = " + localDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _FillLocalDrivingApplicationInfo();
            }
        }
        private void _FillLocalDrivingApplicationInfo()
        {
            ctrlApplicationInfo1.LoadApplicationInfo(localDrivingLicenseApplication.ApplicationID);

            lblDLAppID.Text = localDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedForLicense.Text = LicenseClass.FindLicenseClass(localDrivingLicenseApplication.LicenseClassID).ClassName;
            lblPassedTests.Text = Test.GetPassedTestCount(localDrivingLicenseApplication.LocalDrivingLicenseApplicationID).ToString() + "/3";

            if (localDrivingLicenseApplication.IsLicenseIssued())
                llShowLicenseInfo.Enabled = true;
        }
        private void _ResetLocalDrivingApplicationInfo()
        {
            ctrlApplicationInfo1.LoadApplicationInfo(-1);

            lblAppliedForLicense.Text = "[???]";
            lblDLAppID.Text = "[???]";
            lblPassedTests.Text = "[???]";

            llShowLicenseInfo.Enabled = false;

        }

        private void ctrlApplicationInfo1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlApplicationInfo1_Load_1(object sender, EventArgs e)
        {

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseInfo frm = new ShowLicenseInfo(localDrivingLicenseApplication.GetActiveLicenseID());
            frm.ShowDialog();
        }
    }
}
