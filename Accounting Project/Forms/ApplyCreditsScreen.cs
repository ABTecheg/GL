using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Accounting_GeneralLedger.Resources;

namespace Accounting_GeneralLedger
{
    public partial class ApplyCreditsScreen : Form
    {
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbBatch;
        private SqlDataAdapter adaptertbGeneralSetup;
        private SqlDataAdapter adaptertbAPCredits;
        private SqlDataAdapter adaptertbBatchInvoices;
        private SqlDataAdapter adaptertbInvoiceAccounts;
        private SqlDataAdapter adaptertbCurrency;
        private SqlCommandBuilder cmdBuilder;
        private SqlCommandBuilder cmdBuilderAPCredits;
        private string applyMode = "";
        private DataTable dtCredits;
        private DataTable dtInvoice;
        private int decmal = 1;

        public ApplyCreditsScreen()
        {
            InitializeComponent();
        }

        private void ApplyCreditsScreen_Load(object sender, EventArgs e)
        {
            string msg = GeneralFunctions.CheckLockTables("", "ApplyCreditsScreen", "", "Open");
            if (msg != "")
            {
                MessageBox.Show("ApplyCreditsScreen Open By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btn_Save.Visible = false;
            }
            GeneralFunctions.LockTables("", "ApplyCreditsScreen", "", "Open");
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbAPCredits = new SqlDataAdapter("Select * from APCredits", sqlcon);
            adaptertbBatch = new SqlDataAdapter("Select * from Batch", sqlcon);
            adaptertbBatchInvoices = new SqlDataAdapter("Select * from APTrans", sqlcon);
            adaptertbInvoiceAccounts = new SqlDataAdapter("Select * from APExpense", sqlcon);
            adaptertbCurrency = new SqlDataAdapter("Select * from GLCurrency", sqlcon);

            cmdBuilder = new SqlCommandBuilder(adaptertbBatchInvoices);
            cmdBuilderAPCredits = new SqlCommandBuilder(adaptertbAPCredits);

            adaptertbBatch.Fill(dbAccountingProjectDS.Batch);
            adaptertbAPCredits.Fill(dbAccountingProjectDS.APCredits);
            adaptertbBatchInvoices.Fill(dbAccountingProjectDS.APTrans);
            adaptertbInvoiceAccounts.Fill(dbAccountingProjectDS.APExpense);
            adaptertbCurrency.Fill(dbAccountingProjectDS.GLCurrency);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            {
                decmal = int.Parse(dr["DecimalPointsNumber"].ToString());
            }
            dtCredits = new DataTable();
            dtCredits.Columns.Add("InvoiceID", System.Type.GetType("System.Int32"));
            dtCredits.Columns.Add("BatchNo", System.Type.GetType("System.Int32"));
            dtCredits.Columns.Add("VendorCode", System.Type.GetType("System.String"));
            dtCredits.Columns.Add("VendorName", System.Type.GetType("System.String"));
            dtCredits.Columns.Add("InvoiceDate", System.Type.GetType("System.DateTime"));
            dtCredits.Columns.Add("Reference", System.Type.GetType("System.String"));
            dtCredits.Columns.Add("Amount", System.Type.GetType("System.Double"));
            dtCredits.Columns.Add("AmountPaid", System.Type.GetType("System.Double"));
            dtCredits.Columns.Add("Balance_To_Apply", System.Type.GetType("System.Double"));
            dtCredits.Columns.Add("Curr.", System.Type.GetType("System.String"));
            dgv_CreditTransaction.DataSource = dtCredits;
            dgv_CreditTransaction.Refresh();
            dgv_CreditTransaction.Columns["InvoiceID"].Visible = false;
            dgv_CreditTransaction.Columns["BatchNo"].ReadOnly = true;
            dgv_CreditTransaction.Columns["VendorCode"].ReadOnly = true;
            dgv_CreditTransaction.Columns["VendorName"].ReadOnly = true;
            dgv_CreditTransaction.Columns["InvoiceDate"].ReadOnly = true;
            dgv_CreditTransaction.Columns["Reference"].ReadOnly = true;
            dgv_CreditTransaction.Columns["Amount"].ReadOnly = true;
            dgv_CreditTransaction.Columns["AmountPaid"].ReadOnly = true;
            dgv_CreditTransaction.Columns["Balance_To_Apply"].ReadOnly = true;
            dgv_CreditTransaction.Columns["Curr."].ReadOnly = true;
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

            LoadTransactions();
            label_Mode.Text = "Vendor Code";
            rd_Credits.Checked = true;

            cb_Currency = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLCurrency, cb_Currency, "CurrencyCode", "CurrencyNumber");
            if (GeneralFunctions.Ckecktag("15") != "M")
                cb_Currency.Items.Remove("<new>");
            cb_Currency = GeneralFunctions.RemoveBaseCurrency(cb_Currency);
        }

