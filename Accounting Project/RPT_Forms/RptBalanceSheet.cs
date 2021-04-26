using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Accounting_GeneralLedger
{

    public partial class RptBalanceSheet : Form
    {
        public static string IN = "";
        public static string g1 = "";
        public static string g2 = "";
        public static string g3 = "";
        public static string g4 = "";
        public static string g5 = "";
        public static string g6 = "";
        public static string g7 = "";
        public static string g8 = "";
        public static string g9 = "";
        private static string Balance = "";
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbGeneralSetup;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        private SqlConnection connectReport2;
        private SqlDataReader readerReport2;
        public RptBalanceSheet()
        {
            InitializeComponent();
        }

        private void RptBalanceSheet_Load(object sender, EventArgs e)
        {
            dbAccountingProjectDS = new dbAccountingProjectDS();
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            {
                RptBalanceSheetList.decmial = short.Parse(dr["DecimalPointsNumber"].ToString());
                //Balance = GeneralFunctions.Decrypt(dr["BalanceSheet"].ToString());
                Balance = "All";

            }
            if (Balance == "Standard")
            {
                rdbstandard.Top = 42;
                rdbstandard.Checked = true;
                rdbstandard.Visible = true;
                rdbtraditional.Visible = false;
                rdT.Visible = false;
            }
            else if (Balance == "Traditional")
            {
                rdbtraditional.Checked = true;
                rdbstandard.Visible = false;
                rdbtraditional.Visible = true;
                rdT.Visible = false;
            }
            else if (Balance == "T")
            {
                rdT.Top = 42;
                rdT.Checked = true;
                rdbstandard.Visible = false;
                rdbtraditional.Visible = false;
                rdT.Visible = true;
            }
            else if (Balance == "All")
            {
                rdbstandard.Visible = true;
                rdbtraditional.Visible = true;
                rdT.Visible = true;
            }
            else
            {
                rdbstandard.Visible = false;
                rdbtraditional.Visible = false;
                rdT.Visible = false;
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
            //this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            //this.Text = obj_interface_language.GLTrialBalance;
            //this.label1.Text = obj_interface_language.lblFrom;
            //this.label5.Text = obj_interface_language.labelAccountNumber;
            //this.groupBox1.Text = obj_interface_language.groupReportDate;
            //this.groupBox2.Text = obj_interface_language.groupAccountRange;
            //this.groupBox3.Text = obj_interface_language.groupReportOptions;
            //this.rdbdetail.Text = obj_interface_language.rdbTrialBalanceDetail;
            //this.rdbsummary.Text = obj_interface_language.rdbTrialBalanceSummary;

            //this.btnReport.Text = obj_interface_language.btnReport;

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                connectReport2 = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand commandReport2 = new SqlCommand();
                connectReport2.Open();

                //string acc = "";
                if (rdbstandard.Checked == false && rdbtraditional.Checked == false && rdT.Checked == false)
                {
                    MessageBox.Show("Choose Type of report", "General Ledger");
                    return;
                }

                if (cmbNeg.SelectedIndex != -1)
                {
                    if (cmbNeg.SelectedIndex == 0)
                    {
                        RptBalanceSheetList.Neg = 1;
                        rptBS_T.Neg = 1;
                    }
                    else if (cmbNeg.SelectedIndex == 1)
                    {
                        RptBalanceSheetList.Neg = 3;
                        rptBS_T.Neg = 3;
                    }
                }
                if (rdbstandard.Checked == true)
                {
                    if (chklang.Checked == true)
                    {
                        BalanceSheet.FillBalanceSheet(dtp_from.Value.Date, "AR");
                        RptBalanceSheetList.Lang = "AR";
                    }
                    else
                    {
                        BalanceSheet.FillBalanceSheet(dtp_from.Value.Date, "");
                        RptBalanceSheetList.Lang = "";
                    }
                    IN = FindPeriod(dtp_from.Value.Date);
                    RptBalanceSheetList.Type = "Standard";
                    RptBalanceSheetList rpt = new RptBalanceSheetList();
                    rpt.ShowDialog();
                }
                else if (rdbtraditional.Checked == true)
                {
                    if (chklang.Checked == true)
                    {
                        BalanceSheet.FillBalanceSheet(dtp_from.Value.Date, "AR");
                        RptBalanceSheetList.Lang = "AR";
                    }
                    else
                    {
                        BalanceSheet.FillBalanceSheet(dtp_from.Value.Date, "");
                        RptBalanceSheetList.Lang = "";
                    }
                    IN = FindPeriod(dtp_from.Value.Date);
                    RptBalanceSheetList.Type = "Traditional";
                    RptBalanceSheetList rpt = new RptBalanceSheetList();
                    rpt.ShowDialog();
                }
                else if (rdT.Checked == true)
                {
                    if (chklang.Checked == true)
                    {
                        BalanceSheet.FillBalanceSheet(dtp_from.Value.Date, "AR");
                        rptBS_T.Lang = "AR";
                    }
                    else
                    {
                        BalanceSheet.FillBalanceSheet(dtp_from.Value.Date, "");
                        rptBS_T.Lang = "";
                    }
                    commandReport2 = new SqlCommand();
                    commandReport2.Connection = connectReport2;
                    commandReport2.CommandType = CommandType.Text;
                    commandReport2.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BudgetPlanning]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View RptAssets";
                   readerReport2 = commandReport2.ExecuteReader();
                   readerReport2.Close();
                    string s2 = "";
                    s2 = "Create View RptAssets AS SELECT G1, G2, G3, G4, G5, G6, G7, G8, G9, AccountNumber, AccountName, AccountType, Debit AS Balance FROM dbo.BalanceSheet WHERE (AccountType = 'Assets')";
                    commandReport2.CommandText = s2;
                    readerReport2 = commandReport2.ExecuteReader();
                    readerReport2.Close();

                    commandReport2 = new SqlCommand();
                    commandReport2.Connection = connectReport2;
                    commandReport2.CommandType = CommandType.Text;
                    commandReport2.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BudgetPlanning]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View RptL_E";
                    try
                    {
                        readerReport2 = commandReport2.ExecuteReader();
                        readerReport2.Close();
                    }
                    catch (Exception ex)
                    { }
                    s2 = "";
                    s2 = "Create View RptL_E AS SELECT G1, G2, G3, G4, G5, G6, G7, G8, G9, AccountNumber, AccountName, AccountType, Credit AS Balance FROM dbo.BalanceSheet WHERE  (AccountType = 'Liabilities') OR  (AccountType = 'Equity') OR (AccountType = 'Liabilities ') OR (AccountType = 'Liability')";
                    commandReport2.CommandText = s2;
                    try
                    {
                        readerReport2 = commandReport2.ExecuteReader();
                        readerReport2.Close();
                    }
                    catch (Exception ex)
                    { }
                    IN = FindPeriod(dtp_from.Value.Date);
                    rptBS_T rpt = new rptBS_T();
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
        private static string FindPeriod(DateTime prd)
        {
            string periodName;
            int prid;
            DateTime pred;
            string prdbalance = "";
            if (GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, prd.Date), out prid, out periodName, out pred))
                prdbalance = pred.ToShortDateString();
            else
                MessageBox.Show("The period has been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return prdbalance;
        }
    }
}