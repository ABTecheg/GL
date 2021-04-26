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
    public partial class Bank_Deposit_Type : Form
    {
        private SqlConnection sqlcon;
        private SqlDataAdapter adapter;
        private SqlDataAdapter adaptertbGeneralSetup;
        private SqlDataAdapter adaptertbAccounts;
        private SqlCommandBuilder cmdBuilder;
        private int decmal = 1;
        private string Acct_Deposit_From;
        private string CC_Discount_Acct;
        private string Cash_Short_Over_Acct;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;

        public Bank_Deposit_Type()
        {
            InitializeComponent();
        }

        private void Bank_Deposit_Type_Load(object sender, EventArgs e)
        {
            GeneralFunctions.priviledgeGroupBox(Lock88);
            GeneralFunctions.priviledgeGroupBox(Lock89);
            GeneralFunctions.priviledgeGroupBox(Lock90);
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adapter = new SqlDataAdapter("Select * from Bank_Deposit_Type", sqlcon);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts", sqlcon);
            cmdBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(dbAccountingProjectDS.Bank_Deposit_Type);
            adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            DataTable DtCat = DataClass.RetrieveData("Select Bank_Account_ID,Bank_Account_Name From Bank_Account_Setup ");
            cb_Bank_Account_ID.DataSource = DtCat;
            cb_Bank_Account_ID.DisplayMember = "Bank_Account_Name";
            cb_Bank_Account_ID.ValueMember = "Bank_Account_ID";
            cb_Bank_Account_ID.SelectedIndex = -1;
            foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            {
                txt_Acct_Deposit_From.Mask = dr["AccountNumberFormat"].ToString();
                txt_CC_Discount_Acct.Mask = dr["AccountNumberFormat"].ToString();
                txt_Cash_Short_Over_Acct.Mask = dr["AccountNumberFormat"].ToString();
                decmal = int.Parse(dr["DecimalPointsNumber"].ToString());
            }
            //currentBank_Deposit_Type_ID = GeneralFunctions.Bank_Deposit_Type_ID;
            //txt_Bank_Deposit_Type_ID.Text = currentBank_Deposit_Type_ID.ToString();
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
            //this.Text = obj_interface_language.formBank_Deposit_Type;
            //this.lbl_Bank_Deposit_Type_Name.Text = obj_interface_language.Bank_Deposit_Type_ID;
            //this.lblBank_Deposit_Type_Code.Text = obj_interface_language.DeliveryTypeName;
            //this.label3.Text = obj_interface_language.Percentage;
            //this.lbl_Acct_Deposit_From.Text = obj_interface_language.labelGLAccountNumber;

            //this.btn_New.Text = obj_interface_language.buttonJVTransactionNew;
            //this.btnedit.Text = obj_interface_language.buttonJVTransactionEdit;
            //this.btndelete.Text = obj_interface_language.buttonJVTransactionDelete;
            //this.btnundo.Text = obj_interface_language.buttonJVTransactionUndo;
            //this.btnexit.Text = obj_interface_language.buttonJVTransactionExit;
            //this.btnSavenew.Text = obj_interface_language.buttonJVTransactionSaveNew;
            //this.Btnsaveedit.Text = obj_interface_language.buttonJVTransactionSaveEdit;
            //this.btn_Acct_Deposit_From.Text = obj_interface_language.btnSearch;

            //this.dgv.Columns[0].HeaderText = obj_interface_language.dgvID;
            //this.dgv.Columns[1].HeaderText = obj_interface_language.dgvName;
        }
        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GeneralFunctions.ValidateString(txt_Bank_Deposit_Type_Code.Text, "Please Enter a valid Bank Account Code")
                && GeneralFunctions.AccountNumberValidate(txt_Acct_Deposit_From.Text, out Acct_Deposit_From))
            {
                if (!chkCredit_Card_Deposit.Checked)
                    if (!GeneralFunctions.AccountNumberValidate(txt_Cash_Short_Over_Acct.Text, out Cash_Short_Over_Acct))
                        return;

                if (chkCredit_Card_Deposit.Checked)
                    if (!GeneralFunctions.AccountNumberValidate(txt_CC_Discount_Acct.Text, out CC_Discount_Acct))
                        return;

                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select Bank_Deposit_Type_ID from Bank_Deposit_Type where Bank_Deposit_Type_ID = '" + txt_Bank_Deposit_Type_ID.Text + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("Bank_Deposit_Type_ID = '" + txt_Bank_Deposit_Type_ID.Text + "'", dbAccountingProjectDS.Bank_Deposit_Type))
                {
                    DataRow r = dbAccountingProjectDS.Bank_Deposit_Type.NewRow();
                    r["Bank_Deposit_Type_ID"] = int.Parse(txt_Bank_Deposit_Type_ID.Text);
                    r["Bank_Deposit_Type_Code"] = txt_Bank_Deposit_Type_Code.Text;
                    r["Bank_Deposit_Type_Name"] = txt_Bank_Deposit_Type_Name.Text;
                    r["Acct_Deposit_From"] = txt_Acct_Deposit_From.Text;
                    r["Credit_Card_Deposit"] = chkCredit_Card_Deposit.Checked;
                    double CC_Fees = 0; double.TryParse(txt_CC_Fees.Text, out CC_Fees);
                    if (chkCredit_Card_Deposit.Checked)
                    {
                        r["CC_Discount_Acct"] = txt_CC_Discount_Acct.Text;
                        r["CC_Fees"] = CC_Fees;
                        r["Override_Fees"] = chkOverride_Fees.Checked;
                        r["Cash_Short_Over_Acct"] = "";
                    }
                    else
                    {
                        r["CC_Discount_Acct"] = "";
                        r["CC_Fees"] = 0;
                        r["Override_Fees"] = false;
                        r["Cash_Short_Over_Acct"] = txt_Cash_Short_Over_Acct.Text;
                    }
                    r["Bank_Account_ID"] = cb_Bank_Account_ID.SelectedValue.ToString();
                    dbAccountingProjectDS.Bank_Deposit_Type.Rows.Add(r);
                    ClearAll();
                    dr.Close();
                    sqlcon.Close();
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Bank Deposit Type Code is already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.Bank_Deposit_Type.Select("Bank_Deposit_Type_ID = '" + txt_Bank_Deposit_Type_ID.Text + "'");
                        rArr[0]["Bank_Deposit_Type_Code"] = txt_Bank_Deposit_Type_Code.Text;
                        rArr[0]["Bank_Deposit_Type_Name"] = txt_Bank_Deposit_Type_Name.Text;
                        rArr[0]["Acct_Deposit_From"] = txt_Acct_Deposit_From.Text;
                        rArr[0]["Credit_Card_Deposit"] = chkCredit_Card_Deposit.Checked;
                        double CC_Fees = 0; double.TryParse(txt_CC_Fees.Text, out CC_Fees);
                        if (chkCredit_Card_Deposit.Checked)
                        {
                            rArr[0]["CC_Discount_Acct"] = txt_CC_Discount_Acct.Text;
                            rArr[0]["CC_Fees"] = CC_Fees;
                            rArr[0]["Override_Fees"] = chkOverride_Fees.Checked;
                            rArr[0]["Cash_Short_Over_Acct"] = "";
                        }
                        else
                        {
                            rArr[0]["CC_Discount_Acct"] = "";
                            rArr[0]["CC_Fees"] = 0;
                            rArr[0]["Override_Fees"] = false;
                            rArr[0]["Cash_Short_Over_Acct"] = txt_Cash_Short_Over_Acct.Text;
                        }
                        rArr[0]["Bank_Account_ID"] = cb_Bank_Account_ID.SelectedValue.ToString();
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
                if (GeneralFunctions.ValidateString(txt_Bank_Deposit_Type_Code.Text, "Please Enter a valid Bank Account Code")
                    && GeneralFunctions.AccountNumberValidate(txt_Acct_Deposit_From.Text, out Acct_Deposit_From))
                {
                    if (!chkCredit_Card_Deposit.Checked)
                        if (!GeneralFunctions.AccountNumberValidate(txt_Cash_Short_Over_Acct.Text, out Cash_Short_Over_Acct))
                            return;

                    if (chkCredit_Card_Deposit.Checked)
                        if (!GeneralFunctions.AccountNumberValidate(txt_CC_Discount_Acct.Text, out CC_Discount_Acct))
                            return;

                    DataRow[] rArr = dbAccountingProjectDS.Bank_Deposit_Type.Select("Bank_Deposit_Type_ID = '" + txt_Bank_Deposit_Type_ID.Text + "'");
                    rArr[0]["Bank_Deposit_Type_Code"] = txt_Bank_Deposit_Type_Code.Text;
                    rArr[0]["Bank_Deposit_Type_Name"] = txt_Bank_Deposit_Type_Name.Text;
                    rArr[0]["Acct_Deposit_From"] = txt_Acct_Deposit_From.Text;
                    rArr[0]["Credit_Card_Deposit"] = chkCredit_Card_Deposit.Checked;
                    double CC_Fees = 0; double.TryParse(txt_CC_Fees.Text, out CC_Fees);
                    if (chkCredit_Card_Deposit.Checked)
                    {
                        rArr[0]["CC_Discount_Acct"] = txt_CC_Discount_Acct.Text;
                        rArr[0]["CC_Fees"] = CC_Fees;
                        rArr[0]["Override_Fees"] = chkOverride_Fees.Checked;
                        rArr[0]["Cash_Short_Over_Acct"] = "";
                    }
                    else
                    {
                        rArr[0]["CC_Discount_Acct"] = "";
                        rArr[0]["CC_Fees"] = 0;
                        rArr[0]["Override_Fees"] = false;
                        rArr[0]["Cash_Short_Over_Acct"] = txt_Cash_Short_Over_Acct.Text;
                    }
                    rArr[0]["Bank_Account_ID"] = cb_Bank_Account_ID.SelectedValue.ToString();
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
            txt_Bank_Deposit_Type_ID.Text = "";
            txt_Bank_Deposit_Type_Code.Text = "";
            txt_Bank_Deposit_Type_Name.Text = "";
            txt_Acct_Deposit_From.Text = "";
            txt_CC_Fees.Text = "0";
            chkCredit_Card_Deposit.Checked = false;
            chkOverride_Fees.Checked = false;
            txt_Cash_Short_Over_Acct.Text = "";
            txt_CC_Discount_Acct.Text = "";
            cb_Bank_Account_ID.SelectedIndex = -1;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                dbAccountingProjectDS.Bank_Deposit_Type.Rows[dgv.SelectedRows[0].Index].Delete();
                ClearAll();
            }
            else
            {
                if (txt_Bank_Deposit_Type_ID.Text != "")
                {
                    DataRow[] rArr = dbAccountingProjectDS.Bank_Deposit_Type.Select("Bank_Deposit_Type_ID = '" + txt_Bank_Deposit_Type_ID.Text + "'");
                    if (rArr.Length != 0)
                    {
                        rArr[0].Delete();
                        ClearAll();
                    }
                    else
                    {
                        MessageBox.Show("The given Bank Deposit Type ID doesnt exist \n Cant perform delete operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            adapter.Update(dbAccountingProjectDS.Bank_Deposit_Type);
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
            SqlCommand getBatch = new SqlCommand("Select Max(Bank_Deposit_Type_ID)+1 From Bank_Deposit_Type", sqlconBatch);
            if (getBatch.ExecuteScalar() != DBNull.Value)
            {
                txt_Bank_Deposit_Type_ID.Text = getBatch.ExecuteScalar().ToString();
            }
            else
            {
                txt_Bank_Deposit_Type_ID.Text = "1";
            }
            txt_Bank_Deposit_Type_Code.Text = txt_Bank_Deposit_Type_ID.Text;

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
            drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txt_Acct_Deposit_From.Text + "'");
            if (drAC.Length == 0)
            {
                MessageBox.Show("Check Deposit From Account", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Acct_Deposit_From.Focus();
                return;
            }
            drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txt_CC_Discount_Acct.Text + "'");
            if (drAC.Length == 0 && chkCredit_Card_Deposit.Checked)
            {
                MessageBox.Show("Check CC Discount Account", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_CC_Discount_Acct.Focus();
                return;
            }
            drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txt_Cash_Short_Over_Acct.Text + "'");
            if (drAC.Length == 0 && !chkCredit_Card_Deposit.Checked)
            {
                MessageBox.Show("Check Cash_Short_Over Account", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Cash_Short_Over_Acct.Focus();
                return;
            }
            if (cb_Bank_Account_ID.SelectedIndex < 0)
            {
                MessageBox.Show("Check AR Checks Transaction ", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            editToolStripMenuItem_Click(sender, e);
        }

        private void btnSavenew_Click(object sender, EventArgs e)
        {
            DataRow[] drAC;
            drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txt_Acct_Deposit_From.Text + "'");
            if (drAC.Length == 0)
            {
                MessageBox.Show("Check Bank GL Account", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Acct_Deposit_From.Focus();
                return;
            }
            drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txt_CC_Discount_Acct.Text + "'");
            if (drAC.Length == 0 && chkCredit_Card_Deposit.Checked)
            {
                MessageBox.Show("Check Service Charge Account", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_CC_Discount_Acct.Focus();
                return;
            }
            drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txt_Cash_Short_Over_Acct.Text + "'");
            if (drAC.Length == 0 && !chkCredit_Card_Deposit.Checked)
            {
                MessageBox.Show("Check Interest Earned Account", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Cash_Short_Over_Acct.Focus();
                return;
            }
            if (cb_Bank_Account_ID.SelectedIndex < 0)
            {
                MessageBox.Show("Check Bank ", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DataRow r = dbAccountingProjectDS.Bank_Deposit_Type.Rows[dgv.SelectedRows[0].Index];
                txt_Bank_Deposit_Type_ID.Text = r["Bank_Deposit_Type_ID"].ToString();
                txt_Bank_Deposit_Type_Code.Text = r["Bank_Deposit_Type_Code"].ToString();
                txt_Bank_Deposit_Type_Name.Text = r["Bank_Deposit_Type_Name"].ToString();
                txt_Acct_Deposit_From.Text = r["Acct_Deposit_From"].ToString();
                chkCredit_Card_Deposit.Checked = (bool)r["Credit_Card_Deposit"];
                chkOverride_Fees.Checked = (bool)r["Override_Fees"];
                txt_CC_Discount_Acct.Text = r["CC_Discount_Acct"].ToString();
                txt_Cash_Short_Over_Acct.Text = r["Cash_Short_Over_Acct"].ToString();
                cb_Bank_Account_ID.SelectedValue = r["Bank_Account_ID"].ToString();
                txt_CC_Fees.Text = r["CC_Fees"].ToString();
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

        private void btn_CC_Discount_Acct_Click(object sender, EventArgs e)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.filter = " AND AccountTypeName <> 'Header'";
            accSearch.ShowDialog();
            if (accSearch.selectedAccountName != null)
            {
                txt_CC_Discount_Acct.Text = accSearch.selectedAccountNumber.ToString();
            }
        }

        private void btn_Cash_Short_Over_Acct_Click(object sender, EventArgs e)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.filter = " AND AccountTypeName <> 'Header'";
            accSearch.ShowDialog();
            if (accSearch.selectedAccountName != null)
            {
                txt_Cash_Short_Over_Acct.Text = accSearch.selectedAccountNumber.ToString();
            }
        }

        private void btn_Acct_Deposit_From_Click(object sender, EventArgs e)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.filter = " AND AccountTypeName <> 'Header'";
            accSearch.ShowDialog();
            if (accSearch.selectedAccountName != null)
            {
                txt_Acct_Deposit_From.Text = accSearch.selectedAccountNumber.ToString();
            }
        }

        private void chkCredit_Card_Deposit_CheckedChanged(object sender, EventArgs e)
        {
            lbl_CC_Discount_Acct.Visible = chkCredit_Card_Deposit.Checked;
            lbl_CC_Fees.Visible = chkCredit_Card_Deposit.Checked;
            txt_CC_Discount_Acct.Visible = chkCredit_Card_Deposit.Checked;
            txt_CC_Fees.Visible = chkCredit_Card_Deposit.Checked;
            btn_CC_Discount_Acct.Visible = chkCredit_Card_Deposit.Checked;
            chkOverride_Fees.Visible = chkCredit_Card_Deposit.Checked;
       
            lbl_Cash_Short_Over_Acct.Visible = !chkCredit_Card_Deposit.Checked;
            txt_Cash_Short_Over_Acct.Visible = !chkCredit_Card_Deposit.Checked;
            btn_Cash_Short_Over_Acct.Visible = !chkCredit_Card_Deposit.Checked;
        }

        private void txt_CC_Fees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                if (txt_CC_Fees.Text.Contains("."))
                {
                    char c = '.';
                    string[] sc = txt_CC_Fees.Text.Split(c);

                    if (sc[1].Length < decmal)
                        e.Handled = false;
                    else
                        e.Handled = true;

                }
                else
                    e.Handled = false;

            }
            else if (e.KeyChar == 46)
            {
                if (txt_CC_Fees.Text.Contains(".") == false)
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            else
                e.Handled = true;
        }


    }
}