        private void LoadTransactions()
        {
            try
            {
                txt_Balance.Text = "0";
                DataRow rc;
                DataRow[] drb = dbAccountingProjectDS.Batch.Select("BatchSRC = 'AP' AND BatchStat = 'P'");
                string NOBatches = "";
                string s = "";
                if (drb.Length != 0)
                {
                    foreach (DataRow r in drb)
                    {
                        NOBatches = NOBatches + s + r["BatchNo"].ToString() + "'";
                        s = ",'";
                    }
                    NOBatches = "('" + NOBatches + ")";
                }
                if (NOBatches != "")
                {
                    if (cb_Currency.Text.Trim() != "")
                        drb = dbAccountingProjectDS.APTrans.Select("(TransactionType = 'CreditNote' or TransactionType = 'AdvancedDeposit') and MultiCurrency = 1 and Paid = 0 AND APBatchNumber IN " + NOBatches + " and CurrencyCode = '" + cb_Currency.Text + "'");
                    else
                        drb = dbAccountingProjectDS.APTrans.Select("(TransactionType = 'CreditNote' or TransactionType = 'AdvancedDeposit') and MultiCurrency = 0 and Paid = 0 AND APBatchNumber IN " + NOBatches + "");
                    dtCredits.Clear();
                    if (drb.Length != 0)
                    {
                        for (int i = 0; i < drb.Length; i++)
                        {
                            rc = dtCredits.NewRow();
                            rc["InvoiceID"] = int.Parse(drb[i]["BatchInvoiceID"].ToString());
                            rc["BatchNo"] = int.Parse(drb[i]["APBatchNumber"].ToString());
                            rc["VendorCode"] = drb[i]["VendorCode"].ToString();
                            rc["VendorName"] = drb[i]["VendorName"].ToString();
                            rc["InvoiceDate"] = Convert.ToDateTime(drb[i]["InvoiceDate"].ToString());
                            rc["Reference"] = drb[i]["Reference"].ToString();
                            rc["Amount"] = double.Parse(drb[i]["InvoiceAmount"].ToString());
                            rc["AmountPaid"] = double.Parse(drb[i]["AmountPaid"].ToString());
                            rc["Balance_To_Apply"] = double.Parse(drb[i]["InvoiceAmount"].ToString()) - double.Parse(drb[i]["AmountPaid"].ToString());
                            rc["Curr."] = drb[i]["CurrencyCode"].ToString();
                            dtCredits.Rows.Add(rc);
                        }
                        dgv_CreditTransaction.Refresh();
                    }
                    //UpdateCreditAccountValues();

                    dtInvoice.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            DataRow[] drs = dbAccountingProjectDS.APTrans.Select("TransactionType = 'CreditNote'");
            string NOBatches = "";
            string s = "";
            if (drs.Length != 0)
            {

                foreach (DataRow r in drs)
                {
                    NOBatches = NOBatches + s + r["APBatchNumber"].ToString() + "'";
                    s = ",'";
                }
                NOBatches = "('" + NOBatches + ")";
                DataRow[] drb = dbAccountingProjectDS.Batch.Select("BatchNo IN " + NOBatches + " AND BatchStat = 'P'");
                NOBatches = "";
                s = "";
                if (drb.Length != 0)
                {
                    foreach (DataRow r in drb)
                    {
                        NOBatches = NOBatches + s + r["BatchNo"].ToString() + "'";
                        s = ",'";
                    }
                    NOBatches = "('" + NOBatches + ")";
                }
            }
            if (applyMode == "VendorCode" )
            {
                if (NOBatches.Trim() == "")
                    NOBatches = " (-1)";
                drs = dbAccountingProjectDS.APTrans.Select("TransactionType = 'CreditNote' AND APBatchNumber IN " + NOBatches + "");
                VendorSearch search = new VendorSearch();
                if (drs.Length != 0)
                {
                    search.NOSearch = "";
                    s = "";
                    foreach (DataRow r in drs)
                    {
                        search.NOSearch = search.NOSearch + s + r["VendorCode"].ToString() + "'";
                        s = ",'";
                    }
                    search.NOSearch = "('" + search.NOSearch + ")";
                }
                search.ApplyCredits = "Credits";
                search.ShowDialog();
                if (search.selectedVendorCode != null)
                {
                    txt_Mode.Text = search.selectedVendorCode;
                    FindTransactions();
                }
            }
            if (applyMode == "Batch")
            {
                SearchAP search = new SearchAP();
                if (drs.Length != 0)
                {
                    search.NOSearch = "";
                    s = "";
                    foreach (DataRow r in drs)
                    {
                        search.NOSearch = search.NOSearch + s + r["APBatchNumber"].ToString() + "'";
                        s = ",'";
                    }
                    search.NOSearch = "('" + search.NOSearch + ")";
                }

                search.ApplyCredits = "Credits";
                search.ShowDialog();
                if (search.selectAPNumber != null)
                {
                    txt_Mode.Text = search.selectAPNumber;
                    FindTransactions();
                }
            }
        }


        private void rd_Batch_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_Batch.Checked)
            {
                applyMode = "Batch";
                rd_Credits.Checked = false;
                rd_VendorCode.Checked = false;
                label_Mode.Text = "Batch Number";
                txt_Mode.ReadOnly = false;
            }
        }

