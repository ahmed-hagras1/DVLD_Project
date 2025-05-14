using Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer
{
    public partial class ListDetaindedLicensese: Form
    {
        DataTable _dtDetainedLicenses;
        string _filterColumn;
        public ListDetaindedLicensese()
        {
            InitializeComponent();
        }

        private void ListDetaindedLicensese_Load(object sender, EventArgs e)
        {
            _dtDetainedLicenses = DetainedLicense.GetAllDetainedLicenses();
            dgvDetainedLicenses.DataSource = _dtDetainedLicenses;
            lblDetainedLicensesCount.Text = dgvDetainedLicenses.Rows.Count.ToString();
            cbFilterBy.SelectedIndex = 0;

            if (dgvDetainedLicenses.Rows.Count > 0)
            {
                dgvDetainedLicenses.Columns["DetainID"].HeaderText = "D ID";
                dgvDetainedLicenses.Columns["DetainID"].Width = 40;

                dgvDetainedLicenses.Columns["LicenseID"].HeaderText = "L ID";
                dgvDetainedLicenses.Columns["LicenseID"].Width = 40;

                dgvDetainedLicenses.Columns["DetainDate"].HeaderText = "D Date";
                dgvDetainedLicenses.Columns["DetainDate"].Width = 150;

                dgvDetainedLicenses.Columns["IsReleased"].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns["IsReleased"].Width = 80;

                dgvDetainedLicenses.Columns["FineFees"].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns["FineFees"].Width = 80;

                dgvDetainedLicenses.Columns["ReleaseDate"].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns["ReleaseDate"].Width = 140;

                dgvDetainedLicenses.Columns["NationalNo"].HeaderText = "N No";
                dgvDetainedLicenses.Columns["NationalNo"].Width = 40;

                dgvDetainedLicenses.Columns["FullName"].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns["FullName"].Width = 200;

                dgvDetainedLicenses.Columns["ReleaseApplicationID"].HeaderText = "Release App ID";
                dgvDetainedLicenses.Columns["ReleaseApplicationID"].Width = 110;

            }
        }

        //None
        //Detain ID
        //Is Released
        //National No.
        //Full Name
        //Release Application ID
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilterBy.Text)
            {
                case "Detain ID":
                    cbIsReleased.SelectedIndex = 0;
                    txtFilterBy.Clear();
                    txtFilterBy.Visible = true;
                    cbIsReleased.Visible = false;
                    _filterColumn = "DetainID";
                    break;
                case "Is Released":
                    cbIsReleased.SelectedIndex = 0;
                    txtFilterBy.Clear();
                    txtFilterBy.Visible = false;
                    cbIsReleased.Visible = true;
                    _filterColumn = "IsReleased";
                    break;
                case "National No.":
                    cbIsReleased.SelectedIndex = 0;
                    txtFilterBy.Clear();
                    txtFilterBy.Visible = true;
                    cbIsReleased.Visible = false;
                    _filterColumn = "NationalNo";
                    break;
                case "Full Name":
                    cbIsReleased.SelectedIndex = 0;
                    txtFilterBy.Clear();
                    txtFilterBy.Visible = true;
                    cbIsReleased.Visible = false;
                    _filterColumn = "FullName";
                    break;
                case "Release Application ID":
                    cbIsReleased.SelectedIndex = 0;
                    txtFilterBy.Clear();
                    txtFilterBy.Visible = true;
                    cbIsReleased.Visible = false;
                    _filterColumn = "ReleaseApplicationID";
                    break;
                default:
                    cbIsReleased.SelectedIndex = 0;
                    txtFilterBy.Clear();
                    txtFilterBy.Visible = false;
                    cbIsReleased.Visible = false;
                    _filterColumn = "None";
                    break;
            }
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterBy.Text.Trim()))
            {
                _dtDetainedLicenses.DefaultView.RowFilter = "";
                lblDetainedLicensesCount.Text = dgvDetainedLicenses.Rows.Count.ToString();
                return;
            }


            if (_filterColumn == "NationalNo" || _filterColumn == "FullName")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("{0} like '{1}%'", _filterColumn, txtFilterBy.Text.Trim());
            }
            else
            {
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("{0} = {1}", _filterColumn, txtFilterBy.Text.Trim());

            }

            lblDetainedLicensesCount.Text = dgvDetainedLicenses.Rows.Count.ToString();

        }
        //All
        //Yes
        //No
        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbIsReleased.Text.Trim())
            {
                case "Yes":
                    _dtDetainedLicenses.DefaultView.RowFilter = string.Format("{0} = 1", _filterColumn);
                    break;
                case "No":
                    _dtDetainedLicenses.DefaultView.RowFilter = string.Format("{0} = 0", _filterColumn);
                    break;
                default:
                    _dtDetainedLicenses.DefaultView.RowFilter = "";
                    break;
                    break;
            }

            lblDetainedLicensesCount.Text = dgvDetainedLicenses.Rows.Count.ToString();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            DetainLicense frm = new DetainLicense();
            frm.ShowDialog();

            // Refresh.
            ListDetaindedLicensese_Load(null, null);
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicenseApplication frm = new ReleaseDetainedLicenseApplication();
            frm.ShowDialog();

            // Refresh.
            ListDetaindedLicensese_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmDetainedLicenses_Opening(object sender, CancelEventArgs e)
        {
            tsmiReleaseDetainedLicense.Enabled = !(bool)dgvDetainedLicenses.CurrentRow.Cells[3].Value;
        }

        private void tsmiShowPersonDetails_Click(object sender, EventArgs e)
        {
            clsLicense selectedLicense = clsLicense.FindLicense((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);

            frmShowPersonDetails frm = new frmShowPersonDetails(selectedLicense.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void tsmiShowLicenseDetails_Click(object sender, EventArgs e)
        {
            clsLicense selectedLicense = clsLicense.FindLicense((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);

            ShowLicenseInfo frm = new ShowLicenseInfo(selectedLicense.LicenseID);
            frm.ShowDialog();
        }

        private void tsmiShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            clsLicense selectedLicense = clsLicense.FindLicense((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);

            ShowPersonLicenseHistory frm = new ShowPersonLicenseHistory(selectedLicense.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void tsmiReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            clsLicense selectedLicense = clsLicense.FindLicense((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);

            ReleaseDetainedLicenseApplication frm = new ReleaseDetainedLicenseApplication(selectedLicense.LicenseID);
            frm.ShowDialog();

            // Refresh.
            ListDetaindedLicensese_Load(null, null);
        }
    }
}
