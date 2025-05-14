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
    public partial class ctrlDriverLicenseInfoWithFilter: UserControl
    {
        public event Action<int> OnLicenseSelected;
        protected void LicenseSelected(int licenseID)
        {
            Action<int> handler = OnLicenseSelected;

            if (handler != null)
                handler(licenseID);
        }

        int _licenseID;
        clsLicense _license;
        public clsLicense SelectedLicenseInfo
        {
            get
            {
                return ctrlDriverLicenseInfo1.SelectedLicenseInfo;
            }
        }
        bool _filterEnabled = true;
        public bool EnableFilter
        {
            get
            {
                return _filterEnabled;
            }
            set
            {
                _filterEnabled = value;
                gbFilter.Enabled = _filterEnabled;
            }
        }
        
        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        private void ctrlDriverLicenseInfoWithFilter_Load(object sender, EventArgs e)
        {

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
                return;

            int.TryParse(txtLicenseID.Text.Trim(), out _licenseID);
            _license = clsLicense.FindLicense(_licenseID);

            LoadInfo(_licenseID);
        }
        public void LoadInfo (int licenseID)
        {
            txtLicenseID.Text = licenseID.ToString();

            ctrlDriverLicenseInfo1.LoadInfo(licenseID);
            _licenseID = ctrlDriverLicenseInfo1.LicenseID;

            if (OnLicenseSelected != null && EnableFilter)
                LicenseSelected(_licenseID);
        }
        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtLicenseID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLicenseID.Text.Trim()))
            {
                e.Cancel = true;
                txtLicenseID.Focus();
                errorProvider.SetError(txtLicenseID, "It should have value");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtLicenseID, "");
            }
        }
        public void txtLicenseIDFocus()
        {
            txtLicenseID.Focus();
        }
        private void ctrlDriverLicenseInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
