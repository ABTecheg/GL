using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.Drawing;
using System.IO;

namespace Accounting_GeneralLedger
{
    public static class DataClass
    {
        //.............Change These Variable Value According To "Log In" User .............................//
        //.................................................................................................//
        private static DataTable MyTable;
        private static SqlCommand MyComm;
        private static SqlDataAdapter MyAdapt;
        private static SqlDataReader MyReader;

        public static bool isExsist(string sqlTxt)
        {
            bool x = false;
            MyComm = new SqlCommand(sqlTxt, Conn.mycon);
            MyReader = null;
            try
            {
                using (MyComm)
                using (MyReader)
                {
                    if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
                    MyReader = MyComm.ExecuteReader();
                    if (MyReader.HasRows)
                        x = true;
                    else
                        x = false;
                }
            }
            catch (Exception ex)
            { DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Conn.mycon.Close(); }
            return x;
        }
        public static bool isExsist(string FieldSelected, string WhereFiltering, string TableName)
        {
            bool x = false;
            MyComm = new SqlCommand("select Count(" + FieldSelected + ") As Cont from " + TableName + " where " + WhereFiltering, Conn.mycon);
            MyReader = null;
            try
            {
                using (MyComm)
                using (MyReader)
                {
                    if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
                    MyReader = MyComm.ExecuteReader();
                    MyReader.Read();
                    int i = 0; int.TryParse(MyReader[0].ToString(), out i);
                    if (i > 0)
                        x = true;
                    else
                        x = false;
                }
            }
            catch (Exception ex)
            { DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Conn.mycon.Close(); }
            return x;
        }

