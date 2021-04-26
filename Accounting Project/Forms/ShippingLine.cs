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
    public partial class ShippingLine : Form
    {
        public ShippingLine()
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
        private dbAccountingProjectDS dbAccountingProjectDS;
        private void ShippingLine_Load(object sender, EventArgs e)
        {
            //GeneralFunctions.priviledgeGroupBox(Lock85);
            //GeneralFunctions.priviledgeGroupBox(Lock86);
            //GeneralFunctions.priviledgeGroupBox(Lock87);
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            dbAccountingProjectDS = new dbAccountingProjectDS();
            adapter = new SqlDataAdapter("Select * from ShippingLine", sqlcon);
            cmdBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(dbAccountingProjectDS.ShippingLine);
            dgv.DataSource = dbAccountingProjectDS.ShippingLine;
            //dgv.Columns[0].Visible = false;
            //dgv.Columns[3].Visible = false;
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
            //this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            //this.Text = obj_interface_language.formtaxReason;
            //this.label3.Text = obj_interface_language.ReasonID;
            //this.label1.Text = obj_interface_language.ReasonCode;
            //this.label2.Text = obj_interface_language.ReasonDescription;

            //this.btn_New.Text = obj_interface_language.buttonJVTransactionNew;
            //this.btnedit.Text = obj_interface_language.buttonJVTransactionEdit;
            //this.btndelete.Text = obj_interface_language.buttonJVTransactionDelete;
            //this.btnundo.Text = obj_interface_language.buttonJVTransactionUndo;
            //this.btnexit.Text = obj_interface_language.buttonJVTransactionExit;
            //this.btnSavenew.Text = obj_interface_language.buttonJVTransactionSaveNew;
            //this.Btnsaveedit.Text = obj_interface_language.buttonJVTransactionSaveEdit;

            //this.dgv.Columns[1].HeaderText = obj_interface_language.dgvCode;
            //this.dgv.Columns[2].HeaderText = obj_interface_language.dgvDesc;
        }
        private void SaveChanges()
        {
            adapter.Update(dbAccountingProjectDS.ShippingLine);
            dbAccountingProjectDS.ShippingLine.AcceptChanges();
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
            if (GeneralFunctions.ValidateString(txtCode.Text, "Please Specify Code")
                && GeneralFunctions.ValidateString(txtName1.Text, "Please Specify Name1"))
            {

                DataRow r = dbAccountingProjectDS.ShippingLine.NewRow();
                r["Code"] = txtCode.Text;
                r["Name1"] = txtName1.Text;
                r["Name2"] = txtName2.Text;
                r["PortOfLoading"] = txtPOF.Text;
                r["PortOfDischarge"] = txtPOD.Text;
                if (chkactive.Checked == true)
                    r["Active"] = "A";
                else
                    r["Active"] = "I";
                dbAccountingProjectDS.ShippingLine.Rows.Add(r);
                sqlcon.Close();
                ClearAll();
            }
            groupBox1.Enabled = false;
            btn_New.Visible = true;
            btnSavenew.Visible = false;
            SaveChanges();

        }

        private void Btnsaveedit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (GeneralFunctions.ValidateString(txtCode.Text, "Please Specify Code")
               && GeneralFunctions.ValidateString(txtName1.Text, "Please Specify Name1"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.ShippingLine.Select("Code = '" + txtCode.Text + "'");
                    rArr[0]["Code"] = txtCode.Text;
                    rArr[0]["Name1"] = txtName1.Text;
                    rArr[0]["Name2"] = txtName2.Text;
                    if (chkactive.Checked == true)
                        rArr[0]["Active"] = "A";
                    else
                        rArr[0]["Active"] = "I";
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
            myrst = MessageBox.Show("Are You Sure Delete This Department", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return;

            if (dgv.SelectedRows.Count > 0)
            {
                dbAccountingProjectDS.ShippingLine.Rows[dgv.SelectedRows[0].Index].Delete();
                ClearAll();
            }
            else
            {
                if (GeneralFunctions.ValidateString(txtCode.Text, "Please Specify Code"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.ShippingLine.Select("Code = '" + txtCode.Text + "'");
                    if (rArr.Length != 0)
                    {
                        rArr[0].Delete();
                        ClearAll();
                    }
                    else
                    {
                        MessageBox.Show("The given Code doesnt exist \n Cant perform delete operation");
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
            SqlCommand getBatch = new SqlCommand("Select Max(Code)+1 From ShippingLine", sqlconBatch);
            if (getBatch.ExecuteScalar() != DBNull.Value)
            {
                txtCode.Text = getBatch.ExecuteScalar().ToString();
            }
            else
            {
                txtCode.Text = "1";
            }
            sqlconBatch.Close();
            groupBox1.Enabled = true;
            btn_New.Visible = false;
            btnSavenew.Visible = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
            chkactive.Checked = true;
        }

        private void ClearAll()
        {
            txtCode.Text = "";
            txtName1.Text = "";
            txtName2.Text = "";
            chkactive.Checked = false;
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
                DataRow r = dbAccountingProjectDS.ShippingLine.Rows[dgv.SelectedRows[0].Index];
                txtCode.Text = r["Code"].ToString();
                txtName1.Text = r["Name1"].ToString();
                txtName2.Text = r["Name2"].ToString();
                if (r["Active"].ToString() == "A")
                    chkactive.Checked = true;
                else
                    chkactive.Checked = false;
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