/*
Copyright (C) 2004 Jacquelin POTIER <jacquelin.potier@free.fr>
Dynamic aspect ratio code Copyright (C) 2004 Jacquelin POTIER <jacquelin.potier@free.fr>

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; version 2 of the License.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
*/
using System; using Accounting_GeneralLedger.Report;

namespace Accounting_GeneralLedger
{
    /// <summary>
    /// Summary description for ClassInterfaceLanguage.
    /// </summary>
    public class ClassInterfaceLanguage
    {


        public string mainpage = "Star Financial";
        public string btnpro_code = "OK";
        public string formspc = "SearchProjectCode";
        public string dgvspc_code = "ProjectCode";
        public string dgvspc_desc = "ProjectDescription";
        public string file = "File";
        public string logInUser = "Log In User";
        public string logOffUser = "Log Off User";
        public string exit = "Exit";
        public string systemConfiguration = "System Settings";
        public string companyName = "Company Name";
        public string generalSetup = "Current State";
        public string accountType = "Account Type";
        public string accountDefinition = "Account Definition";
        public string chartOfAccounts = "Chart Of Accounts";
        public string currency = "Currency";
        public string currencyConversion = "Currency Conversion";
        public string projectCodes = "Project Codes";
        public string journalCodes = "Journal Codes";
        public string fiscalPeriod = "Fiscal Period Setup";
        public string userPriviledge = "User Priviledge";
        public string operations = "Operations";
        public string jvTransactions = "Transaction Maintenance";
        public string budgetMaintenance = "Budget Maintenance";
        public string endPeriod = "End Period";
        public string endYear = "End Year";
        public string reports = "Reports";
        public string reportGenerator = "Report Ganerator";
        public string help = "Help";
        public string contactUs = "Contact Us";
        public string formCompanyName = "Company Name";
        public string labelCompanyName = "Company Name";
        public string labelAddress = "Company Name";
        public string labelphone = "Company Name";
        public string labelmobile = "Company Name";
        public string labelmail = "Company Name";
        public string labelweb = "Company Name";
        public string buttonEdit = "Edit";
        public string buttonCompanyOK = "Save";
        public string buttonCompanyExit = "Exit";
        public string formAccountsDefinition = "Accounts Definition";
        public string formTypesCategories = "Types Categories";
        public string dgvAccountDefinitionColumn1 = "AccountNumber";
        public string dgvAccountDefinitionColumn2 = "AccountName";
        public string dgvAccountPercentage = "Percentage";
        public string labelAccountType = "Account Type";
        public string labelAccountNumber = "Account Number";
        public string labelAccountName = "Account Name";
        public string labelOpeningBalance = "Opening Balance";
        public string labelStatus = "Status";
        public string checkboxActive = "Active";
        public string buttonbtnNew = "New";
        public string buttonbtnEdit = "Edit";
        public string buttonbtnDelete = "Delete";
        public string buttonbtnUndo = "Undo";
        public string language = "English";
        public string formAccountsTypes = "Account Types";
        public string dgvAccountTypesColumn1 = "AccountTypeName";
        public string dgvAccountTypesColumn2 = "AccountTypeClass";
        public string labelAccountTypeID = "Account Type ID";
        public string labelAccountTypeName = "Account Type Name";
        public string groupboxAccountTypeClassifications = "Account Type Classifications";
        public string checkbox_credit = "Credit";
        public string checkbox_debit = "Debit";
        public string checkbox_other = "Other";
        public string formGeneralSetup = "General Setup";
        public string labelMaxAccountNumber = "Max Account Number";
        public string labelDecimalPoint = "Decimal Point";
        public string labelJVNumberFormat = "JV Number Format";
        public string labelAPNumberFormat = "AP Number Format";
        public string labelARNumberFormat = "AR Number Format";
        public string lblDefaultLanguage = "Default Language";
        public string labelMaxNumberSubLevel = "Max Number Of SubLevel in Charts of Accounts";
        public string buttonbtnOk = "Save - Exit";
        public string formChartsOfAccounts = "Chart Of Accounts";
        public string dgvChartsOfAccountsColumn1 = "Acc Number";
        public string dgvChartsOfAccountsColumn2 = "Acc Name";
        public string dgvChartsOfAccountsColumn3 = "Acc Type";
        public string dgvChartsOfAccountsColumn4 = "Ative";
        public string buttonbtn_AddAccount = "Add Account";
        public string formCurrency = "Currency";
        public string dgvCurrencyColumn1 = "CurrencyNo";
        public string dgvCurrencyColumn2 = "CurrencyCode";
        public string dgvCurrencyColumn3 = "CurrencySign";
        public string dgvCurrencyColumn4 = "GL AccountNo";
        public string dgvCurrencyColumn5 = "PL AccountNo";
        public string dgvCurrencyColumn6 = "CurrencyDescrip";
        public string dgvCurrencyColumn7 = "Active";
        public string dgvCurrencyColumn8 = "BaseCurrency";
        public string labelCurrencyCodeID = "Currency Code ID";
        public string labelCurrencyCode = "Currency Code";
        public string labelCurrencyCodeSign = "Currency Sign";
        public string labelGLAccountNumber = "Gl Account Number";
        public string labelPLAccountNumber = "Currecny P/L Account Number";
        public string labelCurrencyDescreption = "Currency Description";
        public string checkbox_Active = "Active";
        public string checkbox_baseCurrency = "Base Currency";
        public string formCurrencyConversionTable = "Currency Converion Table";
        public string dgvCurrencyConvCodeColumn1 = "CurrencyConvID";
        public string dgvCurrencyConvCodeColumn2 = "Currency Code";
        public string dgvCurrencyConvCodeColumn3 = "Exchange Rate";
        public string dgvCurrencyConvCodeColumn4 = "Effective Date";
        public string labelCurrencyConvCodeID = "Currency Code ID";
        public string labelCurrencyConvCode = "Currency Code";
        public string labelExchangeRate = "Exchange Rate";
        public string labelExchangeDate = "Exchange Date";
        public string formProjectCodes = "Project Codes";
        public string dgvProjectCodesColumn1 = "ProjectCode";
        public string dgvProjectCodesColumn2 = "ProjectDescription";
        public string dgvProjectCodesColumn3 = "Budget";
        public string dgvProjectCodesColumn4 = "BudgetCurrencyCo";
        public string dgvProjectCodesColumn5 = "StartDate";
        public string dgvProjectCodesColumn6 = "EndDate";
        public string dgvProjectCodesColumn7 = "Active";
        public string labelProjectCodeID = "Project Code ID";
        public string labelProjectCode = "Project Code";
        public string labelProjectDescription = "Project Description";
        public string labelBudget = "Budget";
        public string labelStartDate = "StartDate";
        public string labelEndDate = "EndDate";
        public string labelProjectCodeStatus = "Status";
        public string checkbox_ProjectCodeActive = "Active";
        public string formGLJournalCodes = "GLJournalCodes";
        public string dgvGLJournalCodesColumn1 = "JournalCode";
        public string dgvGLJournalCodesColumn2 = "JournalDescription";
        public string labelJournalCodeID = "Journal Code ID";
        public string labelJournalCode = "Journal Code";
        public string labelJournalDescription = "Journal Description";
        public string formJVTransactions = "Transactions Maintenance";
        public string formAllocationMaintenance = "Allocation Maintenance";
        public string labelBatch = "Batch";
        public string labelJVNumber = "JVNumber";
        public string labelJVDescription = "JVDescription";
        public string labelTemplateName = "Template Name";
        public string labelJVCode = "JV Code";
        public string labelJVDate = "JV Date";
        public string labelPeriod = "Period";
        public string labelJVTransactionsStatus = "Status";
        public string labelBalance = "Balance";
        public string checkbox_multiCurrency = "MultiCurrency";
        public string checkbox_Reverse = "Reverse?";
        public string buttonJVTransactionNew = "New";
        public string buttonJVTransactionSaveNew = "Save";
        public string buttonJVTransactionEdit = "Edit";
        public string buttonJVTransactionSaveEdit = "Save";
        public string buttonJVTransactionDelete = "Delete";
        public string buttonJVTransactionSaveDelete = "Save";
        public string buttonJVTransactionPost = "Post";
        public string buttonJVTransactionPrint = "Print";
        public string buttonJVTransactionCopy = "Copy";
        public string buttonJVTransactionExit = "Exit";
        public string buttonJVTransactionUndo = "Undo";
        public string dgvJVTransactionsColumn1 = "Account Number";
        public string dgvJVTransactionsColumn2 = "Account Name";
        public string dgvJVTransactionsColumn4 = "Date";
        public string dgvJVTransactionsColumn5 = "Reference";
        public string dgvJVTransactionsColumn6 = "Credit";
        public string dgvJVTransactionsColumn7 = "Credit FC";
        public string dgvJVTransactionsColumn8 = "Debit";
        public string dgvJVTransactionsColumn9 = "Debit FC";
        public string dgvJVTransactionsColumn10 = "Units";
        public string dgvJVTransactionsColumn12 = "Project Code";
        public string buttonJVTransactionsFind = "Find";
        public string formBudgetMaintenance = "Budget Maintenance";
        public string labelBudgetMaintenanceFiscalYear = "Fiscal Year";
        public string labelBudgetMaintenanceAccountNumber = "Account Number";
        public string labelBudgetMaintenanceAccountName = "Account Name";
        public string labelBudgetMaintenanceAccountType = "Account Type";
        public string checkboxBudgetMaintenanceActive = "Include Inactive Accounts";
        public string buttonBudgetMaintenanceSave = "Save";
        public string buttonBudgetMaintenanceAdd = "Add New Account";
        public string buttonBudgetMaintenanceExit = "Exit";
        public string dgvBudgetMaintenanceColumn0 = "Account Number";
        public string dgvBudgetMaintenanceColumn1 = "Account Name";
        public string dgvBudgetMaintenanceColumn2 = "Account Type Name";
        public string dgvBudgetMaintenanceColumn3 = "Period1";
        public string dgvBudgetMaintenanceColumn4 = "Period2";
        public string dgvBudgetMaintenanceColumn5 = "Period3";
        public string dgvBudgetMaintenanceColumn6 = "Period4";
        public string dgvBudgetMaintenanceColumn7 = "Period5";
        public string dgvBudgetMaintenanceColumn8 = "Period6";
        public string dgvBudgetMaintenanceColumn9 = "Period7";
        public string dgvBudgetMaintenanceColumn10 = "Period8";
        public string dgvBudgetMaintenanceColumn11 = "Period9";
        public string dgvBudgetMaintenanceColumn12 = "Period10";
        public string dgvBudgetMaintenanceColumn13 = "Period11";
        public string dgvBudgetMaintenanceColumn14 = "Period12";
        public string dgvBudgetMaintenanceColumn15 = "Period13";
        public string formEndPeriod = "End Period";
        public string lblEndPeriodFiscalPeriod = "Fiscal Period";
        public string btnEndPeriodReport = "End Period";
        public string btnEndPeriodExit = "Exit";
        public string formEndYear = "End Year";
        public string lblEndYearFiscalYear = "Fiscal Year";
        public string btnEndYearReport = "End Year";
        public string btnEndYearExit = "Exit";
        public string formReportGenerator = "Report Displayer";
        public string groupBoxReportType = "Report Type";
        public string radioButtonrb1 = "Batch Report";
        public string radioButtonrb2 = "Trial Balance Summary";
        public string lblReportGeneratorFiscalYear = "Fiscal Year";
        public string lblReportGeneratorFiscalPeriod = "Fiscal Period";
        public string btnReport = "Show Report";
        public string formFiscalPeriodSetup = "FiscalPeriodSetup";
        public string gLFiscalPeriodSetupDataGridViewColumn1 = "Fiscal Year";
        public string labelFiscalYear = "Fiscal Year";
        public string labelPeriodDescription = "Period Description";
        public string btn_AutoSetup = "Auto Setup";
        public string btn_SaveChanges = "Save Changes";
        public string resetAutoSetupToolStripMenuItem = "Reset AutoSetup";
        public string insertToolStripMenuItem = "New && Save";
        public string editToolStripMenuItem = "Edit && Save";
        public string deleteToolStripMenuItem = "Delete && Save";
        public string exitToolStripMenuItem = "Exit";
        public string btn_new_save = "New && Save";
        public string btn_edit_save = "Edit && Save";
        public string btn_delete_save = "Delete && Save";
        public string btn_exit = "Exit";
        public string optionsToolStripMenuItem = "Options";
        public string labelPeriod1 = "Period1";
        public string labelPeriod2 = "Period2";
        public string labelPeriod3 = "Period3";
        public string labelPeriod4 = "Period4";
        public string labelPeriod5 = "Period5";
        public string labelPeriod6 = "Period6";
        public string labelPeriod7 = "Period7";
        public string labelPeriod8 = "Period8";
        public string labelPeriod9 = "Period9";
        public string labelPeriod10 = "Period10";
        public string labelPeriod11 = "Period11";
        public string labelPeriod12 = "Period12";
        public string labelPeriod13 = "Period13";
        public string General_Settings = "General_Settings";
        public string General_Ledger_Setup = "General_Ledger_Setup";
        public string G_L_General_Setup = "G_L_General_Setup";
        public string Allocation_Maintenance = "Allocation_Maintenance";
        public string TransactionsTemp_Maintenance = "TransactionsTemp_Maintenance";
        public string Account_Payable_Setup = "Account_Payable_Setup";
        public string Tax_Office = "Tax_Office";
        public string Tax_Reason = "Tax_Reason";
        public string Delivery_Types = "Delivery_Types";
        public string Vendors_Categories = "Vendors_Categories";
        public string Payment_Terms = "Payment_Terms";
        public string STVendors = "Vendors";
        public string Run_Allocation = "Run_Allocation";
        public string GL_Batch_Report = "G/L_Batch_Report";
        public string Chart_of_Account = "Chart_of_Account Report";
        public string GL_Journal = "G/L_Journal Report";
        public string GL_Detail = "G/L_Detail Report";
        public string GL_Trail_Balance = "G/L_Trail_Balance Report";
        public string Account_Payable = "Account_Payable";
        public string Accounts_Payable_Control = "Accounts_Payable_Control";
        public string STAPTransactions = "APTransactions";
        public string Apply_CreditsScreen = "Apply_CreditsScreen";
        public string checkboxtree = "Expand Tree";
        public string AllocationCode = "Allocation Code";
        public string AllocationDescription = "Allocation Description";
        public string SourceAccount = "Source Account";
        public string RemainingPercentage = "Remaining Percentage : 0%";
        public string ChkRepeat = "Repeat In Same Period";
        public string DestinationAccounts = "Destination Accounts";
        public string DGVCode = "Code";
        public string DGVJournal = "Journal";
        public string DGVDescription = "Description";
        public string taxoffId = "Tax Office ID";
        public string taxoffName = "Tax Office Name";
        public string dgvtaxoffId = "TaxOfficeID";
        public string dgvtaxoffName = "TaxOfficeName";
        public string formtaxoffice = "Tax Office";
        public string ReasonID = "Reason ID";
        public string ReasonCode = "Reason Code";
        public string ReasonDescription = "Reason Description";
        public string dgvCode = "Code";
        public string dgvDesc = "Description";
        public string dgvID = "ID";
        public string dgvName = "Name";
        public string formtaxReason = "Tax Reason";
        public string formDeliveryTypes = "Delivery Types";
        public string DeliveryTypeID = "Delivery Type ID";
        public string DeliveryTypeName = "Delivery Type Name";
        public string Percentage = "Percentage";
        public string btnSearch = "Search";
        public string CategoryID = "Category ID";
        public string CategoryCode = "Category Code";
        public string CategoryDescription = "Category Description";
        public string formVendorsCategories = "Vendors Categories";
        public string PaymentTermID = "Payment Term ID";
        public string PaymentTermCode = "Payment Term Code";
        public string PaymentTermDescription = "Payment Term Description";
        public string DueDays = "Due Days";
        public string formPaymentTerms = "Payment Terms";
        public string dgvDueDays = "DueDays";
        public string formVendors = "Vendors";
        public string TermsInformation = "Terms Information";
        public string VendorInformation = "Vendor Information";
        public string VendorID = "Vendor ID";
        public string VendorCode = "Vendor Code";
        public string VendorName = "Vendor Name";
        public string ArabicName = "Arabic Name";
        public string CheckName = "Check Name";
        public string Address = "Address";
        public string City = "City";
        public string Country = "Country";
        public string Phone = "Phone";
        public string Fax = "Fax";
        public string Contacts = "Contacts";
        public string TermID = "Term ID";
        public string Status = "Status";
        public string TaxIDnumber = "Tax ID Number";
        public string TaxOffice = "Tax Office";
        public string TaxFileNumber = "Tax File Number";
        public string VendorCategory = "Vendor Category";
        public string CreditLimit = "Credit Limit";
        public string ExpenseAccounts = "Expense Accounts";
        public string PrintSeparateChecks = "Print Separate Checks";
        public string dgvTitle = "Title";
        public string dgvBusinessPlan = "BusinessPlan";
        public string dgvMobile = "Mobile";
        public string dgvEmail = "Email";
        public string formRunAllocation = "Run Allocation";
        public string Posted = "Posted";
        public string btnRunAllocation = "Run Allocation";
        public string formAccountsPayableControl = "Accounts Payable Control";
        public string APTradeGLAccountNumber = "APTrade GL Account Number";
        public string DefaultNewVendorStatus = "Default New Vendor Status";
        public string DefaultNewVendorTerms = "Default New Vendor Terms";
        public string AllowMultiCurrencyInvoicy = "Allow MultiCurrency Invoicy";
        public string PrintZeroBalanceChecks = "Print ZeroBalance Checks";
        public string PrintSummarizedChecks = "Print Summarized Checks";
        public string AgingPeriods = "Aging Periods";
        public string Days = "Days";
        public string Description = "Description";
        public string Startof1stPeriod = "Start of 1st Period";
        public string Startof2ndPeriod = "Start of 2nd Period";
        public string Startof3rdPeriod = "Start of 3rd Period";
        public string Startof4thPeriod = "Start of 4th Period";
        public string UseWithHoldTax = "Use WithHold Tax";
        public string DefaultPaymentDateStart = "Default Payment Date Start";
        public string btnDoue = "OK";
        public string btnNewBatch = "New Batch";
        public string btnEditBatch = "Edit Batch";
        public string btnDeleteBatch = "Delete Batch";
        public string btnUndoBatch = "Undo Batch";
        public string formAPTransactions = "APTransactions";
        public string APNumber = "AP Number";
        public string lblDate = "Date";
        public string lblUserID = "User ID";
        public string lblPostedIn = "Posted In";
        public string GroupInvoice = "Invoice";
        public string GroupInvoiceInformation = "Invoice Information";
        public string GroupInvoicePaymentInformation = "Invoice Payment Information";
        public string GroupAccessInvoice = "Access Invoice";
        public string lblBatchDetails = "Batch Details";
        public string lblInvoiceDetails = "Invoice Details";
        public string lblInvoiceNumber = "Invoice Number";
        public string lblTransactionType = "Transaction Type";
        public string lblInvoiceStatus = "Invoice Status";
        public string lblReference = "Reference";
        public string lblInvoiceDate = "Invoice Date";
        public string lblPONumber = "P.O Number";
        public string lblVendorTerms = "Vendor Terms";
        public string lblCurrencyRate = "Currency Rate";
        public string lblNetInvoiceAmount = "Net Invoice Amount";
        public string lblSalesTaxAmount = "Sales Tax Amount";
        public string lblDiscountValue = "Discount Value";
        public string lblInvoiceAmount = "Invoice Amount";
        public string lblPayDate = "Pay Date";
        public string lblDeliveryType = "Delivery Type";
        public string lblTaxAmount = "Tax Amount";
        public string lblNonTaxableReason = "NonTaxable Reason";
        public string lblMultiCurrency = "MultiCurrency";
        public string lblNonTaxable = "Non Taxable";
        public string dgvAmount = "Amount";
        public string dgvAmountCC = "AmountCC";
        public string dgvBatchInvoiceID = "BatchInvoiceID";
        public string ReportGLBatch = "Report G/L Batch";
        public string ReportAPBatch = "Report AP Batch";
        public string lblFrom = "From";
        public string lblTo = "To";
        public string groupBatchStatus = "Batch Status";
        public string groupBatchRange = "Batch Range";
        public string rdbBoth = "Both";
        public string rdbPosted = "Posted";
        public string rdbUnPosted = "UnPosted";
        public string chkPrintByBatchRange = "Print By Batch Range";
        public string ChartofAccountReport = "Chart of Account Report";
        public string groupReportOptions = "Report Options";
        public string groupSelectOptions = "Select Options";
        public string groupAccountRange = "Account Range";
        public string rdbAllAccounts = "All Accounts";
        public string rdbActiveAccountsOnly = "Active Accounts Only";
        public string chkPrintByAccountRange = "Print By Account Range";
        public string JournalReport = "Journal Report";
        public string VendorReport = "Vendor List Report";
        public string lblAvailable = "Available";
        public string lblSelect = "Select";
        public string groupG_LJournals = "G/L Journals";
        public string PrintWithBatchDetails = "Print With Batch Details";
        public string PrintAccountOnly = "Print Account Only";
        public string GLDetailAccount = "G/L Detail Account";
        public string groupDateRange = "Date Range";
        public string groupG_LAccountSelection = "G/L Account Selection";
        public string GLTrialBalance = "G/L Trial Balance";
        public string groupReportDate = "Report Date";
        public string rdbTrialBalanceDetail = "Trial Balance (Detail)";
        public string rdbTrialBalanceSummary = "Trial Balance (Summary)";
        public string dgvSelect = "Select";
        public string Summary = "Summary";
        public string Detail = "Detail";
        public string Report_Display = "Report Display";
        public string Vendor = "Vendor";

