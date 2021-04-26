using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Accounting_GeneralLedger {
    public partial class ENDYear : Form {
        public ENDYear() {
            InitializeComponent();
        }
        private SqlConnection sqlconn;
        private SqlDataAdapter sqladap;
        private SqlCommandBuilder sqlcommbuild;
        private dbAccountingProjectDS dbAccountingProjectDS;
        public static string SpecificPeriod;
        public static int SpecificYear;
        /*******************************************/
        private SqlConnection sqlcon2;
        private SqlDataAdapter adaptertbBatch;
        private SqlDataAdapter adaptertbGLTotals;
        private SqlDataAdapter adaptertbMYGLTransactions;
        private SqlCommandBuilder cmdBuilderGLTotals;
        private SqlCommandBuilder cmdBuilderBatch;
        private SqlCommandBuilder cmdMyJVTransactions;
        /*******************************************/

        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;


        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ENDYear_Load(object sender, EventArgs e) {
            refill();
            refillyear();
            if (GeneralFunctions.languagechioce != "") {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }

        }
        private void refill()
        {
            dbAccountingProjectDS = new dbAccountingProjectDS();

            sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);

            adaptertbGLTotals = new SqlDataAdapter("Select * from GLTotals", sqlcon2);
            adaptertbBatch = new SqlDataAdapter("Select * From Batch", sqlcon2);
            adaptertbMYGLTransactions = new SqlDataAdapter("Select * From GLTransactions", sqlcon2);

            cmdBuilderGLTotals = new SqlCommandBuilder(adaptertbGLTotals);
            cmdBuilderBatch = new SqlCommandBuilder(adaptertbBatch);
            cmdMyJVTransactions = new SqlCommandBuilder(adaptertbMYGLTransactions);

            adaptertbGLTotals.Fill(dbAccountingProjectDS.GLTotals);
            adaptertbBatch.Fill(dbAccountingProjectDS.Batch);
            adaptertbMYGLTransactions.Fill(dbAccountingProjectDS.GLTransactions);
        }
        private void update_language_interface() {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.formEndYear;
            this.lblFiscalPeriod.Text = obj_interface_language.lblEndYearFiscalYear;
            this.btnReport.Text = obj_interface_language.btnEndYearReport;
            this.btnExit.Text = obj_interface_language.btnEndYearExit;
        }


        private void cbFiscalYear_DropDown(object sender, System.EventArgs e) {

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
            msg = GeneralFunctions.CheckLockTables("", "JVEndYearAdjustments", "", "Open");
            if (msg != "")
            {
                MessageBox.Show("JVEndYearAdjustments Open By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            msg = GeneralFunctions.CheckLockTables("GLTotals", "", "", "Edit");
            if (msg != "")
            {
                MessageBox.Show("GLTotals Used By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            GeneralFunctions.LockTables("GLFiscalPeriodSetup", "ENDYear", "", "Edit");
            if (DialogResult.No == MessageBox.Show("Do you want to continue Ending Year " + int.Parse(cbFiscalYear.Text) + " ? ", "Ending Year", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;

            SqlConnection sqlDOEndMonthConnection;
            SqlCommand sqlDoEndMonthCommand;
            int x;
            /*******************************/
            SqlConnection sqlcheckAllPeriodsConnection = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcheckAllPeriodsConnection.Open();
            SqlCommand sqlCountPeriods = new SqlCommand("Select MAX(PeriodNumber) From GLFiscalPeriod Where YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlcheckAllPeriodsConnection);
            int count = 0;
            count = Convert.ToInt32(sqlCountPeriods.ExecuteScalar());
            int countPeriods = 0;
            string PeriodsNumbers = "";
            SqlCommand sqlcheckAllPeriodsCommand;
            SqlDataReader sqlREAD;
            for (int i = 1; i <= count; i++)
            {
                sqlcheckAllPeriodsCommand = new SqlCommand("Select PeriodDescription From GLFiscalPeriod WHere YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + " AND PeriodDescription='Period " + i + "' AND Status='OPEN'", sqlcheckAllPeriodsConnection);
                ///countPeriods = sqlcheckAllPeriodsCommand.ExecuteNonQuery();
                sqlREAD = sqlcheckAllPeriodsCommand.ExecuteReader();
                if (sqlREAD.HasRows)
                {
                    while (sqlREAD.Read())
                    {

                        if (countPeriods == 0)
                            PeriodsNumbers = sqlREAD.GetString(0);
                        else
                            PeriodsNumbers = PeriodsNumbers + " , " + sqlREAD.GetString(0);
                        ++countPeriods;
                    }
                }
                sqlREAD.Close();

            }
            if (PeriodsNumbers != "")
            {
                MessageBox.Show("There was periods opened " + PeriodsNumbers + " you must closed them first");
                return;
            }
            else
            {

                SpecificYear = Convert.ToInt32(cbFiscalYear.Text);
                SqlConnection sqlCheckFiscalConnection = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand sqlCheckFiscalCommand;
                sqlCheckFiscalCommand = new SqlCommand("Select FiscalYear From GLFiscalPeriodSetup WHERE FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + " + 1", sqlCheckFiscalConnection);
                sqlCheckFiscalConnection.Open();
                SqlDataReader sqlRead2;
                sqlRead2 = sqlCheckFiscalCommand.ExecuteReader();
                if (sqlRead2.HasRows)
                {
                    while (sqlRead2.Read())
                    {
                        SqlConnection sqlConnectToGLTotals = new SqlConnection(GeneralFunctions.ConnectionString);
                        sqlConnectToGLTotals.Open();
                        SqlCommand sqlCommandOfGlTotals;
                        SqlDataReader sqlReadFromGLTotals;
                        SqlCommand sqlCommandOfGLAccount;
                        SqlDataReader sqlReadFromGLAccounts;
                        SqlCommand sqlUpdateData;
                        SqlConnection sqlNewConnection;
                        SqlConnection sqlnewConnection2;
                        int countUpdatedData = 0;
                        sqlNewConnection = new SqlConnection(GeneralFunctions.ConnectionString);
                        sqlNewConnection.Open();
                        sqlnewConnection2 = new SqlConnection(GeneralFunctions.ConnectionString);
                        sqlnewConnection2.Open();

                        if (count == 12)
                        {
                            sqlCommandOfGlTotals = new SqlCommand("Select * From GLTotals Where FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlConnectToGLTotals);
                            sqlReadFromGLTotals = sqlCommandOfGlTotals.ExecuteReader();
                            if (sqlReadFromGLTotals.HasRows)
                            {
                                while (sqlReadFromGLTotals.Read())
                                {
                                    sqlCommandOfGLAccount = new SqlCommand("Select AccountTypeName From GLAccounts WHERE AccountNumber='" + sqlReadFromGLTotals.GetString(1) + "'", sqlNewConnection);
                                    sqlReadFromGLAccounts = sqlCommandOfGLAccount.ExecuteReader();
                                    if (sqlReadFromGLAccounts.HasRows)
                                    {
                                        while (sqlReadFromGLAccounts.Read())
                                        {
                                            if (sqlReadFromGLAccounts.GetString(0) == "Assets" || sqlReadFromGLAccounts.GetString(0) == "Liability" || sqlReadFromGLAccounts.GetString(0) == "Equity")
                                            {
                                                sqlUpdateData = new SqlCommand("Update GLTotals SET BeginningBalance=" + (sqlReadFromGLTotals.GetSqlDouble(15) + sqlReadFromGLTotals.GetSqlDouble(17)) + " , PeriodBalance1=" + (sqlReadFromGLTotals.GetSqlDouble(15) + sqlReadFromGLTotals.GetSqlDouble(17)) + " WHERE AccountNumber='" + sqlReadFromGLTotals.GetString(1) + "' AND FiscalYear=" + (Convert.ToInt32(cbFiscalYear.Text) + 1) + "", sqlnewConnection2);
                                                countUpdatedData = sqlUpdateData.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    sqlReadFromGLAccounts.Close();
                                }
                            }

                        }
                        else if (count == 13)
                        {
                            sqlCommandOfGlTotals = new SqlCommand("Select * From GLTotals Where FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlConnectToGLTotals);
                            sqlReadFromGLTotals = sqlCommandOfGlTotals.ExecuteReader();
                            if (sqlReadFromGLTotals.HasRows)
                            {
                                while (sqlReadFromGLTotals.Read())
                                {
                                    sqlCommandOfGLAccount = new SqlCommand("Select AccountTypeName From GLAccounts WHERE AccountNumber='" + sqlReadFromGLTotals.GetString(1) + "'", sqlNewConnection);
                                    sqlReadFromGLAccounts = sqlCommandOfGLAccount.ExecuteReader();
                                    if (sqlReadFromGLAccounts.HasRows)
                                    {
                                        while (sqlReadFromGLAccounts.Read())
                                        {
                                            if (sqlReadFromGLAccounts.GetString(0) == "Assets" || sqlReadFromGLAccounts.GetString(0) == "Liability" || sqlReadFromGLAccounts.GetString(0) == "Equity")
                                            {
                                                sqlUpdateData = new SqlCommand("Update GLTotals SET BeginningBalance=" + (sqlReadFromGLTotals.GetSqlDouble(16) + sqlReadFromGLTotals.GetSqlDouble(17)) + " , PeriodBalance1=" + (sqlReadFromGLTotals.GetSqlDouble(16) + sqlReadFromGLTotals.GetSqlDouble(17)) + " WHERE AccountNumber='" + sqlReadFromGLTotals.GetString(1) + "' AND FiscalYear=" + (Convert.ToInt32(cbFiscalYear.Text) + 1) + "", sqlnewConnection2);
                                                countUpdatedData = sqlUpdateData.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    sqlReadFromGLAccounts.Close();
                                }
                            }


                            sqlnewConnection2.Close();
                            sqlNewConnection.Close();
                        }
                    }

                    sqlDOEndMonthConnection = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlDoEndMonthCommand = new SqlCommand("Update GLFiscalPeriodSetup SET Status='CLOSED' WHERE FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlDOEndMonthConnection);
                    sqlDOEndMonthConnection.Open();
                    x = sqlDoEndMonthCommand.ExecuteNonQuery();
                    sqlDOEndMonthConnection.Close();
                    MessageBox.Show("End Year Successfully", "Valid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refill();
                    refillyear();

                }
                else
                {
                    MessageBox.Show("Please Make fiscal year for the next year first", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            GeneralFunctions.UnLockTable("", "ENDYear", "", "Edit");
        }

        private void refillyear()
        {
            SqlConnection sqlCheckConnection = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand sqlCheckCommand = new SqlCommand("Select * From GLFiscalPeriodSetup WHERE Status='OPEN'", sqlCheckConnection);
            sqlCheckConnection.Open();
            SqlDataReader sqlread = sqlCheckCommand.ExecuteReader();
            if (sqlread.HasRows)
            {
                sqlconn = new SqlConnection(GeneralFunctions.ConnectionString);
                sqladap = new SqlDataAdapter("Select * From GLFiscalPeriodSetup WHERE Status='OPEN'", sqlconn);
                sqlcommbuild = new SqlCommandBuilder(sqladap);
                //dbAccountingProjectDS = new dbAccountingProjectDS();
                sqladap.Fill(dbAccountingProjectDS.GLFiscalPeriodSetup);
                cbFiscalYear.Items.Clear();
                foreach (DataRow dr in dbAccountingProjectDS.GLFiscalPeriodSetup.Rows)
                {
                    cbFiscalYear.Items.Add(dr["FiscalYear"].ToString());
                    cbFiscalYear.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("Please check Fiscal year fisrt");
                cbFiscalYear.Items.Clear();
                return;
            }
        }
        private void cbFiscalYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiscalYear.Items.Count > 0)
                cbFiscalYear.SelectedIndex = 0;

        }

        private void cbFiscalYear_DropDownClosed(object sender, EventArgs e)
        {
            if (cbFiscalYear.Items.Count > 0)
                cbFiscalYear.SelectedIndex = 0;

        }

        private void ENDYear_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralFunctions.UnLockTable("", "ENDYear", "", "");
        }
    }
}