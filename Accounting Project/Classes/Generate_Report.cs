using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Threading;

namespace Accounting_GeneralLedger
{
    public class Generate_Report
    {
        public Thread RunReport(string Rpt_Code, string Rpt_Name, int Rpt_Year, int Rpt_Prd)
        {
            Thread Pro = new Thread(new ParameterizedThreadStart(Run_Report));
            Pro.Start(Rpt_Code + "##" + Rpt_Name + "##" + Rpt_Year.ToString() + "##" + Rpt_Prd.ToString());
            return Pro;
        }
        private void Run_Report(object Rpt_Code_Rpt_Name_Rpt_Year_Rpt_Prd)
        {
            System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            try
            {
                string[] Shet = Rpt_Code_Rpt_Name_Rpt_Year_Rpt_Prd.ToString().Split((new string[] { "##" }), StringSplitOptions.None);

                string Rpt_Code = Shet[0];
                string Rpt_Name = Shet[1];
                int Rpt_Year = int.Parse(Shet[2]);
                int Rpt_Prd = int.Parse(Shet[3]);


                DataTable dtCols = DataClass.RetrieveData("SELECT GRCT.Col_No, GRCT.Col_Type, GRCT.Col_Source, GRCT.Col_Range, GRCT.Col_Period, GRCT.Col_Header, GRCT.Col_Calc_Formula, GRCT.Col_Prec_Source,  GRCT.Col_Width, GRCT.Col_Sup, GRCT.Col_Calc_Divide, GR.Daily_Rev FROM dbo.G_Report AS GR LEFT OUTER JOIN dbo.G_Report_Col_Det AS GRCT ON GR.Col_Code = GRCT.Col_Code WHERE (GR.Rpt_Code = N'" + Rpt_Code + "')");
                DataTable dtRows = DataClass.RetrieveData("SELECT GRCT.Row_No, GRCT.Row_Type, GRCT.Row_Accounts, GRCT.Row_Divide_By_Acc, GRCT.Row_Desc, GRCT.Row_TOT_Formula, GRCT.Row_Prec_Row,  GRCT.Row_Rev, GRCT.Row_Sup, GRCT.Row_Format, GRCT.Row_Divide_By_Amt, GR.Daily_Rev FROM dbo.G_Report_Row_Det AS GRCT RIGHT OUTER JOIN dbo.G_Report AS GR ON GRCT.Row_Code = GR.Row_Code WHERE (GR.Rpt_Code = N'" + Rpt_Code + "')");

                Microsoft.Office.Interop.Excel.ApplicationClass myexl = new Microsoft.Office.Interop.Excel.ApplicationClass();
                Microsoft.Office.Interop.Excel.Workbook mywb = myexl.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel.Sheets mysh = mywb.Sheets;
                string currentSheet = "Sheet1";
                Microsoft.Office.Interop.Excel.Worksheet mywsh = (Microsoft.Office.Interop.Excel.Worksheet)mysh.get_Item(currentSheet);
                mywsh.Name = Rpt_Name;
                string letter = GetLetter(dtCols.Rows.Count);
                Microsoft.Office.Interop.Excel.Range rr = mywsh.get_Range("A1", "A1");
                ////for (int c = 0; c < DT.Columns.Count; c++)
                ////{
                ////    rr[1, c + 1] = DT.Columns[c].ColumnName;
                ////}
                //rr.Font.Bold = true;

                for (int row = 0; row < dtRows.Rows.Count; row++)
                {
                    string Accounts = dtRows.Rows[row]["Row_Accounts"].ToString();
                    Accounts = Accounts.Replace("-", "");
                    Accounts = Accounts.Replace("(", "");
                    Accounts = Accounts.Replace(")", "");
                    if (Accounts.Contains("TO"))
                        Accounts = Accounts.Replace("TO", "AND");
                    else
                        Accounts = Accounts + " AND " + Accounts;

                    string Divide_Acc = dtRows.Rows[row]["Row_Divide_By_Acc"].ToString();
                    if (Divide_Acc.Trim() != "")
                    {
                        Divide_Acc = Divide_Acc.Replace("-", "");
                        Divide_Acc = Divide_Acc.Replace("(", "");
                        Divide_Acc = Divide_Acc.Replace(")", "");
                        if (Divide_Acc.Contains("TO"))
                            Divide_Acc = Divide_Acc.Replace("TO", "AND");
                        else
                            Divide_Acc = Divide_Acc + " AND " + Divide_Acc;
                    }
                    if (dtRows.Rows[row]["Row_Type"].ToString().Trim() == "DTL" || dtRows.Rows[row]["Row_Type"].ToString().Trim() == "TOT")
                    {
                        for (int col = 0; col < dtCols.Rows.Count; col++)
                        {
                            rr = mywsh.get_Range(dtCols.Rows[col]["Col_No"].ToString() + (int.Parse(dtRows.Rows[row]["Row_No"].ToString()) / 100).ToString(), dtCols.Rows[col]["Col_No"].ToString() + (int.Parse(dtRows.Rows[row]["Row_No"].ToString()) / 100).ToString());

                            if (dtCols.Rows[col]["Col_Type"].ToString() == "GL")
                            {
                                if (dtRows.Rows[row]["Row_Type"].ToString().Trim() == "DTL")
                                {
                                    DateTime Start_Date = DateTime.Now.Date;
                                    DateTime End_Date = DateTime.Now.Date;
                                    string str = "GLTotals";
                                    string strPrd = "PeriodBalance";
                                    if (dtCols.Rows[col]["Col_Period"].ToString().Substring(0, 3) == "PRD")
                                    {
                                        Rpt_Prd = int.Parse(dtCols.Rows[col]["Col_Period"].ToString().Remove(0, 3));
                                    }
                                    switch (dtCols.Rows[col]["Col_Source"].ToString())
                                    {
                                        case "LST":
                                            Rpt_Year--;
                                            break;
                                        case "BGT":
                                            str = "GLBudget";
                                            strPrd = "Period";
                                            break;
                                    }
                                    if (!DataClass.isExsist("*", "FiscalYear = " + Rpt_Year, "GLFiscalPeriodSetup"))
                                        rr[1, 1] = 0;
                                    else
                                    {

                                        switch (dtCols.Rows[col]["Col_Range"].ToString())
                                        {
                                            case "MTD":
                                                if ((bool)dtCols.Rows[col]["Daily_Rev"] && dtCols.Rows[col]["Col_Source"].ToString() != "BGT")
                                                {
                                                    string PeriodID = DataClass.ReturnRecordNameByID("Select PeriodID" + Rpt_Prd + " From GLFiscalPeriodSetup WHERE FiscalYear = " + Rpt_Year);
                                                    Start_Date = DateTime.Parse(DataClass.ReturnRecordNameByID("Select PeriodStartDate From GLFiscalPeriod WHERE PeriodID = " + PeriodID));
                                                    End_Date = DateTime.Parse(DataClass.ReturnRecordNameByID("Select PeriodEndDate From GLFiscalPeriod WHERE PeriodID = " + PeriodID));
                                                }
                                                else
                                                    strPrd += Rpt_Prd.ToString();
                                                break;
                                            case "YTD":
                                                if ((bool)dtCols.Rows[col]["Daily_Rev"] && dtCols.Rows[col]["Col_Source"].ToString() != "BGT")
                                                {
                                                    string PeriodID = DataClass.ReturnRecordNameByID("Select PeriodID1 From GLFiscalPeriodSetup WHERE FiscalYear = " + Rpt_Year);
                                                    Start_Date = DateTime.Parse(DataClass.ReturnRecordNameByID("Select PeriodStartDate From GLFiscalPeriod WHERE PeriodID = " + PeriodID));
                                                    PeriodID = DataClass.ReturnRecordNameByID("Select PeriodID" + Rpt_Prd + " From GLFiscalPeriodSetup WHERE FiscalYear = " + Rpt_Year);
                                                    End_Date = DateTime.Parse(DataClass.ReturnRecordNameByID("Select PeriodEndDate From GLFiscalPeriod WHERE PeriodID = " + PeriodID));
                                                }
                                                else
                                                {
                                                    string PeriodID = DataClass.ReturnRecordNameByID("Select MIN(PeriodID) AS PeriodID From GLFiscalPeriod WHERE Status='OPEN'");
                                                    string PeriodNumber = DataClass.ReturnRecordNameByID("Select PeriodNumber From GLFiscalPeriod WHERE PeriodID = " + PeriodID);
                                                    string FiscalYear = DataClass.ReturnRecordNameByID("Select FiscalYear From GLFiscalPeriodSetup WHERE PeriodID" + PeriodNumber + " = " + PeriodID);
                                                    if (int.Parse(FiscalYear) > Rpt_Year)
                                                    {
                                                        strPrd += Rpt_Prd.ToString();
                                                    }
                                                    else if (int.Parse(FiscalYear) < Rpt_Year)
                                                    {
                                                        string s = "";
                                                        for (int i = 1; i < Rpt_Prd; i++)
                                                            s += strPrd + i.ToString() + "+";
                                                        s += strPrd + Rpt_Prd.ToString();
                                                        strPrd = s;
                                                    }
                                                    else if (int.Parse(FiscalYear) == Rpt_Year)
                                                    {
                                                        if (int.Parse(PeriodNumber) >= Rpt_Prd - 1)
                                                            strPrd += Rpt_Prd.ToString();
                                                        else
                                                        {
                                                            string s = "";
                                                            for (int i = int.Parse(PeriodNumber); i < Rpt_Prd; i++)
                                                                s += strPrd + i.ToString() + "+";
                                                            s += strPrd + Rpt_Prd.ToString();
                                                            strPrd = s;
                                                        }
                                                    }
                                                }
                                                break;
                                            case "DAY":
                                                if ((bool)dtCols.Rows[col]["Daily_Rev"] && dtCols.Rows[col]["Col_Source"].ToString() != "BGT")
                                                {
                                                    string PeriodID = DataClass.ReturnRecordNameByID("Select PeriodID" + Rpt_Prd + " From GLFiscalPeriodSetup WHERE FiscalYear = " + Rpt_Year);
                                                    Start_Date = DateTime.Parse(DataClass.ReturnRecordNameByID("Select PeriodEndDate From GLFiscalPeriod WHERE PeriodID = " + PeriodID));
                                                    End_Date = Start_Date;
                                                }
                                                break;
                                            case "BEG":
                                                if (strPrd == "Period")
                                                    strPrd = "0";
                                                else
                                                    strPrd = "BeginningBalance";
                                                break;
                                        }
                                        DataTable DT = new DataTable();
                                        if ((bool)dtCols.Rows[col]["Daily_Rev"] && dtCols.Rows[col]["Col_Range"].ToString() != "BEG" && dtCols.Rows[col]["Col_Source"].ToString() != "BGT")
                                        {
                                            System.Collections.ArrayList ItemsNames = new System.Collections.ArrayList();
                                            System.Collections.ArrayList ItemsValues = new System.Collections.ArrayList();

                                            ItemsNames.Add("Rpt_Fdate");
                                            ItemsValues.Add(Start_Date.Date);

                                            ItemsNames.Add("Rpt_Tdate");
                                            ItemsValues.Add(End_Date.Date);

                                            DT = DataClass.SelectRecord("SELECT { fn IFNULL(SUM(GLT.AmountLC), 0) } AS Amt FROM dbo.Batch AS B INNER JOIN dbo.GLTransactions AS GLT ON B.BatchNo = GLT.BatchNo WHERE (B.BatchStat = 'P') AND (Convert(int,replace(GLT.GLAccount,'-','')) Between " + Accounts + ") AND (B.BatchDate Between @Rpt_Fdate AND @Rpt_Tdate ) AND (B.BatchJNL IN (Select JournalCodeID From G_Report_Journal Where Rpt_Code = '" + Rpt_Code + "'))", ItemsNames, ItemsValues);
                                        }
                                        else
                                            DT = DataClass.RetrieveData("SELECT { fn IFNULL(Sum(" + strPrd.Trim() + "), 0) } AS Amt FROM dbo." + str.Trim() + "  WHERE (Convert(int,replace(AccountNumber,'-','')) Between " + Accounts + ") AND ({ fn IFNULL(FiscalYear, 0) } = " + Rpt_Year.ToString() + ") ");
                                        if (DT.Rows.Count > 0)
                                        {
                                            double DAccAmt = 0;
                                            if (Divide_Acc.Trim() != "")
                                            {
                                                DataTable DT2 = new DataTable();
                                                if ((bool)dtCols.Rows[col]["Daily_Rev"] && dtCols.Rows[col]["Col_Range"].ToString() != "BEG" && dtCols.Rows[col]["Col_Source"].ToString() != "BGT")
                                                {
                                                    System.Collections.ArrayList ItemsNames = new System.Collections.ArrayList();
                                                    System.Collections.ArrayList ItemsValues = new System.Collections.ArrayList();

                                                    ItemsNames.Add("Rpt_Fdate");
                                                    ItemsValues.Add(Start_Date.Date);

                                                    ItemsNames.Add("Rpt_Tdate");
                                                    ItemsValues.Add(End_Date.Date);

                                                    DT2 = DataClass.SelectRecord("SELECT { fn IFNULL(SUM(GLT.AmountLC), 0) } AS Amt FROM dbo.Batch AS B INNER JOIN dbo.GLTransactions AS GLT ON B.BatchNo = GLT.BatchNo WHERE (B.BatchStat = 'P') AND (Convert(int,replace(GLT.GLAccount,'-','')) Between " + Divide_Acc + ") AND (B.BatchDate Between @Rpt_Fdate AND @Rpt_Tdate ) AND (B.BatchJNL IN (Select JournalCodeID From G_Report_Journal Where Rpt_Code = '" + Rpt_Code + "'))", ItemsNames, ItemsValues);
                                                }
                                                else
                                                    DT2 = DataClass.RetrieveData("SELECT { fn IFNULL(Sum(" + strPrd.Trim() + "), 0) } AS Amt FROM dbo." + str.Trim() + "  WHERE (Convert(int,replace(AccountNumber,'-','')) Between " + Divide_Acc + ") AND ({ fn IFNULL(FiscalYear, 0) } = " + Rpt_Year.ToString() + ") ");
                                                if (DT2.Rows.Count > 0)
                                                    double.TryParse(DT2.Rows[0]["Amt"].ToString(), out DAccAmt);
                                            }
                                            int Div_Day = 0;
                                            switch (dtRows.Rows[row]["Row_Divide_By_Amt"].ToString().Trim())
                                            {
                                                case "Day":
                                                    string PeriodID = DataClass.ReturnRecordNameByID("Select PeriodID" + Rpt_Prd + " From GLFiscalPeriodSetup WHERE FiscalYear = " + Rpt_Year);
                                                    int.TryParse(DataClass.ReturnRecordNameByID("Select datediff (d, PeriodStartDate, PeriodEndDate) + 1 From GLFiscalPeriod WHERE PeriodID = " + PeriodID), out Div_Day);
                                                    break;
                                                default:
                                                    int.TryParse(dtRows.Rows[row]["Row_Divide_By_Amt"].ToString().Trim(), out Div_Day);
                                                    break;
                                            }
                                            string sval = "";
                                            if (DAccAmt != 0)
                                                sval = "=" + DT.Rows[0]["Amt"].ToString() + "/" + DAccAmt.ToString();

                                            if (Div_Day != 0)
                                            {
                                                if (sval.Contains("="))
                                                    sval += "/" + Div_Day.ToString();
                                                else
                                                    sval = "=" + DT.Rows[0]["Amt"].ToString() + "/" + Div_Day.ToString();
                                            }

                                            if (sval.Trim() != "")
                                                rr[1, 1] = sval.Trim();
                                            else
                                                rr[1, 1] = double.Parse(DT.Rows[0]["Amt"].ToString());

                                        }
                                    }
                                }
                                else if (dtRows.Rows[row]["Row_Type"].ToString().Trim() == "TOT")
                                {
                                    string RTF = dtRows.Rows[row]["Row_TOT_Formula"].ToString();
                                    RTF = RTF.Replace("00", "");
                                    RTF = RTF.Replace("A", dtCols.Rows[col]["Col_No"].ToString());
                                    rr[1, 1] = "=" + RTF.Trim();
                                }

                            }
                            else if (dtCols.Rows[col]["Col_Type"].ToString() == "DB" || dtCols.Rows[col]["Col_Type"].ToString() == "CR")
                            {
                                if (dtRows.Rows[row]["Row_Type"].ToString().Trim() == "DTL")
                                {
                                    string BEG = "";
                                    if (dtCols.Rows[col]["Col_Period"].ToString().Substring(0, 3) == "PRD")
                                    {
                                        Rpt_Prd = int.Parse(dtCols.Rows[col]["Col_Period"].ToString().Remove(0, 3));
                                    }
                                    if (dtCols.Rows[col]["Col_Source"].ToString() == "LST")
                                    {
                                        Rpt_Year--;
                                    }
                                    if (!DataClass.isExsist("*", "FiscalYear = " + Rpt_Year, "GLFiscalPeriodSetup"))
                                        rr[1, 1] = 0;
                                    else
                                    {
                                        string PeriodID = DataClass.ReturnRecordNameByID("Select PeriodID" + Rpt_Prd + " From GLFiscalPeriodSetup WHERE FiscalYear = " + Rpt_Year);
                                        DateTime Start_Date = DateTime.Parse(DataClass.ReturnRecordNameByID("Select PeriodStartDate From GLFiscalPeriod WHERE PeriodID = " + PeriodID));
                                        DateTime End_Date = DateTime.Parse(DataClass.ReturnRecordNameByID("Select PeriodEndDate From GLFiscalPeriod WHERE PeriodID = " + PeriodID));

                                        switch (dtCols.Rows[col]["Col_Range"].ToString())
                                        {
                                            case "YTD":
                                                PeriodID = DataClass.ReturnRecordNameByID("Select PeriodID1 From GLFiscalPeriodSetup WHERE FiscalYear = " + Rpt_Year);
                                                Start_Date = DateTime.Parse(DataClass.ReturnRecordNameByID("Select PeriodStartDate From GLFiscalPeriod WHERE PeriodID = " + PeriodID));
                                                break;
                                            case "DAY":
                                                Start_Date = Start_Date.AddDays(Start_Date.Day * -1).AddDays(DateTime.Now.Day);
                                                End_Date = Start_Date;
                                                break;
                                            case "BEG":
                                                End_Date = Start_Date.AddDays(-1);
                                                PeriodID = DataClass.ReturnRecordNameByID("Select PeriodID1 From GLFiscalPeriodSetup WHERE FiscalYear = " + Rpt_Year);
                                                Start_Date = DateTime.Parse(DataClass.ReturnRecordNameByID("Select PeriodStartDate From GLFiscalPeriod WHERE PeriodID = " + PeriodID));

                                                BEG = " + " + DataClass.ReturnRecordNameByID("SELECT { fn IFNULL(Sum(BeginningBalance), 0) } AS Amt FROM dbo.GLTotals  WHERE (Convert(int,replace(AccountNumber,'-','')) Between " + Accounts + ") AND ({ fn IFNULL(FiscalYear, 0) } = " + Rpt_Year.ToString() + ") ");

                                                break;
                                        }

                                        System.Collections.ArrayList ItemsNames = new System.Collections.ArrayList();
                                        System.Collections.ArrayList ItemsValues = new System.Collections.ArrayList();

                                        ItemsNames.Add("Rpt_Fdate");
                                        ItemsValues.Add(Start_Date.Date);

                                        ItemsNames.Add("Rpt_Tdate");
                                        ItemsValues.Add(End_Date.Date);

                                        string type = ">=";
                                        if (dtCols.Rows[col]["Col_Type"].ToString() == "CR")
                                            type = "<";

                                        DataTable DT = new DataTable();
                                        if ((bool)dtCols.Rows[col]["Daily_Rev"] && dtCols.Rows[col]["Col_Range"].ToString() != "BEG" && dtCols.Rows[col]["Col_Source"].ToString() != "BGT")
                                            DT = DataClass.SelectRecord("SELECT { fn IFNULL(SUM(GLT.AmountLC), 0) } " + BEG + " AS Amt FROM dbo.Batch AS B INNER JOIN dbo.GLTransactions AS GLT ON B.BatchNo = GLT.BatchNo WHERE (B.BatchStat = 'P') AND (GLT.AmountLC " + type + " 0) AND (Convert(int,replace(GLT.GLAccount,'-','')) Between " + Accounts + ") AND (B.BatchDate Between @Rpt_Fdate AND @Rpt_Tdate ) AND (B.BatchJNL IN (Select JournalCodeID From G_Report_Journal Where Rpt_Code = '" + Rpt_Code + "'))", ItemsNames, ItemsValues);
                                        else
                                            DT = DataClass.SelectRecord("SELECT { fn IFNULL(SUM(GLT.AmountLC), 0) } " + BEG + " AS Amt FROM dbo.Batch AS B INNER JOIN dbo.GLTransactions AS GLT ON B.BatchNo = GLT.BatchNo WHERE (B.BatchStat = 'P') AND (GLT.AmountLC " + type + " 0) AND (Convert(int,replace(GLT.GLAccount,'-','')) Between " + Accounts + ") AND (B.BatchDate Between @Rpt_Fdate AND @Rpt_Tdate )", ItemsNames, ItemsValues);
                                        if (DT.Rows.Count > 0)
                                        {
                                            rr[1, 1] = double.Parse(DT.Rows[0]["Amt"].ToString());
                                        }
                                    }
                                }
                                else if (dtRows.Rows[row]["Row_Type"].ToString().Trim() == "TOT")
                                {
                                    string RTF = dtRows.Rows[row]["Row_TOT_Formula"].ToString();
                                    RTF = RTF.Replace("00", "");
                                    RTF = RTF.Replace("A", dtCols.Rows[col]["Col_No"].ToString());
                                    rr[1, 1] = "=" + RTF.Trim();
                                }

                            }
                            else if (dtCols.Rows[col]["Col_Type"].ToString() == "PCT")
                            {
                                if (dtCols.Rows[col]["Col_Prec_Source"].ToString().Trim() != "" && dtRows.Rows[row]["Row_Prec_Row"].ToString().Trim() != "")
                                {
                                    string CPS = dtCols.Rows[col]["Col_Prec_Source"].ToString();
                                    string RPR = (int.Parse(dtRows.Rows[row]["Row_Prec_Row"].ToString()) / 100).ToString();
                                    string RN = (int.Parse(dtRows.Rows[row]["Row_No"].ToString()) / 100).ToString();
                                    rr[1, 1] = "=IF(" + CPS + "" + RPR + "=0, 0, " + CPS + "" + RN + "/" + CPS + "" + RPR + "*100)";
                                }
                            }
                            else if (dtCols.Rows[col]["Col_Type"].ToString() == "CALC")
                            {
                                if (dtCols.Rows[col]["Col_Calc_Formula"].ToString().Trim() != "")
                                {
                                    string CCF = dtCols.Rows[col]["Col_Calc_Formula"].ToString();
                                    string RN = (int.Parse(dtRows.Rows[row]["Row_No"].ToString()) / 100).ToString();
                                    CCF = CCF.Replace("0", RN);
                                    if (dtCols.Rows[col]["Col_Calc_Divide"].ToString().Trim() != "")
                                    {
                                        string CCD = dtCols.Rows[col]["Col_Calc_Divide"].ToString();
                                        CCD = CCD.Replace("0", RN);
                                        CCF = "IF((" + CCD + ")=0,0,(" + CCF + "/ (" + CCD + ")))";
                                    }
                                    rr[1, 1] = "=" + CCF.Trim();
                                }
                            }
                            else if (dtCols.Rows[col]["Col_Type"].ToString() == "DESC")
                            {
                                rr[1, 1] = dtRows.Rows[row]["Row_Desc"].ToString();
                                rr.HorizontalAlignment = 3;
                                rr.VerticalAlignment = 3;
                            }
                        }
                    }
                    else if (dtRows.Rows[row]["Row_Type"].ToString().Trim() == "DESC")
                    {
                        rr = mywsh.get_Range("A" + (int.Parse(dtRows.Rows[row]["Row_No"].ToString()) / 100).ToString(), letter + (int.Parse(dtRows.Rows[row]["Row_No"].ToString()) / 100).ToString());
                        rr.MergeCells = true;
                        rr[1, 1] = dtRows.Rows[row]["Row_Desc"].ToString();
                        rr.HorizontalAlignment = 3;
                        rr.VerticalAlignment = 3;
                    }
                    else if (dtRows.Rows[row]["Row_Type"].ToString().Trim() == "HDL")
                    {
                        rr = mywsh.get_Range("A" + (int.Parse(dtRows.Rows[row]["Row_No"].ToString()) / 100).ToString(), letter + (int.Parse(dtRows.Rows[row]["Row_No"].ToString()) / 100).ToString());
                        rr.MergeCells = true;
                        rr[1, 1] = dtRows.Rows[row]["Row_Desc"].ToString();
                        rr.HorizontalAlignment = 1;
                        rr.VerticalAlignment = 3;
                    }
                    else if (dtRows.Rows[row]["Row_Type"].ToString().Trim() == "HDC")
                    {
                        rr = mywsh.get_Range("A" + (int.Parse(dtRows.Rows[row]["Row_No"].ToString()) / 100).ToString(), letter + (int.Parse(dtRows.Rows[row]["Row_No"].ToString()) / 100).ToString());
                        rr.MergeCells = true;
                        rr[1, 1] = dtRows.Rows[row]["Row_Desc"].ToString();
                        rr.HorizontalAlignment = 3;
                        rr.VerticalAlignment = 3;
                    }
                    else if (dtRows.Rows[row]["Row_Type"].ToString().Trim() == "HDR")
                    {
                        rr = mywsh.get_Range("A" + (int.Parse(dtRows.Rows[row]["Row_No"].ToString()) / 100).ToString(), letter + (int.Parse(dtRows.Rows[row]["Row_No"].ToString()) / 100).ToString());
                        rr.MergeCells = true;
                        rr[1, 1] = dtRows.Rows[row]["Row_Desc"].ToString();
                        rr.HorizontalAlignment = 4;
                        rr.VerticalAlignment = 3;
                    }
                    else if (dtRows.Rows[row]["Row_Type"].ToString().Trim() == "---")
                    {
                        rr = mywsh.get_Range("A" + (int.Parse(dtRows.Rows[row]["Row_No"].ToString()) / 100).ToString(), letter + (int.Parse(dtRows.Rows[row]["Row_No"].ToString()) / 100).ToString());
                        rr.MergeCells = true;
                        rr.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        rr.RowHeight = 2;
                    }
                    else if (dtRows.Rows[row]["Row_Type"].ToString().Trim() == "===")
                    {
                        rr = mywsh.get_Range("A" + (int.Parse(dtRows.Rows[row]["Row_No"].ToString()) / 100).ToString(), letter + (int.Parse(dtRows.Rows[row]["Row_No"].ToString()) / 100).ToString());
                        rr.MergeCells = true;
                        rr.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble;
                        rr.RowHeight = 2;
                    }
                }
                for (int col = 0; col < dtCols.Rows.Count; col++)
                {
                    rr = mywsh.get_Range(dtCols.Rows[col]["Col_No"].ToString() + "1", dtCols.Rows[col]["Col_No"].ToString() + dtRows.Rows.Count.ToString());
                    double i = double.Parse(rr.ColumnWidth.ToString());
                    double.TryParse(dtCols.Rows[col]["Col_Width"].ToString(), out i);
                    if ((bool)dtCols.Rows[col]["Col_Sup"])
                        rr.ColumnWidth = 0;
                    else
                        rr.ColumnWidth = i;

                }
                for (int row = 0; row < dtRows.Rows.Count; row++)
                {
                    rr = mywsh.get_Range("A" + (int.Parse(dtRows.Rows[row]["Row_No"].ToString()) / 100).ToString(), dtCols.Rows[dtCols.Rows.Count - 1]["Col_No"].ToString() + (int.Parse(dtRows.Rows[row]["Row_No"].ToString()) / 100).ToString());
                    rr.NumberFormat = dtRows.Rows[row]["Row_Format"].ToString().Trim();
                    if ((bool)dtRows.Rows[row]["Row_Sup"])
                        rr.RowHeight = 0;
                }
                rr = mywsh.get_Range("A1", letter + "1");
                rr.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, null);
                rr.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, null);
                rr.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, null);
                for (int col = 0; col < dtCols.Rows.Count; col++)
                {
                    rr = mywsh.get_Range(dtCols.Rows[col]["Col_No"].ToString() + "1", dtCols.Rows[col]["Col_No"].ToString() + "2");
                    switch (dtCols.Rows[col]["Col_Type"].ToString())
                    {
                        case "PCT":
                            rr[1, 1] = "";
                            rr[2, 1] = "%";
                            break;
                        case "CALC":
                            rr[1, 1] = "";
                            rr[2, 1] = dtCols.Rows[col]["Col_Header"].ToString();
                            break;
                        case "DB":
                            rr[1, 1] = dtCols.Rows[col]["Col_Range"].ToString() + "(" + "Debit)";
                            rr[2, 1] = dtCols.Rows[col]["Col_Header"].ToString();
                            break;
                        case "CR":
                            rr[1, 1] = dtCols.Rows[col]["Col_Range"].ToString() + "(" + "Credits)";
                            rr[2, 1] = dtCols.Rows[col]["Col_Header"].ToString();
                            break;
                        case "GL":
                            rr[1, 1] = dtCols.Rows[col]["Col_Range"].ToString();
                            rr[2, 1] = dtCols.Rows[col]["Col_Header"].ToString();
                            break;
                    }
                    rr.HorizontalAlignment = 3;
                    rr.VerticalAlignment = 3;
                }
                rr = mywsh.get_Range("A3", letter + "3");
                rr.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                rr.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                rr.MergeCells = true;
                rr[1, 1] = "Period " + Rpt_Prd.ToString() + "/" + Rpt_Year.ToString();
                rr.HorizontalAlignment = 3;
                rr.VerticalAlignment = 3;
                rr.Font.Bold = true;

