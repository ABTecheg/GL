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
    public partial class AccountsPayableControl : Form
    {
        private dbAccountingProjectDS dbAccountingProjectDS;
        private SqlConnection sqlcon;
        private SqlDataAdapter adapterPaymentTerms,adapterGeneralSetup;
        private SqlCommandBuilder cmdbuilder;
        private int FirstPeriodDays, SecondPeriodDays, ThirdPeriodDays, FourthPeriodDays;
        private string validAccountNumber;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;

        public AccountsPayableControl()
        {
            InitializeComponent();
        }
        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.formAccountsPayableControl;
            this.label1.Text = obj_interface_language.APTradeGLAccountNumber;
            this.label2.Text = obj_interface_language.DefaultNewVendorStatus;
            this.label3.Text = obj_interface_language.DefaultNewVendorTerms;
            this.label4.Text = obj_interface_language.AllowMultiCurrencyInvoicy;
            this.label5.Text = obj_interface_language.PrintZeroBalanceChecks;
            this.label6.Text = obj_interface_language.PrintSummarizedChecks;
            this.label7.Text = obj_interface_language.AgingPeriods;
            this.label8.Text = obj_interface_language.Days;
            this.label9.Text = obj_interface_language.Description;
            this.label10.Text = obj_interface_language.Startof1stPeriod;
            this.label11.Text = obj_interface_language.Startof2ndPeriod;
            this.label12.Text = obj_interface_language.Startof3rdPeriod;
            this.label13.Text = obj_interface_language.Startof4thPeriod;
            this.label14.Text = obj_interface_language.UseWithHoldTax;
            this.label15.Text = obj_interface_language.DefaultPaymentDateStart;

            this.btn_Search.Text = obj_interface_language.btnSearch;
            this.btn_Done.Text = obj_interface_language.btnDoue;

        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            //AccountSearch accSearch = new AccountSearch();
            //accSearch.ShowDialog();
            //if (accSearch.selectedAccountName != null && accSearch.selectedAccountNumber != null)
            //{
            //    txt_AccountNumber.Text = accSearch.selectedAccountNumber;
            //}

            SearchForAccount(this.txt_AccountNumber);

        }

        private void SearchForAccount(TextBox txt)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.ShowDialog();
            txt.Text = accSearch.selectedAccountNumber;
        }
  

        private void AccountsPayableControl_Load(object sender, EventArgs e)
        {
            try
            {
                string msg = GeneralFunctions.CheckLockTables("", "", "", "");
                if (msg != "")
                {
                    MessageBox.Show("Can't Open Because Other Form Open By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                    return;
                }
                GeneralFunctions.LockTables("All", "AccountsPayableControl", "", "");

                dbAccountingProjectDS = new dbAccountingProjectDS();
                sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
                adapterPaymentTerms = new SqlDataAdapter("Select * from APPaymentTerms", sqlcon);
                adapterPaymentTerms.Fill(dbAccountingProjectDS.APPaymentTerms);

                cb_VendorTerms = GeneralFunctions.FillComboBox(dbAccountingProjectDS.APPaymentTerms, cb_VendorTerms, "PaymentTermCode", "PaymentTermCodeID");
                SqlConnection sqlcon10 = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlcon10.Open();
                if (!GeneralFunctions.SubTypesloaded)
                {
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
                fillData(sqlcon10);
                if (GeneralFunctions.languagechioce != "")
                {
                    this.obj_options = new ClassOptions();
                    this.obj_options.report_language = GeneralFunctions.languagechioce;
                    this.update_language_interface();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "system Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            if (GeneralFunctions.AccountNumberValidate(txt_AccountNumber.Text, out validAccountNumber) &&
               ValidateInput())
            {
                SaveAPGeneralSetup();
                this.Close();
            }
        }

        private bool ValidateInput()
        {
            if (GeneralFunctions.ValidateComboBox(cb_VendorStatus, "Please Select the Vendor Default Status") &&
                GeneralFunctions.ValidateComboBox(cb_VendorTerms, "Please Select the Vendor Default Terms") &&
                GeneralFunctions.ValidateComboBox(cb_PaymentDate, "Please Select the Vendor Default Payment Date") &&
                GeneralFunctions.ValidateString(txt_FirstPeriodDescription.Text, "Please Specify valid First Period Description") &&
                GeneralFunctions.ValidateString(txt_SecondPeriodDescription.Text, "Please Specify valid Second Period Description") &&
                GeneralFunctions.ValidateString(txt_ThirdPeriodDescription.Text, "Please Specify valid Third Period Description") &&
                GeneralFunctions.ValidateString(txt_FourthPeriodDescription.Text, "Please Specify valid Fourth Period Description") &&
                GeneralFunctions.ValidateInteger(txt_FirstPeriodDays.Text, "Please Specify valid first period days",out FirstPeriodDays) &&
                GeneralFunctions.ValidateInteger(txt_SecondPeriodDays.Text, "Please Specify valid second period days",out SecondPeriodDays) &&
                GeneralFunctions.ValidateInteger(txt_ThirdPeriodDays.Text, "Please Specify valid third period days", out ThirdPeriodDays ) &&
                GeneralFunctions.ValidateInteger(txt_FourthPeriodDays.Text, "Please Specify valid fourth period days", out FourthPeriodDays))
                return true;
            else
                return false;
        }

        private void SaveAPGeneralSetup()
        {
            try
            { 
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adapterGeneralSetup = new SqlDataAdapter("Select * from APGeneralSetup", sqlcon);
            adapterGeneralSetup.Fill(dbAccountingProjectDS.APGeneralSetup);
            cmdbuilder = new SqlCommandBuilder(adapterGeneralSetup);
            if (dbAccountingProjectDS.APGeneralSetup.Count == 0)
            {
                DataRow r = dbAccountingProjectDS.APGeneralSetup.NewRow();
                r["APGeneralSetupID"] = 0;
                r["APAccountNumber"] = validAccountNumber;
                r["DefaultVenderStatus"] = cb_VendorStatus.Text;
                r["DefaultVenderTerms"] = cb_VendorTerms.Text;
                r["DefaultPaymentDateStart"] = cb_PaymentDate.Text;
                if (checkbox_AllowMultiCurrency.Checked)
                    r["AllowMultiCurrencyInvoicy"] = 1;
                else
                    r["AllowMultiCurrencyInvoicy"] = 0;
                if (checkBox_WithHoldTax.Checked)
                    r["WithHoldTax"] = 1;
                else
                    r["WithHoldTax"] = 0;
                if (checkBox_PrintZeroBalance.Checked)
                    r["PrintZeroBalanceChecks"] = 1;
                else
                    r["PrintZeroBalanceChecks"] = 0;
                if (checkBox_PrintSummary.Checked)
                    r["PrintSummarized"] = 1;
                else
                    r["PrintSummarized"] = 0;
                r["FirstPeriodDays"] = FirstPeriodDays;
                r["FirstPeriodDescription"] = txt_FirstPeriodDescription.Text;
                r["SecondPeriodDays"] = SecondPeriodDays;
                r["SecondPeriodDescription"] = txt_SecondPeriodDescription.Text;
                r["ThirdPeriodDays"] = ThirdPeriodDays;
                r["ThirdPeriodDescription"] = txt_ThirdPeriodDescription.Text;
                r["FourthPeriodDays"] = FourthPeriodDays;
                r["FourthPeriodDescription"] = txt_FourthPeriodDescription.Text;
                dbAccountingProjectDS.APGeneralSetup.Rows.Add(r);
                adapterGeneralSetup.Update(dbAccountingProjectDS.APGeneralSetup);
            }
            else
            {
                if (DialogResult.OK == MessageBox.Show("The AP settings has already been defined\n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                {
                    DataRow[] rArr = dbAccountingProjectDS.APGeneralSetup.Select("APGeneralSetupID = 0");
                    rArr[0]["APAccountNumber"] = validAccountNumber;
                    rArr[0]["DefaultVenderStatus"] = cb_VendorStatus.Text;
                    rArr[0]["DefaultVenderTerms"] = cb_VendorTerms.Text;
                    rArr[0]["DefaultPaymentDateStart"] = cb_PaymentDate.Text;
                    if (checkbox_AllowMultiCurrency.Checked)
                        rArr[0]["AllowMultiCurrencyInvoicy"] = 1;
                    else
                        rArr[0]["AllowMultiCurrencyInvoicy"] = 0;
                    if (checkBox_WithHoldTax.Checked)
                        rArr[0]["WithHoldTax"] = 1;
                    else
                        rArr[0]["WithHoldTax"] = 0;
                    if (checkBox_PrintZeroBalance.Checked)
                        rArr[0]["PrintZeroBalanceChecks"] = 1;
                    else
                        rArr[0]["PrintZeroBalanceChecks"] = 0;
                    if (checkBox_PrintSummary.Checked)
                        rArr[0]["PrintSummarized"] = 1;
                    else
                        rArr[0]["PrintSummarized"] = 0;
                    rArr[0]["FirstPeriodDays"] = FirstPeriodDays;
                    rArr[0]["FirstPeriodDescription"] = txt_FirstPeriodDescription.Text;
                    rArr[0]["SecondPeriodDays"] = SecondPeriodDays;
                    rArr[0]["SecondPeriodDescription"] = txt_SecondPeriodDescription.Text;
                    rArr[0]["ThirdPeriodDays"] = ThirdPeriodDays;
                    rArr[0]["ThirdPeriodDescription"] = txt_ThirdPeriodDescription.Text;
                    rArr[0]["FourthPeriodDays"] = FourthPeriodDays;
                    rArr[0]["FourthPeriodDescription"] = txt_FourthPeriodDescription.Text;
                    adapterGeneralSetup.Update(dbAccountingProjectDS.APGeneralSetup);
                   
                }
                else
                {
                    txt_AccountNumber.Text = "";
                    cb_PaymentDate.SelectedIndex = -1;
                    cb_VendorStatus.SelectedIndex = -1;
                    cb_VendorTerms.SelectedIndex = -1;
                    txt_FirstPeriodDays.Text = "";
                    txt_FirstPeriodDescription.Text = "";
                    txt_SecondPeriodDays.Text = "";
                    txt_SecondPeriodDescription.Text = "";
                    txt_ThirdPeriodDays.Text = "";
                    txt_ThirdPeriodDescription.Text = "";
                    txt_FourthPeriodDays.Text = "";
                    txt_FourthPeriodDescription.Text = "";
                    checkbox_AllowMultiCurrency.Checked = false;
                    checkBox_PrintSummary.Checked = false;
                    checkBox_PrintZeroBalance.Checked = false;
                    checkBox_WithHoldTax.Checked = false;
                }
            }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void fillData(SqlConnection _Con)
        {
            SqlCommand MyComm = new SqlCommand();
            SqlDataReader MyDr = null;
            try
            {
                MyComm.CommandText = "Select * from APGeneralSetup";
                MyComm.CommandType = CommandType.Text;
                MyComm.Connection = _Con;
                MyDr = MyComm.ExecuteReader();
                while (MyDr.Read())
                {
                    //0 = MyDr["APGeneralSetupID"];
                    validAccountNumber = MyDr["APAccountNumber"].ToString();
                    txt_AccountNumber.Text = validAccountNumber.ToString();
                    cb_VendorStatus.Text = MyDr["DefaultVenderStatus"].ToString();
                    cb_VendorTerms.Text = MyDr["DefaultVenderTerms"].ToString();
                    cb_PaymentDate.Text = MyDr["DefaultPaymentDateStart"].ToString();

                    if (MyDr["AllowMultiCurrencyInvoicy"].ToString() == "1")
                        checkbox_AllowMultiCurrency.Checked = true;
                    else
                        checkbox_AllowMultiCurrency.Checked = false;
                    if (MyDr["WithHoldTax"].ToString() == "1")
                        checkBox_WithHoldTax.Checked = true;
                    else
                        checkBox_WithHoldTax.Checked = false;
                    if (MyDr["PrintZeroBalanceChecks"].ToString() == "1")
                        checkBox_PrintZeroBalance.Checked = true;
                    else
                        checkBox_PrintZeroBalance.Checked = false;
                    if (MyDr["PrintSummarized"].ToString() == "1")
                        checkBox_PrintSummary.Checked = true;
                    else
                        checkBox_PrintSummary.Checked = false;

                    FirstPeriodDays = int.Parse(MyDr["FirstPeriodDays"].ToString());
                    txt_FirstPeriodDays.Text = FirstPeriodDays.ToString();
                    txt_FirstPeriodDescription.Text = MyDr["FirstPeriodDescription"].ToString();
                    SecondPeriodDays = int.Parse(MyDr["SecondPeriodDays"].ToString());
                    txt_SecondPeriodDays.Text = SecondPeriodDays.ToString();
                    txt_SecondPeriodDescription.Text = MyDr["SecondPeriodDescription"].ToString();
                    ThirdPeriodDays = int.Parse(MyDr["ThirdPeriodDays"].ToString());
                    txt_ThirdPeriodDays.Text = ThirdPeriodDays.ToString();
                    txt_ThirdPeriodDescription.Text = MyDr["ThirdPeriodDescription"].ToString();
                    FourthPeriodDays = int.Parse(MyDr["FourthPeriodDays"].ToString());
                    txt_FourthPeriodDays.Text = FourthPeriodDays.ToString();
                    txt_FourthPeriodDescription.Text = MyDr["FourthPeriodDescription"].ToString();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            { _Con .Close(); }
        }

        private void cb_VendorTerms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_VendorTerms.Text == "<new>")
            {
                PaymentTerms payTerm = new PaymentTerms();
                payTerm.ShowDialog();
                cb_VendorTerms.Items.Clear();
                adapterPaymentTerms.Fill(dbAccountingProjectDS.APPaymentTerms);
                cb_VendorTerms = GeneralFunctions.FillComboBox(dbAccountingProjectDS.APPaymentTerms, cb_VendorTerms, "PaymentTermCode", "PaymentTermCodeID");
            }
        }

        private void txt_FirstPeriodDays_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_SecondPeriodDays_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_ThirdPeriodDays_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_FourthPeriodDays_KeyPress(object sender, KeyPressEventArgs e)
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

        private void AccountsPayableControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralFunctions.UnLockTable("", "AccountsPayableControl", "", "");
        }
    }
}