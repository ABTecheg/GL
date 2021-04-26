using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.Net;
namespace Accounting_GeneralLedger
{
    public static class GeneralFunctions
    {

        static public string ConnectionString = "";
        public static void fillaccountformatnumber()
        {
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * From GeneralSetup", sqlcon);
            cmdBuilderGeneralSetup = new SqlCommandBuilder(adaptertbGeneralSetup);
            dbAccountingProjectDS2 = new dbAccountingProjectDS();

            adaptertbGeneralSetup.Fill(dbAccountingProjectDS2.GeneralSetup);
            AccountNumberFormat = dbAccountingProjectDS2.GeneralSetup.Rows[0][1].ToString();
        }
        static public string AccountNumberFormat = "xxx-xxxx-xx";
        static public int NoOfSubtypes = 4;
        static public string DecimalPointFormat = "x.xxx";
        static public int DecimalPointsNumber = 3;
        static public int AccountNumberLenght = 11;
        static public int maxSublevelNumber = 3;
        static public int GMultiCurrency = 0;
        static public string CompanyName = "AHS";
        static public string newLanguage = "";
        static public string priviledgeData = "";
        //static public string Header = "";

        static public string JVNumberFormat = "MMDDYY";
        static public string APNumberFormat = "MMDDYY";
        static public string ARNumberFormat = "MMDDYY";
        static public string BankNumberFormat = "MMDDYY";
        static public string lblJV = "";
        static public string lblAP = "";
        static public string lblAR = "";
        static public string lblBank = "";
        static public string ParentForm = "";
        static public ArrayList Subtypes = new ArrayList();
        static public bool SubTypesloaded = false;

        static public int PeriodID = 30;
        static public int AccountTypeID = 5;
        static public int JournalCodeID = 0;
        static public int AllocationID = 0;
        static public int DestinationAccounts = 50;
        static public int CurrencyID = 1;
        static public int CurrencyconversionID = 40;
        static public int TemplateID = 8;
        static public int TemplateAccounts = 100;
        static public int JVTransaction = 1;
        static public int AccountsChartRow = 40;
        static public int APTransaction = 1;
        static public int ARTransaction = 1;
        static public int JVAccounts = 200;
        static public int APInvoices = 1;
        static public int APInvoiceAccounts = 75;
        static public int VendorID = 6;
        static public int VendorCategoryID = 1;
        static public int VendorContacts = 8;
        static public int VendorAccounts = 9;
        static public int TaxOfficeID = 0;
        static public int DeliveryTypeID = 0;
        static public int PaymentTermID = 0;
        static public int ProjectCodeID = 2;
        static public int CashFlowCategoryID = 1;
        static public int BankID = 0;
        static public int CheckID = 0;
        static public int DepositTypeID = 0;
        static public int GlobalBatchID = 0;
        static public int TotalID = 2;
        static public string languagechioce = "english";
        static public string selectJVNumber = "";
        static public string IP = "";
        static public string ComputerIP = "";
        static public string ComputerName = "";
        static public string Format_Date = GeneralFunctions.Format_Date;

        static private SqlConnection sqlcon;
        static private SqlDataAdapter adaptertbGeneralSetup;
        static private SqlCommandBuilder cmdBuilderGeneralSetup;
        static private dbAccountingProjectDS dbAccountingProjectDS2;
        public static string StateVer = "";
        public static ArrayList FUNAVL;
        public static bool FindRow(string SearchExpression, DataTable dt)
        {
            bool found = false;
            DataRow[] rArr = dt.Select(SearchExpression);
            if (rArr.Length != 0)
                found = true;
            return found;
        }

