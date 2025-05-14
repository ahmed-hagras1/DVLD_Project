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
    public partial class ctrlScheduledTest: UserControl
    {
        int _testAppointmentID;
        TestAppointment _testAppointment;

        int _testID;

        int _localDrivingLicenseAppID;
        LocalDrivingLicenseApplication _localDrivingLicenseApplication;
        TestType.en_TestType _testType;

        
        public TestType.en_TestType TestType
        {
            set
            {
                _testType = value;

                switch (_testType)
                {
                    case Business_Layer.TestType.en_TestType.VisionTest:
                        pbTestImage.Image = Resources.Vision_512;
                        gbTestType.Text = "Schedule Test";
                        break;
                    case Business_Layer.TestType.en_TestType.WrittenTest:
                        pbTestImage.Image = Resources.Written_Test_512;
                        gbTestType.Text = "Schedule Test";
                        break;
                    case Business_Layer.TestType.en_TestType.PracticalTest:
                        pbTestImage.Image = Resources.Street_Test_32;
                        gbTestType.Text = "Schedule Test";
                        break;
                }
            }
            get
            {
                return _testType;
            }
        }
        public int testAppointmentID
        {
            get
            {
                return _testAppointmentID;
            }
        }
        public int TestID
        {
            get
            {
                return _testID;
            }
        }
        public ctrlScheduledTest( )
        {
            InitializeComponent();
        }

        private void ScheduledTest_Load(object sender, EventArgs e)
        {

        }


        public void LoadInfo(int testAppointmentID )
        {

            _testAppointmentID = testAppointmentID;
            _testAppointment = TestAppointment.FindTestAppointment(_testAppointmentID);

            if(_testAppointment == null)
            {
                MessageBox.Show("Error: Appointment is not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _testAppointmentID = -1;
                return;
            }

            _testID = _testAppointment.testID;

            _localDrivingLicenseAppID = _testAppointment.LocalDrivingLicenseApplicationID;
            _localDrivingLicenseApplication = LocalDrivingLicenseApplication.FindLocalDrivingLicenseApplication(_localDrivingLicenseAppID);

            if(_localDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: Local driving license app is not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblDLAppID.Text = _localDrivingLicenseAppID.ToString();
            lblDLClass.Text = _localDrivingLicenseApplication.LicenseClassName;
            lblName.Text = _localDrivingLicenseApplication.FullName;
            lblTrial.Text = _localDrivingLicenseApplication.TotalTrialsPerTest(_testType).ToString();

            lblDate.Text = _testAppointment.AppointmentDate.ToShortDateString();
            lblFees.Text = _testAppointment.PaidFees.ToString();
            lblTestID.Text = (_testAppointment.testID == -1) ? "Not taken yet" : _testAppointment.testID.ToString();

        }
    }
}
