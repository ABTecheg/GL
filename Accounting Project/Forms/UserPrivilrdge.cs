using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
namespace Accounting_GeneralLedger
{
    public partial class UserPrivilrdge : Form
    {
        public UserPrivilrdge()
        {
            InitializeComponent();
        }
        // last tag 59

        //private ClassInterfaceLanguage obj_interface_language = null;
        //private ClassOptions obj_options;
        //private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        //private string exe_path = Application.StartupPath;
        private string pass = "";
        private string priviledgeUser = "";
        private int countnodes = 0;
        SqlConnection mycon;
        SqlDataAdapter Adapterusers;
        dbAccountingProjectDS dbAccountingProjectDS1;
        private void fillusers()
        {
            dbAccountingProjectDS1 = new dbAccountingProjectDS();
            mycon = new SqlConnection(GeneralFunctions.ConnectionString);
            Adapterusers = new SqlDataAdapter("Select * from Users", mycon);
            Adapterusers.Fill(dbAccountingProjectDS1.Users);
        }
        private void UserPrivilrdge_Load(object sender, EventArgs e)
        {
            tree1.Nodes.Clear();
            tree1.ImageList = this.imageList1;
            countnodes++;
            this.tree1.Nodes.Add("1", "General Ledger", 0);
            countnodes++;
            tree1.Nodes[0].Nodes.Add("2", "System Settings", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes.Add("8", "User Priviledge", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes.Add("9", "General Settings", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[1].Nodes.Add("12", "Company Name", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[1].Nodes[0].Nodes.Add("37", "Edit Company", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[1].Nodes.Add("13", "General Setup", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[1].Nodes.Add("14", "Fiscal Period Setup", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[1].Nodes.Add("15", "Currency", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[1].Nodes[3].Nodes.Add("44", "Add Currency", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[1].Nodes[3].Nodes.Add("45", "Edit Currency", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[1].Nodes[3].Nodes.Add("46", "Delete Currency", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[1].Nodes.Add("16", "Currency Convertion", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[1].Nodes[4].Nodes.Add("41", "Add Currency Convertion", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[1].Nodes[4].Nodes.Add("42", "Edit Currency Convertion", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[1].Nodes[4].Nodes.Add("43", "Delete Currency Convertion", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes.Add("10", "General Ledger Setup", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes.Add("17", "G L General Setup", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes.Add("18", "Account Definition", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes[1].Nodes.Add("38", "Add Account", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes[1].Nodes.Add("39", "Edit Account", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes[1].Nodes.Add("40", "Delete Account", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes.Add("19", "Chart Of Accounts", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes[2].Nodes.Add("47", "Modify Chart Of Accounts", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes.Add("20", "Project Codes", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes[3].Nodes.Add("48", "Add Project Codes", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes[3].Nodes.Add("49", "Edit Project Codes", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes[3].Nodes.Add("50", "Delete Project Codes", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes.Add("21", "GL Journal Codes", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes[4].Nodes.Add("51", "Add GL Journal Codes", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes[4].Nodes.Add("52", "Edit GL Journal Codes", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes[4].Nodes.Add("53", "Delete GL Journal Codes", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes.Add("22", "Allocation Maintenance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes[5].Nodes.Add("54", "Add Allocation Maintenance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes[5].Nodes.Add("55", "Edit Allocation Maintenance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes[5].Nodes.Add("56", "Delete Allocation Maintenance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes.Add("23", "TransactionsTemp Maintenance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes[6].Nodes.Add("57", "Add TransactionsTemp Maintenance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes[6].Nodes.Add("58", "Edit TransactionsTemp Maintenance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[2].Nodes[6].Nodes.Add("59", "Delete TransactionsTemp Maintenance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes.Add("75", "Acount Payable Setup", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes.Add("34", "Accounts Payable Control", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes.Add("76", "Tax Office", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes[1].Nodes.Add("82", "Add Tax Office", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes[1].Nodes.Add("83", "Edit Tax Office", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes[1].Nodes.Add("84", "Delete Tax Office", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes.Add("77", "Tax Reason", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes[2].Nodes.Add("85", "Add Tax Reason", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes[2].Nodes.Add("86", "Edit Tax Reason", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes[2].Nodes.Add("87", "Delete Tax Reason", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes.Add("78", "Delivery Types", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes[3].Nodes.Add("88", "Add Delivery Types", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes[3].Nodes.Add("89", "Edit Delivery Types", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes[3].Nodes.Add("90", "Delete Delivery Types", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes.Add("79", "Vendors Categories", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes[4].Nodes.Add("91", "Add Vendors Categories", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes[4].Nodes.Add("92", "Edit Vendors Categories", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes[4].Nodes.Add("93", "Delete Vendors Categories", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes.Add("80", "Payment Terms", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes[5].Nodes.Add("94", "Add Payment Terms", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes[5].Nodes.Add("95", "Edit Payment Terms", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes[5].Nodes.Add("96", "Delete Payment Terms", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes.Add("81", "Vendors", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes[6].Nodes.Add("97", "Add Vendors", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes[6].Nodes.Add("98", "Edit Vendors", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes[3].Nodes[6].Nodes.Add("99", "Delete Vendors", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[0].Nodes.Add("11", "Account Type", 1);
            countnodes++;
            tree1.Nodes[0].Nodes.Add("3", "General Ledger", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes.Add("24", "Transactions Maintenance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("60", "Add Transactions Maintenance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("61", "Edit Transactions Maintenance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("62", "Delete Transactions Maintenance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("63", "Posted Transactions Maintenance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("64", "Reverse Transactions Maintenance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("65", "Transactions Temp", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes.Add("107", "Transactions Maintenance Cashier", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes[1].Nodes.Add("108", "Add Transactions Maintenance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes[1].Nodes.Add("109", "Edit Transactions Maintenance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes[1].Nodes.Add("110", "Delete Transactions Maintenance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes[1].Nodes.Add("111", "Posted Transactions Maintenance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes.Add("25", "Budget Maintenance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes[2].Nodes.Add("66", "Modify Budget Maintenance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes.Add("26", "Run Allocation", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes[3].Nodes.Add("67", "Run", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes.Add("101", "JVYearEndAdjustments", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes[4].Nodes.Add("102", "Add JVYearEndAdjustments", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes[4].Nodes.Add("103", "Edit JVYearEndAdjustments", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes[4].Nodes.Add("104", "Delete JVYearEndAdjustments", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes[4].Nodes.Add("105", "Posted JVYearEndAdjustments", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes[4].Nodes.Add("106", "Transactions Temp", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes.Add("27", "End Period", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes.Add("28", "End Year", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes.Add("29", "G/L Batch Report", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes.Add("30", "Chart of Account", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes.Add("31", "G/L Journal", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes.Add("32", "G/L Detail", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes.Add("33", "G/L Trail Balance", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[1].Nodes.Add("100", "Balance Sheet", 1);
            countnodes++;
            tree1.Nodes[0].Nodes.Add("4", "Acount Payable", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[2].Nodes.Add("35", "APTransactions", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[2].Nodes[0].Nodes.Add("68", "Add Batch AP", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[2].Nodes[0].Nodes.Add("69", "Edit Batch AP", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[2].Nodes[0].Nodes.Add("70", "Delete Batch AP", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[2].Nodes[0].Nodes.Add("71", "Posted Batch AP", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[2].Nodes[0].Nodes.Add("72", "Add Invoice AP", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[2].Nodes[0].Nodes.Add("73", "Edit Invoice AP", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[2].Nodes[0].Nodes.Add("74", "Delete Invoice AP", 1);
            countnodes++;
            tree1.Nodes[0].Nodes[2].Nodes.Add("36", "Apply CreditsScreen", 1);
            countnodes++;
            tree1.Nodes[0].Nodes.Add("5", "Bank", 1);
            countnodes++;
            tree1.Nodes[0].Nodes.Add("6", "Reports", 1);
            countnodes++;
            tree1.Nodes[0].Nodes.Add("7", "Help", 1);
            tree1.Nodes[0].Checked = true;
            //if (GeneralFunctions.languagechioce != "") {
            //    this.obj_options = new ClassOptions();
            //    this.obj_options.report_language = GeneralFunctions.languagechioce;
            //    this.update_language_interface();
            //}
            //GLInterface gl=new GLInterface();
            comboBox_language.Items.AddRange(GLInterface.report_language_available);
            fillusers();
            movefirst();

            //last count 111

        }



        private void clearAll()
        {
            TreeNode[] TN = new TreeNode[1];
            for (int i = 1; i <= countnodes; i++)
            {
                TN = tree1.Nodes.Find(i.ToString(), true);
                TN[0].Checked = false;
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            clearAll();
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtRePassword.Text = "";
            comboBox_language.Text = "";
            btnNew.Text = "New";
            checkBox1.Checked = false;
            btnDelete.Text = "Delete";
            btnEdit.Text = "Edit";
            btnNew.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;
            txtRePassword.Enabled = false;
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            groupBox3.Enabled = false;
            tree1.Nodes[0].Checked = true;
            movefirst();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            tree1.Nodes[0].Checked = true;
            if (btnNew.Text == "New")
            {
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtRePassword.Text = "";
                btnNew.Text = "Save";
                groupBox3.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                txtUserName.Enabled = true;
                txtPassword.Enabled = true;
                txtRePassword.Enabled = true;
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
                clearAll();
                comboBox_language.Text = "";
            }
            else if (btnNew.Text == "Save")
            {
                if (txtUserName.Text == "")
                {
                    MessageBox.Show("Insert Valid User Name", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (txtPassword.Text == "")
                {
                    MessageBox.Show("Insert Valid Password", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (txtRePassword.Text == "")
                {
                    MessageBox.Show("Insert Valid Confirm Password", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (txtRePassword.Text != txtPassword.Text)
                {
                    MessageBox.Show("Confirm Password Must the same to password", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (comboBox_language.Text == "")
                {
                    MessageBox.Show("Please enter valid language");
                    return;
                }
                setData();

                SqlConnection sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlcon.Open();
                SqlCommand sqlcommandCheck = new SqlCommand("Select UserName From Users WHERE UserName='" + txtUserName.Text + "'", sqlcon);
                SqlDataReader sqlread = sqlcommandCheck.ExecuteReader();
                if (sqlread.HasRows)
                {
                    MessageBox.Show("This user name already defind before", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                sqlread.Close();
                int id = 1;
                SqlCommand getID = new SqlCommand("Select Max(UserID)+1 From Users", sqlcon);
                if (getID.ExecuteScalar() != DBNull.Value)
                {
                    id = int.Parse(getID.ExecuteScalar().ToString());
                }
                else
                {
                    id = 1;
                }
                priviledgeUser = GeneralFunctions.Encrypt(priviledgeUser);
                pass = GeneralFunctions.Encrypt(txtPassword.Text);
                SqlCommand sqlcom = new SqlCommand("Insert Into Users (UserID,UserName,Password,Privilegde,UserLanguage) VALUES (" + id + ",'" + txtUserName.Text + "','" + pass + "','" + priviledgeUser + "','" + comboBox_language.Text + "')", sqlcon);
                int done = 0;
                done = sqlcom.ExecuteNonQuery();
                if (done == 0)
                {
                    MessageBox.Show("Insert Faild");
                    return;
                }
                else
                {
                    MessageBox.Show("Insert Successfully");
                }
                btnNew.Text = "New";
                groupBox3.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
                txtRePassword.Enabled = false;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                sqlcon.Close();
                fillusers();
            }
        }
        private void ShowpriviledgeUser()
        {
            try
            {
                checkBox1.Checked = false;
                TreeNode[] TN = new TreeNode[1];
                for (int i = 1; i <= countnodes; i++)
                {

                    //if (countnodes != priviledgeUser.Length)
                    //{
                    //    clearAll();
                    //    return;
                    //}
                    if (i <= priviledgeUser.Length)
                    {
                        TN = tree1.Nodes.Find(i.ToString(), true);
                        if (TN.Length != 0)
                        {
                            if (priviledgeUser.Substring(i - 1, 1) == "M")
                                TN[0].Checked = true;
                            else if (priviledgeUser.Substring(i - 1, 1) == "T")
                                TN[0].Checked = false;
                        }
                    }
                    else
                    {
                        TN[0].Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }
        private void setData()
        {
            TreeNode[] TN = new TreeNode[1];
            priviledgeUser = "";
            for (int i = 1; i <= countnodes; i++)
            {
                TN = tree1.Nodes.Find(i.ToString(), true);
                if (TN.Length != 0)
                {
                    if (TN[0].Checked == true)
                        priviledgeUser = priviledgeUser + "M";
                    else
                        priviledgeUser = priviledgeUser + "T";
                }
                else
                {
                    priviledgeUser = priviledgeUser + "T";
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            tree1.Nodes[0].Checked = true;
            if (btnEdit.Text == "Edit")
            {
                groupBox3.Enabled = true;
                txtPassword.Enabled = true;
                txtRePassword.Enabled = true;
                btnEdit.Text = "Save";
                btnNew.Enabled = false;
                btnDelete.Enabled = false;
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
            }
            else if (btnEdit.Text == "Save")
            {
                if (txtRePassword.Text != txtPassword.Text)
                {
                    MessageBox.Show("Confirm Password Must the same to password", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                SqlConnection sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlcon.Open();
                setData();
                priviledgeUser = GeneralFunctions.Encrypt(priviledgeUser);
                pass = GeneralFunctions.Encrypt(txtPassword.Text);
                SqlCommand sqlcomm = new SqlCommand("Update Users Set Password='" + pass + "',Privilegde='" + priviledgeUser + "' , UserLanguage='" + comboBox_language.Text + "' WHERE UserName='" + txtUserName.Text + "'", sqlcon);
                int done = 0;
                done = sqlcomm.ExecuteNonQuery();
                if (done == 0)
                {
                    MessageBox.Show("Edit Failed");
                    return;
                }
                else
                {
                    MessageBox.Show("Edit Successfully");
                }
                groupBox3.Enabled = false;
                btnEdit.Text = "Edit";
                btnNew.Enabled = true;
                //btnDelete.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                //btnUndo_Click(sender, e);
                fillusers();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Text == "Delete")
            {
                btnDelete.Text = "Save";
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
            }
            else if (btnDelete.Text == "Save")
            {
                SqlConnection sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlcon.Open();
                SqlCommand sqlcomm = new SqlCommand("Delete From Users Where UserName='" + txtUserName.Text + "'", sqlcon);
                int done = 0;
                done = sqlcomm.ExecuteNonQuery();
                if (done == 0)
                {
                    MessageBox.Show("Delete Failed");
                    return;
                }
                else
                {
                    MessageBox.Show("Delete Successfully");
                }
                btnDelete.Text = "Delete";
                btnNew.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                //btnEdit.Enabled = true;
                btnUndo_Click(sender, e);
            }
        }
        private void movefirst()
        {
            DataRow dr;
            if (dbAccountingProjectDS1.Users.Rows.Count != 0)
            {
                dr = dbAccountingProjectDS1.Users.Rows[0];
                txtUserName.Text = dr["UserName"].ToString();
                pass = GeneralFunctions.Decrypt(dr["Password"].ToString());
                txtPassword.Text = pass;
                txtRePassword.Text = pass;
                priviledgeUser = dr["Privilegde"].ToString();
                priviledgeUser = GeneralFunctions.Decrypt(priviledgeUser);
                if (priviledgeUser.Trim() != "")
                {
                    ShowpriviledgeUser();
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
                comboBox_language.Text = dr["UserLanguage"].ToString();
            }
            else
            {
                MessageBox.Show("There was no users to view");
                return;
            }
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int idusers;
            DataRow[] drs;
            if (txtUserName.Text.Trim() == "")
            {
                movefirst();
            }
            drs = dbAccountingProjectDS1.Users.Select("UserName = '" + txtUserName.Text + "'", "UserID");
            if (drs.Length != 0)
            {
                idusers = int.Parse(drs[0]["UserID"].ToString());
                drs = dbAccountingProjectDS1.Users.Select("UserID < " + idusers + "", "UserID");
                if (drs.Length != 0)
                {
                    txtUserName.Text = drs[drs.Length - 1]["UserName"].ToString();
                    pass = GeneralFunctions.Decrypt(drs[drs.Length - 1]["Password"].ToString());
                    txtPassword.Text = pass;
                    txtRePassword.Text = pass;
                    priviledgeUser = drs[drs.Length - 1]["Privilegde"].ToString();
                    priviledgeUser = GeneralFunctions.Decrypt(priviledgeUser);
                    if (priviledgeUser.Trim() != "")
                    {
                        ShowpriviledgeUser();
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    comboBox_language.Text = drs[drs.Length - 1]["UserLanguage"].ToString();
                }
                else
                {
                    MessageBox.Show("This is first User");
                    return;
                }
            }

        }



        private void btnNext_Click(object sender, EventArgs e)
        {
            int idusers;
            DataRow[] drs;
            if (txtUserName.Text.Trim() == "")
            {
                movefirst();
            }
            drs = dbAccountingProjectDS1.Users.Select("UserName = '" + txtUserName.Text + "'", "UserID");
            if (drs.Length != 0)
            {
                idusers = int.Parse(drs[0]["UserID"].ToString());
                drs = dbAccountingProjectDS1.Users.Select("UserID > " + idusers + "", "UserID");
                if (drs.Length != 0)
                {
                    txtUserName.Text = drs[0]["UserName"].ToString();
                    pass = GeneralFunctions.Decrypt(drs[0]["Password"].ToString());
                    txtPassword.Text = pass;
                    txtRePassword.Text = pass;
                    priviledgeUser = drs[0]["Privilegde"].ToString();
                    priviledgeUser = GeneralFunctions.Decrypt(priviledgeUser);
                    if (priviledgeUser.Trim() != "")
                    {
                        ShowpriviledgeUser();
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    comboBox_language.Text = drs[0]["UserLanguage"].ToString();
                }
                else
                {
                    MessageBox.Show("This is Last User");
                    return;
                }
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                TreeNode[] TN = new TreeNode[1];
                for (int i = 1; i <= countnodes; i++)
                {
                    TN = tree1.Nodes.Find(i.ToString(), true);
                    TN[0].Checked = true;
                }
            }
            else
            {
                clearAll();
                tree1.Nodes[0].Checked = true;

            }
        }

        private void tree1_Click(object sender, EventArgs e)
        {
            tree1.Nodes[0].Checked = true;

        }


        private void tree1_KeyUp(object sender, KeyEventArgs e)
        {
            tree1.Nodes[0].Checked = true;

        }

        private void tree1_AfterCheck(object sender, TreeViewEventArgs e)
        {

            //if (e.Node.Name != "1")
            //{
            //    if (e.Node.Checked == true)
            //    {
            //        foreach (TreeNode no in e.Node.Nodes)
            //        {
            //            no.Checked = true;
            //        }
            //    }
            //    else
            //    {
            //        foreach (TreeNode no in e.Node.Nodes)
            //        {
            //            no.Checked = false;
            //        }
            //    }
            //}
        }


    }
}