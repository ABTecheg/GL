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
    public partial class RPTAPDestributions : Form
    {
        public RPTAPDestributions()
        {
            InitializeComponent();
        }
        public static short decmial = 0;
        private void RPTAPDestributions_Load(object sender, EventArgs e)
        {
            RPTARDistribution rptAPDest = new  RPTARDistribution();
            SqlConnection conTrial = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand comTrial = new SqlCommand();
            SqlDataAdapter adapTrial = new SqlDataAdapter();
            SqlCommand com2 = new SqlCommand();
            SqlDataAdapter adap2 = new SqlDataAdapter();

            DataSet dsTrial = new DataSet();
            dsTrial.Clear();
            DataSet ds2 = new DataSet();
            ds2.Clear();
            try
            {
                comTrial.Connection = conTrial;
                comTrial.CommandType = CommandType.Text;
                comTrial.CommandText = "Select * From RPTAPBatch";
                adapTrial.SelectCommand = comTrial;
                adapTrial.Fill(dsTrial, "RPTAPBatch");

                rptAPDest.SetDataSource(dsTrial);

                com2.Connection = conTrial;
                com2.CommandType = CommandType.Text;
                com2.CommandText = "Select * From RPTAP_Cash";
                adap2.SelectCommand = com2;
                adap2.Fill(ds2, "RPTAP_Cash");

                rptAPDest.Subreports[0].SetDataSource(ds2);

                CrystalDecisions.CrystalReports.Engine.TextObject txtFrom;
                CrystalDecisions.CrystalReports.Engine.TextObject txtTo;


                txtFrom = (CrystalDecisions.CrystalReports.Engine.TextObject)rptAPDest.ReportDefinition.ReportObjects["txtFrom"];
                txtFrom.Text = RPTAPDestributionFrm.txtFrom;

                txtTo = (CrystalDecisions.CrystalReports.Engine.TextObject)rptAPDest.ReportDefinition.ReportObjects["txtTo"];
                txtTo.Text = RPTAPDestributionFrm.txtTo;

                CrystalDecisions.CrystalReports.Engine.FieldObject Amount1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofAccountAmount1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofAccountAmount2;
                //CrystalDecisions.CrystalReports.Engine.FieldObject Amount1s;
                //CrystalDecisions.CrystalReports.Engine.FieldObject SumofAmount1;
                //CrystalDecisions.CrystalReports.Engine.FieldObject SumofAmount2;

                Amount1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAPDest.ReportDefinition.ReportObjects["Amount1"];
                SumofAccountAmount1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAPDest.ReportDefinition.ReportObjects["SumofAccountAmount1"];
                SumofAccountAmount2 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAPDest.ReportDefinition.ReportObjects["SumofAccountAmount2"];
                //Amount1s = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAPDestribution.Subreports[0].ReportDefinition.ReportObjects["Amount1"];
                //SumofAmount1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAPDestribution.Subreports[0].ReportDefinition.ReportObjects["SumofAmount1"];
                //SumofAmount2 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAPDestribution.Subreports[0].ReportDefinition.ReportObjects["SumofAmount2"];

                Amount1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofAccountAmount1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofAccountAmount2.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                //Amount1s.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                //SumofAmount1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                //SumofAmount2.FieldFormat.NumericFormat.DecimalPlaces = decmial;

                this.crystalReportViewer1.ReportSource = rptAPDest;
                crystalReportViewer1.Zoom(100);


            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }

        }
    }
}