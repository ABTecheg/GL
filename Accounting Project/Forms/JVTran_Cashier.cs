using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using JThomas.Controls;
using Accounting_GeneralLedger.Resources;
using System.Drawing.Printing;

//using ru
namespace Accounting_GeneralLedger
{
    public partial class JVTran_Cashier : Form
    {
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbGLProjectCodes;
        private SqlDataAdapter adaptertbdepartmentCodes;
        private SqlDataAdapter adaptertbGLJournalCodes;
        private SqlDataAdapter adaptertbAccounts;
        private SqlDataAdapter adaptertbFiscalPeriod;
        private SqlDataAdapter adaptertbGLTotals;
        private SqlDataAdapter adaptertbCurrency;
        private SqlDataAdapter adaptertbBatch;
        private SqlDataAdapter adaptertbG_L_GeneralSetup;
        private SqlDataAdapter adaptertbMYGLTransactions;
        private SqlDataAdapter adaptertbBatchTemp;
        private SqlDataAdapter adaptertbMYGLTransactionsTemp;
        private SqlDataAdapter adaptertbGeneralSetup;
        private SqlCommandBuilder cmdBuilderGLTotals;
        private SqlCommandBuilder cmdBuilderBatch;
        private SqlCommandBuilder cmdMyJVTransactions;
        private int currentRowIndex = 0;
        private int currentPeriodID;
        private int decmal = 1;
        private int MultiCurrency = 0;
        private static DateTime currentEndDate;
        private string currentJVNumber = "";
        private string JNL_Tran_Cashier = "";
        private string DefaultACCBalanceSheet = "";
        private string DefaultACCIncomeStatment = "";
        private double balance = 0;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private string AccountNumberFormat;
        private double ValBS = 0;
        private double ValPT = 0;
        DataGridViewComboBoxColumn dgvc;
        DataGridViewComboBoxColumn dgvd;
        public JVTran_Cashier()
        {
            InitializeComponent();
        }

