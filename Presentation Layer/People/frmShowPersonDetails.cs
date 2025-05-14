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
    public partial class frmShowPersonDetails: Form
    {
        public frmShowPersonDetails(int personID)
        {
            InitializeComponent();
            ctrlPersonCard.LoadPersonInfo(personID);
        }
        public frmShowPersonDetails(string nationalNo)
        {
            InitializeComponent();
            ctrlPersonCard.LoadPersonInfo(nationalNo);
        }

        private void frmShowPersonDetails_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
