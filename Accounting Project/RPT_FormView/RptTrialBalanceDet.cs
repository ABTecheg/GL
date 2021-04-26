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
    public partial class RptTrialBalanceS : Form
    {
        public RptTrialBalanceS()
        {
            InitializeComponent();
        }
        public static short decmial = 0;

        private void RptTrialBalanceDet_Load(object sender, EventArgs e)
        {
            RptTrialBalanceDetail rpttrialdet = new RptTrialBalanceDetail();
            SqlConnection conTrial = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand comTrial = new SqlCommand();
            SqlDataAdapter adapTrial = new SqlDataAdapter();

            DataSet dsTrial = new DataSet();
            dsTrial.Clear();
            try
            {
                comTrial.Connection = conTrial;
                comTrial.CommandType = CommandType.Text;
                comTrial.CommandText = "Select * From RptGLTrialBalance";
                adapTrial.SelectCommand = comTrial;
                adapTrial.Fill(dsTrial, "RptGLTrialBalance");

                rpttrialdet.SetDataSource(dsTrial);

                CrystalDecisions.CrystalReports.Engine.TextObject txtFrom;
                txtFrom = (CrystalDecisions.CrystalReports.Engine.TextObject)rpttrialdet.ReportDefinition.ReportObjects["Text15"];
                txtFrom.Text = RptGLTrialBalance.txtFrom;

                CrystalDecisions.CrystalReports.Engine.FieldObject OpeningBalance1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTRANSDebitLC1;
                CrystalDecisions.CrystalReports.Engine.FieldObject TRANSDebitLC1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTRANSCreditLC1;
                CrystalDecisions.CrystalReports.Engine.FieldObject TRANSCreditLC1;
                CrystalDecisions.CrystalReports.Engine.FieldObject Net1;
                CrystalDecisions.CrystalReports.Engine.FieldObject Endbalance1;

                OpeningBalance1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialdet.ReportDefinition.ReportObjects["SumofOpenBalance1"];
                SumofTRANSDebitLC1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialdet.ReportDefinition.ReportObjects["SumofDebit1"];
                TRANSDebitLC1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialdet.ReportDefinition.ReportObjects["Debit1"];
                SumofTRANSCreditLC1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialdet.ReportDefinition.ReportObjects["MaxofCredit1"];
                TRANSCreditLC1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialdet.ReportDefinition.ReportObjects["Credit1"];
                Net1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialdet.ReportDefinition.ReportObjects["SumofAmountLC1"];
                Endbalance1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialdet.ReportDefinition.ReportObjects["SumofEndBalance1"];

                OpeningBalance1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTRANSDebitLC1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                TRANSDebitLC1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTRANSCreditLC1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                TRANSCreditLC1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                Net1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                Endbalance1.FieldFormat.NumericFormat.DecimalPlaces = decmial;

                this.crystalReportViewer1.ReportSource = rpttrialdet;
                crystalReportViewer1.Zoom(100);


            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
        }
    }
}