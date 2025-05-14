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
    public partial class FindForm: Form
    {
        public delegate void DataBackEventHandler(object sender ,int personID);
        public event DataBackEventHandler DataBack;

        public FindForm()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack.Invoke(this, ctrlPersonCardWithFilter1.personID);
            this.Close();
        }

        private void FindForm_Load(object sender, EventArgs e)
        {

        }
    }
}
