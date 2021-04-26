using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using JThomas.Controls;


namespace Accounting_GeneralLedger
{
    public partial class AllocationMaintenance : Form
    {
        private string sourceAccountNumber;
        private string sourceAccountName;
        private string AllocationCodefind;
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbGLJournalCodes;
        private SqlDataAdapter adaptertbAllocation;
        private SqlDataAdapter adaptertbAllocationDestinationAccounts;
        private SqlDataAdapter adaptertbAccounts;

        private SqlDataAdapter adaptertbGeneralSetup;
        private SqlCommandBuilder cmdBuildertbAllocation;
        private SqlCommandBuilder cmdBuildertbAllocationDestinationAccounts;
        private DataTable dtDestinationAccounts;
        private DataTable dtSourceAccounts;
        private DataTable dtallocation;
        private int decmal = 1;
        private string AccountNumberFormat;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        DataRow r;
        DataRow rs;
        private int currentRowIndex = 0;
        private int remperc = 0;
        private int currentAllocationID;

        public AllocationMaintenance()
        {
            InitializeComponent();
        }
        private void Remaining_Percentage()
        {
                remperc = 100;
            if (dgv.RowCount != 0)
            {
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    if (dgv.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        double o=0;
                        bool flage = double.TryParse(dgv.Rows[i].Cells["AccountPercentage"].Value.ToString(),out o);
                        if (flage == true)
                            remperc = remperc - int.Parse(dgv.Rows[i].Cells["AccountPercentage"].Value.ToString());
                    }
                }
            }
            if (GeneralFunctions.languagechioce == "arabic")
                lblPercentage.Text = " %" + remperc.ToString() + " : ÇáäÓÈÉ ÇáãÊÈÞíÉ";
            else
                lblPercentage.Text = "Remaining Percentage : " + remperc.ToString() + " %";
        }
        private bool AccountNumberValidate(string AccountNumber, object txt, out string output)
        {
            bool valid = true;
                output = "";
            try
            {
                valid = GeneralFunctions.AccountNumberValidate(AccountNumber, out output);

                if (AccountNumber != "")
                {
                    if (!GeneralFunctions.FindCharacter(AccountNumber, '-'))
                    {
                        //if (txt.ToString().Length == GeneralFunctions.AccountNumberLenght)
                        //{
                            if (GeneralFunctions.CheckSubstring(txt.ToString()))
                            {
                                string AccountNumberFormated = GeneralFunctions.CreateAccountNumberFormat(AccountNumber);
                                sqlcon.Open();
                                SqlCommand cmdSelect = new SqlCommand("Select AccountName from tbAccounts where AccountNumber = '" + AccountNumberFormated + "'", sqlcon);
                                SqlDataReader dr = cmdSelect.ExecuteReader();
                                if (!dr.HasRows)
                                {
                                    MessageBox.Show("The given account number doesnt exist\n Please Insert a valid account number or Browse for the desired account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    valid = false;
                                }
                                else if (dr.HasRows)
                                {
                                    sourceAccountName = dr[0].ToString();
                                    output = AccountNumberFormated;
                                }
                                dr.Close();
                                sqlcon.Close();
                            }
                            else
                            {
                                MessageBox.Show("The Account Number can only contain numeric characters\n " +
                                                             "Please enter valid characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                valid = false;
                            }
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Please Insert a account number compatitable to the given account number format '" + GeneralFunctions.AccountNumberFormat + "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    valid = false;
                        //}
                    }
                    else
                    {
                        int i = 0;
                        string[] arrInputAccountNumber = txt.ToString().Split('-');
                        GeneralFunctions.fillaccountformatnumber();
                        string[] arrAccountNumberFormat = GeneralFunctions.AccountNumberFormat.Split('-');
                        if (arrInputAccountNumber.Length == GeneralFunctions.NoOfSubtypes)
                        {
                            foreach (string s in arrInputAccountNumber)
                            {
                                if (s.Length == arrAccountNumberFormat[i].Length)
                                {
                                    if (!GeneralFunctions.CheckSubstring(s))
                                        valid = false;
                                    i++;
                                }
                                else
                                    valid = false;
                                if (!valid)
                                    MessageBox.Show("The Account Number can only contain numeric characters\n Please Insert a account number compatitable to the given account number format '" + GeneralFunctions.AccountNumberFormat + "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            if (valid)
                            {
                                sqlcon.Open();
                                SqlCommand cmdSelect = new SqlCommand("Select AccountName from GLAccounts where AccountNumber = '" + txt.ToString() + "'", sqlcon);
                                sourceAccountName = (string)cmdSelect.ExecuteScalar();
                                if (sourceAccountName != "")
                                {
                                    output = txt.ToString();
                                }
                                else
                                {
                                    MessageBox.Show("The given account number doesnt exist\n Please Insert a valid account number or Browse for the desired account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    valid = false;
                                }
                                sqlcon.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Insert a account number compatitable to the given account number format '" + GeneralFunctions.AccountNumberFormat + "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            valid = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Insert acceptable values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valid = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message ,"General Ledger");
            }
            return valid;
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.filter = " AND AccountTypeName <> 'Header'";
            accSearch.ShowDialog();
            if (accSearch.selectedAccountName != null && accSearch.selectedAccountNumber != null)
            {
                txt_SourceGLAccount.Text = accSearch.selectedAccountNumber;
                txt_SourceAccountName.Text = accSearch.selectedAccountName;
                sourceAccountName = accSearch.selectedAccountName;
                //AccountNumberValidate(txt_SourceGLAccount.Text, txt_SourceGLAccount, out sourceAccountNumber);
                dgv.CurrentRow.Cells[1].Value = accSearch.selectedAccountNumber;
                dgv.CurrentRow.Cells[2].Value = accSearch.selectedAccountName;

            }
        }

        private bool AccountNameTextValidate()
        {
            bool validate = true;
            try
            {
                if (txt_SourceAccountName.Text != "")
                {
                    if (txt_SourceAccountName.Text != sourceAccountName)
                    {
                        validate = false;
                        MessageBox.Show("The Account Name is associated with the account number \n You can only modify the account number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message ,"General Ledger");
            }
            return validate;
        }

        private void AllocationMaintenance_Load(object sender, EventArgs e)
        {
            try
            {
                string msg = GeneralFunctions.CheckLockTables("", "AllocationMaintenance", "", "Edit");
                if (msg != "")
                {
                    MessageBox.Show("Can't Open Because AllocationMaintenance Edit By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                    return;
                }
                GeneralFunctions.priviledgeGroupBox(Lock54);
                GeneralFunctions.priviledgeGroupBox(Lock55);
                GeneralFunctions.priviledgeGroupBox(Lock56);
                sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
                if (GeneralFunctions.languagechioce != "")
                {
                    this.obj_options = new ClassOptions();
                    this.obj_options.report_language = GeneralFunctions.languagechioce;
                    this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
                }
                load_allocation();
                adaptertbGLJournalCodes = new SqlDataAdapter("Select * from GLJournalCodes", sqlcon);
                adaptertbAllocationDestinationAccounts = new SqlDataAdapter("Select * from GLAllocationDestinationAccounts", sqlcon);
                cmdBuildertbAllocation = new SqlCommandBuilder(adaptertbAllocation);
                cmdBuildertbAllocationDestinationAccounts = new SqlCommandBuilder(adaptertbAllocationDestinationAccounts);
                adaptertbGLJournalCodes.Fill(dbAccountingProjectDS.GLJournalCodes);
                adaptertbAllocationDestinationAccounts.Fill(dbAccountingProjectDS.GLAllocationDestinationAccounts);
                adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
                adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
                foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
                {
                    AccountNumberFormat = dr["AccountNumberFormat"].ToString();
                    decmal = int.Parse(dr["DecimalPointsNumber"].ToString());
                }
                adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts where AccountTypeName <> 'Header'", sqlcon);
                adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
                DataGridViewMaskedTextColumn accformats = new DataGridViewMaskedTextColumn(AccountNumberFormat);
                accformats.DataPropertyName = "AccountNumber";
                accformats.HeaderText = "AccountNumber";     //  German text
                accformats.Name = "AccountNumber";
                accformats.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                accformats.Width = 75;
                DataGridViewMaskedTextColumn accformatd = new DataGridViewMaskedTextColumn(AccountNumberFormat);
                accformatd.DataPropertyName = "AccountNumber";
                accformatd.HeaderText = "AccountNumber";     //  German text
                accformatd.Name = "AccountNumber";
                accformatd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                accformatd.Width = 75;

                dtDestinationAccounts = new DataTable();
                dtDestinationAccounts.Columns.Add("AccountID", System.Type.GetType("System.Int32"));
                dtDestinationAccounts.Columns.Add("AccountNumber", System.Type.GetType("System.String"));
                dtDestinationAccounts.Columns.Add("AccountName", System.Type.GetType("System.String"));
                dtDestinationAccounts.Columns.Add("AccountPercentage", System.Type.GetType("System.Double"));
                dtDestinationAccounts.Columns.Add("AllocationCode", System.Type.GetType("System.String"));
                r = dtDestinationAccounts.NewRow();
                dtDestinationAccounts.Rows.Add(r);
                dgv.DataSource = dtDestinationAccounts;
                //dgv.Columns.Insert(1, accformatd);
                dgv.Columns[2].Visible = false;
                //dgv.Columns["AccountNumber"].ReadOnly = true;
                dgv.Columns["AccountName"].ReadOnly = true;
                dgv.Columns["AccountPercentage"].ReadOnly = false;
                dgv.Columns["AccountID"].Visible = false;
                dgv.Columns["AllocationCode"].Visible = false;
                dgv.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                dtSourceAccounts = new DataTable();
                dtSourceAccounts.Columns.Add("AccountID", System.Type.GetType("System.Int32"));
                dtSourceAccounts.Columns.Add("AccountNumber", System.Type.GetType("System.String"));
                dtSourceAccounts.Columns.Add("AccountName", System.Type.GetType("System.String"));
                dtSourceAccounts.Columns.Add("AccountPercentage", System.Type.GetType("System.Double"));
                dtSourceAccounts.Columns.Add("AllocationCode", System.Type.GetType("System.String"));
                rs = dtSourceAccounts.NewRow();
                dtSourceAccounts.Rows.Add(rs);
                dgva.DataSource = dtSourceAccounts;
                //dgva.Columns.Insert(1, accformats);
                dgva.Columns[2].Visible = false;
               // dgva.Columns["AccountNumber"].ReadOnly = true;
                dgva.Columns["AccountName"].ReadOnly = true;
                dgva.Columns["AccountPercentage"].ReadOnly = false;
                dgva.Columns["AccountID"].Visible = false;
                dgva.Columns["AllocationCode"].Visible = false;
                dgva.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgva.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgva.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                cb_GLJournalCodes = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLJournalCodes, cb_GLJournalCodes, "JournalCode", "JournalCodeID");
                if (GeneralFunctions.Ckecktag("21") != "M")
                    cb_GLJournalCodes.Items.Remove("<new>");
                if (GeneralFunctions.languagechioce != "")
                {
                    this.obj_options = new ClassOptions();
                    this.obj_options.report_language = GeneralFunctions.languagechioce;
                    this.update_language_interface();
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
                currentAllocationID = GeneralFunctions.AllocationID;
                txt_AllocationCodeID.Text = currentAllocationID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }
        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.Allocation_Maintenance;
            this.label7.Text = obj_interface_language.labelJVCode;
            this.label1.Text = obj_interface_language.AllocationCode;
            this.label2.Text = obj_interface_language.AllocationDescription;
            this.label3.Text = obj_interface_language.SourceAccount;
            this.lblPercentage.Text = obj_interface_language.RemainingPercentage;
            this.ChkRepeat.Text = obj_interface_language.ChkRepeat;
            this.label6.Text = obj_interface_language.DestinationAccounts;

            this.btn_New.Text = obj_interface_language.buttonJVTransactionNew;
            this.btnedit.Text = obj_interface_language.buttonJVTransactionEdit;
            this.btndelete.Text = obj_interface_language.buttonJVTransactionDelete;
            this.btnundo.Text = obj_interface_language.buttonJVTransactionUndo;
            this.btnexit.Text = obj_interface_language.buttonJVTransactionExit;
            this.btnnew.Text = obj_interface_language.buttonJVTransactionSaveNew;
            this.btn_SaveChanges.Text = obj_interface_language.buttonJVTransactionSaveEdit;

            this.dgv.Columns["AccountNumber"].HeaderText = obj_interface_language.dgvAccountDefinitionColumn1;
            this.dgv.Columns["AccountName"].HeaderText = obj_interface_language.dgvAccountDefinitionColumn2;
            this.dgv.Columns["AccountPercentage"].HeaderText = obj_interface_language.dgvAccountPercentage;
            this.dgva.Columns["AccountNumber"].HeaderText = obj_interface_language.dgvAccountDefinitionColumn1;
            this.dgva.Columns["AccountName"].HeaderText = obj_interface_language.dgvAccountDefinitionColumn2;
            this.dgva.Columns["AccountPercentage"].HeaderText = obj_interface_language.dgvAccountPercentage;
            this.dgvallocation.Columns["Code"].HeaderText = obj_interface_language.DGVCode;
            this.dgvallocation.Columns["Journal"].HeaderText = obj_interface_language.DGVJournal;
            this.dgvallocation.Columns["Description"].HeaderText = obj_interface_language.DGVDescription;
        }

        private void dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataRow dr;
                if (GeneralFunctions.ValidateString(txt_AllocationCode.Text, "Please Specify the Allocation Code")
                    && GeneralFunctions.ValidateString(txt_AllocationDescription.Text, "Please Specify the Allocation Code") &&
                    GeneralFunctions.ValidateComboBox(cb_GLJournalCodes, "Please Specify the appropriate Journal Code of the given Allocation Code")
                    && AccountNumberValidate(txt_SourceGLAccount.Text, txt_SourceGLAccount, out sourceAccountNumber))
                {
                    AccountSearch accSearch = new AccountSearch();
                    accSearch.filter = " AND AccountTypeName <> 'Header'";
                    accSearch.ShowDialog();
                    if (accSearch.selectedAccountName != null && accSearch.selectedAccountNumber != null)
                    {
                        dtDestinationAccounts.Rows.RemoveAt(dtDestinationAccounts.Rows.Count - 1);
                        dr = dtDestinationAccounts.NewRow();
                        dr["AccountID"] = GeneralFunctions.DestinationAccounts;
                        GeneralFunctions.DestinationAccounts++;
                        dr["AccountNumber"] = accSearch.selectedAccountNumber;
                        dr["AccountName"] = accSearch.selectedAccountName;
                        dtDestinationAccounts.Rows.Add(dr);
                        dr = dtDestinationAccounts.NewRow();
                        dtDestinationAccounts.Rows.Add(dr);
                        bool t = true;
                        dgv.Rows[e.RowIndex].Cells["AccountPercentage"].Selected = true;
                        dgv.BeginEdit(t);

                    }

                    if (accSearch.selectedAccountsTable != null && accSearch.selectedAccountsTable.Rows.Count != 0)
                    {
                        dtDestinationAccounts.Rows.RemoveAt(dtDestinationAccounts.Rows.Count - 1);
                        for (int i = 1; i < accSearch.selectedAccountsTable.Rows.Count; i++)
                        {
                            dr = dtDestinationAccounts.NewRow();
                            dr["AccountID"] = GeneralFunctions.DestinationAccounts;
                            GeneralFunctions.DestinationAccounts++;
                            dr["AccountNumber"] = accSearch.selectedAccountsTable.Rows[i]["AccountNumber"];
                            dr["AccountName"] = accSearch.selectedAccountsTable.Rows[i]["AccountName"];
                            dtDestinationAccounts.Rows.Add(dr);
                        }
                        dr = dtDestinationAccounts.NewRow();
                        dtDestinationAccounts.Rows.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //e.ThrowException = false;
            //e.Cancel = false;
        }

        private bool ValidatePercentageValue()
        {
            DataRow r;
            double currentPerentage = 0;
            bool valid = true;
            try
            {
                string input;

                if (dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        r = dtDestinationAccounts.Rows[i];
                        if (r.Equals(dtDestinationAccounts.Rows[dtDestinationAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == ""
                            && r["AccountNumber"].ToString() == "" && r["AccountPercentage"].ToString() == "")
                        {
                            break;
                        }
                        input = dgv.Rows[i].Cells["AccountPercentage"].EditedFormattedValue.ToString();
                        if (input != "")
                        {
                            try
                            {
                                double value = double.Parse(input);
                                if (value <= 100 && value > 0)
                                {
                                    currentPerentage += value;
                                }
                                else
                                {
                                    MessageBox.Show("This isnt a valid percentage\n Please enter a valid percentage", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    valid = false;
                                    break;
                                }
                            }
                            catch
                            {
                                MessageBox.Show("This isnt a valid percentage\n Please enter a valid percentage", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                valid = false;
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show(" Please enter a valid percentage", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            valid = false;
                        }
                    }
                    if (dtDestinationAccounts.Rows.Count > 1)
                    {
                        if (currentPerentage != 100)
                        {
                            valid = false;
                            MessageBox.Show("The total percentage isnt equal to 100\n Please Adjust the destination accounts percentages", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
            return valid;
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                txt_AllocationCode.Focus();
                dgva.Refresh();
                dgv.Refresh();
                if (GeneralFunctions.ValidateString(txt_AllocationCode.Text, "Please Specify the Allocation Code")
                    && GeneralFunctions.ValidateString(txt_AllocationDescription.Text, "Please Specify the Allocation Description") && AccountNumberValidate(dgva.Rows[0].Cells[1].Value.ToString(), dgva.Rows[0].Cells[1].Value, out sourceAccountNumber)
                     && GeneralFunctions.ValidateComboBox(cb_GLJournalCodes, "Please Specify the appropriate Journal Code of the given Allocation Code")
                     && AccountNameTextValidate() && ValidateDestinationAccount() && ValidatePercentageValue())
                {
                    sqlcon.Open();
                    //SqlCommand cmdSelect = new SqlCommand("Select AllocationCodeID from GLAllocation where AllocationCodeID = '" + txt_AllocationCodeID.Text + "'", sqlcon);
                    //SqlDataReader dr = cmdSelect.ExecuteReader();
                    //if (dr.HasRows )//&& !GeneralFunctions.FindRow("AllocationCodeID = '" + txt_AllocationCodeID.Text + "'", dbAccountingProjectDS.GLAllocation))
                    //{
                        DataRow [] rf = dbAccountingProjectDS.GLAllocation.Select("AllocationCode = '" + txt_AllocationCode.Text + "'");
                        if (rf.Length != 0)
                        {
                            MessageBox.Show("AllocationCode Is Exist", "General Ledger");
                            //dr.Close();
                            sqlcon.Close();
                            return;
                        }
                        DataRow r = this.dbAccountingProjectDS.GLAllocation.NewRow();
                        for (int i = 0; i < dtSourceAccounts.Rows.Count; i++)
                        {
                            DataRow rs = dtSourceAccounts.Rows[i];
                            r = this.dbAccountingProjectDS.GLAllocation.NewRow();
                            if (rs.Equals(dtSourceAccounts.Rows[dtSourceAccounts.Rows.Count - 1]) && rs["AccountNumber"].ToString() == ""
                                && rs["AccountNumber"].ToString() == "" && rs["AccountPercentage"].ToString() == "")
                                break;
                            if (rs.RowState == DataRowState.Added || rs.RowState == DataRowState.Modified)
                            {

                                //r["AllocationCodeID"] = currentAllocationID;
                                GeneralFunctions.AllocationID++;
                                currentAllocationID = GeneralFunctions.AllocationID;
                                r["AllocationCode"] = txt_AllocationCode.Text;
                                r["AllocationGLJournalCode"] = cb_GLJournalCodes.Text;
                                r["AllocationDescription"] = txt_AllocationDescription.Text;
                                r["AllocationSourceAccount"] = dtSourceAccounts.Rows[i]["AccountNumber"].ToString();
                                r["AllocationSourceAccountName"] = dtSourceAccounts.Rows[i]["AccountName"].ToString();
                                r["AllocationSourceAccountPercentage"] = dtSourceAccounts.Rows[i]["AccountPercentage"];
                                if (ChkRepeat.Checked == true)
                                    r["AllocationRepeat"] = "1";
                                else if (ChkRepeat.Checked == false )
                                    r["AllocationRepeat"] = "0";
                                dbAccountingProjectDS.GLAllocation.Rows.Add(r);
                            }
                        }
                        AddDestinationAccount();
                        //dr.Close();
                        sqlcon.Close();
                        Allocationupdate();
                        MessageBox.Show("Allocation Record inserted successfully");
                        //ClearAll();
                        groupBox1.Enabled = false;
                        btn_New.Visible = true;
                        btnnew.Visible = false;
                        btnedit.Enabled = true;
                        btndelete.Enabled = true;

                //    }
                //    else
                //    {
                //        if (DialogResult.OK == MessageBox.Show("The given Allocation Code already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                //        {
                //            DataRow[] rArr = this.dbAccountingProjectDS.GLAllocation.Select("AllocationCodeID = '" + txt_AllocationCodeID.Text + "'");

                //            rArr[0]["AllocationCode"] = txt_AllocationCode.Text;
                //            rArr[0]["AllocationGLJournalCode"] = cb_GLJournalCodes.Text;
                //            rArr[0]["AllocationDescription"] = txt_AllocationDescription.Text;
                //            rArr[0]["AllocationSourceAccount"] = sourceAccountNumber;
                //            rArr[0]["AllocationSourceAccountName"] = sourceAccountName;
                //            EditDestinationAccount();
                //            MessageBox.Show("Allocation Record edited successfully");
                //            ClearAll();
                //        }
                //        else
                //        {
                //            ClearAll();
                //        }
                //        dr.Close();
                //        sqlcon.Close();
                //    }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");

            }
            
  
        }
        private void Allocationupdate()
        {
            try
            {
                cmdBuildertbAllocation.DataAdapter = adaptertbAllocation;
                cmdBuildertbAllocationDestinationAccounts.DataAdapter = adaptertbAllocationDestinationAccounts;
                adaptertbAllocation.Update(dbAccountingProjectDS.GLAllocation);
                adaptertbAllocationDestinationAccounts.Update(dbAccountingProjectDS.GLAllocationDestinationAccounts);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }
        private void AddDestinationAccount()
        {
            try
            {
                DataRow r;
                for (int i = 0; i < dtDestinationAccounts.Rows.Count; i++)
                {
                    r = dtDestinationAccounts.Rows[i];
                    if (r.Equals(dtDestinationAccounts.Rows[dtDestinationAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == ""
                        && r["AccountNumber"].ToString() == "" && r["AccountPercentage"].ToString() == "")
                        break;
                    if (dtDestinationAccounts.Rows[i]["AccountNumber"].ToString() != "")
                    {
                        r = this.dbAccountingProjectDS.GLAllocationDestinationAccounts.NewRow();
                        //if (dgv.Rows[i].Cells["AccountID"].Value.ToString() != "" && dgv.Rows[i].Cells["AllocationCode"].Value.ToString() == "")
                        //    r["AllocationDestinationID"] = dgv.Rows[i].Cells["AccountID"].Value;
                        //else
                        //{
                        //    r["AllocationDestinationID"] = GeneralFunctions.DestinationAccounts;
                        //    GeneralFunctions.DestinationAccounts++;
                        //}
                        r["DestinationGLAccountNumber"] = dtDestinationAccounts.Rows[i]["AccountNumber"];
                        r["DestinationAccountDescription"] = dtDestinationAccounts.Rows[i]["AccountName"];
                        if (dtDestinationAccounts.Rows[i]["AccountPercentage"].ToString() != "")
                            r["DestinationAccountPercentage"] = dtDestinationAccounts.Rows[i]["AccountPercentage"];
                        else
                            r["DestinationAccountPercentage"] = dtDestinationAccounts.Rows[i]["AccountPercentage"];
                        r["AllocationCode"] = txt_AllocationCode.Text;
                        dbAccountingProjectDS.GLAllocationDestinationAccounts.Rows.Add(r);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void EditDestinationAccount()
        {
            try
            {
                DataRow r;
                for (int i = 0; i < dtDestinationAccounts.Rows.Count ; i++)
                {
                    r = dtDestinationAccounts.Rows[i];
                    if (r.Equals(dtDestinationAccounts.Rows[dtDestinationAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == ""
                        && r["AccountNumber"].ToString() == "" && r["AccountPercentage"].ToString() == "")
                        break;
                    if (r.RowState == DataRowState.Modified)
                    {
                        DataRow[] rArr = this.dbAccountingProjectDS.GLAllocationDestinationAccounts.Select("AllocationDestinationID = '" + dgv.Rows[i].Cells["AccountID"].Value + "'");
                        rArr[0]["DestinationGLAccountNumber"] = dtDestinationAccounts.Rows[i]["AccountNumber"];
                        rArr[0]["DestinationAccountDescription"] = dtDestinationAccounts.Rows[i]["AccountName"];
                        if (dgv.Rows[i].Cells["AccountPercentage"].Value.ToString() != "")
                            rArr[0]["DestinationAccountPercentage"] = dtDestinationAccounts.Rows[i]["AccountPercentage"];
                        else
                            rArr[0]["DestinationAccountPercentage"] = dtDestinationAccounts.Rows[i]["AccountPercentage"];
                    }
                    if (r.RowState == DataRowState.Added)
                    {
                        r = this.dbAccountingProjectDS.GLAllocationDestinationAccounts.NewRow();
                        r["DestinationGLAccountNumber"] = dtDestinationAccounts.Rows[i]["AccountNumber"];
                        r["DestinationAccountDescription"] = dtDestinationAccounts.Rows[i]["AccountName"];
                        if (dtDestinationAccounts.Rows[i]["AccountPercentage"].ToString() != "")
                            r["DestinationAccountPercentage"] = dtDestinationAccounts.Rows[i]["AccountPercentage"];
                        else
                            r["DestinationAccountPercentage"] = dtDestinationAccounts.Rows[i]["AccountPercentage"];

                        //if (dgv.Rows[i].Cells["AccountID"].Value.ToString() != "" && dgv.Rows[i].Cells["AllocationCode"].Value.ToString() == "")
                            //r["AllocationDestinationID"] = dtDestinationAccounts.Rows[i].Cells["AccountID"].Value;
                        //else
                        //{
                           // r["AllocationDestinationID"] = GeneralFunctions.DestinationAccounts;
                            GeneralFunctions.DestinationAccounts++;
                        //}
                        r["AllocationCode"] = txt_AllocationCode.Text;
                        dbAccountingProjectDS.GLAllocationDestinationAccounts.Rows.Add(r);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private bool ValidateDestinationAccount()
        {
            bool valid = true;
            try
            {
                DataRow[] rArr;
                DataRow r;
                string validAccountNumber;
                for (int i = 0; i < dtDestinationAccounts.Rows.Count; i++)
                {
                    r = dtDestinationAccounts.Rows[i];
                    if (r.RowState != DataRowState.Deleted)
                    {
                        if (r.Equals(dtDestinationAccounts.Rows[dtDestinationAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == ""
                            && r["AccountNumber"].ToString() == "" && r["AccountPercentage"].ToString() == "")
                            break;
                        if (r["AccountNumber"].ToString() != "")
                        {
                            if (!GridAccountNumbersValidate(r["AccountNumber"].ToString(), out validAccountNumber))
                            {
                                MessageBox.Show("The given account number doesnt exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                    }
                                }
                                else
                                    r["AccountName"] = (string)rArr[0]["AccountName"];
                            }
                        }
                        else
                        {
                            MessageBox.Show("The account number cant be equal to null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            valid = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
            return valid;
        }

        private bool GridAccountNumbersValidate(string AccountNumber, out string output)
        {
            bool valid = true;
            output = "";
            try
            {
                valid = GeneralFunctions.AccountNumberValidate(AccountNumber, out output);
                if (AccountNumber != "")
                {
                    if (!GeneralFunctions.FindCharacter(AccountNumber, '-'))
                    {
                        //if (AccountNumber.Length == GeneralFunctions.AccountNumberLenght)
                        //{
                            if (GeneralFunctions.CheckSubstring(AccountNumber))
                            {
                                string AccountNumberFormated = GeneralFunctions.CreateAccountNumberFormat(AccountNumber);
                                sqlcon.Open();
                                SqlCommand cmdSelect = new SqlCommand("Select AccountName from tbAccounts where AccountNumber = '" + AccountNumberFormated + "'", sqlcon);
                                SqlDataReader dr = cmdSelect.ExecuteReader();
                                if (!dr.HasRows)
                                {
                                    MessageBox.Show("The given account number doesnt exist\n Please Insert a valid account number or Browse for the desired account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    valid = false;
                                }
                                else if (dr.HasRows)
                                {
                                    output = AccountNumberFormated;
                                }
                                dr.Close();
                                sqlcon.Close();
                            }
                            else
                            {
                                MessageBox.Show("The Account Number can only contain numeric characters\n " +
                                                             "Please enter valid characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                valid = false;
                            }
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Please Insert a account number compatitable to the given account number format '" + GeneralFunctions.AccountNumberFormat + "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    valid = false;
                        //}
                    }
                    else
                    {
                        int i = 0;
                        string[] arrInputAccountNumber = AccountNumber.Split('-');
                        string[] arrAccountNumberFormat = GeneralFunctions.AccountNumberFormat.Split('-');
                        if (arrInputAccountNumber.Length == GeneralFunctions.NoOfSubtypes)
                        {
                            foreach (string s in arrInputAccountNumber)
                            {
                                if (s.Length == arrAccountNumberFormat[i].Length)
                                {
                                    if (!GeneralFunctions.CheckSubstring(s))
                                        valid = false;
                                    i++;
                                }
                                else
                                    valid = false;
                                if (!valid)
                                    MessageBox.Show("The Account Number can only contain numeric characters\n Please Insert a account number compatitable to the given account number format '" + GeneralFunctions.AccountNumberFormat + "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            if (valid)
                            {
                                sqlcon.Open();
                                SqlCommand cmdSelect = new SqlCommand("Select AccountName from GLAccounts where AccountNumber = '" + AccountNumber + "'", sqlcon);
                                string sAccountName = (string)cmdSelect.ExecuteScalar();
                                if (sAccountName != "")
                                {
                                    output = AccountNumber;
                                }
                                else
                                {
                                    MessageBox.Show("The given account number doesnt exist\n Please Insert a valid account number or Browse for the desired account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    valid = false;
                                }
                                sqlcon.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Insert a account number compatitable to the given account number format '" + GeneralFunctions.AccountNumberFormat + "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            valid = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Insert acceptable values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valid = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
            return valid;
        }

        private int FindRowIndex(int AccountID)
        {
            try
            {
                int currentID;
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    currentID = ((int)r.Cells["AllocationDestinationID"].Value);
                    if (currentID == AccountID)
                        return r.Index;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
            return -1;
        }

        private void ClearAll()
        {
            try
            {
                dgv.EndEdit();
                dgva.EndEdit();
                txt_AllocationCodeID.Text = currentAllocationID.ToString();
                txt_AllocationCode.Text = "";
                txt_AllocationDescription.Text = "";
                cb_GLJournalCodes.SelectedIndex = -1;
                txt_SourceGLAccount.Text = "";
                txt_SourceAccountName.Text = "";
                dtDestinationAccounts.Clear();
                dtSourceAccounts.Clear();
                int count = dgv.Rows.Count;
                for (int i = count - 1; i >= 0; i--)
                    dgv.Rows.RemoveAt(i);
                DataRow r = dtDestinationAccounts.NewRow();
                dtDestinationAccounts.Rows.Add(r);
                count = dgva.Rows.Count;
                for (int i = count - 1; i >= 0; i--)
                    dgva.Rows.RemoveAt(i);
                r = dtSourceAccounts.NewRow();
                dtSourceAccounts.Rows.Add(r);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void btn_SaveChanges_Click(object sender, EventArgs e)
        {
            //adaptertbAllocation.Update(dbAccountingProjectDS.GLAllocation);
            //adaptertbAllocationDestinationAccounts.Update(dbAccountingProjectDS.GLAllocationDestinationAccounts);
            //dbAccountingProjectDS.AcceptChanges();
            editToolStripMenuItem_Click(sender, e);

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                txt_AllocationCode.Focus();
                if (GeneralFunctions.ValidateString(txt_AllocationCode.Text, "Please Specify the Allocation Code")
                    && GeneralFunctions.ValidateString(txt_AllocationDescription.Text, "Please Specify the Allocation Description") && AccountNumberValidate(dgva.Rows[0].Cells[1].Value.ToString(), dgva.Rows[0].Cells[1].Value, out sourceAccountNumber)
                    && GeneralFunctions.ValidateComboBox(cb_GLJournalCodes, "Please Specify the appropriate Journal Code of the given Allocation Code")
                    && AccountNameTextValidate() && ValidateDestinationAccount() && ValidatePercentageValue())
                {

                    DataRow[] rArr = this.dbAccountingProjectDS.GLAllocation.Select("AllocationCode = '" + txt_AllocationCode.Text + "'");
                    if (rArr.Length != 0 && AllocationCodefind == txt_AllocationCode.Text)
                    {
                        for (int i = 0; i < dtSourceAccounts.Rows.Count - 1; i++)
                        {

                            rArr[i]["AllocationCode"] = txt_AllocationCode.Text;
                            rArr[i]["AllocationGLJournalCode"] = cb_GLJournalCodes.Text;
                            rArr[i]["AllocationDescription"] = txt_AllocationDescription.Text;
                            rArr[i]["AllocationSourceAccount"] = dtSourceAccounts.Rows[i]["AccountNumber"];
                            rArr[i]["AllocationSourceAccountName"] = dtSourceAccounts.Rows[i]["AccountName"];
                            rArr[i]["AllocationSourceAccountPercentage"] = dtSourceAccounts.Rows[i]["AccountPercentage"];
                            if (ChkRepeat.Checked == true)
                                rArr[i]["AllocationRepeat"] = "1";
                            else if (ChkRepeat.Checked == false)
                                rArr[i]["AllocationRepeat"] = "0";
                        }
                        EditDestinationAccount();
                        Allocationupdate();
                        MessageBox.Show("Allocation Record edited successfully");
                        load_allocation();
                        txt_AllocationCodeID.Text = currentAllocationID.ToString();
                        //ClearAll();
                        groupBox1.Enabled = false;
                        btnedit.Visible = true;
                        btn_SaveChanges.Visible = false;
                        btn_New.Enabled = true;
                        btndelete.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Can't Change AllocationCode", "General Ledger");
                    }
                }
                else
                {
                    MessageBox.Show("The given Allocation Code doesnt exist \n Cant perform edit operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
            finally
            {
                GeneralFunctions.UnLockTable("", "AllocationMaintenance", "", "Edit");

            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                txt_AllocationCode.Focus();
                if (GeneralFunctions.ValidateString(txt_AllocationCode.Text, "Please Specify the Allocation Code"))
                {
                    DataRow[] rArrAccounts;
                    DataRow[] rArr = dbAccountingProjectDS.GLAllocation.Select("AllocationCode = '" + txt_AllocationCode.Text + "'");
                    if (rArr.Length != 0)
                    {
                        for (int a = 0; a < rArr.Length; a++)
                        {
                            rArrAccounts = this.dbAccountingProjectDS.GLAllocationDestinationAccounts.Select("AllocationCode = '" + txt_AllocationCode.Text + "'");
                            for (int i = 0; i < rArrAccounts.Length; i++)
                            {
                                rArrAccounts[i].Delete();
                            }

                            rArr[a].Delete();
                        }
                        Allocationupdate();
                        MessageBox.Show("Allocation Record deleted successfully");
                        ClearAll();
                        btnedit.Enabled = false;
                        btndelete.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("The given Allocation Code doesnt exist \n Cant perform delete operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            currentRowIndex = e.RowIndex;
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex != -1 && e.RowIndex != -1)
            //    {
            //        if (dgv.CurrentRow.Cells[e.ColumnIndex].Value != null)
            //        {
            //            if (e.ColumnIndex == 1)
            //            {
            //                string accountNumber;
            //                GeneralFunctions.AccountNumberValidate(dgv.CurrentRow.Cells["AccountNumber"].Value.ToString(), out accountNumber);
            //                dgv.CurrentRow.Cells[1].Value = accountNumber;
            //                if (e.RowIndex == dtDestinationAccounts.Rows.Count - 1)
            //                {
            //                    DataRow r = dtDestinationAccounts.NewRow();
            //                    dtDestinationAccounts.Rows.Add(r);
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "General Ledger");
            //}
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                txt_AllocationCode.Focus();
                DataRow r;
                DataRow rs;
                if (GeneralFunctions.ValidateString(txt_AllocationCode.Text, "Please Specify the Allocation Code"))
                {
                    DataRow[] rArr = this.dbAccountingProjectDS.GLAllocation.Select("AllocationCode = '" + txt_AllocationCode.Text + "'");
                    if (rArr.Length != 0)
                    {
                        dtSourceAccounts.Rows.Clear();
                        for (int i = 0; i < rArr.Length; i++)
                        {
                            rs = dtSourceAccounts.NewRow();

                            txt_AllocationCodeID.Text = rArr[0]["AllocationCodeID"].ToString();
                            cb_GLJournalCodes.Text = rArr[0]["AllocationGLJournalCode"].ToString();
                            txt_AllocationDescription.Text = rArr[0]["AllocationDescription"].ToString();
                            rs["AccountNumber"] = rArr[i]["AllocationSourceAccount"];
                            rs["AccountName"] = rArr[i]["AllocationSourceAccountName"];
                            rs["AccountPercentage"] = rArr[i]["AllocationSourceAccountPercentage"];
                            rs["AllocationCode"] = txt_AllocationCode.Text;
                            AllocationCodefind = txt_AllocationCode.Text;
                            dtSourceAccounts.Rows.Add(rs);
                            rs.AcceptChanges();

                        }
                        rs = dtSourceAccounts.NewRow();
                        dtSourceAccounts.Rows.Add(rs);
                        dgva.DataSource = dtSourceAccounts.DefaultView;

                        DataRow[] rArrResult = this.dbAccountingProjectDS.GLAllocationDestinationAccounts.Select("AllocationCode = '" + txt_AllocationCode.Text + "'");
                        if (rArrResult.Length != 0)
                        {
                            dtDestinationAccounts.Rows.Clear();
                            for (int i = 0; i < rArrResult.Length; i++)
                            {
                                r = dtDestinationAccounts.NewRow();
                                r["AccountID"] = rArrResult[i]["AllocationDestinationID"];
                                r["AccountNumber"] = rArrResult[i]["DestinationGLAccountNumber"];
                                r["AccountName"] = rArrResult[i]["DestinationAccountDescription"];
                                r["AccountPercentage"] = rArrResult[i]["DestinationAccountPercentage"];
                                r["AllocationCode"] = txt_AllocationCode.Text;
                                dtDestinationAccounts.Rows.Add(r);
                                r.AcceptChanges();
                            }
                            r = dtDestinationAccounts.NewRow();
                            dtDestinationAccounts.Rows.Add(r);
                            dgv.DataSource = dtDestinationAccounts.DefaultView;
                        }
                    }
                    else
                        MessageBox.Show("The given allocation code couldnt be found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void dgv_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                
                dgv.EndEdit();

                //if (dgv.CurrentCell != null)
                //{
                //    if (dgv.CurrentCell.ColumnIndex == 1)
                //    {
                //        dgv.CurrentCell = dgv.Rows[currentRowIndex].Cells[2];
                //        return;
                //    }
                //    if (dgv.CurrentCell.ColumnIndex == 2)
                //    {
                //        dgv.CurrentCell = dgv.Rows[currentRowIndex].Cells[3];
                //        return;
                //    }
                //    if (dgv.CurrentCell.ColumnIndex == 3)
                //    {
                //        if (dgv.Rows.Count > currentRowIndex + 1)
                //        {
                //            dgv.CurrentCell = dgv.Rows[currentRowIndex + 1].Cells[1];
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void cb_GLJournalCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb_GLJournalCodes.Text == "<new>")
                {
                    GLJournalCodes jc = new GLJournalCodes();
                    jc.ShowDialog();
                    cb_GLJournalCodes.Items.Clear();
                    adaptertbGLJournalCodes.Fill(dbAccountingProjectDS.GLJournalCodes);
                    cb_GLJournalCodes = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLJournalCodes, cb_GLJournalCodes, "JournalCode", "JournalCodeID");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            ClearAll();
            groupBox1.Enabled = true;
            btn_New.Visible = false;
            btnnew.Visible = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                {
                    DataRow[] rArr;
                    if (dgv.Rows[currentRowIndex].Cells["AccountID"].Value.ToString() != "")
                    {
                        string accountID = dgv.Rows[currentRowIndex].Cells["AccountID"].Value.ToString();
                        rArr = dtDestinationAccounts.Select("AccountID = '" + accountID + "'");
                        if (rArr.Length > 0)
                        {
                            rArr[0].Delete();
                            rArr[0].AcceptChanges();
                        }
                        rArr = dbAccountingProjectDS.GLAllocationDestinationAccounts.Select("AllocationDestinationID = '" + accountID + "'");
                        if (rArr.Length > 0)
                            rArr[0].Delete();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void dgva_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (dgva.CurrentRow.Cells[0].Value.ToString() != "")
            //    {
            //        txt_SourceGLAccount.Text = dgva.CurrentRow.Cells[0].Value.ToString();
            //        txt_SourceAccountName.Text = dgva.CurrentRow.Cells[1].Value.ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "General Ledger");
            //}
        }

        private void dgva_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    if (e.RowIndex != 0)
                    {
                        if (dgva.Rows[e.RowIndex - 1].Cells[3].Value.ToString() == "")
                        {
                            MessageBox.Show("Please Insert AccountPercentage ", "General Ledger");
                            dgva.Rows[e.RowIndex - 1].Cells[3].Selected = true;
                            bool Sel = true;
                            dgva.BeginEdit(Sel);
                            return;
                        }
                    }
                        AccountSearch accSearch = new AccountSearch();
                        accSearch.filter = " AND AccountTypeName <> 'Header'";
                        accSearch.ShowDialog();

                        if (accSearch.selectedAccountName != null && accSearch.selectedAccountNumber != null)
                        {
                            string accnumber;
                            string accname;
                            accnumber = accSearch.selectedAccountNumber;
                            accname = accSearch.selectedAccountName;
                            //AccountNumberValidate(txt_SourceGLAccount.Text, txt_SourceGLAccount, out sourceAccountNumber);
                            dgva.CurrentRow.Cells["AccountNumber"].Value = accnumber;
                            dgva.CurrentRow.Cells["AccountName"].Value = accname;
                                if (e.ColumnIndex != -1 && e.RowIndex != -1)
                                {
                                    if (dgva.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                                    {
                                        if (e.ColumnIndex == 1)
                                        {
                                            string accountNumber;
                                            GeneralFunctions.AccountNumberValidate(dgva.CurrentRow.Cells["AccountNumber"].Value.ToString(), out accountNumber);
                                            dgva.CurrentRow.Cells[1].Value = accountNumber;
                                            if (e.RowIndex == dtSourceAccounts.Rows.Count - 1)
                                            {
                                                DataRow r = dtSourceAccounts.NewRow();
                                                dtSourceAccounts.Rows.Add(r);
                                                bool t = true;
                                                dgva.Rows[e.RowIndex].Cells["AccountPercentage"].Selected = true;
                                                dgva.BeginEdit(t);
                                            }
                                        }
                                    }
                                }
                            //rs = dtSourceAccounts.NewRow();
                            //dtSourceAccounts.Rows.Add(rs);
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    if (e.RowIndex != 0)
                    {
                        if (dgv.Rows[e.RowIndex - 1].Cells[3].Value.ToString() == "")
                        {
                            MessageBox.Show("Please Insert AccountPercentage ", "General Ledger");
                            dgv.Rows[e.RowIndex - 1].Cells[3].Selected = true;
                            bool Sel = true;
                            dgv.BeginEdit(Sel);

                            return;
                        }
                    }      
                    AccountSearch accSearch = new AccountSearch();
                    accSearch.filter = " AND AccountTypeName <> 'Header'";
                    accSearch.ShowDialog();
                        if (accSearch.selectedAccountName != null && accSearch.selectedAccountNumber != null)
                        {
                            //AccountNumberValidate(txt_SourceGLAccount.Text, txt_SourceGLAccount, out sourceAccountNumber);
                            string accnumber;
                            string accname;
                            accnumber = accSearch.selectedAccountNumber;
                            accname = accSearch.selectedAccountName;
                            dgv.CurrentRow.Cells["AccountNumber"].Value = accnumber;
                            dgv.CurrentRow.Cells["AccountName"].Value = accname;
                            if (e.ColumnIndex != -1 && e.RowIndex != -1)
                            {
                                if (dgv.CurrentRow.Cells[e.ColumnIndex].Value != null)
                                {
                                    if (e.ColumnIndex == 1)
                                    {
                                        string accountNumber;
                                        GeneralFunctions.AccountNumberValidate(dgv.CurrentRow.Cells["AccountNumber"].Value.ToString(), out accountNumber);
                                        dgv.CurrentRow.Cells[1].Value = accountNumber;
                                        if (e.RowIndex == dtDestinationAccounts.Rows.Count - 1)
                                        {
                                            DataRow r = dtDestinationAccounts.NewRow();
                                            dtDestinationAccounts.Rows.Add(r);
                                            bool t = true;
                                            dgv.Rows[e.RowIndex].Cells["AccountPercentage"].Selected = true;
                                            dgv.BeginEdit(t);

                                        }
                                    }
                                }
                            }

                            //r = dtDestinationAccounts.NewRow();
                            //dtDestinationAccounts.Rows.Add(r);
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }
        private void dgva_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex != -1 && e.RowIndex != -1)
            //    {
            //        if (dgva.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //        {
            //            if (e.ColumnIndex == 1)
            //            {
            //                string accountNumber;
            //                GeneralFunctions.AccountNumberValidate(dgva.CurrentRow.Cells["AccountNumber"].Value.ToString(), out accountNumber);
            //                dgva.CurrentRow.Cells[1].Value = accountNumber;
            //                if (e.RowIndex == dtSourceAccounts.Rows.Count - 1)
            //                {
            //                    DataRow r = dtSourceAccounts.NewRow();
            //                    dtSourceAccounts.Rows.Add(r);
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "General Ledger");
            //}
            this.Remaining_Percentage();

        }



        private void dgva_Leave(object sender, EventArgs e)
        {
            if (dgva.Rows.Count >1)
            {
                if (dgva.Rows[dgva.Rows.Count - 2].Cells[3].Value.ToString() == "")
                {
                    MessageBox.Show("Please Insert AccountPercentage ", "General Ledger");
                    dgva.Focus();
                    dgva.Rows[dgva.Rows.Count - 2].Cells[3].Selected = true;
                    bool Sel = true;
                    dgva.BeginEdit(Sel);

                }
            }

        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            insertToolStripMenuItem_Click(sender, e);
            load_allocation();

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            string msg = GeneralFunctions.CheckLockTables("GLAllocation", "AllocationMaintenance", txt_AllocationCode.Text, "Edit");
            if (msg != "")
            {
                MessageBox.Show("Can't Delete This Allocation Because Edit By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            msg = GeneralFunctions.CheckLockTables("", "Allocation Run", "", "Open");
            if (msg != "")
            {
                MessageBox.Show("Can't Delete This Allocation Because Allocation Run Open By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            GeneralFunctions.LockTables("GLAllocation", "AllocationMaintenance", txt_AllocationCode.Text, "Edit");
            DialogResult myrst;
            myrst = MessageBox.Show("Are You Sure Delete This Allocation", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return; 
            deleteToolStripMenuItem_Click(sender, e);
            load_allocation();
            GeneralFunctions.UnLockTable("", "AllocationMaintenance", "", "Edit");
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            findToolStripMenuItem_Click(sender, e);
        }

        private void txt_AllocationCode_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == 13)
            //    findToolStripMenuItem_Click(sender, e);
        }



        private void dgv_Leave(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1)
            {
                if (dgv.Rows[dgv.Rows.Count - 2].Cells[3].Value.ToString() == "")
                {
                    MessageBox.Show("Please Insert AccountPercentage ", "General Ledger");
                    dgv.Focus();
                    dgv.Rows[dgv.Rows.Count - 2].Cells[3].Selected = true;
                    bool Sel = true;
                    dgv.BeginEdit(Sel);
                }
            }
        }



        private void dgva_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                
                dgva.EndEdit();
                this.Remaining_Percentage();

                //if (dgva.CurrentCell != null)
                //{
                //    if (dgva.CurrentCell.ColumnIndex == 1)
                //    {
                //        dgva.CurrentCell = dgva.Rows[dgva.CurrentRow.Index].Cells[3];
                //        return;
                //    }
                //    if (dgva.CurrentCell.ColumnIndex == 3)
                //    {
                //        dgva.CurrentCell = dgva.Rows[dgva.CurrentRow.Index].Cells[3];
                //        return;
                //    }
                //    if (dgva.CurrentCell.ColumnIndex == 4)
                //    {
                //        if (dgva.Rows.Count > dgva.CurrentRow.Index + 1)
                //        {
                //            dgva.CurrentCell = dgva.Rows[dgva.CurrentRow.Index + 1].Cells[1];
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }



        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && dgv.Rows[e.RowIndex].Cells[1].Value.ToString() != "")
            {
                DataRow[] drs = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + dgv.CurrentCell.Value.ToString() + "'");
                if (drs.Length != 0)
                {
                    dgv.CurrentRow.Cells["AccountNumber"].Value = drs[0]["AccountNumber"].ToString();
                    dgv.CurrentRow.Cells["AccountName"].Value = drs[0]["AccountName"].ToString();
                    if (e.RowIndex == dtDestinationAccounts.Rows.Count - 1)
                    {
                        DataRow r = dtDestinationAccounts.NewRow();
                        dtDestinationAccounts.Rows.Add(r);
                        bool t = true;
                        dgv.Rows[e.RowIndex].Cells["AccountPercentage"].Selected = true;
                        dgv.BeginEdit(t);

                    }
                    //dgv.CurrentRow.Cells[3].Selected = true;
                    //bool Sel = true;
                    //dgv.BeginEdit(Sel);

                }
                else
                {
                    MessageBox.Show("Can't Find This Account Or This AccountType Is Header", "Error");
                    for (int c = 0; c < dgv.ColumnCount; c++)
                    {
                        dgv.CurrentRow.Cells[c].Value = DBNull.Value;
                    }
                    if (e.RowIndex != dtDestinationAccounts.Rows.Count - 1)
                    {
                        dtDestinationAccounts.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }




        private void dgva_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && dgva.Rows[e.RowIndex].Cells[1].Value.ToString() != "")
            {
                DataRow[] drs = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + dgva.CurrentCell.Value.ToString() + "'");
                if (drs.Length != 0)
                {
                    dgva.CurrentRow.Cells["AccountNumber"].Value = drs[0]["AccountNumber"].ToString();
                    dgva.CurrentRow.Cells["AccountName"].Value = drs[0]["AccountName"].ToString();
                    if (e.RowIndex == dtSourceAccounts.Rows.Count - 1)
                    {
                        DataRow r = dtSourceAccounts.NewRow();
                        dtSourceAccounts.Rows.Add(r);
                        bool t = true;
                        dgva.Rows[e.RowIndex].Cells["AccountPercentage"].Selected = true;
                        dgva.BeginEdit(t);
                    }
                    //dgva.CurrentRow.Cells[3].Selected = true;
                    //bool Sel = true;
                    //dgva.BeginEdit(Sel);

                }
                else
                {
                    MessageBox.Show("Can't Find This Account Or This AccountType Is Header", "Error");
                    for (int c = 0; c < dgva.ColumnCount; c++)
                    {
                        dgva.CurrentRow.Cells[c].Value = DBNull.Value;
                    }
                    if (e.RowIndex != dtSourceAccounts.Rows.Count - 1)
                    {
                        dtSourceAccounts.Rows.RemoveAt(e.RowIndex);
                    }

                }
            }
            this.Remaining_Percentage();
        }

        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dgv_Control_KeyPress);

            e.Control.KeyPress += new KeyPressEventHandler(dgv_Control_KeyPress);

        }
        private void dgv_Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgv.CurrentCell.ColumnIndex == 4)
            {
                if (e.KeyChar == 8)
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
                else if (e.KeyChar == 46)
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

        private void dgva_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dgva_Control_KeyPress);

            e.Control.KeyPress += new KeyPressEventHandler(dgva_Control_KeyPress);

        }
        private void dgva_Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgva.CurrentCell.ColumnIndex == 4)
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                }
                else if (e.KeyChar >= 48 && e.KeyChar <= 57)
                {
                    if (dgva.EditingControl.Text.ToString().Contains("."))
                    {
                        char c = '.';
                        string[] sc = dgva.EditingControl.Text.ToString().Split(c);

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
                    if (dgva.EditingControl.Text.ToString().Contains(".") == false)
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

        private void dgvallocation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (groupBox1.Enabled == true)
                {
                    DialogResult myrst;
                    myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (myrst == DialogResult.No)
                        return;
                }
                btnundo_Click("NO", e);
                if (dgvallocation.CurrentCell.Value.ToString() != "")
                {
                    DataRow r;
                    DataRow rs;
                    if (GeneralFunctions.ValidateString(dgvallocation.CurrentRow.Cells[0].Value.ToString(), "Please Specify the Allocation Code"))
                    {
                        txt_AllocationCode.Text = dgvallocation.CurrentRow.Cells[0].Value.ToString();
                        DataRow[] rArr = this.dbAccountingProjectDS.GLAllocation.Select("AllocationCode = '" + dgvallocation.CurrentRow.Cells[0].Value.ToString() + "'");
                        if (rArr.Length != 0)
                        {
                            DataGridViewMaskedTextColumn accformats = new DataGridViewMaskedTextColumn(AccountNumberFormat);
                            accformats.DataPropertyName = "AccountNumber";
                            accformats.HeaderText = "AccountNumber";     //  German text
                            accformats.Name = "AccountNumber";
                            accformats.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                            accformats.Width = 75;
                            DataGridViewMaskedTextColumn accformatd = new DataGridViewMaskedTextColumn(AccountNumberFormat);
                            accformatd.DataPropertyName = "AccountNumber";
                            accformatd.HeaderText = "AccountNumber";     //  German text
                            accformatd.Name = "AccountNumber";
                            accformatd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                            accformatd.Width = 75;
                            dtSourceAccounts.Rows.Clear();
                            for (int i = 0; i < rArr.Length; i++)
                            {
                                rs = dtSourceAccounts.NewRow();

                                txt_AllocationCodeID.Text = rArr[0]["AllocationCodeID"].ToString();
                                cb_GLJournalCodes.Text = rArr[0]["AllocationGLJournalCode"].ToString();
                                txt_AllocationDescription.Text = rArr[0]["AllocationDescription"].ToString();
                                if (rArr[0]["AllocationRepeat"].ToString() == "1")
                                   ChkRepeat.Checked = true ;
                                else if (rArr[0]["AllocationRepeat"].ToString() == "0")
                                    ChkRepeat.Checked = false;
                                rs["AccountNumber"] = rArr[i]["AllocationSourceAccount"];
                                rs["AccountName"] = rArr[i]["AllocationSourceAccountName"];
                                rs["AccountPercentage"] = rArr[i]["AllocationSourceAccountPercentage"];
                                rs["AllocationCode"] = txt_AllocationCode.Text;
                                AllocationCodefind = txt_AllocationCode.Text;
                                dtSourceAccounts.Rows.Add(rs);
                                rs.AcceptChanges();

                            }
                            rs = dtSourceAccounts.NewRow();
                            dtSourceAccounts.Rows.Add(rs);
                            dgva.DataSource = dtSourceAccounts.DefaultView;
                            dgva.Columns.Insert(1, accformats);
                            dgva.Columns[2].Visible = false;
                            for (int i = 0; i < dgva.RowCount; i++)
                            {
                                if (dgva.Rows[i].Cells[2].Value.ToString() != "")
                                    dgva.Rows[i].Cells[1].Value = dgva.Rows[i].Cells[2].Value.ToString();
                            }
                            DataRow[] rArrResult = this.dbAccountingProjectDS.GLAllocationDestinationAccounts.Select("AllocationCode = '" + dgvallocation.CurrentRow.Cells[0].Value.ToString() + "'");
                            if (rArrResult.Length != 0)
                            {
                                dtDestinationAccounts.Rows.Clear();
                                for (int i = 0; i < rArrResult.Length; i++)
                                {
                                    r = dtDestinationAccounts.NewRow();
                                    r["AccountID"] = rArrResult[i]["AllocationDestinationID"];
                                    r["AccountNumber"] = rArrResult[i]["DestinationGLAccountNumber"];
                                    r["AccountName"] = rArrResult[i]["DestinationAccountDescription"];
                                    r["AccountPercentage"] = rArrResult[i]["DestinationAccountPercentage"];
                                    r["AllocationCode"] = txt_AllocationCode.Text;
                                    dtDestinationAccounts.Rows.Add(r);
                                    r.AcceptChanges();
                                }
                                r = dtDestinationAccounts.NewRow();
                                dtDestinationAccounts.Rows.Add(r);
                                dgv.DataSource = dtDestinationAccounts.DefaultView;
                                dgv.Columns.Insert(1, accformatd);
                                dgv.Columns[2].Visible = false;
                                for (int i = 0; i < dgv.RowCount; i++)
                                {
                                    if (dgv.Rows[i].Cells[2].Value.ToString() != "")
                                        dgv.Rows[i].Cells[1].Value = dgv.Rows[i].Cells[2].Value.ToString();
                                }
                            }
                            else
                            {
                                dtDestinationAccounts.Rows.Clear();
                                r = dtDestinationAccounts.NewRow();
                                dtDestinationAccounts.Rows.Add(r);
                            }
                        }
                        else
                            MessageBox.Show("The given allocation code couldnt be found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                groupBox1.Enabled = false;
                btndelete.Enabled = true;
                btnedit.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        
        }

        private void btnundo_Click(object sender, EventArgs e)
        {
            if (sender.ToString() !=  "NO")
            {
                if (groupBox1.Enabled == true)
                {
                    DialogResult myrst;
                    myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (myrst == DialogResult.No)
                        return;
                    load_allocation();
                }
            }
            ClearAll();
            btn_New.Visible = true;
            btnnew.Visible = false;
            btnedit.Visible = true;
            btn_SaveChanges.Visible = false;
            groupBox1.Enabled = false;
            btn_New.Enabled = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
            GeneralFunctions.UnLockTable("", "AllocationMaintenance", "", "Edit");
            GeneralFunctions.UnLockTable("", "AllocationMaintenance", "", "New");

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (groupBox1.Enabled == true)
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
            string msg = GeneralFunctions.CheckLockTables("GLAllocation", "AllocationMaintenance", txt_AllocationCode.Text, "Edit");
            if (msg != "")
            {
                MessageBox.Show("Can't Edit This Allocation Because Edit By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            msg = GeneralFunctions.CheckLockTables("", "Allocation Run", "", "Open");
            if (msg != "")
            {
                MessageBox.Show("Can't Edit This Allocation Because Allocation Run Open By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            GeneralFunctions.LockTables("GLAllocation", "AllocationMaintenance", txt_AllocationCode.Text, "Edit");
            groupBox1.Enabled = true;
            btnedit.Visible = false;
            btn_SaveChanges.Visible = true;
            btn_New.Enabled = false;
            btndelete.Enabled = false;
        }


        private void load_allocation()
        {
            adaptertbAllocation = new SqlDataAdapter("Select distinct(AllocationCode) from GLAllocation", sqlcon);
            dtallocation = new DataTable();
            adaptertbAllocation.Fill(dtallocation);
            dbAccountingProjectDS.GLAllocationDestinationAccounts.Clear();
            adaptertbAllocationDestinationAccounts = new SqlDataAdapter("Select * from GLAllocationDestinationAccounts", sqlcon);
            adaptertbAllocationDestinationAccounts.Fill(dbAccountingProjectDS.GLAllocationDestinationAccounts);
            ArrayList allcode = new ArrayList();
            for (int i = 0; i < dtallocation.Rows.Count; i++)
            {
                allcode.Add(dtallocation.Rows[i][0].ToString());
            }
            dbAccountingProjectDS.GLAllocation.Clear();
            adaptertbAllocation = new SqlDataAdapter("Select * from GLAllocation", sqlcon);
            adaptertbAllocation.Fill(dbAccountingProjectDS.GLAllocation);
            dtallocation = new DataTable();
            dtallocation.Columns.Add("Code", System.Type.GetType("System.String"));
            dtallocation.Columns.Add("Journal", System.Type.GetType("System.String"));
            dtallocation.Columns.Add("Description", System.Type.GetType("System.String"));
            DataRow drm;
            DataRow[] drs;
            for (int i = 0; i < allcode.Count; i++)
            {
                drs = dbAccountingProjectDS.GLAllocation.Select("AllocationCode = '" + allcode[i].ToString() + "'");
                if (drs.Length != 0)
                {
                    drm = dtallocation.NewRow();
                    drm["Code"] = drs[0]["AllocationCode"];
                    drm["Journal"] = drs[0]["AllocationGLJournalCode"];
                    drm["Description"] = drs[0]["AllocationDescription"];
                    dtallocation.Rows.Add(drm);
                }
            }

            dgvallocation.DataSource = dtallocation;
            dgvallocation.Refresh();
            this.dgvallocation.Columns["Code"].HeaderText = obj_interface_language.DGVCode;
            this.dgvallocation.Columns["Journal"].HeaderText = obj_interface_language.DGVJournal;
            this.dgvallocation.Columns["Description"].HeaderText = obj_interface_language.DGVDescription;

        }

 

        private void txt_AllocationCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
 
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Remaining_Percentage();

        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Remaining_Percentage();
        }

        private void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //Remaining_Percentage();
        }

        private void dgv_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void AllocationMaintenance_MouseMove(object sender, MouseEventArgs e)
        {
            this.Remaining_Percentage();

        }

        private void dgvallocation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AllocationMaintenance_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralFunctions.UnLockTable("", "AllocationMaintenance", "", "");
            GeneralFunctions.UnLockTable("", "AllocationMaintenance", "", "");

        }

        private void groupBox1_EnabledChanged(object sender, EventArgs e)
        {
            if (groupBox1.Enabled == true)
                dgvallocation.Enabled = false;
            else
                dgvallocation.Enabled = true;
        }




    }
}