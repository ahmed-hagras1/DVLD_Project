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
using Presentation_Layer.Properties;
using System.IO;

namespace Presentation_Layer
{
    public partial class ctrlDriverInterrnationalLicenseInfo: UserControl
    {
        int _internationalLicenseID = -1;
        InternationalLicense _internationalLicense;
        public InternationalLicense SelectedInternationalLicenseInfo
        {
            get { return _internationalLicense; }
        }

        public ctrlDriverInterrnationalLicenseInfo()
        {
            InitializeComponent();
        }

        private void ctrlDriverInterrnationalLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        public void LoadInfo(int internationalLicenseID)
        {
            _internationalLicenseID = internationalLicenseID;
            _internationalLicense = InternationalLicense.FindInternationalLicense(_internationalLicenseID);

            if(_internationalLicense == null)
            {
                _internationalLicenseID = -1;
                MessageBox.Show("Error: International license is not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblName.Text = _internationalLicense.DriverInfo.PersonInfo.FullName;
            lblIntLicenseID.Text = _internationalLicenseID.ToString();
            lblLicenseID.Text = _internationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text = _internationalLicense.DriverInfo.PersonInfo.nationalNo;
            
            if(_internationalLicense.DriverInfo.PersonInfo.gender == 0)
            {
                pbGendor.Image = Resources.Man_32;
                lblGendor.Text = "Male";
            }
            else
            {
                pbGendor.Image = Resources.Woman_32;
                lblGendor.Text = "Female";
            }
            
            lblIssueDate.Text = _internationalLicense.IssueDate.ToShortDateString();
            lblApplicationID.Text = _internationalLicense.ApplicationID.ToString();
            lblIsActive.Text = (_internationalLicense.IsActive) ? "Yes" : "No";
            lblDateOfBirth.Text = _internationalLicense.DriverInfo.PersonInfo.dateOfBirth.ToShortDateString();
            lblDriverID.Text = _internationalLicense.DriverID.ToString();
            lblExpirationDate.Text = _internationalLicense.ExpirationDate.ToShortDateString();

            _LoadImage();
        }

        private void _LoadImage()
        {
            if (_internationalLicense.DriverInfo.PersonInfo.gender == 0)
                pbPersonImage.Image = Resources.Male_5121;
            else
                pbPersonImage.Image = Resources.Female_5121;

            string imagePath = _internationalLicense.DriverInfo.PersonInfo.ImagePath;

            if (string.IsNullOrEmpty(imagePath))
                return;

            if (File.Exists(imagePath))
            {
                pbPersonImage.ImageLocation = imagePath;
            }
            else
            {
                MessageBox.Show("Couldn't find this image: " + imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
