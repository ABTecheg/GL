using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Win32;
using System.IO;

namespace Accounting_GeneralLedger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool alreadyexist;
            Mutex mutex = new Mutex(true, "Star_Financial", out alreadyexist);
            if (!alreadyexist)
            {
                MessageBox.Show("Application Already Running", "Warning");
                return;
            }
            GC.KeepAlive(mutex);
            DateTime dt = new DateTime();
            try
            {
                dt = DateTime.Parse("12/31/2000");
                GeneralFunctions.Format_Date = "{0:MM/dd/yyyy}";
                //if (DateTime.Now > DateTime.Parse("10/31/2016"))
                //{
                //    MessageBox.Show("Please Check System", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
            }
            catch
            {
                dt = DateTime.Parse("31/12/2000");
                GeneralFunctions.Format_Date = "{0:dd/MM/yyyy}";
                //if (DateTime.Now > DateTime.Parse("31/10/2016"))
                //{
                //    MessageBox.Show("Please Check System", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Function.FUNAVL = new System.Collections.ArrayList();
            try
            {
                if (File.Exists(Application.StartupPath + @"\" + "Customer_Name.txt"))
                {
                    FileStream fs = File.Open(Application.StartupPath + @"\" + "Customer_Name.txt", FileMode.Open, FileAccess.ReadWrite);
                    StreamReader sr = new StreamReader(fs);
                    Function.StateVer = sr.ReadToEnd();
                    sr.Close();
                    fs.Close();
                }
            }
            catch { }
            try
            {
                string guid = ((System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), true))[0] as System.Runtime.InteropServices.GuidAttribute).Value.ToString();
                dllCryptoMT.FrmKey.CheckAvailability(guid, "eltohamy@advbtech.com", "+224144668", "CrYpToMtFoRaHs*2", ref Function.StateVer, ref Function.FUNAVL);
                if (dllCryptoMT.FrmKey.Availability == false)
                    return;
            }
            catch { return; }

            GeneralFunctions.GetIP();
            frmStrartUp frm = new frmStrartUp();
            frm.ShowDialog();

            UserLogIn lFrm = new UserLogIn();
            lFrm.ShowDialog();
            if (lFrm.DialogResult == DialogResult.OK)
            {
                Application.Run(new GLInterface());
            }
            lFrm.Close();
        }
 
    }
}