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
    public partial class ReplaceDamagedOrLostLicense: Form
    {
        int _newLicenseID = -1;
        public ReplaceDamagedOrLostLicense()
        {
            InitializeComponent();
        }

        private void ReplaceDamagedOrLostLicense_Load(object sender, EventArgs e)
        {
            btnIssueReplacement.Enabled = llShowLicensesHistory.Enabled = llShowNewLicensesInfo.Enabled = false;

            lblCreatedBy.Text = SaveLoginInfo.currentUser.username;
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblAppFees.Text = ApplicationType.FindApplicationTypeByID
                ((int)clsApplication.enApplicationType.ReplacementForADamagedDrivingLicense).applicationTypeFees.ToString();
        }
        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement for damaged license";
            lblAppFees.Text = ApplicationType.FindApplicationTypeByID
                ((int)clsApplication.enApplicationType.ReplacementForADamagedDrivingLicense).applicationTypeFees.ToString();

        }
        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement for lost license";
            lblAppFees.Text = ApplicationType.FindApplicationTypeByID
                ((int)clsApplication.enApplicationType.ReplacementForALostDrivingLicense).applicationTypeFees.ToString();
        }
        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            btnIssueReplacement.Enabled = llShowLicensesHistory.Enabled = llShowNewLicensesInfo.Enabled = false;

            int selectedLicenseID = obj;

            lblOldLicenseID.Text = selectedLicenseID.ToString();
            llShowLicensesHistory.Enabled = (selectedLicenseID != -1);
            
            if(selectedLicenseID == -1)
            {
                return;
            }

            // if you reached to here then selected license is found.
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Error: License is not active.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // if you reached to here then license is found and active.
            btnIssueReplacement.Enabled = true;

        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to issue a replacement for the license?", "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLicense newLicense;

            if (rbDamagedLicense.Checked)
                newLicense = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ReplacementLicense
                    (clsApplication.enApplicationType.ReplacementForADamagedDrivingLicense, SaveLoginInfo.currentUser.userID);
            else
                newLicense = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ReplacementLicense
                    (clsApplication.enApplicationType.ReplacementForALostDrivingLicense, SaveLoginInfo.currentUser.userID);

            if(newLicense == null)
            {
                MessageBox.Show("Failed to issue replacement for this license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _newLicenseID = newLicense.LicenseID;
            lblRLicenseID.Text = _newLicenseID.ToString();
            lblLRAppID.Text = newLicense.ApplicationID.ToString();
            llShowNewLicensesInfo.Enabled = true;
            btnIssueReplacement.Enabled  = ctrlDriverLicenseInfoWithFilter1.EnableFilter = gbReplacementFor.Enabled  = false;

            MessageBox.Show("Licensed Replaced Successfully with ID=" + _newLicenseID.ToString(), "License Issued",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPersonLicenseHistory frm = new ShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonInfo.personID);
            frm.ShowDialog();
        }

        private void llShowNewLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseInfo frm = new ShowLicenseInfo(_newLicenseID);
            frm.ShowDialog();
        }
    }
}
