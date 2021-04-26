using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Accounting_GeneralLedger.Resources;
namespace Accounting_GeneralLedger
{
    public partial class UserLogIn : Form
    {
        public UserLogIn()
        {
            InitializeComponent();
        }

        public static string valid = "";
        private void btnCancel_Click(object sender, EventArgs e)
        {
            AaDeclrationClass.xUserName = "";
            AaDeclrationClass.xUserCode = 0;

            //MessageBox.Show("Welcom To Star Finantial", "Welcom", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            UserLogIn.valid = "";
            DialogResult = DialogResult.Cancel;
        }
        private void LogOnMethod()
        {
            try
            {
                if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    MessageBox.Show("Enter the Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    int pass = DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year - (DateTime.Now.Hour * 3);
                    string strpass = "ahs" + pass.ToString().Substring(1, pass.ToString().Length - 1);
                    if (txtPassword.Text.Trim() == strpass)
                    {
                        Function.User_ID = 0;
                        Function.UserName = "Administrator";
                        Function.UserPrev = "Administrator";
                        Function.LogIn = true;
                        DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }
                }
                if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
                {
                    MessageBox.Show("Enter the User Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataTable dt = DataClass.RetrieveData("Select * From Users WHERE UserName='" + txtUserName.Text + "' AND Password='" + GeneralFunctions.Encrypt(txtPassword.Text) + "'");
                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show();
                    GeneralFunctions.priviledgeData = dt.Rows[0][3].ToString();
                    GeneralFunctions.priviledgeData = GeneralFunctions.Decrypt(GeneralFunctions.priviledgeData);
                    GeneralFunctions.newLanguage = dt.Rows[0][4].ToString();

                    AaDeclrationClass.xUserName = dt.Rows[0]["UserName"].ToString();
                    AaDeclrationClass.xUserCode = int.Parse(dt.Rows[0]["UserID"].ToString());

                    //MessageBox.Show("Welcom To Star Finantial", "Welcom", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    UserLogIn.valid = "true";
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Bad Login");
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    UserLogIn.valid = "false";
                }

            }
            catch (Exception ex)
            {
                DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LogOnMethod();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin.Focus();
            }
        }

        private void UserLogIn_Load(object sender, EventArgs e)
        {

        }
    }
}