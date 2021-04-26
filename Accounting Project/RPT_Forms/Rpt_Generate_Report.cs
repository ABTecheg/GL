using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Accounting_GeneralLedger
{
    public partial class Rpt_Generate_Report : Form
    {
        public Rpt_Generate_Report()
        {
            InitializeComponent();
        }

        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;

        public string Prd = "";
        private void Rpt_Generate_Report_Load(object sender, EventArgs e)
        {
            refillprd();
            if (GeneralFunctions.languagechioce != "")
            {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }
        }

        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.lblFiscalPeriod.Text = obj_interface_language.lblEndPeriodFiscalPeriod;
            this.btnReport.Text = obj_interface_language.btnReport;
            this.btnExit.Text = obj_interface_language.btnEndPeriodExit;
        }

        private void refillprd()
        {
            try
            {
                DataTable dt = DataClass.RetrieveData("SELECT CONVERT(nvarchar, PeriodNumber) + '/' + CONVERT(nvarchar, YEAR(PeriodStartDate)) AS Period_No, PeriodDescription + '/' + CONVERT(nvarchar,  YEAR(PeriodStartDate)) AS Period_Name FROM dbo.GLFiscalPeriod Order BY PeriodID");
                cmbFiscalPeriod.DataSource = dt;
                cmbFiscalPeriod.DisplayMember = "Period_Name";
                cmbFiscalPeriod.ValueMember = "Period_No";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (cmbFiscalPeriod.SelectedIndex > -1)
            {
                Prd = cmbFiscalPeriod.SelectedValue.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}