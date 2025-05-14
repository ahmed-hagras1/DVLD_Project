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

namespace Presentation_Layer
{
    public partial class ChangeUserPassword: Form
    {
        int _userID;
        User _user;
        public ChangeUserPassword(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        // Accept only numbers in textBox.
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ignore the input
            }
        }

        delegate bool ValidateTextBoxes(ref string errorMessage, string text);

        private bool ValidateCurrentPasswordTextBox(ref string errorMessage , string text)
        {
            if (string.IsNullOrEmpty(text))
                errorMessage = "Current password cannot be empty. Please enter your current password.";
            else if (text != _user.password)
                errorMessage = "Incorrect current password. Please try again.";

                return !(string.IsNullOrEmpty(errorMessage));
        }
        private bool ValidateNewPasswordTextBox(ref string errorMessage, string text)
        {
            if (string.IsNullOrEmpty(text))
                errorMessage = "New password cannot be empty. Please enter a new password.";
            else if (text.Length < 4)
                errorMessage = "New password must be at least 4 digits long. Please choose a longer password.";

            return !(string.IsNullOrEmpty(errorMessage));
        }
        private bool ValidateConfirmPasswordTextBox(ref string errorMessage, string text)
        {
            if (string.IsNullOrEmpty(text))
                errorMessage = "Confirm password cannot be empty. Please re-enter your new password.";
            else if (text != txtNewPassword.Text.Trim())
                errorMessage = "Passwords do not match. Please ensure both passwords are the same.";

            return !(string.IsNullOrEmpty(errorMessage));
        }

        private void Validate(object sender, CancelEventArgs e, ValidateTextBoxes validateTextBoxes)
        {
            string errorMessage = default;
            TextBox textBox = (TextBox)sender;

            if(validateTextBoxes(ref errorMessage, textBox.Text))
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

        private void ValidatingCurrentPassword(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidateCurrentPasswordTextBox);
        }

        private void ValidatingNewPassword(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidateNewPasswordTextBox);
        }

        private void ValidatingConfirmNewPassword(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidateConfirmPasswordTextBox);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            if (_user.ChangeUserPassword(txtNewPassword.Text.Trim()))
                MessageBox.Show("Password changed successfully.", "confirm changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Password change failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbShowCurrentPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtCurrentPassword.PasswordChar = (cbShowCurrentPassword.Checked) ? '\0' : '*';
        }

        private void cbShowNewPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtNewPassword.PasswordChar = (cbShowNewPassword.Checked) ? '\0' : '*';
        }

        private void cbShowConfirmNewPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtConfirmNewPassword.PasswordChar = (cbShowConfirmNewPassword.Checked) ? '\0' : '*';
        }

        private void _ResetDefaultValues()
        {
            txtCurrentPassword.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
            txtConfirmNewPassword.Text = string.Empty;
            txtCurrentPassword.Focus();
        }
        private void ChangeUserPassword_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            _user = User.FindUserByUserID(_userID);

            if (_user == null)
            {
                MessageBox.Show("Couldn't find this user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlUserCard1.LoadUserInfo(_userID);
        }
    }
}
