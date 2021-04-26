using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Accounting_GeneralLedger {
    public partial class SearchARTemp : Form {
        public string selectBatchNumber;
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbARBatchTemp;

        public SearchARTemp() {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        

        private void SearchARTemp_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'dbAccountingProjectDS.ARBatchTemp' table. You can move, or remove it, as needed.
            //this.aRBatchTempTableAdapter.Fill(this.dbAccountingProjectDS.ARBatchTemp);
            
            // TODO: This line of code loads data into the 'dbAccountingProjectDS.BatchTemp' table. You can move, or remove it, as needed.
            //this.batchTempTableAdapter.Fill(this.dbAccountingProjectDS.BatchTemp);
            // TODO: This line of code loads data into the 'dbAccountingProjectDS.BatchTemp' table. You can move, or remove it, as needed.
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbARBatchTemp = new SqlDataAdapter("Select * From ARBatchTemp", sqlcon);
            adaptertbARBatchTemp.Fill(dbAccountingProjectDS.ARBatchTemp);

            DataGridViewColumn dc = new DataGridViewColumn();
            dc = dgv.Columns[0];
            dgv.Sort(dc, ListSortDirection.Descending);

        }

       

        private void GridRefresh() {
            adaptertbARBatchTemp.Fill(dbAccountingProjectDS.ARBatchTemp);
            dgv.DataSource = dbAccountingProjectDS.ARBatchTemp;
            dgv.Refresh();
        }

        private void SearchForGivenJVNumber() {
            if (cb_choose.Text == "")
                GridRefresh();
            else if (cb_choose.Text != "") {
                DataView dv = new DataView(dbAccountingProjectDS.ARBatchTemp);
                dv.RowFilter = CreateFilterExpression();
                dgv.DataSource = dv;
                dgv.Refresh();
            }
        }
        private string CreateFilterExpression() {
            string filterExpression = "";

            if (cb_choose.Text != "") {
                if (cb_choose.Text == "Status" && rbU.Checked == true) {
                    filterExpression = "active='A'";
                }
                if (cb_choose.Text == "Status" && rbP.Checked == true) {
                    filterExpression = "active='D'";
                }
                else if (cb_choose.Text == "Number" && txtJV.Text != "") {
                    filterExpression = "TempID = '" + int.Parse(txtJV.Text) + "'";
                }
                else if (cb_choose.Text == "Description" && txtDescription.Text != "") {
                    filterExpression = "DescTemp LIKE '" + txtDescription.Text + "%'";
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

        private void cb_choose_SelectedIndexChanged(object sender, EventArgs e) {
            if (cb_choose.Text == "Status") {
                GBStatus.Visible = true;
                GBNumber.Visible = false;
                GBDescription.Visible = false;
                rbP.Checked = false;
                rbU.Checked = false;
                txtJV.Text = "";
                txtDescription.Text = "";
            }
            else if (cb_choose.Text == "Number") {
                GBNumber.Visible = true;
                GBStatus.Visible = false;
                GBDescription.Visible = false;
                rbP.Checked = false;
                rbU.Checked = false;
                txtJV.Text = "";
                txtDescription.Text = "";
            }
            else if (cb_choose.Text == "Description") {
                GBDescription.Visible = true;
                GBStatus.Visible = false;
                GBNumber.Visible = false;
                rbP.Checked = false;
                rbU.Checked = false;
                rbP.Checked = false;
                rbU.Checked = false;
                txtJV.Text = "";
                txtDescription.Text = "";
            }

            
        }

        private void rbU_CheckedChanged(object sender, EventArgs e) {
            SearchForGivenJVNumber();
        }

        private void txtJV_TextChanged(object sender, EventArgs e) {
            SearchForGivenJVNumber();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e) {
            SearchForGivenJVNumber();
        }

        private void rbP_CheckedChanged(object sender, EventArgs e) {
            SearchForGivenJVNumber();
        }

        private void DTFrom_ValueChanged(object sender, EventArgs e) {
            SearchForGivenJVNumber();
        }

        private void DTTo_ValueChanged(object sender, EventArgs e) {
            SearchForGivenJVNumber();
        }

        
        private void batchTempBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.aRBatchTempBindingSource.EndEdit();
            this.aRBatchTempTableAdapter.Update(this.dbAccountingProjectDS.ARBatchTemp);

        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.CurrentRow.Cells[0].Value.ToString() != "")
            {
                DataGridViewRow r = (DataGridViewRow)dgv.CurrentRow;
                selectBatchNumber = r.Cells[0].Value.ToString();
                this.Close();
            }
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow r = (DataGridViewRow)dgv.CurrentRow;
                selectBatchNumber = r.Cells[0].Value.ToString();
                this.Close();
            }
        }

        




    }
}