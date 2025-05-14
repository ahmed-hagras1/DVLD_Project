using Business_Layer;
using Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Presentation_Layer
{
    public partial class LocalDrivingLicenseApplicationsList: Form
    {
        public LocalDrivingLicenseApplicationsList()
        {
            InitializeComponent();
        }

        // this is not best solution the best solution like what you made in people list. :-)
        private void _ResetLocalDrivingLicenseApplicationList(DataView localDrivingLicenseApplicationsView)
        {
            dgvLDLApps.DataSource = localDrivingLicenseApplicationsView;

            dgvLDLApps.Columns[0].HeaderText = "L.D.LAppID";
            dgvLDLApps.Columns[0].Width = 80;

            dgvLDLApps.Columns[1].HeaderText = "Class Name";
            dgvLDLApps.Columns[1].Width = 200;

            dgvLDLApps.Columns[2].HeaderText = "National No";
            dgvLDLApps.Columns[2].Width = 100;

            dgvLDLApps.Columns[3].HeaderText = "Full Name";
            dgvLDLApps.Columns[3].Width = 250;

            dgvLDLApps.Columns[4].HeaderText = "Application Date";
            dgvLDLApps.Columns[4].Width = 150;

            dgvLDLApps.Columns[5].HeaderText = "Passed Test Count";
            dgvLDLApps.Columns[5].Width = 150;

            dgvLDLApps.Columns[6].HeaderText = "Status";
            dgvLDLApps.Columns[6].Width = 100;

            _ResetRecordsCount();
        }
        private void _ResetRecordsCount ()
        {
            lblRecordsCount.Text = $"#  Records:  {dgvLDLApps.Rows.Count}";
        }
        private void LocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;

            txtFilterBy.Visible = cbStatus.Visible = false;

            _ResetLocalDrivingLicenseApplicationList(LocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications().DefaultView);
        }

        private string _GetFilterColumn()
        {
            string filterColumn;

            switch (cbFilterBy.Text)
            {
                case ("None"):
                    filterColumn = "None";
                    break;
                case ("L.D.LAppID"):
                    filterColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case ("National No"):
                    filterColumn = "NationalNo";
                    break;
                case ("Full Name"):
                    filterColumn = "FullName";
                    break;
                case ("Status"):
                    filterColumn = "Status";
                    break;
                default:
                    filterColumn = "None";
                    break;
            }

            return filterColumn;
        }

        private DataView _GetViewAfterFiltered()
        {
            DataView localDrivingLicenseApplicationView =  LocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications().DefaultView;
            string filterColumn = _GetFilterColumn();

            if (filterColumn == "None")
            {
                txtFilterBy.Clear();
                cbStatus.SelectedIndex = 0;
                txtFilterBy.Visible = cbStatus.Visible = false;

                return localDrivingLicenseApplicationView;
            }
            else if (filterColumn == "Status")
            {
                txtFilterBy.Visible = false;
                cbStatus.Visible = true;


                if (cbStatus.SelectedIndex == cbStatus.FindString("All"))
                {
                    return localDrivingLicenseApplicationView;
                }
                else 
                {
                    localDrivingLicenseApplicationView.RowFilter = filterColumn + " like '" +  cbStatus.Text + "%'";
                    return localDrivingLicenseApplicationView;
                }
               
            }
            else if(filterColumn == "LocalDrivingLicenseApplicationID")
            {
                txtFilterBy.Visible = true;
                cbStatus.Visible = false;

                if (string.IsNullOrEmpty(txtFilterBy.Text))
                {
                    return localDrivingLicenseApplicationView;
                }

                localDrivingLicenseApplicationView.RowFilter = filterColumn + " = " + txtFilterBy.Text.Trim();
                return localDrivingLicenseApplicationView;
            }
            else
            {
                txtFilterBy.Visible = true;
                cbStatus.Visible = false;

                localDrivingLicenseApplicationView.RowFilter = filterColumn + " like '" + txtFilterBy.Text.Trim() + "%'";
                return localDrivingLicenseApplicationView;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ResetLocalDrivingLicenseApplicationList(_GetViewAfterFiltered());

            txtFilterBy.Clear();
            cbStatus.SelectedIndex = 0;
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            _ResetLocalDrivingLicenseApplicationList(_GetViewAfterFiltered());
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ResetLocalDrivingLicenseApplicationList(_GetViewAfterFiltered());
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (_GetFilterColumn() != "LocalDrivingLicenseApplicationID")
                return;

            // Allow digits (0-9), backspace, and delete
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Suppress the key press if it's not a digit or control key
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewLDLAppClick(object sender, EventArgs e)
        {
            AddAndUpdateLocalDrivingLicense frm = new AddAndUpdateLocalDrivingLicense();
            frm.ShowDialog();
            _ResetLocalDrivingLicenseApplicationList(LocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications().DefaultView);
        }

        private void EditApplicationClick(object sender, EventArgs e)
        {
            LocalDrivingLicenseApplication localDrivingLicenseApplication = LocalDrivingLicenseApplication.FindLocalDrivingLicenseApplication((int)dgvLDLApps.CurrentRow.Cells[0].Value);

            if (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enStatus.Cancelled)
            {
                MessageBox.Show("Error: You can't update cancelled applications.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enStatus.Completed)
            {
                MessageBox.Show("Error: You can't update completed applications.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AddAndUpdateLocalDrivingLicense frm = new AddAndUpdateLocalDrivingLicense(localDrivingLicenseApplication.LocalDrivingLicenseApplicationID);
            frm.ShowDialog();

            _ResetLocalDrivingLicenseApplicationList(LocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications().DefaultView);
        }

        private void DeleteApplicationClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question , MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (LocalDrivingLicenseApplication.DeleteLocalDrivingLicenseApplication((int)dgvLDLApps.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Application Deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _ResetLocalDrivingLicenseApplicationList(LocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications().DefaultView);
                }
                else
                {
                    MessageBox.Show("Could not delete application, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
               
        }

        private void CancelApplicationClick(object sender, EventArgs e)
        {
            LocalDrivingLicenseApplication localDrivingLicenseApplication = LocalDrivingLicenseApplication.FindLocalDrivingLicenseApplication((int)dgvLDLApps.CurrentRow.Cells[0].Value);

            if (MessageBox.Show("Are you sure do want to Cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                
                if (localDrivingLicenseApplication.CancelApplication())
                {
                    MessageBox.Show("Application Cancelled successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _ResetLocalDrivingLicenseApplicationList(LocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications().DefaultView);
                }
                else
                {
                    MessageBox.Show("Could not Cancel application, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            LocalDrivingLicenseApplication localDrivingLicenseApplication =
                LocalDrivingLicenseApplication.FindLocalDrivingLicenseApplication((int)dgvLDLApps.CurrentRow.Cells[0].Value);

            int totalPassedTests = (int)dgvLDLApps.CurrentRow.Cells[5].Value;
            bool isLicenseExist = localDrivingLicenseApplication.IsLicenseIssued();

            tsmiShowLicense.Enabled = isLicenseExist;

            if (totalPassedTests == 0)
            {
                tsmiSechduleVisionTest.Enabled = true;
                tsmiSechduleWrittenTest.Enabled = tsmiSechduleStreetTest.Enabled = false;
            }
            else if (totalPassedTests == 1)
            {
                tsmiSechduleWrittenTest.Enabled = true;
                tsmiSechduleVisionTest.Enabled = tsmiSechduleStreetTest.Enabled = false;
            }
            else if (totalPassedTests == 2)
            {
                tsmiSechduleStreetTest.Enabled = true;
                tsmiSechduleVisionTest.Enabled = tsmiSechduleWrittenTest.Enabled = false;
            }
            else
            {
                tsmiIssueDrivingLicense.Enabled = true;
              tsmiSechduleVisionTest.Enabled =tsmiSechduleWrittenTest.Enabled = tsmiSechduleStreetTest.Enabled = false;
            }

            if (totalPassedTests != 3 )
                tsmiIssueDrivingLicense.Enabled = false;


            // You can edit application when license is not exist and application status is new.
            tsmiEditApplication.Enabled = !isLicenseExist && (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enStatus.New);

            // You can cancel or delete application when application status is new only.
            tsmiCancleApplication.Enabled = tsmiDeleteApplication.Enabled = (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enStatus.New);

            if(totalPassedTests == 3)
                tsmiIssueDrivingLicense.Enabled = !isLicenseExist;

            if(localDrivingLicenseApplication.ApplicationStatus == clsApplication.enStatus.Cancelled)
                tsmiSechduleVisionTest.Enabled = tsmiSechduleWrittenTest.Enabled = tsmiSechduleStreetTest.Enabled = false;

        }
        private void AddScheduleTest(TestType.en_TestType testType)
        {
            TestAppointments frm = new TestAppointments((int)dgvLDLApps.CurrentRow.Cells[0].Value , testType);
            frm.ShowDialog();

            _ResetLocalDrivingLicenseApplicationList(LocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications().DefaultView);
        }
        private void tsmiScheduleVisionTest_Click(object sender, EventArgs e)
        {
            AddScheduleTest(TestType.en_TestType.VisionTest);
        }

        private void tsmiScheduleWrittenTest_Click(object sender, EventArgs e)
        {
            AddScheduleTest(TestType.en_TestType.WrittenTest);
        }

        private void tsmiScheduleStreetTest_Click(object sender, EventArgs e)
        {
            AddScheduleTest(TestType.en_TestType.PracticalTest);
        }

        private void tsmiSechduleTests_Click(object sender, EventArgs e)
        {

        }

        private void tsmiIssueDrivingLicense_Click(object sender, EventArgs e)
        {
            IssueLicense frm = new IssueLicense((int)dgvLDLApps.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            // Refresh list.
            LocalDrivingLicenseApplications_Load(null, null);
        }

        private void tsmiShowLicense_Click(object sender, EventArgs e)
        {
            ShowLicenseInfo frm = new ShowLicenseInfo(LocalDrivingLicenseApplication.FindLocalDrivingLicenseApplication
                ((int)dgvLDLApps.CurrentRow.Cells[0].Value).GetActiveLicenseID());
            frm.ShowDialog();
        }

        private void tsmiShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            int personID = LocalDrivingLicenseApplication.FindLocalDrivingLicenseApplication
                ((int)dgvLDLApps.CurrentRow.Cells[0].Value).ApplicantPersonID;

            if (Driver.FindDriverByPersonID(personID) == null)
            {
                MessageBox.Show("Person not have any licenses yet !", "Not Allow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ShowPersonLicenseHistory frm = new ShowPersonLicenseHistory(personID);
            frm.ShowDialog();
        }

        private void tsmiApplicationDetails_Click(object sender, EventArgs e)
        {
            ShowLocalDrivingLicenseApplicationInfo frm = new ShowLocalDrivingLicenseApplicationInfo((int)dgvLDLApps.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            // Refresh list.
            LocalDrivingLicenseApplications_Load(null, null);
        }
    }
}
