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
    public partial class APManualCheck : Form
    {
        //private SqlConnection sqlcon;

        public APManualCheck()
        {
            InitializeComponent();
        }
        private DataTable dtInvoice;
        private SqlDataAdapter adaptertbBatchInvoices;
        private SqlDataAdapter adaptertbInvoiceAccounts;
        private SqlCommandBuilder cmdBuilder;

        private void btn_SearchVendor_Click(object sender, EventArgs e)
        {
            VendorSearch search = new VendorSearch();
            search.ApplyCredits = "Credits";
            search.ShowDialog();
            if (search.selectedVendorCode != null)
            {
                if (search.selectedVendorCode != "")
                {
                    txt_VendorCode.Text = search.selectedVendorCode;
                    DataRow rc;
                    dtInvoice.Clear();
                    DataRow[] drs = dbAccountingProjectDS.APTrans.Select("VendorCode = '" + search.selectedVendorCode + "' AND TransactionType = 'Invoice' and MultiCurrency = 0 and Paid = 0 ", "InvoiceDate");
                    if (drs.Length != 0)
                    {
                        for (int i = 0; i < drs.Length; i++)
                        {
                            rc = dtInvoice.NewRow();
                            rc["InvoiceID"] = int.Parse(drs[i]["BatchInvoiceID"].ToString());
                            rc["Select"] = false;
                            rc["VendorCode"] = drs[i]["VendorCode"].ToString();
                            rc["InvoiceDate"] = Convert.ToDateTime(drs[i]["InvoiceDate"].ToString());
                            rc["Reference"] = drs[i]["Reference"].ToString();
                            rc["InvoiceAmount"] = double.Parse(drs[i]["InvoiceAmount"].ToString());
                            rc["TaxValue"] = double.Parse(drs[i]["TaxValue"].ToString());
                            rc["AmountPaid"] = double.Parse(drs[i]["AmountPaid"].ToString());
                            rc["Balance"] = double.Parse(drs[i]["InvoiceAmount"].ToString()) - double.Parse(drs[i]["TaxValue"].ToString()) - double.Parse(drs[i]["AmountPaid"].ToString());
                            rc["AmtApplied"] = 0;
                            rc["AppliedBalance"] = double.Parse(drs[i]["InvoiceAmount"].ToString()) - double.Parse(drs[i]["TaxValue"].ToString()) - double.Parse(drs[i]["AmountPaid"].ToString());
                            rc["Curr."] = drs[i]["CurrencyCode"].ToString();
                            dtInvoice.Rows.Add(rc);
                        }
                        dgv_AccountCharges.Refresh();
                    }
                    for (int c = 0; c < dgv_AccountCharges.ColumnCount - 1; c++)
                    {
                        dgv_AccountCharges.Columns[c].SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
            }
        }

        private void APManualCheck_Load(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbBatchInvoices = new SqlDataAdapter("Select * from APTrans", sqlcon);
            adaptertbInvoiceAccounts = new SqlDataAdapter("Select * from APExpense", sqlcon);
            cmdBuilder = new SqlCommandBuilder(adaptertbBatchInvoices);
            adaptertbBatchInvoices.Fill(dbAccountingProjectDS.APTrans);
            dtInvoice = new DataTable();
            dtInvoice.Columns.Add("InvoiceID", System.Type.GetType("System.Int32"));
            dtInvoice.Columns.Add("Select", System.Type.GetType("System.Boolean"));
            dtInvoice.Columns.Add("VendorCode", System.Type.GetType("System.String"));
            dtInvoice.Columns.Add("InvoiceDate", System.Type.GetType("System.DateTime"));
            dtInvoice.Columns.Add("Reference", System.Type.GetType("System.String"));
            dtInvoice.Columns.Add("InvoiceAmount", System.Type.GetType("System.Double"));
            dtInvoice.Columns.Add("TaxValue", System.Type.GetType("System.Double"));
            dtInvoice.Columns.Add("AmountPaid", System.Type.GetType("System.Double"));
            dtInvoice.Columns.Add("Balance", System.Type.GetType("System.Double"));
            dtInvoice.Columns.Add("AmtApplied", System.Type.GetType("System.Double"));
            dtInvoice.Columns.Add("AppliedBalance", System.Type.GetType("System.Double"));
            dtInvoice.Columns.Add("Curr.", System.Type.GetType("System.String"));
            dgv_AccountCharges.DataSource = dtInvoice;
            dgv_AccountCharges.Refresh();
            dgv_AccountCharges.Columns["InvoiceID"].Visible = false;
            dgv_AccountCharges.Columns["VendorCode"].ReadOnly = true;
            dgv_AccountCharges.Columns["InvoiceDate"].ReadOnly = true;
            dgv_AccountCharges.Columns["Reference"].ReadOnly = true;
            dgv_AccountCharges.Columns["InvoiceAmount"].ReadOnly = true;
            dgv_AccountCharges.Columns["TaxValue"].ReadOnly = true;
            dgv_AccountCharges.Columns["AmountPaid"].ReadOnly = true;
            dgv_AccountCharges.Columns["Balance"].ReadOnly = true;
            dgv_AccountCharges.Columns["AppliedBalance"].ReadOnly = true;
            dgv_AccountCharges.Columns["Curr."].ReadOnly = true;
            dgv_AccountCharges.Columns["AmtApplied"].DefaultCellStyle.BackColor = Color.LightGray;
        }

        
    }
}