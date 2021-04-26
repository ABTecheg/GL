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
    public partial class Check_Book : Form
    {
        private SqlConnection sqlcon;
        private SqlDataAdapter adapter;
        private SqlDataAdapter adapterCheck_Serial;
        private SqlCommandBuilder cmdBuilder;
        private SqlCommandBuilder cmdBuilderCheck_Serial;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;

        public Check_Book()
        {
            InitializeComponent();
        }

        private void Check_Book_Load(object sender, EventArgs e)
        {
            GeneralFunctions.priviledgeGroupBox(Lock88);
            GeneralFunctions.priviledgeGroupBox(Lock90);
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adapter = new SqlDataAdapter("Select * from Check_Book", sqlcon);
            adapterCheck_Serial = new SqlDataAdapter("Select * from Checks_Serial", sqlcon);
            cmdBuilder = new SqlCommandBuilder(adapter);
            cmdBuilderCheck_Serial = new SqlCommandBuilder(adapterCheck_Serial);
            adapter.Fill(dbAccountingProjectDS.Check_Book);
            adapterCheck_Serial.Fill(dbAccountingProjectDS.Checks_Serial);


            if (GeneralFunctions.languagechioce != "")
            {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }
            DataTable DtCat = DataClass.RetrieveData("Select Bank_Account_ID,Bank_Account_Name From Bank_Account_Setup ");
            cb_Bank_Account_ID.DataSource = DtCat;
            cb_Bank_Account_ID.DisplayMember = "Bank_Account_Name";
            cb_Bank_Account_ID.ValueMember = "Bank_Account_ID";
            cb_Bank_Account_ID.SelectedIndex = -1;
            Load_Data();
        }
        private void update_language_interface()
        {
            //this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            //this.Text = obj_interface_language.formCheck_Book;
            //this.lbl_Bank_Account_Name.Text = obj_interface_language.Bank_Account_ID;
            //this.lblBank_Account_Code.Text = obj_interface_language.DeliveryTypeName;
            //this.label3.Text = obj_interface_language.Percentage;
            //this.lbl_Bank_GL_Account.Text = obj_interface_language.labelGLAccountNumber;

            //this.btn_New.Text = obj_interface_language.buttonJVTransactionNew;
            //this.btnedit.Text = obj_interface_language.buttonJVTransactionEdit;
            //this.btndelete.Text = obj_interface_language.buttonJVTransactionDelete;
            //this.btnundo.Text = obj_interface_language.buttonJVTransactionUndo;
            //this.btnexit.Text = obj_interface_language.buttonJVTransactionExit;
            //this.btnSavenew.Text = obj_interface_language.buttonJVTransactionSaveNew;
            //this.Btnsaveedit.Text = obj_interface_language.buttonJVTransactionSaveEdit;
            //this.btn_Bank_GL_Account.Text = obj_interface_language.btnSearch;

            //this.dgv.Columns[0].HeaderText = obj_interface_language.dgvID;
            //this.dgv.Columns[1].HeaderText = obj_interface_language.dgvName;
        }

        private void ClearAll()
        {
            txt_Check_Book_ID.Text = "";
            txt_From_Serial.Text = "0";
            txt_To_Serial.Text = "0";
            cb_Bank_Account_ID.SelectedIndex = -1;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txt_Check_Book_ID.Text != "")
            {
                if (DataClass.isExsist("*", "Check_Book_ID = " + txt_Check_Book_ID.Text + " AND (Used = 1 Or Void = 1)", "Checks_Serial"))
                {
                    MessageBox.Show("This Check Book Has Check Used Or Voided", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataRow[] rArr = dbAccountingProjectDS.Check_Book.Select("Check_Book_ID = '" + txt_Check_Book_ID.Text + "'");
                DataRow[] rArr2 = dbAccountingProjectDS.Checks_Serial.Select("Check_Book_ID = '" + txt_Check_Book_ID.Text + "'");
                if (rArr.Length != 0)
                {
                    rArr[0].Delete();
                    for (int i = rArr2.Length - 1; i >= 0; i--)
                        rArr2[i].Delete();
                    ClearAll();
                }
                else
                {
                    MessageBox.Show("The given Check Book doesnt exist \n Cant perform delete operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            dgv.ClearSelection();
            SaveChanges();
            btndelete.Enabled = false;

        }

        private void SaveChanges()
        {
            adapter.Update(dbAccountingProjectDS.Check_Book);
            adapterCheck_Serial.Update(dbAccountingProjectDS.Checks_Serial);
            dbAccountingProjectDS.AcceptChanges();
            Load_Data();
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            ClearAll();
            SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconBatch.Open();
            SqlCommand getBatch = new SqlCommand("Select Max(Check_Book_ID)+1 From Check_Book", sqlconBatch);
            if (getBatch.ExecuteScalar() != DBNull.Value)
            {
                txt_Check_Book_ID.Text = getBatch.ExecuteScalar().ToString();
            }
            else
            {
                txt_Check_Book_ID.Text = "1";
            }

            sqlconBatch.Close();
            groupBox1.Enabled = true;
            btn_New.Visible = false;
            btnSavenew.Visible = true;
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
            groupBox1.Enabled = false;
            btn_New.Enabled = true;
            btndelete.Enabled = false;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult myrst;
            myrst = MessageBox.Show("Are You Sure Delete This Check Book ", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return;
            deleteToolStripMenuItem_Click(sender, e);
        }

        private void btnSavenew_Click(object sender, EventArgs e)
        {
            int From_ser = 0; int.TryParse(txt_From_Serial.Text, out From_ser);
            int To_ser = 0; int.TryParse(txt_To_Serial.Text, out To_ser);
            if (From_ser <= 0)
            {
                MessageBox.Show("Check From Serial", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_From_Serial.Focus();
                return;
            }
            if (To_ser <= 0)
            {
                MessageBox.Show("Check To Serial", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_To_Serial.Focus();
                return;
            }
            if (cb_Bank_Account_ID.SelectedIndex < 0)
            {
                MessageBox.Show("Check Bank ", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = From_ser; i <= To_ser; i++)
            {
                DataRow[] drs = dbAccountingProjectDS.Checks_Serial.Select("Bank_Account_ID = " + cb_Bank_Account_ID.SelectedValue.ToString() + " AND Check_Serial = " + i.ToString());
                if (drs.Length > 0)
                {
                    MessageBox.Show("Check Serial " + i.ToString() + "  already exist", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            sqlcon.Open();
            SqlCommand cmdSelect = new SqlCommand("Select Check_Book_ID from Check_Book where Check_Book_ID = '" + txt_Check_Book_ID.Text + "'", sqlcon);
            SqlDataReader dr = cmdSelect.ExecuteReader();
            if (!dr.HasRows && !GeneralFunctions.FindRow("Check_Book_ID = '" + txt_Check_Book_ID.Text + "'", dbAccountingProjectDS.Check_Book))
            {
                DataRow r = dbAccountingProjectDS.Check_Book.NewRow();
                r["Check_Book_ID"] = int.Parse(txt_Check_Book_ID.Text);
                r["Bank_Account_ID"] = cb_Bank_Account_ID.SelectedValue.ToString();
                r["From_Serial"] = From_ser;
                r["To_Serial"] = To_ser;
                r["UserID"] = Accounting_GeneralLedger.Resources.AaDeclrationClass.xUserCode.ToString();
                r["Create_Date"] = DateTime.Now;
                dbAccountingProjectDS.Check_Book.Rows.Add(r);
                for (int i = From_ser; i <= To_ser; i++)
                {
                    DataRow rs = dbAccountingProjectDS.Checks_Serial.NewRow();
                    rs["Check_Book_ID"] = int.Parse(txt_Check_Book_ID.Text);
                    rs["Bank_Account_ID"] = cb_Bank_Account_ID.SelectedValue.ToString();
                    rs["Check_Serial"] = i;
                    rs["Used"] = false;
                    rs["Void"] = false;
                    rs["Description"] = "";
                    rs["Amount"] = 0;
                    rs["Check_Date"] = DateTime.Now.Date;
                    dbAccountingProjectDS.Checks_Serial.Rows.Add(rs);
                }

                ClearAll();
                dr.Close();
                sqlcon.Close();
            }
            groupBox1.Enabled = false;
            btn_New.Visible = true;
            btnSavenew.Visible = false;
            SaveChanges();
        }
        private void Load_Data()
        {
            dgv.DataSource = DataClass.RetrieveData("SELECT CB.Check_Book_ID AS ID, CB.Bank_Account_ID, BAS.Bank_Account_Name AS Bank, CB.From_Serial, CB.To_Serial FROM dbo.Check_Book AS CB INNER JOIN dbo.Bank_Account_Setup AS BAS ON CB.Bank_Account_ID = BAS.Bank_Account_ID");
            dgv.Columns["Bank_Account_ID"].Visible = false;
            dgv.Refresh();
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
                DataRow r = dbAccountingProjectDS.Check_Book.Rows[dgv.SelectedRows[0].Index];
                txt_Check_Book_ID.Text = r["Check_Book_ID"].ToString();
                cb_Bank_Account_ID.SelectedValue = r["Bank_Account_ID"].ToString();
                txt_From_Serial.Text = r["From_Serial"].ToString();
                txt_To_Serial.Text = r["To_Serial"].ToString();
                groupBox1.Enabled = false;
                btndelete.Enabled = true;
            }
        }

        private void groupBox1_EnabledChanged(object sender, EventArgs e)
        {
            if (groupBox1.Enabled == true)
                dgv.Enabled = false;
            else
                dgv.Enabled = true;
        }

        private void Lock90_Enter(object sender, EventArgs e)
        {

        }

        private void Lock88_Enter(object sender, EventArgs e)
        {

        }

        private void Lock89_Enter(object sender, EventArgs e)
        {

        }

        private void txt_To_Serial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else
                e.Handled = true;
        }


    }
}