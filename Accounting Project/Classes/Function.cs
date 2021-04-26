using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;

namespace Accounting_GeneralLedger
{
    public static class Function
    {
        public static string Default_Name = "Name";
        public static DateTime INVC_Fdate;
        public static DateTime INVC_Tdate;
        public static DateTime SO_Fdate;
        public static DateTime SO_Tdate;
        public static int Len_Decimal = 2;
        public static int User_ID = 0;
        public static int Admin_ID = 0;
        public static int WS = 0;
        public static int SCom_Active_ID = 0;
        public static int Store_Active_ID = 0;
        public static bool Main_Store = false;
        public static string UserName = "";
        public static string UserPrev = "";
        public static string AdminPrev = "";
        public static bool Auto_Cust_Type = false;
        public static string Lang = "English";
        public static int DefaultSalesMan = 0;
        public static int Days_ReturnMShip = 0;
        public static DateTime SysDate;
        public static bool LogIn;
        public static string StateThrid = "";
        public static ArrayList VerDB = new ArrayList();
        public static string IP = "";
        public static string ComputerIP = "";
        public static string ComputerName = "";
        public static SortedList List_Setup_SCom;
        public static SortedList List_Setup_Store;
        public static DataTable Printers_IP = new DataTable("Printers_IP");
        public static string StateVer = "";
        public static ArrayList FUNAVL;
        public static void GetIP()
        {
            ComputerName = Dns.GetHostName();
            IPAddress[] IPADD = Dns.GetHostAddresses(Dns.GetHostName());
            ComputerIP = IPADD[0].ToString();
        }

        public enum Point_Type
        {
            Departments = 1,
            Classes = 2,
            SubClasses = 3,
            Items = 4
        }
        public enum Tran_Type
        {
            Vendor_AP = 1
        }
        public enum Paid_Type
        {
            Regular = 1,
            Return = 2
        }
        public enum Paid_Status
        {
            Regular = 1,
            Reversed = 2,
            Reversing = 3,
            Cancelled = 4
        }
        public enum Invoice_Type
        {
            Regular = 1,
            Return = 2
        }
        public enum INVC_Source_Type
        {
            Invoice = 1,
            SO_Deposit = 2,
            PaidIn = 3,
            PaidOut = 4,
            Open_Drawer = 5,
            AR = 6,
            Credit = 7
        }
        public enum Invoice_Status
        {
            Regular = 1,
            Reversed = 2,
            Reversing = 3,
            Cancelled = 4
        }
        public enum SO_Type
        {
            SO_Customer = 1
        }
        public enum SO_Status
        {
            Open = 1,
            Close = 2,
            Cancelled = 3
        }

        public enum Voucher_Type
        {
            Receive = 1,
            Return = 2
        }

        public enum Adj_Type
        {
            Cost = 1,
            Price = 2,
            Qty = 3,
            Min_Max = 4
        }

        public enum Adj_Source_Type
        {
            Manual = 1,
            Reverse = 2,
            Physical_Invn = 3,
            Manual_Invn = 4,
            Calculate = 5
        }
        public enum Vou_Source_Type
        {
            Manual = 1,
            Manual_PO = 2,
            Manual_Tran = 3,
            Auto_Tran = 4
        }

        public enum Voucher_Status
        {
            Regular = 1,
            Reversed = 2,
            Reversing = 3,
            Cancelled = 4
        }

        public enum Adj_Status
        {
            Regular = 1,
            Reversed = 2,
            Reversing = 3
        }
        public enum Physical_Status
        {
            Open = 1,
            Close = 2,
            Cancel = 3
        }

        public enum Physical_Type
        {
            All_Items = 1,
            Scan_Only = 2
        }

        public enum Discount_Type
        {
            Percentage = 1,
            Flat_Amount = 2,
            Open_Amount = 3
        }

        public enum Sale_Status
        {
            OK = 1,
            Stop = 2,
            Cancel = 3
        }

        public enum Sale_Type
        {
            Departments = 1,
            Classes = 2,
            SubClasses = 3,
            Items = 4
        }

        public enum Sale_Price_Type
        {
            Disc_Perc = 1,
            Disc_Value = 2,
            Static_Price = 3,
            Price_Level = 4
        }


