using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Accounting_GeneralLedger.Resources;

namespace Accounting_GeneralLedger
{
    public partial class AP_Manual_Check : Form
    {
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbBatchInvoices;
        private SqlCommandBuilder cmdBuilderBatchInvoices;
        private SqlDataAdapter adaptertbAccounts;
        private SqlDataAdapter adaptertbFiscalPeriod;
        private SqlDataAdapter adaptertbGLTotals;
        private SqlDataAdapter adaptertbBatch;
        private SqlDataAdapter adaptertbChecks_Serial;
        private SqlDataAdapter adaptertbCheck_Pay_Invoice;
        private SqlDataAdapter adaptertbG_L_GeneralSetup;
        private SqlDataAdapter adaptertbGLTransactions;
        private SqlDataAdapter adaptertbGeneralSetup;
        private SqlCommandBuilder cmdBuilderGLTotals;
        private SqlCommandBuilder cmdBuilderBatch;
        private SqlCommandBuilder cmdBuilderChecks_Serial;
        private SqlCommandBuilder cmdBuilderCheck_Pay_Invoice;
        private SqlCommandBuilder cmdGLTransactions;
        private DataTable dtInvoice;
        private int decmal = 1;
        private int currentPeriodID;
        private static DateTime currentEndDate;
        private string JNL_BankDeposit = "";
        private string DefaultACCBalanceSheet = "";
        private string DefaultACCIncomeStatment = "";
        private string AccountNumberFormat;
        private double ValBS = 0;
        private double ValPT = 0;

        public AP_Manual_Check()
        {
            InitializeComponent();
        }

