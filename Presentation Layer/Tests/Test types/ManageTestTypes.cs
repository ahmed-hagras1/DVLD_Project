using Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer
{
    public partial class ManageTestTypes: Form
    {
        DataTable dtTestTypesList;
        public ManageTestTypes()
        {
            InitializeComponent();
        }
        private void ManageTestTypes_Load(object sender, EventArgs e)
        {
            dtTestTypesList = TestType.GetAllTestTypes();
            dgvTestTypes.DataSource = dtTestTypesList;

            if (dgvTestTypes.Rows.Count > 0)
            {
                dgvTestTypes.Columns[0].HeaderText = "ID";
                dgvTestTypes.Columns[0].Width = 50;

                dgvTestTypes.Columns[1].HeaderText = "Title";
                dgvTestTypes.Columns[1].Width = 150;

                dgvTestTypes.Columns[2].HeaderText = "Description";
                dgvTestTypes.Columns[2].Width = 200;

                dgvTestTypes.Columns[3].HeaderText = "Fees";
                dgvTestTypes.Columns[3].Width = 50;
            }


            lblRecords.Text = dgvTestTypes.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiEditTestType_Click(object sender, EventArgs e)
        {
            UpdateTestType frm = new UpdateTestType((TestType.en_TestType)dgvTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            //Refresh.
            ManageTestTypes_Load(sender , e);
        }
    }
}
