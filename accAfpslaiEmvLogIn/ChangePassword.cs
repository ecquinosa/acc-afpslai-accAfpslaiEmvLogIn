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
            if (txtOldPassword.Text == "" || txtNewPassword.Text == "" || txtConfirmPass.Text == "") accAfpslaiEmvObjct.Utilities.ShowWarningMessage("Please enter value in empty field(s)");
            else
            {
                if (txtNewPassword.Text != txtConfirmPass.Text) accAfpslaiEmvObjct.Utilities.ShowWarningMessage("New and Confirm passwords are not identical");
                else
                {
                    //if (accAfpslaiEmvObjct.Utilities.IsPasswordValid(txtNewPassword.Text))
                    //{
                    if (LogIN.msa.changeUserPassword(LogIN.dcsUser.userId, txtOldPassword.Text, txtNewPassword.Text))
                    {
                        LogIN.dcsUser.userPass = LogIN.msa.dcsUser.userPass;
                        isPasswordChanged = true;
                        Close();
                    }
                    //}
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtOldPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPass.Clear();
            txtOldPassword.Focus();
        }
    }
}
