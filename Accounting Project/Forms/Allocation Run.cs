using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Accounting_GeneralLedger.Resources;

namespace Accounting_GeneralLedger
{
    public partial class Allocation_Run : Form
    {
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbAllocation;
        private SqlDataAdapter adaptertbAllocationsource;
        private SqlDataAdapter adaptertbAllocationDestinationAccounts;
        private SqlDataAdapter adaptertbGLJVTransaction;
        private SqlDataAdapter adaptertbBatch;
        private SqlDataAdapter adaptertbAccounts;
        private SqlDataAdapter adaptertbGLTotals;
        private int decmal = 1;
        private SqlDataAdapter adaptertbG_L_GeneralSetup;
        private SqlCommandBuilder cmdBuilderGLTotals;
        private SqlCommandBuilder cmdBuildertbJVTransaction;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private string DefaultACCBalanceSheet = "";
        private string DefaultACCIncomeStatment = "";
        private SqlCommandBuilder cmdBuilderBatch;
        private SqlDataAdapter adaptertbGeneralSetup;
        private DataTable dtDestinationAccounts;
        private DataTable dtallocation;
        private DataTable dtSourceAccounts;
        private DataRow r;
        private string periodName = "";
        private string currentJVNumber = "";
        private int currentPeriodID;
        private static DateTime currentEndDate;
        private double Valuesource = 0;
        private int NewNumber;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        private double ValBS = 0;
        private double ValPT = 0;
        public Allocation_Run()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Allocation_Run_Load(object sender, EventArgs e)
        {
            try
            {
                string msg = GeneralFunctions.CheckLockTables("", "AllocationMaintenance", "", "Edit");
                if ( msg != "")
                {
                    MessageBox.Show("Can't Open Because AllocationMaintenance Edit By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                    return;
                }
                msg = GeneralFunctions.CheckLockTables("", "Allocation Run", "", "Open");
                if (msg != "")
                {
                    MessageBox.Show("Allocation Run Open By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Lock67.Visible = false;
                }
                msg = GeneralFunctions.CheckLockTables("GLFiscalPeriod", "EndMonth", "", "Edit");
                if (msg != "")
                {
                    MessageBox.Show("EndMonth Edit By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                    return;
                }
                msg = GeneralFunctions.CheckLockTables("GLFiscalPeriodSetup", "ENDYear", "", "Edit");
                if (msg != "")
                {
                    MessageBox.Show("ENDYear Edit By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                    return;
                }
                GeneralFunctions.LockTables("", "Allocation Run", "", "Open");
                GeneralFunctions.priviledgeGroupBox(Lock67);
                sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
                dbAccountingProjectDS = new dbAccountingProjectDS();
                adaptertbAllocation = new SqlDataAdapter("Select distinct(AllocationCode) from GLAllocation", sqlcon);
                adaptertbAllocationsource = new SqlDataAdapter("Select * from GLAllocation", sqlcon);
                adaptertbAllocationDestinationAccounts = new SqlDataAdapter("Select * from GLAllocationDestinationAccounts", sqlcon);
                adaptertbGLTotals = new SqlDataAdapter("Select * from GLTotals", sqlcon);
                adaptertbGLJVTransaction = new SqlDataAdapter("Select * From GLTransactions", sqlcon);
                adaptertbBatch = new SqlDataAdapter("Select * From Batch", sqlcon);
                adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
                adaptertbG_L_GeneralSetup = new SqlDataAdapter("Select * from G_L_GeneralSetup", sqlcon);
                adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts", sqlcon);
                adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
                adaptertbBatch.Fill(dbAccountingProjectDS.Batch);
                adaptertbGLTotals.Fill(dbAccountingProjectDS.GLTotals);
                adaptertbGLJVTransaction.Fill(dbAccountingProjectDS.GLTransactions);
                adaptertbAllocationsource.Fill(dbAccountingProjectDS.GLAllocation);
                adaptertbAllocationDestinationAccounts.Fill(dbAccountingProjectDS.GLAllocationDestinationAccounts);
                adaptertbG_L_GeneralSetup.Fill(dbAccountingProjectDS.G_L_GeneralSetup); 
                cmdBuilderBatch = new SqlCommandBuilder(adaptertbBatch); 
                cmdBuildertbJVTransaction = new SqlCommandBuilder(adaptertbGLJVTransaction);
                cmdBuilderGLTotals = new SqlCommandBuilder(adaptertbGLTotals);
                adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
                //adaptertbG_L_GeneralSetup.Fill(dbAccountingProjectDS.G_L_GeneralSetup);
                foreach (DataRow drg in dbAccountingProjectDS.GeneralSetup.Rows)
                {
                    decmal = int.Parse(drg["DecimalPointsNumber"].ToString()); 
                    GeneralFunctions.JVNumberFormat = drg["JVNumberFormat"].ToString();
                    GeneralFunctions.lblJV = drg["lblJV"].ToString();
                }
                DataRow[] drGL = dbAccountingProjectDS.G_L_GeneralSetup.Select();
                if (drGL.Length != 0)
                {
                    DefaultACCBalanceSheet = drGL[0]["BalanceSheet"].ToString();
                    DefaultACCIncomeStatment = drGL[0]["IncomeStatment"].ToString();
                    if (DefaultACCBalanceSheet == "" || DefaultACCIncomeStatment == "")
                    {
                        MessageBox.Show("Please Check AccountBalanceSheet And AccountIncomeStatment In G/L GeneralSetup ", "Error");
                        this.Close();
                    }
                }
                dtallocation = new DataTable();
                adaptertbAllocation.Fill(dtallocation);
                ArrayList allcode = new ArrayList() ;
                for (int i = 0; i < dtallocation.Rows.Count; i++)
                {
                    allcode.Add(dtallocation.Rows[i][0].ToString());
                }
                adaptertbAllocation = new SqlDataAdapter("Select * from GLAllocation", sqlcon);
                adaptertbAllocation.Fill(dbAccountingProjectDS.GLAllocation);
                dtallocation = new DataTable();
                dtallocation.Columns.Add("Code", System.Type.GetType("System.String"));
                dtallocation.Columns.Add("Journal", System.Type.GetType("System.String"));
                dtallocation.Columns.Add("Description", System.Type.GetType("System.String"));
                dtallocation.Columns.Add("Repeat", System.Type.GetType("System.String"));
                DataRow dr;
                DataRow[] drs;
                for (int i = 0; i < allcode.Count; i++)
                {
                    drs = dbAccountingProjectDS.GLAllocation.Select("AllocationCode = '" + allcode[i].ToString() + "'" );
                    if (drs.Length != 0)
                    {
                        dr = dtallocation.NewRow();
                        dr["Code"] = drs[0]["AllocationCode"];
                        dr["Journal"] = drs[0]["AllocationGLJournalCode"];
                        dr["Description"] = drs[0]["AllocationDescription"];
                        dr["Repeat"] = drs[0]["AllocationRepeat"];
                        dtallocation.Rows.Add(dr);
                    }
                }
                        
                dgvallocation.DataSource = dtallocation;
                dgvallocation.Columns["Repeat"].Visible = false;
                dgvallocation.Refresh();
                    //AllocationCode,DestinationGLAccountNumber,DestinationAccountDescription,DestinationAccountPercentage
                dtSourceAccounts = new DataTable();
                //dtSourceAccounts.Columns.Add("AllocationCode", System.Type.GetType("System.Int32"));
                //dtSourceAccounts.Columns.Add("AllocationGLJournalCode", System.Type.GetType("System.String"));
                //dtSourceAccounts.Columns.Add("AllocationDescription", System.Type.GetType("System.String"));
                dtSourceAccounts.Columns.Add("AllocationSourceAccount", System.Type.GetType("System.String"));
                dtSourceAccounts.Columns.Add("AllocationSourceAccountName", System.Type.GetType("System.String"));
                dtSourceAccounts.Columns.Add("AllocationSourceAccountPercentage", System.Type.GetType("System.Double"));
                //adaptertbAllocationsource.Fill(dtSourceAccounts);
                dgvsource.DataSource = dtSourceAccounts;
                //dgvsource.Columns[0].HeaderText = "Code";
                //dgvsource.Columns[1].HeaderText = "GLJournalCode";
                //dgvsource.Columns[2].HeaderText = "Description";
                dgvsource.Columns[0].HeaderText = "AccountNumber";
                dgvsource.Columns[1].HeaderText = "AccountName";
                dgvsource.Columns[2].HeaderText = "Percentage";
                dgvsource.Refresh();
                dtDestinationAccounts = new DataTable();
                //dtDestinationAccounts.Columns.Add("AllocationCode", System.Type.GetType("System.Int32"));
                dtDestinationAccounts.Columns.Add("DestinationGLAccountNumber", System.Type.GetType("System.String"));
                dtDestinationAccounts.Columns.Add("DestinationAccountDescription", System.Type.GetType("System.String"));
                dtDestinationAccounts.Columns.Add("DestinationAccountPercentage", System.Type.GetType("System.Double"));
                //adaptertbAllocationDestinationAccounts.Fill(dtDestinationAccounts);
                dgvdestination.DataSource = dtDestinationAccounts;
                //dgvdestination.Columns[0].HeaderText = "Code";
                dgvdestination.Columns[0].HeaderText = "AccountNumber";
                dgvdestination.Columns[1].HeaderText = "AccountName";
                dgvdestination.Columns[2].HeaderText = "Percentage"; 
                dgvdestination.Refresh();
                if (GeneralFunctions.languagechioce != "")
                {
                    this.obj_options = new ClassOptions();
                    this.obj_options.report_language = GeneralFunctions.languagechioce;
                    this.update_language_interface();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }
        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.formRunAllocation;
            this.label3.Text = obj_interface_language.SourceAccount;
            this.label6.Text = obj_interface_language.DestinationAccounts;
            this.chkpost.Text = obj_interface_language.Posted;

            this.btnrun.Text = obj_interface_language.btnRunAllocation;
            this.btnexit.Text = obj_interface_language.buttonJVTransactionExit;

            this.dgvsource.Columns[0].HeaderText = obj_interface_language.dgvAccountDefinitionColumn1;
            this.dgvsource.Columns[1].HeaderText = obj_interface_language.dgvAccountDefinitionColumn2;
            this.dgvsource.Columns[2].HeaderText = obj_interface_language.dgvAccountPercentage;
            this.dgvdestination.Columns[0].HeaderText = obj_interface_language.dgvAccountDefinitionColumn1;
            this.dgvdestination.Columns[1].HeaderText = obj_interface_language.dgvAccountDefinitionColumn2;
            this.dgvdestination.Columns[2].HeaderText = obj_interface_language.dgvAccountPercentage;
            this.dgvallocation.Columns["Code"].HeaderText = obj_interface_language.DGVCode;
            this.dgvallocation.Columns["Journal"].HeaderText = obj_interface_language.DGVJournal;
            this.dgvallocation.Columns["Description"].HeaderText = obj_interface_language.DGVDescription;

        }
        private void dgvallocation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvallocation.CurrentCell.Value.ToString() != "")
                {
                    DataRow [] arrs = dbAccountingProjectDS.GLAllocation.Select("AllocationCode = '" + dgvallocation.CurrentRow.Cells[0].Value.ToString() + "'");
                    if (arrs[0]["AllocationRepeat"].ToString() == "0")
                        lblrepeat.Text = "Repeat Same Pariod Off";
                    else if (arrs[0]["AllocationRepeat"].ToString() == "1")
                        lblrepeat.Text = "Repeat Same Pariod ON";
                    DataRow[] drc = dbAccountingProjectDS.Batch.Select("AllocationCode = '" + arrs[0]["AllocationCode"].ToString() + "'", "BatchDate");
                    if (drc.Length != 0)
                    {
                        lbllastran.Text = "Last Run in " + string.Format(GeneralFunctions.Format_Date, drc[drc.Length - 1]["BatchDate"]);
                    }
                    else
                        lbllastran.Text = "";
                    dtSourceAccounts.Clear();
                    for (int i = 0; i < arrs.Length; i++)
                    {
                        r = dtSourceAccounts.NewRow();
                        //r["AllocationCode"] = arrs[i]["AllocationCode"];
                        //r["AllocationGLJournalCode"] = arrs[i]["AllocationGLJournalCode"];
                        //r["AllocationDescription"] = arrs[i]["AllocationDescription"];
                        r["AllocationSourceAccount"] = arrs[i]["AllocationSourceAccount"];
                        r["AllocationSourceAccountName"] = arrs[i]["AllocationSourceAccountName"];
                        r["AllocationSourceAccountPercentage"] = arrs[i]["AllocationSourceAccountPercentage"];
                        dtSourceAccounts.Rows.Add(r);
                    }
                    dgvsource.Refresh();
                    DataRow[] arrd = dbAccountingProjectDS.GLAllocationDestinationAccounts.Select("AllocationCode = '" + dgvallocation.CurrentRow.Cells[0].Value.ToString() + "'");
                    dtDestinationAccounts.Clear();
                    for (int i = 0; i < arrd.Length; i++)
                    {
                        r = dtDestinationAccounts.NewRow();
                        //r["AllocationCode"] = arrd[i]["AllocationCode"];
                        r["DestinationGLAccountNumber"] = arrd[i]["DestinationGLAccountNumber"];
                        r["DestinationAccountDescription"] = arrd[i]["DestinationAccountDescription"];
                        r["DestinationAccountPercentage"] = arrd[i]["DestinationAccountPercentage"];
                        dtDestinationAccounts.Rows.Add(r);
                    } 
                    dgvdestination.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void btnrun_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = GeneralFunctions.CheckLockTables("GLTotals", "", "", "Edit");
                if (msg != "")
                {
                    MessageBox.Show("Can't Run Because GLTotals Edit By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                GeneralFunctions.LockTables("GLTotals", "Allocation Run", "", "Edit");
                if (checkvaluePercentage() == false && chkpost.Checked == true)
                {
                    MessageBox.Show("Can't Run Allocation In Status Posted Because Percentage Source Value = 0  ", "General Ledger");
                    return;
                }
                double value = 0;
                string prdbalance = "";
                string s = string.Format(GeneralFunctions.Format_Date, DateTime.Now);
                prdbalance = FindPeriod(s);
                currentJVNumber = GeneralFunctions.CreateJVNumberFormat(GeneralFunctions.lblJV, GeneralFunctions.JVNumberFormat, true);
                if (GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, DateTime.Now), out currentPeriodID, out periodName, out currentEndDate))
                { }
                else
                    MessageBox.Show("The period has been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dgvallocation.CurrentRow.Cells["Repeat"].Value.ToString() == "0")
                {
                    DataRow[] drc = dbAccountingProjectDS.Batch.Select("AllocationCode = '" + dgvallocation.CurrentRow.Cells["Code"].Value.ToString() + "' AND BatchPRD = '" + periodName + "'");
                    if (drc.Length != 0)
                    {
                        MessageBox.Show("Can't Run This Allocation In This Period Again", "General Ledger");
                        return;
                    }
                }
                SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlconBatch.Open();
                SqlCommand getBatch = new SqlCommand("Select Max(BatchNo)+1 From Batch", sqlconBatch);

                if (getBatch.ExecuteScalar() != DBNull.Value)
                {
                    NewNumber = Convert.ToInt32(getBatch.ExecuteScalar());
                }
                else
                {
                    NewNumber = 1;
                }
                sqlconBatch.Close();
                msg = "new";
                while (msg != "")
                {
                    msg = GeneralFunctions.CheckLockTables("Batch", "", NewNumber.ToString(), "New");
                    if (msg != "")
                    {
                        NewNumber = NewNumber + 1;
                    }
                }
                GeneralFunctions.LockTables("Batch", "Allocation Run", NewNumber.ToString(), "New");
                sqlconBatch.Open();
                SqlCommand cmdBatchSelect = new SqlCommand("Select BatchNo From Batch Where BatchNo=" + NewNumber + "", sqlconBatch);
                SqlDataReader drBatch = cmdBatchSelect.ExecuteReader();
                if (!drBatch.HasRows && !GeneralFunctions.FindRow("BatchNo=" + NewNumber + "", dbAccountingProjectDS.Batch))
                {
                    DataRow rBatch = this.dbAccountingProjectDS.Batch.NewRow();
                    rBatch["BatchNo"] = NewNumber;
                    rBatch["JVNumber"] = currentJVNumber;
                    rBatch["BatchDate"] = DateTime.Now.Date; //string.Format(GeneralFunctions.Format_Date, DTP_JVDate.Value.Date);
                    rBatch["BatchPRD"] = periodName;
                    rBatch["BatchDSC"] = dgvallocation.CurrentRow.Cells["Description"].Value.ToString();
                    rBatch["BatchSRC"] = "GL";
                    rBatch["BatchJNL"] = dgvallocation.CurrentRow.Cells["Journal"].Value.ToString();
                    if (chkpost.Checked == true)
                        rBatch["BatchStat"] = "P";
                    else if (chkpost.Checked == false)
                        rBatch["BatchStat"] = "U";
                    rBatch["PostDate"] = DateTime.Now.Date;
                    rBatch["UserID"] = AaDeclrationClass.xUserCode.ToString();
                    rBatch["REVBatch"] = 0;
                    rBatch["REVBatchNo"] = 0;
                    rBatch["REVBatchPRD"] = "";
                    rBatch["AllocationCode"] = dgvallocation.CurrentRow.Cells[0].Value.ToString();
                    rBatch["PropertyCode"] = "";
                    rBatch["Tran_Cashier"] = false;
                    dbAccountingProjectDS.Batch.Rows.Add(rBatch);
                    drBatch.Close();
                    sqlconBatch.Close();
                    SqlConnection sqlTransactions = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlTransactions.Open();
                    double totalsource = 0;
                    int sort = 1;
                    if (chkpost.Checked == true)
                    {
                        if (CheckBalanceAccType() != false)
                        {
                            AddAccountsForBS_PL(NewNumber, prdbalance);
                        }
                    }
                    for (int i = 0; i < dtSourceAccounts.Rows.Count; i++)
                    {
                        r = dtSourceAccounts.Rows[i];
                        if (r.Equals(dtSourceAccounts.Rows[dtSourceAccounts.Rows.Count - 1]) && r["AllocationSourceAccount"].ToString() == "" && r["AllocationSourceAccountName"].ToString() == "")
                            break;
                        if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified)
                        {
                            Valuesource = CurrentBalanceAccount(prdbalance, dtSourceAccounts.Rows[i]["AllocationSourceAccount"].ToString(), DateTime.Now.Date);
                            value = (Valuesource / 100) * (double)dtSourceAccounts.Rows[i]["AllocationSourceAccountPercentage"];
                            value = GeneralFunctions.ChangeDecimal(value, decmal);
                            value = -1 * value;
                            r = this.dbAccountingProjectDS.GLTransactions.NewRow();
                            SqlCommand commadTransactions = new SqlCommand("Select MAX(TransNO)+1 From GLTransactions", sqlTransactions);
                            if (commadTransactions.ExecuteScalar() != DBNull.Value)
                            {
                                r["TransNO"] = Convert.ToUInt32(commadTransactions.ExecuteScalar());
                            }
                            else
                            {
                                r["TransNO"] = 1;
                            }
                            r["BatchNo"] = NewNumber;
                            r["GLAccount"] = dtSourceAccounts.Rows[i]["AllocationSourceAccount"].ToString(); //txt_JVNumber.Text;
                            r["TRANSREF"] = "";
                            r["TRANSDATE"] = DateTime.Now.Date;
                            r["AmountLC"] = value;
                            r["Amount"] = 0;
                            r["TRANSUnit"] = 0;
                            r["CurrencyType"] = "";
                            r["Rate"] = "0";
                            r["ProjectCode"] = "";
                            r["SortNO"] = sort;
                            sort++;
                            
                            dbAccountingProjectDS.GLTransactions.Rows.Add(r);
                            if (chkpost.Checked == true)
                                ModifyTotals(prdbalance, dtSourceAccounts.Rows[i]["AllocationSourceAccount"].ToString(), value, DateTime.Now.Date);
                            updatetable();//adaptertbGLTotals.Update(dbAccountingProjectDS.GLTotals);
                            dbAccountingProjectDS.AcceptChanges();
                            value = -1 * value;
                            totalsource = totalsource + value;
                            Valuesource = 0;
                            value = 0;
                        }
                    }
                    for (int i = 0; i < dtDestinationAccounts.Rows.Count; i++)
                    {
                        r = dtDestinationAccounts.Rows[i];
                        if (r.Equals(dtDestinationAccounts.Rows[dtDestinationAccounts.Rows.Count - 1]) && r["DestinationGLAccountNumber"].ToString() == "" && r["DestinationAccountDescription"].ToString() == "")
                            break;
                        if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified)
                        {
                            value = (totalsource / 100) * double.Parse(dtDestinationAccounts.Rows[i]["DestinationAccountPercentage"].ToString());
                            value = GeneralFunctions.ChangeDecimal(value, decmal);
                            r = this.dbAccountingProjectDS.GLTransactions.NewRow();
                            SqlCommand commadTransactions = new SqlCommand("Select MAX(TransNO)+1 From GLTransactions", sqlTransactions);
                            if (commadTransactions.ExecuteScalar() != DBNull.Value)
                            {
                                r["TransNO"] = Convert.ToUInt32(commadTransactions.ExecuteScalar());
                            }
                            else
                            {
                                r["TransNO"] = 1;
                            }
                            r["BatchNo"] = NewNumber;
                            r["GLAccount"] = dtDestinationAccounts.Rows[i]["DestinationGLAccountNumber"].ToString(); //txt_JVNumber.Text;
                            r["TRANSREF"] = "";
                            r["TRANSDATE"] = DateTime.Now.Date;
                            r["AmountLC"] = value;
                            r["Amount"] = 0;
                            r["TRANSUnit"] = 0;
                            r["CurrencyType"] = "";
                            r["Rate"] = "0";
                            r["ProjectCode"] = "";
                            r["SortNO"] = sort;
                            sort++;
                            
                            dbAccountingProjectDS.GLTransactions.Rows.Add(r);
                            if (chkpost.Checked == true)
                                ModifyTotals(prdbalance, dtDestinationAccounts.Rows[i]["DestinationGLAccountNumber"].ToString(), value, DateTime.Now.Date);
                            updatetable();//adaptertbGLTotals.Update(dbAccountingProjectDS.GLTotals);
                            dbAccountingProjectDS.AcceptChanges();
                            value = 0;
                        }
                    }

                    totalsource = 0;
                    updatetable();
                    sqlTransactions.Close();
                    MessageBox.Show("JV Transaction Record inserted successfully");
                    lbllastran.Text = "Last Run in " + string.Format(GeneralFunctions.Format_Date, DateTime.Now.Date);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
            finally
            {
                GeneralFunctions.UnLockTable("", "Allocation Run", "", "New");
                GeneralFunctions.UnLockTable("", "Allocation Run", "", "Edit");
            }
        }
        private void AddAccountsForBS_PL(int batch, string prdbalance)
        {
            DataRow r;
            SqlConnection sqlTransactions = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlTransactions.Open();
            r = this.dbAccountingProjectDS.GLTransactions.NewRow();
            SqlCommand commadTransactions = new SqlCommand("Select MAX(TransNO)+1 From GLTransactions", sqlTransactions);
            if (commadTransactions.ExecuteScalar() != DBNull.Value)
            {
                r["TransNO"] = Convert.ToUInt32(commadTransactions.ExecuteScalar());
            }
            else
            {
                r["TransNO"] = 1;
            }
            r["BatchNo"] = batch;
            r["GLAccount"] = DefaultACCBalanceSheet; //txt_JVNumber.Text;
            r["TRANSREF"] = "BalanceSheet";
            r["TRANSDATE"] = DateTime.Now.ToShortDateString();
            r["TRANSUnit"] = 0;
            r["Amount"] = "0";
            r["AmountLC"] = -1 * ValBS;
            r["CurrencyType"] = "";
            r["Rate"] = "0";
            r["ProjectCode"] = "";
            r["SortNO"] = 0;
            
            dbAccountingProjectDS.GLTransactions.Rows.Add(r);
            ModifyTotals(prdbalance, DefaultACCBalanceSheet, (-1 * ValBS), DateTime.Now.Date);
            updatetable();
            r = this.dbAccountingProjectDS.GLTransactions.NewRow();
            commadTransactions = new SqlCommand("Select MAX(TransNO)+1 From GLTransactions", sqlTransactions);
            if (commadTransactions.ExecuteScalar() != DBNull.Value)
            {
                r["TransNO"] = Convert.ToUInt32(commadTransactions.ExecuteScalar());
            }
            else
            {
                r["TransNO"] = 1;
            }
            r["BatchNo"] = batch;
            r["GLAccount"] = DefaultACCIncomeStatment; //txt_JVNumber.Text;
            r["TRANSREF"] = "IncomeStatment";
            r["TRANSDATE"] = DateTime.Now.ToShortDateString();
            r["TRANSUnit"] = 0;
            r["Amount"] = "0";
            r["AmountLC"] = -1 * ValPT;
            r["CurrencyType"] = "";
            r["Rate"] = "0";
            r["ProjectCode"] = "";
            r["SortNO"] = 0;
            
            dbAccountingProjectDS.GLTransactions.Rows.Add(r);
            ModifyTotals(prdbalance, DefaultACCIncomeStatment, (-1 * ValPT), DateTime.Now.Date);
            updatetable();
            sqlTransactions.Close();
            //update();
        }
        private bool CheckBalanceAccType()
        {
            bool flage = false;
            int BS = 0;
            int PL = 0;
            DataRow[] rArr;
            ValBS = 0;
            ValPT = 0;
            double total = 0;
            double Valuesource = 0;
            double value = 0;
            DataRow r;
            string prdbalance = "";
            string s = string.Format(GeneralFunctions.Format_Date, DateTime.Now);
            prdbalance = FindPeriod(s);
            for (int i = 0; i < dtSourceAccounts.Rows.Count; i++)
            {
                r = dtSourceAccounts.Rows[i];
                if (r.Equals(dtSourceAccounts.Rows[dtSourceAccounts.Rows.Count - 1]) && r["AllocationSourceAccount"].ToString() == "" && r["AllocationSourceAccountName"].ToString() == "")
                    break;
                if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified)
                {
                    rArr = this.dbAccountingProjectDS.GLAccounts.Select("AccountNumber ='" + dtSourceAccounts.Rows[i]["AllocationSourceAccount"].ToString() + "'");
                    Valuesource = CurrentBalanceAccount(prdbalance, dtSourceAccounts.Rows[i]["AllocationSourceAccount"].ToString(), DateTime.Now.Date);
                    value = (Valuesource / 100) * (double)dtSourceAccounts.Rows[i]["AllocationSourceAccountPercentage"];
                    value = GeneralFunctions.ChangeDecimal(value, decmal);
                    string sdf = string.Format("{*,**}", value);
                    if (rArr[0]["AccountTypeName"].ToString() == "Assets" || rArr[0]["AccountTypeName"].ToString() == "Liability" || rArr[0]["AccountTypeName"].ToString() == "Equity")
                    {
                        BS++;
                            ValBS = ValBS - value;
                    }
                    else if (rArr[0]["AccountTypeName"].ToString() == "Revenue" || rArr[0]["AccountTypeName"].ToString() == "Expenses")
                    {
                        PL++;
                            ValPT = ValPT - value;
                    }
                    total = total + value;
                }
            }
            for (int i = 0; i < dtDestinationAccounts.Rows.Count; i++)
            {
                value = 0;
                r = dtDestinationAccounts.Rows[i];
                if (r.Equals(dtDestinationAccounts.Rows[dtDestinationAccounts.Rows.Count - 1]) && r["DestinationGLAccountNumber"].ToString() == "" && r["DestinationAccountDescription"].ToString() == "")
                    break;
                if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified)
                {
                    rArr = this.dbAccountingProjectDS.GLAccounts.Select("AccountNumber ='" + dtDestinationAccounts.Rows[i]["DestinationGLAccountNumber"].ToString() + "'");
                    value = (total / 100) * double.Parse(dtDestinationAccounts.Rows[i]["DestinationAccountPercentage"].ToString());
                    value = GeneralFunctions.ChangeDecimal(value, decmal);
                    if (rArr[0]["AccountTypeName"].ToString() == "Assets" || rArr[0]["AccountTypeName"].ToString() == "Liability" || rArr[0]["AccountTypeName"].ToString() == "Equity")
                    {
                        BS++;
                        ValBS = ValBS + value;
                    }
                    else if (rArr[0]["AccountTypeName"].ToString() == "Revenue" || rArr[0]["AccountTypeName"].ToString() == "Expenses")
                    {
                        PL++;
                        ValPT = ValPT + value;
                    }
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
        private bool  checkvaluePercentage()
        {
            bool boolchack = true;
            double total = 0;
            DataRow[] rArr;
            string prdbalance = "";
            for (int i = 0; i < dtSourceAccounts.Rows.Count; i++)
            {
                r = dtSourceAccounts.Rows[i];
                if (r.Equals(dtSourceAccounts.Rows[dtSourceAccounts.Rows.Count - 1]) && r["AllocationSourceAccount"].ToString() == "" && r["AllocationSourceAccountName"].ToString() == "")
                    break;
                if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified)
                {
                    string s = string.Format(GeneralFunctions.Format_Date, DateTime.Now);
                    prdbalance = FindPeriod(s);
                    rArr = this.dbAccountingProjectDS.GLTotals.Select("AccountNumber ='" + dtSourceAccounts.Rows[i]["AllocationSourceAccount"].ToString() + "' AND FiscalYear = '" + DateTime.Now.Year + "'");
                    total = total + double.Parse(rArr[0][prdbalance].ToString());
                }
            }
            if (total == 0)
                boolchack = false;
            return boolchack;
        }
        private void updatetable()
        {
            cmdBuilderBatch.DataAdapter = adaptertbBatch;
            adaptertbBatch.Update(dbAccountingProjectDS.Batch); 
            cmdBuildertbJVTransaction.DataAdapter = adaptertbGLJVTransaction;
            adaptertbGLJVTransaction.Update(dbAccountingProjectDS.GLTransactions);
            cmdBuilderGLTotals.DataAdapter = adaptertbGLTotals;
            adaptertbGLTotals.Update(dbAccountingProjectDS.GLTotals);
            dbAccountingProjectDS.AcceptChanges();

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
            cmdBuilderGLTotals.DataAdapter = adaptertbGLTotals;
            adaptertbGLTotals.Update(dbAccountingProjectDS.GLTotals);
            double CurrentBalance = 0;
            DataRow[] rArr = this.dbAccountingProjectDS.GLTotals.Select("AccountNumber ='" + ApAccount + "' AND FiscalYear = '" + prd.Year + "'");
            if (rArr.Length != 0)
            {
                CurrentBalance = double.Parse(rArr[0][prdbalance].ToString());
                rArr[0][prdbalance] = EditPeriodNumber(CurrentBalance, val);
            }
        }
        private double CurrentBalanceAccount(string prdbalance, string ApAccount, DateTime prd)
        {
            double CurrentBalance = 0;
            DataRow[] rArr = this.dbAccountingProjectDS.GLTotals.Select("AccountNumber ='" + ApAccount + "' AND FiscalYear = '" + prd.Year + "'");
            if (rArr.Length != 0)
            {
                CurrentBalance = double.Parse(rArr[0][prdbalance].ToString());
            }
            return CurrentBalance;
        }
        private double EditPeriodNumber(double periodBalance, double value)
        {
            double balance = 0;
            balance = periodBalance + value;
            return balance;
        }

        private void Allocation_Run_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralFunctions.UnLockTable("", "Allocation Run", "", "");
        }

    }
}