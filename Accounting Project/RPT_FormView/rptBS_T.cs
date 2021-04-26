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
    public partial class rptBS_T : Form
    {
        public rptBS_T()
        {
            InitializeComponent();
        }
        public static short decmial = 0;
        public static int Neg = 0;
        public static string Lang = "";

        private void rptBS_T_Load(object sender, EventArgs e)
        {
            RptBST rptBST = new RptBST();
            SqlConnection conBST = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand comBSA = new SqlCommand();
            SqlDataAdapter adapBSA = new SqlDataAdapter();

            DataSet dsBSA = new DataSet();
            dsBSA.Clear();
            SqlCommand comBSL_E = new SqlCommand();
            SqlDataAdapter adapBSL_E = new SqlDataAdapter();

            DataSet dsBSL_E = new DataSet();
            dsBSL_E.Clear();
            try
            {
                comBSA.Connection = conBST;
                comBSA.CommandType = CommandType.Text;
                comBSA.CommandText = "Select * From RptAssets";
                adapBSA.SelectCommand = comBSA;
                adapBSA.Fill(dsBSA, "RptAssets");

                rptBST.Subreports[0].SetDataSource(dsBSA);

                comBSL_E.Connection = conBST;
                comBSL_E.CommandType = CommandType.Text;
                comBSL_E.CommandText = "Select * From RptL_E";
                adapBSL_E.SelectCommand = comBSL_E;
                adapBSL_E.Fill(dsBSL_E, "RptL_E");

                rptBST.Subreports[1].SetDataSource(dsBSL_E);

                CrystalDecisions.CrystalReports.Engine.TextObject EndingIN;
                EndingIN = (CrystalDecisions.CrystalReports.Engine.TextObject)rptBST.ReportDefinition.ReportObjects["EndingIN"];
                EndingIN.Text = RptBalanceSheet.IN;
                CrystalDecisions.CrystalReports.Engine.TextObject txtTitle;
                txtTitle = (CrystalDecisions.CrystalReports.Engine.TextObject)rptBST.ReportDefinition.ReportObjects["txtTitle"];
                CrystalDecisions.CrystalReports.Engine.TextObject AccName;
                AccName = (CrystalDecisions.CrystalReports.Engine.TextObject)rptBST.Subreports[0].ReportDefinition.ReportObjects["Text3"];
                CrystalDecisions.CrystalReports.Engine.TextObject txtBalance;
                txtBalance = (CrystalDecisions.CrystalReports.Engine.TextObject)rptBST.Subreports[0].ReportDefinition.ReportObjects["Text2"];
                CrystalDecisions.CrystalReports.Engine.TextObject AccName2;
                AccName2 = (CrystalDecisions.CrystalReports.Engine.TextObject)rptBST.Subreports[1].ReportDefinition.ReportObjects["Text14"];
                CrystalDecisions.CrystalReports.Engine.TextObject txtBalance2;
                txtBalance2 = (CrystalDecisions.CrystalReports.Engine.TextObject)rptBST.Subreports[1].ReportDefinition.ReportObjects["Text13"];
                if (Lang == "AR")
                {
                    txtTitle.Text = "( T ) „Ì“«‰ «·„—«Ã⁄…";
                    AccName.Text = "√”„ «·Õ”«»";
                    txtBalance.Text = "«·—’Ìœ";
                    AccName2.Text = "√”„ «·Õ”«»";
                    txtBalance2.Text = "«·—’Ìœ";
                    rptBST.SetParameterValue(2, "—ﬁ„ «·’›Õ…");
                    rptBST.SetParameterValue(1, " «—ÌŒ «·ÿ»«⁄…");
                    rptBST.SetParameterValue(0, "‰Â«Ì…");
                    rptBST.SetParameterValue(3, "«·√Ã„«·Ï");
                    rptBST.SetParameterValue(4, "«·√Ã„«·Ï");
                }
                else
                {
                    rptBST.SetParameterValue(2, "Page No");
                    rptBST.SetParameterValue(1, "Print Date In");
                    rptBST.SetParameterValue(0, "Ending");
                    rptBST.SetParameterValue(3, "Total");
                    rptBST.SetParameterValue(4, "Total");
                }
                if (RptBalanceSheet.g1 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh1;
                    gh1 = rptBST.Subreports[0].ReportDefinition.Sections["GroupHeaderSection1"];
                    gh1.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf1;
                    gf1 = rptBST.Subreports[0].ReportDefinition.Sections["GroupFooterSection1"];
                    gf1.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g2 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh2;
                    gh2 = rptBST.Subreports[0].ReportDefinition.Sections["GroupHeaderSection2"];
                    gh2.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf2;
                    gf2 = rptBST.Subreports[0].ReportDefinition.Sections["GroupFooterSection2"];
                    gf2.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g3 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh3;
                    gh3 = rptBST.Subreports[0].ReportDefinition.Sections["GroupHeaderSection3"];
                    gh3.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf3;
                    gf3 = rptBST.Subreports[0].ReportDefinition.Sections["GroupFooterSection3"];
                    gf3.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g4 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh4;
                    gh4 = rptBST.Subreports[0].ReportDefinition.Sections["GroupHeaderSection4"];
                    gh4.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf4;
                    gf4 = rptBST.Subreports[0].ReportDefinition.Sections["GroupFooterSection4"];
                    gf4.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g5 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh5;
                    gh5 = rptBST.Subreports[0].ReportDefinition.Sections["GroupHeaderSection5"];
                    gh5.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf5;
                    gf5 = rptBST.Subreports[0].ReportDefinition.Sections["GroupFooterSection5"];
                    gf5.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g6 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh6;
                    gh6 = rptBST.Subreports[0].ReportDefinition.Sections["GroupHeaderSection6"];
                    gh6.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf6;
                    gf6 = rptBST.Subreports[0].ReportDefinition.Sections["GroupFooterSection6"];
                    gf6.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g7 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh7;
                    gh7 = rptBST.Subreports[0].ReportDefinition.Sections["GroupHeaderSection7"];
                    gh7.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf7;
                    gf7 = rptBST.Subreports[0].ReportDefinition.Sections["GroupFooterSection7"];
                    gf7.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g8 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh8;
                    gh8 = rptBST.Subreports[0].ReportDefinition.Sections["GroupHeaderSection8"];
                    gh8.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf8;
                    gf8 = rptBST.Subreports[0].ReportDefinition.Sections["GroupFooterSection8"];
                    gf8.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g9 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh9;
                    gh9 = rptBST.Subreports[0].ReportDefinition.Sections["GroupHeaderSection9"];
                    gh9.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf9;
                    gf9 = rptBST.Subreports[0].ReportDefinition.Sections["GroupFooterSection9"];
                    gf9.SectionFormat.EnableSuppress = true;
                }

                if (RptBalanceSheet.g1 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh1;
                    gh1 = rptBST.Subreports[1].ReportDefinition.Sections["GroupHeaderSection1"];
                    gh1.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf1;
                    gf1 = rptBST.Subreports[1].ReportDefinition.Sections["GroupFooterSection1"];
                    gf1.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g2 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh2;
                    gh2 = rptBST.Subreports[1].ReportDefinition.Sections["GroupHeaderSection2"];
                    gh2.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf2;
                    gf2 = rptBST.Subreports[1].ReportDefinition.Sections["GroupFooterSection2"];
                    gf2.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g3 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh3;
                    gh3 = rptBST.Subreports[1].ReportDefinition.Sections["GroupHeaderSection3"];
                    gh3.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf3;
                    gf3 = rptBST.Subreports[1].ReportDefinition.Sections["GroupFooterSection3"];
                    gf3.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g4 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh4;
                    gh4 = rptBST.Subreports[1].ReportDefinition.Sections["GroupHeaderSection4"];
                    gh4.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf4;
                    gf4 = rptBST.Subreports[1].ReportDefinition.Sections["GroupFooterSection4"];
                    gf4.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g5 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh5;
                    gh5 = rptBST.Subreports[1].ReportDefinition.Sections["GroupHeaderSection5"];
                    gh5.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf5;
                    gf5 = rptBST.Subreports[1].ReportDefinition.Sections["GroupFooterSection5"];
                    gf5.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g6 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh6;
                    gh6 = rptBST.Subreports[1].ReportDefinition.Sections["GroupHeaderSection6"];
                    gh6.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf6;
                    gf6 = rptBST.Subreports[1].ReportDefinition.Sections["GroupFooterSection6"];
                    gf6.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g7 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh7;
                    gh7 = rptBST.Subreports[1].ReportDefinition.Sections["GroupHeaderSection7"];
                    gh7.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf7;
                    gf7 = rptBST.Subreports[1].ReportDefinition.Sections["GroupFooterSection7"];
                    gf7.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g8 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh8;
                    gh8 = rptBST.Subreports[1].ReportDefinition.Sections["GroupHeaderSection8"];
                    gh8.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf8;
                    gf8 = rptBST.Subreports[1].ReportDefinition.Sections["GroupFooterSection8"];
                    gf8.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g9 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh9;
                    gh9 = rptBST.Subreports[1].ReportDefinition.Sections["GroupHeaderSection9"];
                    gh9.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf9;
                    gf9 = rptBST.Subreports[1].ReportDefinition.Sections["GroupFooterSection9"];
                    gf9.SectionFormat.EnableSuppress = true;
                }


                CrystalDecisions.CrystalReports.Engine.FieldObject Balance1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofBalance1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofBalance2;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofBalance3;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofBalance4;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofBalance5;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofBalance6;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofBalance7;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofBalance8;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofBalance9;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofBalance10;


                Balance1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[0].ReportDefinition.ReportObjects["Balance1"];
                SumofBalance1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[0].ReportDefinition.ReportObjects["SumofBalance1"];
                SumofBalance2 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[0].ReportDefinition.ReportObjects["SumofBalance2"];
                SumofBalance3 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[0].ReportDefinition.ReportObjects["SumofBalance3"];
                SumofBalance4 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[0].ReportDefinition.ReportObjects["SumofBalance4"];
                SumofBalance5 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[0].ReportDefinition.ReportObjects["SumofBalance5"];
                SumofBalance6 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[0].ReportDefinition.ReportObjects["SumofBalance6"];
                SumofBalance7 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[0].ReportDefinition.ReportObjects["SumofBalance7"];
                SumofBalance8 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[0].ReportDefinition.ReportObjects["SumofBalance8"];
                SumofBalance9 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[0].ReportDefinition.ReportObjects["SumofBalance9"];

                Balance1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance2.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance3.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance4.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance5.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance6.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance7.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance8.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance9.FieldFormat.NumericFormat.DecimalPlaces = decmial;

                if (Neg != 0)
                {
                    Balance1.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofBalance1.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofBalance2.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofBalance3.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofBalance4.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofBalance5.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofBalance6.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofBalance7.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofBalance8.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofBalance9.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                }

                Balance1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[1].ReportDefinition.ReportObjects["Balance1"];
                SumofBalance1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[1].ReportDefinition.ReportObjects["SumofBalance1"];
                SumofBalance2 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[1].ReportDefinition.ReportObjects["SumofBalance2"];
                SumofBalance3 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[1].ReportDefinition.ReportObjects["SumofBalance3"];
                SumofBalance4 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[1].ReportDefinition.ReportObjects["SumofBalance4"];
                SumofBalance5 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[1].ReportDefinition.ReportObjects["SumofBalance5"];
                SumofBalance6 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[1].ReportDefinition.ReportObjects["SumofBalance6"];
                SumofBalance7 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[1].ReportDefinition.ReportObjects["SumofBalance7"];
                SumofBalance8 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[1].ReportDefinition.ReportObjects["SumofBalance8"];
                SumofBalance9 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[1].ReportDefinition.ReportObjects["SumofBalance9"];
                SumofBalance10 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBST.Subreports[1].ReportDefinition.ReportObjects["SumofBalance10"];

                Balance1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance2.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance3.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance4.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance5.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance6.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance7.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance8.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance9.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofBalance10.FieldFormat.NumericFormat.DecimalPlaces = decmial;

                if (Neg != 0)
                {
                    Balance1.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofBalance1.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofBalance2.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofBalance3.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofBalance4.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofBalance5.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofBalance6.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofBalance7.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofBalance8.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofBalance9.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofBalance10.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                }


                this.crystalReportViewer1.ReportSource = rptBST;
                crystalReportViewer1.Zoom(100);

            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
        }
    }
}