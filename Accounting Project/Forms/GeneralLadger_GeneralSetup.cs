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
    public partial class GeneralLadger_GeneralSetup : Form
    {
        public GeneralLadger_GeneralSetup()
        {
            InitializeComponent();
        }
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbGeneralSetup;
        private SqlDataAdapter adaptertbG_L_GeneralSetup;
        private SqlDataAdapter adaptertbGLJournalCodes;
        private SqlDataAdapter adaptertbAccounts;
        private SqlCommandBuilder cmdBuilderaG_L_GeneralSetup;
        private dbAccountingProjectDS dbAccountingProjectDS1;
        DataRow[] drs;
        private void GeneralLadger_GeneralSetup_Load(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            dbAccountingProjectDS1 = new dbAccountingProjectDS();
            adaptertbG_L_GeneralSetup = new SqlDataAdapter("Select * from G_L_GeneralSetup", sqlcon);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbGLJournalCodes = new SqlDataAdapter("Select * from GLJournalCodes", sqlcon);
            adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts", sqlcon);
            cmdBuilderaG_L_GeneralSetup = new SqlCommandBuilder(adaptertbG_L_GeneralSetup);
            adaptertbAccounts.Fill(dbAccountingProjectDS1.GLAccounts);
            adaptertbG_L_GeneralSetup.Fill(dbAccountingProjectDS1.G_L_GeneralSetup);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS1.GeneralSetup);
            adaptertbGLJournalCodes.Fill(dbAccountingProjectDS1.GLJournalCodes);
            foreach (DataRow dr in dbAccountingProjectDS1.GeneralSetup.Rows)
            {
                txtbalanceSheet.Mask = dr["AccountNumberFormat"].ToString();
                txtIncome.Mask = dr["AccountNumberFormat"].ToString();
                txtRetained.Mask = dr["AccountNumberFormat"].ToString();
            }
            cb_BankDepost = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_BankDepost, "JournalCode", "JournalCodeID");
            cb_Payable = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Payable, "JournalCode", "JournalCodeID");
            cb_payroll = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_payroll, "JournalCode", "JournalCodeID");
            cb_Receivable = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Receivable, "JournalCode", "JournalCodeID");
            cb_Tran_Cashier = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Tran_Cashier, "JournalCode", "JournalCodeID");
            cb_Systeminterface = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Systeminterface, "JournalCode", "JournalCodeID");
            drs = dbAccountingProjectDS1.G_L_GeneralSetup.Select();
            if (drs.Length != 0)
            {
                cb_BankDepost.Text = drs[0]["BankDepost"].ToString();
                cb_Payable.Text = drs[0]["Accounts_Payable"].ToString();
                cb_payroll.Text = drs[0]["PayRoll"].ToString();
                cb_Receivable.Text = drs[0]["Accounts_Receivable"].ToString();
                cb_Systeminterface.Text = drs[0]["SystemInterface"].ToString();
                txtRetained.Text = drs[0]["RetainedEarnings"].ToString();
                txtIncome.Text = drs[0]["IncomeStatment"].ToString();
                txtbalanceSheet.Text = drs[0]["BalanceSheet"].ToString();
                cb_Receivable.Text = drs[0]["JNL_Tran_Cashier"].ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (btnedit.Visible == false)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            this.Close();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            string msg = GeneralFunctions.CheckLockTables("", "", "", "");
            if (msg != "")
            {
                MessageBox.Show("Can't Edit Because Other Form Open By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            GeneralFunctions.LockTables("All", "GeneralLadger_GeneralSetup", "", "");
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            btnedit.Visible = false;
            btnOk.Visible = true;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DataRow dr;
            DataRow[] drAC;
            drAC = dbAccountingProjectDS1.GLAccounts.Select("AccountNumber = '" + txtbalanceSheet.Text + "' AND AccountTypeName = 'Equity'");
            if (drAC.Length == 0)
            {
                MessageBox.Show("Check Balance Sheet Account Number", "General Ledger",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            drAC = dbAccountingProjectDS1.GLAccounts.Select("AccountNumber = '" + txtIncome.Text + "' AND AccountTypeName IN ('Liability','Revenue')");
            if (drAC.Length == 0)
            {
                MessageBox.Show("Check Income Statment Account Number", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            drAC = dbAccountingProjectDS1.GLAccounts.Select("AccountNumber = '" + txtRetained.Text + "' AND AccountTypeName = 'Equity'");
            if (drAC.Length == 0)
            {
                MessageBox.Show("Check Retained Earnings Account Number", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cb_Tran_Cashier.Text == "")
            {
                MessageBox.Show("Check JNL Transaction Cashier", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            drs = dbAccountingProjectDS1.G_L_GeneralSetup.Select();
            if (drs.Length != 0)
            {
                dr = drs[0];
                drs[0]["BankDepost"] = cb_BankDepost.Text;
                drs[0]["Accounts_Payable"] = cb_Payable.Text;
                drs[0]["PayRoll"] = cb_payroll.Text;
                drs[0]["Accounts_Receivable"] = cb_Receivable.Text;
                drs[0]["SystemInterface"] = cb_Systeminterface.Text;
                drs[0]["RetainedEarnings"] = txtRetained.Text;
                drs[0]["IncomeStatment"] = txtIncome.Text;
                drs[0]["BalanceSheet"] = txtbalanceSheet.Text;
                drs[0]["JNL_Tran_Cashier"] = cb_Tran_Cashier.Text;
            }
            else
            {
                dr = dbAccountingProjectDS1.G_L_GeneralSetup.NewRow();
                dr["BankDepost"] = cb_BankDepost.Text;
                dr["Accounts_Payable"] = cb_Payable.Text;
                dr["PayRoll"] = cb_payroll.Text;
                dr["Accounts_Receivable"] = cb_Receivable.Text;
                dr["SystemInterface"] = cb_Systeminterface.Text;
                dr["RetainedEarnings"] = txtRetained.Text;
                dr["IncomeStatment"] = txtIncome.Text;
                dr["BalanceSheet"] = txtbalanceSheet.Text;
                dr["JNL_Tran_Cashier"] = cb_Tran_Cashier.Text;
                dbAccountingProjectDS1.G_L_GeneralSetup.Rows.Add(dr);
            }
            adaptertbG_L_GeneralSetup.Update(dbAccountingProjectDS1.G_L_GeneralSetup);
            dbAccountingProjectDS1.AcceptChanges();
            MessageBox.Show("Setup Save successfully", "General Ledger");
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            btnedit.Visible = true;
            btnOk.Visible = false;
            GeneralFunctions.UnLockTable("", "GeneralLadger_GeneralSetup", "", "");


        }

        private void txtbalanceSheet_DoubleClick(object sender, EventArgs e)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.filter = " AND AccountTypeName = 'Equity'";
            accSearch.ShowDialog();
            if (accSearch.selectedAccountName != null)
            {
                txtbalanceSheet.Text = accSearch.selectedAccountNumber.ToString();
            }
        }

        private void txtIncome_DoubleClick(object sender, EventArgs e)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.filter = " AND AccountTypeName IN ('Liability','Revenue')";
            accSearch.ShowDialog();
            if (accSearch.selectedAccountName != null)
            {
                txtIncome.Text = accSearch.selectedAccountNumber.ToString();
            }

        }

        private void txtRetained_DoubleClick(object sender, EventArgs e)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.filter = " AND AccountTypeName = 'Equity'";
            accSearch.ShowDialog();
            if (accSearch.selectedAccountName != null)
            {
                txtRetained.Text = accSearch.selectedAccountNumber.ToString();
            }
        }

        private void GeneralLadger_GeneralSetup_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralFunctions.UnLockTable("", "GeneralLadger_GeneralSetup", "", "");
        }

        private void cb_Receivable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Receivable.Text == "<new>")
            {
                GLJournalCodes jc = new GLJournalCodes();
                jc.ShowDialog();
                cb_BankDepost.Items.Clear();
                cb_Payable.Items.Clear();
                cb_payroll.Items.Clear();
                cb_Receivable.Items.Clear();
                cb_Systeminterface.Items.Clear();
                adaptertbGLJournalCodes.Fill(dbAccountingProjectDS1.GLJournalCodes);
                cb_BankDepost = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_BankDepost, "JournalCode", "JournalCodeID");
                cb_Payable = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Payable, "JournalCode", "JournalCodeID");
                cb_payroll = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_payroll, "JournalCode", "JournalCodeID");
                cb_Receivable = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Receivable, "JournalCode", "JournalCodeID");
                cb_Systeminterface = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Systeminterface, "JournalCode", "JournalCodeID");
                cb_Tran_Cashier = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Tran_Cashier, "JournalCode", "JournalCodeID");
            }

        }

        private void cb_Payable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Payable.Text == "<new>")
            {
                GLJournalCodes jc = new GLJournalCodes();
                jc.ShowDialog();
                cb_BankDepost.Items.Clear();
                cb_Payable.Items.Clear();
                cb_payroll.Items.Clear();
                cb_Receivable.Items.Clear();
                cb_Systeminterface.Items.Clear();
                adaptertbGLJournalCodes.Fill(dbAccountingProjectDS1.GLJournalCodes);
                cb_BankDepost = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_BankDepost, "JournalCode", "JournalCodeID");
                cb_Payable = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Payable, "JournalCode", "JournalCodeID");
                cb_payroll = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_payroll, "JournalCode", "JournalCodeID");
                cb_Receivable = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Receivable, "JournalCode", "JournalCodeID");
                cb_Systeminterface = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Systeminterface, "JournalCode", "JournalCodeID");
                cb_Tran_Cashier = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Tran_Cashier, "JournalCode", "JournalCodeID");
            }

        }

        private void cb_Systeminterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Systeminterface.Text == "<new>")
            {
                GLJournalCodes jc = new GLJournalCodes();
                jc.ShowDialog();
                cb_BankDepost.Items.Clear();
                cb_Payable.Items.Clear();
                cb_payroll.Items.Clear();
                cb_Receivable.Items.Clear();
                cb_Systeminterface.Items.Clear();
                adaptertbGLJournalCodes.Fill(dbAccountingProjectDS1.GLJournalCodes);
                cb_BankDepost = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_BankDepost, "JournalCode", "JournalCodeID");
                cb_Payable = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Payable, "JournalCode", "JournalCodeID");
                cb_payroll = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_payroll, "JournalCode", "JournalCodeID");
                cb_Receivable = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Receivable, "JournalCode", "JournalCodeID");
                cb_Systeminterface = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Systeminterface, "JournalCode", "JournalCodeID");
                cb_Tran_Cashier = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Tran_Cashier, "JournalCode", "JournalCodeID");
            }

        }

        private void cb_BankDepost_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_BankDepost.Text == "<new>")
            {
                GLJournalCodes jc = new GLJournalCodes();
                jc.ShowDialog();
                cb_BankDepost.Items.Clear();
                cb_Payable.Items.Clear();
                cb_payroll.Items.Clear();
                cb_Receivable.Items.Clear();
                cb_Systeminterface.Items.Clear();
                adaptertbGLJournalCodes.Fill(dbAccountingProjectDS1.GLJournalCodes);
                cb_BankDepost = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_BankDepost, "JournalCode", "JournalCodeID");
                cb_Payable = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Payable, "JournalCode", "JournalCodeID");
                cb_payroll = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_payroll, "JournalCode", "JournalCodeID");
                cb_Receivable = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Receivable, "JournalCode", "JournalCodeID");
                cb_Systeminterface = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Systeminterface, "JournalCode", "JournalCodeID");
                cb_Tran_Cashier = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Tran_Cashier, "JournalCode", "JournalCodeID");
            }

        }

        private void cb_payroll_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_payroll.Text == "<new>")
            {
                GLJournalCodes jc = new GLJournalCodes();
                jc.ShowDialog();
                cb_BankDepost.Items.Clear();
                cb_Payable.Items.Clear();
                cb_payroll.Items.Clear();
                cb_Receivable.Items.Clear();
                cb_Systeminterface.Items.Clear();
                adaptertbGLJournalCodes.Fill(dbAccountingProjectDS1.GLJournalCodes);
                cb_BankDepost = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_BankDepost, "JournalCode", "JournalCodeID");
                cb_Payable = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Payable, "JournalCode", "JournalCodeID");
                cb_payroll = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_payroll, "JournalCode", "JournalCodeID");
                cb_Receivable = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Receivable, "JournalCode", "JournalCodeID");
                cb_Systeminterface = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Systeminterface, "JournalCode", "JournalCodeID");
                cb_Tran_Cashier = GeneralFunctions.FillComboBox(dbAccountingProjectDS1.GLJournalCodes, cb_Tran_Cashier, "JournalCode", "JournalCodeID");
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtIncome_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtRetained_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}