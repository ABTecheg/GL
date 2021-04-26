using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient ;
using System.Windows.Forms;      

namespace Accounting_GeneralLedger
{

    public class GeneralFunctions2
    {
        public SqlConnection xConn;

        private SqlCommand MyCom;
        private SqlDataReader MyDr;

        public  GeneralFunctions2()
        { 
                xConn = new SqlConnection();
                xConn.ConnectionString = Accounting_GeneralLedger.Properties.Settings.Default.ConnStr;
        }

        public  string getLastNumber(string tableName, string filedName)
        {
            string x = "";
            MyCom = new SqlCommand();
            MyDr = null;
            try
            {
                MyCom.CommandText = "Select TOP 1 " + filedName + " from " + tableName + " Order By " + filedName + " DESC ";
                MyCom.CommandType = CommandType.Text;
                MyCom.Connection = this.xConn;
                xConn.Open() ;
                MyDr =  MyCom.ExecuteReader();
                while(MyDr.Read())
                    x = MyDr[filedName].ToString();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            { xConn.Close(); }

            if (x == null )
                return "";
            else
                return x;

        }

    }
}
