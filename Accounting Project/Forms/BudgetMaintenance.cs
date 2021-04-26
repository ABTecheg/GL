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
using Accounting_GeneralLedger.Forms;

namespace Accounting_GeneralLedger {
    public partial class BudgetMaintenance : Form {

        public string selectedAccountNumber;
        public string selectedAccountName;
        public string selectedAccountType;
        public DataTable selectedAccountsTable;
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbAccounts;
        private SqlDataAdapter adaptertbAccountTypes;
        private SqlCommandBuilder cmdBuilderGeneralSetup;
        private SqlCommandBuilder cmdBuilderGLBudget;
        private SqlDataAdapter adaptertbGeneralSetup;
        private SqlDataAdapter adapterBudgetMaintenance;
        private SqlDataAdapter adapterGLFiscalPeriodSetup;
        private DataTable dtBudget;
        private string AccountNumberFormat;
        private int decmal = 1;
        private int currentRowIndex = 0;
        private string currentAccountNumber = "";
        private string defaultValue;
        private string showValue;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        public BudgetMaintenance() {
            InitializeComponent();
        }






        //private void txt_AccountNumber_TextChanged(object sender, EventArgs e) {
        //    SearchForGivenAccountNumber();

        //}

        private void getDataResults() {
            if (cbFiscalYear.Text == "")
            {
                MessageBox.Show("Specify Fiscal year first");
                return;
            }
            DataRow dr;
            SqlConnection sqlconnection2;
            SqlCommand sqlBudgetData;
            SqlDataReader sqlRead;

            int count = dgv.Rows.Count;
            for (int i = count - 1; i >= 0; i--)
                dgv.Rows.RemoveAt(i);
            //dgv.Enabled = true;
            SqlConnection sqlconAccount = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconAccount.Open();
            if (CreateFilterExpression() == "") {
                return;
            }
            SqlCommand cmdAccountSelect = new SqlCommand("Select * From GLAccounts Where " + CreateFilterExpression() + "", sqlconAccount);
            //MessageBox.Show("Select * From GLAccounts Where " + CreateFilterExpression() + "");
            SqlDataReader drAccount = cmdAccountSelect.ExecuteReader();
            if (drAccount.HasRows) {
                while (drAccount.Read())
                {
                    //dtBudget.Rows.RemoveAt(dtBudget.Rows.Count );
                    dr = dtBudget.NewRow();
                    dr["AccountTypeName"] = drAccount.GetString(2);
                    dr["AccountNumber"] = drAccount.GetString(0);
                    dr["AccountName"] = drAccount.GetString(1);
                    sqlconnection2 = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlconnection2.Open();
                    sqlBudgetData = new SqlCommand("Select * From GLBudget Where AccountNumber='" + drAccount.GetString(0) + "' AND FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlconnection2);
                    sqlRead = sqlBudgetData.ExecuteReader();
                    if (sqlRead.HasRows)
                    {
                        sqlRead.Read();
                        for (int i = 1; i <= 13; i++)
                        {
                            if (sqlRead.GetFloat(i + 2) == 0)
                            {
                                dr["Period" + i.ToString()] = sqlRead.GetFloat(i + 2);
                            }
                            else
                                dr["Period" + i.ToString()] = sqlRead.GetFloat(i + 2);
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= 13; i++)
                        {
                            dr["Period" + i.ToString()] = 0;
                        }

                    }

                    dtBudget.Rows.Add(dr);
                    dgv.Refresh();
                }
            }
        }
        private void SearchForGivenAccountNumber()
        {
            string acc = txt_AccountNumber1.ToString();
            acc = acc.Remove(0, 41).Trim();
            acc = acc.Replace('-', ' ');
            acc = acc.Replace('%', ' ');


            if (acc.Trim() == "" )
                GridRefresh();
            else
            {
                if (txt_AccountNumber1.MaskFull)
                {
                    currentAccountNumber = txt_AccountNumber1.Text;
                }
                else
                {
                    currentAccountNumber = txt_AccountNumber1.ToString();
                    currentAccountNumber = currentAccountNumber.Remove(0, 41).Trim();
                }
                getDataResults();

            }

        }

        private void BudgetMaintenance_Load(object sender, EventArgs e) {
            {
                GeneralFunctions.priviledgeGroupBox(Lock66);
                GeneralFunctions.priviledgeGroupBox(Lock18);
                sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
                adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts", sqlcon);
                adaptertbAccountTypes = new SqlDataAdapter("Select * from GLAccountTypes", sqlcon);
                adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
                adapterBudgetMaintenance = new SqlDataAdapter("Select * From GLBudget", sqlcon);
                adapterGLFiscalPeriodSetup = new SqlDataAdapter("Select * From GLFiscalPeriodSetup", sqlcon);
                cmdBuilderGeneralSetup = new SqlCommandBuilder(adaptertbGeneralSetup);
                cmdBuilderGLBudget = new SqlCommandBuilder(adapterBudgetMaintenance);
                adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
                adapterGLFiscalPeriodSetup.Fill(dbAccountingProjectDS.GLFiscalPeriodSetup);
                adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
                adaptertbAccountTypes.Fill(dbAccountingProjectDS.GLAccountTypes);
                adapterBudgetMaintenance.Fill(dbAccountingProjectDS.GLBudget);
                if (!GeneralFunctions.SubTypesloaded) {
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
                foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
                {
                    AccountNumberFormat = dr["AccountNumberFormat"].ToString();
                    decmal = int.Parse(dr["DecimalPointsNumber"].ToString());
                }
                dtBudget = new DataTable();
                dtBudget.Columns.Add("AccountNumber", System.Type.GetType("System.String"));
                dtBudget.Columns.Add("AccountName", System.Type.GetType("System.String"));
                dtBudget.Columns.Add("AccountTypeName", System.Type.GetType("System.String"));
                dtBudget.Columns.Add("Period1", System.Type.GetType("System.Double"));
                dtBudget.Columns.Add("Period2", System.Type.GetType("System.Double"));
                dtBudget.Columns.Add("Period3", System.Type.GetType("System.Double"));
                dtBudget.Columns.Add("Period4", System.Type.GetType("System.Double"));
                dtBudget.Columns.Add("Period5", System.Type.GetType("System.Double"));
                dtBudget.Columns.Add("Period6", System.Type.GetType("System.Double"));
                dtBudget.Columns.Add("Period7", System.Type.GetType("System.Double"));
                dtBudget.Columns.Add("Period8", System.Type.GetType("System.Double"));
                dtBudget.Columns.Add("Period9", System.Type.GetType("System.Double"));
                dtBudget.Columns.Add("Period10", System.Type.GetType("System.Double"));
                dtBudget.Columns.Add("Period11", System.Type.GetType("System.Double"));
                dtBudget.Columns.Add("Period12", System.Type.GetType("System.Double"));
                dtBudget.Columns.Add("Period13", System.Type.GetType("System.Double"));
                dtBudget.Columns["AccountNumber"].ReadOnly = true;
                dtBudget.Columns["AccountName"].ReadOnly = true;
                dtBudget.Columns["AccountTypeName"].ReadOnly = true;
                for (int c = 0; c < dgv.ColumnCount - 1; c++)
                {
                    dgv.Columns[c].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                txt_AccountNumber1.Mask = AccountNumberFormat;
                dgv.DataSource = dtBudget;
                //txt_AccountNumber.Mask = AccountNumberFormat;// "###-####-##";
                cbFiscalYear = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLFiscalPeriodSetup, cbFiscalYear, "FiscalYear", "0");
                //if (GeneralFunctions.Ckecktag("14") != "M")
                    cbFiscalYear.Items.Remove("<new>");
            }
            if (GeneralFunctions.languagechioce != "") {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }

        }

        private void update_language_interface() {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.formBudgetMaintenance;
            //this.dgv.Columns[0].HeaderText = obj_interface_language.dgvCurrencyConvCodeColumn1.ToString();
            //this.dgv.Columns[1].HeaderText = obj_interface_language.dgvCurrencyConvCodeColumn2.ToString();
            //this.dgv.Columns[2].HeaderText = obj_interface_language.dgvCurrencyConvCodeColumn3.ToString();
            //this.dgv.Columns[3].HeaderText = obj_interface_language.dgvCurrencyConvCodeColumn4.ToString();

            this.label4.Text = obj_interface_language.labelBudgetMaintenanceFiscalYear;
            this.label1.Text = obj_interface_language.labelBudgetMaintenanceAccountNumber;
            this.checkBox_Active.Text = obj_interface_language.checkboxBudgetMaintenanceActive;
            this.btnSave.Text = obj_interface_language.buttonBudgetMaintenanceSave;
            this.btn_Add.Text = obj_interface_language.buttonBudgetMaintenanceAdd;
            this.btnExit.Text = obj_interface_language.buttonBudgetMaintenanceExit;

            this.dgv.Columns[0].HeaderText = obj_interface_language.dgvBudgetMaintenanceColumn0;
            this.dgv.Columns[1].HeaderText = obj_interface_language.dgvBudgetMaintenanceColumn1;
            this.dgv.Columns[2].HeaderText = obj_interface_language.dgvBudgetMaintenanceColumn2;
            this.dgv.Columns[3].HeaderText = obj_interface_language.dgvBudgetMaintenanceColumn3;
            this.dgv.Columns[4].HeaderText = obj_interface_language.dgvBudgetMaintenanceColumn4;
            this.dgv.Columns[5].HeaderText = obj_interface_language.dgvBudgetMaintenanceColumn5;
            this.dgv.Columns[6].HeaderText = obj_interface_language.dgvBudgetMaintenanceColumn6;
            this.dgv.Columns[7].HeaderText = obj_interface_language.dgvBudgetMaintenanceColumn7;
            this.dgv.Columns[8].HeaderText = obj_interface_language.dgvBudgetMaintenanceColumn8;
            this.dgv.Columns[9].HeaderText = obj_interface_language.dgvBudgetMaintenanceColumn9;
            this.dgv.Columns[10].HeaderText = obj_interface_language.dgvBudgetMaintenanceColumn10;
            this.dgv.Columns[11].HeaderText = obj_interface_language.dgvBudgetMaintenanceColumn11;
            this.dgv.Columns[12].HeaderText = obj_interface_language.dgvBudgetMaintenanceColumn12;
            this.dgv.Columns[13].HeaderText = obj_interface_language.dgvBudgetMaintenanceColumn13;
            this.dgv.Columns[14].HeaderText = obj_interface_language.dgvBudgetMaintenanceColumn14;
            this.dgv.Columns[15].HeaderText = obj_interface_language.dgvBudgetMaintenanceColumn15;
                        
        }

        //private void txt_AccountNumber_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
        //    if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back) {
        //        string modifiedAccountNumber = "";
        //        for (int i = 0; i < txt_AccountNumber1.Text.Length - 1; i++)
        //            modifiedAccountNumber += txt_AccountNumber1.Text[i];
        //        currentAccountNumber = GeneralFunctions.ApplyAccountFormat(modifiedAccountNumber);
        //    }
        //}

        private void checkBox_Active_CheckedChanged(object sender, EventArgs e) {
            SearchForGivenAccountNumber();
        }



        //private string CreateFilterExpression() {
            //string filterExpression = "";
            ////Account Number Only 
            //if (txt_AccountNumber1.Text != "" && txt_AccountName.Text == "" && cb_AccountType.Text == "")
            //    filterExpression = "AccountNumber like '" + txt_AccountNumber1.Text + "%'";
            ////Account Type Only 
            //else if (txt_AccountNumber1.Text == "" && txt_AccountName.Text == "" && cb_AccountType.Text == "Any Type")
            //    filterExpression = "AccountTypeName Like '%'";
            //else if (txt_AccountNumber1.Text == "" && txt_AccountName.Text == "" && cb_AccountType.Text != "")
            //    filterExpression = "AccountTypeName = '" + cb_AccountType.Text + "'";
            ////Account Name Only 
            //else if (txt_AccountNumber1.Text == "" && txt_AccountName.Text != "" && cb_AccountType.Text == "")
            //    filterExpression = "AccountName like '%" + txt_AccountName.Text + "%'";
            ////Account Number and Name 
            //else if (txt_AccountNumber1.Text != "" && txt_AccountName.Text != "" && cb_AccountType.Text == "")
            //    filterExpression = "AccountNumber like '" + currentAccountNumber + "%' and AccountName like '%" + txt_AccountName.Text + "%'";
            ////Account Number and Type 
            //else if (txt_AccountNumber1.Text != "" && txt_AccountName.Text == "" && cb_AccountType.Text == "Any Type")
            //    filterExpression = "AccountNumber like '" + currentAccountNumber + "%' and AccountTypeName Like '%'";
            //else if (txt_AccountNumber1.Text != "" && txt_AccountName.Text == "" && cb_AccountType.Text != "")
            //    filterExpression = "AccountNumber like '" + currentAccountNumber + "%' and AccountTypeName = '" + cb_AccountType.Text + "'";
            ////Account Name and Type
            //else if (txt_AccountNumber1.Text == "" && txt_AccountName.Text != "" && cb_AccountType.Text == "Any Type")
            //    filterExpression = "AccountTypeName Like '%' and AccountName like '%" + txt_AccountName.Text + "%'";
            //else if (txt_AccountNumber1.Text == "" && txt_AccountName.Text != "" && cb_AccountType.Text != "")
            //    filterExpression = "AccountTypeName = '" + cb_AccountType.Text + "' and AccountName like '%" + txt_AccountName.Text + "%'";
            ////All 
            //else if (txt_AccountNumber1.Text != "" && txt_AccountName.Text != "" && cb_AccountType.Text == "Any Type")
            //    filterExpression = "AccountNumber like '" + currentAccountNumber + "%' and AccountTypeName Like '%' and AccountName like '%" + txt_AccountName.Text + "%'";
            //else if (txt_AccountNumber1.Text != "" && txt_AccountName.Text != "" && cb_AccountType.Text != "")
            //    filterExpression = "AccountNumber like '" + currentAccountNumber + "%' and AccountTypeName = '" + cb_AccountType.Text + "' and AccountName like '%" + txt_AccountName.Text + "%'";
            ////Check checkbox value
            //if (!checkBox_Active.Checked)
            //    if (filterExpression != "")
            //        filterExpression += " and Active =1";
            //return filterExpression;
        //}
        private string CreateFilterExpression()
        {
            string filterExpression = "";
            //Account Number Only 
            if (currentAccountNumber != "" )
                filterExpression = "(AccountNumber like '" + currentAccountNumber + "%')";
            if (!checkBox_Active.Checked)
                filterExpression += " and Active =1";
            filterExpression += " and AccountTypeName <> 'Header'";
            return filterExpression;
        }

        private void btn_Add_Click(object sender, EventArgs e) {
            if (btnedit.Visible == false)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
                else
                {
                    dgv.Enabled = false;
                    btnedit.Visible = true;
                    btnSave.Visible = false;
                }
            }

            AccountsDefinition accountAdd = new AccountsDefinition();
            accountAdd.ShowDialog();
            GridRefresh();
            SearchForGivenAccountNumber();
        }

        private void GridRefresh() {
            //adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
            //dgv.DataSource = dbAccountingProjectDS.GLAccounts;
            //dgv.Refresh();

            int count = dgv.Rows.Count;
            for (int i = count - 1; i >= 0; i--)
                dgv.Rows.Remove(dgv.Rows[i]);//    dgv.Rows.RemoveAt(i);
        }

         private void btn_SelectCurrentRecord_Click(object sender, EventArgs e) {
            DataRow dr;
            DataTable dt = new DataTable();
            dt.Columns.Add("AccountNumber", System.Type.GetType("System.String"));
            dt.Columns.Add("AccountName", System.Type.GetType("System.String"));
            dt.Columns.Add("AccountTypeName", System.Type.GetType("System.String"));
            dt.Columns.Add("Active", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("OpeningBalance", System.Type.GetType("System.Double"));
            for (int i = 0; i < dgv.Rows.Count; i++) {
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

       

        private void cbFiscalYear_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbFiscalYear.Text != "New") {
                SqlConnection sqlConCheck = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlConCheck.Open();
                SqlCommand sqlCheck = new SqlCommand("Select MAX(PeriodNumber) From GLFiscalPeriod Where YEAR(PeriodStartDate)=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlConCheck);
                if (sqlCheck.ExecuteScalar() != DBNull.Value) {
                    int maxPeriodNumber = Convert.ToInt32((sqlCheck.ExecuteScalar().ToString()));
                    if (maxPeriodNumber == 12) {
                        dgv.Columns["Period13"].Visible = false;
                    }
                    else {
                        dgv.Columns["Period13"].Visible = true;
                    }
                }
                if (txt_AccountNumber1.MaskFull)
                    SearchForGivenAccountNumber();

            }

        }

        private void btnSave_Click(object sender, EventArgs e) {
            DataRow r;
            for (int i = 0; i < dtBudget.Rows.Count; i++) {
                r = dtBudget.Rows[i];
                if (r.Equals(dtBudget.Rows[dtBudget.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountName"].ToString() == "")
                    break;
                if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified) {
                    SqlConnection sqlCheckFound = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlCheckFound.Open();
                    SqlCommand sqlCheckCommand = new SqlCommand("Select * From GLBudget Where AccountNumber='" + dgv.Rows[i].Cells["AccountNumber"].Value + "' AND FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlCheckFound);
                    SqlDataReader sssRead = sqlCheckCommand.ExecuteReader();
                    if (sssRead.HasRows) {
                        //********************************************************
                        SqlConnection sqlconnEditing = new SqlConnection(GeneralFunctions.ConnectionString);
                        sqlconnEditing.Open();
                        SqlCommand sqlcommandEditing = new SqlCommand("Update GLBudget SET Period1 =" + dgv.Rows[i].Cells["Period1"].Value + ",Period2 =" + dgv.Rows[i].Cells["Period2"].Value + ",Period3 =" + dgv.Rows[i].Cells["Period3"].Value + ",Period4 =" + dgv.Rows[i].Cells["Period4"].Value + ",Period5 =" + dgv.Rows[i].Cells["Period5"].Value + ",Period6 =" + dgv.Rows[i].Cells["Period6"].Value + ",Period7 =" + dgv.Rows[i].Cells["Period7"].Value + ",Period8 =" + dgv.Rows[i].Cells["Period8"].Value + ",Period9 =" + dgv.Rows[i].Cells["Period9"].Value + ",Period10 =" + dgv.Rows[i].Cells["Period10"].Value + ",Period11 =" + dgv.Rows[i].Cells["Period11"].Value + ",Period12 =" + dgv.Rows[i].Cells["Period12"].Value + ",Period13 =" + dgv.Rows[i].Cells["Period13"].Value + " ,Period99 = 0 Where AccountNumber='" + dgv.Rows[i].Cells["AccountNumber"].Value + "' AND FiscalYear=" + Convert.ToInt32(cbFiscalYear.Text) + "", sqlconnEditing);
                        //MessageBox.Show("Update Batch SET JVNumber ='" + txt_JVNumber.Text + "',BatchDate ='" + Convert.ToDateTime(DTP_JVDate.Value) + "',BatchPRD='" + txt_Period.Text + "',BatchDSC='" + txt_JVDescription.Text + "',BatchJNL='" + cb_JournalCode.Text + "' WHERE BatchNo=" + Convert.ToInt32(txtBatch.Text) + "");
                        //SqlDataReader sqlreaderEditing = sqlcommandEditing.ExecuteReader();
                        int x = sqlcommandEditing.ExecuteNonQuery();
                        if (x == 1) {
                            MessageBox.Show("Editing Succcessfuly","General Ledger");
                            adapterBudgetMaintenance.Update(dbAccountingProjectDS.GLBudget);
                            dbAccountingProjectDS.AcceptChanges();
                        }
                        else {
                            MessageBox.Show("Update Failed","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            return;
                        }
                        adapterBudgetMaintenance.Fill(dbAccountingProjectDS.GLBudget);

                        //*********************************************************
                    }
                    else {

                        r = this.dbAccountingProjectDS.GLBudget.NewRow();
                        SqlConnection sqlTransactions = new SqlConnection(GeneralFunctions.ConnectionString);
                        sqlTransactions.Open();
                        SqlCommand commadTransactions = new SqlCommand("Select MAX(TotalID)+1 From GLBudget", sqlTransactions);
                        //SqlCommand commandInsert=new SqlCommand(""
                        if (commadTransactions.ExecuteScalar() != DBNull.Value) {
                            r["TotalID"] = Convert.ToUInt32(commadTransactions.ExecuteScalar());
                        }
                        else {
                            r["TotalID"] = 1;
                        }
                        r["AccountNumber"] = dgv.Rows[i].Cells["AccountNumber"].Value;
                        r["FiscalYear"] = Convert.ToInt32(cbFiscalYear.Text); //txt_JVNumber.Text;
                        r["Period1"] = dgv.Rows[i].Cells["Period1"].Value;
                        r["Period2"] = dgv.Rows[i].Cells["Period2"].Value;
                        r["Period3"] = dgv.Rows[i].Cells["Period3"].Value;
                        r["Period4"] = dgv.Rows[i].Cells["Period4"].Value;
                        r["Period5"] = dgv.Rows[i].Cells["Period5"].Value;
                        r["Period6"] = dgv.Rows[i].Cells["Period6"].Value;
                        r["Period7"] = dgv.Rows[i].Cells["Period7"].Value;
                        r["Period8"] = dgv.Rows[i].Cells["Period8"].Value;
                        r["Period9"] = dgv.Rows[i].Cells["Period9"].Value;
                        r["Period10"] = dgv.Rows[i].Cells["Period10"].Value;
                        r["Period11"] = dgv.Rows[i].Cells["Period11"].Value;
                        r["Period12"] = dgv.Rows[i].Cells["Period12"].Value;
                        r["Period13"] = dgv.Rows[i].Cells["Period13"].Value;
                        r["Period99"] = 0;
                        r["BDGCode"] = 1;
                        dbAccountingProjectDS.GLBudget.Rows.Add(r);
                        adapterBudgetMaintenance.Update(dbAccountingProjectDS.GLBudget);
                        dbAccountingProjectDS.AcceptChanges();
                        MessageBox.Show("Editing Succcessfuly", "General Ledger");

                    }
                }
            }
            dgv.Enabled = false;
            btnedit.Visible = true;
            btnSave.Visible = false;

        }

        private void txt_AccountName_TextChanged(object sender, EventArgs e) {
            SearchForGivenAccountNumber();
        }

        private void btnExit_Click(object sender, EventArgs e) {
            if (btnedit.Visible == false)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            this.Close();
        }



 

        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dgv_Control_KeyPress);

            e.Control.KeyPress += new KeyPressEventHandler(dgv_Control_KeyPress);
        }
        private void dgv_Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgv.CurrentCell.ColumnIndex > 2 && dgv.CurrentCell.ColumnIndex < 16)
            {
                if (e.KeyChar == 45 )
                {
                    if (dgv.EditingControl.Text.ToString().Contains("-") == false)
                    {
                        e.Handled = false;

                    }
                    else
                        e.Handled = true;
                }
                else if (e.KeyChar == 8)
                {

                    e.Handled = false;

                }
                else if (e.KeyChar >= 48 && e.KeyChar <= 57)
                {
                    if (dgv.EditingControl.Text.ToString().Contains("."))
                    {
                        char c = '.';
                        string[] sc = dgv.EditingControl.Text.ToString().Split(c);

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
                else if (e.KeyChar == 46 && dgv.CurrentCell.ColumnIndex != 11)
                {
                    if (dgv.EditingControl.Text.ToString().Contains(".") == false)
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
        private void txt_AccountNumber1_DoubleClick(object sender, EventArgs e)
        {
            if (btnedit.Visible == false)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
                else
                {
                    dgv.Enabled = false;
                    btnedit.Visible = true;
                    btnSave.Visible = false;
                }
            }

            AccountSearch accSearch = new AccountSearch();
            accSearch.filter = " AND AccountTypeName <> 'Header'";
            accSearch.ShowDialog();
            if (accSearch.selectedAccountName != null && accSearch.selectedAccountNumber != null && accSearch.selectedAccountType != null && accSearch.selectedAccountType != "Header")
            {
                txt_AccountNumber1.Text = accSearch.selectedAccountNumber;
                SearchForGivenAccountNumber();
            }

        }

        private void txt_AccountNumber1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnedit.Visible == false)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
                else
                {
                    dgv.Enabled = false;
                    btnedit.Visible = true;
                    btnSave.Visible = false;
                }
            }

            if (e.KeyChar == 13)
                if (txt_AccountNumber1.MaskFull)
                    SearchForGivenAccountNumber();
                else
                    MessageBox.Show("Please Completed Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            dgv.Enabled = true;
            btnedit.Visible = false;
            btnSave.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets["Sheet1"];
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 1; i < dgv.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dgv.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                }
            }
            // save the application  
            workbook.SaveAs("D:\\GLPROJECT original", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            app.Quit();
        }
        private void button2_Click(object sender, EventArgs e)
        {

            CreatBudget f = new CreatBudget(); f.Show();
        }
    }
}