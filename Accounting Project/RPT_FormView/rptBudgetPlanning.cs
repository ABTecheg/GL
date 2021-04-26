using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Accounting_GeneralLedger {
    public partial class rptBudgetPlanning : Form {
        public rptBudgetPlanning() {
            InitializeComponent();
        }

        private void rptStandardBalanceSheet_Load(object sender, EventArgs e) {
            BudgetPlanningReport rpt = new BudgetPlanningReport();
            SqlConnection con = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand com = new SqlCommand();
            SqlDataAdapter adap = new SqlDataAdapter();

            DataSet ds = new DataSet();
            ds.Clear();
            try {
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com.CommandText = "Select * From BudgetPlanning";
                adap.SelectCommand = com;
                adap.Fill(ds, "BudgetPlanning");

                rpt.SetDataSource(ds);

                CrystalDecisions.CrystalReports.Engine.TextObject fiscalYear;
                fiscalYear = (CrystalDecisions.CrystalReports.Engine.TextObject) rpt.ReportDefinition.ReportObjects["fYear"];//"fYear"
                fiscalYear.Text = reportGenerator.fiscalYearSetup;
                CViewer1.ReportSource = rpt;
                CViewer1.Zoom(100);
            }
            catch (Exception e2) {
                MessageBox.Show(e2.Message);
            }
        }
    }
}