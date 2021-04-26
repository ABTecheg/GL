using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Accounting_GeneralLedger.Resources;
using JThomas.Controls;

namespace Accounting_GeneralLedger
{
    public partial class APTransactions : Form
    {



        private SqlConnection sqlcon;
        private SqlDataAdapter adapterGLTransactions;
        private SqlDataAdapter adaptertbdepartmentCodes;
        private SqlDataAdapter adapterBatch;
        private SqlDataAdapter adapterAPTrans;
        private SqlDataAdapter adapterAPExpense;
        private SqlDataAdapter adaptertbAccounts;
        private SqlDataAdapter adapterAPDeliveryType;
        private SqlDataAdapter adapterAPPaymentTerms;
        private SqlDataAdapter adaptertbGeneralSetup;
        private SqlDataAdapter adaptertbGLProjectCodes;
        private SqlDataAdapter adaptertbAPTaxReason;
        private SqlDataAdapter adaptertbG_L_GeneralSetup;
        private SqlDataAdapter adaptertbALGeneralSetup;
        private SqlDataAdapter adaptertbGLCurrency;
        private SqlDataAdapter adaptertbGLTotals;
        private SqlCommandBuilder cmdbuilderGLTransactions;
        private SqlCommandBuilder cmdbuilderAPBatches;
        private SqlCommandBuilder cmdbuilderBatchInvoices;
        private SqlCommandBuilder cmdbuilderBatchInvoiceAccounts;
        private SqlCommandBuilder cmdBuilderGLTotals;
        DataGridViewComboBoxColumn dgvc;
        DataGridViewComboBoxColumn dgvd;
        //private dbAccountingProjectDS dbAccountingProjectDS;
        private string DefaultACCBalanceSheet = "";
        private string DefaultACCIncomeStatment = "";
        private DataTable dtInvoiceAccounts;
        private string APNumberFormat = "";
        private string lblAP = "";
        private string AccountNumberFormat = "";
        private string APAccountNumber = "";
        private string DefaultAPJrl = "";
        private int decmal=0;
        private double ValBS = 0;
        private double ValPT = 0;
        private int currentPeriodID;
        private DateTime currentEndDate;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;

