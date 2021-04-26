using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Accounting_GeneralLedger
{
    public partial class Bank_Account_Setup : Form
    {
        private SqlConnection sqlcon;
        private SqlDataAdapter adapter;
        private SqlDataAdapter adaptertbGeneralSetup;
        private SqlDataAdapter adaptertbAccounts;
        private SqlCommandBuilder cmdBuilder;
        private int decmal = 1;
        private string Bank_GL_Account;
        private string Service_Charge_Account;
        private string Interest_Earned_Account;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;

        public Bank_Account_Setup()
        {
            InitializeComponent();
        }

        private void Bank_Account_Setup_Load(object sender, EventArgs e)
        {
            GeneralFunctions.priviledgeGroupBox(Lock88);
            GeneralFunctions.priviledgeGroupBox(Lock89);
            GeneralFunctions.priviledgeGroupBox(Lock90);
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adapter = new SqlDataAdapter("Select * from Bank_Account_Setup", sqlcon);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts", sqlcon);
            cmdBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(dbAccountingProjectDS.Bank_Account_Setup);
            adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            DataTable DtCat = DataClass.RetrieveData("Select TransCode,TransDesc From ARTransactionCodes ");
            cb_AR_Checks_Tran_code.DataSource = DtCat;
            cb_AR_Checks_Tran_code.DisplayMember = "TransDesc";
            cb_AR_Checks_Tran_code.ValueMember = "TransCode";
            cb_AR_Checks_Tran_code.SelectedIndex = -1;
            foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            {
                txt_Bank_GL_Account.Mask = dr["AccountNumberFormat"].ToString();
                txt_Service_Charge_Account.Mask = dr["AccountNumberFormat"].ToString();
                txt_Interest_Earned_Account.Mask = dr["AccountNumberFormat"].ToString();
                decmal = int.Parse(dr["DecimalPointsNumber"].ToString());
            }
            //currentBank_Account_ID = GeneralFunctions.Bank_Account_ID;
            //txt_Bank_Account_ID.Text = currentBank_Account_ID.ToString();
            if (GeneralFunctions.languagechioce != "")
            {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }
            if (!GeneralFunctions.SubTypesloaded)
            {
                SqlConnection sqlcon10 = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlcon10.Open();
                SqlCommand command10 = new SqlCommand("Select AccountSubType From  GeneralSetup", sqlcon10);
                SqlCommand command11 = new SqlCommand("Select FirstSub From GeneralSetup", sqlcon10);
                SqlCommand command12 = new SqlCommand("Select SecondSub From GeneralSetup", sqlcon10);
                SqlCommand command13 = new SqlCommand("Select ThirdSub From GeneralSetup", sqlcon10);
                SqlCommand command14 = new SqlCommand("Select FourthSub From GeneralSetup", sqlcon10);
                int AccountSubTypeNumber;
                if (command10.ExecuteScalar() != DBNull.Value)
                {
                    AccountSubTypeNumber = Convert.ToInt32(command10.ExecuteScalar());
                    if (AccountSubTypeNumber == 2)
                    {
                        GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()), Convert.ToInt32(command12.ExecuteScalar()));
                        GeneralFunctions.SubTypesloaded = true;
                    }
                    if (AccountSubTypeNumber == 3)
                    {
                        GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()), Convert.ToInt32(command12.ExecuteScalar()), Convert.ToInt32(command13.ExecuteScalar()));
                        GeneralFunctions.SubTypesloaded = true;
                    }
                    if (AccountSubTypeNumber == 4)
                    {
                        GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()), Convert.ToInt32(command12.ExecuteScalar()), Convert.ToInt32(command13.ExecuteScalar()), Convert.ToInt32(command14.ExecuteScalar()));
                        GeneralFunctions.SubTypesloaded = true;
                    }

                }
            }
        }
        private void update_language_interface()
        {
            //this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            //this.Text = obj_interface_language.formBank_Account_Setup;
            //this.lbl_Bank_Account_Name.Text = obj_interface_language.Bank_Account_ID;
            //this.lblBank_Account_Code.Text = obj_interface_language.DeliveryTypeName;
            //this.label3.Text = obj_interface_language.Percentage;
            //this.lbl_Bank_GL_Account.Text = obj_interface_language.labelGLAccountNumber;

            //this.btn_New.Text = obj_interface_language.buttonJVTransactionNew;
            //this.btnedit.Text = obj_interface_language.buttonJVTransactionEdit;
            //this.btndelete.Text = obj_interface_language.buttonJVTransactionDelete;
            //this.btnundo.Text = obj_interface_language.buttonJVTransactionUndo;
            //this.btnexit.Text = obj_interface_language.buttonJVTransactionExit;
            //this.btnSavenew.Text = obj_interface_language.buttonJVTransactionSaveNew;
            //this.Btnsaveedit.Text = obj_interface_language.buttonJVTransactionSaveEdit;
            //this.btn_Bank_GL_Account.Text = obj_interface_language.btnSearch;

            //this.dgv.Columns[0].HeaderText = obj_interface_language.dgvID;
            //this.dgv.Columns[1].HeaderText = obj_interface_language.dgvName;
        }
        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GeneralFunctions.ValidateString(txt_Bank_Account_Code.Text, "Please Enter a valid Bank Account Code")
                && GeneralFunctions.AccountNumberValidate(txt_Bank_GL_Account.Text, out Bank_GL_Account)
                && GeneralFunctions.AccountNumberValidate(txt_Service_Charge_Account.Text, out Service_Charge_Account)
                && GeneralFunctions.AccountNumberValidate(txt_Interest_Earned_Account.Text, out Interest_Earned_Account))
            {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select Bank_Account_ID from Bank_Account_Setup where Bank_Account_ID = '" + txt_Bank_Account_ID.Text + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("Bank_Account_ID = '" + txt_Bank_Account_ID.Text + "'", dbAccountingProjectDS.Bank_Account_Setup))
                {
                    DataRow r = dbAccountingProjectDS.Bank_Account_Setup.NewRow();
                    r["Bank_Account_ID"] = int.Parse(txt_Bank_Account_ID.Text);
                    r["Bank_Account_Code"] = txt_Bank_Account_Code.Text;
                    r["Bank_Account_Name"] = txt_Bank_Account_Name.Text;
                    r["Bank_GL_Account"] = txt_Bank_GL_Account.Text;
                    r["Service_Charge_Account"] = txt_Service_Charge_Account.Text;
                    r["Interest_Earned_Account"] = txt_Interest_Earned_Account.Text;
                    r["AR_Checks_Tran_code"] = cb_AR_Checks_Tran_code.SelectedValue.ToString();
                    r["Check_Format"] = txt_Check_Format.Text;
                    r["Deduction_Slip_Format"] = txt_Deduction_Slip_Format.Text;
                    dbAccountingProjectDS.Bank_Account_Setup.Rows.Add(r);
                    ClearAll();
                    dr.Close();
                    sqlcon.Close();
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Bank Account Code is already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.Bank_Account_Setup.Select("Bank_Account_ID = '" + txt_Bank_Account_ID.Text + "'");
                        rArr[0]["Bank_Account_Code"] = txt_Bank_Account_Code.Text;
                        rArr[0]["Bank_Account_Name"] = txt_Bank_Account_Name.Text;
                        rArr[0]["Bank_GL_Account"] = txt_Bank_GL_Account.Text;
                        rArr[0]["Service_Charge_Account"] = txt_Service_Charge_Account.Text;
                        rArr[0]["Interest_Earned_Account"] = txt_Interest_Earned_Account.Text;
                        rArr[0]["AR_Checks_Tran_code"] = cb_AR_Checks_Tran_code.SelectedValue.ToString();
                        rArr[0]["Check_Format"] = txt_Check_Format.Text;
                        rArr[0]["Deduction_Slip_Format"] = txt_Deduction_Slip_Format.Text;
                        ClearAll();
                    }
                    else
                    {
                        ClearAll();
                    }
                    dr.Close();
                    sqlcon.Close();
                }
                groupBox1.Enabled = false;
                btn_New.Visible = true;
                btnSavenew.Visible = false;
                SaveChanges();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (GeneralFunctions.ValidateString(txt_Bank_Account_Code.Text, "Please Enter a valid Bank Account Code")
                    && GeneralFunctions.AccountNumberValidate(txt_Bank_GL_Account.Text, out Bank_GL_Account)
                    && GeneralFunctions.AccountNumberValidate(txt_Service_Charge_Account.Text, out Service_Charge_Account)
                    && GeneralFunctions.AccountNumberValidate(txt_Interest_Earned_Account.Text, out Interest_Earned_Account))
                {
                    DataRow[] rArr = dbAccountingProjectDS.Bank_Account_Setup.Select("Bank_Account_ID = '" + txt_Bank_Account_ID.Text + "'");
                    rArr[0]["Bank_Account_Code"] = txt_Bank_Account_Code.Text;
                    rArr[0]["Bank_Account_Name"] = txt_Bank_Account_Name.Text;
                    rArr[0]["Bank_GL_Account"] = txt_Bank_GL_Account.Text;
                    rArr[0]["Service_Charge_Account"] = txt_Service_Charge_Account.Text;
                    rArr[0]["Interest_Earned_Account"] = txt_Interest_Earned_Account.Text;
                    rArr[0]["AR_Checks_Tran_code"] = cb_AR_Checks_Tran_code.SelectedValue.ToString();
                    rArr[0]["Check_Format"] = txt_Check_Format.Text;
                    rArr[0]["Deduction_Slip_Format"] = txt_Deduction_Slip_Format.Text;
                    //ClearAll();
                }
            }
            else
            {
                MessageBox.Show("Please Select the row that you want to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgv.ClearSelection();
            groupBox1.Enabled = false;
            btnedit.Visible = true;
            Btnsaveedit.Visible = false;
            btn_New.Enabled = true;
            btndelete.Enabled = false;
            btnedit.Enabled = false;
            SaveChanges();

        }

        private void ClearAll()
        {
            txt_Bank_Account_ID.Text = "";
            txt_Bank_Account_Code.Text = "";
            txt_Bank_Account_Name.Text = "";
            txt_Bank_GL_Account.Text = "";
            txt_Check_Format.Text = "";
            txt_Deduction_Slip_Format.Text = "";
            txt_Interest_Earned_Account.Text = "";
            txt_Service_Charge_Account.Text = "";
            cb_AR_Checks_Tran_code.SelectedIndex = -1;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                dbAccountingProjectDS.Bank_Account_Setup.Rows[dgv.SelectedRows[0].Index].Delete();
                ClearAll();
            }
            else
            {
                if (txt_Bank_Account_ID.Text != "")
                {
                    DataRow[] rArr = dbAccountingProjectDS.Bank_Account_Setup.Select("Bank_Account_ID = '" + txt_Bank_Account_ID.Text + "'");
                    if (rArr.Length != 0)
                    {
                        rArr[0].Delete();
                        ClearAll();
                    }
                    else
                    {
                        MessageBox.Show("The given Bank Account ID doesnt exist \n Cant perform delete operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            dgv.ClearSelection();
            SaveChanges();
            btnedit.Enabled = false;
            btndelete.Enabled = false;

        }

        private void SaveChanges()
        {
            adapter.Update(dbAccountingProjectDS.Bank_Account_Setup);
            dbAccountingProjectDS.AcceptChanges();
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            ClearAll();
            SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconBatch.Open();
            SqlCommand getBatch = new SqlCommand("Select Max(Bank_Account_ID)+1 From Bank_Account_Setup", sqlconBatch);
            if (getBatch.ExecuteScalar() != DBNull.Value)
            {
                txt_Bank_Account_ID.Text = getBatch.ExecuteScalar().ToString();
            }
            else
            {
                txt_Bank_Account_ID.Text = "1";
            }
            txt_Bank_Account_Code.Text = txt_Bank_Account_ID.Text;

            sqlconBatch.Close();
            groupBox1.Enabled = true;
            btn_New.Visible = false;
            btnSavenew.Visible = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
        }

        private void txt_AccountNumber_Leave(object sender, EventArgs e)
        {
            //DataRow[] drAC;
            //drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txt_AccountNumber.Text + "'");
            //if (drAC.Length == 0)
            //{
            //    MessageBox.Show("Check Account Number", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txt_AccountNumber.Focus();
            //}

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (groupBox1.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            this.Close();

        }

        private void btnundo_Click(object sender, EventArgs e)
        {
            if (sender.ToString() != "NO")
            {
                if (groupBox1.Enabled == true)
                {
                    DialogResult myrst;
                    myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (myrst == DialogResult.No)
                        return;
                }
            }
            ClearAll();
            btn_New.Visible = true;
            btnSavenew.Visible = false;
            btnedit.Visible = true;
            Btnsaveedit.Visible = false;
            groupBox1.Enabled = false;
            btn_New.Enabled = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult myrst;
            myrst = MessageBox.Show("Are You Sure Delete This Bank Account Setup", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return;
            deleteToolStripMenuItem_Click(sender, e);
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnedit.Visible = false;
            Btnsaveedit.Visible = true;
            btn_New.Enabled = false;
            btndelete.Enabled = false;
        }

        private void Btnsaveedit_Click(object sender, EventArgs e)
        {
            DataRow[] drAC;
            drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txt_Bank_GL_Account.Text + "'");
            if (drAC.Length == 0)
            {
                MessageBox.Show("Check Bank GL Account", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Bank_GL_Account.Focus();
                return;
            }
            drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txt_Service_Charge_Account.Text + "'");
            if (drAC.Length == 0)
            {
                MessageBox.Show("Check Service Charge Account", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Service_Charge_Account.Focus();
                return;
            }
            drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txt_Interest_Earned_Account.Text + "'");
            if (drAC.Length == 0)
            {
                MessageBox.Show("Check Interest Earned Account", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Interest_Earned_Account.Focus();
                return;
            }
            if (cb_AR_Checks_Tran_code.SelectedIndex < 0)
            {
                MessageBox.Show("Check AR Checks Transaction ", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            editToolStripMenuItem_Click(sender, e);
        }

        private void btnSavenew_Click(object sender, EventArgs e)
        {
            DataRow[] drAC;
            drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txt_Bank_GL_Account.Text + "'");
            if (drAC.Length == 0)
            {
                MessageBox.Show("Check Bank GL Account", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Bank_GL_Account.Focus();
                return;
            }
            drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txt_Service_Charge_Account.Text + "'");
            if (drAC.Length == 0)
            {
                MessageBox.Show("Check Service Charge Account", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Service_Charge_Account.Focus();
                return;
            }
            drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txt_Interest_Earned_Account.Text + "'");
            if (drAC.Length == 0)
            {
                MessageBox.Show("Check Interest Earned Account", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Interest_Earned_Account.Focus();
                return;
            }
            if (cb_AR_Checks_Tran_code.SelectedIndex < 0)
            {
                MessageBox.Show("Check AR Checks Transaction ", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            insertToolStripMenuItem_Click(sender, e);
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (groupBox1.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            btnundo_Click("NO", e);
            if (dgv.SelectedRows.Count > 0)
            {
                DataRow r = dbAccountingProjectDS.Bank_Account_Setup.Rows[dgv.SelectedRows[0].Index];
                txt_Bank_Account_ID.Text = r["Bank_Account_ID"].ToString();
                txt_Bank_Account_Code.Text = r["Bank_Account_Code"].ToString();
                txt_Bank_Account_Name.Text = r["Bank_Account_Name"].ToString();
                txt_Bank_GL_Account.Text = r["Bank_GL_Account"].ToString();
                txt_Service_Charge_Account.Text = r["Service_Charge_Account"].ToString();
                txt_Interest_Earned_Account.Text = r["Interest_Earned_Account"].ToString();
                cb_AR_Checks_Tran_code.SelectedValue = r["AR_Checks_Tran_code"].ToString();
                txt_Check_Format.Text = r["Check_Format"].ToString();
                txt_Deduction_Slip_Format.Text = r["Deduction_Slip_Format"].ToString();
                groupBox1.Enabled = false;
                btndelete.Enabled = true;
                btnedit.Enabled = true;
            }
        }

        private void groupBox1_EnabledChanged(object sender, EventArgs e)
        {
            if (groupBox1.Enabled == true)
                dgv.Enabled = false;
            else
                dgv.Enabled = true;
        }

        private void Lock90_Enter(object sender, EventArgs e)
        {

        }

        private void Lock88_Enter(object sender, EventArgs e)
        {

        }

        private void Lock89_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Service_Charge_Account_Click(object sender, EventArgs e)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.filter = " AND AccountTypeName <> 'Header'";
            accSearch.ShowDialog();
            if (accSearch.selectedAccountName != null)
            {
                txt_Service_Charge_Account.Text = accSearch.selectedAccountNumber.ToString();
            }
        }

        private void btn_Interest_Earned_Account_Click(object sender, EventArgs e)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.filter = " AND AccountTypeName <> 'Header'";
            accSearch.ShowDialog();
            if (accSearch.selectedAccountName != null)
            {
                txt_Interest_Earned_Account.Text = accSearch.selectedAccountNumber.ToString();
            }
        }

        private void btn_Bank_GL_Account_Click(object sender, EventArgs e)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.filter = " AND AccountTypeName <> 'Header'";
            accSearch.ShowDialog();
            if (accSearch.selectedAccountName != null)
            {
                txt_Bank_GL_Account.Text = accSearch.selectedAccountNumber.ToString();
            }
        }


    }
}