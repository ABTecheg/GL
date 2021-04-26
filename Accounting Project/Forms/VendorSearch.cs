using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Accounting_GeneralLedger
{
    public partial class VendorSearch : Form
    {
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbVendors;
        private SqlDataAdapter adaptertbVendorCategory;
        public string selectedVendorCode;
        public string NOSearch = "";
        public string ApplyCredits = "";

        public VendorSearch()
        {
            InitializeComponent();
        }

        private void txt_VendorCode_TextChanged(object sender, EventArgs e)
        {
            SearchForGivenVendor();
        }

        private void txt_VendorName_TextChanged(object sender, EventArgs e)
        {
            SearchForGivenVendor();
        }

        private void cb_VendorCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchForGivenVendor();
            if (cb_VendorCategory.Text == "<new>")
            {
                VendorsCategories at = new VendorsCategories();
                at.ShowDialog();
                cb_VendorCategory.Items.Clear();
                adaptertbVendorCategory.Fill(dbAccountingProjectDS.APVendorCategory);
                cb_VendorCategory = GeneralFunctions.FillComboBox(dbAccountingProjectDS.APVendorCategory, cb_VendorCategory, "CategoryCode","CategoryID");
            }
            if (cb_VendorCategory.Text == "Any Type")
            {
                cb_VendorCategory.SelectedIndex = -1;
                SearchForGivenVendor();
            }
        }

        private void SearchForGivenVendor()
        {
            if (txt_VendorCode.Text == "" && txt_VendorName.Text == "" && cb_VendorCategory.Text == "")
                GridRefresh();
            else if (txt_VendorCode.Text != "")
            {
                DataView dv = new DataView(dbAccountingProjectDS.APVendors);
                dv.RowFilter = CreateFilterExpression();
                dgv.DataSource = dv;
                dgv.Refresh();
            }
            else if (cb_VendorCategory.Text != "")
            {
                DataView dv = new DataView(dbAccountingProjectDS.APVendors);
                dv.RowFilter = CreateFilterExpression();
                dgv.DataSource = dv;
                dgv.Refresh();
            }
            else if (txt_VendorName.Text != "")
            {
                DataView dv = new DataView(dbAccountingProjectDS.APVendors);
                dv.RowFilter = CreateFilterExpression();
                dgv.DataSource = dv;
                dgv.Refresh();
            }
        }

        private string CreateFilterExpression()
        {
            string filterExpression = "";
            //Vendor Code Only 
            if (txt_VendorCode.Text != "" && txt_VendorName.Text == "" && cb_VendorCategory.Text == "")
                filterExpression = "VendorCode like '" + txt_VendorCode.Text + "%'";

            //Vendor Category Only 
            else if (txt_VendorCode.Text == "" && txt_VendorName.Text == "" && cb_VendorCategory.Text != "")
                filterExpression = "VendorCategory = '" + cb_VendorCategory.Text + "'";

            //Vendor Name Only 
            else if (txt_VendorCode.Text == "" && txt_VendorName.Text != "" && cb_VendorCategory.Text == "")
                filterExpression = "VendorName like '%" + txt_VendorName.Text + "%'";

            //Vendor Code and Name 
            else if (txt_VendorCode.Text != "" && txt_VendorName.Text != "" && cb_VendorCategory.Text == "")
                filterExpression = "VendorCode like '" + txt_VendorCode.Text + "%' and VendorName like '%" + txt_VendorName.Text + "%'";

            //Vendor Code and Category 
            else if (txt_VendorCode.Text != "" && txt_VendorName.Text == "" && cb_VendorCategory.Text != "")
                filterExpression = "VendorCode like '" + txt_VendorCode.Text + "%' and VendorCategory = '" + cb_VendorCategory.Text + "'";

            //Vendor Name and Category 
            else if (txt_VendorCode.Text == "" && txt_VendorName.Text != "" && cb_VendorCategory.Text != "")
                filterExpression = "VendorCategory = '" + cb_VendorCategory.Text + "' and VendorName like '%" + txt_VendorName.Text + "%'";

            //All 
            else if (txt_VendorCode.Text != "" && txt_VendorName.Text != "" && cb_VendorCategory.Text != "")
                filterExpression = "VendorCode like '" + txt_VendorCode.Text + "%' and VendorCategory = '" + cb_VendorCategory.Text + "'and VendorName like '%" + txt_VendorName.Text + "%'";

         
            return filterExpression;
        }

        private void VendorSearch_Load(object sender, EventArgs e)
        {
            if (GeneralFunctions.Ckecktag("81") != "M")
                btn_NewVendor.Visible = false;
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            if (ApplyCredits == "Credits")
            {
                if (NOSearch != "" )
                {
                    adaptertbVendors = new SqlDataAdapter("Select * From APVendors Where VendorCode IN " + NOSearch , sqlcon);
                }

                else
                    adaptertbVendors = new SqlDataAdapter("Select * from APVendors", sqlcon);
            }
            else
                adaptertbVendors = new SqlDataAdapter("Select * from APVendors", sqlcon);
            adaptertbVendorCategory = new SqlDataAdapter("Select * from APVendorCategory", sqlcon);
            adaptertbVendors.Fill(dbAccountingProjectDS.APVendors);
            adaptertbVendorCategory.Fill(dbAccountingProjectDS.APVendorCategory);
            if (!GeneralFunctions.SubTypesloaded)
            {
                SqlConnection sqlcon10 = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlcon10.Open();
                SqlCommand command10 = new SqlCommand("Select AccountSubType From  GeneralSetup", sqlcon10);
                SqlCommand command11 = new SqlCommand("Select FirstSub From GeneralSetup", sqlcon10);
                SqlCommand command12 = new SqlCommand("Select SecondSub From GeneralSetup", sqlcon10);
                SqlCommand command13 = new SqlCommand("Select ThirdSub From GeneralSetup", sqlcon10);
                SqlCommand command14 = new SqlCommand("Select FourthSub From GeneralSetup", sqlcon10);
                int AccountSubTypeNumber;
                if (command10.ExecuteScalar() != DBNull.Value)
                {
                    AccountSubTypeNumber = Convert.ToInt32(command10.ExecuteScalar());
                    if (AccountSubTypeNumber == 2)
                    {
                        GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()), Convert.ToInt32(command12.ExecuteScalar()));
                        GeneralFunctions.SubTypesloaded = true;
                    }
                    if (AccountSubTypeNumber == 3)
                    {
                        GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()), Convert.ToInt32(command12.ExecuteScalar()), Convert.ToInt32(command13.ExecuteScalar()));
                        GeneralFunctions.SubTypesloaded = true;
                    }
                    if (AccountSubTypeNumber == 4)
                    {
                        GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()), Convert.ToInt32(command12.ExecuteScalar()), Convert.ToInt32(command13.ExecuteScalar()), Convert.ToInt32(command14.ExecuteScalar()));
                        GeneralFunctions.SubTypesloaded = true;
                    }

                }
            }
            cb_VendorCategory = GeneralFunctions.FillComboBox(dbAccountingProjectDS.APVendorCategory, cb_VendorCategory, "CategoryCode", "CategoryID");
            if (GeneralFunctions.Ckecktag("79") != "M")
                cb_VendorCategory.Items.Remove("<new>");
            cb_VendorCategory.Items.Insert(0, "Any Type");
        }

        private void GridRefresh()
        {
            adaptertbVendors.Fill(dbAccountingProjectDS.APVendors);
            dgv.DataSource = dbAccountingProjectDS.APVendors;
            dgv.Refresh();
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow r = (DataGridViewRow)dgv.SelectedRows[0];
                selectedVendorCode = r.Cells["VendorCode"].Value.ToString();
                this.Close();
            }
        }

        private void btn_NewVendor_Click(object sender, EventArgs e)
        {
            Vendors vendorAdd = new Vendors();
            vendorAdd.ShowDialog();
            GridRefresh();
            SearchForGivenVendor();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}