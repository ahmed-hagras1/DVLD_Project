using Business_Layer;
using Presentation_Layer.Users;
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

namespace Presentation_Layer
{
    public partial class UsersList: Form
    {
        DataTable usersList;
        string filterColumn;
        public UsersList()
        {
            InitializeComponent();
        }
        private void _RefreshRecordsCount()
        {
            lblRecordsCount.Text = $"# Records:  {dgvUsersList.Rows.Count}";
        }
        private void UsersList_Load(object sender, EventArgs e)
        {
            usersList = User.GetUsersList();
           
            dgvUsersList.DataSource = usersList;

            if (dgvUsersList.Rows.Count > 0)
            {
                dgvUsersList.Columns[0].HeaderText = "User ID";
                dgvUsersList.Columns[0].Width = 100;


                dgvUsersList.Columns[1].HeaderText = "Person ID";
                dgvUsersList.Columns[1].Width = 100;

                dgvUsersList.Columns[2].HeaderText = "Full name";
                dgvUsersList.Columns[2].Width = 400;

                dgvUsersList.Columns[3].HeaderText = "Username";
                dgvUsersList.Columns[3].Width = 200;

                dgvUsersList.Columns[4].HeaderText = "Is Active";
                dgvUsersList.Columns[4].Width = 100;
            }

            cbFilterItems.SelectedIndex = 0;
            txtFilterText.Visible = cbActiveMode.Visible = false;
            _RefreshRecordsCount();
        }
       
        private void cbFilterItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilterItems.Text)
            {
                case "User ID":
                    filterColumn = "UserID";
                    txtFilterText.Visible = true;
                    cbActiveMode.Visible = false;
                    txtFilterText.Clear();
                    break;
                case "Person ID":
                    filterColumn = "PersonID";
                    txtFilterText.Visible = true;
                    cbActiveMode.Visible = false;
                    txtFilterText.Clear();
                    break;
                    case "Username":
                        filterColumn = "Username";
                    txtFilterText.Visible = true;
                    cbActiveMode.Visible = false;
                    txtFilterText.Clear();
                    break;
                case "Full name":
                    filterColumn = "FullName";
                    txtFilterText.Visible = true;
                    cbActiveMode.Visible = false;
                    txtFilterText.Clear();
                    break;
                case "Is Active":
                    filterColumn = "IsActive";
                    txtFilterText.Visible = false;
                    cbActiveMode.Visible = true;
                    cbActiveMode.SelectedIndex = 0;
                    break;
                default:
                    filterColumn = "None";
                    txtFilterText.Visible = false;
                    cbActiveMode.Visible = false;
                    break;
            }

            _RefreshRecordsCount();
        }
        //None
        //User ID
        //Username
        //Person ID
        //Full name
        //Is Active
        private void _FilterUsersList( string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                usersList.DefaultView.RowFilter = string.Empty;
                _RefreshRecordsCount();
                return;
            }

            if(filterColumn == "IsActive")
            {
                if (cbActiveMode.SelectedIndex == 0)
                    usersList.DefaultView.RowFilter = "";
                else if (cbActiveMode.SelectedIndex == 1)
                    usersList.DefaultView.RowFilter = $"{filterColumn} = 'True'";
                else
                    usersList.DefaultView.RowFilter = $"{filterColumn} = 'False'";
            }
            else if (filterColumn == "UserID" || filterColumn == "PersonID")
            {
                usersList.DefaultView.RowFilter = $"{filterColumn} = {text}";
            }
            else
            {
                usersList.DefaultView.RowFilter = $"{filterColumn} LIKE '{text}%'";
            }

            _RefreshRecordsCount();
        }
        private void cbActiveMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterUsersList(cbActiveMode.Text);
        }

        private void txtFilterText_TextChanged(object sender, EventArgs e)
        {
           _FilterUsersList(txtFilterText.Text.Trim());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _AddAndUpdateUser(int userID)
        {
            AddAndUpdateUser frm = new AddAndUpdateUser(userID);
            frm.ShowDialog();

            // Refresh users list.
            UsersList_Load(null, null);
        }
        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            _AddAndUpdateUser(-1);
        }

        private void tsmiAddNewUser_Click(object sender, EventArgs e)
        {
            _AddAndUpdateUser(-1);
        }

        private void tsmiEditUser_Click(object sender, EventArgs e)
        {
            _AddAndUpdateUser((int)dgvUsersList.CurrentRow.Cells[0].Value);
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this user? This action cannot be undone.","Confirm Deletion"
                , MessageBoxButtons.YesNo , MessageBoxIcon.Question , MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (User.DeleteUser((int)dgvUsersList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("The user has been successfully deleted.","Deletion Successful"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh users list.
                    UsersList_Load(null, null);
                }
                else
                    MessageBox.Show("Unable to delete the user. Please try again or contact support.", "Deletion Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmiShowDetailsUser_Click(object sender, EventArgs e)
        {
            UserInfo frm = new UserInfo((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void txtFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterItems.SelectedIndex == cbFilterItems.FindString("User ID") ||
                cbFilterItems.SelectedIndex == cbFilterItems.FindString("Person ID"))
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true; // Ignore the input
                }
            }
        }

        private void tsmiChangePassword_Click(object sender, EventArgs e)
        {
            ChangeUserPassword frm = new ChangeUserPassword((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
