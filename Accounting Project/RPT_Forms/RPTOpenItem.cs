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
    public partial class RPTOpenItem : Form
    {
        public RPTOpenItem()
        {
            InitializeComponent();
        }
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbVendor;
        private DataTable DTVendor;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private SqlDataAdapter adaptertbGeneralSetup;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        private SqlConnection connectReport2;
        private SqlDataReader readerReport2;

        private void RPTOpenItem_Load(object sender, EventArgs e)
        {
            dbAccountingProjectDS = new dbAccountingProjectDS();
            DTVendor = new DataTable();

            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbVendor = new SqlDataAdapter("SELECT APVendors.VendorCode, APVendors.VendorName FROM APVendors ", sqlcon);
            adaptertbVendor.Fill(DTVendor);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            {
                RPTOpenItems.decmial = short.Parse(dr["DecimalPointsNumber"].ToString());
            }
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
            this.label3.Text = obj_interface_language.lblAvailable;
            this.label4.Text = obj_interface_language.lblSelect;
            this.groupBox1.Text = obj_interface_language.Vendor;
            this.groupBox4.Text = obj_interface_language.groupSelectOptions;
            this.groupBox3.Text = obj_interface_language.Report_Display;
            this.rdsortcode.Text = obj_interface_language.SortCode;
            this.rdsortname.Text = obj_interface_language.SortName;
            this.rdsortcategory.Text = obj_interface_language.SortCategory;
            this.rdvendorcode.Text = obj_interface_language.VendorCode;
            this.rdvendorname.Text = obj_interface_language.VendorName;
            this.rdvendorcategory.Text = obj_interface_language.VendorCategory;

            this.btnReport.Text = obj_interface_language.btnReport;

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
                if (rdsortcode.Checked == false && rdsortname.Checked == false && rdsortcategory.Checked == false && rdsortDueDate.Checked == false)
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

                commandReport2.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BudgetPlanning]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View RPTAPItemOpen";
                try
                {
                    readerReport2 = commandReport2.ExecuteReader();
                    readerReport2.Close();
                }
                catch (Exception ex)
                { }
                string s2 = "";
                s2 = "Create View RPTAPItemOpen AS SELECT TOP 100 PERCENT   dbo.Batch.BatchNo, dbo.APTrans.BatchInvoiceID, dbo.APTrans.VendorCode, dbo.APTrans.VendorName, dbo.APTrans.InvoiceDate, " +
                      "dbo.APTrans.TransactionType, dbo.APTrans.PONumber, dbo.APTrans.PayDate, dbo.APTrans.DueDays, " +
                      "dbo.APTrans.InvoiceAmount - dbo.APTrans.TaxValue AS Inv_Amount, dbo.APTrans.AmountPaid, dbo.APVendorCategory.CategoryDescription, dbo.Batch.BatchDate," +
                      "dbo.APTrans.InvoiceAmount - dbo.APTrans.TaxValue - dbo.APTrans.AmountPaid AS Balance, dbo.APTrans.Paid " +
                      " FROM  dbo.Batch INNER JOIN  dbo.APTrans ON dbo.Batch.BatchNo = dbo.APTrans.APBatchNumber INNER JOIN dbo.APVendors ON dbo.APTrans.VendorCode = dbo.APVendors.VendorCode INNER JOIN " +
                      " dbo.APVendorCategory ON dbo.APVendors.VendorCategory = dbo.APVendorCategory.CategoryCode " +
                      " WHERE (dbo.APTrans.Paid = 0)  AND (dbo.Batch.BatchStat = 'P')";
                if (ListSelect.Items.Count > 0)
                {
                    if (rdvendorcode.Checked == true)
                        s2 = s2 + " AND dbo.APTrans.VendorCode IN ('";
                    else if (rdvendorname.Checked == true)
                        s2 = s2 + " AND dbo.APTrans.VendorName IN ('";
                    else if (rdvendorcategory.Checked == true)
                        s2 = s2 + " AND dbo.APVendorCategory.CategoryDescription IN ('";
                    string s = "";
                    foreach (object ob in ListSelect.Items)
                    {
                        s2 = s2 + s + ob.ToString() + "'";
                        s = ",'";
                    }
                    s2 = s2 + ")";
                }

                if (rdsortcode.Checked == true)
                    s2 = s2 + " ORDER BY dbo.APTrans.VendorCode";
                if (rdsortname.Checked == true)
                    s2 = s2 + " ORDER BY dbo.APTrans.VendorName";
                if (rdsortcategory.Checked == true)
                    s2 = s2 + " ORDER BY dbo.APVendorCategory.CategoryDescription";
                if (rdsortDueDate.Checked == true)
                    s2 = s2 + " ORDER BY dbo.APTrans.DueDays";

                commandReport2.CommandText = s2;
                try
                {
                    readerReport2 = commandReport2.ExecuteReader();
                    readerReport2.Close();
                }
                catch (Exception ex)
                { }
                RPTOpenItems rpt = new RPTOpenItems();
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