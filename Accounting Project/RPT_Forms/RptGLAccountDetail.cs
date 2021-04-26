using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Accounting_GeneralLedger.Forms;

namespace Accounting_GeneralLedger
{
    public partial class RptGLAccountDetail : Form
    {
        public RptGLAccountDetail()
        {
            InitializeComponent();
        }
        public static string txtBatchStat = "";
        public static string txtTo = "";
        public static string txtFrom = "";
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbGeneralSetup;
        private SqlDataAdapter adaptertbAccounts;
        private SqlDataAdapter adaptertbGLJournalCodes;
        private DataTable tableAccount;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        private SqlConnection connectReport2;
        private SqlDataReader readerReport2;
        private void button1_Click(object sender, EventArgs e)
        {
            if (ListAvailable.SelectedIndex != -1)
            {
                int I = ListAvailable.SelectedIndex;
                ListSelect.Items.Add(ListAvailable.SelectedItem.ToString());
                ListAvailable.Items.RemoveAt(I);
                ListAvailable.Focus();
                if (ListAvailable.Items.Count > 0)
                {
                    if (I < ListAvailable.Items.Count)
                        ListAvailable.SetSelected(I, true);
                    else
                        ListAvailable.SetSelected(0, true);

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ListSelect.SelectedIndex != -1)
            {
                ListAvailable.Items.Add(ListSelect.SelectedItem.ToString());
                int I = ListSelect.SelectedIndex;
                ListSelect.Items.RemoveAt(I);
                ListSelect.Focus();
                if (ListSelect.Items.Count > 0)
                {
                    if (I < ListSelect.Items.Count)
                        ListSelect.SetSelected(I, true);
                    else
                        ListSelect.SetSelected(0, true);

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ListAvailable.Items.Count > 0)
            {
                ListSelect.Items.AddRange(ListAvailable.Items);
                ListAvailable.Items.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ListSelect.Items.Count > 0)
            {
                ListAvailable.Items.AddRange(ListSelect.Items);
                ListSelect.Items.Clear();
            }
        }

        private void ListSelect_DoubleClick(object sender, EventArgs e)
        {
            button3_Click(sender, e);

        }

        private void ListAvailable_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(sender, e);

        }
        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.GLDetailAccount;
            this.label1.Text = obj_interface_language.lblFrom;
            this.label2.Text = obj_interface_language.lblTo;
          //  this.label5.Text = obj_interface_language.labelAccountNumber;
            this.label3.Text = obj_interface_language.lblAvailable;
            this.label4.Text = obj_interface_language.lblSelect;
            this.groupBox1.Text = obj_interface_language.groupDateRange;
            this.groupBox2.Text = obj_interface_language.groupAccountRange;
            this.groupBox3.Text = obj_interface_language.groupG_LJournals;
            this.groupBox4.Text = obj_interface_language.groupG_LAccountSelection;
            this.btnReport.Text = obj_interface_language.btnReport;
            dgv.Columns["AccountNumber"].HeaderText = obj_interface_language.dgvAccountDefinitionColumn1;
            dgv.Columns["AccountName"].HeaderText = obj_interface_language.dgvAccountDefinitionColumn2;
            dgv.Columns["Select"].HeaderText = obj_interface_language.dgvSelect;

        }
        private void RptGLAccountDetail_Load(object sender, EventArgs e)
        {
            dbAccountingProjectDS = new dbAccountingProjectDS();
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbGLJournalCodes = new SqlDataAdapter("Select * from GLJournalCodes", sqlcon);
            adaptertbGLJournalCodes.Fill(dbAccountingProjectDS.GLJournalCodes);
            if (dbAccountingProjectDS.GLJournalCodes.Rows.Count != 0)
                foreach (DataRow dr in dbAccountingProjectDS.GLJournalCodes.Rows)
                {
                    ListAvailable.Items.Add(dr["JournalDescription"]);
                }
            adaptertbAccounts = new SqlDataAdapter("Select AccountNumber,AccountName from GLAccounts where AccountTypeName <> 'Header'", sqlcon);
            tableAccount = new DataTable();
            adaptertbAccounts.Fill(tableAccount);
            tableAccount.Columns.Add("Select", Type.GetType("System.Boolean"));
            dgv.DataSource = tableAccount;
            int I = dgv.Rows.Count;
            dgv.Columns["AccountNumber"].ReadOnly = true;
            dgv.Columns["AccountName"].ReadOnly = true;
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            {
                txt_AccountNumber1.Mask = dr["AccountNumberFormat"].ToString();
                RptGLdet.decmial = short.Parse(dr["DecimalPointsNumber"].ToString());

            }
            if (GeneralFunctions.languagechioce != "")
            {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }
        }