        public static bool FindCharacter(string s, char c)
        {
            ArrayList arr = new ArrayList();
            Char[] charArr = s.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                arr.Add(charArr[i]);
            }
            if (arr.Contains(c))
                return true;
            else
                return false;
        }
        public static void priviledgeItem(ToolStripItem item)
        {
            try
            {
                if (item != null)
                {
                    if (priviledgeData == "Administrator")
                    {
                        item.Enabled = true;
                        return;
                    }
                    string ta = "";
                    string MT = "";
                    if (item.Tag != null)
                        ta = item.Tag.ToString().Trim();
                    else
                        ta = "";
                    if (ta != "" && priviledgeData.Length > 0)
                    {
                        MT = priviledgeData.Substring(int.Parse(ta) - 1, 1).Trim();
                        if (MT != "")
                        {
                            if (MT == "M")
                                item.Enabled = true;
                            else
                                item.Enabled = false;
                        }

                    }
                    else
                        item.Enabled = false;
                }
            }
            catch
            {
                item.Enabled = false;
            }
        }
        public static string Ckecktag(string ta)
        {
            string MT = "";
            if (ta != "")
            {
                MT = priviledgeData.Substring(int.Parse(ta) - 1, 1).Trim();
            }
            return MT;
        }
        public static void priviledgeGroupBox(GroupBox item)
        {
            try
            {
                if (priviledgeData == "Administrator")
                {
                    item.Enabled = true;
                    return;
                }
                string tag = "";
                string Checker = "";
                if (item.Tag != null)
                    tag = item.Tag.ToString().Trim();
                else
                    tag = "";
                if (tag != "" && priviledgeData.Length > 0)
                {
                    Checker = priviledgeData.Substring(int.Parse(tag) - 1, 1);
                    if (Checker != "")
                    {
                        if (Checker == "M")
                            item.Enabled = true;
                        else
                            item.Enabled = false;
                    }
                }
                else
                    item.Enabled = false;
            }
            catch (Exception ex)
            {
                item.Enabled = false;
            }
        }
        public static void LoadSubtypes(int FirstParam, int SecondParam)
        {
            Subtypes.Add(FirstParam);
            Subtypes.Add(SecondParam);
        }
        public static void LoadSubtypes(int FirstParam, int SecondParam, int ThirdParam)
        {
            Subtypes.Add(FirstParam);
            Subtypes.Add(SecondParam);
            Subtypes.Add(ThirdParam);
        }
        public static void LoadSubtypes(int FirstParam, int SecondParam, int ThirdParam, int FourthParam)
        {
            Subtypes.Add(FirstParam);
            Subtypes.Add(SecondParam);
            Subtypes.Add(ThirdParam);
            Subtypes.Add(FourthParam);
        }

        public static string CreateAccountNumberFormat(string AccountNo)
        {
            string AccountNumber = "";
            ArrayList arrAccountNo = new ArrayList();
            int startindex = 0;
            foreach (int i in GeneralFunctions.Subtypes)
            {
                arrAccountNo.Add(AccountNo.Substring(startindex, i));
                startindex += i;
            }
            for (int j = 0; j < arrAccountNo.Count - 1; j++)
            {
                AccountNumber += (string)arrAccountNo[j] + '-';
            }
            AccountNumber += (string)arrAccountNo[arrAccountNo.Count - 1];
            return AccountNumber;
        }

        public static bool CheckSubstring(string s)
        {
            bool validated = true;
            Regex AccountNumberRegExp = new Regex("[0-9-]+");
            if (!AccountNumberRegExp.IsMatch(s))
                validated = false;
            else
            {
                Match m = AccountNumberRegExp.Match(s);
                if (m.ToString().Length == s.Length)
                    validated = true;
                else
                    validated = false;

            }
            return validated;
        }

