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
    public partial class ctrlPersonCardWithFilter: UserControl
    {

        public event Action<int> onPersonSelected;
        protected void PersonSelected(int personID)
        {
            Action<int> handler = onPersonSelected;

            if (handler != null)
                handler(personID);
        }

        private bool _showAddPerson = true;
        public bool showAddPerson
        {
            get
            {
                return _showAddPerson;
            }
            set
            {
                _showAddPerson = value;
                btnAddNewPerson.Visible = _showAddPerson;
            }
        }

        private bool _filterEnabled = true;
        public bool filterEnabled
        {
            get => _filterEnabled;
            set
            {
                _filterEnabled = value;
                gbFilter.Enabled = _filterEnabled;
            }
        }

        private int _personID = -1;
        public int personID
        {
            get => ctrlPersonCard1.PersonID;
        }
        private string _nationalNo = string.Empty;
        public string nationalNo
        {
            get => ctrlPersonCard1.NationalNo;
        }
        public Person selectedPersonInfo { get { return ctrlPersonCard1.SelectedPerson; } }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }
        private void _FindNow()
        {
            if (cbFilterItems.SelectedIndex == cbFilterItems.FindString("Person ID"))
            {
                if (int.TryParse(txtFilter.Text.Trim(), out int personID))
                {
                    ctrlPersonCard1.LoadPersonInfo(personID);
                }
                else
                {
                    // show this message if user not enter number.
                    MessageBox.Show("Invalid PersonID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (cbFilterItems.SelectedIndex == cbFilterItems.FindString("National No"))
            {

                ctrlPersonCard1.LoadPersonInfo(txtFilter.Text);
            }
            else
            {
                MessageBox.Show("Please select filter before.", "Note", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cbFilterItems.Focus();
                return;
            }


            if (onPersonSelected != null && filterEnabled)
                onPersonSelected(ctrlPersonCard1.PersonID);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please enter valid data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FindNow();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            Add_UpdatePerson frm = new Add_UpdatePerson();
            frm.DataBack += DataBackEvent;
            frm.ShowDialog();
        }

        private void DataBackEvent(object sender , int personID)
        {
            cbFilterItems.SelectedIndex = 0;
            txtFilter.Text = personID.ToString();

            // Load info in person card.
            ctrlPersonCard1.LoadPersonInfo(personID);
        }

        public void LoadSelectedPersonInfo(int personID)
        {
            _personID = personID;
            txtFilter.Text = _personID.ToString();
            cbFilterItems.SelectedIndex = 0;
            _FindNow();
        }
        public void LoadSelectedPersonInfo (string nationalNo)
        {
            _nationalNo = nationalNo;
            txtFilter.Text = nationalNo;
            cbFilterItems.SelectedIndex = 1;
            _FindNow();
        }
        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterItems.SelectedIndex = 0;
            txtFilter.Focus();
        }

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {

        }

        private void txtFilter_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilter.Text.Trim()))
            {
                e.Cancel = true;
                txtFilter.Focus();
                errorProvider.SetError(txtFilter, "It should have value");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtFilter, "");
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                // If the Enter key is pressed, trigger the search button click event
                btnSearch.PerformClick();
            }

            if(cbFilterItems.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
