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
    public partial class JVTransactions : Form
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
        private DataTable dtJVAccounts;
        private int currentRowIndex = 0;
        private int currentPeriodID;
        private int decmal = 1;
        private int MultiCurrency = 0;
        private static DateTime currentEndDate;
        private string currentJVNumber = "";
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
        public JVTransactions()
        {
            InitializeComponent();
        }

        private void JVTransactions_Load(object sender, EventArgs e)
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
                GeneralFunctions.LockTables("", "JVTransactions", "", "Open");
                // TODO: This line of code loads data into the 'dbAccountingProjectDS1.BatchTemp' table. You can move, or remove it, as needed.
                txt_UserID.Text = AaDeclrationClass.xUserName;
                GeneralFunctions.priviledgeGroupBox(Lock60);
                GeneralFunctions.priviledgeGroupBox(Lock61);
                GeneralFunctions.priviledgeGroupBox(Lock62);
                GeneralFunctions.priviledgeGroupBox(Lock63);
                GeneralFunctions.priviledgeGroupBox(Lock64);
                GeneralFunctions.priviledgeGroupBox(Lock65);
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
                    //AccountNumberFormat = dr["AccountNumberFormat"].ToString();
                    AccountNumberFormat = "";
                    decmal = int.Parse(dr["DecimalPointsNumber"].ToString());
                    GeneralFunctions.lblJV = dr["lblJV"].ToString();
                }
                DataRow[] drs = dbAccountingProjectDS.G_L_GeneralSetup.Select();
                if (drs.Length != 0)
                {
                    DefaultACCBalanceSheet = drs[0]["BalanceSheet"].ToString();
                    DefaultACCIncomeStatment = drs[0]["IncomeStatment"].ToString();
                    if (DefaultACCBalanceSheet == "" || DefaultACCIncomeStatment == "")
                    {
                        MessageBox.Show("Please Check AccountBalanceSheet And AccountIncomeStatment In G/L GeneralSetup ", "Error");
                        this.Close();
                    }
                }
                DataGridViewMaskedTextColumn accformat = new DataGridViewMaskedTextColumn(AccountNumberFormat);
                accformat.DataPropertyName = "AccountNumber";
                accformat.HeaderText = "AccountNumber";     //  German text
                accformat.Name = "AccountNumber";
                accformat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                accformat.Width = 75;
                dtJVAccounts = new DataTable();
                dtJVAccounts.Columns.Add("AccountID", System.Type.GetType("System.Int32"));
                dtJVAccounts.Columns.Add("AccountNumber", System.Type.GetType("System.String"));
                dtJVAccounts.Columns.Add("AccountName", System.Type.GetType("System.String"));
                dtJVAccounts.Columns.Add("AccountTypeName", System.Type.GetType("System.String"));
                dtJVAccounts.Columns.Add("Date", System.Type.GetType("System.DateTime"));
                dtJVAccounts.Columns.Add("Reference", System.Type.GetType("System.String"));
                dtJVAccounts.Columns.Add("Debit", System.Type.GetType("System.String"));
                dtJVAccounts.Columns.Add("DebitFC", System.Type.GetType("System.String"));
                dtJVAccounts.Columns.Add("Credit", System.Type.GetType("System.String"));
                dtJVAccounts.Columns.Add("CreditFC", System.Type.GetType("System.String"));
                dtJVAccounts.Columns.Add("Units", System.Type.GetType("System.Int32"));
                dtJVAccounts.Columns.Add("JVNumber", System.Type.GetType("System.String"));

                DataRow r = dtJVAccounts.NewRow();
                dtJVAccounts.Rows.Add(r);
                dgv.DataSource = dtJVAccounts;
                dgv.Columns["AccountID"].Visible = false;
                dgv.Columns.Insert(1, accformat);
                dgv.Columns[2].Visible = false;
                dgv.Columns["AccountTypeName"].Visible = true;
                dgv.Columns["JVNumber"].Visible = false;
                dgv.Columns["DebitFC"].ReadOnly = true;
                dgv.Columns["CreditFC"].ReadOnly = true;
                dgv.Columns["DebitFC"].HeaderText = "Debit FC";
                dgv.Columns["CreditFC"].HeaderText = "Credit FC";
                dgv.Columns["Debit"].DefaultCellStyle.BackColor = Color.LightSeaGreen;
                dgv.Columns["Credit"].DefaultCellStyle.BackColor = Color.LightSeaGreen;
                dgv.Columns["DebitFC"].DefaultCellStyle.BackColor = Color.Cornsilk;
                dgv.Columns["CreditFC"].DefaultCellStyle.BackColor = Color.Cornsilk;

                dgvc = new DataGridViewComboBoxColumn();
                dgvc.HeaderText = "ProjectCode";
                dgvc.Name = "ProjectCode";
                //dgvc.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
                dgvc = GeneralFunctions.AddItems(dgvc, dbAccountingProjectDS.GLProjectCodes, "ProjectCode");
                if (GeneralFunctions.Ckecktag("20") != "M")
                    dgvc.Items.Remove("<new>");
                dgv.Columns.Add(dgvc);

                dgvd = new DataGridViewComboBoxColumn();
                dgvd.HeaderText = "DepartmentCode";
                dgvd.Name = "DepartmentCode";
                //dgvd.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
                dgvd = GeneralFunctions.AddItems(dgvd, dbAccountingProjectDS.DepartmentCode, "Code");
                //if (GeneralFunctions.Ckecktag("20") != "M")
                //    dgvc.Items.Remove("<new>");
                dgv.Columns.Add(dgvd);

                for (int c = 0; c < dgv.ColumnCount - 1; c++)
                {
                    dgv.Columns[c].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                if (MultiCurrency == 1)
                {
                    checkBox_multiCurrency.Visible = true;
                }
                else
                {
                    checkBox_multiCurrency.Visible = false;
                }
                cb_JournalCode = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLJournalCodes, cb_JournalCode, "JournalCode", "JournalCodeID");
                if (GeneralFunctions.Ckecktag("21") != "M")
                    cb_JournalCode.Items.Remove("<new>");
                cb_Temptran = GeneralFunctions.FillComboBox(dbAccountingProjectDS.BatchTemp, cb_Temptran, "TempID", "DescTemp");
                if (GeneralFunctions.Ckecktag("23") != "M")
                    cb_Temptran.Items.Remove("<new>");
                cb_Currency = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLCurrency, cb_Currency, "CurrencyCode", "CurrencyNumber");
                if (GeneralFunctions.Ckecktag("15") != "M")
                    cb_Currency.Items.Remove("<new>");
                cb_Currency = GeneralFunctions.RemoveBaseCurrency(cb_Currency);
                string periodName;
                if (GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value.Date), out currentPeriodID, out periodName, out currentEndDate))
                    txt_Period.Text = periodName;
                else
                    MessageBox.Show("The period has been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Balance.Text = "0";

                currentJVNumber = GeneralFunctions.CreateJVNumberFormat(GeneralFunctions.lblJV, GeneralFunctions.JVNumberFormat, true);
                txt_JVNumber.Text = currentJVNumber;

                if (GeneralFunctions.languagechioce != "")
                {
                    this.obj_options = new ClassOptions();
                    this.obj_options.report_language = GeneralFunctions.languagechioce;
                    this.update_language_interface();
                }

                if (checkBox_multiCurrency.Checked == true)
                {
                    dgv.Columns["DebitFC"].Visible = true;
                    dgv.Columns["CreditFC"].Visible = true;
                }
                else
                {
                    dgv.Columns["DebitFC"].Visible = false;
                    dgv.Columns["CreditFC"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void fillperiod(int PeriodNo)
        {
            try
            {
                DateTime DP;
                DataRow[] drs = dbAccountingProjectDS.GLFiscalPeriod.Select(" Status='OPEN' AND PeriodID >= " + PeriodNo);
                if (drs.Length != 0)
                {
                    cb_period.Items.Clear();
                    for (int i = 0; i < drs.Length; i++)
                    {
                        DP = Convert.ToDateTime(drs[i]["PeriodStartDate"].ToString());
                        cb_period.Items.Add(DP.ToShortDateString());
                    }
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
                this.label12.Text = obj_interface_language.labelBatch;
                this.label1.Text = obj_interface_language.labelJVNumber;
                this.label11.Text = obj_interface_language.lblCountUnits;
                this.label2.Text = obj_interface_language.labelJVDescription;
                this.label3.Text = obj_interface_language.labelJVCode;
                this.label4.Text = obj_interface_language.labelJVDate;
                this.label10.Text = obj_interface_language.lblJVTransactionsTemp;
                this.label5.Text = obj_interface_language.labelPeriod;
                this.label13.Text = obj_interface_language.labelPeriod;
                this.label9.Text = obj_interface_language.labelJVTransactionsStatus;
                this.label8.Text = obj_interface_language.labelBalance;
                this.label_Currency.Text = obj_interface_language.currency;
                this.label_CurrencyRate.Text = obj_interface_language.lblCurrencyRate;
                this.checkBox_multiCurrency.Text = obj_interface_language.checkbox_multiCurrency;
                this.checkBox_Reverse.Text = obj_interface_language.checkbox_Reverse;

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

                this.dgv.Columns[1].HeaderText = obj_interface_language.dgvJVTransactionsColumn1;
                this.dgv.Columns[3].HeaderText = obj_interface_language.dgvJVTransactionsColumn2;
                this.dgv.Columns[5].HeaderText = obj_interface_language.dgvJVTransactionsColumn4;
                this.dgv.Columns[6].HeaderText = obj_interface_language.dgvJVTransactionsColumn5;
                this.dgv.Columns[9].HeaderText = obj_interface_language.dgvJVTransactionsColumn6;
                this.dgv.Columns[10].HeaderText = obj_interface_language.dgvJVTransactionsColumn7;
                this.dgv.Columns[7].HeaderText = obj_interface_language.dgvJVTransactionsColumn8;
                this.dgv.Columns[8].HeaderText = obj_interface_language.dgvJVTransactionsColumn9;
                this.dgv.Columns[11].HeaderText = obj_interface_language.dgvJVTransactionsColumn10;
                this.dgv.Columns[13].HeaderText = obj_interface_language.dgvJVTransactionsColumn12;
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
                for (int i = 0; i < dtJVAccounts.Rows.Count - 1; i++)
                {
                    dtJVAccounts.Rows[i]["Date"] = string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value);
                }
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
            GeneralFunctions.LockTables("Batch", "JVTransactions", No.ToString(), "New");
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
                DataRow r;
                for (int i = 0; i < dtJVAccounts.Rows.Count; i++)
                {
                    r = dtJVAccounts.Rows[i];
                    if (r.Equals(dtJVAccounts.Rows[dtJVAccounts.Rows.Count - 1]) || r["AccountNumber"].ToString() == "" || r["AccountName"].ToString() == "")
                        break;
                    if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified)
                    {
                        r = this.dbAccountingProjectDS.GLTransactions.NewRow();
                        r["TransNO"] = NewTransNo();
                        r["BatchNo"] = Convert.ToUInt32(txtBatch.Text);
                        r["GLAccount"] = dgv.Rows[i].Cells["AccountNumber"].Value; //txt_JVNumber.Text;
                        r["TRANSREF"] = dgv.Rows[i].Cells["Reference"].Value.ToString();
                        r["TRANSDATE"] = dgv.Rows[i].Cells["Date"].Value;
                        r["TRANSUnit"] = dgv.Rows[i].Cells["Units"].Value;
                        if (double.Parse(dgv.Rows[i].Cells["DebitFC"].Value.ToString()) != 0)
                            r["Amount"] = double.Parse(dgv.Rows[i].Cells["DebitFC"].Value.ToString());
                        else
                            r["Amount"] = 0;
                        if (double.Parse(dgv.Rows[i].Cells["CreditFC"].Value.ToString()) != 0)
                            r["Amount"] = -1 * double.Parse(dgv.Rows[i].Cells["CreditFC"].Value.ToString());
                        else
                            r["Amount"] = 0;
                        r["AmountLC"] = 0;
                        if (double.Parse(dgv.Rows[i].Cells["Debit"].Value.ToString()) != 0)
                            r["AmountLC"] = double.Parse(dgv.Rows[i].Cells["Debit"].Value.ToString());
                        if (double.Parse(dgv.Rows[i].Cells["Credit"].Value.ToString()) != 0)
                            r["AmountLC"] = -1 * double.Parse(dgv.Rows[i].Cells["Credit"].Value.ToString());
                        r["CurrencyType"] = cb_Currency.Text;
                        if (txt_CurrencyRate.Text != "")
                        {
                            r["Rate"] = double.Parse(txt_CurrencyRate.Text.ToString());
                        }
                        else
                            r["Rate"] = "0";

                        if (dgv.Rows[i].Cells["ProjectCode"].Value != null)
                        {
                            r["ProjectCode"] = dgv.Rows[i].Cells["ProjectCode"].Value.ToString();
                        }
                        else
                            r["ProjectCode"] = "";
                        if (dgv.Rows[i].Cells["DepartmentCode"].Value != null)
                        {
                            r["DepartmentCode"] = dgv.Rows[i].Cells["DepartmentCode"].Value.ToString();
                        }
                        else
                            r["DepartmentCode"] = "";
                        r["SortNO"] = i + 1;
                        
                        dbAccountingProjectDS.GLTransactions.Rows.Add(r);
                        //update();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AddJVTransactionAccountsReverse(int BatchReverse)
        {
            try
            {
                DataRow r;
                for (int i = 0; i < dtJVAccounts.Rows.Count; i++)
                {
                    r = dtJVAccounts.Rows[i];
                    if (r.Equals(dtJVAccounts.Rows[dtJVAccounts.Rows.Count - 1]) || r["AccountNumber"].ToString() == "" || r["AccountName"].ToString() == "")
                        break;
                    if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified)
                    {
                        r = this.dbAccountingProjectDS.GLTransactions.NewRow();
                        r["TransNO"] = NewTransNo();
                        r["BatchNo"] = BatchReverse;
                        r["GLAccount"] = dgv.Rows[i].Cells["AccountNumber"].Value; //txt_JVNumber.Text;
                        r["TRANSREF"] = dgv.Rows[i].Cells["Reference"].Value.ToString();
                        r["TRANSDATE"] = dgv.Rows[i].Cells["Date"].Value;
                        r["TRANSUnit"] = dgv.Rows[i].Cells["Units"].Value;
                        if (double.Parse(dgv.Rows[i].Cells["DebitFC"].Value.ToString()) != 0)
                            r["Amount"] = -1 * double.Parse(dgv.Rows[i].Cells["DebitFC"].Value.ToString());
                        else
                            r["Amount"] = 0;
                        if (double.Parse(dgv.Rows[i].Cells["CreditFC"].Value.ToString()) != 0)
                            r["Amount"] = double.Parse(dgv.Rows[i].Cells["CreditFC"].Value.ToString());
                        else
                            r["Amount"] = 0;
                        r["AmountLC"] = 0;
                        if (double.Parse(dgv.Rows[i].Cells["Debit"].Value.ToString()) != 0)
                            r["AmountLC"] = -1 * double.Parse(dgv.Rows[i].Cells["Debit"].Value.ToString());
                        if (double.Parse(dgv.Rows[i].Cells["Credit"].Value.ToString()) != 0)
                            r["AmountLC"] = double.Parse(dgv.Rows[i].Cells["Credit"].Value.ToString());
                        r["CurrencyType"] = cb_Currency.Text;
                        if (txt_CurrencyRate.Text != "")
                        {
                            r["Rate"] = double.Parse(txt_CurrencyRate.Text.ToString());
                        }
                        else
                            r["Rate"] = "0";

                        if (dgv.Rows[i].Cells["ProjectCode"].Value != null)
                        {
                            r["ProjectCode"] = dgv.Rows[i].Cells["ProjectCode"].Value.ToString();
                        }
                        else
                            r["ProjectCode"] = "";
                        if (dgv.Rows[i].Cells["DepartmentCode"].Value != null)
                        {
                            r["DepartmentCode"] = dgv.Rows[i].Cells["DepartmentCode"].Value.ToString();
                        }
                        else
                            r["DepartmentCode"] = "";
                        r["SortNO"] = i + 1;
                        
                        dbAccountingProjectDS.GLTransactions.Rows.Add(r);
                    }
                }
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
        private void AddAccountsForBS_PL_Rev()
        {
            try
            {
                DataRow r;
                r = this.dbAccountingProjectDS.GLTransactions.NewRow();
                r["TransNO"] = NewTransNo();
                r["BatchNo"] = Convert.ToUInt32(txtrevbatch.Text);
                r["GLAccount"] = DefaultACCBalanceSheet; //txt_JVNumber.Text;
                r["TRANSREF"] = "BalanceSheet";
                r["TRANSDATE"] = DateTime.Now.ToShortDateString();
                r["TRANSUnit"] = 0;
                r["Amount"] = "0";
                r["AmountLC"] = ValBS;
                r["CurrencyType"] = "";
                r["Rate"] = "0";
                r["ProjectCode"] = "";
                r["DepartmentCode"] = "";
                r["SortNO"] = 0;
                
                dbAccountingProjectDS.GLTransactions.Rows.Add(r);
                r = this.dbAccountingProjectDS.GLTransactions.NewRow();
                r["TransNO"] = NewTransNo();
                r["BatchNo"] = Convert.ToUInt32(txtrevbatch.Text);
                r["GLAccount"] = DefaultACCIncomeStatment; //txt_JVNumber.Text;
                r["TRANSREF"] = "IncomeStatment";
                r["TRANSDATE"] = DateTime.Now.ToShortDateString();
                r["TRANSUnit"] = 0;
                r["Amount"] = "0";
                r["AmountLC"] = ValPT;
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
            txtrevbatch.Text = "";
            txt_JVNumber.Text = "";
            txt_JVDescription.Text = "";
            txtStatus.Text = "";
            cb_JournalCode.SelectedIndex = -1;
            cb_period.SelectedIndex = -1;
            //cb_Temptran.SelectedIndex = -1;
            int count = dtJVAccounts.Rows.Count;
            for (int i = count - 1; i >= 0; i--)
                dtJVAccounts.Rows.Remove(dtJVAccounts.Rows[i]);//    dgv.Rows.RemoveAt(i);
            DataRow r = dtJVAccounts.NewRow();
            dtJVAccounts.Rows.Add(r);
            DTP_JVDate.Value = DateTime.Now;
            string periodName;
            if (GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value.Date), out currentPeriodID, out periodName, out currentEndDate))
                txt_Period.Text = periodName;
            else
                MessageBox.Show("The period has been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            btn_Post.Enabled = false;
            cb_Currency.Enabled = true;
            checkBox_multiCurrency.Enabled = true;
            checkBox_multiCurrency.Checked = false;
            checkBox_Reverse.Checked = false;
            checkBox_Reverse.Enabled = true;
            txtFind.Text = "";
            dgv.Enabled = true;
            cb_Currency.SelectedIndex = -1;
            txtBatch.Text = "";
            GeneralFunctions.UnLockTable("", "JVTransactions", "", "Edit");
            GeneralFunctions.UnLockTable("", "JVTransactions", "", "New");
        }
        private void EnableAll()
        {
            txtBatch.Enabled = true;
            cb_Temptran.Enabled = true;
            txt_JVDescription.Enabled = true;
            cb_JournalCode.Enabled = true;
            cb_Currency.Enabled = true;
            checkBox_Reverse.Enabled = true;
            checkBox_multiCurrency.Enabled = true;
            DTP_JVDate.Enabled = true;
            dgv.Enabled = true;
            groupDetails.Enabled = true;
        }


        private void DisableAll()
        {
            txtBatch.Enabled = false;
            cb_Temptran.Enabled = false;
            txt_JVDescription.Enabled = false;
            cb_JournalCode.Enabled = false;
            cb_Currency.Enabled = false;
            checkBox_Reverse.Enabled = false;
            checkBox_multiCurrency.Enabled = false;
            DTP_JVDate.Enabled = false;
            dgv.Enabled = false;
            groupDetails.Enabled = false;

        }


        private void CalculateBalance()
        {
            try
            {
                balance = 0;
                double currentvalue = 0;
                DataRow r;
                for (int i = 0; i < dtJVAccounts.Rows.Count; i++)
                {
                    r = dtJVAccounts.Rows[i];
                    if (r.Equals(dtJVAccounts.Rows[dtJVAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountName"].ToString() == "")
                        break;
                    currentvalue = 0;
                    if (dgv.Rows[i].Cells["Debit"].Value.ToString() != "" &&
                                           GeneralFunctions.ValidateDouble(dgv.Rows[i].Cells["Debit"].Value.ToString(), "Please Insert a valid debit value", out currentvalue))
                    {
                        balance += currentvalue;
                    }
                    currentvalue = 0;
                    if (dgv.Rows[i].Cells["Credit"].Value.ToString() != "" &&
                                          GeneralFunctions.ValidateDouble(dgv.Rows[i].Cells["Credit"].Value.ToString(), "Please Insert a valid credit value", out currentvalue))
                    {
                        balance -= currentvalue;
                    }
                }
                txt_Balance.Text = balance.ToString();
                CalculateCountUnits();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void CalculateCountUnits()
        {
            try
            {
                double CountUnits = 0;
                double currentvalue = 0;
                DataRow r;
                for (int i = 0; i < dtJVAccounts.Rows.Count; i++)
                {
                    r = dtJVAccounts.Rows[i];
                    if (r.Equals(dtJVAccounts.Rows[dtJVAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountName"].ToString() == "")
                        break;
                    currentvalue = 0;
                    if (dgv.Rows[i].Cells["Units"].Value.ToString() != "" &&
                                           GeneralFunctions.ValidateDouble(dgv.Rows[i].Cells["Units"].Value.ToString(), "Please Insert a valid debit value", out currentvalue))
                    {
                        CountUnits += currentvalue;
                    }

                }
                txtCountUnits.Text = int.Parse(CountUnits.ToString()).ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private int GetNextPeriod()
        {
            int ID = 0;
            int NO = 0;
            DateTime dt = currentEndDate.AddDays(1);
            GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, dt.Date), out ID, out NO);
            return ID;
        }

        private void dgv_MouseLeave(object sender, EventArgs e)
        {
            dgv.EndEdit();
        }

        private void dgv_Leave(object sender, EventArgs e)
        {
            dgv.EndEdit();
        }

        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                ComboBox cbo = e.Control as ComboBox;
                ComboBox cbd = e.Control as ComboBox;
                if (dgv.CurrentCell.ColumnIndex == 13)
                {
                    try { cbd.SelectionChangeCommitted -= new System.EventHandler(cbd_SelectionChangeCommitted); }
                    catch (Exception ex) { }
                    try { cbo.SelectionChangeCommitted -= new System.EventHandler(cbo_SelectionChangeCommitted); }
                    catch (Exception ex) { }
                    cbo.SelectionChangeCommitted += new System.EventHandler(cbo_SelectionChangeCommitted);
                }
                if (dgv.CurrentCell.ColumnIndex == 14)
                {
                    try { cbo.SelectionChangeCommitted -= new System.EventHandler(cbo_SelectionChangeCommitted); }
                    catch (Exception ex) { }
                    try { cbd.SelectionChangeCommitted -= new System.EventHandler(cbd_SelectionChangeCommitted); }
                    catch (Exception ex) { }
                    cbd.SelectionChangeCommitted += new System.EventHandler(cbd_SelectionChangeCommitted);
                }

                //if (cbo != null)
                //{
                //    cbo.SelectionChangeCommitted += new System.EventHandler(cbo_SelectionChangeCommitted);
                //}
                e.Control.KeyPress -= new KeyPressEventHandler(dgv_Control_KeyPress);

                e.Control.KeyPress += new KeyPressEventHandler(dgv_Control_KeyPress);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgv_Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgv.CurrentCell.ColumnIndex == 7 || dgv.CurrentCell.ColumnIndex == 8 || dgv.CurrentCell.ColumnIndex == 9 || dgv.CurrentCell.ColumnIndex == 10 || dgv.CurrentCell.ColumnIndex == 11)
            {
                if (e.KeyChar == 45 && dgv.CurrentCell.ColumnIndex == 11)
                {
                    if (dgv.EditingControl.Text.ToString().Contains("-") == false)
                    {
                        e.Handled = false;

                    }
                    else
                        e.Handled = true;
                }
                else if (e.KeyChar == 8)
                {

                    e.Handled = false;

                }
                else if (e.KeyChar >= 48 && e.KeyChar <= 57)
                {
                    if (dgv.EditingControl.Text.ToString().Contains("."))
                    {
                        char c = '.';
                        string[] sc = dgv.EditingControl.Text.ToString().Split(c);

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
                else if (e.KeyChar == 46 && dgv.CurrentCell.ColumnIndex != 11)
                {
                    if (dgv.EditingControl.Text.ToString().Contains(".") == false)
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
        private void cbo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ComboBox senderComboBox = (ComboBox)sender;
                if (senderComboBox.SelectedItem != null)
                {
                    if (senderComboBox.SelectedItem.ToString() == "<new>")
                    {
                        ProjectCodes pc = new ProjectCodes();
                        pc.ShowDialog();
                        adaptertbGLProjectCodes.Fill(dbAccountingProjectDS.GLProjectCodes);
                        dgvc.Items.Clear();
                        dgvc = GeneralFunctions.AddItems(dgvc, dbAccountingProjectDS.GLProjectCodes, "ProjectCode");
                        dgv.CancelEdit();
                        dgv.CurrentRow.Cells["Date"].Selected = true;

                    }
                }
            }
            catch (Exception e22)
            {
                MessageBox.Show(e22.Message);
            }
        }
        private void cbd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ComboBox senderComboBox = (ComboBox)sender;
                if (senderComboBox.SelectedItem != null)
                {
                    if (senderComboBox.SelectedItem.ToString() == "<new>")
                    {
                        DepartmentCode pc = new DepartmentCode();
                        pc.ShowDialog();
                        adaptertbdepartmentCodes.Fill(dbAccountingProjectDS.DepartmentCode);
                        dgvd.Items.Clear();
                        dgvd = GeneralFunctions.AddItems(dgvd, dbAccountingProjectDS.DepartmentCode, "Code");
                        dgv.CancelEdit();
                        dgv.CurrentRow.Cells["Date"].Selected = true;

                    }
                }
            }
            catch (Exception e22)
            {
                MessageBox.Show(e22.Message);
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

        private void cb_JournalCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_JournalCode.Text == "<new>")
            {
                GLJournalCodes jc = new GLJournalCodes();
                jc.ShowDialog();
                cb_JournalCode.Items.Clear();
                adaptertbGLJournalCodes.Fill(dbAccountingProjectDS.GLJournalCodes);
                cb_JournalCode = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLJournalCodes, cb_JournalCode, "JournalCode", "JournalCodeID");
            }
        }

        private void cb_Currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Currency.Text == "<new>")
            {
                Currency curr = new Currency();
                curr.ShowDialog();
                cb_Currency.Items.Clear();
                adaptertbCurrency.Fill(dbAccountingProjectDS.GLCurrency);
                cb_Currency = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLCurrency, cb_Currency, "CurrencyCode", "CurrencyNumber");
                cb_Currency = GeneralFunctions.RemoveBaseCurrency(cb_Currency);
            }
            if (cb_Currency.Text != "" && cb_Currency.Text != "<new>")
            {
                double exchangeRate;
                if (!GeneralFunctions.EvaluateExchangeRate(out exchangeRate, cb_Currency.Text))
                {
                    if (DialogResult.OK == MessageBox.Show("The conversion exchange rate for the given currency hasnt been defined\nPress OK if you want to define the exchage rates now"))
                    {
                        CurrencyConversionTable conversion = new CurrencyConversionTable();
                        conversion.ShowDialog();
                        GeneralFunctions.EvaluateExchangeRate(out exchangeRate, cb_Currency.Text);
                        txt_CurrencyRate.Text = exchangeRate.ToString();
                        UpdateForiegnCurrencyValues();
                    }
                }
                else
                {
                    txt_CurrencyRate.Text = exchangeRate.ToString();
                    UpdateForiegnCurrencyValues();
                }
            }
            if (dgv.Rows.Count >= 3)
                CalculateBalance();
        }
        private void UpdateForiegnCurrencyValues()
        {
            DataRow r;
            int c = 0;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells["AccountNumber"].ToString() != "" && dgv.Rows[i].Cells["AccountName"].ToString() != "")
                    c++;
            }
            if (c <= 0)
                return;
            double currentAmount;
            for (int i = 0; i < dtJVAccounts.Rows.Count; i++)
            {
                r = dtJVAccounts.Rows[i];
                if (r.Equals(dtJVAccounts.Rows[dtJVAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountName"].ToString() == "")
                    break;
                if (dgv.Rows[i].Cells["DebitFC"].Value.ToString() == "")
                {
                    r["DebitFC"] = "0";
                }
                if (dgv.Rows[i].Cells["CreditFC"].Value.ToString() == "")
                {
                    r["CreditFC"] = "0";
                }
                if (dgv.Rows[i].Cells["DebitFC"].Value.ToString() != "")
                {
                    currentAmount = double.Parse(dgv.Rows[i].Cells["DebitFC"].Value.ToString());
                    r["Debit"] = currentAmount * double.Parse(txt_CurrencyRate.Text);
                }
                if (dgv.Rows[i].Cells["CreditFC"].Value.ToString() != "")
                {
                    currentAmount = double.Parse(dgv.Rows[i].Cells["CreditFC"].Value.ToString());
                    r["Credit"] = currentAmount * double.Parse(txt_CurrencyRate.Text);
                }
            }
        }
        private void FindBatch(string FBatch)
        {
            try
            {
                ClearAll();
                for (int i = dtJVAccounts.Rows.Count - 1; i >= 0; i--)
                    dtJVAccounts.Rows.RemoveAt(i);
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
                        GeneralFunctions.LockTables("Batch", "JVTransactions", FBatch, "Edit");
                        txtBatch.Text = drBatch.GetInt32(0).ToString();
                        txt_JVNumber.Text = drBatch.GetString(1);
                        txtStatus.Text = drBatch.GetString(7).Trim();
                        txt_JVDescription.Text = drBatch.GetString(4);
                        cb_JournalCode.Text = drBatch.GetString(6);
                        DTP_JVDate.Value = drBatch.GetDateTime(2);
                        txt_Period.Text = drBatch.GetString(3);
                        txt_Balance.Text = "0";
                        txt_UserID.Text = GeneralFunctions.UserName(int.Parse(drBatch.GetString(9).ToString()));
                        if (drBatch.GetSqlInt32(10).Value == 0)
                        {
                            checkBox_Reverse.Checked = false;
                        }
                        else if (drBatch.GetSqlInt32(10).Value == 1)
                        {
                            checkBox_Reverse.Checked = true;
                            cb_period.Text = drBatch.GetString(13);
                            txtrevbatch.Text = drBatch.GetSqlInt32(12).Value.ToString();
                        }
                        SqlConnection sqlTransactions = new SqlConnection(GeneralFunctions.ConnectionString);
                        SqlCommand sqlcommandTransaction = new SqlCommand("Select * From GLTransactions Where BatchNo =" + Convert.ToUInt32(txtBatch.Text) + " AND SortNO <> 0 ORDER BY SortNO", sqlTransactions);
                        sqlTransactions.Open();
                        SqlDataReader sqlreaderTransactions = sqlcommandTransaction.ExecuteReader();
                        DataRow dr;
                        SqlConnection sqlAccountConnection;
                        SqlCommand sqlAccountCommand;
                        SqlDataReader sqlAccountread;
                        int countrowU = 0;
                        double Amount = 0;
                        if (sqlreaderTransactions.HasRows)
                        {
                            while (sqlreaderTransactions.Read())
                            {
                                dr = dtJVAccounts.NewRow();
                                sqlAccountConnection = new SqlConnection(GeneralFunctions.ConnectionString);
                                sqlAccountCommand = new SqlCommand("Select * From GLAccounts Where AccountNumber ='" + sqlreaderTransactions.GetString(2) + "'", sqlAccountConnection);
                                sqlAccountConnection.Open();
                                sqlAccountread = sqlAccountCommand.ExecuteReader();
                                if (sqlAccountread.HasRows)
                                {
                                    while (sqlAccountread.Read())
                                    {
                                        dr["AccountNumber"] = sqlAccountread.GetString(0);
                                        dr["AccountName"] = sqlAccountread.GetString(1);
                                        dr["AccountTypeName"] = sqlAccountread.GetString(2);
                                    }
                                }
                                dr["JVNumber"] = drBatch.GetString(1);
                                if (sqlreaderTransactions.GetValue(3) != DBNull.Value)
                                    dr["Reference"] = sqlreaderTransactions.GetString(3);
                                else
                                    dr["Reference"] = "";
                                dr["Date"] = sqlreaderTransactions.GetDateTime(4);
                                if (sqlreaderTransactions.GetValue(5).ToString() != "" && sqlreaderTransactions.GetValue(5).ToString() != "0")
                                {
                                    Amount = double.Parse(sqlreaderTransactions.GetValue(5).ToString());
                                    if (Amount < 0)
                                    {
                                        dr["CreditFC"] = (-1 * Amount);
                                        dr["DebitFC"] = "0";
                                    }
                                    else if (Amount > 0)
                                    {
                                        dr["CreditFC"] = "0";
                                        dr["DebitFC"] = Amount.ToString();
                                    }
                                    else
                                    {
                                        dr["DebitFC"] = "0";
                                        dr["CreditFC"] = "0";
                                    }
                                }
                                else
                                {
                                    dr["DebitFC"] = "0";
                                    dr["CreditFC"] = "0";
                                }
                                if (sqlreaderTransactions.GetValue(8).ToString() != "" && sqlreaderTransactions.GetValue(8).ToString() != "0")
                                {
                                    Amount = double.Parse(sqlreaderTransactions.GetValue(8).ToString());
                                    if (Amount < 0)
                                    {
                                        dr["Credit"] = (-1 * Amount);
                                        dr["Debit"] = "0";
                                    }
                                    else if (Amount > 0)
                                    {
                                        dr["Credit"] = "0";
                                        dr["Debit"] = Amount.ToString();
                                    }
                                    else
                                    {
                                        dr["Debit"] = "0";
                                        dr["Credit"] = "0";
                                    }
                                }
                                else
                                {
                                    dr["Debit"] = "0";
                                    dr["Credit"] = "0";
                                }
                                if (sqlreaderTransactions.GetValue(9) != DBNull.Value)
                                    dr["Units"] = sqlreaderTransactions.GetInt32(9);
                                else
                                    dr["Units"] = 0;

                                if (sqlreaderTransactions.GetString(6) != "")
                                {
                                    checkBox_multiCurrency.Checked = true;
                                    cb_Currency.Visible = true;
                                    if (sqlreaderTransactions.GetValue(6) != DBNull.Value)
                                        cb_Currency.Text = sqlreaderTransactions.GetString(6);
                                    else
                                        cb_Currency.Text = "";
                                    if (sqlreaderTransactions.GetValue(7) != DBNull.Value)
                                        txt_CurrencyRate.Text = sqlreaderTransactions.GetDouble(7).ToString();
                                    else
                                        txt_CurrencyRate.Text = "";
                                }
                                else
                                {
                                    checkBox_multiCurrency.Checked = false;
                                    cb_Currency.Text = "";
                                    txt_CurrencyRate.Text = "";
                                }

                                dtJVAccounts.Rows.Add(dr);

                                if (sqlreaderTransactions.GetValue(10) != DBNull.Value)
                                    dgv.Rows[countrowU].Cells["ProjectCode"].Value = sqlreaderTransactions.GetValue(10).ToString();
                                else
                                    dgv.Rows[countrowU].Cells["ProjectCode"].Value = "";
                                if (sqlreaderTransactions.GetValue(10) != DBNull.Value)
                                    dgv.Rows[countrowU].Cells["DepartmentCode"].Value = sqlreaderTransactions.GetValue(12).ToString();
                                else
                                    dgv.Rows[countrowU].Cells["DepartmentCode"].Value = "";
                                dgv.Refresh();
                                dgv.Columns["AccountID"].Visible = false;
                                dgv.Columns["AccountTypeName"].Visible = false;
                                dgv.Columns["JVNumber"].Visible = false;
                                dgv.Columns["DebitFC"].ReadOnly = true;
                                dgv.Columns["CreditFC"].ReadOnly = true;
                                dgv.Columns["Debit"].ReadOnly = true;
                                dgv.Columns["Credit"].ReadOnly = true;
                                countrowU++;
                            }
                        }

                    }
                }
                DataRow rDGV = dtJVAccounts.NewRow();
                dtJVAccounts.Rows.Add(rDGV);
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                DisableAll();
                CalculateBalance();
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
                searchSpecificJV.endyearsadjustments = "";
                searchSpecificJV.ShowDialog();
                if (searchSpecificJV.selectBatchNo != "" && searchSpecificJV.selectBatchNo != null)
                {
                    txtFind.Text = searchSpecificJV.selectBatchNo.ToString();
                    FindBatch(txtFind.Text);
                    checkBox_multiCurrency_CheckedChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void checkBox_multiCurrency_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_multiCurrency.Checked == true)
                {
                    cb_Currency.Visible = true;
                    label_Currency.Visible = true;
                    label_CurrencyRate.Visible = true;
                    txt_CurrencyRate.Visible = true;
                    dgv.Columns["Debit"].ReadOnly = true;
                    dgv.Columns["Credit"].ReadOnly = true;
                    dgv.Columns["DebitFC"].ReadOnly = false;
                    dgv.Columns["CreditFC"].ReadOnly = false;
                    dgv.Columns["DebitFC"].Visible = true;
                    dgv.Columns["CreditFC"].Visible = true;
                }
                else
                {
                    cb_Currency.Visible = false;
                    label_Currency.Visible = false;
                    label_CurrencyRate.Visible = false;
                    txt_CurrencyRate.Visible = false;
                    dgv.Columns["Debit"].ReadOnly = false;
                    dgv.Columns["Credit"].ReadOnly = false;
                    dgv.Columns["DebitFC"].ReadOnly = true;
                    dgv.Columns["CreditFC"].ReadOnly = true;
                    dgv.Columns["DebitFC"].Visible = false;
                    dgv.Columns["CreditFC"].Visible = false;

                    //***************************************
                    if (dgv.Rows.Count < 3)
                        return;

                    double currentAmount;
                    DataRow r;
                    for (int i = 0; i < dtJVAccounts.Rows.Count; i++)
                    {
                        r = dtJVAccounts.Rows[i];
                        if (r.Equals(dtJVAccounts.Rows[dtJVAccounts.Rows.Count - 1]) && dgv.Rows[i].Cells["AccountNumber"].Value == null && dgv.Rows[i].Cells["AccountName"].Value == null)
                            break;
                        if (dgv.Rows[i].Cells["DebitFC"].Value.ToString() != "")
                        {
                            currentAmount = double.Parse(dgv.Rows[i].Cells["DebitFC"].Value.ToString());
                            r["DebitFC"] = currentAmount.ToString();
                        }
                        if (dgv.Rows[i].Cells["CreditFC"].Value.ToString() != "")
                        {
                            currentAmount = double.Parse(dgv.Rows[i].Cells["CreditFC"].Value.ToString());
                            r["CreditFC"] = currentAmount.ToString();
                        }
                    }
                    //****************************************

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "General Ledger");
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
        private void AddBatchreverse(int BatchReverse)
        {
            try
            {
                string periodName;
                int prid;
                DateTime pred;
                GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(cb_period.Text)), out prid, out periodName, out pred);
                DataRow rBatch = this.dbAccountingProjectDS.Batch.NewRow();
                rBatch["BatchNo"] = BatchReverse;
                rBatch["JVNumber"] = GeneralFunctions.CreateJVNumberFormat(GeneralFunctions.lblJV, GeneralFunctions.JVNumberFormat, true);
                rBatch["BatchDate"] = Convert.ToDateTime(cb_period.Text); //string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value.Date);
                rBatch["BatchPRD"] = periodName;
                rBatch["BatchDSC"] = txt_JVDescription.Text;
                rBatch["BatchSRC"] = "GL";
                rBatch["BatchJNL"] = cb_JournalCode.Text;
                rBatch["BatchStat"] = "P";
                rBatch["PostDate"] = DateTime.Now.Date;
                rBatch["UserID"] = AaDeclrationClass.xUserCode.ToString();
                rBatch["REVBatch"] = 1;
                if (txtrevbatch.Text == "")
                    rBatch["REVBatchNo"] = 0;
                else
                    rBatch["REVBatchNo"] = int.Parse(txtBatch.Text);
                rBatch["REVBatchPRD"] = txt_Period.Text;
                rBatch["PropertyCode"] = 0;
                rBatch["AllocationCode"] = "";
                rBatch["Tran_Cashier"] = false;
                dbAccountingProjectDS.Batch.Rows.Add(rBatch);
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
                SqlConnection sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlDataReader dr;
                sqlcon.Open();
                int i = 0;
                foreach(DataGridViewRow row in dgv.Rows)
                {
                    i++;
                    if (dgv.RowCount - 1 == i)
                        break;
                    string accnum = (String)row.Cells["AccountNumber"].Value;
                    SqlCommand cmd = new SqlCommand("Select Accnumber From Departmentsccounts Where Accnumber='" + accnum + "'", sqlcon);
                   dr = cmd.ExecuteReader();
                    if(dr.HasRows&& (String)row.Cells["DepartmentCode"].Value==null)
                    {
                        
                        MessageBox.Show("Please Select Department First");
                        sqlcon.Close();
                        dr.Close();
                        return;
                    }
                    dr.Close();
                }
                sqlcon.Close();
                if (!TranValue())
                {
                    MessageBox.Show("Can't Save Please Check Transactions", "General Ledger");
                    return;
                }

                if (txt_Balance.Text != "0")
                {
                    DialogResult myrst;
                    string s = " Balance = " + txt_Balance.Text + " Are You Sure Save";
                    myrst = MessageBox.Show(s, "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (myrst == DialogResult.No)
                        return;
                }

                if (//GeneralFunctions.ValidateString(txt_JVDescription.Text, "Please Specify a JV Description")
                                GeneralFunctions.ValidateComboBox(cb_JournalCode, "Please Select a Journal Code")
                               && ValidateYear() && ValidatePeriod())
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
                        rBatch["BatchJNL"] = cb_JournalCode.Text;
                        rBatch["BatchStat"] = "U";
                        rBatch["PostDate"] = DBNull.Value;
                        rBatch["UserID"] = AaDeclrationClass.xUserCode.ToString();
                        if (checkBox_Reverse.Checked == true)
                        {
                            rBatch["REVBatch"] = 1;
                            if (txtrevbatch.Text == "")
                                rBatch["REVBatchNo"] = 0;
                            else
                                rBatch["REVBatchNo"] = int.Parse(txtrevbatch.Text);
                            rBatch["REVBatchPRD"] = cb_period.Text;

                        }
                        else
                        {
                            rBatch["REVBatch"] = 0;
                            rBatch["REVBatchNo"] = 0;
                            rBatch["REVBatchPRD"] = "";
                        }
                        rBatch["PropertyCode"] = 0;
                        rBatch["AllocationCode"] = "";
                        rBatch["Tran_Cashier"] = false;
                        dbAccountingProjectDS.Batch.Rows.Add(rBatch);
                        AddJVTransactionAccounts();
                        drBatch.Close();
                        sqlconBatch.Close();
                        update();
                        MessageBox.Show("JV Transaction Record inserted successfully", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GeneralFunctions.UnLockTable("", "JVTransactions", "", "New");
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
        private bool TranValue()
        {
            int c = 0;
            bool valid = true;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells["AccountName"].Value.ToString() != "")
                {
                    c++;
                    if (double.Parse(dgv.Rows[i].Cells["Debit"].Value.ToString()) == 0 && double.Parse(dgv.Rows[i].Cells["Credit"].Value.ToString()) == 0 && double.Parse(dgv.Rows[i].Cells["Units"].Value.ToString()) == 0)
                    {
                        valid = false;
                        break;
                    }
                }
            }
            if (c <= 0)
                valid = false;
            return valid;
        }
        private void CopyWithReverse()
        {
            double d = 0;
            double c = 0;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells["AccountName"].Value.ToString() != "")
                {
                    d = double.Parse(dgv.Rows[i].Cells["Debit"].Value.ToString());
                    c = double.Parse(dgv.Rows[i].Cells["Credit"].Value.ToString());
                    dgv.Rows[i].Cells["Credit"].Value = d.ToString();
                    dgv.Rows[i].Cells["Debit"].Value = c.ToString();
                }
            }
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
            if (!TranValue())
            {
                MessageBox.Show("Can't Save Please Check Transactions", "General Ledger");
                return;
            }
            if (txt_JVNumber.Text != "" && GeneralFunctions.ValidateComboBox(cb_JournalCode, "Please Select a Journal Code") && ValidateYear() && ValidatePeriod())
            {
                if (txt_Balance.Text != "0")
                {
                    DialogResult myrst;
                    string s = " Balance = " + txt_Balance.Text + " Are You Sure Save";
                    myrst = MessageBox.Show(s, "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (myrst == DialogResult.No)
                        return;
                }
                int R = 0;
                if (checkBox_Reverse.Checked == true)
                    R = 1;
                SqlConnection sqlconnEditing = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlconnEditing.Open();
                SqlCommand sqlcommandEditing = new SqlCommand("Update Batch SET BatchDate= '" + string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value.Date) + "',BatchPRD='" + txt_Period.Text + "',BatchDSC='" + txt_JVDescription.Text + "',BatchJNL='" + cb_JournalCode.Text + "',UserID='" + AaDeclrationClass.xUserCode.ToString() + "',REVBatch=" + R + ",REVBatchPRD='" + cb_period.Text + "' WHERE BatchNo=" + Convert.ToInt32(txtBatch.Text) + "", sqlconnEditing);
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

        private void cb_Temptran_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb_Temptran.Text != "" && cb_Temptran.Text != "<new>")
                {
                    btnNew_Click("Yes", e);
                    DataRow[] rArrResult;
                    DataRow r;
                    rArrResult = dbAccountingProjectDS.BatchTemp.Select("TempID = '" + int.Parse(cb_Temptran.Text) + "'");
                    if (rArrResult.Length != 0)
                    {
                        txt_JVDescription.Text = rArrResult[0]["DescTemp"].ToString();
                        cb_JournalCode.Text = rArrResult[0]["BatchJNL"].ToString();
                        rArrResult = dbAccountingProjectDS.GLTransactionsTemp.Select("BatchTempNo = '" + int.Parse(cb_Temptran.Text) + "'");
                        if (rArrResult.Length != 0)
                        {
                            dtJVAccounts.Rows.RemoveAt(dtJVAccounts.Rows.Count - 1);
                            double Amount = 0;
                            for (int i = 0; i < rArrResult.Length; i++)
                            {
                                r = dtJVAccounts.NewRow();
                                r["AccountID"] = GeneralFunctions.JVAccounts;
                                GeneralFunctions.JVAccounts++;
                                DataRow[] racc = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + rArrResult[i]["AccountNumber"].ToString() + "'");
                                if (racc.Length != 0)
                                {
                                    r["AccountTypeName"] = racc[0]["AccountTypeName"].ToString();
                                    r["AccountName"] = racc[0]["AccountName"].ToString();
                                }
                                r["AccountNumber"] = rArrResult[i]["AccountNumber"];
                                r["Date"] = string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value);
                                if (rArrResult[i]["Reference"] != null && rArrResult[i]["Reference"].ToString() != "")
                                {
                                    r["Reference"] = rArrResult[i]["Reference"];
                                }

                                if (rArrResult[i]["Units"] != null && rArrResult[i]["Units"].ToString() != "")
                                {
                                    r["Units"] = rArrResult[i]["Units"];
                                }
                                else
                                    r["Units"] = 0;
                                if (rArrResult[i]["Amount"].ToString() != "" && rArrResult[i]["Amount"].ToString() != "0")
                                {
                                    Amount = double.Parse(rArrResult[i]["Amount"].ToString());
                                    if (Amount < 0)
                                    {
                                        r["CreditFC"] = (-1 * Amount);
                                        r["DebitFC"] = "0";
                                    }
                                    else if (Amount > 0)
                                    {
                                        r["CreditFC"] = "0";
                                        r["DebitFC"] = Amount.ToString();
                                    }
                                    else
                                    {
                                        r["DebitFC"] = "0";
                                        r["CreditFC"] = "0";
                                    }
                                }
                                else
                                {
                                    r["DebitFC"] = "0";
                                    r["CreditFC"] = "0";
                                }
                                if (rArrResult[i]["AmountLC"].ToString() != "" && rArrResult[i]["AmountLC"].ToString() != "0")
                                {
                                    Amount = double.Parse(rArrResult[i]["AmountLC"].ToString());
                                    if (Amount < 0)
                                    {
                                        r["Credit"] = (-1 * Amount);
                                        r["Debit"] = "0";
                                    }
                                    else if (Amount > 0)
                                    {
                                        r["Credit"] = "0";
                                        r["Debit"] = Amount.ToString();
                                    }
                                    else
                                    {
                                        r["Debit"] = "0";
                                        r["Credit"] = "0";
                                    }
                                }
                                else
                                {
                                    r["Debit"] = "0";
                                    r["Credit"] = "0";
                                }
                                if (rArrResult[i]["CurrencyType"] != null && rArrResult[i]["CurrencyType"].ToString() != "")
                                {
                                    checkBox_multiCurrency.Checked = true;
                                    cb_Currency.Visible = true;
                                    if (rArrResult[i]["CurrencyType"] != DBNull.Value)
                                        cb_Currency.Text = rArrResult[i]["CurrencyType"].ToString();
                                    else
                                        cb_Currency.Text = "";
                                    txt_CurrencyRate.Visible = true;
                                    cb_Currency.Enabled = true;
                                    if (rArrResult[i]["Rate"] != DBNull.Value)
                                        txt_CurrencyRate.Text = rArrResult[i]["Rate"].ToString();
                                    else
                                        txt_CurrencyRate.Text = "";
                                }
                                else
                                {
                                    checkBox_multiCurrency.Checked = false;
                                    cb_Currency.Visible = false;
                                    cb_Currency.Text = "";
                                    cb_Currency.Enabled = false;
                                    txt_CurrencyRate.Visible = false;
                                    txt_CurrencyRate.Text = "";
                                    checkBox_multiCurrency.Enabled = true;
                                }
                                dtJVAccounts.Rows.Add(r);
                                if (rArrResult[i]["ProjectCode"] != null || rArrResult[i]["ProjectCode"].ToString() != "")
                                {
                                    dgv.Rows[i].Cells["ProjectCode"].Value = rArrResult[i]["ProjectCode"];
                                }
                                if (rArrResult[i]["DepartmentCode"] != null || rArrResult[i]["DepartmentCode"].ToString() != "")
                                {
                                    dgv.Rows[i].Cells["DepartmentCode"].Value = rArrResult[i]["DepartmentCode"];
                                }
                                r.AcceptChanges();
                            }
                            r = dtJVAccounts.NewRow();
                            dtJVAccounts.Rows.Add(r);
                            checkBox_multiCurrency_CheckedChanged(sender, e);
                            CalculateBalance();
                        }
                    }
                }
                else if (cb_Temptran.Text == "<new>")
                {
                    JVTransactionsTemp jc = new JVTransactionsTemp();
                    jc.ShowDialog();
                    cb_Temptran.Items.Clear();
                    dbAccountingProjectDS.BatchTemp.Clear();
                    adaptertbBatchTemp.Fill(dbAccountingProjectDS.BatchTemp);
                    cb_Temptran = GeneralFunctions.FillComboBox(dbAccountingProjectDS.BatchTemp, cb_Temptran, "TempID", "DescTemp");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                DataRow dr;
                if (txt_JVNumber.Text != "")
                {
                    AccountSearch accSearch = new AccountSearch();
                    accSearch.filter = " AND AccountTypeName <> 'Header'";
                    accSearch.ShowDialog();
                    if (accSearch.selectedAccountName != null && accSearch.selectedAccountNumber != null && accSearch.selectedAccountType != null && accSearch.selectedAccountType != "Header")
                    {
                        DataRow[] drc = dtJVAccounts.Select("AccountNumber = '" + accSearch.selectedAccountNumber + "'");
                        if (drc.Length != 0)
                        {
                            MessageBox.Show("This Account Is Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        dtJVAccounts.Rows.RemoveAt(dtJVAccounts.Rows.Count - 1);
                        dr = dtJVAccounts.NewRow();
                        dr["AccountTypeName"] = accSearch.selectedAccountType;
                        dr["AccountID"] = GeneralFunctions.JVAccounts;
                        GeneralFunctions.JVAccounts++;
                        dr["AccountNumber"] = accSearch.selectedAccountNumber;
                        dr["AccountName"] = accSearch.selectedAccountName;
                        dr["Date"] = DTP_JVDate.Value.Date;

                        if (dr["AccountTypeName"].ToString().ToLower() != "header")
                        {
                            dr["Debit"] = "0";
                            dr["Credit"] = "0";
                            dr["DebitFC"] = "0";
                            dr["CreditFC"] = "0";
                            dr["Units"] = 0;
                        }

                        dtJVAccounts.Rows.Add(dr);
                        dr = dtJVAccounts.NewRow();
                        dtJVAccounts.Rows.Add(dr);

                    }
                    if (accSearch.selectedAccountsTable != null && accSearch.selectedAccountsTable.Rows.Count != 0)
                    {
                        dtJVAccounts.Rows.RemoveAt(dtJVAccounts.Rows.Count - 1);
                        for (int i = 1; i < accSearch.selectedAccountsTable.Rows.Count; i++)
                        {
                            dr = dtJVAccounts.NewRow();
                            dr["AccountID"] = GeneralFunctions.TemplateAccounts;
                            GeneralFunctions.TemplateAccounts++;
                            dr["AccountTypeName"] = accSearch.selectedAccountsTable.Rows[i]["AccountTypeName"];
                            dr["AccountNumber"] = accSearch.selectedAccountsTable.Rows[i]["AccountNumber"];
                            dr["AccountName"] = accSearch.selectedAccountsTable.Rows[i]["AccountName"];
                            dr["JVNumber"] = txt_JVNumber.Text;

                            dtJVAccounts.Rows.Add(dr);
                        }
                        dr = dtJVAccounts.NewRow();
                        dtJVAccounts.Rows.Add(dr);
                        dr["Debit"] = "0";
                        dr["Credit"] = "0";
                        dr["DebitFC"] = "0";
                        dr["CreditFC"] = "0";
                        dr["Units"] = 0;
                    }
                }
                else
                    MessageBox.Show("Please Define the JV information first");
            }
            else if (e.ColumnIndex == 13)
            {
                //SearchProjectCode spc = new SearchProjectCode();
                //spc.ShowDialog();
                //if (ClassOptions.Idpro != "")
                //    dgv.CurrentRow.Cells[13].Value = ClassOptions.Idpro;
                //dgv.CurrentRow.Cells[1].Selected = true;
                //ClassOptions.Idpro = "";
            }
        }



        private void dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (dgv.CurrentRow.Cells["AccountTypeName"].Value.ToString() == "Statictical")
                {
                    if (e.ColumnIndex == 7)
                    {
                        e.Cancel = true;
                        return;
                    }
                    if (e.ColumnIndex == 9)
                    {
                        e.Cancel = true;
                        return;
                    }
                    if (e.ColumnIndex == 8)
                    {
                        e.Cancel = true;
                        return;
                    }
                    if (e.ColumnIndex == 10)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                else
                {
                    if (e.ColumnIndex == 11)
                    {
                        e.Cancel = true;
                        return;
                    }

                }
                if (e.ColumnIndex != 1)
                {
                    if (dgv.CurrentRow.Cells["AccountNumber"].Value.ToString() == "")
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                if (e.ColumnIndex == 7)
                {
                    if (double.Parse(dgv.CurrentRow.Cells[9].Value.ToString()) != 0)
                    {
                        e.Cancel = true;
                        return;
                    }

                }
                if (e.ColumnIndex == 9)
                {
                    if (double.Parse(dgv.CurrentRow.Cells[7].Value.ToString()) != 0)
                    {
                        e.Cancel = true;
                        return;
                    }

                }
                if (e.ColumnIndex == 8)
                {
                    if (double.Parse(dgv.CurrentRow.Cells[10].Value.ToString()) != 0)
                    {
                        e.Cancel = true;
                        return;
                    }

                }
                if (e.ColumnIndex == 10)
                {
                    if (double.Parse(dgv.CurrentRow.Cells[8].Value.ToString()) != 0)
                    {
                        e.Cancel = true;
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }
        private bool CheckBalanceAccType()
        {
            bool flage = false;
            int BS = 0;
            int PL = 0;
            ValBS = 0;
            ValPT = 0;
            DataRow r;
            for (int i = 0; i < dtJVAccounts.Rows.Count; i++)
            {
                r = dtJVAccounts.Rows[i];
                if (r.Equals(dtJVAccounts.Rows[dtJVAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountName"].ToString() == "")
                    break;
                if (r["AccountTypeName"].ToString() == "Assets" || r["AccountTypeName"].ToString() == "Liability" || r["AccountTypeName"].ToString() == "Equity")
                {
                    BS++;
                    if (double.Parse(r["Debit"].ToString()) != 0)
                        ValBS = ValBS + double.Parse(r["Debit"].ToString());
                    else if (double.Parse(r["Credit"].ToString()) != 0)
                        ValBS = ValBS - double.Parse(r["Credit"].ToString());
                }
                else if (r["AccountTypeName"].ToString() == "Revenue" || r["AccountTypeName"].ToString() == "Expenses")
                {
                    PL++;
                    if (double.Parse(r["Debit"].ToString()) != 0)
                        ValPT = ValPT + double.Parse(r["Debit"].ToString());
                    else if (double.Parse(r["Credit"].ToString()) != 0)
                        ValPT = ValPT - double.Parse(r["Credit"].ToString());
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
                GeneralFunctions.LockTables("GLTotals", "JVTransactions", "", "Edit");
                //bitcheck l year open wla l2 w mogoda wla l2
                //bitcheck 3la l period
                if (ValidateYear() && ValidatePeriod())
                {
                    string prdbalance = "";
                    double val = 0;
                    int NewBNo = 0;
                    if (txt_Balance.Text != "0")
                    {
                        MessageBox.Show("This JV must have zero balance value", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                            if (checkBox_Reverse.Checked == true)
                            {
                                if (cb_period.Text != "")
                                {
                                    string periodName;
                                    int prid;
                                    DateTime pred;
                                    GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(cb_period.Text)), out prid, out periodName, out pred);
                                    NewBNo = NewBatchNo();
                                    drbatch[0]["REVBatchPRD"] = periodName;
                                    drbatch[0]["REVBatchNo"] = NewBNo;
                                    txtrevbatch.Text = NewBNo.ToString();
                                    AddBatchreverse(NewBNo);
                                    AddJVTransactionAccountsReverse(NewBNo);
                                    if (CheckBalanceAccType() != false)
                                    {
                                        AddAccountsForBS_PL_Rev();
                                    }
                                    DataRow[] transactionreverse = this.dbAccountingProjectDS.GLTransactions.Select("BatchNo=" + NewBNo + "");
                                    if (transactionreverse.Length != 0)
                                    {
                                        string s = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(cb_period.Text).Date);
                                        prdbalance = FindPeriod(s);
                                        for (int i = 0; i < transactionreverse.Length; i++)
                                        {
                                            DataRow[] AcctypeRev = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + transactionreverse[i]["GLAccount"].ToString() + "'");
                                            if (AcctypeRev.Length != 0)
                                            {
                                                if (AcctypeRev[0]["AccountTypeName"].ToString() != "Statictical")
                                                    val = double.Parse(transactionreverse[i]["AmountLC"].ToString());
                                                else
                                                    val = double.Parse(transactionreverse[i]["TRANSUnit"].ToString());
                                            }
                                            ModifyTotals(prdbalance, transactionreverse[i]["GLAccount"].ToString(), val, Convert.ToDateTime(Convert.ToDateTime(cb_period.Text)).Date);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please Check Period Reverse", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            drbatch = this.dbAccountingProjectDS.Batch.Select("BatchNo=" + Convert.ToInt32(txtBatch.Text) + " AND BatchStat='U'");
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
                GeneralFunctions.UnLockTable("GLTotals", "JVTransactions", "", "Edit");
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
                    checkBox_Reverse.Enabled = false;
                }
                else if (groupDetails.Enabled == false)
                {
                    btn_Post.Enabled = false;
                    btnCopy.Enabled = true;
                    checkBox_Reverse.Enabled = false;

                }
            }
            else if (txtStatus.Text == "U")
            {
                if (groupDetails.Enabled == true)
                {
                    btn_Post.Enabled = false;
                    btnCopy.Enabled = false;
                    checkBox_Reverse.Enabled = true;
                }
                else if (groupDetails.Enabled == false)
                {
                    btn_Post.Enabled = true;
                    btnCopy.Enabled = false;
                    checkBox_Reverse.Enabled = false;
                }

            }
            else
            {
                btnCopy.Enabled = false;

            }
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.SelectedRows.Count == 0 && dgv.SelectedCells.Count == 0)
                return;
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (dgv.CurrentCell.Value != null)
                {
                    if (dgv.CurrentRow.Cells["AccountNumber"].Value.ToString() != "")
                    {
                        if (e.ColumnIndex == 1)
                        {
                            string accountNumber;
                            accountNumber = dgv.CurrentRow.Cells["AccountNumber"].Value.ToString();
                            DataRow[] drc = dtJVAccounts.Select("AccountNumber = '" + accountNumber + "'");
                            if (drc.Length != 0)
                            {
                                MessageBox.Show("This Account Is Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dgv.CancelEdit();
                                return;
                            }
                            DataRow[] rArr = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + accountNumber + "' and AccountTypeName <> 'Header'");
                            if (rArr.Length != 0)
                            {
                                dgv.CurrentRow.Cells["AccountTypeName"].Value = rArr[0]["AccountTypeName"].ToString();
                                dgv.CurrentRow.Cells["AccountName"].Value = rArr[0]["AccountName"].ToString();
                                if (e.RowIndex == dtJVAccounts.Rows.Count - 1)
                                {
                                    DataRow r = dtJVAccounts.NewRow();
                                    dtJVAccounts.Rows.Add(r);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please Check AccountNumber", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dgv.CancelEdit();
                                return;
                            }
                        }
                    }

                    if (e.ColumnIndex == 1)
                    {

                        dgv.CurrentRow.Cells["Date"].Value = string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value);
                        dgv.CurrentRow.Cells["DebitFC"].Value = "0";
                        dgv.CurrentRow.Cells["CreditFC"].Value = "0";
                        dgv.CurrentRow.Cells["Debit"].Value = "0";
                        dgv.CurrentRow.Cells["Credit"].Value = "0";
                        dgv.CurrentRow.Cells["Units"].Value = 0;

                    }
                    if (e.ColumnIndex == 11)
                    {
                        if (dgv.CurrentCell.Value.ToString() == "")
                            dgv.CurrentCell.Value = "0";
                        CalculateBalance();
                    }
                    if (e.ColumnIndex == 7)
                    {
                        if (dgv.CurrentCell.Value.ToString() == "")
                            dgv.CurrentCell.Value = "0";
                        CalculateBalance();
                    }
                    if (e.ColumnIndex == 9)
                    {
                        if (dgv.CurrentCell.Value.ToString() == "")
                            dgv.CurrentCell.Value = "0";
                        CalculateBalance();

                    }
                    if (e.ColumnIndex == 8)
                    {
                        if (dgv.CurrentCell.Value.ToString() == "")
                            dgv.CurrentCell.Value = "0";
                        if (checkBox_multiCurrency.Checked && cb_Currency.Text != "")
                        {
                            double amount = double.Parse(dgv.Rows[e.RowIndex].Cells["DebitFC"].Value.ToString());
                            dgv.Rows[e.RowIndex].Cells["Debit"].Value = "" + GeneralFunctions.CalculateForiegnCurrencyValue(amount, double.Parse(txt_CurrencyRate.Text));
                        }
                        else if (checkBox_multiCurrency.Checked && cb_Currency.Text == "")
                        {
                            dgv.Rows[e.RowIndex].Cells["DebitFC"].Value = "0";
                            MessageBox.Show("Please Specify the foreign currency", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        CalculateBalance();
                    }
                    if (e.ColumnIndex == 10)
                    {
                        if (dgv.CurrentCell.Value.ToString() == "")
                            dgv.CurrentCell.Value = "0";
                        if (checkBox_multiCurrency.Checked && cb_Currency.Text != "")
                        {
                            double amount = double.Parse(dgv.Rows[e.RowIndex].Cells["CreditFC"].Value.ToString());
                            dgv.Rows[e.RowIndex].Cells["Credit"].Value = "" + GeneralFunctions.CalculateForiegnCurrencyValue(amount, double.Parse(txt_CurrencyRate.Text));
                        }
                        else if (checkBox_multiCurrency.Checked && cb_Currency.Text == "")
                        {
                            dgv.Rows[currentRowIndex].Cells["CreditFC"].Value = "0";
                            MessageBox.Show("Please Specify the foreign currency", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        CalculateBalance();
                    }
                }
            }
            checkBox_multiCurrency_CheckedChanged(sender, e);

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            DialogResult myrst;
            myrst = MessageBox.Show("You Want Copy This Batch With Reverse", "General Ledger", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.Cancel)
                return;
            if (myrst == DialogResult.Yes)
                CopyWithReverse();
            checkBox_Reverse.Checked = false;
            EnableAll();
            txtFind.Text = "";
            txtrevbatch.Text = "";
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
                checkBox_multiCurrency_CheckedChanged(sender, e);
            }
        }

        private void btnFind_EnabledChanged(object sender, EventArgs e)
        {
            if (btnFind.Enabled == true)
                txtFind.Enabled = true;
            else
                txtFind.Enabled = false;
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgv.SelectedRows.Count != 0)
            {

                if (e.KeyCode == Keys.Delete)
                {
                    DialogResult myrst;
                    myrst = MessageBox.Show("Are You Sure Delete This Transaction", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (myrst == DialogResult.No)
                        return;
                    DataRow[] rArr;
                    if (dgv.CurrentRow.Cells["AccountNumber"].Value.ToString() != "")
                    {
                        string accountID = dgv.CurrentRow.Cells["AccountNumber"].Value.ToString();
                        rArr = dtJVAccounts.Select("AccountNumber = '" + accountID + "'");
                        if (rArr.Length > 0)
                        {
                            rArr[0].Delete();
                            CalculateBalance();
                            SqlConnection sqlconndelete = new SqlConnection(GeneralFunctions.ConnectionString);
                            sqlconndelete.Open();
                            SqlCommand sqlcommandDeletetran = new SqlCommand("Delete From GLTransactions Where GLAccount = '" + accountID + "' And BatchNo = " + int.Parse(txtBatch.Text), sqlconndelete);
                            SqlDataReader drDeletetran = sqlcommandDeletetran.ExecuteReader();
                            drDeletetran.Close();
                            sqlconndelete.Close();
                            refill();
                            //btn_Post.Enabled = true;
                            //btnSaveEdit.Visible = false;
                            //btnEdit.Visible = true;
                            //btnEdit.Enabled = true;
                            //btnNew.Enabled = true;
                            //btnFind.Enabled = true;
                            //btnNew.Visible = true;
                            //btnDelete.Enabled = true;
                            //DisableAll();
                        }
                    }
                }
            }
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
        private void checkBox_Reverse_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Reverse.Checked == true)
            {
                cb_period.Enabled = true;
                if (GetNextPeriod() > 0)
                {
                    fillperiod(GetNextPeriod());
                    cb_period.SelectedIndex = 0;

                }
                else
                {
                    MessageBox.Show("NextPeriod isn't exists", "General Ladger");
                    cb_period.Items.Clear();
                    txtrevbatch.Text = "";
                }
            }
            else
            {
                cb_period.Enabled = false;
                cb_period.SelectedIndex = -1;
                txtrevbatch.Text = "";
            }
        }

        private void txtrevbatch_TextChanged(object sender, EventArgs e)
        {
            if (txtrevbatch.Text != "0" && txtrevbatch.Text != "")
                btnreverse.Visible = true;
            else
                btnreverse.Visible = false;
        }

        private void btnreverse_Click(object sender, EventArgs e)
        {
            if (txtrevbatch.Text != "0" && txtrevbatch.Text != "")
            {
                FindBatch(txtrevbatch.Text);
                checkBox_multiCurrency_CheckedChanged(sender, e);
            }

        }

        private void DTP_JVDate_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dtJVAccounts.Rows.Count - 1; i++)
            {
                dtJVAccounts.Rows[i]["Date"] = string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value);
            }
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

        private void JVTransactions_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralFunctions.UnLockTable("", "JVTransactions", "", "");
        }

        private void txt_UserID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}