        private void AP_Manual_Check_Load(object sender, EventArgs e)
        {
            string msg = GeneralFunctions.CheckLockTables("", "AP_Manual_Check", "", "Open");
            if (msg != "")
            {
                MessageBox.Show("AP_Manual_Check Open By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btn_Save.Visible = false;
            }
            GeneralFunctions.LockTables("", "AP_Manual_Check", "", "Open");
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbChecks_Serial = new SqlDataAdapter("Select * from Checks_Serial", sqlcon);
            adaptertbCheck_Pay_Invoice = new SqlDataAdapter("Select * from Check_Pay_Invoice", sqlcon);
            adaptertbBatch = new SqlDataAdapter("Select * from Batch", sqlcon);
            adaptertbBatchInvoices = new SqlDataAdapter("Select * from APTrans", sqlcon);

            cmdBuilderBatchInvoices = new SqlCommandBuilder(adaptertbBatchInvoices);
            cmdBuilderBatch = new SqlCommandBuilder(adaptertbBatch);
            cmdBuilderChecks_Serial = new SqlCommandBuilder(adaptertbChecks_Serial);
            cmdBuilderCheck_Pay_Invoice = new SqlCommandBuilder(adaptertbCheck_Pay_Invoice);
            adaptertbBatchInvoices.Fill(dbAccountingProjectDS.APTrans);
            adaptertbBatch.Fill(dbAccountingProjectDS.Batch);
            adaptertbChecks_Serial.Fill(dbAccountingProjectDS.Checks_Serial);
            adaptertbCheck_Pay_Invoice.Fill(dbAccountingProjectDS.Check_Pay_Invoice);

            adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts", sqlcon);
            adaptertbFiscalPeriod = new SqlDataAdapter("Select * from GLFiscalPeriod", sqlcon);
            adaptertbGLTotals = new SqlDataAdapter("Select * from GLTotals", sqlcon);
            adaptertbGLTransactions = new SqlDataAdapter("Select * From GLTransactions", sqlcon);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbG_L_GeneralSetup = new SqlDataAdapter("Select * from G_L_GeneralSetup", sqlcon);
            cmdBuilderGLTotals = new SqlCommandBuilder(adaptertbGLTotals);
            cmdGLTransactions = new SqlCommandBuilder(adaptertbGLTransactions);
            adaptertbFiscalPeriod.Fill(dbAccountingProjectDS.GLFiscalPeriod);
            adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
            adaptertbGLTotals.Fill(dbAccountingProjectDS.GLTotals);
            adaptertbGLTransactions.Fill(dbAccountingProjectDS.GLTransactions);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            adaptertbG_L_GeneralSetup.Fill(dbAccountingProjectDS.G_L_GeneralSetup);
            foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            {
                GeneralFunctions.BankNumberFormat = dr["BankNumberFormat"].ToString();
                GeneralFunctions.DecimalPointsNumber = int.Parse(dr["DecimalPointsNumber"].ToString());
                AccountNumberFormat = dr["AccountNumberFormat"].ToString();
                decmal = int.Parse(dr["DecimalPointsNumber"].ToString());
                GeneralFunctions.lblBank = dr["lblBank"].ToString();
            }

            DataRow[] drs = dbAccountingProjectDS.G_L_GeneralSetup.Select();
            if (drs.Length != 0)
            {
                DefaultACCBalanceSheet = drs[0]["BalanceSheet"].ToString();
                DefaultACCIncomeStatment = drs[0]["IncomeStatment"].ToString();
                JNL_BankDeposit = drs[0]["BankDepost"].ToString();
                if (DefaultACCBalanceSheet == "" || DefaultACCIncomeStatment == "")
                {
                    MessageBox.Show("Please Check AccountBalanceSheet And AccountIncomeStatment In G/L GeneralSetup ", "Error");
                    this.Close();
                }
            }
            dtInvoice = new DataTable();
            dtInvoice.Columns.Add("InvoiceID", System.Type.GetType("System.Int32"));
            dtInvoice.Columns.Add("Select", System.Type.GetType("System.Boolean"));
            dtInvoice.Columns.Add("VendorCode", System.Type.GetType("System.String"));
            dtInvoice.Columns.Add("InvoiceDate", System.Type.GetType("System.DateTime"));
            dtInvoice.Columns.Add("Reference", System.Type.GetType("System.String"));
            dtInvoice.Columns.Add("InvoiceAmount", System.Type.GetType("System.Double"));
            dtInvoice.Columns.Add("TaxValue", System.Type.GetType("System.Double"));
            dtInvoice.Columns.Add("AmountPaid", System.Type.GetType("System.Double"));
            dtInvoice.Columns.Add("Balance", System.Type.GetType("System.Double"));
            dtInvoice.Columns.Add("AmtApplied", System.Type.GetType("System.Double"));
            dtInvoice.Columns.Add("AppliedBalance", System.Type.GetType("System.Double"));
            dtInvoice.Columns.Add("Curr.", System.Type.GetType("System.String"));
            dgv_AccountCharges.DataSource = dtInvoice;
            dgv_AccountCharges.Refresh();
            dgv_AccountCharges.Columns["InvoiceID"].Visible = false;
            dgv_AccountCharges.Columns["Select"].ReadOnly = true;
            dgv_AccountCharges.Columns["VendorCode"].ReadOnly = true;
            dgv_AccountCharges.Columns["InvoiceDate"].ReadOnly = true;
            dgv_AccountCharges.Columns["Reference"].ReadOnly = true;
            dgv_AccountCharges.Columns["InvoiceAmount"].ReadOnly = true;
            dgv_AccountCharges.Columns["TaxValue"].ReadOnly = true;
            dgv_AccountCharges.Columns["AmountPaid"].ReadOnly = true;
            dgv_AccountCharges.Columns["Balance"].ReadOnly = true;
            dgv_AccountCharges.Columns["AppliedBalance"].ReadOnly = true;
            dgv_AccountCharges.Columns["Curr."].ReadOnly = true;
            dgv_AccountCharges.Columns["Curr."].Visible = false;
            dgv_AccountCharges.Columns["AmtApplied"].DefaultCellStyle.BackColor = Color.LightGray;
            string periodName;
            if (GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value.Date), out currentPeriodID, out periodName, out currentEndDate))
                txt_Period.Text = periodName;
            else
                MessageBox.Show("The period has been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            DataTable DtCat = DataClass.RetrieveData("Select Bank_Deposit_Type_ID,Bank_Deposit_Type_Name From Bank_Deposit_Type ");
            cb_Bank_Account_ID.DataSource = DtCat;
            cb_Bank_Account_ID.DisplayMember = "Bank_Deposit_Type_Name";
            cb_Bank_Account_ID.ValueMember = "Bank_Deposit_Type_ID";
            cb_Bank_Account_ID.SelectedIndex = -1;

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            VendorSearch search = new VendorSearch();
            search.ApplyCredits = "Credits";
            search.ShowDialog();
            if (search.selectedVendorCode != null)
            {
                if (search.selectedVendorCode != "")
                {
                    txt_VendorCode.Text = search.selectedVendorCode;
                    DataRow rc;
                    dtInvoice.Clear();
                    DataRow[] drs = dbAccountingProjectDS.APTrans.Select("VendorCode = '" + search.selectedVendorCode + "' AND TransactionType = 'Invoice' and MultiCurrency = 0 and Paid = 0 ", "InvoiceDate");
                    if (drs.Length != 0)
                    {
                        for (int i = 0; i < drs.Length; i++)
                        {
                            rc = dtInvoice.NewRow();
                            rc["InvoiceID"] = int.Parse(drs[i]["BatchInvoiceID"].ToString());
                            rc["Select"] = false;
                            rc["VendorCode"] = drs[i]["VendorCode"].ToString();
                            rc["InvoiceDate"] = Convert.ToDateTime(drs[i]["InvoiceDate"].ToString());
                            rc["Reference"] = drs[i]["Reference"].ToString();
                            rc["InvoiceAmount"] = double.Parse(drs[i]["InvoiceAmount"].ToString());
                            rc["TaxValue"] = double.Parse(drs[i]["TaxValue"].ToString());
                            rc["AmountPaid"] = double.Parse(drs[i]["AmountPaid"].ToString());
                            rc["Balance"] = double.Parse(drs[i]["InvoiceAmount"].ToString()) - double.Parse(drs[i]["TaxValue"].ToString()) - double.Parse(drs[i]["AmountPaid"].ToString());
                            rc["AmtApplied"] = 0;
                            rc["AppliedBalance"] = double.Parse(drs[i]["InvoiceAmount"].ToString()) - double.Parse(drs[i]["TaxValue"].ToString()) - double.Parse(drs[i]["AmountPaid"].ToString());
                            rc["Curr."] = drs[i]["CurrencyCode"].ToString();
                            dtInvoice.Rows.Add(rc);
                        }
                        dgv_AccountCharges.Refresh();
                    }
                    for (int c = 0; c < dgv_AccountCharges.ColumnCount - 1; c++)
                    {
                        dgv_AccountCharges.Columns[c].SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
            }

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (cb_Bank_Account_ID.SelectedIndex == -1)
                {
                    MessageBox.Show("Select Bank ", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (cb_Check_Serial.SelectedIndex == -1)
                {
                    MessageBox.Show("Select Check Serial ", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                double check_total = 0; double.TryParse(txt_Checks_Total.Text, out check_total);
                if (check_total <= 0)
                {
                    MessageBox.Show("Check Total Zero ", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                string currentBankNumber = GeneralFunctions.CreateBankNumberFormat(GeneralFunctions.lblBank, GeneralFunctions.BankNumberFormat, true);
                if (ValidateYear() && ValidatePeriod())
                {
                    ArrayList IDArr = new ArrayList();
                    int ID = 0;
                    DataRow dr;
                    DataRow[] drs;
                    DataGridViewRow dgvr;
                    double total = 0;
                    foreach (DataGridViewRow rb in dgv_AccountCharges.Rows)
                    {
                        total = total + double.Parse(rb.Cells["AmtApplied"].Value.ToString());
                    }
                    for (int i = 0; i < dgv_AccountCharges.Rows.Count; i++)
                    {
                        dgvr = dgv_AccountCharges.Rows[i];
                        ID = int.Parse(dgvr.Cells["InvoiceID"].Value.ToString().Trim());
                        double Balance = double.Parse(dgvr.Cells["AppliedBalance"].Value.ToString());
                        double PaidAmount = double.Parse(dgvr.Cells["AmountPaid"].Value.ToString());
                        double AmtApplied = double.Parse(dgvr.Cells["AmtApplied"].Value.ToString());
                        drs = dbAccountingProjectDS.APTrans.Select("BatchInvoiceID = " + ID);
                        if (drs.Length != 0)
                        {
                            drs[0]["AmountPaid"] = PaidAmount + AmtApplied;
                            if (Balance == 0)
                                drs[0]["Paid"] = true;
                        }
                       DataRow drr = this.dbAccountingProjectDS.Check_Pay_Invoice.NewRow();
                       drr["Bank_Account_ID"] = cb_Bank_Account_ID.SelectedValue.ToString();
                       drr["Check_Serial"] = cb_Check_Serial.Text;
                       drr["BatchInvoiceID"] = ID;
                       drr["Amt_To_Paid"] = AmtApplied;
                       drr["UserID"] = AaDeclrationClass.xUserCode.ToString(); ;
                       drr["Create_Date"] = DateTime.Now;
                       dbAccountingProjectDS.Check_Pay_Invoice.Rows.Add(drr);

                    }
                    drs = dbAccountingProjectDS.Checks_Serial.Select("Bank_Account_ID = " + cb_Bank_Account_ID.SelectedValue.ToString() + " AND Check_Serial = " + cb_Check_Serial.Text);
                    if (drs.Length != 0)
                    {
                        drs[0]["Used"] = true;
                        drs[0]["Description"] = txt_JVDescription.Text;
                        drs[0]["Amount"] = check_total;
                        drs[0]["Check_Date"] = DTP_Check_Date.Value.Date;
                    }
                    
                    int BatchNo = NewBatchNo();
                    DataRow rBatch = this.dbAccountingProjectDS.Batch.NewRow();
                    rBatch["BatchNo"] = BatchNo;
                    rBatch["JVNumber"] = currentBankNumber;
                    rBatch["BatchDate"] = DTP_JVDate.Value.Date; //string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value.Date);
                    rBatch["BatchPRD"] = txt_Period.Text;
                    rBatch["BatchDSC"] = txt_JVDescription.Text;
                    rBatch["BatchSRC"] = "Bank";
                    rBatch["BatchJNL"] = JNL_BankDeposit;
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
                    string APAccountNumber = DataClass.ReturnRecordNameByID("Select APAccountNumber From APGeneralSetup ");
                    DataRow r;
                    r = this.dbAccountingProjectDS.GLTransactions.NewRow();
                    r["TransNO"] = NewTransNoGL();
                    r["BatchNo"] = BatchNo;
                    r["GLAccount"] = APAccountNumber;
                    r["TRANSREF"] = "";
                    r["TRANSDATE"] = DTP_JVDate.Value.Date;
                    r["TRANSUnit"] = 0;
                    r["Amount"] = 0;
                    r["AmountLC"] = check_total;
                    r["CurrencyType"] = "";
                    r["Rate"] = "0";
                    r["ProjectCode"] = "";
                    r["DepartmentCode"] = "";
                    r["SortNO"] = 1;
                    dbAccountingProjectDS.GLTransactions.Rows.Add(r);
                    string Bank_GL_Account = DataClass.ReturnRecordNameByID("Select Bank_GL_Account From Bank_Account_Setup Where Bank_Account_ID = " + cb_Bank_Account_ID.SelectedValue.ToString());
                    r = this.dbAccountingProjectDS.GLTransactions.NewRow();
                    r["TransNO"] = NewTransNoGL();
                    r["BatchNo"] = BatchNo;
                    r["GLAccount"] = Bank_GL_Account;
                    r["TRANSREF"] = "";
                    r["TRANSDATE"] = DTP_JVDate.Value.Date;
                    r["TRANSUnit"] = 0;
                    r["Amount"] = 0;
                    r["AmountLC"] = -1 * check_total;
                    r["CurrencyType"] = "";
                    r["Rate"] = "0";
                    r["ProjectCode"] = "";
                    r["DepartmentCode"] = "";
                    r["SortNO"] = 2;
                    dbAccountingProjectDS.GLTransactions.Rows.Add(r);
                    string prdbalance = "";
                    double val = 0;
                    int NewBNo = 0;
                    UpdateDatabase();
                    if (CheckBalanceAccType(BatchNo) != false)
                    {
                        AddAccountsForBS_PL(BatchNo);
                    }
                    DataRow[] drbatch = this.dbAccountingProjectDS.Batch.Select("BatchNo=" + BatchNo + " AND BatchStat='U'");
                    if (drbatch.Length != 0)
                    {
                        drbatch[0]["BatchStat"] = "P";
                        drbatch[0]["PostDate"] = DateTime.Now.ToShortDateString();
                        DataRow[] transactionArray = this.dbAccountingProjectDS.GLTransactions.Select("BatchNo=" + BatchNo + "");
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

                    UpdateDatabase();
                    MessageBox.Show("Save Successfully", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            return No;
        }
        private int NewTransNoGL()
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
        private bool CheckBalanceAccType(int bat)
        {
            bool flage = false;
            int BS = 0;
            int PL = 0;
            ValBS = 0;
            ValPT = 0;
            DataRow[] drbat;
            drbat = dbAccountingProjectDS.GLTransactions.Select("BatchNo = '" + bat + "'");
            DataRow r;
            for (int i = 0; i < drbat.Length; i++)
            {
                r = drbat[i];
                if (r["GLAccount"].ToString() == "")
                    break;
                if (AccType(r["GLAccount"].ToString()) == "Assets" || AccType(r["GLAccount"].ToString()) == "Liability" || AccType(r["GLAccount"].ToString()) == "Equity")
                {
                    BS++;
                    if (double.Parse(r["AmountLC"].ToString()) != 0)
                        ValBS = ValBS + double.Parse(r["AmountLC"].ToString());
                }
                else if (AccType(r["GLAccount"].ToString()) == "Revenue" || AccType(r["GLAccount"].ToString()) == "Expenses")
                {
                    PL++;
                    if (double.Parse(r["AmountLC"].ToString()) != 0)
                        ValPT = ValPT + double.Parse(r["AmountLC"].ToString());
                }
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
        private void AddAccountsForBS_PL(int bat)
        {
            try
            {
                string s = string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value.Date);
                string prdbalance = FindPeriod(s);
                DataRow r;
                r = this.dbAccountingProjectDS.GLTransactions.NewRow();
                r["TransNO"] = NewTransNoGL();
                r["BatchNo"] = bat;
                r["GLAccount"] = DefaultACCBalanceSheet; //txt_JVNumber.Text;
                r["TRANSREF"] = "BalanceSheet";
                r["TRANSDATE"] = DateTime.Now.ToShortDateString();
                r["Amount"] = "0";
                r["AmountLC"] = -1 * ValBS;
                r["CurrencyType"] = "";
                r["Rate"] = "0";
                r["ProjectCode"] = "";
                r["DepartmentCode"] = "";
                r["SortNO"] = 0;

                dbAccountingProjectDS.GLTransactions.Rows.Add(r);
                ModifyTotals(prdbalance, DefaultACCBalanceSheet, ValBS, DTP_JVDate.Value.Date);
                r = this.dbAccountingProjectDS.GLTransactions.NewRow();
                r["TransNO"] = NewTransNoGL();
                r["BatchNo"] = bat;
                r["GLAccount"] = DefaultACCIncomeStatment; //txt_JVNumber.Text;
                r["TRANSREF"] = "IncomeStatment";
                r["TRANSDATE"] = DateTime.Now.ToShortDateString();
                r["Amount"] = "0";
                r["AmountLC"] = -1 * ValPT;
                r["CurrencyType"] = "";
                r["Rate"] = "0";
                r["ProjectCode"] = "";
                r["DepartmentCode"] = "";
                r["SortNO"] = 0;

                dbAccountingProjectDS.GLTransactions.Rows.Add(r);
                ModifyTotals(prdbalance, DefaultACCBalanceSheet, ValPT, DTP_JVDate.Value.Date);
                //update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string AccType(string Acc)
        {
            string acctype = "";
            DataRow[] dracc = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + Acc + "'");
            if (dracc.Length != 0)
            {
                acctype = dracc[0]["AccountTypeName"].ToString();
            }
            return acctype;
        }
        private string AccCode(string Acc)
        {
            string acccode = "";
            DataRow[] dracc = dbAccountingProjectDS.ARTransactionCodes.Select("TransCode = '" + Acc + "'");
            if (dracc.Length != 0)
            {
                acccode = dracc[0]["AccountNumber"].ToString();
            }
            return acccode;
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

        private void UpdateDatabase()
        {
            adaptertbGLTotals.Update(dbAccountingProjectDS.GLTotals);
            adaptertbBatch.Update(dbAccountingProjectDS.Batch);
            adaptertbGLTransactions.Update(dbAccountingProjectDS.GLTransactions);
            adaptertbBatchInvoices.Update(dbAccountingProjectDS.APTrans);
            adaptertbChecks_Serial.Update(dbAccountingProjectDS.Checks_Serial);
            adaptertbCheck_Pay_Invoice.Update(dbAccountingProjectDS.Check_Pay_Invoice);
            
            dbAccountingProjectDS.AcceptChanges();
        }

        private void dgv_AccountCharges_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dgv_AccountCharges_Control_KeyPress);

            e.Control.KeyPress += new KeyPressEventHandler(dgv_AccountCharges_Control_KeyPress);

        }
        private void dgv_AccountCharges_Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgv_AccountCharges.CurrentCell.ColumnIndex == 9)
            {
                if (e.KeyChar == 8)
                {

                    e.Handled = false;

                }
                else if (e.KeyChar >= 48 && e.KeyChar <= 57)
                {
                    if (dgv_AccountCharges.EditingControl.Text.ToString().Contains("."))
                    {
                        char c = '.';
                        string[] sc = dgv_AccountCharges.EditingControl.Text.ToString().Split(c);

                        if (sc[1].Length < decmal)
                        {
                            e.Handled = false;

                        }
                        else
                            e.Handled = true;

                    }
                    else
                    {
                        e.Handled = false;

                    }
                }
                else if (e.KeyChar == 46)
                {
                    if (dgv_AccountCharges.EditingControl.Text.ToString().Contains(".") == false)
                    {
                        e.Handled = false;

                    }
                    else
                        e.Handled = true;
                }
                else
                    e.Handled = true;
            }
        }

        private void dgv_AccountCharges_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!(bool)dgv_AccountCharges.Rows[e.RowIndex].Cells["Select"].Value && e.ColumnIndex != dgv_AccountCharges.Columns["Select"].Index)
            {
                e.Cancel = true;
                //MessageBox.Show("Select Invoice To Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //dgv_AccountCharges.EndEdit();
            }
        }
        private void CalcBalance()
        {
            double total = 0;
            foreach (DataGridViewRow r in dgv_AccountCharges.Rows)
            {
                total = total + double.Parse(r.Cells["AmtApplied"].Value.ToString());
            }
            txt_Checks_Total.Text = total.ToString();
        }
        private void dgv_AccountCharges_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (dgv_AccountCharges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null &&
                    dgv_AccountCharges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
                {
                    if (e.ColumnIndex == 9)
                    {
                        double AmtApplied = double.Parse(dgv_AccountCharges.Rows[e.RowIndex].Cells["AmtApplied"].Value.ToString());
                        double balance = double.Parse(dgv_AccountCharges.Rows[e.RowIndex].Cells["Balance"].Value.ToString());
                        if (balance < AmtApplied)
                        {
                            dgv_AccountCharges.Rows[e.RowIndex].Cells["AmtApplied"].Value = 0;
                            dgv_AccountCharges.Rows[e.RowIndex].Cells["AppliedBalance"].Value = balance;
                            MessageBox.Show("Invalid Amount, The Amount Applied cant exceed the invoice balance amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            dgv_AccountCharges.Rows[e.RowIndex].Cells["AppliedBalance"].Value = balance - AmtApplied;
                        }
                    }
                    else if (e.ColumnIndex == dgv_AccountCharges.Columns["Select"].Index)
                    {
                        double balance = double.Parse(dgv_AccountCharges.Rows[e.RowIndex].Cells["Balance"].Value.ToString());
                        if (!(bool)dgv_AccountCharges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                        {
                            dgv_AccountCharges.Rows[e.RowIndex].Cells["AmtApplied"].Value = 0;
                            dgv_AccountCharges.Rows[e.RowIndex].Cells["AppliedBalance"].Value = balance;
                        }
                        else
                        {
                            dgv_AccountCharges.Rows[e.RowIndex].Cells["AmtApplied"].Value = balance;
                            dgv_AccountCharges.Rows[e.RowIndex].Cells["AppliedBalance"].Value = 0;
                        }
                    }
                    CalcBalance();
                }
                else
                    dgv_AccountCharges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
            }
        }

        private void AP_Manual_Check_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralFunctions.UnLockTable("", "AP_Manual_Check", "", "");
        }

        private void DTP_JVDate_ValueChanged(object sender, EventArgs e)
        {
            string periodName;
            if (GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value.Date), out currentPeriodID, out periodName, out currentEndDate))
                txt_Period.Text = periodName;
            else
                MessageBox.Show("The period has been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cb_Bank_Account_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb_Bank_Account_ID.ValueMember != null && cb_Bank_Account_ID.ValueMember != "" && cb_Bank_Account_ID.SelectedIndex > -1)
                {
                    DataTable dt = DataClass.RetrieveData("SELECT Check_Serial FROM Checks_Serial WHERE (Bank_Account_ID = " + cb_Bank_Account_ID.SelectedValue.ToString() + ") AND Used = 0 AND Void = 0 Order By Check_Serial");
                    if (dt.Rows.Count > 0)
                    {
                        cb_Check_Serial.Items.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                            cb_Check_Serial.Items.Add(dt.Rows[i][0].ToString());
                        if (cb_Check_Serial.Items.Count > 0)
                            cb_Check_Serial.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
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

        private void dgv_AccountCharges_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv_AccountCharges.Columns["Select"].Index)
            {
                dgv_AccountCharges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !(bool)dgv_AccountCharges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                double balance = double.Parse(dgv_AccountCharges.Rows[e.RowIndex].Cells["Balance"].Value.ToString());
                if (!(bool)dgv_AccountCharges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    dgv_AccountCharges.Rows[e.RowIndex].Cells["AmtApplied"].Value = 0;
                    dgv_AccountCharges.Rows[e.RowIndex].Cells["AppliedBalance"].Value = balance;
                }
                else
                {
                    dgv_AccountCharges.Rows[e.RowIndex].Cells["AmtApplied"].Value = balance;
                    dgv_AccountCharges.Rows[e.RowIndex].Cells["AppliedBalance"].Value = 0;
                }
                CalcBalance();
            }
        }

        private void dgv_AccountCharges_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalcBalance();
        }

        private void dgv_AccountCharges_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalcBalance();
        }

    }
}