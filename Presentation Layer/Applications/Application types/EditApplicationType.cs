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
    public partial class EditApplicationType: Form
    {
        int applicationTypeID = 0;
        ApplicationType applicationType;

        public EditApplicationType(int applicationTypeID)
        {
            InitializeComponent();
            this.applicationTypeID = applicationTypeID;
            this.applicationType = ApplicationType.FindApplicationTypeByID(applicationTypeID);
        }

        private void EditApplicationType_Load(object sender, EventArgs e)
        {
            if (applicationType == null)
            {
                MessageBox.Show("Application type not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblApplicationTypeID.Text = applicationType.applicationTypeID.ToString();
            txtApplicationTitle.Text = applicationType.applicationTypeTitle;
            txtApplicationFees.Text = applicationType.applicationTypeFees.ToString();
        }

        delegate bool ValidateTextBoxes(ref string errorMessage, string text);

        private bool ValidateTitle(ref string errorMessage , string text )
        {
            if (string.IsNullOrEmpty(text))
                errorMessage = "It should have value";

            return !(string.IsNullOrEmpty(errorMessage));
        }
        private bool ValidateFees(ref string errorMessage, string text)
        {
            if (string.IsNullOrEmpty(text))
                errorMessage = "It should have value";
           
            return !(string.IsNullOrEmpty(errorMessage));
        }
        private void Validate(object sender , CancelEventArgs e , ValidateTextBoxes validateTextBoxes)
        {
            TextBox textBox = (TextBox)sender;
            string errorMessage = "";

            if (validateTextBoxes(ref errorMessage, textBox.Text))
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
        private void txtApplicationTitle_Validating(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidateTitle);
        }

        private void txtApplicationFees_Validating(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidateFees);
        }
        private void txtApplicationFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Suppress the input
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            applicationType.applicationTypeFees = Convert.ToSingle(txtApplicationFees.Text);
            applicationType.applicationTypeTitle = txtApplicationTitle.Text.Trim();

            if (applicationType.Save())
            {
                MessageBox.Show("The application type has been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save the application type. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
