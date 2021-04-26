using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Accounting_GeneralLedger.Resources;

namespace Accounting_GeneralLedger
{
    public partial class ARGenerateInvoice : Form
    {
        public ARGenerateInvoice()
        {
            InitializeComponent();
        }
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbBatch;
        private SqlDataAdapter adaptertbInvoices;
        private SqlDataAdapter adaptertbARtrans;
        private SqlDataAdapter adaptertbGenInvoice;
        private SqlCommandBuilder cmdBuilderInvoices;
        private SqlCommandBuilder cmdBuilderARtrans;
        private DataTable InvoiceDT;
        private dbAccountingProjectDS dbAccountingProjectDS;

        private void chkdaterange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkdaterange.Checked == true)
            {
                dtp_from.Enabled = true;
                dtp_to.Enabled = true;
            }
            else
            {
                dtp_from.Enabled = false;
                dtp_to.Enabled = false;
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                dgv.Rows.Clear();
                string datasearsh = "";
                if (txtARCode.Text.Trim() != "")
                    datasearsh = "AccountCode like '" + txtARCode.Text.Trim() + "'";
                if (chkdaterange.Checked == true)
                {
                    if (datasearsh != "")
                        datasearsh += " AND (Invoice_Date >= '" + dtp_from.Value.Date + "' AND Invoice_Date <= '" + dtp_to.Value.Date + "')";
                    else
                        datasearsh += " (Invoice_Date >= '" + dtp_from.Value.Date + "' AND Invoice_Date <= '" + dtp_to.Value.Date + "')";
                }
                DataRow[] drs;
                drs = InvoiceDT.Select(datasearsh);
                if (drs.Length != 0)
                {
                    for (int i = 0; i < drs.Length; i++)
                    {
                        dgv.Rows.Add(new object[] {false,
                                               drs[i]["Voucher#"].ToString(),
                                               drs[i]["Batch#"].ToString(),
                                               drs[i]["Invoice_Date"],
                                               drs[i]["Amount"],
                                               drs[i]["CodeTran"].ToString(),
                                               drs[i]["AccountCode"].ToString(),
                                               drs[i]["AccountName"].ToString(),
                                               drs[i]["Invoice#"].ToString()});
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ARGenerateInvoice_Load(object sender, EventArgs e)
        {
            string msg = GeneralFunctions.CheckLockTables("", "ARGenerateInvoice", "", "Open");
            if (msg != "")
            {
                MessageBox.Show("ARGenerateInvoice Open By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btn_Generated.Visible = false;
            }
            GeneralFunctions.LockTables("", "ARGenerateInvoice", "", "Open");
            InvoiceDT = new DataTable();
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            dbAccountingProjectDS = new dbAccountingProjectDS();
            adaptertbBatch = new SqlDataAdapter("Select * from Batch", sqlcon);
            adaptertbInvoices = new SqlDataAdapter("Select * from GenerateInvoice", sqlcon);
            adaptertbGenInvoice = new SqlDataAdapter("SELECT TOP 100 PERCENT dbo.ARtrans.TransNO AS Voucher#,dbo.Batch.BatchNo AS Batch#, dbo.ARtrans.TRANSDATE AS Invoice_Date, dbo.ARtrans.AmountLC AS Amount, dbo.ARtrans.CodeTran, dbo.ARtrans.AccountCode, dbo.ARtrans.AccountName, dbo.ARtrans.GenInv AS Invoice# FROM dbo.ARtrans INNER JOIN dbo.Batch ON dbo.ARtrans.BatchNo = dbo.Batch.BatchNo Where dbo.Batch.BatchSRC = 'AR' AND dbo.ARtrans.GenInv = 0 AND dbo.ARtrans.AmountLC >= 0 ORDER BY dbo.ARtrans.TRANSDATE", sqlcon);
            adaptertbARtrans = new SqlDataAdapter("Select * from ARtrans", sqlcon);
            cmdBuilderInvoices = new SqlCommandBuilder();
            cmdBuilderARtrans = new SqlCommandBuilder();
            cmdBuilderInvoices.DataAdapter = adaptertbInvoices;
            cmdBuilderARtrans.DataAdapter = adaptertbARtrans;
            adaptertbBatch.Fill(dbAccountingProjectDS.Batch);
            adaptertbInvoices.Fill(dbAccountingProjectDS.GenerateInvoice);
            adaptertbARtrans.Fill(dbAccountingProjectDS.ARtrans);
            adaptertbGenInvoice.Fill(InvoiceDT);
            foreach (DataGridViewColumn c in dgv.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
                c.ReadOnly = true;
            }
            dgv.Columns[0].ReadOnly = false;

        }

        private void txtARCode_DoubleClick(object sender, EventArgs e)
        {
            SearchCustomer search = new SearchCustomer();
            search.ShowDialog();
            if (search.selectedAccountCode != null && search.selectedAccountCode != "")
            {
                txtARCode.Text = search.selectedAccountCode;
            }
        }
        private int NewInvoiceNo()
        {
            int No = 0;
            DataRow[] drr = dbAccountingProjectDS.GenerateInvoice.Select("", "InvoiceNO");
            if (drr.Length != 0)
            {
                No = 1 + int.Parse(drr[drr.Length - 1]["InvoiceNO"].ToString());
            }
            else
            {
                No = 1;
            }
            return No;
        }
        private void btn_Generated_Click(object sender, EventArgs e)
        {
            try
            {
                int no = NewInvoiceNo();
                double total = 0;
                dgvInv.Rows.Clear();
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells[0].Value.ToString() == "True")
                    {
                        dgvInv.Rows.Add(dgv.Rows[i].Cells["vouchar"].Value,
                                        dgv.Rows[i].Cells["AccountCode"].Value,
                                        dgv.Rows[i].Cells["InvoiceDate"].Value,
                                        dgv.Rows[i].Cells["Amount"].Value,
                                        no);
                        total += double.Parse(dgv.Rows[i].Cells["Amount"].Value.ToString());
                    }
                }
                if (dgvInv.Rows.Count == 0)
                {
                    MessageBox.Show("Please Select One Invoice At least", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    GrpGenerat.Visible = true;
                    lbltotal.Text = "Total Amount : " + total.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            dgvInv.Rows.Clear();
            GrpGenerat.Visible = false;
        }

        private void chkselectall_CheckedChanged(object sender, EventArgs e)
        {
            if (chkselectall.Checked == true)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dgv.Rows[i].Cells[0].Value = true;
                }
                chkselectall.Text ="Deselect All";
            }
            else
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dgv.Rows[i].Cells[0].Value = false;
                }
                chkselectall.Text = "Select All";
            }
        }
        private void updatedatabase()
        {
            adaptertbARtrans.Update(dbAccountingProjectDS.ARtrans);
            adaptertbInvoices.Update(dbAccountingProjectDS.GenerateInvoice);
            dbAccountingProjectDS.ARtrans.AcceptChanges();
            dbAccountingProjectDS.GenerateInvoice.AcceptChanges();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            DataRow[] dra;
            DataRow r;
            if (dgvInv.Rows.Count != 0)
            {
                try
                {
                    for (int i = 0; i < dgvInv.Rows.Count; i++)
                    {
                        dra = dbAccountingProjectDS.ARtrans.Select("TransNO = '" + dgvInv.Rows[i].Cells["VoucharNO"].Value + "'");
                        if (dra.Length != 0)
                        {
                            dra[0]["GenInv"] = dgvInv.Rows[i].Cells["InvNo"].Value;
                            dra[0]["GenDate"] = DateTime.Now.Date;
                        }
                    }
                    r = dbAccountingProjectDS.GenerateInvoice.NewRow();
                    r["InvoiceNO"] = dgvInv.Rows[0].Cells["InvNo"].Value;
                    r["InvoiceDate"] = DateTime.Now.Date;
                    r["InvoiceDescription"] = "";
                    r["UserID"] = AaDeclrationClass.xUserCode;
                    dbAccountingProjectDS.GenerateInvoice.Rows.Add(r);
                    updatedatabase();
                    MessageBox.Show("Successed...", "Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InvoiceDT.Clear();
                    adaptertbGenInvoice = new SqlDataAdapter("SELECT TOP 100 PERCENT dbo.ARtrans.TransNO AS Voucher#,dbo.Batch.BatchNo AS Batch#, dbo.ARtrans.TRANSDATE AS Invoice_Date, dbo.ARtrans.AmountLC AS Amount, dbo.ARtrans.CodeTran, dbo.ARtrans.AccountCode, dbo.ARtrans.AccountName, dbo.ARtrans.GenInv AS Invoice# FROM dbo.ARtrans INNER JOIN dbo.Batch ON dbo.ARtrans.BatchNo = dbo.Batch.BatchNo Where dbo.Batch.BatchSRC = 'AR' AND dbo.ARtrans.GenInv = 0 AND dbo.ARtrans.AmountLC >= 0 ORDER BY dbo.ARtrans.TRANSDATE", sqlcon);
                    adaptertbGenInvoice.Fill(InvoiceDT);
                    dgv.Rows.Clear();
                    dgvInv.Rows.Clear();
                    GrpGenerat.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void ARGenerateInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralFunctions.UnLockTable("", "ARGenerateInvoice", "", "");
        }
    }
}