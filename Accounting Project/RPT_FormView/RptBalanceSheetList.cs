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
    public partial class RptBalanceSheetList : Form
    {
        public RptBalanceSheetList()
        {
            InitializeComponent();
        }
        public static short decmial = 0;
        public static int Neg = 0;
        public static string Type = "";
        public static string Lang = "";
        private void RptBalanceSheetList_Load(object sender, EventArgs e)
        {
            RptBSList rptBSList = new RptBSList();
            SqlConnection conBSList = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand comBSList = new SqlCommand();
            SqlDataAdapter adapBSList = new SqlDataAdapter();

            DataSet dsBSList = new DataSet();
            dsBSList.Clear();
            try
            {
                comBSList.Connection = conBSList;
                comBSList.CommandType = CommandType.Text;
                comBSList.CommandText = "Select * From BalanceSheet";
                adapBSList.SelectCommand = comBSList;
                adapBSList.Fill(dsBSList, "BalanceSheet");

                rptBSList.SetDataSource(dsBSList);

                CrystalDecisions.CrystalReports.Engine.TextObject EndingIN;
                EndingIN = (CrystalDecisions.CrystalReports.Engine.TextObject)rptBSList.ReportDefinition.ReportObjects["EndingIN"];
                EndingIN.Text = RptBalanceSheet.IN;
                CrystalDecisions.CrystalReports.Engine.TextObject txtTitle;
                txtTitle = (CrystalDecisions.CrystalReports.Engine.TextObject)rptBSList.ReportDefinition.ReportObjects["txtTitle"];
                CrystalDecisions.CrystalReports.Engine.TextObject Text12;
                Text12 = (CrystalDecisions.CrystalReports.Engine.TextObject)rptBSList.ReportDefinition.ReportObjects["Text12"];
                CrystalDecisions.CrystalReports.Engine.TextObject Text13;
                Text13 = (CrystalDecisions.CrystalReports.Engine.TextObject)rptBSList.ReportDefinition.ReportObjects["Text13"];
                
                if (RptBalanceSheet.g1 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh1;
                    gh1 = rptBSList.ReportDefinition.Sections["GroupHeaderSection1"];
                    gh1.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf1;
                    gf1 = rptBSList.ReportDefinition.Sections["GroupFooterSection1"];
                    gf1.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g2 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh2;
                    gh2 = rptBSList.ReportDefinition.Sections["GroupHeaderSection2"];
                    gh2.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf2;
                    gf2 = rptBSList.ReportDefinition.Sections["GroupFooterSection2"];
                    gf2.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g3 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh3;
                    gh3 = rptBSList.ReportDefinition.Sections["GroupHeaderSection3"];
                    gh3.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf3;
                    gf3 = rptBSList.ReportDefinition.Sections["GroupFooterSection3"];
                    gf3.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g4 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh4;
                    gh4 = rptBSList.ReportDefinition.Sections["GroupHeaderSection4"];
                    gh4.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf4;
                    gf4 = rptBSList.ReportDefinition.Sections["GroupFooterSection4"];
                    gf4.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g5 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh5;
                    gh5 = rptBSList.ReportDefinition.Sections["GroupHeaderSection5"];
                    gh5.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf5;
                    gf5 = rptBSList.ReportDefinition.Sections["GroupFooterSection5"];
                    gf5.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g6 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh6;
                    gh6 = rptBSList.ReportDefinition.Sections["GroupHeaderSection6"];
                    gh6.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf6;
                    gf6 = rptBSList.ReportDefinition.Sections["GroupFooterSection6"];
                    gf6.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g7 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh7;
                    gh7 = rptBSList.ReportDefinition.Sections["GroupHeaderSection7"];
                    gh7.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf7;
                    gf7 = rptBSList.ReportDefinition.Sections["GroupFooterSection7"];
                    gf7.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g8 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh8;
                    gh8 = rptBSList.ReportDefinition.Sections["GroupHeaderSection8"];
                    gh8.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf8;
                    gf8 = rptBSList.ReportDefinition.Sections["GroupFooterSection8"];
                    gf8.SectionFormat.EnableSuppress = true;
                }
                if (RptBalanceSheet.g9 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh9;
                    gh9 = rptBSList.ReportDefinition.Sections["GroupHeaderSection9"];
                    gh9.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf9;
                    gf9 = rptBSList.ReportDefinition.Sections["GroupFooterSection9"];
                    gf9.SectionFormat.EnableSuppress = true;
                }
                CrystalDecisions.CrystalReports.Engine.FieldObject Debit1;
                CrystalDecisions.CrystalReports.Engine.FieldObject Credit1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofDebit9;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofCredit9;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofDebit8;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofCredit8;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofDebit7;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofCredit7;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofDebit6;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofCredit6;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofDebit5;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofCredit5;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofDebit4;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofCredit4;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofDebit3;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofCredit3;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofDebit2;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofCredit2;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofDebit1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofCredit1;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofDebit10;
                CrystalDecisions.CrystalReports.Engine.FieldObject SumofCredit10;
                CrystalDecisions.CrystalReports.Engine.FieldObject Balance1;


                CrystalDecisions.CrystalReports.Engine.FieldObject G12;
                CrystalDecisions.CrystalReports.Engine.FieldObject G22;
                CrystalDecisions.CrystalReports.Engine.FieldObject G32;
                CrystalDecisions.CrystalReports.Engine.FieldObject G42;
                CrystalDecisions.CrystalReports.Engine.FieldObject G52;
                CrystalDecisions.CrystalReports.Engine.FieldObject G62;
                CrystalDecisions.CrystalReports.Engine.FieldObject G72;
                CrystalDecisions.CrystalReports.Engine.FieldObject G82;
                CrystalDecisions.CrystalReports.Engine.FieldObject G92;

                CrystalDecisions.CrystalReports.Engine.TextObject T1;
                CrystalDecisions.CrystalReports.Engine.TextObject T2;
                CrystalDecisions.CrystalReports.Engine.TextObject T3;
                CrystalDecisions.CrystalReports.Engine.TextObject T4;
                CrystalDecisions.CrystalReports.Engine.TextObject T5;
                CrystalDecisions.CrystalReports.Engine.TextObject T6;
                CrystalDecisions.CrystalReports.Engine.TextObject T7;
                CrystalDecisions.CrystalReports.Engine.TextObject T8;
                CrystalDecisions.CrystalReports.Engine.TextObject T9;

                Debit1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["Debit1"];
                Credit1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["Credit1"];
                SumofDebit9 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["SumofDebit9"];
                SumofCredit9 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["SumofCredit9"];
                SumofDebit8 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["SumofDebit8"];
                SumofCredit8 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["SumofCredit8"];
                SumofDebit7 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["SumofDebit7"];
                SumofCredit7 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["SumofCredit7"];
                SumofDebit6 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["SumofDebit6"];
                SumofCredit6 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["SumofCredit6"];
                SumofDebit5 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["SumofDebit5"];
                SumofCredit5 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["SumofCredit5"];
                SumofDebit4 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["SumofDebit4"];
                SumofCredit4 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["SumofCredit4"];
                SumofDebit3 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["SumofDebit3"];
                SumofCredit3 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["SumofCredit3"];
                SumofDebit2 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["SumofDebit2"];
                SumofCredit2 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["SumofCredit2"];
                SumofDebit1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["SumofDebit1"];
                SumofCredit1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["SumofCredit1"];
                SumofDebit10 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["SumofDebit10"];
                SumofCredit10 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["SumofCredit10"];
                Balance1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["Balance1"];

                G12 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["G12"];
                G22 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["G22"];
                G32 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["G32"];
                G42 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["G42"];
                G52 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["G52"];
                G62 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["G62"];
                G72 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["G72"];
                G82 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["G82"];
                G92 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rptBSList.ReportDefinition.ReportObjects["G92"];

                T1 = (CrystalDecisions.CrystalReports.Engine.TextObject)rptBSList.ReportDefinition.ReportObjects["T1"];
                T2 = (CrystalDecisions.CrystalReports.Engine.TextObject)rptBSList.ReportDefinition.ReportObjects["T2"];
                T3 = (CrystalDecisions.CrystalReports.Engine.TextObject)rptBSList.ReportDefinition.ReportObjects["T3"];
                T4 = (CrystalDecisions.CrystalReports.Engine.TextObject)rptBSList.ReportDefinition.ReportObjects["T4"];
                T5 = (CrystalDecisions.CrystalReports.Engine.TextObject)rptBSList.ReportDefinition.ReportObjects["T5"];
                T6 = (CrystalDecisions.CrystalReports.Engine.TextObject)rptBSList.ReportDefinition.ReportObjects["T6"];
                T7 = (CrystalDecisions.CrystalReports.Engine.TextObject)rptBSList.ReportDefinition.ReportObjects["T7"];
                T8 = (CrystalDecisions.CrystalReports.Engine.TextObject)rptBSList.ReportDefinition.ReportObjects["T8"];
                T9 = (CrystalDecisions.CrystalReports.Engine.TextObject)rptBSList.ReportDefinition.ReportObjects["T9"];
                if (Lang == "AR")
                {
                    Text12.Text = "„œÌ‰";
                    Text13.Text = "œ«∆‰";
                    rptBSList.SetParameterValue(0, "—ﬁ„ «·’›Õ…");
                    rptBSList.SetParameterValue(1, " «—ÌŒ «·ÿ»«⁄…");
                    rptBSList.SetParameterValue(2, "‰Â«Ì…");
                    T1.Text = "«·√Ã„«·Ï";
                    T2.Text = "«·√Ã„«·Ï";
                    T3.Text = "«·√Ã„«·Ï";
                    T4.Text = "«·√Ã„«·Ï";
                    T5.Text = "«·√Ã„«·Ï";
                    T6.Text = "«·√Ã„«·Ï";
                    T7.Text = "«·√Ã„«·Ï";
                    T8.Text = "«·√Ã„«·Ï";
                    T9.Text = "«·√Ã„«·Ï";
                }
                else
                {
                    //Text12.Text = "Debit";
                    //Text13.Text = "Credit";
                    rptBSList.SetParameterValue(0, "Page No");
                    rptBSList.SetParameterValue(1, "Print Date In");
                    rptBSList.SetParameterValue(2, "Ending");
                    //T1.Text = "Total";
                    //T2.Text = "Total";
                    //T3.Text = "Total";
                    //T4.Text = "Total";
                    //T5.Text = "Total";
                    //T6.Text = "Total";
                    //T7.Text = "Total";
                    //T8.Text = "Total";
                    //T9.Text = "Total";
                }
                if (Neg != 0)
                {
                    Debit1.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    Credit1.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofDebit9.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofCredit9.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofDebit8.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofCredit8.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofDebit7.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofCredit7.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofDebit6.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofCredit6.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofDebit5.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofCredit5.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofDebit4.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofCredit4.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofDebit3.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofCredit3.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofDebit2.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofCredit2.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofDebit1.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofCredit1.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofDebit10.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    SumofCredit10.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                    Balance1.FieldFormat.NumericFormat.NegativeFormat = (CrystalDecisions.Shared.NegativeFormat)Neg;
                }

                Debit1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                Credit1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofDebit9.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofCredit9.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofDebit8.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofCredit8.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofDebit7.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofCredit7.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofDebit6.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofCredit6.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofDebit5.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofCredit5.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofDebit4.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofCredit4.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofDebit3.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofCredit3.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofDebit2.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofCredit2.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofDebit1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofCredit1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofDebit10.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                SumofCredit10.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                Balance1.FieldFormat.NumericFormat.DecimalPlaces = decmial;

                Debit1.Width = 1500;
                Credit1.Width = 1500;
                SumofDebit9.Width = 1500;
                SumofCredit9.Width = 1500;
                SumofDebit8.Width = 1500;
                SumofCredit8.Width = 1500;
                SumofDebit7.Width = 1500;
                SumofCredit7.Width = 1500;
                SumofDebit6.Width = 1500;
                SumofCredit6.Width = 1500;
                SumofDebit5.Width = 1500;
                SumofCredit5.Width = 1500;
                SumofDebit4.Width = 1500;
                SumofCredit4.Width = 1500;
                SumofDebit3.Width = 1500;
                SumofCredit3.Width = 1500;
                SumofDebit2.Width = 1500;
                SumofCredit2.Width = 1500;
                SumofDebit1.Width = 1500;
                SumofCredit1.Width = 1500;
                SumofDebit10.Width = 1500;
                SumofCredit10.Width = 1500;
                Balance1.Width = 1500;
                if (Type == "Standard")
                {
                    if (Lang == "AR")
                        txtTitle.Text = "(„Ì“«‰ «·„—«Ã⁄… («·ﬁÌ«”Ï ";
                    else
                        txtTitle.Text = "Balance Sheet ( Standard )";
                    Text12.ObjectFormat.EnableSuppress = false;
                    Text13.ObjectFormat.EnableSuppress = false;
                    SumofDebit10.ObjectFormat.EnableSuppress = false;
                    SumofCredit10.ObjectFormat.EnableSuppress = false;
                    Balance1.ObjectFormat.EnableSuppress = true;
                    Debit1.Left = 5500;
                    Credit1.Left = 7000;
                    SumofDebit9.Left = 5500;
                    SumofCredit9.Left = 7000;
                    SumofDebit8.Left = 5500;
                    SumofCredit8.Left = 7000;
                    SumofDebit7.Left = 5500;
                    SumofCredit7.Left = 7000;
                    SumofDebit6.Left = 5500;
                    SumofCredit6.Left = 7000;
                    SumofDebit5.Left = 5500;
                    SumofCredit5.Left = 7000;
                    SumofDebit4.Left = 5500;
                    SumofCredit4.Left = 7000;
                    SumofDebit3.Left = 5500;
                    SumofCredit3.Left = 7000;
                    SumofDebit2.Left = 5500;
                    SumofCredit2.Left = 7000;
                    SumofDebit1.Left = 5500;
                    SumofCredit1.Left = 7000;
                    SumofDebit10.Left = 5500;
                    SumofCredit10.Left = 7000;

                    SumofDebit9.Border.TopLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofCredit9.Border.TopLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofDebit8.Border.TopLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofCredit8.Border.TopLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofDebit7.Border.TopLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofCredit7.Border.TopLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofDebit6.Border.TopLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofCredit6.Border.TopLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofDebit5.Border.TopLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofCredit5.Border.TopLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofDebit4.Border.TopLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofCredit4.Border.TopLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofDebit3.Border.TopLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofCredit3.Border.TopLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofDebit2.Border.TopLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofCredit2.Border.TopLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofDebit1.Border.TopLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofCredit1.Border.TopLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                }
                else if (Type == "Traditional")
                {
                    if (Lang == "AR")
                        txtTitle.Text = "(„Ì“«‰ «·„—«Ã⁄… («· ﬁ·ÌœÏ ";
                    else
                        txtTitle.Text = "Balance Sheet ( Traditional )";
                    Text12.ObjectFormat.EnableSuppress = true;
                    Text13.ObjectFormat.EnableSuppress = true;
                    SumofDebit10.ObjectFormat.EnableSuppress = true;
                    SumofCredit10.ObjectFormat.EnableSuppress = true;
                    Balance1.ObjectFormat.EnableSuppress = false;
                    Debit1.Left = 5500;
                    Credit1.Left = 5500;
                    SumofDebit9.Left = 5000;
                    SumofCredit9.Left = 5000;
                    SumofDebit8.Left = 5000;
                    SumofCredit8.Left = 5000;
                    SumofDebit7.Left = 5500;
                    SumofCredit7.Left = 5500;
                    SumofDebit6.Left = 6000;
                    SumofCredit6.Left = 6000;
                    SumofDebit5.Left = 6500;
                    SumofCredit5.Left = 6500;
                    SumofDebit4.Left = 7000;
                    SumofCredit4.Left = 7000;
                    SumofDebit3.Left = 7500;
                    SumofCredit3.Left = 7500;
                    SumofDebit2.Left = 8000;
                    SumofCredit2.Left = 8000;
                    SumofDebit1.Left = 9500;
                    SumofCredit1.Left = 9500;
                    SumofDebit10.Left = 5500;
                    SumofCredit10.Left = 7000;
                    Balance1.Left = 9500;

                    SumofDebit9.Border.BottomLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofCredit9.Border.BottomLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofDebit8.Border.BottomLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofCredit8.Border.BottomLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofDebit7.Border.BottomLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofCredit7.Border.BottomLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofDebit6.Border.BottomLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofCredit6.Border.BottomLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofDebit5.Border.BottomLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofCredit5.Border.BottomLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofDebit4.Border.BottomLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofCredit4.Border.BottomLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofDebit3.Border.BottomLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofCredit3.Border.BottomLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofDebit2.Border.BottomLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;
                    SumofCredit2.Border.BottomLineStyle = CrystalDecisions.Shared.LineStyle.SingleLine;

                    T1.Left = 4000;
                    T2.Left = 3500;
                    T3.Left = 3000;
                    T4.Left = 2500;
                    T5.Left = 2000;
                    T6.Left = 1500;
                    T7.Left = 1000;
                    T8.Left = 700;
                    T9.Left = 400;

                    G12.Left = 4550;
                    G22.Left = 4050;
                    G32.Left = 3550;
                    G42.Left = 3050;
                    G52.Left = 2550;
                    G62.Left = 2050;
                    G72.Left = 1550;
                    G82.Left = 1250;
                    G92.Left = 950;

                }
                
                this.crystalReportViewer1.ReportSource = rptBSList;
                crystalReportViewer1.Zoom(100);

            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
        }


    }
}