        public APTransactions()
        {
            InitializeComponent();
        }
        private void txt_NonTaxableReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            Err.SetError(txt_NonTaxableReason, "");
            if (txt_NonTaxableReason.Text == "<new>")
            {
                TaxReason tx = new TaxReason();
                tx.ShowDialog();
                txt_NonTaxableReason.Items.Clear();
                adaptertbAPTaxReason.Fill(dbAccountingProjectDS.APTaxReason);
                txt_NonTaxableReason = GeneralFunctions.FillComboBox(dbAccountingProjectDS.APTaxReason, txt_NonTaxableReason, "Code_Reason", "ID_Reason");
            }
        }
        private void cbo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            if (senderComboBox.SelectedItem != null)
            {
                if (senderComboBox.SelectedItem.ToString() == "<new>")
                {
                    senderComboBox.SelectedIndex = -1;
                    ProjectCodes pc = new ProjectCodes();
                    pc.ShowDialog();
                    cb_ProjectCode.Items.Clear();
                    adaptertbGLProjectCodes.Fill(dbAccountingProjectDS.GLProjectCodes);
                    cb_ProjectCode = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLProjectCodes, cb_ProjectCode, "ProjectCode", "ProjectCodeID");
                    dgvc.Items.Clear();
                    dgvc = GeneralFunctions.AddItems(dgvc, dbAccountingProjectDS.GLProjectCodes, "ProjectCode");
                }
            }
        }
        private void cbd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            if (senderComboBox.SelectedItem != null)
            {
                if (senderComboBox.SelectedItem.ToString() == "<new>")
                {
                    senderComboBox.SelectedIndex = -1;
                    DepartmentCode pc = new  DepartmentCode();
                    pc.ShowDialog();
                    cb_DepartmentCode.Items.Clear();
                    adaptertbdepartmentCodes.Fill(dbAccountingProjectDS.DepartmentCode);
                    cb_DepartmentCode = GeneralFunctions.FillComboBox(dbAccountingProjectDS.DepartmentCode, cb_DepartmentCode, "Code", "ID");
                    dgvd.Items.Clear();
                    dgvd = GeneralFunctions.AddItems(dgvd, dbAccountingProjectDS.DepartmentCode, "Code");
                }
            }
        }
        private void dgv_InvoiceDetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox cbo = e.Control as ComboBox;
            ComboBox cbd = e.Control as ComboBox;
            if (dgv_InvoiceDetails.CurrentCell.ColumnIndex == 8)
            {
                try { cbd.SelectionChangeCommitted -= new System.EventHandler(cbd_SelectionChangeCommitted); }
                catch (Exception ex) { }
                try { cbo.SelectionChangeCommitted -= new System.EventHandler(cbo_SelectionChangeCommitted); }
                catch (Exception ex) { }
                cbo.SelectionChangeCommitted += new System.EventHandler(cbo_SelectionChangeCommitted);
            }
            if (dgv_InvoiceDetails.CurrentCell.ColumnIndex == 9)
            {
                try { cbo.SelectionChangeCommitted -= new System.EventHandler(cbo_SelectionChangeCommitted); }
                catch (Exception ex) { }
                try { cbd.SelectionChangeCommitted -= new System.EventHandler(cbd_SelectionChangeCommitted); }
                catch (Exception ex) { }
                cbd.SelectionChangeCommitted += new System.EventHandler(cbd_SelectionChangeCommitted);
            }
            e.Control.KeyPress -= new KeyPressEventHandler(dgv_InvoiceDetails_Control_KeyPress);

            e.Control.KeyPress += new KeyPressEventHandler(dgv_InvoiceDetails_Control_KeyPress);


        }
        private void dgv_InvoiceDetails_Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgv_InvoiceDetails.CurrentCell.ColumnIndex == 5 || dgv_InvoiceDetails.CurrentCell.ColumnIndex == 6)
            {
                if (e.KeyChar == 8)
                {

                    e.Handled = false;

                }
                else if (e.KeyChar >= 48 && e.KeyChar <= 57)
                {
                    if (dgv_InvoiceDetails.EditingControl.Text.ToString().Contains("."))
                    {
                        char c = '.';
                        string[] sc = dgv_InvoiceDetails.EditingControl.Text.ToString().Split(c);

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
                    if (dgv_InvoiceDetails.EditingControl.Text.ToString().Contains(".") == false)
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
        private void txt_PONumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                //if (txt_PONumber.Text.Contains("."))
                //{
                //    char c = '.';
                //    string[] sc = txt_PONumber.Text.Split(c);

                //    if (sc[1].Length < decmal)
                //        e.Handled = false;
                //    else
                //        e.Handled = true;

                //}
                //else
                    e.Handled = false;

            }
            //else if (e.KeyChar == 46)
            //{
            //    if (txt_PONumber.Text.Contains(".") == false)
            //        e.Handled = false;
            //    else
            //        e.Handled = true;
            //}
            else
                e.Handled = true;
        }
        //private void checkBox_Currency_Click(object sender, EventArgs e)
        //{
        //    if (checkBox_Currency.Checked)
        //    {
        //        label_Currency.Visible = true;
        //        cb_Currency.Visible = true;
        //        label_CurrencyRate.Visible = true;
        //        txt_CurrencyRate.Visible = true;
        //        dgv_InvoiceDetails.Columns["AmountCC"].ReadOnly = false;
        //    }
        //}
        private void checkBox_Tax_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Tax.Checked)
            {
                txt_NonTaxableReason.Visible = true;
                label_NonTaxableReason.Visible = true;
                label19.Visible = false;
                label27.Visible = false;
                cb_DeliveryType.Visible = false;
                txt_TaxValue.Visible = false;
                cb_DeliveryType.SelectedIndex = -1;
                txt_TaxValue.Text = "0";
            }
            else
            {
                txt_NonTaxableReason.SelectedIndex = -1;
                txt_NonTaxableReason.Visible = false;
                label_NonTaxableReason.Visible = false;
                label19.Visible = true;
                label27.Visible = true;
                cb_DeliveryType.Visible = true;
                txt_TaxValue.Visible = true;
            }
        }
        private void checkBox_Currency_CheckedChanged(object sender, EventArgs e)
        {
            DataRow r; 
            if (checkBox_Currency.Checked == true)
            {
                label_Currency.Visible = true;
                cb_Currency.Visible = true;
                cb_Currency.SelectedIndex = -1;
                label_CurrencyRate.Visible = true;
                txt_CurrencyRate.Visible = true;
                dgv_InvoiceDetails.Columns["AmountCC"].ReadOnly = false;
                dgv_InvoiceDetails.Columns["Amount"].ReadOnly = true;
                dgv_InvoiceDetails.Columns["AmountCC"].Visible = true;
                for (int i = 0; i < dtInvoiceAccounts.Rows.Count; i++)
                {
                    r = dtInvoiceAccounts.Rows[i];
                    if (r.Equals(dtInvoiceAccounts.Rows[dtInvoiceAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountName"].ToString() == "")
                        break;
                    dtInvoiceAccounts.Rows[i]["Amount"] = 0;
                }

            }
            else
            {
                label_Currency.Visible = false;
                cb_Currency.Visible = false;
                cb_Currency.SelectedIndex = -1;
                label_CurrencyRate.Visible = false;
                txt_CurrencyRate.Visible = false;
                txt_CurrencyRate.Text="0";
                dgv_InvoiceDetails.Columns["AmountCC"].ReadOnly = true;
                dgv_InvoiceDetails.Columns["Amount"].ReadOnly = false;
                dgv_InvoiceDetails.Columns["AmountCC"].Visible = false;
                for (int i = 0; i < dtInvoiceAccounts.Rows.Count; i++)
                {
                    r = dtInvoiceAccounts.Rows[i];
                    if (r.Equals(dtInvoiceAccounts.Rows[dtInvoiceAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountName"].ToString() == "")
                        break;
                    dtInvoiceAccounts.Rows[i]["AmountCC"] = 0;
                }
            }
            CalculateBalance();
        }
        private void cb_Currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            Err.SetError(cb_Currency, "");
            if (cb_Currency.Text == "<new>")
            {
                Currency currency = new Currency();
                currency.ShowDialog();
                cb_Currency.Items.Clear();
                adaptertbGLCurrency.Fill(dbAccountingProjectDS.GLCurrency);
                cb_Currency = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLCurrency, cb_Currency, "CurrencyCode", "CurrencyNumber");
                cb_Currency = GeneralFunctions.RemoveBaseCurrency(cb_Currency);
            }
            if (cb_Currency.Text != "" && cb_Currency.Text != "<new>")
            {
                double exchangeRate;
                if (!GeneralFunctions.EvaluateExchangeRate(out exchangeRate, cb_Currency.Text))
                {
                    if (DialogResult.OK == MessageBox.Show("The conversion exchange rate for the given currency hasnt been defined\nPress OK if you want to define the exchage rates now", "General Ledger"))
                    {
                        CurrencyConversionTable conversion = new CurrencyConversionTable();
                        conversion.ShowDialog();
                        GeneralFunctions.EvaluateExchangeRate(out exchangeRate, cb_Currency.Text);
                        txt_CurrencyRate.Text = exchangeRate.ToString();
                        //UpdateForiegnCurrencyValues();
                    }
                }
                else
                {
                    txt_CurrencyRate.Text = exchangeRate.ToString();
                    //UpdateForiegnCurrencyValues();
                }
            }
        }
        private void CalculateDueDays()
        {
            SqlConnection sqlcon1 = new SqlConnection(GeneralFunctions.ConnectionString);
            if (cb_VendorTerms.Text != "")
            {
                DataRow[] rArr = dbAccountingProjectDS.APPaymentTerms.Select("PaymentTermCode = '" + cb_VendorTerms.Text + "'");
                double days = double.Parse(rArr[0]["PaymentDueDays"].ToString());
                if (cb_StartDate.Text == "BatchTransactionDate")
                {
                    txt_DueDays.Text = DTP_Date.Value.AddDays(days).ToShortDateString();
                    //sqlcon1.Open();
                    //SqlCommand sqlcommand = new SqlCommand("sp_AddDay", sqlcon1);
                    //sqlcommand.CommandType = CommandType.StoredProcedure;
                    //SqlParameter sqlparamIn1 = sqlcommand.Parameters.Add("@date", SqlDbType.DateTime);
                    //SqlParameter sqlparamIn2 = sqlcommand.Parameters.Add("@dayNumber", SqlDbType.Int);
                    //sqlparamIn1.Value = DTP_Date.Text;
                    //sqlparamIn2.Value = days;
                    //currentDueDays = (DateTime)sqlcommand.ExecuteScalar();
                    //sqlcon1.Close();
                }
                else if (cb_StartDate.Text == "Invoice Date")
                {
                    txt_DueDays.Text = DTP_InvoiceDate.Value.AddDays(days).ToShortDateString();
                    //sqlcon1.Open();
                    //SqlCommand sqlcommand = new SqlCommand("sp_AddDay", sqlcon1);
                    //sqlcommand.CommandType = CommandType.StoredProcedure;
                    //SqlParameter sqlparamIn1 = sqlcommand.Parameters.Add("@date", SqlDbType.DateTime);
                    //SqlParameter sqlparamIn2 = sqlcommand.Parameters.Add("@dayNumber", SqlDbType.Int);
                    //sqlparamIn1.Value = DTP_InvoiceDate.Text;
                    //sqlparamIn2.Value = days;
                    //currentDueDays = (DateTime)sqlcommand.ExecuteScalar();
                    //sqlcon1.Close();
                }
            }
        }
        private void DTP_InvoiceDate_CloseUp(object sender, EventArgs e)
        {
            CalculateDueDays();
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            VendorSearch vs = new VendorSearch();
            vs.ShowDialog();
            txt_VendorCode.Text = vs.selectedVendorCode;
            ValidateVendorInfo();
        }
        private bool ValidateVendorInfo()
        {
            bool valid = true;
            if (GeneralFunctions.ValidateString(txt_VendorCode.Text, "Please Insert a Valid Vendor Code"))
            {
                sqlcon.Open();
                SqlCommand sqlcommand = new SqlCommand("Select * from APVendors where VendorCode = '" + txt_VendorCode.Text + "'", sqlcon);
                SqlDataReader rd = sqlcommand.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    txt_VendorName.Text = rd.GetString(2);
                    if (cb_VendorTerms.Text == "")
                        cb_VendorTerms.Text = rd["VendorTermID"].ToString();
                }
                else
                {
                    MessageBox.Show("The given vendor code doesnt exist\n Please Insert a Valid Vendor Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valid = false;
                }
                rd.Close();
                sqlcon.Close();
            }
            else
                valid = false;
            return valid;
        }
        private void BatchIdNew()
        {
            int newnum = 0;
            SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconBatch.Open();
            SqlCommand getBatch = new SqlCommand("Select Max(BatchNo)+1 From Batch", sqlconBatch);
            if (getBatch.ExecuteScalar() != DBNull.Value)
            {
                newnum = int.Parse(getBatch.ExecuteScalar().ToString());
            }
            else
            {
                newnum = 1;
            }
            string msg = "new";
            while (msg != "")
            {
                msg = GeneralFunctions.CheckLockTables("Batch", "", newnum.ToString(), "New");
                if (msg != "")
                {
                    newnum = newnum + 1;
                }
            }
            GeneralFunctions.LockTables("Batch", "APTransactions", newnum.ToString(), "New");
            txtBatchNum.Text = newnum.ToString();
        }
        private int NewTransNo()
        {
            int No = 0;
            DataRow[] drr = dbAccountingProjectDS.GLTransactions.Select("", "TransNO");
            if (drr.Length != 0)
            {
                No = 1 + int.Parse(drr[drr.Length - 1]["TransNO"].ToString());
            }
            else
            {
                No = 1;
            }
            return No;
        }
        private int ExpenseIdNew()
        {
            int IDExpense = 0;
            //SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
            //sqlconBatch.Open();
            //SqlCommand getBatch = new SqlCommand("Select Max(InvoiceAccountID)+1 From APExpense", sqlconBatch);
            DataRow[] drr = dbAccountingProjectDS.APExpense.Select("", "InvoiceAccountID");
            if (drr.Length != 0)
            {
                IDExpense = 1 + int.Parse(drr[drr.Length - 1]["InvoiceAccountID"].ToString());
            }
            else
            {
                IDExpense = 1;
            }
            //if (getBatch.ExecuteScalar() != DBNull.Value)
            //{
            //    IDExpense = int.Parse(getBatch.ExecuteScalar().ToString());
            //}
            //else
            //{
            //    IDExpense = 1;
            //}
            return IDExpense;
        }
        private int InvoiceIdNew()
        {
            int IDInvoice = 0;
            //SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
            //sqlconBatch.Open();
            //SqlCommand getBatch = new SqlCommand("Select Max(InvoiceAccountID)+1 From APExpense", sqlconBatch);
            DataRow[] drr = dbAccountingProjectDS.APTrans.Select("", "BatchInvoiceID");
            if (drr.Length != 0)
            {
                IDInvoice = 1 + int.Parse(drr[drr.Length - 1]["BatchInvoiceID"].ToString());
            }
            else
            {
                IDInvoice = 1;
            }
            //if (getBatch.ExecuteScalar() != DBNull.Value)
            //{
            //    IDExpense = int.Parse(getBatch.ExecuteScalar().ToString());
            //}
            //else
            //{
            //    IDExpense = 1;
            //}
            return IDInvoice;
        }
        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.formAPTransactions;
            this.label1.Text = obj_interface_language.APNumber;
            this.label2.Text = obj_interface_language.Description;
            this.label4.Text = obj_interface_language.lblDate;
            this.label3.Text = obj_interface_language.labelPeriod;
            this.label5.Text = obj_interface_language.labelBalance;
            this.label7.Text = obj_interface_language.lblUserID;
            this.label29.Text = obj_interface_language.labelBatch;
            this.label30.Text = obj_interface_language.labelStatus;
            this.label31.Text = obj_interface_language.lblPostedIn;
            this.groupInvoice.Text = obj_interface_language.GroupInvoice;
            this.groupBox1.Text = obj_interface_language.GroupInvoiceInformation;
            this.groupBox2.Text = obj_interface_language.GroupInvoicePaymentInformation;
            this.groupBox3.Text = obj_interface_language.GroupAccessInvoice;

            this.label8.Text = obj_interface_language.lblBatchDetails;
            this.label21.Text = obj_interface_language.lblInvoiceDetails;
            this.label11.Text = obj_interface_language.lblInvoiceNumber;
            this.label9.Text = obj_interface_language.VendorCode;
            this.label13.Text = obj_interface_language.lblTransactionType;
            this.label15.Text = obj_interface_language.lblInvoiceStatus;
            this.label17.Text = obj_interface_language.lblReference;
            this.label12.Text = obj_interface_language.lblInvoiceDate;
            this.label10.Text = obj_interface_language.VendorName;
            this.label14.Text = obj_interface_language.lblPONumber;
            this.label18.Text = obj_interface_language.labelProjectCode;
            this.label20.Text = obj_interface_language.lblVendorTerms;
            this.label_Currency.Text = obj_interface_language.currency;
            this.label_CurrencyRate.Text = obj_interface_language.lblCurrencyRate;
            this.label6.Text = obj_interface_language.lblNetInvoiceAmount;
            this.label22.Text = obj_interface_language.lblSalesTaxAmount;
            this.label26.Text = obj_interface_language.lblDiscountValue;
            this.label16.Text = obj_interface_language.lblInvoiceAmount;
            this.label25.Text = obj_interface_language.labelBalance;
            this.label23.Text = obj_interface_language.lblPayDate;
            this.label24.Text = obj_interface_language.DueDays;
            this.label19.Text = obj_interface_language.lblDeliveryType;
            this.label27.Text = obj_interface_language.lblTaxAmount;
            this.label_NonTaxableReason.Text = obj_interface_language.lblNonTaxableReason;
            this.checkBox_Currency.Text = obj_interface_language.lblMultiCurrency;
            this.checkBox_Tax.Text = obj_interface_language.lblNonTaxable;

            this.btn_New.Text = obj_interface_language.buttonJVTransactionNew;
            this.btnedit.Text = obj_interface_language.buttonJVTransactionEdit;
            this.btndelete.Text = obj_interface_language.buttonJVTransactionDelete;
            this.btnundo.Text = obj_interface_language.buttonJVTransactionUndo;
            this.btnexit.Text = obj_interface_language.buttonJVTransactionExit;
            this.btnSavenew.Text = obj_interface_language.buttonJVTransactionSaveNew;
            this.Btnsaveedit.Text = obj_interface_language.buttonJVTransactionSaveEdit;
            this.btn_newbatch.Text = obj_interface_language.btnNewBatch;
            this.btn_savenewbatch.Text = obj_interface_language.buttonJVTransactionSaveNew;
            this.btneditbatch.Text = obj_interface_language.btnEditBatch;
            this.btn_Saveeditbatch.Text = obj_interface_language.buttonJVTransactionSaveEdit;
            this.btndeletebatch.Text = obj_interface_language.btnDeleteBatch;
            this.btnfindbatch.Text = obj_interface_language.buttonJVTransactionsFind;
            this.btnposted.Text = obj_interface_language.buttonJVTransactionPost;
            this.btnundobatch.Text = obj_interface_language.btnUndoBatch;
            this.btn_Search.Text = obj_interface_language.btnSearch;

            dgv_InvoiceDetails.Columns["AccountNumber"].HeaderText = obj_interface_language.dgvAccountDefinitionColumn1;
            dgv_InvoiceDetails.Columns["AccountName"].HeaderText = obj_interface_language.dgvAccountDefinitionColumn2;
            dgv_InvoiceDetails.Columns["AccountDescription"].HeaderText = obj_interface_language.DGVDescription;
            dgv_InvoiceDetails.Columns["Amount"].HeaderText = obj_interface_language.dgvAmount;
            dgv_InvoiceDetails.Columns["ProjectCode"].HeaderText = obj_interface_language.dgvspc_code;
            dgv_Invoices.Columns["BatchInvoiceID"].HeaderText = obj_interface_language.dgvBatchInvoiceID;
            dgv_Invoices.Columns[1].HeaderText = obj_interface_language.VendorCode;
            dgv_Invoices.Columns[2].HeaderText = obj_interface_language.VendorName;
            dgv_InvoiceDetails.Columns["AmountCC"].HeaderText = obj_interface_language.dgvAmountCC;
        }
        private void APTransactions_Load(object sender, EventArgs e)
        {
            try
            {
                string msg = GeneralFunctions.CheckLockTables("", "ENDYear", "", "Edit");
                if (msg != "")
                {
                    MessageBox.Show("Can't Open Because ENDYear Edit By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                    return;
                }
                msg = GeneralFunctions.CheckLockTables("", "EndMonth", "", "Edit");
                if (msg != "")
                {
                    MessageBox.Show("Can't Open Because EndMonth Edit By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                    return;
                }
                GeneralFunctions.LockTables("", "APTransactions", "", "Open");
                txt_UserID.Text = AaDeclrationClass.xUserName;
                GeneralFunctions.priviledgeGroupBox(Lock68);
                GeneralFunctions.priviledgeGroupBox(Lock69);
                GeneralFunctions.priviledgeGroupBox(Lock70);
                GeneralFunctions.priviledgeGroupBox(Lock71);
                GeneralFunctions.priviledgeGroupBox(Lock72);
                GeneralFunctions.priviledgeGroupBox(Lock73);
                GeneralFunctions.priviledgeGroupBox(Lock74);
                BatchIdNew();
                dbAccountingProjectDS = new dbAccountingProjectDS();
                sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
                adapterGLTransactions = new SqlDataAdapter("Select * from GLTransactions", sqlcon);
                adaptertbdepartmentCodes = new SqlDataAdapter("Select * from DepartmentCode Where active = 'A' ", sqlcon);
                adapterBatch = new SqlDataAdapter("Select * from Batch", sqlcon);
                adapterAPTrans = new SqlDataAdapter("Select * from APTrans", sqlcon);
                adapterAPExpense = new SqlDataAdapter("Select * from APExpense", sqlcon);
                adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts", sqlcon);
                adaptertbAPTaxReason = new SqlDataAdapter("Select * from APTaxReason", sqlcon);
                adaptertbGLProjectCodes = new SqlDataAdapter("Select * from GLProjectCodes Where Active = 1", sqlcon);
                adapterAPDeliveryType = new SqlDataAdapter("Select * from APDeliveryType", sqlcon);
                adapterAPPaymentTerms = new SqlDataAdapter("Select * from APPaymentTerms", sqlcon);
                adaptertbALGeneralSetup = new SqlDataAdapter("Select * from APGeneralSetup", sqlcon);
                adaptertbG_L_GeneralSetup = new SqlDataAdapter("Select * from G_L_GeneralSetup", sqlcon);
                adaptertbGLTotals = new SqlDataAdapter("Select * from GLTotals", sqlcon);
                adaptertbGLCurrency = new SqlDataAdapter("Select * from GLCurrency", sqlcon);
                adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
                adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
                foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
                {
                    if (dr["MultiCurrency"].ToString() == "True")
                    {
                        checkBox_Currency.Visible = true;
                    }
                    else
                    {
                        checkBox_Currency.Visible = false;
                    }
                    AccountNumberFormat = dr["AccountNumberFormat"].ToString();
                    APNumberFormat = dr["APNumberFormat"].ToString();
                    lblAP = dr["lblAP"].ToString();
                    decmal = int.Parse(dr["DecimalPointsNumber"].ToString());
                }

                cmdbuilderGLTransactions = new SqlCommandBuilder(adapterGLTransactions);
                cmdbuilderAPBatches = new SqlCommandBuilder(adapterBatch);
                cmdbuilderBatchInvoices = new SqlCommandBuilder(adapterAPTrans);
                cmdbuilderBatchInvoiceAccounts = new SqlCommandBuilder(adapterAPExpense);
                cmdBuilderGLTotals = new SqlCommandBuilder(adaptertbGLTotals);
                
                adaptertbAPTaxReason.Fill(dbAccountingProjectDS.APTaxReason);
                adaptertbdepartmentCodes.Fill(dbAccountingProjectDS.DepartmentCode);
                adapterGLTransactions.Fill(dbAccountingProjectDS.GLTransactions);
                adapterBatch.Fill(dbAccountingProjectDS.Batch);
                adapterAPTrans.Fill(dbAccountingProjectDS.APTrans);
                adapterAPExpense.Fill(dbAccountingProjectDS.APExpense);
                adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
                adaptertbGLProjectCodes.Fill(dbAccountingProjectDS.GLProjectCodes);
                adapterAPDeliveryType.Fill(dbAccountingProjectDS.APDeliveryType);
                adapterAPPaymentTerms.Fill(dbAccountingProjectDS.APPaymentTerms);
                adaptertbALGeneralSetup.Fill(dbAccountingProjectDS.APGeneralSetup);
                adaptertbG_L_GeneralSetup.Fill(dbAccountingProjectDS.G_L_GeneralSetup);
                adaptertbGLTotals.Fill(dbAccountingProjectDS.GLTotals);
                adaptertbGLCurrency.Fill(dbAccountingProjectDS.GLCurrency);

                DataRow[] drgl = dbAccountingProjectDS.G_L_GeneralSetup.Select();
                if (drgl.Length != 0)
                {
                    DefaultACCBalanceSheet = drgl[0]["BalanceSheet"].ToString();
                    DefaultACCIncomeStatment = drgl[0]["IncomeStatment"].ToString();
                    if (DefaultACCBalanceSheet == "" || DefaultACCIncomeStatment == "")
                    {
                        MessageBox.Show("Please Check AccountBalanceSheet And AccountIncomeStatment In G/L GeneralSetup ", "Error");
                        this.Close();
                    }
                }


                DataGridViewMaskedTextColumn accformats = new DataGridViewMaskedTextColumn(AccountNumberFormat);
                accformats.DataPropertyName = "AccountNumber";
                accformats.HeaderText = "AccountNumber";     //  German text
                accformats.Name = "AccountNumber";
                accformats.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                accformats.Width = 75;

                dtInvoiceAccounts = new DataTable();
                dtInvoiceAccounts.Columns.Add("AccountID", System.Type.GetType("System.Int32"));
                dtInvoiceAccounts.Columns.Add("AccountNumber", System.Type.GetType("System.String"));
                dtInvoiceAccounts.Columns.Add("AccountName", System.Type.GetType("System.String"));
                dtInvoiceAccounts.Columns.Add("AccountDescription", System.Type.GetType("System.String"));
                dtInvoiceAccounts.Columns.Add("Amount", System.Type.GetType("System.Double"));
                dtInvoiceAccounts.Columns.Add("AmountCC", System.Type.GetType("System.Double"));
                dtInvoiceAccounts.Columns.Add("BatchInvoiceID", System.Type.GetType("System.Int32"));

                DataRow r = dtInvoiceAccounts.NewRow();
                dtInvoiceAccounts.Rows.Add(r);
                dgv_InvoiceDetails.DataSource = dtInvoiceAccounts;
                dgv_InvoiceDetails.Columns.Insert(1, accformats);
                dgv_InvoiceDetails.Columns[2].Visible = false;
                dgv_InvoiceDetails.Columns["AccountID"].Visible = false;
                dgv_InvoiceDetails.Columns["BatchInvoiceID"].Visible = false;
                dgv_InvoiceDetails.Columns["AccountName"].ReadOnly = true;
                dgv_InvoiceDetails.Columns["AmountCC"].ReadOnly = true;
                dgv_InvoiceDetails.Columns["AmountCC"].Visible = false;

                dgvc = new DataGridViewComboBoxColumn();
                dgvc.HeaderText = "ProjectCode";
                dgvc.Name = "ProjectCode";
                //dgvc.FlatStyle = FlatStyle.Popup;
                dgvc = GeneralFunctions.AddItems(dgvc, dbAccountingProjectDS.GLProjectCodes, "ProjectCode");
                if (GeneralFunctions.Ckecktag("20") != "M")
                    dgvc.Items.Remove("<new>"); 
                dgv_InvoiceDetails.Columns.Add(dgvc);
                dgvd = new DataGridViewComboBoxColumn();
                dgvd.HeaderText = "DepartmentCode";
                dgvd.Name = "DepartmentCode";
                //dgvd.FlatStyle = FlatStyle.Popup;
                dgvd = GeneralFunctions.AddItems(dgvd, dbAccountingProjectDS.DepartmentCode, "Code");
                //if (GeneralFunctions.Ckecktag("20") != "M")
                //    dgvd.Items.Remove("<new>");
                dgv_InvoiceDetails.Columns.Add(dgvd);

                string periodName;
                if (GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, DTP_Date.Value), out currentPeriodID, out periodName, out currentEndDate))
                    txt_Period.Text = periodName;
                else
                    MessageBox.Show("The period has been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txt_NonTaxableReason = GeneralFunctions.FillComboBox(dbAccountingProjectDS.APTaxReason, txt_NonTaxableReason, "Code_Reason", "ID_Reason");
                cb_ProjectCode = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLProjectCodes, cb_ProjectCode, "ProjectCode", "ProjectCodeID");
                if (GeneralFunctions.Ckecktag("20") != "M")
                    cb_ProjectCode.Items.Remove("<new>");
                cb_DepartmentCode = GeneralFunctions.FillComboBox(dbAccountingProjectDS.DepartmentCode, cb_DepartmentCode, "Code", "ID");
                //if (GeneralFunctions.Ckecktag("20") != "M")
                //    cb_DepartmentCode.Items.Remove("<new>");
                cb_DeliveryType = GeneralFunctions.FillComboBox(dbAccountingProjectDS.APDeliveryType, cb_DeliveryType, "DeliveryTypeName", "DeliveryTypeID");
                if (GeneralFunctions.Ckecktag("78") != "M")
                    cb_DeliveryType.Items.Remove("<new>");
                cb_VendorTerms = GeneralFunctions.FillComboBox(dbAccountingProjectDS.APPaymentTerms, cb_VendorTerms, "PaymentTermCode", "PaymentTermCodeID");
                if (GeneralFunctions.Ckecktag("80") != "M")
                    cb_VendorTerms.Items.Remove("<new>");
                cb_Currency = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLCurrency, cb_Currency, "CurrencyCode", "CurrencyNumber");
                if (GeneralFunctions.Ckecktag("15") != "M")
                    cb_Currency.Items.Remove("<new>");
                cb_Currency = GeneralFunctions.RemoveBaseCurrency(cb_Currency);

                LoadDefaultSetting();
                CalculateDueDays();
                DataRow[] drs = dbAccountingProjectDS.G_L_GeneralSetup.Select();
                if (drs.Length != 0)
                {
                    DefaultAPJrl = drs[0]["Accounts_Payable"].ToString();
                }

                if (GeneralFunctions.languagechioce != "")
                {
                    this.obj_options = new ClassOptions();
                    this.obj_options.report_language = GeneralFunctions.languagechioce;
                    this.update_language_interface();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void LoadDefaultSetting()
        {
            DataRow[] rArr = dbAccountingProjectDS.APGeneralSetup.Select("APGeneralSetupID = 0");
            if (rArr.Length != 0)
            {
                cb_StartDate.Text = rArr[0]["DefaultPaymentDateStart"].ToString();
                cb_VendorTerms.Text = rArr[0]["DefaultVenderTerms"].ToString();
                cb_InvoiceStatus.Text = rArr[0]["DefaultVenderStatus"].ToString();
                APAccountNumber = rArr[0]["APAccountNumber"].ToString();
            }
            else
            {
                MessageBox.Show("The general settings havent been defined, Please Specify the general settings", "General Ledger");
                this.Close();
            }
        }
        private void ReFill()
        {
            dbAccountingProjectDS = new dbAccountingProjectDS();
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adapterGLTransactions = new SqlDataAdapter("Select * from GLTransactions", sqlcon);
            adapterBatch = new SqlDataAdapter("Select * from Batch", sqlcon);
            adapterAPTrans = new SqlDataAdapter("Select * from APTrans", sqlcon);
            adapterAPExpense = new SqlDataAdapter("Select * from APExpense", sqlcon);
            adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts", sqlcon);
            adaptertbAPTaxReason = new SqlDataAdapter("Select * from APTaxReason", sqlcon);
            adaptertbGLProjectCodes = new SqlDataAdapter("Select * from GLProjectCodes Where Active = 1", sqlcon);
            adapterAPDeliveryType = new SqlDataAdapter("Select * from APDeliveryType", sqlcon);
            adapterAPPaymentTerms = new SqlDataAdapter("Select * from APPaymentTerms", sqlcon);
            adaptertbALGeneralSetup = new SqlDataAdapter("Select * from APGeneralSetup", sqlcon);
            adaptertbG_L_GeneralSetup = new SqlDataAdapter("Select * from G_L_GeneralSetup", sqlcon);
            adaptertbGLTotals = new SqlDataAdapter("Select * from GLTotals", sqlcon);
            adaptertbGLCurrency = new SqlDataAdapter("Select * from GLCurrency", sqlcon);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);


            cmdbuilderGLTransactions = new SqlCommandBuilder(adapterGLTransactions);
            cmdbuilderAPBatches = new SqlCommandBuilder(adapterBatch);
            cmdbuilderBatchInvoices = new SqlCommandBuilder(adapterAPTrans);
            cmdbuilderBatchInvoiceAccounts = new SqlCommandBuilder(adapterAPExpense);
            cmdBuilderGLTotals = new SqlCommandBuilder(adaptertbGLTotals);

            adaptertbAPTaxReason.Fill(dbAccountingProjectDS.APTaxReason);
            adapterGLTransactions.Fill(dbAccountingProjectDS.GLTransactions);
            adapterBatch.Fill(dbAccountingProjectDS.Batch);
            adapterAPTrans.Fill(dbAccountingProjectDS.APTrans);
            adapterAPExpense.Fill(dbAccountingProjectDS.APExpense);
            adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
            adaptertbGLProjectCodes.Fill(dbAccountingProjectDS.GLProjectCodes);
            adapterAPDeliveryType.Fill(dbAccountingProjectDS.APDeliveryType);
            adapterAPPaymentTerms.Fill(dbAccountingProjectDS.APPaymentTerms);
            adaptertbALGeneralSetup.Fill(dbAccountingProjectDS.APGeneralSetup);
            adaptertbG_L_GeneralSetup.Fill(dbAccountingProjectDS.G_L_GeneralSetup);
            adaptertbGLTotals.Fill(dbAccountingProjectDS.GLTotals);
            adaptertbGLCurrency.Fill(dbAccountingProjectDS.GLCurrency);
            RefreshInvoicesGrid();
        }
        private void btnundo_Click(object sender, EventArgs e)
        {
            if (sender.ToString() != "NO")
            {
                if (groupBox1.Enabled == true)
                {
                    DialogResult myrst;
                    myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (myrst == DialogResult.No)
                        return;
                }
            }
            ClearCurrentInvoice();
            btn_New.Visible = true;
            btnSavenew.Visible = false;
            btnedit.Visible = true;
            Btnsaveedit.Visible = false;
            groupInvoice.Enabled = false;
            btn_New.Enabled = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
        }

        private void ClearCurrentInvoice()
        {
            Err.Clear();
            int count = dtInvoiceAccounts.Rows.Count;
            for (int i = count - 1; i >= 0; i--)
                dtInvoiceAccounts.Rows.RemoveAt(i);
            DataRow r = dtInvoiceAccounts.NewRow();
            dtInvoiceAccounts.Rows.Add(r);

            txt_VendorCode.Text = "";
            txt_VendorName.Text = "";
            txt_InvoiceNumber.Text = "";
            cb_TransactionType.SelectedIndex = -1;
            txt_PONumber.Text = "";
            cb_InvoiceStatus.Text = "Active";
            txt_NetInvoiceAmount.Text = "0";
            txt_SalesTaxAmount.Text = "0";
            txt_InvoiceAmount.Text = "0";
            txt_DiscountValue.Text = "0";
            txt_TaxValue.Text = "0";
            txt_Reference.Text = "";
            cb_ProjectCode.SelectedIndex = -1;
            cb_DepartmentCode.SelectedIndex = -1;
            cb_DeliveryType.SelectedIndex = -1;
            cb_VendorTerms.SelectedIndex = -1;
            checkBox_Currency.Checked = false;
            checkBox_Tax.Checked = false;
            cb_Currency.SelectedIndex = -1;
            txt_CurrencyRate.Text = "";
            txt_NonTaxableReason.Text = "";
            txt_NonTaxableReason.Visible = false;
            label_NonTaxableReason.Visible = false;
            cb_Currency.Visible = false;
            label_Currency.Visible = false;
            cb_Currency.Visible = false;
            label_CurrencyRate.Visible = false;
            txt_CurrencyRate.Visible = false;

            LoadDefaultSetting();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult myrst;
            myrst = MessageBox.Show("Are You Sure Delete This Invoice", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return;

            if (dgv_Invoices.SelectedRows.Count > 0)
            {
                SqlConnection sqlconndelete = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlconndelete.Open();
                SqlCommand sqlcommandDeletetran = new SqlCommand("Delete From APTrans Where BatchInvoiceID=" + int.Parse(dgv_Invoices.CurrentRow.Cells["BatchInvoiceID"].Value.ToString()) + "", sqlconndelete);
                SqlDataReader drDeletetran = sqlcommandDeletetran.ExecuteReader();
                drDeletetran.Close();
                SqlCommand sqlcommandDelete = new SqlCommand("Delete From APExpense Where BatchInvoiceID=" + int.Parse(dgv_Invoices.CurrentRow.Cells["BatchInvoiceID"].Value.ToString()) + "", sqlconndelete);
                SqlDataReader drDelete = sqlcommandDelete.ExecuteReader();
                if (drDelete != null && drDeletetran != null)
                    MessageBox.Show("Delete Successfully", "General Ledger");
                else
                    MessageBox.Show("Can't Delete", "General Ledger",MessageBoxButtons.OK,MessageBoxIcon.Error);
                drDelete.Close();
                sqlconndelete.Close();
                ReFill();
            }
            else
            {
                MessageBox.Show("Please Select Invoice", "General Ledger");
            }
            dgv_Invoices.ClearSelection();
            //SaveChanges();
            btnedit.Enabled = false;
            btndelete.Enabled = false;

        }
        private void SaveChangesBatch()
        {
            adapterGLTransactions.Update(dbAccountingProjectDS.GLTransactions);
            adapterBatch.Update(dbAccountingProjectDS.Batch);
            adapterAPTrans.Update(dbAccountingProjectDS.APTrans);
            adapterAPExpense.Update(dbAccountingProjectDS.APExpense);
            adaptertbGLTotals.Update(dbAccountingProjectDS.GLTotals);
            dbAccountingProjectDS.AcceptChanges();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            groupInvoice.Enabled = true;
            btnedit.Visible = false;
            Btnsaveedit.Visible = true;
            btn_New.Enabled = false;
            btndelete.Enabled = false;

        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            ClearCurrentInvoice();
            //SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
            //sqlconBatch.Open();
            //SqlCommand getBatch = new SqlCommand("Select Max(BatchInvoiceID)+1 From APTrans", sqlconBatch);
            //if (getBatch.ExecuteScalar() != DBNull.Value)
            //{
            //    txt_InvoiceNumber.Text = getBatch.ExecuteScalar().ToString();
            //}
            //else
            //{
            //    txt_InvoiceNumber.Text = "1";
            //}
            //sqlconBatch.Close();
            txt_InvoiceNumber.Text = InvoiceIdNew().ToString();
            groupInvoice.Enabled = true;
            btn_New.Visible = false;
            btnSavenew.Visible = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
        }

        private void btnSavenew_Click(object sender, EventArgs e)
        {
            DataRow rc;
            for (int i = 0; i < dtInvoiceAccounts.Rows.Count; i++)
            {
                rc = dtInvoiceAccounts.Rows[i];
                if (rc.Equals(dtInvoiceAccounts.Rows[dtInvoiceAccounts.Rows.Count - 1]) && rc["AccountNumber"].ToString() == "" && rc["AccountName"].ToString() == "")
                    break;
                if (dtInvoiceAccounts.Rows[i]["Amount"].ToString() == "0")
                {
                    MessageBox.Show("Check Amount Account", "Error");
                    return;
                }
            }

            if (txt_VendorCode.Text == "")
            {
                Err.SetError(txt_VendorCode, "Please Select Vendor");
            }
            if (cb_TransactionType.Text == "")
            {
                Err.SetError(cb_TransactionType, "Please Select Transaction Type");
            }
            if (cb_VendorTerms.Text == "")
            {
                Err.SetError(cb_VendorTerms, "Please Select Vendor Terms");
            }
            if (cb_StartDate.Text == "")
            {
                Err.SetError(cb_StartDate, "Please Select Pay Date");
            }
            if (cb_Currency.Text == "" && checkBox_Currency.Checked == true)
            {
                Err.SetError(cb_Currency, "Please Select Currency");
            }
            if (cb_TransactionType.Text == "Invoice")
            {
                if (txt_NonTaxableReason.Text == "" && checkBox_Tax.Checked == true)
                {
                    Err.SetError(txt_NonTaxableReason, "Please Select NonTaxableReason");
                }
                if (cb_DeliveryType.Text == "" && checkBox_Tax.Checked == false)
                {
                    Err.SetError(cb_DeliveryType, "Please Select Delivery Type");
                }
            }
            if (txt_InvoiceAmount.Text == "0" || txt_InvoiceAmount.Text == "")
            {
                Err.SetError(txt_InvoiceAmount, "Please Insert Invoice Amount");
            }
            if (txt_VendorCode.Text == "")
            {
                MessageBox.Show("Please Select Vendor", "Error");
                return;
            }
            if (cb_TransactionType.Text == "")
            {
                MessageBox.Show("Please Select Transaction Type", "Error");
                return;
            }
            if (cb_VendorTerms.Text == "")
            {
                MessageBox.Show("Please Select Vendor Terms", "Error");
                return;
            }
            if (cb_StartDate.Text == "")
            {
                MessageBox.Show("Please Select Pay Date", "Error");
                return;
            }
            if (cb_Currency.Text == "" && checkBox_Currency.Checked == true)
            {
                MessageBox.Show("Please Select Currency", "Error");
                return;
            }
            if (cb_TransactionType.Text == "Invoice")
            {
                if (txt_NonTaxableReason.Text == "" && checkBox_Tax.Checked == true)
                {
                    MessageBox.Show("Please Select NonTaxableReason", "Error");
                    return;
                }
                if (cb_DeliveryType.Text == "" && checkBox_Tax.Checked == false)
                {
                    MessageBox.Show("Please Select Delivery Type", "Error");
                    return;
                }
            }
            if (txt_InvoiceAmount.Text == "0" || txt_InvoiceAmount.Text == "")
            {
                MessageBox.Show("Please Insert Invoice Amount", "Error");
                return;
            }
            if (txt_AccountsCurrentBalance.Text != "0")
            {
                DialogResult myrst;
                string s = " Balance = " + txt_Balance.Text + " Are You Sure Save";
                myrst = MessageBox.Show(s, "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (myrst == DialogResult.No)
                    return;
            }

            sqlcon.Open();
            SqlCommand cmdSelect = new SqlCommand("Select BatchInvoiceID from APTrans where BatchInvoiceID = '" + txt_InvoiceNumber.Text + "'", sqlcon);
            SqlDataReader dr = cmdSelect.ExecuteReader();
            if (!dr.HasRows && !GeneralFunctions.FindRow("BatchInvoiceID = '" + txt_InvoiceNumber.Text + "'", dbAccountingProjectDS.APTrans))
            {
                DataRow r = dbAccountingProjectDS.APTrans.NewRow();
                r["BatchInvoiceID"] = txt_InvoiceNumber.Text;
                //GeneralFunctions.APInvoices++;
                //currentInvoiceID = GeneralFunctions.APInvoices;
                r["VendorCode"] = txt_VendorCode.Text;
                r["VendorName"] = txt_VendorName.Text;
                r["InvoiceDate"] = DTP_InvoiceDate.Value.Date;
                r["TransactionType"] = cb_TransactionType.Text;
                r["PayDate"] = cb_StartDate.Text;
                r["PONumber"] = txt_PONumber.Text;
                r["InvoiceStatus"] = cb_InvoiceStatus.Text;
                if (checkBox_Currency.Checked)
                {
                    if (txt_InvoiceAmount.Text != "")
                    {
                        r["InvoiceAmountCC"] = double.Parse(txt_InvoiceAmount.Text);
                        r["InvoiceAmount"] = double.Parse(txt_InvoiceAmount.Text) * double.Parse(txt_CurrencyRate.Text);
                    }
                    if (cb_TransactionType.Text == "Invoice")
                    {
                        if (checkBox_Tax.Checked)
                        {
                            r["NonTaxable"] = 1;
                            r["NonTaxableReason"] = txt_NonTaxableReason.Text;
                        }
                        else
                        {
                            if (txt_TaxValue.Text != "")
                            {
                                r["TaxValueCC"] = double.Parse(txt_TaxValue.Text);
                                r["TaxValue"] = double.Parse(txt_TaxValue.Text) * double.Parse(txt_CurrencyRate.Text);
                            }

                        }
                    }
                    else
                    {
                        r["NonTaxable"] = 0;
                        r["NonTaxableReason"] = "";
                        r["TaxValue"] = 0;
                        r["TaxValueCC"] = 0;
                    }
                    r["MultiCurrency"] = 1;
                    r["CurrencyCode"] = cb_Currency.Text;
                    if (txt_CurrencyRate.Text != "")
                        r["CurrencyRate"] = double.Parse(txt_CurrencyRate.Text);
                }
                else
                {
                    if (txt_InvoiceAmount.Text != "")
                    {
                        r["InvoiceAmount"] = double.Parse(txt_InvoiceAmount.Text);
                        r["InvoiceAmountCC"] = 0;
                    }
                    if (cb_TransactionType.Text == "Invoice")
                    {

                        if (checkBox_Tax.Checked)
                        {
                            r["NonTaxable"] = 1;
                            r["NonTaxableReason"] = txt_NonTaxableReason.Text;
                            r["TaxValue"] = 0;
                            r["TaxValueCC"] = 0;
                        }
                        else
                        {
                            if (txt_TaxValue.Text != "")
                            {
                                r["TaxValue"] = double.Parse(txt_TaxValue.Text);
                                r["TaxValueCC"] = 0;
                            }
                            r["NonTaxable"] = 0;
                            r["NonTaxableReason"] = "";

                        }
                    }
                    else
                    {
                        r["NonTaxable"] = 0;
                        r["NonTaxableReason"] = "";
                        r["TaxValue"] = 0;
                        r["TaxValueCC"] = 0;
                    }
                    r["MultiCurrency"] = 0;
                    r["CurrencyCode"] = "";
                    r["CurrencyRate"] = 0;
                }
                if (txt_NetInvoiceAmount.Text != "")
                    r["NetInvoiceAmount"] = double.Parse(txt_NetInvoiceAmount.Text);
                if (txt_SalesTaxAmount.Text != "")
                    r["SalesTaxAmount"] = double.Parse(txt_SalesTaxAmount.Text);
                if (txt_DiscountValue.Text != "")
                    r["DiscountValue"] = double.Parse(txt_DiscountValue.Text);
                CalculateDueDays();
                r["DueDays"] = Convert.ToDateTime(txt_DueDays.Text);
                r["AmountPaid"] = 0;
                r["Paid"] = 0;
                r["Reference"] = txt_Reference.Text;
                r["DeliveryType"] = cb_DeliveryType.Text;
                r["ProjectCode"] = cb_ProjectCode.Text;
                r["DepartmentCode"] = cb_DepartmentCode.Text;
                r["VendorTerm"] = cb_VendorTerms.Text;
                r["APBatchNumber"] = int.Parse(txtBatchNum.Text);
                dbAccountingProjectDS.APTrans.Rows.Add(r);
                AddInvoiceAccounts();
                dr.Close();
                sqlcon.Close();
                MessageBox.Show("Batch Invoice Record inserted successfully", "General Ledger");
                groupInvoice.Enabled = false;
                RefreshInvoicesGrid();
                btn_New.Visible = true;
                btnSavenew.Visible = false;
                //SaveChanges();
            }
            else
            {
                if (DialogResult.OK == MessageBox.Show("The given Invoice Number already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                {
                    DataRow[] rArr = this.dbAccountingProjectDS.APTrans.Select("BatchInvoiceID = '" + txt_InvoiceNumber.Text + "'");
                    rArr[0]["VendorCode"] = txt_VendorCode.Text;
                    rArr[0]["VendorName"] = txt_VendorName.Text;
                    rArr[0]["InvoiceDate"] = DTP_InvoiceDate.Value;
                    rArr[0]["TransactionType"] = cb_TransactionType.Text;
                    rArr[0]["PayDate"] = cb_StartDate.Text;
                    rArr[0]["PONumber"] = txt_PONumber.Text;
                    rArr[0]["InvoiceStatus"] = cb_InvoiceStatus.Text;
                    if (checkBox_Currency.Checked)
                    {
                        if (txt_InvoiceAmount.Text != "")
                        {
                            rArr[0]["InvoiceAmountCC"] = double.Parse(txt_InvoiceAmount.Text);
                            rArr[0]["InvoiceAmount"] = double.Parse(txt_InvoiceAmount.Text) * double.Parse(txt_CurrencyRate.Text);
                        }
                        if (cb_TransactionType.Text == "Invoice")
                        {
                            if (checkBox_Tax.Checked)
                            {
                                rArr[0]["NonTaxable"] = 1;
                                rArr[0]["NonTaxableReason"] = txt_NonTaxableReason.Text;
                                rArr[0]["TaxValue"] = 0;
                                rArr[0]["TaxValueCC"] = 0;
                            }
                            else
                            {
                                if (txt_TaxValue.Text != "")
                                {
                                    rArr[0]["TaxValueCC"] = double.Parse(txt_TaxValue.Text);
                                    rArr[0]["TaxValue"] = double.Parse(txt_TaxValue.Text) * double.Parse(txt_CurrencyRate.Text);
                                }
                                rArr[0]["NonTaxable"] = 0;
                                rArr[0]["NonTaxableReason"] = "";

                            }
                        }
                        else
                        {
                            rArr[0]["NonTaxable"] = 0;
                            rArr[0]["NonTaxableReason"] = "";
                            rArr[0]["TaxValue"] = 0;
                            rArr[0]["TaxValueCC"] = 0;
                        }

                        rArr[0]["MultiCurrency"] = 1;
                        rArr[0]["CurrencyCode"] = cb_Currency.Text;
                        if (txt_CurrencyRate.Text != "")
                            rArr[0]["CurrencyRate"] = double.Parse(txt_CurrencyRate.Text);
                    }
                    else
                    {
                        if (txt_InvoiceAmount.Text != "")
                        {
                            rArr[0]["InvoiceAmount"] = double.Parse(txt_InvoiceAmount.Text);
                            rArr[0]["InvoiceAmountCC"] = 0;
                        }
                        if (cb_TransactionType.Text == "Invoice")
                        {
                            if (checkBox_Tax.Checked)
                            {
                                rArr[0]["NonTaxable"] = 1;
                                rArr[0]["NonTaxableReason"] = txt_NonTaxableReason.Text;
                                rArr[0]["TaxValue"] = 0;
                                rArr[0]["TaxValueCC"] = 0;
                            }
                            else
                            {
                                if (txt_TaxValue.Text != "")
                                {
                                    rArr[0]["TaxValue"] = double.Parse(txt_TaxValue.Text);
                                    rArr[0]["TaxValueCC"] = 0;
                                }
                                rArr[0]["NonTaxable"] = 0;
                                rArr[0]["NonTaxableReason"] = "";

                            }
                        }
                        else
                        {
                            rArr[0]["NonTaxable"] = 0;
                            rArr[0]["NonTaxableReason"] = "";
                            rArr[0]["TaxValue"] = 0;
                            rArr[0]["TaxValueCC"] = 0;
                        }

                        rArr[0]["MultiCurrency"] = 0;
                        rArr[0]["CurrencyCode"] = "";
                        rArr[0]["CurrencyRate"] = 0;
                    }
                    if (txt_NetInvoiceAmount.Text != "")
                        rArr[0]["NetInvoiceAmount"] = double.Parse(txt_NetInvoiceAmount.Text);
                    if (txt_SalesTaxAmount.Text != "")
                        rArr[0]["SalesTaxAmount"] = double.Parse(txt_SalesTaxAmount.Text);
                    if (txt_DiscountValue.Text != "")
                        rArr[0]["DiscountValue"] = double.Parse(txt_DiscountValue.Text);
                    CalculateDueDays();
                    rArr[0]["DueDays"] = Convert.ToDateTime(txt_DueDays.Text);
                    rArr[0]["AmountPaid"] = 0;
                    rArr[0]["Paid"] = 0;
                    rArr[0]["Reference"] = txt_Reference.Text;
                    rArr[0]["DeliveryType"] = cb_DeliveryType.Text;
                    rArr[0]["ProjectCode"] = cb_ProjectCode.Text;
                    rArr[0]["DepartmentCode"] = cb_DepartmentCode.Text;
                    rArr[0]["VendorTerm"] = cb_VendorTerms.Text;
                    rArr[0]["APBatchNumber"] = int.Parse(txtBatchNum.Text);
                    EditInvoiceAccounts();
                    MessageBox.Show("Batch Invoice Record edited successfully", "General Ledger");
                    ClearCurrentInvoice();
                    groupInvoice.Enabled = false;
                    RefreshInvoicesGrid();
                    btn_New.Visible = true;
                    btnSavenew.Visible = false;
                    //SaveChanges();
                }
                else
                {
                    //ClearAll();
                }
                dr.Close();
                sqlcon.Close();
            }
            

        }



        private void AddInvoiceAccounts()
        {
            DataRow r;
            for (int i = 0; i < dtInvoiceAccounts.Rows.Count; i++)
            {
                r = dtInvoiceAccounts.Rows[i];
                if (r.Equals(dtInvoiceAccounts.Rows[dtInvoiceAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountName"].ToString() == "")
                    break;
                if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified)
                {
                    r = this.dbAccountingProjectDS.APExpense.NewRow();
                    if (dgv_InvoiceDetails.Rows[i].Cells["AccountID"].Value.ToString() == "0")
                        r["InvoiceAccountID"] = ExpenseIdNew();
                    r["GLAccountNumber"] = dgv_InvoiceDetails.Rows[i].Cells["AccountNumber"].Value;

                    if (dgv_InvoiceDetails.Rows[i].Cells["AccountName"].Value.ToString() == "")
                        r["GLAccountName"] = dgv_InvoiceDetails.Rows[i].Cells["AccountName"].EditedFormattedValue;
                    else
                        r["GLAccountName"] = dgv_InvoiceDetails.Rows[i].Cells["AccountName"].Value;
                    r["GLAccountDescription"] = dgv_InvoiceDetails.Rows[i].Cells["AccountDescription"].Value;

                    if (dgv_InvoiceDetails.Rows[i].Cells["Amount"].Value.ToString() != "")
                        r["AccountAmount"] = dgv_InvoiceDetails.Rows[i].Cells["Amount"].Value;

                    if (dgv_InvoiceDetails.Rows[i].Cells["AmountCC"].Value.ToString() != "")
                        r["AccountAmountCC"] = dgv_InvoiceDetails.Rows[i].Cells["AmountCC"].Value;
                    r["AccountProjectCode"] = dgv_InvoiceDetails.Rows[i].Cells["ProjectCode"].Value;
                    r["DepartmentCode"] = dgv_InvoiceDetails.Rows[i].Cells["DepartmentCode"].Value;
                    r["BatchInvoiceID"] = txt_InvoiceNumber.Text;
                    dbAccountingProjectDS.APExpense.Rows.Add(r);
                }
            }
        }
        private void EditInvoiceAccounts()
        {
            DataRow r;
            for (int i = 0; i < dtInvoiceAccounts.Rows.Count; i++)
            {
                r = dtInvoiceAccounts.Rows[i];
                if (r.Equals(dtInvoiceAccounts.Rows[dtInvoiceAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountName"].ToString() == "")
                    break;
                DataRow[] rArr = this.dbAccountingProjectDS.APExpense.Select("InvoiceAccountID = '" + r["AccountID"].ToString() + "'");
                if (rArr.Length !=0)
                {
                    rArr[0]["GLAccountNumber"] = dgv_InvoiceDetails.Rows[i].Cells["AccountNumber"].Value;
                    rArr[0]["GLAccountName"] = dgv_InvoiceDetails.Rows[i].Cells["AccountName"].Value;
                    rArr[0]["GLAccountDescription"] = dgv_InvoiceDetails.Rows[i].Cells["AccountDescription"].Value;
                    if (dgv_InvoiceDetails.Rows[i].Cells["Amount"].Value.ToString() != "")
                        rArr[0]["AccountAmount"] = dgv_InvoiceDetails.Rows[i].Cells["Amount"].Value;
                    if (dgv_InvoiceDetails.Rows[i].Cells["AmountCC"].Value.ToString() != "")
                        rArr[0]["AccountAmountCC"] = dgv_InvoiceDetails.Rows[i].Cells["AmountCC"].Value;
                    rArr[0]["AccountProjectCode"] = dgv_InvoiceDetails.Rows[i].Cells["ProjectCode"].Value;
                    rArr[0]["DepartmentCode"] = dgv_InvoiceDetails.Rows[i].Cells["DepartmentCode"].Value;
                    rArr[0]["BatchInvoiceID"] = txt_InvoiceNumber.Text;
                }
                else
                {
                    r = this.dbAccountingProjectDS.APExpense.NewRow();
                    if (dgv_InvoiceDetails.Rows[i].Cells["AccountID"].Value.ToString() == "0")
                        r["InvoiceAccountID"] = ExpenseIdNew();
                    r["GLAccountNumber"] = dgv_InvoiceDetails.Rows[i].Cells["AccountNumber"].Value;
                    if (dgv_InvoiceDetails.Rows[i].Cells["AccountName"].Value.ToString() == "")
                        r["GLAccountName"] = dgv_InvoiceDetails.Rows[i].Cells["AccountName"].EditedFormattedValue;
                    else
                        r["GLAccountName"] = dgv_InvoiceDetails.Rows[i].Cells["AccountName"].Value;
                    r["GLAccountDescription"] = dgv_InvoiceDetails.Rows[i].Cells["AccountDescription"].Value;
                    if (dgv_InvoiceDetails.Rows[i].Cells["Amount"].Value.ToString() != "")
                        r["AccountAmount"] = dgv_InvoiceDetails.Rows[i].Cells["Amount"].Value;
                    if (dgv_InvoiceDetails.Rows[i].Cells["AmountCC"].Value.ToString() != "")
                        r["AccountAmountCC"] = dgv_InvoiceDetails.Rows[i].Cells["AmountCC"].Value;
                    r["AccountProjectCode"] = dgv_InvoiceDetails.Rows[i].Cells["ProjectCode"].Value;
                    r["DepartmentCode"] = dgv_InvoiceDetails.Rows[i].Cells["DepartmentCode"].Value;
                    r["BatchInvoiceID"] = txt_InvoiceNumber.Text;
                    dbAccountingProjectDS.APExpense.Rows.Add(r);
                }
            }
        }
        private void RefreshInvoicesGrid()
        
        {
            DataView dv = new DataView(dbAccountingProjectDS.APTrans);
            if (txtBatchNum.Text != "")
            {
                dv.RowFilter = "APBatchNumber = '" + txtBatchNum.Text + "'";
                dgv_Invoices.DataSource = dv;
            }
            else
                dgv_Invoices.DataSource = null;
            CalculateBalanceBatch();
        }

        private void cb_ProjectCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_ProjectCode.Text == "<new>")
            {
                ProjectCodes pc = new ProjectCodes();
                pc.ShowDialog();
                cb_ProjectCode.Items.Clear();
                adaptertbGLProjectCodes.Fill(dbAccountingProjectDS.GLProjectCodes);
                cb_ProjectCode = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLProjectCodes, cb_ProjectCode, "ProjectCode", "ProjectCodeID");
                dgvc.Items.Clear();
                dgvc = GeneralFunctions.AddItems(dgvc, dbAccountingProjectDS.GLProjectCodes, "ProjectCode");
            }
        }

        private void cb_TransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_TransactionType.Text == "Invoice")
            {
                txt_SalesTaxAmount.Enabled = true;
                txt_TaxValue.Text = "0";
                txt_TaxValue.Visible = true;
                cb_DeliveryType.SelectedIndex = -1;
                cb_DeliveryType.Visible = true;
                checkBox_Tax.Visible = true;
                label19.Visible = true;
                label27.Visible = true;
                txt_NonTaxableReason.Visible = true;
                label_NonTaxableReason.Visible = true;
            }
            else if (cb_TransactionType.Text == "CreditNote" || cb_TransactionType.Text == "AdvancedDeposit")
            {
                txt_SalesTaxAmount.Text = "0";
                txt_SalesTaxAmount.Enabled = false;
                txt_TaxValue.Text = "0";
                txt_TaxValue.Visible = false;
                cb_DeliveryType.SelectedIndex = -1;
                cb_DeliveryType.Visible = false;
                checkBox_Tax.Visible = false;
                label19.Visible = false;
                label27.Visible = false;
                txt_NonTaxableReason.Visible = false;
                label_NonTaxableReason.Visible = false;
            }
            Err.SetError(cb_TransactionType, "");

        }

        private void cb_VendorTerms_SelectedIndexChanged(object sender, EventArgs e)
        {
            Err.SetError(cb_VendorTerms, "");
            if (cb_VendorTerms.Text == "<new>")
            {
                PaymentTerms pt = new PaymentTerms();
                pt.ShowDialog();
                cb_VendorTerms.Items.Clear();
                adapterAPPaymentTerms.Fill(dbAccountingProjectDS.APPaymentTerms);
                cb_VendorTerms = GeneralFunctions.FillComboBox(dbAccountingProjectDS.APPaymentTerms, cb_VendorTerms, "PaymentTermCode", "PaymentTermCodeID");
            }
        }

        private void cb_StartDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Err.SetError(cb_StartDate, "");
            CalculateDueDays();
        }

        private void cb_DeliveryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Err.SetError(cb_DeliveryType, "");
            if (cb_DeliveryType.Text != "" && cb_DeliveryType.Text != "<new>")
            {
                double percentage = EvaluatePercentage();
                if (txt_NetInvoiceAmount.Text != "0")
                {
                    double taxAmount = (percentage * double.Parse(txt_NetInvoiceAmount.Text)) / 100;
                    txt_TaxValue.Text = taxAmount.ToString();
                    //dtInvoiceAccounts.Rows.RemoveAt(dtInvoiceAccounts.Rows.Count - 1);
                    //AddTaxRecord();
                    //AddAPTradeRecord();
                    //DataRow r = dtInvoiceAccounts.NewRow();
                    //dtInvoiceAccounts.Rows.Add(r);
                }
                else
                {
                    MessageBox.Show("Please Specify the invoice amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cb_DeliveryType.SelectedIndex = -1;
                }
            }
            if (cb_DeliveryType.Text == "<new>")
            {
                DeliveryTypes dt = new DeliveryTypes();
                dt.ShowDialog();
                cb_DeliveryType.Items.Clear();
                adapterAPDeliveryType.Fill(dbAccountingProjectDS.APDeliveryType);
                cb_DeliveryType = GeneralFunctions.FillComboBox(dbAccountingProjectDS.APDeliveryType, cb_DeliveryType, "DeliveryTypeName", "DeliveryTypeID");
            }
        }
        private void AddTaxRecord()
        {
            sqlcon.Open();
            SqlCommand command = new SqlCommand("Select DeliveryTypeAccountNumber from APDeliveryType where DeliveryTypeName = '" + cb_DeliveryType.Text + "'", sqlcon);
            string delievryAccountNumber = (string)command.ExecuteScalar();
            DataRow[] rArr = dtInvoiceAccounts.Select("AccountNumber = '" + delievryAccountNumber + "'");
            if (rArr.Length == 0)
            {
                DataRow r = dtInvoiceAccounts.NewRow();
                r["AccountID"] = GeneralFunctions.APInvoiceAccounts;
                GeneralFunctions.APInvoiceAccounts++;
                r["AccountNumber"] = delievryAccountNumber;
                command = new SqlCommand("Select AccountName from GLAccounts where AccountNumber = '" + r["AccountNumber"].ToString() + "'", sqlcon);
                r["AccountName"] = (string)command.ExecuteScalar();
                r["AccountDescription"] = "Tax:" + txt_InvoiceNumber.Text + "//" + txt_VendorCode.Text;
                if (checkBox_Currency.Checked)
                {
                    r["Amount"] = -(double.Parse(txt_TaxValue.Text));
                    r["AmountCC"] = -(double.Parse(txt_TaxValue.Text) / double.Parse(txt_CurrencyRate.Text));
                }
                else
                    r["Amount"] = -(double.Parse(txt_TaxValue.Text));
                dtInvoiceAccounts.Rows.Add(r);
            }
            sqlcon.Close();
        }
        private void AddAPTradeRecord()
        {
            DataRow[] rArr;
            double invoiceValue;
            invoiceValue = double.Parse(txt_InvoiceAmount.Text);
            sqlcon.Open();
            SqlCommand command = new SqlCommand("Select APAccountNumber from APGeneralSetup where APGeneralSetupID = 0", sqlcon);
            string apAccountNumber = (string)command.ExecuteScalar();
            if (!checkBox_Tax.Checked)
            {
                invoiceValue -= double.Parse(txt_TaxValue.Text);
            }
            rArr = dtInvoiceAccounts.Select("AccountNumber = '" + apAccountNumber + "'");
            if (rArr.Length == 0)
            {
                DataRow r = dtInvoiceAccounts.NewRow();
                r["AccountID"] = GeneralFunctions.APInvoiceAccounts;
                GeneralFunctions.APInvoiceAccounts++;
                r["AccountNumber"] = apAccountNumber;
                command = new SqlCommand("Select AccountName from GLAccounts where AccountNumber = '" + r["AccountNumber"].ToString() + "'", sqlcon);
                r["AccountName"] = (string)command.ExecuteScalar();
                r["AccountDescription"] = "APTrade:" + txt_InvoiceNumber.Text + "//" + txt_VendorCode.Text;
                if (checkBox_Currency.Checked)
                {
                    r["Amount"] = -invoiceValue;
                    r["AmountCC"] = -(invoiceValue / double.Parse(txt_CurrencyRate.Text));
                }
                else
                    r["Amount"] = -invoiceValue;
                dtInvoiceAccounts.Rows.Add(r);
            }
            sqlcon.Close();
        }

        private void txt_NetInvoiceAmount_TextChanged(object sender, EventArgs e)
        {
            if (cb_DeliveryType.Text != "" )
            {
                double percentage = EvaluatePercentage();
                if (txt_NetInvoiceAmount.Text != "0")
                {
                    double taxAmount = (percentage * double.Parse(txt_NetInvoiceAmount.Text)) / 100;
                    txt_TaxValue.Text = taxAmount.ToString();
                }
            }
            clcTotalAmount();
            CalculateBalance();
        }

        private void txt_SalesTaxAmount_TextChanged(object sender, EventArgs e)
        {
            clcTotalAmount();
            CalculateBalance();
        }

        private void txt_DiscountValue_TextChanged(object sender, EventArgs e)
        {
            clcTotalAmount();
            CalculateBalance();
        }
        private void clcTotalAmount()
        {
            try
            {
                txt_InvoiceAmount.Text = ((double.Parse(txt_NetInvoiceAmount.Text) + double.Parse(txt_SalesTaxAmount.Text)) - double.Parse(txt_DiscountValue.Text)).ToString();
            }
            catch
            { }
        }
        private double EvaluatePercentage()
        {
            double percentage;
            //bool valid = true;
            sqlcon.Open();
            SqlCommand command = new SqlCommand("Select DeliveryPercentage from APDeliveryType where DeliveryTypeName ='" + cb_DeliveryType.Text + "'", sqlcon);
            SqlDataReader rd = command.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();
                percentage = double.Parse(rd[0].ToString());
            }
            else
            {
                percentage = 0;
                //valid = false;
            }
            rd.Close();
            sqlcon.Close();
            return percentage;
        }

        private void Btnsaveedit_Click(object sender, EventArgs e)
        {
            DataRow rc;
            for (int i = 0; i < dtInvoiceAccounts.Rows.Count; i++)
            {
                rc = dtInvoiceAccounts.Rows[i];
                if (rc.Equals(dtInvoiceAccounts.Rows[dtInvoiceAccounts.Rows.Count - 1]) && rc["AccountNumber"].ToString() == "" && rc["AccountName"].ToString() == "")
                    break;
                if (dtInvoiceAccounts.Rows[i]["Amount"].ToString() == "0")
                {
                    MessageBox.Show("Check Amount Account", "Error");
                    return;
                }
            }
            if (txt_VendorCode.Text == "")
            {
                Err.SetError(txt_VendorCode, "Please Select Vendor");
            }
            if (cb_TransactionType.Text == "")
            {
                Err.SetError(cb_TransactionType, "Please Select Transaction Type");
            }
            if (cb_VendorTerms.Text == "")
            {
                Err.SetError(cb_VendorTerms, "Please Select Vendor Terms");
            }
            if (cb_StartDate.Text == "")
            {
                Err.SetError(cb_StartDate, "Please Select Pay Date");
            }
            if (cb_Currency.Text == "" && checkBox_Currency.Checked == true)
            {
                Err.SetError(cb_Currency, "Please Select Currency");
            }
            if (cb_TransactionType.Text == "Invoice")
            {
                if (txt_NonTaxableReason.Text == "" && checkBox_Tax.Checked == true)
                {
                    Err.SetError(txt_NonTaxableReason, "Please Select NonTaxableReason");
                }
                if (cb_DeliveryType.Text == "" && checkBox_Tax.Checked == false)
                {
                    Err.SetError(cb_DeliveryType, "Please Select Delivery Type");
                }
            }
            if (txt_InvoiceAmount.Text == "0" || txt_InvoiceAmount.Text == "")
            {
                Err.SetError(txt_InvoiceAmount, "Please Insert Invoice Amount");
            }
            if (txt_VendorCode.Text == "")
            {
                MessageBox.Show("Please Select Vendor", "Error");
                return;
            }
            if (cb_TransactionType.Text == "")
            {
                MessageBox.Show("Please Select Transaction Type", "Error");
                return;
            }
            if (cb_VendorTerms.Text == "")
            {
                MessageBox.Show("Please Select Vendor Terms", "Error");
                return;
            }
            if (cb_StartDate.Text == "")
            {
                MessageBox.Show("Please Select Pay Date", "Error");
                return;
            }
            if (cb_Currency.Text == "" && checkBox_Currency.Checked == true)
            {
                MessageBox.Show("Please Select Currency", "Error");
                return;
            }
            if (cb_TransactionType.Text == "Invoice")
            {
                if (txt_NonTaxableReason.Text == "" && checkBox_Tax.Checked == true)
                {
                    MessageBox.Show("Please Select NonTaxableReason", "Error");
                    return;
                }
                if (cb_DeliveryType.Text == "" && checkBox_Tax.Checked == false)
                {
                    MessageBox.Show("Please Select Delivery Type", "Error");
                    return;
                }
            }
            if (txt_InvoiceAmount.Text == "0" || txt_InvoiceAmount.Text == "")
            {
                MessageBox.Show("Please Insert Invoice Amount", "Error");
                return;
            }

            if (txt_AccountsCurrentBalance.Text != "0")
            {
                DialogResult myrst;
                string s = " Balance = " + txt_Balance.Text + " Are You Sure Save";
                myrst = MessageBox.Show(s, "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (myrst == DialogResult.No)
                    return;
            }
            DataRow[] rArr = this.dbAccountingProjectDS.APTrans.Select("BatchInvoiceID = '" + txt_InvoiceNumber.Text + "'");
            if (rArr.Length != 0)
            {
                rArr[0]["VendorCode"] = txt_VendorCode.Text;
                rArr[0]["VendorName"] = txt_VendorName.Text;
                rArr[0]["InvoiceDate"] = DTP_InvoiceDate.Value;
                rArr[0]["TransactionType"] = cb_TransactionType.Text;
                rArr[0]["PayDate"] = cb_StartDate.Text;
                rArr[0]["PONumber"] = txt_PONumber.Text;
                rArr[0]["InvoiceStatus"] = cb_InvoiceStatus.Text;
                if (checkBox_Currency.Checked)
                {
                    if (txt_InvoiceAmount.Text != "")
                    {
                        rArr[0]["InvoiceAmountCC"] = double.Parse(txt_InvoiceAmount.Text);
                        rArr[0]["InvoiceAmount"] = double.Parse(txt_InvoiceAmount.Text) * double.Parse(txt_CurrencyRate.Text);
                    }
                    if (cb_TransactionType.Text == "Invoice")
                    {
                        if (checkBox_Tax.Checked)
                        {
                            rArr[0]["NonTaxable"] = 1;
                            rArr[0]["NonTaxableReason"] = txt_NonTaxableReason.Text;
                            rArr[0]["TaxValue"] = 0;
                            rArr[0]["TaxValueCC"] = 0;
                        }
                        else
                        {
                            if (txt_TaxValue.Text != "")
                            {
                                rArr[0]["TaxValueCC"] = double.Parse(txt_TaxValue.Text);
                                rArr[0]["TaxValue"] = double.Parse(txt_TaxValue.Text) * double.Parse(txt_CurrencyRate.Text);
                            }
                            rArr[0]["NonTaxable"] = 0;
                            rArr[0]["NonTaxableReason"] = "";

                        }
                    }
                    else
                    {
                        rArr[0]["NonTaxable"] = 0;
                        rArr[0]["NonTaxableReason"] = "";
                        rArr[0]["TaxValue"] = 0;
                        rArr[0]["TaxValueCC"] = 0;
                    }
                    rArr[0]["MultiCurrency"] = 1;
                    rArr[0]["CurrencyCode"] = cb_Currency.Text;
                    if (txt_CurrencyRate.Text != "")
                        rArr[0]["CurrencyRate"] = double.Parse(txt_CurrencyRate.Text);
                }
                else
                {
                    if (txt_InvoiceAmount.Text != "")
                    {
                        rArr[0]["InvoiceAmount"] = double.Parse(txt_InvoiceAmount.Text);
                        rArr[0]["InvoiceAmountCC"] = 0;
                    }
                    if (cb_TransactionType.Text == "Invoice")
                    {

                        if (checkBox_Tax.Checked)
                        {
                            rArr[0]["NonTaxable"] = 1;
                            rArr[0]["NonTaxableReason"] = txt_NonTaxableReason.Text;
                            rArr[0]["TaxValue"] = 0;
                            rArr[0]["TaxValueCC"] = 0;
                        }
                        else
                        {
                            if (txt_TaxValue.Text != "")
                            {
                                rArr[0]["TaxValue"] = double.Parse(txt_TaxValue.Text);
                                rArr[0]["TaxValueCC"] = 0;
                            }
                            rArr[0]["NonTaxable"] = 0;
                            rArr[0]["NonTaxableReason"] = "";
                        }
                    }
                    else
                    {
                        rArr[0]["NonTaxable"] = 0;
                        rArr[0]["NonTaxableReason"] = "";
                        rArr[0]["TaxValue"] = 0;
                        rArr[0]["TaxValueCC"] = 0;
                    }
                    rArr[0]["MultiCurrency"] = 0;
                    rArr[0]["CurrencyCode"] = "";
                    rArr[0]["CurrencyRate"] = 0;
                }
                if (txt_NetInvoiceAmount.Text != "")
                    rArr[0]["NetInvoiceAmount"] = double.Parse(txt_NetInvoiceAmount.Text);
                if (txt_SalesTaxAmount.Text != "")
                    rArr[0]["SalesTaxAmount"] = double.Parse(txt_SalesTaxAmount.Text);
                if (txt_DiscountValue.Text != "")
                    rArr[0]["DiscountValue"] = double.Parse(txt_DiscountValue.Text);
                CalculateDueDays();
                rArr[0]["DueDays"] = Convert.ToDateTime(txt_DueDays.Text);
                rArr[0]["AmountPaid"] = 0;
                rArr[0]["Paid"] = 0;
                rArr[0]["Reference"] = txt_Reference.Text;
                rArr[0]["DeliveryType"] = cb_DeliveryType.Text;
                rArr[0]["ProjectCode"] = cb_ProjectCode.Text;
                rArr[0]["DepartmentCode"] = cb_DepartmentCode.Text;
                rArr[0]["VendorTerm"] = cb_VendorTerms.Text;
                rArr[0]["APBatchNumber"] = int.Parse(txtBatchNum.Text);
                EditInvoiceAccounts();
                MessageBox.Show("Batch Invoice Record edited successfully", "General Ledger");
                //ClearCurrentInvoice();
                dgv_Invoices.ClearSelection();
                groupInvoice.Enabled = false;
                RefreshInvoicesGrid();
                btnedit.Visible = true;
                Btnsaveedit.Visible = false;
                btn_New.Enabled = true;
                btndelete.Enabled = true;
            }
            else
            {
                DataRow r = dbAccountingProjectDS.APTrans.NewRow();
                r["BatchInvoiceID"] = txt_InvoiceNumber.Text;
                //GeneralFunctions.APInvoices++;
                //currentInvoiceID = GeneralFunctions.APInvoices;
                r["VendorCode"] = txt_VendorCode.Text;
                r["VendorName"] = txt_VendorName.Text;
                r["InvoiceDate"] = DTP_InvoiceDate.Value;
                r["TransactionType"] = cb_TransactionType.Text;
                r["PayDate"] = cb_StartDate.Text;
                r["PONumber"] = txt_PONumber.Text;
                r["InvoiceStatus"] = cb_InvoiceStatus.Text;
                if (checkBox_Currency.Checked)
                {
                    if (txt_InvoiceAmount.Text != "")
                    {
                        r["InvoiceAmountCC"] = double.Parse(txt_InvoiceAmount.Text);
                        r["InvoiceAmount"] = double.Parse(txt_InvoiceAmount.Text) * double.Parse(txt_CurrencyRate.Text);
                    }
                    if (cb_TransactionType.Text == "Invoice")
                    {
                        if (checkBox_Tax.Checked)
                        {
                            r["NonTaxable"] = 1;
                            r["NonTaxableReason"] = txt_NonTaxableReason.Text;
                            r["TaxValue"] = 0;
                            r["TaxValueCC"] = 0;
                        }
                        else
                        {
                            if (txt_TaxValue.Text != "")
                            {
                                r["TaxValueCC"] = double.Parse(txt_TaxValue.Text);
                                r["TaxValue"] = double.Parse(txt_TaxValue.Text) * double.Parse(txt_CurrencyRate.Text);
                            }
                            r["NonTaxable"] = 0;
                            r["NonTaxableReason"] = "";

                        }
                    }
                    else
                    {
                        r["NonTaxable"] = 0;
                        r["NonTaxableReason"] = "";
                        r["TaxValue"] = 0;
                        r["TaxValueCC"] = 0;
                    }
                    r["MultiCurrency"] = 1;
                    r["CurrencyCode"] = cb_Currency.Text;
                    if (txt_CurrencyRate.Text != "")
                        r["CurrencyRate"] = double.Parse(txt_CurrencyRate.Text);
                }
                else
                {
                    if (txt_InvoiceAmount.Text != "")
                    {
                        r["InvoiceAmount"] = double.Parse(txt_InvoiceAmount.Text);
                        r["InvoiceAmountCC"] = 0;
                    }
                    if (cb_TransactionType.Text == "Invoice")
                    {

                        if (checkBox_Tax.Checked)
                        {
                            r["NonTaxable"] = 1;
                            r["NonTaxableReason"] = txt_NonTaxableReason.Text;
                            r["TaxValue"] = 0;
                            r["TaxValueCC"] = 0;
                        }
                        else
                        {
                            if (txt_TaxValue.Text != "")
                            {
                                r["TaxValue"] = double.Parse(txt_TaxValue.Text);
                                r["TaxValueCC"] = 0;
                            }
                            r["NonTaxable"] = 0;
                            r["NonTaxableReason"] = "";
                        }
                    }
                    else
                    {
                        r["NonTaxable"] = 0;
                        r["NonTaxableReason"] = "";
                        r["TaxValue"] = 0;
                        r["TaxValueCC"] = 0;
                    }
                    r["MultiCurrency"] = 0;
                    r["CurrencyCode"] = "";
                    r["CurrencyRate"] = 0;
                }
                if (txt_NetInvoiceAmount.Text != "")
                    r["NetInvoiceAmount"] = double.Parse(txt_NetInvoiceAmount.Text);
                if (txt_SalesTaxAmount.Text != "")
                    r["SalesTaxAmount"] = double.Parse(txt_SalesTaxAmount.Text);
                if (txt_DiscountValue.Text != "")
                    r["DiscountValue"] = double.Parse(txt_DiscountValue.Text);
                CalculateDueDays();
                r["DueDays"] = Convert.ToDateTime(txt_DueDays.Text);
                r["AmountPaid"] = 0;
                r["Paid"] = 0;
                r["Reference"] = txt_Reference.Text;
                r["DeliveryType"] = cb_DeliveryType.Text;
                r["ProjectCode"] = cb_ProjectCode.Text;
                r["DepartmentCode"] = cb_DepartmentCode.Text;
                r["VendorTerm"] = cb_VendorTerms.Text;
                r["APBatchNumber"] = int.Parse(txtBatchNum.Text);
                dbAccountingProjectDS.APTrans.Rows.Add(r);
                AddInvoiceAccounts();
                //dr.Close();
                sqlcon.Close();
                MessageBox.Show("Batch Invoice Record edited successfully", "General Ledger");
                dgv_Invoices.ClearSelection();
                groupInvoice.Enabled = false;
                RefreshInvoicesGrid();
                btnedit.Visible = true;
                Btnsaveedit.Visible = false;
                btn_New.Enabled = true;
                btndelete.Enabled = true;
            }
        }

        private void dgv_InvoiceDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (e.RowIndex != 0)
                {
                    if (dgv_InvoiceDetails.Rows[dgv_InvoiceDetails.Rows.Count - 2].Cells[5].Value.ToString() == "" || dgv_InvoiceDetails.Rows[dgv_InvoiceDetails.Rows.Count - 2].Cells[5].Value.ToString() == "0")
                    {
                        MessageBox.Show("Please Insert AccountPercentage ", "General Ledger");
                        dgv_InvoiceDetails.Focus();
                        dgv_InvoiceDetails.Rows[dgv_InvoiceDetails.Rows.Count - 2].Cells[5].Selected = true;
                        bool Sel = true;
                        dgv_InvoiceDetails.BeginEdit(Sel);
                        return;
                    }
                }
                AccountSearch accSearch = new AccountSearch();
                accSearch.filter = " AND AccountTypeName <> 'Header'";
                accSearch.ShowDialog();
                if (accSearch.selectedAccountName != null && accSearch.selectedAccountNumber != null)
                {
                    dgv_InvoiceDetails.CurrentRow.Cells["AccountID"].Value = 0;
                    dgv_InvoiceDetails.CurrentRow.Cells["AccountNumber"].Value = accSearch.selectedAccountNumber.ToString();
                    dgv_InvoiceDetails.CurrentRow.Cells["AccountName"].Value = accSearch.selectedAccountName.ToString();
                    dgv_InvoiceDetails.CurrentRow.Cells["Amount"].Value = 0;
                    dgv_InvoiceDetails.CurrentRow.Cells["AmountCC"].Value = 0;
                    int rn = 0;
                    for (int i = 0; i < dgv_InvoiceDetails.Rows.Count; i++)
                    {
                        if (dgv_InvoiceDetails.Rows[i].Cells["AccountNumber"].Value.ToString() == "")
                            rn++;
                    }
                    if (rn == 0)
                    {
                        DataRow r = dtInvoiceAccounts.NewRow();
                        dtInvoiceAccounts.Rows.Add(r);
                    }
                    dgv_InvoiceDetails.CurrentRow.Cells["Amount"].Selected = true;
                    bool po = true;
                    dgv_InvoiceDetails.BeginEdit(po);

                }
            }
        }
        private void CalculateBalance()
        {
            double balance = 0;
            double currentvalue = 0;
            if (txt_InvoiceAmount.Text != "")
                balance = -double.Parse(txt_InvoiceAmount.Text);
            //if (txt_TaxValue.Text != "")
            //    balance = balance + double.Parse(txt_TaxValue.Text);
            DataRow r;
            for (int i = 0; i < dtInvoiceAccounts.Rows.Count; i++)
            {
                r = dtInvoiceAccounts.Rows[i];
                if (r.Equals(dtInvoiceAccounts.Rows[dtInvoiceAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountName"].ToString() == "")
                    break;
                currentvalue = 0;
                if (checkBox_Currency.Checked == true)
                {
                    if (dgv_InvoiceDetails.Rows[i].Cells["AmountCC"].Value.ToString() != "" &&
                                           GeneralFunctions.ValidateDouble(dgv_InvoiceDetails.Rows[i].Cells["AmountCC"].Value.ToString(), "Please Insert a valid debit value", out currentvalue))
                        balance += currentvalue;
                }
                else
                {
                    if (dgv_InvoiceDetails.Rows[i].Cells["Amount"].Value.ToString() != "" &&
                                           GeneralFunctions.ValidateDouble(dgv_InvoiceDetails.Rows[i].Cells["Amount"].Value.ToString(), "Please Insert a valid debit value", out currentvalue))
                        balance += currentvalue;
                }
                
                
            }
            txt_AccountsCurrentBalance.Text = balance.ToString();
        }
        private void CalculateBalanceBatch()
        {
            try
            {
                double balance = 0;
                    DataRow[] drinvoice = dbAccountingProjectDS.APTrans.Select("APBatchNumber = '" + txtBatchNum.Text + "'");
                    if (drinvoice.Length != 0)
                    {
                        for (int i = drinvoice.Length; i > 0; i--)
                        {
                            if (groupInvoice.Enabled == true && drinvoice[i - 1]["BatchInvoiceID"].ToString() == dgv_Invoices.SelectedRows[0].Cells["BatchInvoiceID"].Value.ToString() && btnedit.Visible == false)
                            {

                            }
                            else
                            {
                                DataRow[] drexpense = dbAccountingProjectDS.APExpense.Select("BatchInvoiceID = '" + drinvoice[i - 1]["BatchInvoiceID"] + "'");
                                if (drexpense.Length != 0)
                                {
                                    for (int a = drexpense.Length; a > 0; a--)
                                    {
                                        balance = balance + double.Parse(drexpense[a - 1]["AccountAmount"].ToString());
                                    }
                                }
                                balance = balance - double.Parse(drinvoice[i - 1]["InvoiceAmount"].ToString());
                                //balance = balance + double.Parse(drinvoice[i - 1]["TaxValue"].ToString());
                            }
                        }

                    }
                if (groupInvoice.Enabled == true)
                        balance = balance + double.Parse(txt_AccountsCurrentBalance.Text);
                    txt_Balance.Text = balance.ToString();

            }
            catch 
            {
            }
        }

        private void dgv_Invoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (groupBox1.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            btnundo_Click("NO", e);
            if (dgv_Invoices.CurrentRow.Cells["BatchInvoiceID"].Value.ToString() != "" || dgv_Invoices.CurrentRow.Cells["BatchInvoiceID"].Value.ToString() != null)
            {
                DataRow[] r = dbAccountingProjectDS.APTrans.Select("BatchInvoiceID = '" + dgv_Invoices.CurrentRow.Cells["BatchInvoiceID"].Value.ToString() + "'");
                txt_VendorCode.Text = r[0]["VendorCode"].ToString();
                txt_VendorName.Text = r[0]["VendorName"].ToString();
                txt_InvoiceNumber.Text = r[0]["BatchInvoiceID"].ToString();
                DTP_InvoiceDate.Text = r[0]["InvoiceDate"].ToString();
                cb_TransactionType.Text = r[0]["TransactionType"].ToString();
                txt_PONumber.Text = r[0]["PONumber"].ToString();
                cb_InvoiceStatus.Text = r[0]["InvoiceStatus"].ToString();
                //txt_InvoiceAmount.Text = r[0]["InvoiceAmount"].ToString();
                txt_NetInvoiceAmount.Text = r[0]["NetInvoiceAmount"].ToString();
                txt_SalesTaxAmount.Text = r[0]["SalesTaxAmount"].ToString();
                txt_DiscountValue.Text = r[0]["DiscountValue"].ToString();
                txt_Reference.Text = r[0]["Reference"].ToString();
                if (r[0]["NonTaxable"].ToString() == "True")
                {
                    checkBox_Tax.Checked = true;
                    txt_NonTaxableReason.Text = r[0]["NonTaxableReason"].ToString();
                }
                else
                {
                    checkBox_Tax.Checked = false;
                    cb_DeliveryType.Text = r[0]["DeliveryType"].ToString();
                    if (r[0]["MultiCurrency"].ToString() == "True")
                        txt_TaxValue.Text = r[0]["TaxValueCC"].ToString();
                    else
                        txt_TaxValue.Text = r[0]["TaxValue"].ToString();
                }
                if (r[0]["MultiCurrency"].ToString() == "True")
                {
                    checkBox_Currency.Checked = true;
                    cb_Currency.Text = r[0]["CurrencyCode"].ToString();
                    txt_CurrencyRate.Text = r[0]["CurrencyRate"].ToString();
                }
                else
                {
                    checkBox_Currency.Checked = false;
                }
                cb_StartDate.Text = r[0]["PayDate"].ToString(); 
                txt_DueDays.Text = Convert.ToDateTime(r[0]["DueDays"].ToString()).ToShortDateString();
                cb_ProjectCode.Text = r[0]["ProjectCode"].ToString();
                cb_DepartmentCode.Text = r[0]["DepartmentCode"].ToString();
                cb_VendorTerms.Text = r[0]["VendorTerm"].ToString();
                dtInvoiceAccounts.Rows.Clear();
                FindInvoiceAccounts(r[0]["BatchInvoiceID"].ToString());
                groupInvoice.Enabled = false;
                btndelete.Enabled = true;
                btnedit.Enabled = true;
            }
        }
        private void FindInvoiceAccounts(string InvoiceID)
        {
                for (int i = dtInvoiceAccounts.Rows.Count; i > 0; i--)
                {
                    dtInvoiceAccounts.Rows.RemoveAt(i);
                }
            DataRow r;
            DataRow[] rArrResult = this.dbAccountingProjectDS.APExpense.Select("BatchInvoiceID = '" + InvoiceID + "'");
            if (rArrResult.Length != 0)
            {
                for (int i = 0; i < rArrResult.Length; i++)
                {
                    r = dtInvoiceAccounts.NewRow();
                    r["AccountID"] = rArrResult[i]["InvoiceAccountID"];
                    r["AccountNumber"] = rArrResult[i]["GLAccountNumber"];
                    r["AccountName"] = rArrResult[i]["GLAccountName"];
                    r["AccountDescription"] = rArrResult[i]["GLAccountDescription"];
                    r["Amount"] = rArrResult[i]["AccountAmount"];
                    r["BatchInvoiceID"] = int.Parse(InvoiceID);
                    dtInvoiceAccounts.Rows.Add(r);
                    dgv_InvoiceDetails.Rows[i].Cells["ProjectCode"].Value = rArrResult[i]["AccountProjectCode"];
                    dgv_InvoiceDetails.Rows[i].Cells["DepartmentCode"].Value = rArrResult[i]["DepartmentCode"];
                    r.AcceptChanges();
                }
            }
                r = dtInvoiceAccounts.NewRow();
                dtInvoiceAccounts.Rows.Add(r);
        }

        private void txt_PONumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_NetInvoiceAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((txt_CurrencyRate.Text == "" || txt_CurrencyRate.Text == "0") && checkBox_Currency.Checked == true)
            {
                MessageBox.Show("Please Insert CurrencyRate ", "General Ledger");
                e.Handled = true;
                return;
            }

            if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                if (txt_NetInvoiceAmount.Text.Contains("."))
                {
                    char c = '.';
                    string[] sc = txt_NetInvoiceAmount.Text.Split(c);

                    if (sc[1].Length < decmal)
                        e.Handled = false;
                    else
                        e.Handled = true;

                }
                else
                e.Handled = false;

            }
            else if (e.KeyChar == 46)
            {
                if (txt_NetInvoiceAmount.Text.Contains(".") == false)
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void txt_SalesTaxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((txt_CurrencyRate.Text == "" || txt_CurrencyRate.Text == "0") && checkBox_Currency.Checked == true)
            {
                MessageBox.Show("Please Insert CurrencyRate ", "General Ledger");
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                if (txt_SalesTaxAmount.Text.Contains("."))
                {
                    char c = '.';
                    string[] sc = txt_SalesTaxAmount.Text.Split(c);

                    if (sc[1].Length < decmal)
                        e.Handled = false;
                    else
                        e.Handled = true;

                }
                else
                    e.Handled = false;

            }
            else if (e.KeyChar == 46)
            {
                if (txt_SalesTaxAmount.Text.Contains(".") == false)
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void txt_DiscountValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((txt_CurrencyRate.Text == "" || txt_CurrencyRate.Text == "0") && checkBox_Currency.Checked == true)
            {
                MessageBox.Show("Please Insert CurrencyRate ", "General Ledger");
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                if (txt_DiscountValue.Text.Contains("."))
                {
                    char c = '.';
                    string[] sc = txt_DiscountValue.Text.Split(c);

                    if (sc[1].Length < decmal)
                        e.Handled = false;
                    else
                        e.Handled = true;

                }
                else
                    e.Handled = false;

            }
            else if (e.KeyChar == 46)
            {
                if (txt_DiscountValue.Text.Contains(".") == false)
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void txt_TaxValue_TextChanged(object sender, EventArgs e)
        {
            CalculateBalance();
        }

        private void txt_VendorCode_Leave(object sender, EventArgs e)
        {
            if (txt_VendorCode.Text != "")
            {
                if (ValidateVendorInfo() != true)
                    txt_VendorCode.Text = "";
            }
        }

        private void dgv_InvoiceDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && dgv_InvoiceDetails.Rows[e.RowIndex].Cells[1].Value.ToString() != "")
            {
                DataRow[] drs = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + dgv_InvoiceDetails.CurrentCell.Value.ToString() + "'");
                if (drs.Length != 0)
                {
                    dgv_InvoiceDetails.CurrentRow.Cells["AccountNumber"].Value = drs[0]["AccountNumber"].ToString();
                    dgv_InvoiceDetails.CurrentRow.Cells["AccountName"].Value = drs[0]["AccountName"].ToString();
                    dgv_InvoiceDetails.CurrentRow.Cells[5].Selected = true;
                    bool Sel = true;
                    dgv_InvoiceDetails.BeginEdit(Sel);
                    int rn = 0;
                    for (int i = 0; i < dgv_InvoiceDetails.Rows.Count; i++)
                    {
                        if (dgv_InvoiceDetails.Rows[i].Cells["AccountNumber"].Value.ToString() == "")
                            rn++;
                    }
                    if (rn == 0)
                    {
                        DataRow r = dtInvoiceAccounts.NewRow();
                        dtInvoiceAccounts.Rows.Add(r);
                    }

                }
                else
                {
                    MessageBox.Show("Can't Find This Account Or This AccountType Is Header", "Error");
                    dgv_InvoiceDetails.CurrentRow.Cells["AccountNumber"].Value = "";
                }
            }
            if (e.ColumnIndex == 5 || e.ColumnIndex == 6)
            {
                if (dgv_InvoiceDetails.CurrentRow.Cells[e.ColumnIndex].Value.ToString() == "")
                {
                    dgv_InvoiceDetails.CurrentRow.Cells[e.ColumnIndex].Value = 0;
                }
            }

        }

        private void dgv_InvoiceDetails_Leave(object sender, EventArgs e)
        {
            if (dgv_InvoiceDetails.Rows.Count > 1)
            {
                if (dgv_InvoiceDetails.Rows[dgv_InvoiceDetails.Rows.Count - 2].Cells[5].Value.ToString() == "" || dgv_InvoiceDetails.Rows[dgv_InvoiceDetails.Rows.Count - 2].Cells[5].Value.ToString() == "")
                {
                    MessageBox.Show("Please Insert AccountPercentage ", "General Ledger");
                    dgv_InvoiceDetails.Focus();
                    dgv_InvoiceDetails.Rows[dgv_InvoiceDetails.Rows.Count - 2].Cells[5].Selected = true;
                    bool Sel = true;
                    dgv_InvoiceDetails.BeginEdit(Sel);

                }
            }
        }

        private void dgv_InvoiceDetails_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 1)
            {
                if (dgv_InvoiceDetails.CurrentRow.Cells["AccountNumber"].Value.ToString() == "")
                {
                    MessageBox.Show("Please Insert AccountNumber ", "General Ledger");
                    e.Cancel = true;
                }
                    if (e.ColumnIndex == 6)
                    {
                        if (txt_CurrencyRate.Text == "" || txt_CurrencyRate.Text == "0")
                        {
                            MessageBox.Show("Please Insert CurrencyRate ", "General Ledger");
                            e.Cancel = true;
                            return;
                        }
                    }
            }
            else
            {
                if (e.RowIndex != 0)
                {
                    if (dgv_InvoiceDetails.Rows[dgv_InvoiceDetails.Rows.Count - 2].Cells[5].Value.ToString() == "" || dgv_InvoiceDetails.Rows[dgv_InvoiceDetails.Rows.Count - 2].Cells[5].Value.ToString() == "0")
                    {
                        MessageBox.Show("Please Insert AccountPercentage ", "General Ledger");
                        dgv_InvoiceDetails.Focus();
                        dgv_InvoiceDetails.Rows[dgv_InvoiceDetails.Rows.Count - 2].Cells[5].Selected = true;
                        e.Cancel=true;
                        return;
                    }
                }
            }
        }

        private void dgv_InvoiceDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 6)
                {
                    if (dgv_InvoiceDetails.CurrentRow.Cells["AmountCC"].Value.ToString() != "0" && dgv_InvoiceDetails.CurrentRow.Cells["AmountCC"].Value.ToString() != "")
                    {
                        dgv_InvoiceDetails.CurrentRow.Cells["Amount"].Value = double.Parse(txt_CurrencyRate.Text) * double.Parse(dgv_InvoiceDetails.CurrentRow.Cells["AmountCC"].Value.ToString());
                    }

                }
                CalculateBalance();
            }
        }

        private void btn_NewAPNumber_Click(object sender, EventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (groupBox3.Enabled == true || groupBox4.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            this.Close();

        }

        private void btndeletebatch_Click(object sender, EventArgs e)
        {
            if (txtstats.Text == "P")
            {
                MessageBox.Show("This Batch is Posted Can't Deleted", "General Ledger");
                return;
            }
            DialogResult myrst;
            myrst = MessageBox.Show("Are You Sure Delete This Batch", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return;
            try
            {
                DataRow[] drexpense ;
                SqlCommand sqlcommandDeletetran ;
                SqlDataReader drDeletetran ;

                    SqlConnection sqlconndelete = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlconndelete.Open();
                    DataRow[] drinvoice = dbAccountingProjectDS.APTrans.Select("APBatchNumber = '" + txtBatchNum.Text + "'");
                    if (drinvoice.Length != 0)
                    {
                        for (int i = drinvoice.Length; i > 0; i--)
                        {
                            sqlcommandDeletetran = new SqlCommand("Delete From APExpense Where InvoiceAccountID=" + int.Parse(drinvoice[i - 1]["BatchInvoiceID"].ToString()) + "", sqlconndelete);
                            drDeletetran = sqlcommandDeletetran.ExecuteReader();
                            drDeletetran.Close();
                        }
                    }

                    sqlcommandDeletetran = new SqlCommand("Delete From APTrans Where APBatchNumber=" + int.Parse(txtBatchNum.Text) + "", sqlconndelete);
                    drDeletetran = sqlcommandDeletetran.ExecuteReader();
                    drDeletetran.Close();
                    SqlCommand sqlcommandDelete = new SqlCommand("Delete From Batch Where BatchNo=" + int.Parse(txtBatchNum.Text) + "", sqlconndelete);
                    SqlDataReader drDelete = sqlcommandDelete.ExecuteReader();
                    if (drDelete != null && drDeletetran != null)
                        MessageBox.Show("Delete Batch successfully", "General Ledger");
                    else
                        MessageBox.Show("Can't Delete", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    drDelete.Close();
                    sqlconndelete.Close();
                    ReFill();
                ClearBatch();
                SaveChangesBatch();
                btneditbatch.Enabled = false;
                btndeletebatch.Enabled = false;
                btnposted.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"General Ledger");
            }
        }

        private void btneditbatch_Click(object sender, EventArgs e)
        {
            if (txtstats.Text == "P")
            {
                MessageBox.Show("This Batch is Posted Can't Edit", "General Ledger");
                return;
            }

            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
            btneditbatch.Visible = false;
            btn_Saveeditbatch.Visible = true;
            btn_newbatch.Enabled = false;
            btnfindbatch.Enabled = false;
            btndeletebatch.Enabled = false;
            btnposted.Enabled = false;

        }

        private void txtBatchNum_TextChanged(object sender, EventArgs e)
        {
            RefreshInvoicesGrid();
            
        }

        private void btn_newbatch_Click(object sender, EventArgs e)
        {
            ClearBatch();
            BatchIdNew();
            string periodName;
            if (GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, DTP_Date.Value.Date), out currentPeriodID, out periodName, out currentEndDate))
                txt_Period.Text = periodName;
            else
                MessageBox.Show("The period has been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txt_APBatchNumber.Text = GeneralFunctions.CreateAPNumberFormat(lblAP, APNumberFormat,true);
            txtstats.Text = "U";
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
            btn_newbatch.Visible = false;
            btn_savenewbatch.Visible = true;
            btneditbatch.Enabled = false;
            btndeletebatch.Enabled = false;
            btnfindbatch.Enabled = false;
            btnposted.Enabled = false;

        }
        private void ClearBatch()
        {
            ClearCurrentInvoice();
            txt_APBatchNumber.Text = "";
            txt_Description.Text = "";
            txt_Period.Text = "";
            txt_Balance.Text = "0";
            txt_UserID.Text = "";
            txtBatchNum.Text = "";
            DTP_Date.Value = DateTime.Now;
            GeneralFunctions.UnLockTable("", "APTransactions", "", "Edit");
            GeneralFunctions.UnLockTable("", "APTransactions", "", "New");
        }

        private void btn_savenewbatch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateYear() || !ValidatePeriod())
                    return;
                if (dgv_Invoices.Rows.Count <= 0)
                {
                    MessageBox.Show("Can't Save Batch Insert Invoice Vendor","General Ledger");
                    return;
                }
                if (btnedit.Visible == false)
                    Btnsaveedit_Click(sender, e);
                if (btn_New.Visible == false)
                    btnSavenew_Click(sender, e);
                DataRow r = dbAccountingProjectDS.Batch.NewRow();
                r["BatchNo"] = txtBatchNum.Text;
                r["JVNumber"] = txt_APBatchNumber.Text;
                r["BatchDate"] = DTP_Date.Value.Date;
                r["BatchPRD"] = txt_Period.Text;
                r["BatchDSC"] = txt_Description.Text;
                r["BatchSRC"] = "AP";
                r["BatchJNL"] = DefaultAPJrl;
                r["BatchStat"] = txtstats.Text;
                r["UserID"] = AaDeclrationClass.xUserCode.ToString();
                r["REVBatch"] = 0;
                r["PropertyCode"] = "0";
                r["REVBatchNo"] = 0;
                r["REVBatchPRD"] = "";
                r["AllocationCode"] = "";
                r["Tran_Cashier"] = false;
                dbAccountingProjectDS.Batch.Rows.Add(r);
                SaveChangesBatch();
                ClearBatch();
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                btn_newbatch.Visible = true;
                btn_savenewbatch.Visible = false;
                btnfindbatch.Enabled = true;
                MessageBox.Show("Save Batch successfully", "General Ledger");
                GeneralFunctions.UnLockTable("", "APTransactions", "", "New");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void btnfindbatch_Click(object sender, EventArgs e)
        {
            try
            {
                ClearBatch();
                ReFill();
                SearchAP searchSpecificAP = new SearchAP();
                searchSpecificAP.ShowDialog();
                if (searchSpecificAP.selectAPNumber != "" && searchSpecificAP.selectAPNumber != null)
                {
                    txtBatchNum.Text = searchSpecificAP.selectAPNumber.ToString();
                    DataRow[] drb = dbAccountingProjectDS.Batch.Select("BatchNo = '" + int.Parse(txtBatchNum.Text) + "'");
                    if (drb.Length != 0)
                    {
                        string msg = GeneralFunctions.CheckLockTables("Batch", "", txtBatchNum.Text, "Edit");
                        if (msg != "")
                        {
                            if (drb[0]["BatchStat"].ToString().Trim() != "P")
                            {
                                MessageBox.Show("Can't Edit Because This Batch Edit By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                txtBatchNum.Text = "";
                                return;
                            }
                        }
                        GeneralFunctions.LockTables("Batch", "APTransactions", txtBatchNum.Text, "Edit");
                        txt_APBatchNumber.Text = drb[0]["JVNumber"].ToString();
                        DTP_Date.Value = Convert.ToDateTime(drb[0]["BatchDate"].ToString());
                        txt_Period.Text = drb[0]["BatchPRD"].ToString();
                        txt_Description.Text = drb[0]["BatchDSC"].ToString();
                        if (drb[0]["BatchStat"].ToString().Trim() == "U")
                            txtstats.Text = "U";
                        else if (drb[0]["BatchStat"].ToString().Trim() == "P")
                        {
                            txtstats.Text = "P";
                            txtPostedDate.Text = Convert.ToDateTime(drb[0]["PostDate"].ToString()).ToShortDateString(); ;
                        }
                        txt_UserID.Text = drb[0]["UserID"].ToString();
                        btneditbatch.Enabled = true;
                        btndeletebatch.Enabled = true;
                        btnposted.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Check Batch Number", "General Ledger");
                        txt_APBatchNumber.Text = "";
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"General Ledger");
            }
        }

        private void txtstats_TextChanged(object sender, EventArgs e)
        {
            if (txtstats.Text == "P")
            {
                if (groupBox4.Enabled == true)
                {
                    btnposted.Enabled = false;
                }
                else if (groupBox4.Enabled == false)
                {
                    btnposted.Enabled = false;

                }
            }
            else if (txtstats.Text == "U")
            {
                if (groupBox4.Enabled == true)
                {
                    btnposted.Enabled = false;
                }
                else if (groupBox4.Enabled == false)
                {
                    btnposted.Enabled = true;
                }
            }
            if (txtstats.Text == "U")
            {
                label31.Visible = false;
                txtPostedDate.Visible = false;
            }
            else if (txtstats.Text == "P")
            {
                label31.Visible = true;
                txtPostedDate.Visible = true;
                txtPostedDate.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void btnundobatch_Click(object sender, EventArgs e)
        {
            if (groupBox3.Enabled == true || groupBox4.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }

            btnundo_Click("NO", e);
            ClearBatch();
            btn_newbatch.Visible = true;
            btn_savenewbatch.Visible = false;
            btneditbatch.Visible = true;
            btn_Saveeditbatch.Visible = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            btn_newbatch.Enabled = true;
            btneditbatch.Enabled = false;
            btndeletebatch.Enabled = false;
            btnfindbatch.Enabled = true;
            btnposted.Enabled = false;

        }

        private void btn_Saveeditbatch_Click(object sender, EventArgs e)
        {
            if (!ValidateYear() || !ValidatePeriod())
                return;

            if (dgv_Invoices.Rows.Count <= 0)
            {
                MessageBox.Show("Can't Save Batch Insert Invoice Vendor", "General Ledger");
                return;
            }
            if (btnedit.Visible == false)
                Btnsaveedit_Click(sender, e);
            if (btn_New.Visible == false)
                btnSavenew_Click(sender, e);
            DataRow[] rArr = this.dbAccountingProjectDS.Batch.Select("BatchNo = '" + txtBatchNum.Text + "'");
            if (rArr.Length != 0)
            {
                rArr[0]["BatchNo"] = txtBatchNum.Text;
                rArr[0]["JVNumber"] = txt_APBatchNumber.Text;
                rArr[0]["BatchDate"] = DTP_Date.Value.Date;
                rArr[0]["BatchPRD"] = txt_Period.Text;
                rArr[0]["BatchDSC"] = txt_Description.Text;
                rArr[0]["BatchSRC"] = "AP";
                rArr[0]["BatchJNL"] = DefaultAPJrl;
                rArr[0]["BatchStat"] = txtstats.Text;
                rArr[0]["UserID"] = AaDeclrationClass.xUserCode.ToString(); 
                rArr[0]["REVBatch"] = 0;
                rArr[0]["PropertyCode"] = "0";
                rArr[0]["REVBatchNo"] = 0;
                rArr[0]["REVBatchPRD"] = "";
                rArr[0]["AllocationCode"] = "";
                SaveChangesBatch();
                MessageBox.Show("Batch edited successfully", "General Ledger");
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                btneditbatch.Visible = true;
                btn_Saveeditbatch.Visible = false;
                btn_newbatch.Enabled = true;
                btndeletebatch.Enabled = true;
                btnposted.Enabled = true;
            }
            else
            {
                DataRow r = dbAccountingProjectDS.Batch.NewRow();
                r["BatchNo"] = txtBatchNum.Text;
                r["JVNumber"] = txt_APBatchNumber.Text;
                r["BatchDate"] = DTP_Date.Value.Date;
                r["BatchPRD"] = txt_Period.Text;
                r["BatchDSC"] = txt_Description.Text;
                r["BatchSRC"] = "AP";
                r["BatchJNL"] = DefaultAPJrl;
                r["BatchStat"] = txtstats.Text;
                r["UserID"] = txt_UserID.Text;
                r["REVBatch"] = 0;
                r["PropertyCode"] = ""; 
                r["REVBatchNo"] = 0;
                r["REVBatchPRD"] = "";
                r["AllocationCode"] = "";
                r["Tran_Cashier"] = false;
                dbAccountingProjectDS.Batch.Rows.Add(r);
                SaveChangesBatch();
                MessageBox.Show("Batch edited successfully", "General Ledger");
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                btneditbatch.Visible = true;
                btn_Saveeditbatch.Visible = false;
                btn_newbatch.Enabled = true;
                btndeletebatch.Enabled = true;
                btnposted.Enabled = true;
            }
        }

        private void txt_AccountsCurrentBalance_TextChanged(object sender, EventArgs e)
        {
            CalculateBalanceBatch();
        }
        private string FindPeriod(DateTime prd)
        {
            int periodNamber;
            int prid;
            string prdbalance = "";
            if (GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, prd.Date), out prid, out periodNamber))
                prdbalance = "PeriodBalance" + periodNamber.ToString().Trim();
            else
                MessageBox.Show("The period has been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return prdbalance;
        }
        private void ModifyTotals(string prdbalance, string ApAccount, double val, DateTime prd)
        {
            double CurrentBalance=0;
            DataRow[] rArr = this.dbAccountingProjectDS.GLTotals.Select("AccountNumber ='" + ApAccount + "' AND FiscalYear = '" + prd.Year+ "'");
            if (rArr.Length != 0)
            {
                CurrentBalance = double.Parse(rArr[0][prdbalance].ToString());
                rArr[0][prdbalance] = EditPeriodNumber(CurrentBalance, val); 
            }
        }

        private double EditPeriodNumber(double periodBalance, double value)
        {
            double balance = 0;
            balance = periodBalance + value;
            return balance;
        }
        private void AddAccountsForBS_PL()
        {
            DataRow r;
            r = this.dbAccountingProjectDS.GLTransactions.NewRow();
            r["TransNO"] = NewTransNo();
            r["BatchNo"] = Convert.ToUInt32(txtBatchNum.Text);
            r["GLAccount"] = DefaultACCBalanceSheet; //txt_JVNumber.Text;
            r["TRANSREF"] = "BalanceSheet";
            r["TRANSDATE"] = DateTime.Now.ToShortDateString();
            r["TRANSUnit"] = 0;
            r["Amount"] = "0";
            r["AmountLC"] = -1 * ValBS;
            r["CurrencyType"] = "";
            r["Rate"] = "0";
            r["ProjectCode"] = "";
            r["DepartmentCode"] = "";
            r["SortNO"] = 0;
            
            dbAccountingProjectDS.GLTransactions.Rows.Add(r);
            r = this.dbAccountingProjectDS.GLTransactions.NewRow();
            r["TransNO"] = NewTransNo();
            r["BatchNo"] = Convert.ToUInt32(txtBatchNum.Text);
            r["GLAccount"] = DefaultACCIncomeStatment; //txt_JVNumber.Text;
            r["TRANSREF"] = "IncomeStatment";
            r["TRANSDATE"] = DateTime.Now.ToShortDateString();
            r["TRANSUnit"] = 0;
            r["Amount"] = "0";
            r["AmountLC"] = -1 * ValPT;
            r["CurrencyType"] = "";
            r["Rate"] = "0";
            r["ProjectCode"] = "";
            r["DepartmentCode"] = "";
            r["SortNO"] = 0;
            
            dbAccountingProjectDS.GLTransactions.Rows.Add(r);
        }
        private string AccType(string Acc)
        {
            string acctype = "";
            DataRow[] dracc = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + Acc + "'");
            if (dracc.Length != 0)
            {
                acctype = dracc[0]["AccountTypeName"].ToString();
            }
            return acctype;
        }
        private void btnposted_Click(object sender, EventArgs e)
        {
            string prdbalance = "";
            double val = 0;
            int BS = 0;
            int PL = 0;
            ValBS = 0;
            ValPT = 0;

            if (!ValidateYear() || !ValidatePeriod())
                return;
            if (txt_Balance.Text != "0")
            {
                MessageBox.Show("This Batch Must Have Zero Balance Value", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            try
            {
                ReFill();
                string msg = GeneralFunctions.CheckLockTables("GLTotals", "", "", "Edit");
                if (msg != "")
                {
                    MessageBox.Show("Can't Run Because GLTotals Edit By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                GeneralFunctions.LockTables("GLTotals", "APTransactions", "", "Edit");
                int sort = 1;
                DataRow[] drbatch = dbAccountingProjectDS.Batch.Select("BatchNo = '" + txtBatchNum.Text + "'");
                if (drbatch.Length != 0)
                {
                    DataRow[] drinvoice = dbAccountingProjectDS.APTrans.Select("APBatchNumber = '" + txtBatchNum.Text + "'");
                    if (drinvoice.Length != 0)
                    {
                        for (int i = 0; i < drinvoice.Length; i++)
                        {
                            DataRow rIn = dbAccountingProjectDS.GLTransactions.NewRow();
                            rIn["TransNO"] = NewTransNo();
                            rIn["BatchNo"] = int.Parse(txtBatchNum.Text);
                            rIn["GLAccount"] = APAccountNumber;
                            rIn["TRANSREF"] = drinvoice[i]["Reference"].ToString();
                            rIn["TRANSDATE"] = Convert.ToDateTime(drinvoice[i]["InvoiceDate"].ToString()).Date;
                            if (drinvoice[i]["TransactionType"].ToString() == "Invoice")
                            {
                                if (drinvoice[i]["InvoiceAmountCC"].ToString() == "" || drinvoice[i]["InvoiceAmountCC"].ToString() == null || drinvoice[i]["TaxValueCC"].ToString() == "" || drinvoice[i]["TaxValueCC"].ToString() == null)
                                    rIn["Amount"] = 0;
                                else
                                    rIn["Amount"] = -1 * (double.Parse(drinvoice[i]["InvoiceAmountCC"].ToString()) - double.Parse(drinvoice[i]["TaxValueCC"].ToString()));
                                rIn["CurrencyType"] = drinvoice[i]["CurrencyCode"].ToString();
                                if (drinvoice[i]["CurrencyRate"].ToString() == "" || drinvoice[i]["CurrencyRate"].ToString() == null)
                                    rIn["Rate"] = 0;
                                else
                                    rIn["Rate"] = double.Parse(drinvoice[i]["CurrencyRate"].ToString());
                                rIn["AmountLC"] = -1 * (double.Parse(drinvoice[i]["InvoiceAmount"].ToString()) - double.Parse(drinvoice[i]["TaxValue"].ToString()));
                                val = double.Parse(rIn["AmountLC"].ToString());
                                if (AccType(APAccountNumber) == "Assets" || AccType(APAccountNumber) == "Liability" || AccType(APAccountNumber) == "Equity")
                                {
                                    BS++;
                                    ValBS = ValBS + val;
                                }
                                else if (AccType(APAccountNumber) == "Revenue" || AccType(APAccountNumber) == "Expenses")
                                {
                                    PL++;
                                    ValPT = ValPT + val;
                                }
                            }
                            else if (drinvoice[i]["TransactionType"].ToString() == "CreditNote")
                            {
                                if (drinvoice[i]["InvoiceAmountCC"].ToString() == "" || drinvoice[i]["InvoiceAmountCC"].ToString() == null || drinvoice[i]["TaxValueCC"].ToString() == "" || drinvoice[i]["TaxValueCC"].ToString() == null)
                                    rIn["Amount"] = 0;
                                else
                                    rIn["Amount"] = (double.Parse(drinvoice[i]["InvoiceAmountCC"].ToString()) - double.Parse(drinvoice[i]["TaxValueCC"].ToString()));
                                rIn["CurrencyType"] = drinvoice[i]["CurrencyCode"].ToString();
                                if (drinvoice[i]["CurrencyRate"].ToString() == "" || drinvoice[i]["CurrencyRate"].ToString() == null)
                                    rIn["Rate"] = 0;
                                else
                                    rIn["Rate"] = double.Parse(drinvoice[i]["CurrencyRate"].ToString());
                                rIn["AmountLC"] = (double.Parse(drinvoice[i]["InvoiceAmount"].ToString()) - double.Parse(drinvoice[i]["TaxValue"].ToString()));
                                val = double.Parse(rIn["AmountLC"].ToString());
                                if (AccType(APAccountNumber) == "Assets" || AccType(APAccountNumber) == "Liability" || AccType(APAccountNumber) == "Equity")
                                {
                                    BS++;
                                    ValBS = ValBS + val;
                                }
                                else if (AccType(APAccountNumber) == "Revenue" || AccType(APAccountNumber) == "Expenses")
                                {
                                    PL++;
                                    ValPT = ValPT + val;
                                }

                            }
                            else if (drinvoice[i]["TransactionType"].ToString() == "AdvancedDeposit")
                            {
                                if (drinvoice[i]["InvoiceAmountCC"].ToString() == "" || drinvoice[i]["InvoiceAmountCC"].ToString() == null || drinvoice[i]["TaxValueCC"].ToString() == "" || drinvoice[i]["TaxValueCC"].ToString() == null)
                                    rIn["Amount"] = 0;
                                else
                                    rIn["Amount"] = (double.Parse(drinvoice[i]["InvoiceAmountCC"].ToString()) - double.Parse(drinvoice[i]["TaxValueCC"].ToString()));
                                rIn["CurrencyType"] = drinvoice[i]["CurrencyCode"].ToString();
                                if (drinvoice[i]["CurrencyRate"].ToString() == "" || drinvoice[i]["CurrencyRate"].ToString() == null)
                                    rIn["Rate"] = 0;
                                else
                                    rIn["Rate"] = double.Parse(drinvoice[i]["CurrencyRate"].ToString());
                                rIn["AmountLC"] = (double.Parse(drinvoice[i]["InvoiceAmount"].ToString()) - double.Parse(drinvoice[i]["TaxValue"].ToString()));
                                val = double.Parse(rIn["AmountLC"].ToString());
                                if (AccType(APAccountNumber) == "Assets" || AccType(APAccountNumber) == "Liability" || AccType(APAccountNumber) == "Equity")
                                {
                                    BS++;
                                    ValBS = ValBS + val;
                                }
                                else if (AccType(APAccountNumber) == "Revenue" || AccType(APAccountNumber) == "Expenses")
                                {
                                    PL++;
                                    ValPT = ValPT + val;
                                }

                            }
                            rIn["TRANSUnit"] = 0;
                            rIn["ProjectCode"] = drinvoice[i]["ProjectCode"].ToString();
                            rIn["DepartmentCode"] = drinvoice[i]["DepartmentCode"].ToString();
                            rIn["SortNO"] = sort;
                            sort = sort + 1;
                            
                            dbAccountingProjectDS.GLTransactions.Rows.Add(rIn);
                            prdbalance = FindPeriod(Convert.ToDateTime(drbatch[0]["BatchDate"].ToString()).Date);

                            ModifyTotals(prdbalance, APAccountNumber, val, Convert.ToDateTime(drbatch[0]["BatchDate"].ToString()).Date);
                            if (drinvoice[i]["DeliveryType"].ToString() != "" && drinvoice[i]["DeliveryType"].ToString() != null && drinvoice[i]["TransactionType"].ToString() == "Invoice")
                            {
                                DataRow[] rd = dbAccountingProjectDS.APDeliveryType.Select("DeliveryTypeName = '" + drinvoice[i]["DeliveryType"].ToString() + "'");
                                if (rd.Length != 0)
                                {
                                    rIn = dbAccountingProjectDS.GLTransactions.NewRow();
                                    rIn["TransNO"] = NewTransNo();
                                    rIn["BatchNo"] = int.Parse(txtBatchNum.Text);
                                    rIn["GLAccount"] = rd[0]["DeliveryTypeAccountNumber"].ToString();
                                    rIn["TRANSREF"] = drinvoice[i]["DeliveryType"].ToString();
                                    rIn["TRANSDATE"] = Convert.ToDateTime(drinvoice[i]["InvoiceDate"].ToString()).Date;
                                    if (drinvoice[i]["TransactionType"].ToString() == "Invoice")
                                    {
                                        if (drinvoice[i]["TaxValueCC"].ToString() == "" || drinvoice[i]["TaxValueCC"].ToString() == null)
                                            rIn["Amount"] = 0;
                                        else
                                            rIn["Amount"] = -1 * (double.Parse(drinvoice[i]["TaxValueCC"].ToString()));
                                        rIn["CurrencyType"] = drinvoice[i]["CurrencyCode"].ToString();
                                        if (drinvoice[i]["CurrencyRate"].ToString() == "" || drinvoice[i]["CurrencyRate"].ToString() == null)
                                            rIn["Rate"] = 0;
                                        else
                                            rIn["Rate"] = double.Parse(drinvoice[i]["CurrencyRate"].ToString());
                                        if (drinvoice[i]["TaxValue"].ToString() == "" || drinvoice[i]["TaxValue"].ToString() == null)
                                            rIn["AmountLC"] = 0;
                                        else
                                            rIn["AmountLC"] = -1 * (double.Parse(drinvoice[i]["TaxValue"].ToString()));
                                        val = double.Parse(rIn["AmountLC"].ToString());
                                        if (AccType(rd[0]["DeliveryTypeAccountNumber"].ToString()) == "Assets" || AccType(rd[0]["DeliveryTypeAccountNumber"].ToString()) == "Liability" || AccType(rd[0]["DeliveryTypeAccountNumber"].ToString()) == "Equity")
                                        {
                                            BS++;
                                            ValBS = ValBS + val;
                                        }
                                        else if (AccType(rd[0]["DeliveryTypeAccountNumber"].ToString()) == "Revenue" || AccType(rd[0]["DeliveryTypeAccountNumber"].ToString()) == "Expenses")
                                        {
                                            PL++;
                                            ValPT = ValPT + val;
                                        }

                                    }
                                    else if (drinvoice[i]["TransactionType"].ToString() == "CreditNote")
                                    {
                                        if (drinvoice[i]["TaxValueCC"].ToString() == "" || drinvoice[i]["TaxValueCC"].ToString() == null)
                                            rIn["Amount"] = 0;
                                        else
                                            rIn["Amount"] = (double.Parse(drinvoice[i]["TaxValueCC"].ToString()));
                                        rIn["CurrencyType"] = drinvoice[i]["CurrencyCode"].ToString();
                                        if (drinvoice[i]["CurrencyRate"].ToString() == "" || drinvoice[i]["CurrencyRate"].ToString() == null)
                                            rIn["Rate"] = 0;
                                        else
                                            rIn["Rate"] = double.Parse(drinvoice[i]["CurrencyRate"].ToString());
                                        if (drinvoice[i]["TaxValue"].ToString() == "" || drinvoice[i]["TaxValue"].ToString() == null)
                                            rIn["AmountLC"] = 0;
                                        else
                                            rIn["AmountLC"] = (double.Parse(drinvoice[i]["TaxValue"].ToString()));
                                        val = double.Parse(rIn["AmountLC"].ToString());
                                        if (AccType(rd[0]["DeliveryTypeAccountNumber"].ToString()) == "Assets" || AccType(rd[0]["DeliveryTypeAccountNumber"].ToString()) == "Liability" || AccType(rd[0]["DeliveryTypeAccountNumber"].ToString()) == "Equity")
                                        {
                                            BS++;
                                            ValBS = ValBS + val;
                                        }
                                        else if (AccType(rd[0]["DeliveryTypeAccountNumber"].ToString()) == "Revenue" || AccType(rd[0]["DeliveryTypeAccountNumber"].ToString()) == "Expenses")
                                        {
                                            PL++;
                                            ValPT = ValPT + val;
                                        }

                                    }
                                    else if (drinvoice[i]["TransactionType"].ToString() == "AdvancedDeposit")
                                    {
                                        if (drinvoice[i]["TaxValueCC"].ToString() == "" || drinvoice[i]["TaxValueCC"].ToString() == null)
                                            rIn["Amount"] = 0;
                                        else
                                            rIn["Amount"] = (double.Parse(drinvoice[i]["TaxValueCC"].ToString()));
                                        rIn["CurrencyType"] = drinvoice[i]["CurrencyCode"].ToString();
                                        if (drinvoice[i]["CurrencyRate"].ToString() == "" || drinvoice[i]["CurrencyRate"].ToString() == null)
                                            rIn["Rate"] = 0;
                                        else
                                            rIn["Rate"] = double.Parse(drinvoice[i]["CurrencyRate"].ToString());
                                        if (drinvoice[i]["TaxValue"].ToString() == "" || drinvoice[i]["TaxValue"].ToString() == null)
                                            rIn["AmountLC"] = 0;
                                        else
                                            rIn["AmountLC"] = (double.Parse(drinvoice[i]["TaxValue"].ToString()));
                                        val = double.Parse(rIn["AmountLC"].ToString());
                                        if (AccType(rd[0]["DeliveryTypeAccountNumber"].ToString()) == "Assets" || AccType(rd[0]["DeliveryTypeAccountNumber"].ToString()) == "Liability" || AccType(rd[0]["DeliveryTypeAccountNumber"].ToString()) == "Equity")
                                        {
                                            BS++;
                                            ValBS = ValBS + val;
                                        }
                                        else if (AccType(rd[0]["DeliveryTypeAccountNumber"].ToString()) == "Revenue" || AccType(rd[0]["DeliveryTypeAccountNumber"].ToString()) == "Expenses")
                                        {
                                            PL++;
                                            ValPT = ValPT + val;
                                        }

                                    }
                                    rIn["TRANSUnit"] = 0;
                                    rIn["ProjectCode"] = drinvoice[i]["ProjectCode"].ToString();
                                    rIn["DepartmentCode"] = drinvoice[i]["DepartmentCode"].ToString();
                                    rIn["SortNO"] = sort;
                                    sort = sort + 1;
                                    
                                    dbAccountingProjectDS.GLTransactions.Rows.Add(rIn);
                                    ModifyTotals(prdbalance, rd[0]["DeliveryTypeAccountNumber"].ToString(), val, Convert.ToDateTime(drbatch[0]["BatchDate"].ToString()).Date);

                                }
                            }
                            DataRow[] drexpense = dbAccountingProjectDS.APExpense.Select("BatchInvoiceID = '" + drinvoice[i]["BatchInvoiceID"] + "'");
                            if (drexpense.Length != 0)
                            {
                                for (int a = 0; a < drexpense.Length; a++)
                                {
                                    rIn = dbAccountingProjectDS.GLTransactions.NewRow();
                                    rIn["TransNO"] = NewTransNo();
                                    rIn["BatchNo"] = int.Parse(txtBatchNum.Text);
                                    rIn["GLAccount"] = drexpense[a]["GLAccountNumber"].ToString();
                                    rIn["TRANSREF"] = drexpense[a]["GLAccountDescription"].ToString();
                                    rIn["TRANSDATE"] = Convert.ToDateTime(drinvoice[i]["InvoiceDate"].ToString()).Date;
                                    if (drinvoice[i]["TransactionType"].ToString() == "Invoice")
                                    {
                                        rIn["Amount"] = double.Parse(drexpense[a]["AccountAmountCC"].ToString());
                                        rIn["CurrencyType"] = drinvoice[i]["CurrencyCode"].ToString();
                                        if (drinvoice[i]["CurrencyRate"].ToString() == "" || drinvoice[i]["CurrencyRate"].ToString() == null)
                                            rIn["Rate"] = 0;
                                        else
                                            rIn["Rate"] = double.Parse(drinvoice[i]["CurrencyRate"].ToString());
                                        rIn["AmountLC"] = double.Parse(drexpense[a]["AccountAmount"].ToString());
                                        val = double.Parse(rIn["AmountLC"].ToString());
                                        if (AccType(drexpense[a]["GLAccountNumber"].ToString()) == "Assets" || AccType(drexpense[a]["GLAccountNumber"].ToString()) == "Liability" || AccType(drexpense[a]["GLAccountNumber"].ToString()) == "Equity")
                                        {
                                            BS++;
                                            ValBS = ValBS + val;
                                        }
                                        else if (AccType(drexpense[a]["GLAccountNumber"].ToString()) == "Revenue" || AccType(drexpense[a]["GLAccountNumber"].ToString()) == "Expenses")
                                        {
                                            PL++;
                                            ValPT = ValPT + val;
                                        }
                                    }
                                    else if (drinvoice[i]["TransactionType"].ToString() == "CreditNote")
                                    {
                                        rIn["Amount"] = -1 * double.Parse(drexpense[a]["AccountAmountCC"].ToString());
                                        rIn["CurrencyType"] = drinvoice[i]["CurrencyCode"].ToString();
                                        if (drinvoice[i]["CurrencyRate"].ToString() == "" || drinvoice[i]["CurrencyRate"].ToString() == null)
                                            rIn["Rate"] = 0;
                                        else
                                            rIn["Rate"] = double.Parse(drinvoice[i]["CurrencyRate"].ToString());
                                        rIn["AmountLC"] = -1 * double.Parse(drexpense[a]["AccountAmount"].ToString());
                                        val = double.Parse(rIn["AmountLC"].ToString());
                                        if (AccType(drexpense[a]["GLAccountNumber"].ToString()) == "Assets" || AccType(drexpense[a]["GLAccountNumber"].ToString()) == "Liability" || AccType(drexpense[a]["GLAccountNumber"].ToString()) == "Equity")
                                        {
                                            BS++;
                                            ValBS = ValBS + val;
                                        }
                                        else if (AccType(drexpense[a]["GLAccountNumber"].ToString()) == "Revenue" || AccType(drexpense[a]["GLAccountNumber"].ToString()) == "Expenses")
                                        {
                                            PL++;
                                            ValPT = ValPT + val;
                                        }

                                    }
                                    else if (drinvoice[i]["TransactionType"].ToString() == "AdvancedDeposit")
                                    {
                                        rIn["Amount"] = -1 * double.Parse(drexpense[a]["AccountAmountCC"].ToString());
                                        rIn["CurrencyType"] = drinvoice[i]["CurrencyCode"].ToString();
                                        if (drinvoice[i]["CurrencyRate"].ToString() == "" || drinvoice[i]["CurrencyRate"].ToString() == null)
                                            rIn["Rate"] = 0;
                                        else
                                            rIn["Rate"] = double.Parse(drinvoice[i]["CurrencyRate"].ToString());
                                        rIn["AmountLC"] = -1 * double.Parse(drexpense[a]["AccountAmount"].ToString());
                                        val = double.Parse(rIn["AmountLC"].ToString());
                                        if (AccType(drexpense[a]["GLAccountNumber"].ToString()) == "Assets" || AccType(drexpense[a]["GLAccountNumber"].ToString()) == "Liability" || AccType(drexpense[a]["GLAccountNumber"].ToString()) == "Equity")
                                        {
                                            BS++;
                                            ValBS = ValBS + val;
                                        }
                                        else if (AccType(drexpense[a]["GLAccountNumber"].ToString()) == "Revenue" || AccType(drexpense[a]["GLAccountNumber"].ToString()) == "Expenses")
                                        {
                                            PL++;
                                            ValPT = ValPT + val;
                                        }

                                    }
                                    rIn["TRANSUnit"] = 0;
                                    rIn["ProjectCode"] = drexpense[a]["AccountProjectCode"].ToString();
                                    rIn["DepartmentCode"] = drexpense[a]["DepartmentCode"].ToString();
                                    rIn["SortNO"] = sort;
                                    sort = sort + 1;
                                    
                                    dbAccountingProjectDS.GLTransactions.Rows.Add(rIn);
                                    ModifyTotals(prdbalance, drexpense[a]["GLAccountNumber"].ToString(), val, Convert.ToDateTime(drbatch[0]["BatchDate"].ToString()).Date);

                                }
                            }
                        }
                    }
                    if (BS > 0 && PL > 0)
                    {
                        AddAccountsForBS_PL();
                        ModifyTotals(prdbalance, DefaultACCBalanceSheet, (-1 * ValBS), Convert.ToDateTime(drbatch[0]["BatchDate"].ToString()).Date);
                        ModifyTotals(prdbalance, DefaultACCIncomeStatment, (-1 * ValPT), Convert.ToDateTime(drbatch[0]["BatchDate"].ToString()).Date);
                    }
                    else
                    {

                        ValPT = 0;
                        ValBS = 0;
                    }
                    drbatch[0]["BatchStat"] = "P";
                    drbatch[0]["PostDate"] = DateTime.Now.Date;
                    SaveChangesBatch();
                    MessageBox.Show("The Batch is posted", "General Ledger");
                    txtstats.Text = "P";
                    btnfindbatch.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
            finally
            {
                GeneralFunctions.UnLockTable("GLTotals", "APTransactions", "", "Edit");
            }
        
        }

        private void txt_NetInvoiceAmount_Leave(object sender, EventArgs e)
        {
            if (txt_NetInvoiceAmount.Text == "")
                txt_NetInvoiceAmount.Text = "0";
        }

        private void txt_SalesTaxAmount_Leave(object sender, EventArgs e)
        {
            if (txt_SalesTaxAmount.Text == "")
                txt_SalesTaxAmount.Text = "0";
        }

        private void txt_DiscountValue_Leave(object sender, EventArgs e)
        {
            if (txt_DiscountValue.Text == "")
                txt_DiscountValue.Text = "0";
        }

        private void txt_CurrencyRate_TextChanged(object sender, EventArgs e)
        {
            DataRow r;
            for (int i = 0; i < dtInvoiceAccounts.Rows.Count; i++)
            {
                r = dtInvoiceAccounts.Rows[i];
                if (r.Equals(dtInvoiceAccounts.Rows[dtInvoiceAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountName"].ToString() == "")
                    break;
                dtInvoiceAccounts.Rows[i]["Amount"] = double.Parse(txt_CurrencyRate.Text) * double.Parse(dtInvoiceAccounts.Rows[i]["AmountCC"].ToString());
            }
            CalculateBalance();
        }

        private void txt_VendorCode_TextChanged(object sender, EventArgs e)
        {
            Err.SetError(txt_VendorCode, "");
        }

        private void txt_InvoiceAmount_TextChanged(object sender, EventArgs e)
        {
            Err.SetError(txt_InvoiceAmount, "");

        }

        private void dgv_InvoiceDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgv_InvoiceDetails.SelectedRows.Count != 0)
            {

                if (e.KeyCode == Keys.Delete)
                {
                    DialogResult myrst;
                    myrst = MessageBox.Show("Are You Sure Delete", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (myrst == DialogResult.No)
                        return;
                    DataRow[] rArr;
                    if (dgv_InvoiceDetails.CurrentRow.Cells["AccountNumber"].Value.ToString() != "")
                    {
                        string accountID = dgv_InvoiceDetails.CurrentRow.Cells["AccountNumber"].Value.ToString();
                        rArr = dtInvoiceAccounts.Select("AccountNumber = '" + accountID + "'");
                        if (rArr.Length > 0)
                        {
                            rArr[0].Delete();
                            CalculateBalance();
                            SqlConnection sqlconndelete = new SqlConnection(GeneralFunctions.ConnectionString);
                            sqlconndelete.Open();
                            SqlCommand sqlcommandDeletetran = new SqlCommand("Delete From APExpense Where GLAccountNumber = '" + accountID + "' And BatchInvoiceID = " + int.Parse(dgv_Invoices.CurrentRow.Cells["BatchInvoiceID"].Value.ToString()), sqlconndelete);
                            SqlDataReader drDeletetran = sqlcommandDeletetran.ExecuteReader();
                            drDeletetran.Close();
                            sqlconndelete.Close();
                            ReFill();

                        }
                    }
                }
            }
        }
        private bool ValidatePeriod()
        {
            bool valid = true;
            SqlConnection sqlconnectValidate = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand sqlcommandValidate;
            sqlcommandValidate = new SqlCommand("Select Status From GLFiscalPeriod WHERE PeriodDescription='" + txt_Period.Text + "' AND YEAR(PeriodStartDate)=" + DTP_Date.Value.Year + "", sqlconnectValidate);
            sqlconnectValidate.Open();
            SqlDataReader sqlRead = sqlcommandValidate.ExecuteReader();
            string StatusValue = "";
            if (sqlRead.HasRows)
            {
                while (sqlRead.Read())
                {
                    StatusValue = sqlRead.GetString(0);
                    if (StatusValue == "CLOSED")
                    {
                        Err.SetError(txt_Period, "The given period is closed");
                        MessageBox.Show("The given period is closed");
                        valid = false;
                    }
                    else if (StatusValue == "OPEN")
                    {
                        Err.SetError(txt_Period, "");
                        valid = true;
                    }
                }
            }
            else
            {
                Err.SetError(txt_Period, "The given period isn't exists for this year");
                MessageBox.Show("The given period isn't exists for this year");
                valid = false;
            }
            Err.SetError(txt_Period, "");
            return valid;
        }
        private bool ValidateYear()
        {
            bool valid = true;
            SqlConnection sqlconnectValidate = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand sqlcommandValidate;
            sqlcommandValidate = new SqlCommand("Select Status From GLFiscalPeriodSetup WHERE FiscalYear=" + Convert.ToDateTime(DTP_Date.Value).Year + "", sqlconnectValidate);
            sqlconnectValidate.Open();
            SqlDataReader sqlRead = sqlcommandValidate.ExecuteReader();
            string StatusValue = "";
            if (sqlRead.HasRows)
            {
                while (sqlRead.Read())
                {
                    StatusValue = sqlRead.GetString(0);
                    if (StatusValue == "CLOSED")
                    {
                        Err.SetError(DTP_Date, "The given Year is closed");
                        MessageBox.Show("The given Year is closed");
                        valid = false;
                    }
                    else if (StatusValue == "OPEN")
                    {
                        Err.SetError(DTP_Date, "");
                        valid = true;
                    }
                }
            }
            else
            {
                Err.SetError(DTP_Date, "The given year isn't exists for fiscal year");
                MessageBox.Show("The given year isn't exists for fiscal year");
                valid = false;
            }
            Err.SetError(DTP_Date, "");
            return valid;
        }

        private void cb_DepartmentCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_DepartmentCode.Text == "<new>")
            {
                DepartmentCode pc = new DepartmentCode();
                pc.ShowDialog();
                cb_DepartmentCode.Items.Clear();
                adaptertbdepartmentCodes.Fill(dbAccountingProjectDS.DepartmentCode);
                cb_DepartmentCode = GeneralFunctions.FillComboBox(dbAccountingProjectDS.DepartmentCode, cb_DepartmentCode, "Code", "ID");
                dgvd.Items.Clear();
                dgvd = GeneralFunctions.AddItems(dgvd, dbAccountingProjectDS.DepartmentCode, "Code");
            }

        }
        private void dgv_InvoiceDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        private void APTransactions_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralFunctions.UnLockTable("", "APTransactions", "", "");
        }

        private void txt_InvoiceNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else
                e.Handled = true;
        }

    }
}
