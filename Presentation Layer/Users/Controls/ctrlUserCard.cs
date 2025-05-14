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
    public partial class ctrlUserCard: UserControl
    {
        int _userID = -1;
        User user = null;
        
        public int UserID
        {
            get { return _userID; }
        }
        public ctrlUserCard()
        {
            InitializeComponent();
        }
        private void _FillUserInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(user.personID);

            lblUserID.Text = _userID.ToString();
            lblUsername.Text = user.username;

            if (user.isActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";

        }
        public void LoadUserInfo(int userID)
        {
            _userID = userID;
            user = User.FindUserByUserID(userID);

            if(user == null)
            {
                MessageBox.Show($"No user with userID = {userID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }
        private void ctrlUserCard_Load(object sender, EventArgs e)
        {

        }
    }
}
