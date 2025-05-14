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
    public partial class ShowInternationalLicenseInfo: Form
    {
        int _internationalLicenseID;
        public ShowInternationalLicenseInfo(int internationalLicenseID)
        {
            InitializeComponent();
            _internationalLicenseID = internationalLicenseID;
        }

        private void ShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverInterrnationalLicenseInfo1.LoadInfo(_internationalLicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
