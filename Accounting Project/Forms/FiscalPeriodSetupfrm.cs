using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;

namespace Accounting_GeneralLedger {
    public partial class FiscalPeriodSetupfrm : Form {
        private SqlConnection sqlcon;
        private SqlCommand sqlcommand;
        private SqlParameter sqlparamIn, sqlparamOut;
        private int fiscalYear;
        private DateTime dt;
        private bool autoSetup;
        private SqlDataAdapter adapterFiscalPeriodSetup;
        private SqlDataAdapter adapterFiscalPeriod;
        private SqlDataAdapter adaptertbGLTotals;
        private SqlCommandBuilder cmdBuilderFiscalPeriodSetup;
        private SqlCommandBuilder cmdBuilderFiscalPeriod;
        private SqlCommandBuilder cmdBuilderGLTotals;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        DataRow[] dr;
        DataRow[] drset;
        DataRow[] rArrResult;

        public FiscalPeriodSetupfrm() {
            InitializeComponent();
        }

        private void FiscalPeriodSetup_Load(object sender, EventArgs e) {
            string msg = GeneralFunctions.CheckLockTables("", "FiscalPeriodSetupfrm", "", "Open");
            if (msg != "")
            {
                MessageBox.Show("FiscalPeriodSetup Open By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btn_new_save.Visible = false;
            }
            GeneralFunctions.LockTables("", "FiscalPeriodSetupfrm", "", "Open");
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            // TODO: This line of code loads data into the 'dbAccountingProjectDS.GLFiscalPeriodSetup' table. You can move, or remove it, as needed.
            this.gLFiscalPeriodSetupTableAdapter.Fill(this.dbAccountingProjectDS.GLFiscalPeriodSetup);
            // TODO: This line of code loads data into the 'dbAccountingProjectDS.GLFiscalPeriodSetup' table. You can move, or remove it, as needed.
            this.gLFiscalPeriodSetupTableAdapter.Fill(this.dbAccountingProjectDS.GLFiscalPeriodSetup);
            adapterFiscalPeriodSetup = new SqlDataAdapter("Select * from GLFiscalPeriodSetup", sqlcon);
            adapterFiscalPeriod = new SqlDataAdapter("Select * from GLFiscalPeriod", sqlcon);
            cmdBuilderFiscalPeriod = new SqlCommandBuilder(adapterFiscalPeriod);
            cmdBuilderFiscalPeriodSetup = new SqlCommandBuilder(adapterFiscalPeriodSetup);
            adapterFiscalPeriodSetup.Fill(dbAccountingProjectDS.GLFiscalPeriodSetup);
            adapterFiscalPeriod.Fill(dbAccountingProjectDS.GLFiscalPeriod);
            adaptertbGLTotals = new SqlDataAdapter("Select * from GLTotals", sqlcon);
            cmdBuilderGLTotals = new SqlCommandBuilder(adaptertbGLTotals);
            adaptertbGLTotals.Fill(dbAccountingProjectDS.GLTotals);

            ResetTextBoxes();

            SqlConnection sqlconPeriodID = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconPeriodID.Open();
            SqlCommand command = new SqlCommand("Select Max(PeriodID)+1 From GLFiscalPeriod", sqlconPeriodID);
            int value;
            if (command.ExecuteScalar() != DBNull.Value)
                value = Convert.ToInt32(command.ExecuteScalar());
            else
                value = 1;
            GeneralFunctions.PeriodID = value;

            DTP_StartDate1.Format = DateTimePickerFormat.Custom;
            DTP_StartDate1.CustomFormat = "dd MMMM yyyy";
            DTP_EndDate1.Format = DateTimePickerFormat.Custom;
            DTP_EndDate1.CustomFormat = "dd MMMM yyyy";

            DTP_StartDate2.Format = DateTimePickerFormat.Custom;
            DTP_StartDate2.CustomFormat = "dd MMMM yyyy";
            DTP_EndDate2.Format = DateTimePickerFormat.Custom;
            DTP_EndDate2.CustomFormat = "dd MMMM yyyy";

            DTP_StartDate3.Format = DateTimePickerFormat.Custom;
            DTP_StartDate3.CustomFormat = "dd MMMM yyyy";
            DTP_EndDate3.Format = DateTimePickerFormat.Custom;
            DTP_EndDate3.CustomFormat = "dd MMMM yyyy";

            DTP_StartDate4.Format = DateTimePickerFormat.Custom;
            DTP_StartDate4.CustomFormat = "dd MMMM yyyy";
            DTP_EndDate4.Format = DateTimePickerFormat.Custom;
            DTP_EndDate4.CustomFormat = "dd MMMM yyyy";

            DTP_StartDate5.Format = DateTimePickerFormat.Custom;
            DTP_StartDate5.CustomFormat = "dd MMMM yyyy";
            DTP_EndDate5.Format = DateTimePickerFormat.Custom;
            DTP_EndDate5.CustomFormat = "dd MMMM yyyy";

            DTP_StartDate6.Format = DateTimePickerFormat.Custom;
            DTP_StartDate6.CustomFormat = "dd MMMM yyyy";
            DTP_EndDate6.Format = DateTimePickerFormat.Custom;
            DTP_EndDate6.CustomFormat = "dd MMMM yyyy";

            DTP_StartDate7.Format = DateTimePickerFormat.Custom;
            DTP_StartDate7.CustomFormat = "dd MMMM yyyy";
            DTP_EndDate7.Format = DateTimePickerFormat.Custom;
            DTP_EndDate7.CustomFormat = "dd MMMM yyyy";

            DTP_StartDate8.Format = DateTimePickerFormat.Custom;
            DTP_StartDate8.CustomFormat = "dd MMMM yyyy";
            DTP_EndDate8.Format = DateTimePickerFormat.Custom;
            DTP_EndDate8.CustomFormat = "dd MMMM yyyy";

            DTP_StartDate9.Format = DateTimePickerFormat.Custom;
            DTP_StartDate9.CustomFormat = "dd MMMM yyyy";
            DTP_EndDate9.Format = DateTimePickerFormat.Custom;
            DTP_EndDate9.CustomFormat = "dd MMMM yyyy";

            DTP_StartDate10.Format = DateTimePickerFormat.Custom;
            DTP_StartDate10.CustomFormat = "dd MMMM yyyy";
            DTP_EndDate10.Format = DateTimePickerFormat.Custom;
            DTP_EndDate10.CustomFormat = "dd MMMM yyyy";

            DTP_StartDate11.Format = DateTimePickerFormat.Custom;
            DTP_StartDate11.CustomFormat = "dd MMMM yyyy";
            DTP_EndDate11.Format = DateTimePickerFormat.Custom;
            DTP_EndDate11.CustomFormat = "dd MMMM yyyy";


            DTP_StartDate12.Format = DateTimePickerFormat.Custom;
            DTP_StartDate12.CustomFormat = "dd MMMM yyyy";
            DTP_EndDate12.Format = DateTimePickerFormat.Custom;
            DTP_EndDate12.CustomFormat = "dd MMMM yyyy";

            DTP_StartDate13.Format = DateTimePickerFormat.Custom;
            DTP_StartDate13.CustomFormat = "dd MMMM yyyy";
            DTP_EndDate13.Format = DateTimePickerFormat.Custom;
            DTP_EndDate13.CustomFormat = "dd MMMM yyyy";


            if (GeneralFunctions.languagechioce != "")
            {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }

        }
        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.fiscalPeriod;
            this.gLFiscalPeriodSetupDataGridView.Columns[0].HeaderText = obj_interface_language.gLFiscalPeriodSetupDataGridViewColumn1.ToString();
            this.labelFiscalYear.Text = obj_interface_language.labelFiscalYear;
            this.labelStartDate.Text = obj_interface_language.labelStartDate;
            this.labelEndDate.Text = obj_interface_language.labelEndDate;
            this.labelPeriodDescription.Text = obj_interface_language.labelPeriodDescription;
            this.btn_AutoSetup.Text = obj_interface_language.btn_AutoSetup;
            this.btn_SaveChanges.Text = obj_interface_language.btn_SaveChanges;
            this.resetAutoSetupToolStripMenuItem.Text = obj_interface_language.resetAutoSetupToolStripMenuItem;
            this.insertToolStripMenuItem.Text = obj_interface_language.insertToolStripMenuItem;
            this.editToolStripMenuItem.Text = obj_interface_language.editToolStripMenuItem;
            this.deleteToolStripMenuItem.Text = obj_interface_language.deleteToolStripMenuItem;
            this.exitToolStripMenuItem.Text = obj_interface_language.exitToolStripMenuItem;
            this.optionsToolStripMenuItem.Text = obj_interface_language.optionsToolStripMenuItem;
            this.btn_new_save.Text = obj_interface_language.btn_new_save;
            this.btn_edit_save.Text = obj_interface_language.btn_edit_save;
            this.btn_delete_save.Text = obj_interface_language.btn_delete_save;
            this.btn_exit.Text = obj_interface_language.btn_exit;
            this.labelPeriod1.Text = obj_interface_language.labelPeriod1;
            this.labelPeriod2.Text = obj_interface_language.labelPeriod2;
            this.labelPeriod3.Text = obj_interface_language.labelPeriod3;
            this.labelPeriod4.Text = obj_interface_language.labelPeriod4;
            this.labelPeriod5.Text = obj_interface_language.labelPeriod5;
            this.labelPeriod6.Text = obj_interface_language.labelPeriod6;
            this.labelPeriod7.Text = obj_interface_language.labelPeriod7;
            this.labelPeriod8.Text = obj_interface_language.labelPeriod8;
            this.labelPeriod9.Text = obj_interface_language.labelPeriod9;
            this.labelPeriod10.Text = obj_interface_language.labelPeriod10;
            this.labelPeriod11.Text = obj_interface_language.labelPeriod11;
            this.labelPeriod12.Text = obj_interface_language.labelPeriod12;
            this.labelPeriod13.Text = obj_interface_language.labelPeriod13;
        }
        private bool FiscalYearValidate() {
            bool valid = true;
            if (txt_FiscalYear.Text != "") {
                try {
                    fiscalYear = int.Parse(txt_FiscalYear.Text);
                    if (fiscalYear > 1753 && fiscalYear < 9998) {
                        valid = true;
                    }
                    else {
                        MessageBox.Show("Please Enter the desired Year between 1753 and 9998", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        valid = false;
                    }
                }
                catch {
                    MessageBox.Show("Please Enter acceptable value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valid = false;
                }
            }
            else {
                MessageBox.Show("Please Enter the desired Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valid = false;
            }
            return valid;
        }

        private void btn_AutoSetup_Click(object sender, EventArgs e) {
            if (FiscalYearValidate()) {
                if (DialogResult.Yes == MessageBox.Show("The Auto Setup creates a 12 period setup\n Are you sure you want to preceed", "Alert", MessageBoxButtons.YesNo)) {
                    dt = new DateTime(fiscalYear, 1, 1);
                    DTP_StartDate1.Value = dt;
                    DTP_EndDate1.Value = FindLastDayInMonth(dt);

                    dt = new DateTime(fiscalYear, 2, 1);
                    DTP_StartDate2.Value = dt;
                    DTP_EndDate2.Value = FindLastDayInMonth(dt);

                    dt = new DateTime(fiscalYear, 3, 1);
                    DTP_StartDate3.Value = dt;
                    DTP_EndDate3.Value = FindLastDayInMonth(dt);

                    dt = new DateTime(fiscalYear, 4, 1);
                    DTP_StartDate4.Value = dt;
                    DTP_EndDate4.Value = FindLastDayInMonth(dt);

                    dt = new DateTime(fiscalYear, 5, 1);
                    DTP_StartDate5.Value = dt;
                    DTP_EndDate5.Value = FindLastDayInMonth(dt);

                    dt = new DateTime(fiscalYear, 6, 1);
                    DTP_StartDate6.Value = dt;
                    DTP_EndDate6.Value = FindLastDayInMonth(dt);

                    dt = new DateTime(fiscalYear, 7, 1);
                    DTP_StartDate7.Value = dt;
                    DTP_EndDate7.Value = FindLastDayInMonth(dt);

                    dt = new DateTime(fiscalYear, 8, 1);
                    DTP_StartDate8.Value = dt;
                    DTP_EndDate8.Value = FindLastDayInMonth(dt);

                    dt = new DateTime(fiscalYear, 9, 1);
                    DTP_StartDate9.Value = dt;
                    DTP_EndDate9.Value = FindLastDayInMonth(dt);

                    dt = new DateTime(fiscalYear, 10, 1);
                    DTP_StartDate10.Value = dt;
                    DTP_EndDate10.Value = FindLastDayInMonth(dt);

                    dt = new DateTime(fiscalYear, 11, 1);
                    DTP_StartDate11.Value = dt;
                    DTP_EndDate11.Value = FindLastDayInMonth(dt);

                    dt = new DateTime(fiscalYear, 12, 1);
                    DTP_StartDate12.Value = dt;
                    DTP_EndDate12.Value = FindLastDayInMonth(dt);

                    labelPeriod13.Visible = false;
                    txt_Period13.Visible = false;
                    DTP_StartDate13.Visible = false;
                    DTP_EndDate13.Visible = false;

                    autoSetup = true;
                }
            }
        }

        private DateTime FindLastDayInMonth(DateTime startdate) {
            sqlcon.Open();
            sqlcommand = new SqlCommand("sp_EndOfMonth", sqlcon);
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlparamIn = sqlcommand.Parameters.Add("@date", SqlDbType.DateTime);
            sqlparamIn.Value = startdate;
            sqlparamOut = sqlcommand.Parameters.Add("@lastday", SqlDbType.DateTime);
            sqlparamOut.Direction = ParameterDirection.Output;
            sqlcommand.ExecuteNonQuery();
            sqlcon.Close();
            return ((DateTime) sqlcommand.Parameters["@lastday"].Value);

        }

        private bool ValidatePeriodDates()
        {
            string sDate = "";
            bool valid = true;
            DateTime checkDate;

            checkDate = AddDate(DTP_EndDate1.Value);
            if (DTP_StartDate2.Value != checkDate)
            {
                valid = false;
                if (sDate == "")
                    sDate = checkDate.ToShortDateString();
            }

            checkDate = AddDate(DTP_EndDate2.Value);
            if (DTP_StartDate3.Value != checkDate)
            {
                valid = false; if (sDate == "")
                    sDate = checkDate.ToShortDateString();
            }

            checkDate = AddDate(DTP_EndDate3.Value);
            if (DTP_StartDate4.Value != checkDate)
            {
                valid = false; if (sDate == "")
                    sDate = checkDate.ToShortDateString();
            }

            checkDate = AddDate(DTP_EndDate4.Value);
            if (DTP_StartDate5.Value != checkDate)
            {
                valid = false; if (sDate == "")
                    sDate = checkDate.ToShortDateString();
            }

            checkDate = AddDate(DTP_EndDate5.Value);
            if (DTP_StartDate6.Value != checkDate)
            {
                valid = false; if (sDate == "")
                    sDate = checkDate.ToShortDateString();
            }

            checkDate = AddDate(DTP_EndDate6.Value);
            if (DTP_StartDate7.Value != checkDate)
            {
                valid = false; if (sDate == "")
                    sDate = checkDate.ToShortDateString();
            }

            checkDate = AddDate(DTP_EndDate7.Value);
            if (DTP_StartDate8.Value != checkDate)
            {
                valid = false; if (sDate == "")
                    sDate = checkDate.ToShortDateString();
            }

            checkDate = AddDate(DTP_EndDate8.Value);
            if (DTP_StartDate9.Value != checkDate)
            {
                valid = false; if (sDate == "")
                    sDate = checkDate.ToShortDateString();
            }

            checkDate = AddDate(DTP_EndDate9.Value);
            if (DTP_StartDate10.Value != checkDate)
            {
                valid = false; if (sDate == "")
                    sDate = checkDate.ToShortDateString();
            }


            checkDate = AddDate(DTP_EndDate10.Value);
            if (DTP_StartDate11.Value != checkDate)
            {
                valid = false; if (sDate == "")
                    sDate = checkDate.ToShortDateString();
            }

            checkDate = AddDate(DTP_EndDate11.Value);
            if (DTP_StartDate12.Value != checkDate)
            {
                valid = false;
                if (sDate == "")
                    sDate = checkDate.ToShortDateString();
            }

        if (!autoSetup)
        {
            checkDate = AddDate(DTP_EndDate12.Value);
            if (DTP_StartDate13.Value != checkDate)
            {
                valid = false;
                if (sDate == "")
                    sDate = checkDate.ToShortDateString();
            }
        }
            if (sDate != "")
                MessageBox.Show("Please Chick Distribution Dates ( " + sDate + " )", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return valid;
        }

        private DateTime AddDate(DateTime date) {
            DateTime dtResult;
            sqlcon.Open();
            sqlcommand = new SqlCommand("sp_AddDay", sqlcon);
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlparamIn = sqlcommand.Parameters.Add("@date", SqlDbType.DateTime);
            SqlParameter sqlparamIn2 = sqlcommand.Parameters.Add("@dayNumber", SqlDbType.Int);
            sqlparamIn.Value = date;
            sqlparamIn2.Value = 1;
            dtResult = (DateTime) sqlcommand.ExecuteScalar();
            sqlcon.Close();
            return dtResult;

        }

        private void ResetTextBoxes() {
            txt_Period1.Text = "Period 1";
            txt_Period2.Text = "Period 2";
            txt_Period3.Text = "Period 3";
            txt_Period4.Text = "Period 4";
            txt_Period5.Text = "Period 5";
            txt_Period6.Text = "Period 6";
            txt_Period7.Text = "Period 7";
            txt_Period8.Text = "Period 8";
            txt_Period9.Text = "Period 9";
            txt_Period10.Text = "Period 10";
            txt_Period11.Text = "Period 11";
            txt_Period12.Text = "Period 12";
            txt_Period13.Text = "Period 13";
        }

        private bool ValidatePeriodDescription() {
            if (GeneralFunctions.ValidateSpacedString(txt_Period1.Text, "Please Specify Period1 Description")
               && GeneralFunctions.ValidateSpacedString(txt_Period2.Text, "Please Specify Period2 Description")
               && GeneralFunctions.ValidateSpacedString(txt_Period3.Text, "Please Specify Period3 Description")
               && GeneralFunctions.ValidateSpacedString(txt_Period4.Text, "Please Specify Period4 Description")
               && GeneralFunctions.ValidateSpacedString(txt_Period5.Text, "Please Specify Period5 Description")
               && GeneralFunctions.ValidateSpacedString(txt_Period6.Text, "Please Specify Period6 Description")
               && GeneralFunctions.ValidateSpacedString(txt_Period7.Text, "Please Specify Period7 Description")
               && GeneralFunctions.ValidateSpacedString(txt_Period8.Text, "Please Specify Period8 Description")
               && GeneralFunctions.ValidateSpacedString(txt_Period9.Text, "Please Specify Period9 Description")
               && GeneralFunctions.ValidateSpacedString(txt_Period10.Text, "Please Specify Period10 Description")
               && GeneralFunctions.ValidateSpacedString(txt_Period11.Text, "Please Specify Period11 Description")
               && GeneralFunctions.ValidateSpacedString(txt_Period12.Text, "Please Specify Period12 Description")
               && GeneralFunctions.ValidateSpacedString(txt_Period13.Text, "Please Specify Period13 Description"))
                return true;
            else
                return false;
        }

        private void AddGLTotalRow() {
            try
            {
                int StartYear = Convert.ToInt32(txt_FiscalYear.Text);
                SqlConnection mainsqlconn = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand mainsqlcomm = new SqlCommand("Select Distinct YEAR(FiscalYear) From GLTotals", mainsqlconn);
                mainsqlconn.Open();
                SqlDataReader read = mainsqlcomm.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();
                    StartYear = read.GetInt32(0);
                }
                read.Close();
                mainsqlconn.Close();

            //    while (read.Read()) {
            SqlConnection sqlAccountsConnection = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand sqlAccountsCommand = new SqlCommand("Select AccountNumber,OpeningBalance From GLAccounts", sqlAccountsConnection);
            sqlAccountsConnection.Open();
            SqlDataReader sqlAccountRead = sqlAccountsCommand.ExecuteReader();
            if (sqlAccountRead.HasRows)
            {
                while (sqlAccountRead.Read())
                {
                    //SqlConnection sqlGetAccountFromGLAccountsCon = new SqlConnection(GeneralFunctions.ConnectionString);
                    //SqlCommand sqlGetAccountFromGLAccountsCom = new SqlCommand("Select * From GLTotals WHERE FiscalYear <> " + read.GetInt32(0) + "", sqlGetAccountFromGLAccountsCon);
                    //sqlGetAccountFromGLAccountsCon.Open();
                    //SqlDataReader sqlGetAccountFromGLAccountRead = sqlGetAccountFromGLAccountsCom.ExecuteReader();
                    //if (sqlGetAccountFromGLAccountRead.HasRows) {
                    //    while (sqlGetAccountFromGLAccountRead.Read()) {
                    DataRow r = dbAccountingProjectDS.GLTotals.NewRow();
                    SqlConnection sq = new SqlConnection(GeneralFunctions.ConnectionString);
                    sq.Open();
                    SqlCommand sqcommand = new SqlCommand("Select max(TotalID)+1 From GLTotals", sq);
                    if (sqcommand.ExecuteScalar() == DBNull.Value)
                        GeneralFunctions.TotalID = 1;
                    else
                        GeneralFunctions.TotalID = Convert.ToInt32(sqcommand.ExecuteScalar());
                    if (Convert.ToInt32(txt_FiscalYear.Text) == StartYear)
                    {
                        r["TotalID"] = GeneralFunctions.TotalID;
                        r["AccountNumber"] = sqlAccountRead.GetString(0);
                        r["FiscalYear"] = Convert.ToInt32(txt_FiscalYear.Text);
                        r["BeginningBalance"] = sqlAccountRead.GetDouble(1);
                        r["PeriodBalance1"] = sqlAccountRead.GetDouble(1);
                        r["PeriodBalance2"] = 0;
                        r["PeriodBalance3"] = 0;
                        r["PeriodBalance4"] = 0;
                        r["PeriodBalance5"] = 0;
                        r["PeriodBalance6"] = 0;
                        r["PeriodBalance7"] = 0;
                        r["PeriodBalance8"] = 0;
                        r["PeriodBalance9"] = 0;
                        r["PeriodBalance10"] = 0;
                        r["PeriodBalance11"] = 0;
                        r["PeriodBalance12"] = 0;
                        r["PeriodBalance13"] = 0;
                        r["PeriodBalance99"] = 0;
                    }
                    else
                    {
                        r["TotalID"] = GeneralFunctions.TotalID;
                        r["AccountNumber"] = sqlAccountRead.GetString(0);
                        r["FiscalYear"] = Convert.ToInt32(txt_FiscalYear.Text);
                        r["BeginningBalance"] = 0;
                        r["PeriodBalance1"] = 0;
                        r["PeriodBalance2"] = 0;
                        r["PeriodBalance3"] = 0;
                        r["PeriodBalance4"] = 0;
                        r["PeriodBalance5"] = 0;
                        r["PeriodBalance6"] = 0;
                        r["PeriodBalance7"] = 0;
                        r["PeriodBalance8"] = 0;
                        r["PeriodBalance9"] = 0;
                        r["PeriodBalance10"] = 0;
                        r["PeriodBalance11"] = 0;
                        r["PeriodBalance12"] = 0;
                        r["PeriodBalance13"] = 0;
                        r["PeriodBalance99"] = 0;
                    }
                    dbAccountingProjectDS.GLTotals.Rows.Add(r);
                    sq.Close();
                    adaptertbGLTotals.Update(dbAccountingProjectDS.GLTotals);
                    dbAccountingProjectDS.AcceptChanges();
                    //    }
                    //}
                }
             }
            adaptertbGLTotals.Update(dbAccountingProjectDS.GLTotals);
            dbAccountingProjectDS.AcceptChanges();
           
            }
                catch (Exception ex){    
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        
            //    }

            //}

        }
        private void insertToolStripMenuItem_Click(object sender, EventArgs e) {
            int currentPeriodId;
            if (FiscalYearValidate() && ValidatePeriodDates() && ValidatePeriodDescription())
            {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select FiscalYear from GLFiscalPeriodSetup where FiscalYear = '" + fiscalYear + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("FiscalYear = '" + fiscalYear + "'", dbAccountingProjectDS.GLFiscalPeriodSetup))
                {
                    dr.Close();
                    DataRow r = this.dbAccountingProjectDS.GLFiscalPeriodSetup.NewRow();
                    r["FiscalYear"] = fiscalYear;

                    currentPeriodId = AddPeriodID(r, "PeriodID1");
                    AddPeriodRow(currentPeriodId, txt_Period1.Text, DTP_StartDate1.Value, DTP_EndDate1.Value, 1);

                    currentPeriodId = AddPeriodID(r, "PeriodID2");
                    AddPeriodRow(currentPeriodId, txt_Period2.Text, DTP_StartDate2.Value, DTP_EndDate2.Value, 2);

                    currentPeriodId = AddPeriodID(r, "PeriodID3");
                    AddPeriodRow(currentPeriodId, txt_Period3.Text, DTP_StartDate3.Value, DTP_EndDate3.Value, 3);

                    currentPeriodId = AddPeriodID(r, "PeriodID4");
                    AddPeriodRow(currentPeriodId, txt_Period4.Text, DTP_StartDate4.Value, DTP_EndDate4.Value, 4);

                    currentPeriodId = AddPeriodID(r, "PeriodID5");
                    AddPeriodRow(currentPeriodId, txt_Period5.Text, DTP_StartDate5.Value, DTP_EndDate5.Value, 5);

                    currentPeriodId = AddPeriodID(r, "PeriodID6");
                    AddPeriodRow(currentPeriodId, txt_Period6.Text, DTP_StartDate6.Value, DTP_EndDate6.Value, 6);

                    currentPeriodId = AddPeriodID(r, "PeriodID7");
                    AddPeriodRow(currentPeriodId, txt_Period7.Text, DTP_StartDate7.Value, DTP_EndDate7.Value, 7);

                    currentPeriodId = AddPeriodID(r, "PeriodID8");
                    AddPeriodRow(currentPeriodId, txt_Period8.Text, DTP_StartDate8.Value, DTP_EndDate8.Value, 8);

                    currentPeriodId = AddPeriodID(r, "PeriodID9");
                    AddPeriodRow(currentPeriodId, txt_Period9.Text, DTP_StartDate9.Value, DTP_EndDate9.Value, 9);

                    currentPeriodId = AddPeriodID(r, "PeriodID10");
                    AddPeriodRow(currentPeriodId, txt_Period10.Text, DTP_StartDate10.Value, DTP_EndDate10.Value, 10);

                    currentPeriodId = AddPeriodID(r, "PeriodID11");
                    AddPeriodRow(currentPeriodId, txt_Period11.Text, DTP_StartDate11.Value, DTP_EndDate11.Value, 11);

                    currentPeriodId = AddPeriodID(r, "PeriodID12");
                    AddPeriodRow(currentPeriodId, txt_Period12.Text, DTP_StartDate12.Value, DTP_EndDate12.Value, 12);
                    if (!autoSetup)
                    {
                        currentPeriodId = AddPeriodID(r, "PeriodID13");
                        AddPeriodRow(currentPeriodId, txt_Period13.Text, DTP_StartDate13.Value, DTP_EndDate13.Value, 13);
                    }

                    r["Status"] = "OPEN";
                    dbAccountingProjectDS.GLFiscalPeriodSetup.Rows.Add(r);
                    dr.Close();
                    adapterFiscalPeriodSetup.Update(dbAccountingProjectDS.GLFiscalPeriodSetup);
                    dbAccountingProjectDS.AcceptChanges();
                    dr.Close();
                    sqlcon.Close();
                    AddGLTotalRow();
                    ClearAll();
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Fiscal Year Periods already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = this.dbAccountingProjectDS.GLFiscalPeriodSetup.Select("FiscalYear = '" + fiscalYear + "'");
                        EditPeriodRow(((int)rArr[0]["PeriodID1"]), txt_Period1.Text, DTP_StartDate1.Value, DTP_EndDate1.Value);
                        EditPeriodRow(((int)rArr[0]["PeriodID2"]), txt_Period2.Text, DTP_StartDate2.Value, DTP_EndDate2.Value);
                        EditPeriodRow(((int)rArr[0]["PeriodID3"]), txt_Period3.Text, DTP_StartDate3.Value, DTP_EndDate3.Value);
                        EditPeriodRow(((int)rArr[0]["PeriodID4"]), txt_Period4.Text, DTP_StartDate4.Value, DTP_EndDate4.Value);
                        EditPeriodRow(((int)rArr[0]["PeriodID5"]), txt_Period5.Text, DTP_StartDate5.Value, DTP_EndDate5.Value);
                        EditPeriodRow(((int)rArr[0]["PeriodID6"]), txt_Period6.Text, DTP_StartDate6.Value, DTP_EndDate6.Value);
                        EditPeriodRow(((int)rArr[0]["PeriodID7"]), txt_Period7.Text, DTP_StartDate7.Value, DTP_EndDate7.Value);
                        EditPeriodRow(((int)rArr[0]["PeriodID8"]), txt_Period8.Text, DTP_StartDate8.Value, DTP_EndDate8.Value);
                        EditPeriodRow(((int)rArr[0]["PeriodID9"]), txt_Period9.Text, DTP_StartDate9.Value, DTP_EndDate9.Value);
                        EditPeriodRow(((int)rArr[0]["PeriodID10"]), txt_Period10.Text, DTP_StartDate10.Value, DTP_EndDate10.Value);
                        EditPeriodRow(((int)rArr[0]["PeriodID11"]), txt_Period11.Text, DTP_StartDate11.Value, DTP_EndDate11.Value);
                        EditPeriodRow(((int)rArr[0]["PeriodID12"]), txt_Period12.Text, DTP_StartDate12.Value, DTP_EndDate12.Value);
                        if (!autoSetup)
                            EditPeriodRow(((int)rArr[0]["PeriodID13"]), txt_Period13.Text, DTP_StartDate13.Value, DTP_EndDate13.Value);
                        ClearAll();
                    }
                    else
                    {
                        ClearAll();
                    }
                    dr.Close();
                    sqlcon.Close();
                }
            }
            else
                return;
            adapterFiscalPeriodSetup.Update(dbAccountingProjectDS.GLFiscalPeriodSetup);
            adapterFiscalPeriod.Update(dbAccountingProjectDS.GLFiscalPeriod);
            dbAccountingProjectDS.AcceptChanges();
            SqlConnection sqlconPeriodID2 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconPeriodID2.Open();
            SqlCommand command2 = new SqlCommand("Select Max(PeriodID)+1 From GLFiscalPeriod", sqlconPeriodID2);
            int value2;
            if (command2.ExecuteScalar() != DBNull.Value)
                value2 = Convert.ToInt32(command2.ExecuteScalar());
            else
                value2 = 1;
            GeneralFunctions.PeriodID = value2;
            MessageBox.Show("Create Year Successfully", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int AddPeriodID(DataRow r, string columnName) {

            //***********************
            SqlConnection sqlconPeriodID = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconPeriodID.Open();
            SqlCommand command = new SqlCommand("Select Max(PeriodID)+1 From GLFiscalPeriod", sqlconPeriodID);
            int value;
            if (command.ExecuteScalar() != DBNull.Value)
                value = Convert.ToInt32(command.ExecuteScalar());
            else
                value = 1;
            GeneralFunctions.PeriodID = value;
            //**************************
            sqlconPeriodID.Close();
            r[columnName] = GeneralFunctions.PeriodID;
            //GeneralFunctions.PeriodID++;
            return int.Parse(r[columnName].ToString());
        }

        private void AddPeriodRow(int periodID, string description, DateTime startDate, DateTime endDate, int periodNumber) {
            DataRow r = dbAccountingProjectDS.GLFiscalPeriod.NewRow();
            r["PeriodID"] = periodID;
            r["PeriodDescription"] = description;
            r["PeriodNumber"] = periodNumber;
            r["PeriodStartDate"] = startDate;
            r["PeriodEndDate"] = endDate;
            r["Status"] = "OPEN";
            dbAccountingProjectDS.GLFiscalPeriod.Rows.Add(r);
            adapterFiscalPeriod.Update(dbAccountingProjectDS.GLFiscalPeriod);
            dbAccountingProjectDS.AcceptChanges();
        }

        private void EditPeriodRow(int periodID, string description, DateTime startDate, DateTime endDate) {
            rArrResult = this.dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID = '" + periodID + "'");
            rArrResult[0]["PeriodStartDate"] = startDate;
            rArrResult[0]["PeriodEndDate"] = endDate;
            rArrResult[0]["PeriodDescription"] = description;

        }

        private void btn_SaveChanges_Click(object sender, EventArgs e) {
            adapterFiscalPeriodSetup.Update(dbAccountingProjectDS.GLFiscalPeriodSetup);
            adapterFiscalPeriod.Update(dbAccountingProjectDS.GLFiscalPeriod);
            dbAccountingProjectDS.AcceptChanges();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            if (FiscalYearValidate() && ValidatePeriodDates() && ValidatePeriodDescription()) {
                DataRow[] rArr = this.dbAccountingProjectDS.GLFiscalPeriodSetup.Select("FiscalYear = '" + fiscalYear + "'");
                if (rArr.Length != 0) {
                    EditPeriodRow(((int) rArr[0]["PeriodID1"]), txt_Period1.Text, DTP_StartDate1.Value, DTP_EndDate1.Value);
                    EditPeriodRow(((int) rArr[0]["PeriodID2"]), txt_Period2.Text, DTP_StartDate2.Value, DTP_EndDate2.Value);
                    EditPeriodRow(((int) rArr[0]["PeriodID3"]), txt_Period3.Text, DTP_StartDate3.Value, DTP_EndDate3.Value);
                    EditPeriodRow(((int) rArr[0]["PeriodID4"]), txt_Period4.Text, DTP_StartDate4.Value, DTP_EndDate4.Value);
                    EditPeriodRow(((int) rArr[0]["PeriodID5"]), txt_Period5.Text, DTP_StartDate5.Value, DTP_EndDate5.Value);
                    EditPeriodRow(((int) rArr[0]["PeriodID6"]), txt_Period6.Text, DTP_StartDate6.Value, DTP_EndDate6.Value);
                    EditPeriodRow(((int) rArr[0]["PeriodID7"]), txt_Period7.Text, DTP_StartDate7.Value, DTP_EndDate7.Value);
                    EditPeriodRow(((int) rArr[0]["PeriodID8"]), txt_Period8.Text, DTP_StartDate8.Value, DTP_EndDate8.Value);
                    EditPeriodRow(((int) rArr[0]["PeriodID9"]), txt_Period9.Text, DTP_StartDate9.Value, DTP_EndDate9.Value);
                    EditPeriodRow(((int) rArr[0]["PeriodID10"]), txt_Period10.Text, DTP_StartDate10.Value, DTP_EndDate10.Value);
                    EditPeriodRow(((int) rArr[0]["PeriodID11"]), txt_Period11.Text, DTP_StartDate11.Value, DTP_EndDate11.Value);
                    EditPeriodRow(((int) rArr[0]["PeriodID12"]), txt_Period12.Text, DTP_StartDate12.Value, DTP_EndDate12.Value);
                    if (!autoSetup)
                        EditPeriodRow(((int) rArr[0]["PeriodID13"]), txt_Period13.Text, DTP_StartDate13.Value, DTP_EndDate13.Value);
                    ClearAll();
                }
            }
            else {
                MessageBox.Show("The given Fiscal Year doesnt exist \n Cant perform edit operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            adapterFiscalPeriodSetup.Update(dbAccountingProjectDS.GLFiscalPeriodSetup);
            adapterFiscalPeriod.Update(dbAccountingProjectDS.GLFiscalPeriod);
            dbAccountingProjectDS.AcceptChanges();
            SqlConnection sqlconPeriodID = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconPeriodID.Open();
            SqlCommand command = new SqlCommand("Select Max(PeriodID)+1 From GLFiscalPeriod", sqlconPeriodID);
            int value;
            if (command.ExecuteScalar() != DBNull.Value)
                value = Convert.ToInt32(command.ExecuteScalar());
            else
                value = 1;
            GeneralFunctions.PeriodID = value;
            MessageBox.Show("Edit Year Successfully", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("Are you sure to delete this fiscal year from Database?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                return;
            if (FiscalYearValidate())
            {
                //if (DialogResult.Yes == MessageBox.Show("Are you sure to delete this fiscal year from Database?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                //{
                if (DialogResult.OK == MessageBox.Show("This will affect many data related to this fiscal year ,Press Ok to confirm", "Help", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                {
                    SqlConnection deleteConnection = new SqlConnection(GeneralFunctions.ConnectionString);
                    SqlCommand deleteCommand;
                    deleteConnection.Open();
                    int x = 0;
                    deleteCommand = new SqlCommand("Delete From GLTotals Where FiscalYear=" + Convert.ToInt32(txt_FiscalYear.Text) + "", deleteConnection);
                    x += deleteCommand.ExecuteNonQuery();
                    deleteCommand = new SqlCommand("Delete From GLBudget Where FiscalYear=" + Convert.ToInt32(txt_FiscalYear.Text) + "", deleteConnection);
                    x += deleteCommand.ExecuteNonQuery();
                }
                else
                    return;
                //}
                DataRow[] drs = dbAccountingProjectDS.GLTotals.Select("FiscalYear = '" + Convert.ToInt32(txt_FiscalYear.Text) + "'");
                if (drs.Length != 0)
                {
                    for (int i = drs.Length - 1; i >= 0; i--)
                    {
                        drs[i].Delete();

                    }
                }
                DataRow[] rArrPeriods;
                DataRow[] rArr = dbAccountingProjectDS.GLFiscalPeriodSetup.Select("FiscalYear = '" + fiscalYear + "'");
                if (rArr.Length != 0)
                {
                    rArrPeriods = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID = " + ((int)rArr[0]["PeriodID1"]));
                    rArrPeriods[0].Delete();
                    rArrPeriods = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID = " + ((int)rArr[0]["PeriodID2"]));
                    rArrPeriods[0].Delete();
                    rArrPeriods = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID = " + ((int)rArr[0]["PeriodID3"]));
                    rArrPeriods[0].Delete();
                    rArrPeriods = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID = " + ((int)rArr[0]["PeriodID4"]));
                    rArrPeriods[0].Delete();
                    rArrPeriods = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID = " + ((int)rArr[0]["PeriodID5"]));
                    rArrPeriods[0].Delete();
                    rArrPeriods = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID = " + ((int)rArr[0]["PeriodID6"]));
                    rArrPeriods[0].Delete();
                    rArrPeriods = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID = " + ((int)rArr[0]["PeriodID7"]));
                    rArrPeriods[0].Delete();
                    rArrPeriods = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID = " + ((int)rArr[0]["PeriodID8"]));
                    rArrPeriods[0].Delete();
                    rArrPeriods = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID = " + ((int)rArr[0]["PeriodID9"]));
                    rArrPeriods[0].Delete();
                    rArrPeriods = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID = " + ((int)rArr[0]["PeriodID10"]));
                    rArrPeriods[0].Delete();
                    rArrPeriods = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID = " + ((int)rArr[0]["PeriodID11"]));
                    rArrPeriods[0].Delete();
                    rArrPeriods = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID = " + ((int)rArr[0]["PeriodID12"]));
                    rArrPeriods[0].Delete();
                    if (rArr[0]["PeriodID13"].ToString() != "")
                    {
                        rArrPeriods = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID = " + ((int)rArr[0]["PeriodID13"]));
                        rArrPeriods[0].Delete();
                    }
                    rArr[0].Delete();
                    ClearAll();
                }
                else
                {
                    MessageBox.Show("The given Fiscal Year doesnt exist \n Cant perform delete operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
                return;
            adapterFiscalPeriodSetup.Update(dbAccountingProjectDS.GLFiscalPeriodSetup);
            adapterFiscalPeriod.Update(dbAccountingProjectDS.GLFiscalPeriod);
            dbAccountingProjectDS.AcceptChanges();
            SqlConnection sqlconPeriodID = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconPeriodID.Open();
            SqlCommand command = new SqlCommand("Select Max(PeriodID)+1 From GLFiscalPeriod", sqlconPeriodID);
            int value;
            if (command.ExecuteScalar() != DBNull.Value)
                value = Convert.ToInt32(command.ExecuteScalar());
            else
                value = 1;
            GeneralFunctions.PeriodID = value;
            MessageBox.Show("Delete Year Successfully", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void ClearAll() {
            ResetTextBoxes();
            txt_FiscalYear.Text = "";
            DTP_StartDate1.Text = "";
            DTP_EndDate1.Text = "";

            DTP_StartDate2.Text = "";
            DTP_EndDate2.Text = "";

            DTP_StartDate3.Text = "";
            DTP_EndDate3.Text = "";

            DTP_StartDate4.Text = "";
            DTP_EndDate4.Text = "";

            DTP_StartDate5.Text = "";
            DTP_EndDate5.Text = "";

            DTP_StartDate6.Text = "";
            DTP_EndDate6.Text = "";

            DTP_StartDate7.Text = "";
            DTP_EndDate7.Text = "";

            DTP_StartDate8.Text = "";
            DTP_EndDate8.Text = "";

            DTP_StartDate9.Text = "";
            DTP_EndDate9.Text = "";

            DTP_StartDate10.Text = "";
            DTP_EndDate10.Text = "";

            DTP_StartDate11.Text = "";
            DTP_EndDate11.Text = "";

            DTP_StartDate12.Text = "";
            DTP_EndDate12.Text = "";

            DTP_StartDate13.Text = "";
            DTP_EndDate13.Text = "";
        }

        private void resetAutoSetupToolStripMenuItem_Click(object sender, EventArgs e) {
            labelPeriod13.Visible = true;
            txt_Period13.Visible = true;
            DTP_StartDate13.Visible = true;
            DTP_EndDate13.Visible = true;
            autoSetup = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void gLFiscalPeriodSetupBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.gLFiscalPeriodSetupBindingSource.EndEdit();
            this.gLFiscalPeriodSetupTableAdapter.Update(this.dbAccountingProjectDS.GLFiscalPeriodSetup);

        }

        private void gLFiscalPeriodSetupBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.gLFiscalPeriodSetupBindingSource.EndEdit();
            this.gLFiscalPeriodSetupTableAdapter.Update(this.dbAccountingProjectDS.GLFiscalPeriodSetup);

        }

        private void gLFiscalPeriodSetupDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gLFiscalPeriodSetupDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gLFiscalPeriodSetupDataGridView.Rows.Count == 0)
                {
                    foreach (Control mycon in this.Controls)
                    {
                        if (mycon is DateTimePicker)
                        {
                            mycon.Text = DateTime.Now.ToShortDateString();
                        }

                    }
                    txt_FiscalYear.Text = "";
                }
                else
                {
                    int i;
                    i = gLFiscalPeriodSetupDataGridView.CurrentRow.Index;
                    string x;
                    x = gLFiscalPeriodSetupDataGridView[0, i].Value.ToString();

                    drset = dbAccountingProjectDS.GLFiscalPeriodSetup.Select("FiscalYear ='" + x + "'");

                    if (drset.Length != 0)
                    {
                        txt_FiscalYear.Text = x;
                        if (drset[0][1] != DBNull.Value)
                            i = Convert.ToInt32(drset[0][1]);
                        dr = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID ='" + i + "'");
                        if (dr.Length != 0)
                        {
                            DTP_StartDate1.Value = Convert.ToDateTime(dr[0][3]);
                            DTP_EndDate1.Value = Convert.ToDateTime(dr[0][4]);
                        }
                        if (drset[0][2] != DBNull.Value)
                            i = Convert.ToInt32(drset[0][2]);
                        dr = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID ='" + i + "'");
                        if (dr.Length != 0)
                        {
                            DTP_StartDate2.Value = Convert.ToDateTime(dr[0][3]);
                            DTP_EndDate2.Value = Convert.ToDateTime(dr[0][4]);
                        }
                        if (drset[0][3] != DBNull.Value)
                            i = Convert.ToInt32(drset[0][3]);
                        dr = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID ='" + i + "'");
                        if (dr.Length != 0)
                        {
                            DTP_StartDate3.Value = Convert.ToDateTime(dr[0][3]);
                            DTP_EndDate3.Value = Convert.ToDateTime(dr[0][4]);
                        }
                        if (drset[0][4] != DBNull.Value)
                            i = Convert.ToInt32(drset[0][4]);
                        dr = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID ='" + i + "'");
                        if (dr.Length != 0)
                        {
                            DTP_StartDate4.Value = Convert.ToDateTime(dr[0][3]);
                            DTP_EndDate4.Value = Convert.ToDateTime(dr[0][4]);
                        }
                        if (drset[0][5] != DBNull.Value)
                            i = Convert.ToInt32(drset[0][5]);
                        dr = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID ='" + i + "'");
                        if (dr.Length != 0)
                        {
                            DTP_StartDate5.Value = Convert.ToDateTime(dr[0][3]);
                            DTP_EndDate5.Value = Convert.ToDateTime(dr[0][4]);
                        }
                        if (drset[0][6] != DBNull.Value)
                            i = Convert.ToInt32(drset[0][6]);
                        dr = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID ='" + i + "'");
                        if (dr.Length != 0)
                        {
                            DTP_StartDate6.Value = Convert.ToDateTime(dr[0][3]);
                            DTP_EndDate6.Value = Convert.ToDateTime(dr[0][4]);
                        }
                        if (drset[0][7] != DBNull.Value)
                            i = Convert.ToInt32(drset[0][7]);
                        dr = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID ='" + i + "'");
                        if (dr.Length != 0)
                        {
                            DTP_StartDate7.Value = Convert.ToDateTime(dr[0][3]);
                            DTP_EndDate7.Value = Convert.ToDateTime(dr[0][4]);
                        }
                        if (drset[0][8] != DBNull.Value)
                            i = Convert.ToInt32(drset[0][8]);
                        dr = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID ='" + i + "'");
                        if (dr.Length != 0)
                        {
                            DTP_StartDate8.Value = Convert.ToDateTime(dr[0][3]);
                            DTP_EndDate8.Value = Convert.ToDateTime(dr[0][4]);
                        }
                        if (drset[0][9] != DBNull.Value)
                            i = Convert.ToInt32(drset[0][9]);
                        dr = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID ='" + i + "'");
                        if (dr.Length != 0)
                        {
                            DTP_StartDate9.Value = Convert.ToDateTime(dr[0][3]);
                            DTP_EndDate9.Value = Convert.ToDateTime(dr[0][4]);
                        }
                        if (drset[0][10] != DBNull.Value)
                        i = Convert.ToInt32(drset[0][10]);
                        dr = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID ='" + i + "'");
                        if (dr.Length != 0)
                        {
                            DTP_StartDate10.Value = Convert.ToDateTime(dr[0][3]);
                            DTP_EndDate10.Value = Convert.ToDateTime(dr[0][4]);
                        }
                        if (drset[0][11] != DBNull.Value)
                            i = Convert.ToInt32(drset[0][11]);
                        dr = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID ='" + i + "'");
                        if (dr.Length != 0)
                        {
                            DTP_StartDate11.Value = Convert.ToDateTime(dr[0][3]);
                            DTP_EndDate11.Value = Convert.ToDateTime(dr[0][4]);
                        }
                        if (drset[0][12] != DBNull.Value)
                            i = Convert.ToInt32(drset[0][12]);
                        dr = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID ='" + i + "'");
                        if (dr.Length != 0)
                        {
                            DTP_StartDate12.Value = Convert.ToDateTime(dr[0][3]);
                            DTP_EndDate12.Value = Convert.ToDateTime(dr[0][4]);
                        }                        //ADOcls.myDataRow = ADOcls.myDataRows[0];
                        if (drset[0][13] != DBNull.Value)
                        {
                            i = Convert.ToInt32(drset[0][13]);
                            dr = dbAccountingProjectDS.GLFiscalPeriod.Select("PeriodID ='" + i + "'");
                            if (dr.Length != 0)
                            {
                                labelPeriod13.Visible = true;
                                txt_Period13.Visible = true;
                                DTP_StartDate13.Visible = true;
                                DTP_EndDate13.Visible = true;
                                DTP_StartDate13.Value = Convert.ToDateTime(dr[0][3]);
                                DTP_EndDate13.Value = Convert.ToDateTime(dr[0][4]);
                            }
                        }
                        else
                        {
                            labelPeriod13.Visible = false;
                            txt_Period13.Visible = false;
                            DTP_StartDate13.Visible = false;
                            DTP_EndDate13.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }



        private void btn_new_save_Click(object sender, EventArgs e)
        {
            insertToolStripMenuItem_Click(sender, e);
        }

        private void btn_edit_save_Click(object sender, EventArgs e)
        {
            string msg = GeneralFunctions.CheckLockTables("", "", "", "");
            if (msg != "")
            {
                MessageBox.Show("Can't Open Because Other Form Open By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            GeneralFunctions.LockTables("All", "FiscalPeriodSetupfrm", "", "");
            editToolStripMenuItem_Click(sender, e);
            GeneralFunctions.UnLockTable("All", "FiscalPeriodSetupfrm", "", "");
        }

        private void btn_delete_save_Click(object sender, EventArgs e)
        {
            string msg = GeneralFunctions.CheckLockTables("", "", "", "");
            if (msg != "")
            {
                MessageBox.Show("Can't Open Because Other Form Open By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            GeneralFunctions.LockTables("All", "FiscalPeriodSetupfrm", "", "");
            deleteToolStripMenuItem_Click(sender, e);
            GeneralFunctions.UnLockTable("All", "FiscalPeriodSetupfrm", "", "");

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_FiscalYear_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FiscalPeriodSetupfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralFunctions.UnLockTable("", "FiscalPeriodSetupfrm", "", "");
        }

        private void gLFiscalPeriodSetupDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gLFiscalPeriodSetupDataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}