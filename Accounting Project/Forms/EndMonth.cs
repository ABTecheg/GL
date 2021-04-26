using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Accounting_GeneralLedger {
    public partial class EndMonth : Form {
        public EndMonth() {
            InitializeComponent();
        }


        private dbAccountingProjectDS dbAccountingProjectDS;
        public static string SpecificPeriod;
        public static int SpecificYear;
        /*******************************************/
        private SqlConnection sqlcon2;
        private SqlDataAdapter adaptertbBatch;
        private SqlDataAdapter adaptertbGLTotals;
        private SqlDataAdapter adaptertbMYGLTransactions;
        private SqlDataAdapter adaptertFiscalPeriod;
        private SqlCommandBuilder cmdBuilderFiscalPeriod;
        private SqlCommandBuilder cmdBuilderGLTotals;
        private SqlCommandBuilder cmdBuilderBatch;
        private SqlCommandBuilder cmdMyJVTransactions;
        /*******************************************/

        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;


        private void EndMonth_Load(object sender, EventArgs e) {

            refill();
            refillprd();
            if (GeneralFunctions.languagechioce != "") {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }
        }

        private void update_language_interface() {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.formEndPeriod;
            this.lblFiscalPeriod.Text = obj_interface_language.lblEndPeriodFiscalPeriod;
            this.btnReport.Text = obj_interface_language.btnEndPeriodReport;
            this.btnExit.Text = obj_interface_language.btnEndPeriodExit;
        }
        private void refill()
        {
            dbAccountingProjectDS = new dbAccountingProjectDS();

            sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);

            adaptertbGLTotals = new SqlDataAdapter("Select * from GLTotals", sqlcon2);
            adaptertbBatch = new SqlDataAdapter("Select * From Batch", sqlcon2);
            adaptertbMYGLTransactions = new SqlDataAdapter("Select * From GLTransactions", sqlcon2);
            adaptertFiscalPeriod = new SqlDataAdapter("Select * From GLFiscalPeriod where Status = 'OPEN'", sqlcon2);

            cmdBuilderFiscalPeriod = new SqlCommandBuilder(adaptertFiscalPeriod);
            cmdBuilderGLTotals = new SqlCommandBuilder(adaptertbGLTotals);
            cmdBuilderBatch = new SqlCommandBuilder(adaptertbBatch);
            cmdMyJVTransactions = new SqlCommandBuilder(adaptertbMYGLTransactions);

            adaptertFiscalPeriod.Fill(dbAccountingProjectDS.GLFiscalPeriod);
            adaptertbGLTotals.Fill(dbAccountingProjectDS.GLTotals);
            adaptertbBatch.Fill(dbAccountingProjectDS.Batch);
            adaptertbMYGLTransactions.Fill(dbAccountingProjectDS.GLTransactions);
        }

        private void refillprd()
        {
            SqlConnection sqlCheckConnection = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand sqlCheckCommand = new SqlCommand("Select * From GLFiscalPeriod WHERE Status='OPEN'", sqlCheckConnection);
            sqlCheckConnection.Open();
            SqlDataReader sqlread = sqlCheckCommand.ExecuteReader();
            if (sqlread.HasRows)
            {

                cbFiscalPeriod.Items.Clear();
                foreach (DataRow dr in dbAccountingProjectDS.GLFiscalPeriod.Rows)
                {
                    cbFiscalPeriod.Items.Add(dr["PeriodDescription"].ToString() + "/" + Convert.ToDateTime(dr["PeriodStartDate"].ToString()).Year.ToString());
                }
                cbFiscalPeriod.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Please make fiscal year first for current year");
                cbFiscalPeriod.Items.Clear();
                return;
            }
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            string msg = GeneralFunctions.CheckLockTables("", "Allocation Run", "", "Open");
            if (msg != "")
            {
                MessageBox.Show("Allocation Run Open By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            msg = GeneralFunctions.CheckLockTables("", "APTransactions", "", "Open");
            if (msg != "")
            {
                MessageBox.Show("APTransactions Open By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            msg = GeneralFunctions.CheckLockTables("GLTotals", "", "", "Edit");
            if (msg != "")
            {
                MessageBox.Show("GLTotals Used By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            msg = GeneralFunctions.CheckLockTables("", "ARTransactions", "", "Open");
            if (msg != "")
            {
                MessageBox.Show("ARTransactions Open By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            msg = GeneralFunctions.CheckLockTables("", "ARPaymentsTransactions", "", "Open");
            if (msg != "")
            {
                MessageBox.Show("ARPaymentsTransactions Open By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            msg = GeneralFunctions.CheckLockTables("", "JVTransactions", "", "Open");
            if (msg != "")
            {
                MessageBox.Show("JVTransactions Open By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            GeneralFunctions.LockTables("GLFiscalPeriod", "EndMonth", "", "Edit");
            if (cbFiscalPeriod.Items.Count == 0)
                return;
            string prd = cbFiscalPeriod.Text.Substring(0, cbFiscalPeriod.Text.IndexOf('/'));
            int Y = int.Parse(cbFiscalPeriod.Text.Substring(cbFiscalPeriod.Text.IndexOf('/') + 1));
            if (DialogResult.No == MessageBox.Show("Do you want to continue End " + prd + " ? ", "Ending Period", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            SqlConnection sqlcheckAllPeriodsConnection = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcheckAllPeriodsConnection.Open();
            SqlCommand sqlCountPeriods = new SqlCommand("Select MAX(PeriodNumber) From GLFiscalPeriod Where YEAR(PeriodStartDate)=" + Y + "", sqlcheckAllPeriodsConnection);
            int count = 0;
            count = Convert.ToInt32(sqlCountPeriods.ExecuteScalar());
            sqlcheckAllPeriodsConnection.Close();
            SqlConnection sqlDOEndMonthConnection;
            SqlCommand sqlDoEndMonthCommand;
            SqlDataReader sqlReadPeriod;
            SqlConnection sqlInnerConnection;
            SqlCommand sqlInnerCommand;
            int x;
            /*******************************/
            SqlConnection sqlCheckUnpostedBatchesConnection = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand sqlCheckUnpostedBatchesCommand = new SqlCommand("Select * From Batch WHERE BatchStat Like 'U%' AND BatchPRD='" + prd + "' AND YEAR(BatchDate)=" + Y + "", sqlCheckUnpostedBatchesConnection);
            SpecificPeriod = prd;
            SpecificYear = Y;
            //MessageBox.Show("Ending Period " + SpecificYear);
            if (sqlCheckUnpostedBatchesConnection.State == ConnectionState.Open)
                sqlCheckUnpostedBatchesConnection.Close();
            sqlCheckUnpostedBatchesConnection.Open();
            SqlDataReader sqlCheckUnpostedBatchesRead;
            sqlCheckUnpostedBatchesRead = sqlCheckUnpostedBatchesCommand.ExecuteReader();
            if (sqlCheckUnpostedBatchesRead.HasRows)
            {
                ShowUnpostedJV sunp = new ShowUnpostedJV();
                sunp.ShowDialog();
                MessageBox.Show("Can't End This Period Because this Period Containing Batches Un Posted", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                sqlCheckUnpostedBatchesConnection.Close();
                sqlCheckUnpostedBatchesRead.Close();
            }
            else
            {
                sqlCheckUnpostedBatchesConnection.Close();
                sqlCheckUnpostedBatchesRead.Close();
                sqlCheckUnpostedBatchesCommand = new SqlCommand("Select * From GLFiscalPeriodSetup WHERE FiscalYear = " + Convert.ToString(SpecificYear - 1) + " AND Status = 'OPEN'", sqlCheckUnpostedBatchesConnection);
                if (sqlCheckUnpostedBatchesConnection.State == ConnectionState.Open)
                    sqlCheckUnpostedBatchesConnection.Close();
                sqlCheckUnpostedBatchesConnection.Open();
                SqlDataReader sqlChecklastyearRead;
                sqlChecklastyearRead = sqlCheckUnpostedBatchesCommand.ExecuteReader();
                if (sqlChecklastyearRead.HasRows)
                {
                    MessageBox.Show("Can't End This Period Because Year = " + Convert.ToString(SpecificYear - 1) + " Is Open", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    sqlCheckUnpostedBatchesRead.Close();
                    sqlCheckUnpostedBatchesConnection.Close();
                    return;
                }
                sqlCheckUnpostedBatchesRead.Close();
                sqlCheckUnpostedBatchesConnection.Close();
                sqlDOEndMonthConnection = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlDoEndMonthCommand = new SqlCommand("Select PeriodNumber From GLFiscalPeriod WHERE PeriodDescription='" + prd + "' AND YEAR(PeriodStartDate)=" + Y + "", sqlDOEndMonthConnection);
                sqlDOEndMonthConnection.Open();
                sqlReadPeriod = sqlDoEndMonthCommand.ExecuteReader();

                sqlReadPeriod.Read();
                int PeriodID = sqlReadPeriod.GetInt32(0);
                sqlReadPeriod.Close();
                sqlDOEndMonthConnection.Close();
                if (PeriodID != 13 && PeriodID != 12)
                {
                    sqlInnerConnection = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlInnerConnection.Open();
                    sqlInnerCommand = new SqlCommand("Update GLTotals SET PeriodBalance" + Convert.ToString(PeriodID + 1) + "=PeriodBalance" + Convert.ToString(PeriodID + 1) + "+PeriodBalance" + PeriodID.ToString() + " WHERE FiscalYear=" + Y + "", sqlInnerConnection);
                    x = sqlInnerCommand.ExecuteNonQuery();
                    sqlInnerConnection.Close();
                }
                else if (PeriodID == 12 && count == 13)
                {
                    sqlInnerConnection = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlInnerConnection.Open();
                    sqlInnerCommand = new SqlCommand("Update GLTotals SET PeriodBalance" + Convert.ToString(PeriodID + 1) + "=PeriodBalance" + Convert.ToString(PeriodID + 1) + "+PeriodBalance" + PeriodID.ToString() + " WHERE FiscalYear=" + Y + "", sqlInnerConnection);
                    x = sqlInnerCommand.ExecuteNonQuery();
                    sqlInnerConnection.Close();
                }
                sqlDOEndMonthConnection = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlDoEndMonthCommand = new SqlCommand("Update GLFiscalPeriod SET Status='CLOSED' WHERE PeriodDescription='" + prd + "' AND YEAR(PeriodStartDate)=" + Y + "", sqlDOEndMonthConnection);
                sqlDOEndMonthConnection.Open();
                x = sqlDoEndMonthCommand.ExecuteNonQuery();
                sqlDOEndMonthConnection.Close();
                MessageBox.Show("End Period Successfully", "Valid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refill();
                refillprd();
            }
            GeneralFunctions.UnLockTable("", "EndMonth", "", "Edit");
        }
    




        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void cbFiscalPeriod_DropDownClosed(object sender, EventArgs e)
        {
            if (cbFiscalPeriod.Items.Count > 0)
                cbFiscalPeriod.SelectedIndex = 0;
        }

        private void cbFiscalPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiscalPeriod.Items.Count > 0)
                cbFiscalPeriod.SelectedIndex = 0;
        }

        private void EndMonth_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralFunctions.UnLockTable("", "EndMonth", "", "");
        }
    }
}