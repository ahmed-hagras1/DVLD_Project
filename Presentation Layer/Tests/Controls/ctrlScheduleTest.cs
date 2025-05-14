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

namespace Presentation_Layer
{
    public partial class ctrlScheduleTest: UserControl
    {
        enum enMode { UpdateMode =0 , AddNewMode =1}
        enMode _Mode = enMode.UpdateMode;

        enum enCreationMode { FirstTimeSchedule = 0 , RetakeTestSchedule = 1 }
        enCreationMode _creationMode = enCreationMode.FirstTimeSchedule;

        int _testAppointmentID = -1;
        TestAppointment _testAppointment;

        int _localDrivingLicenseAppID = -1;
        LocalDrivingLicenseApplication _localDrivingLicenseApp;

        TestType.en_TestType _testType = TestType.en_TestType.VisionTest;
        float totalFees = 0;

        public TestType.en_TestType testType
        {
            get { return _testType; }

            set
            {
                _testType = value;

                switch (_testType)
                {
                    case TestType.en_TestType.VisionTest:
                        pbTestImage.Image = Resources.Vision_512;
                        gbTestType.Text = "Schedule Test";
                        break;
                    case TestType.en_TestType.WrittenTest:
                        pbTestImage.Image = Resources.Written_Test_512;
                        gbTestType.Text = "Schedule Test";
                        break;
                    case TestType.en_TestType.PracticalTest:
                        pbTestImage.Image = Resources.driving_test_512;
                        gbTestType.Text = "Schedule Test";
                        break;
                }

            }
        }
        
        public ctrlScheduleTest()
        {
            InitializeComponent();
        }

        private void ctrlScheduledTest_Load(object sender, EventArgs e)
        {

        }

        public void LoadInfo(int localDrivingLicenseAppID, int appointmentID = -1)
        {

            if (appointmentID == -1)
                _Mode = enMode.AddNewMode;
            else
                _Mode = enMode.UpdateMode;

            _localDrivingLicenseAppID = localDrivingLicenseAppID;
            _localDrivingLicenseApp = LocalDrivingLicenseApplication.FindLocalDrivingLicenseApplication(_localDrivingLicenseAppID);
            _testAppointmentID = appointmentID;

            if(_localDrivingLicenseApp == null)
            {
                MessageBox.Show($"Error: No local driving license app with ID = {_localDrivingLicenseAppID}","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            // if person first time schedule test then creationMode will be firstTime else creationMode will be retake test.
            if (!_localDrivingLicenseApp.DoesAttendTestType(_testType))
                _creationMode = enCreationMode.FirstTimeSchedule;
            else
                _creationMode = enCreationMode.RetakeTestSchedule;

            lblDLAppID.Text = _localDrivingLicenseAppID.ToString();
            lblDLClass.Text = _localDrivingLicenseApp.licenseClassInfo.ClassName;
            lblName.Text = _localDrivingLicenseApp.FullName;
            lblTrial.Text = _localDrivingLicenseApp.TotalTrialsPerTest(_testType).ToString();
           

            if (_creationMode == enCreationMode.FirstTimeSchedule)
            {
                lblScheduleTestTitle.Text = "Schedule Test";

                lblRAppFees.Text = "0";
                lblRTestAppID.Text = "N/A";
                gbRetakeTestInfo.Enabled = false;
            }
            else
            {
                lblScheduleTestTitle.Text = "Retake Schedule Test";

                lblRAppFees.Text = ApplicationType.FindApplicationTypeByID((int)clsApplication.enApplicationType.RetakeTest).applicationTypeFees.ToString();
                lblRTestAppID.Text = "0";
                gbRetakeTestInfo.Enabled = true;
            }

            if (_Mode == enMode.AddNewMode)
            {
                lblFees.Text = TestType.FindTestTypeByID(_testType).testTypeFees.ToString();
                dtpDate.Value = dtpDate.MinDate = DateTime.Now;
                _testAppointment = new TestAppointment();
            }
            else
            {
               if(!_LoadTestAppointmentData())
                    return;
            }

            totalFees = Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRAppFees.Text);
            lblTotalFees.Text = totalFees.ToString();

            if (!_HandelActiveTestAppointment())
                return;

            if(!_HandleAppointmentLockedConstraint())
                return;

            if (!_HandlePreviousTestConstraint())
                return;

        }
        private bool _LoadTestAppointmentData()
        {
            _testAppointment = TestAppointment.FindTestAppointment(_testAppointmentID);

            if(_testAppointment == null)
            {
                MessageBox.Show($"Error: No appointment with ID: {_testAppointmentID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                dtpDate.Enabled = false;
                return false;
            }

            lblFees.Text = _testAppointment.PaidFees.ToString();

            // We compare the current date with the appointment data to set the min date.
            if (DateTime.Compare(DateTime.Now, _testAppointment.AppointmentDate) < 0)
                // current date is min if current date is earlier than appointment date.
                dtpDate.MinDate = DateTime.Now;
            else
                // Appointment date is min if appointment date is earlier than current date.
                dtpDate.MinDate = _testAppointment.AppointmentDate;


            dtpDate.Value = _testAppointment.AppointmentDate;

            if(_testAppointment.RetakeTestAppID == -1)
            {
                gbRetakeTestInfo.Enabled = false;
                lblRAppFees.Text = "0";
                lblRTestAppID.Text = "N/A";

            }
            else
            {
                gbRetakeTestInfo.Enabled = true;
                lblRAppFees.Text = _testAppointment.PaidFees.ToString();
                lblRTestAppID.Text = _testAppointment.RetakeTestAppID.ToString();
                lblScheduleTestTitle.Text = "Retake Schedule Test";
            }

            return true;

        }
        private bool _HandelActiveTestAppointment()
        {
            if (_Mode == enMode.AddNewMode && LocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_localDrivingLicenseAppID, (int)_testType))
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person already has an active scheduled test.";
                dtpDate.Enabled = false;
                btnSave.Enabled = false;
                return false;
            }

            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            // Check if the test appointment is locked 
            // if appointment is locked user can't update the appointment.
            if (_testAppointment.IsLocked)
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Test appointment is locked. Cannot be updated.";
                dtpDate.Enabled = false;
                btnSave.Enabled = false;
                return false;
            }
            else 
                lblUserMessage.Visible = false;