        private void rd_VendorCode_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_VendorCode.Checked)
            {
                applyMode = "VendorCode";
                rd_Credits.Checked = false;
                rd_Batch.Checked = false;
                label_Mode.Text = "Vendor Code";
                txt_Mode.ReadOnly = false;
            }
        }

        private void rd_Credits_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_Credits.Checked)
            {
                applyMode = "AllCredits";
                rd_VendorCode.Checked = false;
                rd_Batch.Checked = false;
                txt_Mode.ReadOnly = true;
                FindTransactions();
            }
        }

        private void FindTransactions()
        {
            txt_Balance.Text = "0";
            DataRow rc;
            string rowFilter = "";
            dtCredits.Clear();
            if (applyMode == "AllCredits")
            {
                LoadTransactions();
                return;
            }
            else if (applyMode == "VendorCode" && txt_Mode.Text != "")
                rowFilter = "(TransactionType = 'CreditNote' or TransactionType = 'AdvancedDeposit') and VendorCode = '" + txt_Mode.Text + "'";
            else if (applyMode == "Batch" && txt_Mode.Text != "")
                rowFilter = "(TransactionType = 'CreditNote' or TransactionType = 'AdvancedDeposit') and APBatchNumber = '" + txt_Mode.Text + "'";
            if (cb_Currency.Text != "" && txt_Mode.Text != "")
                rowFilter += " and CurrencyCode = '" + cb_Currency.Text + "'";
            else if (cb_Currency.Text == "" && txt_Mode.Text != "")
                rowFilter += " and CurrencyCode = ''";
            else if (cb_Currency.Text == "" && txt_Mode.Text == "")
                rowFilter += " and CurrencyCode = ''";
            else if (cb_Currency.Text != "" && txt_Mode.Text == "")
                rowFilter += "  CurrencyCode = '" + cb_Currency.Text + "'";
            DataRow[] drb = dbAccountingProjectDS.APTrans.Select(rowFilter + " and Paid = 0");
            if (drb.Length != 0)
            {
                for (int i = 0; i < drb.Length; i++)
                {
                    rc = dtCredits.NewRow();
                    rc["InvoiceID"] = int.Parse(drb[i]["BatchInvoiceID"].ToString());
                    rc["BatchNo"] = int.Parse(drb[i]["APBatchNumber"].ToString());
                    rc["VendorCode"] = drb[i]["VendorCode"].ToString();
                    rc["VendorName"] = drb[i]["VendorName"].ToString();
                    rc["InvoiceDate"] = Convert.ToDateTime(drb[i]["InvoiceDate"].ToString());
                    rc["Reference"] = drb[i]["Reference"].ToString();
                    rc["Amount"] = double.Parse(drb[i]["InvoiceAmount"].ToString());
                    rc["AmountPaid"] = double.Parse(drb[i]["AmountPaid"].ToString());
                    rc["Balance_To_Apply"] = double.Parse(drb[i]["InvoiceAmount"].ToString()) - double.Parse(drb[i]["AmountPaid"].ToString());
                    rc["Curr."] = drb[i]["CurrencyCode"].ToString();
                    dtCredits.Rows.Add(rc);
                }
                dgv_CreditTransaction.Refresh();
            }

        }

        private void cb_Currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Currency.Text == "<new>")
            {
                Currency currency = new Currency();
                currency.ShowDialog();
                cb_Currency.Items.Clear();
                adaptertbCurrency.Fill(dbAccountingProjectDS.GLCurrency);
                cb_Currency = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLCurrency, cb_Currency, "CurrencyCode", "CurrencyNumber");
                cb_Currency = GeneralFunctions.RemoveBaseCurrency(cb_Currency);
            }
            else
            {
                FindTransactions();
            }
        }

        private void UpdateAccountChargesValues()
        {
            DataGridViewRow r;
            double Paid = 0;
            for (int i = 0; i < dgv_AccountCharges.Rows.Count; i++)
            {
                r = dgv_AccountCharges.Rows[i];
                Paid = double.Parse(r.Cells["AmountPaid"].Value.ToString());

                if (Paid != 0)
                {
                    r.Cells["AmountPaid"].Value = Paid;
                    r.Cells["Balance"].Value = double.Parse(r.Cells["invoiceAmount"].Value.ToString()) - double.Parse(r.Cells["TaxValue"].Value.ToString()) - Paid;
                    r.Cells["AppliedBalance"].Value = r.Cells["Balance"].Value;
                    r.Cells["AmtApplied"].Value = 0;
                }
                else
                {
                    r.Cells["AmountPaid"].Value = 0.00;
                    r.Cells["Balance"].Value = double.Parse(r.Cells["invoiceAmount"].Value.ToString()) - double.Parse(r.Cells["TaxValue"].Value.ToString());
                    r.Cells["AppliedBalance"].Value = r.Cells["Balance"].Value;
                    r.Cells["AmtApplied"].Value = 0;
                }
            }
        }
        private void btn_Distribute_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow r;
                if (txt_Balance.Text != "")
                {
                    for (int i = 0; i < dgv_AccountCharges.Rows.Count; i++)
                    {
                        r = dgv_AccountCharges.Rows[i];
                        if (dgv_AccountCharges.Rows[i].Cells["Select"].Value != null)
                        {
                            if (dgv_AccountCharges.Rows[i].Cells["Select"].Value.ToString() == "True")
                            {
                                double Balance = double.Parse(r.Cells["AppliedBalance"].Value.ToString());
                                double BalanceToApply = double.Parse(txt_Balance.Text);
                                if (Balance <= BalanceToApply)
                                {
                                    r.Cells["AmtApplied"].Value = double.Parse(r.Cells["AmtApplied"].Value.ToString()) + Balance;
                                    BalanceToApply -= Balance;
                                    txt_Balance.Text = BalanceToApply.ToString();
                                    r.Cells["AppliedBalance"].Value = 0;
                                }
                                else
                                {
                                    double ApplyAmount = BalanceToApply;
                                    r.Cells["AmtApplied"].Value = double.Parse(r.Cells["AmtApplied"].Value.ToString()) + ApplyAmount;
                                    BalanceToApply -= ApplyAmount;
                                    txt_Balance.Text = BalanceToApply.ToString();
                                    r.Cells["AppliedBalance"].Value = Balance - ApplyAmount;
                                }
                            }
                        }
                        CalcBalance();
                    }
                }
                else
                    MessageBox.Show("Please Select the credit to distribute", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList IDArr = new ArrayList();
                int ID = 0;
                int InvIDPay = 0;
                DataRow dr;
                DataRow[] drs;
                DataGridViewRow r;
                double total = 0;
                foreach (DataGridViewRow rb in dgv_AccountCharges.Rows)
                {
                    total = total + double.Parse(rb.Cells["AmtApplied"].Value.ToString());
                }
                if (total != 0)
                {
                    r = dgv_CreditTransaction.CurrentRow;
                    ID = int.Parse(r.Cells["InvoiceID"].Value.ToString().Trim());
                    InvIDPay = ID;
                    drs = dbAccountingProjectDS.APTrans.Select("BatchInvoiceID = " + ID);
                    if (drs.Length != 0)
                    {
                        drs[0]["AmountPaid"] = double.Parse(drs[0]["AmountPaid"].ToString()) + total;
                        if (double.Parse(drs[0]["AmountPaid"].ToString()) == double.Parse(drs[0]["InvoiceAmount"].ToString()))
                            drs[0]["Paid"] = true;
                    }
                    dr = dbAccountingProjectDS.APCredits.NewRow();
                    dr["CreditID"] = NewCreditID();
                    dr["InvoiceID"] = ID;
                    dr["CreditAmount"] = total;
                    dr["CreditDate"] = DateTime.Now.ToShortDateString();
                    dr["UserID"] = AaDeclrationClass.xUserCode;
                    dr["InvIDPay"] = 0;
                    dbAccountingProjectDS.APCredits.Rows.Add(dr);
                }
                for (int i = 0; i < dgv_AccountCharges.Rows.Count; i++)
                {
                    r = dgv_AccountCharges.Rows[i];
                    ID = int.Parse(r.Cells["InvoiceID"].Value.ToString().Trim());
                    double Balance = double.Parse(r.Cells["AppliedBalance"].Value.ToString());
                    double PaidAmount = double.Parse(r.Cells["AmountPaid"].Value.ToString());
                    double AmtApplied = double.Parse(r.Cells["AmtApplied"].Value.ToString());
                    drs = dbAccountingProjectDS.APTrans.Select("BatchInvoiceID = " + ID);
                    if (drs.Length != 0)
                    {
                        drs[0]["AmountPaid"] = PaidAmount + AmtApplied;
                        if (Balance == 0)
                            drs[0]["Paid"] = true;
                    }
                    if (AmtApplied != 0)
                    {
                        dr = dbAccountingProjectDS.APCredits.NewRow();
                        dr["CreditID"] = NewCreditID();
                        dr["InvoiceID"] = ID;
                        dr["CreditAmount"] = AmtApplied;
                        dr["CreditDate"] = DateTime.Now.ToShortDateString();
                        dr["UserID"] = AaDeclrationClass.xUserCode;
                        dr["InvIDPay"] = InvIDPay;
                        dbAccountingProjectDS.APCredits.Rows.Add(dr);
                        if (Balance == 0)
                            IDArr.Add(ID);
                    }
                }
                UpdateDatabase();
                LoadTransactions();

                MessageBox.Show("Save Successfully", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int NewCreditID()
        {
            int No = 0;
            DataRow[] drr = dbAccountingProjectDS.APCredits.Select("", "CreditID");
            if (drr.Length != 0)
            {
                No = 1 + int.Parse(drr[drr.Length - 1]["CreditID"].ToString());
            }
            else
            {
                No = 1;
            }
            return No;
        }
        private void UpdateDatabase()
        {
            adaptertbAPCredits.Update(dbAccountingProjectDS.APCredits);
            adaptertbBatchInvoices.Update(dbAccountingProjectDS.APTrans);
            dbAccountingProjectDS.APTrans.AcceptChanges();
            dbAccountingProjectDS.APCredits.AcceptChanges();
        }

        private void dgv_CreditTransaction_MouseClick(object sender, MouseEventArgs e)
        {
            DataRow rc;
            if (dgv_CreditTransaction.CurrentRow.Cells["Balance_To_Apply"].Value != null)
                txt_Balance.Text = dgv_CreditTransaction.CurrentRow.Cells["Balance_To_Apply"].Value.ToString();

            DataRow[] drb = dbAccountingProjectDS.Batch.Select("BatchSRC = 'AP' AND BatchStat = 'P'");
            string NOBatches = "";
            string s = "";
            if (drb.Length != 0)
            {
                foreach (DataRow r in drb)
                {
                    NOBatches = NOBatches + s + r["BatchNo"].ToString() + "'";
                    s = ",'";
                }
                NOBatches = "('" + NOBatches + ")";
            }
            if (dgv_CreditTransaction.CurrentRow.Cells["VendorCode"].Value.ToString().Trim() != "")
            {
                dtInvoice.Clear();
                DataRow[] drs = dbAccountingProjectDS.APTrans.Select("VendorCode = '" + dgv_CreditTransaction.SelectedRows[0].Cells["VendorCode"].Value.ToString().Trim() + "' AND TransactionType = 'Invoice' and MultiCurrency = 0 and Paid = 0 AND APBatchNumber IN " + NOBatches, "InvoiceDate");
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

        private void dgv_AccountCharges_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dgv_AccountCharges_Control_KeyPress);

            e.Control.KeyPress += new KeyPressEventHandler(dgv_AccountCharges_Control_KeyPress);

        }
        private void dgv_AccountCharges_Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgv_AccountCharges.CurrentCell.ColumnIndex == 9)
            {
                if (e.KeyChar == 8)
                {

                    e.Handled = false;

                }
                else if (e.KeyChar >= 48 && e.KeyChar <= 57)
                {
                    if (dgv_AccountCharges.EditingControl.Text.ToString().Contains("."))
                    {
                        char c = '.';
                        string[] sc = dgv_AccountCharges.EditingControl.Text.ToString().Split(c);

                        if (sc[1].Length < decmal)
                        {
                            e.Handled = false;

                        }
                        else
                            e.Handled = true;

                    }
                    else
                    {
                        e.Handled = false;

                    }
                }
                else if (e.KeyChar == 46)
                {
                    if (dgv_AccountCharges.EditingControl.Text.ToString().Contains(".") == false)
                    {
                        e.Handled = false;

                    }
                    else
                        e.Handled = true;
                }
                else
                    e.Handled = true;
            }
        }

        private void dgv_AccountCharges_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (txt_Balance.Text == "" || txt_Balance.Text == "0")
            {
                MessageBox.Show("Select Invoice To Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgv_AccountCharges.EndEdit();
            }
        }
        private void CalcBalance()
        {
            double total = double.Parse(dgv_CreditTransaction.CurrentRow.Cells["Balance_To_Apply"].Value.ToString());
            double b = 0;
            foreach (DataGridViewRow r in dgv_AccountCharges.Rows)
            {
                b = b + double.Parse(r.Cells["AmtApplied"].Value.ToString());
            }
            total = total - b;
            txt_Balance.Text = total.ToString();
        }
        private void dgv_AccountCharges_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (txt_Balance.Text == "")
                return;
            double totalbalance = double.Parse(txt_Balance.Text);
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (dgv_AccountCharges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null &&
                    dgv_AccountCharges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
                {
                    if (e.ColumnIndex == 9)
                    {
                        double AmtApplied = double.Parse(dgv_AccountCharges.Rows[e.RowIndex].Cells["AmtApplied"].Value.ToString());
                        double balance = double.Parse(dgv_AccountCharges.Rows[e.RowIndex].Cells["Balance"].Value.ToString());
                        if (balance < AmtApplied || totalbalance < AmtApplied)
                        {
                            dgv_AccountCharges.Rows[e.RowIndex].Cells["AmtApplied"].Value = 0;
                            dgv_AccountCharges.Rows[e.RowIndex].Cells["AppliedBalance"].Value = balance;
                            MessageBox.Show("Invalid Amount, The Amount Applied cant exceed the invoice balance amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            dgv_AccountCharges.Rows[e.RowIndex].Cells["AppliedBalance"].Value = balance - AmtApplied;
                        }
                        CalcBalance();
                    }
                }
                else
                    dgv_AccountCharges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
            }
        }

        private void ApplyCreditsScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralFunctions.UnLockTable("", "ApplyCreditsScreen", "", "");
        }
    }
}