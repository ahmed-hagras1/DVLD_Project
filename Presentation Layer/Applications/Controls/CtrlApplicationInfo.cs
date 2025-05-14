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

namespace Presentation_Layer
{
    public partial class CtrlApplicationInfo: UserControl
    {
        clsApplication _application;
        public CtrlApplicationInfo()
        {
            InitializeComponent();
        }

        private void CtrlApplicationInfo_Load(object sender, EventArgs e)
        {

        }

        public void LoadApplicationInfo (int applicationID)
        {
            _application = clsApplication.FindApplication(applicationID);

            if (_application == null)
            {

                _ResetApplicationInfo();
                MessageBox.Show($"Error: No application with applicationID = {applicationID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                _FillApplicationInfo();


        }
        private void _FillApplicationInfo()
        {
            llViewPersonInfo.Enabled = true;

            lblID.Text = _application.ApplicationID.ToString();
            lblStatus.Text = _application.StatusText;
            lblFees.Text = _application.PaidFees.ToString();
            lblType.Text = _application.applicationType.applicationTypeTitle;
            lblApplicant.Text = _application.ApplicationPersonFullName;
            lblDate.Text = _application.ApplicationDate.ToShortDateString();
            lblLastStatusDate.Text = _application.LastStatusDate.ToShortDateString();
            lblCreatedBy.Text = _application.CreatedByUserInfo.username;
        }
        private void _ResetApplicationInfo()
        {
            lblID.Text = "[???]";
            lblStatus.Text = "[???]";
            lblFees.Text = "[???]";
            lblType.Text = "[???]";
            lblApplicant.Text = "[???]";
            lblDate.Text = "[???]";
            lblLastStatusDate.Text = "[???]";
            lblCreatedBy.Text = "[???]";

            llViewPersonInfo.Enabled = false;
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonDetails frm = new frmShowPersonDetails(_application.ApplicantPersonID);
            frm.ShowDialog();
        }
    }
}
