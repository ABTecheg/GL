using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Accounting_GeneralLedger
{
    public partial class TaxOffice : Form
    {
        private SqlConnection sqlcon;
        private SqlDataAdapter adapter;
        private SqlCommandBuilder cmdBuilder;
        private int currentTaxOfficeID;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        public TaxOffice()
        {
            InitializeComponent();
        }
        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.formtaxoffice;
            this.label1.Text = obj_interface_language.taxoffId;
            this.label2.Text = obj_interface_language.taxoffName;

            this.btn_New.Text = obj_interface_language.buttonJVTransactionNew;
            this.btnedit.Text = obj_interface_language.buttonJVTransactionEdit;
            this.btndelete.Text = obj_interface_language.buttonJVTransactionDelete;
            this.btnundo.Text = obj_interface_language.buttonJVTransactionUndo;
            this.btnexit.Text = obj_interface_language.buttonJVTransactionExit;
            this.btnSavenew.Text = obj_interface_language.buttonJVTransactionSaveNew;
            this.Btnsaveedit.Text = obj_interface_language.buttonJVTransactionSaveEdit;

            this.dgv.Columns[0].HeaderText = obj_interface_language.dgvtaxoffId;
            this.dgv.Columns[1].HeaderText = obj_interface_language.dgvtaxoffName;
        }

        private void TaxOffice_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbAccountingProjectDS.APTaxOffice' table. You can move, or remove it, as needed.
            this.aPTaxOfficeTableAdapter.Fill(this.dbAccountingProjectDS.APTaxOffice);
            // TODO: This line of code loads data into the 'dbAccountingProjectDS.APGeneralSetup' table. You can move, or remove it, as needed.
            this.aPGeneralSetupTableAdapter.Fill(this.dbAccountingProjectDS.APGeneralSetup);
            // TODO: This line of code loads data into the 'dbAccountingProjectDS.APTaxOffice' table. You can move, or remove it, as needed.
            this.aPTaxOfficeTableAdapter.Fill(this.dbAccountingProjectDS.APTaxOffice);
            GeneralFunctions.priviledgeGroupBox(Lock82);
            GeneralFunctions.priviledgeGroupBox(Lock83);
            GeneralFunctions.priviledgeGroupBox(Lock84);
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adapter = new SqlDataAdapter("Select * from APTaxOffice", sqlcon);
            cmdBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(dbAccountingProjectDS.APTaxOffice);
            currentTaxOfficeID = GeneralFunctions.TaxOfficeID;
            txt_TaxOfficeID.Text = currentTaxOfficeID.ToString();
            if (GeneralFunctions.languagechioce != "")
            {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }

        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GeneralFunctions.ValidateString(txt_TaxOfficeName.Text, "Please Enter a valid Tax Office Name"))
            {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select TaxOfficeID from APTaxOffice where TaxOfficeID = '" + txt_TaxOfficeID.Text + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("TaxOfficeID = '" + txt_TaxOfficeID.Text + "'", dbAccountingProjectDS.APTaxOffice))
                {
                    DataRow r = dbAccountingProjectDS.APTaxOffice.NewRow();
                    r["TaxOfficeID"] = int.Parse(txt_TaxOfficeID.Text);
                    //GeneralFunctions.TaxOfficeID++;
                    //currentTaxOfficeID = GeneralFunctions.TaxOfficeID;
                    r["TaxOfficeName"] = txt_TaxOfficeName.Text;
                    dbAccountingProjectDS.APTaxOffice.Rows.Add(r);
                    MessageBox.Show("Tax Office Record inserted successfully", "General Ledger");
                    txt_TaxOfficeID.Text = "";
                    txt_TaxOfficeName.Text = "";
                    dr.Close();
                    sqlcon.Close();
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Tax Office Name is already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.APTaxOffice.Select("TaxOfficeID = '" + txt_TaxOfficeID.Text + "'");
                        rArr[0]["TaxOfficeName"] = txt_TaxOfficeName.Text;
                        MessageBox.Show("Tax Office Record edited successfully", "General Ledger");
                        txt_TaxOfficeID.Text = "";
                        txt_TaxOfficeName.Text = "";
                    }
                    else
                    {
                        txt_TaxOfficeID.Text = "";
                        txt_TaxOfficeName.Text = "";
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
                if (GeneralFunctions.ValidateString(txt_TaxOfficeName.Text, "Please Enter a valid Tax Office Name"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.APTaxOffice.Select("TaxOfficeID = '" + txt_TaxOfficeID.Text + "'");
                    rArr[0]["TaxOfficeName"] = txt_TaxOfficeName.Text;
                    MessageBox.Show("Tax Office Record edited successfully", "General Ledger");
                    //txt_TaxOfficeID.Text = currentTaxOfficeID.ToString();
                    //txt_TaxOfficeName.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please Select the row that you want to edit", "General Ledger");
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
                dbAccountingProjectDS.APTaxOffice.Rows[dgv.SelectedRows[0].Index].Delete();
                MessageBox.Show("Tax Office Record deleted successfully", "General Ledger");
                txt_TaxOfficeID.Text = "";
                txt_TaxOfficeName.Text = "";
            }
            else
            {
                if (txt_TaxOfficeID.Text != "")
                {
                    DataRow[] rArr = dbAccountingProjectDS.APTaxOffice.Select("TaxOfficeID = '" + txt_TaxOfficeID.Text + "'");
                    if (rArr.Length != 0)
                    {
                        rArr[0].Delete();
                        MessageBox.Show("Tax Office Record deleted successfully", "General Ledger");
                        txt_TaxOfficeID.Text = "";
                        txt_TaxOfficeName.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("The given Tax Office ID doesnt exist \n Cant perform delete operation", "General Ledger");
                    }
                }
            }
            dgv.ClearSelection();
            SaveChanges();
            btnedit.Enabled = false;
            btndelete.Enabled = false;

        }

        private void SaveChanges()
        {
            adapter.Update(dbAccountingProjectDS.APTaxOffice);
            dbAccountingProjectDS.AcceptChanges();
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            txt_TaxOfficeID.Text = "";
            txt_TaxOfficeName.Text = "";
            SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconBatch.Open();
            SqlCommand getBatch = new SqlCommand("Select Max(TaxOfficeID)+1 From APTaxOffice", sqlconBatch);
            if (getBatch.ExecuteScalar() != DBNull.Value)
            {
                txt_TaxOfficeID.Text = getBatch.ExecuteScalar().ToString();
            }
            else
            {
                txt_TaxOfficeID.Text = "1";
            }
            sqlconBatch.Close();
            groupBox1.Enabled = true;
            btn_New.Visible = false;
            btnSavenew.Visible = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
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
            txt_TaxOfficeID.Text = "";
            txt_TaxOfficeName.Text = "";
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
            myrst = MessageBox.Show("Are You Sure Delete This TaxOffice", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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
                DataRow r = dbAccountingProjectDS.APTaxOffice.Rows[dgv.SelectedRows[0].Index];
                txt_TaxOfficeID.Text = r["TaxOfficeID"].ToString();
                txt_TaxOfficeName.Text = r["TaxOfficeName"].ToString();
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