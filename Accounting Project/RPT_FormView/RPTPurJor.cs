using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Accounting_GeneralLedger
{
    public partial class RPTPurJor : Form
    {
        public RPTPurJor()
        {
            InitializeComponent();
        }
        public static short decmial = 0;

        private void RPTPurJor_Load(object sender, EventArgs e)
        {
            RPTPurJournal rptPurJur = new  RPTPurJournal();
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

                rptPurJur.SetDataSource(dsTrial);

                CrystalDecisions.CrystalReports.Engine.TextObject txtFrom;
                CrystalDecisions.CrystalReports.Engine.TextObject txtTo;


                txtFrom = (CrystalDecisions.CrystalReports.Engine.TextObject)rptPurJur.ReportDefinition.ReportObjects["txtFrom"];
                txtFrom.Text = RPTPurchseJournal.txtFrom;

                txtTo = (CrystalDecisions.CrystalReports.Engine.TextObject)rptPurJur.ReportDefinition.ReportObjects["txtTo"];
                txtTo.Text = RPTPurchseJournal.txtTo;

                CrystalDecisions.CrystalReports.Engine.FieldObject SumofInvAmount1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofInvAmount3;
                CrystalDecisions.CrystalReports.Engine.FieldObject AccAmount1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofBatchNo2;

                SumofInvAmount1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptPurJur.ReportDefinition.ReportObjects["SumofInvAmount1"];
                SumofInvAmount3 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptPurJur.ReportDefinition.ReportObjects["SumofInvAmount3"];
                AccAmount1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptPurJur.ReportDefinition.ReportObjects["AccAmount1"];
                SumofBatchNo2 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptPurJur.ReportDefinition.ReportObjects["SumofBatchNo2"];

                SumofInvAmount1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofInvAmount3.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                AccAmount1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBatchNo2.FieldFormat.NumericFormat.DecimalPlaces = decmial;

                this.crystalReportViewer1.ReportSource = rptPurJur;
                crystalReportViewer1.Zoom(100);


            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
        }
    }
}