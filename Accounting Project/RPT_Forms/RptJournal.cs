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
    public partial class RptJournal : Form
    {
        public RptJournal()
        {
            InitializeComponent();
        }
        public static string txtBatchStat = "";
        public static string txtTo = "";
        public static string txtFrom = "";
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbGLJournalCodes;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private SqlDataAdapter adaptertbGeneralSetup;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        private SqlConnection connectReport2;
        private SqlDataReader readerReport2;

        private void rdbdetails_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ListAvailable.SelectedIndex != -1)
            {
                int I = ListAvailable.SelectedIndex;
                    ListSelect.Items.Add(ListAvailable.SelectedItem.ToString());
                    ListAvailable.Items.RemoveAt(I);
                ListAvailable.Focus();
                if (ListAvailable.Items.Count > 0)
                {
                    if (I  < ListAvailable.Items.Count)
                        ListAvailable.SetSelected(I, true);
                    else
                        ListAvailable.SetSelected(0, true);

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ListSelect.SelectedIndex != -1)
            {
                ListAvailable.Items.Add(ListSelect.SelectedItem.ToString());
                int I = ListSelect.SelectedIndex;
                ListSelect.Items.RemoveAt(I);
                ListSelect.Focus();
                if (ListSelect.Items.Count > 0)
                {
                    if (I < ListSelect.Items.Count)
                        ListSelect.SetSelected(I, true);
                    else
                        ListSelect.SetSelected(0, true);

                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (ListAvailable.Items.Count > 0)
            {
                ListSelect.Items.AddRange(ListAvailable.Items);
                ListAvailable.Items.Clear();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (ListSelect.Items.Count > 0)
            {
                ListAvailable.Items.AddRange(ListSelect.Items);
                ListSelect.Items.Clear();
            }
        }

        private void RptJournal_Load(object sender, EventArgs e)
        {
            dbAccountingProjectDS = new dbAccountingProjectDS();
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbGLJournalCodes = new SqlDataAdapter("Select * from GLJournalCodes", sqlcon);
            adaptertbGLJournalCodes.Fill(dbAccountingProjectDS.GLJournalCodes);
            if (dbAccountingProjectDS.GLJournalCodes.Rows.Count != 0)
            foreach (DataRow dr in dbAccountingProjectDS.GLJournalCodes.Rows)
            {
                ListAvailable.Items.Add(dr["JournalDescription"]);
            }
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            {
                RptJournalDet.decmial = short.Parse(dr["DecimalPointsNumber"].ToString());
                RptJournalAcc.decmial = short.Parse(dr["DecimalPointsNumber"].ToString());

            }

            rdb_both.Checked = true;
            rdbdetails.Checked = true;
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
            this.Text = obj_interface_language.JournalReport;
            this.label1.Text = obj_interface_language.lblFrom;
            this.label2.Text = obj_interface_language.lblTo;
            this.label3.Text = obj_interface_language.lblAvailable;
            this.label4.Text = obj_interface_language.lblSelect;
            this.groupBox1.Text = obj_interface_language.groupBatchStatus;
            this.groupBox2.Text = obj_interface_language.groupReportOptions;
            this.groupBox3.Text = obj_interface_language.groupG_LJournals;
            this.rdb_both.Text = obj_interface_language.rdbBoth;
            this.rdb_post.Text = obj_interface_language.rdbPosted;
            this.rdb_unpost.Text = obj_interface_language.rdbUnPosted;
            this.rdbdetails.Text = obj_interface_language.PrintWithBatchDetails;
            this.rdbsummer.Text = obj_interface_language.PrintAccountOnly;

            this.btnReport.Text = obj_interface_language.btnReport;

        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                connectReport2 = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand commandReport2 = new SqlCommand();


                connectReport2.Open();
                if (rdb_both.Checked == false && rdb_post.Checked == false && rdb_unpost.Checked == false)
                {
                    MessageBox.Show("Choose type of report", "General Ledger");
                    return;
                }
                if (rdbdetails.Checked == false && rdbsummer.Checked == false)
                {
                    MessageBox.Show("Choose type of report", "General Ledger");
                    return;
                }
                if (ListSelect.Items.Count < 1)
                {
                    MessageBox.Show("Select G/L Journal", "General Ledger");
                    return;
                }

                commandReport2 = new SqlCommand();
                commandReport2.Connection = connectReport2;
                commandReport2.CommandType = CommandType.Text;


                commandReport2.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BudgetPlanning]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View RptJournal";
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
                s2 = "Create View RptJournal AS SELECT dbo.Batch.JVNumber, dbo.Batch.BatchDate, dbo.Batch.BatchDSC, dbo.Batch.BatchJNL, dbo.Batch.BatchStat, dbo.Batch.PostDate, " +
                          "dbo.GLTransactions.BatchNo, dbo.GLTransactions.GLAccount, dbo.GLTransactions.TRANSREF, dbo.GLTransactions.TRANSDATE, " +
                          "dbo.GLTransactions.CurrencyType, dbo.GLTransactions.Rate, dbo.GLTransactions.TRANSUnit, dbo.GLAccounts.AccountName, dbo.Batch.BatchPRD," +
                          "dbo.Batch.REVBatch, dbo.GLJournalCodes.JournalDescription, dbo.Batch.UserID, dbo.Batch.REVBatchNo, dbo.Batch.REVBatchPRD," +
                          "dbo.Batch.AllocationCode, dbo.GLTransactions.Amount, dbo.GLTransactions.AmountLC, dbo.GLTransactions.ProjectCode," +
                          "dbo.Batch.PropertyCode FROM dbo.Batch INNER JOIN " +
                          "dbo.GLTransactions ON dbo.Batch.BatchNo = dbo.GLTransactions.BatchNo INNER JOIN " +
                          "dbo.GLAccounts ON dbo.GLTransactions.GLAccount = dbo.GLAccounts.AccountNumber INNER JOIN " +
                          "dbo.GLJournalCodes ON dbo.Batch.BatchJNL = dbo.GLJournalCodes.JournalCode where dbo.Batch.BatchSRC = 'GL' AND (dbo.GLTransactions.SortNO <> 0) AND Batch.BatchDate Between '" + string.Format(GeneralFunctions.Format_Date, dtp_from.Value.Date) + "' AND '" + string.Format(GeneralFunctions.Format_Date, dtp_to.Value.Date) + "'";
                txtBatchStat = "Both";
                if (rdb_post.Checked == true)
                {
                    s2 = s2 + " AND Batch.BatchStat = 'P'";
                    txtBatchStat = "Posted Batches";
                }
                else if (rdb_unpost.Checked == true)
                {
                    s2 = s2 + " AND Batch.BatchStat = 'U'";
                    txtBatchStat = "UnPosted Batches";
                }
                if (ListSelect.Items.Count > 0)
                {
                    s2 = s2 + " AND GLJournalCodes.JournalDescription IN ('";
                    string s = "";
                    foreach (object ob in ListSelect.Items)
                    {
                        s2 = s2 + s + ob.ToString() + "'";
                        s = ",'";
                    }
                    s2 = s2 + ")";
                }
                //if (chkrange.Checked == true)
                //    s2 = s2 + "AND GLTransactions.BatchNo Between '" + int.Parse(txtboxFrom.Text) + "' AND '" + int.Parse(txtboxto.Text) + "'";
                commandReport2.CommandText = s2;
                try
                {
                    readerReport2 = commandReport2.ExecuteReader();
                    readerReport2.Close();
                }
                catch (Exception ex)
                { }
                if (rdbdetails.Checked == true)
                {
                    RptJournalDet rpt = new RptJournalDet();
                    rpt.ShowDialog();
                }
                else if (rdbsummer.Checked == true)
                {
                    RptJournalAcc rpt = new RptJournalAcc();
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

        private void ListAvailable_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void ListSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListSelect_DoubleClick(object sender, EventArgs e)
        {
            button3_Click(sender, e);

        }

        private void ListAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}