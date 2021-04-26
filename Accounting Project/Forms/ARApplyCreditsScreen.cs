using System; using Accounting_GeneralLedger.Report;
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
    public partial class ARApplyCreditsScreen : Form
    {
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbBatch;
        private SqlDataAdapter adaptertbGeneralSetup;
        private SqlDataAdapter adaptertbARCredits;
        private SqlDataAdapter adaptertbBatchInvoices;
        private SqlDataAdapter adaptertbInvoiceAccounts;
        private SqlDataAdapter adaptertbCurrency;
        private SqlCommandBuilder cmdBuilder;
        private SqlCommandBuilder cmdBuilderARCredits;
        private string applyMode = "";
        private string NOBatchesAR = "";
        private string NOTranARCredit = "";
        private string NOBatchesARP = "";
        private DataTable dtCredits;
        private DataTable dtInvoice;
        private int decmal = 1;

        public ARApplyCreditsScreen()
        {
            InitializeComponent();
        }

        private void ApplyCreditsScreen_Load(object sender, EventArgs e)
        {
            string msg = GeneralFunctions.CheckLockTables("", "ARApplyCreditsScreen", "", "Open");
            if (msg != "")
            {
                MessageBox.Show("ARApplyCreditsScreen Open By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btn_Save.Visible = false;
            }
            GeneralFunctions.LockTables("", "ARApplyCreditsScreen", "", "Open");
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbARCredits = new SqlDataAdapter("Select * from ARCredits", sqlcon);
            adaptertbBatch = new SqlDataAdapter("Select * from Batch", sqlcon);
            adaptertbBatchInvoices = new SqlDataAdapter("Select * from ARtrans", sqlcon);
            adaptertbInvoiceAccounts = new SqlDataAdapter("Select * from APExpense", sqlcon);
            adaptertbCurrency = new SqlDataAdapter("Select * from GLCurrency", sqlcon);

            cmdBuilder = new SqlCommandBuilder(adaptertbBatchInvoices);
            cmdBuilderARCredits = new SqlCommandBuilder(adaptertbARCredits);

            adaptertbBatch.Fill(dbAccountingProjectDS.Batch);
            adaptertbARCredits.Fill(dbAccountingProjectDS.ARCredits);
            adaptertbBatchInvoices.Fill(dbAccountingProjectDS.ARtrans);
            adaptertbInvoiceAccounts.Fill(dbAccountingProjectDS.APExpense);
            adaptertbCurrency.Fill(dbAccountingProjectDS.GLCurrency);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            {
                decmal = int.Parse(dr["DecimalPointsNumber"].ToString());
            }
            DataRow[] drbatch = dbAccountingProjectDS.Batch.Select("BatchSRC = 'ARP' AND BatchStat = 'P'");
            string NOBatches = "";
            string s = "";
            if (drbatch.Length != 0)
            {
                foreach (DataRow r in drbatch)
                {
                    NOBatches = NOBatches + s + r["BatchNo"].ToString() + "'";
                    s = ",'";
                }
                NOBatches = "('" + NOBatches + ")";
            }
            NOBatchesARP = NOBatches;
            drbatch = dbAccountingProjectDS.Batch.Select("BatchSRC = 'AR' AND BatchStat = 'P'");
            NOBatches = "";
            s = "";
            if (drbatch.Length != 0)
            {
                foreach (DataRow r in drbatch)
                {
                    NOBatches = NOBatches + s + r["BatchNo"].ToString() + "'";
                    s = ",'";
                }
                NOBatches = "('" + NOBatches + ")";
            }
            NOBatchesAR = NOBatches;
            drbatch = dbAccountingProjectDS.Batch.Select("BatchSRC = 'AR' AND BatchStat = 'P'");
            NOBatches = "";
            s = "";
            if (drbatch.Length != 0)
            {
                foreach (DataRow r in drbatch)
                {
                    NOBatches = NOBatches + s + r["BatchNo"].ToString() + "'";
                    s = ",'";
                }
                NOBatches = "('" + NOBatches + ")";
            }
            DataRow[] drtrancr;
            if (NOBatches == "")
                drtrancr = dbAccountingProjectDS.ARtrans.Select("Paid = 'N' AND BatchNo IN (0) AND AmountLC < 0 ");
            else
                drtrancr = dbAccountingProjectDS.ARtrans.Select("Paid = 'N' AND BatchNo IN " + NOBatches + " AND AmountLC < 0 ");
            NOBatches = "";
            s = "";
            if (drtrancr.Length != 0)
            {
                foreach (DataRow r in drtrancr)
                {
                    NOBatches = NOBatches + s + r["TransNO"].ToString() + "'";
                    s = ",'";
                }
                NOBatches = "('" + NOBatches + ")";
            }
            NOTranARCredit = NOBatches;
            dtCredits = new DataTable();
            dtCredits.Columns.Add("InvoiceID", System.Type.GetType("System.Int32"));
            dtCredits.Columns.Add("BatchNo", System.Type.GetType("System.Int32"));
            dtCredits.Columns.Add("AccountCode", System.Type.GetType("System.String"));
            dtCredits.Columns.Add("AccountName", System.Type.GetType("System.String"));
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
            dgv_CreditTransaction.Columns["AccountCode"].ReadOnly = true;
            dgv_CreditTransaction.Columns["AccountName"].ReadOnly = true;
            dgv_CreditTransaction.Columns["InvoiceDate"].ReadOnly = true;
            dgv_CreditTransaction.Columns["Reference"].ReadOnly = true;
            dgv_CreditTransaction.Columns["Amount"].ReadOnly = true;
            dgv_CreditTransaction.Columns["AmountPaid"].ReadOnly = true;
            dgv_CreditTransaction.Columns["Balance_To_Apply"].ReadOnly = true;
            dgv_CreditTransaction.Columns["Curr."].ReadOnly = true;
            
            dtInvoice = new DataTable();
            dtInvoice.Columns.Add("InvoiceID", System.Type.GetType("System.Int32"));
            dtInvoice.Columns.Add("Select", System.Type.GetType("System.Boolean"));
            dtInvoice.Columns.Add("AccountCode", System.Type.GetType("System.String"));
            dtInvoice.Columns.Add("InvoiceDate", System.Type.GetType("System.DateTime"));
            dtInvoice.Columns.Add("Reference", System.Type.GetType("System.String"));
            dtInvoice.Columns.Add("InvoiceAmount", System.Type.GetType("System.Double"));
            dtInvoice.Columns.Add("AmountPaid", System.Type.GetType("System.Double"));
            dtInvoice.Columns.Add("Balance", System.Type.GetType("System.Double"));
            dtInvoice.Columns.Add("AmtApplied", System.Type.GetType("System.Double"));
            dtInvoice.Columns.Add("AppliedBalance", System.Type.GetType("System.Double"));
            dtInvoice.Columns.Add("Curr.", System.Type.GetType("System.String"));
            dgv_AccountCharges.DataSource = dtInvoice;
            dgv_AccountCharges.Refresh();
            dgv_AccountCharges.Columns["InvoiceID"].Visible = false;
            dgv_AccountCharges.Columns["AccountCode"].ReadOnly = true;
            dgv_AccountCharges.Columns["InvoiceDate"].ReadOnly = true;
            dgv_AccountCharges.Columns["Reference"].ReadOnly = true;
            dgv_AccountCharges.Columns["InvoiceAmount"].ReadOnly = true;
            dgv_AccountCharges.Columns["AmountPaid"].ReadOnly = true;
            dgv_AccountCharges.Columns["Balance"].ReadOnly = true;
            dgv_AccountCharges.Columns["AppliedBalance"].ReadOnly = true;
            dgv_AccountCharges.Columns["Curr."].ReadOnly = true;
            dgv_AccountCharges.Columns["AmtApplied"].DefaultCellStyle.BackColor = Color.LightGray;

            LoadTransactions();
            label_Mode.Text = "Account Code";
            rd_Credits.Checked = true;

            cb_Currency = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLCurrency, cb_Currency, "CurrencyCode", "CurrencyNumber");
            if (GeneralFunctions.Ckecktag("15") != "M")
                cb_Currency.Items.Remove("<new>");
            cb_Currency = GeneralFunctions.RemoveBaseCurrency(cb_Currency);
        }

        private void LoadTransactions()
        {
            txt_Balance.Text = "0";
            DataRow rc;
            DataRow[] drb = dbAccountingProjectDS.Batch.Select("BatchSRC = 'ARP' AND BatchStat = 'P'");
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
            if (NOBatches == "")
            {
                if (cb_Currency.Text.Trim() != "")
                    drb = dbAccountingProjectDS.ARtrans.Select(" CurrencyType <> '' and Paid = 'N' AND BatchNo IN (0) and CurrencyType = '" + cb_Currency.Text + "'");
                else
                    drb = dbAccountingProjectDS.ARtrans.Select(" CurrencyType = '' and Paid = 'N' AND BatchNo IN (0)");
            }
            else
            {
                if (cb_Currency.Text.Trim() != "")
                    drb = dbAccountingProjectDS.ARtrans.Select(" CurrencyType <> '' and Paid = 'N' AND BatchNo IN " + NOBatches + " and CurrencyType = '" + cb_Currency.Text + "'");
                else
                    drb = dbAccountingProjectDS.ARtrans.Select(" CurrencyType = '' and Paid = 'N' AND BatchNo IN " + NOBatches);
            }
             dtCredits.Clear();
             if (drb.Length != 0)
             {
                 for (int i = 0; i < drb.Length; i++)
                 {
                     rc = dtCredits.NewRow();
                     rc["InvoiceID"] = int.Parse(drb[i]["TransNO"].ToString());
                     rc["BatchNo"] = int.Parse(drb[i]["BatchNo"].ToString());
                     rc["AccountCode"] = drb[i]["AccountCode"].ToString();
                     rc["AccountName"] = drb[i]["AccountName"].ToString();
                     rc["InvoiceDate"] = Convert.ToDateTime(drb[i]["TRANSDATE"].ToString());
                     rc["Reference"] = drb[i]["TRANSREF"].ToString();
                     if (double.Parse(drb[i]["AmountLC"].ToString()) < 0)
                         rc["Amount"] = -1 * double.Parse(drb[i]["AmountLC"].ToString());
                     else
                         rc["Amount"] = double.Parse(drb[i]["AmountLC"].ToString());
                     rc["AmountPaid"] = double.Parse(drb[i]["AmountPaid"].ToString());
                     if (double.Parse(drb[i]["AmountLC"].ToString()) < 0)
                         rc["Balance_To_Apply"] = (-1 * double.Parse(drb[i]["AmountLC"].ToString())) - double.Parse(drb[i]["AmountPaid"].ToString());
                     else
                         rc["Balance_To_Apply"] = double.Parse(drb[i]["AmountLC"].ToString()) - double.Parse(drb[i]["AmountPaid"].ToString());
                     rc["Curr."] = drb[i]["CurrencyType"].ToString();
                     dtCredits.Rows.Add(rc);
                 }
                 dgv_CreditTransaction.Refresh();
             }
             if (NOTranARCredit != "")
             {
                 if (cb_Currency.Text.Trim() != "")
                     drb = dbAccountingProjectDS.ARtrans.Select(" CurrencyType <> '' and Paid = 'N' AND TransNO IN " + NOTranARCredit + " and CurrencyType = '" + cb_Currency.Text + "'");
                 else
                     drb = dbAccountingProjectDS.ARtrans.Select(" CurrencyType = '' and Paid = 'N' AND TransNO IN " + NOTranARCredit);
                 if (drb.Length != 0)
                 {
                     for (int i = 0; i < drb.Length; i++)
                     {
                         rc = dtCredits.NewRow();
                         rc["InvoiceID"] = int.Parse(drb[i]["TransNO"].ToString());
                         rc["BatchNo"] = int.Parse(drb[i]["BatchNo"].ToString());
                         rc["AccountCode"] = drb[i]["AccountCode"].ToString();
                         rc["AccountName"] = drb[i]["AccountName"].ToString();
                         rc["InvoiceDate"] = Convert.ToDateTime(drb[i]["TRANSDATE"].ToString());
                         rc["Reference"] = drb[i]["TRANSREF"].ToString();
                         if (double.Parse(drb[i]["AmountLC"].ToString()) < 0)
                             rc["Amount"] = -1 * double.Parse(drb[i]["AmountLC"].ToString());
                         else
                             rc["Amount"] = double.Parse(drb[i]["AmountLC"].ToString());
                         rc["AmountPaid"] = double.Parse(drb[i]["AmountPaid"].ToString());
                         if (double.Parse(drb[i]["AmountLC"].ToString()) < 0)
                             rc["Balance_To_Apply"] = (-1 * double.Parse(drb[i]["AmountLC"].ToString())) - double.Parse(drb[i]["AmountPaid"].ToString());
                         else
                             rc["Balance_To_Apply"] = double.Parse(drb[i]["AmountLC"].ToString()) - double.Parse(drb[i]["AmountPaid"].ToString());
                         rc["Curr."] = drb[i]["CurrencyType"].ToString();
                         dtCredits.Rows.Add(rc);
                     }
                     dgv_CreditTransaction.Refresh();
                 }
             }
            //UpdateCreditAccountValues();

            dtInvoice.Clear();

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            DataRow[] drs;
            // drs = dbAccountingProjectDS.ARtrans.Select("TransactionType = 'CreditNote'");
            string NOBatches = "";
            string s = "";
            //if (drs.Length != 0)
            //{

            //    foreach (DataRow r in drs)
            //    {
            //        NOBatches = NOBatches + s + r["APBatchNumber"].ToString() + "'";
            //        s = ",'";
            //    }
            //    NOBatches = "('" + NOBatches + ")";
            //}
            DataRow[] drb = dbAccountingProjectDS.Batch.Select("BatchSRC = 'ARP' AND BatchStat = 'P'");
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
            if (applyMode == "AccountCode")
            {
                if (NOBatches == "")
                {
                    if (NOTranARCredit != "")
                        drs = dbAccountingProjectDS.ARtrans.Select(" ( Paid = 'N' AND BatchNo IN (0) ) OR  ( Paid = 'N' AND TransNO IN " + NOTranARCredit + ")");
                    else
                        drs = dbAccountingProjectDS.ARtrans.Select(" Paid = 'N' AND BatchNo IN (0)");
                }
                else
                {
                    if (NOTranARCredit != "")
                        drs = dbAccountingProjectDS.ARtrans.Select(" ( Paid = 'N' AND BatchNo IN " + NOBatches + " ) OR  ( Paid = 'N' AND TransNO IN " + NOTranARCredit + ")");
                    else
                        drs = dbAccountingProjectDS.ARtrans.Select(" Paid = 'N' AND BatchNo IN " + NOBatches);
                }
            SearchCustomer search = new SearchCustomer();
                if (drs.Length != 0)
                {
                    search.NOSearch = "";
                    s = "";
                    foreach (DataRow r in drs)
                    {
                        search.NOSearch = search.NOSearch + s + r["AccountCode"].ToString() + "'";
                        s = ",'";
                    }
                    search.NOSearch = "('" + search.NOSearch + ")";
                }
                search.ApplyCredits = "Credits";
                search.ShowDialog();
                if (search.selectedAccountCode != null && search.selectedAccountCode != "")
                {
                    txt_Mode.Text = search.selectedAccountCode;
                    FindTransactions();
                }
            }
            if (applyMode == "Batch")
            {
                if (NOBatchesARP == "")
                {
                    if (NOTranARCredit != "")
                        drs = dbAccountingProjectDS.ARtrans.Select(" ( Paid = 'N' AND BatchNo IN (0) ) OR ( Paid = 'N' AND TransNO IN " + NOTranARCredit + ")");
                    else
                        drs = dbAccountingProjectDS.ARtrans.Select(" Paid = 'N' AND BatchNo IN (0)");
                }
                else
                {
                    if (NOTranARCredit != "")
                        drs = dbAccountingProjectDS.ARtrans.Select(" ( Paid = 'N' AND BatchNo IN " + NOBatchesARP + " ) OR ( Paid = 'N' AND TransNO IN " + NOTranARCredit + ")");
                    else
                        drs = dbAccountingProjectDS.ARtrans.Select(" Paid = 'N' AND BatchNo IN " + NOBatchesARP);
                }
                SearchAR search = new SearchAR();
                if (drs.Length != 0)
                {
                    search.NOSearch = "";
                    s = "";
                    foreach (DataRow r in drs)
                    {
                        search.NOSearch = search.NOSearch + s + r["BatchNo"].ToString() + "'";
                        s = ",'";
                    }
                    search.NOSearch = "('" + search.NOSearch + ")";
                }

                search.ApplyCredits = "Credits";
                search.ShowDialog();
                if (search.selectARNumber != null && search.selectARNumber != "")
                {
                    txt_Mode.Text = search.selectARNumber;
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
                rd_ARCode.Checked = false;
                label_Mode.Text = "Batch Number";
                txt_Mode.ReadOnly = false;
            }
        }

        private void rd_VendorCode_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_ARCode.Checked)
            {
                applyMode = "AccountCode";
                rd_Credits.Checked = false;
                rd_Batch.Checked = false;
                label_Mode.Text = "Account Code";
                txt_Mode.ReadOnly = false;
            }
        }

        private void rd_Credits_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_Credits.Checked)
            {
                applyMode = "AllCredits";
                rd_ARCode.Checked = false;
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
            else if (applyMode == "AccountCode" && txt_Mode.Text != "")
                rowFilter = "AccountCode = '" + txt_Mode.Text + "'";
            else if (applyMode == "Batch" && txt_Mode.Text != "")
                rowFilter = "BatchNo = '" + txt_Mode.Text + "'";
            if (cb_Currency.Text != "" && txt_Mode.Text != "")
                rowFilter += " and CurrencyType = '" + cb_Currency.Text + "'";
            else if (cb_Currency.Text == "" && txt_Mode.Text != "")
                rowFilter += " and CurrencyType = ''";
            else if (cb_Currency.Text == "" && txt_Mode.Text == "")
                rowFilter += " and CurrencyType = ''";
            else if (cb_Currency.Text != "" && txt_Mode.Text == "")
                rowFilter += "  CurrencyType = '" + cb_Currency.Text + "'";
            DataRow[] drb;
            if (NOBatchesARP == "")
                drb = dbAccountingProjectDS.ARtrans.Select(rowFilter + " and Paid = 'N' AND BatchNo IN (0)");
            else
                drb = dbAccountingProjectDS.ARtrans.Select(rowFilter + " and Paid = 'N' AND BatchNo IN " + NOBatchesARP);
            if (drb.Length != 0)
            {
                for (int i = 0; i < drb.Length; i++)
                {
                    rc = dtCredits.NewRow();
                    rc["InvoiceID"] = int.Parse(drb[i]["TransNO"].ToString());
                    rc["BatchNo"] = int.Parse(drb[i]["BatchNo"].ToString());
                    rc["AccountCode"] = drb[i]["AccountCode"].ToString();
                    rc["AccountName"] = drb[i]["AccountName"].ToString();
                    rc["InvoiceDate"] = Convert.ToDateTime(drb[i]["TRANSDATE"].ToString());
                    rc["Reference"] = drb[i]["TRANSREF"].ToString();
                    if (double.Parse(drb[i]["AmountLC"].ToString()) < 0)
                        rc["Amount"] = -1 * double.Parse(drb[i]["AmountLC"].ToString());
                    else
                        rc["Amount"] = double.Parse(drb[i]["AmountLC"].ToString());
                    rc["AmountPaid"] = double.Parse(drb[i]["AmountPaid"].ToString());
                    if (double.Parse(drb[i]["AmountLC"].ToString()) < 0)
                        rc["Balance_To_Apply"] = (-1 * double.Parse(drb[i]["AmountLC"].ToString())) - double.Parse(drb[i]["AmountPaid"].ToString());
                    else
                        rc["Balance_To_Apply"] = double.Parse(drb[i]["AmountLC"].ToString()) - double.Parse(drb[i]["AmountPaid"].ToString());
                    rc["Curr."] = drb[i]["CurrencyType"].ToString();
                    dtCredits.Rows.Add(rc);
                }
                dgv_CreditTransaction.Refresh();
            }
            if (NOTranARCredit != "")
            {
                 drb = dbAccountingProjectDS.ARtrans.Select(rowFilter + " and Paid = 'N' AND TransNO IN " + NOTranARCredit);
                if (drb.Length != 0)
                {
                    for (int i = 0; i < drb.Length; i++)
                    {
                        rc = dtCredits.NewRow();
                        rc["InvoiceID"] = int.Parse(drb[i]["TransNO"].ToString());
                        rc["BatchNo"] = int.Parse(drb[i]["BatchNo"].ToString());
                        rc["AccountCode"] = drb[i]["AccountCode"].ToString();
                        rc["AccountName"] = drb[i]["AccountName"].ToString();
                        rc["InvoiceDate"] = Convert.ToDateTime(drb[i]["TRANSDATE"].ToString());
                        rc["Reference"] = drb[i]["TRANSREF"].ToString();
                        if (double.Parse(drb[i]["AmountLC"].ToString()) < 0)
                            rc["Amount"] = -1 * double.Parse(drb[i]["AmountLC"].ToString());
                        else
                            rc["Amount"] = double.Parse(drb[i]["AmountLC"].ToString());
                        rc["AmountPaid"] = double.Parse(drb[i]["AmountPaid"].ToString());
                        if (double.Parse(drb[i]["AmountLC"].ToString()) < 0)
                            rc["Balance_To_Apply"] = (-1 * double.Parse(drb[i]["AmountLC"].ToString())) - double.Parse(drb[i]["AmountPaid"].ToString());
                        else
                            rc["Balance_To_Apply"] = double.Parse(drb[i]["AmountLC"].ToString()) - double.Parse(drb[i]["AmountPaid"].ToString());
                        rc["Curr."] = drb[i]["CurrencyType"].ToString();
                        dtCredits.Rows.Add(rc);
                    }
                    dgv_CreditTransaction.Refresh();
                }
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
                    r.Cells["Balance"].Value = double.Parse(r.Cells["invoiceAmount"].Value.ToString())  - Paid;
                    r.Cells["AppliedBalance"].Value = r.Cells["Balance"].Value;
                    r.Cells["AmtApplied"].Value = 0;
                }
                else
                {
                    r.Cells["AmountPaid"].Value = 0.00;
                    r.Cells["Balance"].Value = double.Parse(r.Cells["invoiceAmount"].Value.ToString()) ;
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
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                    drs = dbAccountingProjectDS.ARtrans.Select("TransNO = " + ID);
                    if (drs.Length != 0)
                    {
                        drs[0]["AmountPaid"] = double.Parse(drs[0]["AmountPaid"].ToString()) + total;
                        drs[0]["PaidDate"] = DateTime.Now.Date;
                        if (double.Parse(drs[0]["AmountLC"].ToString()) < 0)
                        {
                            if (double.Parse(drs[0]["AmountPaid"].ToString()) == -1 * double.Parse(drs[0]["AmountLC"].ToString()))
                                drs[0]["Paid"] = "P";
                        }
                        else
                        {
                            if (double.Parse(drs[0]["AmountPaid"].ToString()) == double.Parse(drs[0]["AmountLC"].ToString()))
                                drs[0]["Paid"] = "P";
                        }
                    }
                    dr = dbAccountingProjectDS.ARCredits.NewRow();
                    dr["CreditID"] = NewCreditID();
                    dr["InvoiceID"] = ID;
                    dr["CreditAmount"] = total;
                    dr["CreditDate"] = DateTime.Now.ToShortDateString();
                    dr["UserID"] = AaDeclrationClass.xUserCode;
                    dr["InvIDPay"] = 0;
                    dbAccountingProjectDS.ARCredits.Rows.Add(dr);
                }
                for (int i = 0; i < dgv_AccountCharges.Rows.Count; i++)
                {
                    r = dgv_AccountCharges.Rows[i];
                    ID = int.Parse(r.Cells["InvoiceID"].Value.ToString().Trim());
                    double Balance = double.Parse(r.Cells["AppliedBalance"].Value.ToString());
                    double PaidAmount = double.Parse(r.Cells["AmountPaid"].Value.ToString());
                    double AmtApplied = double.Parse(r.Cells["AmtApplied"].Value.ToString());
                    drs = dbAccountingProjectDS.ARtrans.Select("TransNO = " + ID);
                    if (drs.Length != 0)
                    {
                        drs[0]["AmountPaid"] = PaidAmount + AmtApplied;
                        drs[0]["PaidDate"] = DateTime.Now.Date;
                        if (Balance == 0)
                            drs[0]["Paid"] = "P";
                    }
                    if (AmtApplied != 0)
                    {
                        dr = dbAccountingProjectDS.ARCredits.NewRow();
                        dr["CreditID"] = NewCreditID();
                        dr["InvoiceID"] = ID;
                        dr["CreditAmount"] = AmtApplied;
                        dr["CreditDate"] = DateTime.Now.ToShortDateString();
                        dr["UserID"] = AaDeclrationClass.xUserCode;
                        dr["InvIDPay"] = InvIDPay;
                        dbAccountingProjectDS.ARCredits.Rows.Add(dr);
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
            DataRow[] drr = dbAccountingProjectDS.ARCredits.Select("", "CreditID");
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
            adaptertbARCredits.Update(dbAccountingProjectDS.ARCredits);
            adaptertbBatchInvoices.Update(dbAccountingProjectDS.ARtrans);
            dbAccountingProjectDS.ARtrans.AcceptChanges();
            dbAccountingProjectDS.ARCredits.AcceptChanges();
        }

        private void dgv_CreditTransaction_MouseClick(object sender, MouseEventArgs e)
        {
            DataRow rc;
            if (dgv_CreditTransaction.CurrentRow.Cells["Balance_To_Apply"].Value != null)
                txt_Balance.Text = dgv_CreditTransaction.CurrentRow.Cells["Balance_To_Apply"].Value.ToString();

            DataRow[] drb = dbAccountingProjectDS.Batch.Select("BatchSRC = 'AR' AND BatchStat = 'P'");
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
            if (dgv_CreditTransaction.CurrentRow.Cells["AccountCode"].Value.ToString().Trim() != "")
            {
                dtInvoice.Clear();
                DataRow[] drs;
                if (NOBatches == "")
                    drs = dbAccountingProjectDS.ARtrans.Select("AccountCode = '" + dgv_CreditTransaction.SelectedRows[0].Cells["AccountCode"].Value.ToString().Trim() + "' AND AmountLC >= 0 and CurrencyType = '' and Paid = 'N' AND BatchNo IN (0)", "TRANSDATE");
                else
                    drs = dbAccountingProjectDS.ARtrans.Select("AccountCode = '" + dgv_CreditTransaction.SelectedRows[0].Cells["AccountCode"].Value.ToString().Trim() + "' AND AmountLC >= 0 and CurrencyType = '' and Paid = 'N' AND BatchNo IN " + NOBatches, "TRANSDATE");
                if (drs.Length != 0)
                {
                    for (int i = 0; i < drs.Length; i++)
                    {
                        rc = dtInvoice.NewRow();
                        rc["InvoiceID"] = int.Parse(drs[i]["TransNO"].ToString());
                        rc["Select"] = false;
                        rc["AccountCode"] = drs[i]["AccountCode"].ToString();
                        rc["InvoiceDate"] = Convert.ToDateTime(drs[i]["TRANSDATE"].ToString());
                        rc["Reference"] = drs[i]["TRANSREF"].ToString();
                        rc["InvoiceAmount"] = double.Parse(drs[i]["AmountLC"].ToString());
                        rc["AmountPaid"] = double.Parse(drs[i]["AmountPaid"].ToString());
                        rc["Balance"] = double.Parse(drs[i]["AmountLC"].ToString()) - double.Parse(drs[i]["AmountPaid"].ToString());
                        rc["AmtApplied"] = 0;
                        rc["AppliedBalance"] = double.Parse(drs[i]["AmountLC"].ToString()) - double.Parse(drs[i]["AmountPaid"].ToString());
                        rc["Curr."] = drs[i]["CurrencyType"].ToString();
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
            if (dgv_AccountCharges.CurrentCell.ColumnIndex == 8)
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
            if (txt_Balance.Text == "" )
                return;
            double totalbalance = double.Parse(txt_Balance.Text);
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (dgv_AccountCharges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null &&
                    dgv_AccountCharges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
                {
                    if (e.ColumnIndex == 8)
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

        private void ARApplyCreditsScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralFunctions.UnLockTable("", "ARApplyCreditsScreen", "", "");

        }
    }
}