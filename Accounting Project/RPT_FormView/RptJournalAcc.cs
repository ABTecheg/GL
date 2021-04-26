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
    public partial class RptJournalAcc : Form
    {
        public RptJournalAcc()
        {
            InitializeComponent();
        }
        public static short decmial = 0;
        private void RptJournalAcc_Load(object sender, EventArgs e)
        {
            RptJournalAccOnly rptjnl = new RptJournalAccOnly();
            SqlConnection conTrial = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand comTrial = new SqlCommand();
            SqlDataAdapter adapTrial = new SqlDataAdapter();

            DataSet dsTrial = new DataSet();
            dsTrial.Clear();
            try
            {
                comTrial.Connection = conTrial;
                comTrial.CommandType = CommandType.Text;
                comTrial.CommandText = "Select * From RptJournal";
                adapTrial.SelectCommand = comTrial;
                adapTrial.Fill(dsTrial, "RptJournal");

                rptjnl.SetDataSource(dsTrial);

                CrystalDecisions.CrystalReports.Engine.TextObject txtFrom;
                CrystalDecisions.CrystalReports.Engine.TextObject txtTo;
                CrystalDecisions.CrystalReports.Engine.TextObject txtBatchStat;


                txtFrom = (CrystalDecisions.CrystalReports.Engine.TextObject)rptjnl.ReportDefinition.ReportObjects["txtFrom"];
                txtFrom.Text = RptJournal.txtFrom;

                txtTo = (CrystalDecisions.CrystalReports.Engine.TextObject)rptjnl.ReportDefinition.ReportObjects["txtTo"];
                txtTo.Text = RptJournal.txtTo;

                txtBatchStat = (CrystalDecisions.CrystalReports.Engine.TextObject)rptjnl.ReportDefinition.ReportObjects["txtBatchStat"];
                txtBatchStat.Text = RptJournal.txtBatchStat;

                CrystalDecisions.CrystalReports.Engine.FieldObject TRANSDebitLC1;
                CrystalDecisions.CrystalReports.Engine.FieldObject TRANSCreditLC1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTRANSDebitLC2;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTRANSCreditLC2;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTRANSDebitLC1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTRANSCreditLC1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTRANSDebitLC3;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTRANSCreditLC3;

                TRANSDebitLC1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptjnl.ReportDefinition.ReportObjects["Debit1"];
                TRANSCreditLC1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptjnl.ReportDefinition.ReportObjects["Credit1"];
                SumofTRANSDebitLC2 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptjnl.ReportDefinition.ReportObjects["SumofTRANSDebitLC2"];
                SumofTRANSCreditLC2 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptjnl.ReportDefinition.ReportObjects["SumofTRANSCreditLC2"];
                SumofTRANSDebitLC1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptjnl.ReportDefinition.ReportObjects["SumofTRANSDebitLC1"];
                SumofTRANSCreditLC1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptjnl.ReportDefinition.ReportObjects["SumofTRANSCreditLC1"];
                SumofTRANSDebitLC3 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptjnl.ReportDefinition.ReportObjects["SumofTRANSDebitLC3"];
                SumofTRANSCreditLC3 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptjnl.ReportDefinition.ReportObjects["SumofTRANSCreditLC3"];

                TRANSDebitLC1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                TRANSCreditLC1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTRANSDebitLC2.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTRANSCreditLC2.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTRANSDebitLC1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTRANSCreditLC1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTRANSDebitLC3.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTRANSCreditLC3.FieldFormat.NumericFormat.DecimalPlaces = decmial;

                this.crystalReportViewer1.ReportSource = rptjnl;
                crystalReportViewer1.Zoom(100);


            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }

        }
    }
}