        public static void loadDay()
        {

            SqlCommand myCom = new SqlCommand("Select top 1 SysDate From SystemDate Where Status = N'Open' And OutLet_ID_Active = " + Function.Store_Active_ID.ToString() + " and SCom_ID_Active = " + Function.SCom_Active_ID.ToString() + " Order By ID DESC", Conn.mycon);
            try
            {
                if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
                MyReader = null;
                MyReader = myCom.ExecuteReader();
                if (MyReader.HasRows)
                {
                    while (MyReader.Read())
                    {
                        Function.SysDate = MyReader.GetDateTime(0);
                    }
                    MyReader.Close();

                }
                else if (Function.Store_Active_ID != 0 && Function.SCom_Active_ID != 0)
                {
                    MyReader.Close();
                    if (Conn.mycon.State != ConnectionState.Closed) Conn.mycon.Close();
                    setNonQuery("Insert Into SystemDate (SysDate,Start_Time,End_Time,Status,User_ID,SCom_ID_Active,OutLet_ID_Active) Values (GetDate(),GetDate(),GetDate(),N'Open',0," + Function.SCom_Active_ID.ToString() + "," + Function.Store_Active_ID.ToString() + ") ");
                    Function.SysDate = DateTime.Now;
                }
                else
                {
                    MyReader.Close();

                    Function.SysDate = DateTime.Now;
                }
            }
            catch (Exception ex)
            { DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { if (Conn.mycon.State != ConnectionState.Closed) Conn.mycon.Close(); }
        }
        public static void LoadSetupSCom()
        {
            Function.List_Setup_SCom = new SortedList();
            SqlCommand myCom = new SqlCommand("Select * From Setup_SCom Where SCom_ID = " + Function.SCom_Active_ID.ToString(), Conn.mycon);
            try
            {
                if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
                MyReader = null;
                MyReader = myCom.ExecuteReader();
                if (MyReader.HasRows)
                {
                    while (MyReader.Read())
                    {
                        for (int i = 0; i < MyReader.FieldCount; i++)
                            Function.List_Setup_SCom.Add(MyReader.GetName(i), MyReader[i]);
                    }
                }
                MyReader.Close();
                if (Function.List_Setup_SCom.Count > 0)
                    int.TryParse(Function.List_Setup_SCom["Len_Decimal"].ToString(), out Function.Len_Decimal);
            }
            catch (Exception ex)
            { DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Conn.mycon.Close(); }
        }
        public static void LoadSetupStore()
        {
            Function.List_Setup_Store = new SortedList();
            SqlCommand myCom = new SqlCommand("Select * From Setup_Store Where Store_ID = " + Function.Store_Active_ID.ToString(), Conn.mycon);
            try
            {
                if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
                MyReader = null;
                MyReader = myCom.ExecuteReader();
                if (MyReader.HasRows)
                {
                    while (MyReader.Read())
                    {
                        for (int i = 0; i < MyReader.FieldCount; i++)
                            Function.List_Setup_Store.Add(MyReader.GetName(i), MyReader[i]);
                    }
                    Function.Lang = Function.List_Setup_Store["Default_Lang"].ToString();
                }
                MyReader.Close();

            }
            catch (Exception ex)
            { DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Conn.mycon.Close(); }
        }
        public static void setTempXMLFile(string tableName, ref DataTable tableData)
        {
            if (System.IO.File.Exists(System.IO.Path.GetTempPath() + "\\rpt" + tableName + ".Xml"))
            {
                System.IO.File.Delete(System.IO.Path.GetTempPath() + "\\rpt" + tableName + ".Xml");
            }
            tableData.WriteXml(System.IO.Path.GetTempPath() + "\\rpt" + tableName + ".Xml", XmlWriteMode.WriteSchema);
        }

        public static void setNonQuery(string sqlTxt)
        {
            SqlCommand myCom = new SqlCommand(sqlTxt, Conn.mycon);
            try
            {
                if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
                int i = myCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            { DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Conn.mycon.Close(); }
        }
        public static void setNonQuery(string sqlTxt, ref int Cont)
        {
            SqlCommand myCom = new SqlCommand(sqlTxt, Conn.mycon);
            try
            {
                if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
                Cont = myCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            { DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Conn.mycon.Close(); }
        }


        public static void fillCombowithCountryNames(ref ComboBox myCombo)
        {
            myCombo.Items.Clear();
            myCombo.Items.Add("Albania");
            myCombo.Items.Add("Algeria");
            myCombo.Items.Add("Argentina");
            myCombo.Items.Add("Australia");
            myCombo.Items.Add("Austria");
            myCombo.Items.Add("Bahrain");
            myCombo.Items.Add("Belarus");
            myCombo.Items.Add("Belgium");
            myCombo.Items.Add("Bolivia");
            myCombo.Items.Add("Bosnia and Herzegovina");
            myCombo.Items.Add("Brazil");
            myCombo.Items.Add("Bulgaria");
            myCombo.Items.Add("Canada");
            myCombo.Items.Add("Chile");
            myCombo.Items.Add("China");
            myCombo.Items.Add("Colombia");
            myCombo.Items.Add("Costa Rica");
            myCombo.Items.Add("Croatia");
            myCombo.Items.Add("Cyprus");
            myCombo.Items.Add("Czech Republic");
            myCombo.Items.Add("Denmark");
            myCombo.Items.Add("Dominican Republic");
            myCombo.Items.Add("Ecuador");
            myCombo.Items.Add("Egypt");
            myCombo.Items.Add("El Salvador");
            myCombo.Items.Add("Estonia");
            myCombo.Items.Add("Finland");
            myCombo.Items.Add("France");
            myCombo.Items.Add("Germany");
            myCombo.Items.Add("Greece");
            myCombo.Items.Add("Guatemala");
            myCombo.Items.Add("Honduras");
            myCombo.Items.Add("Hong Kong");
            myCombo.Items.Add("Hungary");
            myCombo.Items.Add("Iceland");
            myCombo.Items.Add("India");
            myCombo.Items.Add("Indonesia");
            myCombo.Items.Add("Iraq");
            myCombo.Items.Add("Ireland");
            myCombo.Items.Add("Israel");
            myCombo.Items.Add("Italy");
            myCombo.Items.Add("Japan");
            myCombo.Items.Add("Jordan");
            myCombo.Items.Add("Kuwait");
            myCombo.Items.Add("Latvia");
            myCombo.Items.Add("Lebanon");
            myCombo.Items.Add("Libya");
            myCombo.Items.Add("Lithuania");
            myCombo.Items.Add("Luxembourg");
            myCombo.Items.Add("Macedonia");
            myCombo.Items.Add("Malaysia");
            myCombo.Items.Add("Malta");
            myCombo.Items.Add("Mexico");
            myCombo.Items.Add("Montenegro");
            myCombo.Items.Add("Morocco");
            myCombo.Items.Add("Netherlands");
            myCombo.Items.Add("New Zealand");
            myCombo.Items.Add("Nicaragua");
            myCombo.Items.Add("Norway");
            myCombo.Items.Add("Oman");
            myCombo.Items.Add("Panama");
            myCombo.Items.Add("Paraguay");
            myCombo.Items.Add("Peru");
            myCombo.Items.Add("Philippines");
            myCombo.Items.Add("Poland");
            myCombo.Items.Add("Portugal");
            myCombo.Items.Add("Puerto Rico");
            myCombo.Items.Add("Qatar");
            myCombo.Items.Add("Romania");
            myCombo.Items.Add("Russia");
            myCombo.Items.Add("Saudi Arabia");
            myCombo.Items.Add("Serbia");
            myCombo.Items.Add("Serbia and Montenegro");
            myCombo.Items.Add("Singapore");
            myCombo.Items.Add("Slovakia");
            myCombo.Items.Add("Slovenia");
            myCombo.Items.Add("South Africa");
            myCombo.Items.Add("South Korea");
            myCombo.Items.Add("Spain");
            myCombo.Items.Add("Sudan");
            myCombo.Items.Add("Sweden");
            myCombo.Items.Add("Switzerland");
            myCombo.Items.Add("Syria");
            myCombo.Items.Add("Taiwan");
            myCombo.Items.Add("Thailand");
            myCombo.Items.Add("Tunisia");
            myCombo.Items.Add("Turkey");
            myCombo.Items.Add("Ukraine");
            myCombo.Items.Add("United Arab Emirates");
            myCombo.Items.Add("United Kingdom");
            myCombo.Items.Add("United States");
            myCombo.Items.Add("Uruguay");
            myCombo.Items.Add("Venezuela");
            myCombo.Items.Add("Vietnam");
            myCombo.Items.Add("Yemen");
        }


        public static bool CheckIfPrimaryInteredBefore(string TableName, string FiledSelect, string FieldName, string FieldValue)
        {
            bool found = false;
            MyComm = new SqlCommand("Select " + FiledSelect + " from " + TableName + " where " + FieldName + " = N'" + FieldValue + "'", Conn.mycon);
            try
            {
                if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
                MyReader = MyComm.ExecuteReader();
                if (MyReader.HasRows)
                {
                    found = true;
                }
            }
            catch (Exception ex)
            { DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                Conn.mycon.Close(); MyReader.Close();
            }

            Conn.mycon.Close();
            return found;
        }
        public static bool CheckIfPrimaryInteredBefore(string Str)
        {
            bool found = false;
            MyComm = new SqlCommand(Str, Conn.mycon);
            try
            {
                if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
                MyReader = MyComm.ExecuteReader();
                if (MyReader.Read())
                {
                    found = true;
                }
            }
            catch (Exception ex)
            { DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                Conn.mycon.Close(); MyReader.Close();
            }

            Conn.mycon.Close();
            return found;
        }

        public static Int64 SelectMaxID64(string TableName, string FieldName)
        {
            Int64 ID = 0;
            MyComm = new SqlCommand("Select  Max ( " + FieldName + " ) From " + TableName, Conn.mycon);
            try
            {
                if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
                if (MyComm.ExecuteScalar().ToString() == "")
                    ID = 0;
                else
                {
                    ID = Int64.Parse(MyComm.ExecuteScalar().ToString());
                }
            }
            catch (Exception ex)
            { DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Conn.mycon.Close(); }
            return ID;
        }
        public static int SelectMaxID(string TableName, string FieldName)
        {
            int ID = 0;
            MyComm = new SqlCommand("Select  Max ( " + FieldName + " ) From " + TableName, Conn.mycon);
            try
            {
                if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
                if (MyComm.ExecuteScalar().ToString() == "")
                    ID = 0;
                else
                {
                    ID = int.Parse(MyComm.ExecuteScalar().ToString());
                }
            }
            catch (Exception ex)
            { DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Conn.mycon.Close(); }
            return ID;
        }
        public static string GetStrID(int ID, int Digit)
        {
            string str = ID.ToString();
            if (str.Length > Digit)
                str = str.Substring(str.Length - Digit, Digit);
            else
                for (int i = ID.ToString().Length; i < Digit; i++)
                    str = "0" + str;
            return str;
        }
        public static string GetStrID(Int64 ID, int Digit)
        {
            string str = ID.ToString();
            if (str.Length > Digit)
                str = str.Substring(str.Length - Digit, Digit);
            else
                for (int i = ID.ToString().Length; i < Digit; i++)
                    str = "0" + str;
            return str;
        }
        public static string SelectNewIDForWS(string ColSerial, string TableName, int SCom, int Store, int lenSerial)
        {
            string StrID = "";
            int ID = 0;
            MyComm = new SqlCommand("Select  Max (" + ColSerial + ") From " + TableName + " where Store_ID = " + Store.ToString() + " And SCom_ID = " + SCom.ToString(), Conn.mycon);
            try
            {
                if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
                if (MyComm.ExecuteScalar().ToString() == "")
                    ID = 0;
                else
                {
                    ID = int.Parse(MyComm.ExecuteScalar().ToString());
                }
                StrID = GetStrID(SCom, 2) + GetStrID(Store, 2) + GetStrID(Function.WS, 2) + GetStrID(ID + 1, lenSerial);
            }
            catch (Exception ex)
            { DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Conn.mycon.Close(); }
            return StrID;
        }

        public static string SelectNewIDCheck()
        {
            string StrID = "";
            int ID = 0;
            MyComm = new SqlCommand("Select  Max (CheckSerail) From Checks where OutLet_ID = " + Function.Store_Active_ID.ToString() + " And SCom_ID_Active = " + Function.SCom_Active_ID.ToString(), Conn.mycon);
            try
            {
                if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
                if (MyComm.ExecuteScalar().ToString() == "")
                    ID = 0;
                else
                {
                    ID = int.Parse(MyComm.ExecuteScalar().ToString());
                }
                if (ID == 0)
                {
                    MyComm = new SqlCommand("Select  Max (CheckSerail) From histChecks where OutLet_ID = " + Function.Store_Active_ID.ToString() + " And SCom_ID_Active = " + Function.SCom_Active_ID.ToString(), Conn.mycon);
                    if (MyComm.ExecuteScalar().ToString() == "")
                        ID = 0;
                    else
                    {
                        ID = int.Parse(MyComm.ExecuteScalar().ToString());
                    }
                }
                StrID = GetStrID(Function.SCom_Active_ID, 2) + GetStrID(Function.Store_Active_ID, 3) + GetStrID(Function.WS, 2) + GetStrID(ID + 1, 6);
            }
            catch (Exception ex)
            { DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Conn.mycon.Close(); }
            return StrID;
        }
        public static int SelectMaxCode(string TableName, string FieldName)
        {
            int ID = 1;
            string str = "";
            str = "declare @scount int " +
                   " set @scount = (SELECT count(*) FROM " + TableName + ")  " +
                 "   declare @MaxID int " +
                  "  tryagen: " +
                  "  set @MaxID = (select count(*) FROM " + TableName + " where " + FieldName + " =  convert(nvarchar(10),@scount)) " +
                  "  if (@MaxID > 0) " +
                  "  begin " +
                  "  set @scount = @scount + 1 " +
                 "    goto tryagen " +
                   " end " +
                 "   select @scount AS MaxCode";
            MyComm = new SqlCommand(str, Conn.mycon);
            try
            {
                if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
                if (MyComm.ExecuteScalar().ToString() == "")
                    ID = 1;
                else
                {
                    ID = int.Parse(MyComm.ExecuteScalar().ToString());
                }
            }
            catch (Exception ex)
            { DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Conn.mycon.Close(); }
            return ID;
        }

        public static string ReturnRecordNameByID(string IDColName, string IDVal, string RetColName, string TableName)
        {
            string NameR = "";
            MyComm = new SqlCommand("Select " + RetColName + " From " + TableName + " where " + IDColName + " ='" + IDVal + "'", Conn.mycon);
            try
            {
                if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
                MyReader = MyComm.ExecuteReader();
                while (MyReader.Read())
                {
                    NameR = MyReader[RetColName.Trim()].ToString();
                }
            }
            catch (Exception ex)
            { DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Conn.mycon.Close(); }
            return NameR;
        }
        public static string ReturnRecordNameByID(string condition, string RetColName)
        {
            string NameR = "";
            MyComm = new SqlCommand("Select " + RetColName + " From " + condition, Conn.mycon);
            try
            {
                if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
                MyReader = MyComm.ExecuteReader();
                while (MyReader.Read())
                {
                    NameR = MyReader[0].ToString();
                }
            }
            catch (Exception ex)
            { DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Conn.mycon.Close(); }
            return NameR;
        }
        public static string ReturnRecordNameByID(string condition, string RetColName, string TableName)
        {
            string NameR = "";
            MyComm = new SqlCommand("Select " + RetColName + " From " + TableName + " where " + condition, Conn.mycon);
            try
            {
                if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
                MyReader = MyComm.ExecuteReader();
                while (MyReader.Read())
                {
                    NameR = MyReader[0].ToString();
                }
            }
            catch (Exception ex)
            { DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Conn.mycon.Close(); }
            return NameR;
        }
        public static string ReturnRecordNameByID(string Str)
        {
            string NameR = "";
            MyComm = new SqlCommand(Str, Conn.mycon);
            try
            {
                if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
                MyReader = MyComm.ExecuteReader();
                while (MyReader.Read())
                {
                    NameR = MyReader[0].ToString();
                }
            }
            catch (Exception ex)
            { DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Conn.mycon.Close(); }
            return NameR;
        }

        public static DataTable SelectFrom2Tables(string CoulmnsFromTableOne, string CoulmnsFromTableTow, string TableOneName, string TableTowName, string EqualityMEMOne, string EqualityMEMTow, string AnyAthorANDCond)
        {
            MyComm = new SqlCommand("Select " + CoulmnsFromTableOne + " , " + CoulmnsFromTableTow + " from " + TableOneName + " , " + TableTowName + " where " + EqualityMEMOne + " = " + EqualityMEMTow + " " + AnyAthorANDCond, Conn.mycon);
            MyAdapt = new SqlDataAdapter(MyComm);
            MyTable = new DataTable();
            MyAdapt.Fill(MyTable);
            return MyTable;
        }

        public static DataTable SelectFrom3Tables(string CoulmnsFromTableOne, string CoulmnsFromTableTow, string CoulmnsFromTableThree, string TableOneName, string TableTowName, string TableThreeName, string EqualityMEMOne, string EqualityMEMTow, string EqualityFromOther, string AnyAthorANDCond)
        {

            MyComm = new SqlCommand("Select " + CoulmnsFromTableOne + " , " + CoulmnsFromTableTow + " , " + CoulmnsFromTableThree + " from " + TableOneName + " , " + TableTowName + " , " + TableThreeName + " where " + EqualityMEMOne + " = " + EqualityMEMTow + " and " + EqualityFromOther + " " + AnyAthorANDCond, Conn.mycon);
            MyAdapt = new SqlDataAdapter(MyComm);
            MyTable = new DataTable();
            MyAdapt.Fill(MyTable);
            return MyTable;
        }

        private static SqlDbType GetDBType(Type theType)
        {
            SqlParameter p1 = new SqlParameter();
            TypeConverter tc = TypeDescriptor.GetConverter(p1.DbType);
            if (tc.CanConvertFrom(theType))
                p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
            else
            {
                try
                {
                    p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
                }
                catch { p1.SqlDbType = SqlDbType.Image; }
            }
            return p1.SqlDbType;
        }

        public static void InsertRecord(string InsertCommand, ArrayList FieldsNames, ArrayList FieldsValues)
        {
            string FName = "";
            MyComm = new SqlCommand(InsertCommand, Conn.mycon);
            Type TempType;
            for (int i = 0; i < FieldsNames.Count; i++)
            {
                TempType = FieldsValues[i].GetType();
                FName = FieldsNames[i].ToString();
                MyComm.Parameters.Add(FName, GetDBType(TempType)).Value = FieldsValues[i];
            }
            //try
            //{
            if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
            int ii = MyComm.ExecuteNonQuery();
            Conn.mycon.Close();
            //}
            //catch (Exception ex)
            //{ DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            //finally { Conn.mycon.Close(); }
        }

        public static DataTable RetrieveData(string FieldSelected, string TableName)
        {
            MyAdapt = new SqlDataAdapter("select " + FieldSelected + " from " + TableName, Conn.mycon);
            MyTable = new DataTable();
            MyAdapt.Fill(MyTable);
            return MyTable;
        }
        public static DataTable RetrieveData(string SQL_Str)
        {
            MyAdapt = new SqlDataAdapter(SQL_Str, Conn.mycon);
            MyTable = new DataTable();
            MyAdapt.Fill(MyTable);
            return MyTable;
        }

        public static DataTable RetrieveData(string FieldSelected, string WhereFiltering, string TableName)
        {
            MyAdapt = new SqlDataAdapter("select " + FieldSelected + " from " + TableName + " where " + WhereFiltering, Conn.mycon);
            MyTable = new DataTable();
            MyAdapt.Fill(MyTable);
            return MyTable;
        }
        public static DataTable RetrieveDataPOS(string SQL_Str)
        {
            MyAdapt = new SqlDataAdapter(SQL_Str, Conn.mycon);
            MyTable = new DataTable();
            MyAdapt.Fill(MyTable);
            return MyTable;
        }

        public static void DeleteRecord(string SelectedCodeVal, string FieldWhereTxt, string TableName, string AndCondition)
        {
            MyComm = new SqlCommand("Delete from " + TableName + " where " + FieldWhereTxt + " = N'" + SelectedCodeVal + "' " + AndCondition, Conn.mycon);
            try
            {
                if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
                MyComm.ExecuteNonQuery();
            }
            catch (Exception ex)
            { DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            { Conn.mycon.Close(); }
        }

        public static void UpdateRecord(string UpdateCommand, ArrayList FieldsNames, ArrayList FieldsValues)
        {
            string FName = "";
            MyComm = new SqlCommand(UpdateCommand, Conn.mycon);
            Type TempType;
            for (int i = 0; i < FieldsNames.Count; i++)
            {
                if (FieldsValues[i] != null)
                {
                    TempType = FieldsValues[i].GetType();
                    FName = FieldsNames[i].ToString();
                    MyComm.Parameters.Add(FName, GetDBType(TempType)).Value = FieldsValues[i];
                }
                else
                {
                    FName = FieldsNames[i].ToString();
                    MyComm.Parameters.Add(FName, DBNull.Value).Value = FieldsValues[i];
                }
            }

            //try
            //{
            if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
            int ii = MyComm.ExecuteNonQuery();
            Conn.mycon.Close();
            //}
            //catch (Exception ex)
            //{ DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            //finally { Conn.mycon.Close(); }
        }
        public static DataTable SelectRecord(string SelectCommand, ArrayList FieldsNames, ArrayList FieldsValues)
        {
            string FName = "";
            MyComm = new SqlCommand(SelectCommand, Conn.mycon);
            Type TempType;
            for (int i = 0; i < FieldsNames.Count; i++)
            {
                TempType = FieldsValues[i].GetType();
                FName = FieldsNames[i].ToString();
                MyComm.Parameters.Add(FName, GetDBType(TempType)).Value = FieldsValues[i];
            }
            MyAdapt = new SqlDataAdapter(MyComm);
            MyTable = new DataTable();
            MyAdapt.Fill(MyTable);
            return MyTable;

        }
        public static void SelectRecord(string SelectCommand, ArrayList FieldsNames, ArrayList FieldsValues, ref DataTable Mtable)
        {
            string FName = "";
            MyComm = new SqlCommand(SelectCommand, Conn.mycon);
            Type TempType;
            for (int i = 0; i < FieldsNames.Count; i++)
            {
                TempType = FieldsValues[i].GetType();
                FName = FieldsNames[i].ToString();
                MyComm.Parameters.Add(FName, GetDBType(TempType)).Value = FieldsValues[i];
            }
            MyAdapt = new SqlDataAdapter(MyComm);
            MyAdapt.Fill(Mtable);

        }
        #region ChangeInfoFlow

        // Change Infos Main Method
        //
        //
        public static void ChangeInfoData(string User_ID, string Customer, string Contract, string Unit, string Property, string Note, string Reservation, string Payment)
        {
            ArrayList ItemsNames = new ArrayList();
            ArrayList ItemsValues = new ArrayList();

            ItemsNames.Add("ID");
            ItemsValues.Add(User_ID);

            ItemsNames.Add("Customer");
            ItemsValues.Add(Customer);

            ItemsNames.Add("Contract");
            ItemsValues.Add(Contract);

            ItemsNames.Add("Unit");
            ItemsValues.Add(Unit);

            ItemsNames.Add("Property");
            ItemsValues.Add(Property);

            ItemsNames.Add("Note");
            ItemsValues.Add(Note);

            ItemsNames.Add("UpdateDate");
            ItemsValues.Add(DateTime.Now.Date);

            ItemsNames.Add("Reservation");
            ItemsValues.Add(Reservation);

            ItemsNames.Add("Payment");
            ItemsValues.Add(Payment);
            try
            {
                DataClass.InsertRecord("insert into Change_info (ID,Customer,Contract,Unit,Property,Note,UpdateDate,Reservation,Payment) values (@ID,@Customer,@Contract,@Unit,@Property,@Note,@UpdateDate,@Reservation,@Payment)", ItemsNames, ItemsValues);
            }
            catch { };


        }
        #endregion


        //'''''''''''''''''''Retrieve User Previlages'''''''''''''''''''''
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        //-------------------------------------------------------------------
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        //The Function To Get The Masseage Box Language 
        public static string MessageLanguages(string MsegAlis)
        {
            string x = null;
            x = Function.Lang;
            //MirrorLocations(Me) 
            // StreamReader will retrieve the file from the source 
            // and will convert it into a stream ready to be processed. 
            System.IO.StreamReader Languagesr = new System.IO.StreamReader(x);
            // The XmlTextReader 
            System.Xml.XmlTextReader Languagexr = new System.Xml.XmlTextReader(Languagesr);
            // The XmlDocument 
            System.Xml.XmlDocument carlotDoc = new System.Xml.XmlDocument();
            carlotDoc.Load(Languagexr);
            System.Xml.XmlNodeList carLotItems = default(System.Xml.XmlNodeList);
            System.Xml.XmlNode make = default(System.Xml.XmlNode);
            //Buttons 
            carLotItems = carlotDoc.SelectNodes("General/MessageBoxes");
            string MasgText = "";
            switch (MsegAlis)
            {
                case "Error":
                    make = carLotItems.Item(0).SelectSingleNode("Error");
                    MasgText = make.InnerText;
                    break;
                case "EnterTheSerilNumber":
                    make = carLotItems.Item(0).SelectSingleNode("EnterTheSerilNumber");
                    MasgText = make.InnerText;
                    break;
                case "ThisNumberIsUsedPefore":
                    make = carLotItems.Item(0).SelectSingleNode("ThisNumberIsUsedPefore");
                    MasgText = make.InnerText;
                    break;
                case "SelectCategory":
                    make = carLotItems.Item(0).SelectSingleNode("SelectCategory");
                    MasgText = make.InnerText;
                    break;
                case "SelectSubCategory":
                    make = carLotItems.Item(0).SelectSingleNode("SelectSubCategory");
                    MasgText = make.InnerText;
                    break;
                case "SelectItem":
                    make = carLotItems.Item(0).SelectSingleNode("SelectItem");
                    MasgText = make.InnerText;
                    break;
                case "EnterQTy":
                    make = carLotItems.Item(0).SelectSingleNode("EnterQTy");
                    MasgText = make.InnerText;
                    break;
                case "EnterTheUnitPrice":
                    make = carLotItems.Item(0).SelectSingleNode("EnterTheUnitPrice");
                    MasgText = make.InnerText;
                    break;
                case "AddItemToSave":
                    make = carLotItems.Item(0).SelectSingleNode("AddItemToSave");
                    MasgText = make.InnerText;
                    break;
                case "EnterTheCode":
                    make = carLotItems.Item(0).SelectSingleNode("EnterTheCode");
                    MasgText = make.InnerText;
                    break;
                case "EnterTheName":
                    make = carLotItems.Item(0).SelectSingleNode("EnterTheName");
                    MasgText = make.InnerText;
                    break;
                case "ErrorOnThePassword":
                    make = carLotItems.Item(0).SelectSingleNode("ErrorOnThePassword");
                    MasgText = make.InnerText;
                    break;
                case "SelectTheUserClasses":
                    make = carLotItems.Item(0).SelectSingleNode("SelectTheUserClasses");
                    MasgText = make.InnerText;
                    break;
                case "SelectTheVendor":
                    make = carLotItems.Item(0).SelectSingleNode("SelectTheVendor");
                    MasgText = make.InnerText;
                    break;

                case "CantAccecable":
                    make = carLotItems.Item(0).SelectSingleNode("CantAccecable");
                    MasgText = make.InnerText;
                    break;
                case "CantAccecableTheStorgLevelIs":
                    make = carLotItems.Item(0).SelectSingleNode("CantAccecableTheStorgLevelIs");
                    MasgText = make.InnerText;
                    break;
                case "SelectAnatherOutlet":
                    make = carLotItems.Item(0).SelectSingleNode("SelectAnatherOutlet");
                    MasgText = make.InnerText;
                    break;
                case "SelectTheFSComOutlet":
                    make = carLotItems.Item(0).SelectSingleNode("SelectTheFSComOutlet");
                    MasgText = make.InnerText;
                    break;
                case "SelectTheSecandOutlet":
                    make = carLotItems.Item(0).SelectSingleNode("SelectTheSecandOutlet");
                    MasgText = make.InnerText;
                    break;
            }
            return MasgText;
        }
        //The Function To Select The Language Path 
        public static string LanguageXmlFile(int LaguageCode)
        {
            string xFilePath = null;
            if (LaguageCode == 1)
            {
                xFilePath = "XMLs\\LanguageEnglish.xml";
            }
            else
            {
                xFilePath = "XMLs\\LanguageArabic.xml";
            }
            return xFilePath;
        }
        ///////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////
        public static string Tafgeet(Double Amount, string Curr, string SubCurr)
        {
            if (Amount <= 0) return "";
            string Value = Math.Floor(Amount).ToString();
            string NewValue = null;
            try
            {
                string[] Part1 = new string[10] { "", "≈ÕœÌ ", "«À‰«", "À·«À", "√—»⁄…", "Œ„”…", "” …", "”»⁄…", "À„«‰Ì…", " ”⁄…" 
        };
                string[] Part2 = new string[10] { "", "⁄‘—", "⁄‘—Ê‰", "À·«ÀÊ‰", "√—»⁄Ê‰", "Œ„”Ê‰", "” Ê‰", "”»⁄Ê‰", "À„«‰Ê‰", " ”⁄Ê‰" 
        };
                string[] Part3 = new string[10] { "", "„∆…", "„∆ «‰", "À·«À „«∆…", "√—»⁄ „«∆…", "Œ„” „«∆…", "”  „«∆…", "”»⁄ „«∆…", "À„«‰ „«∆…", " ”⁄ „«∆…" 
        };
                string[] Part4 = new string[10] { "", "√·›", "√·›«‰", "À·«À… ¬·«›", "√—»⁄ ¬·«›", "Œ„”… ¬·«›", "” … ¬·«›", "”»⁄ ¬·«›", "À„«‰Ì… ¬·«›", " ”⁄… ¬·«›" 
        };

                //---------------------------< ....... «·„·«ÌÌÌÌÌÌÌÌÌÌÌÌÌ‰ ........ > 
                if (Value.Length == 7)
                {
                    if (Value.Substring(0, 1) == "1")
                    {
                        NewValue = "„·ÌÊ‰ ";
                    }
                    else if (Value.Substring(0, 1) == "2")
                    {
                        NewValue = "„·ÌÊ‰«‰ ";
                    }
                    else
                    {
                        NewValue = Part1[int.Parse(Value.Substring(0, 1))] + " „·«ÌÌ‰";
                    }

                    Value = Value.Substring(1, Value.Length - 1);
                }
                //------------------------------------< ....... „∆«  «·√·Ê›....... > 
                if (Value.Length == 6)
                {
                    NewValue += " " + Part3[int.Parse(Value.Substring(0, 1))] + " Ê";
                    Value = Value.Substring(1, Value.Length - 1);
                }
                //---------------------------------- 
                if (Value.Length == 5)
                {
                    NewValue += " " + Part1[int.Parse(Value.Substring(1, 1))];
                    NewValue += " Ê" + Part2[int.Parse(Value.Substring(0, 1))] + " √·›« Ê";
                    Value = Value.Substring(1, Value.Length - 1);
                    Value = Value.Substring(1, Value.Length - 1);
                }
                //--------------------------------- 
                if (Value.Length == 4)
                {
                    NewValue += " " + Part4[int.Parse(Value.Substring(0, 1))];
                    Value = Value.Substring(1, Value.Length - 1);
                }
                if (Value.Length == 3)
                {
                    if (!Value.Contains("00"))
                    {
                        NewValue += " " + Part3[int.Parse(Value.Substring(0, 1))] + " Ê";
                        Value = Value.Substring(1, Value.Length - 1);
                    }
                    else
                    {
                        NewValue += " " + Part3[int.Parse(Value.Substring(0, 1))];
                        Value = Value.Substring(1, Value.Length - 1);
                    }
                }
                //NewValue += " " & Part3(Integer.Parse(Value.Substring(0, 1))) & " Ê" 
                //Value = Value.Substring(1, Value.Length - 1) 
                //----------------------------------- 
                if (Value.Length >= 1 && Value.Length <= 2)
                {
                    NewValue += Part1[int.Parse(Value.Substring(1, 1))];
                    NewValue += " " + Part2[int.Parse(Value.Substring(0, 1))];
                    Value = Value.Substring(1, Value.Length - 1);
                    Value = Value.Substring(1, Value.Length - 1);
                }
                NewValue += " " + Curr;
                //«·ﬂ”— «·⁄‘—Ì 
                string Real = Amount.ToString("");
                int Pos = Real.IndexOf('.', 0, Real.Length);
                if (Pos != -1)
                {
                    Pos += 1;
                    try
                    {
                        string NewReal = (float.Parse(Real.Substring(Pos, Real.Length - Pos))).ToString();
                        if (NewReal.Length == 1)
                        {
                            NewValue += " Ê " + Part1[int.Parse(NewReal.Substring(0, 1))];
                        }
                        else
                        {
                            NewValue += " Ê " + Part1[int.Parse(NewReal.Substring(1, 1))];
                            NewValue += " Ê " + Part2[int.Parse(NewReal.Substring(0, 1))];
                        }
                        NewValue += " " + SubCurr;
                    }
                    catch
                    {
                    }
                }
            }
            catch { };
            return (NewValue);
        }

        public static bool isExsist(DataGridView myDg, int fIndex, string fValue)
        {
            for (int r = 0; r <= myDg.Rows.Count - 1; r++)
            {
                if (myDg.Rows[r].Cells[fIndex].FormattedValue != null && myDg.Rows[r].Cells[fIndex].FormattedValue.ToString() == fValue)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool isExsist(DataGridView myDg, int fIndex, string fValue, ref int fRowIndx)
        {
            for (int r = 0; r <= myDg.Rows.Count - 1; r++)
            {
                if (myDg.Rows[r].Cells[fIndex].FormattedValue.ToString() == fValue)
                {
                    fRowIndx = r;
                    return true;
                }
            }
            return false;
        }
        public static bool isExsist(DataGridView myDg, int fIndex, string fValue, int fIndex2, string fValue2, ref int fRowIndx)
        {
            for (int r = 0; r <= myDg.Rows.Count - 1; r++)
            {
                if (myDg.Rows[r].Cells[fIndex].FormattedValue.ToString() == fValue && myDg.Rows[r].Cells[fIndex2].Value.ToString() == fValue2)
                {
                    fRowIndx = r;
                    return true;
                }
            }
            return false;
        }

        public static float ConvertValuesAccordingUnits(string MainUnitCode, float MainUnitQty, string CompareUnitCode, float CompareUnitQty, float MainCost)
        {

            float NewCost = 0;

            DataTable ConvTable = RetrieveData("Qty", "LargeUnit='" + MainUnitCode + "' and SmallUnit='" + CompareUnitCode + "'", "Conversion");
            if (ConvTable.Rows.Count != 0)
            {
                float ConvVal = 0;
                float.TryParse(ConvTable.Rows[0][0].ToString(), out ConvVal);
                float TempS = MainUnitQty * ConvVal;
                float CostPerUnit = MainCost / TempS;
                NewCost = CostPerUnit * CompareUnitQty;
            }
            else
            {
                ConvTable = RetrieveData("Qty", "LargeUnit='" + CompareUnitCode + "' and SmallUnit='" + MainUnitCode + "'", "Conversion");
                if (ConvTable.Rows.Count != 0)
                {

                    float ConvVal = 0;
                    float.TryParse(ConvTable.Rows[0][0].ToString(), out ConvVal);
                    float TempS = CompareUnitQty * ConvVal * MainCost;
                    NewCost = TempS / MainUnitQty;
                }
                else
                {
                    NewCost = 0;
                }
            }

            return NewCost;
        }

        public static float Return_ItemCost_BasedOn_CostMethod(string Method, string ItemCode, string UnitCode, int ItemQty)
        {
            DataTable MyData = new DataTable();
            float Cost = 0;
            float NewCost = 0;
            if (Method == "FIFO")
            {
                MyData = RetrieveData("*", " ItemCode = N'" + ItemCode + "' ORDER BY changeDate", "ItemsCost");
                if (MyData.Rows.Count != 0)
                {
                    float.TryParse(MyData.Rows[0]["Cost"].ToString(), out Cost);
                    string Ucode = MyData.Rows[0]["UnitCode"].ToString();
                    NewCost = ConvertValuesAccordingUnits(Ucode, 1, UnitCode, ItemQty, Cost);
                }
            }
            else if (Method == "LIFO")
            {
                MyData = RetrieveData("*", " ItemCode = N'" + ItemCode + "' ORDER BY changeDate DESC", "ItemsCost");
                if (MyData.Rows.Count != 0)
                {
                    float.TryParse(MyData.Rows[0]["Cost"].ToString(), out Cost);
                    string Ucode = MyData.Rows[0]["UnitCode"].ToString();
                    NewCost = ConvertValuesAccordingUnits(Ucode, 1, UnitCode, ItemQty, Cost);
                }
            }
            else if (Method == "AV")
            {
                DateTime MyTime = DateTime.Now.Date;
                DateTime BeforeMonth = DateTime.Now.Date.AddMonths(-1).Date;
                MyData = RetrieveData("*", " ItemCode='" + ItemCode + "' and changeDate between '" + BeforeMonth + "' and '" + MyTime + "'", "ItemsCost");
                if (MyData.Rows.Count != 0)
                {
                    for (int i = 0; i < MyData.Rows.Count; i++)
                    {
                        string Ucode = MyData.Rows[0]["UnitCode"].ToString();
                        float.TryParse(MyData.Rows[0]["Cost"].ToString(), out Cost);

                        NewCost += ConvertValuesAccordingUnits(Ucode, 1, UnitCode, ItemQty, Cost);
                    }
                    NewCost = NewCost / MyData.Rows.Count;
                }
            }

            return NewCost;
        }

        public static void UpdateStockAfterPOS(int CrossCode, int inVenCode)
        {

        }
        public static void LockTables(string TableLock, string FormLock, string IDRow, string State)
        {
            SqlCommand mycomDTS;
            if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
            mycomDTS = new SqlCommand("insert Into AvailableTable (ComputerIP,ComputerName,TableLock,DateLock,IDRow,FormLock,State) VALUES (N'" + Function.ComputerIP + "',N'" + Function.ComputerName + "',N'" + TableLock + "',N'" + DateTime.Now.ToString() + "',N'" + IDRow + "',N'" + FormLock + "',N'" + State + "')", Conn.mycon);
            mycomDTS.ExecuteNonQuery();
            Conn.mycon.Close();
        }
        public static string CheckLockTables(string TableLock, string FormLock, string IDRow, string State)
        {
            SqlCommand mycomDTS;
            string NameAvil = "";
            string s = "";
            if (TableLock != "")
            {
                s = "TableLock = N'" + TableLock + "'";
            }
            if (FormLock != "")
            {
                if (s == "")
                    s = " FormLock = N'" + FormLock + "'";
                else
                    s += " AND FormLock = N'" + FormLock + "'";
            }
            if (IDRow != "")
            {
                if (s == "")
                    s = " IDRow = N'" + IDRow + "'";
                else
                    s += " AND IDRow = N'" + IDRow + "'";
            }
            if (State != "")
            {
                if (s == "")
                    s = " State = N'" + State + "'";
                else
                    s += " AND State = N'" + State + "'";
            }
            if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
            if (s != "")
                mycomDTS = new SqlCommand("Select * From AvailableTable Where (" + s + " AND ComputerName <> '" + Function.ComputerName + "') OR (TableLock = N'ALL' AND ComputerName <> '" + Function.ComputerName + "')", Conn.mycon);
            else
                mycomDTS = new SqlCommand("Select * From AvailableTable Where (TableLock = N'ALL' AND ComputerName <> '" + Function.ComputerName + "')", Conn.mycon);
            SqlDataReader mydr = mycomDTS.ExecuteReader();
            if (mydr.HasRows == true)
            {
                mydr.Read();
                NameAvil = mydr["ComputerName"].ToString() + " " + mydr["ComputerIP"].ToString();
                mydr.Close();
            }
            Conn.mycon.Close();
            return NameAvil;
        }
        public static string CheckLockTablesMe(string TableLock, string FormLock, string IDRow, string State)
        {
            SqlCommand mycomDTS;
            string NameAvil = "";
            string s = "";
            if (TableLock != "")
            {
                s = "TableLock = N'" + TableLock + "'";
            }
            if (FormLock != "")
            {
                if (s == "")
                    s = " FormLock = N'" + FormLock + "'";
                else
                    s += " AND FormLock = N'" + FormLock + "'";
            }
            if (IDRow != "")
            {
                if (s == "")
                    s = " IDRow = N'" + IDRow + "'";
                else
                    s += " AND IDRow = N'" + IDRow + "'";
            }
            if (State != "")
            {
                if (s == "")
                    s = " State = N'" + State + "'";
                else
                    s += " AND State = N'" + State + "'";
            }
            if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
            if (s != "")
                mycomDTS = new SqlCommand("Select * From AvailableTable Where (" + s + " AND ComputerName = N'" + Function.ComputerName + "') OR (TableLock = N'ALL' AND ComputerName = N'" + Function.ComputerName + "')", Conn.mycon);
            else
                mycomDTS = new SqlCommand("Select * From AvailableTable Where (TableLock = N'ALL' AND ComputerName = N'" + Function.ComputerName + "')", Conn.mycon);
            SqlDataReader mydr = mycomDTS.ExecuteReader();
            if (mydr.HasRows == true)
            {
                mydr.Read();
                NameAvil = mydr["ComputerName"].ToString() + " " + mydr["ComputerIP"].ToString();
                mydr.Close();
            }
            Conn.mycon.Close();
            return NameAvil;
        }
        public static void UnLockTablesSelect(string DTS)
        {

            if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
            SqlCommand mycomDTS = new SqlCommand("Delete AvailableTable Where ID IN " + DTS, Conn.mycon);
            mycomDTS.ExecuteNonQuery();
            Conn.mycon.Close();
        }

        public static void UnLockTable(string TableLock, string FormLock, string IDRow, string State)
        {
            SqlCommand mycomDTS;
            string s = "";
            if (TableLock != "")
            {
                s = "TableLock = N'" + TableLock + "'";
            }
            if (FormLock != "")
            {
                if (s == "")
                    s = " FormLock = N'" + FormLock + "'";
                else
                    s += " AND FormLock = N'" + FormLock + "'";
            }
            if (IDRow != "")
            {
                if (s == "")
                    s = " IDRow = N'" + IDRow + "'";
                else
                    s += " AND IDRow = N'" + IDRow + "'";
            }
            if (State != "")
            {
                if (s == "")
                    s = " State = N'" + State + "'";
                else
                    s += " AND State = N'" + State + "'";
            }

            if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
            mycomDTS = new SqlCommand("Delete AvailableTable Where " + s + " AND ComputerName = N'" + Function.ComputerName + "'", Conn.mycon);
            mycomDTS.ExecuteNonQuery();
            Conn.mycon.Close();
        }
        public static void UnLockAllTable()
        {
            SqlCommand mycomDTS;
            if (Conn.mycon.State == ConnectionState.Closed) Conn.mycon.Open();
            mycomDTS = new SqlCommand("Truncate TAble AvailableTable", Conn.mycon);
            mycomDTS.ExecuteNonQuery();
            Conn.mycon.Close();
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
                DataClass.LogError(ex); MessageBox.Show(ex.Message, "Error");
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
                DataClass.LogError(ex); MessageBox.Show(ex.Message, "Error");
            }
            return St;
        }
        public static void RCalc_AP_Balance_For_Vendor()
        {
            try
            {
                string str = "";

                str += " Update Vend_AP Set AP_Balance = (Select SUM(Amt) - SUM(Paid_Amt) AS Amt From Voucher Where (Vend_ID = Vend_AP.Vend_ID)) ; \n";

                if (str.Trim() != "")
                    setNonQuery(str);
            }
            catch (Exception ex)
            {
                DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void Calc_INVC_Points(string INVC_ID)
        {
            try
            {
                if (ReturnRecordNameByID("Select Status From Invoice Where INVC_ID ='" + INVC_ID + "'") == Function.Invoice_Status.Reversing.ToString())
                {
                    DataTable dt = RetrieveData("Select * From Customer_Points Where INVC_ID = (Select Reverse From Invoice Where INVC_ID = '" + INVC_ID + "') ");
                    if (dt.Rows.Count > 0)
                    {
                        int Point_Used = 0; int.TryParse(dt.Rows[0]["Used"].ToString(), out Point_Used);
                        if (Point_Used == 0)
                        {
                            string str = " Update Customer_Points Set Voided = 1 Where INVC_ID = " + dt.Rows[0]["INVC_ID"].ToString() + " ; \n ";
                            setNonQuery(str);
                            return;
                        }
                    }
                    else
                        return;
                }

                DataTable dtitm = DataClass.RetrieveData("SELECT II.Item_ID, It.Dept_ID, It.Class_ID, It.SClass_ID, (II.Qty * II.Price) AS Price, II.INVC_ID, I.Cust_ID, I.Store_ID, I.SCom_ID,  { fn IFNULL ((SELECT SUM(Disc_Amt) AS Discount FROM dbo.Invoice_Tender AS InvT WHERE (INVC_ID = II.INVC_ID)), 0) } AS Discount FROM dbo.Invoice AS I INNER JOIN dbo.Invoice_Item AS II ON I.INVC_ID = II.INVC_ID LEFT OUTER JOIN dbo.Items AS It ON II.Item_ID = It.Item_ID WHERE (II.Item_ID <> 0) AND (I.Cust_ID <> 0) AND (II.Price <> 0) AND (I.Post = 1) AND (II.INVC_ID = " + INVC_ID + ") ");
                if (dtitm.Rows.Count == 0)
                    return;
                Int64 Cust_ID = 0; Int64.TryParse(dtitm.Rows[0]["Cust_ID"].ToString(), out Cust_ID);

                DataTable dtPoints = DataClass.RetrieveData("SELECT P.Point_ID, P.Code, P.Remove_When_Disc, P.Start_Point, P.Max_Point, P.Valid_Days, PIt.Point_Type, PIt.ICS_ID, PIt.Point_For_One FROM dbo.Points AS P INNER JOIN dbo.Points_Category AS PIt ON P.Point_ID = PIt.Point_ID Where P.SCom_ID = " + dtitm.Rows[0]["SCom_ID"].ToString() + " AND P.Cancel = 0 AND P.Store_ID IN  (" + dtitm.Rows[0]["Store_ID"].ToString() + ",0) ORDER BY PIt.Serial");
                if (dtPoints.Rows.Count > 0)
                {
                    if ((double)dtitm.Rows[0]["Discount"] > 0 && (bool)dtPoints.Rows[0]["Remove_When_Disc"])
                        return;
                    double points = 0;
                    for (int i = 0; i < dtitm.Rows.Count; i++)
                    {
                        for (int p = 0; p < dtPoints.Rows.Count; p++)
                        {
                            if ((dtPoints.Rows[p]["Point_Type"].ToString() == Function.Point_Type.Items.ToString() && dtitm.Rows[i]["Item_ID"].ToString() == dtPoints.Rows[p]["ICS_ID"].ToString()) || (dtPoints.Rows[p]["Point_Type"].ToString() == Function.Point_Type.Departments.ToString() && dtitm.Rows[i]["Dept_ID"].ToString() == dtPoints.Rows[p]["ICS_ID"].ToString()) || (dtPoints.Rows[p]["Point_Type"].ToString() == Function.Point_Type.Classes.ToString() && dtitm.Rows[i]["Class_ID"].ToString() == dtPoints.Rows[p]["ICS_ID"].ToString()) || (dtPoints.Rows[p]["Point_Type"].ToString() == Function.Point_Type.SubClasses.ToString() && dtitm.Rows[i]["SClass_ID"].ToString() == dtPoints.Rows[p]["ICS_ID"].ToString()))
                            {
                                points += double.Parse(dtPoints.Rows[p]["Point_For_One"].ToString()) * double.Parse(dtitm.Rows[i]["Price"].ToString());
                                break;
                            }
                        }
                    }
                    int ret = 1;
                    if (points < 0)
                    {
                        ret = -1;
                        points = points * ret;
                    }
                    if ((int)dtPoints.Rows[0]["Start_Point"] > points)
                        points = 0;
                    if ((int)dtPoints.Rows[0]["Max_Point"] < points)
                        points = (int)dtPoints.Rows[0]["Max_Point"];

                    int point = (int)points;
                    point = point * ret;

                    string str = "";
                    if (point > 0)
                    {
                        int Point_Used = 0; int.TryParse(ReturnRecordNameByID("Select Used From Customer_Points Where INVC_ID ='" + INVC_ID + "'"), out Point_Used);
                        str += " Delete Customer_Points Where INVC_ID = " + INVC_ID + " ; \n ";
                        str += " Update Invoice Set Point_ID = " + dtPoints.Rows[0]["Point_ID"].ToString() + " Where INVC_ID = " + INVC_ID + " ; \n ";
                        str += " Insert Into Customer_Points (Cust_ID, Point_ID, INVC_ID, Points, Used, Expiry_Date, CreateDate, ModifiedDate, User_ID, Voided) Values (" + Cust_ID.ToString() + ", " + dtPoints.Rows[0]["Point_ID"].ToString() + ", " + INVC_ID + ", " + point.ToString() + ", " + Point_Used.ToString() + ", GetDate() + " + dtPoints.Rows[0]["Valid_Days"].ToString() + ", GetDate(), GetDate(), " + Function.User_ID.ToString() + ",0) ; \n ";
                        setNonQuery(str);
                    }
                    else if (point < 0)
                    {
                        int Remin_Points = point * -1;
                        DataTable dt = DataClass.RetrieveData("Select Cust_ID,INVC_ID,Points,Used,(Points - Used) AS Remin_Points From Customer_Points Where Voided = 0 AND (Points - Used) > 0 AND Expiry_Date >= GetDate() AND Cust_ID = " + Cust_ID);
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                int val = 0; int.TryParse(dt.Rows[i]["Remin_Points"].ToString(), out val);
                                if (val > Remin_Points)
                                    val = Remin_Points;
                                str += " Update Customer_Points Set Used = Used + " + val + " , ModifiedDate = GetDate(),User_ID = " + Function.User_ID.ToString() + " Where Cust_ID = " + Cust_ID + " AND INVC_ID = " + dt.Rows[i]["INVC_ID"].ToString() + " ; \n ";
                                Remin_Points = Remin_Points - val;
                                if (Remin_Points <= 0)
                                    break;
                            }
                            str += " Update Invoice Set Point_ID = " + dtPoints.Rows[0]["Point_ID"].ToString() + " Where INVC_ID = " + INVC_ID + " ; \n ";
                            if (str.Trim() != "")
                                DataClass.setNonQuery(str);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void LogError(Exception ex)
        {
            StreamWriter SW;
            if (!File.Exists(Application.StartupPath + @"\" + "LogError_" + Application.ProductName + ".csv"))
                SW = File.CreateText(Application.StartupPath + @"\" + "LogError_" + Application.ProductName + ".csv");
            else
                SW = File.AppendText(Application.StartupPath + @"\" + "LogError_" + Application.ProductName + ".csv");
            try
            {
                string FileName = "";
                string FileLineNumber = "";
                if (ex.StackTrace.Contains(":line") && ex.StackTrace.Contains(":line"))
                {
                    FileName = ex.StackTrace.Substring(ex.StackTrace.IndexOf(" in "), (ex.StackTrace.IndexOf(":line") - ex.StackTrace.IndexOf(" in ")));
                    FileLineNumber = ex.StackTrace.Remove(0, ex.StackTrace.IndexOf(":line") + 5);
                }
                SW.WriteLine(DateTime.Now.ToString() + "," + ex.Message + "," + FileName + "," + FileLineNumber + "," + ex.TargetSite);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SW.Close();
            }
        }
        public static void NewInvoice(string INVC_ID, string INVC_NO, string INVC_TYPE, DateTime INVC_Date, string Status, Int64 Reverse, bool Post, Int64 Cust_ID, int Cashier_ID, int Seller_ID, int Store_ID, Int64 SO_ID, string Source_Type, double Amt, int MOP_ID, string MOP_Serial, DateTime MOP_Date)
        {
            try
            {
                ArrayList ItemsNames = new ArrayList();
                ArrayList ItemsValues = new ArrayList();

                ItemsNames.Add("INVC_Date");
                ItemsValues.Add(INVC_Date);

                ItemsNames.Add("Post");
                ItemsValues.Add(Post);

                ItemsNames.Add("MOP_Date");
                ItemsValues.Add(MOP_Date);

                string Str = "";
                Str += " Insert Into Invoice (INVC_ID, INVC_No, INVC_TYPE, INVC_Date, Status, Reverse, Comment, Cancelled, Hold, Post, PostedDate, Cust_ID, Cashier_ID, Seller_ID, CreateDate, ModifiedDate, User_ID, SCom_ID, Store_ID, WS, Num_Print,Point_ID,SO_ID,Source_Type) Values(" + INVC_ID.Trim() + ", " + INVC_NO.Trim() + ", '" + INVC_TYPE + "',@INVC_Date, '" + Status + "', " + Reverse.ToString().Trim() + ", '', 0, 0, @Post, GetDate(), " + Cust_ID.ToString() + ", " + Cashier_ID.ToString() + ", " + Seller_ID.ToString() + ", GetDate(), GetDate(), " + Function.User_ID.ToString() + ", " + Function.SCom_Active_ID.ToString() + ", " + Store_ID.ToString() + ", " + Function.WS.ToString() + ",0,0," + SO_ID.ToString() + ",'" + Source_Type + "') ; \n";
                Str += " Insert Into Invoice_Tender (INVC_ID, MOP_ID, Tax_Amt, SubTotal, Disc_Amt, Disc_Perc, NetTotal, Fee_Amt, Amt, Taken, Given, Paid_Total, Rimining_Total) Values(" + INVC_ID.Trim() + ",  " + MOP_ID + ", 0, " + Amt + ", 0, 0, " + Amt + ", 0, " + Amt + ", " + Amt + ", 0, " + Amt + ", 0) ; \n";
                if (Amt != 0)
                    Str += " Insert Into Invoice_MOP (INVC_ID,Serial,MOP_ID,MOP_Value,MOP_Serial,MOP_Date,Voided,Voided_Reason,CreateDate,ModifiedDate) Values (" + INVC_ID.Trim() + ", 1," + MOP_ID + "," + Amt + ",'" + MOP_Serial + "',@MOP_Date,0,'',GetDate(),GetDate()) ; \n";
                DataClass.InsertRecord(Str, ItemsNames, ItemsValues);
            }
            catch (Exception ex)
            {
                DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}