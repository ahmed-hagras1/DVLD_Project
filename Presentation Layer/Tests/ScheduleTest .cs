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
    public partial class ScheduleTest: Form
    {
        int _localDrivingLicenseAppID = -1;
        int _testAppointmentID = -1;
        TestType.en_TestType _testType;
        public ScheduleTest(int localDrivingLicenseAppID , TestType.en_TestType testType ,int  testAppointment = -1)
        {
            InitializeComponent();
            _localDrivingLicenseAppID = localDrivingLicenseAppID;
            _testAppointmentID = testAppointment;
            _testType = testType;
        }
        private void ScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.testType = _testType;
            ctrlScheduleTest1.LoadInfo(_localDrivingLicenseAppID, _testAppointmentID);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
