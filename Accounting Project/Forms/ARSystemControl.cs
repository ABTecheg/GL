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
    public partial class ARSystemControl : Form
    {
        public SqlConnection sqlcon;
        public SqlDataAdapter adapter;
        public SqlCommandBuilder cmdBuilder;
        public ARSystemControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccountSearch AccF = new AccountSearch();
            AccF.ShowDialog();
            this.txt_GLAccount.Text = AccF.selectedAccountNumber;
        }
        private void ClearControls()
        {

            #region TabOneControls

            YearsToRetain.Value = 0;
            MonthForArchieve.Value = 0;
            chxOverCredit.Checked = false;
            chxConfirmation.Checked = false;
            chxRequire.Checked = false;
            ComboStatus.SelectedIndex = 0;
            txt_CreditLimit.Text = "";
            txt_Annual.Text = "";
            txt_MinmumFinance.Text = "";
            txt_FinanceCharge.Text = "";
            txt_nightAudit.Text = "";
            txt_DefaultDirectory.Text = "";
            Combo_Transaction.SelectedIndex = 0;
            chxCompound.Checked = false;

            #endregion

            #region Tab2Controls
            chxPrintTax.Checked = false;
            chxPrintInformation.Checked = false;
            chxAutomaticInvoices.Checked = false;
            chxEmailInvoices.Checked = false;
            chxPrintStat.Checked = false;
            chxShowAllTrans.Checked = false;
            chxDisplayOriginal.Checked = false;
            chxImportCard.Checked = false;
            chxUseAR.Checked = false;
            chxUseInvoicesDate.Checked = false;
            chx_AgeCredits.Checked = false;

            txt_AgingPeriodFifth.Text = "";
            txt_AgingPeriodForth.Text = "";
            txt_AgingPeriodThree.Text = "";
            txt_AgingPeriodTow.Text = "";
            txt_AgingPeriodOne.Text = "";
            txt_DaysPeriodFifth.Text = "";
            txt_DaysPeriodforth.Text = "";
            txt_DaysPeriodThree.Text = "";
            txt_DaysPeriodTow.Text = "";
            txt_DaysPeriodOne.Text = "";
            txt_FinanceDesc.Text = "";
            txt_BalanceDesc.Text = "";

            ComboStatement.SelectedIndex = 0;
            radio_BalanceForword.Checked = false;
            radio_OpenItem.Checked = false;
            #endregion

            #region Tab3Controls
            txt_SMTP.Text = "";
            txt_EmailAdd.Text = "";
            txt_AuthLogin.Text = "";
            txt_Password.Text = "";
            txt_ARCode.Text = "";
            txtTerminalID.Text = "";
            chxAuthentication.Checked = false;
            chxAutoPost.Checked = false;
            chxCreditProcessing.Checked = false;
            chxCreditTracking.Checked = false;
            chxUseCreditPrinting.Checked = false;
            chxDontStore.Checked = false;
            chxTimeShare.Checked = false;
            radioHotel.Checked = false;
            radioMarketing.Checked = false;
            comboPrinterType.SelectedIndex = 0;
            comboProcessorType.SelectedIndex = 0;
            #endregion
        }
       

        private void ARSystemControl_Load(object sender, EventArgs e)
        {
            string msg = GeneralFunctions.CheckLockTables("", "", "", "");
            if (msg != "")
            {
                MessageBox.Show("Can't Open Because Other Form Open By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
                return;
            }
            GeneralFunctions.LockTables("All", "ARSystemControl", "", "");

            this.ARSystemSetupTableAdapter = new Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.ARSystemSetupTableAdapter();
            // TODO: This line of code loads data into the 'dbAccountingProjectDS.GLAccounts' table. You can move, or remove it, as needed.
      
            this.ARSystemSetupTableAdapter.Fill(this.dbAccountingProjectDS.ARSystemSetup);
            this.gLAccountsTableAdapter.Fill(this.dbAccountingProjectDS.GLAccounts);
            // TODO: This line of code loads data into the 'dbAccountingProjectDS.ARTransactionCodes' table. You can move, or remove it, as needed.
            this.aRTransactionCodesTableAdapter.Fill(this.dbAccountingProjectDS.ARTransactionCodes);
            // TODO: This line of code loads data into the 'dbAccountingProjectDS.APTrans' table. You can move, or remove it, as needed.
            this.aPTransTableAdapter.Fill(this.dbAccountingProjectDS.APTrans);

            //GeneralFunctions.priviledgeGroupBox(ARGroup);
            SqlConnection sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon.Open();
            SqlCommand sqlcomm = new SqlCommand("Select * From ARSystemSetup", sqlcon);
            SqlDataReader sqlread = sqlcomm.ExecuteReader();
            if (sqlread.HasRows)
            {
                while (sqlread.Read())
                {

                    #region TabOneControls
                    txtID.Text = sqlread["ARSetupID"].ToString();
                    txt_GLAccount.Text = sqlread["ARAccountNum"].ToString();
                    YearsToRetain.Value = decimal.Parse(sqlread["YearsToRetain"].ToString());
                    MonthForArchieve.Value = decimal.Parse(sqlread["MonthAllowed"].ToString());
                    chxOverCredit.Checked = bool.Parse(sqlread["DisplayOverCredit"].ToString());
                    chxConfirmation.Checked = bool.Parse(sqlread["DisplayConfirmation"].ToString());
                    chxRequire.Checked = bool.Parse(sqlread["RequireFirst"].ToString());
                    ComboStatus.SelectedValue = (object)(sqlread["AccStatus"].ToString());


                    txt_CreditLimit.Text = sqlread["AccCredit"].ToString();
                    txt_Annual.Text = sqlread["AnnualFinance"].ToString();
                    txt_MinmumFinance.Text = sqlread["MinmumFinance"].ToString();
                    txt_FinanceCharge.Text = sqlread["FinanceChargeDay"].ToString();
                    txt_nightAudit.Text = sqlread["NightAuditCode"].ToString();
                    txt_DefaultDirectory.Text = sqlread["DefaultDocument"].ToString();
                    Combo_Transaction.SelectedValue = (object)(sqlread["FinanceTransCode"].ToString());
                    chxCompound.Checked = bool.Parse(sqlread["CompoundFinance"].ToString());

                    #endregion

                    #region Tab2Controls



                    chxPrintTax.Checked = bool.Parse(sqlread["PrintTax"].ToString());
                    chxPrintInformation.Checked = bool.Parse(sqlread["PrintInfo"].ToString());
                    chxAutomaticInvoices.Checked = bool.Parse(sqlread["AutoInvoices"].ToString());
                    chxEmailInvoices.Checked = bool.Parse(sqlread["EmailInvoices"].ToString());
                    chxPrintStat.Checked = bool.Parse(sqlread["PrintStatement"].ToString());
                    chxShowAllTrans.Checked = bool.Parse(sqlread["ShowTransBill"].ToString());
                    chxDisplayOriginal.Checked = bool.Parse(sqlread["DisplayOriginalCharge"].ToString());
                    chxImportCard.Checked = bool.Parse(sqlread["ImportCreditCard"].ToString());
                    chxUseAR.Checked = bool.Parse(sqlread["UseARTax"].ToString());
                    chxUseInvoicesDate.Checked = bool.Parse(sqlread["UseInvoiceDate"].ToString());
                    chx_AgeCredits.Checked = bool.Parse(sqlread["AgeCredits"].ToString());

                    txt_AgingPeriodFifth.Text = sqlread["DAgingFive"].ToString();
                    txt_AgingPeriodForth.Text = sqlread["DAgingFour"].ToString();
                    txt_AgingPeriodThree.Text = sqlread["DAgingThree"].ToString();
                    txt_AgingPeriodTow.Text = sqlread["DAgingTOW"].ToString();
                    txt_AgingPeriodOne.Text = sqlread["DAgingONE"].ToString();
                    txt_DaysPeriodFifth.Text = sqlread["DPeriodFive"].ToString();
                    txt_DaysPeriodforth.Text = sqlread["DPeriodFour"].ToString();
                    txt_DaysPeriodThree.Text = sqlread["DPeriodThree"].ToString();
                    txt_DaysPeriodTow.Text = sqlread["DPeriodTow"].ToString();
                    txt_DaysPeriodOne.Text = sqlread["DPeriodONE"].ToString();
                    txt_FinanceDesc.Text = sqlread["FinanceDesc"].ToString();
                    txt_BalanceDesc.Text = sqlread["BalanceDesc"].ToString();

                    ComboStatement.SelectedValue = sqlread["StatementAccount"];
                    radio_BalanceForword.Checked = bool.Parse(sqlread["BalanceForword"].ToString());
                    radio_OpenItem.Checked = bool.Parse(sqlread["OpenItem"].ToString());
                    #endregion

                    #region Tab3Controls


                    txt_SMTP.Text = sqlread["ServerStp"].ToString();
                    txt_EmailAdd.Text = sqlread["EmailAdd"].ToString();
                    txt_AuthLogin.Text = sqlread["AuthentLog"].ToString();
                    txt_Password.Text = sqlread["AuthentPass"].ToString();
                    txt_ARCode.Text = sqlread["ARCodeForInvalid"].ToString();
                    txtTerminalID.Text = sqlread["TerminalID"].ToString();
                    chxAuthentication.Checked = bool.Parse(sqlread["UseAuthent"].ToString());
                    chxAutoPost.Checked = bool.Parse(sqlread["AutoPost"].ToString());
                    chxCreditProcessing.Checked = bool.Parse(sqlread["CreditProcessing"].ToString());
                    chxCreditTracking.Checked = bool.Parse(sqlread["CreditTracking"].ToString());
                    chxUseCreditPrinting.Checked = bool.Parse(sqlread["CreditPrinting"].ToString());
                    chxDontStore.Checked = bool.Parse(sqlread["DontStore"].ToString());
                    chxTimeShare.Checked = bool.Parse(sqlread["TimeShare"].ToString());
                    radioHotel.Checked = bool.Parse(sqlread["HotelIndust"].ToString());
                    radioMarketing.Checked = bool.Parse(sqlread["DirectMarket"].ToString());
                    comboPrinterType.SelectedItem = sqlread["PrinterType"];
                    comboProcessorType.SelectedItem = sqlread["ProcessType"];
                    #endregion
                }
                sqlread.Close();
            }
            else
            {
                ClearControls();
               
                txtID.Text = "1";

             
                SaveNewBtn.Visible = true;
                btnedit.Visible = false;
                Btnsaveedit.Visible = false;
                tab1groupBox.Enabled = true;
                Tab2groupBox.Enabled = true;
                tab3groupBox.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AccountSearch AccF = new AccountSearch();
            AccF.ShowDialog();
            this.txt_ARCode.Text = AccF.selectedAccountNumber;
        }

        private void NewSaveBtn_Click(object sender, EventArgs e)
        {
            if (txt_GLAccount.Text == "")
                MessageBox.Show("Should Choose Account Number", "system Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                int id = int.Parse(txtID.Text.ToString());
                sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand(" Select ARSetupID from ARSystemSetup where ARSetupID= '" + id + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();

                if (!dr.HasRows)
                {
                    DataRow r = dbAccountingProjectDS.ARSystemSetup.NewRow();

                    #region TabOneControls
                    r["ARAccountNum"] = txt_GLAccount.Text;
                    r["YearsToRetain"] = YearsToRetain.Value;
                    r["MonthAllowed"] = MonthForArchieve.Value;
                    r["DisplayOverCredit"] = chxOverCredit.Checked;
                    r["DisplayConfirmation"] = chxConfirmation.Checked;
                    r["RequireFirst"] = chxRequire.Checked;
                    r["AccStatus"] = ComboStatus.SelectedIndex;
                    r["AccCredit"] = txt_CreditLimit.Text;
                    r["AnnualFinance"] = txt_Annual.Text;
                    r["MinmumFinance"] = txt_MinmumFinance.Text;
                    r["FinanceChargeDay"] = txt_FinanceCharge.Text;
                    r["NightAuditCode"] = txt_nightAudit.Text;
                    r["DefaultDocument"] = txt_DefaultDirectory.Text;
                    r["FinanceTransCode"] = Combo_Transaction.SelectedValue.ToString();
                    r["CompoundFinance"] = chxCompound.Checked;

                    #endregion

                    #region Tab2Controls
                    r["PrintTax"] = chxPrintTax.Checked;
                    r["PrintInfo"] = chxPrintInformation.Checked;
                    r["AutoInvoices"] = chxAutomaticInvoices.Checked;
                    r["EmailInvoices"] = chxEmailInvoices.Checked;
                    r["PrintStatement"] = chxPrintStat.Checked;
                    r["ShowTransBill"] = chxShowAllTrans.Checked;
                    r["DisplayOriginalCharge"] = chxDisplayOriginal.Checked;
                    r["ImportCreditCard"] = chxImportCard.Checked;
                    r["UseARTax"] = chxUseAR.Checked;
                    r["UseInvoiceDate"] = chxUseInvoicesDate.Checked;
                    r["AgeCredits"] = chx_AgeCredits.Checked;

                    r["DAgingFive"] = txt_AgingPeriodFifth.Text;
                    r["DAgingFour"] = txt_AgingPeriodForth.Text;
                    r["DAgingThree"] = txt_AgingPeriodThree.Text;
                    r["DAgingTOW"] = txt_AgingPeriodTow.Text;
                    r["DAgingONE"] = txt_AgingPeriodOne.Text;
                    r["DPeriodFive"] = txt_DaysPeriodFifth.Text;
                    r["DPeriodFour"] = txt_DaysPeriodforth.Text;
                    r["DPeriodThree"] = txt_DaysPeriodThree.Text;
                    r["DPeriodTow"] = txt_DaysPeriodTow.Text;
                    r["DPeriodONE"] = txt_DaysPeriodOne.Text;
                    r["FinanceDesc"] = txt_FinanceDesc.Text;
                    r["BalanceDesc"] = txt_BalanceDesc.Text;

                    r["StatementAccount"] = ComboStatement.SelectedValue.ToString();
                    r["BalanceForword"] = radio_BalanceForword.Checked;
                    r["OpenItem"] = radio_OpenItem.Checked;
                    #endregion

                    #region Tab3Controls
                    r["ServerStp"] = txt_SMTP.Text;
                    r["EmailAdd"] = txt_EmailAdd.Text;

                    r["AuthentLog"] = txt_AuthLogin.Text;
                    r["AuthentPass"] = txt_Password.Text;
                    r["ARCodeForInvalid"] = txt_ARCode.Text;
                    r["TerminalID"] = txtTerminalID.Text;
                    r["UseAuthent"] = chxAuthentication.Checked;
                    r["AutoPost"] = chxAutoPost.Checked;
                    r["CreditProcessing"] = chxCreditProcessing.Checked;
                    r["CreditTracking"] = chxCreditTracking.Checked;
                    r["CreditPrinting"] = chxUseCreditPrinting.Checked;
                    r["DontStore"] = chxDontStore.Checked;
                    r["TimeShare"] = chxTimeShare.Checked;
                    r["HotelIndust"] = radioHotel.Checked;
                    r["DirectMarket"] = radioMarketing.Checked;
                    r["PrinterType"] = comboPrinterType.SelectedItem.ToString();
                    r["ProcessType"] = comboProcessorType.SelectedItem.ToString();
                    #endregion


                    dbAccountingProjectDS.ARSystemSetup.Rows.Add(r);

                    dr.Close();
                    sqlcon.Close();
                }
            }

            this.ARSystemSetupTableAdapter.Update(this.dbAccountingProjectDS.ARSystemSetup);
            dbAccountingProjectDS.AcceptChanges();
            
           
            SaveNewBtn.Visible = false;
            btnedit.Visible = true;
            Btnsaveedit.Visible = false;
            tab3groupBox.Enabled = false;
            Tab2groupBox.Enabled = false;
            tab1groupBox.Enabled = false;
        }

        private void UndoBtn_Click(object sender, EventArgs e)
        {
            if (sender.ToString() != "NO")
            {
                if (tab1groupBox.Enabled == true)
                {
                    DialogResult myrst;
                    myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (myrst == DialogResult.No)
                        return;
                }
            }
            
            SaveNewBtn.Visible = false;
            btnedit.Visible = true;
            Btnsaveedit.Visible = false;
            tab3groupBox.Enabled = false;
            Tab2groupBox.Enabled = false;
            tab1groupBox.Enabled = false;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AccountSearch AccF = new AccountSearch();
            AccF.ShowDialog();
            this.txt_ARCode.Text = AccF.selectedAccountNumber;
            this.txt_GLAccount.Text = AccF.selectedAccountNumber;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            tab1groupBox.Enabled = true;
            Tab2groupBox.Enabled = true;
            tab3groupBox.Enabled = true;
            Btnsaveedit.Visible = true;
            Btnsaveedit.Enabled = true;
            btnedit.Visible = false;
            
        }

        private void Btnsaveedit_Click(object sender, EventArgs e)
        {
            if (txt_GLAccount.Text == "")
            {
                MessageBox.Show("Insert Account Number");
                return;
            }
            if (txt_AgingPeriodForth.Text == "" || txt_AgingPeriodThree.Text == "" || txt_AgingPeriodTow.Text == "" || txt_AgingPeriodOne.Text == "" || txt_DaysPeriodforth.Text == "" || txt_DaysPeriodThree.Text == "" || txt_DaysPeriodOne.Text == "" || txt_DaysPeriodTow.Text == "")
            {
                MessageBox.Show("Misssing Data !!!!!");
                return;
            }
            int ID = 1; int.TryParse(txtID.Text.Trim(), out ID);

            if (GeneralFunctions.FindRow("ARSetupID = '" + ID + "'", dbAccountingProjectDS.ARSystemSetup))
            {
                DataRow r = dbAccountingProjectDS.ARSystemSetup.FindByARSetupID(ID);

                r.BeginEdit();


                #region TabOneControls
                r["ARAccountNum"] = txt_GLAccount.Text;
                r["YearsToRetain"] = YearsToRetain.Value;
                r["MonthAllowed"] = MonthForArchieve.Value;
                r["DisplayOverCredit"] = chxOverCredit.Checked;
                r["DisplayConfirmation"] = chxConfirmation.Checked;
                r["RequireFirst"] = chxRequire.Checked;
                r["AccStatus"] = ComboStatus.SelectedIndex;
                r["AccCredit"] = txt_CreditLimit.Text;
                r["AnnualFinance"] = txt_Annual.Text;
                r["MinmumFinance"] = txt_MinmumFinance.Text;
                r["FinanceChargeDay"] = txt_FinanceCharge.Text;
                r["NightAuditCode"] = txt_nightAudit.Text;
                r["DefaultDocument"] = txt_DefaultDirectory.Text;
                r["FinanceTransCode"] = Combo_Transaction.SelectedValue.ToString();
                r["CompoundFinance"] = chxCompound.Checked;

                #endregion

                #region Tab2Controls
                r["PrintTax"] = chxPrintTax.Checked;
                r["PrintInfo"] = chxPrintInformation.Checked;
                r["AutoInvoices"] = chxAutomaticInvoices.Checked;
                r["EmailInvoices"] = chxEmailInvoices.Checked;
                r["PrintStatement"] = chxPrintStat.Checked;
                r["ShowTransBill"] = chxShowAllTrans.Checked;
                r["DisplayOriginalCharge"] = chxDisplayOriginal.Checked;
                r["ImportCreditCard"] = chxImportCard.Checked;
                r["UseARTax"] = chxUseAR.Checked;
                r["UseInvoiceDate"] = chxUseInvoicesDate.Checked;
                r["AgeCredits"] = chx_AgeCredits.Checked;

                r["DAgingFive"] = txt_AgingPeriodFifth.Text;
                r["DAgingFour"] = txt_AgingPeriodForth.Text;
                r["DAgingThree"] = txt_AgingPeriodThree.Text;
                r["DAgingTOW"] = txt_AgingPeriodTow.Text;
                r["DAgingONE"] = txt_AgingPeriodOne.Text;
                r["DPeriodFive"] = txt_DaysPeriodFifth.Text;
                r["DPeriodFour"] = txt_DaysPeriodforth.Text;
                r["DPeriodThree"] = txt_DaysPeriodThree.Text;
                r["DPeriodTow"] = txt_DaysPeriodTow.Text;
                r["DPeriodONE"] = txt_DaysPeriodOne.Text;
                r["FinanceDesc"] = txt_FinanceDesc.Text;
                r["BalanceDesc"] = txt_BalanceDesc.Text;

                r["StatementAccount"] = ComboStatement.SelectedValue.ToString();
                r["BalanceForword"] = radio_BalanceForword.Checked;
                r["OpenItem"] = radio_OpenItem.Checked;
                #endregion

                #region Tab3Controls
                r["ServerStp"] = txt_SMTP.Text;
                r["EmailAdd"] = txt_EmailAdd.Text;

                r["AuthentLog"] = txt_AuthLogin.Text;
                r["AuthentPass"] = txt_Password.Text;
                r["ARCodeForInvalid"] = txt_ARCode.Text;
                r["TerminalID"] = txtTerminalID.Text;
                r["UseAuthent"] = chxAuthentication.Checked;
                r["AutoPost"] = chxAutoPost.Checked;
                r["CreditProcessing"] = chxCreditProcessing.Checked;
                r["CreditTracking"] = chxCreditTracking.Checked;
                r["CreditPrinting"] = chxUseCreditPrinting.Checked;
                r["DontStore"] = chxDontStore.Checked;
                r["TimeShare"] = chxTimeShare.Checked;
                r["HotelIndust"] = radioHotel.Checked;
                r["DirectMarket"] = radioMarketing.Checked;
                r["PrinterType"] = comboPrinterType.SelectedItem.ToString();
                r["ProcessType"] = comboProcessorType.SelectedItem.ToString();
                #endregion

                r.EndEdit();
                this.ARSystemSetupTableAdapter.Update(this.dbAccountingProjectDS.ARSystemSetup);
            }



            this.ARSystemSetupTableAdapter.Update(this.dbAccountingProjectDS.ARSystemSetup);
            dbAccountingProjectDS.AcceptChanges();

            
            SaveNewBtn.Visible = false;
            btnedit.Visible = true;
            Btnsaveedit.Visible = false;
            tab3groupBox.Enabled = false;
            Tab2groupBox.Enabled = false;
            tab1groupBox.Enabled = false;

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            AccountSearch AccF = new AccountSearch();
            AccF.ShowDialog();
            this.txt_ARCode.Text = AccF.selectedAccountNumber;
            this.txt_GLAccount.Text = AccF.selectedAccountNumber;
        }

        private void ARSystemControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralFunctions.UnLockTable("", "ARSystemControl", "", "");
        }
    }
}