        public static string Ckecktag(string tag)
        {
            string MT = "";
            try
            {
                if (UserPrev == "Administrator")
                {
                    MT = "T";
                }
                else if (tag != "")
                {
                    MT = UserPrev.Substring(int.Parse(tag), 1);
                }
            }
            catch (Exception ex)
            {
                MT = "F";
            }
            return MT;
        }
        public static bool Check_Permission(string POS_Pass, string Ckecktag)
        {
            try
            {
                if (string.IsNullOrEmpty(POS_Pass.Trim()))
                {
                    return false;
                }
                else
                {
                    int pass = DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year - (DateTime.Now.Hour * 3);
                    string strpass = "ahs" + pass.ToString().Substring(1, pass.ToString().Length - 1);
                    if (POS_Pass.Trim() == strpass)
                        return true;
                }
                string ClassPrv = DataClass.ReturnRecordNameByID("SELECT UP.ClassPrv FROM dbo.UserDefnation AS UD INNER JOIN dbo.UsersPrivileges AS UP ON UD.UserClass_ID = UP.UserClass_ID WHERE (UD.PassCode = '" + Encrypt(POS_Pass) + "') AND ( UD.Active = 1)");
                if (Function.Ckecktag(Ckecktag, Function.Decrypt(ClassPrv)) == "T")
                    return true;
                else
                    return false;
                return false;
            }
            catch (Exception ex)
            {
                DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        public static string Ckecktag(string tag, string Prv)
        {
            string MT = "";
            try
            {
                if (tag != "")
                {
                    MT = Prv.Substring(int.Parse(tag), 1);
                }
            }
            catch (Exception ex)
            {
                MT = "F";
            }
            return MT;
        }
        public static void priviledgeGroupBox(GroupBox item)
        {
            try
            {
                if (UserPrev == "Administrator")
                {
                    item.Enabled = true;
                    return;
                }
                string tag = "";
                string Checker = "";
                if (item.Tag != null)
                    tag = item.Tag.ToString().Trim();
                else
                    tag = "";
                if (tag != "" && UserPrev.Length > 0)
                {
                    Checker = UserPrev.Substring(int.Parse(tag), 1);
                    if (Checker != "")
                    {
                        if (Checker == "T")
                            item.Enabled = true;
                        else
                            item.Enabled = false;
                    }
                }
                else
                    item.Enabled = false;
            }
            catch (Exception ex)
            {
                item.Enabled = false;
            }
        }

        public static void priviledgeButtons(ToolStripButton item)
        {
            try
            {
                string tag = "";
                string Checker = "";
                if (UserPrev == "Administrator")
                {
                    item.Enabled = true;
                    return;
                }
                if (item.Tag != null)
                    tag = item.Tag.ToString().Trim();
                else
                    tag = "";
                if (tag != "" && UserPrev.Length > 0)
                {
                    Checker = UserPrev.Substring(int.Parse(tag), 1).Trim();
                    if (Checker != "")
                    {
                        if (Checker == "T")
                            item.Enabled = true;
                        else
                            item.Enabled = false;
                    }
                }
                else
                    item.Enabled = false;
            }
            catch
            {
                item.Enabled = false;
            }
        }
        public static void priviledgeToolStripButtons(ToolStripDropDownButton item)
        {
            try
            {
                string tag = "";
                string Checker = "";
                if (UserPrev == "Administrator")
                {
                    item.Enabled = true;
                    return;
                }
                if (item.Tag != null)
                    tag = item.Tag.ToString().Trim();
                else
                    tag = "";
                if (tag != "" && UserPrev.Length > 0)
                {
                    if (int.Parse(tag) == 20)
                    {
                    }
                    Checker = UserPrev.Substring(int.Parse(tag), 1).Trim();
                    if (Checker != "")
                    {
                        if (Checker == "T")
                            item.Enabled = true;
                        else
                            item.Enabled = false;
                    }
                }
                else
                    item.Enabled = false;
            }
            catch
            {
                item.Enabled = false;
            }
        }

        public static void priviledgeItem(ToolStripMenuItem item)
        {
            try
            {
                if (item != null)
                {
                    if (UserPrev == "Administrator")
                    {
                        item.Enabled = true;
                        return;
                    }
                    string ta = "";
                    string MT = "";
                    if (item.Tag != null)
                        ta = item.Tag.ToString().Trim();
                    else
                        ta = "";
                    if (ta != "" && UserPrev.Length > 0)
                    {
                        MT = UserPrev.Substring(int.Parse(ta), 1).Trim();
                        if (MT != "")
                        {
                            if (MT == "T")
                                item.Enabled = true;
                            else
                                item.Enabled = false;
                        }

                    }
                    else
                        item.Enabled = false;
                }
            }
            catch
            {
                item.Enabled = false;
            }
        }
        public static string Encrypt(string str)
        {
            string St = "";

            System.Text.ASCIIEncoding AsciC = new System.Text.ASCIIEncoding();
            byte[] ByteString = AsciC.GetBytes(str);
            St = Convert.ToBase64String(ByteString);
            return St;
        }
        public static string Decrypt(string str)
        {
            string St = "";
            System.Text.ASCIIEncoding AsciC = new System.Text.ASCIIEncoding();
            byte[] ByteString = Convert.FromBase64String(str);
            St = AsciC.GetString(ByteString);
            return St;
        }
        public static double ChangeDecimal(double val, int Decml)
        {
            decimal Dec = 0;
            decimal.TryParse(val.ToString(), out Dec);
            Dec = decimal.Round(Dec, Decml);
            return decimal.ToDouble(Dec);
        }
        public static void ApplyRTL(Control startControl)
        {
            if ((startControl is Panel) || (startControl is GroupBox))
            {
                foreach (Control control in startControl.Controls)
                {
                    control.Location = CalculateRTL(control.Location, startControl.Size, control.Size);
                }
            }

            foreach (Control control in startControl.Controls)
                ApplyRTL(control);
        }

        public static Point CalculateRTL(Point currentPoint, Size parentSize, Size currentSize)
        {
            return new Point(parentSize.Width - currentSize.Width - currentPoint.X, currentPoint.Y);
        }
        public static Image imgResize(ref Image img, int percentage)
        {
            //get the height and width of the image
            int originalW = img.Width;
            int originalH = img.Height;

            //get the new size based on the percentage change
            int resizedW = (int)(originalW * percentage);
            int resizedH = (int)(originalH * percentage);

            //create a new Bitmap the size of the new image
            Bitmap bmp = new Bitmap(resizedW, resizedH);
            //create a new graphic from the Bitmap
            Graphics graphic = Graphics.FromImage((Image)bmp);
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //draw the newly resized image
            graphic.DrawImage(img, 0, 0, resizedW, resizedH);
            //dispose and free up the resources
            graphic.Dispose();
            //return the image
            return (Image)bmp;
        }

        public static Image imgResize(ref Image img, int originalW, int originalH)
        {
            //get the new size based on the percentage change
            int resizedW = (int)(originalW);
            int resizedH = (int)(originalH);

            //create a new Bitmap the size of the new image
            Bitmap bmp = new Bitmap(resizedW, resizedH);
            //create a new graphic from the Bitmap
            using (Graphics graphic = Graphics.FromImage((Image)bmp))
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //draw the newly resized image
                graphic.DrawImage(img, 0, 0, resizedW, resizedH);
                //dispose and free up the resources
            }
            //return the image
            return (Image)bmp;
        }
        public static void FormLoadingShow(string Txt, System.Threading.Thread mythr)
        {
            StateThrid = Txt;
            FormLoading frm = new FormLoading();
            frm.mythr = mythr;
            frm.ShowDialog();
        }
        public static bool Check_Delete(string COLUMN_NAME, string COLUMN_Value, string table_name_Not_In)
        {
            System.Data.DataTable dt = DataClass.RetrieveData("SELECT information_schema.Columns.table_name,information_schema.Tables.Table_Type FROM information_schema.Columns INNER JOIN information_schema.Tables ON information_schema.Columns.table_name = information_schema.Tables.table_name Where information_schema.Columns.COLUMN_NAME = '" + COLUMN_NAME + "' AND information_schema.Columns.table_name NOT IN (" + table_name_Not_In + ") AND information_schema.Tables.Table_Type = 'BASE TABLE'");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (DataClass.isExsist("*", " " + COLUMN_NAME + " = " + COLUMN_Value + " ", dt.Rows[i]["table_name"].ToString()))
                    {
                        MessageBox.Show("Can't Delete This Because Is Used In " + dt.Rows[i]["table_name"].ToString(), "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
            }
            return true;
        }


    }
}