        private void JVTran_Cashier_Load(object sender, EventArgs e)
        {
            try
            {
                string msg = GeneralFunctions.CheckLockTables("", "ENDYear", "", "Edit");
                if (msg != "")
                {
                    MessageBox.Show("Can't Open Because ENDYear Edit By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                    return;
                }
                msg = GeneralFunctions.CheckLockTables("", "EndMonth", "", "Edit");
                if (msg != "")
                {
                    MessageBox.Show("Can't Open Because EndMonth Edit By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                    return;
                }
                GeneralFunctions.LockTables("", "JVTran_Cashier", "", "Open");
                // TODO: This line of code loads data into the 'dbAccountingProjectDS1.BatchTemp' table. You can move, or remove it, as needed.
                txt_UserID.Text = AaDeclrationClass.xUserName;
                GeneralFunctions.priviledgeGroupBox(Lock60);
                GeneralFunctions.priviledgeGroupBox(Lock61);
                GeneralFunctions.priviledgeGroupBox(Lock62);
                GeneralFunctions.priviledgeGroupBox(Lock63);
                dbAccountingProjectDS = new dbAccountingProjectDS();
                sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
                adaptertbGLProjectCodes = new SqlDataAdapter("Select * from GLProjectCodes Where Active = 1", sqlcon);
                adaptertbdepartmentCodes = new SqlDataAdapter("Select * from DepartmentCode Where active = 'A' ", sqlcon);
                adaptertbGLJournalCodes = new SqlDataAdapter("Select * from GLJournalCodes", sqlcon);
                //adaptertbGLJVTransaction = new SqlDataAdapter("Select * from GLJournalVoucher", sqlcon);
                //adaptertbGLJVAccounts = new SqlDataAdapter("Select * from GLJVTransactionAccounts", sqlcon);
                adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts", sqlcon);
                //adaptertbTemplateAccounts = new SqlDataAdapter("Select * from GLTemplateAccounts", sqlcon);
                adaptertbFiscalPeriod = new SqlDataAdapter("Select * from GLFiscalPeriod", sqlcon);
                adaptertbGLTotals = new SqlDataAdapter("Select * from GLTotals", sqlcon);
                adaptertbCurrency = new SqlDataAdapter("Select * from GLCurrency", sqlcon);
                adaptertbBatchTemp = new SqlDataAdapter("Select * From BatchTemp Where active = 'A'", sqlcon);
                adaptertbMYGLTransactionsTemp = new SqlDataAdapter("Select * From GLTransactionsTemp", sqlcon);
                adaptertbBatch = new SqlDataAdapter("Select * From Batch", sqlcon);
                adaptertbMYGLTransactions = new SqlDataAdapter("Select * From GLTransactions", sqlcon);
                adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
                adaptertbG_L_GeneralSetup = new SqlDataAdapter("Select * from G_L_GeneralSetup", sqlcon);
                //cmdBuildertbJVTransaction = new SqlCommandBuilder(adaptertbGLJVTransaction);
                //cmdBuildertbJVAccounts = new SqlCommandBuilder(adaptertbGLJVAccounts);
                cmdBuilderGLTotals = new SqlCommandBuilder(adaptertbGLTotals);
                cmdBuilderBatch = new SqlCommandBuilder(adaptertbBatch);
                cmdMyJVTransactions = new SqlCommandBuilder(adaptertbMYGLTransactions);
                //cmdBuilderBatchTemp = new SqlCommandBuilder(adaptertbBatchTemp);
                //cmdMyJVTransactionsTemp = new SqlCommandBuilder(adaptertbMYGLTransactionsTemp);

                adaptertbGLProjectCodes.Fill(dbAccountingProjectDS.GLProjectCodes);
                adaptertbdepartmentCodes.Fill(dbAccountingProjectDS.DepartmentCode);
                adaptertbGLJournalCodes.Fill(dbAccountingProjectDS.GLJournalCodes);
                //adaptertbTemplate.Fill(dbAccountingProjectDS.GLTemplates);
                adaptertbFiscalPeriod.Fill(dbAccountingProjectDS.GLFiscalPeriod);
                adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
                //adaptertbTemplateAccounts.Fill(dbAccountingProjectDS.GLTemplateAccounts);
                //adaptertbGLJVTransaction.Fill(dbAccountingProjectDS.GLJournalVoucher);
                //adaptertbGLJVAccounts.Fill(dbAccountingProjectDS.GLJVTransactionAccounts);
                adaptertbGLTotals.Fill(dbAccountingProjectDS.GLTotals);
                adaptertbCurrency.Fill(dbAccountingProjectDS.GLCurrency);
                adaptertbBatch.Fill(dbAccountingProjectDS.Batch);
                adaptertbMYGLTransactions.Fill(dbAccountingProjectDS.GLTransactions);
                adaptertbBatchTemp.Fill(dbAccountingProjectDS.BatchTemp);
                adaptertbMYGLTransactionsTemp.Fill(dbAccountingProjectDS.GLTransactionsTemp);
                adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
                adaptertbG_L_GeneralSetup.Fill(dbAccountingProjectDS.G_L_GeneralSetup);
                foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
                {
                    if (dr["MultiCurrency"].ToString() == "False")
                        MultiCurrency = 0;
                    else
                        MultiCurrency = 1;
                    GeneralFunctions.JVNumberFormat = dr["JVNumberFormat"].ToString();
                    GeneralFunctions.DecimalPointsNumber = int.Parse(dr["DecimalPointsNumber"].ToString());
                    AccountNumberFormat = dr["AccountNumberFormat"].ToString();
                    decmal = int.Parse(dr["DecimalPointsNumber"].ToString());
                    GeneralFunctions.lblJV = dr["lblJV"].ToString();
                }
                DataRow[] drs = dbAccountingProjectDS.G_L_GeneralSetup.Select();
                if (drs.Length != 0)
                {
                    DefaultACCBalanceSheet = drs[0]["BalanceSheet"].ToString();
                    JNL_Tran_Cashier = drs[0]["JNL_Tran_Cashier"].ToString();
                    DefaultACCIncomeStatment = drs[0]["IncomeStatment"].ToString();
                    if (DefaultACCBalanceSheet == "" || DefaultACCIncomeStatment == "")
                    {
                        MessageBox.Show("Please Check AccountBalanceSheet And AccountIncomeStatment In G/L GeneralSetup ", "Error");
                        this.Close();
                    }
                }
                txtAccount_Debit.Mask = AccountNumberFormat;
                txtAccount_Credit.Mask = AccountNumberFormat;
                string periodName;
                if (GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value.Date), out currentPeriodID, out periodName, out currentEndDate))
                    txt_Period.Text = periodName;
                else
                    MessageBox.Show("The period has been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Amount.Text = "0";

                currentJVNumber = GeneralFunctions.CreateJVNumberFormat(GeneralFunctions.lblJV, GeneralFunctions.JVNumberFormat, true);
                txt_JVNumber.Text = currentJVNumber;

                if (GeneralFunctions.languagechioce != "")
                {
                    this.obj_options = new ClassOptions();
                    this.obj_options.report_language = GeneralFunctions.languagechioce;
                    this.update_language_interface();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void update_language_interface()
        {
            try
            {
                this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
                this.Text = obj_interface_language.formJVTransactions;

                this.label7.Text = obj_interface_language.lblUserID;
                this.label6.Text = obj_interface_language.labelBatch;
                this.label1.Text = obj_interface_language.labelJVNumber;
                //this.lblAccount_Debit.Text = obj_interface_language.lblCountUnits;
                this.label2.Text = obj_interface_language.labelJVDescription;
                this.label4.Text = obj_interface_language.labelJVDate;
                //this.lblAccount_Credit.Text = obj_interface_language.lblJVTransactionsTemp;
                this.label5.Text = obj_interface_language.labelPeriod;
                this.label9.Text = obj_interface_language.labelJVTransactionsStatus;
                //this.lblAmount.Text = obj_interface_language.labelBalance;

                this.btnNew.Text = obj_interface_language.buttonJVTransactionNew;
                this.btnEdit.Text = obj_interface_language.buttonJVTransactionEdit;
                this.btnDelete.Text = obj_interface_language.buttonJVTransactionDelete;
                this.btnUndo.Text = obj_interface_language.buttonJVTransactionUndo;
                this.btnExit.Text = obj_interface_language.buttonJVTransactionExit;
                this.btnSaveNew.Text = obj_interface_language.buttonJVTransactionSaveNew;
                this.btnSaveEdit.Text = obj_interface_language.buttonJVTransactionSaveEdit;
                this.btn_Post.Text = obj_interface_language.buttonJVTransactionPost;
                this.btnPrint.Text = obj_interface_language.buttonJVTransactionPrint;
                this.btnCopy.Text = obj_interface_language.buttonJVTransactionCopy;
                this.btnFind.Text = obj_interface_language.buttonJVTransactionsFind;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DTP_JVDate_CloseUp(object sender, EventArgs e)
        {
            try
            {
                string periodName;
                if (GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value.Date), out currentPeriodID, out periodName, out currentEndDate))
                    txt_Period.Text = periodName;
                else
                    MessageBox.Show("The period has been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void update()
        {
            adaptertbGLTotals.Update(dbAccountingProjectDS.GLTotals);
            adaptertbBatch.Update(dbAccountingProjectDS.Batch);
            adaptertbMYGLTransactions.Update(dbAccountingProjectDS.GLTransactions);
            dbAccountingProjectDS.AcceptChanges();
        }
        private static int NewBatchNo()
        {
            int No = 0;
            SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconBatch.Open();
            SqlCommand getBatch = new SqlCommand("Select Max(BatchNo)+1 From Batch", sqlconBatch);
            if (getBatch.ExecuteScalar() != DBNull.Value)
            {
                No = Convert.ToInt32(getBatch.ExecuteScalar());
            }
            else
            {
                No = 1;
            }
            string msg = "new";
            while (msg != "")
            {
                msg = GeneralFunctions.CheckLockTables("Batch", "", No.ToString(), "New");
                if (msg != "")
                {
                    No = No + 1;
                }
            }
            GeneralFunctions.LockTables("Batch", "JVTran_Cashier", No.ToString(), "New");
            return No;
        }
        private int NewTransNo()
        {
            int No = 0;
            DataRow[] drr = dbAccountingProjectDS.GLTransactions.Select("", "TransNO");
            if (drr.Length != 0)
            {
                No = 1 + int.Parse(drr[drr.Length - 1]["TransNO"].ToString());
            }
            else
            {
                No = 1;
            }
            return No;
        }
        private void AddJVTransactionAccounts()
        {
            try
            {
                double amt = 0; double.TryParse(txt_Amount.Text, out amt);
                DataRow r;
                r = this.dbAccountingProjectDS.GLTransactions.NewRow();
                r["TransNO"] = NewTransNo();
                r["BatchNo"] = Convert.ToUInt32(txtBatch.Text);
                r["GLAccount"] = txtAccount_Debit.Text;
                r["TRANSREF"] = "";
                r["TRANSDATE"] = DTP_JVDate.Value.Date;
                r["TRANSUnit"] = 0;
                r["Amount"] = 0;
                r["AmountLC"] = amt;
                r["CurrencyType"] = "";
                r["Rate"] = "0";
                r["ProjectCode"] = "";
                r["DepartmentCode"] = "";
                r["SortNO"] = 1;
                dbAccountingProjectDS.GLTransactions.Rows.Add(r);
                r = this.dbAccountingProjectDS.GLTransactions.NewRow();
                r["TransNO"] = NewTransNo();
                r["BatchNo"] = Convert.ToUInt32(txtBatch.Text);
                r["GLAccount"] = txtAccount_Credit.Text;
                r["TRANSREF"] = "";
                r["TRANSDATE"] = DTP_JVDate.Value.Date;
                r["TRANSUnit"] = 0;
                r["Amount"] = 0;
                r["AmountLC"] = -1 * amt;
                r["CurrencyType"] = "";
                r["Rate"] = "0";
                r["ProjectCode"] = "";
                r["DepartmentCode"] = "";
                r["SortNO"] = 2;
                dbAccountingProjectDS.GLTransactions.Rows.Add(r);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AddAccountsForBS_PL()
        {
            try
            {
                DataRow r;
                r = this.dbAccountingProjectDS.GLTransactions.NewRow();
                r["TransNO"] = NewTransNo();
                r["BatchNo"] = Convert.ToUInt32(txtBatch.Text);
                r["GLAccount"] = DefaultACCBalanceSheet; //txt_JVNumber.Text;
                r["TRANSREF"] = "BalanceSheet";
                r["TRANSDATE"] = DateTime.Now.ToShortDateString();
                r["TRANSUnit"] = 0;
                r["Amount"] = "0";
                r["AmountLC"] = -1 * ValBS;
                r["CurrencyType"] = "";
                r["Rate"] = "0";
                r["ProjectCode"] = "";
                r["DepartmentCode"] = "";
                r["SortNO"] = 0;

                dbAccountingProjectDS.GLTransactions.Rows.Add(r);
                r = this.dbAccountingProjectDS.GLTransactions.NewRow();
                r["TransNO"] = NewTransNo();
                r["BatchNo"] = Convert.ToUInt32(txtBatch.Text);
                r["GLAccount"] = DefaultACCIncomeStatment; //txt_JVNumber.Text;
                r["TRANSREF"] = "IncomeStatment";
                r["TRANSDATE"] = DateTime.Now.ToShortDateString();
                r["TRANSUnit"] = 0;
                r["Amount"] = "0";
                r["AmountLC"] = -1 * ValPT;
                r["CurrencyType"] = "";
                r["Rate"] = "0";
                r["ProjectCode"] = "";
                r["DepartmentCode"] = "";
                r["SortNO"] = 0;

                dbAccountingProjectDS.GLTransactions.Rows.Add(r);
                //update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EditJVAccounts()
        {
            try
            {
                SqlConnection sqlconndelete = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlconndelete.Open();
                SqlCommand sqlcommandDeletetran = new SqlCommand("Delete From GLTransactions Where  BatchNo = " + int.Parse(txtBatch.Text), sqlconndelete);
                SqlDataReader drDeletetran = sqlcommandDeletetran.ExecuteReader();
                drDeletetran.Close();
                sqlconndelete.Close();
                refill();
                AddJVTransactionAccounts();
                //DataRow r;
                //for (int i = 0; i < dtJVAccounts.Rows.Count; i++)
                //{
                //    r = dtJVAccounts.Rows[i];
                //    if (r.Equals(dtJVAccounts.Rows[dtJVAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountName"].ToString() == "")
                //        break;
                //    string Acc;
                //    Acc = r["AccountNumber"].ToString();
                //    DataRow[] rs = dbAccountingProjectDS.GLTransactions.Select("BatchNo = " + int.Parse(txtBatch.Text) + "" );
                //    if (rs.Length < dgv.Rows.Count-1)
                //    {
                //        r = this.dbAccountingProjectDS.GLTransactions.NewRow();
                //        r["TransNO"] = NewTransNo();
                //        r["BatchNo"] = Convert.ToUInt32(txtBatch.Text);
                //        r["GLAccount"] = dgv.Rows[i].Cells["AccountNumber"].Value; //txt_JVNumber.Text;
                //        r["TRANSREF"] = dgv.Rows[i].Cells["Reference"].Value.ToString();
                //        r["TRANSDATE"] = dgv.Rows[i].Cells["Date"].Value;
                //        r["TRANSUnit"] = dgv.Rows[i].Cells["Units"].Value;
                //        if (double.Parse(dgv.Rows[i].Cells["DebitFC"].Value.ToString()) != 0)
                //            r["Amount"] = double.Parse(dgv.Rows[i].Cells["DebitFC"].Value.ToString());
                //        if (double.Parse(dgv.Rows[i].Cells["CreditFC"].Value.ToString()) != 0)
                //            r["Amount"] = -1 * double.Parse(dgv.Rows[i].Cells["CreditFC"].Value.ToString());

                //        if (double.Parse(dgv.Rows[i].Cells["Debit"].Value.ToString()) != 0)
                //            r["AmountLC"] = double.Parse(dgv.Rows[i].Cells["Debit"].Value.ToString());
                //        if (double.Parse(dgv.Rows[i].Cells["Credit"].Value.ToString()) != 0)
                //            r["AmountLC"] = -1 * double.Parse(dgv.Rows[i].Cells["Credit"].Value.ToString());
                //        r["CurrencyType"] = cb_Currency.Text;
                //        if (txt_CurrencyRate.Text != "")
                //        {
                //            r["Rate"] = double.Parse(txt_CurrencyRate.Text.ToString());
                //        }
                //        else
                //            r["Rate"] = "0";

                //        if (dgv.Rows[i].Cells["ProjectCode"].Value != null)
                //        {
                //            r["ProjectCode"] = dgv.Rows[i].Cells["ProjectCode"].Value.ToString();
                //        }
                //        else
                //            r["ProjectCode"] = "";
                //        r["SortNO"] = i + 1;
                //        dbAccountingProjectDS.GLTransactions.Rows.Add(r);
                //    }
                //    else
                //    {
                //        rs[i]["GLAccount"] = dgv.Rows[i].Cells["AccountNumber"].Value; //txt_JVNumber.Text;
                //        rs[i]["TRANSREF"] = dgv.Rows[i].Cells["Reference"].Value.ToString();
                //        rs[i]["TRANSDATE"] = dgv.Rows[i].Cells["Date"].Value;
                //        rs[i]["TRANSUnit"] = dgv.Rows[i].Cells["Units"].Value;
                //        if (double.Parse(dgv.Rows[i].Cells["DebitFC"].Value.ToString()) != 0)
                //            rs[i]["Amount"] = double.Parse(dgv.Rows[i].Cells["DebitFC"].Value.ToString());
                //        if (double.Parse(dgv.Rows[i].Cells["CreditFC"].Value.ToString()) != 0)
                //            rs[i]["Amount"] = -1 * double.Parse(dgv.Rows[i].Cells["CreditFC"].Value.ToString());

                //        if (double.Parse(dgv.Rows[i].Cells["Debit"].Value.ToString()) != 0)
                //            rs[i]["AmountLC"] = double.Parse(dgv.Rows[i].Cells["Debit"].Value.ToString());
                //        if (double.Parse(dgv.Rows[i].Cells["Credit"].Value.ToString()) != 0)
                //            rs[i]["AmountLC"] = -1 * double.Parse(dgv.Rows[i].Cells["Credit"].Value.ToString());
                //        rs[i]["CurrencyType"] = cb_Currency.Text;
                //        if (txt_CurrencyRate.Text != "")
                //        {
                //            rs[i]["Rate"] = double.Parse(txt_CurrencyRate.Text.ToString());
                //        }
                //        else
                //            rs[i]["Rate"] = "0";

                //        if (dgv.Rows[i].Cells["ProjectCode"].Value != null)
                //        {
                //            rs[i]["ProjectCode"] = dgv.Rows[i].Cells["ProjectCode"].Value.ToString();
                //        }
                //        else
                //            rs[i]["ProjectCode"] = "";
                //        rs[i]["SortNO"] = i + 1;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearAll()
        {
            txt_UserID.Text = AaDeclrationClass.xUserName;
            txtAccount_Debit.Text = "";
            txtAccount_Credit.Text = "";
            txtAccount_Debit_Name.Text = "";
            txtAccount_Credit_Name.Text = "";
            txtAccount_Debit_Name.Tag = "";
            txtAccount_Credit_Name.Tag = "";
            txt_JVNumber.Text = "";
            txt_JVDescription.Text = "";
            txtStatus.Text = "";
            //cb_Temptran.SelectedIndex = -1;
            DTP_JVDate.Value = DateTime.Now;
            string periodName;
            if (GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value.Date), out currentPeriodID, out periodName, out currentEndDate))
                txt_Period.Text = periodName;
            else
                MessageBox.Show("The period has been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            btn_Post.Enabled = false;
            txtFind.Text = "";
            txt_Amount.Text = "0";
            txt_Amount.Enabled = true;
            txtAccount_Debit.Enabled = true;
            txtAccount_Credit.Enabled = true;

            txtBatch.Text = "";
            GeneralFunctions.UnLockTable("", "JVTran_Cashier", "", "Edit");
            GeneralFunctions.UnLockTable("", "JVTran_Cashier", "", "New");
        }
        private void EnableAll()
        {
            txtBatch.Enabled = true;
            txt_JVDescription.Enabled = true;
            DTP_JVDate.Enabled = true;
            txt_Amount.Enabled = true;
            txtAccount_Debit.Enabled = true;
            txtAccount_Credit.Enabled = true;
            groupDetails.Enabled = true;
        }


        private void DisableAll()
        {
            txtBatch.Enabled = false;
            txt_JVDescription.Enabled = false;
            DTP_JVDate.Enabled = false;
            txt_Amount.Enabled = false;
            txtAccount_Debit.Enabled = false;
            txtAccount_Credit.Enabled = false;
            groupDetails.Enabled = false;

        }


        private int GetNextPeriod()
        {
            int ID = 0;
            int NO = 0;
            DateTime dt = currentEndDate.AddDays(1);
            GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, dt.Date), out ID, out NO);
            return ID;
        }

        private string FindPeriod(string prd)
        {
            int periodNamber;
            int prid;
            string prdbalance = "";
            if (GeneralFunctions.RetrievePeriod(prd, out prid, out periodNamber))
                prdbalance = "PeriodBalance" + periodNamber.ToString().Trim();
            else
                MessageBox.Show("The period has been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return prdbalance;
        }
        private void ModifyTotals(string prdbalance, string ApAccount, double val, DateTime prd)
        {
            double CurrentBalance = 0;
            DataRow[] rArr = this.dbAccountingProjectDS.GLTotals.Select("AccountNumber ='" + ApAccount + "' AND FiscalYear = '" + prd.Year + "'");
            if (rArr.Length != 0)
            {
                CurrentBalance = double.Parse(rArr[0][prdbalance].ToString());
                rArr[0][prdbalance] = EditPeriodNumber(CurrentBalance, val);
            }
        }
        private double EditPeriodNumber(double periodBalance, double value)
        {
            double balance = 0;
            balance = periodBalance + value;
            return balance;
        }

        private void FindBatch(string FBatch)
        {
            try
            {
                ClearAll();
                SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlconBatch.Open();
                if (FBatch == "")
                {
                    MessageBox.Show("You must specify data to find");
                    return;
                }
                SqlCommand cmdBatchSelect = new SqlCommand("Select * From Batch Where BatchPRD <> 'Period 99' and BatchNo='" + FBatch + "'", sqlconBatch);
                SqlDataReader drBatch = cmdBatchSelect.ExecuteReader();
                if (drBatch.HasRows)
                {
                    while (drBatch.Read())
                    {
                        string msg = GeneralFunctions.CheckLockTables("Batch", "", FBatch, "Edit");
                        if (msg != "")
                        {
                            if (drBatch.GetString(7).Trim() != "P")
                            {
                                MessageBox.Show("Can't Edit Because This Batch Edit By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }
                        GeneralFunctions.LockTables("Batch", "JVTran_Cashier", FBatch, "Edit");
                        txtBatch.Text = drBatch.GetInt32(0).ToString();
                        txt_JVNumber.Text = drBatch.GetString(1);
                        txtStatus.Text = drBatch.GetString(7).Trim();
                        txt_JVDescription.Text = drBatch.GetString(4);
                        DTP_JVDate.Value = drBatch.GetDateTime(2);
                        txt_Period.Text = drBatch.GetString(3);
                        txt_UserID.Text = GeneralFunctions.UserName(int.Parse(drBatch.GetString(9).ToString()));
                        SqlConnection sqlTransactions = new SqlConnection(GeneralFunctions.ConnectionString);
                        SqlCommand sqlcommandTransaction = new SqlCommand("Select * From GLTransactions Where BatchNo =" + Convert.ToUInt32(txtBatch.Text) + " AND SortNO <> 0 ORDER BY SortNO", sqlTransactions);
                        sqlTransactions.Open();
                        SqlDataReader sqlreaderTransactions = sqlcommandTransaction.ExecuteReader();
                        SqlConnection sqlAccountConnection;
                        SqlCommand sqlAccountCommand;
                        SqlDataReader sqlAccountread;
                        int countrowU = 0;
                        double Amount = 0;
                        if (sqlreaderTransactions.HasRows)
                        {
                            while (sqlreaderTransactions.Read())
                            {
                                Amount = double.Parse(sqlreaderTransactions.GetValue(8).ToString());
                                if (Amount < 0)
                                {
                                    sqlAccountConnection = new SqlConnection(GeneralFunctions.ConnectionString);
                                    sqlAccountCommand = new SqlCommand("Select * From GLAccounts Where AccountNumber ='" + sqlreaderTransactions.GetString(2) + "'", sqlAccountConnection);
                                    sqlAccountConnection.Open();
                                    sqlAccountread = sqlAccountCommand.ExecuteReader();
                                    if (sqlAccountread.HasRows)
                                    {
                                        while (sqlAccountread.Read())
                                        {
                                            txtAccount_Credit.Text = sqlAccountread.GetString(0);
                                            txtAccount_Credit_Name.Text = sqlAccountread.GetString(1);
                                            txtAccount_Credit_Name.Tag = sqlAccountread.GetString(2);
                                        }
                                    }
                                }
                                else if (Amount > 0)
                                {
                                    sqlAccountConnection = new SqlConnection(GeneralFunctions.ConnectionString);
                                    sqlAccountCommand = new SqlCommand("Select * From GLAccounts Where AccountNumber ='" + sqlreaderTransactions.GetString(2) + "'", sqlAccountConnection);
                                    sqlAccountConnection.Open();
                                    sqlAccountread = sqlAccountCommand.ExecuteReader();
                                    if (sqlAccountread.HasRows)
                                    {
                                        while (sqlAccountread.Read())
                                        {
                                            txtAccount_Debit.Text = sqlAccountread.GetString(0);
                                            txtAccount_Debit_Name.Text = sqlAccountread.GetString(1);
                                            txtAccount_Debit_Name.Tag = sqlAccountread.GetString(2);
                                        }
                                    }
                                    txt_Amount.Text = Amount.ToString();
                                }

                                countrowU++;

                            }
                        }

                    }
                }
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                DisableAll();
            }
            catch (Exception e22)
            {
                MessageBox.Show(e22.Message);
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                SearchJV searchSpecificJV = new SearchJV();
                searchSpecificJV.endyearsadjustments = "Tran_Cashier";
                searchSpecificJV.ShowDialog();
                if (searchSpecificJV.selectBatchNo != "" && searchSpecificJV.selectBatchNo != null)
                {
                    txtFind.Text = searchSpecificJV.selectBatchNo.ToString();
                    FindBatch(txtFind.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (groupDetails.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender != "Yes")
                {
                    if (groupDetails.Enabled == true)
                    {
                        DialogResult myrst;
                        myrst = MessageBox.Show("Are You Sure Open New Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (myrst == DialogResult.No)
                            return;
                    }
                }
                ClearAll();
                EnableAll();
                currentJVNumber = GeneralFunctions.CreateJVNumberFormat(GeneralFunctions.lblJV, GeneralFunctions.JVNumberFormat, true);
                txt_JVNumber.Text = currentJVNumber;
                //******************************************
                string periodName;
                if (GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value.Date), out currentPeriodID, out periodName, out currentEndDate))
                    txt_Period.Text = periodName;
                else
                    MessageBox.Show("The period has been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //*************************************
                txtBatch.Text = NewBatchNo().ToString();
                //*************************************
                btnNew.Visible = false;
                btnSaveNew.Visible = true;
                btn_Post.Enabled = false;
                btnFind.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnSaveEdit.Enabled = false;
                txtStatus.Text = "U";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] drAC;
                drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txtAccount_Debit.Text + "'");
                if (drAC.Length == 0)
                {
                    MessageBox.Show("Check Account Debit", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txtAccount_Credit.Text + "'");
                if (drAC.Length == 0)
                {
                    MessageBox.Show("Check Account Credit", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txt_Amount.Text == "0")
                {
                    //DialogResult myrst;
                    //string s = " Amount = 0 , Are You Sure Save";
                    //myrst = MessageBox.Show(s, "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (myrst == DialogResult.No)
                    //    return;
                    MessageBox.Show("Amount = 0", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ValidateYear() && ValidatePeriod())
                {
                    //*************************************************
                    SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlconBatch.Open();
                    SqlCommand cmdBatchSelect = new SqlCommand("Select BatchNo From Batch Where BatchNo=" + Convert.ToUInt32(txtBatch.Text) + "", sqlconBatch);
                    SqlDataReader drBatch = cmdBatchSelect.ExecuteReader();
                    if (!drBatch.HasRows && !GeneralFunctions.FindRow("BatchNo=" + Convert.ToUInt32(txtBatch.Text) + "", dbAccountingProjectDS.Batch))
                    {
                        DataRow rBatch = this.dbAccountingProjectDS.Batch.NewRow();
                        rBatch["BatchNo"] = Convert.ToUInt32(txtBatch.Text);
                        rBatch["JVNumber"] = txt_JVNumber.Text;
                        rBatch["BatchDate"] = DTP_JVDate.Value.Date; //string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value.Date);
                        rBatch["BatchPRD"] = txt_Period.Text;
                        rBatch["BatchDSC"] = txt_JVDescription.Text;
                        rBatch["BatchSRC"] = "GL";
                        rBatch["BatchJNL"] = JNL_Tran_Cashier;
                        rBatch["BatchStat"] = "U";
                        rBatch["PostDate"] = DBNull.Value;
                        rBatch["UserID"] = AaDeclrationClass.xUserCode.ToString();
                        rBatch["REVBatch"] = 0;
                        rBatch["REVBatchNo"] = 0;
                        rBatch["REVBatchPRD"] = "";
                        rBatch["PropertyCode"] = 0;
                        rBatch["AllocationCode"] = "";
                        rBatch["Tran_Cashier"] = true;
                        dbAccountingProjectDS.Batch.Rows.Add(rBatch);
                        AddJVTransactionAccounts();
                        drBatch.Close();
                        sqlconBatch.Close();
                        update();
                        MessageBox.Show("JV Transaction Record inserted successfully", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GeneralFunctions.UnLockTable("", "JVTran_Cashier", "", "New");
                        btn_Post.Enabled = true;
                        btnNew.Visible = true;
                        btnSaveNew.Visible = false;
                        btnFind.Enabled = true;
                        DisableAll();
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;

                    }

                }
                else
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Lodger");
            }
        }
        private bool ValidateYear()
        {
            bool valid = true;
            SqlConnection sqlconnectValidate = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand sqlcommandValidate;
            sqlcommandValidate = new SqlCommand("Select Status From GLFiscalPeriodSetup WHERE FiscalYear=" + Convert.ToDateTime(DTP_JVDate.Value).Year + "", sqlconnectValidate);
            sqlconnectValidate.Open();
            SqlDataReader sqlRead = sqlcommandValidate.ExecuteReader();
            string StatusValue = "";
            if (sqlRead.HasRows)
            {
                while (sqlRead.Read())
                {
                    StatusValue = sqlRead.GetString(0);
                    if (StatusValue == "CLOSED")
                    {
                        errorProvider1.SetError(DTP_JVDate, "The given Year is closed");
                        MessageBox.Show("The given Year is closed");
                        valid = false;
                    }
                    else if (StatusValue == "OPEN")
                    {
                        errorProvider1.SetError(DTP_JVDate, "");
                        valid = true;
                    }
                }
            }
            else
            {
                errorProvider1.SetError(DTP_JVDate, "The given year isn't exists for fiscal year");
                MessageBox.Show("The given year isn't exists for fiscal year");
                valid = false;
            }
            errorProvider1.SetError(DTP_JVDate, "");
            return valid;
        }
        private bool ValidatePeriod()
        {
            bool valid = true;
            SqlConnection sqlconnectValidate = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand sqlcommandValidate;
            sqlcommandValidate = new SqlCommand("Select Status From GLFiscalPeriod WHERE PeriodDescription='" + txt_Period.Text + "' AND YEAR(PeriodStartDate)=" + DTP_JVDate.Value.Year + "", sqlconnectValidate);
            sqlconnectValidate.Open();
            SqlDataReader sqlRead = sqlcommandValidate.ExecuteReader();
            string StatusValue = "";
            if (sqlRead.HasRows)
            {
                while (sqlRead.Read())
                {
                    StatusValue = sqlRead.GetString(0);
                    if (StatusValue == "CLOSED")
                    {
                        errorProvider1.SetError(txt_Period, "The given period is closed");
                        MessageBox.Show("The given period is closed");
                        valid = false;
                    }
                    else if (StatusValue == "OPEN")
                    {
                        errorProvider1.SetError(txt_Period, "");
                        valid = true;
                    }
                }
            }
            else
            {
                errorProvider1.SetError(txt_Period, "The given period isn't exists for this year");
                MessageBox.Show("The given period isn't exists for this year");
                valid = false;
            }
            errorProvider1.SetError(txt_Period, "");
            return valid;
        }
        private void btnUndo_Click(object sender, EventArgs e)
        {

            if (groupDetails.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnFind.Enabled = true;
            btnNew.Enabled = true;
            btnNew.Visible = true;
            btnSaveNew.Visible = false;
            btnEdit.Visible = true;
            btnSaveEdit.Visible = false;
            btnDelete.Visible = true;

            ClearAll();
            DisableAll();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtStatus.Text == "P")
            {
                MessageBox.Show("This JV Posted Can't Edit", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            btn_Post.Enabled = false;
            btnFind.Enabled = false;
            btnSaveEdit.Visible = true;
            btnSaveEdit.Enabled = true;
            btnEdit.Visible = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            EnableAll();

        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            DataRow[] drAC;
            drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txtAccount_Debit.Text + "'");
            if (drAC.Length == 0)
            {
                MessageBox.Show("Check Account Debit", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txtAccount_Credit.Text + "'");
            if (drAC.Length == 0)
            {
                MessageBox.Show("Check Account Credit", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txt_Amount.Text == "0")
            {
                //DialogResult myrst;
                //string s = " Amount = 0 , Are You Sure Save";
                //myrst = MessageBox.Show(s, "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (myrst == DialogResult.No)
                //    return;
                MessageBox.Show("Amount = 0", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ValidateYear() && ValidatePeriod())
            {
                SqlConnection sqlconnEditing = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlconnEditing.Open();
                SqlCommand sqlcommandEditing = new SqlCommand("Update Batch SET BatchDate= '" + string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value.Date) + "',BatchPRD='" + txt_Period.Text + "',BatchDSC='" + txt_JVDescription.Text + "',BatchJNL='" + JNL_Tran_Cashier + "',UserID='" + AaDeclrationClass.xUserCode.ToString() + "',REVBatch= 0,REVBatchPRD='' WHERE BatchNo=" + Convert.ToInt32(txtBatch.Text) + "", sqlconnEditing);
                int x = sqlcommandEditing.ExecuteNonQuery();
                if (x == 1)
                {
                    EditJVAccounts();
                    update();
                    MessageBox.Show("Editing Succcessfuly", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_Post.Enabled = true;
                    btnSaveEdit.Visible = false;
                    btnEdit.Visible = true;
                    btnEdit.Enabled = true;
                    btnNew.Enabled = true;
                    btnFind.Enabled = true;
                    btnNew.Visible = true;
                    btnDelete.Enabled = true;
                    DisableAll();
                }
                else
                {
                    MessageBox.Show("Update Failed");
                    DisableAll();
                    return;
                }


            }
            else
            {
                MessageBox.Show("Can't perform edit operation", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                EnableAll();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtStatus.Text == "P")
            {
                MessageBox.Show("This Batch is Posted Can't Deleted", "General Ledger");
                return;
            }
            DialogResult myrst;
            myrst = MessageBox.Show("Are You Sure Delete This Batch", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return;
            try
            {
                SqlConnection sqlconndelete = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlconndelete.Open();
                SqlCommand sqlcommandDeletetran = new SqlCommand("Delete From GLTransactions Where BatchNo=" + Convert.ToInt32(txtBatch.Text) + "", sqlconndelete);
                SqlDataReader drDeletetran = sqlcommandDeletetran.ExecuteReader();
                drDeletetran.Close();
                SqlCommand sqlcommandDelete = new SqlCommand("Delete From Batch Where BatchNo=" + Convert.ToInt32(txtBatch.Text) + "", sqlconndelete);
                SqlDataReader drDelete = sqlcommandDelete.ExecuteReader();
                if (drDelete != null)
                {
                    MessageBox.Show("Delete Successfully");
                    btnDelete.Visible = true;
                    btnDelete.Enabled = false;
                    btnNew.Enabled = true;
                    btnNew.Visible = true;
                    btnEdit.Enabled = false;
                }
                drDelete.Close();
                sqlconndelete.Close();
                ClearAll();
                DisableAll();
                refill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void PDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            //this.DrawToBitmap(bmp, this.ClientRectangle);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height)); //Takes the Snap of the Exact WindowForm size as Bitmap image
            e.Graphics.DrawImage(bmp, 0, 0);
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog1.Document = PrintDocument1;
            PageSetupDialog1.Document = PrintDocument1;
            frmPrint fpr = new frmPrint();
            fpr.ShowDialog();
            if (fpr.Result > 0)
            {
                try
                {
                    if (fpr.Result == 1) // Print
                    {
                        PrintDocument1.DefaultPageSettings.Landscape = false;
                        PrintDocument1.PrintPage += PDoc_PrintPage;
                        PrintDocument1.Print();
                    }
                    else if (fpr.Result == 2) // Page Setup
                    {
                        PrintDocument1.DefaultPageSettings.Landscape = true;
                        PrintDocument1.PrintPage += PDoc_PrintPage;
                        PrintDocument1.Print();
                    }
                }
                catch (Exception err1)
                {
                    MessageBox.Show(err1.Message);
                }
            }
        }

        private bool CheckBalanceAccType()
        {
            bool flage = false;
            int BS = 0;
            int PL = 0;
            ValBS = 0;
            ValPT = 0;
            double amt = 0; double.TryParse(txt_Amount.Text, out amt);
            if (txtAccount_Debit_Name.Tag.ToString() == "Assets" || txtAccount_Debit_Name.Tag.ToString() == "Liability" || txtAccount_Debit_Name.Tag.ToString() == "Equity")
            {
                BS++;
                ValBS = ValBS + amt;
            }
            else if (txtAccount_Debit_Name.Tag.ToString() == "Revenue" || txtAccount_Debit_Name.Tag.ToString() == "Expenses")
            {
                PL++;
                ValPT = ValPT + amt;
            }
            if (txtAccount_Credit_Name.Tag.ToString() == "Assets" || txtAccount_Credit_Name.Tag.ToString() == "Liability" || txtAccount_Credit_Name.Tag.ToString() == "Equity")
            {
                BS++;
                ValBS = ValBS - amt;
            }
            else if (txtAccount_Credit_Name.Tag.ToString() == "Revenue" || txtAccount_Credit_Name.Tag.ToString() == "Expenses")
            {
                PL++;
                ValPT = ValPT - amt;
            }
            if (BS > 0 && PL > 0)
                flage = true;
            else
            {
                flage = false;
                ValPT = 0;
                ValBS = 0;
            }
            return flage;
        }

        private void btn_Post_Click(object sender, EventArgs e)
        {
            try
            {
                refill();
                string msg = GeneralFunctions.CheckLockTables("GLTotals", "", "", "Edit");
                if (msg != "")
                {
                    MessageBox.Show("Can't Run Because GLTotals Edit By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                GeneralFunctions.LockTables("GLTotals", "JVTran_Cashier", "", "Edit");
                if (ValidateYear() && ValidatePeriod())
                {

                    string prdbalance = "";
                    double val = 0;
                    int NewBNo = 0;
                    if (txt_Amount.Text == "0")
                    {
                        MessageBox.Show("Amount = 0", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (txtBatch.Text != "")
                    {
                        if (CheckBalanceAccType() != false)
                        {
                            AddAccountsForBS_PL();
                        }
                        DataRow[] drbatch = this.dbAccountingProjectDS.Batch.Select("BatchNo=" + Convert.ToInt32(txtBatch.Text) + " AND BatchStat='U'");
                        if (drbatch.Length != 0)
                        {
                            drbatch[0]["BatchStat"] = "P";
                            drbatch[0]["PostDate"] = DateTime.Now.ToShortDateString();
                            DataRow[] transactionArray = this.dbAccountingProjectDS.GLTransactions.Select("BatchNo=" + Convert.ToInt32(txtBatch.Text) + "");
                            if (transactionArray.Length != 0)
                            {
                                string st = string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value);
                                prdbalance = FindPeriod(st);
                                for (int i = 0; i < transactionArray.Length; i++)
                                {
                                    DataRow[] Acctype = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + transactionArray[i]["GLAccount"].ToString() + "'");
                                    if (Acctype.Length != 0)
                                    {
                                        if (Acctype[0]["AccountTypeName"].ToString() != "Statictical")
                                            val = double.Parse(transactionArray[i]["AmountLC"].ToString());
                                        else
                                            val = double.Parse(transactionArray[i]["TRANSUnit"].ToString());
                                    }
                                    ModifyTotals(prdbalance, transactionArray[i]["GLAccount"].ToString(), val, Convert.ToDateTime(drbatch[0]["BatchDate"].ToString()).Date);
                                }
                            }
                        }
                    }
                    update();
                    MessageBox.Show("The given Batch is posted", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStatus.Text = "P";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
            finally
            {
                GeneralFunctions.UnLockTable("GLTotals", "JVTran_Cashier", "", "Edit");
            }

        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {
            if (txtStatus.Text == "P")
            {
                if (groupDetails.Enabled == true)
                {
                    btn_Post.Enabled = false;
                    btnCopy.Enabled = false;
                }
                else if (groupDetails.Enabled == false)
                {
                    btn_Post.Enabled = false;
                    btnCopy.Enabled = true;

                }
            }
            else if (txtStatus.Text == "U")
            {
                if (groupDetails.Enabled == true)
                {
                    btn_Post.Enabled = false;
                    btnCopy.Enabled = false;
                }
                else if (groupDetails.Enabled == false)
                {
                    btn_Post.Enabled = true;
                    btnCopy.Enabled = false;
                }

            }
            else
            {
                btnCopy.Enabled = false;

            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            EnableAll();
            txtFind.Text = "";
            DTP_JVDate.Value = DateTime.Now;
            currentJVNumber = GeneralFunctions.CreateJVNumberFormat(GeneralFunctions.lblJV, GeneralFunctions.JVNumberFormat, true);
            txt_JVNumber.Text = currentJVNumber;
            //******************************************
            string periodName;
            if (GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value.Date), out currentPeriodID, out periodName, out currentEndDate))
                txt_Period.Text = periodName;
            else
                MessageBox.Show("The period has been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //*************************************
            txtBatch.Text = NewBatchNo().ToString();
            //*************************************
            btnNew.Visible = false;
            btnSaveNew.Visible = true;
            btnFind.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSaveEdit.Enabled = false;
            txtStatus.Text = "U";


        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txtFind.Text != "" && txtFind.Text != "0")
                    FindBatch(txtFind.Text);
            }
        }

        private void btnFind_EnabledChanged(object sender, EventArgs e)
        {
            if (btnFind.Enabled == true)
                txtFind.Enabled = true;
            else
                txtFind.Enabled = false;
        }

        private void refill()
        {
            dbAccountingProjectDS = new dbAccountingProjectDS();
            adaptertbGLProjectCodes.Fill(dbAccountingProjectDS.GLProjectCodes);
            adaptertbGLJournalCodes.Fill(dbAccountingProjectDS.GLJournalCodes);
            adaptertbFiscalPeriod.Fill(dbAccountingProjectDS.GLFiscalPeriod);
            adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
            adaptertbGLTotals.Fill(dbAccountingProjectDS.GLTotals);
            adaptertbCurrency.Fill(dbAccountingProjectDS.GLCurrency);
            adaptertbBatch.Fill(dbAccountingProjectDS.Batch);
            adaptertbMYGLTransactions.Fill(dbAccountingProjectDS.GLTransactions);
            adaptertbBatchTemp.Fill(dbAccountingProjectDS.BatchTemp);
            adaptertbMYGLTransactionsTemp.Fill(dbAccountingProjectDS.GLTransactionsTemp);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            adaptertbG_L_GeneralSetup.Fill(dbAccountingProjectDS.G_L_GeneralSetup);

        }

        private void DTP_JVDate_ValueChanged(object sender, EventArgs e)
        {
            string periodName;
            if (GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value.Date), out currentPeriodID, out periodName, out currentEndDate))
                txt_Period.Text = periodName;
            else
                MessageBox.Show("The period has been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void JVTran_Cashier_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralFunctions.UnLockTable("", "JVTran_Cashier", "", "");
        }

        private void txt_Balance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                if (txt_Amount.Text.Contains("."))
                {
                    char c = '.';
                    string[] sc = txt_Amount.Text.Split(c);

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
                if (txt_Amount.Text.Contains(".") == false)
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void txtAccount_Debit_DoubleClick(object sender, EventArgs e)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.filter = " AND AccountTypeName <> 'Header'";
            accSearch.ShowDialog();
            if (accSearch.selectedAccountName != null && accSearch.selectedAccountNumber != null && accSearch.selectedAccountType != null && accSearch.selectedAccountType != "Header")
            {
                txtAccount_Debit.Text = accSearch.selectedAccountNumber;
                txtAccount_Debit_Name.Text = accSearch.selectedAccountName;
                txtAccount_Debit_Name.Tag = accSearch.selectedAccountType;

            }
        }

        private void txtAccount_Credit_DoubleClick(object sender, EventArgs e)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.filter = " AND AccountTypeName <> 'Header'";
            accSearch.ShowDialog();
            if (accSearch.selectedAccountName != null && accSearch.selectedAccountNumber != null && accSearch.selectedAccountType != null && accSearch.selectedAccountType != "Header")
            {
                txtAccount_Credit.Text = accSearch.selectedAccountNumber;
                txtAccount_Credit_Name.Text = accSearch.selectedAccountName;
                txtAccount_Credit_Name.Tag = accSearch.selectedAccountType;

            }
        }

        private void txtAccount_Debit_Leave(object sender, EventArgs e)
        {
            DataRow[] drAC;
            drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txtAccount_Debit.Text + "'");
            if (drAC.Length != 0)
            {
                txtAccount_Debit.Text = drAC[0]["AccountNumber"].ToString();
                txtAccount_Debit_Name.Text = drAC[0]["AccountName"].ToString();
                txtAccount_Debit_Name.Tag = drAC[0]["AccountTypeName"].ToString();
            }
            else
            {
                txtAccount_Debit.Text = "";
                txtAccount_Debit_Name.Text = "";
                txtAccount_Debit_Name.Tag = "";
            }
        }

        private void txtAccount_Credit_Leave(object sender, EventArgs e)
        {
            DataRow[] drAC;
            drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txtAccount_Credit.Text + "'");
            if (drAC.Length != 0)
            {
                txtAccount_Credit.Text = drAC[0]["AccountNumber"].ToString();
                txtAccount_Credit_Name.Text = drAC[0]["AccountName"].ToString();
                txtAccount_Credit_Name.Tag = drAC[0]["AccountTypeName"].ToString();
            }
            else
            {
                txtAccount_Credit.Text = "";
                txtAccount_Credit_Name.Text = "";
                txtAccount_Credit_Name.Tag = "";
            }
        }
    }
}