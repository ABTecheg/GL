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
    public partial class BankAccountMaintenance : Form
    {
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbCurrency;
        private SqlDataAdapter adaptertbAccounts;
        private SqlDataAdapter adaptertbBankAccounts;
        private SqlDataAdapter adaptertbCashFlowCategory;
        private SqlCommandBuilder cmdBuilder;
        private int currentBankID;
        private string bankAccountNumber,GLbankAccountNumber, serviceAccountNumber;
        private double interestEarned;

        public BankAccountMaintenance()
        {
            InitializeComponent();
        }

        private void BankAccountMaintenance_Load(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts", sqlcon);
            adaptertbCurrency = new SqlDataAdapter("Select * from GLCurrency", sqlcon);
            adaptertbCashFlowCategory = new SqlDataAdapter("Select * from ARCashFlowCategory", sqlcon);
            adaptertbBankAccounts = new SqlDataAdapter("Select * from ARBankAccounts",sqlcon);

            cmdBuilder = new SqlCommandBuilder(adaptertbBankAccounts);

            adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
            adaptertbCashFlowCategory.Fill(dbAccountingProjectDS.ARCashFlowCategory);
            adaptertbCurrency.Fill(dbAccountingProjectDS.GLCurrency);
            adaptertbBankAccounts.Fill(dbAccountingProjectDS.ARBankAccounts);

            cb_Currency = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLCurrency, cb_Currency, "CurrencyCode","CurrencyNumber");
            cb_CashFlowCategory = GeneralFunctions.FillComboBox(dbAccountingProjectDS.ARCashFlowCategory, cb_CashFlowCategory, "CashFlowCategoryCode","CashFlowCategoryID");

            currentBankID = GeneralFunctions.BankID;
            txt_BankId.Text = currentBankID.ToString();
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            txt_BankId.Text = currentBankID.ToString();
            txt_BankCode.Text = "";
            txt_BankAccountNumber.Text = "";
            txt_BankAccountDescription.Text = "";
            cb_Currency.SelectedIndex = -1;
            txt_ServiceAccountNumber.Text = "";
            txt_InterestEarned.Text = "";
            txt_BankAccount.Text = "";
            cb_CashFlowCategory.SelectedIndex = -1;
            checkBox_Active.Checked = false;
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
            }
        }

        private void cb_CashFlowCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_CashFlowCategory.Text == "<new>")
            {
                CashFlowCategories cashCategories = new CashFlowCategories();
                cashCategories.ShowDialog();
                cb_CashFlowCategory.Items.Clear();
                adaptertbCashFlowCategory.Fill(dbAccountingProjectDS.ARCashFlowCategory);
                cb_CashFlowCategory = GeneralFunctions.FillComboBox(dbAccountingProjectDS.ARCashFlowCategory, cb_CashFlowCategory, "CashFlowCategoryCode", "CashFlowCategoryID");
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            GeneralFunctions.SearchForAccountNumber(txt_BankAccountNumber);
        }

        private void btn_SearchAccount_Click(object sender, EventArgs e)
        {
            GeneralFunctions.SearchForAccountNumber(txt_ServiceAccountNumber);
        }

        private void btn_SaveChanges_Click(object sender, EventArgs e)
        {
            adaptertbBankAccounts.Update(dbAccountingProjectDS.ARBankAccounts);
            dbAccountingProjectDS.AcceptChanges();
        }

        private bool ValidateInput()
        {
            if (!GeneralFunctions.AccountNumberValidate(txt_BankAccountNumber.Text, out GLbankAccountNumber) ||
                !GeneralFunctions.AccountNumberValidate(txt_BankAccount.Text, out bankAccountNumber) ||
               !GeneralFunctions.ValidateString(txt_BankCode.Text, "Please Specify the Bank Code") ||
               !GeneralFunctions.ValidateComboBox(cb_Currency,"Please Specify the Bank Currency"))
                return false;
            if (txt_ServiceAccountNumber.Text != "")
            {
                if (!GeneralFunctions.AccountNumberValidate(txt_ServiceAccountNumber.Text, out serviceAccountNumber))
                    return false;
            }
            if (txt_BankAccountDescription.Text != "")
            {
                if (!GeneralFunctions.ValidateSpacedString(txt_BankAccountDescription.Text,"Please Specify the Bank Account Description"))
                    return false;
            }
            if (txt_InterestEarned.Text != "")
            {
                if (!GeneralFunctions.ValidateDouble(txt_InterestEarned.Text, "Please Specify the Bank earned interest",out interestEarned))
                    return false;
            }
            return true;
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select BankID from ARBankAccounts where BankID = '" + txt_BankId.Text + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("BankID = '" + txt_BankId.Text + "'", dbAccountingProjectDS.ARBankAccounts))
                {
                    DataRow r = dbAccountingProjectDS.ARBankAccounts.NewRow();
                    r["BankID"] = currentBankID;
                    GeneralFunctions.BankID++;
                    currentBankID = GeneralFunctions.BankID;
                    r["BankCode"] = txt_BankCode.Text;
                    r["BankAccount"] = bankAccountNumber;
                    r["BankGLAccountNumber"] = GLbankAccountNumber;
                    r["BankAccountDescription"] = txt_BankAccountDescription.Text;
                    r["BankCurrency"] = cb_Currency.Text;
                    r["ServiceAccountNumber"] = serviceAccountNumber;
                    r["InterestEarned"] = interestEarned;
                    r["CashFlowCategoryCode"] = cb_CashFlowCategory.Text;
                    if (checkBox_Active.Checked)
                        r["Active"] = 1;
                    else
                        r["Active"] = 0;
                    dbAccountingProjectDS.ARBankAccounts.Rows.Add(r);
                    MessageBox.Show("Bank Account inserted successfully");
                    ClearAll();
                    dr.Close();
                    sqlcon.Close();
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Bank Code is already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.ARBankAccounts.Select("BankID = '" + txt_BankId.Text + "'");
                        rArr[0]["BankCode"] = txt_BankCode.Text;
                        rArr[0]["BankAccount"] = bankAccountNumber;
                        rArr[0]["BankGLAccountNumber"] = GLbankAccountNumber;
                        rArr[0]["BankAccountDescription"] = txt_BankAccountDescription.Text;
                        rArr[0]["BankCurrency"] = cb_Currency.Text;
                        rArr[0]["ServiceAccountNumber"] = serviceAccountNumber;
                        rArr[0]["InterestEarned"] = interestEarned;
                        rArr[0]["CashFlowCategoryCode"] = cb_CashFlowCategory.Text;
                        if (checkBox_Active.Checked)
                            rArr[0]["Active"] = 1;
                        else
                            rArr[0]["Active"] = 0;
                        MessageBox.Show("Bank Account edited successfully");
                        ClearAll();
                    }
                    else
                    {
                        ClearAll();
                    }
                    dr.Close();
                    sqlcon.Close();
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (ValidateInput())
                {
                    DataRow[] rArr = dbAccountingProjectDS.ARBankAccounts.Select("BankID = '" + txt_BankId.Text + "'");
                    rArr[0]["BankCode"] = txt_BankCode.Text;
                    rArr[0]["BankAccount"] = bankAccountNumber;
                    rArr[0]["BankGLAccountNumber"] = GLbankAccountNumber;
                    rArr[0]["BankAccountDescription"] = txt_BankAccountDescription.Text;
                    rArr[0]["BankCurrency"] = cb_Currency.Text;
                    rArr[0]["ServiceAccountNumber"] = serviceAccountNumber;
                    rArr[0]["InterestEarned"] = interestEarned;
                    rArr[0]["CashFlowCategoryCode"] = cb_CashFlowCategory.Text;
                    if (checkBox_Active.Checked)
                        rArr[0]["Active"] = 1;
                    else
                        rArr[0]["Active"] = 0;
                    MessageBox.Show("Bank Account edited successfully");
                    ClearAll();
                }
            }
            else
            {
                MessageBox.Show("Please Select the row that you want to edit");
            }
            dgv.ClearSelection();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                dbAccountingProjectDS.ARBankAccounts.Rows[dgv.SelectedRows[0].Index].Delete();
                MessageBox.Show("Bank Account deleted successfully");
                ClearAll();
            }
            else
            {
                if (txt_BankId.Text != "")
                {
                    DataRow[] rArr = dbAccountingProjectDS.ARBankAccounts.Select("BankID = '" + txt_BankId.Text + "'");
                    if (rArr.Length != 0)
                    {
                        rArr[0].Delete();
                        MessageBox.Show("Bank Account deleted successfully");
                        ClearAll();
                    }
                    else
                    {
                        MessageBox.Show("The given Bank Account ID doesnt exist \n Cant perform delete operation");
                    }
                }
            }
            dgv.ClearSelection();
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataRow r = dbAccountingProjectDS.ARBankAccounts.Rows[dgv.SelectedRows[0].Index];
                txt_BankId.Text = r["BankID"].ToString();
                txt_BankAccount.Text = r["BankAccount"].ToString();
                txt_BankCode.Text = r["BankCode"].ToString();
                txt_BankAccountNumber.Text = r["BankGLAccountNumber"].ToString();
                txt_BankAccountDescription.Text = r["BankAccountDescription"].ToString();
                cb_Currency.Text = r["BankCurrency"].ToString();
                txt_ServiceAccountNumber.Text = r["ServiceAccountNumber"].ToString();
                txt_InterestEarned.Text = r["InterestEarned"].ToString();
                cb_CashFlowCategory.Text = r["CashFlowCategoryCode"].ToString();
                if (r["Active"].ToString() == "True")
                    checkBox_Active.Checked = true;
                else
                    checkBox_Active.Checked = false;
            }
        }

        private void btn_SearchForAccount_Click(object sender, EventArgs e)
        {
            GeneralFunctions.SearchForAccountNumber(txt_BankAccount);
        }

        private void BankAccountMaintenance_Load_1(object sender, EventArgs e)
        {

        }
    }
}