        private void txt_AccountNumber1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txt_AccountNumber1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tableAccount.Rows.Count > 0)
                {
                    foreach (DataRow dr in tableAccount.Rows)
                    {
                        dr["Select"] = false;
                    }
                }
            }
            catch
            {
            }
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
                txt_AccountNumber1.Text = "";

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (radio_department.Checked) {
                try
                {
                    connectReport2 = new SqlConnection(GeneralFunctions.ConnectionString);
                    SqlCommand commandReport2 = new SqlCommand();



                    connectReport2.Open();
                    int I = 0;
                    string acc = "";
                    acc = txt_AccountNumber1.Text.Replace('-', ' ');
                    acc = acc.Trim();
                    foreach (DataRow dr in tableAccount.Rows)
                    {
                        if (dr["Select"].ToString() == "True")
                            I = I + 1;
                    }
                    if (I == 0 && acc == "")
                    {
                        MessageBox.Show("Choose G/L Account", "General Ledger");
                        return;
                    }

                    if (ListSelect.Items.Count < 1)
                    {
                        MessageBox.Show("Select G/L Journal", "General Ledger");
                        return;
                    }

                    commandReport2 = new SqlCommand();
                    commandReport2.Connection = connectReport2;
                    commandReport2.CommandType = CommandType.Text;


                    commandReport2.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BudgetPlanning]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View RptGLdetail";
                    try
                    {
                        readerReport2 = commandReport2.ExecuteReader();
                        readerReport2.Close();
                    }
                    catch (Exception ex)
                    { }

                    txtFrom = dtp_from.Value.ToShortDateString();
                    txtTo = dtp_to.Value.ToShortDateString();

                    string s2 = "";
                    s2 = "Create View RptGLdetail AS SELECT dbo.GLTransactions.GLAccount, dbo.GLAccounts.AccountName, dbo.GLAccounts.AccountTypeName, dbo.GLAccounts.Active," +
                              "dbo.GLAccounts.OpeningBalance, dbo.GLTransactions.BatchNo, dbo.Batch.BatchDate, dbo.Batch.BatchPRD, dbo.Batch.BatchDSC," +
                              "dbo.Batch.BatchJNL, dbo.Batch.BatchStat, dbo.Batch.PostDate, dbo.GLTransactions.TRANSREF, dbo.GLTransactions.TRANSDATE, " +
                              "dbo.GLTransactions.CurrencyType, dbo.GLTransactions.Rate, dbo.GLTransactions.TRANSUnit, dbo.GLJournalCodes.JournalDescription," +
                              "dbo.Batch.UserID, dbo.Batch.PropertyCode, dbo.GLTransactions.ProjectCode, dbo.GLTransactions.Amount, dbo.GLTransactions.AmountLC," +
                              "dbo.Batch.REVBatchNo, dbo.Batch.REVBatchPRD, dbo.Batch.AllocationCode, dbo.Batch.REVBatch FROM dbo.GLJournalCodes INNER JOIN dbo.GLTransactions INNER JOIN dbo.Batch ON dbo.GLTransactions.BatchNo = dbo.Batch.BatchNo INNER JOIN dbo.GLAccounts ON dbo.GLTransactions.GLAccount = dbo.GLAccounts.AccountNumber ON dbo.GLJournalCodes.JournalCode = dbo.Batch.BatchJNL where dbo.Batch.BatchSRC = 'GL'  AND (dbo.GLTransactions.SortNO <> 0) AND GLTransactions.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, dtp_from.Value.Date) + "' AND '" + string.Format(GeneralFunctions.Format_Date, dtp_to.Value.Date) + "'" + " AND dbo.GLTransactions.DepartmentCode='"+txt_DepartmentCode.Text+"'";

                    if (ListSelect.Items.Count > 0)
                    {
                        s2 = s2 + " AND GLJournalCodes.JournalDescription IN ('";
                        string s = "";
                        foreach (object ob in ListSelect.Items)
                        {
                            s2 = s2 + s + ob.ToString() + "'";
                            s = ",'";
                        }
                        s2 = s2 + ")";
                    }
                    if (acc != "")
                    {
                        acc = txt_AccountNumber1.ToString();
                        acc = acc.Remove(0, 41).Trim();
                        s2 = s2 + " AND GLTransactions.GLAccount like '" + acc + "'";
                    }
                    else if (I > 0)
                    {
                        s2 = s2 + " AND GLTransactions.GLAccount IN ('";
                        string s = "";
                        foreach (DataRow dr in tableAccount.Rows)
                        {
                            if (dr["Select"].ToString() == "True")
                            {
                                s2 = s2 + s + dr["AccountNumber"].ToString() + "'";
                                s = ",'";
                            }
                        }
                        s2 = s2 + ")";
                    }
                    //if (chkrange.Checked == true)
                    //    s2 = s2 + "AND GLTransactions.BatchNo Between '" + int.Parse(txtboxFrom.Text) + "' AND '" + int.Parse(txtboxto.Text) + "'";
                    commandReport2.CommandText = s2;
                    try
                    {
                        readerReport2 = commandReport2.ExecuteReader();
                        readerReport2.Close();
                    }
                    catch (Exception ex)
                    { }
                    RptGLdet rpt = new RptGLdet();
                    rpt.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    connectReport2.Close();
                }

            }
            else {
                try
                {
                    connectReport2 = new SqlConnection(GeneralFunctions.ConnectionString);
                    SqlCommand commandReport2 = new SqlCommand();



                    connectReport2.Open();
                    int I = 0;
                    string acc = "";
                    acc = txt_AccountNumber1.Text.Replace('-', ' ');
                    acc = acc.Trim();
                    foreach (DataRow dr in tableAccount.Rows)
                    {
                        if (dr["Select"].ToString() == "True")
                            I = I + 1;
                    }
                    if (I == 0 && acc == "")
                    {
                        MessageBox.Show("Choose G/L Account", "General Ledger");
                        return;
                    }

                    if (ListSelect.Items.Count < 1)
                    {
                        MessageBox.Show("Select G/L Journal", "General Ledger");
                        return;
                    }

                    commandReport2 = new SqlCommand();
                    commandReport2.Connection = connectReport2;
                    commandReport2.CommandType = CommandType.Text;


                    commandReport2.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BudgetPlanning]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View RptGLdetail";
                    try
                    {
                        readerReport2 = commandReport2.ExecuteReader();
                        readerReport2.Close();
                    }
                    catch (Exception ex)
                    { }

                    txtFrom = dtp_from.Value.ToShortDateString();
                    txtTo = dtp_to.Value.ToShortDateString();

                    string s2 = "";
                    s2 = "Create View RptGLdetail AS SELECT     dbo.GLTransactions.GLAccount, dbo.GLAccounts.AccountName, dbo.GLAccounts.AccountTypeName, dbo.GLAccounts.Active," +
                              "dbo.GLAccounts.OpeningBalance, dbo.GLTransactions.BatchNo, dbo.Batch.BatchDate, dbo.Batch.BatchPRD, dbo.Batch.BatchDSC," +
                              "dbo.Batch.BatchJNL, dbo.Batch.BatchStat, dbo.Batch.PostDate, dbo.GLTransactions.TRANSREF, dbo.GLTransactions.TRANSDATE, " +
                              "dbo.GLTransactions.CurrencyType, dbo.GLTransactions.Rate, dbo.GLTransactions.TRANSUnit, dbo.GLJournalCodes.JournalDescription," +
                              "dbo.Batch.UserID, dbo.Batch.PropertyCode, dbo.GLTransactions.ProjectCode, dbo.GLTransactions.Amount, dbo.GLTransactions.AmountLC," +
                              "dbo.Batch.REVBatchNo, dbo.Batch.REVBatchPRD, dbo.Batch.AllocationCode, dbo.Batch.REVBatch FROM dbo.GLJournalCodes INNER JOIN dbo.GLTransactions INNER JOIN dbo.Batch ON dbo.GLTransactions.BatchNo = dbo.Batch.BatchNo INNER JOIN dbo.GLAccounts ON dbo.GLTransactions.GLAccount = dbo.GLAccounts.AccountNumber ON dbo.GLJournalCodes.JournalCode = dbo.Batch.BatchJNL where dbo.Batch.BatchSRC = 'GL'  AND (dbo.GLTransactions.SortNO <> 0) AND GLTransactions.TRANSDATE Between '" + string.Format(GeneralFunctions.Format_Date, dtp_from.Value.Date) + "' AND '" + string.Format(GeneralFunctions.Format_Date, dtp_to.Value.Date) + "'";

                    if (ListSelect.Items.Count > 0)
                    {
                        s2 = s2 + " AND GLJournalCodes.JournalDescription IN ('";
                        string s = "";
                        foreach (object ob in ListSelect.Items)
                        {
                            s2 = s2 + s + ob.ToString() + "'";
                            s = ",'";
                        }
                        s2 = s2 + ")";
                    }
                    if (acc != "")
                    {
                        acc = txt_AccountNumber1.ToString();
                        acc = acc.Remove(0, 41).Trim();
                        s2 = s2 + " AND GLTransactions.GLAccount like '" + acc + "'";
                    }
                    else if (I > 0)
                    {
                        s2 = s2 + " AND GLTransactions.GLAccount IN ('";
                        string s = "";
                        foreach (DataRow dr in tableAccount.Rows)
                        {
                            if (dr["Select"].ToString() == "True")
                            {
                                s2 = s2 + s + dr["AccountNumber"].ToString() + "'";
                                s = ",'";
                            }
                        }
                        s2 = s2 + ")";
                    }
                    //if (chkrange.Checked == true)
                    //    s2 = s2 + "AND GLTransactions.BatchNo Between '" + int.Parse(txtboxFrom.Text) + "' AND '" + int.Parse(txtboxto.Text) + "'";
                    commandReport2.CommandText = s2;
                    try
                    {
                        readerReport2 = commandReport2.ExecuteReader();
                        readerReport2.Close();
                    }
                    catch (Exception ex)
                    { }
                    RptGLdet rpt = new RptGLdet();
                    rpt.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    connectReport2.Close();
                }
            }
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            DepartmentsLoad dpld = new DepartmentsLoad();
            //var val=

            var val = dpld.ShowDialog();

            if (val == DialogResult.OK)
            {
                txt_DepartmentCode.Text = dpld.ReturnValue1;
            }
        }
    }
}