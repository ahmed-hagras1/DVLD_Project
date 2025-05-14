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
    public partial class TakeTest: Form
    {
        int _testAppointmentID;
        TestAppointment _testAppointment;
        Test _test;
        TestType.en_TestType _testType;
        public TakeTest(int testAppointmentID, TestType.en_TestType testType)
        {
            InitializeComponent();
            _testAppointmentID = testAppointmentID;
            _testType = testType;
        }

        private void TakeTest_Load(object sender, EventArgs e)
        {
            ctrlScheduledTest1.LoadInfo(_testAppointmentID);
            ctrlScheduledTest1.TestType = _testType;

            if (ctrlScheduledTest1.testAppointmentID == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;

            int testID = ctrlScheduledTest1.TestID;
            if(testID != -1)
            {
                _test = Test.FindTest(testID);

                if (_test.testResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;

                lblUserMessage.Visible = true;
                rbFail.Enabled = rbPass.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to take the test? After that you cannot change the pass/fail results after you save.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _testAppointment = TestAppointment.FindTestAppointment(_testAppointmentID);

            if (_testAppointment == null)
            {
                MessageBox.Show("Error: Test appointment is not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _test = new Test();

            _test.testAppointmentID = _testAppointmentID;
            _test.testResult = rbPass.Checked;
            _test.notes = txtNotes.Text.Trim();
            _test.createdByUserID = SaveLoginInfo.currentUser.userID;

            if (_test.Save())
            {
                MessageBox.Show("Test taken successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error: Test taken failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
