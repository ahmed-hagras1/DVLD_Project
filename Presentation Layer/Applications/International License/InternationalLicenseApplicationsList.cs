using Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer
{
    public partial class InternationalLicenseApplicationsList: Form
    {
        DataTable _internationalLicensesList;
        string _filterColumn;
        public InternationalLicenseApplicationsList()
        {
            InitializeComponent();
        }

        private void InternationalLicenseApplicationsList_Load(object sender, EventArgs e)
        {
          
            _internationalLicensesList = InternationalLicense.GetAllInternationalLicense();
            dgvInternationalLicenseApplications.DataSource = _internationalLicensesList;

            if(dgvInternationalLicenseApplications.Rows.Count > 0)
            {
                dgvInternationalLicenseApplications.Columns["InternationalLicenseID"].HeaderText = "Int License ID";
                dgvInternationalLicenseApplications.Columns["InternationalLicenseID"].Width = 100;

                dgvInternationalLicenseApplications.Columns["ApplicationID"].HeaderText = "Application ID";
                dgvInternationalLicenseApplications.Columns["ApplicationID"].Width = 100;

                dgvInternationalLicenseApplications.Columns["DriverID"].HeaderText = "Driver ID";
                dgvInternationalLicenseApplications.Columns["DriverID"].Width = 100;

                dgvInternationalLicenseApplications.Columns["IssuedUsingLocalLicenseID"].HeaderText = "L License ID";
                dgvInternationalLicenseApplications.Columns["IssuedUsingLocalLicenseID"].Width = 100;

                dgvInternationalLicenseApplications.Columns["IssueDate"].HeaderText = "Issue Date";
                dgvInternationalLicenseApplications.Columns["IssueDate"].Width = 200;

                dgvInternationalLicenseApplications.Columns["ExpirationDate"].HeaderText = "Expiration Date";
                dgvInternationalLicenseApplications.Columns["ExpirationDate"].Width = 200;

                dgvInternationalLicenseApplications.Columns["IsActive"].HeaderText = "Is Active";
                dgvInternationalLicenseApplications.Columns["IsActive"].Width = 80;

            }

            cbFilterBy.SelectedIndex = 0;
            lblInternatioanlLicenseApplicationsCount.Text = dgvInternationalLicenseApplications.Rows.Count.ToString();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilterBy.Text.Trim())
            {
                case "None":
                    txtFilterBy.Visible = cbIsActive.Visible = false;
                    txtFilterBy.Clear();
                    cbIsActive.SelectedIndex = 0;
                    break;
                case "Is Active":
                    txtFilterBy.Visible = false;
                    cbIsActive.Visible = true;
                    cbIsActive.SelectedIndex = 0;
                    txtFilterBy.Clear();
                    break;
                default:
                    txtFilterBy.Visible = true;
                    cbIsActive.Visible = false;
                    cbIsActive.SelectedIndex = 0;
                    txtFilterBy.Clear();
                    break;
            }

            switch (cbFilterBy.Text.Trim())
            {
                case "International License ID":
                    _filterColumn = "InternationalLicenseID";
                    break;
                case "Application ID":
                    _filterColumn = "ApplicationID";
                    break;
                case "Driver ID":
                    _filterColumn = "DriverID";
                    break;
                case "Local License ID":
                    _filterColumn = "IssuedUsingLocalLicenseID";
                    break;
                case "Is Active":
                    _filterColumn = "IsActive";
                    break;
                default:
                    _filterColumn = "None";
                    break;
            }
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterBy.Text.Trim()))
            {
                _internationalLicensesList.DefaultView.RowFilter = "";
            }
            else
            {
                _internationalLicensesList.DefaultView.RowFilter = string.Format("{0} = {1}", _filterColumn, txtFilterBy.Text.Trim());
            }

            lblInternatioanlLicenseApplicationsCount.Text = dgvInternationalLicenseApplications.Rows.Count.ToString();
        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsActive.SelectedIndex == cbIsActive.FindString("All"))
            {
                _internationalLicensesList.DefaultView.RowFilter = "";
            }
            else if (cbIsActive.SelectedIndex == cbIsActive.FindString("Yes"))
            {
                _internationalLicensesList.DefaultView.RowFilter = $"{_filterColumn} = 1";
            }
            else
            {
                _internationalLicensesList.DefaultView.RowFilter = $"{_filterColumn} = 0";
            }

            lblInternatioanlLicenseApplicationsCount.Text = dgvInternationalLicenseApplications.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits 1-9 and backspace/control keys
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < '1' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
        }

        private void btnAddNewILDLApp_Click(object sender, EventArgs e)
        {
            InternationalLicenseApplication frm = new InternationalLicenseApplication();
            frm.ShowDialog();

            InternationalLicenseApplicationsList_Load(null, null);
        }

        private void tsmiShowPersonDetails_Click(object sender, EventArgs e)
        {
            frmShowPersonDetails frm = new frmShowPersonDetails
                (InternationalLicense.FindInternationalLicense((int)dgvInternationalLicenseApplications.CurrentRow.Cells[0].Value).DriverInfo.PersonInfo.personID);
            frm.ShowDialog();
        }

        private void tsmiShowLicenseDetails_Click(object sender, EventArgs e)
        {
            ShowInternationalLicenseInfo frm = new ShowInternationalLicenseInfo((int)dgvInternationalLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void tsmiShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            ShowPersonLicenseHistory frm = new ShowPersonLicenseHistory
                (InternationalLicense.FindInternationalLicense((int)dgvInternationalLicenseApplications.CurrentRow.Cells[0].Value).DriverInfo.PersonInfo.personID);
            frm.ShowDialog();
        }
    }
}
