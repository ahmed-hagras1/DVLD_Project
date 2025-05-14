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
    public partial class InternationalLicenseApplication: Form
    {
        int _internationalLicenseID = -1;
        public InternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            llShowLicensesInfo.Enabled = llShowLicensesHistory.Enabled = false;

            int selectedLicenseID = obj;

            lblLocalLicenseID.Text = selectedLicenseID.ToString();

            if (selectedLicenseID == -1)
                return;

            llShowLicensesHistory.Enabled = (selectedLicenseID != -1);

            int activeInternationalLicenseID = InternationalLicense.GetActiveInternationalLicenseIDByDriverID(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);

            if(activeInternationalLicenseID != -1)
            {
                MessageBox.Show($"Error: Person already have an international license with ID = {activeInternationalLicenseID}" , "Not Allow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                llShowLicensesInfo.Enabled = true;
                _internationalLicenseID = activeInternationalLicenseID;
                btnIssue.Enabled = false;
                return;
            }

            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassID != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnIssue.Enabled = true;
            _internationalLicenseID = -1;
        }

        private void InternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblFees.Text = ApplicationType.FindApplicationTypeByID((int)clsApplication.enApplicationType.NewInternationalLicense).applicationTypeFees.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            lblCreatedBy.Text = SaveLoginInfo.currentUser.username;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want issue this license?", "Confirm" , MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive == false)
            {
                MessageBox.Show("License is not Active!", "Not Allow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show("License is already expired", "Not Allow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InternationalLicense internationalLicense = new InternationalLicense();

            internationalLicense.DriverID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            internationalLicense.IssuedUsingLocalLicenseID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID;
            internationalLicense.IssueDate = DateTime.Now;
            internationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            internationalLicense.IsActive = true;
            internationalLicense.CreatedByUserID = SaveLoginInfo.currentUser.userID;
            internationalLicense.ApplicantPersonID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            internationalLicense.ApplicationDate = DateTime.Now;
            internationalLicense.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;
            internationalLicense.ApplicationStatus = clsApplication.enStatus.Completed;
            internationalLicense.LastStatusDate = DateTime.Now;
            internationalLicense.PaidFees = internationalLicense.applicationType.applicationTypeFees;

            if (!internationalLicense.Save())
            {
                MessageBox.Show("Error: Failed to issue international license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _internationalLicenseID = internationalLicense.InternationalLicenseID;
            lblILLicenseID.Text = internationalLicense.InternationalLicenseID.ToString();
            lblILAppID.Text = internationalLicense.ApplicationID.ToString();

            MessageBox.Show($"International license issued successfully with ID = {_internationalLicenseID}", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssue.Enabled = ctrlDriverLicenseInfoWithFilter1.EnableFilter = false;
            llShowLicensesInfo.Enabled = true;
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPersonLicenseHistory frm = new ShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void llShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowInternationalLicenseInfo frm = new ShowInternationalLicenseInfo(_internationalLicenseID);
            frm.ShowDialog();
        }
    }
}
