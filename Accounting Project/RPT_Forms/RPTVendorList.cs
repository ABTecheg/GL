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
    public partial class RPTVendorList : Form
    {
        public RPTVendorList()
        {
            InitializeComponent();
        }
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbVendor;
        private DataTable DTVendor;
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
            this.Text = obj_interface_language.VendorReport;
            this.label3.Text = obj_interface_language.lblAvailable;
            this.label4.Text = obj_interface_language.lblSelect;
            this.groupBox1.Text = obj_interface_language.Vendor;
            this.groupBox2.Text = obj_interface_language.groupReportOptions;
            this.groupBox4.Text = obj_interface_language.groupSelectOptions;
            this.groupBox3.Text = obj_interface_language.Report_Display;
            this.rdsortcode.Text = obj_interface_language.SortCode;
            this.rdsortname.Text = obj_interface_language.SortName;
            this.rdsortcategory.Text = obj_interface_language.SortCategory;
            this.rdvendorcode.Text = obj_interface_language.VendorCode;
            this.rdvendorname.Text = obj_interface_language.VendorName;
            this.rdvendorcategory.Text = obj_interface_language.VendorCategory;
            this.rdbdetails.Text = obj_interface_language.Detail;
            this.rdbsummer.Text = obj_interface_language.Summary;

            this.btnReport.Text = obj_interface_language.btnReport;

        }

        private void RPTVendorList_Load(object sender, EventArgs e)
        {

            dbAccountingProjectDS = new dbAccountingProjectDS();
            DTVendor = new DataTable();

            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbVendor = new SqlDataAdapter("SELECT APVendors.VendorCode, APVendors.VendorName FROM APVendors ", sqlcon);
            adaptertbVendor.Fill(DTVendor);
            rdvendorcode.Checked = true;
            if (DTVendor.Rows.Count != 0)
            {
                ListAvailable.Items.Clear();
                ListSelect.Items.Clear();
                foreach (DataRow dr in DTVendor.Rows)
                {
                    if (!ListAvailable.Items.Contains(dr["VendorCode"]))
                        ListAvailable.Items.Add(dr["VendorCode"]);
                }
            }
            rdsortcode.Checked = true;
            rdbsummer.Checked = true;
            if (GeneralFunctions.languagechioce != "")
            {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }
        }

        private void rdvendorcode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdvendorcode.Checked == true)
            {
                DTVendor.Clear();
                DTVendor.AcceptChanges();
                adaptertbVendor = new SqlDataAdapter("SELECT APVendors.VendorCode, APVendors.VendorName FROM APVendors ", sqlcon);
                adaptertbVendor.Fill(DTVendor);
                if (DTVendor.Rows.Count != 0)
                {
                    ListAvailable.Items.Clear();
                    ListSelect.Items.Clear();
                    foreach (DataRow dr in DTVendor.Rows)
                    {
                        if (!ListAvailable.Items.Contains(dr["VendorCode"]))
                            ListAvailable.Items.Add(dr["VendorCode"]);
                    }
                    ListAvailable.Sorted = true;
                }
            }
        }

        private void rdvendorname_CheckedChanged(object sender, EventArgs e)
        {
            if (rdvendorname.Checked == true)
            {
                DTVendor.Clear();
                DTVendor.AcceptChanges();
                adaptertbVendor = new SqlDataAdapter("SELECT APVendors.VendorCode, APVendors.VendorName FROM APVendors ", sqlcon);
                adaptertbVendor.Fill(DTVendor);
                if (DTVendor.Rows.Count != 0)
                {
                    ListAvailable.Items.Clear();
                    ListSelect.Items.Clear();
                    foreach (DataRow dr in DTVendor.Rows)
                    {
                        if (!ListAvailable.Items.Contains(dr["VendorName"]))
                            ListAvailable.Items.Add(dr["VendorName"]);
                    }
                    ListAvailable.Sorted = true;
                }
            }

        }

        private void rdvendorcategory_CheckedChanged(object sender, EventArgs e)
        {
            if (rdvendorcategory.Checked == true)
            {
                DTVendor.Clear();
                DTVendor.AcceptChanges();
                adaptertbVendor = new SqlDataAdapter("SELECT APVendors.VendorCode, APVendors.VendorName,APVendorCategory.CategoryDescription FROM APVendors INNER JOIN APVendorCategory ON dbo.APVendors.VendorCategory = APVendorCategory.CategoryCode", sqlcon);
                adaptertbVendor.Fill(DTVendor);
                if (DTVendor.Rows.Count != 0)
                {
                    ListAvailable.Items.Clear();
                    ListSelect.Items.Clear();
                    foreach (DataRow dr in DTVendor.Rows)
                    {
                        if (!ListAvailable.Items.Contains(dr["CategoryDescription"]))
                            ListAvailable.Items.Add(dr["CategoryDescription"]);
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
                if (rdbsummer.Checked == false && rdbdetails.Checked == false)
                {
                    MessageBox.Show("Choose type of report", "General Ledger");
                    return;
                }
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

                commandReport2.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BudgetPlanning]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View RPTVendor";
                try
                {
                    readerReport2 = commandReport2.ExecuteReader();
                    readerReport2.Close();
                }
                catch (Exception ex)
                { }
                VendorList.FillVendorList();
                string s2 = "";
                s2 = "Create View RPTVendor AS SELECT TOP 100 PERCENT  dbo.RptVendorList.* FROM dbo.RptVendorList ";
                if (ListSelect.Items.Count > 0)
                {
                    if (rdvendorcode.Checked == true)
                        s2 = s2 + " Where VendorCode IN ('";
                    else if (rdvendorname.Checked == true)
                        s2 = s2 + " Where VendorName IN ('";
                    else if (rdvendorcategory.Checked == true)
                        s2 = s2 + " Where CategoryDescription IN ('";
                    string s = "";
                    foreach (object ob in ListSelect.Items)
                    {
                        s2 = s2 + s + ob.ToString() + "'";
                        s = ",'";
                    }
                    s2 = s2 + ")";
                }

                if (rdsortcode.Checked == true)
                    s2 = s2 + " ORDER BY dbo.RptVendorList.VendorCode";
                if (rdsortname.Checked == true)
                    s2 = s2 + " ORDER BY dbo.RptVendorList.VendorName";
                if (rdsortcategory.Checked == true)
                    s2 = s2 + " ORDER BY dbo.RptVendorList.CategoryDescription";

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
                    RPTVendorDet rpt = new RPTVendorDet();
                    rpt.ShowDialog();
                }
                else
                {
                    RPTVendorSumm rpt = new RPTVendorSumm();
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