        public static string CreateJVNumberFormat(string lbl, string format, bool JVNumber)
        {
            DateTime dtResult = DateTime.Now;
            string resultnumber = "";
            if (format == "MMDDYYYY")
            {
                resultnumber = string.Format(GeneralFunctions.Format_Date, dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "DDMMYYYY")
            {
                resultnumber = string.Format(GeneralFunctions.Format_Date, dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "YYYYMMDD")
            {
                resultnumber = string.Format("{0:yyyy/MM/dd}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "YYYYDDMM")
            {
                resultnumber = string.Format("{0:yyyy/dd/MM}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "MMDDYY")
            {
                resultnumber = string.Format("{0:MM/dd/yy}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "DDMMYY")
            {
                resultnumber = string.Format("{0:dd/MM/yy}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "YYMMDD")
            {
                resultnumber = string.Format("{0:yy/MM/dd}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "MMYYYY")
            {
                resultnumber = string.Format("{0:MM/yyyy}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "YYYYMM")
            {
                resultnumber = string.Format("{0:yyyy/MM}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "MMYY")
            {
                resultnumber = string.Format("{0:MM/yy}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "YYMM")
            {
                resultnumber = string.Format("{0:yy/MM}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }

            SqlConnection sqlconJVTran = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconJVTran.Open();
            SqlCommand getJVFromBatch;
            int NewNumber;
            string New;
            if (lbl == "")
                getJVFromBatch = new SqlCommand("Select Max(right(JVNumber,3)) From Batch where BatchSRC = 'GL'", sqlconJVTran);
            else
                getJVFromBatch = new SqlCommand("Select Max(right(JVNumber,3)) From Batch where BatchSRC = 'GL'", sqlconJVTran);

            if (getJVFromBatch.ExecuteScalar() != DBNull.Value)
            {
                New = (int.Parse(getJVFromBatch.ExecuteScalar().ToString())).ToString();
                bool flage = int.TryParse(New, out NewNumber);
                NewNumber++;
                New = NewNumber.ToString();
                if (New.Length < 3)
                {
                    for (int i = New.Length; i < 3; i++)
                    {
                        New = "0" + New;
                    }
                }
                else if (New.Length > 3)
                {
                    New = "001";
                }
            }
            else
            {
                New = "001";
            }
            resultnumber += New;
            resultnumber = lbl + resultnumber;
            return resultnumber;
        }
        public static string CreateAPNumberFormat(string lbl, string format, bool APNumber)
        {
            DateTime dtResult = DateTime.Now;
            string resultnumber = "";
            if (format == "MMDDYYYY")
            {
                resultnumber = string.Format(GeneralFunctions.Format_Date, dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "DDMMYYYY")
            {
                resultnumber = string.Format(GeneralFunctions.Format_Date, dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "YYYYMMDD")
            {
                resultnumber = string.Format("{0:yyyy/MM/dd}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "YYYYDDMM")
            {
                resultnumber = string.Format("{0:yyyy/dd/MM}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "MMDDYY")
            {
                resultnumber = string.Format("{0:MM/dd/yy}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "DDMMYY")
            {
                resultnumber = string.Format("{0:dd/MM/yy}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "YYMMDD")
            {
                resultnumber = string.Format("{0:yy/MM/dd}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "MMYYYY")
            {
                resultnumber = string.Format("{0:MM/yyyy}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "YYYYMM")
            {
                resultnumber = string.Format("{0:yyyy/MM}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "MMYY")
            {
                resultnumber = string.Format("{0:MM/yy}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "YYMM")
            {
                resultnumber = string.Format("{0:yy/MM}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            int NewNumber;
            string New;
            SqlConnection sqlconAPTran = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconAPTran.Open();
            SqlCommand getAPFromBatch;

            getAPFromBatch = new SqlCommand("Select Max(right(JVNumber,3)) From Batch where BatchSRC = 'AP'", sqlconAPTran);
            if (getAPFromBatch.ExecuteScalar() != DBNull.Value)
            {
                New = getAPFromBatch.ExecuteScalar().ToString();
                bool flage = int.TryParse(New, out NewNumber);
                NewNumber++;
                New = NewNumber.ToString();
                if (New.Length < 3)
                {
                    for (int i = New.Length; i < 3; i++)
                    {
                        New = "0" + New;
                    }
                }
                else if (New.Length > 3)
                {
                    New = "001";
                }
            }
            else
            {
                New = "001";
            }
            resultnumber += New;
            resultnumber = lbl + resultnumber;
            return resultnumber;
        }
        public static string CreateARNumberFormat(string lbl, string format, bool APNumber)
        {
            DateTime dtResult = DateTime.Now;
            string resultnumber = "";
            if (format == "MMDDYYYY")
            {
                resultnumber = string.Format(GeneralFunctions.Format_Date, dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "DDMMYYYY")
            {
                resultnumber = string.Format(GeneralFunctions.Format_Date, dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "YYYYMMDD")
            {
                resultnumber = string.Format("{0:yyyy/MM/dd}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "YYYYDDMM")
            {
                resultnumber = string.Format("{0:yyyy/dd/MM}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "MMDDYY")
            {
                resultnumber = string.Format("{0:MM/dd/yy}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "DDMMYY")
            {
                resultnumber = string.Format("{0:dd/MM/yy}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "YYMMDD")
            {
                resultnumber = string.Format("{0:yy/MM/dd}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "MMYYYY")
            {
                resultnumber = string.Format("{0:MM/yyyy}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "YYYYMM")
            {
                resultnumber = string.Format("{0:yyyy/MM}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "MMYY")
            {
                resultnumber = string.Format("{0:MM/yy}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "YYMM")
            {
                resultnumber = string.Format("{0:yy/MM}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            int NewNumber;
            string New;
            SqlConnection sqlconARTran = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconARTran.Open();
            SqlCommand getARFromBatch;
            getARFromBatch = new SqlCommand("Select Max(right(JVNumber,3)) From Batch where BatchSRC = 'AR'", sqlconARTran);
            if (getARFromBatch.ExecuteScalar() != DBNull.Value)
            {
                New = getARFromBatch.ExecuteScalar().ToString();
                bool flage = int.TryParse(New, out NewNumber);
                NewNumber++;
                New = NewNumber.ToString();
                if (New.Length < 3)
                {
                    for (int i = New.Length; i < 3; i++)
                    {
                        New = "0" + New;
                    }
                }
                else if (New.Length > 3)
                {
                    New = "001";
                }
            }
            else
            {
                New = "001";
            }
            resultnumber += New;
            resultnumber = lbl + resultnumber;
            return resultnumber;
        }
        public static string CreateBankNumberFormat(string lbl, string format, bool APNumber)
        {
            DateTime dtResult = DateTime.Now;
            string resultnumber = "";
            if (format == "MMDDYYYY")
            {
                resultnumber = string.Format(GeneralFunctions.Format_Date, dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "DDMMYYYY")
            {
                resultnumber = string.Format(GeneralFunctions.Format_Date, dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "YYYYMMDD")
            {
                resultnumber = string.Format("{0:yyyy/MM/dd}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "YYYYDDMM")
            {
                resultnumber = string.Format("{0:yyyy/dd/MM}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "MMDDYY")
            {
                resultnumber = string.Format("{0:MM/dd/yy}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "DDMMYY")
            {
                resultnumber = string.Format("{0:dd/MM/yy}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "YYMMDD")
            {
                resultnumber = string.Format("{0:yy/MM/dd}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "MMYYYY")
            {
                resultnumber = string.Format("{0:MM/yyyy}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "YYYYMM")
            {
                resultnumber = string.Format("{0:yyyy/MM}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "MMYY")
            {
                resultnumber = string.Format("{0:MM/yy}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            if (format == "YYMM")
            {
                resultnumber = string.Format("{0:yy/MM}", dtResult.Date);
                resultnumber = resultnumber.Replace("/", "");
            }
            int NewNumber;
            string New;
            SqlConnection sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon.Open();
            SqlCommand getBatch;
            getBatch = new SqlCommand("Select Max(right(JVNumber,3)) From Batch where BatchSRC = 'Bank'", sqlcon);
            if (getBatch.ExecuteScalar() != DBNull.Value)
            {
                New = getBatch.ExecuteScalar().ToString();
                bool flage = int.TryParse(New, out NewNumber);
                NewNumber++;
                New = NewNumber.ToString();
                if (New.Length < 3)
                {
                    for (int i = New.Length; i < 3; i++)
                    {
                        New = "0" + New;
                    }
                }
                else if (New.Length > 3)
                {
                    New = "001";
                }
            }
            else
            {
                New = "001";
            }
            resultnumber += New;
            resultnumber = lbl + resultnumber;
            return resultnumber;
        }
        public static bool AccountNumberValidate(string AccountNumber, out string output)
        {
            dbAccountingProjectDS2 = new dbAccountingProjectDS();
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * From GeneralSetup", sqlcon);
            cmdBuilderGeneralSetup = new SqlCommandBuilder(adaptertbGeneralSetup);

            adaptertbGeneralSetup.Fill(dbAccountingProjectDS2.GeneralSetup);
            // AccountNumberFormat = dbAccountingProjectDS2.GeneralSetup.Rows[0][1].ToString();
            foreach (DataRow dr in dbAccountingProjectDS2.GeneralSetup.Rows)
            {
                GeneralFunctions.AccountNumberLenght = dr["AccountNumberFormat"].ToString().Length;
                GeneralFunctions.AccountNumberFormat = dr["AccountNumberFormat"].ToString();
                GeneralFunctions.NoOfSubtypes = dr["AccountNumberFormat"].ToString().Split('-').Length; //Convert.ToInt16(dr["AccountNumberFormat"].ToString().Split('-').Length  ); 

            }

            bool valid = true;
            output = "";
            if (AccountNumber != "")
            {
                if (!GeneralFunctions.FindCharacter(AccountNumber, '-'))
                {
                    //if (AccountNumber.Length == GeneralFunctions.AccountNumberLenght)
                    //{
                        if (GeneralFunctions.CheckSubstring(AccountNumber))
                        {
                        //string AccountNumberFormated = GeneralFunctions.CreateAccountNumberFormat(AccountNumber);
                            string AccountNumberFormated = AccountNumber;
                            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
                            sqlcon.Open();
                            SqlCommand cmdSelect = new SqlCommand("Select AccountName from GLAccounts where AccountNumber = '" + AccountNumberFormated + "'", sqlcon);
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
                                else
                                    valid = true;
                                i++;
                            }
                            else
                                valid = false;
                            if (!valid)
                                MessageBox.Show("The Account Number can only contain numeric characters\n Please Insert a account number compatitable to the given account number format '" + GeneralFunctions.AccountNumberFormat + "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (valid)
                        {
                            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
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
                //MessageBox.Show("Please Insert acceptable values","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                valid = false;
            }
            return valid;
        }

        public static bool ValidateComboBox(ComboBox cb, string msg)
        {
            bool validate = true;
            if (cb.Text == "")
            {
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validate = false;
            }
            return validate;
        }

        public static bool ValidateString(string str, string msg)
        {
            bool validate = true;
            if (str != "")
            {
                //Regex StringRegExp = new Regex("[0-9a-zA-Z. ]+");
                //if (StringRegExp.IsMatch(str))
                //{
                //Match m = StringRegExp.Match(str);
                //if (!m.ToString().Equals(str))
                //{
                //    MessageBox.Show(msg,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                //    validate = false;
                //}
                //}
                //else
                //{
                //    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    validate = false;
                //}
            }
            else
            {
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validate = false;
            }
            return validate;
        }

        public static bool ValidateSpacedString(string str, string msg)
        {
            bool validate = true;
            if (str != "")
            {
                return validate;
            }
            else
            {
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validate = false;
            }
            return validate;
        }

        public static bool ValidateNumber(string str, string msg)
        {
            bool validate = true;
            Regex NumberRegExp = new Regex("[0-9]+");
            if (NumberRegExp.IsMatch(str))
            {
                Match m = NumberRegExp.Match(str);
                if (!m.ToString().Equals(str))
                {
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    validate = false;
                }
            }
            else
            {
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validate = false;
            }
            return validate;
        }
        //public static  bool AccountNumberValidate2(string accountNumber)
        //{
        //    bool valid = true;
        //    int i = 0;
        //    if (accountNumber != "")
        //    {
        //        if (GeneralFunctions.FindCharacter(accountNumber, '-'))
        //        {
        //            string[] arrInputAccountNumber = accountNumber.Split('-');
        //            string[] arrAccountNumberFormat = GeneralFunctions.AccountNumberFormat.Split('-');
        //            if (arrInputAccountNumber.Length == GeneralFunctions.NoOfSubtypes)
        //            {
        //                foreach (string s in arrInputAccountNumber)
        //                {
        //                    if (s.Length == arrAccountNumberFormat[i].Length)
        //                    {
        //                        if (!GeneralFunctions.CheckSubstring(s))
        //                        {
        //                           // MessageBox(accountNumber, "The Account Number can only contain numeric characters\n " +
        //                             //                    "Please enter valid characters");
        //                            valid = false;
        //                        }
        //                        i++;
        //                    }
        //                    else
        //                        valid = false;
        //                }
        //                if (valid)
        //                {
        //                    //MessageBox(accountNumber, "");
        //                    //accountNumber = accountNumber;
        //                }
        //            }
        //            else
        //                valid = false;
        //        }
        //        else
        //        {
        //            if (accountNumber.Length == GeneralFunctions.AccountNumberLenght)
        //            {
        //                if (GeneralFunctions.CheckSubstring(accountNumber))
        //                {
        //                    accountNumber = GeneralFunctions.CreateAccountNumberFormat(accountNumber);
        //                    //MessageBox(accountNumber, "");
        //                }
        //                else
        //                {
        //                    //MessageBox(accountNumber, "The Account Number can only contain numeric characters\n " +
        //                                                //"Please enter valid characters");
        //                    valid = false;
        //                }
        //            }
        //            else
        //            {
        //                //MessageBox(accountNumber, "Please Insert a account number compatitable to the given account number format '" + GeneralFunctions.AccountNumberFormat + "'");
        //                valid = false;
        //            }
        //        }
        //    }
        //    else
        //        valid = false;
        //    if (!valid)
        //        //MessageBox(accountNumber, "Please Insert a account number compatitable to the given account number format '" + GeneralFunctions.AccountNumberFormat + "'");
        //    return valid;
        //}

        public static bool ValidateEmail(string str, string msg)
        {
            bool validate = true;
            Regex EmailRegExp = new Regex("(.)+@[0-9a-zA-z]+(.[a-zA-Z]+)+");
            if (EmailRegExp.IsMatch(str))
            {
                Match m = EmailRegExp.Match(str);
                if (!m.ToString().Equals(str))
                {
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    validate = false;
                }
            }
            else
            {
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validate = false;
            }
            return validate;
        }

        public static bool ValidateInteger(string str, string msg, out int value)
        {
            bool valid = true;
            if (str != "")
            {
                try
                {
                    value = int.Parse(str);
                }
                catch
                {
                    value = 0;
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valid = false;
                }
            }
            else
            {
                value = 0;
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valid = false;
            }
            return valid;
        }

        public static bool ValidateDouble(string str, string msg, out double value)
        {
            bool valid = true;
            if (str != "")
            {
                try
                {
                    value = double.Parse(str);
                }
                catch
                {
                    value = 0;
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valid = false;
                }
            }
            else
            {
                value = 0;
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valid = false;
            }
            return valid;
        }

        public static DataGridViewComboBoxColumn AddItems(DataGridViewComboBoxColumn dgvc, DataTable dt, string columnName)
        {
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dgvc.Items.Add(dr[columnName].ToString());
                }
                dgvc.Items.Add("<new>");
            }
            else
            {
                dgvc.Items.Add("<new>");
            }
            return dgvc;
        }
        public static DataGridViewComboBoxColumn AddItemsFilter(DataGridViewComboBoxColumn dgvc, DataTable dt, string columnName, string Filter)
        {
            DataRow[] drs;
            drs = dt.Select(Filter);
            if (drs.Length != 0)
            {
                foreach (DataRow dr in drs)
                {
                    dgvc.Items.Add(dr[columnName].ToString());
                }
                dgvc.Items.Add("<new>");
            }
            else
            {
                dgvc.Items.Add("<new>");
            }
            return dgvc;
        }

        public static bool RetrievePeriod(String date, out int PeriodID, out string PeriodName, out DateTime enddate)
        {
            bool valid = true;
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon.Open();
            SqlCommand sqlcommand = new SqlCommand("sp_getFiscalPeriod", sqlcon);
            sqlcommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlparamIn = sqlcommand.Parameters.Add("@date", SqlDbType.NVarChar);
            sqlparamIn.Value = date;
            SqlDataReader rd = sqlcommand.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();
                PeriodName = rd["PeriodDescription"].ToString();
                PeriodID = rd.GetInt32(0);
                enddate = rd.GetDateTime(4);
            }
            else
            {
                PeriodName = "";
                PeriodID = -1;
                enddate = new DateTime();
                valid = false;
            }
            rd.Close();
            sqlcon.Close();
            return valid;
        }

        public static bool RetrievePeriod(String date, out int PeriodID, out int PeriodNumber)
        {
            bool valid = true;
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon.Open();
            SqlCommand sqlcommand = new SqlCommand("sp_getFiscalPeriod", sqlcon);
            sqlcommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlparamIn = sqlcommand.Parameters.Add("@date", SqlDbType.NVarChar);
            sqlparamIn.Value = date;
            SqlDataReader rd = sqlcommand.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();
                PeriodID = rd.GetInt32(0);
                PeriodNumber = rd.GetInt32(2);
            }
            else
            {
                PeriodID = -1;
                PeriodNumber = -1;
                valid = false;
            }
            rd.Close();
            sqlcon.Close();
            return valid;
        }
        public static bool RetrievePeriod(String date, out int PeriodID, out int PeriodNumber, out int year)
        {
            bool valid = true;
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon.Open();
            SqlCommand sqlcommand = new SqlCommand("sp_getFiscalPeriod", sqlcon);
            sqlcommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlparamIn = sqlcommand.Parameters.Add("@date", SqlDbType.NVarChar);
            sqlparamIn.Value = date;
            SqlDataReader rd = sqlcommand.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();
                PeriodID = rd.GetInt32(0);
                PeriodNumber = rd.GetInt32(2);
                year = rd.GetDateTime(3).Year;
            }
            else
            {
                PeriodID = -1;
                PeriodNumber = -1;
                year = 0;
                valid = false;
            }
            rd.Close();
            sqlcon.Close();
            return valid;
        }
        public static void DeleteRows(DataTable DT)
        {
            for (int i = DT.Rows.Count - 1; i >= 0; i--)
            {
                DT.Rows[i].Delete();
            }
        }
        public static ComboBox FillComboBox(DataTable dt, ComboBox cb, string columnName, string columnID)
        {
            ArrayList items = new ArrayList();
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cb.Items.Add(dr[columnName].ToString());
                }
            }
            cb.Items.Add("<new>");

            return cb;
        }

        public static string ApplyAccountFormat(string input)
        {
            string AccountNumber = "";
            int count;
            ArrayList arrAccountNo = new ArrayList();
            int startindex = 0;
            SqlConnection sqlconn = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconn.Open();
            SqlCommand sqlcoman = new SqlCommand("Select AccountSubType From GeneralSetup ", sqlconn);
            int x;
            if (sqlcoman.ExecuteScalar() != DBNull.Value)
            {
                x = Convert.ToInt32(sqlcoman.ExecuteScalar());
                if (x != 0)
                {
                    GeneralFunctions.NoOfSubtypes = x;
                }
            }


            foreach (int i in GeneralFunctions.Subtypes)
            {
                if (input.Length < i + startindex)
                {
                    count = input.Length - startindex;
                    arrAccountNo.Add(input.Substring(startindex, count));
                    break;
                }
                else
                {
                    count = i;
                    arrAccountNo.Add(input.Substring(startindex, count));
                }

                startindex += count;
            }
            for (int j = 0; j < arrAccountNo.Count - 1; j++)
            {
                AccountNumber += (string)arrAccountNo[j] + '-';
            }
            AccountNumber += (string)arrAccountNo[arrAccountNo.Count - 1];
            return AccountNumber;
        }

        public static TreeNode FindCurrentNode(string givenName, ArrayList nodesList)
        {
            foreach (TreeNode n in nodesList)
            {
                if (n.Name == givenName)
                    return n;
            }
            return null;
        }

        public static void SearchForAccountNumber(TextBox txt)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.ShowDialog();
            if (accSearch.selectedAccountName != null && accSearch.selectedAccountNumber != null)
            {
                txt.Text = accSearch.selectedAccountNumber;
            }
        }

        public static double CalculateForiegnCurrencyValue(double value, double exchangeRate)
        {
            double result = value * exchangeRate;
            return result;
        }

        public static ComboBox RemoveBaseCurrency(ComboBox cb)
        {
            SqlConnection sqlcon1 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon1.Open();
            SqlCommand command = new SqlCommand("Select CurrencyCode from GLCurrency where BaseCurrency = 1", sqlcon1);
            string baseCurrency = (string)command.ExecuteScalar();
            if (baseCurrency != "")
            {
                cb.Items.Remove(baseCurrency);
            }
            sqlcon1.Close();
            return cb;
        }
        public static string Encrypt(string str)
        {
            string St = "";
            try
            {

                System.Text.ASCIIEncoding AsciC = new System.Text.ASCIIEncoding();
                byte[] ByteString = AsciC.GetBytes(str);
                St = Convert.ToBase64String(ByteString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return St;
        }
        public static string Decrypt(string str)
        {
            string St = "";
            try
            {
                System.Text.ASCIIEncoding AsciC = new System.Text.ASCIIEncoding();
                byte[] ByteString = Convert.FromBase64String(str);
                St = AsciC.GetString(ByteString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return St;
        }
        public static bool EvaluateExchangeRate(out double exchangeRate, string CurrencyCode)
        {
            SqlConnection sqlcon1 = new SqlConnection(GeneralFunctions.ConnectionString);
            bool valid = true;
            sqlcon1.Open();
            SqlCommand command = new SqlCommand("Select ExchangeRate from GLCurrencyConversion where CurrencyCode ='" + CurrencyCode + "'", sqlcon1);
            SqlDataReader rd = command.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();
                exchangeRate = double.Parse(rd[0].ToString());
            }
            else
            {
                exchangeRate = 0;
                valid = false;
            }
            rd.Close();
            sqlcon1.Close();
            return valid;
        }
        public static double ChangeDecimal(double D, int C)
        {
            double DO = 0;
            decimal DC = 0;
            DC = decimal.Parse(D.ToString());
            DC = decimal.Round(DC, C);
            DO = double.Parse(DC.ToString());
            return DO;
        }
        public static void GetIP()
        {
            ComputerName = Dns.GetHostName();
            IPAddress[] IPADD = Dns.GetHostAddresses(Dns.GetHostName());
            ComputerIP = IPADD[0].ToString();
        }
        public static void LockTables(string TableLock, string FormLock, string IDRow, string State)
        {
            SqlCommand mycomDTS;
            SqlConnection myconDTS = new SqlConnection(GeneralFunctions.ConnectionString);
            myconDTS.Open();
            mycomDTS = new SqlCommand("insert Into AvailableTable (ComputerIP,ComputerName,TableLock,DateLock,IDRow,FormLock,State) VALUES ('" + ComputerIP + "','" + ComputerName + "','" + TableLock + "','" + DateTime.Now.ToString() + "','" + IDRow + "','" + FormLock + "','" + State + "')", myconDTS);
            mycomDTS.ExecuteNonQuery();
            myconDTS.Close();
        }
        public static string CheckLockTables(string TableLock, string FormLock, string IDRow, string State)
        {
            SqlCommand mycomDTS;
            string NameAvil = "";
            string s = "";
            if (TableLock != "")
            {
                s = "TableLock = '" + TableLock + "'";
            }
            if (FormLock != "")
            {
                if (s == "")
                    s = " FormLock = '" + FormLock + "'";
                else
                    s += " AND FormLock = '" + FormLock + "'";
            }
            if (IDRow != "")
            {
                if (s == "")
                    s = " IDRow = '" + IDRow + "'";
                else
                    s += " AND IDRow = '" + IDRow + "'";
            }
            if (State != "")
            {
                if (s == "")
                    s = " State = '" + State + "'";
                else
                    s += " AND State = '" + State + "'";
            }
            SqlConnection myconDTS = new SqlConnection(GeneralFunctions.ConnectionString);
            myconDTS.Open();
            if (s != "")
                mycomDTS = new SqlCommand("Select * From AvailableTable Where (" + s + " AND ComputerName <> '" + ComputerName + "') OR (TableLock = 'ALL' AND ComputerName <> '" + ComputerName + "')", myconDTS);
            else
                mycomDTS = new SqlCommand("Select * From AvailableTable Where (TableLock = 'ALL' AND ComputerName <> '" + ComputerName + "')", myconDTS);
            SqlDataReader mydr = mycomDTS.ExecuteReader();
            if (mydr.HasRows == true)
            {
                mydr.Read();
                NameAvil = mydr["ComputerName"].ToString() + " " + mydr["ComputerIP"].ToString();
                mydr.Close();
            }
            myconDTS.Close();
            return NameAvil;
        }
        public static void UnLockTablesSelect(string DTS)
        {
            SqlCommand mycomDTS;
            SqlConnection myconDTS = new SqlConnection(GeneralFunctions.ConnectionString);
            myconDTS.Open();
            mycomDTS = new SqlCommand("Delete AvailableTable Where ID IN " + DTS, myconDTS);
            mycomDTS.ExecuteNonQuery();
            myconDTS.Close();
        }

        public static void UnLockTable(string TableLock, string FormLock, string IDRow, string State)
        {
            SqlCommand mycomDTS;
            string s = "";
            if (TableLock != "")
            {
                s = "TableLock = '" + TableLock + "'";
            }
            if (FormLock != "")
            {
                if (s == "")
                    s = " FormLock = '" + FormLock + "'";
                else
                    s += " AND FormLock = '" + FormLock + "'";
            }
            if (IDRow != "")
            {
                if (s == "")
                    s = " IDRow = '" + IDRow + "'";
                else
                    s += " AND IDRow = '" + IDRow + "'";
            }
            if (State != "")
            {
                if (s == "")
                    s = " State = '" + State + "'";
                else
                    s += " AND State = '" + State + "'";
            }

            SqlConnection myconDTS = new SqlConnection(GeneralFunctions.ConnectionString);
            myconDTS.Open();
            mycomDTS = new SqlCommand("Delete AvailableTable Where " + s + " AND ComputerName = '" + ComputerName + "'", myconDTS);
            mycomDTS.ExecuteNonQuery();
            myconDTS.Close();
        }
        public static void UnLockAllTable()
        {
            SqlCommand mycomDTS;
            SqlConnection myconDTS = new SqlConnection(GeneralFunctions.ConnectionString);
            myconDTS.Open();
            mycomDTS = new SqlCommand("Truncate TAble AvailableTable", myconDTS);
            mycomDTS.ExecuteNonQuery();
            myconDTS.Close();
        }

        public static string UserName(int UserID)
        {
            string user = "";
            SqlConnection sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand("Select * From Users WHERE UserID=" + UserID + "", sqlcon);
            SqlDataReader sqlreadValidation = sqlcom.ExecuteReader();
            if (sqlreadValidation.HasRows == true)
            {
                while (sqlreadValidation.Read())
                {
                    user = sqlreadValidation["UserName"].ToString();
                }
            }
            sqlcon.Close();
            return user;
        }


    }
}
