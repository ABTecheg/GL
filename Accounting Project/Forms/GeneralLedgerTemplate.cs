    using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Accounting_GeneralLedger
{
    public partial class GeneralLedgerTemplate : Form
    {
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbGLJournalCodes;
        private SqlDataAdapter adaptertbTemplate;
        private SqlDataAdapter adaptertbAccounts;
        private SqlDataAdapter adaptertbTemplateAccounts;
        private SqlDataAdapter adaptertbCurrency;
        private SqlCommandBuilder cmdBuildertbTemplate;
        private SqlCommandBuilder cmdBuildertbTemplateAccounts;
        private DataTable dtTemplateAccounts;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private int currentTemplateID;
        private int currentRowIndex = 0;
        private string value;
        private double balance;
        private int unitsCount;

        public GeneralLedgerTemplate()
        {
            InitializeComponent();
        }

        private void GeneralLedgerTemplate_Load(object sender, EventArgs e)
        {
            dbAccountingProjectDS = new dbAccountingProjectDS();
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbTemplate = new SqlDataAdapter("Select * from GLTemplates", sqlcon);
            adaptertbGLJournalCodes = new SqlDataAdapter("Select * from GLJournalCodes", sqlcon);
            adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts", sqlcon);
            adaptertbTemplateAccounts = new SqlDataAdapter("Select * from GLTemplateAccounts", sqlcon);
            adaptertbCurrency = new SqlDataAdapter("Select * from GLCurrency", sqlcon);

            cmdBuildertbTemplate = new SqlCommandBuilder(adaptertbTemplate);
            cmdBuildertbTemplateAccounts = new SqlCommandBuilder(adaptertbTemplateAccounts);
           
            adaptertbGLJournalCodes.Fill(dbAccountingProjectDS.GLJournalCodes);
            adaptertbTemplate.Fill(dbAccountingProjectDS.GLTemplates);
            adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
            adaptertbTemplateAccounts.Fill(dbAccountingProjectDS.GLTemplateAccounts);
            adaptertbCurrency.Fill(dbAccountingProjectDS.GLCurrency);

            dtTemplateAccounts = new DataTable();
            dtTemplateAccounts.Columns.Add("AccountID", System.Type.GetType("System.Int32"));
            dtTemplateAccounts.Columns.Add("AccountNumber", System.Type.GetType("System.String"));
            dtTemplateAccounts.Columns.Add("AccountName", System.Type.GetType("System.String"));
            dtTemplateAccounts.Columns.Add("AccountTypeName", System.Type.GetType("System.String"));
            dtTemplateAccounts.Columns.Add("Reference", System.Type.GetType("System.String"));
            dtTemplateAccounts.Columns.Add("Debit", System.Type.GetType("System.Double"));
            dtTemplateAccounts.Columns.Add("Credit", System.Type.GetType("System.Double"));
            dtTemplateAccounts.Columns.Add("DebitCC", System.Type.GetType("System.Double"));
            dtTemplateAccounts.Columns.Add("CreditCC", System.Type.GetType("System.Double"));
            dtTemplateAccounts.Columns.Add("Units", System.Type.GetType("System.Int32"));
            dtTemplateAccounts.Columns.Add("TemplateCode", System.Type.GetType("System.String"));

            DataRow r = dtTemplateAccounts.NewRow();
            dtTemplateAccounts.Rows.Add(r);
            dgv.DataSource = dtTemplateAccounts;
            dgv.Columns["AccountID"].Visible = false;
            dgv.Columns["AccountTypeName"].Visible = false;
            dgv.Columns["TemplateCode"].Visible = false;
            dgv.Columns["DebitCC"].ReadOnly = true;
            dgv.Columns["CreditCC"].ReadOnly = true;

            DataGridViewComboBoxColumn dgvc = new DataGridViewComboBoxColumn();
            dgvc.HeaderText = "ProjectCode";
            dgvc.Name = "ProjectCode";
            dgvc.FlatStyle = FlatStyle.Popup;
            AddItems(dgvc);
            dgv.Columns.Add(dgvc);

            cb_JournalCode = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLJournalCodes, cb_JournalCode, "JournalCode","JournalCodeID");
            cb_Currency = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLCurrency, cb_Currency, "CurrencyCode", "CurrencyNumber");
            cb_Currency = GeneralFunctions.RemoveBaseCurrency(cb_Currency);

            value = "0.";
            for (int i = 0; i < GeneralFunctions.DecimalPointsNumber; i++)
            {
                value += "0";
            }
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
                if (command10.ExecuteScalar() != DBNull.Value) {
                    AccountSubTypeNumber = Convert.ToInt32(command10.ExecuteScalar());
                    if (AccountSubTypeNumber == 2) {
                        GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()), Convert.ToInt32(command12.ExecuteScalar()));
                        GeneralFunctions.SubTypesloaded = true;
                    }
                    if (AccountSubTypeNumber == 3) {
                        GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()), Convert.ToInt32(command12.ExecuteScalar()), Convert.ToInt32(command13.ExecuteScalar()));
                        GeneralFunctions.SubTypesloaded = true;
                    }
                    if (AccountSubTypeNumber == 4) {
                        GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()), Convert.ToInt32(command12.ExecuteScalar()), Convert.ToInt32(command13.ExecuteScalar()), Convert.ToInt32(command14.ExecuteScalar()));
                        GeneralFunctions.SubTypesloaded = true;
                    }

                }
            }
            currentTemplateID = GeneralFunctions.TemplateID;
            txt_TemplateID.Text = currentTemplateID.ToString();
        }

        private void AddItems(DataGridViewComboBoxColumn dgvc)
        {
            if (dbAccountingProjectDS.GLJournalCodes.Rows.Count != 0)
            {
                foreach (DataRow dr in dbAccountingProjectDS.GLJournalCodes.Rows)
                {
                    dgvc.Items.Add(dr["JournalCode"].ToString());
                }
            }
            else
            {
                MessageBox.Show("You havent inserted the Journal codes yet\n Please Insert the journal codes and Try again");
                this.Close();
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow r;
            if (GeneralFunctions.ValidateString(txt_TemplateCode.Text,"Please Specify a Template Code"))
            {
                DataRow[] rArr = this.dbAccountingProjectDS.GLTemplates.Select("TemplateCode = '" + txt_TemplateCode.Text + "'");
                if (rArr.Length != 0)
                {
                    txt_TemplateID.Text = rArr[0]["TemplateCodeID"].ToString();
                    txt_TemplateName.Text = rArr[0]["TemplateDescription"].ToString();
                    cb_JournalCode.Text = rArr[0]["JournalCode"].ToString();
                    if (((bool)rArr[0]["MultiCurrency"]))
                        cb_Currency.Text = rArr[0]["Currency"].ToString();

                    DataRow[] rArrResult = this.dbAccountingProjectDS.GLTemplateAccounts.Select("TemplateCode = '" + txt_TemplateCode.Text + "'");
                    if (rArrResult.Length != 0)
                    {
                        dtTemplateAccounts.Rows.RemoveAt(dtTemplateAccounts.Rows.Count - 1);
                        for (int i = 0; i < rArrResult.Length; i++)
                        {
                            r = dtTemplateAccounts.NewRow();
                            r["AccountID"] = rArrResult[i]["TemplateAccountID"];
                            r["AccountNumber"] = rArrResult[i]["TemplateAccountNumber"];
                            r["AccountName"] = rArrResult[i]["TemplateAccountName"];
                            r["Reference"] = rArrResult[i]["TemplateAccountReference"];
                            r["Debit"] = rArrResult[i]["TemplateAccountDebit"];
                            r["Credit"] = rArrResult[i]["TemplateAccountCredit"];
                            r["DebitCC"] = rArrResult[i]["TemplateAccountDebitCC"];
                            r["CreditCC"] = rArrResult[i]["TemplateAccountCreditCC"];
                            r["Units"] = rArrResult[i]["TemplateAccountUnits"];
                            r["TemplateCode"] = txt_TemplateCode.Text;
                            dtTemplateAccounts.Rows.Add(r);
                            dgv.Rows[i].Cells["ProjectCode"].Value = rArrResult[i]["TemplateAccountProjectCode"];
                            r.AcceptChanges();
                        }
                        r = dtTemplateAccounts.NewRow();
                        dtTemplateAccounts.Rows.Add(r);
                    }
                }
                else
                    MessageBox.Show("The given Template code couldnt be found");
            }
        }

        private bool TemplateAccountsValidate()
        {
            bool valid = true;
            DataRow[] rArr;
            DataRow r;
            string validAccountNumber;
            double debitvalue = 0,creditvalue = 0,currentvalue;
            for (int i = 0; i < dtTemplateAccounts.Rows.Count; i++)
            {
                r = dtTemplateAccounts.Rows[i];
                if (r.RowState != DataRowState.Deleted)
                {
                    if (r.Equals(dtTemplateAccounts.Rows[dtTemplateAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountNumber"].ToString() == "")
                        break;
                    if (r["AccountNumber"].ToString() != "")
                    {
                        if (!GeneralFunctions.AccountNumberValidate(r["AccountNumber"].ToString(), out validAccountNumber))
                        {
                            errorProvider1.SetError(dgv, "The given account number doesnt exist");
                            valid = false;
                        }
                        else
                        {
                            r["AccountNumber"] = validAccountNumber;
                            rArr = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + validAccountNumber + "'");
                            if (r["AccountName"].ToString() != "")
                            {
                                if (rArr.Length != 0)
                                {
                                    if (rArr[0]["AccountName"].ToString() != r["AccountName"].ToString())
                                        r["AccountName"] = (string)rArr[0]["AccountName"];
                                    else
                                    {
                                        errorProvider1.SetError(dgv, "");
                                    }
                                }
                            }
                            else
                                r["AccountName"] = (string)rArr[0]["AccountName"];
                            if (dgv.Rows[i].Cells["AccountTypeName"].Value.ToString().ToLower() == "header"
                                   || dgv.Rows[i].Cells["AccountTypeName"].Value.ToString().ToLower() == "statistical")
                            {
                                r["Debit"] = DBNull.Value;
                                r["Credit"] = DBNull.Value;
                            }
                            currentvalue = 0;
                            if (dgv.Rows[i].Cells["Debit"].Value.ToString() != "" &&
                                GeneralFunctions.ValidateDouble(dgv.Rows[i].Cells["Debit"].Value.ToString(), "Please Insert a valid debit value", out currentvalue))
                            {
                                debitvalue += currentvalue;
                            }
                            currentvalue = 0;
                            if (dgv.Rows[i].Cells["Credit"].Value.ToString() != "" &&
                                 GeneralFunctions.ValidateDouble(dgv.Rows[i].Cells["Credit"].Value.ToString(), "Please Insert a valid credit value", out currentvalue))
                            {
                                creditvalue += currentvalue;
                            }
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(dgv, "The account number cant be equal to null");
                        valid = false;
                    }
                }
            }
            if (debitvalue != creditvalue)
            {
                MessageBox.Show("The debit accounts arent equal to credit accounts");
                valid = false;
            }
            return valid;
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GeneralFunctions.ValidateString(txt_TemplateCode.Text,"Please Specify the template code")
                && GeneralFunctions.ValidateString(txt_TemplateName.Text, "Please Specify the template name")
                && GeneralFunctions.ValidateComboBox(cb_JournalCode, "Please Specify the appropriate Journal Code of the given Template Code")
                && TemplateAccountsValidate())
            {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select TemplateCodeID from GLTemplates where TemplateCodeID = '" + txt_TemplateID.Text + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("TemplateCodeID = '" + txt_TemplateID.Text + "'", dbAccountingProjectDS.GLTemplates))
                {
                    DataRow r = this.dbAccountingProjectDS.GLTemplates.NewRow();
                    r["TemplateCodeID"] = currentTemplateID;
                    GeneralFunctions.TemplateID++;
                    currentTemplateID = GeneralFunctions.TemplateID;
                    r["TemplateCode"] = txt_TemplateCode.Text;
                    r["TemplateDescription"] = txt_TemplateName.Text;
                    r["JournalCode"] = cb_JournalCode.Text;
                    if (checkBox_Currency.Checked)
                    {
                        r["MultiCurrency"] = 1;
                        r["JVCurrency"] = cb_Currency.Text;
                    }
                    dbAccountingProjectDS.GLTemplates.Rows.Add(r);
                    AddTemplateAccounts();
                    dr.Close();
                    sqlcon.Close();
                    MessageBox.Show("Template Record inserted successfully");
                    ClearAll();
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Template Code already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = this.dbAccountingProjectDS.GLTemplates.Select("TemplateCodeID = '" + txt_TemplateID.Text + "'");
                        rArr[0]["TemplateDescription"] = txt_TemplateName.Text;
                        rArr[0]["JournalCode"] = cb_JournalCode.Text;
                        if (checkBox_Currency.Checked)
                        {
                            rArr[0]["MultiCurrency"] = 1;
                            rArr[0]["JVCurrency"] = cb_Currency.Text;
                        }
                        EditTemplateAccount();
                        MessageBox.Show("Template Record edited successfully");
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

        private void AddTemplateAccounts()
        {
            DataRow r;
            for (int i = 0; i < dtTemplateAccounts.Rows.Count; i++)
            {
                r = dtTemplateAccounts.Rows[i];
                if (r.Equals(dtTemplateAccounts.Rows[dtTemplateAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountNumber"].ToString() == "" )
                    break;
                if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified)
                {
                    r = this.dbAccountingProjectDS.GLTemplateAccounts.NewRow();
                    if (dgv.Rows[i].Cells["AccountID"].Value.ToString() != "" && dgv.Rows[i].Cells["TemplateCode"].Value.ToString() == "")
                        r["TemplateAccountID"] = dgv.Rows[i].Cells["AccountID"].Value;
                    else
                    {
                        r["TemplateAccountID"] = GeneralFunctions.TemplateAccounts;
                        GeneralFunctions.TemplateAccounts++;
                    }
                    r["TemplateAccountNumber"] = dgv.Rows[i].Cells["AccountNumber"].Value;

                    if (dgv.Rows[i].Cells["AccountName"].Value.ToString() == "")
                        r["TemplateAccountName"] = dgv.Rows[i].Cells["AccountName"].EditedFormattedValue;
                    else
                        r["TemplateAccountName"] = dgv.Rows[i].Cells["AccountName"].Value;
                    r["TemplateAccountReference"] = dgv.Rows[i].Cells["Reference"].Value;

                    if (dgv.Rows[i].Cells["Debit"].Value.ToString() != "")
                        r["TemplateAccountDebit"] = dgv.Rows[i].Cells["Debit"].Value;
                    if (dgv.Rows[i].Cells["Credit"].Value.ToString() != "")
                        r["TemplateAccountCredit"] = dgv.Rows[i].Cells["Credit"].Value;

                    if (dgv.Rows[i].Cells["DebitCC"].Value.ToString() != "")
                        r["TemplateAccountDebitCC"] = dgv.Rows[i].Cells["DebitCC"].Value;
                    if (dgv.Rows[i].Cells["CreditCC"].Value.ToString() != "")
                        r["TemplateAccountCreditCC"] = dgv.Rows[i].Cells["CreditCC"].Value;

                    r["TemplateAccountUnits"] = dgv.Rows[i].Cells["Units"].Value;
                    r["TemplateAccountProjectCode"] = dgv.Rows[i].Cells["ProjectCode"].Value;
                    r["TemplateCode"] = txt_TemplateCode.Text;
                    dbAccountingProjectDS.GLTemplateAccounts.Rows.Add(r);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GeneralFunctions.ValidateString(txt_TemplateCode.Text, "Please Specify the template code")
              && GeneralFunctions.ValidateString(txt_TemplateName.Text, "Please Specify the template name")
              && GeneralFunctions.ValidateComboBox(cb_JournalCode, "Please Specify the appropriate Journal Code of the given Template Code")
              && TemplateAccountsValidate())
            {
                DataRow[] rArr = this.dbAccountingProjectDS.GLTemplates.Select("TemplateCodeID = '" + txt_TemplateID.Text + "'");
                if (rArr.Length != 0)
                {
                    rArr[0]["TemplateDescription"] = txt_TemplateName.Text;
                    rArr[0]["JournalCode"] = cb_JournalCode.Text;
                    if (checkBox_Currency.Checked)
                    {
                        rArr[0]["MultiCurrency"] = 1;
                        rArr[0]["JVCurrency"] = cb_Currency.Text;
                    }
                    EditTemplateAccount();
                    MessageBox.Show("Template Record edited successfully");
                    ClearAll();
                }
            }
            else
            {
                MessageBox.Show("The given Template Code doesnt exist \n Cant perform edit operation");
            }
        }

        private void EditTemplateAccount()
        {
            DataRow r;
            for (int i = 0; i < dtTemplateAccounts.Rows.Count; i++)
            {
                r = dtTemplateAccounts.Rows[i];
                if (r.Equals(dtTemplateAccounts.Rows[dtTemplateAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountNumber"].ToString() == "" )
                    break;
                if (r.RowState == DataRowState.Modified)
                {
                    DataRow[] rArr = this.dbAccountingProjectDS.GLTemplateAccounts.Select("TemplateAccountID = '" + dgv.Rows[i].Cells["AccountID"].Value + "'");
                    rArr[0]["TemplateAccountNumber"] = dgv.Rows[i].Cells["AccountNumber"].Value;
                    rArr[0]["TemplateAccountName"] = dgv.Rows[i].Cells["AccountName"].Value;
                    rArr[0]["TemplateAccountReference"] = dgv.Rows[i].Cells["Reference"].Value;

                    if (dgv.Rows[i].Cells["Debit"].Value.ToString() != "")
                        rArr[0]["TemplateAccountDebit"] = dgv.Rows[i].Cells["Debit"].Value;
                    if (dgv.Rows[i].Cells["Credit"].Value.ToString() != "")
                        rArr[0]["TemplateAccountCredit"] = dgv.Rows[i].Cells["Credit"].Value;

                    if (dgv.Rows[i].Cells["DebitCC"].Value.ToString() != "")
                        rArr[0]["TemplateAccountDebitCC"] = dgv.Rows[i].Cells["DebitCC"].Value;
                    if (dgv.Rows[i].Cells["CreditCC"].Value.ToString() != "")
                        rArr[0]["TemplateAccountCreditCC"] = dgv.Rows[i].Cells["CreditCC"].Value;

                    rArr[0]["TemplateAccountUnits"] = dgv.Rows[i].Cells["Units"].Value;
                    rArr[0]["TemplateAccountProjectCode"] = dgv.Rows[i].Cells["ProjectCode"].Value;
                    rArr[0]["TemplateCode"] = txt_TemplateCode.Text;
                }
                if (r.RowState == DataRowState.Added)
                {
                    r = this.dbAccountingProjectDS.GLTemplateAccounts.NewRow();
                    r["TemplateAccountNumber"] = dgv.Rows[i].Cells["AccountNumber"].Value;
                    if (dgv.Rows[i].Cells["AccountName"].Value.ToString() == "")
                        r["TemplateAccountName"] = dgv.Rows[i].Cells["AccountName"].EditedFormattedValue;
                    else
                        r["TemplateAccountName"] = dgv.Rows[i].Cells["AccountName"].Value;
                    r["TemplateAccountReference"] = dgv.Rows[i].Cells["Reference"].Value;

                    if (dgv.Rows[i].Cells["Debit"].Value.ToString() != "")
                        r["TemplateAccountDebit"] = dgv.Rows[i].Cells["Debit"].Value;
                    if (dgv.Rows[i].Cells["Credit"].Value.ToString() != "")
                        r["TemplateAccountCredit"] = dgv.Rows[i].Cells["Credit"].Value;

                    if (dgv.Rows[i].Cells["DebitCC"].Value.ToString() != "")
                        r["TemplateAccountDebitCC"] = dgv.Rows[i].Cells["DebitCC"].Value;
                    if (dgv.Rows[i].Cells["CreditCC"].Value.ToString() != "")
                        r["TemplateAccountCreditCC"] = dgv.Rows[i].Cells["CreditCC"].Value;

                    r["TemplateAccountUnits"] = dgv.Rows[i].Cells["Units"].Value;
                    r["TemplateAccountProjectCode"] = dgv.Rows[i].Cells["ProjectCode"].Value;
                    if (dgv.Rows[i].Cells["AccountID"].Value.ToString() != "" && dgv.Rows[i].Cells["TemplateCode"].Value.ToString() == "")
                        r["TemplateAccountID"] = dgv.Rows[i].Cells["AccountID"].Value;
                    else
                    {
                        r["TemplateAccountID"] = GeneralFunctions.TemplateAccounts;
                        GeneralFunctions.TemplateAccounts++;
                    }
                    r["TemplateCode"] = txt_TemplateCode.Text;
                    dbAccountingProjectDS.GLTemplateAccounts.Rows.Add(r);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GeneralFunctions.ValidateString(txt_TemplateCode.Text,"Please Specify the Template Code"))
            {
                DataRow[] rArrAccounts;
                DataRow[] rArr = dbAccountingProjectDS.GLTemplates.Select("TemplateCodeID = '" + txt_TemplateID.Text + "'");
                if (rArr.Length != 0)
                {
                    rArrAccounts = this.dbAccountingProjectDS.GLTemplateAccounts.Select("TemplateCode = '" + txt_TemplateCode.Text + "'");
                    for (int i = 0; i < rArrAccounts.Length; i++)
                    {
                        rArrAccounts[i].Delete();
                    }
                    rArr[0].Delete();
                    MessageBox.Show("Template Record deleted successfully");
                    ClearAll();
                }
                else
                {
                    MessageBox.Show("The given Template Code doesnt exist \n Cant perform delete operation");
                }
            }
        }

        private void ClearAll()
        {
            txt_TemplateID.Text = currentTemplateID.ToString();
            txt_TemplateCode.Text = "";
            txt_TemplateName.Text = "";
            cb_JournalCode.SelectedIndex = -1;
            int count = dgv.Rows.Count;
            for (int i = count - 1; i >= 0; i--)
                dgv.Rows.RemoveAt(i);
            DataRow r = dtTemplateAccounts.NewRow();
            dtTemplateAccounts.Rows.Add(r);
        }

        private void btn_SaveChanges_Click(object sender, EventArgs e)
        {
            adaptertbTemplate.Update(dbAccountingProjectDS.GLTemplates);
            adaptertbTemplateAccounts.Update(dbAccountingProjectDS.GLTemplateAccounts);
            dbAccountingProjectDS.AcceptChanges();
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    if (e.ColumnIndex == 1)
                    {
                        if (dgv.Rows[currentRowIndex].Cells["AccountTypeName"].Value.ToString() == "")
                        {
                            string accountNumber;
                            GeneralFunctions.AccountNumberValidate(dgv.Rows[currentRowIndex].Cells["AccountNumber"].Value.ToString(),out accountNumber);
                            DataRow[] rArr = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + accountNumber + "'");
                            if (rArr.Length != 0)
                            {
                                dgv.Rows[currentRowIndex].Cells["AccountTypeName"].Value = rArr[0]["AccountTypeName"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("The given account number doesnt exist\n Please Enter another account or Choose an existing account");
                            }
                        }
                        if (dgv.Rows[currentRowIndex].Cells["AccountTypeName"].Value.ToString().ToLower() != "header"
                               && dgv.Rows[currentRowIndex].Cells["AccountTypeName"].Value.ToString().ToLower() != "statistical"
                               && dgv.Rows[currentRowIndex].Cells["AccountTypeName"].Value.ToString().ToLower() != "")
                        {
                            dgv.Rows[currentRowIndex].Cells["Debit"].Value = value;
                            dgv.Rows[currentRowIndex].Cells["Credit"].Value = value;
                            dgv.Rows[currentRowIndex].Cells["Units"].Value = 0;
                        }
                        if (currentRowIndex == dtTemplateAccounts.Rows.Count - 1)
                        {
                            DataRow r = dtTemplateAccounts.NewRow();
                            dtTemplateAccounts.Rows.Add(r);
                        }
                    }
                    if (e.ColumnIndex == 5)
                    {
                        CalculateBalance();
                        if (checkBox_Currency.Checked && cb_Currency.Text != "")
                        {
                            double amount = double.Parse(dgv.Rows[currentRowIndex].Cells["Debit"].Value.ToString());
                            dgv.Rows[currentRowIndex].Cells["DebitCC"].Value = GeneralFunctions.CalculateForiegnCurrencyValue(amount, double.Parse(txt_CurrencyRate.Text));
                        }
                        else if (checkBox_Currency.Checked && cb_Currency.Text == "")
                        {
                            dgv.Rows[currentRowIndex].Cells["Debit"].Value = "";
                            MessageBox.Show("Please Specify the foreign currency", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (e.ColumnIndex == 6)
                    {
                        CalculateBalance();
                        if (checkBox_Currency.Checked && cb_Currency.Text != "")
                        {
                            double amount = double.Parse(dgv.Rows[currentRowIndex].Cells["Credit"].Value.ToString());
                            dgv.Rows[currentRowIndex].Cells["CreditCC"].Value = GeneralFunctions.CalculateForiegnCurrencyValue(amount, double.Parse(txt_CurrencyRate.Text));
                        }
                        else if (checkBox_Currency.Checked && cb_Currency.Text == "")
                        {
                            dgv.Rows[currentRowIndex].Cells["Credit"].Value = "";
                            MessageBox.Show("Please Specify the foreign currency", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (e.ColumnIndex == 7)
                    {
                        CalculateUnitsCount();
                    }
                }
            }   
        }

        private void CalculateBalance()
        {
            balance = 0;
            double currentvalue = 0;
            DataRow r;
            for (int i = 0; i < dtTemplateAccounts.Rows.Count; i++)
            {
                r = dtTemplateAccounts.Rows[i];
                if (r.Equals(dtTemplateAccounts.Rows[dtTemplateAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountName"].ToString() == "")
                    break;
                currentvalue = 0;
                if (dgv.Rows[i].Cells["Debit"].Value.ToString() != "" &&
                                       GeneralFunctions.ValidateDouble(dgv.Rows[i].Cells["Debit"].Value.ToString(), "Please Insert a valid debit value", out currentvalue))
                {
                    balance += currentvalue;
                }
                currentvalue = 0;
                if (dgv.Rows[i].Cells["Credit"].Value.ToString() != "" &&
                                      GeneralFunctions.ValidateDouble(dgv.Rows[i].Cells["Credit"].Value.ToString(), "Please Insert a valid credit value", out currentvalue))
                {
                    balance -= currentvalue;
                }
            }
            txt_Balance.Text = balance.ToString();
        }

        private void CalculateUnitsCount()
        {
            unitsCount = 0;
            int currentvalue = 0;
            DataRow r;
            for (int i = 0; i < dtTemplateAccounts.Rows.Count; i++)
            {
                r = dtTemplateAccounts.Rows[i];
                if (r.Equals(dtTemplateAccounts.Rows[dtTemplateAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountName"].ToString() == "")
                    break;
                currentvalue = 0;
                if (dgv.Rows[i].Cells["Units"].Value.ToString() != "" &&
                                       GeneralFunctions.ValidateInteger(dgv.Rows[i].Cells["Units"].Value.ToString(), "Please Insert a valid Units value", out currentvalue))
                {
                    unitsCount += currentvalue;
                }
            }
            txt_Units.Text = unitsCount.ToString();
        }

        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            currentRowIndex = e.RowIndex;
        }

        private void dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataRow dr;
            if (GeneralFunctions.ValidateString(txt_TemplateCode.Text, "Please Specify the template code")
              && GeneralFunctions.ValidateString(txt_TemplateName.Text, "Please Specify the template name")
              && GeneralFunctions.ValidateComboBox(cb_JournalCode, "Please Specify the appropriate Journal Code of the given Template Code"))
            {
                AccountSearch accSearch = new AccountSearch();
                accSearch.ShowDialog();
                if (accSearch.selectedAccountName != null && accSearch.selectedAccountNumber != null)
                {
                    dtTemplateAccounts.Rows.RemoveAt(dtTemplateAccounts.Rows.Count - 1);
                    dr = dtTemplateAccounts.NewRow();
                    dr["AccountTypeName"] = accSearch.selectedAccountType;
                    dr["AccountID"] = GeneralFunctions.TemplateAccounts;
                    GeneralFunctions.TemplateAccounts++;
                    dr["AccountNumber"] = accSearch.selectedAccountNumber;
                    dr["AccountName"]= accSearch.selectedAccountName;
                    dtTemplateAccounts.Rows.Add(dr);

                    dr = dtTemplateAccounts.NewRow();
                    dtTemplateAccounts.Rows.Add(dr);
                }
               
                if (accSearch.selectedAccountsTable != null && accSearch.selectedAccountsTable.Rows.Count != 0)
                {
                    dtTemplateAccounts.Rows.RemoveAt(dtTemplateAccounts.Rows.Count - 1);
                    for (int i = 0; i < accSearch.selectedAccountsTable.Rows.Count; i++)
                    {
                        dr = dtTemplateAccounts.NewRow();
                        dr["AccountID"] = GeneralFunctions.TemplateAccounts;
                        GeneralFunctions.TemplateAccounts++;
                        dr["AccountTypeName"] = accSearch.selectedAccountsTable.Rows[i]["AccountTypeName"];
                        dr["AccountNumber"] = accSearch.selectedAccountsTable.Rows[i]["AccountNumber"];
                        dr["AccountName"] = accSearch.selectedAccountsTable.Rows[i]["AccountName"];
                        if (dr["AccountTypeName"].ToString().ToLower() != "header" && dr["AccountTypeName"].ToString().ToLower() != "statistical")
                        {
                            dr["Debit"] = value;
                            dr["Credit"] = value;
                            dr["Units"] = 0;
                        }
                        dtTemplateAccounts.Rows.Add(dr);
                    }
                    dr = dtTemplateAccounts.NewRow();
                    dtTemplateAccounts.Rows.Add(dr);
                }
            }
        }

        private void dgv_MouseLeave(object sender, EventArgs e)
        {
            if (dgv.CurrentCell != null)
            {
                if (dgv.CurrentCell.ColumnIndex == 1)
                {
                    dgv.CurrentCell = dgv.Rows[currentRowIndex].Cells[2];
                    return;
                }
                if (dgv.CurrentCell.ColumnIndex == 2)
                {
                    dgv.CurrentCell = dgv.Rows[currentRowIndex].Cells[4];
                    return;
                }
                if (dgv.CurrentCell.ColumnIndex == 4)
                {
                    dgv.CurrentCell = dgv.Rows[currentRowIndex].Cells[5];
                    return;
                }
                if (dgv.CurrentCell.ColumnIndex == 5)
                {
                    dgv.CurrentCell = dgv.Rows[currentRowIndex].Cells[6];
                    return;
                }
                if (dgv.CurrentCell.ColumnIndex == 6)
                {
                    dgv.CurrentCell = dgv.Rows[currentRowIndex].Cells[7];
                    return;
                }
                if (dgv.CurrentCell.ColumnIndex == 7)
                {
                    dgv.CurrentCell = dgv.Rows[currentRowIndex].Cells[9];
                    return;
                }
                if (dgv.CurrentCell.ColumnIndex == 9)
                {
                    if (dgv.Rows.Count > currentRowIndex + 1)
                    {
                        dgv.CurrentCell = dgv.Rows[currentRowIndex + 1].Cells[1];
                    }
                }
            }
        }

        private void cb_JournalCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_JournalCode.Text == "<new>")
            {
                GLJournalCodes jc = new GLJournalCodes();
                jc.ShowDialog();
                cb_JournalCode.Items.Clear();
                adaptertbGLJournalCodes.Fill(dbAccountingProjectDS.GLJournalCodes);
                cb_JournalCode = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLJournalCodes, cb_JournalCode, "JournalCode","JournalCodeID");
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                DataRow[] rArr;
                if (dgv.Rows[currentRowIndex].Cells["AccountID"].Value.ToString() != "")
                {
                    string accountID = dgv.Rows[currentRowIndex].Cells["AccountID"].Value.ToString();
                    rArr = dtTemplateAccounts.Select("AccountID = '" + accountID + "'");
                    if (rArr.Length > 0)
                    {
                        rArr[0].Delete();
                    }
                    rArr = dbAccountingProjectDS.GLTemplateAccounts.Select("TemplateAccountID = '" + accountID + "'");
                    if (rArr.Length > 0)
                        rArr[0].Delete();

                }
            }
        }

        private void checkBox_Currency_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Currency.Checked == true) {
                cb_Currency.Visible = true;
                label_Currency.Visible = true;
                label_CurrencyRate.Visible = true;
                txt_CurrencyRate.Visible = true;
                dgv.Columns["DebitLC"].ReadOnly = true;
                dgv.Columns["CreditLC"].ReadOnly = true;
            }
            else {
                cb_Currency.Visible = false;
                label_Currency.Visible = false;
                label_CurrencyRate.Visible = false;
                txt_CurrencyRate.Visible = false;
                dgv.Columns["DebitLC"].ReadOnly = true;
                dgv.Columns["CreditLC"].ReadOnly = true;
                //***************************************
                double currentAmount;
                DataRow r;
                for (int i = 0; i < dtTemplateAccounts.Rows.Count; i++) {
                    r = dtTemplateAccounts.Rows[i];
                    if (r.Equals(dtTemplateAccounts.Rows[dtTemplateAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountName"].ToString() == "")
                        break;
                    if (dgv.Rows[i].Cells["DebitFC"].Value.ToString() != "") {
                        currentAmount = double.Parse(dgv.Rows[i].Cells["DebitFC"].Value.ToString());
                        r["DebitLC"] = DBNull.Value;
                    }
                    if (dgv.Rows[i].Cells["CreditFC"].Value.ToString() != "") {
                        currentAmount = double.Parse(dgv.Rows[i].Cells["CreditFC"].Value.ToString());
                        r["CreditLC"] = DBNull.Value;
                    }
                }
                //****************************************

            }
            if (checkBox_Currency.Checked)
            {
                label_Currency.Visible = true;
                cb_Currency.Visible = true;
                label_CurrencyRate.Visible = true;
                txt_CurrencyRate.Visible = true;
                dgv.Columns["DebitCC"].ReadOnly = false;
                dgv.Columns["CreditCC"].ReadOnly = false;
            }
        }

        private void cb_Currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Currency.Text == "<new>")
            {
                Currency curr = new Currency();
                curr.ShowDialog();
                cb_Currency.Items.Clear();
                adaptertbCurrency.Fill(dbAccountingProjectDS.GLCurrency);
                cb_Currency = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLCurrency, cb_Currency, "CurrencyCode", "CurrencyNumber");
                cb_Currency = GeneralFunctions.RemoveBaseCurrency(cb_Currency);
            }
            if (cb_Currency.Text != "" && cb_Currency.Text != "<new>")
            {
               double exchangeRate;
                if (!GeneralFunctions.EvaluateExchangeRate(out exchangeRate,cb_Currency.Text))
                {
                    if (DialogResult.OK == MessageBox.Show("The conversion exchange rate for the given currency hasnt been defined\nPress OK if you want to define the exchage rates now"))
                    {
                        CurrencyConversionTable conversion = new CurrencyConversionTable();
                        conversion.ShowDialog();
                        GeneralFunctions.EvaluateExchangeRate(out exchangeRate, cb_Currency.Text);
                        txt_CurrencyRate.Text = exchangeRate.ToString();
                        UpdateForiegnCurrencyValues();
                    }
                }
                else
                {
                    txt_CurrencyRate.Text = exchangeRate.ToString();
                    UpdateForiegnCurrencyValues();
                }
            }
        }

        private void UpdateForiegnCurrencyValues()
        {
            double currentAmount;
             DataRow r;
             for (int i = 0; i < dtTemplateAccounts.Rows.Count; i++)
             {
                 r = dtTemplateAccounts.Rows[i];
                 if (r.Equals(dtTemplateAccounts.Rows[dtTemplateAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountName"].ToString() == "")
                     break;
                 if (dgv.Rows[i].Cells["Debit"].Value.ToString() != "")
                 {
                     currentAmount = double.Parse(dgv.Rows[i].Cells["Debit"].Value.ToString());
                     r["DebitCC"] = currentAmount / double.Parse(txt_CurrencyRate.Text);
                 }
                 if (dgv.Rows[i].Cells["Credit"].Value.ToString() != "")
                 {
                     currentAmount = double.Parse(dgv.Rows[i].Cells["Credit"].Value.ToString());
                     r["CreditCC"] = currentAmount / double.Parse(txt_CurrencyRate.Text);
                 }
             }
        }
    }
}