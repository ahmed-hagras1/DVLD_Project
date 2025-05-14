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
    public partial class UpdateTestType: Form
    {

        TestType testType = null;

        TestType.en_TestType testTypeID { get; set; }

        public UpdateTestType(TestType.en_TestType testTypeID)
        {
            InitializeComponent();

            this.testTypeID = testTypeID;
        }

        private void _LoadTestTypeInfo()
        {

            testType = TestType.FindTestTypeByID(this.testTypeID);

            if (testType == null) {
                MessageBox.Show("Test type not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblTestTypeID.Text = testType.testTypeID.ToString();
            txtTestTitle.Text = testType.testTypeTitle;
            txtTestTypeDescription.Text = testType.testTypeDescription;
            txtTestFees.Text = testType.testTypeFees.ToString();

        }
        private void UpdateTestType_Load(object sender, EventArgs e)
        {
            _LoadTestTypeInfo();
        }

        private void txtTestFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Suppress the input
            }
        }

        delegate bool ValidateTextBoxes(ref string errorMessage, string text);

        private bool ValidateTitle(ref string errorMessage, string text)
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
        private bool ValidateDescription(ref string errorMessage ,string text)
        {
            if (string.IsNullOrEmpty(text))
                errorMessage = "It should have value";

            return !(string.IsNullOrEmpty(errorMessage));
        }
        private void Validate(object sender, CancelEventArgs e, ValidateTextBoxes validateTextBoxes)
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
        private void ValidatingTitle (object sender , CancelEventArgs e)
        {
            Validate(sender, e, ValidateTitle);
        }
        private void ValidatingFees(object sender , CancelEventArgs e ) 
        {
            Validate(sender, e, ValidateFees);
        }
        private void ValidatingDescription(object sender , CancelEventArgs e)
        {
            Validate(sender, e, ValidateDescription);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            testType.testTypeTitle = txtTestTitle.Text.Trim();
            testType.testTypeDescription = txtTestTypeDescription.Text.Trim();
            testType.testTypeFees = Convert.ToSingle(txtTestFees.Text.Trim());

            if (testType.Save())
            {
                MessageBox.Show("The test type has been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save the test type. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
