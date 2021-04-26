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
    public partial class RPTVendorSumm : Form
    {
        public RPTVendorSumm()
        {
            InitializeComponent();
        }

        private void RPTVendorSumm_Load(object sender, EventArgs e)
        {
            RptVendorSummary rptVendorSumm = new RptVendorSummary();
            SqlConnection conTrial = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand comTrial = new SqlCommand();
            SqlDataAdapter adapTrial = new SqlDataAdapter();

            DataSet dsTrial = new DataSet();
            dsTrial.Clear();
            try
            {
                comTrial.Connection = conTrial;
                comTrial.CommandType = CommandType.Text;
                comTrial.CommandText = "Select * From RptVendor";
                adapTrial.SelectCommand = comTrial;
                adapTrial.Fill(dsTrial, "RptVendor");
               
                rptVendorSumm.SetDataSource(dsTrial);

                this.crystalReportViewer1.ReportSource = rptVendorSumm;
                crystalReportViewer1.Zoom(100);


            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }

        }
    }
}