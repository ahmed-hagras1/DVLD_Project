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
    public partial class ListApplicationTypes: Form
    {
        DataTable _dtApplicationTypes;
        public ListApplicationTypes()
        {
            InitializeComponent();
        }
        private void ManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _dtApplicationTypes = ApplicationType.GetAllApplicationTypes();
            dgvApplicationTypes.DataSource = _dtApplicationTypes;

            if (dgvApplicationTypes.Rows.Count > 0)
            {
                dgvApplicationTypes.Columns[0].HeaderText = "ID";
                dgvApplicationTypes.Columns[0].Width = 100;

                dgvApplicationTypes.Columns[1].HeaderText = "Title";
                dgvApplicationTypes.Columns[1].Width = 250;

                dgvApplicationTypes.Columns[0].HeaderText = "Fees";
                dgvApplicationTypes.Columns[0].Width = 100;

            }

            lblRecords.Text = dgvApplicationTypes.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiEditApplication_Click(object sender, EventArgs e)
        {
            EditApplicationType frm = new EditApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            // Refresh
            ManageApplicationTypes_Load(null, null);
        }
    }
}
