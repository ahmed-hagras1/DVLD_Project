using Business_Layer;
using Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer
{
    public partial class Add_UpdatePerson: Form
    {

        // Declare delegate.
        public delegate void DataBackEventHandler(object sender , int personID);

        // Declare an Event using the delegate.
        public event DataBackEventHandler DataBack;
        enum en_Gender { Male = 0 , Female = 1};
        public enum en_Mode { UpdateMode = 0, AddNewMode = 1 };
        public en_Mode Mode = en_Mode.AddNewMode;
        int personID;
        Person person;
        
        public Add_UpdatePerson(int personID)
        {
            InitializeComponent();
            Mode = en_Mode.UpdateMode;
            this.person = Person.FindPerson(personID);
            this.personID = personID;
        }

        public Add_UpdatePerson()
        {
            InitializeComponent();

            this.Mode = en_Mode.AddNewMode;
            person = new Person();
        }
        private void _LoadAllCountriesInComboBox()
        {
            DataTable countries = Country.GetAllCountries();

            foreach (DataRow row in countries.Rows)
            {
                cbCountries.Items.Add(row["CountryName"]);
            }
        }
        private void _ResetDefaultData()
        {
            _LoadAllCountriesInComboBox();

            // Make minimum age you can enter 18 years old.  
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);

            // this will set default country to Egypt.
            cbCountries.SelectedIndex = cbCountries.FindString("Egypt");

            // hide/show the remove link incase there is no image for the person.
            // In Add >> always visible = false , in Update >> Visible = false when image not exist.
            llRemoveImage.Visible = (pbImage.ImageLocation != null);

            // Set default image for the person.
            if (rbMale.Checked)
                pbImage.Image = Resources.Male_5121;
            else
                pbImage.Image = Resources.Female_5121;

            if (Mode == en_Mode.AddNewMode)
                lblCaption.Text = "Add new person";
            else
                lblCaption.Text = "Update person";
        }
        private void _LoadData()
        {
            // If you want in feature update data by using personId.
            if(person == null)
            {
                MessageBox.Show($"No person with ID = {personID}", "Person Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtFirstName.Text = person.firstName;
            txtSecondName.Text = person.secondName;
            txtThirdName.Text = person.thirdName;
            txtLastName.Text = person.lastName;
            txtNationalNo.Text = person.nationalNo;
            txtPhone.Text = person.phone;
            txtEmail.Text = person.email;
            txtAddress.Text = person.address;
            dtpDateOfBirth.Value = person.dateOfBirth;

            if (person.gender == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            // load person image incase it was set.
            if (person.ImagePath != "" && File.Exists(person.ImagePath))
                pbImage.ImageLocation = person.ImagePath;

            cbCountries.SelectedIndex = cbCountries.FindString(person.countryInfo.countryName);
            lblPersonID.Text = person.personID.ToString();

            // hide/show the remove link incase there is no image for the person.
            llRemoveImage.Visible = (person.ImagePath != "");
        }
        private void Add_UpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultData();

            if(Mode == en_Mode.UpdateMode)
            _LoadData();
        }
        delegate bool ValidateTextBoxes(ref string errorMessage, string text);

        private bool ValidateName(ref string errorMessage, string text)
        {
            if (string.IsNullOrEmpty(text))
                errorMessage = "It should have value";

            // return is textBox have value or not.
            return !string.IsNullOrEmpty(errorMessage);
        }
        private bool ValidateNationalNo(ref string errorMessage, string text)
        {
            if (string.IsNullOrEmpty(text) || Person.IsPersonExist(text))
            {
                if (string.IsNullOrEmpty(text))
                    errorMessage = "It should have value";
                else if(Mode != en_Mode.UpdateMode)
                    errorMessage = "Person already exist";
            }

            // return true if textBox not have value or nationalNo exist before.
            return !string.IsNullOrEmpty(errorMessage);
        }
        private bool ValidatePhone(ref string errorMessage, string text)
        {
            if (string.IsNullOrEmpty(text))
                errorMessage = "It should have value";

            return !string.IsNullOrEmpty(errorMessage);
        }
        private bool ValidateAddress(ref string errorMessage, string text)
        {
            if (string.IsNullOrEmpty(text))
                errorMessage = "It should have value";

            return !string.IsNullOrEmpty(errorMessage);
        }
        private void Validate(object sender, CancelEventArgs e, ValidateTextBoxes validateTextBoxes)
        {
            TextBox textBox = (TextBox)sender;
            string errorMessage = default;

            if (validateTextBoxes(ref errorMessage, textBox.Text.Trim()))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider.SetError(textBox, errorMessage);
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBox, "");
            }

        }
        private void ValidatingName(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidateName);
        }

        private void ValidatingNationalNo(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidateNationalNo);
        }

        private void ValidatingPhone(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidatePhone);
        }

        private void ValidatingAddress(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidateAddress);
        }
        private bool _HandlePersonImage()
        {
            if (person.ImagePath != pbImage.ImageLocation )
            {
                if(person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(person.ImagePath);
                    }
                    catch (Exception)
                    {

                    }
                }

                if (pbImage.ImageLocation != null )
                {
                    string sourceImageFile = pbImage.ImageLocation.ToString();

                    if (Utility.CopyImageToProjectImagesFolder(ref sourceImageFile))
                    {
                        pbImage.ImageLocation = sourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error coping image file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check all form valid or not.
            if (!this.ValidateChildren())
            {
                return;
            }

            if (!_HandlePersonImage())
                return;


            person.firstName = txtFirstName.Text.Trim();
            person.secondName = txtSecondName.Text.Trim();
            person.thirdName = txtThirdName.Text.Trim();
            person.lastName = txtLastName.Text.Trim();

            person.nationalNo = txtNationalNo.Text.Trim();
            person.dateOfBirth = dtpDateOfBirth.Value.Date;

            if (rbMale.Checked)
                person.gender = (byte)en_Gender.Male;
            else
                person.gender = (byte)en_Gender.Female;
            person.phone = txtPhone.Text.Trim();

            person.email = txtEmail.Text.Trim();
            person.nationalCountryID = Country.FindCountry(cbCountries.Text).countryID;

            person.address = txtAddress.Text.Trim();

            if (pbImage.ImageLocation != null)
                person.ImagePath = pbImage.ImageLocation;
            else
                person.ImagePath = "";

            if (person.Save())
            {
                lblPersonID.Text = person.personID.ToString();

                // Change Mode to update mode.
                Mode = en_Mode.UpdateMode;
                lblCaption.Text = "Update Person";
                MessageBox.Show("Data saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, person.personID);
            }
            else
            {
                MessageBox.Show("Error: Data is not saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                if (pbImage.ImageLocation == null)
                    pbImage.Image = Resources.Male_5121;
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
            {
                if (pbImage.ImageLocation == null)
                    pbImage.Image = Resources.Female_5121;
            }
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                pbImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;

            if (rbMale.Checked)
                pbImage.Image = Resources.Male_5121;
            else
                pbImage.Image = Resources.Female_5121;

            llRemoveImage.Visible = false;
        }
    }
}
