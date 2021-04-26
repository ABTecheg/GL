using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Collections;

namespace Accounting_GeneralLedger
{
    public partial class AccountsDefinition : Form
    {
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbAccounts;
        private SqlDataAdapter adaptertbAccountTypes;
        private SqlDataAdapter adaptertbGLTotals;
        private SqlDataAdapter adaptertbG_L_GeneralSetup;
        private SqlDataAdapter adaptertbGeneralSetup;
        private SqlCommandBuilder cmdBuilderAccounts;
        private SqlCommandBuilder cmdBuilderGLTotals;
        private SqlCommandBuilder cmdBuilderGeneralSetup;
        private SqlDataAdapter adapterGLBudget;
        private string oldName;
        private string AccountNumber;
        private double openingBalance;
        private int currentTotalID;
        private int decmal = 1;
        //private string AccountNumberFormat;
        private string tempAccountNumber;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;

        public AccountsDefinition()
        {
            InitializeComponent();
        }

        private void ChartOfAccounts_Load(object sender, EventArgs e)
        {
            GeneralFunctions.priviledgeGroupBox(Lock38);
            GeneralFunctions.priviledgeGroupBox(Lock39);
            GeneralFunctions.priviledgeGroupBox(Lock40);
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts", sqlcon);
            adaptertbG_L_GeneralSetup = new SqlDataAdapter("Select * from G_L_GeneralSetup", sqlcon);
            adaptertbAccountTypes = new SqlDataAdapter("Select * from GLAccountTypes", sqlcon);
            adapterGLBudget = new SqlDataAdapter("Select * From GLBudget", sqlcon);
            adapterGLBudget.Fill(dbAccountingProjectDS.GLBudget);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbGLTotals = new SqlDataAdapter("Select * from GLTotals", sqlcon);
            cmdBuilderGLTotals = new SqlCommandBuilder(adaptertbGLTotals);
            adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
            adaptertbG_L_GeneralSetup.Fill(dbAccountingProjectDS.G_L_GeneralSetup);
            cmdBuilderAccounts = new SqlCommandBuilder(adaptertbAccounts);
            cmdBuilderGeneralSetup = new SqlCommandBuilder(adaptertbGeneralSetup);


            adaptertbAccountTypes.Fill(dbAccountingProjectDS.GLAccountTypes);
            adaptertbGLTotals.Fill(dbAccountingProjectDS.GLTotals);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);

            dgv.ClearSelection();
            cb_AccountTypes = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLAccountTypes, cb_AccountTypes, "AccountTypeName", "AccountTypeID");
            cb_AccountTypes.Items.Remove("<new>");


            //foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            //{
            //    AccountNumberFormat = dr["AccountNumberFormat"].ToString();
            //    decmal = int.Parse(dr["DecimalPointsNumber"].ToString());
            //}
            //txtAccountNumbers.Mask = AccountNumberFormat;// "###-####-##";
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
            cb_AccountTypes.SelectedIndex = -1;
            currentTotalID = GeneralFunctions.TotalID;
            Gb1.Enabled = false;
            if (GeneralFunctions.languagechioce != "")
            {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }

