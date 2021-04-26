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
    public partial class CashFlowCategories : Form
    {
        public SqlConnection sqlcon;
        public SqlDataAdapter adapter;
        public SqlCommandBuilder cmdBuilder;
        //private int currentCashFlowCategoryID;

        public CashFlowCategories()
        {
            InitializeComponent();
        }

        private void SaveChanges()
        {
            adapter.Update(dbAccountingProjectDS.ARCashFlowCategory);
            dbAccountingProjectDS.ARCashFlowCategory.AcceptChanges();
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            ClearAll();
            SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconBatch.Open();
            SqlCommand getBatch = new SqlCommand("Select Max(CashFlowCategoryID)+1 From ARCashFlowCategory", sqlconBatch);
            if (getBatch.ExecuteScalar() != DBNull.Value)
            {
                txt_CashFlowID.Text = getBatch.ExecuteScalar().ToString();
            }
            else
            {
                txt_CashFlowID.Text = "1";
            }
            sqlconBatch.Close();
            groupBox1.Enabled = true;
            btn_New.Visible = false;
            btnSavenew.Visible = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
        }

        private void CashFlowCategories_Load(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adapter = new SqlDataAdapter("Select * from ARCashFlowCategory", sqlcon);
            cmdBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(dbAccountingProjectDS.ARCashFlowCategory);
            //currentCashFlowCategoryID = GeneralFunctions.CashFlowCategoryID;
            txt_CashFlowID.Text = "";
        }

        private void insertToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (GeneralFunctions.ValidateString(txt_CashFlowCode.Text, "Please Enter a valid Cash Flow Category Code")
                && GeneralFunctions.ValidateString(txt_CashFlowDescription.Text,"Please Enter a valid Cash Flow Category Description"))
            {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select CashFlowCategoryID from ARCashFlowCategory where CashFlowCategoryID = '" + txt_CashFlowID.Text + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("CashFlowCategoryID = '" + txt_CashFlowID.Text + "'", dbAccountingProjectDS.ARCashFlowCategory))
                {
                    DataRow r = dbAccountingProjectDS.ARCashFlowCategory.NewRow();
                    r["CashFlowCategoryID"] = int.Parse(txt_CashFlowID.Text);
                    //GeneralFunctions.CashFlowCategoryID++;
                    //currentCashFlowCategoryID = GeneralFunctions.CashFlowCategoryID;
                    r["CashFlowCategoryCode"] = txt_CashFlowCode.Text;
                    r["CashFlowCategoryDescription"] = txt_CashFlowDescription.Text;
                    dbAccountingProjectDS.ARCashFlowCategory.Rows.Add(r);
                    ClearAll();
                    dr.Close();
                    sqlcon.Close();
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Cash Flow Code already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.ARCashFlowCategory.Select("CashFlowCategoryID = '" + txt_CashFlowID.Text + "'");
                        rArr[0]["CashFlowCategoryCode"] = txt_CashFlowCode.Text;
                        rArr[0]["CashFlowCategoryDescription"] = txt_CashFlowDescription.Text;
                        ClearAll();
                    }
                    else
                    {
                        ClearAll();
                    }
                    dr.Close();
                    sqlcon.Close();
                }
            groupBox1.Enabled = false;
            btn_New.Visible = true;
            btnSavenew.Visible = false;
            SaveChanges();
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (GeneralFunctions.ValidateString(txt_CashFlowCode.Text, "Please Enter a valid Cash Flow Category Code")
                 && GeneralFunctions.ValidateString(txt_CashFlowDescription.Text, "Please Enter a valid Cash Flow Category Description"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.ARCashFlowCategory.Select("CashFlowCategoryID = '" + txt_CashFlowID.Text + "'");
                    rArr[0]["CashFlowCategoryCode"] = txt_CashFlowCode.Text;
                    rArr[0]["CashFlowCategoryDescription"] = txt_CashFlowDescription.Text;
                    //ClearAll();
                }
            }
            else
            {
                MessageBox.Show("Please Select the row that you want to edit");
            }
            dgv.ClearSelection();
            groupBox1.Enabled = false;
            btnedit.Visible = true;
            Btnsaveedit.Visible = false;
            btn_New.Enabled = true;
            btndelete.Enabled = true;
            SaveChanges();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                dbAccountingProjectDS.ARCashFlowCategory.Rows[dgv.SelectedRows[0].Index].Delete();
                ClearAll();
            }
            else
            {
                if (txt_CashFlowCode.Text != "")
                {
                    DataRow[] rArr = dbAccountingProjectDS.ARCashFlowCategory.Select("CashFlowCategoryID = '" + txt_CashFlowID.Text + "'");
                    if (rArr.Length != 0)
                    {
                        rArr[0].Delete();
                        ClearAll();
                    }
                    else
                    {
                        MessageBox.Show("The given Cash Category Code doesnt exist \n Cant perform delete operation");
                    }
                }
            }
            dgv.ClearSelection();
            SaveChanges();
            btnedit.Enabled = false;
            btndelete.Enabled = false;

        }

        private void ClearAll()
        {
            txt_CashFlowID.Text = "";
            txt_CashFlowCode.Text = "";
            txt_CashFlowDescription.Text = "";
        }


        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (groupBox1.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            btnundo_Click("NO", e);
            if (dgv.SelectedRows.Count > 0)
            {
                DataRow r = dbAccountingProjectDS.ARCashFlowCategory.Rows[dgv.SelectedRows[0].Index];
                txt_CashFlowID.Text = r["CashFlowCategoryID"].ToString();
                txt_CashFlowCode.Text = r["CashFlowCategoryCode"].ToString();
                txt_CashFlowDescription.Text = r["CashFlowCategoryDescription"].ToString();
                groupBox1.Enabled = false;
                btndelete.Enabled = true;
                btnedit.Enabled = true;

            }

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (groupBox1.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            this.Close();

        }

        private void btnundo_Click(object sender, EventArgs e)
        {
            if (sender.ToString() != "NO")
            {
                if (groupBox1.Enabled == true)
                {
                    DialogResult myrst;
                    myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (myrst == DialogResult.No)
                        return;
                }
            }
            ClearAll();
            btn_New.Visible = true;
            btnSavenew.Visible = false;
            btnedit.Visible = true;
            Btnsaveedit.Visible = false;
            groupBox1.Enabled = false;
            btn_New.Enabled = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult myrst;
            myrst = MessageBox.Show("Are You Sure Delete This Allocation", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return;
            deleteToolStripMenuItem_Click(sender, e);
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnedit.Visible = false;
            Btnsaveedit.Visible = true;
            btn_New.Enabled = false;
            btndelete.Enabled = false;

        }

        private void Btnsaveedit_Click(object sender, EventArgs e)
        {
            editToolStripMenuItem_Click(sender, e);
        }

        private void btnSavenew_Click(object sender, EventArgs e)
        {
            insertToolStripMenuItem1_Click(sender, e);
        }
    }
}