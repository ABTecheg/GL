using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Accounting_GeneralLedger
{
    public partial class TaxReason : Form
    {
        public TaxReason()
        {
            InitializeComponent();
        }
        private SqlConnection sqlcon;
        private SqlDataAdapter adapter;
        private SqlCommandBuilder cmdBuilder;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;

        private void aPTaxReasonBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //this.Validate();
            //this.aPTaxReasonBindingSource.EndEdit();
            //this.aPTaxReasonTableAdapter.Update(this.dbAccountingProjectDS.APTaxReason);

        }

        private void TaxReason_Load(object sender, EventArgs e)
        {
            GeneralFunctions.priviledgeGroupBox(Lock85);
            GeneralFunctions.priviledgeGroupBox(Lock86);
            GeneralFunctions.priviledgeGroupBox(Lock87);
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adapter = new SqlDataAdapter("Select * from APTaxReason", sqlcon);
            cmdBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(dbAccountingProjectDS.APTaxReason);
            dgv.ClearSelection();
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
            this.Text = obj_interface_language.formtaxReason;
            this.label3.Text = obj_interface_language.ReasonID;
            this.label1.Text = obj_interface_language.ReasonCode;
            this.label2.Text = obj_interface_language.ReasonDescription;

            this.btn_New.Text = obj_interface_language.buttonJVTransactionNew;
            this.btnedit.Text = obj_interface_language.buttonJVTransactionEdit;
            this.btndelete.Text = obj_interface_language.buttonJVTransactionDelete;
            this.btnundo.Text = obj_interface_language.buttonJVTransactionUndo;
            this.btnexit.Text = obj_interface_language.buttonJVTransactionExit;
            this.btnSavenew.Text = obj_interface_language.buttonJVTransactionSaveNew;
            this.Btnsaveedit.Text = obj_interface_language.buttonJVTransactionSaveEdit;

            this.dgv.Columns[1].HeaderText = obj_interface_language.dgvCode;
            this.dgv.Columns[2].HeaderText = obj_interface_language.dgvDesc;
        }
        private void SaveChanges()
        {
            adapter.Update(dbAccountingProjectDS.APTaxReason);
            dbAccountingProjectDS.AcceptChanges();
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

        private void btnSavenew_Click(object sender, EventArgs e)
        {
            if (GeneralFunctions.ValidateString(txt_ReasonCode.Text, "Please Specify the Reason Code")
    && GeneralFunctions.ValidateString(txt_ReasonDescription.Text, "Please Specify the Reason Description"))
            {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select Code_Reason from APTaxReason where Code_Reason = '" + txt_ReasonCode.Text + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("Code_Reason = '" + txt_ReasonCode.Text + "'", dbAccountingProjectDS.APTaxReason))
                {
                    DataRow r = dbAccountingProjectDS.APTaxReason.NewRow();
                    r["ID_Reason"] = int.Parse(txt_ReasonCodeID.Text);
                    //GeneralFunctions.VendorCategoryID++;
                    //currentCategoryID = GeneralFunctions.VendorCategoryID;
                    r["Code_Reason"] = txt_ReasonCode.Text;
                    r["Description_Reason"] = txt_ReasonDescription.Text;
                    dbAccountingProjectDS.APTaxReason.Rows.Add(r);
                    dr.Close();
                    sqlcon.Close();
                    ClearAll();
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The Reason Code already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.APTaxReason.Select("Code_Reason = '" + txt_ReasonCode.Text + "'");
                        rArr[0]["Code_Reason"] = txt_ReasonCode.Text;
                        rArr[0]["Description_Reason"] = txt_ReasonDescription.Text;
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

        private void Btnsaveedit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (GeneralFunctions.ValidateString(txt_ReasonCode.Text, "Please Specify the Reason Code")
               && GeneralFunctions.ValidateString(txt_ReasonDescription.Text, "Please Specify the Reason Description"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.APTaxReason.Select("ID_Reason = '" + txt_ReasonCodeID.Text + "'");
                    rArr[0]["Code_Reason"] = txt_ReasonCode.Text;
                    rArr[0]["Description_Reason"] = txt_ReasonDescription.Text;
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

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult myrst;
            myrst = MessageBox.Show("Are You Sure Delete This Reason", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return;

            if (dgv.SelectedRows.Count > 0)
            {
                dbAccountingProjectDS.APTaxReason.Rows[dgv.SelectedRows[0].Index].Delete();
                ClearAll();
            }
            else
            {
                if (GeneralFunctions.ValidateString(txt_ReasonCode.Text, "Please Specify the Reason Code"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.APTaxReason.Select("Code_Reason = '" + txt_ReasonCode.Text + "'");
                    if (rArr.Length != 0)
                    {
                        rArr[0].Delete();
                        ClearAll();
                    }
                    else
                    {
                        MessageBox.Show("The given Reason Code doesnt exist \n Cant perform delete operation");
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
            SqlCommand getBatch = new SqlCommand("Select Max(ID_Reason)+1 From APTaxReason", sqlconBatch);
            if (getBatch.ExecuteScalar() != DBNull.Value)
            {
                txt_ReasonCodeID.Text = getBatch.ExecuteScalar().ToString();
            }
            else
            {
                txt_ReasonCodeID.Text = "1";
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
            txt_ReasonCodeID.Text = "";
            txt_ReasonCode.Text = "";
            txt_ReasonDescription.Text = "";
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

        private void btnedit_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnedit.Visible = false;
            Btnsaveedit.Visible = true;
            btn_New.Enabled = false;
            btndelete.Enabled = false;

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
                txt_ReasonCodeID.Text = dgv.SelectedRows[0].Cells[0].FormattedValue.ToString();
                txt_ReasonCode.Text = dgv.SelectedRows[0].Cells[1].FormattedValue.ToString();
                txt_ReasonDescription.Text = dgv.SelectedRows[0].Cells[2].FormattedValue.ToString();
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