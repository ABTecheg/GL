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
    public partial class RptGLBatch : Form
    {
        public RptGLBatch()
        {
            InitializeComponent();
        }
        public static string txtBatchStat = "";
        public static string txtTo = "";
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
        private void RptGLBatch_Load(object sender, EventArgs e)
        {
            dbAccountingProjectDS = new dbAccountingProjectDS();
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            {
                RptBatches.decmial = short.Parse(dr["DecimalPointsNumber"].ToString());
            }
            rdb_both.Checked = true;
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
            this.Text = obj_interface_language.ReportGLBatch;
            this.label1.Text = obj_interface_language.lblFrom;
            this.label4.Text = obj_interface_language.lblFrom;
            this.label2.Text = obj_interface_language.lblTo;
            this.label3.Text = obj_interface_language.lblTo;
            this.groupBox1.Text = obj_interface_language.groupBatchStatus;
            this.groupBox2.Text = obj_interface_language.groupBatchRange;
            this.rdb_both.Text = obj_interface_language.rdbBoth;
            this.rdb_post.Text = obj_interface_language.rdbPosted;
            this.rdb_unpost.Text = obj_interface_language.rdbUnPosted;
            this.chkrange.Text = obj_interface_language.chkPrintByBatchRange;

            this.btnReport.Text = obj_interface_language.btnReport;

        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdb_both.Checked == false && rdb_post.Checked == false && rdb_unpost.Checked == false)
                {
                    MessageBox.Show("Choose type of report");
                    return;
                }
                connectReport2 = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand commandReport2 = new SqlCommand();


                connectReport2.Open();

                commandReport2 = new SqlCommand();
                commandReport2.Connection = connectReport2;
                commandReport2.CommandType = CommandType.Text;


                commandReport2.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BudgetPlanning]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View RptBatch";
                try
                {
                    readerReport2 = commandReport2.ExecuteReader();
                    readerReport2.Close();
                }
                catch (Exception ex)
                { }

                txtFrom = dtp_from.Value.ToShortDateString();
                txtTo = dtp_to.Value.ToShortDateString();

                string s2 = "";
                s2 = "Create View RptBatch AS SELECT dbo.Batch.JVNumber, dbo.Batch.BatchDate, dbo.Batch.BatchDSC, dbo.Batch.BatchJNL, dbo.Batch.BatchStat, dbo.Batch.PostDate," +
                          "dbo.GLTransactions.BatchNo, dbo.GLTransactions.GLAccount, dbo.GLTransactions.TRANSREF, dbo.GLTransactions.TRANSDATE, " +
                          "dbo.GLTransactions.CurrencyType, dbo.GLTransactions.Rate, dbo.GLTransactions.TRANSUnit, dbo.GLAccounts.AccountName, dbo.Batch.BatchPRD, " +
                          "dbo.Batch.REVBatch, dbo.GLTransactions.Amount, dbo.GLTransactions.AmountLC, dbo.GLTransactions.ProjectCode, dbo.Batch.UserID FROM dbo.Batch INNER JOIN " +
                          "dbo.GLTransactions ON dbo.Batch.BatchNo = dbo.GLTransactions.BatchNo INNER JOIN " +
                          "dbo.GLAccounts ON dbo.GLTransactions.GLAccount = dbo.GLAccounts.AccountNumber where dbo.Batch.BatchSRC = 'GL' AND (dbo.GLTransactions.SortNO <> 0) AND Batch.BatchDate Between '" + string.Format(GeneralFunctions.Format_Date, dtp_from.Value.Date) + "' AND '" + string.Format(GeneralFunctions.Format_Date, dtp_to.Value.Date) + "'";
                txtBatchStat = "Both";
                if (rdb_post.Checked == true)
                {
                    s2 = s2 + "AND Batch.BatchStat = 'P'";
                    txtBatchStat = "Posted Batches";
                }
                else if (rdb_unpost.Checked == true)
                {
                    s2 = s2 + "AND Batch.BatchStat = 'U'";
                    txtBatchStat = "UnPosted Batches";
                }
                if (chkrange.Checked == true)
                    s2 = s2 + "AND GLTransactions.BatchNo Between '" + int.Parse(txtboxFrom.Text) + "' AND '" + int.Parse(txtboxto.Text) + "'";
                commandReport2.CommandText = s2;
                try
                {
                    readerReport2 = commandReport2.ExecuteReader();
                    readerReport2.Close();
                }
                catch (Exception ex)
                { }
                RptBatches rpt = new RptBatches();
                rpt.ShowDialog();
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

        private void chkrange_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}