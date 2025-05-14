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
    public partial class frmLoginForm: Form
    {
        public frmLoginForm()
        {
            InitializeComponent();
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
        private void btnLogin_Enter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.Green;
        }

        private void btnLogin_Leave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.White;
        }
        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username".ToLower())
            {
                txtUsername.Text = "";
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password".ToLower())
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = '*';
            }
        }
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password".ToLower();
                txtPassword.PasswordChar = '\0';
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username".ToLower();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = User.FindUserByUsernameAndPassword(txtUsername.Text, txtPassword.Text);

            // If username or password wrong.
            if(user == null)
            {
                MessageBox.Show("Invalid username or password", "Failed login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If user not active.
            if (!user.isActive)
            {
                MessageBox.Show("User is not active", "Failed login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate remember login info.
            if (chkRememberMe.Checked)
                SaveLoginInfo.RememberLoginInfo(txtUsername.Text, txtPassword.Text);
            else
                SaveLoginInfo.RememberLoginInfo("", ""); // Delete saved login info from txt file.


            SaveLoginInfo.currentUser = user;
            Form frm = new MainScreen(this);
            this.Hide();
            frm.ShowDialog();
        }

        private void frmLoginForm_Load(object sender, EventArgs e)
        {
            string username = "", password = "";
            if (SaveLoginInfo.GetStoredLoginInfo(ref username ,ref password))
            {
                txtUsername.Text = username;
                txtPassword.Text = password;
                chkRememberMe.Checked = true;
                txtPassword.PasswordChar = '*';
            }
            else
            {
                txtUsername.Text = "Username".ToLower();
                txtPassword.Text = "Password".ToLower();
                chkRememberMe.Checked = false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