            btn_Edit.Enabled = false;
            btnDelete.Enabled = false;
            InputLanguageChanged += new InputLanguageChangedEventHandler(txtAR_InputLanguageChanged);

        }
        void txtAR_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        {
            if (txt_AccountARName.Focused == true && InputLanguage.CurrentInputLanguage.Culture.Name != "ar-EG")
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.GetCultureInfoByIetfLanguageTag("ar-EG"));
        }
        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.formAccountsDefinition;
            this.dgv.Columns[1].HeaderText = obj_interface_language.dgvAccountDefinitionColumn1.ToString();
            this.dgv.Columns[2].HeaderText = obj_interface_language.dgvAccountDefinitionColumn2.ToString();
            this.btn_New.Text = obj_interface_language.buttonbtnNew;
            this.btn_Edit.Text = obj_interface_language.buttonbtnEdit;
            this.btnDelete.Text = obj_interface_language.buttonbtnDelete;
            this.btnUndo.Text = obj_interface_language.buttonbtnUndo;
            this.btnExit.Text = obj_interface_language.buttonCompanyExit;
            this.label1.Text = obj_interface_language.labelAccountType;
            this.label2.Text = obj_interface_language.labelAccountNumber;
            this.label5.Text = obj_interface_language.labelAccountName;
            this.label4.Text = obj_interface_language.labelOpeningBalance;
            this.label3.Text = obj_interface_language.labelStatus;
            this.checkBox_Active.Text = obj_interface_language.checkboxActive;
            this.btnSavenew.Text = obj_interface_language.buttonJVTransactionSaveNew;
            this.Btnsaveedit.Text = obj_interface_language.buttonJVTransactionSaveEdit;

        }

        //private void btn_SaveChanges_Click(object sender, EventArgs e) {
        //    adaptertbAccounts.Update(dbAccountingProjectDS.GLAccounts);
        //    adaptertbGLTotals.Update(dbAccountingProjectDS.GLTotals);
        //    dbAccountingProjectDS.AcceptChanges();
        //}

        private bool AccountNumberValidate()
        {
            bool valid = true;
            int i = 0;
            if (txtAccountNumbers.Text != "")
            {
                if (GeneralFunctions.FindCharacter(txtAccountNumbers.Text, '-'))
                {
                    string[] arrInputAccountNumber = txtAccountNumbers.Text.Split('-');
                    string[] arrAccountNumberFormat = GeneralFunctions.AccountNumberFormat.Split('-');
                    if (arrInputAccountNumber.Length == GeneralFunctions.NoOfSubtypes)
                    {
                        foreach (string s in arrInputAccountNumber)
                        {
                            if (s.Length == arrAccountNumberFormat[i].Length)
                            {
                                if (!GeneralFunctions.CheckSubstring(s))
                                {
                                    errorProvider1.SetError(txtAccountNumbers, "The Account Number can only contain numeric characters\n " +
                                                         "Please enter valid characters");
                                    valid = false;
                                }
                                i++;
                            }
                            else
                                valid = false;
                        }
                        if (valid)
                        {
                            errorProvider1.SetError(txtAccountNumbers, "");
                            AccountNumber = txtAccountNumbers.Text;
                        }
                    }
                    else
                        valid = false;
                }
                else
                {
                    if (txtAccountNumbers.Text.Length == GeneralFunctions.AccountNumberLenght)
                    {
                        if (GeneralFunctions.CheckSubstring(txtAccountNumbers.Text))
                        {
                            AccountNumber = GeneralFunctions.CreateAccountNumberFormat(txtAccountNumbers.Text);
                            errorProvider1.SetError(txtAccountNumbers, "");
                        }
                        else
                        {
                            errorProvider1.SetError(txtAccountNumbers, "The Account Number can only contain numeric characters\n " +
                                                        "Please enter valid characters");
                            valid = false;
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txtAccountNumbers, "Please Insert a account number compatitable to the given account number format '" + GeneralFunctions.AccountNumberFormat + "'");
                        valid = false;
                    }
                }
            }
            else
                valid = false;
            if (!valid)
                errorProvider1.SetError(txtAccountNumbers, "Please Insert a account number compatitable to the given account number format '" + GeneralFunctions.AccountNumberFormat + "'");
            return valid;
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccountNumberValidate() && GeneralFunctions.ValidateString(txt_AccountName.Text, "Please Specify the Account Name")
                && GeneralFunctions.ValidateDouble(txt_OpeningBalance.Text, "Please Specify the Opening Balance", out openingBalance) &&
                GeneralFunctions.ValidateComboBox(cb_AccountTypes, "Please Specify the Account Type"))
            {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select AccountNumber from GLAccounts where AccountNumber = '" + AccountNumber + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("AccountNumber = '" + AccountNumber + "'", dbAccountingProjectDS.GLAccounts))
                {
                    DataRow r = dbAccountingProjectDS.GLAccounts.NewRow();
                    r["AccountNumber"] = AccountNumber;
                    r["AccountName"] = txt_AccountName.Text;
                    r["AccountNameArabic"] = txt_AccountARName.Text;
                    r["AccountTypeName"] = cb_AccountTypes.Text;
                    r["Active"] = checkBox_Active.Checked;
                    r["OpeningBalance"] = openingBalance;
                    r["SubLvl"] = ChkSubLvl.Checked;
                    dbAccountingProjectDS.GLAccounts.Rows.Add(r);
                    AddGLTotalRow();
                    dr.Close();
                    sqlcon.Close();
                    ClearAll();
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Account Number already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + AccountNumber + "'");
                        rArr[0]["AccountName"] = txt_AccountName.Text;
                        rArr[0]["AccountNameArabic"] = txt_AccountARName.Text;
                        rArr[0]["AccountTypeName"] = cb_AccountTypes.Text;
                        rArr[0]["Active"] = checkBox_Active.Checked;
                        rArr[0]["SubLvl"] = ChkSubLvl.Checked;
                        if (double.Parse(rArr[0]["OpeningBalance"].ToString()) != openingBalance)
                            MessageBox.Show("Cant Edit the openning balance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearAll();
                    }
                    else
                    {
                        cb_AccountTypes.Text = "";
                        txt_AccountName.Text = "";
                        txtAccountNumbers.Text = "";
                        checkBox_Active.Checked = false;
                        ChkSubLvl.Checked = false;
                        txt_OpeningBalance.Text = "";
                    }
                    dr.Close();
                    sqlcon.Close();
                }
            }
        }

        private void AddGLTotalRow()
        {
            try
            {
                SqlConnection mainsqlconn = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand mainsqlcomm = new SqlCommand("Select Distinct YEAR(PeriodStartDate) From GLFiscalPeriod where Status = 'OPEN'", mainsqlconn);
                mainsqlconn.Open();
                SqlDataReader read = mainsqlcomm.ExecuteReader();
                if (read.HasRows)
                {
                    int StartYear = 0;
                    while (read.Read())
                    {
                        if (StartYear == 0)
                            StartYear = read.GetInt32(0);
                        DataRow r = dbAccountingProjectDS.GLTotals.NewRow();
                        SqlConnection sq = new SqlConnection(GeneralFunctions.ConnectionString);
                        sq.Open();
                        if (dbAccountingProjectDS.GLTotals.Rows.Count != 0)
                        {
                            SqlCommand sqcommand = new SqlCommand("Select max(TotalID)+1 From GLTotals", sq);
                            GeneralFunctions.TotalID = Convert.ToInt32(sqcommand.ExecuteScalar());
                            currentTotalID = GeneralFunctions.TotalID;
                        }
                        else { currentTotalID = 1; }
                        if (read.GetInt32(0) == StartYear)
                        {
                            r["TotalID"] = currentTotalID;
                            r["AccountNumber"] = AccountNumber;
                            r["FiscalYear"] = read.GetInt32(0);
                            r["BeginningBalance"] = openingBalance;
                            r["PeriodBalance1"] = openingBalance;
                            if (CheckPeriod(1, StartYear))
                            {
                                r["PeriodBalance1"] = 0;
                                r["PeriodBalance2"] = openingBalance;
                            }
                            else
                                r["PeriodBalance2"] = 0;
                            if (CheckPeriod(2, StartYear))
                            {
                                r["PeriodBalance1"] = 0;
                                r["PeriodBalance2"] = 0;
                                r["PeriodBalance3"] = openingBalance;
                            }
                            else
                                r["PeriodBalance3"] = 0;
                            if (CheckPeriod(3, StartYear))
                            {
                                r["PeriodBalance1"] = 0;
                                r["PeriodBalance2"] = 0;
                                r["PeriodBalance3"] = 0;
                                r["PeriodBalance4"] = openingBalance;
                            }
                            else
                                r["PeriodBalance4"] = 0;
                            if (CheckPeriod(4, StartYear))
                            {
                                r["PeriodBalance1"] = 0;
                                r["PeriodBalance2"] = 0;
                                r["PeriodBalance3"] = 0;
                                r["PeriodBalance4"] = 0;
                                r["PeriodBalance5"] = openingBalance;
                            }
                            else
                                r["PeriodBalance5"] = 0;
                            if (CheckPeriod(5, StartYear))
                            {
                                r["PeriodBalance1"] = 0;
                                r["PeriodBalance2"] = 0;
                                r["PeriodBalance3"] = 0;
                                r["PeriodBalance4"] = 0;
                                r["PeriodBalance5"] = 0;
                                r["PeriodBalance6"] = openingBalance;
                            }
                            else
                                r["PeriodBalance6"] = 0;
                            if (CheckPeriod(6, StartYear))
                            {
                                r["PeriodBalance1"] = 0;
                                r["PeriodBalance2"] = 0;
                                r["PeriodBalance3"] = 0;
                                r["PeriodBalance4"] = 0;
                                r["PeriodBalance5"] = 0;
                                r["PeriodBalance6"] = 0;
                                r["PeriodBalance7"] = openingBalance;
                            }
                            else
                                r["PeriodBalance7"] = 0;
                            if (CheckPeriod(7, StartYear))
                            {
                                r["PeriodBalance1"] = 0;
                                r["PeriodBalance2"] = 0;
                                r["PeriodBalance3"] = 0;
                                r["PeriodBalance4"] = 0;
                                r["PeriodBalance5"] = 0;
                                r["PeriodBalance6"] = 0;
                                r["PeriodBalance7"] = 0;
                                r["PeriodBalance8"] = openingBalance;
                            }
                            else
                                r["PeriodBalance8"] = 0;
                            if (CheckPeriod(8, StartYear))
                            {
                                r["PeriodBalance1"] = 0;
                                r["PeriodBalance2"] = 0;
                                r["PeriodBalance3"] = 0;
                                r["PeriodBalance4"] = 0;
                                r["PeriodBalance5"] = 0;
                                r["PeriodBalance6"] = 0;
                                r["PeriodBalance7"] = 0;
                                r["PeriodBalance8"] = 0;
                                r["PeriodBalance9"] = openingBalance;
                            }
                            else
                                r["PeriodBalance9"] = 0;
                            if (CheckPeriod(9, StartYear))
                            {
                                r["PeriodBalance1"] = 0;
                                r["PeriodBalance2"] = 0;
                                r["PeriodBalance3"] = 0;
                                r["PeriodBalance4"] = 0;
                                r["PeriodBalance5"] = 0;
                                r["PeriodBalance6"] = 0;
                                r["PeriodBalance7"] = 0;
                                r["PeriodBalance8"] = 0;
                                r["PeriodBalance9"] = 0;
                                r["PeriodBalance10"] = openingBalance;
                            }
                            else
                                r["PeriodBalance10"] = 0;
                            if (CheckPeriod(10, StartYear))
                            {
                                r["PeriodBalance1"] = 0;
                                r["PeriodBalance2"] = 0;
                                r["PeriodBalance3"] = 0;
                                r["PeriodBalance4"] = 0;
                                r["PeriodBalance5"] = 0;
                                r["PeriodBalance6"] = 0;
                                r["PeriodBalance7"] = 0;
                                r["PeriodBalance8"] = 0;
                                r["PeriodBalance9"] = 0;
                                r["PeriodBalance10"] = 0;
                                r["PeriodBalance11"] = openingBalance;
                            }
                            else
                                r["PeriodBalance11"] = 0;
                            if (CheckPeriod(11, StartYear))
                            {
                                r["PeriodBalance1"] = 0;
                                r["PeriodBalance2"] = 0;
                                r["PeriodBalance3"] = 0;
                                r["PeriodBalance4"] = 0;
                                r["PeriodBalance5"] = 0;
                                r["PeriodBalance6"] = 0;
                                r["PeriodBalance7"] = 0;
                                r["PeriodBalance8"] = 0;
                                r["PeriodBalance9"] = 0;
                                r["PeriodBalance10"] = 0;
                                r["PeriodBalance11"] = 0;
                                r["PeriodBalance12"] = openingBalance;
                            }
                            else
                                r["PeriodBalance12"] = 0;
                            if (CheckPeriod(12, StartYear))
                            {
                                r["PeriodBalance1"] = 0;
                                r["PeriodBalance2"] = 0;
                                r["PeriodBalance3"] = 0;
                                r["PeriodBalance4"] = 0;
                                r["PeriodBalance5"] = 0;
                                r["PeriodBalance6"] = 0;
                                r["PeriodBalance7"] = 0;
                                r["PeriodBalance8"] = 0;
                                r["PeriodBalance9"] = 0;
                                r["PeriodBalance10"] = 0;
                                r["PeriodBalance11"] = 0;
                                r["PeriodBalance12"] = 0;
                                r["PeriodBalance13"] = openingBalance;
                            }
                            else
                                r["PeriodBalance13"] = 0;
                            r["PeriodBalance99"] = 0;
                        }
                        else
                        {
                            r["TotalID"] = currentTotalID;
                            r["AccountNumber"] = AccountNumber;
                            r["FiscalYear"] = read.GetInt32(0);
                            r["BeginningBalance"] = 0;
                            r["PeriodBalance1"] = 0;
                            r["PeriodBalance2"] = 0;
                            r["PeriodBalance3"] = 0;
                            r["PeriodBalance4"] = 0;
                            r["PeriodBalance5"] = 0;
                            r["PeriodBalance6"] = 0;
                            r["PeriodBalance7"] = 0;
                            r["PeriodBalance8"] = 0;
                            r["PeriodBalance9"] = 0;
                            r["PeriodBalance10"] = 0;
                            r["PeriodBalance11"] = 0;
                            r["PeriodBalance12"] = 0;
                            r["PeriodBalance13"] = 0;
                            r["PeriodBalance99"] = 0;
                        }
                        dbAccountingProjectDS.GLTotals.Rows.Add(r);
                        //r.c;
                        sq.Close();
                        cmdBuilderGLTotals.DataAdapter = adaptertbGLTotals;
                        adaptertbGLTotals.Update(dbAccountingProjectDS.GLTotals);
                        dbAccountingProjectDS.AcceptChanges();

                    }

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool CheckPeriod(int prd, int Year)
        {
            bool flage = false;
            string stats = "";
            SqlConnection mycon = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand mycom = new SqlCommand("select Status from GLFiscalPeriod where PeriodNumber = '" + prd + "' and Year(PeriodStartDate) = " + Year + "", mycon);
            mycon.Open();
            stats = mycom.ExecuteScalar().ToString();
            if (stats == "CLOSED")
                flage = true;
            mycon.Close();
            return flage;
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (GeneralFunctions.AccountNumberValidate(txtAccountNumbers.Text, out AccountNumber) &&
                 GeneralFunctions.ValidateString(txt_AccountName.Text, "Please Specify the Account Name")
                 && GeneralFunctions.ValidateDouble(txt_OpeningBalance.Text, "Please Specify the Opening Balance", out openingBalance) &&
                 GeneralFunctions.ValidateComboBox(cb_AccountTypes, "Please Specify the Account Type"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + AccountNumber + "'");
                    rArr[0]["AccountName"] = txt_AccountName.Text;
                    rArr[0]["AccountNameArabic"] = txt_AccountARName.Text;
                    rArr[0]["AccountTypeName"] = cb_AccountTypes.Text;
                    if (double.Parse(rArr[0]["OpeningBalance"].ToString()) != openingBalance)
                        MessageBox.Show("Cant Edit the openning balance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rArr[0]["Active"] = checkBox_Active.Checked;
                    rArr[0]["SubLvl"] = ChkSubLvl.Checked;
                    ClearAll();
                }
            }
            else
            {
                MessageBox.Show("Please Select the row that you want to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgv.ClearSelection();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                dbAccountingProjectDS.GLAccounts.Rows[dgv.SelectedRows[0].Index].Delete();
                ClearAll();
            }
            else
            {
                if (txtAccountNumbers.Text != "" && GeneralFunctions.AccountNumberValidate(txtAccountNumbers.Text, out AccountNumber))
                {
                    DataRow[] rArr = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + AccountNumber + "'");
                    if (rArr.Length != 0)
                    {
                        rArr[0].Delete();
                        ClearAll();
                    }
                    else
                    {
                        MessageBox.Show("The given Account Number doesnt exist \n Cant perform delete operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            dgv.ClearSelection();
        }

        private void ClearAll()
        {
            txtAccountNumbers.Text = "";
            txt_AccountName.Text = "";
            cb_AccountTypes.SelectedIndex = -1;
            txt_OpeningBalance.Text = "";
            checkBox_Active.Checked = false;
            ChkSubLvl.Checked = false;
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {

            if (dgv.SelectedRows.Count > 0)
            {
                DataRow r = dbAccountingProjectDS.GLAccounts.Rows[dgv.SelectedRows[0].Index];
                txtAccountNumbers.Text = r["AccountNumber"].ToString();
                txt_AccountName.Text = r["AccountName"].ToString();
                txt_AccountARName.Text = r["AccountNameArabic"].ToString();
                oldName = r["AccountName"].ToString();
                txt_OpeningBalance.Text = r["OpeningBalance"].ToString();
                cb_AccountTypes.Text = r["AccountTypeName"].ToString();
                checkBox_Active.Checked = (bool)r["Active"];
                ChkSubLvl.Checked = (bool)r["SubLvl"];
                btn_Edit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }


        private void ConfirmDelete()
        {
            if (dgv.SelectedRows.Count > 0)
            {
                dbAccountingProjectDS.GLAccounts.Rows[dgv.SelectedRows[0].Index].Delete();
                ClearAll();
            }
            else
            {
                if (txtAccountNumbers.Text != "")
                {
                    DataRow[] rArr = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txtAccountNumbers.Text + "'");
                    if (rArr.Length != 0)
                    {
                        rArr[0].Delete();
                        ClearAll();
                    }
                    else
                    {
                        MessageBox.Show("The given Account Number doesnt exist \n Cant perform delete operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            dgv.ClearSelection();
            adaptertbAccounts.Update(dbAccountingProjectDS.GLAccounts);
            adaptertbGLTotals.Update(dbAccountingProjectDS.GLTotals);
            dbAccountingProjectDS.AcceptChanges();
            cb_AccountTypes.Text = "";
            txt_AccountName.Text = "";
            txtAccountNumbers.Text = "";
            checkBox_Active.Checked = false;
            ChkSubLvl.Checked = false;
            txt_OpeningBalance.Text = "";
            btn_Edit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Gb1.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            this.Close();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {

            if (sender.ToString() != "NO")
            {
                if (Gb1.Enabled == true)
                {
                    DialogResult myrst;
                    myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (myrst == DialogResult.No)
                        return;
                }
            }
            btn_New.Visible = true;
            btnSavenew.Visible = false;
            btn_Edit.Visible = true;
            Btnsaveedit.Visible = false;
            Gb1.Enabled = false;
            btn_New.Enabled = true;
            btn_Edit.Enabled = false;
            btnDelete.Enabled = false;
            cb_AccountTypes.Text = "";
            txt_AccountName.Text = "";
            txt_AccountARName.Text = "";
            txtAccountNumbers.Text = "";
            checkBox_Active.Checked = false;
            ChkSubLvl.Checked = false;
            txt_OpeningBalance.Text = "";
            dgv.ClearSelection();
            txtAccountNumbers.Enabled = true;
        }

        private void cb_AccountTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_AccountTypes.Text == "<new>")
            {
                AccountTypes accDef = new AccountTypes();
                accDef.ShowDialog();
                cb_AccountTypes.Items.Clear();
                adaptertbAccountTypes.Fill(dbAccountingProjectDS.GLAccountTypes);
                cb_AccountTypes = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLAccountTypes, cb_AccountTypes, "AccountTypeName", "AccountTypeID");
            }
            else if (cb_AccountTypes.Text == "Header")
            {
                txt_OpeningBalance.Text = "0";
                txt_OpeningBalance.Enabled = false;
            }
            else
                txt_OpeningBalance.Enabled = true;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtAccountNumbers_Enter(object sender, EventArgs e)
        {
            txtAccountNumbers.SelectAll();

        }

        private void cb_AccountTypes_Click(object sender, EventArgs e)
        {

        }

        private void cb_AccountTypes_DropDownClosed(object sender, EventArgs e)
        {
            txtAccountNumbers.Focus();
        }

        private void cb_AccountTypes_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void txt_OpeningBalance_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_OpeningBalance_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txt_OpeningBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45)
            {
                if (txt_OpeningBalance.Text.Contains("-") == false)
                {
                    e.Handled = true;
                    txt_OpeningBalance.Text = "-" + txt_OpeningBalance.Text;
                    txt_OpeningBalance.SelectionStart = txt_OpeningBalance.TextLength;
                }
                else
                    e.Handled = true;
            }
            else if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                if (txt_OpeningBalance.Text.Contains("."))
                {
                    char c = '.';
                    string[] sc = txt_OpeningBalance.Text.Split(c);

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
                if (txt_OpeningBalance.Text.Contains(".") == false)
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            else
                e.Handled = true;

        }

        private void txt_AccountARName_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.GetCultureInfoByIetfLanguageTag("ar-EG"));

        }

        private void txt_AccountARName_Leave(object sender, EventArgs e)
        {
            txt_OpeningBalance.Focus();
            InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;

        }

        private void Gb1_EnabledChanged(object sender, EventArgs e)
        {
            if (Gb1.Enabled == true)
                dgv.Enabled = false;
            else
                dgv.Enabled = true;

        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            cb_AccountTypes.Text = "";
            txtAccountNumbers.Text = "";
            txt_AccountName.Text = "";
            txt_OpeningBalance.Text = "";
            cb_AccountTypes.Focus();
            txt_OpeningBalance.Text = "0";
            checkBox_Active.Checked = true;
            ChkSubLvl.Checked = false;
            Gb1.Enabled = true;
            btn_New.Visible = false;
            btnSavenew.Visible = true;
            btn_Edit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnSavenew_Click(object sender, EventArgs e)
        {
            //if (txtAccountNumbers.Text.Length < AccountNumberFormat.Length)
            //{
            //    MessageBox.Show("Insert Valid Account Number like this expression " + AccountNumberFormat + "");
            //    return;
            //}
            if (GeneralFunctions.ValidateString(txt_AccountName.Text, "Please Specify the Account Name")
            && GeneralFunctions.ValidateDouble(txt_OpeningBalance.Text, "Please Specify the Opening Balance", out openingBalance) &&
            GeneralFunctions.ValidateComboBox(cb_AccountTypes, "Please Specify the Account Type"))
            {
                sqlcon.Open();
                AccountNumber = txtAccountNumbers.Text;
                SqlCommand cmdSelect = new SqlCommand("Select AccountNumber from GLAccounts where AccountNumber = '" + AccountNumber + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("AccountNumber = '" + AccountNumber + "'", dbAccountingProjectDS.GLAccounts))
                {
                    DataRow r = dbAccountingProjectDS.GLAccounts.NewRow();
                    r["AccountNumber"] = txtAccountNumbers.Text;
                    r["AccountName"] = txt_AccountName.Text;
                    r["AccountNameArabic"] = txt_AccountARName.Text;
                    r["AccountTypeName"] = cb_AccountTypes.Text;
                    r["Active"] = checkBox_Active.Checked;
                    r["SubLvl"] = ChkSubLvl.Checked;
                    r["OpeningBalance"] = openingBalance;
                    dbAccountingProjectDS.GLAccounts.Rows.Add(r);

                    dr.Close();
                    sqlcon.Close();

                    adaptertbAccounts.Update(dbAccountingProjectDS.GLAccounts);
                    dbAccountingProjectDS.AcceptChanges();
                    AddGLTotalRow();
                    ClearAll();



                    cb_AccountTypes.Text = "";
                    txt_AccountName.Text = "";
                    txtAccountNumbers.Text = "";
                    checkBox_Active.Checked = false;
                    ChkSubLvl.Checked = false;
                    txt_OpeningBalance.Text = "";
                    Gb1.Enabled = false;
                    btn_New.Visible = true;
                    btnSavenew.Visible = false;
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Account Number already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + AccountNumber + "'");
                        DataRow[] newArray = dbAccountingProjectDS.GLTotals.Select("AccountNumber = '" + txtAccountNumbers.Text + "'");
                        rArr[0]["AccountName"] = txt_AccountName.Text;
                        rArr[0]["AccountNameArabic"] = txt_AccountARName.Text;
                        rArr[0]["AccountTypeName"] = cb_AccountTypes.Text;
                        rArr[0]["Active"] = checkBox_Active.Checked;
                        rArr[0]["SubLvl"] = ChkSubLvl.Checked;
                        //if (double.Parse(rArr[0]["OpeningBalance"].ToString()) != openingBalance)
                        //    MessageBox.Show("Cant Edit the openning balance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rArr[0]["OpeningBalance"] = openingBalance;
                        newArray[0]["BeginningBalance"] = openingBalance;
                        ClearAll();
                        dr.Close();
                        sqlcon.Close();
                        adaptertbAccounts.Update(dbAccountingProjectDS.GLAccounts);
                        adaptertbGLTotals.Update(dbAccountingProjectDS.GLTotals);
                        dbAccountingProjectDS.AcceptChanges();
                        cb_AccountTypes.Text = "";
                        txt_AccountName.Text = "";
                        txtAccountNumbers.Text = "";
                        checkBox_Active.Checked = false;
                        ChkSubLvl.Checked = false;
                        txt_OpeningBalance.Text = "";
                        Gb1.Enabled = false;
                        btn_New.Visible = true;
                        btnSavenew.Visible = false;
                    }
                    else
                    {
                        cb_AccountTypes.Text = "";
                        txt_AccountName.Text = "";
                        txtAccountNumbers.Text = "";
                        checkBox_Active.Checked = false;
                        txt_OpeningBalance.Text = "";
                        adaptertbAccounts.Update(dbAccountingProjectDS.GLAccounts);
                        adaptertbGLTotals.Update(dbAccountingProjectDS.GLTotals);
                        dbAccountingProjectDS.AcceptChanges();
                        cb_AccountTypes.Text = "";
                        txt_AccountName.Text = "";
                        txtAccountNumbers.Text = "";
                        checkBox_Active.Checked = false;
                        ChkSubLvl.Checked = false;
                        txt_OpeningBalance.Text = "";
                        Gb1.Enabled = false;
                        btn_New.Visible = true;
                        btnSavenew.Visible = false;
                    }
                    dr.Close();
                    sqlcon.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtAccountNumbers.Enabled = false;
            txt_OpeningBalance.Enabled = false;
            tempAccountNumber = txtAccountNumbers.Text;
            Gb1.Enabled = true;
            btn_Edit.Visible = false;
            Btnsaveedit.Visible = true;
            btn_New.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void Btnsaveedit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (GeneralFunctions.ValidateString(txt_AccountName.Text, "Please Specify the Account Name")
                 && GeneralFunctions.ValidateDouble(txt_OpeningBalance.Text, "Please Specify the Opening Balance", out openingBalance) &&
                 GeneralFunctions.ValidateComboBox(cb_AccountTypes, "Please Specify the Account Type"))
                {
                    if (tempAccountNumber == txtAccountNumbers.Text)
                    {
                        DataRow[] rArr = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txtAccountNumbers.Text + "'");
                        DataRow[] newArray = dbAccountingProjectDS.GLTotals.Select("AccountNumber = '" + txtAccountNumbers.Text + "'");
                        SqlConnection sqlconCharts = new SqlConnection(GeneralFunctions.ConnectionString);
                        sqlconCharts.Open();
                        SqlCommand sqlCommand = new SqlCommand("Update GLAccountsChart SET TreeRowParent='" + txt_AccountName.Text + "' WHERE TreeRowParent='" + oldName + "'", sqlconCharts);
                        int verify;
                        verify = sqlCommand.ExecuteNonQuery();
                        sqlCommand = new SqlCommand("Update GLAccountsChart SET TreeRowName='" + txt_AccountName.Text + "' WHERE TreeRowName='" + oldName + "'", sqlconCharts);
                        verify = sqlCommand.ExecuteNonQuery();
                        rArr[0]["AccountName"] = txt_AccountName.Text;
                        rArr[0]["AccountNameArabic"] = txt_AccountARName.Text;
                        rArr[0]["AccountTypeName"] = cb_AccountTypes.Text;
                        //if (double.Parse(rArr[0]["OpeningBalance"].ToString()) != openingBalance)
                        //    MessageBox.Show("Cant Edit the openning balance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rArr[0]["OpeningBalance"] = openingBalance;
                        rArr[0]["Active"] = checkBox_Active.Checked;
                        rArr[0]["SubLvl"] = ChkSubLvl.Checked;
                        //newArray[0]["BeginningBalance"] =  openingBalance;

                        ClearAll();
                    }
                    else if (tempAccountNumber != txtAccountNumbers.Text)
                    {
                        DataRow[] rArr2 = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txtAccountNumbers.Text + "'");
                        DataRow[] newArray2 = dbAccountingProjectDS.GLTotals.Select("AccountNumber = '" + txtAccountNumbers.Text + "'");
                        if (rArr2.Length == 1)
                        {
                            MessageBox.Show("Account Number Already exists");
                            return;
                        }

                    }

                }
            }
            else
            {
                MessageBox.Show("Please Select the row that you want to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgv.ClearSelection();
            adaptertbAccounts.Update(dbAccountingProjectDS.GLAccounts);
            adaptertbGLTotals.Update(dbAccountingProjectDS.GLTotals);
            dbAccountingProjectDS.AcceptChanges();
            cb_AccountTypes.Text = "";
            txt_AccountName.Text = "";
            txt_AccountARName.Text = "";
            txtAccountNumbers.Text = "";
            txtAccountNumbers.Enabled = true;
            checkBox_Active.Checked = false;
            ChkSubLvl.Checked = false;
            txt_OpeningBalance.Text = "";
            Gb1.Enabled = false;
            btn_Edit.Visible = true;
            Btnsaveedit.Visible = false;
            btn_New.Enabled = true;
            btnDelete.Enabled = false;
            btn_Edit.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow[] drs = dbAccountingProjectDS.G_L_GeneralSetup.Select();
            if (drs.Length != 0)
            {
                if (txtAccountNumbers.Text == drs[0]["BalanceSheet"].ToString())
                {
                    MessageBox.Show("This Account Used In General Ledger General Setup Can't Deleted", "General Ledger");
                    return;
                }
                if (txtAccountNumbers.Text == drs[0]["IncomeStatment"].ToString())
                {
                    MessageBox.Show("This Account Used In General Ledger General Setup Can't Deleted", "General Ledger");
                    return;
                }
                if (txtAccountNumbers.Text == drs[0]["RetainedEarnings"].ToString())
                {
                    MessageBox.Show("This Account Used In General Ledger General Setup Can't Deleted", "General Ledger");
                    return;
                }
            }
            DialogResult myrst;
            myrst = MessageBox.Show("Are You Sure Delete This Account", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return;
            SqlConnection sqlcheckFoundConnection = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand sqlcheckCommand;
            sqlcheckFoundConnection.Open();
            sqlcheckCommand = new SqlCommand("Select GLAccount From GLTransactions Where GLAccount='" + txtAccountNumbers.Text + "'", sqlcheckFoundConnection);
            SqlDataReader sqlRead = sqlcheckCommand.ExecuteReader();
            DataRow[] dr;
            if (!sqlRead.HasRows)
            {
                SqlConnection deleteConnection2 = new SqlConnection(GeneralFunctions.ConnectionString);
                //SqlCommand deleteCommand5;
                deleteConnection2.Open();
                //int x2 = 0;
                dr = dbAccountingProjectDS.GLTotals.Select("AccountNumber='" + txtAccountNumbers.Text + "'");
                if (dr.Length != 0)
                {
                    for (int i = 0; i <= dr.Length - 1; i++)
                        dr[0].Delete();
                }
                //deleteCommand5 = new SqlCommand("Delete From GLTotals Where AccountNumber='" + txtAccountNumbers.Text + "'", deleteConnection2);
                //x2 += deleteCommand5.ExecuteNonQuery();
                cmdBuilderGLTotals.DataAdapter = adaptertbGLTotals;
                adaptertbGLTotals.Update(dbAccountingProjectDS.GLTotals);
                dbAccountingProjectDS.AcceptChanges();

                //deleteCommand5 = new SqlCommand("Delete From GLBudget Where AccountNumber='" + txtAccountNumbers.Text + "'", deleteConnection2);
                //x2 += deleteCommand5.ExecuteNonQuery();
                dr = dbAccountingProjectDS.GLBudget.Select("AccountNumber='" + txtAccountNumbers.Text + "'");
                if (dr.Length != 0)
                {
                    for (int i = 0; i <= dr.Length - 1; i++)
                        dr[0].Delete();
                }
                cmdBuilderGLTotals.DataAdapter = adapterGLBudget;
                adapterGLBudget.Update(dbAccountingProjectDS.GLBudget);
                dbAccountingProjectDS.AcceptChanges();
                deleteConnection2.Close();
                ConfirmDelete();
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure to delete this account from Database?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    if (DialogResult.OK == MessageBox.Show("This will affect many data related to this Account Number,Press Ok to confirm", "Help", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                    {
                        if (DialogResult.OK == MessageBox.Show("This will Damage many Accounts Values related to this Account ,Press Ok to confirm", "Stop", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop))
                        {
                            SqlConnection deleteConnection = new SqlConnection(GeneralFunctions.ConnectionString);
                            SqlCommand deleteCommand;
                            SqlCommand deleteCommand2;
                            SqlDataReader readFormat;
                            SqlCommand selectBatches;
                            SqlDataReader readBatches;
                            deleteConnection.Open();
                            int x = 0;
                            //deleteCommand = new SqlCommand("Delete From GLTotals Where AccountNumber='" + txtAccountNumbers.Text + "'", deleteConnection);
                            //x += deleteCommand.ExecuteNonQuery();
                            dr = dbAccountingProjectDS.GLTotals.Select("AccountNumber='" + txtAccountNumbers.Text + "'");
                            if (dr.Length != 0)
                            {
                                for (int i = 0; i <= dr.Length - 1; i++)
                                    dr[0].Delete();
                            }
                            cmdBuilderGLTotals.DataAdapter = adaptertbGLTotals;
                            adaptertbGLTotals.Update(dbAccountingProjectDS.GLTotals);
                            dbAccountingProjectDS.AcceptChanges();
                            //deleteCommand = new SqlCommand("Delete From GLBudget Where AccountNumber='" + txtAccountNumbers.Text + "'", deleteConnection);
                            //x += deleteCommand.ExecuteNonQuery();
                            dr = dbAccountingProjectDS.GLBudget.Select("AccountNumber='" + txtAccountNumbers.Text + "'");
                            if (dr.Length != 0)
                            {
                                for (int i = 0; i <= dr.Length - 1; i++)
                                    dr[0].Delete();
                            }
                            cmdBuilderGLTotals.DataAdapter = adapterGLBudget;
                            adapterGLBudget.Update(dbAccountingProjectDS.GLBudget);
                            dbAccountingProjectDS.AcceptChanges();
                            deleteCommand = new SqlCommand("Select AccountNumberFormat FROM GeneralSetup", deleteConnection);
                            readFormat = deleteCommand.ExecuteReader();
                            readFormat.Read();
                            //MessageBox.Show(readFormat.GetString(0).Length.ToString());
                            deleteCommand = new SqlCommand("Delete From GLAccountsChart Where LEFT(TreeRowName," + Convert.ToInt32(readFormat.GetString(0).Length) + ")='" + txtAccountNumbers.Text + "' OR LEFT(TreeRowParent," + Convert.ToInt32(readFormat.GetString(0).Length) + ")='" + txtAccountNumbers.Text + "'", deleteConnection);
                            readFormat.Close();
                            x += deleteCommand.ExecuteNonQuery();
                            selectBatches = new SqlCommand("Select BatchNo From GLTransactions Where GLAccount='" + txtAccountNumbers.Text + "'", deleteConnection);
                            readBatches = selectBatches.ExecuteReader();
                            SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                            sqlcon2.Open();
                            if (readBatches.HasRows)
                            {
                                while (readBatches.Read())
                                {
                                    deleteCommand2 = new SqlCommand("Delete From Batch Where BatchNo=" + Convert.ToInt32(readBatches.GetInt32(0)) + "", sqlcon2);

                                    x += deleteCommand2.ExecuteNonQuery();
                                }
                            }

                            ConfirmDelete();
                        }
                        else
                            return;
                    }
                }
            }
        }
    }
}