            return true;
        }
        private bool _HandlePreviousTestConstraint()
        {
            switch (_testType)
            {
                case TestType.en_TestType.VisionTest:
                    lblUserMessage.Visible = false;
                    return true;
                    break;
                case TestType.en_TestType.WrittenTest:
                    if (!_localDrivingLicenseApp.DoesPassTestType(TestType.en_TestType.VisionTest))
                    {
                        lblUserMessage.Visible = true;
                        lblUserMessage.Text = "Cannot schedule, vision test should be passed first";
                        dtpDate.Enabled = false;
                        btnSave.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        dtpDate.Enabled = true;
                        btnSave.Enabled = true;
                        return true;
                    }
                        break;
                case TestType.en_TestType.PracticalTest:
                    if (!_localDrivingLicenseApp.DoesPassTestType(TestType.en_TestType.WrittenTest))
                    {
                        lblUserMessage.Visible = true;
                        lblUserMessage.Text = "Cannot schedule, Written test should be passed first";
                        dtpDate.Enabled = false;
                        btnSave.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        dtpDate.Enabled = true;
                        btnSave.Enabled = true;
                        return true;
                    }
                    break;
                default:
                    return true;
                    break;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!_HandleRetakeTestApplication())
                return;

            _testAppointment.TestTypeID = _testType;
            _testAppointment.LocalDrivingLicenseApplicationID = _localDrivingLicenseAppID;
            _testAppointment.AppointmentDate = dtpDate.Value;
            _testAppointment.PaidFees = Convert.ToSingle(lblFees.Text);
            _testAppointment.CreatedByUserID = SaveLoginInfo.currentUser.userID;

            if (_testAppointment.Save())
            {
                MessageBox.Show("Data saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblRTestAppID.Text = _testAppointment.TestAppointmentID.ToString();
                _Mode = enMode.UpdateMode;
                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error: Data is not saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool _HandleRetakeTestApplication()
        {
            if(_Mode == enMode.AddNewMode && _creationMode == enCreationMode.RetakeTestSchedule)
            {
                clsApplication application = new clsApplication();

                application.ApplicantPersonID = _localDrivingLicenseApp.ApplicantPersonID;
                application.ApplicationDate = DateTime.Now;
                application.ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                application.ApplicationStatus = clsApplication.enStatus.Completed;
                application.LastStatusDate = DateTime.Now;
                application.PaidFees = ApplicationType.FindApplicationTypeByID((int)clsApplication.enApplicationType.RetakeTest).applicationTypeFees;
                application.CreatedByUserID = SaveLoginInfo.currentUser.userID;

                if (!application.Save())
                {
                    _testAppointment.RetakeTestAppID = -1;
                    MessageBox.Show("Failed to create application.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _testAppointment.RetakeTestAppID = application.ApplicationID;
            }

            _testAppointment.RetakeTestAppID = -1;
            return true;
        }
    }
}
