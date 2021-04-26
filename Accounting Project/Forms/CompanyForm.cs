using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Accounting_GeneralLedger {
    public partial class CompanyForm : Form {

        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        private string tempCompany = "";
        public CompanyForm() {
            InitializeComponent();
        }

        private void CompanyForm_Load(object sender, EventArgs e) {
            GeneralFunctions.priviledgeGroupBox(Lock37);

            SqlConnection sqlcon = new SqlConnection(GeneralFunctions.ConnectionString );
            sqlcon.Open();
            SqlCommand sqlcomm = new SqlCommand("Select * From Company", sqlcon);
            SqlDataReader sqlread = sqlcomm.ExecuteReader();
            if (sqlread.HasRows) {
                while (sqlread.Read()) 
                {
                        txtCompany.Text = sqlread.GetString(1);
                        tempCompany = sqlread.GetString(1);
                        txtaddress.Text = sqlread.GetString(2);
                        txtphone.Text = sqlread.GetString(3);
                        txtmobile.Text = sqlread.GetString(4);
                        txtmail.Text = sqlread.GetString(5);
                        txtweb.Text = sqlread.GetString(6); 

                }
            }
            else {
                txtCompany.Text = GeneralFunctions.CompanyName;
                tempCompany = GeneralFunctions.CompanyName;

            }
            if (GeneralFunctions.languagechioce != "") {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }
        }
        private void update_language_interface() {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.companyName;
            this.lblCompany.Text = obj_interface_language.labelCompanyName;
            this.lblAddress.Text = obj_interface_language.labelAddress;
            this.lblphone.Text = obj_interface_language.labelphone;
            this.lblmobile.Text = obj_interface_language.labelmobile;
            this.lblmail.Text = obj_interface_language.labelmail;
            this.lblweb.Text = obj_interface_language.labelweb;
            this.btnedit.Text = obj_interface_language.buttonEdit;
            this.btnOk.Text = obj_interface_language.buttonCompanyOK;
            this.btnExit.Text = obj_interface_language.buttonCompanyExit; 
        }

        private void btnExit_Click(object sender, EventArgs e) {
            if ( btnedit.Visible == false)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            this.Close();

        }

        private void btnOk_Click(object sender, EventArgs e) {
            if (txtCompany.Text == "") {
                MessageBox.Show("Insert Valid Company Name");
                return;
            }
            SqlConnection sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon.Open();
            SqlCommand sqlcomm = new SqlCommand("Select * From Company", sqlcon);
            SqlDataReader sqlread = sqlcomm.ExecuteReader();
            if (sqlread.HasRows) {
                sqlread.Close();
                SqlCommand sqlUpdate = new SqlCommand("Update Company Set CompanyName='" + txtCompany.Text + "',Address='" + txtaddress.Text + "',Phone='" + txtphone.Text + "',Mobile='" + txtmobile.Text + "',E_mail='" + txtmail.Text + "',Web_site='" + txtweb.Text + "'", sqlcon);
                SqlCommand sqlUpdate2 = new SqlCommand("Update GLAccountsChart Set  TreeRowParent='" + txtCompany.Text + "' WHERE  (Root=0 AND TreeRowParent='" + tempCompany + "')", sqlcon);
                SqlCommand sqlUpdate3 = new SqlCommand("Update GLAccountsChart Set  TreeRowName='" + txtCompany.Text + "' WHERE  Root=1", sqlcon);
                int f=sqlUpdate2.ExecuteNonQuery();
                int f2 = sqlUpdate3.ExecuteNonQuery();
                if (sqlUpdate.ExecuteNonQuery() == 1) {
                    MessageBox.Show("Update Successfully");
                    //this.Close();
                }else
                    MessageBox.Show("Update Faild");
            }
            else {
                sqlread.Close();
                SqlCommand sqlInsert = new SqlCommand("Insert Into Company (CompanyName,Address,Phone,Mobile,E_mail,Web_site) VALUES ('" + txtCompany.Text + "','" + txtaddress.Text + "','" + txtphone.Text + "','" + txtmobile.Text + "','" + txtmail.Text + "','" + txtweb.Text + "')", sqlcon);
                if (sqlInsert.ExecuteNonQuery() == 1) {
                    MessageBox.Show("Insert Successfully");
                    //this.Close();
                }
                else
                    MessageBox.Show("Insert Faild");
            }
            foreach (Control co in Controls)
            {
                if (co is TextBox)
                    co.Enabled = false;
            }
                btnedit.Visible = true;
                btnOk.Visible = false;

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            foreach (Control co in Controls)
            {
                if (co is TextBox)
                    co.Enabled = true;
            }
                btnedit.Visible = false;
                btnOk.Visible = true;
        }

        private void btnedit_Click_1(object sender, EventArgs e)
        {

        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {

        }
    }
}