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
    public partial class AddAndUpdateLocalDrivingLicense: Form
    {
        enum enMode { UpdateMode = 0, AddNewMode = 1 };
        enMode Mode = enMode.AddNewMode;

        int localDrivingLicenseApplicationID = -1;
        int selectedPersonID = -1;
        LocalDrivingLicenseApplication localDrivingLicenseApplication;
        
        public AddAndUpdateLocalDrivingLicense()
        {
            InitializeComponent();

            Mode = enMode.AddNewMode;

            localDrivingLicenseApplication = new LocalDrivingLicenseApplication();
           
        }
        public AddAndUpdateLocalDrivingLicense(int localDrivingLicenseApplicationID)
        {
            InitializeComponent();

            this.localDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            
            Mode = enMode.UpdateMode;

            localDrivingLicenseApplication = LocalDrivingLicenseApplication.FindLocalDrivingLicenseApplication(localDrivingLicenseApplicationID);
            selectedPersonID = localDrivingLicenseApplication.ApplicantPersonID;
        }
        private void _FillLicenseClassesInComboBox()
        {
            DataTable licenseClasses = LicenseClass.GetAllLicenseClasses();

            foreach (DataRow row in licenseClasses.Rows)
            {
                cbLicenseClasses.Items.Add(row["ClassName"]);
            }

        }
        private void _ResetDefaultData()
        {
            _FillLicenseClassesInComboBox();

            if(Mode == enMode.AddNewMode)
            {
                lblTitle.Text = "New local driving license application";
                this.Text = "New local driving license application";
                lblDate.Text = DateTime.Now.ToShortDateString();
                cbLicenseClasses.SelectedIndex = 2;
                lblFees.Text = ApplicationType.FindApplicationTypeByID((int)clsApplication.enApplicationType.NewLocalDrivingLicenseService).applicationTypeFees.ToString();
                lblUsername.Text = SaveLoginInfo.currentUser.username;

                btnSave.Enabled = btnNext.Enabled = tpApplicationInfo.Enabled = false;

            }
            else
            {
                lblTitle.Text = "Update local driving license application";
                this.Text = "Update local driving license application";

                btnSave.Enabled = btnNext.Enabled = tpApplicationInfo.Enabled = true;
            }

        }
        
        private void _LoadData()
        {
            ctrlPersonCardWithFilter1.filterEnabled = false;

            if (localDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + localDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ctrlPersonCardWithFilter1.LoadSelectedPersonInfo(selectedPersonID);

            lblID.Text = localDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDate.Text = clsApplication.FindApplication(localDrivingLicenseApplication.ApplicationID).ApplicationDate.ToShortDateString();
            cbLicenseClasses.SelectedIndex = cbLicenseClasses.FindString(LicenseClass.FindLicenseClass(localDrivingLicenseApplication.LicenseClassID).ClassName);
            lblFees.Text = ApplicationType.FindApplicationTypeByID
                (clsApplication.FindApplication(localDrivingLicenseApplication.ApplicationID).ApplicationTypeID).applicationTypeFees.ToString();
            lblUsername.Text = User.FindUserByUserID(clsApplication.FindApplication(localDrivingLicenseApplication.ApplicationID).CreatedByUserID).username;
        }
        private void AddAndUpdateLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            _ResetDefaultData();

            if (Mode == enMode.UpdateMode)
                _LoadData();
        }

        private void ctrlPersonCardWithFilter1_onPersonSelected(int obj)
        {
            btnSave.Enabled = btnNext.Enabled = tpApplicationInfo.Enabled = true;
            selectedPersonID = obj;
        }

        private void DataBackEvent(object sender , int personID)
        {
            selectedPersonID = personID;
            ctrlPersonCardWithFilter1.LoadSelectedPersonInfo(selectedPersonID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            int licenseClassID = LicenseClass.FindLicenseClass(cbLicenseClasses.Text).LicenseClassID;

            int activeApplicationID = clsApplication.GetActiveApplicationForLicenseClass(selectedPersonID, clsApplication.enApplicationType.NewLocalDrivingLicenseService, licenseClassID);
           
            // Person already have an active application from selected license class.
            if (activeApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + activeApplicationID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClasses.Focus();
                return;
            }

            if(clsLicense.IsLicenseExistByPersonID(selectedPersonID , licenseClassID))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose different driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

                ctrlPersonCardWithFilter1.filterEnabled = true;

            localDrivingLicenseApplication.ApplicantPersonID = selectedPersonID;
            localDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            localDrivingLicenseApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.NewLocalDrivingLicenseService;
            localDrivingLicenseApplication.ApplicationStatus = clsApplication.enStatus.New;
            localDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            localDrivingLicenseApplication.PaidFees = ApplicationType.FindApplicationTypeByID((int)clsApplication.enApplicationType.NewLocalDrivingLicenseService).applicationTypeFees;
            localDrivingLicenseApplication.CreatedByUserID = SaveLoginInfo.currentUser.userID;

            localDrivingLicenseApplication.LicenseClassID = licenseClassID;

            if (localDrivingLicenseApplication.Save())
            {
                lblID.Text = localDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();

                Mode = enMode.UpdateMode;
                lblTitle.Text = "Update local driving license application";

                MessageBox.Show("Data saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data is not saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (ctrlPersonCardWithFilter1.personID == -1)
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tabControl1.SelectedIndex = 1;
        }
    }
}
