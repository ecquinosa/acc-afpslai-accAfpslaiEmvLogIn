
using System;
using System.Windows.Forms;

namespace accAfpslaiEmvLogIn
{
    public partial class LogIN : Form
    {
        
        public LogIN(accAfpslaiEmvObjct.MiddleServerApi pMsa)
        {
            InitializeComponent();
            msa = pMsa;
            if(msa!=null)linkLabel1.Text = msa.baseUrl;
        } 

        public bool IsSuccess = false;      
        public static accAfpslaiEmvObjct.user dcsUser = null;
        public static accAfpslaiEmvObjct.MiddleServerApi msa = null;

        private void LogIN_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }           

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" && txtPassword.Text == "")
            {
                lblResult.Text = "Please enter valid credential";
                txtUsername.Focus();
            }
            else if (txtUsername.Text != "" && txtPassword.Text == "")
            {
                lblResult.Text = "Please enter valid credential";
                txtPassword.Focus();
            }
            else if (txtUsername.Text == "" && txtPassword.Text != "")
            {
                lblResult.Text = "Please enter valid credential";
                txtUsername.Focus();
            }
            else
            {
                if (ValidateLogIN_AFPSLAI()) Login();
            }
        }

        private void Login()
        {
            IsSuccess = true;
            Close();
        }

        private void LogIN_FormClosing(object sender, FormClosingEventArgs e)
        {
                
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) btnLogin.PerformClick();            
        }       

        private bool ValidateLogIN_AFPSLAI()
        {            
            if (msa != null)
            {
                var response = msa.ValidateLogIn(txtUsername.Text, txtPassword.Text);
                if (response)
                {
                    dcsUser = msa.dcsUser;
                    if (dcsUser.isChangePassword)
                    {
                        ChangePassword cp = new ChangePassword();
                        cp.ShowDialog();
                        response = cp.isPasswordChanged;
                        if (!response) accAfpslaiEmvObjct.Utilities.ShowWarningMessage("User failed to change password");
                    }
                }

                return response;
            }
            else
            {
                accAfpslaiEmvObjct.Utilities.ShowWarningMessage("Failed to load api object");
                return false;
            }            
        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            txtUsername.Text = "admin";
            txtPassword.Text = "afPsL@ieMv2021";
        }
    }
}
