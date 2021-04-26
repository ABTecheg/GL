using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace Accounting_GeneralLedger
{
    public partial class ViewGLAcc : Form
    {
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbAccounts;
        private SqlDataAdapter adaptertbGeneralSetup;
        private SqlDataAdapter adaptertbGLTotals;
        private SqlDataAdapter adaptertbGLBudget;
        private SqlDataAdapter adaptertbFiscalPeriod;
        private SqlDataAdapter adaptertbFiscalPeriodsetup;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private DataTable DTTran;
        private DataTable dsView;
        public ViewGLAcc()
        {
            InitializeComponent();
        }

        private void ViewGLAcc_Load(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            dbAccountingProjectDS = new dbAccountingProjectDS();
            adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts", sqlcon);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbFiscalPeriod = new SqlDataAdapter("Select * from GLFiscalPeriod", sqlcon);
            adaptertbFiscalPeriodsetup = new SqlDataAdapter("Select * from GLFiscalPeriodSetup", sqlcon);
            adaptertbGLTotals = new SqlDataAdapter("Select * from GLTotals", sqlcon);
            adaptertbGLTotals.Fill(dbAccountingProjectDS.GLTotals);
            adaptertbGLBudget = new SqlDataAdapter("Select * from GLBudget", sqlcon);
            adaptertbGLBudget.Fill(dbAccountingProjectDS.GLBudget);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
            adaptertbFiscalPeriod.Fill(dbAccountingProjectDS.GLFiscalPeriod);
            adaptertbFiscalPeriodsetup.Fill(dbAccountingProjectDS.GLFiscalPeriodSetup);
            foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            {
                //txt_AccountNumber.Mask = dr["AccountNumberFormat"].ToString();
                txt_AccountNumber.Mask = "";
            }
            DTTran = new DataTable();
            DTTran.Columns.Add("Date", System.Type.GetType("System.String"));
            DTTran.Columns.Add("Batch_Date", System.Type.GetType("System.String"));
            DTTran.Columns.Add("Reference", System.Type.GetType("System.String"));
            DTTran.Columns.Add("Debit", System.Type.GetType("System.String"));
            DTTran.Columns.Add("Credit", System.Type.GetType("System.String"));
            DTTran.Columns.Add("Units", System.Type.GetType("System.String"));
            DTTran.Columns.Add("Journal", System.Type.GetType("System.String"));
            DTTran.Columns.Add("Src", System.Type.GetType("System.String"));
            DTTran.Columns.Add("User", System.Type.GetType("System.String"));

            fillperiod();
            fillYear();
            dgvtotal.Rows.Add(new object[] { "BeginningBalance", "", "0", "", "", "0" });
            dgvtotal.Rows.Add(new object[] { "Period 1", "0", "0", "0", "0", "0" });
            dgvtotal.Rows.Add(new object[] { "Period 2", "0", "0", "0", "0", "0" });
            dgvtotal.Rows.Add(new object[] { "Period 3", "0", "0", "0", "0", "0" });
            dgvtotal.Rows.Add(new object[] { "Period 4", "0", "0", "0", "0", "0" });
            dgvtotal.Rows.Add(new object[] { "Period 5", "0", "0", "0", "0", "0" });
            dgvtotal.Rows.Add(new object[] { "Period 6", "0", "0", "0", "0", "0" });
            dgvtotal.Rows.Add(new object[] { "Period 7", "0", "0", "0", "0", "0" });
            dgvtotal.Rows.Add(new object[] { "Period 8", "0", "0", "0", "0", "0" });
            dgvtotal.Rows.Add(new object[] { "Period 9", "0", "0", "0", "0", "0" });
            dgvtotal.Rows.Add(new object[] { "Period 10", "0", "0", "0", "0", "0" });
            dgvtotal.Rows.Add(new object[] { "Period 11", "0", "0", "0", "0", "0" });
            dgvtotal.Rows.Add(new object[] { "Period 12", "0", "0", "0", "0", "0" });
            dgvtotal.Rows.Add(new object[] { "Period 13", "0", "0", "0", "0", "0" });
            dgvtotal.Rows.Add(new object[] { "Year End Adjustments", "0", "0", "", "0", "0" });
            dgvtotal.Rows.Add(new object[] { "EnddningBalance", "0", "0", "", "0", "0" });
        }
        private void findAcc()
        {
            SqlConnection connectReport2 = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand commandReport2 = new SqlCommand();
            SqlDataReader readerReport2;
            SqlDataAdapter adapView;


            connectReport2.Open();

            commandReport2 = new SqlCommand();
            commandReport2.Connection = connectReport2;
            commandReport2.CommandType = CommandType.Text;

            string acc = txt_AccountNumber.ToString();
            acc = acc.Remove(0, 41).Trim();
            DataRow[] drs = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + acc + "'");
            if (drs.Length != 0)
            {
                commandReport2.CommandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BudgetPlanning]') and OBJECTPROPERTY(id, N'IsView') = 1) Drop View ViewGLAcc";
                try
                {
                    readerReport2 = commandReport2.ExecuteReader();
                    readerReport2.Close();
                }
                catch (Exception ex)
                { }

                string s2 = "";
                s2 = "Create View ViewGLAcc AS SELECT TOP 100 PERCENT dbo.GLTransactions.TRANSDATE, dbo.Batch.BatchDate, dbo.GLTransactions.TRANSREF, dbo.GLTransactions.AmountLC, dbo.GLTransactions.TRANSUnit, dbo.Batch.BatchJNL, dbo.Batch.BatchSRC, dbo.Users.UserName FROM dbo.Batch INNER JOIN dbo.GLTransactions ON dbo.Batch.BatchNo = dbo.GLTransactions.BatchNo INNER JOIN dbo.Users ON dbo.Batch.UserID = dbo.Users.UserID WHERE (dbo.Batch.BatchStat = 'P') And dbo.GLTransactions.GLAccount like '" + acc + "'";
                if (cb_period.Text != "All")
                {
                    string prd = cb_period.Text.Substring(0, cb_period.Text.IndexOf('/'));
                    int Y = int.Parse(cb_period.Text.Substring(cb_period.Text.IndexOf('/') + 1));
                    s2 = s2 + " and dbo.Batch.BatchPRD = '" + prd + "' and Year(dbo.Batch.BatchDate) = " + Y + " ORDER BY dbo.GLTransactions.TRANSDATE";

                }
                else
                    s2 = s2 + " ORDER BY dbo.GLTransactions.TRANSDATE";


                commandReport2.CommandText = s2;
                readerReport2 = commandReport2.ExecuteReader();
                readerReport2.Close();
            }
            else
                MessageBox.Show("This Number Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            connectReport2.Close();

            connectReport2.Open();
            adapView = new SqlDataAdapter("Select * From ViewGLAcc", connectReport2);

            dsView = new DataTable();
            dsView.Clear();
            try
            {
                adapView.Fill(dsView);
                fillDTtran();
                dgvtran.DataSource = DTTran;
                dgvtran.Refresh();
                connectReport2.Close();
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
                connectReport2.Close();
            }
            AccTotal(acc);
            AccTotalBudget(acc);
            if (cb_year.SelectedIndex != 0)
                AccTotallast(acc);
            else
            {
                dgvtotal.Rows[0].Cells[4].Value = "";
                dgvtotal.Rows[0].Cells[5].Value = "0";
                for (int i = 1; i < 16; i++)
                {
                    dgvtotal.Rows[i].Cells[4].Value = "0";
                    dgvtotal.Rows[i].Cells[5].Value = "0";
                }
            }
        }
        private void fillDTtran()
        {
            DataRow r;
            double d;
            for (int i = DTTran.Rows.Count; i > 0; i--)
            {
                DTTran.Rows[i - 1].Delete();
            }

            if (dsView.Rows.Count != 0)
            {
                for (int i = 0; i < dsView.Rows.Count; i++)
                {
                    r = DTTran.NewRow();
                    r["Date"] = Convert.ToDateTime(dsView.Rows[i]["TRANSDATE"].ToString()).ToShortDateString();
                    r["Batch_Date"] = Convert.ToDateTime(dsView.Rows[i]["BatchDate"].ToString()).ToShortDateString();
                    r["Reference"] = dsView.Rows[i]["TRANSREF"].ToString();
                    r["Units"] = dsView.Rows[i]["TRANSUnit"].ToString();
                    r["Journal"] = dsView.Rows[i]["BatchJNL"].ToString();
                    r["Src"] = dsView.Rows[i]["BatchSRC"].ToString();
                    r["User"] = dsView.Rows[i]["UserName"].ToString();
                    d = double.Parse(dsView.Rows[i]["AmountLC"].ToString());
                    if (d < 0)
                    {
                        r["Debit"] = "0";
                        d = -1 * d;
                        r["Credit"] = d.ToString();
                    }
                    else
                    {
                        r["Debit"] = d.ToString();
                        r["Credit"] = "0";
                    }

                    DTTran.Rows.Add(r);
                }

            }
        }
        private void fillperiod()
        {
            DateTime DP;
            DataRow[] drs = dbAccountingProjectDS.GLFiscalPeriod.Select();
            if (drs.Length != 0)
            {
                cb_period.Items.Clear();
                cb_period.Items.Add("All");
                for (int i = 0; i < drs.Length; i++)
                {
                    DP = Convert.ToDateTime(drs[i]["PeriodStartDate"].ToString());
                    cb_period.Items.Add(drs[i]["PeriodDescription"].ToString() + "/" + DP.Year.ToString());
                }
                cb_period.SelectedIndex = 0;
            }
        }

        private void fillYear()
        {
            DataRow[] drs = dbAccountingProjectDS.GLFiscalPeriodSetup.Select();
            if (drs.Length != 0)
            {
                cb_year.Items.Clear();
                for (int i = 0; i < drs.Length; i++)
                {
                    cb_year.Items.Add(drs[i]["FiscalYear"].ToString());
                }
                cb_year.SelectedIndex = 0;
            }
        }

        private void txt_AccountNumber_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txt_AccountNumber_DoubleClick(object sender, EventArgs e)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.filter = " AND AccountTypeName <> 'Header'";
            accSearch.ShowDialog();
            if (accSearch.selectedAccountName != null && accSearch.selectedAccountNumber != null && accSearch.selectedAccountType != null && accSearch.selectedAccountType != "Header")
            {
                txt_AccountNumber.Text = accSearch.selectedAccountNumber;
                findAcc();
            }
        }

        private void cb_period_SelectedIndexChanged(object sender, EventArgs e)
        {
            string acc = txt_AccountNumber.ToString();
            acc = acc.Remove(0, 41).Trim();
            acc = acc.Replace('-', ' ');
            acc = acc.Replace('%', ' ');
            if (acc.Trim() != "")
                findAcc();
        }

        private bool CheckPeriod(int prd, int Year)
        {
            bool flage = false;
            string stats = "";
            SqlConnection mycon = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand mycom = new SqlCommand("select Status from GLFiscalPeriod where PeriodNumber = '" + prd + "' and Year(PeriodStartDate) = " + Year + "", mycon);
            mycon.Open();
            stats = mycom.ExecuteScalar().ToString();
            if (stats == "CLOSED")
                flage = true;
            mycon.Close();
            return flage;
        }
        private double CurrentBalanceAccount(string prdbalance, string ApAccount, int prd)
        {
            double CurrentBalance = 0;
            DataRow[] rArr = this.dbAccountingProjectDS.GLTotals.Select("AccountNumber ='" + ApAccount + "' AND FiscalYear = '" + prd + "'");
            if (rArr.Length != 0)
            {
                CurrentBalance = double.Parse(rArr[0][prdbalance].ToString());
            }
            return CurrentBalance;
        }
        private double CurrentBudgetAccount(string prdbalance, string ApAccount, int prd)
        {
            double CurrentBalance = 0;
            DataRow[] rArr = this.dbAccountingProjectDS.GLBudget.Select("AccountNumber ='" + ApAccount + "' AND FiscalYear = '" + prd + "'");
            if (rArr.Length != 0)
            {
                CurrentBalance = double.Parse(rArr[0][prdbalance].ToString());
            }
            return CurrentBalance;
        }

        private void AccTotal(string Acc)
        {
            double val = 0;
            double net = 0;
            int StartYear = 0;
            if (cb_year.Text == "")
                return;
            else
                StartYear = int.Parse(cb_year.Text);
            dgvtotal.Rows[0].Cells[2].Value = CurrentBalanceAccount("BeginningBalance", Acc, StartYear);
            dgvtotal.Rows[1].Cells[2].Value = CurrentBalanceAccount("PeriodBalance1", Acc, StartYear);
            dgvtotal.Rows[1].Cells[1].Value = CurrentBalanceAccount("PeriodBalance1", Acc, StartYear) - CurrentBalanceAccount("BeginningBalance", Acc, StartYear);
            net += CurrentBalanceAccount("PeriodBalance1", Acc, StartYear) - CurrentBalanceAccount("BeginningBalance", Acc, StartYear);
            val = CurrentBalanceAccount("PeriodBalance1", Acc, StartYear);
            for (int i = 2; i <= 13; i++)
            {
                if (CheckPeriod(i - 1, StartYear))
                {
                    //dgvtotal.Rows[i - 1].Cells[1].Style.BackColor = Color.RoyalBlue;
                    //dgvtotal.Rows[i - 1].Cells[2].Style.BackColor = Color.RoyalBlue;
                    dgvtotal.Rows[i].Cells[2].Value = CurrentBalanceAccount("PeriodBalance" + i.ToString(), Acc, StartYear);
                    dgvtotal.Rows[i].Cells[1].Value = CurrentBalanceAccount("PeriodBalance" + i.ToString(), Acc, StartYear) - CurrentBalanceAccount("PeriodBalance" + Convert.ToString(i - 1), Acc, StartYear);
                    net += CurrentBalanceAccount("PeriodBalance" + i.ToString(), Acc, StartYear) - CurrentBalanceAccount("PeriodBalance" + Convert.ToString(i - 1), Acc, StartYear);
                    val = CurrentBalanceAccount("PeriodBalance" + i.ToString(), Acc, StartYear);
                }
                else
                {
                    //dgvtotal.Rows[i - 1].Cells[1].Style.BackColor = Color.GreenYellow;
                    //dgvtotal.Rows[i - 1].Cells[2].Style.BackColor = Color.GreenYellow;
                    val += CurrentBalanceAccount("PeriodBalance" + i.ToString(), Acc, StartYear);
                    dgvtotal.Rows[i].Cells[1].Value = CurrentBalanceAccount("PeriodBalance" + i.ToString(), Acc, StartYear);
                    net += CurrentBalanceAccount("PeriodBalance" + i.ToString(), Acc, StartYear);
                    dgvtotal.Rows[i].Cells[2].Value = val;
                }
            }
            if (CheckPeriod(12, StartYear))
            {
                dgvtotal.Rows[14].Cells[2].Value = CurrentBalanceAccount("PeriodBalance99", Acc, StartYear);
                dgvtotal.Rows[14].Cells[1].Value = CurrentBalanceAccount("PeriodBalance99", Acc, StartYear) - CurrentBalanceAccount("PeriodBalance12", Acc, StartYear);
                net += CurrentBalanceAccount("PeriodBalance99", Acc, StartYear) - CurrentBalanceAccount("PeriodBalance12", Acc, StartYear);
            }
            else
            {
                val += CurrentBalanceAccount("PeriodBalance99", Acc, StartYear);
                dgvtotal.Rows[14].Cells[1].Value = CurrentBalanceAccount("PeriodBalance99", Acc, StartYear);
                net += CurrentBalanceAccount("PeriodBalance99", Acc, StartYear);
                dgvtotal.Rows[14].Cells[2].Value = val;
            }
            dgvtotal.Rows[15].Cells[1].Value = net;
            dgvtotal.Rows[15].Cells[2].Value = val;
        }
        private void AccTotallast(string Acc)
        {
            double val = 0;
            double net = 0;
            int StartYear = 0;
            if (cb_year.Text == "")
                return;
            else
                StartYear = int.Parse(cb_year.Text) - 1;
            dgvtotal.Rows[0].Cells[5].Value = CurrentBalanceAccount("BeginningBalance", Acc, StartYear);
            dgvtotal.Rows[1].Cells[5].Value = CurrentBalanceAccount("PeriodBalance1", Acc, StartYear);
            dgvtotal.Rows[1].Cells[4].Value = CurrentBalanceAccount("PeriodBalance1", Acc, StartYear) - CurrentBalanceAccount("BeginningBalance", Acc, StartYear);
            net += CurrentBalanceAccount("PeriodBalance1", Acc, StartYear) - CurrentBalanceAccount("BeginningBalance", Acc, StartYear);
            val = CurrentBalanceAccount("PeriodBalance1", Acc, StartYear);
            for (int i = 2; i <= 13; i++)
            {
                if (CheckPeriod(i - 1, StartYear))
                {
                    dgvtotal.Rows[i].Cells[5].Value = CurrentBalanceAccount("PeriodBalance" + i.ToString(), Acc, StartYear);
                    dgvtotal.Rows[i].Cells[4].Value = CurrentBalanceAccount("PeriodBalance" + i.ToString(), Acc, StartYear) - CurrentBalanceAccount("PeriodBalance" + Convert.ToString(i - 1), Acc, StartYear);
                    net += CurrentBalanceAccount("PeriodBalance" + i.ToString(), Acc, StartYear) - CurrentBalanceAccount("PeriodBalance" + Convert.ToString(i - 1), Acc, StartYear);
                }
                else
                {
                    val += CurrentBalanceAccount("PeriodBalance" + i.ToString(), Acc, StartYear);
                    dgvtotal.Rows[i].Cells[4].Value = CurrentBalanceAccount("PeriodBalance" + i.ToString(), Acc, StartYear);
                    net += CurrentBalanceAccount("PeriodBalance" + i.ToString(), Acc, StartYear);
                    dgvtotal.Rows[i].Cells[5].Value = val;
                }
            }
            if (CheckPeriod(12, StartYear))
            {
                dgvtotal.Rows[14].Cells[5].Value = CurrentBalanceAccount("PeriodBalance99", Acc, StartYear);
                dgvtotal.Rows[14].Cells[4].Value = CurrentBalanceAccount("PeriodBalance99", Acc, StartYear) - CurrentBalanceAccount("PeriodBalance12", Acc, StartYear);
                net += CurrentBalanceAccount("PeriodBalance99", Acc, StartYear) - CurrentBalanceAccount("PeriodBalance12", Acc, StartYear);
            }
            else
            {
                val += CurrentBalanceAccount("PeriodBalance99", Acc, StartYear);
                dgvtotal.Rows[14].Cells[4].Value = CurrentBalanceAccount("PeriodBalance99", Acc, StartYear);
                net += CurrentBalanceAccount("PeriodBalance99", Acc, StartYear);
                dgvtotal.Rows[14].Cells[5].Value = val;
            }
            dgvtotal.Rows[15].Cells[4].Value = net;
            dgvtotal.Rows[15].Cells[5].Value = val;
        }
        private void cb_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            string acc = txt_AccountNumber.ToString();
            acc = acc.Remove(0, 41).Trim();
            acc = acc.Replace('-', ' ');
            acc = acc.Replace('%', ' ');
            if (acc.Trim() != "")
                findAcc();

        }
        private void AccTotalBudget(string Acc)
        {
            int StartYear = 0;
            if (cb_year.Text == "")
                return;
            else
                StartYear = int.Parse(cb_year.Text);
            dgvtotal.Rows[1].Cells[3].Value = CurrentBudgetAccount("Period1", Acc, StartYear);
            for (int i = 2; i <= 13; i++)
            {
                dgvtotal.Rows[i].Cells[3].Value = CurrentBudgetAccount("Period" + i.ToString(), Acc, StartYear);
            }
            //dgvtotal.Rows[14].Cells[3].Value = CurrentBudgetAccount("Period99", Acc, StartYear);
        }


        private void tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab.SelectedIndex == 0)
            {
                label1.Visible = false;
                cb_year.Visible = false;
                label13.Visible = true;
                cb_period.Visible = true;
            }
            else if (tab.SelectedIndex == 1)
            {
                label1.Visible = true;
                cb_year.Visible = true;
                label13.Visible = false;
                cb_period.Visible = false;
            }
        }

        private void txt_AccountNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                if (txt_AccountNumber.MaskFull)
                    findAcc();
                else
                    MessageBox.Show("Please Completed Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void dgvtran_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}