using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Accounting_GeneralLedger
{
    public partial class Currency : Form
    {
        private SqlConnection sqlcon;
        private SqlDataAdapter adapter;
        private SqlCommandBuilder cmdBuilder;
        private int currentcurrencyNumber;
        private static bool baseCurrencyAvailable = false;
        private string GLAccountNo = "";
        private string CurrencyAccountNumber = "";
        private bool save = false;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;

        public Currency()
        {
            InitializeComponent();
        }

        private void Currency_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbAccountingProjectDS.GLCurrency' table. You can move, or remove it, as needed.
            //this.gLCurrencyTableAdapter.Fill(this.dbAccountingProjectDS.GLCurrency);
            // TODO: This line of code loads data into the 'dbAccountingProjectDataSet.GLCurrency' table. You can move, or remove it, as needed.
            //this.gLCurrencyTableAdapter.Fill(this.dbAccountingProjectDataSet.GLCurrency);
            GeneralFunctions.priviledgeGroupBox(Lock44);
            GeneralFunctions.priviledgeGroupBox(Lock45);
            GeneralFunctions.priviledgeGroupBox(Lock46);
            SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon2.Open();
            SqlCommand command2 = new SqlCommand("Select BaseCurrency From GLCurrency Where BaseCurrency=1", sqlcon2);
            SqlDataReader sqlread2 = command2.ExecuteReader();
            if (sqlread2.HasRows)
            {

                checkBox_baseCurrency.Enabled = false;
            }
            else
            {
                checkBox_baseCurrency.Enabled = true;
            }
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adapter = new SqlDataAdapter("Select * from GLCurrency", sqlcon);
            cmdBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(dbAccountingProjectDS.GLCurrency);
            dgv.ClearSelection();

            SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon3.Open();
            SqlCommand GetCurrencyID = new SqlCommand("Select MAX(CurrencyNumber)+1 From GLCurrency", sqlcon3);
            if (GetCurrencyID.ExecuteScalar() != DBNull.Value)
            {
                GeneralFunctions.CurrencyID = Convert.ToInt32(GetCurrencyID.ExecuteScalar());
            }
            else
                GeneralFunctions.CurrencyID = 1;

            currentcurrencyNumber = GeneralFunctions.CurrencyID;
            txt_CurrencyCodeID.Text = currentcurrencyNumber.ToString();
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

            if (GeneralFunctions.languagechioce != "")
            {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }


            btndelete.Enabled = false;
            btnedit.Enabled = false;
        }

        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.formCurrency;
            this.dgv.Columns[0].HeaderText = obj_interface_language.dgvCurrencyColumn1.ToString();
            this.dgv.Columns[1].HeaderText = obj_interface_language.dgvCurrencyColumn2.ToString();
            this.dgv.Columns[2].HeaderText = obj_interface_language.dgvCurrencyColumn3.ToString();
            this.dgv.Columns[3].HeaderText = obj_interface_language.dgvCurrencyColumn4.ToString();
            this.dgv.Columns[4].HeaderText = obj_interface_language.dgvCurrencyColumn5.ToString();
            this.dgv.Columns[5].HeaderText = obj_interface_language.dgvCurrencyColumn6.ToString();
            this.dgv.Columns[6].HeaderText = obj_interface_language.dgvCurrencyColumn7.ToString();
            this.dgv.Columns[7].HeaderText = obj_interface_language.dgvCurrencyColumn8.ToString();
            this.label5.Text = obj_interface_language.labelCurrencyCodeID;
            this.label2.Text = obj_interface_language.labelCurrencyCode;
            this.label6.Text = obj_interface_language.labelCurrencyCodeSign;
            this.label1.Text = obj_interface_language.labelGLAccountNumber;
            this.label4.Text = obj_interface_language.labelPLAccountNumber;
            this.label3.Text = obj_interface_language.labelCurrencyDescreption;
            this.checkBox_Active.Text = obj_interface_language.checkbox_Active;
            this.checkBox_baseCurrency.Text = obj_interface_language.checkbox_baseCurrency;
            this.btn_New.Text = obj_interface_language.buttonbtnNew;
            this.btnedit.Text = obj_interface_language.buttonbtnEdit;
            this.btndelete.Text = obj_interface_language.buttonbtnDelete;
            this.btnUndo.Text = obj_interface_language.buttonbtnUndo;
            this.btnExit.Text = obj_interface_language.buttonCompanyExit;
            this.btnSavenew.Text = obj_interface_language.buttonJVTransactionSaveNew;
            this.Btnsaveedit.Text = obj_interface_language.buttonJVTransactionSaveEdit;
        }

        //private void btn_SaveChanges_Click(object sender, EventArgs e) {
        //    adapter.Update(dbAccountingProjectDS.GLCurrency);
        //    dbAccountingProjectDS.AcceptChanges();
        //    //CheckBaseCurrency();
        //    save = true;
        //}

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GeneralFunctions.ValidateString(txt_CurrencyCode.Text, "Please Specify the Currency Code") &&
                GeneralFunctions.ValidateString(txt_CurrencyDescription.Text, "Please Specify the Currency Description")
                && GeneralFunctions.AccountNumberValidate(txt_GLAccountNumber.Text, out GLAccountNo)
                && GeneralFunctions.AccountNumberValidate(txt_CurrencyAccountNumber.Text, out CurrencyAccountNumber)
                && BaseCurrenyValidate())
            {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select CurrencyNumber from GLCurrency where CurrencyNumber = '" + txt_CurrencyCodeID.Text + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("CurrencyNumber = '" + txt_CurrencyCodeID.Text + "'", dbAccountingProjectDS.GLCurrency))
                {
                    DataRow r = dbAccountingProjectDS.GLCurrency.NewRow();
                    r["CurrencyNumber"] = currentcurrencyNumber;
                    //GeneralFunctions.CurrencyID++;
                    //currentcurrencyNumber = GeneralFunctions.CurrencyID;
                    r["CurrencyCode"] = txt_CurrencyCode.Text;
                    r["CurrencyDescription"] = txt_CurrencyDescription.Text;
                    r["GLAccountNumber"] = GLAccountNo;
                    r["CurrencyPLAccountNumber"] = CurrencyAccountNumber;
                    if (checkBox_baseCurrency.Checked)
                    {
                        baseCurrencyAvailable = true;
                        r["BaseCurrency"] = 1;
                    }
                    else
                        r["BaseCurrency"] = 0;
                    if (checkBox_Active.Checked)
                        r["Active"] = 1;
                    else
                        r["Active"] = 0;
                    dbAccountingProjectDS.GLCurrency.Rows.Add(r);
                    dr.Close();
                    sqlcon.Close();
                    ClearAll();
                    if (save)
                        save = false;
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Currency Code already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.GLCurrency.Select("CurrencyNumber = '" + txt_CurrencyCodeID.Text + "'");
                        rArr[0]["CurrencyCode"] = txt_CurrencyCode.Text;
                        rArr[0]["CurrencyDescription"] = txt_CurrencyDescription.Text;
                        rArr[0]["GLAccountNumber"] = GLAccountNo;
                        rArr[0]["CurrencyPLAccountNumber"] = CurrencyAccountNumber;
                        if (checkBox_Active.Checked)
                            rArr[0]["Active"] = 1;
                        else
                            rArr[0]["Active"] = 0;
                        if (checkBox_baseCurrency.Checked)
                        {
                            baseCurrencyAvailable = true;
                            rArr[0]["BaseCurrency"] = 1;
                        }
                        else if (!checkBox_baseCurrency.Checked && rArr[0]["BaseCurrency"].ToString() == "True")
                        {
                            baseCurrencyAvailable = false;
                            rArr[0]["BaseCurrency"] = 0;
                            MessageBox.Show("The values in the conversion table has to be changed on change of the base currency\n Please Insert the conversion table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ClearAll();
                        if (save)
                            save = false;
                    }
                    else
                        ClearAll();
                    dr.Close();
                    sqlcon.Close();
                }
            }
        }

        private bool BaseCurrenyValidate()
        {
            bool valid = false;
            if (checkBox_baseCurrency.Checked && !baseCurrencyAvailable)
            {
                if (!checkBox_Active.Checked)
                {
                    if (DialogResult.OK == MessageBox.Show("The Base Currency has to be active \n Press OK if you want the given currency to be the base currency", "Alert", MessageBoxButtons.OKCancel))
                    {
                        checkBox_Active.Checked = true;
                        valid = true;
                    }
                }
                else
                {
                    valid = true;
                }
            }
            else if (checkBox_baseCurrency.Checked && baseCurrencyAvailable)
            {
                MessageBox.Show("A Base Currency already exists\n If you want the current currency to be the base currency, edit the current currency", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!checkBox_baseCurrency.Checked)
            {
                valid = true;
            }
            return valid;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (GeneralFunctions.ValidateString(txt_CurrencyCode.Text, "Please Specify the Currency Code") &&
                    GeneralFunctions.ValidateString(txt_CurrencyDescription.Text, "Please Specify the Currency Description")
                    && GeneralFunctions.AccountNumberValidate(txt_GLAccountNumber.Text, out GLAccountNo)
                    && GeneralFunctions.AccountNumberValidate(txt_CurrencyAccountNumber.Text, out CurrencyAccountNumber)
                    && BaseCurrenyValidate())
                {
                    DataRow[] rArr = dbAccountingProjectDS.GLCurrency.Select("CurrencyNumber = '" + txt_CurrencyCodeID.Text + "'");
                    if (rArr.Length != 0)
                    {
                        rArr[0]["CurrencyCode"] = txt_CurrencyCode.Text;
                        rArr[0]["CurrencyDescription"] = txt_CurrencyDescription.Text;
                        rArr[0]["GLAccountNumber"] = GLAccountNo;
                        rArr[0]["CurrencyPLAccountNumber"] = CurrencyAccountNumber;
                        if (checkBox_Active.Checked)
                            rArr[0]["Active"] = 1;
                        else
                            rArr[0]["Active"] = 0;
                        if (checkBox_baseCurrency.Checked)
                        {
                            baseCurrencyAvailable = false;
                            rArr[0]["BaseCurrency"] = 1;
                        }
                        else if (!checkBox_baseCurrency.Checked && rArr[0]["BaseCurrency"].ToString() == "True")
                        {
                            baseCurrencyAvailable = false;
                            rArr[0]["BaseCurrency"] = 0;
                            MessageBox.Show("The values in the conversion table has to be changed on change of the base currency\n Please Insert the conversion table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (!checkBox_baseCurrency.Checked)
                        {
                            rArr[0]["BaseCurrency"] = 0;
                        }
                    }
                    ClearAll();
                    if (save)
                        save = false;
                }
            }
            else
            {
                MessageBox.Show("Please Select the row that you want to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgv.ClearSelection();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataRow[] rArr = dbAccountingProjectDS.GLCurrency.Select("CurrencyNumber = '" + txt_CurrencyCodeID.Text + "'");
                if (rArr[0]["BaseCurrency"].ToString() == "True")
                {
                    baseCurrencyAvailable = false;
                }
                ClearAll();
                dbAccountingProjectDS.GLCurrency.Rows[dgv.SelectedRows[0].Index].Delete();
                if (save)
                    save = false;
            }
            else
            {
                if (txt_CurrencyCode.Text != "" && GeneralFunctions.ValidateString(txt_CurrencyCode.Text, "Please Specify the Currency Code"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.GLCurrency.Select("CurrencyNumber = '" + txt_CurrencyCodeID.Text + "'");
                    if (rArr.Length != 0)
                    {
                        if (rArr[0]["BaseCurrency"].ToString() == "True")
                        {
                            baseCurrencyAvailable = false;
                        }
                        rArr[0].Delete();
                        ClearAll();
                        if (save)
                            save = false;
                    }
                    else
                    {
                        MessageBox.Show("The given Currency Code doesnt exist \n Cant perform delete operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            dgv.ClearSelection();
        }

        private void checkBox_baseCurrency_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_baseCurrency.Checked && !checkBox_Active.Checked)
            {
                MessageBox.Show("The base currency is always active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBox_Active.Checked = true;
            }
        }

        private void ClearAll()
        {
            txt_CurrencyCode.Text = currentcurrencyNumber.ToString();
            txt_CurrencyCode.Text = "";
            txt_CurrencyDescription.Text = "";
            txt_CurrencyAccountNumber.Text = "";
            txt_GLAccountNumber.Text = "";
            checkBox_Active.Checked = false;
            checkBox_baseCurrency.Checked = false;
            dgv.Enabled = true;
        }

        private void Currency_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GB1.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void CheckBaseCurrency()
        {
            sqlcon.Open();
            SqlCommand cmdSelect = new SqlCommand("Select CurrencyNumber from GLCurrency where BaseCurrency = 1", sqlcon);
            SqlDataReader dr = cmdSelect.ExecuteReader();
            if (!dr.HasRows)
                baseCurrencyAvailable = false;
            else if (dr.HasRows)
                baseCurrencyAvailable = true;
            dr.Close();
            sqlcon.Close();
        }

        private void btn_GLAccountBrowse_Click(object sender, EventArgs e)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.ShowDialog();
            txt_GLAccountNumber.Text = accSearch.selectedAccountNumber;
        }

        private void btn_CurrencyAccountBrowse_Click(object sender, EventArgs e)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.ShowDialog();
            txt_CurrencyAccountNumber.Text = accSearch.selectedAccountNumber;
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (sender.ToString() != "NO")
            {
                if (GB1.Enabled == true)
                {
                    DialogResult myrst;
                    myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (myrst == DialogResult.No)
                        return;
                }
            }
            ClearAll();
            btn_New.Visible = true;
            btnSavenew.Visible = false;
            btnedit.Visible = true;
            Btnsaveedit.Visible = false;
            GB1.Enabled = false;
            btn_New.Enabled = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
            SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon3.Open();
            SqlCommand GetCurrencyID = new SqlCommand("Select MAX(CurrencyNumber)+1 From GLCurrency", sqlcon3);
            if (GetCurrencyID.ExecuteScalar() != DBNull.Value)
            {
                GeneralFunctions.CurrencyID = Convert.ToInt32(GetCurrencyID.ExecuteScalar());
            }
            else
                GeneralFunctions.CurrencyID = 1;

            currentcurrencyNumber = GeneralFunctions.CurrencyID;
            txt_CurrencyCodeID.Text = currentcurrencyNumber.ToString();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataRow r = dbAccountingProjectDS.GLCurrency.Rows[dgv.SelectedRows[0].Index];
                txt_CurrencyCodeID.Text = r["CurrencyNumber"].ToString();
                txt_CurrencyCode.Text = r["CurrencyCode"].ToString();
                txtCurrencySign.Text = r["CurrencySign"].ToString();
                txt_CurrencyDescription.Text = r["CurrencyDescription"].ToString();
                txt_GLAccountNumber.Text = r["GLAccountNumber"].ToString();
                txt_CurrencyAccountNumber.Text = r["CurrencyPLAccountNumber"].ToString();
                if (r["Active"].ToString() == "True")
                    checkBox_Active.Checked = true;
                else
                    checkBox_Active.Checked = false;
                if (r["BaseCurrency"].ToString() == "True")
                    checkBox_baseCurrency.Checked = true;
                else
                    checkBox_baseCurrency.Checked = false;

            }
            GB1.Enabled = false;
            btn_New.Enabled = false;
            btnedit.Enabled = true;
            btndelete.Enabled = true;
        }

        private void GB1_EnabledChanged(object sender, EventArgs e)
        {
            if (GB1.Enabled == true)
                dgv.Enabled = false;
            else
                dgv.Enabled = true;
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon3.Open();
            SqlCommand GetCurrencyID = new SqlCommand("Select MAX(CurrencyNumber)+1 From GLCurrency", sqlcon3);
            if (GetCurrencyID.ExecuteScalar() != DBNull.Value)
            {
                GeneralFunctions.CurrencyID = Convert.ToInt32(GetCurrencyID.ExecuteScalar());
            }
            else
                GeneralFunctions.CurrencyID = 1;

            currentcurrencyNumber = GeneralFunctions.CurrencyID;
            txt_CurrencyCodeID.Text = currentcurrencyNumber.ToString();

            ClearAll();
            SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon2.Open();
            SqlCommand command2 = new SqlCommand("Select BaseCurrency From GLCurrency Where BaseCurrency=1", sqlcon2);
            SqlDataReader sqlread2 = command2.ExecuteReader();
            if (sqlread2.HasRows)
            {

                checkBox_baseCurrency.Enabled = false;
            }
            else
            {
                checkBox_baseCurrency.Enabled = true;
            }
            GB1.Enabled = true;
            btn_New.Visible = false;
            btnSavenew.Visible = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
        }

        private void btnSavenew_Click(object sender, EventArgs e)
        {
            if (GeneralFunctions.ValidateString(txt_CurrencyCode.Text, "Please Specify the Currency Code") &&
            GeneralFunctions.ValidateString(txt_CurrencyDescription.Text, "Please Specify the Currency Description")
            && GeneralFunctions.AccountNumberValidate(txt_GLAccountNumber.Text, out GLAccountNo)
            && GeneralFunctions.AccountNumberValidate(txt_CurrencyAccountNumber.Text, out CurrencyAccountNumber)
            && BaseCurrenyValidate())
            {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select CurrencyNumber from GLCurrency where CurrencyNumber = '" + txt_CurrencyCodeID.Text + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("CurrencyNumber = '" + txt_CurrencyCodeID.Text + "'", dbAccountingProjectDS.GLCurrency))
                {
                    DataRow r = dbAccountingProjectDS.GLCurrency.NewRow();
                    r["CurrencyNumber"] = currentcurrencyNumber;
                    //GeneralFunctions.CurrencyID++;
                    //currentcurrencyNumber = GeneralFunctions.CurrencyID;
                    r["CurrencyCode"] = txt_CurrencyCode.Text;
                    r["CurrencySign"] = txtCurrencySign.Text;
                    r["CurrencyDescription"] = txt_CurrencyDescription.Text;
                    r["GLAccountNumber"] = GLAccountNo;
                    r["CurrencyPLAccountNumber"] = CurrencyAccountNumber;
                    if (checkBox_baseCurrency.Checked)
                    {
                        baseCurrencyAvailable = true;
                        r["BaseCurrency"] = 1;
                    }
                    else
                        r["BaseCurrency"] = 0;
                    if (checkBox_Active.Checked)
                        r["Active"] = 1;
                    else
                        r["Active"] = 0;
                    dbAccountingProjectDS.GLCurrency.Rows.Add(r);
                    dr.Close();
                    sqlcon.Close();
                    adapter.Update(dbAccountingProjectDS.GLCurrency);
                    dbAccountingProjectDS.AcceptChanges();
                    //CheckBaseCurrency();
                    save = true;
                    GB1.Enabled = false;
                    btn_New.Visible = true;
                    btnSavenew.Visible = false;
                    ClearAll();
                    if (save)
                        save = false;
                    SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlcon2.Open();
                    SqlCommand command2 = new SqlCommand("Select MAX(CurrencyNumber)+1 from GLCurrency ", sqlcon2);
                    int MaxNumber2 = Convert.ToInt32(command2.ExecuteScalar());
                    txt_CurrencyCodeID.Text = Convert.ToString(MaxNumber2);
                    currentcurrencyNumber = MaxNumber2;
                    sqlcon2.Close();
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Currency Code already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.GLCurrency.Select("CurrencyNumber = '" + txt_CurrencyCodeID.Text + "'");
                        rArr[0]["CurrencyCode"] = txt_CurrencyCode.Text;
                        rArr[0]["CurrencySign"] = txtCurrencySign.Text;
                        rArr[0]["CurrencyDescription"] = txt_CurrencyDescription.Text;
                        rArr[0]["GLAccountNumber"] = GLAccountNo;
                        rArr[0]["CurrencyPLAccountNumber"] = CurrencyAccountNumber;
                        if (checkBox_Active.Checked)
                            rArr[0]["Active"] = 1;
                        else
                            rArr[0]["Active"] = 0;
                        if (checkBox_baseCurrency.Checked)
                        {
                            baseCurrencyAvailable = true;
                            rArr[0]["BaseCurrency"] = 1;
                        }
                        else if (!checkBox_baseCurrency.Checked && rArr[0]["BaseCurrency"].ToString() == "True")
                        {
                            baseCurrencyAvailable = false;
                            rArr[0]["BaseCurrency"] = 0;
                            MessageBox.Show("The values in the conversion table has to be changed on change of the base currency\n Please Insert the conversion table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        adapter.Update(dbAccountingProjectDS.GLCurrency);
                        dbAccountingProjectDS.AcceptChanges();
                        //CheckBaseCurrency();
                        save = true;
                        GB1.Enabled = false;
                        btn_New.Visible = true;
                        btnSavenew.Visible = false;
                        ClearAll();
                        if (save)
                            save = false;
                        SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                        sqlcon2.Open();
                        SqlCommand command2 = new SqlCommand("Select MAX(CurrencyNumber)+1 from GLCurrency ", sqlcon2);
                        int MaxNumber2 = Convert.ToInt32(command2.ExecuteScalar());
                        txt_CurrencyCodeID.Text = Convert.ToString(MaxNumber2);
                        currentcurrencyNumber = MaxNumber2;
                        sqlcon2.Close();
                    }
                    else
                        ClearAll();
                    GB1.Enabled = false;
                    btn_New.Visible = true;
                    btnSavenew.Visible = false;
                    if (save)
                        save = false;
                    dr.Close();
                    sqlcon.Close();
                    adapter.Update(dbAccountingProjectDS.GLCurrency);
                    dbAccountingProjectDS.AcceptChanges();
                    SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlcon3.Open();
                    SqlCommand command3 = new SqlCommand("Select MAX(CurrencyNumber)+1 from GLCurrency ", sqlcon3);
                    int MaxNumber3 = Convert.ToInt32(command3.ExecuteScalar());
                    txt_CurrencyCodeID.Text = Convert.ToString(MaxNumber3);
                    currentcurrencyNumber = MaxNumber3;
                    sqlcon3.Close();
                }
            }
        }

        private void Btnsaveedit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (GeneralFunctions.ValidateString(txt_CurrencyCode.Text, "Please Specify the Currency Code") &&
                    GeneralFunctions.ValidateString(txt_CurrencyDescription.Text, "Please Specify the Currency Description")
                    && GeneralFunctions.AccountNumberValidate(txt_GLAccountNumber.Text, out GLAccountNo)
                    && GeneralFunctions.AccountNumberValidate(txt_CurrencyAccountNumber.Text, out CurrencyAccountNumber)
                    && BaseCurrenyValidate())
                {
                    DataRow[] rArr = dbAccountingProjectDS.GLCurrency.Select("CurrencyNumber = '" + txt_CurrencyCodeID.Text + "'");
                    if (rArr.Length != 0)
                    {
                        rArr[0]["CurrencyCode"] = txt_CurrencyCode.Text;
                        rArr[0]["CurrencySign"] = txtCurrencySign.Text;
                        rArr[0]["CurrencyDescription"] = txt_CurrencyDescription.Text;
                        rArr[0]["GLAccountNumber"] = GLAccountNo;
                        rArr[0]["CurrencyPLAccountNumber"] = CurrencyAccountNumber;
                        if (checkBox_Active.Checked)
                            rArr[0]["Active"] = 1;
                        else
                            rArr[0]["Active"] = 0;
                        if (checkBox_baseCurrency.Checked)
                        {
                            baseCurrencyAvailable = false;
                            rArr[0]["BaseCurrency"] = 1;
                        }
                        else if (!checkBox_baseCurrency.Checked && rArr[0]["BaseCurrency"].ToString() == "True")
                        {
                            baseCurrencyAvailable = false;
                            rArr[0]["BaseCurrency"] = 0;
                            MessageBox.Show("The values in the conversion table has to be changed on change of the base currency\n Please Insert the conversion table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (!checkBox_baseCurrency.Checked)
                        {
                            rArr[0]["BaseCurrency"] = 0;
                        }
                    }
                    ClearAll();
                    dgv.ClearSelection();
                    GB1.Enabled = false;
                    btnedit.Visible = true;
                    Btnsaveedit.Visible = false;
                    btn_New.Enabled = true;
                    btndelete.Enabled = true;
                    if (save)
                        save = false;
                    adapter.Update(dbAccountingProjectDS.GLCurrency);
                    dbAccountingProjectDS.AcceptChanges();
                    SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlcon2.Open();
                    SqlCommand command2 = new SqlCommand("Select MAX(CurrencyNumber)+1 from GLCurrency ", sqlcon2);
                    int MaxNumber2 = Convert.ToInt32(command2.ExecuteScalar());
                    txt_CurrencyCodeID.Text = Convert.ToString(MaxNumber2);
                    currentcurrencyNumber = MaxNumber2;
                    sqlcon2.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Select the row that you want to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgv.ClearSelection();
            SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon3.Open();
            SqlCommand GetCurrencyID = new SqlCommand("Select MAX(CurrencyNumber)+1 From GLCurrency", sqlcon3);
            if (GetCurrencyID.ExecuteScalar() != DBNull.Value)
            {
                GeneralFunctions.CurrencyID = Convert.ToInt32(GetCurrencyID.ExecuteScalar());
            }
            else
                GeneralFunctions.CurrencyID = 1;

            currentcurrencyNumber = GeneralFunctions.CurrencyID;
            txt_CurrencyCodeID.Text = currentcurrencyNumber.ToString();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            GB1.Enabled = true;
            btnedit.Visible = false;
            Btnsaveedit.Visible = true;
            btn_New.Enabled = false;
            btndelete.Enabled = false;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult myrst;
            myrst = MessageBox.Show("Are You Sure Delete This Currency", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return;
            if (dgv.SelectedRows.Count > 0)
            {
                DataRow[] rArr = dbAccountingProjectDS.GLCurrency.Select("CurrencyNumber = '" + txt_CurrencyCodeID.Text + "'");
                if (rArr[0]["BaseCurrency"].ToString() == "True")
                {
                    baseCurrencyAvailable = false;
                }
                ClearAll();
                dbAccountingProjectDS.GLCurrency.Rows[dgv.SelectedRows[0].Index].Delete();
                dgv.ClearSelection();
                btnedit.Enabled = false;
                btndelete.Enabled = false;
                if (save)
                    save = false;
                adapter.Update(dbAccountingProjectDS.GLCurrency);
                dbAccountingProjectDS.AcceptChanges();
            }
            else
            {
                if (txt_CurrencyCode.Text != "" && GeneralFunctions.ValidateString(txt_CurrencyCode.Text, "Please Specify the Currency Code"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.GLCurrency.Select("CurrencyNumber = '" + txt_CurrencyCodeID.Text + "'");
                    if (rArr.Length != 0)
                    {
                        if (rArr[0]["BaseCurrency"].ToString() == "True")
                        {
                            baseCurrencyAvailable = false;
                        }
                        rArr[0].Delete();
                        ClearAll();
                        dgv.ClearSelection();
                        btnedit.Enabled = false;
                        btndelete.Enabled = false;
                        if (save)
                            save = false;
                        adapter.Update(dbAccountingProjectDS.GLCurrency);
                        dbAccountingProjectDS.AcceptChanges();
                    }
                    else
                    {
                        MessageBox.Show("The given Currency Code doesnt exist \n Cant perform delete operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            dgv.ClearSelection();
            btnedit.Enabled = false;
            btndelete.Enabled = false;
            SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon2.Open();
            SqlCommand command2 = new SqlCommand("Select BaseCurrency From GLCurrency Where BaseCurrency=1", sqlcon2);
            SqlDataReader sqlread2 = command2.ExecuteReader();
            if (sqlread2.HasRows)
            {

                checkBox_baseCurrency.Enabled = false;
            }
            else
            {
                checkBox_baseCurrency.Enabled = true;
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}