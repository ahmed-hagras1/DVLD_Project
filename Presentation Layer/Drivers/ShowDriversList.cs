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
    public partial class ShowDriversList: Form
    {
        DataTable _dtAllDrivers;
        public ShowDriversList()
        {
            InitializeComponent();
        }

        private void ShowDriversList_Load(object sender, EventArgs e)
        {
            cbFilterItems.SelectedIndex = 0;
            _dtAllDrivers = Driver.GetAllDrivers();

            dgvDriversList.DataSource = _dtAllDrivers;
            lblDriversCount.Text = dgvDriversList.Rows.Count.ToString();

            if(dgvDriversList.Rows.Count > 0)
            {
                dgvDriversList.Columns["DriverID"].HeaderText = "Driver ID";
                dgvDriversList.Columns["DriverID"].Width = 100;

                dgvDriversList.Columns["PersonID"].HeaderText = "Person ID";
                dgvDriversList.Columns["PersonID"].Width = 100;

                dgvDriversList.Columns["NationalNo"].HeaderText = "National No";
                dgvDriversList.Columns["NationalNo"].Width = 100;

                dgvDriversList.Columns["FullName"].HeaderText = "Full Name";
                dgvDriversList.Columns["FullName"].Width = 250;

                dgvDriversList.Columns["CreatedDate"].HeaderText = "Date";
                dgvDriversList.Columns["CreatedDate"].Width = 150;

                dgvDriversList.Columns["NumberOfActiveLicenses"].HeaderText = "Active Licenses";
                dgvDriversList.Columns["NumberOfActiveLicenses"].Width = 150;

            }
        }
        private void cbFilterItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterItems.Text.Trim() != "None");

            txtFilterValue.Text = "";
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string filterColumn;

            switch (cbFilterItems.Text.Trim())
            {
                case "Driver ID":
                    filterColumn = "DriverID";
                    break;
                case "Person ID":
                    filterColumn = "PersonID";
                    break;
                case "National No":
                    filterColumn = "NationalNo";
                    break;
                case "Full Name":
                    filterColumn = "FullName";
                    break;
                default:
                    filterColumn = "None";
                    break;
            }

            if (filterColumn == "DriverID" || filterColumn == "PersonID")
            {
                if (txtFilterValue.Text.Trim() == "")
                {
                    _dtAllDrivers.DefaultView.RowFilter = "";
                    lblDriversCount.Text = dgvDriversList.Rows.Count.ToString();
                    return;
                }

                _dtAllDrivers.DefaultView.RowFilter = string.Format("{0} = {1}" , filterColumn , txtFilterValue.Text.Trim());
            }
            else if (filterColumn == "NationalNo" || filterColumn == "FullName")
            {
                _dtAllDrivers.DefaultView.RowFilter = string.Format("{0} like '{1}%'", filterColumn, txtFilterValue.Text.Trim());
            }
            else
            {
                _dtAllDrivers.DefaultView.RowFilter = "";
            }

                lblDriversCount.Text = dgvDriversList.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterItems.Text.Trim() == "Driver ID" || cbFilterItems.Text.Trim() == "Person ID")
            {
                if (char.IsControl(e.KeyChar))
                {
                    return;
                }

                // Allow only digits (0-9)
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Reject the input
                }
            }
        }

        private void tsmiShowPersonInfo_Click(object sender, EventArgs e)
        {
            frmShowPersonDetails frm = new frmShowPersonDetails((int)dgvDriversList.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void tsmiShowPersonLicensesHistory_Click(object sender, EventArgs e)
        {
            ShowPersonLicenseHistory frm = new ShowPersonLicenseHistory((int)dgvDriversList.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void tsmiIssueInternationalLicense_Click(object sender, EventArgs e)
        {

        }
    }
}
