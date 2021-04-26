using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Accounting_GeneralLedger {
    public partial class AccountTypes : Form {
        private string selectedAccountTypeClassification = "";
        private SqlConnection sqlcon;
        private SqlDataAdapter adapter;
        private SqlCommandBuilder cmdBuilder;
        private int currentAccountTypeID;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;

        public AccountTypes() {
            InitializeComponent();
        }

        private void AccountTypes_Load(object sender, EventArgs e) {

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adapter = new SqlDataAdapter("Select * from GLAccountTypes", sqlcon);

            cmdBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(dbAccountingProjectDS.GLAccountTypes);
            dvg.ClearSelection();
            SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon2.Open();
            SqlCommand GetAccountID = new SqlCommand("Select MAX(AccountTypeID)+1 From GLAccountTypes", sqlcon2);
            if (GetAccountID.ExecuteScalar() != DBNull.Value) {
                GeneralFunctions.AccountTypeID = Convert.ToInt32(GetAccountID.ExecuteScalar());
            }
            else
                GeneralFunctions.AccountTypeID = 1;
            currentAccountTypeID = GeneralFunctions.AccountTypeID;
            txt_AccountTypeID.Text = currentAccountTypeID.ToString();

            if (GeneralFunctions.languagechioce != "") {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }
        }

        private void update_language_interface() {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.formAccountsTypes;
            this.dvg.Columns[0].HeaderText = obj_interface_language.dgvAccountTypesColumn1.ToString();
            this.dvg.Columns[1].HeaderText = obj_interface_language.dgvAccountTypesColumn2.ToString();
            this.btnNew.Text = obj_interface_language.buttonbtnNew;
            this.btnEdit.Text = obj_interface_language.buttonbtnEdit;
            this.btnDelete.Text = obj_interface_language.buttonbtnDelete;
            this.btnUndo.Text = obj_interface_language.buttonbtnUndo;
            this.btnExit.Text = obj_interface_language.buttonCompanyExit;
            this.label1.Text = obj_interface_language.labelAccountTypeName;
            this.label2.Text = obj_interface_language.labelAccountTypeID;
            this.groupBox1.Text = obj_interface_language.groupboxAccountTypeClassifications;
            this.checkBox_credit.Text = obj_interface_language.checkbox_credit;
            this.checkBox_Debit.Text = obj_interface_language.checkbox_debit;
            this.checkBox_other.Text = obj_interface_language.checkbox_other;


        }
        private void insertToolStripMenuItem_Click(object sender, EventArgs e) {
            if (selectedAccountTypeClassification == "" || !GeneralFunctions.ValidateString(txt_AccountTypeName.Text, "Please Specify the Account Type Name")) {
                MessageBox.Show("Please Enter a valid account type and Select the classification of the given account type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select AccountTypeID from GLAccountTypes where AccountTypeID = '" + txt_AccountTypeID.Text + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("AccountTypeID = '" + txt_AccountTypeID.Text + "'", dbAccountingProjectDS.GLAccountTypes)) {
                    DataRow r = dbAccountingProjectDS.GLAccountTypes.NewRow();
                    r["AccountTypeID"] = currentAccountTypeID;
                    GeneralFunctions.AccountTypeID++;
                    r["AccountTypeName"] = txt_AccountTypeName.Text;
                    r["AccountTypeClassification"] = selectedAccountTypeClassification;
                    dbAccountingProjectDS.GLAccountTypes.Rows.Add(r);
                    txt_AccountTypeName.Text = "";
                    currentAccountTypeID = GeneralFunctions.AccountTypeID;
                    txt_AccountTypeID.Text = currentAccountTypeID.ToString();
                    UnCheckAll();
                    dr.Close();
                    sqlcon.Close();
                }
                else {
                    if (DialogResult.OK == MessageBox.Show("The given Account Type already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel)) {
                        DataRow[] rArr = dbAccountingProjectDS.GLAccountTypes.Select("AccountTypeID = '" + txt_AccountTypeID.Text + "'");
                        rArr[0]["AccountTypeName"] = txt_AccountTypeName.Text;
                        rArr[0]["AccountTypeClassification"] = selectedAccountTypeClassification;
                        txt_AccountTypeName.Text = "";
                        txt_AccountTypeID.Text = currentAccountTypeID.ToString();
                        UnCheckAll();
                    }
                    else {
                        txt_AccountTypeName.Text = "";
                        txt_AccountTypeID.Text = currentAccountTypeID.ToString();
                        UnCheckAll();
                    }
                    sqlcon.Close();
                    dr.Close();
                }
            }
            adapter.Update(dbAccountingProjectDS.GLAccountTypes);
            dbAccountingProjectDS.AcceptChanges();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            if (selectedAccountTypeClassification == "" || !GeneralFunctions.ValidateString(txt_AccountTypeName.Text, "Please Specify the Account Type Name")) {
                MessageBox.Show("Please Enter a valid account type and Select the classification of the given account type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                if (dvg.SelectedRows.Count > 0) {
                    DataRow[] rArr = dbAccountingProjectDS.GLAccountTypes.Select("AccountTypeID = '" + txt_AccountTypeID.Text + "'");
                    rArr[0]["AccountTypeName"] = txt_AccountTypeName.Text;
                    rArr[0]["AccountTypeClassification"] = selectedAccountTypeClassification;
                    dvg.ClearSelection();
                    txt_AccountTypeName.Text = "";
                    txt_AccountTypeID.Text = currentAccountTypeID.ToString();
                    UnCheckAll();
                }
                else {
                    MessageBox.Show("Please Select the row that you want to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            adapter.Update(dbAccountingProjectDS.GLAccountTypes);
            dbAccountingProjectDS.AcceptChanges();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            if (dvg.SelectedRows.Count > 0) {
                dbAccountingProjectDS.GLAccountTypes.Rows[dvg.SelectedRows[0].Index].Delete();
                txt_AccountTypeName.Text = "";
                txt_AccountTypeID.Text = currentAccountTypeID.ToString();
                UnCheckAll();
            }
            else {
                if (txt_AccountTypeName.Text != "" && GeneralFunctions.ValidateString(txt_AccountTypeName.Text, "Please Specify the Account Type Name")) {
                    DataRow[] rArr = dbAccountingProjectDS.GLAccountTypes.Select("AccountTypeID = '" + txt_AccountTypeID.Text + "'");
                    if (rArr.Length != 0) {
                        rArr[0].Delete();
                        txt_AccountTypeName.Text = "";
                        txt_AccountTypeID.Text = currentAccountTypeID.ToString();
                        UnCheckAll();
                    }
                    else {
                        MessageBox.Show("The given Journal Code doesnt exist \n Cant perform delete operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            dvg.ClearSelection();
            adapter.Update(dbAccountingProjectDS.GLAccountTypes);
            dbAccountingProjectDS.AcceptChanges();
        }

        private void checkBox_credit_CheckedChanged(object sender, EventArgs e) {
            if (checkBox_credit.Checked) {
                selectedAccountTypeClassification = "credit";
                checkBox_Debit.Checked = false;
                checkBox_other.Checked = false;
            }
        }

        private void checkBox_Debit_CheckedChanged(object sender, EventArgs e) {
            if (checkBox_Debit.Checked) {
                selectedAccountTypeClassification = "debit";
                checkBox_credit.Checked = false;
                checkBox_other.Checked = false;
            }
        }

        private void checkBox_other_CheckedChanged(object sender, EventArgs e) {
            if (checkBox_other.Checked) {
                selectedAccountTypeClassification = "other";
                checkBox_credit.Checked = false;
                checkBox_Debit.Checked = false;
            }
        }

        private void UnCheckAll() {
            checkBox_credit.Checked = false;
            checkBox_Debit.Checked = false;
            checkBox_other.Checked = false;
        }

        private void btn_SaveChanges_Click(object sender, EventArgs e) {
            adapter.Update(dbAccountingProjectDS.GLAccountTypes);
            dbAccountingProjectDS.AcceptChanges();
        }

        private void dvg_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (dvg.SelectedRows.Count > 0) {
                DataRow r = dbAccountingProjectDS.GLAccountTypes.Rows[dvg.SelectedRows[0].Index];
                txt_AccountTypeID.Text = r["AccountTypeID"].ToString();
                txt_AccountTypeName.Text = r["AccountTypeName"].ToString();
                if (r["AccountTypeClassification"].ToString() == "credit")
                    checkBox_credit.Checked = true;
                else if (r["AccountTypeClassification"].ToString() == "debit")
                    checkBox_Debit.Checked = true;
                else if (r["AccountTypeClassification"].ToString() == "other")
                    checkBox_other.Checked = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnNew.Enabled = false;
            }

            btnNew.Enabled = false;
        }

        private void btn_New_Click(object sender, EventArgs e) {
            SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon2.Open();
            SqlCommand GetAccountID = new SqlCommand("Select MAX(AccountTypeID)+1 From GLAccountTypes", sqlcon2);
            if (GetAccountID.ExecuteScalar() != DBNull.Value) {
                GeneralFunctions.AccountTypeID = Convert.ToInt32(GetAccountID.ExecuteScalar());
            }
            else
                GeneralFunctions.AccountTypeID = 1;
            currentAccountTypeID = GeneralFunctions.AccountTypeID;
            txt_AccountTypeID.Text = currentAccountTypeID.ToString();
            txt_AccountTypeName.Text = "";
            UnCheckAll();
        }

        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnUndo_Click(object sender, EventArgs e) {
            if (btnUndo.Text == "Undo") {
                btnDelete.Text = "Delete";
                btnEdit.Text = "Edit";
                btnNew.Text = "New";
            }
            else if (btnUndo.Text == "ÊÑÇÌÚ") {
                btnDelete.Text = "ÍÐÝ";
                btnEdit.Text = "ÊÚÏíá";
                btnNew.Text = "ÌÏíÏ";
            }
            SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon2.Open();
            SqlCommand GetAccountID = new SqlCommand("Select MAX(AccountTypeID)+1 From GLAccountTypes", sqlcon2);
            if (GetAccountID.ExecuteScalar() != DBNull.Value) {
                GeneralFunctions.AccountTypeID = Convert.ToInt32(GetAccountID.ExecuteScalar());
            }
            else
                GeneralFunctions.AccountTypeID = 1;
            currentAccountTypeID = GeneralFunctions.AccountTypeID;
            txt_AccountTypeID.Text = currentAccountTypeID.ToString();
            UnCheckAll();

            dvg.ClearSelection();
            txt_AccountTypeName.Text = "";
            btnNew.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            dvg.Enabled = true;

            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void btnNew_Click(object sender, EventArgs e) {
            if (btnNew.Text == "New" || btnNew.Text == "ÌÏíÏ") {
                if (btnNew.Text == "New")
                    btnNew.Text = "Save";
                else if (btnNew.Text == "ÌÏíÏ")
                    btnNew.Text = "ÍÝÙ";
                SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlcon2.Open();
                SqlCommand GetAccountID = new SqlCommand("Select MAX(AccountTypeID)+1 From GLAccountTypes", sqlcon2);
                if (GetAccountID.ExecuteScalar() != DBNull.Value) {
                    //if 
                    GeneralFunctions.AccountTypeID = Convert.ToInt32(GetAccountID.ExecuteScalar());
                }
                else
                    GeneralFunctions.AccountTypeID = 1;
                currentAccountTypeID = GeneralFunctions.AccountTypeID;
                txt_AccountTypeID.Text = currentAccountTypeID.ToString();
                txt_AccountTypeName.Text = "";
                UnCheckAll();
                dvg.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
            else if (btnNew.Text == "Save" || btnNew.Text == "ÍÝÙ") {
                if (selectedAccountTypeClassification == "" || !GeneralFunctions.ValidateString(txt_AccountTypeName.Text, "Please Specify the Account Type Name")) {
                    MessageBox.Show("Please Enter a valid account type and Select the classification of the given account type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    sqlcon.Open();
                    SqlCommand cmdSelect = new SqlCommand("Select AccountTypeID from GLAccountTypes where AccountTypeID = '" + txt_AccountTypeID.Text + "'", sqlcon);
                    SqlDataReader dr = cmdSelect.ExecuteReader();
                    if (!dr.HasRows && !GeneralFunctions.FindRow("AccountTypeID = '" + txt_AccountTypeID.Text + "'", dbAccountingProjectDS.GLAccountTypes)) {
                        DataRow r = dbAccountingProjectDS.GLAccountTypes.NewRow();
                        r["AccountTypeID"] = currentAccountTypeID;
                        GeneralFunctions.AccountTypeID++;
                        r["AccountTypeName"] = txt_AccountTypeName.Text;
                        r["AccountTypeClassification"] = selectedAccountTypeClassification;
                        dbAccountingProjectDS.GLAccountTypes.Rows.Add(r);
                        txt_AccountTypeName.Text = "";
                        currentAccountTypeID = GeneralFunctions.AccountTypeID;
                        txt_AccountTypeID.Text = currentAccountTypeID.ToString();
                        UnCheckAll();
                        dr.Close();
                        sqlcon.Close();

                        btnDelete.Enabled = false;
                        btnEdit.Enabled = false;
                    }
                    else {
                        if (DialogResult.OK == MessageBox.Show("The given Account Type already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel)) {
                            DataRow[] rArr = dbAccountingProjectDS.GLAccountTypes.Select("AccountTypeID = '" + txt_AccountTypeID.Text + "'");
                            rArr[0]["AccountTypeName"] = txt_AccountTypeName.Text;
                            rArr[0]["AccountTypeClassification"] = selectedAccountTypeClassification;
                            txt_AccountTypeName.Text = "";
                            txt_AccountTypeID.Text = currentAccountTypeID.ToString();
                            UnCheckAll();
                        }
                        else {
                            txt_AccountTypeName.Text = "";
                            txt_AccountTypeID.Text = currentAccountTypeID.ToString();
                            UnCheckAll();
                        }
                        sqlcon.Close();
                        dr.Close();
                    }
                }
                adapter.Update(dbAccountingProjectDS.GLAccountTypes);
                dbAccountingProjectDS.AcceptChanges();
                if (btnNew.Text == "Save")
                    btnNew.Text = "New";
                else if (btnNew.Text == "ÍÝÙ")
                    btnNew.Text = "ÌÏíÏ";
                SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlcon3.Open();
                SqlCommand GetAccountID3 = new SqlCommand("Select MAX(AccountTypeID)+1 From GLAccountTypes", sqlcon3);
                if (GetAccountID3.ExecuteScalar() != DBNull.Value) {
                    //if 
                    GeneralFunctions.AccountTypeID = Convert.ToInt32(GetAccountID3.ExecuteScalar());
                }
                else
                    GeneralFunctions.AccountTypeID = 1;
                currentAccountTypeID = GeneralFunctions.AccountTypeID;
                txt_AccountTypeID.Text = currentAccountTypeID.ToString();
                txt_AccountTypeName.Text = "";
                UnCheckAll();
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                dvg.Enabled = true;

                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
           
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            if (btnEdit.Text == "Edit" || btnEdit.Text == "ÊÚÏíá") {
                if (btnEdit.Text == "Edit")
                    btnEdit.Text = "Save";
                else if (btnEdit.Text == "ÊÚÏíá")
                    btnEdit.Text = "ÍÝÙ";
                btnNew.Enabled = false;
                btnDelete.Enabled = false;
                dvg.Enabled = false;
                btnNew.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (btnEdit.Text == "Save" || btnEdit.Text == "ÍÝÙ") {

                if (selectedAccountTypeClassification == "" || !GeneralFunctions.ValidateString(txt_AccountTypeName.Text, "Please Specify the Account Type Name")) {
                    MessageBox.Show("Please Enter a valid account type and Select the classification of the given account type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    if (dvg.SelectedRows.Count > 0) {
                        DataRow[] rArr = dbAccountingProjectDS.GLAccountTypes.Select("AccountTypeID = '" + txt_AccountTypeID.Text + "'");
                        rArr[0]["AccountTypeName"] = txt_AccountTypeName.Text;
                        rArr[0]["AccountTypeClassification"] = selectedAccountTypeClassification;
                        dvg.ClearSelection();
                        txt_AccountTypeName.Text = "";
                        txt_AccountTypeID.Text = currentAccountTypeID.ToString();
                        UnCheckAll();
                    }
                    else {
                        MessageBox.Show("Please Select the row that you want to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                adapter.Update(dbAccountingProjectDS.GLAccountTypes);
                dbAccountingProjectDS.AcceptChanges();
                SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlcon3.Open();
                SqlCommand GetAccountID3 = new SqlCommand("Select MAX(AccountTypeID)+1 From GLAccountTypes", sqlcon3);
                if (GetAccountID3.ExecuteScalar() != DBNull.Value) {
                    //if 
                    GeneralFunctions.AccountTypeID = Convert.ToInt32(GetAccountID3.ExecuteScalar());
                }
                else
                    GeneralFunctions.AccountTypeID = 1;
                currentAccountTypeID = GeneralFunctions.AccountTypeID;
                txt_AccountTypeID.Text = currentAccountTypeID.ToString();
                txt_AccountTypeName.Text = "";
                if (btnEdit.Text == "Save")
                    btnEdit.Text = "Edit";
                else if (btnEdit.Text == "ÍÝÙ")
                    btnEdit.Text = "ÊÚÏíá";
                UnCheckAll();
                btnNew.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                dvg.Enabled = true;
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (btnDelete.Text == "Delete" || btnDelete.Text == "ÍÐÝ") {
                if (btnDelete.Text == "Delete")
                    btnDelete.Text = "Save";
                else if (btnDelete.Text == "ÍÐÝ")
                    btnDelete.Text = "ÍÝÙ";
                btnEdit.Enabled = false;
                btnNew.Enabled = false;
                dvg.Enabled = false;
                btnEdit.Enabled = false;
                btnNew.Enabled = false;
            }
            else if (btnDelete.Text == "Save" || btnDelete.Text == "ÍÝÙ") {
                SqlConnection sqlcheckFoundConnection = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand sqlcheckCommand;
                sqlcheckFoundConnection.Open();
                sqlcheckCommand = new SqlCommand("Select AccountTypeName From GLAccounts Where AccountTypeName='" + txt_AccountTypeName.Text + "'", sqlcheckFoundConnection);
                SqlDataReader sqlRead = sqlcheckCommand.ExecuteReader();
                if (!sqlRead.HasRows) {
                    ConfirmDelete();
                }
                else {
                    if (DialogResult.Yes == MessageBox.Show("Are you sure to delete this type from Database?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) {
                        if (DialogResult.OK == MessageBox.Show("This will affect many data related to this Account type ,Press Ok to confirm", "Help", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)) {
                            if (DialogResult.OK == MessageBox.Show("This will Damage many Accounts related to this Type ,Press Ok to confirm", "Stop", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop)) {
                                SqlConnection deleteConnection = new SqlConnection(GeneralFunctions.ConnectionString);
                                SqlCommand deleteCommand;
                                deleteConnection.Open();
                                int x = 0;
                                deleteCommand = new SqlCommand("Delete From GLAccounts Where AccountTypeName='" + txt_AccountTypeName.Text + "'", deleteConnection);
                                x += deleteCommand.ExecuteNonQuery();
                                ConfirmDelete();
                            }
                            else
                                return;
                        }
                    }
                }
            }
            
        }
        private void ConfirmDelete() {
            if (dvg.SelectedRows.Count > 0) {
                dbAccountingProjectDS.GLAccountTypes.Rows[dvg.SelectedRows[0].Index].Delete();
                txt_AccountTypeName.Text = "";
                txt_AccountTypeID.Text = currentAccountTypeID.ToString();
                UnCheckAll();
            }
            else {
                if (txt_AccountTypeName.Text != "" && GeneralFunctions.ValidateString(txt_AccountTypeName.Text, "Please Specify the Account Type Name")) {
                    DataRow[] rArr = dbAccountingProjectDS.GLAccountTypes.Select("AccountTypeID = '" + txt_AccountTypeID.Text + "'");
                    if (rArr.Length != 0) {
                        rArr[0].Delete();
                        txt_AccountTypeName.Text = "";
                        txt_AccountTypeID.Text = currentAccountTypeID.ToString();
                        UnCheckAll();
                    }
                    else {
                        MessageBox.Show("The given Journal Code doesnt exist \n Cant perform delete operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            dvg.ClearSelection();
            adapter.Update(dbAccountingProjectDS.GLAccountTypes);
            dbAccountingProjectDS.AcceptChanges();
            if (btnDelete.Text == "Save")
                btnDelete.Text = "Delete";
            else if (btnDelete.Text == "ÍÝÙ")
                btnDelete.Text = "ÍÐÝ";
            SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon3.Open();
            SqlCommand GetAccountID3 = new SqlCommand("Select MAX(AccountTypeID)+1 From GLAccountTypes", sqlcon3);
            if (GetAccountID3.ExecuteScalar() != DBNull.Value) {
                //if 
                GeneralFunctions.AccountTypeID = Convert.ToInt32(GetAccountID3.ExecuteScalar());
            }
            else
                GeneralFunctions.AccountTypeID = 1;
            currentAccountTypeID = GeneralFunctions.AccountTypeID;
            txt_AccountTypeID.Text = currentAccountTypeID.ToString();
            txt_AccountTypeName.Text = "";
            UnCheckAll();
            btnNew.Enabled = true;
            btnDelete.Enabled = false;
            dvg.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void dvg_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }


    }
}