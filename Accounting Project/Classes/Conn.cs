using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Globalization;



namespace Accounting_GeneralLedger
{
    public static class Conn
    {
        public static SqlConnection mycon;
        private static string con = "";
        public static bool MyCon()
        {
            bool flage = false;
            FileStream fs;
            try
            {
                fs = File.Open(Application.StartupPath + @"\" + "MyCon.txt", FileMode.Open, FileAccess.ReadWrite);
                StreamReader sr = new StreamReader(fs);
                con = sr.ReadToEnd();
                sr.Close();
                fs.Close();
                mycon = new SqlConnection(con);
                mycon.Open();
                mycon.Close();
                GeneralFunctions.ConnectionString = con;
                flage = true;

                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                connectionStringsSection.ConnectionStrings["Accounting_GeneralLedger.Properties.Settings.ConnStr"].ConnectionString = con;
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
            }
            catch
            {
                flage = CreateCon();
                if (flage == true)
                {
                    fs = File.Open(Application.StartupPath + @"\" + "MyCon.txt", FileMode.Create, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(con);
                    sw.Close();
                    fs.Close();
                }
            }
            return flage;
        }
        private static bool CreateCon()
        {
            bool flage = false;
            while (true)
            {
                try
                {
                    try
                    {
                        mycon = new SqlConnection(con);
                    }
                    catch
                    {
                        con = con.Remove(0, con.IndexOf(";") + 1);
                        mycon = new SqlConnection(con);
                    }
                    mycon.Open();
                    mycon.Close();
                    flage = true;
                    break;
                }
                catch
                {
                    ADODB.Connection adodbConnection =
                   new ADODB.Connection();
                    object connection = (object)adodbConnection;

                    MSDASC.DataLinks dlg = new MSDASC.DataLinks();
                    //dlg.PromptEdit(ref connection);
                    if (dlg.PromptEdit(ref connection))
                        con = adodbConnection.ConnectionString.ToString();
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("The connection is field, Do you want exit program ?", "Installment Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            return flage = false;
                    }
                }
            }

            return flage;
        }
    }
}
