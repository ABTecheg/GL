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
    public partial class ReportARCustList : Form
    {
        public ReportARCustList()
        {
            InitializeComponent();
        }
        public string Type = "";
        public static short decmial = 0;
        private void ReportARCustList_Load(object sender, EventArgs e)
        {
            if (Type == "Details")
            {
                CR_ARCustDet rptCustList = new CR_ARCustDet();
                SqlConnection conTrial = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand comTrial = new SqlCommand();
                SqlDataAdapter adapTrial = new SqlDataAdapter();

                DataSet dsTrial = new DataSet();
                dsTrial.Clear();
                try
                {
                    comTrial.Connection = conTrial;
                    comTrial.CommandType = CommandType.Text;
                    comTrial.CommandText = "Select * From RPTCustList";
                    adapTrial.SelectCommand = comTrial;
                    adapTrial.Fill(dsTrial, "RPTCustList");

                    rptCustList.SetDataSource(dsTrial);

                    this.crystalReportViewer1.ReportSource = rptCustList;
                    crystalReportViewer1.Zoom(100);


                }
                catch (Exception e3)
                {
                    MessageBox.Show(e3.Message);
                }
            }
            else
            {
                CR_ARCustList rptCustList = new CR_ARCustList();
                SqlConnection conTrial = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand comTrial = new SqlCommand();
                SqlDataAdapter adapTrial = new SqlDataAdapter();

                DataSet dsTrial = new DataSet();
                dsTrial.Clear();
                try
                {
                    comTrial.Connection = conTrial;
                    comTrial.CommandType = CommandType.Text;
                    comTrial.CommandText = "Select * From RPTCustList";
                    adapTrial.SelectCommand = comTrial;
                    adapTrial.Fill(dsTrial, "RPTCustList");

                    rptCustList.SetDataSource(dsTrial);

                    this.crystalReportViewer1.ReportSource = rptCustList;
                    crystalReportViewer1.Zoom(100);


                }
                catch (Exception e3)
                {
                    MessageBox.Show(e3.Message);
                }
            }
        }
    }
}