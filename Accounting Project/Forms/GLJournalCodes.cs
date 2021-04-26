using System;
using Accounting_GeneralLedger.Report;
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
    public partial class GLJournalCodes : Form
    {
        //private string JournalCode="";
        //private string JournalDescription="";
        private SqlConnection sqlcon;
        private SqlDataAdapter adapter;
        private SqlCommandBuilder cmdBuilder;
        private int currentJournalCode;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        public GLJournalCodes()
        {
            InitializeComponent();
        }

        //private void btnSaveChanges_Click(object sender, EventArgs e)
        //{
        //    adapter.Update(dbAccountingProjectDS.GLJournalCodes);
        //    dbAccountingProjectDS.AcceptChanges();
        //}

        private void GLJournalCodes_Load(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adapter = new SqlDataAdapter("Select * from GLJournalCodes", sqlcon);
            cmdBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(dbAccountingProjectDS.GLJournalCodes);
            dgv.ClearSelection();
            //currentJournalCode = GeneralFunctions.JournalCodeID;
            //txt_JournalCodeID.Text = currentJournalCode.ToString();
            SqlConnection sqlcon1 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon1.Open();
            SqlCommand command = new SqlCommand("Select MAX(JournalCodeID)+1 from GLJournalCodes ", sqlcon1);
            int MaxNumber;
            if (command.ExecuteScalar() != DBNull.Value)
            {
                MaxNumber = Convert.ToInt32(command.ExecuteScalar());
                txt_JournalCodeID.Text = Convert.ToString(MaxNumber);
                currentJournalCode = MaxNumber;
            }
            else
            {
                MaxNumber = 1;
                txt_JournalCodeID.Text = Convert.ToString(MaxNumber);
                currentJournalCode = MaxNumber;
            }
            if (GeneralFunctions.languagechioce != "")
            {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }

            btndelete.Enabled = false;
            btnedit.Enabled = false;
        }

        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.formGLJournalCodes;
            this.dgv.Columns[0].HeaderText = obj_interface_language.dgvGLJournalCodesColumn1.ToString();
            this.dgv.Columns[1].HeaderText = obj_interface_language.dgvGLJournalCodesColumn2.ToString();
            this.label3.Text = obj_interface_language.labelJournalCodeID;
            this.label1.Text = obj_interface_language.labelJournalCode;
            this.label2.Text = obj_interface_language.labelJournalDescription;
            this.btn_New.Text = obj_interface_language.buttonbtnNew;
            this.btnedit.Text = obj_interface_language.buttonbtnEdit;
            this.btndelete.Text = obj_interface_language.buttonbtnDelete;
            this.btnundo.Text = obj_interface_language.buttonbtnUndo;
            this.btnexit.Text = obj_interface_language.buttonCompanyExit;
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GeneralFunctions.ValidateString(txtJournalCode.Text, "Please Specify the Journal Code")
                && GeneralFunctions.ValidateString(txtJournalDescription.Text, "Please Specify the Journal Description"))
            {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select JournalCodeID from GLJournalCodes where JournalCodeID = '" + txt_JournalCodeID.Text + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("JournalCodeID = '" + txt_JournalCodeID.Text + "'", dbAccountingProjectDS.GLJournalCodes))
                {
                    DataRow r = dbAccountingProjectDS.GLJournalCodes.NewRow();
                    r["JournalCodeID"] = currentJournalCode;
                    GeneralFunctions.JournalCodeID = currentJournalCode;
                    //currentJournalCode = GeneralFunctions.JournalCodeID;
                    r["JournalCode"] = txtJournalCode.Text;
                    r["JournalDescription"] = txtJournalDescription.Text;
                    dbAccountingProjectDS.GLJournalCodes.Rows.Add(r);
                    dr.Close();
                    sqlcon.Close();
                    adapter.Update(dbAccountingProjectDS.GLJournalCodes);
                    dbAccountingProjectDS.AcceptChanges();
                    SqlConnection sqlcon1 = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlcon1.Open();
                    SqlCommand command = new SqlCommand("Select MAX(JournalCodeID)+1 from GLJournalCodes ", sqlcon1);
                    int MaxNumber;
                    if (command.ExecuteScalar() != DBNull.Value)
                    {
                        MaxNumber = Convert.ToInt32(command.ExecuteScalar());
                        txt_JournalCodeID.Text = Convert.ToString(MaxNumber);
                        currentJournalCode = MaxNumber;
                    }
                    else
                    {
                        MaxNumber = 1;
                        txt_JournalCodeID.Text = Convert.ToString(MaxNumber);
                        currentJournalCode = MaxNumber;
                    }
                    txt_JournalCodeID.Text = currentJournalCode.ToString();
                    txtJournalCode.Text = "";
                    txtJournalDescription.Text = "";
                    sqlcon1.Close();
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Journal Code already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.GLJournalCodes.Select("JournalCodeID = '" + txt_JournalCodeID.Text + "'");
                        rArr[0]["JournalCode"] = txtJournalCode.Text;
                        rArr[0]["JournalDescription"] = txtJournalDescription.Text;
                        adapter.Update(dbAccountingProjectDS.GLJournalCodes);
                        dbAccountingProjectDS.AcceptChanges();
                        SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                        sqlcon2.Open();
                        SqlCommand command2 = new SqlCommand("Select MAX(JournalCodeID)+1 from GLJournalCodes ", sqlcon2);
                        int MaxNumber2;
                        if (command2.ExecuteScalar() != DBNull.Value)
                        {
                            MaxNumber2 = Convert.ToInt32(command2.ExecuteScalar());
                            txt_JournalCodeID.Text = Convert.ToString(MaxNumber2);
                            currentJournalCode = MaxNumber2;
                        }
                        else
                        {
                            MaxNumber2 = 1;
                            txt_JournalCodeID.Text = Convert.ToString(MaxNumber2);
                            currentJournalCode = MaxNumber2;
                        }
                        txt_JournalCodeID.Text = currentJournalCode.ToString();
                        txtJournalCode.Text = "";
                        txtJournalDescription.Text = "";
                    }
                    else
                    {
                        SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
                        sqlcon3.Open();
                        SqlCommand command3 = new SqlCommand("Select MAX(JournalCodeID)+1 from GLJournalCodes ", sqlcon3);
                        int MaxNumber3;
                        if (command3.ExecuteScalar() != DBNull.Value)
                        {
                            MaxNumber3 = Convert.ToInt32(command3.ExecuteScalar());
                            txt_JournalCodeID.Text = Convert.ToString(MaxNumber3);
                            currentJournalCode = MaxNumber3;
                        }
                        else
                        {
                            MaxNumber3 = 1;
                            txt_JournalCodeID.Text = Convert.ToString(MaxNumber3);
                            currentJournalCode = MaxNumber3;
                        }
                        txt_JournalCodeID.Text = currentJournalCode.ToString();
                        txtJournalCode.Text = "";
                        txtJournalDescription.Text = "";
                    }
                    dr.Close();
                    sqlcon.Close();
                }
            }
            else
                MessageBox.Show("Please Insert acceptable values");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                dbAccountingProjectDS.GLJournalCodes.Rows[dgv.SelectedRows[0].Index].Delete();
                adapter.Update(dbAccountingProjectDS.GLJournalCodes);
                dbAccountingProjectDS.AcceptChanges();
                SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlcon2.Open();
                SqlCommand command2 = new SqlCommand("Select MAX(JournalCodeID)+1 from GLJournalCodes ", sqlcon2);
                int MaxNumber2;
                if (command2.ExecuteScalar() != DBNull.Value)
                {
                    MaxNumber2 = Convert.ToInt32(command2.ExecuteScalar());
                    txt_JournalCodeID.Text = Convert.ToString(MaxNumber2);
                    currentJournalCode = MaxNumber2;
                }
                else
                {
                    MaxNumber2 = 1;
                    txt_JournalCodeID.Text = Convert.ToString(MaxNumber2);
                    currentJournalCode = MaxNumber2;
                }
                txt_JournalCodeID.Text = currentJournalCode.ToString();
                txtJournalCode.Text = "";
                txtJournalDescription.Text = "";
            }
            else
            {
                if (GeneralFunctions.ValidateString(txtJournalCode.Text, "Please Specify the Journal Code"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.GLJournalCodes.Select("JournalCodeID = '" + txt_JournalCodeID.Text + "'");
                    if (rArr.Length != 0)
                    {
                        rArr[0].Delete();
                        adapter.Update(dbAccountingProjectDS.GLJournalCodes);
                        dbAccountingProjectDS.AcceptChanges();
                        SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                        sqlcon2.Open();
                        SqlCommand command2 = new SqlCommand("Select MAX(JournalCodeID)+1 from GLJournalCodes ", sqlcon2);
                        int MaxNumber2;
                        if (command2.ExecuteScalar() != DBNull.Value)
                        {
                            MaxNumber2 = Convert.ToInt32(command2.ExecuteScalar());
                            txt_JournalCodeID.Text = Convert.ToString(MaxNumber2);
                            currentJournalCode = MaxNumber2;
                        }
                        else
                        {
                            MaxNumber2 = 1;
                            txt_JournalCodeID.Text = Convert.ToString(MaxNumber2);
                            currentJournalCode = MaxNumber2;
                        }
                        txt_JournalCodeID.Text = currentJournalCode.ToString();
                        txtJournalCode.Text = "";
                        txtJournalDescription.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("The given Journal Code doesnt exist \n Cant perform delete operation");
                    }
                }
            }
            dgv.ClearSelection();
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataRow r = dbAccountingProjectDS.GLJournalCodes.Rows[dgv.SelectedRows[0].Index];
                txt_JournalCodeID.Text = r["JournalCodeID"].ToString();
                txtJournalCode.Text = r["JournalCode"].ToString();
                txtJournalDescription.Text = r["JournalDescription"].ToString();
                GB1.Enabled = false;
                btnedit.Enabled = true;
                btndelete.Enabled = true;
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (GeneralFunctions.ValidateString(txtJournalCode.Text, "Please Specify the Journal Code")
                && GeneralFunctions.ValidateString(txtJournalDescription.Text, "Please Specify the Journal Description"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.GLJournalCodes.Select("JournalCodeID = '" + txt_JournalCodeID.Text + "'");
                    rArr[0]["JournalCode"] = txtJournalCode.Text;
                    rArr[0]["JournalDescription"] = txtJournalDescription.Text;
                    adapter.Update(dbAccountingProjectDS.GLJournalCodes);
                    dbAccountingProjectDS.AcceptChanges();
                    SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlcon2.Open();
                    SqlCommand command2 = new SqlCommand("Select MAX(JournalCodeID)+1 from GLJournalCodes ", sqlcon2);
                    int MaxNumber2;
                    if (command2.ExecuteScalar() != DBNull.Value)
                    {
                        MaxNumber2 = Convert.ToInt32(command2.ExecuteScalar());
                        txt_JournalCodeID.Text = Convert.ToString(MaxNumber2);
                        currentJournalCode = MaxNumber2;
                    }
                    else
                    {
                        MaxNumber2 = 1;
                        txt_JournalCodeID.Text = Convert.ToString(MaxNumber2);
                        currentJournalCode = MaxNumber2;
                    }
                    txt_JournalCodeID.Text = currentJournalCode.ToString();
                    txtJournalCode.Text = "";
                    txtJournalDescription.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please Select the row that you want to edit");
            }
            dgv.ClearSelection();
        }



        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GLJournalCodes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GB1.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void btnundo_Click(object sender, EventArgs e)
        {
            if (sender.ToString() != "NO")
            {
                if (GB1.Enabled == true)
                {
                    DialogResult myrst;
                    myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (myrst == DialogResult.No)
                        return;
                }
            }
            SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon2.Open();
            SqlCommand command2 = new SqlCommand("Select MAX(JournalCodeID)+1 from GLJournalCodes ", sqlcon2);
            int MaxNumber2;
            if (command2.ExecuteScalar() != DBNull.Value)
            {
                MaxNumber2 = Convert.ToInt32(command2.ExecuteScalar());
                txt_JournalCodeID.Text = Convert.ToString(MaxNumber2);
                currentJournalCode = MaxNumber2;
            }
            else
            {
                MaxNumber2 = 1;
                txt_JournalCodeID.Text = Convert.ToString(MaxNumber2);
                currentJournalCode = MaxNumber2;
            }
            txt_JournalCodeID.Text = currentJournalCode.ToString();
            txtJournalCode.Text = "";
            txtJournalDescription.Text = "";
            // ClearAll();

            btn_New.Visible = true;
            btnSavenew.Visible = false;
            btnedit.Visible = true;
            Btnsaveedit.Visible = false;
            GB1.Enabled = false;
            btn_New.Enabled = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult myrst;
            myrst = MessageBox.Show("Are You Sure Delete This Journal Code", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return;
            if (dgv.SelectedRows.Count > 0)
            {
                dbAccountingProjectDS.GLJournalCodes.Rows[dgv.SelectedRows[0].Index].Delete();
                adapter.Update(dbAccountingProjectDS.GLJournalCodes);
                dbAccountingProjectDS.AcceptChanges();
                SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlcon2.Open();
                SqlCommand command2 = new SqlCommand("Select MAX(JournalCodeID)+1 from GLJournalCodes ", sqlcon2);
                int MaxNumber2;
                if (command2.ExecuteScalar() != DBNull.Value)
                {
                    MaxNumber2 = Convert.ToInt32(command2.ExecuteScalar());
                    txt_JournalCodeID.Text = Convert.ToString(MaxNumber2);
                    currentJournalCode = MaxNumber2;
                }
                else
                {
                    MaxNumber2 = 1;
                    txt_JournalCodeID.Text = Convert.ToString(MaxNumber2);
                    currentJournalCode = MaxNumber2;
                }
                txt_JournalCodeID.Text = currentJournalCode.ToString();
                txtJournalCode.Text = "";
                txtJournalDescription.Text = "";
                dgv.ClearSelection();
                btnedit.Enabled = false;
                btndelete.Enabled = false;
            }
            else
            {
                if (GeneralFunctions.ValidateString(txtJournalCode.Text, "Please Specify the Journal Code"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.GLJournalCodes.Select("JournalCodeID = '" + txt_JournalCodeID.Text + "'");
                    if (rArr.Length != 0)
                    {
                        rArr[0].Delete();
                        adapter.Update(dbAccountingProjectDS.GLJournalCodes);
                        dbAccountingProjectDS.AcceptChanges();
                        SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                        sqlcon2.Open();
                        SqlCommand command2 = new SqlCommand("Select MAX(JournalCodeID)+1 from GLJournalCodes ", sqlcon2);
                        int MaxNumber2;
                        if (command2.ExecuteScalar() != DBNull.Value)
                        {
                            MaxNumber2 = Convert.ToInt32(command2.ExecuteScalar());
                            txt_JournalCodeID.Text = Convert.ToString(MaxNumber2);
                            currentJournalCode = MaxNumber2;
                        }
                        else
                        {
                            MaxNumber2 = 1;
                            txt_JournalCodeID.Text = Convert.ToString(MaxNumber2);
                            currentJournalCode = MaxNumber2;
                        }
                        txt_JournalCodeID.Text = currentJournalCode.ToString();
                        txtJournalCode.Text = "";
                        txtJournalDescription.Text = "";
                        dgv.ClearSelection();
                        btnedit.Enabled = false;
                        btndelete.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("The given Journal Code doesnt exist \n Cant perform delete operation");
                    }
                }
            }
            dgv.ClearSelection();
            btnedit.Enabled = false;
            btndelete.Enabled = false;
        }

        private void Btnsaveedit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (GeneralFunctions.ValidateString(txtJournalCode.Text, "Please Specify the Journal Code")
                && GeneralFunctions.ValidateString(txtJournalDescription.Text, "Please Specify the Journal Description"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.GLJournalCodes.Select("JournalCodeID = '" + txt_JournalCodeID.Text + "'");
                    rArr[0]["JournalCode"] = txtJournalCode.Text;
                    rArr[0]["JournalDescription"] = txtJournalDescription.Text;
                    adapter.Update(dbAccountingProjectDS.GLJournalCodes);
                    dbAccountingProjectDS.AcceptChanges();
                    SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlcon2.Open();
                    SqlCommand command2 = new SqlCommand("Select MAX(JournalCodeID)+1 from GLJournalCodes ", sqlcon2);
                    int MaxNumber2;
                    if (command2.ExecuteScalar() != DBNull.Value)
                    {
                        MaxNumber2 = Convert.ToInt32(command2.ExecuteScalar());
                        txt_JournalCodeID.Text = Convert.ToString(MaxNumber2);
                        currentJournalCode = MaxNumber2;
                    }
                    else
                    {
                        MaxNumber2 = 1;
                        txt_JournalCodeID.Text = Convert.ToString(MaxNumber2);
                        currentJournalCode = MaxNumber2;
                    }
                    txt_JournalCodeID.Text = currentJournalCode.ToString();
                    txtJournalCode.Text = "";
                    txtJournalDescription.Text = "";
                    dgv.ClearSelection();
                    GB1.Enabled = false;
                    btnedit.Visible = true;
                    Btnsaveedit.Visible = false;
                    btn_New.Enabled = true;
                    btndelete.Enabled = false;
                    btnedit.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please Select the row that you want to edit");
            }
            dgv.ClearSelection();
            GB1.Enabled = false;
            btnedit.Visible = true;
            Btnsaveedit.Visible = false;
            btn_New.Enabled = true;
            btndelete.Enabled = false;
            btnedit.Enabled = false;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
                GB1.Enabled = true;
                btnedit.Visible = false;
                Btnsaveedit.Visible = true;
                btn_New.Enabled = false;
                btndelete.Enabled = false;
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon5 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon5.Open();
            SqlCommand command5 = new SqlCommand("Select MAX(JournalCodeID)+1 from GLJournalCodes ", sqlcon5);
            int MaxNumber5;
            if (command5.ExecuteScalar() != DBNull.Value)
            {
                MaxNumber5 = Convert.ToInt32(command5.ExecuteScalar());
                txt_JournalCodeID.Text = Convert.ToString(MaxNumber5);
                currentJournalCode = MaxNumber5;
            }
            else
            {
                MaxNumber5 = 1;
                txt_JournalCodeID.Text = Convert.ToString(MaxNumber5);
                currentJournalCode = MaxNumber5;
            }
            txt_JournalCodeID.Text = currentJournalCode.ToString();
            txtJournalCode.Text = "";
            txtJournalDescription.Text = "";
            GB1.Enabled = true;
            btn_New.Visible = false;
            btnSavenew.Visible = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
        }

        private void btnSavenew_Click(object sender, EventArgs e)
        {
            if (GeneralFunctions.ValidateString(txtJournalCode.Text, "Please Specify the Journal Code")
            && GeneralFunctions.ValidateString(txtJournalDescription.Text, "Please Specify the Journal Description"))
            {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select JournalCodeID from GLJournalCodes where JournalCodeID = '" + txt_JournalCodeID.Text + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("JournalCodeID = '" + txt_JournalCodeID.Text + "'", dbAccountingProjectDS.GLJournalCodes))
                {
                    DataRow r = dbAccountingProjectDS.GLJournalCodes.NewRow();
                    r["JournalCodeID"] = currentJournalCode;
                    GeneralFunctions.JournalCodeID = currentJournalCode;
                    //currentJournalCode = GeneralFunctions.JournalCodeID;
                    r["JournalCode"] = txtJournalCode.Text;
                    r["JournalDescription"] = txtJournalDescription.Text;
                    dbAccountingProjectDS.GLJournalCodes.Rows.Add(r);
                    dr.Close();
                    sqlcon.Close();
                    adapter.Update(dbAccountingProjectDS.GLJournalCodes);
                    dbAccountingProjectDS.AcceptChanges();
                    SqlConnection sqlcon1 = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlcon1.Open();
                    SqlCommand command = new SqlCommand("Select MAX(JournalCodeID)+1 from GLJournalCodes ", sqlcon1);
                    int MaxNumber;
                    if (command.ExecuteScalar() != DBNull.Value)
                    {
                        MaxNumber = Convert.ToInt32(command.ExecuteScalar());
                        txt_JournalCodeID.Text = Convert.ToString(MaxNumber);
                        currentJournalCode = MaxNumber;
                    }
                    else
                    {
                        MaxNumber = 1;
                        txt_JournalCodeID.Text = Convert.ToString(MaxNumber);
                        currentJournalCode = MaxNumber;
                    }
                    txt_JournalCodeID.Text = currentJournalCode.ToString();
                    txtJournalCode.Text = "";
                    txtJournalDescription.Text = "";
                    GB1.Enabled = false;
                    btn_New.Visible = true;
                    btnSavenew.Visible = false;
                    sqlcon1.Close();
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Journal Code already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.GLJournalCodes.Select("JournalCodeID = '" + txt_JournalCodeID.Text + "'");
                        rArr[0]["JournalCode"] = txtJournalCode.Text;
                        rArr[0]["JournalDescription"] = txtJournalDescription.Text;
                        adapter.Update(dbAccountingProjectDS.GLJournalCodes);
                        dbAccountingProjectDS.AcceptChanges();
                        SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                        sqlcon2.Open();
                        SqlCommand command2 = new SqlCommand("Select MAX(JournalCodeID)+1 from GLJournalCodes ", sqlcon2);
                        int MaxNumber2;
                        if (command2.ExecuteScalar() != DBNull.Value)
                        {
                            MaxNumber2 = Convert.ToInt32(command2.ExecuteScalar());
                            txt_JournalCodeID.Text = Convert.ToString(MaxNumber2);
                            currentJournalCode = MaxNumber2;
                        }
                        else
                        {
                            MaxNumber2 = 1;
                            txt_JournalCodeID.Text = Convert.ToString(MaxNumber2);
                            currentJournalCode = MaxNumber2;
                        }
                        txt_JournalCodeID.Text = currentJournalCode.ToString();
                        txtJournalCode.Text = "";
                        txtJournalDescription.Text = "";
                        GB1.Enabled = false;
                        btn_New.Visible = true;
                        btnSavenew.Visible = false;
                    }
                    else
                    {
                        SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
                        sqlcon3.Open();
                        SqlCommand command3 = new SqlCommand("Select MAX(JournalCodeID)+1 from GLJournalCodes ", sqlcon3);
                        int MaxNumber3;
                        if (command3.ExecuteScalar() != DBNull.Value)
                        {
                            MaxNumber3 = Convert.ToInt32(command3.ExecuteScalar());
                            txt_JournalCodeID.Text = Convert.ToString(MaxNumber3);
                            currentJournalCode = MaxNumber3;
                        }
                        else
                        {
                            MaxNumber3 = 1;
                            txt_JournalCodeID.Text = Convert.ToString(MaxNumber3);
                            currentJournalCode = MaxNumber3;
                        }
                        txt_JournalCodeID.Text = currentJournalCode.ToString();
                        txtJournalCode.Text = "";
                        txtJournalDescription.Text = "";
                        GB1.Enabled = false;
                        btn_New.Visible = true;
                        btnSavenew.Visible = false;
                    }
                    dr.Close();
                    sqlcon.Close();
                }
            }
            else
                MessageBox.Show("Please Insert acceptable values");
        }


    }
}