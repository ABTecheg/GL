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
    public partial class RptBatches : Form
    {
        public RptBatches()
        {
            InitializeComponent();
        }
        public static short decmial = 0;
        private void RepBatches_Load(object sender, EventArgs e)
        {
            RptGLBatches rptglbatch = new RptGLBatches();
            SqlConnection conTrial = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand comTrial = new SqlCommand();
            SqlDataAdapter adapTrial = new SqlDataAdapter();

            DataSet dsTrial = new DataSet();
            dsTrial.Clear();
            try
            {
                comTrial.Connection = conTrial;
                comTrial.CommandType = CommandType.Text;
                comTrial.CommandText = "Select * From RptBatch";
                adapTrial.SelectCommand = comTrial;
                adapTrial.Fill(dsTrial, "RptBatch");

                rptglbatch.SetDataSource(dsTrial);

                CrystalDecisions.CrystalReports.Engine.TextObject txtFrom;
                CrystalDecisions.CrystalReports.Engine.TextObject txtTo;
                CrystalDecisions.CrystalReports.Engine.TextObject txtBatchStat;


                txtFrom = (CrystalDecisions.CrystalReports.Engine.TextObject)rptglbatch.ReportDefinition.ReportObjects["txtFrom"];
                txtFrom.Text = RptGLBatch.txtFrom;

                txtTo = (CrystalDecisions.CrystalReports.Engine.TextObject)rptglbatch.ReportDefinition.ReportObjects["txtTo"];
                txtTo.Text = RptGLBatch.txtTo;

                txtBatchStat = (CrystalDecisions.CrystalReports.Engine.TextObject)rptglbatch.ReportDefinition.ReportObjects["txtBatchStat"];
                txtBatchStat.Text = RptGLBatch.txtBatchStat;

                CrystalDecisions.CrystalReports.Engine.FieldObject TRANSDebitLC1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTRANSDebitLC1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTRANSDebitLC2;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTRANSCreditLC2;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTRANSCreditLC1;
                CrystalDecisions.CrystalReports.Engine.FieldObject TRANSCreditLC1;
                CrystalDecisions.CrystalReports.Engine.FieldObject TRANSUnit1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTRANSUnit1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTRANSUnit2;

                TRANSDebitLC1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptglbatch.ReportDefinition.ReportObjects["Debit1"];
                SumofTRANSDebitLC1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptglbatch.ReportDefinition.ReportObjects["SumofTRANSDebitLC1"];
                SumofTRANSDebitLC2 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptglbatch.ReportDefinition.ReportObjects["SumofTRANSDebitLC2"];
                SumofTRANSCreditLC2 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptglbatch.ReportDefinition.ReportObjects["SumofTRANSCreditLC2"];
                SumofTRANSCreditLC1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptglbatch.ReportDefinition.ReportObjects["SumofTRANSCreditLC1"];
                TRANSCreditLC1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptglbatch.ReportDefinition.ReportObjects["Credit1"];
                TRANSUnit1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptglbatch.ReportDefinition.ReportObjects["TRANSUnit1"];
                SumofTRANSUnit1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptglbatch.ReportDefinition.ReportObjects["SumofTRANSUnit1"];
                SumofTRANSUnit2 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptglbatch.ReportDefinition.ReportObjects["SumofTRANSUnit2"];

                TRANSDebitLC1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTRANSDebitLC1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTRANSDebitLC2.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTRANSCreditLC2.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTRANSCreditLC1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                TRANSCreditLC1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                TRANSUnit1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTRANSUnit1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTRANSUnit2.FieldFormat.NumericFormat.DecimalPlaces = decmial;

                this.crystalReportViewer1.ReportSource = rptglbatch;
                crystalReportViewer1.Zoom(100);


            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }

        }
    }
}