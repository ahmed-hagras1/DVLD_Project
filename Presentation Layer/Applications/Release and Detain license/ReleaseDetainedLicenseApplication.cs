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
    public partial class ReleaseDetainedLicenseApplication: Form
    {
        float _totalFees = 0;
        int _selectedLicenseID = -1;
        public ReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
        }
        public ReleaseDetainedLicenseApplication(int licenseID)
        {
            InitializeComponent();

            _selectedLicenseID = licenseID;
            ctrlDriverLicenseInfoWithFilter1.LoadInfo(licenseID);
            ctrlDriverLicenseInfoWithFilter1.EnableFilter = false;
        }
        private void ReleaseDetainedLicenseApplication_Load(object sender, EventArgs e)
        {
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            btnRelease.Enabled = llShowLicensesHistory.Enabled = llShowLicensesInfo.Enabled = false;


            _selectedLicenseID = obj;

            llShowLicensesHistory.Enabled = (_selectedLicenseID != -1);
            lblLicenseID.Text = _selectedLicenseID.ToString();

            if (_selectedLicenseID == -1)
            {
                return;
            }


            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseDetained)
            {
                MessageBox.Show("Selected license is not detained.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplicationFees.Text =
                ApplicationType.FindApplicationTypeByID((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense).applicationTypeFees.ToString();
            lblCreatedBy.Text = SaveLoginInfo.currentUser.username;
            lblDetainID.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedLicenseInfo.detainedID.ToString();
            lblDetainDate.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedLicenseInfo.detainDate.ToShortDateString();
            lblFineFees.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedLicenseInfo.fineFees.ToString();

            _totalFees = Convert.ToSingle(lblFineFees.Text) + Convert.ToSingle(lblApplicationFees.Text);
            lblTotalFees.Text = _totalFees.ToString();

            btnRelease.Enabled = true;

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained license?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int releaseApplicationID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ReleaseLicense
                (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedLicenseInfo.detainedID, SaveLoginInfo.currentUser.userID);

            if (releaseApplicationID == -1)
            {
                MessageBox.Show("Failed to release the detained license.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplicationID.Text = releaseApplicationID.ToString();
            btnRelease.Enabled = ctrlDriverLicenseInfoWithFilter1.EnableFilter = false;
            llShowLicensesInfo.Enabled = true;

            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseInfo frm = new ShowLicenseInfo(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID);
            frm.ShowDialog();
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPersonLicenseHistory frm = new ShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void ctrlDriverLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
