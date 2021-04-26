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
    public partial class RptGLdet : Form
    {
        public RptGLdet()
        {
            InitializeComponent();
        }
        public static short decmial = 0;
        private void RptGLdet_Load(object sender, EventArgs e)
        {
            RptGLDetail rptgldet = new RptGLDetail();
            SqlConnection conTrial = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand comTrial = new SqlCommand();
            SqlDataAdapter adapTrial = new SqlDataAdapter();

            DataSet dsTrial = new DataSet();
            dsTrial.Clear();
            try
            {
                comTrial.Connection = conTrial;
                comTrial.CommandType = CommandType.Text;
                comTrial.CommandText = "Select * From RptGLdetail";
                adapTrial.SelectCommand = comTrial;
                adapTrial.Fill(dsTrial, "RptGLdetail");

                rptgldet.SetDataSource(dsTrial);

                CrystalDecisions.CrystalReports.Engine.TextObject txtFrom;
                CrystalDecisions.CrystalReports.Engine.TextObject txtTo;


                txtFrom = (CrystalDecisions.CrystalReports.Engine.TextObject)rptgldet.ReportDefinition.ReportObjects["txtFrom"];
                txtFrom.Text = RptGLAccountDetail.txtFrom;

                txtTo = (CrystalDecisions.CrystalReports.Engine.TextObject)rptgldet.ReportDefinition.ReportObjects["txtTo"];
                txtTo.Text = RptGLAccountDetail.txtTo;

                CrystalDecisions.CrystalReports.Engine.FieldObject TRANSDebitLC1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTRANSDebitLC1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTRANSDebitLC2;
                CrystalDecisions.CrystalReports.Engine.FieldObject TRANSCreditLC1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTRANSCreditLC1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTRANSCreditLC2;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTRANSCreditLC3;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTRANSCreditLC4;

                TRANSDebitLC1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptgldet.ReportDefinition.ReportObjects["Debit1"];
                SumofTRANSDebitLC1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptgldet.ReportDefinition.ReportObjects["SumofTRANSDebitLC1"];
                SumofTRANSDebitLC2 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptgldet.ReportDefinition.ReportObjects["SumofTRANSDebitLC2"];
                TRANSCreditLC1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptgldet.ReportDefinition.ReportObjects["Credit1"];
                SumofTRANSCreditLC1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptgldet.ReportDefinition.ReportObjects["SumofTRANSCreditLC1"];
                SumofTRANSCreditLC2 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptgldet.ReportDefinition.ReportObjects["SumofTRANSCreditLC2"];
                SumofTRANSCreditLC3 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptgldet.ReportDefinition.ReportObjects["SumofCredit1"];
                SumofTRANSCreditLC4 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptgldet.ReportDefinition.ReportObjects["SumofCredit2"];

                TRANSDebitLC1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTRANSDebitLC1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTRANSDebitLC2.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                TRANSCreditLC1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTRANSCreditLC1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTRANSCreditLC2.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTRANSCreditLC3.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTRANSCreditLC4.FieldFormat.NumericFormat.DecimalPlaces = decmial;

                this.crystalReportViewer1.ReportSource = rptgldet;
                crystalReportViewer1.Zoom(100);


            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }

        }
    }
}