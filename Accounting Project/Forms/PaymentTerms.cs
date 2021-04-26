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
    public partial class PaymentTerms : Form
    {
        private SqlConnection sqlcon;
        private SqlDataAdapter adapter;
        private SqlCommandBuilder cmdBuilder;
        private int dueDays;
        //private int currentPaymentID;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;

        public PaymentTerms()
        {
            InitializeComponent();
        }

        private void PaymentTerms_Load(object sender, EventArgs e)
        {
            GeneralFunctions.priviledgeGroupBox(Lock94);
            GeneralFunctions.priviledgeGroupBox(Lock95);
            GeneralFunctions.priviledgeGroupBox(Lock96);
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adapter = new SqlDataAdapter("Select * from APPaymentTerms", sqlcon);
            cmdBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(dbAccountingProjectDS.APPaymentTerms);
            dgv.ClearSelection();
            //currentPaymentID = GeneralFunctions.PaymentTermID;
            //txt_PaymentCodeID.Text = currentPaymentID.ToString();
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
            this.Text = obj_interface_language.formPaymentTerms;
            this.label4.Text = obj_interface_language.PaymentTermID;
            this.label1.Text = obj_interface_language.PaymentTermCode;
            this.label2.Text = obj_interface_language.PaymentTermDescription;
            this.label3.Text = obj_interface_language.DueDays;

            this.btn_New.Text = obj_interface_language.buttonJVTransactionNew;
            this.btnedit.Text = obj_interface_language.buttonJVTransactionEdit;
            this.btndelete.Text = obj_interface_language.buttonJVTransactionDelete;
            this.btnundo.Text = obj_interface_language.buttonJVTransactionUndo;
            this.btnexit.Text = obj_interface_language.buttonJVTransactionExit;
            this.btnSavenew.Text = obj_interface_language.buttonJVTransactionSaveNew;
            this.Btnsaveedit.Text = obj_interface_language.buttonJVTransactionSaveEdit;

            this.dgv.Columns[0].HeaderText = obj_interface_language.dgvCode;
            this.dgv.Columns[1].HeaderText = obj_interface_language.dgvDesc;
            this.dgv.Columns[2].HeaderText = obj_interface_language.dgvDueDays;
        }
        private void SaveChanges()
        {
            adapter.Update(dbAccountingProjectDS.APPaymentTerms);
            dbAccountingProjectDS.AcceptChanges();
        }



        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GeneralFunctions.ValidateString(txt_TermCode.Text,"Please Specify Term Code")
                && GeneralFunctions.ValidateString(txt_TermDescription.Text, "Please Specify Term Code Description")
                && GeneralFunctions.ValidateInteger(txt_DueDays.Text, "Please Specify Term Code Due Days", out dueDays))
            {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select PaymentTermCodeID from APPaymentTerms where PaymentTermCodeID = '" + txt_PaymentCodeID.Text + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("PaymentTermCodeID = '" + txt_PaymentCodeID.Text + "'", dbAccountingProjectDS.APPaymentTerms) && !GeneralFunctions.FindRow("PaymentTermCode = '" + txt_TermCode.Text + "'", dbAccountingProjectDS.APPaymentTerms))
                {
                    DataRow r = dbAccountingProjectDS.APPaymentTerms.NewRow();
                    r["PaymentTermCodeID"] = int.Parse(txt_PaymentCodeID.Text);
                    r["PaymentTermCode"] = txt_TermCode.Text;
                    r["PaymentTermDescription"] = txt_TermDescription.Text;
                    r["PaymentDueDays"] = dueDays;
                    dbAccountingProjectDS.APPaymentTerms.Rows.Add(r);
                    dr.Close();
                    sqlcon.Close();
                    ClearAll();
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Payment Term Code already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.APPaymentTerms.Select("PaymentTermCode = '" + txt_TermCode.Text + "'");
                        //rArr[0]["PaymentTermCode"] = txt_TermCode.Text; 
                        rArr[0]["PaymentTermDescription"] = txt_TermDescription.Text;
                        rArr[0]["PaymentDueDays"] = dueDays;
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
            else
                MessageBox.Show("Please Insert acceptable values");
        }

        private void ClearAll()
        {
            txt_PaymentCodeID.Text = "";
            txt_TermCode.Text = "";
            txt_TermDescription.Text = "";
            txt_DueDays.Text = "";
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (GeneralFunctions.ValidateString(txt_TermCode.Text, "Please Specify Term Code")
                && GeneralFunctions.ValidateString(txt_TermDescription.Text, "Please Specify Term Code Description")
                && GeneralFunctions.ValidateInteger(txt_DueDays.Text, "Please Specify Term Code Due Days", out dueDays))
                {
                    if (!GeneralFunctions.FindRow("PaymentTermCode = '" + txt_TermCode.Text + "' AND PaymentTermCodeID <> '" + txt_PaymentCodeID.Text + "'", dbAccountingProjectDS.APPaymentTerms))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.APPaymentTerms.Select("PaymentTermCodeID = '" + txt_PaymentCodeID.Text + "'");
                        rArr[0]["PaymentTermCode"] = txt_TermCode.Text;
                        rArr[0]["PaymentTermDescription"] = txt_TermDescription.Text;
                        rArr[0]["PaymentDueDays"] = dueDays;
                        //ClearAll();
                    }
                    else
                    {
                        MessageBox.Show("The given Payment Term Code already exists ", "Stop", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select the row that you want to edit","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                dbAccountingProjectDS.APPaymentTerms.Rows[dgv.SelectedRows[0].Index].Delete();
                ClearAll();
            }
            else
            {
                if (GeneralFunctions.ValidateString(txt_TermCode.Text,"Please Specify the Payment Term Code"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.APPaymentTerms.Select("PaymentTermCode = '" + txt_TermCode.Text + "'");
                    if (rArr.Length != 0)
                    {
                        rArr[0].Delete();
                        ClearAll();
                    }
                    else
                    {
                        MessageBox.Show("The given Payment Term Code doesnt exist \n Cant perform delete operation","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            SqlCommand getBatch = new SqlCommand("Select Max(PaymentTermCodeID)+1 From APPaymentTerms", sqlconBatch);
            if (getBatch.ExecuteScalar() != DBNull.Value)
            {
                txt_PaymentCodeID.Text = getBatch.ExecuteScalar().ToString();
            }
            else
            {
                txt_PaymentCodeID.Text = "1";
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
            myrst = MessageBox.Show("Are You Sure Delete This Payment Terms", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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



        private void txt_DueDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                    e.Handled = false;
            }
            else
                e.Handled = true;
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
                DataRow r = dbAccountingProjectDS.APPaymentTerms.Rows[dgv.SelectedRows[0].Index];
                txt_PaymentCodeID.Text = r["PaymentTermCodeID"].ToString();
                txt_TermCode.Text = r["PaymentTermCode"].ToString();
                txt_TermDescription.Text = r["PaymentTermDescription"].ToString();
                txt_DueDays.Text = r["PaymentDueDays"].ToString();
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