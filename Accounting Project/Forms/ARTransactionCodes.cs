using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Accounting_GeneralLedger
{
    public partial class ARTransactionCodes : Form
    {

        private SqlConnection sqlcon;
        private SqlDataAdapter adapter;
        private SqlCommandBuilder cmdBuilder;
        //private int currentCategoryID;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        public string AccountNumberSelected = "";
        public ARTransactionCodes()
        {
            InitializeComponent();
        }

        private void ARTransactionCodes_Load(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adapter = new SqlDataAdapter("Select * from ARTransactionCodes", sqlcon);
            cmdBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(dbAccountingProjectDS.ARTransactionCodes);
            dgv.ClearSelection();
            //currentCategoryID = GeneralFunctions.VendorCategoryID;
            txtCode.Text = "";
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
            //this.Text = obj_interface_language.formVendorsCategories;
            //this.label3.Text = obj_interface_language.CategoryID;
            //this.label1.Text = obj_interface_language.CategoryCode;
            //this.label2.Text = obj_interface_language.CategoryDescription;

            //this.NewBtn.Text = obj_interface_language.buttonJVTransactionNew;
            //this.EditBtn.Text = obj_interface_language.buttonJVTransactionEdit;
            //this.DeleteBtn.Text = obj_interface_language.buttonJVTransactionDelete;
            //this.btnundo.Text = obj_interface_language.buttonJVTransactionUndo;
            //this.btnexit.Text = obj_interface_language.buttonJVTransactionExit;
            //this.NewSaveBtn.Text = obj_interface_language.buttonJVTransactionSaveNew;
            //this.EditSaveBtn.Text = obj_interface_language.buttonJVTransactionSaveEdit;

            //this.dgv.Columns[0].HeaderText = obj_interface_language.dgvCode;
            //this.dgv.Columns[1].HeaderText = obj_interface_language.dgvDesc;
        }
        private void SaveChanges()
        {
            adapter.Update(dbAccountingProjectDS.ARTransactionCodes);
            dbAccountingProjectDS.AcceptChanges();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AccountSearch Acc = new AccountSearch();
            Acc.filter = " AND AccountTypeName <> 'Header'";
            Acc.ShowDialog();
            this.txtAccount.Text = Acc.selectedAccountNumber;
            
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            ClearAll();
            groupBox1.Enabled = true;
            NewBtn.Visible = false; 
            NewSaveBtn.Visible = true; 
            EditBtn.Enabled = false;
            DeleteBtn.Enabled = false; 
           
        }
        private void ClearAll()
        {
            txtCode.Text = "";
            txt_Desc.Text = "";
            txtAccount.Text = "";
            chxInActive.Checked = false;
            chxPayMethod.Checked = false;
        }
        private void NewSaveBtn_Click(object sender, EventArgs e)
        {

            if (GeneralFunctions.ValidateString(txtCode.Text, "Please Specify the Transaction Code")
                && GeneralFunctions.ValidateString(txtAccount.Text, "Please Specify the Account Number")
                && GeneralFunctions.ValidateString(txt_Desc.Text, "Please Specify Transaction Description"))
            {
                if (!GeneralFunctions.FindRow("TransCode = '" + txtCode.Text + "'", dbAccountingProjectDS.ARTransactionCodes))
                {
                    DataRow r = dbAccountingProjectDS.ARTransactionCodes.NewRow();
                    r["TransCode"] = txtCode.Text;
                    r["TransDesc"] = txt_Desc.Text;
                    r["AccountNumber"] = txtAccount.Text;
                    if (chxInActive.Checked == true)
                        r["InActive"] = "I";
                    else
                        r["InActive"] = "A";
                    if (chxPayMethod.Checked == true)
                        r["PaymentMethod"] = "A";
                    else
                        r["PaymentMethod"] = "I";
                    dbAccountingProjectDS.ARTransactionCodes.Rows.Add(r);
                    ClearAll();
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Transaction Code already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.ARTransactionCodes.Select("TransCode = '" + txtCode.Text + "'");
                        rArr[0]["TransDesc"] = txt_Desc.Text;
                        rArr[0]["AccountNumber"] = txtAccount.Text;
                        if (chxInActive.Checked == true)
                            rArr[0]["InActive"] = "I";
                        else
                            rArr[0]["InActive"] = "A";
                        if (chxPayMethod.Checked == true)
                            rArr[0]["PaymentMethod"] = "A";
                        else
                            rArr[0]["PaymentMethod"] = "I";
                        ClearAll();
                    }
                    else
                    {
                        ClearAll();
                    }
                }
                groupBox1.Enabled = false;
                NewBtn.Visible = true;
                NewSaveBtn.Visible = false;
                SaveChanges();
            }



        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            txtCode.Enabled = false;
            groupBox1.Enabled = true;
            EditBtn.Visible = false;
            EditSaveBtn.Visible = true;
            NewBtn.Enabled = false;
            DeleteBtn.Enabled = false;
           
        }

        private void EditSaveBtn_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (GeneralFunctions.ValidateString(txtCode.Text, "Please Specify the Transaction Code")
                    && GeneralFunctions.ValidateString(txtAccount.Text, "Please Specify the Account Number")
                    && GeneralFunctions.ValidateString(txt_Desc.Text, "Please Specify Transaction Description"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.ARTransactionCodes.Select("TransCode = '" + txtCode.Text + "'");
                    rArr[0]["TransDesc"] = txt_Desc.Text;
                    rArr[0]["AccountNumber"] = txtAccount.Text;
                    if (chxInActive.Checked == true)
                        rArr[0]["InActive"] = "I";
                    else
                        rArr[0]["InActive"] = "A";
                    if (chxPayMethod.Checked == true)
                        rArr[0]["PaymentMethod"] = "A";
                    else
                        rArr[0]["PaymentMethod"] = "I";
                }
            }
            else
            {
                MessageBox.Show("Please Select the row that you want to edit");
            }
            dgv.ClearSelection();
            groupBox1.Enabled = false;
            EditBtn.Visible = true;
            EditSaveBtn.Visible = false; 
            NewBtn.Enabled = true;
            DeleteBtn.Enabled = true;
            txtCode.Enabled = true;
            SaveChanges();

        }


        private void UndoBtn_Click(object sender, EventArgs e)
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
            NewBtn.Visible = true;
            NewSaveBtn.Visible = false;
            EditBtn.Visible = true;
            EditSaveBtn.Visible = false;
            groupBox1.Enabled = false;
            NewBtn.Enabled = true;
            EditBtn.Enabled = false;
            DeleteBtn.Enabled = false;
            txtCode.Enabled = true;
        
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            

            DialogResult myrst;
            myrst = MessageBox.Show("Are You Sure Delete This Code", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return;
            sqlcon.Open();
            SqlCommand mycom = new SqlCommand("Select Count(*) From ARtrans Where CodeTran = '" + txtCode.Text + "'", sqlcon);
            int c = (int) mycom.ExecuteScalar();
            sqlcon.Close();
            if (c != 0)
            {
                MessageBox.Show("Can't Deleted This Code Because It Used In Another Transaction","Stop",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            if (dgv.SelectedRows.Count > 0)
            {
                dbAccountingProjectDS.ARTransactionCodes.Rows[dgv.SelectedRows[0].Index].Delete();
                ClearAll();
            }
            else
            {
                if (GeneralFunctions.ValidateString(txtCode.Text, "Please Specify the Transaction Code"))
                {
                    DataRow[] rArr = dbAccountingProjectDS.ARTransactionCodes.Select("TransCode = '" + txtCode.Text + "'");
                    if (rArr.Length != 0)
                    {
                        rArr[0].Delete();
                        ClearAll();
                    }
                    else
                    {
                        MessageBox.Show("This Code doesnt exist \n Cant perform delete operation");
                    }
                }
            }
            dgv.ClearSelection();
            SaveChanges();
            EditBtn.Enabled = false;
            DeleteBtn.Enabled = false;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
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

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (groupBox1.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            UndoBtn_Click("NO", e);
            if (dgv.SelectedRows.Count > 0)
            {
                DataRow r = dbAccountingProjectDS.ARTransactionCodes.Rows[dgv.SelectedRows[0].Index];
                txtCode.Text = r["TransCode"].ToString();
                txt_Desc.Text = r["TransDesc"].ToString();
                txtAccount.Text = r["AccountNumber"].ToString();
                if (r["InActive"].ToString() == "I")
                    chxInActive.Checked = true;
                else
                    chxInActive.Checked = false;
                if (r["PaymentMethod"].ToString() == "A")
                    chxPayMethod.Checked = true;
                else
                    chxPayMethod.Checked = false;

                groupBox1.Enabled = false;
                DeleteBtn.Enabled = true;
                EditBtn.Enabled = true;

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