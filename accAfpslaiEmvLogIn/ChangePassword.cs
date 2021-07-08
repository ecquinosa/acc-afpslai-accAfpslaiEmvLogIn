using System;
using System.Windows.Forms;

namespace accAfpslaiEmvLogIn
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }
       
        public bool isPasswordChanged = false;
        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text == "" || txtNewPassword.Text == "") accAfpslaiEmvObjct.Utilities.ShowWarningMessage("Please enter value in empty field(s)");
            else
            {
                if (accAfpslaiEmvObjct.Utilities.IsPasswordValid(txtNewPassword.Text))
                {
                    if (LogIN.msa.changeUserPassword(LogIN.dcsUser.userId, txtOldPassword.Text, txtNewPassword.Text))
                    {
                        isPasswordChanged = true;
                        Close();
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtOldPassword.Clear();
            txtNewPassword.Clear();
            txtOldPassword.Focus();
        }
    }
}