        public string SortCode = "Sorted By Vendor Code ";
        public string SortName = "Sorted By Vendor Name ";
        public string SortCategory = "Sorted By Vendor Category ";

        public string lblCountUnits = "Count Units";
        public string lblJVTransactionsTemp = "JVTransactions Temp";
        public string formJVTransactionsTemp = "Transactions Maintenance Temp";


        //ARAccountCategory Form
        public string ARAccountCategory = "ARAccountCategory";
        public string Type_ID = "Type ID";
        public string Code = "Code";

        public string CategoryName = "Category Name";
        //ARAccountCategory Form
        public string formARDiscountCategories = "Discount Categories";
        public string Disc_ID = "Disc ID";
        public string Disc_Name = "Discount Name";
        public string Disc_Desc = "Discount Descrption";





        public ClassInterfaceLanguage()
        {

        }

        public static ClassInterfaceLanguage load(string config_file_name)
        {
            try
            {
                if (System.IO.Path.GetFileNameWithoutExtension(config_file_name) == "")// don't show error if application is run for first time 
                    return new ClassInterfaceLanguage();
                return (ClassInterfaceLanguage)XML_access.XMLDeserializeObject(config_file_name, typeof(ClassInterfaceLanguage));
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error loading interface language file " + config_file_name + ".\r\n" + e.Message + "\r\nDefault language will be used for interface", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new ClassInterfaceLanguage();
            }
        }
        public bool save(string config_file_name)
        {
            try
            {
                XML_access.XMLSerializeObject(config_file_name, this, typeof(ClassInterfaceLanguage));
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
