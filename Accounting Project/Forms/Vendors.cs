using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using JThomas.Controls;

namespace Accounting_GeneralLedger
{
    public partial class Vendors : Form
    {
        //private dbAccountingProjectDS dbAccountingProjectDS;
        private SqlConnection sqlcon;
        private SqlDataAdapter adapterAPVendorCategory;
        private SqlDataAdapter adapterAPPaymentTerms;
        private SqlDataAdapter adapterAPVendors;
        private SqlDataAdapter adapterAPTaxOffice;
        private SqlDataAdapter adapterAPVendorContacts;
        private SqlDataAdapter adapterAPVendorAccounts;
        private SqlDataAdapter adapterGLAccounts;
        private SqlCommandBuilder cmdBuilderAPVendors;
        private SqlCommandBuilder cmdBuilderAPVendorContacts;
        private SqlCommandBuilder cmdBuilderAPVendorAccounts;
        private int currentRowIndexContacts;
        private int currentRowIndexAccounts;
        private DataTable dtVendorContacts;
        private DataTable dtVendorAccounts;
        //private int currentVendorID;
        private string AccountNumberFormat;
        private SqlDataAdapter adaptertbGeneralSetup;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;




        public Vendors()
        {
            InitializeComponent();
        }
        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.formVendors;
            this.TP_TermsInfo.Text = obj_interface_language.TermsInformation;
            this.TP_VendorInfo.Text = obj_interface_language.VendorInformation;
            this.label20.Text = obj_interface_language.VendorID;
            this.label1.Text = obj_interface_language.VendorCode;
            this.label2.Text = obj_interface_language.VendorName;
            this.label3.Text = obj_interface_language.ArabicName;
            this.label4.Text = obj_interface_language.CheckName;
            this.label5.Text = obj_interface_language.Address;
            this.label6.Text = obj_interface_language.City;
            this.label7.Text = obj_interface_language.Country;
            this.label8.Text = obj_interface_language.Phone;
            this.label9.Text = obj_interface_language.Fax;
            this.label10.Text = obj_interface_language.Contacts;
            this.label18.Text = obj_interface_language.VendorCode;
            this.label11.Text = obj_interface_language.TermID;
            this.label12.Text = obj_interface_language.Status;
            this.label13.Text = obj_interface_language.TaxIDnumber;
            this.label14.Text = obj_interface_language.TaxOffice;
            this.label19.Text = obj_interface_language.TaxFileNumber;
            this.label15.Text = obj_interface_language.VendorCategory;
            this.label16.Text = obj_interface_language.CreditLimit;
            this.label17.Text = obj_interface_language.ExpenseAccounts;
            this.checkox_PrintSeparateChecks.Text = obj_interface_language.PrintSeparateChecks;

            this.btn_New.Text = obj_interface_language.buttonJVTransactionNew;
            this.btnedit.Text = obj_interface_language.buttonJVTransactionEdit;
            this.btndelete.Text = obj_interface_language.buttonJVTransactionDelete;
            this.btnundo.Text = obj_interface_language.buttonJVTransactionUndo;
            this.btnexit.Text = obj_interface_language.buttonJVTransactionExit;
            this.btnSavenew.Text = obj_interface_language.buttonJVTransactionSaveNew;
            this.Btnsaveedit.Text = obj_interface_language.buttonJVTransactionSaveEdit;

            this.dgv.Columns[1].HeaderText = obj_interface_language.dgvCode;
            this.dgv.Columns[2].HeaderText = obj_interface_language.dgvName;

            dgv_Contacts.Columns["ContactName"].HeaderText = obj_interface_language.dgvName;
            dgv_Contacts.Columns["ContactTitle"].HeaderText = obj_interface_language.dgvTitle;
            dgv_Contacts.Columns["ContactBusinessPlan"].HeaderText = obj_interface_language.dgvBusinessPlan;
            dgv_Contacts.Columns["ContactMobile"].HeaderText = obj_interface_language.dgvMobile;
            dgv_Contacts.Columns["ContactEmail"].HeaderText = obj_interface_language.dgvEmail;

            dgv_ExpenseAccounts.Columns["AccountNumber"].HeaderText = obj_interface_language.dgvAccountDefinitionColumn1;
            dgv_ExpenseAccounts.Columns["AccountDescription"].HeaderText = obj_interface_language.dgvAccountDefinitionColumn2;

        }
        private void Vendors_Load(object sender, EventArgs e)
        {
            GeneralFunctions.priviledgeGroupBox(Lock97);
            GeneralFunctions.priviledgeGroupBox(Lock98);
            GeneralFunctions.priviledgeGroupBox(Lock99);

            // TODO: This line of code loads data into the 'dbAccountingProjectDS.APVendors' table. You can move, or remove it, as needed.
            //this.aPVendorsTableAdapter.Fill(this.dbAccountingProjectDS.APVendors);
            //dbAccountingProjectDS = new dbAccountingProjectDS();
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adapterAPPaymentTerms = new SqlDataAdapter("Select * from APPaymentTerms", sqlcon);
            adapterAPVendorCategory = new SqlDataAdapter("Select * from APVendorCategory", sqlcon);
            adapterAPVendors = new SqlDataAdapter("Select * from APVendors", sqlcon);
            adapterAPVendorContacts = new SqlDataAdapter("Select * from APVendorContacts", sqlcon);
            adapterAPVendorAccounts = new SqlDataAdapter("Select * from APVendorAccounts", sqlcon);
            adapterGLAccounts = new SqlDataAdapter("Select * from GLAccounts", sqlcon);
            adapterAPTaxOffice = new SqlDataAdapter("Select * from APTaxOffice", sqlcon);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);

            cmdBuilderAPVendors = new SqlCommandBuilder(adapterAPVendors);
            cmdBuilderAPVendorContacts = new SqlCommandBuilder(adapterAPVendorContacts);
            cmdBuilderAPVendorAccounts = new SqlCommandBuilder(adapterAPVendorAccounts);

            adapterAPPaymentTerms.Fill(dbAccountingProjectDS.APPaymentTerms);
            adapterAPVendorCategory.Fill(dbAccountingProjectDS.APVendorCategory);
            adapterAPVendors.Fill(dbAccountingProjectDS.APVendors);
            adapterAPVendorContacts.Fill(dbAccountingProjectDS.APVendorContacts);
            adapterAPVendorAccounts.Fill(dbAccountingProjectDS.APVendorAccounts);
            adapterGLAccounts.Fill(dbAccountingProjectDS.GLAccounts);
            adapterAPTaxOffice.Fill(dbAccountingProjectDS.APTaxOffice);
            foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            {
                AccountNumberFormat = dr["AccountNumberFormat"].ToString();
            }
            dgv.DataSource = dbAccountingProjectDS.APVendors;
            dtVendorContacts = new DataTable();
            dtVendorContacts.Columns.Add("ContactID", System.Type.GetType("System.Int32"));
            dtVendorContacts.Columns.Add("ContactName", System.Type.GetType("System.String"));
            dtVendorContacts.Columns.Add("ContactTitle", System.Type.GetType("System.String"));
            dtVendorContacts.Columns.Add("ContactBusinessPlan", System.Type.GetType("System.String"));
            dtVendorContacts.Columns.Add("ContactMobile", System.Type.GetType("System.String"));
            dtVendorContacts.Columns.Add("ContactEmail", System.Type.GetType("System.String"));
            dtVendorContacts.Columns.Add("VendorCode", System.Type.GetType("System.String"));

