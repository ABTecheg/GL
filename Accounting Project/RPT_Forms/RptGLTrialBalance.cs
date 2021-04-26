using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Accounting_GeneralLedger.Forms;

namespace Accounting_GeneralLedger
{
    public partial class RptGLTrialBalance : Form
    {
        public RptGLTrialBalance()
        {
            InitializeComponent();
        }
       
        public static string g1 = "";
        public static string g2 = "";
        public static string g3 = "";
        public static string g4 = "";
        public static string g5 = "";
        public static string g6 = "";
        public static string g7 = "";
        public static string g8 = "";
        public static string g9 = "";
        public static string txtFrom = "";
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbGeneralSetup;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        private SqlConnection connectReport2;
        private SqlDataReader readerReport2;

        private void RptGLTrialBalance_Load(object sender, EventArgs e)
        {
           // radioButton1.Checked = true;
            dbAccountingProjectDS = new dbAccountingProjectDS();
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            {
                txt_AccountNumber1.Mask = dr["AccountNumberFormat"].ToString();
                RptTrialBalanceS.decmial = short.Parse(dr["DecimalPointsNumber"].ToString());
                RptsTrailBalance.decmial = short.Parse(dr["DecimalPointsNumber"].ToString());

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
            this.Text = obj_interface_language.GLTrialBalance;
            this.label1.Text = obj_interface_language.lblFrom;
           // this.label5.Text = obj_interface_language.labelAccountNumber;
            this.groupBox1.Text = obj_interface_language.groupReportDate;
            this.groupBox2.Text = obj_interface_language.groupAccountRange;
            this.groupBox3.Text = obj_interface_language.groupReportOptions;
            this.rdbdetail.Text = obj_interface_language.rdbTrialBalanceDetail;
            this.rdbsummary.Text = obj_interface_language.rdbTrialBalanceSummary;

            this.btnReport.Text = obj_interface_language.btnReport;

        }
        private void btnReport_Click(object sender, EventArgs e)
        {
              if (radioButton1.Checked && !radioButton2.Checked)
                {
                    try
                    {
                        connectReport2 = new SqlConnection(GeneralFunctions.ConnectionString);
                        SqlCommand commandReport2 = new SqlCommand();


                        connectReport2.Open();
                        string acc = "";
                        if (rdbdetail.Checked == false && rdbsummary.Checked == false)
                        {
                            MessageBox.Show("Choose Type of report", "General Ledger");
                            return;
                        }

                        commandReport2 = new SqlCommand();
                        commandReport2.Connection = connectReport2;
                        commandReport2.CommandType = CommandType.Text;

                        TrialBalance.FillTrialBalance(dtp_from.Value.Date);
                        commandReport2.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BudgetPlanning]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View RptGLTrialBalance";
                        try
                        {
                            readerReport2 = commandReport2.ExecuteReader();
                            readerReport2.Close();
                        }
                        catch (Exception ex)
                        { }

                        txtFrom = dtp_from.Value.ToShortDateString();
                        string s2 = "";
                        acc = txt_AccountNumber1.ToString();
                        acc = acc.Remove(0, 41).Trim();
                        s2 = "Create View RptGLTrialBalance AS SELECT dbo.TrialBalance.AccountNumber, dbo.TrialBalance.AccountName, dbo.TrialBalance.AccountType, dbo.TrialBalance.OpenBalance, dbo.TrialBalance.EndBalance, dbo.GLTransactions.BatchNo, dbo.GLTransactions.TRANSREF, dbo.GLTransactions.TRANSDATE," +
                                  "dbo.GLTransactions.Amount, dbo.GLTransactions.AmountLC, dbo.Batch.BatchDate, dbo.Batch.BatchJNL, dbo.TrialBalance.G1, dbo.TrialBalance.G2, dbo.TrialBalance.G3, dbo.TrialBalance.G4, dbo.TrialBalance.G5, dbo.TrialBalance.G6, dbo.TrialBalance.G7, dbo.TrialBalance.G8, " +
                                  "dbo.TrialBalance.G9 FROM dbo.Batch INNER JOIN dbo.GLTransactions ON dbo.Batch.BatchNo = dbo.GLTransactions.BatchNo INNER JOIN " +
                                  "dbo.TrialBalance ON dbo.GLTransactions.GLAccount = dbo.TrialBalance.AccountNumber where dbo.Batch.BatchSRC = 'GL' AND GLTransactions.TRANSDATE < '" + string.Format(GeneralFunctions.Format_Date, dtp_from.Value.Date) + "' AND GLTransactions.GLAccount like '" + acc + "'";
                        commandReport2.CommandText = s2;
                        try
                        {
                            readerReport2 = commandReport2.ExecuteReader();
                            readerReport2.Close();
                        }
                        catch (Exception ex)
                        { }
                        if (rdbdetail.Checked == true)
                        {
                            RptTrialBalanceS rpt = new RptTrialBalanceS();
                            rpt.ShowDialog();
                        }
                        else if (rdbsummary.Checked == true)
                        {
                            RptsTrailBalance rpt = new RptsTrailBalance();
                            rpt.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        connectReport2.Close();
                    }
                }

                else if (!radioButton1.Checked && radioButton2.Checked)
                {
                try
                {
                    connectReport2 = new SqlConnection(GeneralFunctions.ConnectionString);
                    SqlCommand commandReport2 = new SqlCommand();

                    connectReport2.Open();
                    commandReport2 = new SqlCommand();
                    commandReport2.Connection = connectReport2;
                    commandReport2.CommandType = CommandType.Text;
                    string s2 = "";

                    s2 = "Create View RptGLTrialBalance AS SELECT dbo.TrialBalance.AccountNumber,dbo.TrialBalance.AccountName, dbo.TrialBalance.AccountType, dbo.TrialBalance.OpenBalance,dbo.TrialBalance.EndBalance, dbo.GLTransactions.BatchNo,dbo.GLTransactions.TRANSREF,dbo.GLTransactions.TRANSDATE,dbo.GLTransactions.Amount,dbo.GLTransactions.AmountLC, dbo.Batch.BatchDate,dbo.Batch.BatchJNL,dbo.TrialBalance.G1,dbo.TrialBalance.G2,dbo.TrialBalance.G3,dbo.TrialBalance.G4,dbo.TrialBalance.G5,dbo.TrialBalance.G6,dbo.TrialBalance.G7,dbo.TrialBalance.G8,dbo.TrialBalance.G9 FROM dbo.Batch INNER JOIN dbo.GLTransactions ON dbo.Batch.BatchNo = dbo.GLTransactions.BatchNo  INNER JOIN dbo.TrialBalance ON dbo.GLTransactions.GLAccount = dbo.TrialBalance.AccountNumber   where dbo.Batch.BatchSRC = 'GL'  AND GLTransactions.DepartmentCode = '" + txt_DepartmentCode.Text+"'";
                    commandReport2.CommandText = s2;
                    try
                    {
                        readerReport2 = commandReport2.ExecuteReader();
                        readerReport2.Close();
                    }
                    catch (Exception ex)
                    { }
                    if (rdbdetail.Checked == true)
                    {
                        RptTrialBalanceS rpt = new RptTrialBalanceS();
                        rpt.ShowDialog();
                    }
                    else if (rdbsummary.Checked == true)
                    {
                        RptsTrailBalance rpt = new RptsTrailBalance();
                        rpt.ShowDialog();
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    connectReport2.Close();
                }

            }


        }

        private void txt_AccountNumber1_DoubleClick(object sender, EventArgs e)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.filter = " AND AccountTypeName <> 'Header'";
            accSearch.ShowDialog();
            if (accSearch.selectedAccountName != null && accSearch.selectedAccountNumber != null && accSearch.selectedAccountType != null && accSearch.selectedAccountType != "Header")
            {
                txt_AccountNumber1.Text = accSearch.selectedAccountNumber;
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void txt_DepartmentCode_DoubleClick_1(object sender, EventArgs e)
        {
            DepartmentsLoad dpld = new DepartmentsLoad();
            //var val=

            var val=dpld.ShowDialog();

            if (val==DialogResult.OK)
            {
                txt_DepartmentCode.Text = dpld.ReturnValue1;
            }


             
        }
    }
}