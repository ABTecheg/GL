using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Accounting_GeneralLedger
{
    public partial class SearchCustomer : Form
    {
        public SearchCustomer()
        {
            InitializeComponent();
        }
        private SqlConnection sqlcon;
        private SqlDataAdapter adapterCust;
        public string selectedAccountCode ;
        public string selectedAccountName;
        public string ApplyCredits = "";
        public string NOSearch = "";
        private DataTable dt;
        void SearchCustomer_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dgv.DataSource = dt;
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            if (ApplyCredits == "Credits")
            {
                if (NOSearch != "")
                {
                    adapterCust = new SqlDataAdapter("Select AccountCode,AccoutName AS AccountName,Status From ARCustomerMaintainance Where AccountCode IN " + NOSearch, sqlcon);
                }

                else
                    adapterCust = new SqlDataAdapter("Select AccountCode,AccoutName AS AccountName,Status from ARCustomerMaintainance", sqlcon);
            }
            else
                adapterCust = new SqlDataAdapter("Select AccountCode,AccoutName AS AccountName,Status from ARCustomerMaintainance", sqlcon);
            dt.Clear();
            adapterCust.Fill(dt);
            selectedAccountCode = "";
            selectedAccountName = "";
        }

        private void txt_AccountCode_TextChanged(object sender, EventArgs e)
        {

                Fillter();

        }

        private void txt_AccountName_TextChanged(object sender, EventArgs e)
        {

                Fillter();

        }

        private void cb_Status_SelectedIndexChanged(object sender, EventArgs e)
        {

                Fillter();

        }
        private void Fillter()
        {
            dt.Clear();
            string ss = "";
            if (txt_AccountCode.Text.Trim() != "")
            {
                if (ss.Trim() != "")
                    ss += " AND AccountCode LIKE '" + txt_AccountCode.Text + "%'";
                else
                    ss += " Where AccountCode LIKE '" + txt_AccountCode.Text + "%'";
            }
            if (txt_AccountName.Text.Trim() != "")
            {
                if (ss.Trim() != "")
                    ss += " AND AccoutName LIKE '" + txt_AccountName.Text + "%'";
                else
                    ss += " Where AccoutName LIKE '" + txt_AccountName.Text + "%'";
            }
            if (cb_Status.Text.Trim() != "")
            {
                if (ss.Trim() != "")
                    ss += " AND Status = '" + cb_Status.Text + "'";
                else
                    ss += " Where Status = '" + cb_Status.Text + "'";
            }
            if (ApplyCredits == "Credits")
            {
                if (NOSearch != "")
                {
                    adapterCust = new SqlDataAdapter("Select AccountCode,AccoutName AS AccountName,Status From ARCustomerMaintainance Where AccountCode IN " + NOSearch + ss, sqlcon);
                }

                else
                    adapterCust = new SqlDataAdapter("Select AccountCode,AccoutName AS AccountName,Status from ARCustomerMaintainance " + ss, sqlcon);
            }
            else
                adapterCust = new SqlDataAdapter("Select AccountCode,AccoutName AS AccountName,Status from ARCustomerMaintainance " + ss, sqlcon);
            adapterCust.Fill(dt);


        }
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (dgv.SelectedRows.Count != 0)
                {
                    selectedAccountCode = dgv.CurrentRow.Cells["AccountCode"].Value.ToString();
                    selectedAccountName = dgv.CurrentRow.Cells["AccountName"].Value.ToString();
                    this.Close();
                }
            }
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgv.SelectedRows.Count != 0)
            {
                selectedAccountCode = dgv.CurrentRow.Cells["AccountCode"].Value.ToString();
                selectedAccountName = dgv.CurrentRow.Cells["AccountName"].Value.ToString();
                this.Close();
            }

        }


    }
}