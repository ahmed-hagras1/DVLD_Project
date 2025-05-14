using Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer
{
    public partial class IssueLicense: Form
    {
        int _localDrivingLicenseApplicationID = -1;
        LocalDrivingLicenseApplication _localDrivingLicenseApplication;

        public IssueLicense(int localDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _localDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _localDrivingLicenseApplication = LocalDrivingLicenseApplication.FindLocalDrivingLicenseApplication(_localDrivingLicenseApplicationID);
        }

        private void IssueLicense_Load(object sender, EventArgs e)
        {
            if(_localDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: local driving license app is not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }

            int licenseID = _localDrivingLicenseApplication.GetActiveLicenseID();
            if (licenseID != -1)
            {
                MessageBox.Show("Person already has License before with License ID=" + licenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }

            if (!_localDrivingLicenseApplication.DoesPassAllTests())
            {
                MessageBox.Show("Person should pass all tests first.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }

            // you can issue the license only if the application status is new.
            if (_localDrivingLicenseApplication.ApplicationStatus != clsApplication.enStatus.New)
            {
                MessageBox.Show("Person should have a new application.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }

            btnIssue.Enabled = true;
            ctrlLocalDrivingLicenseApplicationInfo1.LoadLocalDrivingLicenseApplicationInfo(_localDrivingLicenseApplicationID);

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
   
            if(MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (_localDrivingLicenseApplication.IssueLicenseForTheFirstTime(txtNotes.Text.Trim(), SaveLoginInfo.currentUser.userID) != -1)
            {
                MessageBox.Show("License issued successfully", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIssue.Enabled = false;
                ctrlLocalDrivingLicenseApplicationInfo1.EnableShowLicenseInfoLink = true;
            }
            else
            {
                MessageBox.Show("License issued failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
