using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Accounting_GeneralLedger
{
    public partial class RPTAPDestributionFrm : Form
    {
        public RPTAPDestributionFrm()
        {
            InitializeComponent();
        }
        public static string txtTo = "";
        public static string txtFrom = "";
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbGeneralSetup;
        private SqlDataAdapter adaptertbAPGeneralSetup;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        private SqlConnection connectReport2;
        private SqlDataReader readerReport2;
        ArrayList ACClist;
        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            //this.Text = obj_interface_language.ReportAPBatch;
            this.label1.Text = obj_interface_language.lblFrom;
            this.label2.Text = obj_interface_language.lblTo;
            this.btnReport.Text = obj_interface_language.btnReport;

        }

        private void RPTAPDestributionFrm_Load(object sender, EventArgs e)
        {
            ACClist = new ArrayList();
            dbAccountingProjectDS = new dbAccountingProjectDS();
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            {
                RPTAPDestributions.decmial = short.Parse(dr["DecimalPointsNumber"].ToString());
            }
            SqlCommand mycom = new SqlCommand("SELECT DISTINCT dbo.APDeliveryType.DeliveryTypeAccountNumber FROM dbo.GLTransactions INNER JOIN  dbo.Batch ON dbo.GLTransactions.BatchNo = dbo.Batch.BatchNo INNER JOIN dbo.APDeliveryType ON dbo.GLTransactions.GLAccount = dbo.APDeliveryType.DeliveryTypeAccountNumber WHERE     (dbo.Batch.BatchSRC = N'AP') AND (dbo.Batch.BatchStat = N'P')");
            sqlcon.Open();
            mycom.Connection = sqlcon;
            SqlDataReader sqldr;
            sqldr= mycom.ExecuteReader();
            while (sqldr.Read())
            {
                ACClist.Add(sqldr[0].ToString());
            }
            mycom.Clone();
            sqldr.Close();
            sqlcon.Close();
            adaptertbAPGeneralSetup = new SqlDataAdapter("Select * from APGeneralSetup", sqlcon);
            adaptertbAPGeneralSetup.Fill(dbAccountingProjectDS.APGeneralSetup);
            foreach (DataRow dr in dbAccountingProjectDS.APGeneralSetup.Rows)
            {
                ACClist.Add(dr["APAccountNumber"].ToString());
            }
            if (GeneralFunctions.languagechioce != "")
            {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
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
                s2 = "Create View RPTAPBatch AS SELECT  dbo.Batch.BatchNo, dbo.Batch.JVNumber, dbo.Batch.BatchDate, dbo.Batch.BatchPRD, dbo.Batch.BatchDSC, dbo.Batch.BatchJNL, " +
                     " dbo.Batch.BatchStat, dbo.Batch.PostDate, dbo.APTrans.BatchInvoiceID, dbo.APTrans.InvoiceDate, dbo.APTrans.VendorCode, dbo.APTrans.VendorName, dbo.APTrans.TransactionType, dbo.APTrans.InvoiceAmount - dbo.APTrans.TaxValue AS Inv_Amount, " +
                     " dbo.APExpense.GLAccountNumber, dbo.APExpense.GLAccountName, dbo.APExpense.GLAccountDescription, dbo.APExpense.AccountAmount, dbo.Users.UserName, dbo.APTrans.Reference, dbo.APTrans.PONumber FROM dbo.Batch INNER JOIN dbo.APTrans ON dbo.Batch.BatchNo = dbo.APTrans.APBatchNumber INNER JOIN " +
                     " dbo.APExpense ON dbo.APTrans.BatchInvoiceID = dbo.APExpense.BatchInvoiceID INNER JOIN dbo.Users ON dbo.Batch.UserID = dbo.Users.UserID INNER JOIN dbo.APVendors ON dbo.APTrans.VendorCode = dbo.APVendors.VendorCode INNER JOIN " +
                     " dbo.APVendorCategory ON dbo.APVendors.VendorCategory = dbo.APVendorCategory.CategoryCode where dbo.Batch.BatchSRC = 'AP' AND dbo.Batch.BatchStat = 'P' AND Batch.BatchDate Between '" + string.Format(GeneralFunctions.Format_Date, dtp_from.Value.Date) + "' AND '" + string.Format(GeneralFunctions.Format_Date, dtp_to.Value.Date) + "'";
                commandReport2.CommandText = s2;
                try
                {
                    readerReport2 = commandReport2.ExecuteReader();
                    readerReport2.Close();
                }
                catch (Exception ex)
                { }
                commandReport2.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BudgetPlanning]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View RPTAP_Cash";
                try
                {
                    readerReport2 = commandReport2.ExecuteReader();
                    readerReport2.Close();
                }
                catch (Exception ex)
                { }


                s2 = "";
                s2 = "Create View RPTAP_Cash AS SELECT dbo.GLTransactions.GLAccount, dbo.GLAccounts.AccountName, dbo.GLTransactions.TRANSDATE, dbo.GLTransactions.TRANSREF, dbo.Batch.BatchNo, dbo.Batch.BatchDate, dbo.GLTransactions.AmountLC AS Amount, dbo.Batch.BatchStat, dbo.Batch.PostDate, dbo.Batch.BatchSRC FROM dbo.Batch INNER JOIN " +
                     " dbo.GLTransactions ON dbo.Batch.BatchNo = dbo.GLTransactions.BatchNo INNER JOIN " +
                     " dbo.GLAccounts ON dbo.GLTransactions.GLAccount = dbo.GLAccounts.AccountNumber where dbo.Batch.BatchSRC = 'AP' AND dbo.GLTransactions.SortNO <> 0 AND dbo.Batch.BatchStat = 'P' AND Batch.BatchDate Between '" + string.Format(GeneralFunctions.Format_Date, dtp_from.Value.Date) + "' AND '" + string.Format(GeneralFunctions.Format_Date, dtp_to.Value.Date) + "'";
                if (ACClist.Count != 0)
                {
                    s2 = s2 + " AND dbo.GLTransactions.GLAccount IN ('";
                    string s = "";
                    foreach (object ob in ACClist)
                    {
                        s2 = s2 + s + ob.ToString() + "'";
                        s = ",'";
                    }
                    s2 = s2 + ")";
                }
                commandReport2.CommandText = s2;
                try
                {
                    readerReport2 = commandReport2.ExecuteReader();
                    readerReport2.Close();
                }
                catch (Exception ex)
                { }

                RPTAPDestributions rpt = new RPTAPDestributions();
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