            DataRow r = dtVendorContacts.NewRow();
            dtVendorContacts.Rows.Add(r);
            dgv_Contacts.DataSource = dtVendorContacts;
            for (int c = 0; c < dgv_Contacts.ColumnCount; c++)
            {
                dgv_Contacts.Columns[c].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgv_Contacts.Columns["ContactID"].Visible = false;
            dgv_Contacts.Columns["VendorCode"].Visible = false;
            dgv_Contacts.Columns["ContactName"].HeaderText = "Name";
            dgv_Contacts.Columns["ContactTitle"].HeaderText = "Title";
            dgv_Contacts.Columns["ContactBusinessPlan"].HeaderText = "BusinessPlan";
            dgv_Contacts.Columns["ContactMobile"].HeaderText = "Mobile";
            dgv_Contacts.Columns["ContactEmail"].HeaderText = "Email";
            dtVendorAccounts = new DataTable();
            dtVendorAccounts.Columns.Add("AccountID", System.Type.GetType("System.Int32"));
            dtVendorAccounts.Columns.Add("AccountNumber", System.Type.GetType("System.String"));
            dtVendorAccounts.Columns.Add("AccountDescription", System.Type.GetType("System.String"));
            dtVendorAccounts.Columns.Add("VendorCode", System.Type.GetType("System.String"));

            r = dtVendorAccounts.NewRow();
            dtVendorAccounts.Rows.Add(r);
            dgv_ExpenseAccounts.DataSource = dtVendorAccounts;

            DataGridViewMaskedTextColumn accformat = new DataGridViewMaskedTextColumn(AccountNumberFormat);
            accformat.DataPropertyName = "AccountNumber";
            accformat.HeaderText = "AccountNumber";     //  German text
            accformat.Name = "AccountNumber";
            accformat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            accformat.Width = 75;
            dgv_ExpenseAccounts.Columns.Insert(1, accformat);
            dgv_ExpenseAccounts.Columns[2].Visible = false;
            dgv_ExpenseAccounts.Columns["AccountDescription"].ReadOnly = true;
            dgv_ExpenseAccounts.Columns["AccountID"].Visible = false;
            dgv_ExpenseAccounts.Columns["VendorCode"].Visible = false;
            for (int c = 0; c < dgv_ExpenseAccounts.ColumnCount; c++)
            {
                dgv_ExpenseAccounts.Columns[c].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            cb_TermID = GeneralFunctions.FillComboBox(dbAccountingProjectDS.APPaymentTerms, cb_TermID, "PaymentTermCode", "PaymentTermCodeID");
            if (GeneralFunctions.Ckecktag("80") != "M")
                cb_TermID.Items.Remove("<new>");
            cb_VendorCategory = GeneralFunctions.FillComboBox(dbAccountingProjectDS.APVendorCategory, cb_VendorCategory, "CategoryCode", "CategoryID");
            if (GeneralFunctions.Ckecktag("79") != "M")
                cb_VendorCategory.Items.Remove("<new>");
            cb_TaxOffice = GeneralFunctions.FillComboBox(dbAccountingProjectDS.APTaxOffice, cb_TaxOffice, "TaxOfficeName", "TaxOfficeID");
            if (GeneralFunctions.Ckecktag("76") != "M")
                cb_TaxOffice.Items.Remove("<new>");

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

            //currentVendorID = GeneralFunctions.VendorID;
            //txt_VendorID.Text = currentVendorID.ToString();
            SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconBatch.Open();
            SqlCommand getBatch = new SqlCommand("Select Max(ContactID)+1 From APVendorContacts", sqlconBatch);
            if (getBatch.ExecuteScalar() != DBNull.Value)
            {
                GeneralFunctions.VendorContacts = int.Parse(getBatch.ExecuteScalar().ToString());
            }
            else
            {
                GeneralFunctions.VendorContacts = 1;
            }
            sqlconBatch.Close();
            sqlconBatch.Open();
            SqlCommand getBatch2 = new SqlCommand("Select Max(VendorAccountID)+1 From APVendorAccounts", sqlconBatch);
            if (getBatch2.ExecuteScalar() != DBNull.Value)
            {
                GeneralFunctions.VendorAccounts = int.Parse(getBatch2.ExecuteScalar().ToString());
            }
            else
            {
                GeneralFunctions.VendorAccounts = 1;
            }
            sqlconBatch.Close();

            if (GeneralFunctions.languagechioce != "")
            {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }
            InputLanguageChanged += new InputLanguageChangedEventHandler(txtAR_InputLanguageChanged);

        }
        void txtAR_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        {
            if (txt_VendorArabicName.Focused == true && InputLanguage.CurrentInputLanguage.Culture.Name != "ar-EG")
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.GetCultureInfoByIetfLanguageTag("ar-EG"));
        }
        private bool VendorCodeValidate()
        {
            bool validate = true;
            if (txt_VendorCode.Text == "")
            {
                errorProvider1.SetError(txt_VendorCode, "Please insert a valid Vendor Code");
                validate = false;
            }
            else
            {
                if (txt_VendorCode.Text.Length > 4)
                {
                    errorProvider1.SetError(txt_VendorCode, "The maximum size of the Vendor Code is 4 characters \n"
                                                             + "Please Insert a code of an acceptable size");
                    validate = false;
                }
                else
                {
                    Regex VendorCodeRegExp = new Regex("[0-9a-zA-Z]+");
                    if (VendorCodeRegExp.IsMatch(txt_VendorCode.Text))
                    {
                        Match m = VendorCodeRegExp.Match(txt_VendorCode.Text);
                        if (m.ToString().Equals(txt_VendorCode.Text))
                        {
                            errorProvider1.SetError(txt_VendorCode, "");
                        }
                        else
                        {
                            errorProvider1.SetError(txt_VendorCode, "The Vendor Code can only contain alpha-numeric characters\n " +
                                                                 "Please enter valid characters");
                            validate = false;
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txt_VendorCode, "The Vendor Code can only contain alpha-numeric characters\n " +
                                                                 "Please enter valid characters");
                        validate = false;
                    }
                }
            }
            return validate;
        }

