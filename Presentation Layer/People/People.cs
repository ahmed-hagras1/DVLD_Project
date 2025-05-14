using Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Presentation_Layer
{
    public partial class frmPeople: Form
    {
        DataTable _dtAllPeople;
        DataTable _dtPeople;

        string _filterColumn;
        public frmPeople()
        {
            InitializeComponent();
        }
        private void _LoadAllCountriesInComboBox()
        {
            DataTable dataTable = Country.GetAllCountries();

            foreach (DataRow row in dataTable.Rows )
            {
                cbCountries.Items.Add(row["CountryName"]);
            }
        }
        private void frmPeople_Load(object sender, EventArgs e)
        {
            _dtAllPeople = Person.GetAllPeople();

        //only select the columns that you want to show in the grid
        //Purpose: This is often used to:
            //Reduce memory usage by selecting only needed columns.
           //Create a subset of data for display or processing.
            _dtPeople = _dtAllPeople.DefaultView.ToTable(true , "PersonID" , "NationalNo" , "FirstName" , "SecondName" , "ThirdName",
                "LastName" , "GenderCaption", "DateOfBirth", "CountryName", "Phone", "Email");
            dgvPeople.DataSource = _dtPeople;

            if (dgvPeople.Rows.Count > 0)
            {
                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 100;

                dgvPeople.Columns[1].HeaderText = "National No";
                dgvPeople.Columns[1].Width = 70;

                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 100;

                dgvPeople.Columns[3].HeaderText = "Second Name";
                dgvPeople.Columns[3].Width = 100;

                dgvPeople.Columns[4].HeaderText = "Third Name";
                dgvPeople.Columns[4].Width = 100;

                dgvPeople.Columns[5].HeaderText = "Last Name";
                dgvPeople.Columns[5].Width = 100;

                dgvPeople.Columns[6].HeaderText = "Gender";
                dgvPeople.Columns[6].Width = 70;

                dgvPeople.Columns[7].HeaderText = "Date Of Birth";
                dgvPeople.Columns[7].Width = 150;

                dgvPeople.Columns[8].HeaderText = "Nationality";
                dgvPeople.Columns[8].Width = 70;

                dgvPeople.Columns[9].HeaderText = "Phone";
                dgvPeople.Columns[9].Width = 90;

                dgvPeople.Columns[10].HeaderText = "Email";
                dgvPeople.Columns[10].Width = 150;

            }

            cbFilterBy.SelectedIndex = 0;
            txtFilterBy.Visible = false;
            lblRecordsCount.Text = "# Records:   " + dgvPeople.Rows.Count.ToString();
            _LoadAllCountriesInComboBox();
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.Green;
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.White;
        }

        private void EnterInButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.Green;
        }

        private void LeaveFromButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.White;
        }

        
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If Selected item not None or Nationality.
            if (cbFilterBy.SelectedIndex != 0 && cbFilterBy.SelectedIndex != 7)
            {
                txtFilterBy.Visible = true;
                txtFilterBy.Clear();
                cbCountries.Visible = false;
            }
            else if (cbFilterBy.SelectedIndex == 7)
            {
                txtFilterBy.Visible = false;
                cbCountries.SelectedIndex = 0;
                cbCountries.Visible = true;
            }
            else
            {
                txtFilterBy.Visible = false;
                txtFilterBy.Clear();
                cbCountries.Visible = false;
            }

            _dtAllPeople.DefaultView.RowFilter = "";
            lblRecordsCount.Text = "# Records:   " + dgvPeople.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want delete person with ID = " + dgvPeople.CurrentRow.Cells[0].Value ,
                "Coniform delete", MessageBoxButtons.YesNo , MessageBoxIcon.Question , MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (Person.DeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person deleted successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the data.
                    frmPeople_Load(null, null);
                    return;
                }
            }

        }

        // Open AddNew form when click in Add New. 
        private void _AddNewClick()
        {
            Form frm = new Add_UpdatePerson();
            frm.ShowDialog();

            // Refresh the data.
            frmPeople_Load(null, null);
        }
        private void tsmiShowDetails_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonDetails((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            // Refresh the data.
            frmPeople_Load(null, null);
        }
        private void tsmiAddNewPerson_Click(object sender, EventArgs e)
        {
            _AddNewClick();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            _AddNewClick();
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            Form frm = new Add_UpdatePerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            // Refresh the data.
            frmPeople_Load(null, null);
        }

        private void _FilterPeopleList(string text)
        {

            if(string.IsNullOrEmpty(text.Trim()))
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordsCount.Text = "# Records:   " + dgvPeople.Rows.Count.ToString();
                return;
            }

            if (cbFilterBy.SelectedIndex == cbFilterBy.FindString("Person ID"))
            {
                int.TryParse(text, out int result);
                _dtPeople.DefaultView.RowFilter = $"PersonID = {result}";
            }
            else if (cbFilterBy.SelectedIndex == cbFilterBy.FindString("National No"))
            {
                _dtPeople.DefaultView.RowFilter = $"NationalNo like '{text}%'";
            }
            else if (cbFilterBy.SelectedIndex == cbFilterBy.FindString("First Name"))
            {
                _dtPeople.DefaultView.RowFilter = $"FirstName like '{text}%'";
            }
            else if (cbFilterBy.SelectedIndex == cbFilterBy.FindString("Second Name"))
            {
                _dtPeople.DefaultView.RowFilter = $"SecondName like '{text}%'";
            }
            else if (cbFilterBy.SelectedIndex == cbFilterBy.FindString("Third Name"))
            {
                _dtPeople.DefaultView.RowFilter = $"ThirdName like '{text}%'";
            }
            else if (cbFilterBy.SelectedIndex == cbFilterBy.FindString("Last Name"))
            {
                _dtPeople.DefaultView.RowFilter = $"LastName like '{text}%'";
            }
            else if (cbFilterBy.SelectedIndex == cbFilterBy.FindString("Nationality"))
            {
                if (cbCountries.SelectedIndex != 0)
                    _dtPeople.DefaultView.RowFilter = $"CountryName = '{text}'";
            }
            else if (cbFilterBy.SelectedIndex == cbFilterBy.FindString("Gender"))
            {
                _dtPeople.DefaultView.RowFilter = $"GenderCaption like '{text}%'";
            }
            else if (cbFilterBy.SelectedIndex == cbFilterBy.FindString("Phone"))
            {
                _dtPeople.DefaultView.RowFilter = $"Phone like '{text}%'";
            }
            else if (cbFilterBy.SelectedIndex == cbFilterBy.FindString("Email"))
            {
                _dtPeople.DefaultView.RowFilter = $"Email like '{text}%'";
            }

            lblRecordsCount.Text = "# Records:   " + dgvPeople.Rows.Count.ToString();
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            _FilterPeopleList(txtFilterBy.Text);
        }

        private void cbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterPeopleList(cbCountries.Text);
        }

        private void dgvPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "Phone")
            {

                // Allow control characters (like backspace)
                if (char.IsControl(e.KeyChar))
                {
                    return;
                }

                // Allow only digits
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
