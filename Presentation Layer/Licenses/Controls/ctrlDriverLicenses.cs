using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Layer;

namespace Presentation_Layer
{
    public partial class ctrlDriverLicenses: UserControl
    {
        int _driverID;
        Driver _driver;
        DataTable _dtDriverLocalLicensesHistory;
        DataTable _dtDriverInternationalLicenseHistory;
        public ctrlDriverLicenses()
        {
            InitializeComponent();
            
        }

        private void ctrlDriverLicenses_Load(object sender, EventArgs e)
        {

        }

        private void _FillLocalInfo()
        {
            
           _dtDriverLocalLicensesHistory = Driver.GetLicenses(_driverID);

            lblLocalLicensesCount.Text = _dtDriverLocalLicensesHistory.Rows.Count.ToString();

            if (_dtDriverLocalLicensesHistory.Rows.Count == 0)
                return;

            dgvLocalLicenses.DataSource = _dtDriverLocalLicensesHistory;

            dgvLocalLicenses.Columns["LicenseID"].HeaderText = "Lic ID";
            dgvLocalLicenses.Columns["LicenseID"].Width = 70;

            dgvLocalLicenses.Columns["ApplicationID"].HeaderText = "App ID";
            dgvLocalLicenses.Columns["ApplicationID"].Width = 70;

            dgvLocalLicenses.Columns["ClassName"].HeaderText = "Class Name";
            dgvLocalLicenses.Columns["ClassName"].Width = 240;

            dgvLocalLicenses.Columns["IssueDate"].HeaderText = "Issue Date";
            dgvLocalLicenses.Columns["IssueDate"].Width = 140;

            dgvLocalLicenses.Columns["ExpirationDate"].HeaderText = "Expiration Date";
            dgvLocalLicenses.Columns["ExpirationDate"].Width = 140;

            dgvLocalLicenses.Columns["IsActive"].HeaderText = "Is Active";
            dgvLocalLicenses.Columns["IsActive"].Width = 70;
        }
        private void _FillInternationalInfo()
        {
            _dtDriverInternationalLicenseHistory = Driver.GetInternationalLicenses(_driverID);

            lblInternationalLicensesCount.Text = _dtDriverInternationalLicenseHistory.Rows.Count.ToString();

            if (_dtDriverInternationalLicenseHistory.Rows.Count == 0)
                return;

            dgvInternationalLicenses.DataSource = _dtDriverInternationalLicenseHistory;

            dgvInternationalLicenses.Columns["InternationalLicenseID"].HeaderText = "International License ID";
            dgvInternationalLicenses.Columns["InternationalLicenseID"].Width = 170;

            dgvInternationalLicenses.Columns["ApplicationID"].HeaderText = "App ID";
            dgvInternationalLicenses.Columns["ApplicationID"].Width = 70;

            dgvInternationalLicenses.Columns["IssuedUsingLocalLicenseID"].HeaderText = "L License ID";
            dgvInternationalLicenses.Columns["IssuedUsingLocalLicenseID"].Width = 150;

            dgvInternationalLicenses.Columns["IssueDate"].HeaderText = "Issue Date";
            dgvInternationalLicenses.Columns["IssueDate"].Width = 150;

            dgvInternationalLicenses.Columns["ExpirationDate"].HeaderText = "Expiration Date";
            dgvInternationalLicenses.Columns["ExpirationDate"].Width = 150;

            dgvInternationalLicenses.Columns["IsActive"].HeaderText = "Is Active";
            dgvInternationalLicenses.Columns["IsActive"].Width = 70;
        }

        public void LoadInfo(int driverID)
        {
            _driverID = driverID;
            _driver = Driver.FindDriver(_driverID);

            if (_driver == null)
            {
                MessageBox.Show("Error: Driver not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalInfo();
            _FillInternationalInfo();
        }
        public void LoadInfoByPersonID(int personID)
        {
            _driver = Driver.FindDriverByPersonID(personID);
           

            if(_driver == null)
            {
                MessageBox.Show("Error: Driver not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _driverID = _driver.DriverID;

            _FillLocalInfo();
            _FillInternationalInfo();
        }
        public void Clear()
        {
            
        }
        private void tsmiShowLicenseInfo_Click(object sender, EventArgs e)
        {
            ShowLicenseInfo frm = new ShowLicenseInfo((int)dgvLocalLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void tsmiShowInternaitonalLicenseInfo_Click(object sender, EventArgs e)
        {
            ShowInternationalLicenseInfo frm = new ShowInternationalLicenseInfo((int)dgvInternationalLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

    }
}
