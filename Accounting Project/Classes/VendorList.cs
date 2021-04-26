using System; using Accounting_GeneralLedger.Report;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Accounting_GeneralLedger
{
    public static class VendorList
    {
        private static SqlConnection sqlcon;
        private static SqlDataAdapter adapterVendor;
        private static SqlDataAdapter adapterContact;
        private static SqlDataAdapter adapterCategory;
        private static SqlDataAdapter adapterVendorList;
        private static SqlCommandBuilder commbVendorList;
        private static dbAccountingProjectDS dbAccountingProjectDS;
        public static void FillVendorList()
        {
            SqlConnection sqlconndelete = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconndelete.Open();
            SqlCommand sqlcommandDeletetran = new SqlCommand("Delete From RptVendorList", sqlconndelete);
            SqlDataReader drDeletetran = sqlcommandDeletetran.ExecuteReader();
            drDeletetran.Close();
            sqlconndelete.Close();
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            dbAccountingProjectDS = new dbAccountingProjectDS();
            adapterVendor = new SqlDataAdapter("Select * from APVendors", sqlcon);
            adapterContact = new SqlDataAdapter("Select * from APVendorContacts", sqlcon);
            adapterCategory = new SqlDataAdapter("Select * from APVendorCategory", sqlcon);
            adapterVendorList = new SqlDataAdapter("Select * from RptVendorList", sqlcon);
            commbVendorList = new SqlCommandBuilder(adapterVendorList);
            adapterVendor.Fill(dbAccountingProjectDS.APVendors);
            adapterContact.Fill(dbAccountingProjectDS.APVendorContacts);
            adapterCategory.Fill(dbAccountingProjectDS.APVendorCategory);
            adapterVendorList.Fill(dbAccountingProjectDS.RptVendorList);
            DataRow r;
            DataRow[] rs;
            DataRow[] rc;
            if (dbAccountingProjectDS.APVendors.Rows.Count > 0)
            {
                for (int i = 0; i < dbAccountingProjectDS.APVendors.Rows.Count; i++)
                {
                    rs = dbAccountingProjectDS.APVendorContacts.Select("VendorCode = '" + dbAccountingProjectDS.APVendors.Rows[i]["VendorCode"].ToString() + "'");
                    if (rs.Length != 0)
                    {
                        for (int c = 0; c < rs.Length; c++)
                        {

                            r = dbAccountingProjectDS.RptVendorList.NewRow();
                            r["VendorCode"] = dbAccountingProjectDS.APVendors.Rows[i]["VendorCode"];
                            r["VendorName"] = dbAccountingProjectDS.APVendors.Rows[i]["VendorName"];
                            r["VendorCity"] = dbAccountingProjectDS.APVendors.Rows[i]["VendorCity"];
                            r["VendorPhone"] = dbAccountingProjectDS.APVendors.Rows[i]["VendorPhone"];
                            r["VendorCountry"] = dbAccountingProjectDS.APVendors.Rows[i]["VendorCountry"];
                            r["VendorFax"] = dbAccountingProjectDS.APVendors.Rows[i]["VendorFax"];
                            r["VendorTermID"] = dbAccountingProjectDS.APVendors.Rows[i]["VendorTermID"];
                            r["VendorStatus"] = dbAccountingProjectDS.APVendors.Rows[i]["VendorStatus"];
                            r["VendorAddress"] = dbAccountingProjectDS.APVendors.Rows[i]["VendorAddress"];
                            rc = dbAccountingProjectDS.APVendorCategory.Select("CategoryCode = '" + dbAccountingProjectDS.APVendors.Rows[i]["VendorCategory"].ToString() + "'");
                            if (rc.Length != 0)
                            {
                                r["CategoryDescription"] = dbAccountingProjectDS.APVendorCategory.Rows[0]["CategoryDescription"];
                            }
                            else
                                r["CategoryDescription"] = "";
                            r["ContactName"] = rs[c]["ContactName"];
                            r["ContactMobile"] = rs[c]["ContactMobile"];
                            r["ContactEmail"] = rs[c]["ContactEmail"];
                            dbAccountingProjectDS.RptVendorList.Rows.Add(r);
                        }
                    }
                    else
                    {
                        r = dbAccountingProjectDS.RptVendorList.NewRow();
                        r["VendorCode"] = dbAccountingProjectDS.APVendors.Rows[i]["VendorCode"];
                        r["VendorName"] = dbAccountingProjectDS.APVendors.Rows[i]["VendorName"];
                        r["VendorCity"] = dbAccountingProjectDS.APVendors.Rows[i]["VendorCity"];
                        r["VendorPhone"] = dbAccountingProjectDS.APVendors.Rows[i]["VendorPhone"];
                        r["VendorCountry"] = dbAccountingProjectDS.APVendors.Rows[i]["VendorCountry"];
                        r["VendorFax"] = dbAccountingProjectDS.APVendors.Rows[i]["VendorFax"];
                        r["VendorTermID"] = dbAccountingProjectDS.APVendors.Rows[i]["VendorTermID"];
                        r["VendorStatus"] = dbAccountingProjectDS.APVendors.Rows[i]["VendorStatus"];
                        r["VendorAddress"] = dbAccountingProjectDS.APVendors.Rows[i]["VendorAddress"];
                        rc = dbAccountingProjectDS.APVendorCategory.Select("CategoryCode = '" + dbAccountingProjectDS.APVendors.Rows[i]["VendorCategory"].ToString() + "'");
                        if (rc.Length != 0)
                        {
                            r["CategoryDescription"] = dbAccountingProjectDS.APVendorCategory.Rows[0]["CategoryDescription"];
                        }
                        else
                            r["CategoryDescription"] = "";
                        r["ContactName"] = "";
                        r["ContactMobile"] = "";
                        r["ContactEmail"] = "";
                        dbAccountingProjectDS.RptVendorList.Rows.Add(r);
                    }
                    

                }
                update();
            }
        }
        private static void update()
        {
            adapterVendorList.Update(dbAccountingProjectDS.RptVendorList);
            dbAccountingProjectDS.AcceptChanges();
        }

    }
}
