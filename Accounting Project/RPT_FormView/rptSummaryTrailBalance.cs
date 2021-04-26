using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Accounting_GeneralLedger {
    public partial class rptSummaryTrailBalance : Form {
        public rptSummaryTrailBalance() {
            InitializeComponent();
        }

        private void rptSummaryTrailBalance_Load(object sender, EventArgs e) {
            if (reportGenerator.ReportType == "Trial Balance") {
                TrialBalanceSummary rptTrialBalance = new TrialBalanceSummary();
                SqlConnection conTrial = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand comTrial = new SqlCommand();
                SqlDataAdapter adapTrial = new SqlDataAdapter();

                DataSet dsTrial = new DataSet();
                dsTrial.Clear();
                try {
                    comTrial.Connection = conTrial;
                    comTrial.CommandType = CommandType.Text;
                    comTrial.CommandText = "Select * From TrialBalanceSummary";
                    adapTrial.SelectCommand = comTrial;
                    adapTrial.Fill(dsTrial, "TrialBalanceSummary");

                    rptTrialBalance.SetDataSource(dsTrial);

                    CrystalDecisions.CrystalReports.Engine.TextObject fiscalYear;
                    CrystalDecisions.CrystalReports.Engine.TextObject fiscalPeriod;
                    CrystalDecisions.CrystalReports.Engine.TextObject txtTitle;
                    CrystalDecisions.CrystalReports.Engine.TextObject txtFrom;
                    CrystalDecisions.CrystalReports.Engine.TextObject txtTo;
                    CrystalDecisions.CrystalReports.Engine.TextObject PeriodFrom;
                    CrystalDecisions.CrystalReports.Engine.TextObject PeriodTo;

                    //CrystalDecisions.CrystalReports.Engine.TextObject fiscalPeriodNumber;
                    fiscalYear = (CrystalDecisions.CrystalReports.Engine.TextObject) rptTrialBalance.ReportDefinition.ReportObjects["fYear"];//"fYear"
                    fiscalYear.Text = reportGenerator.fiscalYearSetup;

                    fiscalPeriod = (CrystalDecisions.CrystalReports.Engine.TextObject) rptTrialBalance.ReportDefinition.ReportObjects["fPeriod"];
                    fiscalPeriod.Text = reportGenerator.fiscalPeriodSetup;

                    txtTitle = (CrystalDecisions.CrystalReports.Engine.TextObject) rptTrialBalance.ReportDefinition.ReportObjects["txtTitle"];
                    txtTitle.Text = reportGenerator.PostedUNPostedStatus;

                    txtFrom = (CrystalDecisions.CrystalReports.Engine.TextObject) rptTrialBalance.ReportDefinition.ReportObjects["txtFrom"];
                    txtFrom.Text = reportGenerator.StartedAccount;

                    txtTo = (CrystalDecisions.CrystalReports.Engine.TextObject) rptTrialBalance.ReportDefinition.ReportObjects["txtTo"];
                    txtTo.Text = reportGenerator.EndedAccount;

                    PeriodFrom = (CrystalDecisions.CrystalReports.Engine.TextObject)rptTrialBalance.ReportDefinition.ReportObjects["PeriodFrom"];
                    PeriodFrom.Text = reportGenerator.PeriodFrom;

                    PeriodTo = (CrystalDecisions.CrystalReports.Engine.TextObject)rptTrialBalance.ReportDefinition.ReportObjects["PeriodTo"];
                    PeriodTo.Text = reportGenerator.PeriodTo0;

                    CViewer1.ReportSource = rptTrialBalance;
                    CViewer1.Zoom(100);


                }
                catch (Exception e3) {
                    MessageBox.Show(e3.Message);
                }
            }
            else if (reportGenerator.ReportType == "Revision") {
                //SummaryReportFinal srf = new SummaryReportFinal();
                //SqlConnection conSummary = new SqlConnection(GeneralFunctions.ConnectionString);
                //SqlCommand comMoney = new SqlCommand();
                //SqlDataAdapter adapSummary = new SqlDataAdapter();

                //DataSet dsRevision = new DataSet();
                //dsRevision.Clear();
                //try
                //{
                //    comMoney.Connection = conSummary;
                //    comMoney.CommandType = CommandType.Text;
                //    comMoney.CommandText = "Select * From SummaryReport ORDER BY [ORDER]";
                //    adapSummary.SelectCommand = comMoney;
                //    adapSummary.Fill(dsRevision, "SummaryReport");

                //    srf.SetDataSource(dsRevision);

                //    //CrystalDecisions.CrystalReports.Engine.TextObject fiscalYear;
                //    //CrystalDecisions.CrystalReports.Engine.TextObject fiscalPeriod;
                //    //CrystalDecisions.CrystalReports.Engine.TextObject txtTitle;
                //    //CrystalDecisions.CrystalReports.Engine.TextObject txtFrom;
                //    //CrystalDecisions.CrystalReports.Engine.TextObject txtTo;
                //    //CrystalDecisions.CrystalReports.Engine.TextObject PeriodFrom;
                //    //CrystalDecisions.CrystalReports.Engine.TextObject PeriodTo;

                //    //CrystalDecisions.CrystalReports.Engine.TextObject fiscalPeriodNumber;
                //    //fiscalYear = (CrystalDecisions.CrystalReports.Engine.TextObject)rptTrialBalance.ReportDefinition.ReportObjects["fYear"];//"fYear"
                //    //fiscalYear.Text = reportGenerator.fiscalYearSetup;

                //    //fiscalPeriod = (CrystalDecisions.CrystalReports.Engine.TextObject)rptTrialBalance.ReportDefinition.ReportObjects["fPeriod"];
                //    //fiscalPeriod.Text = reportGenerator.fiscalPeriodSetup;

                //    //txtTitle = (CrystalDecisions.CrystalReports.Engine.TextObject)rptTrialBalance.ReportDefinition.ReportObjects["txtTitle"];
                //    //txtTitle.Text = reportGenerator.PostedUNPostedStatus;

                //    //txtFrom = (CrystalDecisions.CrystalReports.Engine.TextObject)rptTrialBalance.ReportDefinition.ReportObjects["txtFrom"];
                //    //txtFrom.Text = reportGenerator.StartedAccount;

                //    //txtTo = (CrystalDecisions.CrystalReports.Engine.TextObject)rptTrialBalance.ReportDefinition.ReportObjects["txtTo"];
                //    //txtTo.Text = reportGenerator.EndedAccount;

                //    //PeriodFrom = (CrystalDecisions.CrystalReports.Engine.TextObject)rptTrialBalance.ReportDefinition.ReportObjects["PeriodFrom"];
                //    //PeriodFrom.Text = reportGenerator.PeriodFrom;

                //    //PeriodTo = (CrystalDecisions.CrystalReports.Engine.TextObject)rptTrialBalance.ReportDefinition.ReportObjects["PeriodTo"];
                //    //PeriodTo.Text = reportGenerator.PeriodTo0;

                //    CViewer1.ReportSource = srf;
                //    CViewer1.Zoom(100);


                //}
                //catch (Exception e8)
                //{
                //    MessageBox.Show(e8.Message);
                //}
                SummaryReportFinal srf = new SummaryReportFinal();
                SqlConnection conSummary = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand comMoney = new SqlCommand();
                SqlDataAdapter adapSummary = new SqlDataAdapter();

                DataSet dsRevision = new DataSet();
                dsRevision.Clear();
                try
                {
                    comMoney.Connection = conSummary;
                    comMoney.CommandType = CommandType.Text;
                    comMoney.CommandText = "Select * From SummarizeData ORDER BY [TotalORDER]";
                    adapSummary.SelectCommand = comMoney;
                    adapSummary.Fill(dsRevision, "SummarizeData");

                    srf.SetDataSource(dsRevision);

                    CrystalDecisions.CrystalReports.Engine.TextObject fiscalYear;
                    CrystalDecisions.CrystalReports.Engine.TextObject fiscalPeriod;
                    //CrystalDecisions.CrystalReports.Engine.TextObject txtTitle;
                    //CrystalDecisions.CrystalReports.Engine.TextObject txtFrom;
                    //CrystalDecisions.CrystalReports.Engine.TextObject txtTo;
                    CrystalDecisions.CrystalReports.Engine.TextObject PeriodFrom;
                    CrystalDecisions.CrystalReports.Engine.TextObject PeriodTo;

                    //CrystalDecisions.CrystalReports.Engine.TextObject fiscalPeriodNumber;
                    fiscalYear = (CrystalDecisions.CrystalReports.Engine.TextObject)srf.ReportDefinition.ReportObjects["fYear"];//"fYear"
                    fiscalYear.Text = reportGenerator.fiscalYearSetup;

                    fiscalPeriod = (CrystalDecisions.CrystalReports.Engine.TextObject)srf.ReportDefinition.ReportObjects["fPeriod"];
                    fiscalPeriod.Text = reportGenerator.fiscalPeriodSetup;

                    //txtTitle = (CrystalDecisions.CrystalReports.Engine.TextObject)rptTrialBalance.ReportDefinition.ReportObjects["txtTitle"];
                    //txtTitle.Text = reportGenerator.PostedUNPostedStatus;

                    //txtFrom = (CrystalDecisions.CrystalReports.Engine.TextObject)rptTrialBalance.ReportDefinition.ReportObjects["txtFrom"];
                    //txtFrom.Text = reportGenerator.StartedAccount;

                    //txtTo = (CrystalDecisions.CrystalReports.Engine.TextObject)rptTrialBalance.ReportDefinition.ReportObjects["txtTo"];
                    //txtTo.Text = reportGenerator.EndedAccount;

                    PeriodFrom = (CrystalDecisions.CrystalReports.Engine.TextObject)srf.ReportDefinition.ReportObjects["PeriodFrom"];
                    PeriodFrom.Text = reportGenerator.PeriodFrom;

                    PeriodTo = (CrystalDecisions.CrystalReports.Engine.TextObject)srf.ReportDefinition.ReportObjects["PeriodTo"];
                    PeriodTo.Text = reportGenerator.PeriodTo0;

                    CViewer1.ReportSource = srf;
                    CViewer1.Zoom(100);


                }
                catch (Exception e8)
                {
                    MessageBox.Show(e8.Message);
                }
                finally
                {
                    conSummary.Close();
                }
            }
            else if (reportGenerator.ReportType == "Money") {
           
                MoneyState ms = new MoneyState();
                SqlConnection conMoney = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand comMoney = new SqlCommand();
                SqlDataAdapter adapMoney = new SqlDataAdapter();

                DataSet dsMoney = new DataSet();
                dsMoney.Clear();
                try
                {
                    comMoney.Connection = conMoney;
                    comMoney.CommandType = CommandType.Text;
                    comMoney.CommandText = "Select * From MyIncomes ORDER BY [ORDER]";
                    adapMoney.SelectCommand = comMoney;
                    adapMoney.Fill(dsMoney, "MyIncomes");

                    ms.SetDataSource(dsMoney);

                    CrystalDecisions.CrystalReports.Engine.TextObject fiscalYear;
                    CrystalDecisions.CrystalReports.Engine.TextObject fiscalPeriod;
                    
                    CrystalDecisions.CrystalReports.Engine.TextObject PeriodFrom;
                    CrystalDecisions.CrystalReports.Engine.TextObject PeriodTo;

                    fiscalYear = (CrystalDecisions.CrystalReports.Engine.TextObject)ms.ReportDefinition.ReportObjects["fYear"];//"fYear"
                    fiscalYear.Text = reportGenerator.fiscalYearSetup;

                    fiscalPeriod = (CrystalDecisions.CrystalReports.Engine.TextObject)ms.ReportDefinition.ReportObjects["fPeriod"];
                    fiscalPeriod.Text = reportGenerator.fiscalPeriodSetup;

                    PeriodFrom = (CrystalDecisions.CrystalReports.Engine.TextObject)ms.ReportDefinition.ReportObjects["PeriodFrom"];
                    PeriodFrom.Text = reportGenerator.PeriodFrom;

                    PeriodTo = (CrystalDecisions.CrystalReports.Engine.TextObject)ms.ReportDefinition.ReportObjects["PeriodTo"];
                    PeriodTo.Text = reportGenerator.PeriodTo0;

                    CViewer1.ReportSource = ms;
                    CViewer1.Zoom(100);


                }
                catch (Exception e9)
                {
                    MessageBox.Show(e9.Message);
                }
                finally
                {
                    conMoney.Close();
                }
            }
            else if (reportGenerator.ReportType == "Income")
            {

                IncomeMenu im = new IncomeMenu();
                SqlConnection conIncome = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand comIncome = new SqlCommand();
                SqlDataAdapter adapIncome = new SqlDataAdapter();

                DataSet dsIncome = new DataSet();
                dsIncome.Clear();
                try
                {
                    comIncome.Connection = conIncome;
                    comIncome.CommandType = CommandType.Text;
                    comIncome.CommandText = "Select * From MyIncomes WHERE AccountNumber <> '20-100-100' ORDER BY [ORDER]";
                    adapIncome.SelectCommand = comIncome;
                    adapIncome.Fill(dsIncome, "MyIncomes");

                    im.SetDataSource(dsIncome);

                    CrystalDecisions.CrystalReports.Engine.TextObject fiscalYear;
                    CrystalDecisions.CrystalReports.Engine.TextObject fiscalPeriod;

                    CrystalDecisions.CrystalReports.Engine.TextObject PeriodFrom;
                    CrystalDecisions.CrystalReports.Engine.TextObject PeriodTo;

                    fiscalYear = (CrystalDecisions.CrystalReports.Engine.TextObject)im.ReportDefinition.ReportObjects["fYear"];//"fYear"
                    fiscalYear.Text = reportGenerator.fiscalYearSetup;

                    fiscalPeriod = (CrystalDecisions.CrystalReports.Engine.TextObject)im.ReportDefinition.ReportObjects["fPeriod"];
                    fiscalPeriod.Text = reportGenerator.fiscalPeriodSetup;

                    PeriodFrom = (CrystalDecisions.CrystalReports.Engine.TextObject)im.ReportDefinition.ReportObjects["PeriodFrom"];
                    PeriodFrom.Text = reportGenerator.PeriodFrom;

                    PeriodTo = (CrystalDecisions.CrystalReports.Engine.TextObject)im.ReportDefinition.ReportObjects["PeriodTo"];
                    PeriodTo.Text = reportGenerator.PeriodTo0;

                    CViewer1.ReportSource = im ;
                    CViewer1.Zoom(100);


                }
                catch (Exception e10)
                {
                    MessageBox.Show(e10.Message);
                }
                finally
                {
                    conIncome.Close();
                }
            }
            else if (reportGenerator.ReportType == "JVs") {
                JVsReports im = new JVsReports();
                SqlConnection conIncome = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand comIncome = new SqlCommand();
                SqlDataAdapter adapIncome = new SqlDataAdapter();

                DataSet dsIncome = new DataSet();
                dsIncome.Clear();
                try
                {
                    comIncome.Connection = conIncome;
                    comIncome.CommandType = CommandType.Text;
                    comIncome.CommandText = "Select * From MyJVs";
                    adapIncome.SelectCommand = comIncome;
                    adapIncome.Fill(dsIncome, "MyJVs");

                    im.SetDataSource(dsIncome);

                    CrystalDecisions.CrystalReports.Engine.TextObject fYear;
                    CrystalDecisions.CrystalReports.Engine.TextObject ANumber;

                    CrystalDecisions.CrystalReports.Engine.TextObject AName;
                    //CrystalDecisions.CrystalReports.Engine.TextObject PeriodTo;

                    fYear = (CrystalDecisions.CrystalReports.Engine.TextObject)im.ReportDefinition.ReportObjects["fYear"];//"fYear"
                    fYear.Text = reportGenerator.fiscalYearSetup;

                    ANumber = (CrystalDecisions.CrystalReports.Engine.TextObject)im.ReportDefinition.ReportObjects["ANumber"];
                    ANumber.Text = reportGenerator.AccountNumberNow;

                    AName = (CrystalDecisions.CrystalReports.Engine.TextObject)im.ReportDefinition.ReportObjects["AName"];
                    AName.Text = reportGenerator.AccountNameNow;

                    CViewer1.ReportSource = im;
                    CViewer1.Zoom(100);


                }
                catch (Exception e11)
                {
                    MessageBox.Show(e11.Message);
                }
                finally
                {
                    conIncome.Close();
                }
            }
            else
            {
                BatchesReport rpt = new BatchesReport();
                SqlConnection con = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand com = new SqlCommand();
                SqlDataAdapter adap = new SqlDataAdapter();

                DataSet ds = new DataSet();
                ds.Clear();
                try
                {
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "Select * From BatchReport";
                    adap.SelectCommand = com;
                    adap.Fill(ds, "BatchReport");

                    rpt.SetDataSource(ds);

                    CrystalDecisions.CrystalReports.Engine.TextObject fiscalYear;
                    CrystalDecisions.CrystalReports.Engine.TextObject fiscalPeriod;
                    CrystalDecisions.CrystalReports.Engine.TextObject txtTitle;

                    //CrystalDecisions.CrystalReports.Engine.TextObject fiscalPeriodNumber;
                    fiscalYear = (CrystalDecisions.CrystalReports.Engine.TextObject)rpt.ReportDefinition.ReportObjects["fYear"];//"fYear"
                    fiscalYear.Text = reportGenerator.fiscalYearSetup;

                    fiscalPeriod = (CrystalDecisions.CrystalReports.Engine.TextObject)rpt.ReportDefinition.ReportObjects["fPeriod"];
                    fiscalPeriod.Text = reportGenerator.fiscalPeriodSetup;

                    txtTitle = (CrystalDecisions.CrystalReports.Engine.TextObject)rpt.ReportDefinition.ReportObjects["txtTitle"];
                    txtTitle.Text = reportGenerator.PostedUNPostedStatus;
                    CViewer1.ReportSource = rpt;
                    CViewer1.Zoom(100);


                }
                catch (Exception e2)
                {
                    MessageBox.Show(e2.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}