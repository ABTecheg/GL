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
    public partial class RPTARTranCust : Form
    {
        public RPTARTranCust()
        {
            InitializeComponent();
        }
        public static string txtTo = "";
        public static string txtFrom = "";
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbGeneralSetup;
        private SqlDataAdapter adaptertbCust;
        private DataTable DTCust;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        private SqlConnection connectReport2;
        private SqlDataReader readerReport2;
        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            //this.Text = obj_interface_language.VendorReport;
            //this.label3.Text = obj_interface_language.lblAvailable;
            //this.label4.Text = obj_interface_language.lblSelect;
            //this.groupBox1.Text = obj_interface_language.Vendor;
            //this.groupBox4.Text = obj_interface_language.groupSelectOptions;
            //this.groupBox3.Text = obj_interface_language.Report_Display;
            //this.rdsortcode.Text = obj_interface_language.SortCode;
            //this.rdsortname.Text = obj_interface_language.SortName;
            //this.rdsortcategory.Text = obj_interface_language.SortCategory;
            //this.rdvendorcode.Text = obj_interface_language.VendorCode;
            //this.rdvendorname.Text = obj_interface_language.VendorName;
            //this.rdvendorcategory.Text = obj_interface_language.VendorCategory;

            //this.btnReport.Text = obj_interface_language.btnReport;

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                connectReport2 = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand commandReport2 = new SqlCommand();


                connectReport2.Open();

                commandReport2 = new SqlCommand();
                commandReport2.Connection = connectReport2;
                commandReport2.CommandType = CommandType.Text;

                commandReport2.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BudgetPlanning]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View RptARTrans";
                try
                {
                    readerReport2 = commandReport2.ExecuteReader();
                    readerReport2.Close();
                }
                catch (Exception ex)
                { }

                txtFrom = dtp_from.Value.ToShortDateString();
                txtTo = dtp_to.Value.ToShortDateString();
                string s2 = "";
                s2 = "Create View RptARTrans AS SELECT  TOP 100 PERCENT dbo.Batch.BatchNo, dbo.Batch.BatchDate, dbo.Batch.BatchPRD, dbo.Batch.BatchDSC, dbo.Batch.BatchSRC, dbo.Batch.BatchStat, dbo.Batch.PostDate, " +
                      "dbo.ARTransactionCodes.TransDesc, dbo.ARtrans.CodeTran, dbo.ARtrans.TransNO, dbo.ARtrans.GLAccount, dbo.ARtrans.TRANSREF, dbo.ARtrans.TRANSDATE, dbo.ARtrans.AmountLC, dbo.Users.UserName, dbo.ARtrans.AccountCode, dbo.ARtrans.AccountName " +
                       " FROM dbo.Users INNER JOIN dbo.Batch ON dbo.Users.UserID = dbo.Batch.UserID INNER JOIN dbo.ARtrans ON dbo.Batch.BatchNo = dbo.ARtrans.BatchNo LEFT OUTER JOIN " +
                      "dbo.ARTransactionCodes ON dbo.ARtrans.CodeTran = dbo.ARTransactionCodes.TransCode where dbo.Batch.BatchSRC IN ('AR','ARP') AND ARtrans.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, dtp_from.Value.Date) + "' AND '" + string.Format(GeneralFunctions.Format_Date, dtp_to.Value.Date) + "'";
                if (ListSelect.Items.Count > 0)
                {
                    if (rdAccountCode.Checked == true)
                        s2 = s2 + " AND dbo.ARtrans.AccountCode IN ('";
                    else if (rdAccountName.Checked == true)
                        s2 = s2 + " AND dbo.ARtrans.AccountName IN ('";
                    string s = "";
                    foreach (object ob in ListSelect.Items)
                    {
                        s2 = s2 + s + ob.ToString() + "'";
                        s = ",'";
                    }
                    s2 = s2 + ")";
                }

                if (rdAccountCode.Checked == true)
                    s2 = s2 + " ORDER BY dbo.ARtrans.AccountCode";
                else if (rdAccountName.Checked == true)
                    s2 = s2 + " ORDER BY dbo.ARtrans.AccountName";

                commandReport2.CommandText = s2;
                try
                {
                    readerReport2 = commandReport2.ExecuteReader();
                    readerReport2.Close();
                }
                catch (Exception ex)
                { }
                RptARByCust rpt = new RptARByCust();
                rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                connectReport2.Close();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ListAvailable.SelectedIndex != -1)
            {
                int I = ListAvailable.SelectedIndex;
                ListSelect.Items.Add(ListAvailable.SelectedItem.ToString());
                ListAvailable.Items.RemoveAt(I);
                ListAvailable.Focus();
                if (ListAvailable.Items.Count > 0)
                {
                    if (I < ListAvailable.Items.Count)
                        ListAvailable.SetSelected(I, true);
                    else
                        ListAvailable.SetSelected(0, true);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ListAvailable.Items.Count > 0)
            {
                ListSelect.Items.AddRange(ListAvailable.Items);
                ListAvailable.Items.Clear();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ListSelect.SelectedIndex != -1)
            {
                ListAvailable.Items.Add(ListSelect.SelectedItem.ToString());
                int I = ListSelect.SelectedIndex;
                ListSelect.Items.RemoveAt(I);
                ListSelect.Focus();
                if (ListSelect.Items.Count > 0)
                {
                    if (I < ListSelect.Items.Count)
                        ListSelect.SetSelected(I, true);
                    else
                        ListSelect.SetSelected(0, true);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ListSelect.Items.Count > 0)
            {
                ListAvailable.Items.AddRange(ListSelect.Items);
                ListSelect.Items.Clear();
            }
        }

        private void RPTARTranCust_Load(object sender, EventArgs e)
        {
            dbAccountingProjectDS = new dbAccountingProjectDS();
            DTCust = new DataTable();

            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbCust = new SqlDataAdapter("SELECT ARCustomerMaintainance.AccountCode, ARCustomerMaintainance.AccoutName FROM ARCustomerMaintainance ", sqlcon);
            adaptertbCust.Fill(DTCust);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            {
                RptARByCust.decmial = short.Parse(dr["DecimalPointsNumber"].ToString());
            }
            rdAccountCode.Checked = true;
            if (DTCust.Rows.Count != 0)
            {
                ListAvailable.Items.Clear();
                ListSelect.Items.Clear();
                foreach (DataRow dr in DTCust.Rows)
                {
                    if (!ListAvailable.Items.Contains(dr["AccountCode"]))
                        ListAvailable.Items.Add(dr["AccountCode"]);
                }
                ListAvailable.Sorted = true;
            }
            if (GeneralFunctions.languagechioce != "")
            {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }

        }

        private void rdAccountCode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAccountCode.Checked == true)
            {
                DTCust.Clear();
                DTCust.AcceptChanges();
                adaptertbCust = new SqlDataAdapter("SELECT ARCustomerMaintainance.AccountCode, ARCustomerMaintainance.AccoutName FROM ARCustomerMaintainance ", sqlcon);
                adaptertbCust.Fill(DTCust);
                if (DTCust.Rows.Count != 0)
                {
                    ListAvailable.Items.Clear();
                    ListSelect.Items.Clear();
                    foreach (DataRow dr in DTCust.Rows)
                    {
                        if (!ListAvailable.Items.Contains(dr["AccountCode"]))
                            ListAvailable.Items.Add(dr["AccountCode"]);
                    }
                    ListAvailable.Sorted = true;
                }
            }

        }

        private void rdAccountName_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAccountName.Checked == true)
            {
                DTCust.Clear();
                DTCust.AcceptChanges();
                adaptertbCust = new SqlDataAdapter("SELECT ARCustomerMaintainance.AccountCode, ARCustomerMaintainance.AccoutName FROM ARCustomerMaintainance ", sqlcon);
                adaptertbCust.Fill(DTCust);
                if (DTCust.Rows.Count != 0)
                {
                    ListAvailable.Items.Clear();
                    ListSelect.Items.Clear();
                    foreach (DataRow dr in DTCust.Rows)
                    {
                        if (!ListAvailable.Items.Contains(dr["AccoutName"]))
                            ListAvailable.Items.Add(dr["AccoutName"]);
                    }
                    ListAvailable.Sorted = true;
                }
            }
        }

        private void ListAvailable_DoubleClick(object sender, EventArgs e)
        {
            button1_Click("", e);
        }

        private void ListSelect_DoubleClick(object sender, EventArgs e)
        {
            button3_Click("", e);
        }




    }
}