        private void dgv_Contacts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            currentRowIndexContacts = e.RowIndex;
            //if (e.ColumnIndex != -1 && e.RowIndex != -1)
            //{
            //    if (dgv_Contacts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //    {
            //        if (e.ColumnIndex == 1)
            //        {
            //            if (currentRowIndexContacts == dtVendorContacts.Rows.Count - 1)
            //            {
            //                DataRow r = dtVendorContacts.NewRow();
            //                dtVendorContacts.Rows.Add(r);
            //            }
            //        }
            //    }
            //}
        }

        private void dgv_Contacts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex != -1 && e.RowIndex != -1)
            //{
            //    if (dgv_Contacts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //    {
            //        if (e.ColumnIndex == 1)
            //        {
            //            if (currentRowIndexContacts == dtVendorContacts.Rows.Count - 1)
            //            {
            //                DataRow r = dtVendorContacts.NewRow();
            //                dtVendorContacts.Rows.Add(r);
            //            }
            //        }
            //    }
            //}
        }

        private void dgv_Contacts_MouseLeave(object sender, EventArgs e)
        {
            //if (dgv_Contacts.CurrentCell != null)
            //{
            //    if (dgv_Contacts.CurrentCell.ColumnIndex == 1)
            //    {
            //        dgv_Contacts.CurrentCell = dgv_Contacts.Rows[currentRowIndexContacts].Cells[2];
            //        return;
            //    }
            //    if (dgv_Contacts.CurrentCell.ColumnIndex == 2)
            //    {
            //        dgv_Contacts.CurrentCell = dgv_Contacts.Rows[currentRowIndexContacts].Cells[3];
            //        return;
            //    }
            //    if (dgv_Contacts.CurrentCell.ColumnIndex == 3)
            //    {
            //        dgv_Contacts.CurrentCell = dgv_Contacts.Rows[currentRowIndexContacts].Cells[4];
            //        return;
            //    }
            //    if (dgv_Contacts.CurrentCell.ColumnIndex == 4)
            //    {
            //        dgv_Contacts.CurrentCell = dgv_Contacts.Rows[currentRowIndexContacts].Cells[5];
            //        return;
            //    }
            //    if (dgv_Contacts.CurrentCell.ColumnIndex == 5)
            //    {
            //        if (dgv_Contacts.Rows.Count > currentRowIndexContacts + 1)
            //        {
            //            dgv_Contacts.CurrentCell = dgv_Contacts.Rows[currentRowIndexContacts + 1].Cells[1];
            //        }
            //    }
            //}
            dgv_Contacts.EndEdit();
        }

        private bool ValidateInput()
        {
            if (txt_VendorName.Text != "")
            {
                if (!GeneralFunctions.ValidateString(txt_VendorName.Text, "Please Enter an acceptable Vendor Name"))
                {
                    tabControl1.SelectedIndex = 0;
                    return false;
                }
            }
            if (txt_VendorArabicName.Text != "")
            {
                if (!GeneralFunctions.ValidateString(txt_VendorArabicName.Text, "Please Enter an acceptable Vendor Arabic Name"))
                {
                    tabControl1.SelectedIndex = 0;
                    return false;
                }
            }
            if (txt_VendorCheckName.Text != "")
            {
                if (!GeneralFunctions.ValidateString(txt_VendorCheckName.Text, "Please Enter an acceptable Vendor Check Name"))
                {
                    tabControl1.SelectedIndex = 0;
                    return false;
                }
            }
            if (txt_Address.Text != "")
            {
                if (!GeneralFunctions.ValidateString(txt_Address.Text, "Please Enter an acceptable Vendor Address"))
                {
                    tabControl1.SelectedIndex = 0;
                    return false;
                }
            }
            if (txt_City.Text != "")
            {
                if (!GeneralFunctions.ValidateString(txt_City.Text, "Please Enter an acceptable Vendor City"))
                {
                    tabControl1.SelectedIndex = 0;
                    return false;
                }
            }
            if (txt_Country.Text != "")
            {
                if (!GeneralFunctions.ValidateString(txt_Country.Text, "Please Enter an acceptable Vendor Country"))
                {
                    tabControl1.SelectedIndex = 0;
                    return false;
                }
            }
            //if (txt_Phone.Text != "")
            //{
            //    if (!GeneralFunctions.ValidateNumber(txt_Phone.Text, "Please Enter an acceptable Vendor Phone"))
            //    {
            //        tabControl1.SelectedIndex = 0;
            //        return false;
            //    }
            //}
            //if (txt_Fax.Text != "")
            //{
            //    if (!GeneralFunctions.ValidateNumber(txt_Fax.Text, "Please Enter an acceptable Vendor Fax"))
            //    {
            //        tabControl1.SelectedIndex = 0;
            //        return false;
            //    }
            //}
            if (txt_TaxIDNumber.Text != "")
            {
                if (!GeneralFunctions.ValidateNumber(txt_TaxIDNumber.Text, "Please Enter an acceptable Vendor Tax Number ID"))
                {
                    tabControl1.SelectedIndex = 1;
                    return false;
                }
            }
            if (txt_TaxFileNumber.Text != "")
            {
                if (!GeneralFunctions.ValidateNumber(txt_TaxFileNumber.Text, "Please Enter an acceptable Vendor Tax File ID"))
                {
                    tabControl1.SelectedIndex = 1;
                    return false;
                }
            }
            if (cb_TaxOffice.Text != "")
            {
                if (!GeneralFunctions.ValidateComboBox(cb_TaxOffice, "Please Specify a Vendor Tax Office"))
                {
                    tabControl1.SelectedIndex = 1;
                    return false;
                }
            }
            if (txt_CreditLimit.Text != "")
            {
                if (!GeneralFunctions.ValidateNumber(txt_CreditLimit.Text, "Please Enter an acceptable Vendor Credit Limit"))
                {
                    tabControl1.SelectedIndex = 1;
                    return false;
                }
            }
            return true;
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VendorCodeValidate() && ValidateInput() && ValidateVendorContants() && VendorAccountsValidate())
            {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select VendorID from APVendors where VendorID = '" + txt_VendorID.Text + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("VendorID = '" + txt_VendorID.Text + "'", dbAccountingProjectDS.APVendors) && !GeneralFunctions.FindRow("VendorCode = '" + txt_VendorCode.Text + "'", dbAccountingProjectDS.APVendors))
                {
                    DataRow r = this.dbAccountingProjectDS.APVendors.NewRow();
                    r["VendorID"] = int.Parse(txt_VendorID.Text);
                    //GeneralFunctions.VendorID++;
                    //currentVendorID = GeneralFunctions.VendorID;
                    r["VendorCode"] = txt_VendorCode.Text;
                    r["VendorName"] = txt_VendorName.Text;
                    r["VendorArabicName"] = txt_VendorArabicName.Text;
                    r["VendorCheckName"] = txt_VendorCheckName.Text;
                    r["VendorAddress"] = txt_Address.Text;
                    r["VendorCity"] = txt_City.Text;
                    r["VendorCountry"] = txt_Country.Text;
                    r["VendorPhone"] = txt_Phone.Text;
                    r["VendorFax"] = txt_Fax.Text;
                    r["VendorTermID"] = cb_TermID.Text;
                    r["VendorStatus"] = cb_Status.Text;
                    r["VendorCategory"] = cb_VendorCategory.Text;
                    r["VendorTaxOffice"] = cb_TaxOffice.Text;
                    if (txt_CreditLimit.Text != "")
                        r["VendorCreditLimit"] = int.Parse(txt_CreditLimit.Text);
                    if (txt_TaxIDNumber.Text != "")
                        r["VendorTaxID"] = int.Parse(txt_TaxIDNumber.Text);
                    if (txt_TaxFileNumber.Text != "")
                        r["VendorTaxFileNumber"] = int.Parse(txt_TaxFileNumber.Text);
                    if (checkox_PrintSeparateChecks.Checked)
                        r["VendorPrintSeparateChecks"] = 1;
                    else
                        r["VendorPrintSeparateChecks"] = 0;
                    dbAccountingProjectDS.APVendors.Rows.Add(r);
                    AddVendorContacts();
                    AddVendorAccounts();
                    dr.Close();
                    sqlcon.Close();
                    MessageBox.Show("Vendor Record inserted successfully");
                    ClearAll();
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Vendor Code already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = this.dbAccountingProjectDS.APVendors.Select("VendorCode = '" + txt_VendorCode.Text + "'");
                        //rArr[0]["VendorCode"] = txt_VendorName.Text;
                        rArr[0]["VendorName"] = txt_VendorName.Text;
                        rArr[0]["VendorArabicName"] = txt_VendorArabicName.Text;
                        rArr[0]["VendorCheckName"] = txt_VendorCheckName.Text;
                        rArr[0]["VendorAddress"] = txt_Address.Text;
                        rArr[0]["VendorCity"] = txt_City.Text;
                        rArr[0]["VendorCountry"] = txt_City.Text;
                        rArr[0]["VendorPhone"] = txt_Phone.Text;
                        rArr[0]["VendorFax"] = txt_Fax.Text;
                        rArr[0]["VendorTermID"] = cb_TermID.Text;
                        rArr[0]["VendorStatus"] = cb_Status.Text;
                        rArr[0]["VendorCategory"] = cb_VendorCategory.Text;
                        rArr[0]["VendorTaxOffice"] = cb_TaxOffice.Text;
                        if (txt_CreditLimit.Text != "")
                            rArr[0]["VendorCreditLimit"] = txt_CreditLimit.Text;
                        if (txt_TaxIDNumber.Text != "")
                            rArr[0]["VendorTaxID"] = txt_TaxIDNumber.Text;
                        if (txt_TaxFileNumber.Text != "")
                            rArr[0]["VendorTaxFileNumber"] = txt_TaxFileNumber.Text;
                        if (checkox_PrintSeparateChecks.Checked)
                            rArr[0]["VendorPrintSeparateChecks"] = 1;
                        else
                            rArr[0]["VendorPrintSeparateChecks"] = 0;
                        EditVendorContacts();
                        EditVendorAccounts();
                        MessageBox.Show("Vendor Record edited successfully");
                        ClearAll();
                    }
                    else
                    {
                        ClearAll();
                    }
                }
                dr.Close();
                sqlcon.Close();
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                btn_New.Visible = true;
                btnSavenew.Visible = false;
                SaveChanges();
            }

        }

        private void AddVendorContacts()
        {
            DataRow r;
            for (int i = 0; i < dtVendorContacts.Rows.Count; i++)
            {
                r = dtVendorContacts.Rows[i];
                if (r.Equals(dtVendorContacts.Rows[dtVendorContacts.Rows.Count - 1]) && r["ContactID"].ToString() == "" && r["ContactName"].ToString() == "")
                    break;
                if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified)
                {
                    r = this.dbAccountingProjectDS.APVendorContacts.NewRow();
                    if (dgv_Contacts.Rows[i].Cells["ContactID"].Value.ToString() != "" && dgv_Contacts.Rows[i].Cells["VendorCode"].Value.ToString() == "")
                        r["ContactID"] = dgv_Contacts.Rows[i].Cells["ContactID"].Value;
                    else
                    {
                        r["ContactID"] = GeneralFunctions.VendorContacts;
                        GeneralFunctions.VendorContacts++;
                    }
                    r["ContactName"] = dgv_Contacts.Rows[i].Cells["ContactName"].Value;
                    r["ContactTitle"] = dgv_Contacts.Rows[i].Cells["ContactTitle"].Value;
                    r["ContactBusinessPlan"] = dgv_Contacts.Rows[i].Cells["ContactBusinessPlan"].Value;
                    r["ContactMobile"] = dgv_Contacts.Rows[i].Cells["ContactMobile"].Value;
                    r["ContactEmail"] = dgv_Contacts.Rows[i].Cells["ContactEmail"].Value;
                    r["VendorCode"] = txt_VendorCode.Text;
                    dbAccountingProjectDS.APVendorContacts.Rows.Add(r);
                }
            }
        }

        private void AddVendorAccounts()
        {
            DataRow r;
            for (int i = 0; i < dtVendorAccounts.Rows.Count; i++)
            {
                r = dtVendorAccounts.Rows[i];
                if (r.Equals(dtVendorAccounts.Rows[dtVendorAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountDescription"].ToString() == "")
                    break;
                if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Modified)
                {
                    r = this.dbAccountingProjectDS.APVendorAccounts.NewRow();
                    if (dgv_ExpenseAccounts.Rows[i].Cells["AccountID"].Value.ToString() != "" && dgv_ExpenseAccounts.Rows[i].Cells["VendorCode"].Value.ToString() == "")
                        r["VendorAccountID"] = dgv_ExpenseAccounts.Rows[i].Cells["ContactID"].Value;
                    else
                    {
                        r["VendorAccountID"] = GeneralFunctions.VendorAccounts;
                        GeneralFunctions.VendorAccounts++;
                    }
                    r["VendorAccountNumber"] = dgv_ExpenseAccounts.Rows[i].Cells["AccountNumber"].Value;
                    r["VendorAccountDescription"] = dgv_ExpenseAccounts.Rows[i].Cells["AccountDescription"].Value;
                    r["VendorCode"] = txt_VendorCode.Text;
                    dbAccountingProjectDS.APVendorAccounts.Rows.Add(r);
                }
            }
        }

        private void EditVendorContacts()
        {
            DataRow r;
            for (int i = 0; i < dtVendorContacts.Rows.Count; i++)
            {
                r = dtVendorContacts.Rows[i];
                if (r.Equals(dtVendorContacts.Rows[dtVendorContacts.Rows.Count - 1]) && r["ContactID"].ToString() == "" && r["ContactName"].ToString() == "")
                    break;
                if (r.RowState == DataRowState.Modified)
                {
                    DataRow[] rArr = this.dbAccountingProjectDS.APVendorContacts.Select("ContactID = '" + r["ContactID"].ToString() + "'");
                    rArr[0]["ContactName"] = dgv_Contacts.Rows[i].Cells["ContactName"].Value;
                    rArr[0]["ContactTitle"] = dgv_Contacts.Rows[i].Cells["ContactTitle"].Value;
                    rArr[0]["ContactBusinessPlan"] = dgv_Contacts.Rows[i].Cells["ContactBusinessPlan"].Value;
                    rArr[0]["ContactMobile"] = dgv_Contacts.Rows[i].Cells["ContactMobile"].Value;
                    rArr[0]["ContactEmail"] = dgv_Contacts.Rows[i].Cells["ContactEmail"].Value;
                    rArr[0]["VendorCode"] = txt_VendorCode.Text;
                }
                if (r.RowState == DataRowState.Added)
                {
                    r = this.dbAccountingProjectDS.APVendorContacts.NewRow();
                    if (dgv_Contacts.Rows[i].Cells["ContactID"].Value.ToString() != "" && dgv_Contacts.Rows[i].Cells["VendorCode"].Value.ToString() == "")
                        r["ContactID"] = dgv_Contacts.Rows[i].Cells["ContactID"].Value;
                    else
                    {
                        r["ContactID"] = GeneralFunctions.VendorContacts;
                        GeneralFunctions.VendorContacts++;
                    }
                    r["ContactName"] = dgv_Contacts.Rows[i].Cells["ContactName"].Value;
                    r["ContactTitle"] = dgv_Contacts.Rows[i].Cells["ContactTitle"].Value;
                    r["ContactBusinessPlan"] = dgv_Contacts.Rows[i].Cells["ContactBusinessPlan"].Value;
                    r["ContactMobile"] = dgv_Contacts.Rows[i].Cells["ContactMobile"].Value;
                    r["ContactEmail"] = dgv_Contacts.Rows[i].Cells["ContactEmail"].Value;
                    r["VendorCode"] = txt_VendorCode.Text;
                    dbAccountingProjectDS.APVendorContacts.Rows.Add(r);
                }
            }
        }

        private void EditVendorAccounts()
        {
            DataRow r;
            for (int i = 0; i < dtVendorAccounts.Rows.Count; i++)
            {
                r = dtVendorAccounts.Rows[i];
                if (r["AccountNumber"].ToString().Trim() != "" && dgv_ExpenseAccounts.Rows[i].Cells["AccountNumber"] .FormattedValue.ToString() != "")
                {
                    if (r.RowState == DataRowState.Modified)
                    {
                        DataRow[] rArr = this.dbAccountingProjectDS.APVendorAccounts.Select("VendorAccountID = '" + r["AccountID"].ToString() + "'");
                        rArr[0]["VendorAccountNumber"] = dgv_ExpenseAccounts.Rows[i].Cells["AccountNumber"].Value;
                        rArr[0]["VendorAccountDescription"] = dgv_ExpenseAccounts.Rows[i].Cells["AccountDescription"].Value;
                        rArr[0]["VendorCode"] = txt_VendorCode.Text;
                    }
                    if (r.RowState == DataRowState.Added)
                    {
                        r = this.dbAccountingProjectDS.APVendorAccounts.NewRow();
                        if (dgv_ExpenseAccounts.Rows[i].Cells["AccountID"].Value.ToString() != "" && dgv_ExpenseAccounts.Rows[i].Cells["VendorCode"].Value.ToString() == "")
                            r["VendorAccountID"] = dgv_ExpenseAccounts.Rows[i].Cells["AccountID"].Value;
                        else
                        {
                            r["VendorAccountID"] = GeneralFunctions.VendorAccounts;
                            GeneralFunctions.VendorAccounts++;
                        }
                        r["VendorAccountNumber"] = dgv_ExpenseAccounts.Rows[i].Cells["AccountNumber"].Value;
                        r["VendorAccountDescription"] = dgv_ExpenseAccounts.Rows[i].Cells["AccountDescription"].Value;
                        r["VendorCode"] = txt_VendorCode.Text;
                        dbAccountingProjectDS.APVendorAccounts.Rows.Add(r);
                    }
                }
            }
        }

        private bool ValidateVendorContants()
        {
            bool valid = true;
            DataRow r;
            for (int i = 0; i < dtVendorContacts.Rows.Count; i++)
            {
                r = dtVendorContacts.Rows[i];
                if (r.RowState != DataRowState.Deleted)
                {
                    if (r.Equals(dtVendorContacts.Rows[dtVendorContacts.Rows.Count - 1]) && r["ContactID"].ToString() == "" && r["ContactName"].ToString() == "")
                        break;
                    if (r["ContactID"].ToString() == "" && r["ContactName"].ToString() == "")
                        break;
                    if (r["ContactName"].ToString() != "" && GeneralFunctions.ValidateString(r["ContactName"].ToString(), "Please Enter the Contact Name"))
                    {
                        if (r["ContactTitle"].ToString() != "")
                        {
                            if (!GeneralFunctions.ValidateString(r["ContactTitle"].ToString(), "Please Enter the Contact Title"))
                            {
                                tabControl1.SelectedIndex = 0;
                                return false;
                            }
                        }
                        if (r["ContactBusinessPlan"].ToString() != "")
                        {
                            if (!GeneralFunctions.ValidateString(r["ContactBusinessPlan"].ToString(), "Please Enter the Contact Business Plan"))
                            {
                                tabControl1.SelectedIndex = 0;
                                return false;
                            }
                        }
                        //if (r["ContactMobile"].ToString() != "")
                        //{
                        //    if (!GeneralFunctions.ValidateNumber(r["ContactMobile"].ToString(), "Please Enter the Contact Mobile"))
                        //    {
                        //        tabControl1.SelectedIndex = 0;
                        //        return false;
                        //    }
                        //}
                        if (r["ContactEmail"].ToString() != "")
                        {
                            if (!GeneralFunctions.ValidateEmail(r["ContactEmail"].ToString(), "Please Enter the Contact Email"))
                            {
                                tabControl1.SelectedIndex = 0;
                                return false;
                            }
                        }
                    }
                    else
                    {
                        tabControl1.SelectedIndex = 0;
                        return false;
                    }
                }
            }
            return valid;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VendorCodeValidate() && ValidateInput() && ValidateVendorContants() && VendorAccountsValidate())
            {
                DataRow[] rArr = this.dbAccountingProjectDS.APVendors.Select("VendorID = '" + txt_VendorID.Text + "'");
                if (rArr.Length != 0)
                {
                    rArr[0]["VendorCode"] = txt_VendorCode.Text;
                    rArr[0]["VendorName"] = txt_VendorName.Text;
                    rArr[0]["VendorArabicName"] = txt_VendorArabicName.Text;
                    rArr[0]["VendorCheckName"] = txt_VendorCheckName.Text;
                    rArr[0]["VendorAddress"] = txt_Address.Text;
                    rArr[0]["VendorCity"] = txt_City.Text;
                    rArr[0]["VendorCountry"] = txt_City.Text;
                    rArr[0]["VendorPhone"] = txt_Phone.Text;
                    rArr[0]["VendorFax"] = txt_Fax.Text;
                    rArr[0]["VendorTermID"] = cb_TermID.Text;
                    rArr[0]["VendorStatus"] = cb_Status.Text;
                    rArr[0]["VendorCategory"] = cb_VendorCategory.Text;
                    rArr[0]["VendorTaxOffice"] = cb_TaxOffice.Text;
                    rArr[0]["VendorTermID"] = cb_TermID.Text;
                    rArr[0]["VendorStatus"] = cb_Status.Text;
                    rArr[0]["VendorCategory"] = cb_VendorCategory.Text;
                    if (txt_CreditLimit.Text != "")
                        rArr[0]["VendorCreditLimit"] = int.Parse(txt_CreditLimit.Text);
                    if (txt_TaxIDNumber.Text != "")
                        rArr[0]["VendorTaxID"] = int.Parse(txt_TaxIDNumber.Text);
                    if (txt_TaxFileNumber.Text != "")
                        rArr[0]["VendorTaxFileNumber"] = int.Parse(txt_TaxFileNumber.Text);
                    if (checkox_PrintSeparateChecks.Checked)
                        rArr[0]["VendorPrintSeparateChecks"] = 1;
                    else
                        rArr[0]["VendorPrintSeparateChecks"] = 0;
                    EditVendorContacts();
                    EditVendorAccounts();
                    MessageBox.Show("Vendor Record edited successfully");
                    //ClearAll();
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                    btnedit.Visible = true;
                    Btnsaveedit.Visible = false;
                    btn_New.Enabled = true;
                    btndelete.Enabled = true;
                    SaveChanges();
                }

            }
            else
            {
                MessageBox.Show("The given Vendor Code doesnt exist \n Cant perform edit operation");
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txt_VendorCode.Text != "")
            {
                DataRow[] rArrAccounts;
                DataRow[] rArr = dbAccountingProjectDS.APVendors.Select("VendorID = '" + txt_VendorID.Text + "'");
                if (rArr.Length != 0)
                {
                    rArrAccounts = this.dbAccountingProjectDS.APVendorContacts.Select("VendorCode = '" + txt_VendorCode.Text + "'");
                    for (int i = 0; i < rArrAccounts.Length; i++)
                    {
                        rArrAccounts[i].Delete();
                    }
                    rArrAccounts = this.dbAccountingProjectDS.APVendorAccounts.Select("VendorCode = '" + txt_VendorCode.Text + "'");
                    for (int i = 0; i < rArrAccounts.Length; i++)
                    {
                        rArrAccounts[i].Delete();
                    }
                    rArr[0].Delete();
                    MessageBox.Show("Vendor Record deleted successfully");
                    ClearAll();
                }
                else
                {
                    MessageBox.Show("The given Vendor Code doesnt exist \n Cant perform delete operation");
                }
            }
            SaveChanges();
            btnedit.Enabled = false;
            btndelete.Enabled = false;

        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow r;
            if (txt_VendorCode.Text != "")
            {
                DataRow[] rArr = this.dbAccountingProjectDS.APVendors.Select("VendorCode = '" + txt_VendorCode.Text + "'");
                if (rArr.Length != 0)
                {
                    txt_VendorID.Text = rArr[0]["VendorID"].ToString();
                    txt_VendorName.Text = rArr[0]["VendorName"].ToString();
                    txt_VendorArabicName.Text = rArr[0]["VendorArabicName"].ToString();
                    txt_VendorCheckName.Text = rArr[0]["VendorCheckName"].ToString();
                    txt_Address.Text = rArr[0]["VendorAddress"].ToString();
                    txt_City.Text = rArr[0]["VendorCity"].ToString();
                    txt_Country.Text = rArr[0]["VendorCountry"].ToString();
                    txt_Phone.Text = rArr[0]["VendorPhone"].ToString();
                    txt_Fax.Text = rArr[0]["VendorFax"].ToString();
                    cb_TermID.Text = rArr[0]["VendorTermID"].ToString();
                    cb_Status.Text = rArr[0]["VendorStatus"].ToString();
                    cb_VendorCategory.Text = rArr[0]["VendorCategory"].ToString();
                    txt_TaxIDNumber.Text = rArr[0]["VendorTaxID"].ToString();
                    txt_TaxFileNumber.Text = rArr[0]["VendorTaxFileNumber"].ToString();
                    cb_TaxOffice.Text = rArr[0]["VendorTaxOffice"].ToString();
                    txt_CreditLimit.Text = rArr[0]["VendorCreditLimit"].ToString();
                    if (rArr[0]["VendorPrintSeparateChecks"].ToString() == "True")
                        checkox_PrintSeparateChecks.Checked = true;
                    else
                        checkox_PrintSeparateChecks.Checked = false;

                    DataRow[] rArrResult = this.dbAccountingProjectDS.APVendorContacts.Select("VendorCode = '" + txt_VendorCode.Text + "'");
                    if (rArrResult.Length != 0)
                    {
                        dtVendorContacts.Rows.RemoveAt(dtVendorContacts.Rows.Count - 1);
                        for (int i = 0; i < rArrResult.Length; i++)
                        {
                            r = dtVendorContacts.NewRow();
                            r["ContactID"] = rArrResult[i]["ContactID"];
                            r["ContactName"] = rArrResult[i]["ContactName"];
                            r["ContactTitle"] = rArrResult[i]["ContactTitle"];
                            r["ContactBusinessPlan"] = rArrResult[i]["ContactBusinessPlan"];
                            r["ContactMobile"] = rArrResult[i]["ContactMobile"];
                            r["ContactEmail"] = rArrResult[i]["ContactEmail"];
                            r["VendorCode"] = rArrResult[i]["VendorCode"];
                            dtVendorContacts.Rows.Add(r);
                            r.AcceptChanges();
                        }
                        r = dtVendorContacts.NewRow();
                        dtVendorContacts.Rows.Add(r);
                    }

                    rArrResult = this.dbAccountingProjectDS.APVendorAccounts.Select("VendorCode = '" + txt_VendorCode.Text + "'");
                    if (rArrResult.Length != 0)
                    {
                        dtVendorAccounts.Rows.RemoveAt(dtVendorAccounts.Rows.Count - 1);
                        for (int i = 0; i < rArrResult.Length; i++)
                        {
                            r = dtVendorAccounts.NewRow();
                            r["AccountID"] = rArrResult[i]["VendorAccountID"];
                            r["AccountNumber"] = rArrResult[i]["VendorAccountNumber"];
                            r["AccountDescription"] = rArrResult[i]["VendorAccountDescription"];
                            r["VendorCode"] = rArrResult[i]["VendorCode"];
                            dtVendorAccounts.Rows.Add(r);
                            r.AcceptChanges();
                        }
                        r = dtVendorAccounts.NewRow();
                        dtVendorAccounts.Rows.Add(r);
                    }
                }
                else
                    MessageBox.Show("The given Vendor code couldnt be found");
            }
        }

        private void ClearAll()
        {
            txt_VendorID.Text = "";
            txt_VendorCode.Text = "";
            txt_VendorName.Text = "";
            txt_VendorArabicName.Text = "";
            txt_VendorCheckName.Text = "";
            txt_Address.Text = "";
            txt_City.Text = "";
            txt_Country.Text = "";
            txt_Phone.Text = "";
            txt_Fax.Text = "";
            dtVendorContacts.Rows.Clear();
            //int count = dgv_Contacts.Rows.Count;
            //for (int i = count - 1; i >= 0; i--)
            //    dgv_Contacts.Rows.RemoveAt(i);
            DataRow r = dtVendorContacts.NewRow();
            dtVendorContacts.Rows.Add(r);

            cb_TermID.SelectedIndex = -1;
            cb_Status.SelectedIndex = -1;
            cb_VendorCategory.SelectedIndex = -1;
            cb_TaxOffice.SelectedIndex = -1;
            txt_TaxIDNumber.Text = "";
            txt_TaxFileNumber.Text = "";
            txt_TermVendorCode.Text = "";
            txt_CreditLimit.Text = "";
            checkox_PrintSeparateChecks.Checked = false;
            dtVendorAccounts.Rows.Clear();
            //count = dtVendorAccounts.Rows.Count;
            //for (int i = count - 1; i >= 0; i--)
            //    dtVendorAccounts.Rows.RemoveAt(i);
            r = dtVendorAccounts.NewRow();
            dtVendorAccounts.Rows.Add(r);
        }

        private void SaveChanges()
        {
            adapterAPVendors.Update(dbAccountingProjectDS.APVendors);
            adapterAPVendorContacts.Update(dbAccountingProjectDS.APVendorContacts);
            adapterAPVendorAccounts.Update(dbAccountingProjectDS.APVendorAccounts);
            dbAccountingProjectDS.AcceptChanges();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (txt_VendorCode.Text != "")
                {
                    txt_TermVendorCode.Text = txt_VendorCode.Text;
                }
            }
        }

        private void dgv_ExpenseAccounts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            currentRowIndexAccounts = e.RowIndex;
            //if (e.ColumnIndex != -1 && e.RowIndex != -1)
            //{
            //    if (dgv_ExpenseAccounts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //    {
            //        if (e.ColumnIndex == 1)
            //        {
            //            if (currentRowIndexAccounts == dtVendorAccounts.Rows.Count - 1)
            //            {
            //                DataRow r = dtVendorAccounts.NewRow();
            //                dtVendorAccounts.Rows.Add(r);
            //            }
            //        }
            //    }
            //}
        }

        private void dgv_ExpenseAccounts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex != -1 && e.RowIndex != -1)
            //{
            //    if (dgv_ExpenseAccounts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //    {
            //        if (e.ColumnIndex == 1)
            //        {
            //            if (currentRowIndexAccounts == dtVendorAccounts.Rows.Count - 1)
            //            {
            //                DataRow r = dtVendorAccounts.NewRow();
            //                dtVendorAccounts.Rows.Add(r);
            //            }
            //        }
            //    }
            //}
        }

        private void dgv_ExpenseAccounts_MouseLeave(object sender, EventArgs e)
        {
            //if (dgv_ExpenseAccounts.CurrentCell != null)
            //{
            //    if (dgv_ExpenseAccounts.CurrentCell.ColumnIndex == 1)
            //    {
            //        dgv_ExpenseAccounts.CurrentCell = dgv_ExpenseAccounts.Rows[currentRowIndexAccounts].Cells[2];
            //        return;
            //    }
            //    if (dgv_ExpenseAccounts.CurrentCell.ColumnIndex == 2)
            //    {
            //        if (dgv_ExpenseAccounts.Rows.Count > currentRowIndexAccounts + 1)
            //        {
            //            dgv_ExpenseAccounts.CurrentCell = dgv_ExpenseAccounts.Rows[currentRowIndexAccounts + 1].Cells[1];
            //        }
            //    }
            //}
            dgv_ExpenseAccounts.EndEdit();
        }

        private void dgv_ExpenseAccounts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataRow dr;
            if (VendorCodeValidate() && ValidateInput() && ValidateVendorContants())
            {
                AccountSearch accSearch = new AccountSearch();
                accSearch.ShowDialog();
                if (accSearch.selectedAccountName != null && accSearch.selectedAccountNumber != null)
                {
                    dtVendorAccounts.Rows.RemoveAt(dtVendorAccounts.Rows.Count - 1);
                    dr = dtVendorAccounts.NewRow();
                    dr["AccountID"] = GeneralFunctions.VendorAccounts;
                    GeneralFunctions.VendorAccounts++;
                    dr["AccountNumber"] = accSearch.selectedAccountNumber;
                    dr["AccountDescription"] = accSearch.selectedAccountName;
                    dr["VendorCode"] = txt_VendorCode.Text;
                    dtVendorAccounts.Rows.Add(dr);
                    dr = dtVendorAccounts.NewRow();
                    dtVendorAccounts.Rows.Add(dr);
                }

                if (accSearch.selectedAccountsTable != null && accSearch.selectedAccountsTable.Rows.Count != 0)
                {
                    dtVendorAccounts.Rows.RemoveAt(dtVendorAccounts.Rows.Count - 1);
                    for (int i = 1; i < accSearch.selectedAccountsTable.Rows.Count; i++)
                    {
                        dr = dtVendorAccounts.NewRow();
                        dr["AccountID"] = GeneralFunctions.VendorAccounts;
                        GeneralFunctions.VendorAccounts++;
                        dr["AccountNumber"] = accSearch.selectedAccountsTable.Rows[i]["AccountNumber"];
                        dr["AccountDescription"] = accSearch.selectedAccountsTable.Rows[i]["AccountName"];
                        dr["VendorCode"] = txt_VendorCode.Text;
                        dtVendorAccounts.Rows.Add(dr);
                    }
                    dr = dtVendorAccounts.NewRow();
                    dtVendorAccounts.Rows.Add(dr);
                }
            }
            else
                MessageBox.Show("Please Define the Vendor information first");
        }

        private bool VendorAccountsValidate()
        {
            bool valid = true;
            DataRow[] rArr;
            DataRow r;
            string validAccountNumber;
            for (int i = 0; i < dtVendorAccounts.Rows.Count; i++)
            {
                r = dtVendorAccounts.Rows[i];
                if (r.RowState != DataRowState.Deleted)
                {
                    if (r.Equals(dtVendorAccounts.Rows[dtVendorAccounts.Rows.Count - 1]) && r["AccountNumber"].ToString() == "" && r["AccountDescription"].ToString() == "")
                        break;
                    if (r["AccountNumber"].ToString() != "")
                    {
                        if (!GeneralFunctions.AccountNumberValidate(r["AccountNumber"].ToString(), out validAccountNumber))
                        {
                            errorProvider1.SetError(dgv_ExpenseAccounts, "The given account number doesnt exist");
                            tabControl1.SelectedIndex = 1;
                            valid = false;
                        }
                        else
                        {
                            r["AccountNumber"] = validAccountNumber;
                            rArr = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + validAccountNumber + "'");
                            if (r["AccountDescription"].ToString() != "")
                            {
                                if (rArr.Length != 0)
                                {
                                    if (rArr[0]["AccountName"].ToString() != r["AccountDescription"].ToString())
                                        r["AccountDescription"] = (string)rArr[0]["AccountName"];
                                    else
                                    {
                                        errorProvider1.SetError(dgv_ExpenseAccounts, "");
                                    }
                                }
                            }
                            else
                                r["AccountDescription"] = (string)rArr[0]["AccountName"];
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(dgv_ExpenseAccounts, "The account number cant be equal to null");
                        tabControl1.SelectedIndex = 1;
                        valid = false;
                    }
                }
            }
            return valid;
        }

        private void cb_TermID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_TermID.Text == "<new>")
            {
                PaymentTerms payTerms = new PaymentTerms();
                payTerms.ShowDialog();
                cb_TermID.Items.Clear();
                adapterAPPaymentTerms.Fill(dbAccountingProjectDS.APPaymentTerms);
                cb_TermID = GeneralFunctions.FillComboBox(dbAccountingProjectDS.APPaymentTerms, cb_TermID, "PaymentTermCode", "PaymentTermCodeID");
            }
        }

        private void cb_TaxOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_TaxOffice.Text == "<new>")
            {
                TaxOffice taxOff = new TaxOffice();
                taxOff.ShowDialog();
                cb_TaxOffice.Items.Clear();
                adapterAPTaxOffice.Fill(dbAccountingProjectDS.APTaxOffice);
                cb_TaxOffice = GeneralFunctions.FillComboBox(dbAccountingProjectDS.APTaxOffice, cb_TaxOffice, "TaxOfficeName", "TaxOfficeID");
            }
        }

        private void cb_VendorCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_VendorCategory.Text == "<new>")
            {
                VendorsCategories vencat = new VendorsCategories();
                vencat.ShowDialog();
                cb_VendorCategory.Items.Clear();
                adapterAPVendorCategory.Fill(dbAccountingProjectDS.APVendorCategory);
                cb_VendorCategory = GeneralFunctions.FillComboBox(dbAccountingProjectDS.APVendorCategory, cb_VendorCategory, "CategoryCode", "CategoryID");
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            ClearAll();
            SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconBatch.Open();
            SqlCommand getBatch = new SqlCommand("Select Max(VendorID)+1 From APVendors", sqlconBatch);
            if (getBatch.ExecuteScalar() != DBNull.Value)
            {
                txt_VendorID.Text = getBatch.ExecuteScalar().ToString();
            }
            else
            {
                txt_VendorID.Text = "1";
            }
            sqlconBatch.Close();
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            btn_New.Visible = false;
            btnSavenew.Visible = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
        }

        private void dgv_Contacts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                DataRow[] rArr;
                if (dgv_Contacts.Rows[currentRowIndexContacts].Cells["ContactID"].Value.ToString() != "")
                {
                    string contactID = dgv_Contacts.Rows[currentRowIndexContacts].Cells["ContactID"].Value.ToString();
                    rArr = dtVendorContacts.Select("ContactID = '" + contactID + "'");
                    if (rArr.Length > 0)
                    {
                        rArr[0].Delete();
                        rArr[0].AcceptChanges();
                    }
                    rArr = dbAccountingProjectDS.APVendorContacts.Select("ContactID = '" + contactID + "'");
                    if (rArr.Length > 0)
                        rArr[0].Delete();

                }
            }
        }

        private void dgv_ExpenseAccounts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                DataRow[] rArr;
                if (dgv_ExpenseAccounts.Rows[currentRowIndexAccounts].Cells["AccountID"].Value.ToString() != "")
                {
                    string accountID = dgv_ExpenseAccounts.Rows[currentRowIndexAccounts].Cells["AccountID"].Value.ToString();
                    rArr = dtVendorAccounts.Select("AccountID = '" + accountID + "'");
                    if (rArr.Length > 0)
                    {
                        rArr[0].Delete();
                        rArr[0].AcceptChanges();
                    }
                    rArr = dbAccountingProjectDS.APVendorAccounts.Select("VendorAccountID = '" + accountID + "'");
                    if (rArr.Length > 0)
                        rArr[0].Delete();

                }
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {

            if (groupBox1.Enabled == true && groupBox2.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            this.Close();

        }

        private void btnundo_Click(object sender, EventArgs e)
        {
            if (sender.ToString() != "NO")
            {
                if (groupBox1.Enabled == true && groupBox2.Enabled == true)
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
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            btn_New.Enabled = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult myrst;
            myrst = MessageBox.Show("Are You Sure Delete This Vendors", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return;
            deleteToolStripMenuItem_Click(sender, e);

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            btnedit.Visible = false;
            Btnsaveedit.Visible = true;
            btn_New.Enabled = false;
            btndelete.Enabled = false;

        }

        private void Btnsaveedit_Click(object sender, EventArgs e)
        {
            editToolStripMenuItem_Click(sender, e);
        }

        private void btnSavenew_Click(object sender, EventArgs e)
        {
            insertToolStripMenuItem_Click(sender, e);
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (groupBox1.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            btnundo_Click("NO", e);
            int m = 0;
            DataRow r;
            if (dgv.SelectedRows.Count > 0)
            {

                if (dgv.CurrentRow.Cells[1].Value.ToString() != "")
                {
                    DataRow[] rArr = this.dbAccountingProjectDS.APVendors.Select("VendorCode = '" + dgv.CurrentRow.Cells[1].Value.ToString() + "'");
                    if (rArr.Length != 0)
                    {
                        txt_VendorID.Text = rArr[0]["VendorID"].ToString();
                        txt_VendorName.Text = rArr[0]["VendorName"].ToString();
                        txt_VendorCode.Text = rArr[0]["VendorCode"].ToString();
                        txt_VendorArabicName.Text = rArr[0]["VendorArabicName"].ToString();
                        txt_VendorCheckName.Text = rArr[0]["VendorCheckName"].ToString();
                        txt_Address.Text = rArr[0]["VendorAddress"].ToString();
                        txt_City.Text = rArr[0]["VendorCity"].ToString();
                        txt_Country.Text = rArr[0]["VendorCountry"].ToString();
                        txt_Phone.Text = rArr[0]["VendorPhone"].ToString();
                        txt_Fax.Text = rArr[0]["VendorFax"].ToString();
                        cb_TermID.Text = rArr[0]["VendorTermID"].ToString();
                        cb_Status.Text = rArr[0]["VendorStatus"].ToString();
                        cb_VendorCategory.Text = rArr[0]["VendorCategory"].ToString();
                        txt_TaxIDNumber.Text = rArr[0]["VendorTaxID"].ToString();
                        txt_TaxFileNumber.Text = rArr[0]["VendorTaxFileNumber"].ToString();
                        cb_TaxOffice.Text = rArr[0]["VendorTaxOffice"].ToString();
                        txt_CreditLimit.Text = rArr[0]["VendorCreditLimit"].ToString();
                        if (rArr[0]["VendorPrintSeparateChecks"].ToString() == "True")
                            checkox_PrintSeparateChecks.Checked = true;
                        else
                            checkox_PrintSeparateChecks.Checked = false;

                        DataRow[] rArrResult = this.dbAccountingProjectDS.APVendorContacts.Select("VendorCode = '" + dgv.CurrentRow.Cells[1].Value.ToString() + "'");
                        if (rArrResult.Length != 0)
                        {
                            //m = dtVendorContacts.Rows.Count;
                            //for (int t = 0; t < m; t++)
                            //{
                            //    dtVendorContacts.Rows.RemoveAt(m - t - 1);
                            //}
                            dtVendorContacts.Rows.Clear();
                            for (int i = 0; i < rArrResult.Length; i++)
                            {
                                r = dtVendorContacts.NewRow();
                                r["ContactID"] = rArrResult[i]["ContactID"];
                                r["ContactName"] = rArrResult[i]["ContactName"];
                                r["ContactTitle"] = rArrResult[i]["ContactTitle"];
                                r["ContactBusinessPlan"] = rArrResult[i]["ContactBusinessPlan"];
                                r["ContactMobile"] = rArrResult[i]["ContactMobile"];
                                r["ContactEmail"] = rArrResult[i]["ContactEmail"];
                                r["VendorCode"] = rArrResult[i]["VendorCode"];
                                dtVendorContacts.Rows.Add(r);
                                r.AcceptChanges();
                            }
                            r = dtVendorContacts.NewRow();
                            dtVendorContacts.Rows.Add(r);
                        }

                        rArrResult = this.dbAccountingProjectDS.APVendorAccounts.Select("VendorCode = '" + dgv.CurrentRow.Cells[1].Value.ToString() + "'");
                        if (rArrResult.Length != 0)
                        {
                            //m = dtVendorAccounts.Rows.Count;
                            //for (int t = 0; t < m; t++)
                            //{
                            //    dtVendorAccounts.Rows.RemoveAt(m - t - 1);
                            //}
                            dtVendorAccounts.Rows.Clear();
                            //dtVendorAccounts.Rows.RemoveAt(dtVendorAccounts.Rows.Count - 1);
                            for (int i = 0; i < rArrResult.Length; i++)
                            {
                                r = dtVendorAccounts.NewRow();
                                r["AccountID"] = rArrResult[i]["VendorAccountID"];
                                r["AccountNumber"] = rArrResult[i]["VendorAccountNumber"];
                                r["AccountDescription"] = rArrResult[i]["VendorAccountDescription"];
                                r["VendorCode"] = rArrResult[i]["VendorCode"];
                                dtVendorAccounts.Rows.Add(r);
                                r.AcceptChanges();
                            }
                            r = dtVendorAccounts.NewRow();
                            dtVendorAccounts.Rows.Add(r);
                        }

                        groupBox1.Enabled = false;
                        btndelete.Enabled = true;
                        btnedit.Enabled = true;


                    }
                    else
                        MessageBox.Show("The given Vendor code couldnt be found");
                }
            }
        }

        private void txt_TaxIDNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 8)
            //    e.Handled = false;
            //else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            //{
            //        e.Handled = false;

            //}
            //else
            //    e.Handled = true;
        }

        private void txt_TaxFileNumber_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_CreditLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45)
            {
                if (txt_CreditLimit.Text.Contains("-") == false)
                {
                    e.Handled = true;
                    txt_CreditLimit.Text = "-" + txt_CreditLimit.Text;
                    txt_CreditLimit.SelectionStart = txt_CreditLimit.TextLength;
                }
                else
                    e.Handled = true;
            }
            else if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                if (txt_CreditLimit.Text.Contains("."))
                {
                    char c = '.';
                    string[] sc = txt_CreditLimit.Text.Split(c);

                    if (sc[1].Length < 3)
                        e.Handled = false;
                    else
                        e.Handled = true;

                }
                else
                    e.Handled = false;

            }
            else if (e.KeyChar == 46)
            {
                if (txt_CreditLimit.Text.Contains(".") == false)
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void dgv_ExpenseAccounts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void dgv_ExpenseAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgv_ExpenseAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                AccountSearch accSearch = new AccountSearch();
                accSearch.filter = " AND AccountTypeName <> 'Header'";
                accSearch.ShowDialog();
                if (accSearch.selectedAccountName != null && accSearch.selectedAccountNumber != null)
                {
                    dgv_ExpenseAccounts.CurrentRow.Cells["AccountNumber"].Value = accSearch.selectedAccountNumber.ToString();
                    dgv_ExpenseAccounts.CurrentRow.Cells["AccountDescription"].Value = accSearch.selectedAccountName.ToString();
                    dgv_ExpenseAccounts.EndEdit();
                    int rn = 0;
                    for (int i = 0; i < dgv_ExpenseAccounts.Rows.Count; i++)
                    {
                        if (dgv_ExpenseAccounts.Rows[i].Cells["AccountNumber"].Value.ToString() == "")
                            rn++;
                    }
                    if (rn == 0)
                    {
                        DataRow r = dtVendorAccounts.NewRow();
                        dtVendorAccounts.Rows.Add(r);
                    }
                }

            }

        }

        private void dgv_ExpenseAccounts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                DataRow[] drs = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + dgv_ExpenseAccounts.CurrentCell.Value.ToString() + "'");
                if (drs.Length != 0)
                {
                    dgv_ExpenseAccounts.CurrentRow.Cells["AccountNumber"].Value = drs[0]["AccountNumber"].ToString();
                    dgv_ExpenseAccounts.CurrentRow.Cells["AccountDescription"].Value = drs[0]["AccountName"].ToString();
                    int rn = 0;
                    for (int i = 0; i < dgv_ExpenseAccounts.Rows.Count; i++)
                    {
                        if (dgv_ExpenseAccounts.Rows[i].Cells["AccountNumber"].Value.ToString() == "")
                            rn++;
                    }
                    if (rn == 0)
                    {
                        DataRow r = dtVendorAccounts.NewRow();
                        dtVendorAccounts.Rows.Add(r);
                    }
                }
                else
                {
                    MessageBox.Show("Check Account Number", "General Ledger");
                    dgv_ExpenseAccounts.CurrentCell.Value = "";
                }

            }
        }

        private void dgv_Contacts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rn = 0;
            for (int i = 0; i < dgv_Contacts.Rows.Count; i++)
            {
                if (dgv_Contacts.Rows[i].Cells["ContactName"].Value.ToString() == "")
                    rn++;
            }
            if (rn == 0)
            {
                DataRow r = dtVendorContacts.NewRow();
                dtVendorContacts.Rows.Add(r);
            }
        }

        private void txt_VendorArabicName_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void txt_VendorArabicName_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txt_TaxIDNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_VendorArabicName_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.GetCultureInfoByIetfLanguageTag("ar-EG"));
        }

        private void txt_VendorArabicName_Leave(object sender, EventArgs e)
        {
            txt_VendorCheckName.Focus();
            InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
        }

        private void groupBox1_EnabledChanged(object sender, EventArgs e)
        {
            if (groupBox1.Enabled == true)
                dgv.Enabled = false;
            else
                dgv.Enabled = true;
        }

        private void txt_VendorCode_TextChanged(object sender, EventArgs e)
        {
            txt_TermVendorCode.Text = txt_VendorCode.Text;
        }
    }
}