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

namespace Presentation_Layer.Users
{
    public partial class AddAndUpdateUser: Form
    {
        enum en_Mode { UpdateMode = 0 , AddNewMode=1 };
        en_Mode _Mode = en_Mode.AddNewMode;
        int _userID = -1;
        User _user;
        int _selectedPersonID;
        public AddAndUpdateUser(int userID)
        {
            InitializeComponent();

            _userID = userID;

            if (userID != -1)
            {
                _Mode = en_Mode.UpdateMode;
                _user = User.FindUserByUserID(_userID);
                _selectedPersonID = _user.personID;
                lblTitle.Text = "Update user";
                ctrlPersonCardWithFilter1.LoadSelectedPersonInfo(_user.personID);
                ctrlPersonCardWithFilter1.filterEnabled = false;
                _LoadUserInfo();
                cbIsActive.Checked = _user.isActive;
            }
            else
            {
                _Mode = en_Mode.AddNewMode;
                _user = new User();
                lblTitle.Text = "Add new user";
                btnSave.Enabled = btnNext.Enabled = tpLoginInfo.Enabled = false;
            }
        }
        private void _ResetDefaultValues()
        {
            if(_Mode == en_Mode.AddNewMode)
            {
                lblTitle.Text = "Add new user";
                this.Text = "Add new user";
                _user = new User();

                tpLoginInfo.Enabled = false;
            }
            else
            {
                lblTitle.Text = "Update user";
                this.Text = "Update user";

                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;
            }
        }
        private void AddAndUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == en_Mode.UpdateMode)
                _LoadUserInfo();
        }

        private void _LoadUserInfo()
        {
            lblUserID.Text = _user.userID.ToString();
            txtUsername.Text = _user.username;
            txtPassword.Text = _user.password;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            
             if (ctrlPersonCardWithFilter1.selectedPersonInfo == null)
             {
                 MessageBox.Show("Person is not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
             }
             else if (User.IsUserExistByPersonID(ctrlPersonCardWithFilter1.selectedPersonInfo.personID))
             {
                 if (_Mode == en_Mode.AddNewMode)
                 {
                     MessageBox.Show("Selected person already has a user, choose another one.", "Select another person",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                 }
                 else
                 {
                    _LoadUserInfo();
                 }
             }

             tabControl1.SelectedIndex = 1;
           
        }

        delegate bool ValidateTextBoxes(ref string errorMessage , string text);

        private bool ValidateUsername(ref string errorMessage , string text)
        {
            if (string.IsNullOrEmpty(text))
                errorMessage = "It should have value.";

            if (_Mode == en_Mode.AddNewMode)
            {
                if (User.IsUserExist(text))
                    errorMessage = "This user already exist";
            }


            return !string.IsNullOrEmpty(errorMessage);
        }
        private bool ValidatePassword(ref string errorMessage, string text)
        {
            if (string.IsNullOrEmpty(text))
                errorMessage = "It should have value.";
            else if (text.Length < 4)
                errorMessage = "Password should contain at least 4 digits";


            return !string.IsNullOrEmpty(errorMessage);
        }

        private bool ConfirmPassword(ref string errorMessage, string text)
        {
            if (string.IsNullOrEmpty(text))
                errorMessage = "It should have value.";
            else if (text != txtPassword.Text)
                errorMessage = "Password and Confirm Password do not match.";


            return !string.IsNullOrEmpty(errorMessage);
        }

        private void Validate(object sender , CancelEventArgs e , ValidateTextBoxes validateTextBoxes )
        {
            TextBox textBox = (TextBox)sender;
            string errorMessage = default;

            if (validateTextBoxes(ref errorMessage , textBox.Text))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider.SetError(textBox, errorMessage);
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBox, null);
                
            }
        }
        // Make textBox accept only digits.
        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ValidatingUsername(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidateUsername);
        }

        private void ValidatingPassword(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidatePassword);
        }

        private void ValidatingConfirmPassword(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ConfirmPassword);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            _user.username = txtUsername.Text.Trim();
            _user.password = txtPassword.Text.Trim();
            _user.isActive = cbIsActive.Checked;
            _user.personID = ctrlPersonCardWithFilter1.selectedPersonInfo.personID;
            

            if (_user.Save())
            {
                if(_Mode == en_Mode.AddNewMode)
                {
                    _Mode = en_Mode.UpdateMode;

                    lblTitle.Text = "Update user";
                    tabControl1.SelectedIndex = 0;
                    ctrlPersonCardWithFilter1.filterEnabled = false;
                }
                else
                {
                    tabControl1.SelectedIndex = 0;
                }

                MessageBox.Show("User data has been saved successfully.", "Saved Successfully",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Failed to save user data. Please check the input and try again.", "Save Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if ( _user.username == SaveLoginInfo.currentUser.username && _user.isActive == false)
            {
                SaveLoginInfo.currentUser= _user;
                frmLoginForm frm = new frmLoginForm();
                frm.ShowDialog();
            }
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = (cbShowPassword.Checked) ? '\0' : '*';
        }

        private void cbShowConfirmPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtConfirmPassword.PasswordChar = (cbShowConfirmPassword.Checked) ? '\0' : '*';
        }

        private void ctrlPersonCardWithFilter1_onPersonSelected(int obj)
        {
            _selectedPersonID = obj;
            btnSave.Enabled = btnNext.Enabled = tpLoginInfo.Enabled = true;
        }
    }
}
