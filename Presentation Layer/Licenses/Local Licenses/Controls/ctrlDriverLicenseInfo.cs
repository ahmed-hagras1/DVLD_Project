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
    public partial class ctrlDriverLicenseInfo: UserControl
    {
        int _licenseID = -1;
        clsLicense _license;
        public clsLicense SelectedLicenseInfo
        {
            get { return _license; }
        }
        public int LicenseID
        {
            get { return _licenseID; }
        }
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        private void ctrlDriverLicenseInfo_Load(object sender, EventArgs e)
        {

        }

       public void LoadInfo(int licenseID)
       {
            _licenseID = licenseID;
            _license = clsLicense.FindLicense(_licenseID);


            if (_license == null)
            {
                MessageBox.Show("Error: License is not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _licenseID = -1;
                return;
            }

            lblClass.Text = _license.LicenseClassInfo.ClassName;
            lblName.Text = _license.DriverInfo.PersonInfo.FullName;
            lblLicenseID.Text = _license.LicenseID.ToString();
            lblNationalNo.Text = _license.DriverInfo.PersonInfo.nationalNo;
            
           if(_license.DriverInfo.PersonInfo.gender == 0)
            {
                lblGendor.Text = "Male";
                PbGendor.Image = Resources.Man_32;
            }
            else
            {
                lblGendor.Text = "Female";
                PbGendor.Image = Resources.Woman_32;
            }

            lblIssueDate.Text = _license.IssueDate.ToShortDateString();
            lblIssueReason.Text = _license.IssueReasonText;
            lblNotes.Text = (string.IsNullOrEmpty(_license.Notes)) ? "No Notes" : _license.Notes;
            lblIsActive.Text = (_license.IsActive) ? "Yes" : "No";
            lblDateOfBirth.Text = _license.DriverInfo.PersonInfo.dateOfBirth.ToShortDateString();
            lblDriverID.Text = _license.DriverID.ToString();
            lblExpirationDate.Text = _license.ExpirationDate.ToShortDateString();
            lblIsDetained.Text = _license.IsLicenseDetained ? "Yes" : "No";

            _LoadImage();
       }
        private void _LoadImage()
        {

            if (_license.DriverInfo.PersonInfo.gender == 0)
                pbPersonImage.Image = Resources.Male_5121;
            else
                pbPersonImage.Image = Resources.Female_5121;

          
            string imagePath = _license.DriverInfo.PersonInfo.ImagePath;

            if (string.IsNullOrEmpty(imagePath))
                return;

            if (File.Exists(imagePath))
                pbPersonImage.ImageLocation = imagePath;
            else
                MessageBox.Show("Couldn't find this image: " + imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
