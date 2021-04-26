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
    public partial class ProjectCodes : Form
    {
        private double budget;
        private SqlConnection sqlcon;
        private SqlDataAdapter adapterProjectCodes;
        private SqlDataAdapter adapterCurrency;
        private SqlCommandBuilder cmdBuilder;
        private SqlDataAdapter adaptertbGeneralSetup;
        private int currentProjectCodeID;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        private int decmal = 1;

        public ProjectCodes()
        {
            InitializeComponent();
        }

        private void ProjectCodes_Load(object sender, EventArgs e)
        {
            GeneralFunctions.priviledgeGroupBox(Lock48);
            GeneralFunctions.priviledgeGroupBox(Lock49);
            GeneralFunctions.priviledgeGroupBox(Lock50);
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adapterProjectCodes = new SqlDataAdapter("Select * from GLProjectCodes", sqlcon);
            adapterCurrency = new SqlDataAdapter("Select * from GLCurrency", sqlcon);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            cmdBuilder = new SqlCommandBuilder(adapterProjectCodes);
            adapterProjectCodes.Fill(dbAccountingProjectDS.GLProjectCodes);
            adapterCurrency.Fill(dbAccountingProjectDS.GLCurrency);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            dgv.ClearSelection();
            foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            {
                decmal = int.Parse(dr["DecimalPointsNumber"].ToString());
            }
            cb_Currency = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLCurrency, cb_Currency, "CurrencyCode", "CurrencyNumber");

            SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon3.Open();
            SqlCommand GetProjectCodeID = new SqlCommand("Select MAX(ProjectCodeID)+1 From GLProjectCodes", sqlcon3);
            if (GetProjectCodeID.ExecuteScalar() != DBNull.Value)
            {
                GeneralFunctions.ProjectCodeID = Convert.ToInt32(GetProjectCodeID.ExecuteScalar());
            }
            else
                GeneralFunctions.ProjectCodeID = 1;

            currentProjectCodeID = GeneralFunctions.ProjectCodeID;
            txt_ProjectCodeID.Text = currentProjectCodeID.ToString();
            dgv.Enabled = true;

            if (GeneralFunctions.languagechioce != "")
            {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }
            btnDelete.Enabled = false;
            btnedit.Enabled = false;
        }

        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.formProjectCodes;
            this.dgv.Columns[0].HeaderText = obj_interface_language.dgvProjectCodesColumn1.ToString();
            this.dgv.Columns[1].HeaderText = obj_interface_language.dgvProjectCodesColumn2.ToString();
            this.dgv.Columns[2].HeaderText = obj_interface_language.dgvProjectCodesColumn3.ToString();
            this.dgv.Columns[3].HeaderText = obj_interface_language.dgvProjectCodesColumn4.ToString();
            this.dgv.Columns[4].HeaderText = obj_interface_language.dgvProjectCodesColumn5.ToString();
            this.dgv.Columns[5].HeaderText = obj_interface_language.dgvProjectCodesColumn6.ToString();
            this.dgv.Columns[6].HeaderText = obj_interface_language.dgvProjectCodesColumn7.ToString();
            this.label7.Text = obj_interface_language.labelProjectCodeID;
            this.label1.Text = obj_interface_language.labelProjectCode;
            this.label2.Text = obj_interface_language.labelProjectDescription;
            this.label3.Text = obj_interface_language.labelBudget;
            this.label4.Text = obj_interface_language.labelStartDate;
            this.label5.Text = obj_interface_language.labelEndDate;
            this.label6.Text = obj_interface_language.labelProjectCodeStatus;
            this.checkBox_Active.Text = obj_interface_language.checkbox_ProjectCodeActive;
            this.btn_New.Text = obj_interface_language.buttonbtnNew;
            this.btnedit.Text = obj_interface_language.buttonbtnEdit;
            this.btnDelete.Text = obj_interface_language.buttonbtnDelete;
            this.btnUndo.Text = obj_interface_language.buttonbtnUndo;
            this.btnExit.Text = obj_interface_language.buttonCompanyExit;
            this.btnSavenew.Text = obj_interface_language.buttonJVTransactionSaveNew;
            this.Btnsaveedit.Text = obj_interface_language.buttonJVTransactionSaveEdit;
        }

        //private void btn_SaveChanges_Click(object sender, EventArgs e)
        //{
        //    adapterProjectCodes.Update(dbAccountingProjectDS.GLProjectCodes);
        //    dbAccountingProjectDS.AcceptChanges();
        //}

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GeneralFunctions.ValidateString(txt_ProjectCode.Text, "Please Specify the Project Code")
                && GeneralFunctions.ValidateString(txt_ProjectDescription.Text, "Please Specify the Project Code Description")
                && GeneralFunctions.ValidateDouble(txt_Budget.Text, "Please Specify the Budget Value", out budget)
                && GeneralFunctions.ValidateComboBox(cb_Currency, "Please Specify an appropriate currency"))
            {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select ProjectCodeID from GLProjectCodes where ProjectCodeID = '" + txt_ProjectCodeID.Text + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("ProjectCodeID = '" + txt_ProjectCodeID.Text + "'", dbAccountingProjectDS.GLProjectCodes))
                {
                    DataRow r = dbAccountingProjectDS.GLProjectCodes.NewRow();
                    r["ProjectCodeID"] = currentProjectCodeID;
                    GeneralFunctions.ProjectCodeID++;
                    currentProjectCodeID = GeneralFunctions.ProjectCodeID;
                    r["ProjectCode"] = txt_ProjectCode.Text;
                    r["ProjectDescription"] = txt_ProjectDescription.Text;
                    r["Budget"] = budget;
                    r["BudgetCurrencyCode"] = cb_Currency.Text;
                    r["StartDate"] = DTP_StartDate.Text;
                    r["EndDate"] = DTP_EndDate.Text;
                    if (checkBox_Active.Checked)
                        r["Active"] = 1;
                    else
                        r["Active"] = 0;
                    dbAccountingProjectDS.GLProjectCodes.Rows.Add(r);
                    dr.Close();
                    sqlcon.Close();
                    ClearAll();
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Project Code already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.GLProjectCodes.Select("ProjectCodeID = '" + txt_ProjectCodeID.Text + "'");
                        rArr[0]["ProjectCode"] = txt_ProjectCode.Text;
                        rArr[0]["ProjectDescription"] = txt_ProjectDescription.Text;
                        rArr[0]["Budget"] = budget;
                        rArr[0]["BudgetCurrencyCode"] = cb_Currency.Text;
                        rArr[0]["StartDate"] = DTP_StartDate.Text;
                        rArr[0]["EndDate"] = DTP_EndDate.Text;
                        if (checkBox_Active.Checked)
                            rArr[0]["Active"] = 1;
                        else
                            rArr[0]["Active"] = 0;
                        ClearAll();
                    }
                    else
                        ClearAll();
                    dr.Close();
                    sqlcon.Close();
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (GeneralFunctions.ValidateString(txt_ProjectCode.Text, "Please Specify the Project Code")
                && GeneralFunctions.ValidateString(txt_ProjectDescription.Text, "Please Specify the Project Code Description")
                && GeneralFunctions.ValidateDouble(txt_Budget.Text, "Please Specify the Budget Value", out budget)
                && GeneralFunctions.ValidateComboBox(cb_Currency, "Please Specify an appropriate currency"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.GLProjectCodes.Select("ProjectCodeID = '" + txt_ProjectCodeID.Text + "'");
                    rArr[0]["ProjectCode"] = txt_ProjectCode.Text;
                    rArr[0]["ProjectDescription"] = txt_ProjectDescription.Text;
                    rArr[0]["Budget"] = budget;
                    rArr[0]["BudgetCurrencyCode"] = cb_Currency.Text;
                    rArr[0]["StartDate"] = DTP_StartDate.Text;
                    rArr[0]["EndDate"] = DTP_EndDate.Text;
                    if (checkBox_Active.Checked)
                        rArr[0]["Active"] = 1;
                    else
                        rArr[0]["Active"] = 0;
                }
            }
            else
            {
                MessageBox.Show("Please Select the row that you want to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgv.ClearSelection();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                dbAccountingProjectDS.GLProjectCodes.Rows[dgv.SelectedRows[0].Index].Delete();
                ClearAll();
            }
            else
            {
                if (GeneralFunctions.ValidateString(txt_ProjectCode.Text, "Please Specify the Project Code"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.GLProjectCodes.Select("ProjectCode = '" + txt_ProjectCode.Text + "'");
                    if (rArr.Length != 0)
                    {
                        rArr[0].Delete();
                        ClearAll();
                    }
                    else
                    {
                        MessageBox.Show("The given Project Code doesnt exist \n Cant perform delete operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            dgv.ClearSelection();
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataRow r = dbAccountingProjectDS.GLProjectCodes.Rows[dgv.SelectedRows[0].Index];
                txt_ProjectCodeID.Text = r["ProjectCodeID"].ToString();
                txt_ProjectCode.Text = r["ProjectCode"].ToString();
                txt_ProjectDescription.Text = r["ProjectDescription"].ToString();
                txt_Budget.Text = r["Budget"].ToString();
                cb_Currency.Text = r["BudgetCurrencyCode"].ToString();
                DTP_StartDate.Text = r["StartDate"].ToString();
                DTP_EndDate.Text = r["EndDate"].ToString();
                if (r["Active"].ToString() == "True")
                    checkBox_Active.Checked = true;
                else
                    checkBox_Active.Checked = false;
                GB1.Enabled = false;
                btnedit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void ClearAll()
        {
            SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon3.Open();
            SqlCommand GetProjectCodeID = new SqlCommand("Select MAX(ProjectCodeID)+1 From GLProjectCodes", sqlcon3);
            if (GetProjectCodeID.ExecuteScalar() != DBNull.Value)
            {
                GeneralFunctions.ProjectCodeID = Convert.ToInt32(GetProjectCodeID.ExecuteScalar());
            }
            else
                GeneralFunctions.ProjectCodeID = 1;

            currentProjectCodeID = GeneralFunctions.ProjectCodeID;
            txt_ProjectCodeID.Text = currentProjectCodeID.ToString();

            txt_ProjectCode.Text = "";
            txt_ProjectDescription.Text = "";
            txt_Budget.Text = "";
            cb_Currency.SelectedIndex = -1;
            DTP_StartDate.Text = "";
            DTP_EndDate.Text = "";
            checkBox_Active.Checked = false;
            sqlcon3.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult myrst;
            myrst = MessageBox.Show("Are You Sure Delete This Project Code", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return;
            if (dgv.SelectedRows.Count > 0)
            {
                dbAccountingProjectDS.GLProjectCodes.Rows[dgv.SelectedRows[0].Index].Delete();
                ClearAll();
                adapterProjectCodes.Update(dbAccountingProjectDS.GLProjectCodes);
                dbAccountingProjectDS.AcceptChanges();
                dgv.ClearSelection();
                btnedit.Enabled = false;
                btnDelete.Enabled = false;

            }
            else
            {
                if (GeneralFunctions.ValidateString(txt_ProjectCode.Text, "Please Specify the Project Code"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.GLProjectCodes.Select("ProjectCode = '" + txt_ProjectCode.Text + "'");
                    if (rArr.Length != 0)
                    {
                        rArr[0].Delete();
                        ClearAll();
                        adapterProjectCodes.Update(dbAccountingProjectDS.GLProjectCodes);
                        dbAccountingProjectDS.AcceptChanges();
                        dgv.ClearSelection();
                        btnedit.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("The given Project Code doesnt exist \n Cant perform delete operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            dgv.ClearSelection();
            btnedit.Enabled = false;
            btnDelete.Enabled = false;
            SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon3.Open();
            SqlCommand GetProjectCodeID = new SqlCommand("Select MAX(ProjectCodeID)+1 From GLProjectCodes", sqlcon3);
            if (GetProjectCodeID.ExecuteScalar() != DBNull.Value)
            {
                GeneralFunctions.ProjectCodeID = Convert.ToInt32(GetProjectCodeID.ExecuteScalar());
            }
            else
                GeneralFunctions.ProjectCodeID = 1;

            currentProjectCodeID = GeneralFunctions.ProjectCodeID;
            txt_ProjectCodeID.Text = currentProjectCodeID.ToString();
            GeneralFunctions.UnLockTable("", "ProjectCodes", "", "Edit");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                if (txt_Budget.Text.Contains("."))
                {
                    char c = '.';
                    string[] sc = txt_Budget.Text.Split(c);

                    if (sc[1].Length < decmal)
                        e.Handled = false;
                    else
                        e.Handled = true;

                }
                else
                    e.Handled = false;

            }
            else if (e.KeyChar == 46)
            {
                if (txt_Budget.Text.Contains(".") == false)
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            else
                e.Handled = true;
            //switch (Convert.ToInt16(e.KeyChar)){
            //    case (short)Keys.Back:
            //    case (short) Keys.Enter:
            //    case (short) Keys.Escape:
            //    case (short) Keys.Delete:
            //        return;
            //    default:
            //        e.Handled = !Char.IsDigit(e.KeyChar );
            //        break;
            //}
        }

        private void btnUndo_Click(object sender, EventArgs e)
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
            SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon3.Open();
            SqlCommand GetProjectCodeID = new SqlCommand("Select MAX(ProjectCodeID)+1 From GLProjectCodes", sqlcon3);
            if (GetProjectCodeID.ExecuteScalar() != DBNull.Value)
            {
                GeneralFunctions.ProjectCodeID = Convert.ToInt32(GetProjectCodeID.ExecuteScalar());
            }
            else
                GeneralFunctions.ProjectCodeID = 1;

            currentProjectCodeID = GeneralFunctions.ProjectCodeID;
            txt_ProjectCodeID.Text = currentProjectCodeID.ToString();
            ClearAll();

            btn_New.Visible = true;
            btnSavenew.Visible = false;
            btnedit.Visible = true;
            Btnsaveedit.Visible = false;
            GB1.Enabled = false;
            btn_New.Enabled = true;
            btnedit.Enabled = false;
            btnDelete.Enabled = false;
            GeneralFunctions.UnLockTable("", "ProjectCodes", "", "Edit");
            GeneralFunctions.UnLockTable("", "ProjectCodes", "", "New");

        }

        private void cb_Currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Currency.Text == "<new>")
            {
                Currency curr = new Currency();
                curr.ShowDialog();
                cb_Currency.Items.Clear();
                adapterCurrency.Fill(dbAccountingProjectDS.GLCurrency);
                cb_Currency = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLCurrency, cb_Currency, "CurrencyCode", "CurrencyNumber");
            }
        }

        private void ProjectCodes_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralFunctions.UnLockTable("", "ProjectCodes", "", "");
            GeneralFunctions.UnLockTable("", "ProjectCodes", "", "");
        }

        private void GB1_EnabledChanged(object sender, EventArgs e)
        {
            if (GB1.Enabled == true)
                dgv.Enabled = false;
            else
                dgv.Enabled = true;
        }

        private void btnSavenew_Click(object sender, EventArgs e)
        {
            //if (GeneralFunctions.ValidateString(txt_ProjectCode.Text, "Please Specify the Project Code")
            //&& GeneralFunctions.ValidateString(txt_ProjectDescription.Text, "Please Specify the Project Code Description")
            //&& GeneralFunctions.ValidateDouble(txt_Budget.Text, "Please Specify the Budget Value", out budget)
            //&& GeneralFunctions.ValidateComboBox(cb_Currency, "Please Specify an appropriate currency"))
            if (GeneralFunctions.ValidateString(txt_ProjectCode.Text, "Please Specify the Project Code")
            && GeneralFunctions.ValidateString(txt_ProjectDescription.Text, "Please Specify the Project Code Description")
            && GeneralFunctions.ValidateDouble(txt_Budget.Text, "Please Specify the Budget Value", out budget))
            {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select ProjectCodeID from GLProjectCodes where ProjectCodeID = '" + txt_ProjectCodeID.Text + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("ProjectCodeID = '" + txt_ProjectCodeID.Text + "'", dbAccountingProjectDS.GLProjectCodes))
                {
                    DataRow r = dbAccountingProjectDS.GLProjectCodes.NewRow();
                    r["ProjectCodeID"] = currentProjectCodeID;
                    GeneralFunctions.ProjectCodeID++;
                    currentProjectCodeID = GeneralFunctions.ProjectCodeID;
                    r["ProjectCode"] = txt_ProjectCode.Text;
                    r["ProjectDescription"] = txt_ProjectDescription.Text;
                    r["Budget"] = budget;
                    r["BudgetCurrencyCode"] = cb_Currency.Text;
                    r["StartDate"] = DTP_StartDate.Text;
                    r["EndDate"] = DTP_EndDate.Text;
                    if (checkBox_Active.Checked)
                        r["Active"] = 1;
                    else
                        r["Active"] = 0;
                    dbAccountingProjectDS.GLProjectCodes.Rows.Add(r);
                    dr.Close();
                    sqlcon.Close();
                    ClearAll();
                    adapterProjectCodes.Update(dbAccountingProjectDS.GLProjectCodes);
                    dbAccountingProjectDS.AcceptChanges();
                    SqlConnection sqlcon2 = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlcon2.Open();
                    SqlCommand GetProjectCodeID2 = new SqlCommand("Select MAX(ProjectCodeID)+1 From GLProjectCodes", sqlcon2);
                    if (GetProjectCodeID2.ExecuteScalar() != DBNull.Value)
                    {
                        GeneralFunctions.ProjectCodeID = Convert.ToInt32(GetProjectCodeID2.ExecuteScalar());
                    }
                    else
                        GeneralFunctions.ProjectCodeID = 1;
                    currentProjectCodeID = GeneralFunctions.ProjectCodeID;
                    txt_ProjectCodeID.Text = currentProjectCodeID.ToString();
                    GB1.Enabled = false;
                    btn_New.Visible = true;
                    btnSavenew.Visible = false;
                    GeneralFunctions.UnLockTable("", "ProjectCodes", "", "New");
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Project Code already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.GLProjectCodes.Select("ProjectCodeID = '" + txt_ProjectCodeID.Text + "'");
                        rArr[0]["ProjectCode"] = txt_ProjectCode.Text;
                        rArr[0]["ProjectDescription"] = txt_ProjectDescription.Text;
                        rArr[0]["Budget"] = budget;
                        rArr[0]["BudgetCurrencyCode"] = cb_Currency.Text;
                        rArr[0]["StartDate"] = DTP_StartDate.Text;
                        rArr[0]["EndDate"] = DTP_EndDate.Text;
                        if (checkBox_Active.Checked)
                            rArr[0]["Active"] = 1;
                        else
                            rArr[0]["Active"] = 0;
                        ClearAll();
                        adapterProjectCodes.Update(dbAccountingProjectDS.GLProjectCodes);
                        dbAccountingProjectDS.AcceptChanges();
                        SqlConnection sqlcon5 = new SqlConnection(GeneralFunctions.ConnectionString);
                        sqlcon5.Open();
                        SqlCommand GetProjectCodeID1 = new SqlCommand("Select MAX(ProjectCodeID)+1 From GLProjectCodes", sqlcon5);
                        if (GetProjectCodeID1.ExecuteScalar() != DBNull.Value)
                        {
                            GeneralFunctions.ProjectCodeID = Convert.ToInt32(GetProjectCodeID1.ExecuteScalar());
                        }
                        else
                            GeneralFunctions.ProjectCodeID = 1;

                        currentProjectCodeID = GeneralFunctions.ProjectCodeID;
                        txt_ProjectCodeID.Text = currentProjectCodeID.ToString();
                        GB1.Enabled = false;
                        btn_New.Visible = true;
                        btnSavenew.Visible = false;
                    }
                    else

                        dr.Close();
                    sqlcon.Close();
                    ClearAll();
                    adapterProjectCodes.Update(dbAccountingProjectDS.GLProjectCodes);
                    dbAccountingProjectDS.AcceptChanges();
                    SqlConnection sqlcon4 = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlcon4.Open();
                    SqlCommand GetProjectCodeID4 = new SqlCommand("Select MAX(ProjectCodeID)+1 From GLProjectCodes", sqlcon4);
                    if (GetProjectCodeID4.ExecuteScalar() != DBNull.Value)
                    {
                        GeneralFunctions.ProjectCodeID = Convert.ToInt32(GetProjectCodeID4.ExecuteScalar());
                    }
                    else
                        GeneralFunctions.ProjectCodeID = 1;
                    currentProjectCodeID = GeneralFunctions.ProjectCodeID;
                    txt_ProjectCodeID.Text = currentProjectCodeID.ToString();
                    GB1.Enabled = false;
                    btn_New.Visible = true;
                    btnSavenew.Visible = false;
                    GeneralFunctions.UnLockTable("", "ProjectCodes", "", "New");
                }
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            ClearAll();
            SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon3.Open();
            SqlCommand GetProjectCodeID = new SqlCommand("Select MAX(ProjectCodeID)+1 From GLProjectCodes", sqlcon3);
            if (GetProjectCodeID.ExecuteScalar() != DBNull.Value)
            {
                GeneralFunctions.ProjectCodeID = Convert.ToInt32(GetProjectCodeID.ExecuteScalar());
            }
            else
                GeneralFunctions.ProjectCodeID = 1;
            string msg = "new";
            while (msg != "")
            {
                msg = GeneralFunctions.CheckLockTables("GLProjectCodes", "", GeneralFunctions.ProjectCodeID.ToString(), "New");
                if (msg != "")
                {
                    GeneralFunctions.ProjectCodeID = GeneralFunctions.ProjectCodeID + 1;
                }
            }
            GeneralFunctions.LockTables("GLProjectCodes", "ProjectCodes", GeneralFunctions.ProjectCodeID.ToString(), "New");

            currentProjectCodeID = GeneralFunctions.ProjectCodeID;
            txt_ProjectCodeID.Text = currentProjectCodeID.ToString();
            GB1.Enabled = true;
            btn_New.Visible = false;
            btnSavenew.Visible = true;
            btnedit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void Btnsaveedit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                //if (GeneralFunctions.ValidateString(txt_ProjectCode.Text, "Please Specify the Project Code")
                //&& GeneralFunctions.ValidateString(txt_ProjectDescription.Text, "Please Specify the Project Code Description")
                //&& GeneralFunctions.ValidateDouble(txt_Budget.Text, "Please Specify the Budget Value", out budget)
                //&& GeneralFunctions.ValidateComboBox(cb_Currency, "Please Specify an appropriate currency"))
                if (GeneralFunctions.ValidateString(txt_ProjectCode.Text, "Please Specify the Project Code")
                && GeneralFunctions.ValidateString(txt_ProjectDescription.Text, "Please Specify the Project Code Description")
                && GeneralFunctions.ValidateDouble(txt_Budget.Text, "Please Specify the Budget Value", out budget))
                {
                    DataRow[] rArr = dbAccountingProjectDS.GLProjectCodes.Select("ProjectCodeID = '" + txt_ProjectCodeID.Text + "'");
                    rArr[0]["ProjectCode"] = txt_ProjectCode.Text;
                    rArr[0]["ProjectDescription"] = txt_ProjectDescription.Text;
                    rArr[0]["Budget"] = budget;
                    rArr[0]["BudgetCurrencyCode"] = cb_Currency.Text;
                    rArr[0]["StartDate"] = DTP_StartDate.Text;
                    rArr[0]["EndDate"] = DTP_EndDate.Text;
                    if (checkBox_Active.Checked)
                        rArr[0]["Active"] = 1;
                    else
                        rArr[0]["Active"] = 0;
                    adapterProjectCodes.Update(dbAccountingProjectDS.GLProjectCodes);
                    dbAccountingProjectDS.AcceptChanges();
                    ClearAll();
                    SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlcon3.Open();
                    SqlCommand GetProjectCodeID = new SqlCommand("Select MAX(ProjectCodeID)+1 From GLProjectCodes", sqlcon3);
                    if (GetProjectCodeID.ExecuteScalar() != DBNull.Value)
                    {
                        GeneralFunctions.ProjectCodeID = Convert.ToInt32(GetProjectCodeID.ExecuteScalar());
                    }
                    else
                        GeneralFunctions.ProjectCodeID = 1;

                    currentProjectCodeID = GeneralFunctions.ProjectCodeID;
                    txt_ProjectCodeID.Text = currentProjectCodeID.ToString();
                    dgv.ClearSelection();
                    GB1.Enabled = false;
                    btnedit.Visible = true;
                    Btnsaveedit.Visible = false;
                    btn_New.Enabled = true;
                    btnDelete.Enabled = false;
                    btnedit.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please Select the row that you want to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgv.ClearSelection();
            GB1.Enabled = false;
            btnedit.Visible = true;
            Btnsaveedit.Visible = false;
            btn_New.Enabled = true;
            btnDelete.Enabled = false;
            btnedit.Enabled = false;
            GeneralFunctions.UnLockTable("", "ProjectCodes", "", "Edit");
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            string msg = GeneralFunctions.CheckLockTables("GLProjectCodes", "ProjectCodes", txt_ProjectCodeID.Text, "Edit");
            if (msg != "")
            {
                MessageBox.Show("Can't Edit This Project Because Edit By " + msg, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            GeneralFunctions.LockTables("GLProjectCodes", "ProjectCodes", txt_ProjectCodeID.Text, "Edit");

            GB1.Enabled = true;
            btnedit.Visible = false;
            Btnsaveedit.Visible = true;
            btn_New.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void ProjectCodes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GB1.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    e.Cancel = true;
            }
        }

    }
}