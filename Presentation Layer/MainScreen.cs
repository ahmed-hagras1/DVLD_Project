using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Presentation_Layer
{
    public partial class MainScreen: Form
    {
        frmLoginForm _loginForm;
        public MainScreen(frmLoginForm loginForm)
        {
            InitializeComponent();
            _loginForm = loginForm;
        }

        private void tsmiPeople_Click(object sender, EventArgs e)
        {
            Form frm = new frmPeople();
            frm.ShowDialog();
        }

        private void tsmiDrivers_Click(object sender, EventArgs e)
        {
            ShowDriversList frm = new ShowDriversList();
            frm.ShowDialog();
        }

        private void tsmiUsers_Click(object sender, EventArgs e)
        {
            UsersList frm = new UsersList();
            frm.ShowDialog();
        }

        private void tsmiSignOut_Click(object sender, EventArgs e)
        {
            // delete saved login info.
            SaveLoginInfo.RememberLoginInfo("", "");
            this.Close();
            _loginForm.Show();
        }

        private void tsmiCurrentUserInfo_Click(object sender, EventArgs e)
        {
            UserInfo frm = new UserInfo(SaveLoginInfo.currentUser.userID);
            frm.ShowDialog();
        }

        private void tsmiChangePassword_Click(object sender, EventArgs e)
        {
            ChangeUserPassword frm = new ChangeUserPassword(SaveLoginInfo.currentUser.userID);
            frm.ShowDialog();
        }

        private void tsmiManageApplications_Click(object sender, EventArgs e)
        {

        }

        private void tsmiManageApplicationTypes_Click(object sender, EventArgs e)
        {
            ListApplicationTypes frm = new ListApplicationTypes();
            frm.ShowDialog();
        }

        private void tsmiManageTestTypes_Click(object sender, EventArgs e)
        {
            ManageTestTypes frm = new ManageTestTypes();
            frm.ShowDialog();
        }

        private void tsmiLocalLicense_Click(object sender, EventArgs e)
        {
            AddAndUpdateLocalDrivingLicense frm = new AddAndUpdateLocalDrivingLicense();
            frm.ShowDialog();
        }

        private void tsmiLocalDrivingLicenseApplications_Click(object sender, EventArgs e)
        {
            LocalDrivingLicenseApplicationsList frm = new LocalDrivingLicenseApplicationsList();
            frm.ShowDialog();
        }

        private void tsmiInternationalLicense_Click(object sender, EventArgs e)
        {
            InternationalLicenseApplication frm = new InternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void tsmiInternationalLicenseApplications_Click(object sender, EventArgs e)
        {
            InternationalLicenseApplicationsList frm = new InternationalLicenseApplicationsList();
            frm.ShowDialog();
        }

        private void tsmiRenewDrivingLicense_Click(object sender, EventArgs e)
        {
            RenewLicenseApplication frm = new RenewLicenseApplication();
            frm.ShowDialog();
        }

        private void tsmiReplacementForLostOrDamagedLicense_Click(object sender, EventArgs e)
        {
            ReplaceDamagedOrLostLicense frm = new ReplaceDamagedOrLostLicense();
            frm.ShowDialog();
        }

        private void tsmiRetakeTest_Click(object sender, EventArgs e)
        {
            LocalDrivingLicenseApplicationsList frm = new LocalDrivingLicenseApplicationsList();
            frm.ShowDialog();
        }

        private void tsmiDetainLicense_Click(object sender, EventArgs e)
        {
            DetainLicense frm = new DetainLicense();
            frm.ShowDialog();
        }

        private void tsmiReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicenseApplication frm = new ReleaseDetainedLicenseApplication();
            frm.ShowDialog();
        }

        private void tsmiManageDetainLicenses_Click(object sender, EventArgs e)
        {
            ListDetaindedLicensese frm = new ListDetaindedLicensese();
            frm.ShowDialog();
        }

        private void tsmiReleaseDetainedDrivingLicense_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicenseApplication frm = new ReleaseDetainedLicenseApplication();
            frm .ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _loginForm.Close();
            this.Close();
        }
    }
}
