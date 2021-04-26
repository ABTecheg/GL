using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace Accounting_GeneralLedger
{
    public partial class AccountSearch : Form
    {
        public string selectedAccountNumber;
        public string selectedAccountName;
        public string selectedAccountType;
        public DataTable selectedAccountsTable;
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbAccounts;
        private SqlDataAdapter adaptertbAccountTypes;
        private SqlCommandBuilder cmdBuilderGeneralSetup;
        private SqlDataAdapter adaptertbGeneralSetup;
        private string AccountNumberFormat;

        private string currentAccountNumber = "";
        public string filter = "";

        public AccountSearch()
        {
            InitializeComponent();
        }

        private void SearchForGivenAccountNumber()
        {
            try
            {
                if (txt_AccountNumber1.Text == "" && txt_AccountName.Text == "" && cb_AccountType.SelectedIndex <= 0)
                    GridRefresh();
                else if (txt_AccountNumber1.Text != "")
                {
                    currentAccountNumber = txt_AccountNumber1.Text.ToString();
                    DataTable dv = new DataTable();
                    adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts where AccountTypeName <> '' " + CreateFilterExpression() + filter, sqlcon);
                    adaptertbAccounts.Fill(dv);
                    dgv.DataSource = dv;
                    dgv.Refresh();
                }
                else if (cb_AccountType.Text != "")
                {
                    DataView dv = new DataView(dbAccountingProjectDS.GLAccounts);
                    dv.RowFilter = CreateFilterExpression();
                    dgv.DataSource = dv;
                    dgv.Refresh();
                }
                else if (txt_AccountName.Text != "")
                {
                    DataView dv = new DataView(dbAccountingProjectDS.GLAccounts);
                    dv.RowFilter = CreateFilterExpression();
                    dgv.DataSource = dv;
                    dgv.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void AccountSearch_Load(object sender, EventArgs e)
        {
            try
            {
                if (GeneralFunctions.Ckecktag("18") != "M")
                    btn_Add.Visible = false;

                sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
                //if (GeneralFunctions.Header == "")
                adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts where AccountTypeName <> '' " + filter, sqlcon);
                //else if (GeneralFunctions.Header == "AR")
                //    adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts where AccountTypeName <> 'Header' AND AccountTypeName <> 'Statictical'", sqlcon);
                //else if (GeneralFunctions.Header == "Yes")
                //    adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts where AccountTypeName <> 'Header'", sqlcon);
                adaptertbAccountTypes = new SqlDataAdapter("Select * from GLAccountTypes where AccountTypeName <> '' " + filter, sqlcon);
                adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
                cmdBuilderGeneralSetup = new SqlCommandBuilder(adaptertbGeneralSetup);
                adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);

                adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
                adaptertbAccountTypes.Fill(dbAccountingProjectDS.GLAccountTypes);

                if (!GeneralFunctions.SubTypesloaded)
                {
                    SqlConnection sqlcon10 = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlcon10.Open();
                    SqlCommand command10 = new SqlCommand("Select AccountSubType From  GeneralSetup", sqlcon10);
                    SqlCommand command11 = new SqlCommand("Select FirstSub From GeneralSetup", sqlcon10);
                    SqlCommand command12 = new SqlCommand("Select SecondSub From GeneralSetup", sqlcon10);
                    SqlCommand command13 = new SqlCommand("Select ThirdSub From GeneralSetup", sqlcon10);
                    SqlCommand command14 = new SqlCommand("Select FourthSub From GeneralSetup", sqlcon10);
                    int AccountSubTypeNumber;
                    if (command10.ExecuteScalar() != DBNull.Value)
                    {
                        AccountSubTypeNumber = Convert.ToInt32(command10.ExecuteScalar());
                        if (AccountSubTypeNumber == 2)
                        {
                            GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()), Convert.ToInt32(command12.ExecuteScalar()));
                            GeneralFunctions.SubTypesloaded = true;
                        }
                        if (AccountSubTypeNumber == 3)
                        {
                            GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()), Convert.ToInt32(command12.ExecuteScalar()), Convert.ToInt32(command13.ExecuteScalar()));
                            GeneralFunctions.SubTypesloaded = true;
                        }
                        if (AccountSubTypeNumber == 4)
                        {
                            GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()), Convert.ToInt32(command12.ExecuteScalar()), Convert.ToInt32(command13.ExecuteScalar()), Convert.ToInt32(command14.ExecuteScalar()));
                            GeneralFunctions.SubTypesloaded = true;
                        }

                    }
                }
                //foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
                //{
                //    AccountNumberFormat = dr["AccountNumberFormat"].ToString();
                //}
                //txt_AccountNumber1.Mask = AccountNumberFormat;
                //txt_AccountNumber.Mask = AccountNumberFormat;// "###-####-##";
                cb_AccountType = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLAccountTypes, cb_AccountType, "AccountTypeName", "AccountTypeID");
                cb_AccountType.Items.Insert(0, "Any Type");
                //if (GeneralFunctions.Header == "Yes")
                //    cb_AccountType.Items.Remove("Header");
                //if (GeneralFunctions.Header == "AR")
                //{
                //    cb_AccountType.Items.Remove("Header");
                //    cb_AccountType.Items.Remove("Statictical");
                //}
                cb_AccountType.Items.Remove("<new>");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void txt_AccountNumber_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                {
                    string modifiedAccountNumber = "";
                    for (int i = 0; i < txt_AccountNumber1.Text.Length - 1; i++)
                        modifiedAccountNumber += txt_AccountNumber1.Text[i];
                    currentAccountNumber = GeneralFunctions.ApplyAccountFormat(modifiedAccountNumber);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void checkBox_Active_CheckedChanged(object sender, EventArgs e)
        {
            SearchForGivenAccountNumber();
        }

        private void cb_AccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SearchForGivenAccountNumber();
                if (cb_AccountType.Text == "<new>")
                {
                    AccountTypes at = new AccountTypes();
                    at.ShowDialog();
                    cb_AccountType.Items.Clear();
                    adaptertbAccountTypes.Fill(dbAccountingProjectDS.GLAccountTypes);
                    cb_AccountType = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLAccountTypes, cb_AccountType, "AccountTypeName", "AccountTypeID");
                }
                if (cb_AccountType.Text == "Any Type")
                {
                    cb_AccountType.SelectedIndex = 0;
                    SearchForGivenAccountNumber();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private string CreateFilterExpression()
        {
            string filterExpression = "";
            //Account Number Only 
            if (currentAccountNumber != "" && txt_AccountName.Text == "" && cb_AccountType.SelectedIndex == 0)
                filterExpression = " AND (AccountNumber like '" + currentAccountNumber + "%')";
            //Account Type Only 
            else if (currentAccountNumber == "" && txt_AccountName.Text == "" && cb_AccountType.SelectedIndex > 0)
                if (cb_AccountType.Text == "Any Type")
                    filterExpression = "";
                else
                    filterExpression = " AND (AccountTypeName = '" + cb_AccountType.Text + "')";
            //Account Name Only 
            else if (currentAccountNumber == "" && txt_AccountName.Text != "" && cb_AccountType.SelectedIndex == 0)
                filterExpression = " AND (AccountName like '%" + txt_AccountName.Text + "%')";
            //Account Number and Name 
            else if (currentAccountNumber != "" && txt_AccountName.Text != "" && cb_AccountType.SelectedIndex == 0)
                filterExpression = " AND (AccountNumber like '" + currentAccountNumber + "' And AccountName like '%" + txt_AccountName.Text + "%' )";
            //Account Number and Type 
            else if (currentAccountNumber != "" && txt_AccountName.Text == "" && cb_AccountType.SelectedIndex >= 0)
                filterExpression = " AND (AccountNumber like '" + currentAccountNumber + "' And AccountTypeName = '" + cb_AccountType.Text + "' )";
            //Account Name and Type 
            else if (currentAccountNumber == "" && txt_AccountName.Text != "" && cb_AccountType.SelectedIndex >= 0)
                filterExpression = " AND (AccountTypeName = '" + cb_AccountType.Text + "' And AccountName like '%" + txt_AccountName.Text + "%')";
            //All 
            else if (currentAccountNumber != "" && txt_AccountName.Text != "" && cb_AccountType.SelectedIndex >= 0)
                filterExpression = " AND (AccountNumber like '" + currentAccountNumber + "' And AccountTypeName = '" + cb_AccountType.Text + "'and AccountName like '%" + txt_AccountName.Text + "%' )";
            //Check checkbox value
            if (!checkBox_Active.Checked)
                filterExpression += " AND Active =1";
            return filterExpression;
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                AccountsDefinition accountAdd = new AccountsDefinition();
                accountAdd.ShowDialog();
                GridRefresh();
                SearchForGivenAccountNumber();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void GridRefresh()
        {
            adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
            dgv.DataSource = dbAccountingProjectDS.GLAccounts;
            dgv.Refresh();
        }

        private void txt_AccountName_TextChanged(object sender, EventArgs e)
        {
            SearchForGivenAccountNumber();
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    DataGridViewRow r = (DataGridViewRow)dgv.SelectedRows[0];
                    selectedAccountNumber = r.Cells["AccountNumberCol"].Value.ToString();
                    selectedAccountName = r.Cells["AccountNameCol"].Value.ToString();
                    selectedAccountType = r.Cells["ColAccountTypeName"].Value.ToString();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void btn_SelectCurrentRecord_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr;
                DataTable dt = new DataTable();
                dt.Columns.Add("AccountNumber", System.Type.GetType("System.String"));
                dt.Columns.Add("AccountName", System.Type.GetType("System.String"));
                dt.Columns.Add("AccountTypeName", System.Type.GetType("System.String"));
                dt.Columns.Add("Active", System.Type.GetType("System.Boolean"));
                dt.Columns.Add("OpeningBalance", System.Type.GetType("System.Double"));
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dr = dt.NewRow();
                    dr["AccountNumber"] = dgv.Rows[i].Cells["AccountNumberCol"].Value;
                    dr["AccountName"] = dgv.Rows[i].Cells["AccountNameCol"].Value;
                    dr["AccountTypeName"] = dgv.Rows[i].Cells["ColAccountTypeName"].Value;
                    dr["Active"] = dgv.Rows[i].Cells["activeDataGridViewCheckBoxColumn"].Value;
                    dr["OpeningBalance"] = dgv.Rows[i].Cells["openingBalanceDataGridViewTextBoxColumn"].Value;
                    dt.Rows.Add(dr);
                }
                selectedAccountsTable = dt;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void txt_AccountNumber1_TextChanged(object sender, EventArgs e)
        {
            SearchForGivenAccountNumber();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}