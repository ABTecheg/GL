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
    public partial class RptsTrailBalance : Form
    {
        public RptsTrailBalance()
        {
            InitializeComponent();
        }
        public static short decmial = 0;

        private void RptsTrailBalance_Load(object sender, EventArgs e)
        {
            RptTrialBalanceSummary rpttrialsumm = new RptTrialBalanceSummary();
            SqlConnection conTrial = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand comTrial = new SqlCommand();
            SqlDataAdapter adapTrial = new SqlDataAdapter();

            DataSet dsTrial = new DataSet();
            dsTrial.Clear();
            try
            {
                comTrial.Connection = conTrial;
                comTrial.CommandType = CommandType.Text;
                comTrial.CommandText = "Select * From RptGLTrialBalance";
                adapTrial.SelectCommand = comTrial;
                adapTrial.Fill(dsTrial, "RptGLTrialBalance");

                rpttrialsumm.SetDataSource(dsTrial);

                CrystalDecisions.CrystalReports.Engine.TextObject txtFrom;
                txtFrom = (CrystalDecisions.CrystalReports.Engine.TextObject)rpttrialsumm.ReportDefinition.ReportObjects["Text15"];
                txtFrom.Text = RptGLTrialBalance.txtFrom;
                if (RptGLTrialBalance.g1 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh1;
                    gh1 = rpttrialsumm.ReportDefinition.Sections["GroupHeaderSection1"];
                    gh1.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf1;
                    gf1 = rpttrialsumm.ReportDefinition.Sections["GroupFooterSection1"];
                    gf1.SectionFormat.EnableSuppress = true;
                }
                if (RptGLTrialBalance.g2 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh2;
                    gh2 = rpttrialsumm.ReportDefinition.Sections["GroupHeaderSection2"];
                    gh2.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf2;
                    gf2 = rpttrialsumm.ReportDefinition.Sections["GroupFooterSection2"];
                    gf2.SectionFormat.EnableSuppress = true;
                }
                if (RptGLTrialBalance.g3 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh3;
                    gh3 = rpttrialsumm.ReportDefinition.Sections["GroupHeaderSection3"];
                    gh3.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf3;
                    gf3 = rpttrialsumm.ReportDefinition.Sections["GroupFooterSection3"];
                    gf3.SectionFormat.EnableSuppress = true;
                }
                if (RptGLTrialBalance.g4 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh4;
                    gh4 = rpttrialsumm.ReportDefinition.Sections["GroupHeaderSection4"];
                    gh4.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf4;
                    gf4 = rpttrialsumm.ReportDefinition.Sections["GroupFooterSection4"];
                    gf4.SectionFormat.EnableSuppress = true;
                }
                if (RptGLTrialBalance.g5 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh5;
                    gh5 = rpttrialsumm.ReportDefinition.Sections["GroupHeaderSection5"];
                    gh5.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf5;
                    gf5 = rpttrialsumm.ReportDefinition.Sections["GroupFooterSection5"];
                    gf5.SectionFormat.EnableSuppress = true;
                }
                if (RptGLTrialBalance.g6 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh6;
                    gh6 = rpttrialsumm.ReportDefinition.Sections["GroupHeaderSection6"];
                    gh6.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf6;
                    gf6 = rpttrialsumm.ReportDefinition.Sections["GroupFooterSection6"];
                    gf6.SectionFormat.EnableSuppress = true;
                }
                if (RptGLTrialBalance.g7 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh7;
                    gh7 = rpttrialsumm.ReportDefinition.Sections["GroupHeaderSection7"];
                    gh7.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf7;
                    gf7 = rpttrialsumm.ReportDefinition.Sections["GroupFooterSection7"];
                    gf7.SectionFormat.EnableSuppress = true;
                }
                if (RptGLTrialBalance.g8 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh8;
                    gh8 = rpttrialsumm.ReportDefinition.Sections["GroupHeaderSection8"];
                    gh8.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf8;
                    gf8 = rpttrialsumm.ReportDefinition.Sections["GroupFooterSection8"];
                    gf8.SectionFormat.EnableSuppress = true;
                }
                if (RptGLTrialBalance.g9 == "Hide")
                {
                    CrystalDecisions.CrystalReports.Engine.Section gh9;
                    gh9 = rpttrialsumm.ReportDefinition.Sections["GroupHeaderSection9"];
                    gh9.SectionFormat.EnableSuppress = true;
                    CrystalDecisions.CrystalReports.Engine.Section gf9;
                    gf9 = rpttrialsumm.ReportDefinition.Sections["GroupFooterSection9"];
                    gf9.SectionFormat.EnableSuppress = true;
                }

                CrystalDecisions.CrystalReports.Engine.FieldObject DC1;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC2;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC3;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC4;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC5;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC6;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC7;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC8;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC9;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC10;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC11;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC12;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC13;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC14;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC15;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC16;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC17;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC18;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC19;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC20;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC21;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC22;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC23;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC24;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC25;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC26;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC27;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC28;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC29;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC30;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC31;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC32;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC33;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC34;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC35;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC36;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC37;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC38;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC39;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC40;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC41;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC42;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC43;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC44;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC45;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC46;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC47;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC48;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC49;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC50;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC51;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC52;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC53;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC54;
                CrystalDecisions.CrystalReports.Engine.FieldObject DC55;

                DC1 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["OpenBalance1"];
                DC2 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofDebit1"];
                DC3 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofCredit1"];
                DC4 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofAmountLC12"];
                DC5 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["EndBalance1"];
                DC6 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofDebit2"];
                DC7 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofDebit3"];
                DC8 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofDebit4"];
                DC9 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofDebit5"];
                DC10 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofDebit6"];
                DC11 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofDebit7"];
                DC12 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofDebit8"];
                DC13 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofDebit9"];
                DC14 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofDebit10"];
                DC15 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofDebit11"];
                DC16 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofCredit2"];
                DC17 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofCredit3"];
                DC18 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofCredit4"];
                DC19 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofCredit5"];
                DC20 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofCredit6"];
                DC21 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofCredit7"];
                DC22 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofCredit8"];
                DC23 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofCredit9"];
                DC24 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofCredit10"];
                DC25 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofCredit11"];
                DC26 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofOpenBalance1"];
                DC27 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofOpenBalance2"];
                DC28 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofOpenBalance3"];
                DC29 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofOpenBalance4"];
                DC30 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofOpenBalance5"];
                DC31 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofOpenBalance6"];
                DC32 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofOpenBalance7"];
                DC33 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofOpenBalance8"];
                DC34 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofOpenBalance9"];
                DC35 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofOpenBalance10"];
                DC36 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofAmountLC1"];
                DC37 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofAmountLC2"];
                DC38 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofAmountLC3"];
                DC39 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofAmountLC4"];
                DC40 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofAmountLC5"];
                DC41 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofAmountLC6"];
                DC42 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofAmountLC7"];
                DC43 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofAmountLC8"];
                DC44 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofAmountLC9"];
                DC45 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofAmountLC10"];
                DC46 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofEndBalance1"];
                DC47 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofEndBalance2"];
                DC48 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofEndBalance3"];
                DC49 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofEndBalance4"];
                DC50 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofEndBalance5"];
                DC51 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofEndBalance6"];
                DC52 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofEndBalance7"];
                DC53 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofEndBalance8"];
                DC54 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofEndBalance9"];
                DC55 = (CrystalDecisions.CrystalReports.Engine.FieldObject)rpttrialsumm.ReportDefinition.ReportObjects["SumofEndBalance10"];

                DC1.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC2.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC3.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC4.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC5.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC6.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC7.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC8.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC9.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC10.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC11.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC12.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC13.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC14.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC15.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC16.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC17.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC18.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC19.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC20.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC21.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC22.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC23.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC24.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC25.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC26.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC27.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC28.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC29.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC30.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC31.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC32.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC33.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC34.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC35.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC36.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC37.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC38.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC39.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC40.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC41.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC42.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC43.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC44.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC45.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC46.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC47.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC48.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC49.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC50.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC51.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC52.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC53.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC54.FieldFormat.NumericFormat.DecimalPlaces = decmial;
                DC55.FieldFormat.NumericFormat.DecimalPlaces = decmial;


                this.crystalReportViewer1.ReportSource = rpttrialsumm;
                crystalReportViewer1.Zoom(100);


            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
        }
    }
}