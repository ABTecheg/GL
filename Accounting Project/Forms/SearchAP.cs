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
    public partial class SearchAP : Form
    {
        public SearchAP()
        {
            InitializeComponent();
        }
        public string selectAPNumber;
        public string ApplyCredits="";
        public string NOSearch = "";
        public DataTable selectedBatch;
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbBatch;
        private void SearchAP_Load(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            if (ApplyCredits == "Credits")
            {
                if (NOSearch != "")
                {
                    adaptertbBatch = new SqlDataAdapter("Select * From Batch Where BatchSRC = 'AP' AND BatchStat = 'P' AND BatchNo IN " + NOSearch, sqlcon);
                }

                else
                    adaptertbBatch = new SqlDataAdapter("Select * From Batch Where BatchSRC = 'AP'", sqlcon);
            }
            else
                adaptertbBatch = new SqlDataAdapter("Select * From Batch Where BatchSRC = 'AP'", sqlcon);
            adaptertbBatch.Fill(dbAccountingProjectDS.Batch);

            DataGridViewColumn dc = new DataGridViewColumn();
            dc = dgv.Columns[0];
            dgv.Sort(dc, ListSortDirection.Descending);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow r = (DataGridViewRow)dgv.CurrentRow;
                selectAPNumber = r.Cells[0].Value.ToString();
                this.Close();
            }
        }
        private void GridRefresh()
        {
            adaptertbBatch.Fill(dbAccountingProjectDS.Batch);
            dgv.DataSource = dbAccountingProjectDS.Batch;
            dgv.Refresh();
        }
        private void SearchForGivenAPNumber()
        {
            if (cb_choose.Text == "")
                GridRefresh();
            else if (cb_choose.Text != "")
            {
                DataView dv = new DataView(dbAccountingProjectDS.Batch);
                dv.RowFilter = CreateFilterExpression();
                dgv.DataSource = dv;
                dgv.Refresh();
            }
        }
        private string CreateFilterExpression()
        {
            string filterExpression = "";

            if (cb_choose.Text != "")
            {
                if (cb_choose.Text == "Status" && rbU.Checked == true)
                {
                    filterExpression = "BatchStat='U'";
                }
                if (cb_choose.Text == "Status" && rbP.Checked == true)
                {
                    filterExpression = "BatchStat='P'";
                }
                else if (cb_choose.Text == "Number" && txtJV.Text != "")
                {
                    filterExpression = "JVNumber LIKE '" + txtJV.Text + "%'";
                }
                else if (cb_choose.Text == "Description" && txtDescription.Text != "")
                {
                    filterExpression = "BatchDSC LIKE '" + txtDescription.Text + "%'";
                }
                else if (cb_choose.Text == "Date" && DTFrom.Value.ToString() != "" && DTTo.Value.ToString() != "")
                {
                    filterExpression = "BatchDate >= '" + DTFrom.Value + "' AND BatchDate <='" + DTTo.Value + "'";
                }
            }
            /*
             Number
             Date
             Description
             Status
             */
            return filterExpression;
        }

        private void cb_choose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_choose.Text == "Status")
            {
                GBStatus.Visible = true;
                GBNumber.Visible = false;
                GBDescription.Visible = false;
                GBDate.Visible = false;
                rbP.Checked = false;
                rbU.Checked = false;
                txtJV.Text = "";
                txtDescription.Text = "";
            }
            else if (cb_choose.Text == "Number")
            {
                GBNumber.Visible = true;
                GBStatus.Visible = false;
                GBDescription.Visible = false;
                GBDate.Visible = false;
                rbP.Checked = false;
                rbU.Checked = false;
                txtJV.Text = "";
                txtDescription.Text = "";
            }
            else if (cb_choose.Text == "Description")
            {
                GBDescription.Visible = true;
                GBStatus.Visible = false;
                GBNumber.Visible = false;
                GBDate.Visible = false;
                rbP.Checked = false;
                rbU.Checked = false;
                rbP.Checked = false;
                rbU.Checked = false;
                txtJV.Text = "";
                txtDescription.Text = "";
            }
            else if (cb_choose.Text == "Date"
                )
            {
                GBDate.Visible = true;
                GBDescription.Visible = false;
                GBStatus.Visible = false;
                GBNumber.Visible = false;
                rbP.Checked = false;
                rbU.Checked = false;
                rbP.Checked = false;
                rbU.Checked = false;
                txtJV.Text = "";
                txtDescription.Text = "";
                DTFrom.Value = DateTime.Now;
                DTTo.Value = DateTime.Now;
            }
        }

        private void txtJV_TextChanged(object sender, EventArgs e)
        {
            SearchForGivenAPNumber();
        }

        private void DTFrom_ValueChanged(object sender, EventArgs e)
        {
            SearchForGivenAPNumber();
        }

        private void DTTo_ValueChanged(object sender, EventArgs e)
        {
            SearchForGivenAPNumber();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            SearchForGivenAPNumber();
        }

        private void rbU_CheckedChanged(object sender, EventArgs e)
        {
            SearchForGivenAPNumber();
        }

        private void rbP_CheckedChanged(object sender, EventArgs e)
        {
            SearchForGivenAPNumber();
        }

        private void SearchAP_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbBatch = new SqlDataAdapter("Select * From Batch", sqlcon);
            adaptertbBatch.Fill(dbAccountingProjectDS.Batch);
        }


    }
}