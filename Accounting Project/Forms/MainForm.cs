using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Accounting_GeneralLedger
{

    public partial class MainForm : Form
    {
        private const string LANGUAGE_DIRECTORY = "\\languages\\";
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        private string[] report_language_available = null;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;

        public MainForm()
        {
            InitializeComponent();
        }

        private void vendorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vendors vendors= new Vendors();
            vendors.ShowDialog(); 
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            Vendors vendors = new Vendors();
            vendors.ShowDialog(); 
        }

        private void btnVendorCategories_Click(object sender, EventArgs e)
        {
            VendorsCategories vendorcategories = new VendorsCategories();
            vendorcategories.ShowDialog(); 
        }

        private void vendorsCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VendorsCategories vendorcategories = new VendorsCategories();
            vendorcategories.ShowDialog(); 
        }

        private void btnVendorSearch_Click(object sender, EventArgs e)
        {
            VendorSearch vendorsearch = new VendorSearch();
            vendorsearch.ShowDialog(); 
        }

        private void vendorSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VendorSearch vendorsearch = new VendorSearch();
            vendorsearch.ShowDialog(); 
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AccountsDefinition accountsdefinition = new AccountsDefinition();
            accountsdefinition.ShowDialog(); 
        }

        private void btnAccountsDefinitions_Click(object sender, EventArgs e)
        {
            AccountsDefinition accountsdefinition = new AccountsDefinition();
            accountsdefinition.ShowDialog(); 
        }

        private void btnAccountSearch_Click(object sender, EventArgs e)
        {
            AccountSearch accountsearch = new AccountSearch();
            accountsearch.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AccountSearch accountsearch = new AccountSearch();
            accountsearch.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            AccountsPayableControl accountspayablecontrol = new AccountsPayableControl();
            accountspayablecontrol.ShowDialog();  
        }

        private void butAccountPayableControl_Click(object sender, EventArgs e)
        {
            AccountsPayableControl accountspayablecontrol = new AccountsPayableControl();
            accountspayablecontrol.ShowDialog();  
        }

        private void accountTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountTypes accountstype = new AccountTypes();
            accountstype.ShowDialog(); 
        }

        private void butAccountType_Click(object sender, EventArgs e)
        {
            AccountTypes accountstype = new AccountTypes();
            accountstype.ShowDialog();
        }

        private void addFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFolder addfolder = new AddFolder();
            addfolder.ShowDialog(); 
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            AddFolder addfolder = new AddFolder();
            addfolder.ShowDialog();
        }

        private void allocationMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllocationMaintenance allocationmaintenance = new AllocationMaintenance();
            allocationmaintenance.ShowDialog();
        }

        private void butAllocationMaintenance_Click(object sender, EventArgs e)
        {
            AllocationMaintenance allocationmaintenance = new AllocationMaintenance();
            allocationmaintenance.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            APTransactions aptransactions = new APTransactions();
            aptransactions.ShowDialog(); 
        }

        private void butAPManualCheck_Click(object sender, EventArgs e)
        {
            APTransactions aptransactions = new APTransactions();
            aptransactions.ShowDialog(); 
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ApplyCreditsScreen applycreditsscreen = new ApplyCreditsScreen();
            applycreditsscreen.ShowDialog(); 
        }

        private void butApplyCreditsScreen_Click(object sender, EventArgs e)
        {
            ApplyCreditsScreen applycreditsscreen = new ApplyCreditsScreen();
            applycreditsscreen.ShowDialog(); 
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            APTransactions aptransactions = new APTransactions();
            aptransactions.ShowDialog();
        }

        private void butAPTransactions_Click(object sender, EventArgs e)
        {
            APTransactions aptransactions = new APTransactions();
            aptransactions.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            BankAccountMaintenance bankaccountmaintenence = new BankAccountMaintenance();
            bankaccountmaintenence.ShowDialog(); 
        }

        private void butBankAccountMaintenance_Click(object sender, EventArgs e)
        {
            BankAccountMaintenance bankaccountmaintenence = new BankAccountMaintenance();
            bankaccountmaintenence.ShowDialog(); 
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Bank_Deposit bankdeposit = new Bank_Deposit();
            bankdeposit.ShowDialog();
        }

        private void butBankDeposit_Click(object sender, EventArgs e)
        {
            Bank_Deposit bankdeposit = new Bank_Deposit();
            bankdeposit.ShowDialog();
        }


        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            BatchSearch batchSearch = new BatchSearch();
            batchSearch.ShowDialog(); 
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            CashFlowCategories cashflowcategories = new CashFlowCategories();
            cashflowcategories.ShowDialog(); 
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            ChartsOfAccounts chartsofaccount = new ChartsOfAccounts();
            chartsofaccount.ShowDialog();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            Check_Book checkbook = new Check_Book();
            checkbook.ShowDialog(); 
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            Currency currency = new Currency();
            currency.ShowDialog();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            CurrencyConversionTable currencyconversiontable = new CurrencyConversionTable();
            currencyconversiontable.ShowDialog(); 
        }

        private void deliveryTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeliveryTypes deliverytypes = new DeliveryTypes();
            deliverytypes.ShowDialog();
        }

        private void enterRangeOfAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnterRangeOfAccounts enterrangeofaccounts = new EnterRangeOfAccounts();
            enterrangeofaccounts.ShowDialog();
        }

        private void fiscalPeriodSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiscalPeriodSetupfrm fiscalperiodsetupfrm = new FiscalPeriodSetupfrm();
            fiscalperiodsetupfrm.ShowDialog();
        }

        private void generalLedgerTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneralLedgerTemplate generalledgertemplate = new GeneralLedgerTemplate();
            generalledgertemplate.ShowDialog();
        }

        private void generalSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneralSetup generalsetup = new GeneralSetup();
            generalsetup.ShowDialog();
        }

        private void gLGeneralSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GLGeneralSetup glgeneralsetup = new GLGeneralSetup();
            glgeneralsetup.ShowDialog();
        }

        private void gLJournalCodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GLJournalCodes gljournalcodes = new GLJournalCodes();
            gljournalcodes.ShowDialog();
        }

        private void jVTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                JVTransactions jvtransactions = new JVTransactions();
                jvtransactions.ShowDialog();
            }
            catch (Exception e2) {
                MessageBox.Show(e2.Message);
            }
        }

        private void paymentTermsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentTerms paymentterms = new PaymentTerms();
            paymentterms.ShowDialog(); 
        }

        private void projectCodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectCodes projectcodes = new ProjectCodes();
            projectcodes.ShowDialog();
        }

        private void taxOfficeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaxOffice taxoffice = new TaxOffice();
            taxoffice.ShowDialog(); 
        }

        private void budgetMaintenanceToolStripMenuItem_Click(object sender, EventArgs e) {
            BudgetMaintenance bm = new BudgetMaintenance();
            bm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e) {
//            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.CreateSpecificCulture("FA")); //' just change the < FA > with any thing u want
            int cpt;
            try {
                this.report_language_available = System.IO.Directory.GetFiles(this.exe_path + LANGUAGE_DIRECTORY, "*.xml");
                if (this.report_language_available != null) {
                    for (cpt = 0; cpt < this.report_language_available.Length; cpt++)
                        this.report_language_available[cpt] = System.IO.Path.GetFileNameWithoutExtension(this.report_language_available[cpt]);
                    this.comboBox_language.Items.AddRange(this.report_language_available);
                }
            }
            catch {
                this.report_language_available = null;
            }
        }

        private void comboBox_language_SelectedIndexChanged(object sender, EventArgs e) {
            this.obj_options = new ClassOptions();
            this.obj_options.report_language = this.comboBox_language.Text;

            this.update_language_interface();
            // update visual information
            //this.update_information(this.last_raw_metar);
            //this.start_from_config();
        }

       

        private void update_language_interface() {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");

            this.Text = this.obj_interface_language.mainpage;
            this.fileToolStripMenuItem.Text = this.obj_interface_language.file;
            this.logInToolStripMenuItem.Text = this.obj_interface_language.logInUser;
            this.logOffUserToolStripMenuItem.Text = this.obj_interface_language.logOffUser;
            this.exitToolStripMenuItem.Text = this.obj_interface_language.exit;
            this.groupBox_language.Text = this.obj_interface_language.language;
            //this.groupBox_Window.Text = this.obj_interface_language.window;

            //this.checkBox_clouds.Text = this.obj_interface_language.weather;
            //this.checkBox_temp.Text = this.obj_interface_language.temperature;
            //this.checkBox_w_clouds.Text = this.obj_interface_language.weather;
            //this.checkBox_w_pressure.Text = this.obj_interface_language.pressure;
            //this.checkBox_w_temp.Text = this.obj_interface_language.temperature;
            //this.checkBox_w_topmost.Text = this.obj_interface_language.top_most_window;
            //this.checkBox_w_wind.Text = this.obj_interface_language.wind;
            //this.checkBox_wind_dir.Text = this.obj_interface_language.wind_direction;
            //this.checkBox_wind_speed.Text = this.obj_interface_language.wind_speed;

            //this.label_city.Text = this.obj_interface_language.country_city;
            //this.label_height_unit.Text = this.obj_interface_language.height;
            //this.label_length_unit.Text = this.obj_interface_language.length;
            //this.label_orientation.Text = this.obj_interface_language.orientation;
            //this.label_precipitation_height_unit.Text = this.obj_interface_language.precipitation_height;
            //this.label_pressure_unit.Text = this.obj_interface_language.pressure;
            //this.label_temp_unit.Text = this.obj_interface_language.temperature;
            //this.label_wind_unit.Text = this.obj_interface_language.wind;
            //this.label_window_opacity.Text = this.obj_interface_language.window_opacity;

            //this.label_proxy_ip.Text = this.obj_interface_language.proxy_ip;
            //this.label_proxy_port.Text = this.obj_interface_language.proxy_port;
            //this.label_proxy_type.Text = this.obj_interface_language.proxy_type;
            //this.label_remote_host_directory.Text = this.obj_interface_language.remote_host_directory;
            //this.label_remote_host_ip.Text = this.obj_interface_language.remote_host_ip;
            //this.label_remote_host_port.Text = this.obj_interface_language.remote_host_port;
            //this.checkBox_use_proxy.Text = this.obj_interface_language.use_proxy;
            //this.label_update_interval.Text = this.obj_interface_language.update_interval;
            //this.label_retry_interval.Text = this.obj_interface_language.retry_interval;

            //this.button_apply.Text = this.obj_interface_language.apply;
            //this.button_cancel.Text = this.obj_interface_language.cancel;
            //this.button_exit.Text = this.obj_interface_language.exit;

            //this.menuItem_about.Text = this.obj_interface_language.about;
            //this.menuItem_details.Text = this.obj_interface_language.details;
            //this.menuItem_exit.Text = this.obj_interface_language.exit;
            //this.menuItem_hide_show.Text = this.obj_interface_language.show_hide;
            //this.menuItem_options.Text = this.obj_interface_language.options;

            //this.show_state();

            //this.frm_details.Text = this.obj_interface_language.details;

            //this.frm_weather_view.set_tooltips_text(this.obj_interface_language.details, this.obj_interface_language.options);

        }
        
    }
}