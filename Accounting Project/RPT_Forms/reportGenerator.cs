using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
namespace Accounting_GeneralLedger
{
    public partial class reportGenerator : Form
    {
        public reportGenerator()
        {
            InitializeComponent();
        }
        private SqlConnection sqlconn;
        private SqlDataAdapter sqladap;
        private SqlCommandBuilder sqlcommbuild;
        private dbAccountingProjectDS dbAccountingProjectDS;
        public static string fiscalYearSetup = "";
        public static string fiscalPeriodSetup = "";
        public static string PostedUNPostedStatus = "";
        public static string StartedAccount = "";
        public static string EndedAccount = "";
        public static string ReportType = "";
        public static string PeriodFrom = "";
        public static string PeriodTo0 = "";
        public static string AccountNumberNow = "";
        public static string AccountNameNow = "";
        string AccType = "";

        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;


        private void reportGenerator_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconnect1 = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand sqlcommand1 = new SqlCommand("Select Distinct YEAR(PeriodStartDate) From GLFiscalPeriod", sqlconnect1);
            sqlconnect1.Open();
            SqlDataReader sqlread1 = sqlcommand1.ExecuteReader();
            cbFiscalPeriod.Items.Clear();
            if (sqlread1.HasRows)
            {
                while (sqlread1.Read())
                {
                    cbFiscalYear.Items.Add(sqlread1.GetInt32(0).ToString());
                }
            }
            if (GeneralFunctions.languagechioce != "")
            {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }

        }

        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.formReportGenerator;
            this.lblFiscalPeriod.Text = obj_interface_language.lblReportGeneratorFiscalPeriod;
            this.lblFiscalYear.Text = obj_interface_language.lblReportGeneratorFiscalYear;
            this.groupBox1.Text = obj_interface_language.groupBoxReportType;
            this.rb1.Text = obj_interface_language.radioButtonrb1;
            this.rbTrialBalance.Text = obj_interface_language.radioButtonrb2;
            this.btnReport.Text = obj_interface_language.btnReport;
        }

        private void cbFiscalPeriod_DropDown(object sender, System.EventArgs e)
        {
            if (cbFiscalYear.Text != "")
            {
                if (rbIncomeMenu.Checked == true || rbMoneyState.Checked == true)
                {
                    sqlconn = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqladap = new SqlDataAdapter("Select * From GLFiscalPeriod WHERE YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND Status='CLOSED'", sqlconn);
                    sqlcommbuild = new SqlCommandBuilder(sqladap);
                    dbAccountingProjectDS = new dbAccountingProjectDS();
                    sqladap.Fill(dbAccountingProjectDS.GLFiscalPeriod);
                    cbFiscalPeriod.Items.Clear();
                    foreach (DataRow dr in dbAccountingProjectDS.GLFiscalPeriod.Rows)
                    {
                        cbFiscalPeriod.Items.Add(dr["PeriodDescription"].ToString());
                    }
                }
                else
                {
                    sqlconn = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqladap = new SqlDataAdapter("Select * From GLFiscalPeriod WHERE YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlconn);
                    sqlcommbuild = new SqlCommandBuilder(sqladap);
                    dbAccountingProjectDS = new dbAccountingProjectDS();
                    sqladap.Fill(dbAccountingProjectDS.GLFiscalPeriod);
                    cbFiscalPeriod.Items.Clear();
                    foreach (DataRow dr in dbAccountingProjectDS.GLFiscalPeriod.Rows)
                    {
                        cbFiscalPeriod.Items.Add(dr["PeriodDescription"].ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose fiscal year first", "General Ledger");
                return;
            }
        }

        private void cbFiscalPeriod2_DropDown(object sender, System.EventArgs e)
        {
            if (cbFiscalYear.Text != "")
            {
                if (cbFiscalPeriod.Text != "")
                {
                    if (rbIncomeMenu.Checked == true || rbMoneyState.Checked == true)
                    {
                        sqlconn = new SqlConnection(GeneralFunctions.ConnectionString);
                        sqladap = new SqlDataAdapter("Select * From GLFiscalPeriod WHERE YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND Status='CLOSED'", sqlconn);
                        sqlcommbuild = new SqlCommandBuilder(sqladap);
                        dbAccountingProjectDS = new dbAccountingProjectDS();
                        sqladap.Fill(dbAccountingProjectDS.GLFiscalPeriod);
                        cbFiscalPeriod2.Items.Clear();
                        foreach (DataRow dr in dbAccountingProjectDS.GLFiscalPeriod.Rows)
                        {
                            cbFiscalPeriod2.Items.Add(dr["PeriodDescription"].ToString());
                        }
                    }
                    else
                    {

                        sqlconn = new SqlConnection(GeneralFunctions.ConnectionString);
                        sqladap = new SqlDataAdapter("Select * From GLFiscalPeriod WHERE YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlconn);
                        sqlcommbuild = new SqlCommandBuilder(sqladap);
                        dbAccountingProjectDS = new dbAccountingProjectDS();
                        sqladap.Fill(dbAccountingProjectDS.GLFiscalPeriod);
                        cbFiscalPeriod2.Items.Clear();
                        foreach (DataRow dr in dbAccountingProjectDS.GLFiscalPeriod.Rows)
                        {
                            cbFiscalPeriod2.Items.Add(dr["PeriodDescription"].ToString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please choose fiscal period one first", "General Ledger");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please choose fiscal year first");
                return;
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (rb1.Checked == false && rb2.Checked == false && rbTrialBalance.Checked == false && rbRevision.Checked == false && rbMoneyState.Checked == false && rbIncomeMenu.Checked == false && rbAnalysis.Checked == false)
            {
                MessageBox.Show("Choose type of report", "General Ledger");
                return;
            }
            if (rb1.Checked == true)
            {
                if (cbFiscalYear.Text == "")
                {
                    MessageBox.Show("Make sure that you choose specific fiscal year", "General Ledger");
                    return;
                }
                if (cbFiscalPeriod.Text == "")
                {
                    MessageBox.Show("Make sure that you choose fiscal period from", "General Ledger");
                    return;
                }
                if (rbPosted.Checked == false && rbUnPosted.Checked == false)
                {
                    MessageBox.Show("Choose Type Posted Or UnPosted", "General Ledger");
                    return;
                }
                //if (cbFiscalPeriod2.Text == "")
                //{
                //    MessageBox.Show("Make sure that you choose fiscal period to");
                //    return;
                //}

                SqlConnection connectReport = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand commandReport = new SqlCommand();
                SqlDataReader readerReport;


                connectReport.Open();

                commandReport = new SqlCommand();
                commandReport.Connection = connectReport;
                commandReport.CommandType = CommandType.Text;


                commandReport.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BatchReport]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View BatchReport";
                readerReport = commandReport.ExecuteReader();
                readerReport.Close();


                string s = "";

                SqlConnection sqlConnectToGetPeriod = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand sqlCommandToGetPeriod = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='" + cbFiscalPeriod.Text + "' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlConnectToGetPeriod);
                sqlConnectToGetPeriod.Open();
                SqlDataReader sqlReadStartEnd = sqlCommandToGetPeriod.ExecuteReader();
                if (sqlReadStartEnd.HasRows)
                {
                    while (sqlReadStartEnd.Read())
                    {
                        if (rbPosted.Checked == true)
                        {
                            MessageBox.Show(string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd.GetDateTime(4))));
                            //s = "CREATE VIEW TrialBalanceSummary AS Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                            //    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                            //    "WHERE GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd.GetDateTime(4))) + "' AND GLF.PeriodDescription='" + cbFiscalPeriod.Text + "' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                            //    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate ";
                            s = "CREATE VIEW BatchReport AS Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit' ,B.JVNumber " +
                                "FROM GLAccounts GLA,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                "WHERE GLA.AccountNumber=GLTR.GLAccount AND GLTR.BatchNo=B.BatchNo AND GLTR.TRANSDATE Between '" + Convert.ToDateTime(sqlReadStartEnd.GetDateTime(3)).ToString(GeneralFunctions.Format_Date) + "' AND '" + Convert.ToDateTime(sqlReadStartEnd.GetDateTime(4)).ToString(GeneralFunctions.Format_Date) + "' AND GLF.PeriodDescription='" + cbFiscalPeriod.Text + "' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLF.PeriodStartDate,GLF.PeriodEndDate,B.JVNumber  ";
                        }
                        else
                        {
                            MessageBox.Show(string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd.GetDateTime(4))));
                            s = "CREATE VIEW BatchReport AS Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit' ,B.JVNumber " +
                                "FROM GLAccounts GLA,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                "WHERE GLA.AccountNumber=GLTR.GLAccount AND GLTR.BatchNo=B.BatchNo AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd.GetDateTime(4))) + "' AND GLF.PeriodDescription='" + cbFiscalPeriod.Text + "' AND B.BatchStat='U' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLF.PeriodStartDate,GLF.PeriodEndDate,B.JVNumber  ";

                        }
                    }
                }
                commandReport.CommandText = s;
                readerReport = commandReport.ExecuteReader();
                readerReport.Close();
                reportGenerator.fiscalYearSetup = cbFiscalYear.Text;
                reportGenerator.fiscalPeriodSetup = cbFiscalPeriod.Text;
                if (rbPosted.Checked == true)
                    reportGenerator.PostedUNPostedStatus = " ﬁ—Ì— «·ﬁÌÊœ «·„—Õ·…";
                else
                    reportGenerator.PostedUNPostedStatus = " ﬁ—Ì— «·ﬁÌÊœ €Ì— «·„—Õ·…";
                reportGenerator.ReportType = "Batch Report";
                rptSummaryTrailBalance rsum = new rptSummaryTrailBalance();
                rsum.ShowDialog();
            }
            else if (rbTrialBalance.Checked == true)
            {
                SqlConnection sqlconn2 = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlconn2.Open();
                SqlCommand sqlcom2 = new SqlCommand("Select AccountNumberFormat,FirstSub,SecondSub,ThirdSub,FourthSub from GeneralSetup", sqlconn2);
                SqlDataReader sqlread2 = sqlcom2.ExecuteReader();
                sqlread2.Read();
                int MaxAccountDigits = sqlread2.GetString(0).Length;
                int FirstSub = sqlread2.GetInt32(1);
                int SecondSub = sqlread2.GetInt32(2);
                int ThirdSub = sqlread2.GetInt32(3);
                int ForthSub = sqlread2.GetInt32(4);
                if (cbFiscalYear.Text == "")
                {
                    MessageBox.Show("Make sure that you choose specific fiscal year", "General Ledger");
                    return;
                }
                if (cbFiscalPeriod.Text == "")
                {
                    MessageBox.Show("Make sure that you choose fiscal period from", "General Ledger");
                    return;
                }
                if (cbFiscalPeriod2.Text == "")
                {
                    MessageBox.Show("Make sure that you choose fiscal period to", "General Ledger");
                    return;
                }
                if (txtFromAccount.Text == "")
                {
                    MessageBox.Show("Make sure that account number from insert first", "General Ledger");
                    return;
                }
                if (txtFromAccount.Text.Length != MaxAccountDigits)
                {
                    MessageBox.Show("Insert valid Account Number From", "General Ledger");
                    return;
                }
                if (txtToAccount.Text == "")
                {
                    MessageBox.Show("Make sure that account number to insert first", "General Ledger");
                    return;
                }
                if (txtToAccount.Text.Length != MaxAccountDigits)
                {
                    MessageBox.Show("Insert valid Account Number To", "General Ledger");
                    return;
                }
                string[] AccountNumbersData = new string[1000000];
                SqlConnection SQLconnAccounts = new SqlConnection(GeneralFunctions.ConnectionString);
                SQLconnAccounts.Open();
                SqlCommand sqlCommandAccounts = new SqlCommand("Select * FROM GLAccounts", SQLconnAccounts);
                SqlDataReader sqlreadAccounts = sqlCommandAccounts.ExecuteReader();
                int i = 0;
                if (sqlreadAccounts.HasRows)
                {
                    while (sqlreadAccounts.Read())
                    {
                        AccountNumbersData[i] = sqlreadAccounts.GetString(0);
                        ++i;
                    }
                }

                string[] TempAccounts;
                string tempAccountNumber = "";
                ArrayList array = new ArrayList();

                int[] tempAccountNumbersInteger = new int[1000000];
                for (int j = 0; j < i; j++)
                {
                    tempAccountNumber = "";
                    TempAccounts = AccountNumbersData[j].Split('-');
                    for (int k = 0; k < TempAccounts.Length; k++)
                    {
                        tempAccountNumber = tempAccountNumber + TempAccounts[k];
                    }
                    tempAccountNumbersInteger[j] = Convert.ToInt32(tempAccountNumber);
                }

                string[] tempTextFrom;
                string[] tempTextTo;
                string tempTextFrom2 = "";
                string tempTextTo2 = "";
                tempTextFrom = txtFromAccount.Text.Split('-');
                tempTextTo = txtToAccount.Text.Split('-');

                for (int g = 0; g < tempTextFrom.Length; g++)
                {
                    tempTextFrom2 = tempTextFrom2 + tempTextFrom[g];
                }

                for (int r = 0; r < tempTextTo.Length; r++)
                {
                    tempTextTo2 = tempTextTo2 + tempTextTo[r];
                }
                int from = 0;
                int to = 0;
                for (int z = 0; z < i; z++)
                {
                    if (Convert.ToInt32(tempTextFrom2) == tempAccountNumbersInteger[z])
                    {
                        from = z;

                    }
                }

                for (int z2 = 0; z2 < i; z2++)
                {
                    if (Convert.ToInt32(tempTextTo2) == tempAccountNumbersInteger[z2])
                    {
                        to = z2;

                    }
                }
                //Stop Here
                string[] ListValues = new string[1000000];
                int d = 0;
                for (int w = from; w <= to; w++)
                {
                    ListValues[d] = Convert.ToString(tempAccountNumbersInteger[w]);
                    ++d;
                }

                string ConditionValue = "'";
                string p1 = "", p2 = "", p3 = "";
                string collectAccount = "";
                if (ForthSub == 0)
                {

                    for (int r = 0; r < d; r++)
                    {
                        p1 = "";
                        p2 = "";
                        p3 = "";
                        collectAccount = "";
                        p1 = ListValues[r].Substring(0, FirstSub);
                        p2 = ListValues[r].Substring(FirstSub, SecondSub);
                        p3 = ListValues[r].Substring(FirstSub + SecondSub, ThirdSub);
                        collectAccount = p1 + "-" + p2 + "-" + p3;
                        if (r == d - 1)
                            ConditionValue = ConditionValue + collectAccount + "'";
                        else
                            ConditionValue = ConditionValue + collectAccount + "','";
                    }
                }
                SqlConnection connectReport2 = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand commandReport2 = new SqlCommand();
                SqlDataReader readerReport2;


                connectReport2.Open();

                commandReport2 = new SqlCommand();
                commandReport2.Connection = connectReport2;
                commandReport2.CommandType = CommandType.Text;


                commandReport2.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TrialBalanceSummary]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TrialBalanceSummary";
                readerReport2 = commandReport2.ExecuteReader();
                readerReport2.Close();
                commandReport2.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TrialBalanceSummaryData]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TrialBalanceSummaryData";
                readerReport2 = commandReport2.ExecuteReader();
                readerReport2.Close();

                string s2 = "";

                if (cbFiscalPeriod.Text == cbFiscalPeriod2.Text)
                {
                    SqlConnection sqlConnectToGetPeriod2 = new SqlConnection(GeneralFunctions.ConnectionString);
                    SqlCommand sqlCommandToGetPeriod2 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='" + cbFiscalPeriod.Text + "' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlConnectToGetPeriod2);
                    sqlConnectToGetPeriod2.Open();
                    SqlDataReader sqlReadStartEnd2 = sqlCommandToGetPeriod2.ExecuteReader();
                    if (sqlReadStartEnd2.HasRows)
                    {
                        while (sqlReadStartEnd2.Read())
                        {
                            MessageBox.Show(string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(4))));
                            s2 = "CREATE VIEW TrialBalanceSummary AS Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(4))) + "' AND GLF.PeriodDescription='" + cbFiscalPeriod.Text + "' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate ";
                        }
                    }
                    commandReport2.CommandText = s2;
                    readerReport2 = commandReport2.ExecuteReader();
                    readerReport2.Close();
                    reportGenerator.fiscalYearSetup = cbFiscalYear.Text;
                    reportGenerator.fiscalPeriodSetup = cbFiscalPeriod.Text;
                    reportGenerator.PostedUNPostedStatus = " ﬁ—Ì— «·—’Ìœ «· Ã—Ì»Ì";
                    reportGenerator.StartedAccount = tempTextFrom2;
                    reportGenerator.EndedAccount = tempTextTo2;
                    reportGenerator.ReportType = "Trial Balance";
                    rptSummaryTrailBalance rsum = new rptSummaryTrailBalance();
                    rsum.ShowDialog();
                }
                else if (cbFiscalPeriod.Text != cbFiscalPeriod2.Text)
                {

                    SqlConnection sqlConnectToGetPeriod2 = new SqlConnection(GeneralFunctions.ConnectionString);
                    SqlConnection sqlConnectToGetPeriod3 = new SqlConnection(GeneralFunctions.ConnectionString);
                    SqlCommand sqlCommandToGetPeriod2 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='" + cbFiscalPeriod.Text + "' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlConnectToGetPeriod2);
                    SqlCommand sqlCommandToGetPeriod3 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='" + cbFiscalPeriod2.Text + "' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlConnectToGetPeriod3);
                    sqlConnectToGetPeriod2.Open();
                    sqlConnectToGetPeriod3.Open();
                    SqlDataReader sqlReadStartEnd2 = sqlCommandToGetPeriod2.ExecuteReader();
                    SqlDataReader sqlReadStartEnd3 = sqlCommandToGetPeriod3.ExecuteReader();
                    int PeriodFrom = 0;
                    int PeriodTo = 0;
                    if (sqlReadStartEnd2.HasRows)
                    {
                        if (sqlReadStartEnd3.HasRows)
                        {
                            sqlReadStartEnd2.Read();
                            sqlReadStartEnd3.Read();
                            PeriodFrom = sqlReadStartEnd2.GetInt32(2);
                            PeriodTo = sqlReadStartEnd3.GetInt32(2);
                            if (PeriodFrom > PeriodTo)
                            {
                                MessageBox.Show("You must put small period first", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                            else if (PeriodFrom == 1 && PeriodTo == 2)
                            {
                                s2 = "CREATE VIEW TrialBalanceSummaryData AS Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 1' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 2' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate ";
                            }
                            else if (PeriodFrom == 1 && PeriodTo == 3)
                            {
                                SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlCommand sqlcom3 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 2' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon3);
                                sqlcon3.Open();
                                SqlDataReader sqlread3 = sqlcom3.ExecuteReader();
                                sqlread3.Read();
                                s2 = "CREATE VIEW TrialBalanceSummaryData AS Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 1' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 2' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 3' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate ";
                            }
                            else if (PeriodFrom == 1 && PeriodTo == 4)
                            {
                                SqlConnection sqlcon4 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon5 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlCommand sqlcom4 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 2' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon4);
                                SqlCommand sqlcom5 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 3' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon5);
                                sqlcon4.Open();
                                sqlcon5.Open();
                                SqlDataReader sqlread4 = sqlcom4.ExecuteReader();
                                SqlDataReader sqlread5 = sqlcom5.ExecuteReader();
                                sqlread4.Read();
                                sqlread5.Read();
                                s2 = "CREATE VIEW TrialBalanceSummaryData AS Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 1' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread4.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread4.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 2' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread5.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread5.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 3' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 4' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate ";

                            }
                            else if (PeriodFrom == 1 && PeriodTo == 5)
                            {
                                SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon4 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlCommand sqlcomm2 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 2' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon2);
                                SqlCommand sqlcom3 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 3' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon3);
                                SqlCommand sqlcomm4 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 4' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon4);
                                sqlcon2.Open();
                                sqlcon3.Open();
                                sqlcon4.Open();
                                SqlDataReader sqlread22 = sqlcomm2.ExecuteReader();
                                SqlDataReader sqlread3 = sqlcom3.ExecuteReader();
                                SqlDataReader sqlread4 = sqlcomm4.ExecuteReader();
                                sqlread22.Read();
                                sqlread3.Read();
                                sqlread4.Read();
                                s2 = "CREATE VIEW TrialBalanceSummaryData AS Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 1' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread22.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread22.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 2' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 3' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread4.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread4.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 4' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 5' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate ";
                            }
                            else if (PeriodFrom == 1 && PeriodTo == 6)
                            {
                                SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon4 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon5 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlCommand sqlcomm2 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 2' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon2);
                                SqlCommand sqlcom3 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 3' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon3);
                                SqlCommand sqlcomm4 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 4' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon4);
                                SqlCommand sqlcomm5 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 5' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon5);
                                sqlcon2.Open();
                                sqlcon3.Open();
                                sqlcon4.Open();
                                sqlcon5.Open();
                                SqlDataReader sqlread22 = sqlcomm2.ExecuteReader();
                                SqlDataReader sqlread3 = sqlcom3.ExecuteReader();
                                SqlDataReader sqlread4 = sqlcomm4.ExecuteReader();
                                SqlDataReader sqlread5 = sqlcomm5.ExecuteReader();
                                sqlread22.Read();
                                sqlread3.Read();
                                sqlread4.Read();
                                sqlread5.Read();
                                s2 = "CREATE VIEW TrialBalanceSummaryData AS Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 1' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread22.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread22.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 2' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 3' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread4.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread4.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 4' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread5.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread5.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 5' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 6' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate ";
                            }
                            else if (PeriodFrom == 1 && PeriodTo == 7)
                            {
                                SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon4 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon5 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon6 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlCommand sqlcomm2 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 2' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon2);
                                SqlCommand sqlcom3 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 3' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon3);
                                SqlCommand sqlcomm4 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 4' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon4);
                                SqlCommand sqlcomm5 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 5' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon5);
                                SqlCommand sqlcomm6 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 6' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon6);
                                sqlcon2.Open();
                                sqlcon3.Open();
                                sqlcon4.Open();
                                sqlcon5.Open();
                                sqlcon6.Open();
                                SqlDataReader sqlread22 = sqlcomm2.ExecuteReader();
                                SqlDataReader sqlread3 = sqlcom3.ExecuteReader();
                                SqlDataReader sqlread4 = sqlcomm4.ExecuteReader();
                                SqlDataReader sqlread5 = sqlcomm5.ExecuteReader();
                                SqlDataReader sqlread6 = sqlcomm6.ExecuteReader();
                                sqlread22.Read();
                                sqlread3.Read();
                                sqlread4.Read();
                                sqlread5.Read();
                                sqlread6.Read();
                                s2 = "CREATE VIEW TrialBalanceSummaryData AS Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 1' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread22.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread22.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 2' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 3' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread4.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread4.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 4' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread5.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread5.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 5' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread6.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread6.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 6' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 7' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate ";
                            }
                            else if (PeriodFrom == 1 && PeriodTo == 8)
                            {
                                SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon4 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon5 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon6 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon7 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlCommand sqlcomm2 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 2' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon2);
                                SqlCommand sqlcom3 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 3' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon3);
                                SqlCommand sqlcomm4 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 4' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon4);
                                SqlCommand sqlcomm5 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 5' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon5);
                                SqlCommand sqlcomm6 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 6' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon6);
                                SqlCommand sqlcomm7 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 7' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon7);
                                sqlcon2.Open();
                                sqlcon3.Open();
                                sqlcon4.Open();
                                sqlcon5.Open();
                                sqlcon6.Open();
                                sqlcon7.Open();
                                SqlDataReader sqlread22 = sqlcomm2.ExecuteReader();
                                SqlDataReader sqlread3 = sqlcom3.ExecuteReader();
                                SqlDataReader sqlread4 = sqlcomm4.ExecuteReader();
                                SqlDataReader sqlread5 = sqlcomm5.ExecuteReader();
                                SqlDataReader sqlread6 = sqlcomm6.ExecuteReader();
                                SqlDataReader sqlread7 = sqlcomm7.ExecuteReader();
                                sqlread22.Read();
                                sqlread3.Read();
                                sqlread4.Read();
                                sqlread5.Read();
                                sqlread6.Read();
                                sqlread7.Read();
                                s2 = "CREATE VIEW TrialBalanceSummaryData AS Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 1' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread22.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread22.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 2' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 3' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread4.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread4.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 4' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread5.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread5.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 5' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread6.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread6.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 6' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread7.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread7.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 7' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 8' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate ";
                            }
                            else if (PeriodFrom == 1 && PeriodTo == 9)
                            {
                                SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon4 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon5 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon6 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon7 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon8 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlCommand sqlcomm2 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 2' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon2);
                                SqlCommand sqlcom3 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 3' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon3);
                                SqlCommand sqlcomm4 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 4' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon4);
                                SqlCommand sqlcomm5 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 5' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon5);
                                SqlCommand sqlcomm6 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 6' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon6);
                                SqlCommand sqlcomm7 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 7' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon7);
                                SqlCommand sqlcomm8 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 8' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon8);
                                sqlcon2.Open();
                                sqlcon3.Open();
                                sqlcon4.Open();
                                sqlcon5.Open();
                                sqlcon6.Open();
                                sqlcon7.Open();
                                sqlcon8.Open();
                                SqlDataReader sqlread22 = sqlcomm2.ExecuteReader();
                                SqlDataReader sqlread3 = sqlcom3.ExecuteReader();
                                SqlDataReader sqlread4 = sqlcomm4.ExecuteReader();
                                SqlDataReader sqlread5 = sqlcomm5.ExecuteReader();
                                SqlDataReader sqlread6 = sqlcomm6.ExecuteReader();
                                SqlDataReader sqlread7 = sqlcomm7.ExecuteReader();
                                SqlDataReader sqlread8 = sqlcomm8.ExecuteReader();
                                sqlread22.Read();
                                sqlread3.Read();
                                sqlread4.Read();
                                sqlread5.Read();
                                sqlread6.Read();
                                sqlread7.Read();
                                sqlread8.Read();
                                s2 = "CREATE VIEW TrialBalanceSummaryData AS Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 1' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread22.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread22.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 2' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 3' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread4.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread4.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 4' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread5.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread5.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 5' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread6.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread6.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 6' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread7.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread7.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 7' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread8.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread8.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 8' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 9' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate ";
                            }
                            else if (PeriodFrom == 1 && PeriodTo == 10)
                            {
                                SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon4 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon5 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon6 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon7 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon8 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon9 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlCommand sqlcomm2 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 2' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon2);
                                SqlCommand sqlcom3 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 3' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon3);
                                SqlCommand sqlcomm4 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 4' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon4);
                                SqlCommand sqlcomm5 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 5' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon5);
                                SqlCommand sqlcomm6 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 6' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon6);
                                SqlCommand sqlcomm7 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 7' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon7);
                                SqlCommand sqlcomm8 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 8' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon8);
                                SqlCommand sqlcomm9 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 9' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon9);
                                sqlcon2.Open();
                                sqlcon3.Open();
                                sqlcon4.Open();
                                sqlcon5.Open();
                                sqlcon6.Open();
                                sqlcon7.Open();
                                sqlcon8.Open();
                                sqlcon9.Open();
                                SqlDataReader sqlread22 = sqlcomm2.ExecuteReader();
                                SqlDataReader sqlread3 = sqlcom3.ExecuteReader();
                                SqlDataReader sqlread4 = sqlcomm4.ExecuteReader();
                                SqlDataReader sqlread5 = sqlcomm5.ExecuteReader();
                                SqlDataReader sqlread6 = sqlcomm6.ExecuteReader();
                                SqlDataReader sqlread7 = sqlcomm7.ExecuteReader();
                                SqlDataReader sqlread8 = sqlcomm8.ExecuteReader();
                                SqlDataReader sqlread9 = sqlcomm9.ExecuteReader();
                                sqlread22.Read();
                                sqlread3.Read();
                                sqlread4.Read();
                                sqlread5.Read();
                                sqlread6.Read();
                                sqlread7.Read();
                                sqlread8.Read();
                                sqlread9.Read();
                                s2 = "CREATE VIEW TrialBalanceSummaryData AS Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 1' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread22.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread22.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 2' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 3' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread4.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread4.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 4' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread5.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread5.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 5' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread6.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread6.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 6' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread7.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread7.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 7' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread8.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread8.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 8' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread9.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread9.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 9' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 10' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate ";
                            }
                            else if (PeriodFrom == 1 && PeriodTo == 11)
                            {
                                SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon4 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon5 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon6 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon7 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon8 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon9 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon10 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlCommand sqlcomm2 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 2' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon2);
                                SqlCommand sqlcom3 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 3' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon3);
                                SqlCommand sqlcomm4 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 4' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon4);
                                SqlCommand sqlcomm5 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 5' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon5);
                                SqlCommand sqlcomm6 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 6' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon6);
                                SqlCommand sqlcomm7 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 7' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon7);
                                SqlCommand sqlcomm8 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 8' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon8);
                                SqlCommand sqlcomm9 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 9' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon9);
                                SqlCommand sqlcomm10 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 10' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon10);
                                sqlcon2.Open();
                                sqlcon3.Open();
                                sqlcon4.Open();
                                sqlcon5.Open();
                                sqlcon6.Open();
                                sqlcon7.Open();
                                sqlcon8.Open();
                                sqlcon9.Open();
                                sqlcon10.Open();
                                SqlDataReader sqlread22 = sqlcomm2.ExecuteReader();
                                SqlDataReader sqlread3 = sqlcom3.ExecuteReader();
                                SqlDataReader sqlread4 = sqlcomm4.ExecuteReader();
                                SqlDataReader sqlread5 = sqlcomm5.ExecuteReader();
                                SqlDataReader sqlread6 = sqlcomm6.ExecuteReader();
                                SqlDataReader sqlread7 = sqlcomm7.ExecuteReader();
                                SqlDataReader sqlread8 = sqlcomm8.ExecuteReader();
                                SqlDataReader sqlread9 = sqlcomm9.ExecuteReader();
                                SqlDataReader sqlread10 = sqlcomm10.ExecuteReader();
                                sqlread22.Read();
                                sqlread3.Read();
                                sqlread4.Read();
                                sqlread5.Read();
                                sqlread6.Read();
                                sqlread7.Read();
                                sqlread8.Read();
                                sqlread9.Read();
                                sqlread10.Read();
                                s2 = "CREATE VIEW TrialBalanceSummaryData AS Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 1' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread22.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread22.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 2' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 3' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread4.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread4.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 4' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread5.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread5.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 5' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread6.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread6.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 6' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread7.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread7.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 7' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread8.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread8.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 8' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread9.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread9.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 9' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread10.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread10.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 10' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 11' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate ";
                            }
                            else if (PeriodFrom == 1 && PeriodTo == 12)
                            {
                                SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon4 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon5 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon6 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon7 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon8 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon9 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon10 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlCommand sqlcomm2 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 2' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon2);
                                SqlCommand sqlcom3 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 3' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon3);
                                SqlCommand sqlcomm4 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 4' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon4);
                                SqlCommand sqlcomm5 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 5' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon5);
                                SqlCommand sqlcomm6 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 6' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon6);
                                SqlCommand sqlcomm7 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 7' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon7);
                                SqlCommand sqlcomm8 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 8' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon8);
                                SqlCommand sqlcomm9 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 9' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon9);
                                SqlCommand sqlcomm10 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 10' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon10);
                                SqlCommand sqlcomm11 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 11' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon11);
                                sqlcon2.Open();
                                sqlcon3.Open();
                                sqlcon4.Open();
                                sqlcon5.Open();
                                sqlcon6.Open();
                                sqlcon7.Open();
                                sqlcon8.Open();
                                sqlcon9.Open();
                                sqlcon10.Open();
                                sqlcon11.Open();
                                SqlDataReader sqlread22 = sqlcomm2.ExecuteReader();
                                SqlDataReader sqlread3 = sqlcom3.ExecuteReader();
                                SqlDataReader sqlread4 = sqlcomm4.ExecuteReader();
                                SqlDataReader sqlread5 = sqlcomm5.ExecuteReader();
                                SqlDataReader sqlread6 = sqlcomm6.ExecuteReader();
                                SqlDataReader sqlread7 = sqlcomm7.ExecuteReader();
                                SqlDataReader sqlread8 = sqlcomm8.ExecuteReader();
                                SqlDataReader sqlread9 = sqlcomm9.ExecuteReader();
                                SqlDataReader sqlread10 = sqlcomm10.ExecuteReader();
                                SqlDataReader sqlread11 = sqlcomm11.ExecuteReader();
                                sqlread22.Read();
                                sqlread3.Read();
                                sqlread4.Read();
                                sqlread5.Read();
                                sqlread6.Read();
                                sqlread7.Read();
                                sqlread8.Read();
                                sqlread9.Read();
                                sqlread10.Read();
                                sqlread11.Read();
                                s2 = "CREATE VIEW TrialBalanceSummaryData AS Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 1' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread22.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread22.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 2' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 3' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread4.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread4.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 4' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread5.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread5.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 5' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread6.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread6.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 6' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread7.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread7.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 7' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread8.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread8.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 8' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread9.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread9.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 9' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread10.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread10.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 10' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread11.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread11.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 11' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 12' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate ";
                            }
                            else if (PeriodFrom == 1 && PeriodTo == 13)
                            {
                                SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon4 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon5 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon6 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon7 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon8 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon9 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon10 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlConnection sqlcon12 = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlCommand sqlcomm2 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 2' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon2);
                                SqlCommand sqlcom3 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 3' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon3);
                                SqlCommand sqlcomm4 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 4' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon4);
                                SqlCommand sqlcomm5 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 5' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon5);
                                SqlCommand sqlcomm6 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 6' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon6);
                                SqlCommand sqlcomm7 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 7' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon7);
                                SqlCommand sqlcomm8 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 8' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon8);
                                SqlCommand sqlcomm9 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 9' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon9);
                                SqlCommand sqlcomm10 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 10' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon10);
                                SqlCommand sqlcomm11 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 11' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon11);
                                SqlCommand sqlcomm12 = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='Period 12' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcon12);
                                sqlcon2.Open();
                                sqlcon3.Open();
                                sqlcon4.Open();
                                sqlcon5.Open();
                                sqlcon6.Open();
                                sqlcon7.Open();
                                sqlcon8.Open();
                                sqlcon9.Open();
                                sqlcon10.Open();
                                sqlcon11.Open();
                                sqlcon12.Open();
                                SqlDataReader sqlread22 = sqlcomm2.ExecuteReader();
                                SqlDataReader sqlread3 = sqlcom3.ExecuteReader();
                                SqlDataReader sqlread4 = sqlcomm4.ExecuteReader();
                                SqlDataReader sqlread5 = sqlcomm5.ExecuteReader();
                                SqlDataReader sqlread6 = sqlcomm6.ExecuteReader();
                                SqlDataReader sqlread7 = sqlcomm7.ExecuteReader();
                                SqlDataReader sqlread8 = sqlcomm8.ExecuteReader();
                                SqlDataReader sqlread9 = sqlcomm9.ExecuteReader();
                                SqlDataReader sqlread10 = sqlcomm10.ExecuteReader();
                                SqlDataReader sqlread11 = sqlcomm11.ExecuteReader();
                                SqlDataReader sqlread12 = sqlcomm12.ExecuteReader();
                                sqlread22.Read();
                                sqlread3.Read();
                                sqlread4.Read();
                                sqlread5.Read();
                                sqlread6.Read();
                                sqlread7.Read();
                                sqlread8.Read();
                                sqlread9.Read();
                                sqlread10.Read();
                                sqlread11.Read();
                                sqlread12.Read();
                                s2 = "CREATE VIEW TrialBalanceSummaryData AS Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 1' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread22.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread22.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 2' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 3' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread4.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread4.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 4' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread5.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread5.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 5' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread6.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread6.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 6' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread7.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread7.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 7' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread8.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread8.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 8' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread9.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread9.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 9' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread10.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread10.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 10' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread11.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread11.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 11' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread12.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlread12.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 12' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate " +
                                    "Union  " +
                                    "Select GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate,SUM(GLTR.TRANSDebitLC) AS 'Debit',SUM(GLTR.TRANSCreditLC) AS 'Credit',(GLTO.BeginningBalance+SUM(GLTR.TRANSDebitLC))-SUM(GLTR.TRANSCreditLC) AS 'EndBalance'" +
                                    "FROM GLAccounts GLA,GLTotals GLTO,GLTransactions GLTR,GLFiscalPeriod GLF,Batch B  " +
                                    "WHERE GLA.AccountNumber IN(" + ConditionValue + ") AND GLA.AccountNumber=GLTR.GLAccount AND GLA.AccountNumber=GLTO.AccountNumber AND GLTR.BatchNo=B.BatchNo AND GLTO.FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " AND GLTR.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(3))) + "' AND '" + string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(4))) + "' AND GLF.PeriodDescription ='Period 13' AND YEAR(B.PostDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND B.BatchStat='P' AND YEAR(GLF.PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " " +
                                    "GROUP BY GLA.AccountNumber,GLA.AccountName,GLA.AccountTypeName,GLTO.BeginningBalance,GLF.PeriodStartDate,GLF.PeriodEndDate ";
                            }
                        }
                    }
                    commandReport2.CommandText = s2;
                    readerReport2 = commandReport2.ExecuteReader();
                    readerReport2.Close();
                    SqlConnection sqlConnectionReportFinal = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlConnectionReportFinal.Open();
                    SqlCommand sqlCommandReportFinal = new SqlCommand("CREATE VIEW TrialBalanceSummary AS SELECT AccountNumber, AccountName, AccountTypeName, BeginningBalance, SUM(Debit) AS Debit, SUM(Credit) AS Credit, (BeginningBalance+SUM(Debit)-SUM(Credit)) AS EndBalance FROM TrialBalanceSummaryData GROUP BY AccountNumber, AccountName, AccountTypeName, BeginningBalance", sqlConnectionReportFinal);
                    SqlDataReader sqlReadReportFinal = sqlCommandReportFinal.ExecuteReader();
                    //if (sqlReadReportFinal.HasRows)
                    sqlReadReportFinal.Read();

                    reportGenerator.fiscalYearSetup = cbFiscalYear.Text;
                    reportGenerator.fiscalPeriodSetup = "Period " + PeriodFrom + " To Period " + PeriodTo;
                    reportGenerator.PostedUNPostedStatus = "„·Œ’ „Ì“«‰ «·„—«Ã⁄…";
                    reportGenerator.StartedAccount = tempTextFrom2;
                    reportGenerator.EndedAccount = tempTextTo2;
                    reportGenerator.PeriodFrom = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd2.GetDateTime(3))).ToString();
                    MessageBox.Show(reportGenerator.PeriodFrom);
                    reportGenerator.PeriodTo0 = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEnd3.GetDateTime(4))).ToString();
                    MessageBox.Show(reportGenerator.PeriodTo0);
                    reportGenerator.ReportType = "Trial Balance";
                    rptSummaryTrailBalance rsum = new rptSummaryTrailBalance();
                    rsum.ShowDialog();
                }
            }
            //else if (rbRevision.Checked == true)
            //{
            //    if (cbFiscalYear.Text == "")
            //    {
            //        MessageBox.Show("Make sure that you choose specific fiscal year");
            //        return;
            //    }

            //    if (cbFiscalPeriod.Text == "")
            //    {
            //        MessageBox.Show("Make sure that you choose fiscal period from");
            //        return;
            //    }

            //    if (cbFiscalPeriod2.Text == "")
            //    {
            //        MessageBox.Show("Make sure that you choose fiscal period to");
            //        return;
            //    }

            //    SqlConnection connectReportSummary = new SqlConnection(GeneralFunctions.ConnectionString);
            //    SqlCommand commandReportSummary = new SqlCommand();
            //    SqlDataReader readerReportSummary;


            //    connectReportSummary.Open();

            //    commandReportSummary = new SqlCommand();
            //    commandReportSummary.Connection = connectReportSummary;
            //    commandReportSummary.CommandType = CommandType.Text;


            //    commandReportSummary.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SummaryReport]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View SummaryReport";
            //    readerReportSummary = commandReportSummary.ExecuteReader();
            //    readerReportSummary.Close();
            //    string SQuery = "";

            //    if (cbFiscalPeriod.Text == cbFiscalPeriod2.Text)
            //    {
            //        if (cbFiscalPeriod.Text == "Period 1")
            //            SQuery = "CREATE VIEW dbo.SummaryReport AS " +
            //             "SELECT     TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,PeriodBalance1 AS BeginningBalance,PeriodBalance1 AS EndingBalance " +
            //             "FROM         dbo.GLAccountsChart";
            //        commandReportSummary.CommandText = SQuery;
            //        readerReportSummary = commandReportSummary.ExecuteReader();
            //        reportGenerator.ReportType = "Revision";
            //        rptSummaryTrailBalance rptSummmary = new rptSummaryTrailBalance();
            //        rptSummmary.ShowDialog();
            //        readerReportSummary.Close();
            //    }
            //}
            else if (rbRevision.Checked == true)
            {
                if (cbFiscalYear.Text == "")
                {
                    MessageBox.Show("Make sure that you choose specific fiscal year");
                    return;
                }

                if (cbFiscalPeriod.Text == "")
                {
                    MessageBox.Show("Make sure that you choose fiscal period from");
                    return;
                }

                if (cbFiscalPeriod2.Text == "")
                {
                    MessageBox.Show("Make sure that you choose fiscal period to");
                    return;
                }

                SqlConnection connectReportSummary = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand commandReportSummary = new SqlCommand();
                SqlDataReader readerReportSummary;

                reportGenerator.fiscalYearSetup = cbFiscalYear.Text;

                connectReportSummary.Open();

                commandReportSummary = new SqlCommand();
                commandReportSummary.Connection = connectReportSummary;
                commandReportSummary.CommandType = CommandType.Text;


                commandReportSummary.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SummarizeData]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View SummarizeData";
                readerReportSummary = commandReportSummary.ExecuteReader();
                readerReportSummary.Close();
                string SQuery = "";
                SqlConnection sqlConnectToGetPeriodOne = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlConnection sqlConnectToGetPeriodTwo = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand sqlCommandToGetPeriodOne = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='" + cbFiscalPeriod.Text + "' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlConnectToGetPeriodOne);
                SqlCommand sqlCommandToGetPeriodTwo = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='" + cbFiscalPeriod2.Text + "' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlConnectToGetPeriodTwo);
                sqlConnectToGetPeriodOne.Open();
                sqlConnectToGetPeriodTwo.Open();
                SqlDataReader sqlReadStartEndOne = sqlCommandToGetPeriodOne.ExecuteReader();
                SqlDataReader sqlReadStartEndTwo = sqlCommandToGetPeriodTwo.ExecuteReader();

                SqlConnection sqlConnecteTemp = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlConnecteTemp.Open();
                SqlCommand sqlCommandTemp = new SqlCommand();
                SqlDataReader sqlReadTemp;
                sqlCommandTemp.Connection = sqlConnecteTemp;
                sqlCommandTemp.CommandType = CommandType.Text;

                int PeriodFromOne = 0;
                int PeriodToTwo = 0;
                if (sqlReadStartEndOne.HasRows)
                {
                    if (sqlReadStartEndTwo.HasRows)
                    {
                        sqlReadStartEndOne.Read();
                        sqlReadStartEndTwo.Read();
                        PeriodFromOne = sqlReadStartEndOne.GetInt32(2);
                        PeriodToTwo = sqlReadStartEndTwo.GetInt32(2);
                        if (PeriodFromOne > PeriodToTwo)
                        {
                            MessageBox.Show("You must put small period first", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        else if (PeriodFromOne == PeriodToTwo)
                        {
                            reportGenerator.PeriodFrom = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndOne.GetDateTime(3))).ToString();
                            //MessageBox.Show(reportGenerator.PeriodFrom);
                            reportGenerator.PeriodTo0 = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndTwo.GetDateTime(4))).ToString();

                            if (PeriodFromOne == 1)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                     "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                     "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                     " UNION " +
                                     "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                     "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                     "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , SUM(Debit) AS Debit, SUM(Credit) AS Credit,(BeginningBalance+SUM(Debit)-SUM(Credit)) AS EndingBalance  " +
                                     "FROM     Temp " +
                                     " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName" +
                                     " UNION " +
                                     "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                     " UNION " +
                                     " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";

                            }
                            commandReportSummary.CommandText = SQuery;
                            readerReportSummary = commandReportSummary.ExecuteReader();
                            reportGenerator.ReportType = "Revision";
                            reportGenerator.fiscalPeriodSetup = "Period " + PeriodFromOne + " To Period " + PeriodToTwo;
                            reportGenerator.PeriodFrom = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndOne.GetDateTime(3))).ToString();
                            //MessageBox.Show(reportGenerator.PeriodFrom);
                            reportGenerator.PeriodTo0 = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndTwo.GetDateTime(4))).ToString();

                            rptSummaryTrailBalance rptSummmary = new rptSummaryTrailBalance();

                            rptSummmary.ShowDialog();
                            readerReportSummary.Close();
                        }
                        else if (PeriodFromOne < PeriodToTwo)
                        {
                            reportGenerator.PeriodFrom = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndOne.GetDateTime(3))).ToString();
                            //MessageBox.Show(reportGenerator.PeriodFrom);
                            reportGenerator.PeriodTo0 = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndTwo.GetDateTime(4))).ToString();

                            if (PeriodFromOne == 1 && PeriodToTwo == 2)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                     "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                     "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , SUM(Debit) AS Debit, SUM(Credit) AS Credit,(BeginningBalance+SUM(Debit)-SUM(Credit)) AS EndingBalance  " +
                                     "FROM     Temp " +
                                     " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName" +
                                     " UNION " +
                                     "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                     " UNION " +
                                     " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";

                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 3)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                     "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , SUM(Debit) AS Debit, SUM(Credit) AS Credit,(BeginningBalance+SUM(Debit)-SUM(Credit)) AS EndingBalance  " +
                                     "FROM     Temp " +
                                     " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName" +
                                     " UNION " +
                                     "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                     " UNION " +
                                     " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";

                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 4)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                     "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , SUM(Debit) AS Debit, SUM(Credit) AS Credit,(BeginningBalance+SUM(Debit)-SUM(Credit)) AS EndingBalance  " +
                                     "FROM     Temp " +
                                     " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName" +
                                     " UNION " +
                                     "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                     " UNION " +
                                     " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";

                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 5)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                     "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , SUM(Debit) AS Debit, SUM(Credit) AS Credit,(BeginningBalance+SUM(Debit)-SUM(Credit)) AS EndingBalance  " +
                                     "FROM     Temp " +
                                     " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName" +
                                     " UNION " +
                                     "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                     " UNION " +
                                     " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";

                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 6)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                  "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                     "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                     " UNION " +
                                     "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                     "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                     "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , SUM(Debit) AS Debit, SUM(Credit) AS Credit,(BeginningBalance+SUM(Debit)-SUM(Credit)) AS EndingBalance  " +
                                     "FROM     Temp " +
                                     " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName" +
                                     " UNION " +
                                     "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                     " UNION " +
                                     " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";

                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 7)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                  "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                     "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                     " UNION " +
                                     "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                     "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                     "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , SUM(Debit) AS Debit, SUM(Credit) AS Credit,(BeginningBalance+SUM(Debit)-SUM(Credit)) AS EndingBalance  " +
                                     "FROM     Temp " +
                                     " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName" +
                                     " UNION " +
                                     "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                     " UNION " +
                                     " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";

                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 8)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                  "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                    "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                    " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                    " UNION " +
                                    "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                    "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                    " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                     "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , SUM(Debit) AS Debit, SUM(Credit) AS Credit,(BeginningBalance+SUM(Debit)-SUM(Credit)) AS EndingBalance  " +
                                     "FROM     Temp " +
                                     " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName" +
                                     " UNION " +
                                     "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                     " UNION " +
                                     " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";

                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 9)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                  "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                     "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                     " UNION " +
                                     "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                     "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                     "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , SUM(Debit) AS Debit, SUM(Credit) AS Credit,(BeginningBalance+SUM(Debit)-SUM(Credit)) AS EndingBalance  " +
                                     "FROM     Temp " +
                                     " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName" +
                                     " UNION " +
                                     "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                     " UNION " +
                                     " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";

                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 10)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                  "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                     "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                     " UNION " +
                                     "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                     "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                     "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , SUM(Debit) AS Debit, SUM(Credit) AS Credit,(BeginningBalance+SUM(Debit)-SUM(Credit)) AS EndingBalance  " +
                                     "FROM     Temp " +
                                     " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName" +
                                     " UNION " +
                                     "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                     " UNION " +
                                     " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";

                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 11)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                  "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                    "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                    " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                    " UNION " +
                                    "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                    "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                    " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                     "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , SUM(Debit) AS Debit, SUM(Credit) AS Credit,(BeginningBalance+SUM(Debit)-SUM(Credit)) AS EndingBalance  " +
                                     "FROM     Temp " +
                                     " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName" +
                                     " UNION " +
                                     "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                     " UNION " +
                                     " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";

                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 12)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                   "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                   "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11','Period 12')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                   " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                   " UNION " +
                                   "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                   "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11','Period 12')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                   " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                     "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , SUM(Debit) AS Debit, SUM(Credit) AS Credit,(BeginningBalance+SUM(Debit)-SUM(Credit)) AS EndingBalance  " +
                                     "FROM     Temp " +
                                     " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName" +
                                     " UNION " +
                                     "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                     " UNION " +
                                     " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";

                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 13)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                  "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                   "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11','Period 12','Period 13')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                   " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                   " UNION " +
                                   "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                   "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11','Period 12','Period 13')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                   " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                     "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , SUM(Debit) AS Debit, SUM(Credit) AS Credit,(BeginningBalance+SUM(Debit)-SUM(Credit)) AS EndingBalance  " +
                                     "FROM     Temp " +
                                     " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName" +
                                     " UNION " +
                                     "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName" +
                                     " UNION " +
                                     " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , 0 AS Debit, 0 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' " +
                                     " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName";

                            }

                            commandReportSummary.CommandText = SQuery;
                            readerReportSummary = commandReportSummary.ExecuteReader();
                            reportGenerator.ReportType = "Revision";
                            reportGenerator.fiscalPeriodSetup = "Period " + PeriodFromOne + " To Period " + PeriodToTwo;
                            reportGenerator.PeriodFrom = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndOne.GetDateTime(3))).ToString();
                            //MessageBox.Show(reportGenerator.PeriodFrom);
                            reportGenerator.PeriodTo0 = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndTwo.GetDateTime(4))).ToString();

                            rptSummaryTrailBalance rptSummmary = new rptSummaryTrailBalance();

                            rptSummmary.ShowDialog();
                            readerReportSummary.Close();

                        }
                    }
                }
            }
            else if (rbMoneyState.Checked == true)
            {
                if (cbFiscalYear.Text == "")
                {
                    MessageBox.Show("Make sure that you choose specific fiscal year");
                    return;
                }

                if (cbFiscalPeriod.Text == "")
                {
                    MessageBox.Show("Make sure that you choose fiscal period from");
                    return;
                }

                if (cbFiscalPeriod2.Text == "")
                {
                    MessageBox.Show("Make sure that you choose fiscal period to");
                    return;
                }
                SqlConnection connectReportSummary = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand commandReportSummary = new SqlCommand();
                SqlDataReader readerReportSummary;

                reportGenerator.fiscalYearSetup = cbFiscalYear.Text;

                connectReportSummary.Open();

                commandReportSummary = new SqlCommand();
                commandReportSummary.Connection = connectReportSummary;
                commandReportSummary.CommandType = CommandType.Text;


                commandReportSummary.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SummarizeData]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View SummarizeData";
                readerReportSummary = commandReportSummary.ExecuteReader();
                readerReportSummary.Close();
                string SQuery = "";
                SqlConnection sqlConnectToGetPeriodOne = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlConnection sqlConnectToGetPeriodTwo = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand sqlCommandToGetPeriodOne = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='" + cbFiscalPeriod.Text + "' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlConnectToGetPeriodOne);
                SqlCommand sqlCommandToGetPeriodTwo = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='" + cbFiscalPeriod2.Text + "' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlConnectToGetPeriodTwo);
                sqlConnectToGetPeriodOne.Open();
                sqlConnectToGetPeriodTwo.Open();
                SqlDataReader sqlReadStartEndOne = sqlCommandToGetPeriodOne.ExecuteReader();
                SqlDataReader sqlReadStartEndTwo = sqlCommandToGetPeriodTwo.ExecuteReader();
                SqlConnection sqlConnecteTemp = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlConnecteTemp.Open();
                SqlCommand sqlCommandTemp = new SqlCommand();
                SqlDataReader sqlReadTemp;
                sqlCommandTemp.Connection = sqlConnecteTemp;
                sqlCommandTemp.CommandType = CommandType.Text;

                int PeriodFromOne = 0;
                int PeriodToTwo = 0;
                if (sqlReadStartEndOne.HasRows)
                {
                    if (sqlReadStartEndTwo.HasRows)
                    {
                        sqlReadStartEndOne.Read();
                        sqlReadStartEndTwo.Read();
                        PeriodFromOne = sqlReadStartEndOne.GetInt32(2);
                        PeriodToTwo = sqlReadStartEndTwo.GetInt32(2);
                        if (PeriodFromOne > PeriodToTwo)
                        {
                            MessageBox.Show("You must put small period first", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        else if (PeriodFromOne == PeriodToTwo)
                        {
                            reportGenerator.PeriodFrom = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndOne.GetDateTime(3))).ToString();
                            //MessageBox.Show(reportGenerator.PeriodFrom);
                            reportGenerator.PeriodTo0 = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndTwo.GetDateTime(4))).ToString();


                            
                            if (PeriodFromOne == 1)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance1 AS Debit, GLTotals.PeriodBalance1 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance1" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance1 AS Debit, GLTotals.PeriodBalance1 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance1";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance1 AS Debit, GLTotals.PeriodBalance1 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance1" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance1 AS Debit, GLTotals.PeriodBalance1 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance1";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                        }
                        else if (PeriodFromOne < PeriodToTwo)
                        {
                            reportGenerator.PeriodFrom = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndOne.GetDateTime(3))).ToString();
                            //MessageBox.Show(reportGenerator.PeriodFrom);
                            reportGenerator.PeriodTo0 = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndTwo.GetDateTime(4))).ToString();

                            if (PeriodFromOne == 1 && PeriodToTwo == 2)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance2 AS Debit, GLTotals.PeriodBalance2 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance2" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance2 AS Debit, GLTotals.PeriodBalance2 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance2";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance2 AS Debit, GLTotals.PeriodBalance2 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance2" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance2 AS Debit, GLTotals.PeriodBalance2 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance2";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 3)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance3 AS Debit, GLTotals.PeriodBalance3 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance3" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance3 AS Debit, GLTotals.PeriodBalance3 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance3";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance ,Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance3 AS Debit, GLTotals.PeriodBalance3 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance3" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance3 AS Debit, GLTotals.PeriodBalance3 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance3";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 4)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance4 AS Debit, GLTotals.PeriodBalance4 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance4" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance4 AS Debit, GLTotals.PeriodBalance4 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance4";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance4 AS Debit, GLTotals.PeriodBalance4 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance4" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance4 AS Debit, GLTotals.PeriodBalance4 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance4";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 5)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance5 AS Debit, GLTotals.PeriodBalance5 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance5" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance5 AS Debit, GLTotals.PeriodBalance5 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance5";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance5 AS Debit, GLTotals.PeriodBalance5 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance5" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance5 AS Debit, GLTotals.PeriodBalance5 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance5";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 6)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance6 AS Debit, GLTotals.PeriodBalance6 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance6" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance6 AS Debit, GLTotals.PeriodBalance6 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance6";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance6 AS Debit, GLTotals.PeriodBalance6 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A22%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance6" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance6 AS Debit, GLTotals.PeriodBalance6 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance6";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 7)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance7 AS Debit, GLTotals.PeriodBalance7 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance7" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance7 AS Debit, GLTotals.PeriodBalance7 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance7";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance7 AS Debit, GLTotals.PeriodBalance7 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance7" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance7 AS Debit, GLTotals.PeriodBalance7 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance7";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 8)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance8 AS Debit, GLTotals.PeriodBalance8 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance8" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance8 AS Debit, GLTotals.PeriodBalance8 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance8";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance8 AS Debit, GLTotals.PeriodBalance8 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance8" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance8 AS Debit, GLTotals.PeriodBalance8 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance8";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 9)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance9 AS Debit, GLTotals.PeriodBalance9 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance9" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance9 AS Debit, GLTotals.PeriodBalance9 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance9";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance9 AS Debit, GLTotals.PeriodBalance9 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance9" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance9 AS Debit, GLTotals.PeriodBalance9 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance9";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 10)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance10 AS Debit, GLTotals.PeriodBalance10 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance10" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance10 AS Debit, GLTotals.PeriodBalance10 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance10";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance10 AS Debit, GLTotals.PeriodBalance10 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance10" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance10 AS Debit, GLTotals.PeriodBalance10 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance10";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 11)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance11 AS Debit, GLTotals.PeriodBalance11 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance11" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance11 AS Debit, GLTotals.PeriodBalance11 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance11";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance11 AS Debit, GLTotals.PeriodBalance11 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance11" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance11 AS Debit, GLTotals.PeriodBalance11 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance11";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 12)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance12 AS Debit, GLTotals.PeriodBalance12 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11','Period 12')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance12" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance12 AS Debit, GLTotals.PeriodBalance12 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11','Period 12')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance12";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance12 AS Debit, GLTotals.PeriodBalance12 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance12" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance12 AS Debit, GLTotals.PeriodBalance12 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance12";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 13)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance13 AS Debit, GLTotals.PeriodBalance13 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11','Period 12','Period 13')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance13" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance13 AS Debit, GLTotals.PeriodBalance13 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11','Period 12','Period 13')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance13";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance13 AS Debit, GLTotals.PeriodBalance13 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance13" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance13 AS Debit, GLTotals.PeriodBalance13 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A1%' OR GLAccountsChart.TotalOrder LIKE 'A2%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance13";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            //commandReportSummary.CommandText = SQuery;
                            //readerReportSummary = commandReportSummary.ExecuteReader();
                            //reportGenerator.ReportType = "Income";
                            //reportGenerator.fiscalPeriodSetup = "Period " + PeriodFromOne + " To Period " + PeriodToTwo;
                            //reportGenerator.PeriodFrom = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndOne.GetDateTime(3))).ToString();
                            ////MessageBox.Show(reportGenerator.PeriodFrom);
                            //reportGenerator.PeriodTo0 = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndTwo.GetDateTime(4))).ToString();

                            //rptSummaryTrailBalance rptSummmary = new rptSummaryTrailBalance();

                            //rptSummmary.ShowDialog();
                            //readerReportSummary.Close();

                        }
                    }
                    reportGenerator.ReportType = "Money";
                    reportGenerator.fiscalPeriodSetup = "Period " + PeriodFromOne + " To Period " + PeriodToTwo;
                    reportGenerator.PeriodFrom = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndOne.GetDateTime(3))).ToString();
                    //MessageBox.Show(reportGenerator.PeriodFrom);
                    reportGenerator.PeriodTo0 = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndTwo.GetDateTime(4))).ToString();

                    rptSummaryTrailBalance rptSummmary = new rptSummaryTrailBalance();

                    rptSummmary.ShowDialog();
                    readerReportSummary.Close();
                }
                
            }
            else if (rbIncomeMenu.Checked == true)
            {
                if (cbFiscalYear.Text == "")
                {
                    MessageBox.Show("Make sure that you choose specific fiscal year");
                    return;
                }
                if (cbFiscalPeriod.Text == "")
                {
                    MessageBox.Show("Make sure that you choose fiscal period from");
                    return;
                }
                if (cbFiscalPeriod2.Text == "")
                {
                    MessageBox.Show("Make sure that you choose fiscal period to");
                    return;
                }

                SqlConnection connectReportSummary = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand commandReportSummary = new SqlCommand();
                SqlDataReader readerReportSummary;

                reportGenerator.fiscalYearSetup = cbFiscalYear.Text;

                connectReportSummary.Open();

                commandReportSummary = new SqlCommand();
                commandReportSummary.Connection = connectReportSummary;
                commandReportSummary.CommandType = CommandType.Text;


                commandReportSummary.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SummarizeData]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View SummarizeData";
                readerReportSummary = commandReportSummary.ExecuteReader();
                readerReportSummary.Close();
                string SQuery = "";
                SqlConnection sqlConnectToGetPeriodOne = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlConnection sqlConnectToGetPeriodTwo = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand sqlCommandToGetPeriodOne = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='" + cbFiscalPeriod.Text + "' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlConnectToGetPeriodOne);
                SqlCommand sqlCommandToGetPeriodTwo = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='" + cbFiscalPeriod2.Text + "' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlConnectToGetPeriodTwo);
                sqlConnectToGetPeriodOne.Open();
                sqlConnectToGetPeriodTwo.Open();
                SqlDataReader sqlReadStartEndOne = sqlCommandToGetPeriodOne.ExecuteReader();
                SqlDataReader sqlReadStartEndTwo = sqlCommandToGetPeriodTwo.ExecuteReader();
                SqlConnection sqlConnecteTemp = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlConnecteTemp.Open();
                SqlCommand sqlCommandTemp = new SqlCommand();
                SqlDataReader sqlReadTemp;
                sqlCommandTemp.Connection = sqlConnecteTemp;
                sqlCommandTemp.CommandType = CommandType.Text;

                int PeriodFromOne = 0;
                int PeriodToTwo = 0;
                if (sqlReadStartEndOne.HasRows)
                {
                    if (sqlReadStartEndTwo.HasRows)
                    {
                        sqlReadStartEndOne.Read();
                        sqlReadStartEndTwo.Read();
                        PeriodFromOne = sqlReadStartEndOne.GetInt32(2);
                        PeriodToTwo = sqlReadStartEndTwo.GetInt32(2);
                        if (PeriodFromOne > PeriodToTwo)
                        {
                            MessageBox.Show("You must put small period first", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        else if (PeriodFromOne == PeriodToTwo)
                        {
                            reportGenerator.PeriodFrom = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndOne.GetDateTime(3))).ToString();
                            //MessageBox.Show(reportGenerator.PeriodFrom);
                            reportGenerator.PeriodTo0 = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndTwo.GetDateTime(4))).ToString();


                            if (PeriodFromOne == 1)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance1 AS Debit, GLTotals.PeriodBalance1 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance1" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance1 AS Debit, GLTotals.PeriodBalance1 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance1";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance1 AS Debit, GLTotals.PeriodBalance1 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance1" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance1 AS Debit, GLTotals.PeriodBalance1 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance1";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                        }
                        else if (PeriodFromOne < PeriodToTwo)
                        {
                            reportGenerator.PeriodFrom = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndOne.GetDateTime(3))).ToString();
                            //MessageBox.Show(reportGenerator.PeriodFrom);
                            reportGenerator.PeriodTo0 = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndTwo.GetDateTime(4))).ToString();

                            if (PeriodFromOne == 1 && PeriodToTwo == 2)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance2 AS Debit, GLTotals.PeriodBalance2 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance2" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance2 AS Debit, GLTotals.PeriodBalance2 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance2";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance2 AS Debit, GLTotals.PeriodBalance2 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance2" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance2 AS Debit, GLTotals.PeriodBalance2 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance2";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 3)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance3 AS Debit, GLTotals.PeriodBalance3 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance3" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance3 AS Debit, GLTotals.PeriodBalance3 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance3";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance3 AS Debit, GLTotals.PeriodBalance3 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance3" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance3 AS Debit, GLTotals.PeriodBalance3 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance3";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 4)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance4 AS Debit, GLTotals.PeriodBalance4 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance4" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance4 AS Debit, GLTotals.PeriodBalance4 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance4";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance4 AS Debit, GLTotals.PeriodBalance4 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance4" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance4 AS Debit, GLTotals.PeriodBalance4 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance4";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 5)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance5 AS Debit, GLTotals.PeriodBalance5 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance5" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance5 AS Debit, GLTotals.PeriodBalance5 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance5";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance5 AS Debit, GLTotals.PeriodBalance5 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance5" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance5 AS Debit, GLTotals.PeriodBalance5 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance5";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 6)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance6 AS Debit, GLTotals.PeriodBalance6 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance6" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance6 AS Debit, GLTotals.PeriodBalance6 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance6";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance6 AS Debit, GLTotals.PeriodBalance6 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance6" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance6 AS Debit, GLTotals.PeriodBalance6 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance6";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 7)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance7 AS Debit, GLTotals.PeriodBalance7 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance7" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance7 AS Debit, GLTotals.PeriodBalance7 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance7";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance7 AS Debit, GLTotals.PeriodBalance7 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance7" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance7 AS Debit, GLTotals.PeriodBalance7 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance7";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 8)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance8 AS Debit, GLTotals.PeriodBalance8 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance8" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance8 AS Debit, GLTotals.PeriodBalance8 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance8";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance8 AS Debit, GLTotals.PeriodBalance8 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance8" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance8 AS Debit, GLTotals.PeriodBalance8 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance8";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 9)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance9 AS Debit, GLTotals.PeriodBalance9 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance9" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance9 AS Debit, GLTotals.PeriodBalance9 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance9";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance9 AS Debit, GLTotals.PeriodBalance9 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance9" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance9 AS Debit, GLTotals.PeriodBalance9 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance9";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 10)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance10 AS Debit, GLTotals.PeriodBalance10 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance10" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance10 AS Debit, GLTotals.PeriodBalance10 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance10";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance10 AS Debit, GLTotals.PeriodBalance10 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance10" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance10 AS Debit, GLTotals.PeriodBalance10 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance10";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 11)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance11 AS Debit, GLTotals.PeriodBalance11 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance11" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance11 AS Debit, GLTotals.PeriodBalance11 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance11";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance11 AS Debit, GLTotals.PeriodBalance11 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance11" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance11 AS Debit, GLTotals.PeriodBalance11 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance11";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 12)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance12 AS Debit, GLTotals.PeriodBalance12 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11','Period 12')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance12" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance12 AS Debit, GLTotals.PeriodBalance12 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11','Period 12')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance12";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance12 AS Debit, GLTotals.PeriodBalance12 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance12" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance12 AS Debit, GLTotals.PeriodBalance12 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance12";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            else if (PeriodFromOne == 1 && PeriodToTwo == 13)
                            {
                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View TEMP";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE VIEW dbo.TEMP AS " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance13 AS Debit, GLTotals.PeriodBalance13 AS Credit,(GLTotals.BeginningBalance-SUM(GLTransactions.TRANSCreditLC)+SUM(GLTransactions.TRANSDebitLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11','Period 12','Period 13')" + //AND Batch.BatchPRD='Period1'" + // --AND GLTransactions.TRANSDATE Between '" + reportGenerator.PeriodFrom + "' AND '" + reportGenerator.PeriodTo0 + "'" +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName,GLTotals.PeriodBalance13" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance13 AS Debit, GLTotals.PeriodBalance13 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance " +//, SUM(GLTransactions.TRANSDebitLC) AS Debit, SUM(GLTransactions.TRANSCreditLC) AS Credit,(GLTotals.BeginningBalance+SUM(GLTransactions.TRANSDebitLC)-SUM(GLTransactions.TRANSCreditLC)) AS EndingBalance  " +
                                 "FROM         GLAccountsChart INNER JOIN GLTransactions ON GLAccountsChart.AccountNumber = GLTransactions.GLAccount INNER JOIN   GLTotals ON GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " INNER JOIN GLAccounts ON GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') INNER JOIN Batch ON GLTransactions.BatchNo = Batch.BatchNo AND Batch.BatchStat='P' AND Batch.BatchPRD NOT IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11','Period 12','Period 13')" + // AND GLAccountsChart.AccountNumber NOT IN(SELECT  GLTransactions.GLAccount FROM   GLTransactions ) " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance13";

                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();

                                sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyIncomes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyIncomes]";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();
                                sqlCommandTemp.CommandText = "CREATE TABLE MyIncomes (TreeRowName VARCHAR(255),TreeRowParent VARCHAR(255),ListOrder VARCHAR(50),TotalOrder VARCHAR(50),AccountNumber VARCHAR(50),AccountName VARCHAR(255),BeginningBalance float,Debit float,Credit float,ENDBalance float)";
                                sqlReadTemp = sqlCommandTemp.ExecuteReader();
                                sqlReadTemp.Close();



                                SQuery = "CREATE VIEW dbo.SummarizeData AS " +
                                 "SELECT   TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber,AccountName,BeginningBalance , Debit AS Debit, Credit AS Credit,(BeginningBalance-SUM(Credit)+SUM(Debit)) AS EndingBalance  " +
                                 "FROM     Temp " +
                                 " GROUP BY TreeRowName, TreeRowParent, ListOrder, TotalOrder, AccountNumber, BeginningBalance,AccountName,Debit,Credit" +
                                 " UNION " +
                                 "SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,    GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance13 AS Debit, GLTotals.PeriodBalance13 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts WHERE  GLAccountsChart.AccountNumber NOT IN ( SELECT GLAccount FROM  GLTransactions) AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance13" +
                                 " UNION " +
                                 " SELECT     GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder, GLAccountsChart.AccountNumber,GLAccounts.AccountName,GLTotals.BeginningBalance , GLTotals.PeriodBalance13 AS Debit, GLTotals.PeriodBalance13 AS Credit,(GLTotals.BeginningBalance ) AS EndingBalance  FROM       GLAccountsChart , GLTransactions, GLTotals , GLAccounts,Batch WHERE  GLAccountsChart.AccountNumber =GLTransactions.GLAccount AND GLAccountsChart.AccountNumber = GLTotals.AccountNumber AND GLTotals.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + " AND GLAccountsChart.AccountNumber = GLAccounts.AccountNumber AND GLTransactions.BatchNo=Batch.BatchNo AND Batch.BatchStat='U' AND (GLAccountsChart.TotalOrder LIKE 'A3%' OR GLAccountsChart.TotalOrder LIKE 'A4%') " +
                                 " GROUP BY GLAccountsChart.TreeRowName, GLAccountsChart.TreeRowParent, GLAccountsChart.ListOrder, GLAccountsChart.TotalOrder,  GLAccountsChart.AccountNumber, GLTotals.BeginningBalance,GLAccounts.AccountName, GLTotals.PeriodBalance13";



                                commandReportSummary.CommandText = SQuery;
                                readerReportSummary = commandReportSummary.ExecuteReader();
                                //string conditions = "";
                                SqlCommand sqlCommandTempTest = new SqlCommand();
                                SqlDataReader sqlReadTempTest;
                                sqlCommandTempTest.Connection = sqlConnecteTemp;
                                sqlCommandTempTest.CommandType = CommandType.Text;
                                sqlCommandTempTest.CommandText = "Select * FROM SummarizeData";
                                sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                                SqlConnection newConnect11 = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect11.Open();
                                SqlCommand sqlCommandTemp11 = new SqlCommand();
                                SqlDataReader sqlReadTemp1;
                                sqlCommandTemp11.Connection = newConnect11;
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                if (sqlReadTempTest.HasRows)
                                {
                                    while (sqlReadTempTest.Read())
                                    {


                                        //SqlDataReader sqlReadTemp1;

                                        sqlCommandTemp11.CommandType = CommandType.Text;
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + sqlReadTempTest.GetString(4) + "'";
                                        //sqlReadTemp1.Close();
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        AccType = sqlReadTemp1.GetString(0).ToString();
                                        sqlReadTemp1.Close();
                                        sqlCommandTemp11.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                                        sqlReadTemp1 = sqlCommandTemp11.ExecuteReader();
                                        sqlReadTemp1.Read();
                                        if (sqlReadTemp1.GetString(0).ToString() == "credit")
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + ",0," + sqlReadTempTest.GetValue(8) + ",0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                        else
                                        {
                                            sqlCommandTemp1.CommandType = CommandType.Text;
                                            sqlCommandTemp1.CommandText = "Insert INTO MyIncomes (TreeRowName ,TreeRowParent ,ListOrder ,TotalOrder ,AccountNumber ,AccountName ,BeginningBalance ,Debit ,Credit ,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "','" + sqlReadTempTest.GetString(3) + "','" + sqlReadTempTest.GetString(4) + "','" + sqlReadTempTest.GetString(5) + "'," + sqlReadTempTest.GetValue(6) + "," + sqlReadTempTest.GetValue(7) + ",0,0)";
                                            sqlCommandTemp1.ExecuteNonQuery();
                                            sqlReadTemp1.Close();
                                            //newConnect.Close();
                                        }
                                    }
                                }
                                sqlReadTempTest.Close();
                            }
                            //commandReportSummary.CommandText = SQuery;
                            //readerReportSummary = commandReportSummary.ExecuteReader();
                            //reportGenerator.ReportType = "Income";
                            //reportGenerator.fiscalPeriodSetup = "Period " + PeriodFromOne + " To Period " + PeriodToTwo;
                            //reportGenerator.PeriodFrom = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndOne.GetDateTime(3))).ToString();
                            ////MessageBox.Show(reportGenerator.PeriodFrom);
                            //reportGenerator.PeriodTo0 = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndTwo.GetDateTime(4))).ToString();

                            //rptSummaryTrailBalance rptSummmary = new rptSummaryTrailBalance();

                            //rptSummmary.ShowDialog();
                            //readerReportSummary.Close();

                        }
                    }
                    reportGenerator.ReportType = "Income";
                    reportGenerator.fiscalPeriodSetup = "Period " + PeriodFromOne + " To Period " + PeriodToTwo;
                    reportGenerator.PeriodFrom = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndOne.GetDateTime(3))).ToString();
                    //MessageBox.Show(reportGenerator.PeriodFrom);
                    reportGenerator.PeriodTo0 = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndTwo.GetDateTime(4))).ToString();

                    rptSummaryTrailBalance rptSummmary = new rptSummaryTrailBalance();

                    rptSummmary.ShowDialog();
                    readerReportSummary.Close();
                }
            }
            else if (rbAnalysis.Checked == true)
            {
                if (cbFiscalYear.Text == "")
                {
                    MessageBox.Show("Make sure that you choose specific fiscal year");
                    return;
                }

                if (cbFiscalPeriod.Text == "")
                {
                    MessageBox.Show("Make sure that you choose fiscal period from");
                    return;
                }

                if (txtFromAccount.Text == "")
                {
                    MessageBox.Show("Make sure that you choose valid Account Number");
                    return;
                }

                SqlConnection connectReportSummary = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand commandReportSummary = new SqlCommand();
                SqlDataReader readerReportSummary;

                reportGenerator.fiscalYearSetup = cbFiscalYear.Text;

                connectReportSummary.Open();

                commandReportSummary = new SqlCommand();
                commandReportSummary.Connection = connectReportSummary;
                commandReportSummary.CommandType = CommandType.Text;


                commandReportSummary.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MainJVs]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View MainJVs";
                readerReportSummary = commandReportSummary.ExecuteReader();
                readerReportSummary.Close();
                string SQuery = "";
                SqlConnection sqlConnectToGetPeriodOne = new SqlConnection(GeneralFunctions.ConnectionString);
                //SqlConnection sqlConnectToGetPeriodTwo = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand sqlCommandToGetPeriodOne = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='" + cbFiscalPeriod.Text + "' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlConnectToGetPeriodOne);
                //SqlCommand sqlCommandToGetPeriodTwo = new SqlCommand("Select * FROM GLFiscalPeriod WHERE PeriodDescription='" + cbFiscalPeriod2.Text + "' AND YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlConnectToGetPeriodTwo);
                sqlConnectToGetPeriodOne.Open();
                //sqlConnectToGetPeriodTwo.Open();
                SqlDataReader sqlReadStartEndOne = sqlCommandToGetPeriodOne.ExecuteReader();
                //SqlDataReader sqlReadStartEndTwo = sqlCommandToGetPeriodTwo.ExecuteReader();
                SqlConnection sqlConnecteTemp = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlConnecteTemp.Open();
                SqlCommand sqlCommandTemp = new SqlCommand();
                SqlDataReader sqlReadTemp;
                sqlCommandTemp.Connection = sqlConnecteTemp;
                sqlCommandTemp.CommandType = CommandType.Text;
                //string accountNameNow, AccountNumberNow;
                double BeginBalance = 0;
                int PeriodFromOne = 0;
                int myPeriod = 0;
                //int PeriodToTwo = 0;
                if (sqlReadStartEndOne.HasRows)
                {
                    //if (sqlReadStartEndTwo.HasRows)
                    //{
                    sqlReadStartEndOne.Read();
                    //sqlReadStartEndTwo.Read();
                    PeriodFromOne = sqlReadStartEndOne.GetInt32(2);
                    //PeriodToTwo = sqlReadStartEndTwo.GetInt32(2);
                    //if (PeriodFromOne > PeriodToTwo)
                    //{
                    //    MessageBox.Show("You must put small period first", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //    return;
                    //}

                    //if (PeriodFromOne == PeriodToTwo)
                    //{
                    reportGenerator.PeriodFrom = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndOne.GetDateTime(3))).ToString();
                    //MessageBox.Show(reportGenerator.PeriodFrom);
                    //reportGenerator.PeriodTo0 = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndTwo.GetDateTime(4))).ToString();


                    if (PeriodFromOne == 1)
                    {

                        sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[JVs]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();
                        sqlCommandTemp.CommandText = "CREATE VIEW JVs AS " +
                         "SELECT   GLA.AccountNumber,GLA.AccountName,B.JVNumber,GLTO.BeginningBalance " +
                         "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                         "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount='" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "'";

                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();


                        sqlCommandTemp.CommandText = "SELECT DISTINCT AccountNumber,AccountName,BeginningBalance FROM JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        if (sqlReadTemp.HasRows)
                        {
                            sqlReadTemp.Read();
                            reportGenerator.AccountNameNow = sqlReadTemp.GetString(1);
                            reportGenerator.AccountNumberNow = sqlReadTemp.GetString(0);
                            BeginBalance = sqlReadTemp.GetDouble(2);
                            SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                            newConnect.Open();
                            SqlCommand sqlCommandTemp1 = new SqlCommand();
                            SqlDataReader sqlReadTemp1;
                            //SqlDataReader sqlReadTemp1;
                            sqlCommandTemp1.Connection = newConnect;
                            sqlCommandTemp1.CommandType = CommandType.Text;
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + reportGenerator.AccountNumberNow + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            AccType = sqlReadTemp1.GetString(0).ToString();
                            sqlReadTemp1.Close();
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            if (sqlReadTemp1.GetString(0).ToString() == "credit")
                            {
                                myPeriod = -1;
                            }
                            else
                            {
                                myPeriod = 0;
                            }
                            newConnect.Close();

                        }
                        sqlReadTemp.Close();
                        if (myPeriod == -1)
                            SQuery = "CREATE VIEW MainJVs AS " +
                             "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,0 AS Debit,BeginningBalance AS Credit FROM JVs " +
                             "Union " +
                             "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                             "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                             "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";
                        else if (myPeriod == 0)
                            SQuery = "CREATE VIEW MainJVs AS " +
                             "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,BeginningBalance AS Debit,0 AS Credit FROM JVs " +
                             "Union " +
                             "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                             "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                             "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";



                    }

                    else if (PeriodFromOne == 2)
                    {


                        sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[JVs]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();
                        sqlCommandTemp.CommandText = "CREATE VIEW JVs AS " +
                         "SELECT   GLA.AccountNumber,GLA.AccountName,B.JVNumber,GLTO.BeginningBalance " +
                         "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                         "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount='" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "'";

                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();

                        sqlCommandTemp.CommandText = "SELECT DISTINCT AccountNumber,AccountName,BeginningBalance FROM JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        if (sqlReadTemp.HasRows)
                        {
                            sqlReadTemp.Read();
                            reportGenerator.AccountNameNow = sqlReadTemp.GetString(1);
                            reportGenerator.AccountNumberNow = sqlReadTemp.GetString(0);
                            SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                            newConnect.Open();
                            SqlCommand sqlCommandTemp1 = new SqlCommand();
                            SqlDataReader sqlReadTemp1;
                            //SqlDataReader sqlReadTemp1;
                            sqlCommandTemp1.Connection = newConnect;
                            sqlCommandTemp1.CommandType = CommandType.Text;
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + reportGenerator.AccountNumberNow + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            AccType = sqlReadTemp1.GetString(0).ToString();
                            sqlReadTemp1.Close();
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            if (sqlReadTemp1.GetString(0).ToString() == "credit")
                            {
                                myPeriod = -1;
                            }
                            else
                            {
                                myPeriod = 0;
                            }
                            newConnect.Close();

                        }
                        sqlReadTemp.Close();
                        if (myPeriod == -1)
                            SQuery = "CREATE VIEW MainJVs AS " +
                             "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,0 AS Debit,BeginningBalance AS Credit FROM JVs " +
                             "Union " +
                             "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                             "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                             "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";
                        else if (myPeriod == 0)
                            SQuery = "CREATE VIEW MainJVs AS " +
                                                     "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,BeginningBalance AS Debit,0 AS Credit FROM JVs " +
                                                     "Union " +
                                                     "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                                                     "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                                                     "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";

                    }
                    else if (PeriodFromOne == 3)
                    {


                        sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[JVs]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();
                        sqlCommandTemp.CommandText = "CREATE VIEW JVs AS " +
                         "SELECT   GLA.AccountNumber,GLA.AccountName,B.JVNumber,GLTO.BeginningBalance " +
                         "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                         "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount='" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "'";

                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();

                        sqlCommandTemp.CommandText = "SELECT DISTINCT AccountNumber,AccountName,BeginningBalance FROM JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        if (sqlReadTemp.HasRows)
                        {
                            sqlReadTemp.Read();
                            reportGenerator.AccountNameNow = sqlReadTemp.GetString(1);
                            reportGenerator.AccountNumberNow = sqlReadTemp.GetString(0);
                            SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                            newConnect.Open();
                            SqlCommand sqlCommandTemp1 = new SqlCommand();
                            SqlDataReader sqlReadTemp1;
                            //SqlDataReader sqlReadTemp1;
                            sqlCommandTemp1.Connection = newConnect;
                            sqlCommandTemp1.CommandType = CommandType.Text;
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + reportGenerator.AccountNumberNow + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            AccType = sqlReadTemp1.GetString(0).ToString();
                            sqlReadTemp1.Close();
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            if (sqlReadTemp1.GetString(0).ToString() == "credit")
                            {
                                myPeriod = -1;
                            }
                            else
                            {
                                myPeriod = 0;
                            }
                            newConnect.Close();

                        }
                        sqlReadTemp.Close();
                        if (myPeriod == -1)
                            SQuery = "CREATE VIEW MainJVs AS " +
                             "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,0 AS Debit,BeginningBalance AS Credit FROM JVs " +
                             "Union " +
                             "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                             "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                             "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";
                        else if (myPeriod == 0)
                            SQuery = "CREATE VIEW MainJVs AS " +
                             "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,BeginningBalance AS Debit,0 AS Credit FROM JVs " +
                             "Union " +
                             "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                             "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                             "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";

                    }
                    else if (PeriodFromOne == 4)
                    {


                        sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[JVs]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();
                        sqlCommandTemp.CommandText = "CREATE VIEW JVs AS " +
                         "SELECT   GLA.AccountNumber,GLA.AccountName,B.JVNumber,GLTO.BeginningBalance " +
                         "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                         "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount='" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "'";

                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();
                        sqlCommandTemp.CommandText = "SELECT DISTINCT AccountNumber,AccountName,BeginningBalance FROM JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        if (sqlReadTemp.HasRows)
                        {
                            sqlReadTemp.Read();
                            reportGenerator.AccountNameNow = sqlReadTemp.GetString(1);
                            reportGenerator.AccountNumberNow = sqlReadTemp.GetString(0);
                            SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                            newConnect.Open();
                            SqlCommand sqlCommandTemp1 = new SqlCommand();
                            SqlDataReader sqlReadTemp1;
                            //SqlDataReader sqlReadTemp1;
                            sqlCommandTemp1.Connection = newConnect;
                            sqlCommandTemp1.CommandType = CommandType.Text;
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + reportGenerator.AccountNumberNow + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            AccType = sqlReadTemp1.GetString(0).ToString();
                            sqlReadTemp1.Close();
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            if (sqlReadTemp1.GetString(0).ToString() == "credit")
                            {
                                myPeriod = -1;
                            }
                            else
                            {
                                myPeriod = 0;
                            }
                            newConnect.Close();

                        }
                        sqlReadTemp.Close();
                        if (myPeriod == -1)
                            SQuery = "CREATE VIEW MainJVs AS " +
                             "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,0 AS Debit,BeginningBalance AS Credit FROM JVs " +
                             "Union " +
                             "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                             "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                             "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";
                        else if (myPeriod == 0)
                            SQuery = "CREATE VIEW MainJVs AS " +
                             "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,BeginningBalance AS Debit,0 AS Credit FROM JVs " +
                             "Union " +
                             "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                             "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                             "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";

                    }
                    else if (PeriodFromOne == 5)
                    {


                        sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[JVs]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();
                        sqlCommandTemp.CommandText = "CREATE VIEW JVs AS " +
                         "SELECT   GLA.AccountNumber,GLA.AccountName,B.JVNumber,GLTO.BeginningBalance " +
                         "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                         "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount='" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "'";

                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();

                        sqlCommandTemp.CommandText = "SELECT DISTINCT AccountNumber,AccountName,BeginningBalance FROM JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        if (sqlReadTemp.HasRows)
                        {
                            sqlReadTemp.Read();
                            reportGenerator.AccountNameNow = sqlReadTemp.GetString(1);
                            reportGenerator.AccountNumberNow = sqlReadTemp.GetString(0);
                            SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                            newConnect.Open();
                            SqlCommand sqlCommandTemp1 = new SqlCommand();
                            SqlDataReader sqlReadTemp1;
                            //SqlDataReader sqlReadTemp1;
                            sqlCommandTemp1.Connection = newConnect;
                            sqlCommandTemp1.CommandType = CommandType.Text;
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + reportGenerator.AccountNumberNow + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            AccType = sqlReadTemp1.GetString(0).ToString();
                            sqlReadTemp1.Close();
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            if (sqlReadTemp1.GetString(0).ToString() == "credit")
                            {
                                myPeriod = -1;
                            }
                            else
                            {
                                myPeriod = 0;
                            }
                            newConnect.Close();

                        }
                        sqlReadTemp.Close();
                        if (myPeriod == -1)
                            SQuery = "CREATE VIEW MainJVs AS " +
                             "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,0 AS Debit,BeginningBalance AS Credit FROM JVs " +
                             "Union " +
                             "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                             "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                             "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";
                        else if (myPeriod == 0)
                            SQuery = "CREATE VIEW MainJVs AS " +
                                                    "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,BeginningBalance AS Debit,0 AS Credit FROM JVs " +
                                                    "Union " +
                                                    "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                                                    "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                                                    "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";

                    }
                    else if (PeriodFromOne == 6)
                    {


                        sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[JVs]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();
                        sqlCommandTemp.CommandText = "CREATE VIEW JVs AS " +
                         "SELECT   GLA.AccountNumber,GLA.AccountName,B.JVNumber,GLTO.BeginningBalance " +
                         "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                         "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount='" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "'";

                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();

                        sqlCommandTemp.CommandText = "SELECT DISTINCT AccountNumber,AccountName,BeginningBalance FROM JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        if (sqlReadTemp.HasRows)
                        {
                            sqlReadTemp.Read();
                            reportGenerator.AccountNameNow = sqlReadTemp.GetString(1);
                            reportGenerator.AccountNumberNow = sqlReadTemp.GetString(0);
                            SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                            newConnect.Open();
                            SqlCommand sqlCommandTemp1 = new SqlCommand();
                            SqlDataReader sqlReadTemp1;
                            //SqlDataReader sqlReadTemp1;
                            sqlCommandTemp1.Connection = newConnect;
                            sqlCommandTemp1.CommandType = CommandType.Text;
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + reportGenerator.AccountNumberNow + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            AccType = sqlReadTemp1.GetString(0).ToString();
                            sqlReadTemp1.Close();
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            if (sqlReadTemp1.GetString(0).ToString() == "credit")
                            {
                                myPeriod = -1;
                            }
                            else
                            {
                                myPeriod = 0;
                            }
                            newConnect.Close();

                        }
                        sqlReadTemp.Close();
                        if (myPeriod == -1)
                            SQuery = "CREATE VIEW MainJVs AS " +
                             "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,0 AS Debit,BeginningBalance AS Credit FROM JVs " +
                             "Union " +
                             "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                             "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                             "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";
                        else if (myPeriod == 0)
                            SQuery = "CREATE VIEW MainJVs AS " +
                                                     "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,BeginningBalance AS Debit,0 AS Credit FROM JVs " +
                                                     "Union " +
                                                     "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                                                     "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                                                     "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";

                    }
                    else if (PeriodFromOne == 7)
                    {


                        sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[JVs]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();
                        sqlCommandTemp.CommandText = "CREATE VIEW JVs AS " +
                         "SELECT   GLA.AccountNumber,GLA.AccountName,B.JVNumber,GLTO.BeginningBalance " +
                         "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                         "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount='" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "'";

                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();

                        sqlCommandTemp.CommandText = "SELECT DISTINCT AccountNumber,AccountName,BeginningBalance FROM JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        if (sqlReadTemp.HasRows)
                        {
                            sqlReadTemp.Read();
                            reportGenerator.AccountNameNow = sqlReadTemp.GetString(1);
                            reportGenerator.AccountNumberNow = sqlReadTemp.GetString(0);
                            SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                            newConnect.Open();
                            SqlCommand sqlCommandTemp1 = new SqlCommand();
                            SqlDataReader sqlReadTemp1;
                            //SqlDataReader sqlReadTemp1;
                            sqlCommandTemp1.Connection = newConnect;
                            sqlCommandTemp1.CommandType = CommandType.Text;
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + reportGenerator.AccountNumberNow + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            AccType = sqlReadTemp1.GetString(0).ToString();
                            sqlReadTemp1.Close();
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            if (sqlReadTemp1.GetString(0).ToString() == "credit")
                            {
                                myPeriod = -1;
                            }
                            else
                            {
                                myPeriod = 0;
                            }
                            newConnect.Close();

                        }
                        sqlReadTemp.Close();
                        if (myPeriod == -1)
                            SQuery = "CREATE VIEW MainJVs AS " +
                             "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,0 AS Debit,BeginningBalance AS Credit FROM JVs " +
                             "Union " +
                             "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                             "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                             "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";
                        else if (myPeriod == 0)
                            SQuery = "CREATE VIEW MainJVs AS " +
                                                     "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,BeginningBalance AS Debit,0 AS Credit FROM JVs " +
                                                     "Union " +
                                                     "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                                                     "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                                                     "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";

                    }
                    else if (PeriodFromOne == 8)
                    {


                        sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[JVs]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();
                        sqlCommandTemp.CommandText = "CREATE VIEW JVs AS " +
                         "SELECT   GLA.AccountNumber,GLA.AccountName,B.JVNumber,GLTO.BeginningBalance " +
                         "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                         "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount='" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "'";

                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();

                        sqlCommandTemp.CommandText = "SELECT DISTINCT AccountNumber,AccountName,BeginningBalance FROM JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        if (sqlReadTemp.HasRows)
                        {
                            sqlReadTemp.Read();
                            reportGenerator.AccountNameNow = sqlReadTemp.GetString(1);
                            reportGenerator.AccountNumberNow = sqlReadTemp.GetString(0);
                            SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                            newConnect.Open();
                            SqlCommand sqlCommandTemp1 = new SqlCommand();
                            SqlDataReader sqlReadTemp1;
                            //SqlDataReader sqlReadTemp1;
                            sqlCommandTemp1.Connection = newConnect;
                            sqlCommandTemp1.CommandType = CommandType.Text;
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + reportGenerator.AccountNumberNow + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            AccType = sqlReadTemp1.GetString(0).ToString();
                            sqlReadTemp1.Close();
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            if (sqlReadTemp1.GetString(0).ToString() == "credit")
                            {
                                myPeriod = -1;
                            }
                            else
                            {
                                myPeriod = 0;
                            }
                            newConnect.Close();

                        }
                        sqlReadTemp.Close();
                        if (myPeriod == -1)
                            SQuery = "CREATE VIEW MainJVs AS " +
                             "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,0 AS Debit,BeginningBalance AS Credit FROM JVs " +
                             "Union " +
                             "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                             "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                             "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";
                        else if (myPeriod == 0)
                            SQuery = "CREATE VIEW MainJVs AS " +
                                                     "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,BeginningBalance AS Debit,0 AS Credit FROM JVs " +
                                                     "Union " +
                                                     "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                                                     "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                                                     "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";

                    }
                    else if (PeriodFromOne == 9)
                    {


                        sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[JVs]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();
                        sqlCommandTemp.CommandText = "CREATE VIEW JVs AS " +
                         "SELECT   GLA.AccountNumber,GLA.AccountName,B.JVNumber,GLTO.BeginningBalance " +
                         "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                         "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount='" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "'";

                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();

                        sqlCommandTemp.CommandText = "SELECT DISTINCT AccountNumber,AccountName,BeginningBalance FROM JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        if (sqlReadTemp.HasRows)
                        {
                            sqlReadTemp.Read();
                            reportGenerator.AccountNameNow = sqlReadTemp.GetString(1);
                            reportGenerator.AccountNumberNow = sqlReadTemp.GetString(0);
                            SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                            newConnect.Open();
                            SqlCommand sqlCommandTemp1 = new SqlCommand();
                            SqlDataReader sqlReadTemp1;
                            //SqlDataReader sqlReadTemp1;
                            sqlCommandTemp1.Connection = newConnect;
                            sqlCommandTemp1.CommandType = CommandType.Text;
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + reportGenerator.AccountNumberNow + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            AccType = sqlReadTemp1.GetString(0).ToString();
                            sqlReadTemp1.Close();
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            if (sqlReadTemp1.GetString(0).ToString() == "credit")
                            {
                                myPeriod = -1;
                            }
                            else
                            {
                                myPeriod = 0;
                            }
                            newConnect.Close();

                        }
                        sqlReadTemp.Close();
                        if (myPeriod == -1)
                            SQuery = "CREATE VIEW MainJVs AS " +
                             "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,0 AS Debit,BeginningBalance AS Credit FROM JVs " +
                             "Union " +
                             "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                             "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                             "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";
                        else if (myPeriod == 0)
                            SQuery = "CREATE VIEW MainJVs AS " +
                                                     "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,BeginningBalance AS Debit,0 AS Credit FROM JVs " +
                                                     "Union " +
                                                     "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                                                     "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                                                     "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";

                    }
                    else if (PeriodFromOne == 10)
                    {


                        sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[JVs]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();
                        sqlCommandTemp.CommandText = "CREATE VIEW JVs AS " +
                         "SELECT   GLA.AccountNumber,GLA.AccountName,B.JVNumber,GLTO.BeginningBalance " +
                         "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                         "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount='" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "'";

                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();

                        sqlCommandTemp.CommandText = "SELECT DISTINCT AccountNumber,AccountName,BeginningBalance FROM JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        if (sqlReadTemp.HasRows)
                        {
                            sqlReadTemp.Read();
                            reportGenerator.AccountNameNow = sqlReadTemp.GetString(1);
                            reportGenerator.AccountNumberNow = sqlReadTemp.GetString(0);
                            SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                            newConnect.Open();
                            SqlCommand sqlCommandTemp1 = new SqlCommand();
                            SqlDataReader sqlReadTemp1;
                            //SqlDataReader sqlReadTemp1;
                            sqlCommandTemp1.Connection = newConnect;
                            sqlCommandTemp1.CommandType = CommandType.Text;
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + reportGenerator.AccountNumberNow + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            AccType = sqlReadTemp1.GetString(0).ToString();
                            sqlReadTemp1.Close();
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            if (sqlReadTemp1.GetString(0).ToString() == "credit")
                            {
                                myPeriod = -1;
                            }
                            else
                            {
                                myPeriod = 0;
                            }
                            newConnect.Close();

                        }
                        sqlReadTemp.Close();
                        if (myPeriod == -1)
                            SQuery = "CREATE VIEW MainJVs AS " +
                             "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,0 AS Debit,BeginningBalance AS Credit FROM JVs " +
                             "Union " +
                             "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                             "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                             "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";
                        else if (myPeriod == 0)
                            SQuery = "CREATE VIEW MainJVs AS " +
                         "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,BeginningBalance AS Debit,0 AS Credit FROM JVs " +
                         "Union " +
                         "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                         "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                         "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";

                    }
                    else if (PeriodFromOne == 11)
                    {


                        sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[JVs]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();
                        sqlCommandTemp.CommandText = "CREATE VIEW JVs AS " +
                         "SELECT   GLA.AccountNumber,GLA.AccountName,B.JVNumber,GLTO.BeginningBalance " +
                         "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                         "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount='" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "'";

                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();

                        sqlCommandTemp.CommandText = "SELECT DISTINCT AccountNumber,AccountName,BeginningBalance FROM JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        if (sqlReadTemp.HasRows)
                        {
                            sqlReadTemp.Read();
                            reportGenerator.AccountNameNow = sqlReadTemp.GetString(1);
                            reportGenerator.AccountNumberNow = sqlReadTemp.GetString(0);
                            SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                            newConnect.Open();
                            SqlCommand sqlCommandTemp1 = new SqlCommand();
                            SqlDataReader sqlReadTemp1;
                            //SqlDataReader sqlReadTemp1;
                            sqlCommandTemp1.Connection = newConnect;
                            sqlCommandTemp1.CommandType = CommandType.Text;
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + reportGenerator.AccountNumberNow + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            AccType = sqlReadTemp1.GetString(0).ToString();
                            sqlReadTemp1.Close();
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            if (sqlReadTemp1.GetString(0).ToString() == "credit")
                            {
                                myPeriod = -1;
                            }
                            else
                            {
                                myPeriod = 0;
                            }
                            newConnect.Close();

                        }
                        sqlReadTemp.Close();
                        if (myPeriod == -1)
                            SQuery = "CREATE VIEW MainJVs AS " +
                             "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,0 AS Debit,BeginningBalance AS Credit FROM JVs " +
                             "Union " +
                             "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                             "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                             "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";
                        else if (myPeriod == 0)
                            SQuery = "CREATE VIEW MainJVs AS " +
                         "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,BeginningBalance AS Debit,0 AS Credit FROM JVs " +
                         "Union " +
                         "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                         "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                         "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";


                    }
                    else if (PeriodFromOne == 12)
                    {


                        sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[JVs]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();
                        sqlCommandTemp.CommandText = "CREATE VIEW JVs AS " +
                         "SELECT   GLA.AccountNumber,GLA.AccountName,B.JVNumber,GLTO.BeginningBalance " +
                         "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                         "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount='" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11','Period 12') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "'";

                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();

                        sqlCommandTemp.CommandText = "SELECT DISTINCT AccountNumber,AccountName,BeginningBalance FROM JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        if (sqlReadTemp.HasRows)
                        {
                            sqlReadTemp.Read();
                            reportGenerator.AccountNameNow = sqlReadTemp.GetString(1);
                            reportGenerator.AccountNumberNow = sqlReadTemp.GetString(0);
                            SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                            newConnect.Open();
                            SqlCommand sqlCommandTemp1 = new SqlCommand();
                            SqlDataReader sqlReadTemp1;
                            //SqlDataReader sqlReadTemp1;
                            sqlCommandTemp1.Connection = newConnect;
                            sqlCommandTemp1.CommandType = CommandType.Text;
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + reportGenerator.AccountNumberNow + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            AccType = sqlReadTemp1.GetString(0).ToString();
                            sqlReadTemp1.Close();
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            if (sqlReadTemp1.GetString(0).ToString() == "credit")
                            {
                                myPeriod = -1;
                            }
                            else
                            {
                                myPeriod = 0;
                            }
                            newConnect.Close();
                        }
                        sqlReadTemp.Close();
                        if (myPeriod == -1)
                            SQuery = "CREATE VIEW MainJVs AS " +
                             "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,0 AS Debit,BeginningBalance AS Credit FROM JVs " +
                             "Union " +
                             "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                             "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                             "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11','Period 12') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";
                        else if (myPeriod == 0)
                            SQuery = "CREATE VIEW MainJVs AS " +
                                                     "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,BeginningBalance AS Debit,0 AS Credit FROM JVs " +
                                                     "Union " +
                                                     "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                                                     "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                                                     "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11','Period 12') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";

                    }
                    else if (PeriodFromOne == 13)
                    {


                        sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[JVs]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();
                        sqlCommandTemp.CommandText = "CREATE VIEW JVs AS " +
                         "SELECT   GLA.AccountNumber,GLA.AccountName,B.JVNumber,GLTO.BeginningBalance " +
                         "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                         "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount='" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11','Period 12','Period 13') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "'";

                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        sqlReadTemp.Close();

                        sqlCommandTemp.CommandText = "SELECT DISTINCT AccountNumber,AccountName,BeginningBalance FROM JVs";
                        sqlReadTemp = sqlCommandTemp.ExecuteReader();
                        if (sqlReadTemp.HasRows)
                        {
                            sqlReadTemp.Read();
                            reportGenerator.AccountNameNow = sqlReadTemp.GetString(1);
                            reportGenerator.AccountNumberNow = sqlReadTemp.GetString(0);

                            SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                            newConnect.Open();
                            SqlCommand sqlCommandTemp1 = new SqlCommand();
                            SqlDataReader sqlReadTemp1;
                            //SqlDataReader sqlReadTemp1;
                            sqlCommandTemp1.Connection = newConnect;
                            sqlCommandTemp1.CommandType = CommandType.Text;
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeName FROM GLAccounts WHERE AccountNumber='" + reportGenerator.AccountNumberNow + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            AccType = sqlReadTemp1.GetString(0).ToString();
                            sqlReadTemp1.Close();
                            sqlCommandTemp1.CommandText = "SELECT AccountTypeClassification FROM GLAccountTypes WHERE AccountTypeName='" + AccType + "'";
                            sqlReadTemp1 = sqlCommandTemp1.ExecuteReader();
                            sqlReadTemp1.Read();
                            if (sqlReadTemp1.GetString(0).ToString() == "credit")
                            {
                                myPeriod = -1;
                            }
                            else
                            {
                                myPeriod = 0;
                            }
                            newConnect.Close();



                        }
                        sqlReadTemp.Close();

                        if (myPeriod == -1)
                            SQuery = "CREATE VIEW MainJVs AS " +
                             "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,0 AS Debit,BeginningBalance AS Credit FROM JVs " +
                             "Union " +
                             "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                             "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                             "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11','Period 12','Period 13') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";
                        else if (myPeriod == 0)
                            SQuery = "CREATE VIEW MainJVs AS " +
                                                    "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,BeginningBalance AS Debit,0 AS Credit FROM JVs " +
                                                    "Union " +
                                                    "SELECT   GLA.AccountNumber,GLTR.TRANSREF AS AccountName,B.JVNumber,GLTR.TRANSDebitLC AS Debit,GLTR.TRANSCreditLC AS Credit " +
                                                    "FROM         GLAccounts GLA, GLTotals GLTO ,Batch B,GLTransactions GLTR " +
                                                    "WHERE GLA.AccountNumber = GLTO.AccountNumber AND GLA.AccountNumber = GLTR.GLAccount AND B.BatchStat='P' AND GLTR.GLAccount<>'" + txtFromAccount.Text + "' AND B.BatchNo=GLTR.BatchNo AND B.BatchPRD IN ('Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11','Period 12','Period 13') AND GLTO.FiscalYear='" + Convert.ToInt32(cbFiscalYear.Text) + "' AND B.JVNumber IN (SELECT DISTINCT JVNumber FROM JVs) ";

                    }
                    commandReportSummary.CommandText = SQuery;
                    readerReportSummary = commandReportSummary.ExecuteReader();
                    reportGenerator.ReportType = "JVs";
                    reportGenerator.fiscalPeriodSetup = "Period " + PeriodFromOne;// +" To Period " + PeriodToTwo;
                    reportGenerator.PeriodFrom = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndOne.GetDateTime(3))).ToString();
                    //MessageBox.Show(reportGenerator.PeriodFrom);
                    //reportGenerator.PeriodTo0 = string.Format(GeneralFunctions.Format_Date, Convert.ToDateTime(sqlReadStartEndTwo.GetDateTime(4))).ToString();


                    double readBeginBalance = 0;
                    string readSpecAccountName = "";
                    sqlCommandTemp.CommandText = "SELECT '' AS AccountNumber,'" + Convert.ToInt32(cbFiscalYear.Text) + "'+'/'+'1/1' AS AccountName,'—’Ìœ «Ê· «·„œ…' AS JVNumber,0 AS Debit,BeginningBalance AS Credit FROM JVs ";
                    sqlReadTemp = sqlCommandTemp.ExecuteReader();
                    if (sqlReadTemp.HasRows)
                    {
                        while (sqlReadTemp.Read())
                        {
                            readBeginBalance = sqlReadTemp.GetDouble(4);
                            readSpecAccountName = sqlReadTemp.GetString(2);
                        }
                    }
                    sqlReadTemp.Close();

                    sqlCommandTemp.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MyJVs]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[MyJVs]";
                    sqlReadTemp = sqlCommandTemp.ExecuteReader();
                    sqlReadTemp.Close();
                    sqlCommandTemp.CommandText = "CREATE TABLE MyJVs (AccountNumber VARCHAR(20),AccountName VARCHAR(255),JVNumber VARCHAR(50),Debit float,Credit float,ENDBalance float)";
                    sqlReadTemp = sqlCommandTemp.ExecuteReader();
                    sqlReadTemp.Close();

                    string conditions = "";
                    SqlCommand sqlCommandTempTest = new SqlCommand();
                    SqlDataReader sqlReadTempTest;
                    sqlCommandTempTest.Connection = sqlConnecteTemp;
                    sqlCommandTempTest.CommandType = CommandType.Text;
                    sqlCommandTempTest.CommandText = "Select * FROM MainJVs";
                    sqlReadTempTest = sqlCommandTempTest.ExecuteReader();
                    if (sqlReadTempTest.HasRows)
                    {
                        while (sqlReadTempTest.Read())
                        {
                            if (sqlReadTempTest.GetValue(2).ToString() == "—’Ìœ «Ê· «·„œ…")
                            {
                                //MessageBox.Show(Convert.ToString( sqlReadTempTest.GetValue(0)));
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                sqlCommandTemp1.Connection = newConnect;
                                sqlCommandTemp1.CommandType = CommandType.Text;
                                sqlCommandTemp1.CommandText = "Insert INTO MyJVs (AccountNumber,AccountName,JVNumber,Debit,Credit,ENDBalance) VALUES ('','" + sqlReadTempTest.GetString(1) + "','" + sqlReadTempTest.GetString(2) + "'," + sqlReadTempTest.GetValue(3) + "," + sqlReadTempTest.GetValue(4) + "," + readBeginBalance + ")";
                                sqlCommandTemp1.ExecuteNonQuery();
                                newConnect.Close();
                                continue;

                            }
                            else
                            {
                                SqlConnection newConnect = new SqlConnection(GeneralFunctions.ConnectionString);
                                newConnect.Open();
                                SqlCommand sqlCommandTemp1 = new SqlCommand();
                                //SqlDataReader sqlReadTemp1;
                                if (sqlReadTempTest.GetValue(1) == DBNull.Value)
                                {
                                    conditions = "";
                                }
                                else
                                {
                                    conditions = sqlReadTempTest.GetString(1);
                                }
                                sqlCommandTemp1.Connection = newConnect;
                                sqlCommandTemp1.CommandType = CommandType.Text;
                                readBeginBalance = readBeginBalance + Convert.ToDouble(sqlReadTempTest.GetValue(4)) - Convert.ToDouble(sqlReadTempTest.GetValue(3));
                                sqlCommandTemp1.CommandText = "Insert INTO MyJVs (AccountNumber,AccountName,JVNumber,Debit,Credit,ENDBalance) VALUES ('" + sqlReadTempTest.GetString(0) + "','" + conditions + "','" + sqlReadTempTest.GetString(2) + "'," + sqlReadTempTest.GetValue(3) + "," + sqlReadTempTest.GetValue(4) + "," + readBeginBalance + ")";
                                sqlCommandTemp1.ExecuteNonQuery();
                                newConnect.Close();

                            }
                        }
                    }
                    sqlReadTempTest.Close();
                    rptSummaryTrailBalance rptSummmary = new rptSummaryTrailBalance();

                    rptSummmary.ShowDialog();
                    readerReportSummary.Close();

                    //}
                    //}
                }
            }
            else if (rb2.Checked == true)
            {
                if (cbFiscalYear.Text == "")
                {
                    MessageBox.Show("Make sure that you choose specific fiscal year");
                    return;
                }

                if (cbFiscalPeriod.Text == "")
                {
                    MessageBox.Show("Make sure that you choose fiscal period from");
                    return;
                }

                if (cbFiscalPeriod2.Text == "")
                {
                    MessageBox.Show("Make sure that you choose fiscal period to");
                    return;
                }
                SqlConnection connectReport2 = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand commandReport2 = new SqlCommand();
                SqlDataReader readerReport2;


                connectReport2.Open();

                commandReport2 = new SqlCommand();
                commandReport2.Connection = connectReport2;
                commandReport2.CommandType = CommandType.Text;


                commandReport2.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BudgetPlanning]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View BudgetPlanning";
                readerReport2 = commandReport2.ExecuteReader();
                readerReport2.Close();

                SqlConnection sqlconnection2 = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand sqlcommand2 = new SqlCommand("Select * From GeneralSetup", sqlconnection2);
                sqlconnection2.Open();
                SqlDataReader sqlreader2 = sqlcommand2.ExecuteReader();
                int lenghtofAccount = 0;
                if (sqlreader2.HasRows)
                {
                    while (sqlreader2.Read())
                    {
                        lenghtofAccount = sqlreader2.GetString(1).ToString().Length;
                    }
                }
                string s2 = "";

                s2 = "Create View BudgetPlanning AS SELECT A.AccountNumber, A.AccountName, B.PeriodBalance1 + B.PeriodBalance2 + B.PeriodBalance3 + B.PeriodBalance4 + B.PeriodBalance5 + B.PeriodBalance6 + B.PeriodBalance7 + B.PeriodBalance8 + B.PeriodBalance9 + B.PeriodBalance10 + B.PeriodBalance11 + B.PeriodBalance12 + B.PeriodBalance13 AS TotalBudget, A.AccountTypeName " +
                     "FROM dbo.GLTotals B INNER JOIN dbo.GLAccounts A ON B.AccountNumber = A.AccountNumber INNER JOIN dbo.GLAccountsChart G ON A.AccountNumber = LEFT(G.TreeRowName, " + lenghtofAccount + ") " +
                     "WHERE (B.FiscalYear = " + Convert.ToInt32(cbFiscalYear.Text) + ") AND (A.AccountTypeName = 'Revenue' OR A.AccountTypeName = 'Expenses')";
                commandReport2.CommandText = s2;
                readerReport2 = commandReport2.ExecuteReader();
                readerReport2.Close();
                reportGenerator.fiscalYearSetup = cbFiscalYear.Text;

                rptBudgetPlanning rbp = new rptBudgetPlanning();
                rbp.ShowDialog();
            }
        }

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            if (rb1.Checked == true)
            {
                cbFiscalPeriod.Text = "Period 1";
                cbFiscalPeriod2.Text = "";
                lblFiscalPeriod.Visible = true;
                cbFiscalPeriod.Visible = true;
                rbPosted.Visible = true;
                rbUnPosted.Visible = true;
                lblFromAccount.Visible = false;
                lblToAccount.Visible = false;
                txtFromAccount.Visible = false;
                txtToAccount.Visible = false;
                btnFrom.Visible = false;
                btnTo.Visible = false;
                lblFiscalPeriod2.Visible = false;
                cbFiscalPeriod2.Visible = false;
            }
            else
            {
                cbFiscalPeriod.Text = "Period 1";
                cbFiscalPeriod2.Text = "";
                rbPosted.Visible = false;
                rbUnPosted.Visible = false;
                lblFromAccount.Visible = false;
                lblToAccount.Visible = false;
                txtFromAccount.Visible = false;
                txtToAccount.Visible = false;
                btnFrom.Visible = false;
                btnTo.Visible = false;
                lblFiscalPeriod2.Visible = true;
                cbFiscalPeriod2.Visible = true;
            }
        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {
            if (rb2.Checked == true)
            {
                cbFiscalPeriod.Text = "Period 1";
                cbFiscalPeriod2.Text = "";
                rbPosted.Visible = false;
                rbUnPosted.Visible = false;
                lblFromAccount.Visible = false;
                lblToAccount.Visible = false;
                txtFromAccount.Visible = false;
                txtToAccount.Visible = false;
                btnFrom.Visible = false;
                btnTo.Visible = false;
                lblFiscalPeriod2.Visible = true;
                cbFiscalPeriod2.Visible = true;
            }
        }

        private void rbTrialBalance_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTrialBalance.Checked == true)
            {
                cbFiscalPeriod.Text = "Period 1";
                cbFiscalPeriod2.Text = "";
                rbPosted.Visible = false;
                rbUnPosted.Visible = false;
                lblFromAccount.Visible = true;
                lblToAccount.Visible = true;
                txtFromAccount.Visible = true;
                txtToAccount.Visible = true;
                btnFrom.Visible = true;
                btnTo.Visible = true;
                lblFiscalPeriod2.Visible = true;
                cbFiscalPeriod2.Visible = true;
            }
        }

        private void btnTo_Click(object sender, EventArgs e)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.ShowDialog();
            if (accSearch.selectedAccountName != null && accSearch.selectedAccountNumber != null && accSearch.selectedAccountType != null)
            {
                txtToAccount.Text = accSearch.selectedAccountNumber;
            }
        }

        private void btnFrom_Click(object sender, EventArgs e)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.ShowDialog();
            if (accSearch.selectedAccountName != null && accSearch.selectedAccountNumber != null && accSearch.selectedAccountType != null)
            {
                txtFromAccount.Text = accSearch.selectedAccountNumber;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand sqlcommand1 = new SqlCommand("SELECT AccountNumberFormat FROM GeneralSetup", sqlConnect);
            SqlCommand sqlcommand2 = new SqlCommand("SELECT TreeRowName FROM GLAccountsChart", sqlConnect);
            sqlConnect.Open();
            SqlDataReader sqlread1 = sqlcommand1.ExecuteReader();
            if (sqlread1.HasRows)
            {
                while (sqlread1.Read())
                {

                }
            }
            SqlDataReader sqldread = sqlcommand2.ExecuteReader();
            if (sqldread.HasRows)
            {
                while (sqldread.Read())
                {

                }
            }
        }

        private void rbRevision_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRevision.Checked == true)
            {
                cbFiscalPeriod.Text = "Period 1";
                cbFiscalPeriod2.Text = "";
                rbPosted.Visible = false;
                rbUnPosted.Visible = false;
                lblFromAccount.Visible = false;
                lblToAccount.Visible = false;
                txtFromAccount.Visible = false;
                txtToAccount.Visible = false;
                btnFrom.Visible = false;
                btnTo.Visible = false;
                lblFiscalPeriod2.Visible = true;
                cbFiscalPeriod2.Visible = true;
            }
        }

        private void rbMoneyState_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMoneyState.Checked == true)
            {
                cbFiscalPeriod.Text = "Period 1";
                cbFiscalPeriod2.Text = "";
                rbPosted.Visible = false;
                rbUnPosted.Visible = false;
                lblFromAccount.Visible = false;
                lblToAccount.Visible = false;
                txtFromAccount.Visible = false;
                txtToAccount.Visible = false;
                btnFrom.Visible = false;
                btnTo.Visible = false;
                lblFiscalPeriod2.Visible = true;
                cbFiscalPeriod2.Visible = true;
            }
        }

        private void rbIncomeMenu_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIncomeMenu.Checked == true)
            {
                cbFiscalPeriod.Text = "Period 1";
                cbFiscalPeriod2.Text = "";
                rbPosted.Visible = false;
                rbUnPosted.Visible = false;
                lblFromAccount.Visible = false;
                lblToAccount.Visible = false;
                txtFromAccount.Visible = false;
                txtToAccount.Visible = false;
                btnFrom.Visible = false;
                btnTo.Visible = false;
                lblFiscalPeriod2.Visible = true;
                cbFiscalPeriod2.Visible = true;
            }
        }

        private void cbFiscalPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rbAnalysis_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAnalysis.Checked == true)
            {
                cbFiscalPeriod.Text = "Period 1";
                cbFiscalPeriod2.Text = "";
                rbPosted.Visible = false;
                rbUnPosted.Visible = false;
                lblFromAccount.Visible = true;
                lblToAccount.Visible = false;
                txtFromAccount.Visible = true;
                txtToAccount.Visible = false;
                btnFrom.Visible = true;
                btnTo.Visible = false;
                lblFiscalPeriod2.Visible = false;
                cbFiscalPeriod2.Visible = false;
            }
        }


    }
}