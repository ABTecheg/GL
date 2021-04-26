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
    public partial class RPTARCustList : Form
    {
        public RPTARCustList()
        {
            InitializeComponent();
        }
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbCust;
        private DataTable DTCust;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private SqlDataAdapter adaptertbGeneralSetup;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        private SqlConnection connectReport2;
        private SqlDataReader readerReport2;

        private void RPTARCustList_Load(object sender, EventArgs e)
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
                ReportARCustList.decmial = short.Parse(dr["DecimalPointsNumber"].ToString());
            }
            rdbsummer.Checked = true;
            rdAccountcode.Checked = true;
            if (DTCust.Rows.Count != 0)
            {
                ListAvailable.Items.Clear();
                ListSelect.Items.Clear();
                foreach (DataRow dr in DTCust.Rows)
                {
                    if (!ListAvailable.Items.Contains(dr["AccountCode"]))
                        ListAvailable.Items.Add(dr["AccountCode"]);
                }
            }
            rdsortcode.Checked = true;
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

        private void rdAccountcode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAccountcode.Checked == true)
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

        private void rdAccountname_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAccountname.Checked == true)
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

        private void rdAccountcategory_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAccountcategory.Checked == true)
            {
                DTCust.Clear();
                DTCust.AcceptChanges();
                adaptertbCust = new SqlDataAdapter("SELECT ARCustomerMaintainance.AccountCode, ARCustomerMaintainance.AccoutName ,Ar_AccontCat.CatDesc FROM ARCustomerMaintainance INNER JOIN Ar_AccontCat ON dbo.ARCustomerMaintainance.Category = Ar_AccontCat.ArAccCatCode", sqlcon);
                adaptertbCust.Fill(DTCust);
                if (DTCust.Rows.Count != 0)
                {
                    ListAvailable.Items.Clear();
                    ListSelect.Items.Clear();
                    foreach (DataRow dr in DTCust.Rows)
                    {
                        if (!ListAvailable.Items.Contains(dr["CatDesc"]))
                            ListAvailable.Items.Add(dr["CatDesc"]);
                    }
                    ListAvailable.Sorted = true;
                }
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

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdsortcode.Checked == false && rdsortname.Checked == false && rdsortcategory.Checked == false)
                {
                    MessageBox.Show("Choose Display of report", "General Ledger");
                    return;
                }
                connectReport2 = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand commandReport2 = new SqlCommand();


                connectReport2.Open();

                commandReport2 = new SqlCommand();
                commandReport2.Connection = connectReport2;
                commandReport2.CommandType = CommandType.Text;

                commandReport2.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BudgetPlanning]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View RPTCustList";
                try
                {
                    readerReport2 = commandReport2.ExecuteReader();
                    readerReport2.Close();
                }
                catch (Exception ex)
                { }
                string s2 = "";
                s2 = "Create View RPTCustList AS SELECT TOP 100 PERCENT dbo.ARCustomerMaintainance.AccountCode, dbo.ARCustomerMaintainance.AccoutName, dbo.ARCustomerMaintainance.Created, "+
                " dbo.ARCustomerMaintainance.Status, dbo.ARCustomerMaintainance.Type, dbo.ARCustomerMaintainance.Contact, dbo.ARCustomerMaintainance.Line1, "+
                " dbo.ARCustomerMaintainance.Line2, dbo.ARCustomerMaintainance.City, dbo.ARCustomerMaintainance.County, dbo.ARCustomerMaintainance.phone, "+
                " dbo.ARCustomerMaintainance.fax, dbo.ARCustomerMaintainance.Email, dbo.ARCustomerMaintainance.FinanceChange, "+
                " dbo.ARCustomerMaintainance.CreditLimit, dbo.ARCustomerMaintainance.TaxIDNum, dbo.Ar_AccontCat.CatDesc "+
                " FROM dbo.ARCustomerMaintainance LEFT OUTER JOIN dbo.Ar_AccontCat ON dbo.ARCustomerMaintainance.Category = dbo.Ar_AccontCat.ArAccCatCode" +
                " WHERE (dbo.ARCustomerMaintainance.AccountCode <> '') ";
                if (ListSelect.Items.Count > 0)
                {
                    if (rdb_Active.Checked == true)
                        s2 = s2 + " AND dbo.ARCustomerMaintainance.Status <> 'I'";
                    else if (rdb_Inactive.Checked == true)
                        s2 = s2 + " AND dbo.ARCustomerMaintainance.Status = 'I'";
                    if (rdAccountcode.Checked == true)
                        s2 = s2 + " AND dbo.ARCustomerMaintainance.AccountCode IN ('";
                    else if (rdAccountname.Checked == true)
                        s2 = s2 + " AND dbo.ARCustomerMaintainance.AccoutName IN ('";
                    else if (rdAccountcategory.Checked == true)
                        s2 = s2 + " AND dbo.Ar_AccontCat.CatDesc IN ('";
                    string s = "";
                    foreach (object ob in ListSelect.Items)
                    {
                        s2 = s2 + s + ob.ToString() + "'";
                        s = ",'";
                    }
                    s2 = s2 + ")";
                }

                if (rdsortcode.Checked == true)
                    s2 = s2 + " ORDER BY dbo.ARCustomerMaintainance.AccountCode";
                if (rdsortname.Checked == true)
                    s2 = s2 + " ORDER BY dbo.ARCustomerMaintainance.AccoutName";
                if (rdsortcategory.Checked == true)
                    s2 = s2 + " ORDER BY dbo.Ar_AccontCat.CatDesc";

                commandReport2.CommandText = s2;
                try
                {
                    readerReport2 = commandReport2.ExecuteReader();
                    readerReport2.Close();
                }
                catch (Exception ex)
                { }
                if (rdbdetails.Checked == true)
                {
                    ReportARCustList rpt = new ReportARCustList();
                    rpt.Type = "Details";
                    rpt.ShowDialog();
                }
                else
                {
                    ReportARCustList rpt = new ReportARCustList();
                    rpt.Type = "Summary";
                    rpt.ShowDialog();
                }
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