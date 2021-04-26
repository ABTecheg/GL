using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Accounting_GeneralLedger
{
    public partial class SearchJV : Form
    {
        public string selectBatchNo = "";
        public string endyearsadjustments = "";
        public DataTable selectedBatch;
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbBatch;

        public SearchJV()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow r = (DataGridViewRow)dgv.CurrentRow;
                selectBatchNo = r.Cells["BatchNo"].Value.ToString();
                this.Close();
            }
        }

        private void SearchJV_Load(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            if (endyearsadjustments == "Tran_Cashier")
                adaptertbBatch = new SqlDataAdapter("Select * From Batch where BatchPRD <> 'Period 99' AND Tran_Cashier = 1 and (Select Count(TransNO) From GLTransactions Where GLTransactions.BatchNo = Batch.BatchNo AND SortNO <> 0) = 2", sqlcon);
            else if (endyearsadjustments == "Period 99")
                adaptertbBatch = new SqlDataAdapter("Select * From Batch where BatchPRD = 'Period 99' and ((BatchSRC = 'GL') or (BatchSRC = 'AP' and BatchStat <> 'U'))", sqlcon);
            else
                adaptertbBatch = new SqlDataAdapter("Select * From Batch where BatchPRD <> 'Period 99' and ((BatchSRC = 'GL') or (BatchSRC = 'AP' and BatchStat <> 'U') or (BatchSRC = 'AR' and BatchStat <> 'U') or (BatchSRC = 'ARP' and BatchStat <> 'U') OR (BatchSRC = 'Bank'))", sqlcon);
            adaptertbBatch.Fill(dbAccountingProjectDS.Batch);
            DataGridViewColumn dc = new DataGridViewColumn();
            dc = dgv.Columns[0];
            dgv.Sort(dc, ListSortDirection.Descending);
        }
        private void GridRefresh()
        {
            adaptertbBatch.Fill(dbAccountingProjectDS.Batch);
            dgv.DataSource = dbAccountingProjectDS.Batch;
            dgv.Refresh();
        }

        private void SearchForGivenJVNumber()
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
                else if (cb_choose.Text == "Status" && rbP.Checked == true)
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

        private void rbU_CheckedChanged(object sender, EventArgs e)
        {
            SearchForGivenJVNumber();
        }

        private void txtJV_TextChanged(object sender, EventArgs e)
        {
            SearchForGivenJVNumber();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            SearchForGivenJVNumber();
        }

        private void rbP_CheckedChanged(object sender, EventArgs e)
        {
            SearchForGivenJVNumber();
        }

        private void DTFrom_ValueChanged(object sender, EventArgs e)
        {
            SearchForGivenJVNumber();
        }

        private void DTTo_ValueChanged(object sender, EventArgs e)
        {
            SearchForGivenJVNumber();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow r = (DataGridViewRow)dgv.CurrentRow;
                selectBatchNo = r.Cells["BatchNo"].Value.ToString();
                this.Close();
            }
        }




    }
}