                //rr.Columns.AutoFit();
                myexl.Visible = true;


            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;
                Function.StateThrid = "";
                Thread.CurrentThread.Abort();
            }

        }
        private string GetLetter(int LetterIndex)
        {
            string Lett = "";
            if (LetterIndex > 26)
            {
                Lett = "A";
                LetterIndex = LetterIndex - 26;
            }
            switch (LetterIndex)
            {
                case 1:
                    Lett += "A";
                    break;
                case 2:
                    Lett += "B";
                    break;
                case 3:
                    Lett += "C";
                    break;
                case 4:
                    Lett += "D";
                    break;
                case 5:
                    Lett += "E";
                    break;
                case 6:
                    Lett += "F";
                    break;
                case 7:
                    Lett += "G";
                    break;
                case 8:
                    Lett += "H";
                    break;
                case 9:
                    Lett += "I";
                    break;
                case 10:
                    Lett += "J";
                    break;
                case 11:
                    Lett += "K";
                    break;
                case 12:
                    Lett += "L";
                    break;
                case 13:
                    Lett += "M";
                    break;
                case 14:
                    Lett += "N";
                    break;
                case 15:
                    Lett += "O";
                    break;
                case 16:
                    Lett += "P";
                    break;
                case 17:
                    Lett += "Q";
                    break;
                case 18:
                    Lett += "R";
                    break;
                case 19:
                    Lett += "S";
                    break;
                case 20:
                    Lett += "T";
                    break;
                case 21:
                    Lett += "U";
                    break;
                case 22:
                    Lett += "V";
                    break;
                case 23:
                    Lett += "W";
                    break;
                case 24:
                    Lett += "X";
                    break;
                case 25:
                    Lett += "Y";
                    break;
                case 26:
                    Lett += "Z";
                    break;
            }
            return Lett;
        }

    }
}
