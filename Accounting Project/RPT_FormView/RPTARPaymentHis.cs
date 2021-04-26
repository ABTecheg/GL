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
    public partial class RPTARPaymentHis : Form
    {
        public RPTARPaymentHis()
        {
            InitializeComponent();
        }
        public static short decmial = 0;
        double TotalPaymentAmt = 0;
        private void RPTARPaymentHis_Load(object sender, EventArgs e)
        {
            CR_ARPaymentHistory rptARPayHis = new CR_ARPaymentHistory();
            SqlConnection conTrial = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand comTrial = new SqlCommand();
            SqlCommand comSUM = new SqlCommand();
            SqlDataAdapter adapTrial = new SqlDataAdapter();

            DataSet dsTrial = new DataSet();
            dsTrial.Clear();
            try
            {
                TotalPaymentAmt = 0;
                comSUM.Connection = conTrial;
                comSUM.CommandText = "SELECT DISTINCT TransNO, Payment_Amount FROM RPTPaymentHistory";
                if (conTrial.State == ConnectionState.Closed)
                    conTrial.Open();
                SqlDataReader dr = comSUM.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        if (double.Parse(dr["Payment_Amount"].ToString()) > 0)
                            TotalPaymentAmt += (double.Parse(dr["Payment_Amount"].ToString()) * -1);
                        else
                            TotalPaymentAmt += double.Parse(dr["Payment_Amount"].ToString());
                    }
                }
                if (conTrial.State == ConnectionState.Open)
                    conTrial.Close();
                comTrial.Connection = conTrial;
                comTrial.CommandType = CommandType.Text;
                comTrial.CommandText = "Select * From RPTPaymentHistory";
                adapTrial.SelectCommand = comTrial;
                adapTrial.Fill(dsTrial, "RPTPaymentHistory");
                rptARPayHis.SetDataSource(dsTrial);

                CrystalDecisions.CrystalReports.Engine.TextObject txtFrom;
                CrystalDecisions.CrystalReports.Engine.TextObject txtTo;
                CrystalDecisions.CrystalReports.Engine.TextObject txtTitle;
                CrystalDecisions.CrystalReports.Engine.TextObject Text7;
                CrystalDecisions.CrystalReports.Engine.TextObject Text16;
                CrystalDecisions.CrystalReports.Engine.TextObject Text22;


                txtFrom = (CrystalDecisions.CrystalReports.Engine.TextObject)rptARPayHis.ReportDefinition.ReportObjects["txtFrom"];
                txtFrom.Text = RPTARPaymentHistory.txtFrom;

                txtTo = (CrystalDecisions.CrystalReports.Engine.TextObject)rptARPayHis.ReportDefinition.ReportObjects["txtTo"];
                txtTo.Text = RPTARPaymentHistory.txtTo;

                txtTitle = (CrystalDecisions.CrystalReports.Engine.TextObject)rptARPayHis.ReportDefinition.ReportObjects["txtTitle"];
                Text7 = (CrystalDecisions.CrystalReports.Engine.TextObject)rptARPayHis.ReportDefinition.ReportObjects["Text7"];
                Text16 = (CrystalDecisions.CrystalReports.Engine.TextObject)rptARPayHis.ReportDefinition.ReportObjects["Text16"];
                Text22 = (CrystalDecisions.CrystalReports.Engine.TextObject)rptARPayHis.ReportDefinition.ReportObjects["Text22"];
                if (RPTARPaymentHistory.txtReport == "Credit")
                {
                    txtTitle.Text = "AR Credit Report";
                    Text7.Text = "Credit_Amount";
                    Text16.Text = "Total Credit :";
                    Text22.Text = "Total Unapplied Credit :";
                }
                else if (RPTARPaymentHistory.txtReport == "Payment")
                {
                    txtTitle.Text = "AR Payment History Report";
                    Text7.Text = "Payment_Amount";
                    Text16.Text = "Total Payments :";
                    Text22.Text = "Total Unapplied Payments :";
                }
                else
                {
                    txtTitle.Text = "AR Payment And Credit Report";
                    Text7.Text = "Amount";
                    Text16.Text = "Total :";
                    Text22.Text = "Total Unapplied :";
                }
                CrystalDecisions.CrystalReports.Engine.FieldObject AmountApplied1;
                CrystalDecisions.CrystalReports.Engine.FieldObject PaymentAmount1;
                CrystalDecisions.CrystalReports.Engine.FieldObject TotalPayment1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofAmountApplied1;
                CrystalDecisions.CrystalReports.Engine.FieldObject TotalUnappied1;

                AmountApplied1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptARPayHis.ReportDefinition.ReportObjects["AmountApplied1"];
                PaymentAmount1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptARPayHis.ReportDefinition.ReportObjects["PaymentAmount1"];
                TotalPayment1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptARPayHis.ReportDefinition.ReportObjects["TotalPayment1"];
                SumofAmountApplied1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptARPayHis.ReportDefinition.ReportObjects["SumofAmountApplied1"];
                TotalUnappied1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptARPayHis.ReportDefinition.ReportObjects["TotalUnappied1"];

                AmountApplied1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                PaymentAmount1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                TotalPayment1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofAmountApplied1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                TotalUnappied1.FieldFormat.NumericFormat.DecimalPlaces = decmial;

                rptARPayHis.SetParameterValue(0, TotalPaymentAmt);

                this.crystalReportViewer1.ReportSource = rptARPayHis;
                crystalReportViewer1.Zoom(100);


            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
        }
    }
}