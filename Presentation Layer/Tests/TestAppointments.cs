using Business_Layer;
using Presentation_Layer.Properties;
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
    public partial class TestAppointments: Form
    {
        DataTable _dtLicenseTestAppointments;
        int _localDrivingLicenseApplicationID;
        TestType.en_TestType testType = TestType.en_TestType.VisionTest;
        public TestAppointments(int localDrivingLicenseApplicationID , TestType.en_TestType testType)
        {
            InitializeComponent();

            this._localDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.testType = testType;

            ctrlLocalDrivingLicenseApplicationInfo1.LoadLocalDrivingLicenseApplicationInfo(localDrivingLicenseApplicationID);
        }

        private void TestAppointments_Load(object sender, EventArgs e)
        {
            _AddVisionImageAndTitle();

            ctrlLocalDrivingLicenseApplicationInfo1.LoadLocalDrivingLicenseApplicationInfo(_localDrivingLicenseApplicationID);
            _dtLicenseTestAppointments = TestAppointment.GetAllTestAppointmentsPerTestType(_localDrivingLicenseApplicationID, testType);
            dgvTestAppointmentsList.DataSource = _dtLicenseTestAppointments;

            if (dgvTestAppointmentsList.Rows.Count > 0)
            {
                dgvTestAppointmentsList.Columns[0].HeaderText = "Appointment ID";
                dgvTestAppointmentsList.Columns[0].Width = 150;

                dgvTestAppointmentsList.Columns[1].HeaderText = "Appointment Date";
                dgvTestAppointmentsList.Columns[1].Width = 150;

                dgvTestAppointmentsList.Columns[2].HeaderText = "Paid Fees";
                dgvTestAppointmentsList.Columns[2].Width = 120;

                dgvTestAppointmentsList.Columns[3].HeaderText = "Is Locked";
                dgvTestAppointmentsList.Columns[3].Width = 120;
            }

            lblRecordsCount.Text = dgvTestAppointmentsList.Rows.Count.ToString();

        }
        private void _AddVisionImageAndTitle()
        {
            switch (this.testType)
            {
                case TestType.en_TestType.VisionTest:
                    pbTestTypeImag.Image = Resources.Vision_512;
                    lblTitle.Text = "Vision Test Appointments";
                    break;
                case TestType.en_TestType.WrittenTest:
                    pbTestTypeImag.Image = Resources.Written_Test_512;
                    lblTitle.Text = "Written Test Appointments";
                    break;
                case TestType.en_TestType.PracticalTest:
                    pbTestTypeImag.Image = Resources.driving_test_512;
                    lblTitle.Text = "Practical Test Appointments";
                    break;
            }
        }
        private void btnAddTestAppointment_Click(object sender, EventArgs e)
        {
            if (LocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_localDrivingLicenseApplicationID , (int)testType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LocalDrivingLicenseApplication.DoesPassTestType(_localDrivingLicenseApplicationID , testType))
            {
                MessageBox.Show("Person Already pass in this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ScheduleTest frm = new ScheduleTest(_localDrivingLicenseApplicationID , testType);
            frm.ShowDialog();

            TestAppointments_Load(null, null);
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            ScheduleTest frm = new ScheduleTest(_localDrivingLicenseApplicationID , testType, (int)dgvTestAppointmentsList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            TestAppointments_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiTakeTest_Click(object sender, EventArgs e)
        {
            TakeTest frm = new TakeTest((int)dgvTestAppointmentsList.CurrentRow.Cells[0].Value, testType);
            frm.ShowDialog();

            TestAppointments_Load(null, null);
        }

        private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            tsmiEdit.Enabled = tsmiTakeTest.Enabled = !TestAppointment.FindTestAppointment((int)dgvTestAppointmentsList.CurrentRow.Cells[0].Value).IsLocked;
        }
    }
}
