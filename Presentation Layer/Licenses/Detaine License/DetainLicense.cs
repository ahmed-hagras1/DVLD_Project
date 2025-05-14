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
    public partial class DetainLicense: Form
    {
        int _detainID = -1;
        int _selectedLicenseID = -1;
        public DetainLicense()
        {
            InitializeComponent();
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits (0-9), backspace, and decimal separator (.)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true; // Ignore the input
                return;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        private void DetainLicense_Load(object sender, EventArgs e)
        {
            btnDetain.Enabled = llShowLicensesHistory.Enabled = llShowLicensesInfo.Enabled = false;

            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = SaveLoginInfo.currentUser.username.ToString();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            btnDetain.Enabled = llShowLicensesHistory.Enabled = llShowLicensesInfo.Enabled = false;

            _selectedLicenseID = obj;

            lblLicenseID.Text = _selectedLicenseID.ToString();
            llShowLicensesHistory.Enabled = (_selectedLicenseID != -1);

            if(_selectedLicenseID == -1)
            {
                return;
            }

            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseDetained)
            {
                MessageBox.Show("License already detained.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnDetain.Enabled = true;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            if (MessageBox.Show("Are you sure you want detain license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _detainID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainLicense
                (Convert.ToSingle(txtFineFees.Text.Trim()), SaveLoginInfo.currentUser.userID);
           
            if(_detainID == -1)
            {
                MessageBox.Show("Failed to detain license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblDLID.Text = _detainID.ToString();

            btnDetain.Enabled = ctrlDriverLicenseInfoWithFilter1.EnableFilter = txtFineFees.Enabled = false;
            llShowLicensesInfo.Enabled = true;

            MessageBox.Show("License Detained Successfully with ID = " + _detainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text.Trim()))
            {
                e.Cancel = true;
                txtFineFees.Focus();
                errorProvider1.SetError(txtFineFees, "It should have value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFineFees, "");
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
