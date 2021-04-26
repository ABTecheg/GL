using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Accounting_GeneralLedger
{
    public partial class VendorsCategories : Form
    {
        private SqlConnection sqlcon;
        private SqlDataAdapter adapter;
        private SqlCommandBuilder cmdBuilder;
        //private int currentCategoryID;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;

        public VendorsCategories()
        {
            InitializeComponent();
        }

        private void VendorsCategories_Load(object sender, EventArgs e)
        {
            GeneralFunctions.priviledgeGroupBox(Lock91);
            GeneralFunctions.priviledgeGroupBox(Lock92);
            GeneralFunctions.priviledgeGroupBox(Lock93);
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adapter = new SqlDataAdapter("Select * from APVendorCategory", sqlcon);
            cmdBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(dbAccountingProjectDS.APVendorCategory);
            dgv.ClearSelection();
            //currentCategoryID = GeneralFunctions.VendorCategoryID;
            txt_CategoryCodeID.Text = "";
            if (GeneralFunctions.languagechioce != "")
            {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }

        }
        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.formVendorsCategories;
            this.label3.Text = obj_interface_language.CategoryID;
            this.label1.Text = obj_interface_language.CategoryCode;
            this.label2.Text = obj_interface_language.CategoryDescription;

            this.btn_New.Text = obj_interface_language.buttonJVTransactionNew;
            this.btnedit.Text = obj_interface_language.buttonJVTransactionEdit;
            this.btndelete.Text = obj_interface_language.buttonJVTransactionDelete;
            this.btnundo.Text = obj_interface_language.buttonJVTransactionUndo;
            this.btnexit.Text = obj_interface_language.buttonJVTransactionExit;
            this.btnSavenew.Text = obj_interface_language.buttonJVTransactionSaveNew;
            this.Btnsaveedit.Text = obj_interface_language.buttonJVTransactionSaveEdit;

            this.dgv.Columns[0].HeaderText = obj_interface_language.dgvCode;
            this.dgv.Columns[1].HeaderText = obj_interface_language.dgvDesc;
        }
        private void SaveChanges()
        {
            adapter.Update(dbAccountingProjectDS.APVendorCategory);
            dbAccountingProjectDS.AcceptChanges();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GeneralFunctions.ValidateString(txt_CategoryCode.Text,"Please Specify the Vendor Category Code")
                && GeneralFunctions.ValidateString(txt_CategoryDescription.Text, "Please Specify the Vendor Category Description"))
            {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select CategoryCode from APVendorCategory where CategoryCode = '" + txt_CategoryCode.Text + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("CategoryCode = '" + txt_CategoryCode.Text + "'", dbAccountingProjectDS.APVendorCategory))
                {
                    DataRow r = dbAccountingProjectDS.APVendorCategory.NewRow();
                    r["CategoryID"] = int.Parse(txt_CategoryCodeID.Text);
                    //GeneralFunctions.VendorCategoryID++;
                    //currentCategoryID = GeneralFunctions.VendorCategoryID;
                    r["CategoryCode"] = txt_CategoryCode.Text;
                    r["CategoryDescription"] = txt_CategoryDescription.Text;
                    dbAccountingProjectDS.APVendorCategory.Rows.Add(r);
                    dr.Close();
                    sqlcon.Close();
                    ClearAll();
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Category Code already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.APVendorCategory.Select("CategoryCode = '" + txt_CategoryCode.Text + "'");
                        rArr[0]["CategoryCode"] = txt_CategoryCode.Text;
                        rArr[0]["CategoryDescription"] = txt_CategoryDescription.Text;
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
                if (GeneralFunctions.ValidateString(txt_CategoryCode.Text, "Please Specify the Vendor Category Code")
               && GeneralFunctions.ValidateString(txt_CategoryDescription.Text, "Please Specify the Vendor Category Description"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.APVendorCategory.Select("CategoryID = '" + txt_CategoryCodeID.Text + "'");
                    rArr[0]["CategoryCode"] = txt_CategoryCode.Text;
                    rArr[0]["CategoryDescription"] = txt_CategoryDescription.Text;
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
                dbAccountingProjectDS.APVendorCategory.Rows[dgv.SelectedRows[0].Index].Delete();
                ClearAll();
            }
            else
            {
                if (GeneralFunctions.ValidateString(txt_CategoryCode.Text,"Please Specify the Category Code"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.APVendorCategory.Select("CategoryCode = '" + txt_CategoryCode.Text + "'");
                    if (rArr.Length != 0)
                    {
                        rArr[0].Delete();
                        ClearAll();
                    }
                    else
                    {
                        MessageBox.Show("The given Category Code doesnt exist \n Cant perform delete operation");
                    }
                }
            }
            dgv.ClearSelection();
            SaveChanges();
            btnedit.Enabled = false;
            btndelete.Enabled = false;

        }


        private void btn_New_Click(object sender, EventArgs e)
        {
            ClearAll();
            SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconBatch.Open();
            SqlCommand getBatch = new SqlCommand("Select Max(CategoryID)+1 From APVendorCategory", sqlconBatch);
            if (getBatch.ExecuteScalar() != DBNull.Value)
            {
                txt_CategoryCodeID.Text = getBatch.ExecuteScalar().ToString();
            }
            else
            {
                txt_CategoryCodeID.Text = "1";
            }
            sqlconBatch.Close();
            groupBox1.Enabled = true;
            btn_New.Visible = false;
            btnSavenew.Visible = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;

        }

        private void ClearAll()
        {
            txt_CategoryCodeID.Text = "";
            txt_CategoryCode.Text = "";
            txt_CategoryDescription.Text = "";
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
            myrst = MessageBox.Show("Are You Sure Delete This Vendors Categories", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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
            insertToolStripMenuItem_Click(sender, e);
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
                txt_CategoryCodeID.Text = dgv.SelectedRows[0].Cells[0].FormattedValue.ToString();
                txt_CategoryCode.Text = dgv.SelectedRows[0].Cells[1].FormattedValue.ToString();
                txt_CategoryDescription.Text = dgv.SelectedRows[0].Cells[2].FormattedValue.ToString();
                groupBox1.Enabled = false;
                btndelete.Enabled = true;
                btnedit.Enabled = true;

            }
        }

        private void groupBox1_EnabledChanged(object sender, EventArgs e)
        {
            if (groupBox1.Enabled == true)
                dgv.Enabled = false;
            else
                dgv.Enabled = true;
        }
    }
}