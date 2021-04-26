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
    public partial class Bank_Deposit : Form
    {
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbAccounts;
        private SqlDataAdapter adaptertbFiscalPeriod;
        private SqlDataAdapter adaptertbGLTotals;
        private SqlDataAdapter adaptertbBatch;
        private SqlDataAdapter adaptertbG_L_GeneralSetup;
        private SqlDataAdapter adaptertbGLTransactions;
        private SqlDataAdapter adaptertbGeneralSetup;
        private SqlCommandBuilder cmdBuilderGLTotals;
        private SqlCommandBuilder cmdBuilderBatch;
        private SqlCommandBuilder cmdGLTransactions;
        private int currentRowIndex = 0;
        private int currentPeriodID;
        private int decmal = 1;
        private static DateTime currentEndDate;
        private string ARCTYLEDGER = "";
        private string JNL_BankDeposit = "";
        private string DefaultACCBalanceSheet = "";
        private string DefaultACCIncomeStatment = "";
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private string AccountNumberFormat;
        private double ValBS = 0;
        private double ValPT = 0;
        System.Collections.SortedList Lst_Bank_Deposit_Type;
        public Bank_Deposit()
        {
            InitializeComponent();
        }

        private void Bank_Deposit_Load(object sender, EventArgs e)
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
                GeneralFunctions.LockTables("", "Bank_Deposit", "", "Open");
                // TODO: This line of code loads data into the 'dbAccountingProjectDS1.BatchTemp' table. You can move, or remove it, as needed.
                dbAccountingProjectDS = new dbAccountingProjectDS();
                sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
                adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts", sqlcon);
                adaptertbFiscalPeriod = new SqlDataAdapter("Select * from GLFiscalPeriod", sqlcon);
                adaptertbGLTotals = new SqlDataAdapter("Select * from GLTotals", sqlcon);
                adaptertbBatch = new SqlDataAdapter("Select * From Batch", sqlcon);
                adaptertbGLTransactions = new SqlDataAdapter("Select * From GLTransactions", sqlcon);
                adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
                adaptertbG_L_GeneralSetup = new SqlDataAdapter("Select * from G_L_GeneralSetup", sqlcon);
                cmdBuilderGLTotals = new SqlCommandBuilder(adaptertbGLTotals);
                cmdBuilderBatch = new SqlCommandBuilder(adaptertbBatch);
                cmdGLTransactions = new SqlCommandBuilder(adaptertbGLTransactions);
                adaptertbFiscalPeriod.Fill(dbAccountingProjectDS.GLFiscalPeriod);
                adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
                adaptertbGLTotals.Fill(dbAccountingProjectDS.GLTotals);
                adaptertbBatch.Fill(dbAccountingProjectDS.Batch);
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
                string periodName;
                if (GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value.Date), out currentPeriodID, out periodName, out currentEndDate))
                    txt_Period.Text = periodName;
                else
                    MessageBox.Show("The period has been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                if (GeneralFunctions.languagechioce != "")
                {
                    this.obj_options = new ClassOptions();
                    this.obj_options.report_language = GeneralFunctions.languagechioce;
                    this.update_language_interface();
                }

                DataTable DtCat = DataClass.RetrieveData("Select Bank_Deposit_Type_ID,Bank_Deposit_Type_Name From Bank_Deposit_Type ");
                cb_Bank_Deposit_Type.DataSource = DtCat;
                cb_Bank_Deposit_Type.DisplayMember = "Bank_Deposit_Type_Name";
                cb_Bank_Deposit_Type.ValueMember = "Bank_Deposit_Type_ID";
                cb_Bank_Deposit_Type.SelectedIndex = -1;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void update_language_interface()
        {
            //    try
            //    {
            //    this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            //    this.Text = obj_interface_language.formARTransactions;

            //    this.label7.Text = obj_interface_language.lblUserID;
            //    this.label6.Text = obj_interface_language.labelBatch;
            //    this.label12.Text = obj_interface_language.labelBatch;
            //    this.label1.Text = obj_interface_language.labelJVNumber;
            //    this.label11.Text = obj_interface_language.lblCountUnits;
            //    this.label2.Text = obj_interface_language.labelJVDescription;
            //    this.label3.Text = obj_interface_language.labelJVCode;
            //    this.label4.Text = obj_interface_language.labelJVDate;
            //    this.label10.Text = obj_interface_language.lblARTransactionsTemp;
            //    this.label5.Text = obj_interface_language.labelPeriod;
            //    this.label13.Text = obj_interface_language.labelPeriod;
            //    this.label9.Text = obj_interface_language.labelARTransactionsStatus;
            //    this.label8.Text = obj_interface_language.labelBalance;
            //    this.label_Currency.Text = obj_interface_language.currency;
            //    this.label_CurrencyRate.Text = obj_interface_language.lblCurrencyRate;
            //    this.checkBox_multiCurrency.Text = obj_interface_language.checkbox_multiCurrency;
            //    this.checkBox_Reverse.Text = obj_interface_language.checkbox_Reverse;

            //    this.btnNew.Text = obj_interface_language.buttonJVTransactionNew;
            //    this.btnEdit.Text = obj_interface_language.buttonJVTransactionEdit;
            //    this.btnDelete.Text = obj_interface_language.buttonJVTransactionDelete;
            //    this.btnUndo.Text = obj_interface_language.buttonJVTransactionUndo;
            //    this.btnExit.Text = obj_interface_language.buttonJVTransactionExit;
            //    this.btnSaveNew.Text = obj_interface_language.buttonARTransactionsaveNew;
            //    this.btnSaveEdit.Text = obj_interface_language.buttonARTransactionsaveEdit;
            //    this.btn_Post.Text = obj_interface_language.buttonJVTransactionPost;
            //    this.btnPrint.Text = obj_interface_language.buttonJVTransactionPrint;
            //    this.btnCopy.Text = obj_interface_language.buttonJVTransactionCopy;
            //    this.btnFind.Text = obj_interface_language.buttonARTransactionsFind;

            //    this.dgv.Columns[1].HeaderText = obj_interface_language.dgvARTransactionsColumn1;
            //    this.dgv.Columns[3].HeaderText = obj_interface_language.dgvARTransactionsColumn2;
            //    this.dgv.Columns[5].HeaderText = obj_interface_language.dgvARTransactionsColumn4;
            //    this.dgv.Columns[6].HeaderText = obj_interface_language.dgvARTransactionsColumn5;
            //    this.dgv.Columns[9].HeaderText = obj_interface_language.dgvARTransactionsColumn6;
            //    this.dgv.Columns[10].HeaderText = obj_interface_language.dgvARTransactionsColumn7;
            //    this.dgv.Columns[7].HeaderText = obj_interface_language.dgvARTransactionsColumn8;
            //    this.dgv.Columns[8].HeaderText = obj_interface_language.dgvARTransactionsColumn9;
            //    this.dgv.Columns[11].HeaderText = obj_interface_language.dgvARTransactionsColumn10;
            //    this.dgv.Columns[13].HeaderText = obj_interface_language.dgvARTransactionsColumn12;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

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
            adaptertbGLTransactions.Update(dbAccountingProjectDS.GLTransactions);
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
        private void ClearAll()
        {
            txt_JVDescription.Text = "";
            DTP_JVDate.Value = DateTime.Now;
            string periodName;
            if (GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value.Date), out currentPeriodID, out periodName, out currentEndDate))
                txt_Period.Text = periodName;
            else
                MessageBox.Show("The period has been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtReceipt_Amt.Text = "0";
            txtCash_Fees.Text = "0";
            cb_Bank_Deposit_Type.SelectedIndex = -1;
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
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (txt_NetDeposit.Text != "0")
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            this.Close();
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

            if (txt_NetDeposit.Text != "0")
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            ClearAll();
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

        private void DTP_JVDate_ValueChanged(object sender, EventArgs e)
        {
            string periodName;
            if (GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value.Date), out currentPeriodID, out periodName, out currentEndDate))
                txt_Period.Text = periodName;
            else
                MessageBox.Show("The period has been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Bank_Deposit_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralFunctions.UnLockTable("", "Bank_Deposit", "", "");
        }

        private void txtReceipt_Amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                if (txtReceipt_Amt.Text.Contains("."))
                {
                    char c = '.';
                    string[] sc = txtReceipt_Amt.Text.Split(c);

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
                if (txtReceipt_Amt.Text.Contains(".") == false)
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void txtCash_Fees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCash_Fees.ReadOnly)
                return;
            if (e.KeyChar == 45)
            {
                if (txtCash_Fees.Text.Contains("-") == false)
                {
                    e.Handled = true;
                    txtCash_Fees.Text = "-" + txtCash_Fees.Text;
                    txtCash_Fees.SelectionStart = txtCash_Fees.TextLength;
                }
                else
                    e.Handled = true;
            }
            else if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                if (txtCash_Fees.Text.Contains("."))
                {
                    char c = '.';
                    string[] sc = txtCash_Fees.Text.Split(c);

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
                if (txtCash_Fees.Text.Contains(".") == false)
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void cb_Bank_Deposit_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Lst_Bank_Deposit_Type = new System.Collections.SortedList();
                if (cb_Bank_Deposit_Type.ValueMember != null && cb_Bank_Deposit_Type.ValueMember != "" && cb_Bank_Deposit_Type.SelectedIndex > -1)
                {
                    DataTable dt = DataClass.RetrieveData("SELECT BDT.Bank_Deposit_Type_ID, BDT.Acct_Deposit_From, BDT.Credit_Card_Deposit, BDT.CC_Discount_Acct, BDT.CC_Fees, BDT.Cash_Short_Over_Acct, BDT.Override_Fees, BDT.Bank_Account_ID,  BAS.Bank_GL_Account FROM dbo.Bank_Deposit_Type AS BDT INNER JOIN dbo.Bank_Account_Setup AS BAS ON BDT.Bank_Account_ID = BAS.Bank_Account_ID WHERE (BDT.Bank_Deposit_Type_ID = " + cb_Bank_Deposit_Type.SelectedValue.ToString() + ")");
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                            Lst_Bank_Deposit_Type.Add(dt.Columns[i].ColumnName, dt.Rows[0][i]);

                        lblCashOverSort.Visible = !(bool)Lst_Bank_Deposit_Type["Credit_Card_Deposit"];
                        lblCredit_Fees.Visible = (bool)Lst_Bank_Deposit_Type["Credit_Card_Deposit"];
                        if ((bool)Lst_Bank_Deposit_Type["Credit_Card_Deposit"])
                        {
                            txtCash_Fees.ReadOnly = !(bool)Lst_Bank_Deposit_Type["Override_Fees"];
                            Calc_CC_Fees();
                        }
                        else
                            txtCash_Fees.ReadOnly = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }
        private void Calc_CC_Fees()
        {
            try
            {
                double amt = 0; double.TryParse(txtReceipt_Amt.Text, out amt);
                double CC_Fees = 0; double.TryParse(Lst_Bank_Deposit_Type["CC_Fees"].ToString(), out CC_Fees);
                double Cash_Fees = 0;
                if (CC_Fees > 0)
                {
                    Cash_Fees = Function.ChangeDecimal((amt * (CC_Fees / 100)), decmal);
                    Cash_Fees = -1 * Cash_Fees;
                }
                txtCash_Fees.Text = (amt + Cash_Fees).ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Calc_NetDeposit()
        {
            try
            {
                double amt = 0; double.TryParse(txtReceipt_Amt.Text, out amt);
                double Cash_Fees = 0; double.TryParse(txtCash_Fees.Text, out Cash_Fees);
                txt_NetDeposit.Text = (amt + Cash_Fees).ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void txtReceipt_Amt_TextChanged(object sender, EventArgs e)
        {
            if (Lst_Bank_Deposit_Type.Count > 0 && (bool)Lst_Bank_Deposit_Type["Credit_Card_Deposit"])
                Calc_CC_Fees();
            Calc_NetDeposit();
        }

        private void txtCash_Fees_TextChanged(object sender, EventArgs e)
        {
            Calc_NetDeposit();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                double Receipt_Amt = 0; double.TryParse(txtReceipt_Amt.Text, out Receipt_Amt);
                double Cash_Fees = 0; double.TryParse(txtCash_Fees.Text, out Cash_Fees);
                double NetDeposit = 0; double.TryParse(txt_NetDeposit.Text, out NetDeposit);

                if (cb_Bank_Deposit_Type.SelectedIndex == -1)
                {
                    MessageBox.Show("Select Bank Deposit Type", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (Receipt_Amt == 0)
                {
                    MessageBox.Show("Insert Receipt Amount", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                string msg = GeneralFunctions.CheckLockTables("GLTotals", "", "", "Edit");
                if (msg != "")
                {
                    MessageBox.Show("Can't Run Because GLTotals Edit By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                string currentBankNumber = GeneralFunctions.CreateBankNumberFormat(GeneralFunctions.lblBank, GeneralFunctions.BankNumberFormat, true);
                if (ValidateYear() && ValidatePeriod())
                {
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
                    DataRow r;
                    r = this.dbAccountingProjectDS.GLTransactions.NewRow();
                    r["TransNO"] = NewTransNoGL();
                    r["BatchNo"] = BatchNo;
                    r["GLAccount"] = Lst_Bank_Deposit_Type["Bank_GL_Account"].ToString();
                    r["TRANSREF"] = "";
                    r["TRANSDATE"] = DTP_JVDate.Value.Date;
                    r["TRANSUnit"] = 0;
                    r["Amount"] = 0;
                    r["AmountLC"] = NetDeposit;
                    r["CurrencyType"] = "";
                    r["Rate"] = "0";
                    r["ProjectCode"] = "";
                    r["DepartmentCode"] = "";
                    r["SortNO"] = 1;
                    dbAccountingProjectDS.GLTransactions.Rows.Add(r);
                    r = this.dbAccountingProjectDS.GLTransactions.NewRow();
                    r["TransNO"] = NewTransNoGL();
                    r["BatchNo"] = BatchNo;
                    r["GLAccount"] = Lst_Bank_Deposit_Type["Acct_Deposit_From"].ToString();
                    r["TRANSREF"] = "";
                    r["TRANSDATE"] = DTP_JVDate.Value.Date;
                    r["TRANSUnit"] = 0;
                    r["Amount"] = 0;
                    r["AmountLC"] = -1 * Receipt_Amt;
                    r["CurrencyType"] = "";
                    r["Rate"] = "0";
                    r["ProjectCode"] = "";
                    r["DepartmentCode"] = "";
                    r["SortNO"] = 2;
                    dbAccountingProjectDS.GLTransactions.Rows.Add(r);
                    if (Cash_Fees != 0)
                    {
                        r = this.dbAccountingProjectDS.GLTransactions.NewRow();
                        r["TransNO"] = NewTransNoGL();
                        r["BatchNo"] = BatchNo;
                        if ((bool)Lst_Bank_Deposit_Type["Credit_Card_Deposit"])
                            r["GLAccount"] = Lst_Bank_Deposit_Type["CC_Discount_Acct"].ToString();
                        else
                            r["GLAccount"] = Lst_Bank_Deposit_Type["Cash_Short_Over_Acct"].ToString();
                        r["TRANSREF"] = "";
                        r["TRANSDATE"] = DTP_JVDate.Value.Date;
                        r["TRANSUnit"] = 0;
                        r["Amount"] = 0;
                        r["AmountLC"] = -1 * Cash_Fees;
                        r["CurrencyType"] = "";
                        r["Rate"] = "0";
                        r["ProjectCode"] = "";
                        r["DepartmentCode"] = "";
                        r["SortNO"] = 3;
                        dbAccountingProjectDS.GLTransactions.Rows.Add(r);
                    }
                    string prdbalance = "";
                    double val = 0;
                    int NewBNo = 0;
                    update();
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

                    update();
                    MessageBox.Show("The given Batch is posted", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







    }
}