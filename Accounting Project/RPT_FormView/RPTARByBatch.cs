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
    public partial class RPTARByBatch : Form
    {
        public RPTARByBatch()
        {
            InitializeComponent();
        }
        public static short decmial = 0;

        private void RPTARByBatch_Load(object sender, EventArgs e)
        {
            CR_ARTranBatch rptARbatch = new CR_ARTranBatch();
            SqlConnection conTrial = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand comTrial = new SqlCommand();
            SqlDataAdapter adapTrial = new SqlDataAdapter();

            DataSet dsTrial = new DataSet();
            dsTrial.Clear();
            try
            {
                comTrial.Connection = conTrial;
                comTrial.CommandType = CommandType.Text;
                comTrial.CommandText = "Select * From RptARTrans";
                adapTrial.SelectCommand = comTrial;
                adapTrial.Fill(dsTrial, "RptARTrans");

                rptARbatch.SetDataSource(dsTrial);

                CrystalDecisions.CrystalReports.Engine.TextObject txtFrom;
                CrystalDecisions.CrystalReports.Engine.TextObject txtTo;
                CrystalDecisions.CrystalReports.Engine.TextObject txtBatchStat;


                txtFrom = (CrystalDecisions.CrystalReports.Engine.TextObject)rptARbatch.ReportDefinition.ReportObjects["txtFrom"];
                txtFrom.Text = RptARTranBatch.txtFrom;

                txtTo = (CrystalDecisions.CrystalReports.Engine.TextObject)rptARbatch.ReportDefinition.ReportObjects["txtTo"];
                txtTo.Text = RptARTranBatch.txtTo;

                txtBatchStat = (CrystalDecisions.CrystalReports.Engine.TextObject)rptARbatch.ReportDefinition.ReportObjects["txtBatchStat"];
                txtBatchStat.Text = RptARTranBatch.txtBatchStat;

                CrystalDecisions.CrystalReports.Engine.FieldObject AmountLC1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofAmountLC1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofAmountLC2;

                AmountLC1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptARbatch.ReportDefinition.ReportObjects["AmountLC1"];
                SumofAmountLC1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptARbatch.ReportDefinition.ReportObjects["SumofAmountLC1"];
                SumofAmountLC2 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptARbatch.ReportDefinition.ReportObjects["SumofAmountLC2"];

                AmountLC1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofAmountLC1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofAmountLC2.FieldFormat.NumericFormat.DecimalPlaces = decmial;

                this.crystalReportViewer1.ReportSource = rptARbatch;
                crystalReportViewer1.Zoom(100);


            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }

        }
    }
}