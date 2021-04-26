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
    public partial class RPTAPBatch : Form
    {
        public RPTAPBatch()
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

        private void RPTAPBatch_Load(object sender, EventArgs e)
        {
            dbAccountingProjectDS = new dbAccountingProjectDS();
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            {
                RPTAPBatches.decmial = short.Parse(dr["DecimalPointsNumber"].ToString());
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
            this.Text = obj_interface_language.ReportAPBatch;
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


                commandReport2.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BudgetPlanning]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View RPTAPBatch";
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
                s2 = "Create View RPTAPBatch AS SELECT dbo.Batch.BatchNo, dbo.Batch.JVNumber, dbo.Batch.BatchDate, dbo.Batch.BatchPRD, dbo.Batch.BatchDSC, dbo.Batch.BatchJNL, dbo.Batch.BatchStat, " +
                      "dbo.Batch.PostDate, dbo.APTrans.BatchInvoiceID, dbo.APTrans.InvoiceDate, dbo.APTrans.VendorCode, dbo.APTrans.VendorName, "+
                      "dbo.APTrans.TransactionType, dbo.APTrans.InvoiceAmount - dbo.APTrans.TaxValue AS Inv_Amount, dbo.APExpense.GLAccountNumber, "+
                      "dbo.APExpense.GLAccountName, dbo.APExpense.GLAccountDescription, dbo.APExpense.AccountAmount, dbo.Users.UserName, dbo.APTrans.Reference, dbo.APTrans.PONumber FROM  dbo.Batch INNER JOIN " +
                      "dbo.APTrans ON dbo.Batch.BatchNo = dbo.APTrans.APBatchNumber INNER JOIN "+
                      "dbo.APExpense ON dbo.APTrans.BatchInvoiceID = dbo.APExpense.BatchInvoiceID INNER JOIN "+
                      "dbo.Users ON dbo.Batch.UserID = dbo.Users.UserID where dbo.Batch.BatchSRC = 'AP' AND Batch.BatchDate Between '" + string.Format(GeneralFunctions.Format_Date, dtp_from.Value.Date) + "' AND '" + string.Format(GeneralFunctions.Format_Date, dtp_to.Value.Date) + "'";
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
                    s2 = s2 + "AND Batch.BatchNo Between '" + int.Parse(txtboxFrom.Text) + "' AND '" + int.Parse(txtboxto.Text) + "'";
                commandReport2.CommandText = s2;
                try
                {
                    readerReport2 = commandReport2.ExecuteReader();
                    readerReport2.Close();
                }
                catch (Exception ex)
                { }
                RPTAPBatches rpt = new RPTAPBatches();
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

    }
}