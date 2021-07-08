
using System;
using System.Windows.Forms;

namespace accAfpslaiEmvLogIn
{
    public partial class LogIN : Form
    {
        //public LogIN(string pBaseUrl, string pApiKey, string pBranchIssue, string pMsgHeader)
        //{
        //    InitializeComponent();
        //    this.baseUrl = pBaseUrl;
        //    this.apiKey = pApiKey;
        //    this.branchIssue = pBranchIssue;
        //    this.msgHeader = pMsgHeader;
        //}
        public LogIN(accAfpslaiEmvObjct.MiddleServerApi msa)
        {
            InitializeComponent();
            this.msa = msa;
        } 

        public bool IsSuccess = false;
        //public string baseUrl = "";
        //public string apiKey = "";
        //public string branchIssue = "";
        //public string msgHeader = "";
        public accAfpslaiEmvObjct.user dcsUser = null;
        public accAfpslaiEmvObjct.MiddleServerApi msa = null;

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
            //accAfpslaiEmvObjct.MiddleServerApi 
            //if (msa == null) msa = new accAfpslaiEmvObjct.MiddleServerApi(baseUrl, apiKey, branchIssue, accAfpslaiEmvObjct.MiddleServerApi.afpslaiEmvSystem.login);
            var response = msa.ValidateLogIn(txtUsername.Text, txtPassword.Text);
            if (response) dcsUser = msa.dcsUser;

            return response;
        }
       
    }
}
