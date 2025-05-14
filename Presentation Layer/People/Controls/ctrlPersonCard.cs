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
    public partial class ctrlPersonCard: UserControl
    {
        private int _personID;
        private string _nationalNo;
        private Person _selectedPerson = null;

        public int PersonID
        {
            get { return _personID; }
        }
        public string NationalNo
        {
            get { return _nationalNo; }
        }
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
        }
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int personID)
        {
            this._selectedPerson = Person.FindPerson(personID);

            if (_selectedPerson == null)
            {
                MessageBox.Show($"No person with personID = {personID.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        public void LoadPersonInfo (string NationalNo)
        {
            _selectedPerson = Person.FindPerson(NationalNo);

            if (_selectedPerson == null)
            {
                MessageBox.Show($"No person with NationalNo = {NationalNo}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        private void _LoadPersonImage()
        {
            if (!string.IsNullOrEmpty(_selectedPerson.ImagePath))
            {
                if (File.Exists(_selectedPerson.ImagePath))
                {
                    pbImage.ImageLocation = _selectedPerson.ImagePath;
                    return;
                }
                else
                {
                    MessageBox.Show("Couldn't find this image: " + _selectedPerson.ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            pbImage.Image = (_selectedPerson.gender == 0) ? Resources.Male_5121 : Resources.Female_5121;
        }
        private void _FillPersonInfo()
        {
            _personID = _selectedPerson.personID;
            _nationalNo = _selectedPerson.nationalNo;

            lblPersonID.Text = _selectedPerson.personID.ToString();

            lblName.Text = _selectedPerson.firstName + " " + _selectedPerson.secondName + " ";
            if (!string.IsNullOrEmpty(_selectedPerson.thirdName))
                lblName.Text += _selectedPerson.thirdName + " ";
            lblName.Text += _selectedPerson.lastName;

            lblNationalNo.Text = _selectedPerson.nationalNo;

            lblGendor.Text = (_selectedPerson.gender == 0) ? "Male" :  "Female";

            lblEmail.Text = _selectedPerson.email;
            lblAddress.Text = _selectedPerson.address;
            lblDateOfBirth.Text = _selectedPerson.dateOfBirth.Date.ToShortDateString();
            lblPhone.Text = _selectedPerson.phone;
            lblCountry.Text = _selectedPerson.countryInfo.countryName;
            _LoadPersonImage();
        }
        private void _ResetPersonInfo()
        {
            _personID = -1;
            lblPersonID.Text = "???";
            lblName.Text = "???";
            lblNationalNo.Text = "???";
            lblGendor.Text = "???";
            lblEmail.Text = "???";
            lblAddress.Text = "???";
            lblDateOfBirth.Text = "???";
            lblPhone.Text = "???";
            lblCountry.Text = "???";
            pbImage.Image = Resources.Male_5121;
        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new Add_UpdatePerson(_personID);
            frm.ShowDialog();

            // refresh person info.
            LoadPersonInfo(_personID);
        }

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {

        }

        private void pbImage_Click(object sender, EventArgs e)
        {

        }
    }
}
