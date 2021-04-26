    using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Accounting_GeneralLedger
{
    public partial class GeneralSetup : Form
    {
        private const int SC_CLOSE = 0xF060;
        private const int MF_GRAYED = 0x1;
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        private static extern int EnableMenuItem(IntPtr hMenu, int wIDEnableItem, int wEnable);

        private SqlConnection sqlcon;
        private SqlDataAdapter adapterGeneralSetup;
        private SqlCommandBuilder cmdbuilder;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private SqlDataAdapter adaptertbGeneralSetup;
        private SqlCommandBuilder cmdBuilderGeneralSetup;
        private int decimalPointsNumber;
        private int maxSublevelNumber;
        private string tempAccountNumber;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;

        public GeneralSetup()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            GeneralFunctions.maxSublevelNumber = maxSublevelNumber;
            SaveGLGeneralSetup();
            this.Close();

            //int.TryParse(txt_SublevelNumber.Text, out maxSublevelNumber);
            //if (maxSublevelNumber > 4)
            //{
            //    MessageBox.Show("Max Level Number 4 ", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            //if (/*MaxAcountNoValidate() &&*/ DecimalPointValidate() &&
            //    GeneralFunctions.ValidateComboBox(cb_JVNumberFormat, "Please Specify the JV Number Format") &&
            //    GeneralFunctions.ValidateComboBox(cb_APNumberFormat, "Please Specify the AP Number Format") &&
            //    GeneralFunctions.ValidateComboBox(cb_ARNumberFormat, "Please Specify the AR Number Format") &&
            //    GeneralFunctions.ValidateComboBox(cb_BankNumberFormat, "Please Specify the Bank Number Format") &&
            //    GeneralFunctions.ValidateInteger(txt_SublevelNumber.Text, "Please Specify the Max number of Sublevels", out maxSublevelNumber))
            //{
            //    GeneralFunctions.maxSublevelNumber = maxSublevelNumber;
            //    SaveGLGeneralSetup();
            //    this.Close();
            //}
            //else
            //    MessageBox.Show("Please Insert correct values");
        }

        private bool MaxAcountNoValidate()
        {
            bool validated = true;
            if (txtMaxAccountNo.Text == "")
            {
                errorProvider1.SetError(txtMaxAccountNo, "Please enter an accepted value");
                validated = false;
            }
            else
            {
                int n = 0;
                int AccountNumberLenght = 0;
                Regex AccountNoRegExp = new Regex("#+(?>-#+)+");
                if (AccountNoRegExp.IsMatch(txtMaxAccountNo.Text))
                {
                    Match m = AccountNoRegExp.Match(txtMaxAccountNo.Text);
                    if (m.ToString().Equals(txtMaxAccountNo.Text))
                    {
                        errorProvider1.SetError(txtMaxAccountNo, "");
                        GeneralFunctions.AccountNumberFormat = txtMaxAccountNo.Text;
                        string[] arr = GeneralFunctions.AccountNumberFormat.Split('-');
                        foreach (string s in arr)
                        {
                            GeneralFunctions.Subtypes.Clear();
                            GeneralFunctions.Subtypes.Add(s.Length);
                            AccountNumberLenght += s.Length;
                            n++;
                        }
                        GeneralFunctions.NoOfSubtypes = n;
                        GeneralFunctions.AccountNumberLenght = AccountNumberLenght;
                        //GeneralFunctions.max
                    }
                    else
                    {
                        errorProvider1.SetError(txtMaxAccountNo, "The Account Number Format can only contain '#' characters to represent numbers  \n " +
                                                            "and '-' character to represent the spaces between the numbers \n The account number must end with the '#' character"
                                                            + "Please remove nonvalid charaters");
                        validated = false;
                    }
                }
                else
                {
                    errorProvider1.SetError(txtMaxAccountNo, "The Account Number Format can only contain '#' characters to represent numbers  \n " +
                                                              "and '-' character to represent the spaces between the numbers \n Please enter acceptable values");
                    validated = false;
                }
            }
            return validated;
        }

        private bool DecimalPointValidate()
        {
            bool validated = true;
            if (txtDecimalPoint.Text == "")
            {
                errorProvider1.SetError(txtDecimalPoint, "Please enter an accepted value");
                validated = false;
            }
            else
            {
                if (GeneralFunctions.FindCharacter(txtDecimalPoint.Text, '.') && CheckOneOccurence(txtDecimalPoint.Text, '.'))
                {
                    string[] InputNumber = txtDecimalPoint.Text.Split('.');
                    Regex DecimalNoRegExp = new Regex("#+");
                    Match digitmatch = DecimalNoRegExp.Match(InputNumber[0]);
                    if (digitmatch.Length == 1)
                    {
                        Match decimalmatch = DecimalNoRegExp.Match(InputNumber[1]);
                        if (decimalmatch.Length == InputNumber[1].Length)
                        {
                            errorProvider1.SetError(txtDecimalPoint, "");
                            GeneralFunctions.DecimalPointFormat = txtDecimalPoint.Text;
                            decimalPointsNumber = InputNumber[1].Length;
                            GeneralFunctions.DecimalPointsNumber = decimalPointsNumber;
                        }
                        else
                        {
                            errorProvider1.SetError(txtDecimalPoint, "The Digits in the decimal number format are represented by '#' characters only " +
                                                            "\n Please enter an acceptable decimal number format");
                            validated = false;
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txtDecimalPoint, "The Digits in the decimal number format are represented by '#' characters only " +
                                                                 "\n Only one digit is required before the decimal point '.'" +
                                                                 "\n Please enter an acceptable decimal number format");
                        validated = false;
                    }
                }
                else
                {
                    errorProvider1.SetError(txtDecimalPoint, "The Decimal Number Format has to contain only one '.' character to represent the decimal point " +
                                                           "\n Please enter an acceptable decimal number format");
                    validated = false;
                }
            }
            return validated;
        }

        private bool CheckOneOccurence(string s, char c)
        {
            string[] splitarr = txtDecimalPoint.Text.Split('.');
            ArrayList arr = new ArrayList();
            for (int i = 0; i < splitarr.Length; i++)
            {
                arr.Add(splitarr[i]);
            }
            if (arr.Count > 2)
                return false;
            else
                return true;
        }
        private void GeneralSetup_Activated(object sender, EventArgs e)
        {
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);
        }
        private void GeneralSetup_Load(object sender, EventArgs e)
        {
            string msg = GeneralFunctions.CheckLockTables("", "", "", "");
            if (msg != "")
            {
                MessageBox.Show("Can't Open Because Other Form Open By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
                return;
            }
            GeneralFunctions.LockTables("All", "GeneralSetup", "", "");

            string BS = "";
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);

            dbAccountingProjectDS = new dbAccountingProjectDS();
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            FillNumberFormat(cb_APNumberFormat);
            FillNumberFormat(cb_ARNumberFormat);
            FillNumberFormat(cb_JVNumberFormat);
            FillNumberFormat(cb_BankNumberFormat);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * From GeneralSetup", sqlcon);
            cmdBuilderGeneralSetup = new SqlCommandBuilder(adaptertbGeneralSetup);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            {
                txtMaxAccountNo.Text = dr["AccountNumberFormat"].ToString();
                txtDecimalPoint.Text = dr["DecimalPointFormat"].ToString();
                cb_JVNumberFormat.Text = dr["JVNumberFormat"].ToString();
                cb_APNumberFormat.Text = dr["APNumberFormat"].ToString();
                cb_ARNumberFormat.Text = dr["ARNumberFormat"].ToString();
                cb_BankNumberFormat.Text = dr["BankNumberFormat"].ToString();
                lblAP.Text = dr["lblAP"].ToString();
                lblAR.Text = dr["lblAR"].ToString();
                lblJV.Text = dr["lblJV"].ToString();
                lblBank.Text = dr["lblBank"].ToString();
                //txt_SublevelNumber.Text = dr["AccountsChartSubLevels"].ToString();
                tempAccountNumber = dr["AccountNumberFormat"].ToString();
                cbMultiCurrency.Checked = Convert.ToBoolean(dr["MultiCurrency"].ToString());
                comboBox_language.Text = dr["SelectedLanguage"].ToString();
                BS = dr["BalanceSheet"].ToString();
                if (BS.Trim() == "")
                    cmbBS.SelectedIndex = -1;
                else
                {
                    cmbBS.Text = GeneralFunctions.Decrypt(BS);
                }
            }

            if (GeneralFunctions.languagechioce != "")
            {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }
            //GLInterface gl=new GLInterface();
            comboBox_language.Items.AddRange(GLInterface.report_language_available);
        }

        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.formGeneralSetup;
            this.btnExit.Text = obj_interface_language.buttonCompanyExit;
            this.btnOk.Text = obj_interface_language.buttonbtnOk;
            this.label1.Text = obj_interface_language.labelMaxAccountNumber;
            this.label2.Text = obj_interface_language.labelDecimalPoint;
            this.label3.Text = obj_interface_language.labelJVNumberFormat;
            this.label5.Text = obj_interface_language.labelAPNumberFormat;
            this.label6.Text = obj_interface_language.labelARNumberFormat;
          //  this.label4.Text = obj_interface_language.labelMaxNumberSubLevel;
            this.lblDefaultLanguage.Text = obj_interface_language.lblDefaultLanguage;

        }

        private void FillNumberFormat(ComboBox cb)
        {
            cb.Items.Add("MMDDYYYY");
            cb.Items.Add("DDMMYYYY");
            cb.Items.Add("YYYYMMDD");
            cb.Items.Add("YYYYDDMM");
            cb.Items.Add("MMDDYY");
            cb.Items.Add("DDMMYY");
            cb.Items.Add("YYMMDD");
            cb.Items.Add("MMYYYY");
            cb.Items.Add("YYYYMM");
            cb.Items.Add("MMYY");
            cb.Items.Add("YYMM");
            cb.Items.Add("AutoNumber");
        }

        private void cb_JVNumberFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            GeneralFunctions.JVNumberFormat = cb_JVNumberFormat.Text;
        }

        private void SaveGLGeneralSetup()
        {
            if (comboBox_language.Text == "")
            {
                MessageBox.Show("You must choose default language");
                return;
            }
            string[] arr;
            adapterGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adapterGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            cmdbuilder = new SqlCommandBuilder(adapterGeneralSetup);
            if (dbAccountingProjectDS.GeneralSetup.Count == 0)
            {
                DataRow r = dbAccountingProjectDS.GeneralSetup.NewRow();
                r["GeneralSetupID"] = 0;
                r["AccountNumberFormat"] = txtMaxAccountNo.Text;
                r["DecimalPointFormat"] = txtDecimalPoint.Text;
                r["DecimalPointsNumber"] = decimalPointsNumber;
                r["JVNumberFormat"] = cb_JVNumberFormat.Text;
                r["APNumberFormat"] = cb_APNumberFormat.Text;
                r["ARNumberFormat"] = cb_ARNumberFormat.Text;
                r["BankNumberFormat"] = cb_BankNumberFormat.Text;
                r["lblJV"] = lblJV.Text;
                r["lblAP"] = lblAP.Text;
                r["lblAR"] = lblAR.Text;
                r["lblBank"] = lblBank.Text;
             //   r["AccountsChartSubLevels"] = int.Parse(txt_SublevelNumber.Text);
                arr = GeneralFunctions.AccountNumberFormat.Split('-');
                r["AccountSubType"] = arr.Length;
                if (arr.Length == 2)
                {
                    r["FirstSub"] = arr[0].Length;
                    r["SecondSub"] = arr[1].Length;
                    r["ThirdSub"] = int.Parse("0");
                    r["FourthSub"] = int.Parse("0");
                }
                if (arr.Length == 3)
                {
                    r["FirstSub"] = arr[0].Length;
                    r["SecondSub"] = arr[1].Length;
                    r["ThirdSub"] = arr[2].Length;
                    r["FourthSub"] = int.Parse("0");
                }
                if (arr.Length == 4)
                {
                    r["FirstSub"] = arr[0].Length;
                    r["SecondSub"] = arr[1].Length;
                    r["ThirdSub"] = arr[2].Length;
                    r["FourthSub"] = arr[3].Length;
                }
                if (cbMultiCurrency.Checked == true)
                {

                    r["MultiCurrency"] = true;
                }
                else
                {
                    r["MultiCurrency"] = false;
                }

                r["SelectedLanguage"] = comboBox_language.Text;
                r["BalanceSheet"] = GeneralFunctions.Encrypt(cmbBS.Text);
                dbAccountingProjectDS.GeneralSetup.Rows.Add(r);
                adapterGeneralSetup.Update(dbAccountingProjectDS.GeneralSetup);
            }
            else
            {
                if (DialogResult.OK == MessageBox.Show("The GL settings has already been defined\n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                {
                    DataRow[] rArr = dbAccountingProjectDS.GeneralSetup.Select("GeneralSetupID = 0");
                    if (tempAccountNumber == txtMaxAccountNo.Text)
                    {
                        rArr[0]["AccountNumberFormat"] = txtMaxAccountNo.Text;
                        rArr[0]["DecimalPointFormat"] = txtDecimalPoint.Text;
                        rArr[0]["DecimalPointsNumber"] = decimalPointsNumber;
                        rArr[0]["JVNumberFormat"] = cb_JVNumberFormat.Text;
                        rArr[0]["APNumberFormat"] = cb_APNumberFormat.Text;
                        rArr[0]["ARNumberFormat"] = cb_ARNumberFormat.Text;
                        rArr[0]["BankNumberFormat"] = cb_BankNumberFormat.Text;
                        rArr[0]["lblJV"] = lblJV.Text;
                        rArr[0]["lblAP"] = lblAP.Text;
                        rArr[0]["lblAR"] = lblAR.Text;
                        rArr[0]["lblBank"] = lblBank.Text;
                     //   rArr[0]["AccountsChartSubLevels"] = int.Parse(txt_SublevelNumber.Text);
                        arr = GeneralFunctions.AccountNumberFormat.Split('-');
                        rArr[0]["AccountSubType"] = arr.Length;
                        if (arr.Length == 2)
                        {
                            rArr[0]["FirstSub"] = arr[0].Length;
                            rArr[0]["SecondSub"] = arr[1].Length;
                            rArr[0]["ThirdSub"] = int.Parse("0");
                            rArr[0]["FourthSub"] = int.Parse("0");
                        }
                        if (arr.Length == 3)
                        {
                            rArr[0]["FirstSub"] = arr[0].Length;
                            rArr[0]["SecondSub"] = arr[1].Length;
                            rArr[0]["ThirdSub"] = arr[2].Length;
                            rArr[0]["FourthSub"] = int.Parse("0");
                        }
                        if (arr.Length == 4)
                        {
                            rArr[0]["FirstSub"] = arr[0].Length;
                            rArr[0]["SecondSub"] = arr[1].Length;
                            rArr[0]["ThirdSub"] = arr[2].Length;
                            rArr[0]["FourthSub"] = arr[3].Length;
                        }
                        if (cbMultiCurrency.Checked == true)
                        {

                            rArr[0]["MultiCurrency"] = true;
                        }
                        else
                        {
                            rArr[0]["MultiCurrency"] = false;
                        }
                        rArr[0]["SelectedLanguage"] = comboBox_language.Text;
                        rArr[0]["BalanceSheet"] = GeneralFunctions.Encrypt(cmbBS.Text);

                    }
                    else
                    {
                        MessageBox.Show("if you change account number format you require to change all accounts");
                        rArr[0]["AccountNumberFormat"] = txtMaxAccountNo.Text;
                        rArr[0]["DecimalPointFormat"] = txtDecimalPoint.Text;
                        rArr[0]["DecimalPointsNumber"] = decimalPointsNumber;
                        rArr[0]["JVNumberFormat"] = cb_JVNumberFormat.Text;
                        rArr[0]["APNumberFormat"] = cb_APNumberFormat.Text;
                        rArr[0]["ARNumberFormat"] = cb_ARNumberFormat.Text;
                        rArr[0]["BankNumberFormat"] = cb_BankNumberFormat.Text;
                        rArr[0]["lblJV"] = lblJV.Text;
                        rArr[0]["lblAP"] = lblAP.Text;
                        rArr[0]["lblAR"] = lblAR.Text;
                        rArr[0]["lblBank"] = lblBank.Text;
                      //  rArr[0]["AccountsChartSubLevels"] = int.Parse(txt_SublevelNumber.Text);
                        arr = GeneralFunctions.AccountNumberFormat.Split('-');
                        rArr[0]["AccountSubType"] = arr.Length;
                        if (arr.Length == 2)
                        {
                            rArr[0]["FirstSub"] = arr[0].Length;
                            rArr[0]["SecondSub"] = arr[1].Length;
                            rArr[0]["ThirdSub"] = int.Parse("0");
                            rArr[0]["FourthSub"] = int.Parse("0");
                        }
                        if (arr.Length == 3)
                        {
                            rArr[0]["FirstSub"] = arr[0].Length;
                            rArr[0]["SecondSub"] = arr[1].Length;
                            rArr[0]["ThirdSub"] = arr[2].Length;
                            rArr[0]["FourthSub"] = int.Parse("0");
                        }
                        if (arr.Length == 4)
                        {
                            rArr[0]["FirstSub"] = arr[0].Length;
                            rArr[0]["SecondSub"] = arr[1].Length;
                            rArr[0]["ThirdSub"] = arr[2].Length;
                            rArr[0]["FourthSub"] = arr[3].Length;
                        }
                        if (cbMultiCurrency.Checked == true)
                        {

                            rArr[0]["MultiCurrency"] = true;
                        }
                        else
                        {
                            rArr[0]["MultiCurrency"] = false;
                        }
                        rArr[0]["SelectedLanguage"] = comboBox_language.Text;
                        rArr[0]["BalanceSheet"] = GeneralFunctions.Encrypt(cmbBS.Text);
                    }
                    adapterGeneralSetup.Update(dbAccountingProjectDS.GeneralSetup);

                }
                else
                {
                    txtMaxAccountNo.Text = "";
                    txtDecimalPoint.Text = "";
                    cb_JVNumberFormat.SelectedIndex = -1;
                    cb_APNumberFormat.SelectedIndex = -1;
                    cb_ARNumberFormat.SelectedIndex = -1;
                    cb_BankNumberFormat.SelectedIndex = -1;
                    cmbBS.SelectedIndex = -1;
                    lblAR.Text = "";
                    lblAP.Text = "";
                    lblJV.Text = "";
                    lblBank.Text = "";
                    //txt_SublevelNumber.Text = "";
                }
            }

        }

        private void cb_APNumberFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            GeneralFunctions.APNumberFormat = cb_APNumberFormat.Text;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_ARNumberFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            GeneralFunctions.ARNumberFormat = cb_ARNumberFormat.Text;
        }

        private void GeneralSetup_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralFunctions.UnLockTable("", "GeneralSetup", "", "");
        }

        private void txtMaxAccountNo_TextChanged(object sender, EventArgs e)
        {
            string[] ns;
            string[] sp = new string[1];
            sp[0] = "-";
            ns = txtMaxAccountNo.Text.Split(sp, StringSplitOptions.RemoveEmptyEntries);
            //if (ns.Length != 0)
            //    //txt_SublevelNumber.Text = ns.Length.ToString();
            //else
            // //   txt_SublevelNumber.Text = "0";

        }

        private void txt_SublevelNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}