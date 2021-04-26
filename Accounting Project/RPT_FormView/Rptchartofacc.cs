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
    public partial class Rptchartofacc : Form
    {
        public Rptchartofacc()
        {
            InitializeComponent();
        }
        public static short decmial = 0;
        private void Rptchartofacc_Load(object sender, EventArgs e)
        {
            RptChartOfAccount rptChart = new RptChartOfAccount();
            SqlConnection conTrial = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand comTrial = new SqlCommand();
            SqlDataAdapter adapTrial = new SqlDataAdapter();

            DataSet dsTrial = new DataSet();
            dsTrial.Clear();
            try
            {
                comTrial.Connection = conTrial;
                comTrial.CommandType = CommandType.Text;
                comTrial.CommandText = "Select * From ChartOfAccount";
                adapTrial.SelectCommand = comTrial;
                adapTrial.Fill(dsTrial, "ChartOfAccount");
             
                rptChart.SetDataSource(dsTrial);
                

                CrystalDecisions.CrystalReports.Engine.TextObject txtinyear;
                txtinyear = (CrystalDecisions.CrystalReports.Engine.TextObject)rptChart.ReportDefinition.ReportObjects["InYear"];
                txtinyear.Text = RptChart.InYear.ToString();

                CrystalDecisions.CrystalReports.Engine.FieldObject OpeningBalance1;
                OpeningBalance1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptChart.ReportDefinition.ReportObjects["BeginningBalance1"];
                OpeningBalance1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                


                this.crystalReportViewer1.ReportSource = rptChart;
                crystalReportViewer1.Zoom(100);


            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
        }
    }
}