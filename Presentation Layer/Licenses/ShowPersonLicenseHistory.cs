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
    public partial class ShowPersonLicenseHistory: Form
    {
        int _personID = -1;

        public ShowPersonLicenseHistory()
        {
            InitializeComponent();
        }
        public ShowPersonLicenseHistory(int personID)
        {
            InitializeComponent();
            _personID = personID;
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            // You can search by personID.
            if (_personID == -1)
            {
               ctrlPersonCardWithFilter1.filterEnabled = true;
            }

            ctrlDriverLicenses1.LoadInfoByPersonID(_personID);
            ctrlPersonCardWithFilter1.filterEnabled = false;
            ctrlPersonCardWithFilter1.LoadSelectedPersonInfo(_personID);
        }
    }
}
