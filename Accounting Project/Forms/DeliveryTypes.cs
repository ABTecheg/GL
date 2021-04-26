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
    public partial class DeliveryTypes : Form
    {
        private SqlConnection sqlcon;
        private SqlDataAdapter adapter;
        private SqlDataAdapter adaptertbGeneralSetup;
        private SqlDataAdapter adaptertbAccounts;
        private SqlCommandBuilder cmdBuilder;
        private int decmal = 1;
        private string currentAccountNumber;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;

        public DeliveryTypes()
        {
            InitializeComponent();
        }

        private void DeliveryTypes_Load(object sender, EventArgs e)
        {
            GeneralFunctions.priviledgeGroupBox(Lock88);
            GeneralFunctions.priviledgeGroupBox(Lock89);
            GeneralFunctions.priviledgeGroupBox(Lock90);
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adapter = new SqlDataAdapter("Select * from APDeliveryType", sqlcon);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);
            adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts", sqlcon);
            cmdBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(dbAccountingProjectDS.APDeliveryType);
            adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            {
                txt_AccountNumber.Mask = dr["AccountNumberFormat"].ToString();
                decmal = int.Parse(dr["DecimalPointsNumber"].ToString());
            }
            //currentDeliveryTypeID = GeneralFunctions.DeliveryTypeID;
            //txt_DeliveryTypeID.Text = currentDeliveryTypeID.ToString();
            if (GeneralFunctions.languagechioce != "")
            {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }
            if (!GeneralFunctions.SubTypesloaded)
            {
                SqlConnection sqlcon10 = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlcon10.Open();
                SqlCommand command10 = new SqlCommand("Select AccountSubType From  GeneralSetup", sqlcon10);
                SqlCommand command11 = new SqlCommand("Select FirstSub From GeneralSetup", sqlcon10);
                SqlCommand command12 = new SqlCommand("Select SecondSub From GeneralSetup", sqlcon10);
                SqlCommand command13 = new SqlCommand("Select ThirdSub From GeneralSetup", sqlcon10);
                SqlCommand command14 = new SqlCommand("Select FourthSub From GeneralSetup", sqlcon10);
                int AccountSubTypeNumber;
                if (command10.ExecuteScalar() != DBNull.Value) {
                    AccountSubTypeNumber = Convert.ToInt32(command10.ExecuteScalar());
                    if (AccountSubTypeNumber == 2) {
                        GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()), Convert.ToInt32(command12.ExecuteScalar()));
                        GeneralFunctions.SubTypesloaded = true;
                    }
                    if (AccountSubTypeNumber == 3) {
                        GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()), Convert.ToInt32(command12.ExecuteScalar()), Convert.ToInt32(command13.ExecuteScalar()));
                        GeneralFunctions.SubTypesloaded = true;
                    }
                    if (AccountSubTypeNumber == 4) {
                        GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()), Convert.ToInt32(command12.ExecuteScalar()), Convert.ToInt32(command13.ExecuteScalar()), Convert.ToInt32(command14.ExecuteScalar()));
                        GeneralFunctions.SubTypesloaded = true;
                    }

                }
            }
        }
        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.formDeliveryTypes;
            this.label1.Text = obj_interface_language.DeliveryTypeID;
            this.label2.Text = obj_interface_language.DeliveryTypeName;
            this.label3.Text = obj_interface_language.Percentage;
            this.label4.Text = obj_interface_language.labelGLAccountNumber;

            this.btn_New.Text = obj_interface_language.buttonJVTransactionNew;
            this.btnedit.Text = obj_interface_language.buttonJVTransactionEdit;
            this.btndelete.Text = obj_interface_language.buttonJVTransactionDelete;
            this.btnundo.Text = obj_interface_language.buttonJVTransactionUndo;
            this.btnexit.Text = obj_interface_language.buttonJVTransactionExit;
            this.btnSavenew.Text = obj_interface_language.buttonJVTransactionSaveNew;
            this.Btnsaveedit.Text = obj_interface_language.buttonJVTransactionSaveEdit;
            this.btn_Search.Text = obj_interface_language.btnSearch;

            this.dgv.Columns[0].HeaderText = obj_interface_language.dgvID;
            this.dgv.Columns[1].HeaderText = obj_interface_language.dgvName;
        }
        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GeneralFunctions.ValidateString(txt_DeliveryTypeName.Text, "Please Enter a valid Delivery Type Name")
                && GeneralFunctions.AccountNumberValidate(txt_AccountNumber.Text, out currentAccountNumber))
            {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select DeliveryTypeID from APDeliveryType where DeliveryTypeID = '" + txt_DeliveryTypeID.Text + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("DeliveryTypeID = '" + txt_DeliveryTypeID.Text + "'", dbAccountingProjectDS.APDeliveryType))
                {
                    DataRow r = dbAccountingProjectDS.APDeliveryType.NewRow();
                    r["DeliveryTypeID"] = int.Parse(txt_DeliveryTypeID.Text);
                    //GeneralFunctions.DeliveryTypeID++;
                    //currentDeliveryTypeID = GeneralFunctions.DeliveryTypeID;
                    r["DeliveryTypeName"] = txt_DeliveryTypeName.Text;
                    r["DeliveryPercentage"] = txt_Percentage.Text;
                    r["DeliveryTypeAccountNumber"] = txt_AccountNumber.Text;
                    dbAccountingProjectDS.APDeliveryType.Rows.Add(r);
                    ClearAll();
                    dr.Close();
                    sqlcon.Close();
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Delivery Type Name is already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.APDeliveryType.Select("DeliveryTypeID = '" + txt_DeliveryTypeID.Text + "'");
                        rArr[0]["DeliveryTypeName"] = txt_DeliveryTypeName.Text;
                        rArr[0]["DeliveryPercentage"] = txt_Percentage.Text;
                        rArr[0]["DeliveryTypeAccountNumber"] = currentAccountNumber;
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
                if (GeneralFunctions.ValidateString(txt_DeliveryTypeName.Text, "Please Enter a valid Delivery Type Name")
                    && GeneralFunctions.AccountNumberValidate(txt_AccountNumber.Text, out currentAccountNumber))
                {
                    DataRow[] rArr = dbAccountingProjectDS.APDeliveryType.Select("DeliveryTypeID = '" + txt_DeliveryTypeID.Text + "'");
                    rArr[0]["DeliveryTypeName"] = txt_DeliveryTypeName.Text;
                    rArr[0]["DeliveryTypeAccountNumber"] = txt_AccountNumber.Text;
                    rArr[0]["DeliveryPercentage"] = txt_Percentage.Text;
                    //ClearAll();
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
            btndelete.Enabled = false;
            btnedit.Enabled = false;
            SaveChanges();

        }

        private void ClearAll()
        {
            txt_DeliveryTypeID.Text = "";
            txt_DeliveryTypeName.Text = "";
            txt_Percentage.Text = "";
            txt_AccountNumber.Text = "";
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                dbAccountingProjectDS.APDeliveryType.Rows[dgv.SelectedRows[0].Index].Delete();
                ClearAll();
            }
            else
            {
                if (txt_DeliveryTypeID.Text != "")
                {
                    DataRow[] rArr = dbAccountingProjectDS.APDeliveryType.Select("DeliveryTypeID = '" + txt_DeliveryTypeID.Text + "'");
                    if (rArr.Length != 0)
                    {
                        rArr[0].Delete();
                        ClearAll();
                    }
                    else
                    {
                        MessageBox.Show("The given Delivery Type ID doesnt exist \n Cant perform delete operation","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            adapter.Update(dbAccountingProjectDS.APDeliveryType);
            dbAccountingProjectDS.AcceptChanges();
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            ClearAll();
            SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconBatch.Open();
            SqlCommand getBatch = new SqlCommand("Select Max(DeliveryTypeID)+1 From APDeliveryType", sqlconBatch);
            if (getBatch.ExecuteScalar() != DBNull.Value)
            {
                txt_DeliveryTypeID.Text = getBatch.ExecuteScalar().ToString();
            }
            else
            {
                txt_DeliveryTypeID.Text = "1";
            }
            sqlconBatch.Close();
            groupBox1.Enabled = true;
            btn_New.Visible = false;
            btnSavenew.Visible = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
        }


        private void txt_Percentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                if (txt_Percentage.Text.Contains("."))
                {
                    char c = '.';
                    string[] sc = txt_Percentage.Text.Split(c);

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
                if (txt_Percentage.Text.Contains(".") == false)
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void txt_AccountNumber_DoubleClick(object sender, EventArgs e)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.filter = " AND AccountTypeName <> 'Header'";
            accSearch.ShowDialog();
            if (accSearch.selectedAccountName != null)
            {
                txt_AccountNumber.Text = accSearch.selectedAccountNumber.ToString();
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.filter = " AND AccountTypeName <> 'Header'";
            accSearch.ShowDialog();
            if (accSearch.selectedAccountName != null)
            {
                txt_AccountNumber.Text = accSearch.selectedAccountNumber.ToString();
            }
        }

        private void txt_AccountNumber_Leave(object sender, EventArgs e)
        {
            //DataRow[] drAC;
            //drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txt_AccountNumber.Text + "'");
            //if (drAC.Length == 0)
            //{
            //    MessageBox.Show("Check Account Number", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txt_AccountNumber.Focus();
            //}

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
            myrst = MessageBox.Show("Are You Sure Delete This DeliveryTypes", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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
            DataRow[] drAC;
            drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txt_AccountNumber.Text + "'");
            if (drAC.Length == 0)
            {
                MessageBox.Show("Check Account Number", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_AccountNumber.Focus();
                return;
            } 
            editToolStripMenuItem_Click(sender, e);
        }

        private void btnSavenew_Click(object sender, EventArgs e)
        {
            DataRow[] drAC;
            drAC = dbAccountingProjectDS.GLAccounts.Select("AccountNumber = '" + txt_AccountNumber.Text + "'");
            if (drAC.Length == 0)
            {
                MessageBox.Show("Check Account Number", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_AccountNumber.Focus();
                return;
            }
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
                DataRow r = dbAccountingProjectDS.APDeliveryType.Rows[dgv.SelectedRows[0].Index];
                txt_DeliveryTypeID.Text = r["DeliveryTypeID"].ToString();
                txt_DeliveryTypeName.Text = r["DeliveryTypeName"].ToString();
                txt_Percentage.Text = r["DeliveryPercentage"].ToString();
                txt_AccountNumber.Text = r["DeliveryTypeAccountNumber"].ToString();
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

        private void Lock90_Enter(object sender, EventArgs e)
        {

        }

        private void Lock88_Enter(object sender, EventArgs e)
        {

        }

        private void Lock89_Enter(object sender, EventArgs e)
        {

        }


    }
}