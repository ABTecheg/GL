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
    public partial class RPTOpenItems : Form
    {
        public RPTOpenItems()
        {
            InitializeComponent();
        }
        public static short decmial = 0;

        private void RPTOpenItems_Load(object sender, EventArgs e)
        {
            RPTItemOpen rptOpenItem = new RPTItemOpen();
            SqlConnection conTrial = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand comTrial = new SqlCommand();
            SqlDataAdapter adapTrial = new SqlDataAdapter();

            DataSet dsTrial = new DataSet();
            dsTrial.Clear();
            try
            {
                comTrial.Connection = conTrial;
                comTrial.CommandType = CommandType.Text;
                comTrial.CommandText = "Select * From RPTAPItemOpen";
                adapTrial.SelectCommand = comTrial;
                adapTrial.Fill(dsTrial, "RPTAPItemOpen");

                rptOpenItem.SetDataSource(dsTrial);

                CrystalDecisions.CrystalReports.Engine.FieldObject InvAmt1;
                CrystalDecisions.CrystalReports.Engine.FieldObject PaidAmt1;
                CrystalDecisions.CrystalReports.Engine.FieldObject Balance1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofBalance1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofBalance2;

                InvAmt1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptOpenItem.ReportDefinition.ReportObjects["InvAmt1"];
                PaidAmt1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptOpenItem.ReportDefinition.ReportObjects["PaidAmt1"];
                Balance1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptOpenItem.ReportDefinition.ReportObjects["Balance1"];
                SumofBalance1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptOpenItem.ReportDefinition.ReportObjects["SumofBalance1"];
                SumofBalance2 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptOpenItem.ReportDefinition.ReportObjects["SumofBalance2"];

                InvAmt1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                PaidAmt1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                Balance1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance2.FieldFormat.NumericFormat.DecimalPlaces = decmial;

                this.crystalReportViewer1.ReportSource = rptOpenItem;
                crystalReportViewer1.Zoom(100);


            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }

        }
    }
}