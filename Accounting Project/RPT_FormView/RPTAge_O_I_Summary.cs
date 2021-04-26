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
    public partial class RPTAge_O_I_Summary : Form
    {
        public RPTAge_O_I_Summary()
        {
            InitializeComponent();
        }
        public static DateTime DateAge;
        public static short decmial = 0;

        private void RPTAge_O_I_Summary_Load(object sender, EventArgs e)
        {
            RPTAge_O_I_Summ rptAgeOpenItem = new  RPTAge_O_I_Summ();
            SqlConnection conTrial = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand comTrial = new SqlCommand();
            SqlDataAdapter adapTrial = new SqlDataAdapter();

            DataSet dsTrial = new DataSet();
            dsTrial.Clear();
            try
            {
                comTrial.Connection = conTrial;
                comTrial.CommandType = CommandType.Text;
                comTrial.CommandText = "Select * From RPTAgeOpenItem";
                adapTrial.SelectCommand = comTrial;
                adapTrial.Fill(dsTrial, "RPTAgeOpenItem");

                rptAgeOpenItem.SetDataSource(dsTrial);
                rptAgeOpenItem.SetParameterValue("DateAge", DateAge);
                CrystalDecisions.CrystalReports.Engine.FieldObject Bal1st1;
                CrystalDecisions.CrystalReports.Engine.FieldObject Bal2st1;
                CrystalDecisions.CrystalReports.Engine.FieldObject Bal3st1;
                CrystalDecisions.CrystalReports.Engine.FieldObject Bal4st1;
                CrystalDecisions.CrystalReports.Engine.FieldObject Total1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofBatchNo1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofBatchNo2;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTotal1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTotal2;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTotal3;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTotal4;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofTotal5;

                Bal1st1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAgeOpenItem.ReportDefinition.ReportObjects["Bal1st1"];
                Bal2st1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAgeOpenItem.ReportDefinition.ReportObjects["Bal2st1"];
                Bal3st1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAgeOpenItem.ReportDefinition.ReportObjects["Bal3st1"];
                Bal4st1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAgeOpenItem.ReportDefinition.ReportObjects["Bal4st1"];
                Total1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAgeOpenItem.ReportDefinition.ReportObjects["Total1"];
                SumofBatchNo1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAgeOpenItem.ReportDefinition.ReportObjects["SumofBatchNo1"];
                SumofBatchNo2 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAgeOpenItem.ReportDefinition.ReportObjects["SumofBatchNo2"];
                SumofTotal1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAgeOpenItem.ReportDefinition.ReportObjects["SumofTotal1"];
                SumofTotal2 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAgeOpenItem.ReportDefinition.ReportObjects["SumofTotal2"];
                SumofTotal3 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAgeOpenItem.ReportDefinition.ReportObjects["SumofTotal3"];
                SumofTotal4 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAgeOpenItem.ReportDefinition.ReportObjects["SumofTotal4"];
                SumofTotal5 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptAgeOpenItem.ReportDefinition.ReportObjects["SumofTotal5"];

                Bal1st1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                Bal2st1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                Bal3st1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                Bal4st1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                Total1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBatchNo1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBatchNo2.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTotal1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTotal2.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTotal3.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTotal4.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofTotal5.FieldFormat.NumericFormat.DecimalPlaces = decmial;

                this.crystalReportViewer1.ReportSource = rptAgeOpenItem;
                crystalReportViewer1.Zoom(100);


            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
        }
    }
}