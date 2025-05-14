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
    public partial class RenewLicenseApplication: Form
    {
        float _totalFees = 0;
        int _renewLicenseID = -1;
        public RenewLicenseApplication()
        {
            InitializeComponent();
        }

        private void RenewLicenseApplication_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();

            llShowLicensesHistory.Enabled = llShowNewLicensesInfo.Enabled = btnRenew.Enabled = false;

            lblAppDate.Text = lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = lblAppDate.Text;

            lblAppFees.Text = ApplicationType.FindApplicationTypeByID((int)clsApplication.enApplicationType.RenewDrivingLicenseService).applicationTypeFees.ToString();
            lblCreatedBy.Text = SaveLoginInfo.currentUser.username;
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            llShowLicensesHistory.Enabled = llShowNewLicensesInfo.Enabled = btnRenew.Enabled = false;
            

            int selectedLicenseID = obj;

            lblOldLicenseID.Text = selectedLicenseID.ToString();

            if (selectedLicenseID == -1)
            {
                return;
            }

            llShowLicensesHistory.Enabled = true;
            lblExpirationDate.Text = DateTime.Now.AddYears(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.DefaultValidityLength).ToShortDateString();
            lblLicenseFees.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.ClassFees.ToString();

            _totalFees = Convert.ToSingle(lblAppFees.Text) + Convert.ToSingle(lblLicenseFees.Text);
            lblTotalFees.Text = _totalFees.ToString();

            txtNotes.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Notes;

            // When license is not expired.
            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show($"Selected License is not yet expired, it will expire on {ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate}",
                    "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            // When license is not active.
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                // license not active when already have a renew license, replaced for damaged, replaced for lost, or Detained.
                MessageBox.Show("Selected license is not active.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = llShowNewLicensesInfo.Enabled = false;
                return;
            }

            btnRenew.Enabled = true;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLicense newLicense = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.RenewLicense(txtNotes.Text.Trim(), SaveLoginInfo.currentUser.userID);
           

            if(newLicense == null)
            {
                MessageBox.Show("Failed to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _renewLicenseID = newLicense.LicenseID;
            lblRLAppID.Text = newLicense.ApplicationID.ToString();
            lblRLicenseID.Text = newLicense.LicenseID.ToString();

            MessageBox.Show($"License Renewed successfully with ID = {_renewLicenseID}", "License renewed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ctrlDriverLicenseInfoWithFilter1.EnableFilter = btnRenew.Enabled = false;
            llShowNewLicensesInfo.Enabled = true;
            
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPersonLicenseHistory frm = new ShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void llShowNewLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseInfo frm = new ShowLicenseInfo(_renewLicenseID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
