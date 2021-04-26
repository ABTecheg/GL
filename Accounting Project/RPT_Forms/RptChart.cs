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
    public partial class RptChart : Form
    {
        public RptChart()
        {
            InitializeComponent();
        }
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbGeneralSetup;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        public static int InYear = 0;
        private SqlConnection connectReport2;
        private SqlDataReader readerReport2;
        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                 connectReport2 = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand commandReport2 = new SqlCommand();


                connectReport2.Open();
                if (rdball.Checked == false && rdbonly.Checked == false)
                {
                    MessageBox.Show("Choose type of report", "General Ledger");
                    return;
                }
                if (rdnumber.Checked == false && rdname.Checked == false && rdType.Checked == false)
                {
                    MessageBox.Show("Choose Display of report", "General Ledger");
                    return;
                }

                commandReport2 = new SqlCommand();
                commandReport2.Connection = connectReport2;
                commandReport2.CommandType = CommandType.Text;

                string acc = txt_AccountNumber1.ToString();
                acc = acc.Remove(0, 41).Trim();


                commandReport2.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BudgetPlanning]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View ChartOfAccount";
                try
                {
                    readerReport2 = commandReport2.ExecuteReader();
                    readerReport2.Close();
                }
                catch (Exception ex)
                { }

                InYear = dtpIN.Value.Year;
                string s2 = "";
                s2 = "Create View ChartOfAccount AS SELECT TOP 100 PERCENT  dbo.GLAccounts.AccountNumber, dbo.GLAccounts.AccountName, dbo.GLAccounts.AccountTypeName, dbo.GLAccounts.Active,dbo.GLTotals.BeginningBalance FROM dbo.GLAccounts INNER JOIN dbo.GLTotals ON dbo.GLAccounts.AccountNumber = dbo.GLTotals.AccountNumber WHERE (dbo.GLTotals.FiscalYear = '" + dtpIN.Value.Year + "')";
                if (rdball.Checked == true && chkrange.Checked == true)
                    s2 = s2 + " And GLAccounts.AccountNumber like '" + acc + "'";
                if (rdbonly.Checked == true && chkrange.Checked == true)
                    s2 = s2 + " And GLAccounts.AccountNumber like '" + acc + "' AND GLAccounts.Active = '1'";
                if (rdbonly.Checked == true && chkrange.Checked == false)
                    s2 = s2 + " And GLAccounts.Active = '1' ";
                if (rdnumber.Checked == true)
                    s2 = s2 + " ORDER BY dbo.GLAccounts.AccountNumber";
                if (rdname.Checked == true)
                    s2 = s2 + " ORDER BY dbo.GLAccounts.AccountName";
                if (rdType.Checked == true)
                    s2 = s2 + " ORDER BY dbo.GLAccounts.AccountTypeName";

                commandReport2.CommandText = s2;
                try
                {
                    readerReport2 = commandReport2.ExecuteReader();
                    readerReport2.Close();
                }
                catch (Exception ex)
                { }
                Rptchartofacc rpt = new Rptchartofacc();

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

        private void RptChart_Load(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS1.GeneralSetup);
            foreach (DataRow dr in dbAccountingProjectDS1.GeneralSetup.Rows)
            {
                txt_AccountNumber1.Mask = dr["AccountNumberFormat"].ToString();
                Rptchartofacc.decmial = short.Parse(dr["DecimalPointsNumber"].ToString());

            }
            rdball.Checked = true;
            rdnumber.Checked = true;
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
            this.Text = obj_interface_language.ChartofAccountReport;
            this.label4.Text = obj_interface_language.labelAccountNumber;
            this.groupBox1.Text = obj_interface_language.groupReportOptions;
            this.groupBox2.Text = obj_interface_language.groupAccountRange;
            this.rdball.Text = obj_interface_language.rdbAllAccounts;
            this.rdbonly.Text = obj_interface_language.rdbActiveAccountsOnly;
            this.chkrange.Text = obj_interface_language.chkPrintByAccountRange;
            this.btnReport.Text = obj_interface_language.btnReport;

        }
    }
}