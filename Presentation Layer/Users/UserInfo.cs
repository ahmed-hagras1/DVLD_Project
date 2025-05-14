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
    public partial class UserInfo: Form
    {
        int userID;
        public UserInfo(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(this.userID);
        }
    }
}
