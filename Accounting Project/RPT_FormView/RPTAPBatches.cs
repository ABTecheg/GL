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
    public partial class RPTAPBatches : Form
    {
        public RPTAPBatches()
        {
            InitializeComponent();
        }
        public static short decmial = 0;

        private void RPTAPBatches_Load(object sender, EventArgs e)
        {
            RPTAPBatchs rptAPbatch = new RPTAPBatchs();
            SqlConnection conTrial = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand comTrial = new SqlCommand();
            SqlDataAdapter adapTrial = new SqlDataAdapter();

            DataSet dsTrial = new DataSet();
            dsTrial.Clear();
            try
            {
                comTrial.Connection = conTrial;
                comTrial.CommandType = CommandType.Text;
                comTrial.CommandText = "Select * From RPTAPBatch";
                adapTrial.SelectCommand = comTrial;
                adapTrial.Fill(dsTrial, "RPTAPBatch");

                rptAPbatch.SetDataSource(dsTrial);

                CrystalDecisions.CrystalReports.Engine.TextObject txtFrom;
                CrystalDecisions.CrystalReports.Engine.TextObject txtTo;
                CrystalDecisions.CrystalReports.Engine.TextObject txtBatchStat;


                txtFrom = (CrystalDecisions.CrystalReports.Engine.TextObject)rptAPbatch.ReportDefinition.ReportObjects["txtFrom"];
                txtFrom.Text = RPTAPBatch.txtFrom;

                txtTo = (CrystalDecisions.CrystalReports.Engine.TextObject)rptAPbatch.ReportDefinition.ReportObjects["txtTo"];
                txtTo.Text = RPTAPBatch.txtTo;

                txtBatchStat = (CrystalDecisions.CrystalReports.Engine.TextObject)rptAPbatch.ReportDefinition.ReportObjects["txtBatchStat"];
                txtBatchStat.Text = RPTAPBatch.txtBatchStat;

                CrystalDecisions.CrystalReports.Engine.FieldObject SumofInvAmount1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofInvAmount3;
                CrystalDecisions.CrystalReports.Engine.FieldObject AccAmount1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofBatchNo2;

                SumofInvAmount1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAPbatch.ReportDefinition.ReportObjects["SumofInvAmount1"];
                SumofInvAmount3 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAPbatch.ReportDefinition.ReportObjects["SumofInvAmount3"];
                AccAmount1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAPbatch.ReportDefinition.ReportObjects["AccAmount1"];
                SumofBatchNo2 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAPbatch.ReportDefinition.ReportObjects["SumofBatchNo2"];

                SumofInvAmount1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofInvAmount3.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                AccAmount1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBatchNo2.FieldFormat.NumericFormat.DecimalPlaces = decmial;

                this.crystalReportViewer1.ReportSource = rptAPbatch;
                crystalReportViewer1.Zoom(100);


            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }

        }
    }
}