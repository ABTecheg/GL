using System; using Accounting_GeneralLedger.Report;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Accounting_GeneralLedger
{
    public static class BalanceSheet
    {
        private static SqlConnection sqlcon;
        private static SqlDataAdapter adapterBalanceSheet;
        private static SqlDataAdapter adapteraccount;
        private static SqlDataAdapter adaptertbGLTotals;
        private static SqlDataAdapter adaptertChart;
        private static SqlCommandBuilder commbChart;
        private static SqlCommandBuilder commbBalanceSheet;
        private static SqlCommandBuilder commbaccount;
        private static SqlCommandBuilder commbGLTotals;
        private static dbAccountingProjectDS dbAccountingProjectDS;
        private static DataRow r;
        private static DataRow[] rsb;
        private static DataRow[] rst;
        private static DataRow[] rs;
        private static string listorder;
        private static string totalorder;
        private static string acc;
        private static int n, ID;
        private static double valbalance;
        private static string periodbalance;
        public static void FillBalanceSheet(DateTime DatePeriod,string Lang)
        {
            SqlConnection sqlconndelete = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconndelete.Open();
            SqlCommand sqlcommandDeletetran = new SqlCommand("Delete From BalanceSheet", sqlconndelete);
            SqlDataReader drDeletetran = sqlcommandDeletetran.ExecuteReader();
            drDeletetran.Close();
            sqlconndelete.Close();
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            dbAccountingProjectDS = new dbAccountingProjectDS();
            adaptertChart = new SqlDataAdapter("Select * from GLAccountsChart", sqlcon);
            adapterBalanceSheet = new SqlDataAdapter("Select * from BalanceSheet", sqlcon);
            adapteraccount = new SqlDataAdapter("Select * from GLAccounts", sqlcon);
            adaptertbGLTotals = new SqlDataAdapter("Select * from GLTotals", sqlcon);
            commbChart = new SqlCommandBuilder(adaptertChart);
            commbBalanceSheet = new SqlCommandBuilder(adapterBalanceSheet);
            commbaccount = new SqlCommandBuilder(adapteraccount);
            commbGLTotals = new SqlCommandBuilder(adaptertbGLTotals);
            adaptertChart.Fill(dbAccountingProjectDS.GLAccountsChart);
            adapteraccount.Fill(dbAccountingProjectDS.GLAccounts);
            adaptertbGLTotals.Fill(dbAccountingProjectDS.GLTotals);
            adapterBalanceSheet.Fill(dbAccountingProjectDS.BalanceSheet);
            periodbalance = FindPeriod(DatePeriod);
            if (dbAccountingProjectDS.GLAccounts.Rows.Count > 0)
            {
               // ID = 1;
              //  ID = dbAccountingProjectDS.BalanceSheet.Count + 1;
                for (int i = 0; i < dbAccountingProjectDS.GLAccounts.Rows.Count; i++)
                {
                    if (dbAccountingProjectDS.GLAccounts.Rows[i]["AccountTypeName"].ToString() == "Assets" || dbAccountingProjectDS.GLAccounts.Rows[i]["AccountTypeName"].ToString() == "Liability" || dbAccountingProjectDS.GLAccounts.Rows[i]["AccountTypeName"].ToString() == "Equity"|| dbAccountingProjectDS.GLAccounts.Rows[i]["AccountTypeName"].ToString().Contains("iabil"))
                    {
                        //SqlConnection sqlconndelete = new SqlConnection(GeneralFunctions.ConnectionString);
                        //sqlconndelete.Open();

                        //SqlCommand sqlcommandDeletetran = new SqlCommand(string.Format("select * from BalanceSheet where AccountNumber ={0}", dbAccountingProjectDS.GLAccounts.Rows[i]["AccountNumber"].ToString()), sqlconndelete);
                        //SqlDataReader drDeletetran = sqlcommandDeletetran.ExecuteReader();
                        //bool x = false;
                        //if (drDeletetran.HasRows)
                        //{
                        //    x = true;
                        //}
                        //else { x = false; }

                        //drDeletetran.Close();
                        //sqlconndelete.Close();
                     bool x = false;
                        if (x==false)
                        {
                            acc = dbAccountingProjectDS.GLAccounts.Rows[i]["AccountNumber"].ToString();
                            rs = dbAccountingProjectDS.GLAccountsChart.Select("AccountNumber = '" + acc + "'");
                            rsb = dbAccountingProjectDS.GLTotals.Select("AccountNumber = '" + acc + "' AND FiscalYear = " + DatePeriod.Year + "");
                            if (rsb.Length != 0 && periodbalance != "")
                                valbalance = double.Parse(rsb[0][periodbalance].ToString());
                            else
                                valbalance = 0;

                            if (rs.Length != 0 && rs[0]["TreeRowParent"].ToString()== "Personal Accounts Ramy Harby")
                            {
                                r = dbAccountingProjectDS.BalanceSheet.NewRow();
                                r["ID"] = ID;
                                ID++;
                                r["AccountNumber"] = acc;
                                if (Lang == "AR")
                                    r["AccountName"] = dbAccountingProjectDS.GLAccounts.Rows[i]["AccountNameArabic"].ToString();
                                else
                                    r["AccountName"] = dbAccountingProjectDS.GLAccounts.Rows[i]["AccountName"].ToString();
                                r["AccountType"] = dbAccountingProjectDS.GLAccounts.Rows[i]["AccountTypeName"].ToString();
                                if (dbAccountingProjectDS.GLAccounts.Rows[i]["AccountTypeName"].ToString() == "Assets")
                                    r["Debit"] =  valbalance;
                                else
                                    r["Credit"] = valbalance;
                                totalorder = rs[0]["ListOrder"].ToString();
                                if (totalorder != "")
                                {
                                    string[] ns;
                                    string[] sp = new string[1];
                                    sp[0] = "-";
                                    listorder = totalorder.Remove(0, 2);
                                    ns = listorder.Split(sp, StringSplitOptions.None);
                                    listorder = "0";
                                    for (int m = 0; m < ns.Length - 1; m++)
                                    {
                                        listorder = listorder + "-" + ns[m];
                                        n = m + 1;
                                        rst = dbAccountingProjectDS.GLAccountsChart.Select("ListOrder = '" + listorder + "'");
                                        if (rst.Length != 0)
                                        {
                                            if (Lang == "AR")
                                            {
                                                string ARN = FindArabicName(rst[0]["AccountNumber"].ToString());
                                                if (ARN != "")
                                                    r["g" + n.ToString()] = ARN;
                                                else
                                                    r["g" + n.ToString()] = rst[0]["TreeRowName"].ToString();
                                            }
                                            else
                                                r["g" + n.ToString()] = rst[0]["TreeRowName"].ToString();

                                        }
                                    }
                                }
                                dbAccountingProjectDS.BalanceSheet.Rows.Add(r);
                            }
                        }
                    }
                }
                for (int q = 1; q <= 9; q++)
                {
                    HideField("g" + q.ToString());
                }
                    update();
            }
        }
        private static string FindArabicName(string EN)
        {
            string ARName = "";
            DataRow[] dracc = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + EN + "'");
            if (dracc.Length != 0)
            {
                ARName = dracc[0]["AccountNameArabic"].ToString();
            }
            return ARName;
        }
        private static void update()
        {
            adaptertChart.Update(dbAccountingProjectDS.GLAccountsChart);
            adapteraccount.Update(dbAccountingProjectDS.GLAccounts);
            adaptertbGLTotals.Update(dbAccountingProjectDS.GLTotals);
            adapterBalanceSheet.Update(dbAccountingProjectDS.BalanceSheet);
            dbAccountingProjectDS.AcceptChanges();
        }
        private static string FindPeriod(DateTime prd)
        {
            int periodNamber;
            int prid;
            string prdbalance = "";
            if (GeneralFunctions.RetrievePeriod(string.Format(GeneralFunctions.Format_Date, prd.Date), out prid, out periodNamber))
                prdbalance = "PeriodBalance" + periodNamber.ToString().Trim();
            else
                MessageBox.Show("The period has been defined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return prdbalance;
        }
        private static void HideField(string ST)
        {
            if (dbAccountingProjectDS.BalanceSheet.Rows.Count != 0)
            {
                int h = 0;
                for (int f = 0; f < dbAccountingProjectDS.BalanceSheet.Rows.Count; f++)
                {
                    if (dbAccountingProjectDS.BalanceSheet.Rows[f][ST].ToString() != "" && dbAccountingProjectDS.BalanceSheet.Rows[f][ST].ToString() != null)
                    {
                        h++;
                        break;
                    }
                }
                if (h == 0)
                {
                    dbAccountingProjectDS.BalanceSheet.Rows[0][ST] = "Hide";
                    if (ST == "g1")
                        RptBalanceSheet.g1 = "Hide";
                    if (ST == "g2")
                        RptBalanceSheet.g2 = "Hide";
                    if (ST == "g3")
                        RptBalanceSheet.g3 = "Hide";
                    if (ST == "g4")
                        RptBalanceSheet.g4 = "Hide";
                    if (ST == "g5")
                        RptBalanceSheet.g5 = "Hide";
                    if (ST == "g6")
                        RptBalanceSheet.g6 = "Hide";
                    if (ST == "g7")
                        RptBalanceSheet.g7 = "Hide";
                    if (ST == "g8")
                        RptBalanceSheet.g8 = "Hide";
                    if (ST == "g9")
                        RptBalanceSheet.g9 = "Hide";

                }
            }
        }

    }
}
