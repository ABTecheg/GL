using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Accounting_GeneralLedger
{
    public partial class GLInterface : Form
    {

        private const string LANGUAGE_DIRECTORY = "\\languages\\";
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        public static string[] report_language_available = null;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;

        public GLInterface()
        {
            InitializeComponent();
        }
        private void checkLoginStatus()
        {
            try
            {
                if (Function.UserPrev == "Administrator")
                    registerToolStripMenuItem.Visible = true;
                else
                    registerToolStripMenuItem.Visible = false;
                if (UserLogIn.valid == "true" || (UserLogIn.valid != "False" && Function.UserPrev == "Administrator"))
                {
                    GeneralFunctions.priviledgeItem(btnSetup);
                    GeneralFunctions.priviledgeItem(btnGL);
                    GeneralFunctions.priviledgeItem(btnGL_Setup);
                    GeneralFunctions.priviledgeItem(btnBank);
                    GeneralFunctions.priviledgeItem(reportsToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(accountDefinitionToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(userPleviledgeToolStripMenuItem);
                    //GeneralFunctions.priviledgeItem(helpToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(btnAP);
                    GeneralFunctions.priviledgeItem(generalSettingsToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(accountTypeToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(generalSetupToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(companyNameToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(fiscalYearSetupToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(currencyToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(currencyConvertionToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(gLGeneralSetupToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(chartOfAccountsToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(allocationMaintenanceToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(glJournalCodesToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(projectCodesToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(transactionsTempMaintenanceToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(jVTransactionsToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(allocationRunToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(budgetMaintenanceToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(endYearToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(endPeriodToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(chartOfAccountToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(glJournalToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(gLDetailToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(gLBatchReportToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(acountTransactionsToolStripMenuItem1);
                    GeneralFunctions.priviledgeItem(gLTrailBalanceToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(applyCreditsScreenToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(aPTransactionsToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(acountTransactionsToolStripMenuItem1);
                    GeneralFunctions.priviledgeItem(taxOfficeToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(taxReasonToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(deliveryTypesToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(vendorsCategoriesToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(paymentTermsToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(vendorsToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(balanceSheetToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(endYearAdjustmentsToolStripMenuItem);
                    GeneralFunctions.priviledgeItem(transactionsCashierToolStripMenuItem);

                    comboBox_language.Text = GeneralFunctions.newLanguage;
                    btnSetup.Enabled = true;
                    btnGL.Enabled = true;
                    reportsToolStripMenuItem.Enabled = true;
                    logOffUserToolStripMenuItem.Enabled = true;
                    logInToolStripMenuItem.Enabled = false;
                    btnAR.Enabled = true;
                }
                else
                {
                    btnSetup.Enabled = false;
                    btnGL.Enabled = false;
                    reportsToolStripMenuItem.Enabled = false;
                    logOffUserToolStripMenuItem.Enabled = false;
                    logInToolStripMenuItem.Enabled = true;
                    btnAP.Enabled = false;
                    btnBank.Enabled = false;
                    //helpToolStripMenuItem.Enabled = false;
                    btnAR.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GLInterface_Load(object sender, EventArgs e)
        {
            try
            {
                //update AccountFormat
                SqlConnection MyConnection;
                SqlCommand MyComm;

                MyConnection = new SqlConnection(GeneralFunctions.ConnectionString);
                MyConnection.Open();

                MyComm = new SqlCommand("Update GeneralSetup  set AccountNumberFormat =  '' " , MyConnection);
                MyComm.ExecuteNonQuery();
                //update AccountFormat


                checkLoginStatus();
                int cpt;
                try
                {
                    GLInterface.report_language_available = System.IO.Directory.GetFiles(this.exe_path + LANGUAGE_DIRECTORY, "*.xml");
                    if (GLInterface.report_language_available != null)
                    {
                        for (cpt = 0; cpt < GLInterface.report_language_available.Length; cpt++)
                            GLInterface.report_language_available[cpt] = System.IO.Path.GetFileNameWithoutExtension(GLInterface.report_language_available[cpt]);
                        this.comboBox_language.Items.AddRange(GLInterface.report_language_available);
                    }
                }
                catch
                {
                    GLInterface.report_language_available = null;
                }
                //logOffUserToolStripMenuItem_Click(sender, e);
                dbAccountingProjectDS dbAccountingProjectDS = new dbAccountingProjectDS();

                SqlConnection sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlDataAdapter adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
                adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
                foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
                {
                    if (dr["MultiCurrency"].ToString() == "True")
                        GeneralFunctions.GMultiCurrency = 1;
                    else
                        GeneralFunctions.GMultiCurrency = 0;
                }
                if (GeneralFunctions.GMultiCurrency == 1)
                {
                    this.currencyConvertionToolStripMenuItem.Visible = true;
                    this.currencyToolStripMenuItem.Visible = true;
                }
                else
                {
                    this.currencyConvertionToolStripMenuItem.Visible = false;
                    this.currencyToolStripMenuItem.Visible = false;
                }
                SqlConnection sqlconLanguage = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand sqlcomLanguage = new SqlCommand("Select SelectedLanguage From GeneralSetup", sqlconLanguage);
                sqlconLanguage.Open();
                SqlDataReader sqlread = sqlcomLanguage.ExecuteReader();
                if (sqlread.HasRows)
                {
                    sqlread.Read();
                    comboBox_language.Text = sqlread.GetString(0);
                }
                sqlread.Close();
                sqlconLanguage.Close();
                //logInToolStripMenuItem_Click(sender, e);
                Load_G_Report();
            }
            catch { }
            finally
            {
                if (Function.FUNAVL.Count > 0)
                {
                    if (Function.FUNAVL.Contains("SS"))
                    {
                        btnSetup.Visible = true;
                    }
                    if (Function.FUNAVL.Contains("GL"))
                    {
                        btnGL.Visible = true;
                        btnGL_Setup.Visible = true;
                    }
                    if (Function.FUNAVL.Contains("AP"))
                    {
                        btnAP.Visible = true;
                        btnAP_Setup.Visible = true;
                    }
                    if (Function.FUNAVL.Contains("AR"))
                    {
                        btnAR.Visible = true;
                        btnAR_Setup.Visible = true;
                    }
                    if (Function.FUNAVL.Contains("Bank"))
                    {
                        btnBank.Visible = true;
                        btnBank_Setup.Visible = true;
                    }
                }
            }

        }
        private void Load_G_Report()
        {
            try
            {
                DataTable dt = DataClass.RetrieveData("SELECT Rpt_Code, Rpt_Name FROM dbo.G_Report AS GR Where GR.Active = "+"'true'");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ToolStripMenuItem btnGRpt = new ToolStripMenuItem();
                    btnGRpt.Name = "GRpt_" + dt.Rows[i]["Rpt_Code"].ToString();
                    btnGRpt.Size = new System.Drawing.Size(162, 22);
                    btnGRpt.Text = dt.Rows[i]["Rpt_Name"].ToString();
                    btnGRpt.Tag = dt.Rows[i]["Rpt_Code"].ToString();
                    btnGRpt.Click += new System.EventHandler(btnGRpt_Click);

                    this.generateReportsToolStripMenuItem.DropDownItems.Add(btnGRpt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGRpt_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem btn = (ToolStripMenuItem)sender;
                Rpt_Generate_Report frm = new Rpt_Generate_Report();
                frm.Text = btn.Text.Trim();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string[] ss = frm.Prd.Split((new string[] { "/" }), StringSplitOptions.RemoveEmptyEntries);
                    int Rpt_Prd = 0; int.TryParse(ss[0].Trim(), out Rpt_Prd);
                    int Rpt_Year = 0; int.TryParse(ss[1].Trim(), out Rpt_Year);
                    if (Rpt_Prd != 0 && Rpt_Year != 0)
                    {
                        System.Threading.Thread Mythr = (new Generate_Report()).RunReport(btn.Tag.ToString(), btn.Text.Trim(), Rpt_Year, Rpt_Prd);
                        Function.FormLoadingShow("Building Report ...", Mythr);
                    }
                    else
                        MessageBox.Show("Check Selected Period", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void comboBox_language_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.obj_options = new ClassOptions();
            this.obj_options.report_language = this.comboBox_language.Text;
            GeneralFunctions.languagechioce = this.obj_options.report_language;
            this.update_language_interface();
        }

        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");

            this.Text = this.obj_interface_language.mainpage;
            this.fileToolStripMenuItem.Text = this.obj_interface_language.file;
            this.logInToolStripMenuItem.Text = this.obj_interface_language.logInUser;
            this.logOffUserToolStripMenuItem.Text = this.obj_interface_language.logOffUser;
            this.exitToolStripMenuItem.Text = this.obj_interface_language.exit;
            this.groupBox_language.Text = this.obj_interface_language.language;
            this.btnSetup.Text = this.obj_interface_language.systemConfiguration;
            this.companyNameToolStripMenuItem.Text = this.obj_interface_language.companyName;
            this.generalSetupToolStripMenuItem.Text = this.obj_interface_language.generalSetup;
            this.accountTypeToolStripMenuItem.Text = this.obj_interface_language.accountType;
            this.accountDefinitionToolStripMenuItem.Text = this.obj_interface_language.accountDefinition;
            this.chartOfAccountsToolStripMenuItem.Text = this.obj_interface_language.chartOfAccounts;
            this.currencyToolStripMenuItem.Text = this.obj_interface_language.currency;
            this.currencyConvertionToolStripMenuItem.Text = this.obj_interface_language.currencyConversion;
            this.projectCodesToolStripMenuItem.Text = this.obj_interface_language.projectCodes;
            this.glJournalCodesToolStripMenuItem.Text = this.obj_interface_language.journalCodes;
            this.fiscalYearSetupToolStripMenuItem.Text = this.obj_interface_language.fiscalPeriod;
            this.userPleviledgeToolStripMenuItem.Text = this.obj_interface_language.userPriviledge;
            this.btnGL.Text = this.obj_interface_language.operations;
            this.jVTransactionsToolStripMenuItem.Text = this.obj_interface_language.jvTransactions;
            this.budgetMaintenanceToolStripMenuItem.Text = this.obj_interface_language.budgetMaintenance;
            this.endPeriodToolStripMenuItem.Text = this.obj_interface_language.endPeriod;
            this.endYearToolStripMenuItem.Text = this.obj_interface_language.endYear;
            this.reportsToolStripMenuItem.Text = this.obj_interface_language.reports;
            this.reportGaneratorToolStripMenuItem.Text = this.obj_interface_language.reportGenerator;
            this.helpToolStripMenuItem.Text = this.obj_interface_language.help;
            this.aboutToolStripMenuItem1.Text = this.obj_interface_language.contactUs;
            this.generalSettingsToolStripMenuItem.Text = this.obj_interface_language.General_Settings;
            this.btnGL_Setup.Text = this.obj_interface_language.General_Ledger_Setup;
            this.gLGeneralSetupToolStripMenuItem.Text = this.obj_interface_language.G_L_General_Setup;
            this.allocationMaintenanceToolStripMenuItem.Text = this.obj_interface_language.Allocation_Maintenance;
            this.transactionsTempMaintenanceToolStripMenuItem.Text = this.obj_interface_language.TransactionsTemp_Maintenance;
            this.btnAP_Setup.Text = this.obj_interface_language.Account_Payable_Setup;
            this.taxOfficeToolStripMenuItem.Text = this.obj_interface_language.Tax_Office;
            this.taxReasonToolStripMenuItem.Text = this.obj_interface_language.Tax_Reason;
            this.deliveryTypesToolStripMenuItem.Text = this.obj_interface_language.Delivery_Types;
            this.vendorsCategoriesToolStripMenuItem.Text = this.obj_interface_language.Vendors_Categories;
            this.paymentTermsToolStripMenuItem.Text = this.obj_interface_language.Payment_Terms;
            this.vendorsToolStripMenuItem.Text = this.obj_interface_language.STVendors;
            this.allocationRunToolStripMenuItem.Text = this.obj_interface_language.Run_Allocation;
            this.gLBatchReportToolStripMenuItem.Text = this.obj_interface_language.GL_Batch_Report;
            this.chartOfAccountToolStripMenuItem.Text = this.obj_interface_language.Chart_of_Account;
            this.glJournalToolStripMenuItem.Text = this.obj_interface_language.GL_Journal;
            this.gLDetailToolStripMenuItem.Text = this.obj_interface_language.GL_Detail;
            this.gLTrailBalanceToolStripMenuItem.Text = this.obj_interface_language.GL_Trail_Balance;
            this.btnAP.Text = this.obj_interface_language.Account_Payable;
            this.acountTransactionsToolStripMenuItem1.Text = this.obj_interface_language.Accounts_Payable_Control;
            this.aPTransactionsToolStripMenuItem.Text = this.obj_interface_language.STAPTransactions;
            this.applyCreditsScreenToolStripMenuItem.Text = this.obj_interface_language.Apply_CreditsScreen;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void accountDefinitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountsDefinition accountsdefinition = new AccountsDefinition();
            accountsdefinition.ShowDialog();
        }

        private void accountTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountTypes accountTypes = new AccountTypes();
            accountTypes.ShowDialog();
        }

        private void generalSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void chartOfAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChartsOfAccounts chartsOfAccounts = new ChartsOfAccounts();
            chartsOfAccounts.ShowDialog();
        }

        private void currencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void currencyConvertionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrencyConversionTable currencyConversionTable = new CurrencyConversionTable();
            currencyConversionTable.ShowDialog();
        }

        private void projectCodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectCodes projectCodes = new ProjectCodes();
            projectCodes.ShowDialog();
        }

        private void glJournalCodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GLJournalCodes gljournalCodes = new GLJournalCodes();
            gljournalCodes.ShowDialog();
        }

        private void jVTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JVTransactions jvTransactions = new JVTransactions();
            jvTransactions.ShowDialog();
        }

        private void budgetMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BudgetMaintenance budgetMaintenance = new BudgetMaintenance();
            budgetMaintenance.ShowDialog();
        }

        private void fiscalYearSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiscalPeriodSetupfrm fiscalPeriod = new FiscalPeriodSetupfrm();
            fiscalPeriod.ShowDialog();
        }

        private void companyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void reportGaneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportGenerator rg = new reportGenerator();
            rg.ShowDialog();
        }

        private void endPeriodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EndMonth em = new EndMonth();
            em.ShowDialog();
        }

        private void endYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ENDYear ey = new ENDYear();
            ey.ShowDialog();
        }

        private void logOffUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserLogIn.valid = "False";
            checkLoginStatus();
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserLogIn uli = new UserLogIn();
            uli.ShowDialog();
            checkLoginStatus();
        }

        private void userPleviledgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserPrivilrdge up = new UserPrivilrdge();
            up.ShowDialog();
        }

        private void aPTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            APTransactions frm = new APTransactions();
            frm.ShowDialog();
        }

        private void acountTransactionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void allocationMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aPManualCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AP_Manual_Check frm = new AP_Manual_Check();
            frm.ShowDialog();
        }

        private void bankDepositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bank_Deposit frm = new Bank_Deposit();
            frm.ShowDialog();
        }


        private void cashFlowCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashFlowCategories frm = new CashFlowCategories();
            frm.ShowDialog();
        }

        private void checkBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Check_Book frm = new Check_Book();
            frm.ShowDialog();
        }

        private void mainFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm frm = new MainForm();
            frm.ShowDialog();
        }

        private void menuFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuForm frm = new MenuForm();
            frm.ShowDialog();
        }

        private void applyCreditsScreenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ApplyCreditsScreen frm = new ApplyCreditsScreen();
            frm.ShowDialog();
        }

        private void allocationMaintenanceToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void allocationRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Allocation_Run frm = new Allocation_Run();
            frm.ShowDialog();
        }

        private void transactionsTempMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void gLBatchReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void chartOfAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void glJournalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gLDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gLTrailBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generalSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void companyNameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CompanyForm companyN = new CompanyForm();
            companyN.ShowDialog();

        }

        private void generalSetupToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GeneralSetup generalSetup = new GeneralSetup();
            generalSetup.ShowDialog();
        }

        private void fiscalYearSetupToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FiscalPeriodSetupfrm fiscalPeriod = new FiscalPeriodSetupfrm();
            fiscalPeriod.ShowDialog();

        }

        private void currencyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Currency currency = new Currency();
            currency.ShowDialog();

        }

        private void currencyConvertionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CurrencyConversionTable currencyConversionTable = new CurrencyConversionTable();
            currencyConversionTable.ShowDialog();

        }

        private void accountDefinitionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AccountsDefinition accountsdefinition = new AccountsDefinition();
            accountsdefinition.ShowDialog();

        }

        private void chartOfAccountsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ChartsOfAccounts chartsOfAccounts = new ChartsOfAccounts();
            chartsOfAccounts.ShowDialog();

        }

        private void projectCodesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ProjectCodes projectCodes = new ProjectCodes();
            projectCodes.ShowDialog();

        }

        private void glJournalCodesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GLJournalCodes gljournalCodes = new GLJournalCodes();
            gljournalCodes.ShowDialog();

        }

        private void allocationMaintenanceToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            AllocationMaintenance frm = new AllocationMaintenance();
            frm.ShowDialog();

        }

        private void transactionsTempMaintenanceToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            JVTransactionsTemp frm = new JVTransactionsTemp();
            frm.ShowDialog();

        }

        private void gLBatchReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RptGLBatch frm = new RptGLBatch();
            frm.ShowDialog();

        }

        private void chartOfAccountToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RptChart frm = new RptChart();
            frm.ShowDialog();

        }

        private void glJournalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RptJournal frm = new RptJournal();
            frm.ShowDialog();

        }

        private void gLDetailToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RptGLAccountDetail frm = new RptGLAccountDetail();
            frm.ShowDialog();

        }

        private void gLTrailBalanceToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RptGLTrialBalance frm = new RptGLTrialBalance();
            frm.ShowDialog();

        }

        private void gLGeneralSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneralLadger_GeneralSetup frm = new GeneralLadger_GeneralSetup();
            frm.ShowDialog();

        }

        private void taxOfficeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaxOffice frm = new TaxOffice();
            frm.ShowDialog();

        }

        private void taxReasonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaxReason frm = new TaxReason();
            frm.ShowDialog();

        }

        private void deliveryTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeliveryTypes frm = new DeliveryTypes();
            frm.ShowDialog();

        }

        private void vendorsCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VendorsCategories frm = new VendorsCategories();
            frm.ShowDialog();

        }

        private void paymentTermsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentTerms frm = new PaymentTerms();
            frm.ShowDialog();

        }

        private void vendorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vendors frm = new Vendors();
            frm.ShowDialog();

        }

        private void balanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RptBalanceSheet frm = new RptBalanceSheet();
            frm.ShowDialog();
        }

        private void viewGLAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewGLAcc frm = new ViewGLAcc();
            frm.ShowDialog();
        }

        private void endYearAdjustmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JVEndYearAdjustments frm = new JVEndYearAdjustments();
            frm.ShowDialog();
        }

        private void accountCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ARAccountCategory frm = new ARAccountCategory();
            frm.ShowDialog();
        }

        private void typeCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeCategories frm = new TypeCategories();
            frm.ShowDialog();

        }

        private void accountCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ARAccountCategories2 frm = new ARAccountCategories2();
            frm.ShowDialog();

        }

        private void discountCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ARDiscountCategories frm = new ARDiscountCategories();
            frm.ShowDialog();

        }

        private void aRSystemControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ARSystemControl frm = new ARSystemControl();
            frm.ShowDialog();

        }

        private void aRCustomerMaintainanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ARCustomerMaintainance frm = new ARCustomerMaintainance();
            frm.ShowDialog();

        }

        private void aRTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ARTransactions frm = new ARTransactions();
            frm.ShowDialog();

        }

        private void vendorListReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPTVendorList frm = new RPTVendorList();
            frm.ShowDialog();

        }

        private void batchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPTAPBatch frm = new RPTAPBatch();
            frm.ShowDialog();

        }

        private void transactionCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ARTransactionCodes frm = new ARTransactionCodes();
            frm.ShowDialog();
        }

        private void openItemReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPTOpenItem frm = new RPTOpenItem();
            frm.ShowDialog();

        }

        private void aRPaymentsTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ARPaymentsTransactions frm = new ARPaymentsTransactions();
            frm.ShowDialog();
        }

        private void ageOpenItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPTAgeOpenItem frm = new RPTAgeOpenItem();
            frm.ShowDialog();

        }

        private void purchaseJouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPTPurchseJournal frm = new RPTPurchseJournal();
            frm.ShowDialog();

        }

        private void destributionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPTAPDestributionFrm frm = new RPTAPDestributionFrm();
            frm.ShowDialog();

        }

        private void aRApplyCreditScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ARApplyCreditsScreen frm = new ARApplyCreditsScreen();
            frm.ShowDialog();
        }

        private void aRGenerateInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ARGenerateInvoice frm = new ARGenerateInvoice();
            frm.ShowDialog();
        }

        private void accountsPayableControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountsPayableControl frm = new AccountsPayableControl();
            frm.ShowDialog();

        }

        private void departmentCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepartmentCode frm = new DepartmentCode();
            frm.ShowDialog();
        }

        private void availableTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AvailableTables frm = new AvailableTables();
            frm.ShowDialog();
        }

        private void customerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPTARCustList frm = new RPTARCustList();
            frm.ShowDialog();
        }

        private void byBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RptARTranBatch frm = new RptARTranBatch();
            frm.ShowDialog();
        }

        private void byTransactionCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPTARTranCode frm = new RPTARTranCode();
            frm.ShowDialog();
        }

        private void byCustomerAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPTARTranCust frm = new RPTARTranCust();
            frm.ShowDialog();
        }

        private void aRAgingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPTARAging frm = new RPTARAging();
            frm.ShowDialog();
        }

        private void aRPaymentHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPTARPaymentHistory.txtReport = "Payment";
            RPTARPaymentHistory frm = new RPTARPaymentHistory();
            frm.ShowDialog();
        }

        private void aRCreditReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPTARPaymentHistory.txtReport = "Credit";
            RPTARPaymentHistory frm = new RPTARPaymentHistory();
            frm.ShowDialog();
        }
        private void aRPaymentAndCreditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPTARPaymentHistory.txtReport = "Both";
            RPTARPaymentHistory frm = new RPTARPaymentHistory();
            frm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmabout frm = new Frmabout();
            frm.ShowDialog();
        }

        private void columnDefinitionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Generate_Report_Columns frm = new Generate_Report_Columns();
            frm.ShowDialog();
        }

        private void rowDefinitionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Generate_Report_Rows frm = new Generate_Report_Rows();
            frm.ShowDialog();
        }

        private void rowDefinitionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Generate_Report_Setup frm = new Generate_Report_Setup();
            frm.ShowDialog();
        }

        private void aRTempMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ARTransactionsTemp frm = new ARTransactionsTemp();
            frm.ShowDialog();
        }

        private void transactionsCashierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JVTran_Cashier JvTran_Cashier = new JVTran_Cashier();
            JvTran_Cashier.ShowDialog();
        }

        private void bankAccountSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bank_Account_Setup frmBank_Account_Setup = new Bank_Account_Setup();
            frmBank_Account_Setup.ShowDialog();
        }

        private void bankDepositTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bank_Deposit_Type frmBank_Deposit_Type = new Bank_Deposit_Type();
            frmBank_Deposit_Type.ShowDialog();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string guid = ((System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), true))[0] as System.Runtime.InteropServices.GuidAttribute).Value.ToString();
                dllCryptoMT.FrmKey.Register(guid, "eltohamy@advbtech.com", "+224144668", "CrYpToMtFoRaHs*2", ref Function.StateVer, ref Function.FUNAVL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearanceCompaniesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearanceCompanies frm = new ClearanceCompanies();
            frm.ShowDialog();
        }

        private void shippingAgentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShippingAgent frm = new ShippingAgent();
            frm.ShowDialog();
        }

        private void shippingLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShippingLine frm = new ShippingLine();
            frm.ShowDialog();
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {

        }
    }
}