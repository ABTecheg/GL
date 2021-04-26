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
    public partial class ARCustomerMaintainance : Form
    {

        public SqlConnection sqlcon;
        public SqlDataAdapter adapter;
        public SqlCommandBuilder cmdBuilder;
        DataTable DTStatus;
        DataTable DTType;
        public ARCustomerMaintainance()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DTStatus = new DataTable("DTStatus");
            DTStatus.Columns.Add("Code", System.Type.GetType("System.String"));
            DTStatus.Columns.Add("Desc", System.Type.GetType("System.String"));
            DTStatus.Rows.Add(new object[] { "P", "Permanent" });
            DTStatus.Rows.Add(new object[] { "T", "Temporary" });
            DTStatus.Rows.Add(new object[] { "I", "Inactive" });
            cmxStatus.DataSource = DTStatus;
            cmxStatus.ValueMember = "Code";
            cmxStatus.DisplayMember = "Desc";
            DTType = new DataTable("DTType");
            DTType.Columns.Add("Code", System.Type.GetType("System.String"));
            DTType.Columns.Add("Desc", System.Type.GetType("System.String"));
            DTType.Rows.Add(new object[] { "B", "Balance Forward" });
            DTType.Rows.Add(new object[] { "O", "Open Item" });
            cmxType.DataSource = DTType;
            cmxType.ValueMember = "Code";
            cmxType.DisplayMember = "Desc";

            // TODO: This line of code loads data into the 'dbAccountingProjectDS.ARContacts' table. You can move, or remove it, as needed.
            this.aRContactsTableAdapter.Fill(this.dbAccountingProjectDS.ARContacts);
            // TODO: This line of code loads data into the 'dbAccountingProjectDS.Contacts' table. You can move, or remove it, as needed.

            try
            {
                //this.aRContactsTableAdapter.FillBy(this.dbAccountingProjectDS.ARContacts, int.Parse(txtID.Text.ToString()));
                this.aRContactsTableAdapter.Fill(this.dbAccountingProjectDS.ARContacts);
            }
            catch
            {

            }
            // TODO: This line of code loads data into the 'dbAccountingProjectDS.ARCustomerMaintainance' table. You can move, or remove it, as needed.
            this.aRCustomerMaintainanceTableAdapter.Fill(this.dbAccountingProjectDS.ARCustomerMaintainance);

            //Da elTypeCOMBOBOX
            SqlDataAdapter Adapter = new SqlDataAdapter("Select * from TypeCategories", GeneralFunctions.ConnectionString);
            Adapter.Fill(this.dbAccountingProjectDS.TypeCategories);
            GeneralFunctions.FillComboBox(this.dbAccountingProjectDS.TypeCategories, this.cmxMiscType, "TypeCatName", "1");

            //Da elAccountCatCOMBOBOX
            Adapter = new SqlDataAdapter("Select * from Ar_AccontCat", GeneralFunctions.ConnectionString);
            Adapter.Fill(this.dbAccountingProjectDS.Ar_AccontCat);
            GeneralFunctions.FillComboBox(this.dbAccountingProjectDS.Ar_AccontCat, this.cmxAccountCat, "ArAccCatCode", "0");

            //Da elDisCatCOMBOBOX
            Adapter = new SqlDataAdapter("Select * from ARDiscountCategories", GeneralFunctions.ConnectionString);
            Adapter.Fill(this.dbAccountingProjectDS.ARDiscountCategories);
            GeneralFunctions.FillComboBox(this.dbAccountingProjectDS.ARDiscountCategories, this.cmxDisCatName, "CatName", "0");
        
        }



        private void txtID_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = txtID.Text;
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {

            txtAccCode.Text = "";
            txtAccName.Text = "";
            txtAttention.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
            txtCounty.Text = "";
            txtCreditL.Text = "";
            txtDept.Text = "";
            txtID.Text = "";
            txtLine.Text = "";
            txtLine2.Text = "";
            txtPostCode.Text = "";
            txtTax.Text = "";
            cmxAccountCat.SelectedIndex = -1;
            cmxDisCatName.SelectedIndex = -1;
            cmxStatus.SelectedIndex = 0;
            cmxMiscType.SelectedIndex = 0;
            cmxType.SelectedIndex = 0;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            tab1groupBox.Enabled = true;
            GrXDetails.Enabled = true;
            DTPCreated.Value = DateTime.Now.Date;
            try
            {
                SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlconBatch.Open();
                SqlCommand getBatch = new SqlCommand("Select Max(CustomerMainID)+1 From ARCustomerMaintainance", sqlconBatch);
                if (getBatch.ExecuteScalar() != DBNull.Value)
                {
                    txtID.Text = getBatch.ExecuteScalar().ToString();
                }
                else
                {
                    txtID.Text = "1";
                }
                sqlconBatch.Close();


                tab1groupBox.Enabled = true;
                GrXDetails.Enabled = true;

               

                DeleteBtn.Enabled = false;
                UndoBtn.Enabled = true;
                txtAccCode.Text = "";
                txtAccName.Text = "";
                NewBtn.Visible = false;
                NewSaveBtn.Visible = true;
                NewSaveBtn.Enabled = true;
                EditBtn.Enabled = false;
                EditSaveBtn.Visible = false;
                DeleteBtn.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Error In  CustMain Created");
            }
        }

        private void NewSaveBtn_Click(object sender, EventArgs e)
        {

            if (txtLast.Text == "" && txtFirst.Text == "" && txtPhone.Text == "")
            {
                DialogResult myrst;
                myrst = MessageBox.Show("There is NO Contacts Added .. Continue", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            
            try
            {
                int id = int.Parse(txtID.Text.ToString());
                if (txtAccCode.Text == "" || txtAccName.Text == "")
                {
                    MessageBox.Show("Missing Account Code or Account Name !!");
                    return;
                }
                else
                {
                    sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlcon.Open();
                    SqlCommand cmdSelect = new SqlCommand(" Select CustomerMainID from ARCustomerMaintainance where CustomerMainID= '" + id + "'", sqlcon);
                    SqlDataReader dr = cmdSelect.ExecuteReader();

                    if (!dr.HasRows)
                    {
                        DataRow r = dbAccountingProjectDS.ARCustomerMaintainance.NewRow();
                        r["CustomerMainID"] = txtID.Text;
                        r["AccountCode"] = txtAccCode.Text;
                        r["AccoutName"] = txtAccName.Text;
                        r["Attention"] = txtAttention.Text;
                        r["City"] = txtCity.Text;
                        r["Country"] = txtCountry.Text;
                        r["County"] = txtCounty.Text;
                        r["CreditLimit"] = txtCreditL.Text.ToString();
                        r["Department"] = txtDept.Text;

                        r["Line1"] = txtLine.Text;
                        r["Line2"] = txtLine2.Text;
                        r["PostCode"] = txtPostCode.Text;
                        r["TaxIDNum"] = txtTax.Text;
                        r["Category"] = cmxAccountCat.Text;
                        r["DiscountCategory"] = cmxDisCatName.Text;
                        r["Status"] = cmxStatus.SelectedValue.ToString();
                        r["Type"] = cmxType.SelectedValue.ToString();
                        r["Created"] = DTPCreated.Value.ToShortDateString();
                        r["LastPayment"] = DTPLastP.Value.ToShortDateString();
                        r["LastStatement"] = DTPLastS.Value.ToShortDateString();
                        r["FinanceChange"] = checkBox1.Checked;
                        r["NonTaxable"] = checkBox2.Checked;
                        r["MiscType"] = cmxMiscType.Text;
                        r["MainNameTitle"] = comboBox1.Text;
                        r["LastName"] = txtLast.Text;
                        r["FirstName"] = txtFirst.Text;
                        r["Contact"] = txtContact.Text;
                        r["phone"] = txtPhone.Text;
                        r["fax"] = txtFax.Text;
                        r["Email"] = txtEmail.Text;
                        r["EmailInvoices"] = ChxEmail.Checked.ToString();
                        r["Salution"] = txtSalution.Text;
                        r["PrintBalance"] = ChXPrint.Checked.ToString();
                        r["primaryAddress"] = ChXPrimary.Checked.ToString();
                        dbAccountingProjectDS.ARCustomerMaintainance.Rows.Add(r);

                        dr.Close();
                        sqlcon.Close();
                        txtAccCode.Text = "";
                        txtAccName.Text = "";
                        txtAttention.Text = "";
                        txtCity.Text = "";
                        txtCountry.Text = "";
                        txtCounty.Text = "";
                        txtCreditL.Text = "";
                        txtDept.Text = "";
                        txtID.Text = "";
                        txtLine.Text = "";
                        txtLine2.Text = "";
                        txtPostCode.Text = "";
                        txtTax.Text = "";
                        cmxAccountCat.SelectedIndex = 0;
                        cmxDisCatName.SelectedIndex = 0;
                        cmxStatus.SelectedIndex = 0;
                        cmxMiscType.SelectedIndex = 0;
                        cmxType.SelectedIndex = 0;
                        checkBox1.Checked = false;
                        checkBox2.Checked = false;
                        MessageBox.Show(" Adding Customer Successfuly");
                        this.aRCustomerMaintainanceTableAdapter.Update(this.dbAccountingProjectDS.ARCustomerMaintainance);

                    }
                }
            }
            catch
            {
                MessageBox.Show("Error In Adding Customer");

            }
            tab1groupBox.Enabled = false;
            GrXDetails.Enabled = false;
            NewBtn.Visible = true;
            EditBtn.Visible = true;
            //EditBtn.Enabled = true;
            NewSaveBtn.Visible = false;
            UndoBtn_Click("", e);

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            tab1groupBox.Enabled = true;
            GrXMain.Enabled = true;
            GrXSettings.Enabled = true;
            GrXDetails.Enabled = true;
            EditBtn.Visible = false;
            EditSaveBtn.Visible = true;
            EditSaveBtn.Enabled = true;
            NewBtn.Enabled = false;
            DeleteBtn.Enabled = false;


            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }
         
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender.ToString() != "NO")
            {
                if (GrXSettings.Enabled == true)
                {
                    DialogResult myrst;
                    myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (myrst == DialogResult.No)
                        return;
                }
            }
            try
            {

                int i;
                i = dataGridView1.CurrentRow.Index;


                txtID.Text = dataGridView1[0, i].Value.ToString();
                txtAccCode.Text = dataGridView1[1, i].Value.ToString();
                txtAccName.Text = dataGridView1[2, i].Value.ToString();
                cmxType.SelectedValue = dataGridView1[3, i].Value.ToString();
                cmxStatus.SelectedValue = dataGridView1[4, i].Value.ToString();
                txtCreditL.Text = dataGridView1[5, i].Value.ToString();
                txtTax.Text = dataGridView1[6, i].Value.ToString();
                cmxAccountCat.Text = dataGridView1[7, i].Value.ToString();
                cmxDisCatName.Text = dataGridView1[8, i].Value.ToString();
                checkBox1.Checked = bool.Parse(dataGridView1[9, i].Value.ToString());
                checkBox2.Checked = bool.Parse(dataGridView1[10, i].Value.ToString());
                DTPCreated.Value = Convert.ToDateTime(dataGridView1[11, i].Value.ToString());
                //DTPLastP;
                //DTPLastS;
                txtAttention.Text = dataGridView1[14, i].Value.ToString();
                txtDept.Text = dataGridView1[15, i].Value.ToString();
                txtLine.Text = dataGridView1[16, i].Value.ToString();
                txtLine2.Text = dataGridView1[17, i].Value.ToString();
                txtCity.Text = dataGridView1[18, i].Value.ToString();
                txtCounty.Text = dataGridView1[19, i].Value.ToString();
                txtCountry.Text = dataGridView1[20, i].Value.ToString();
                txtPostCode.Text = dataGridView1[21, i].Value.ToString();
                cmxMiscType.Text = dataGridView1[22, i].Value.ToString();
                comboBox1.Text = dataGridView1[23, i].Value.ToString();
                txtLast.Text = dataGridView1[24, i].Value.ToString();
                txtFirst.Text = dataGridView1[25, i].Value.ToString();
                txtPhone.Text = dataGridView1[26, i].Value.ToString();
                txtContact.Text = dataGridView1[27, i].Value.ToString();
                txtFax.Text = dataGridView1[28, i].Value.ToString();
                txtEmail.Text = dataGridView1[29, i].Value.ToString();
                ChxEmail.Checked = bool.Parse(dataGridView1[30, i].Value.ToString());
                txtSalution.Text = dataGridView1[31, i].Value.ToString();
                ChXPrint.Checked = bool.Parse(dataGridView1[32, i].Value.ToString());
                ChXPrimary.Checked = bool.Parse(dataGridView1[33, i].Value.ToString());

                EditBtn.Enabled = true;
                DeleteBtn.Enabled = true;
            }

            catch (Exception ex)
            { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }


        private void EditSaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int IDS = int.Parse(txtID.Text.ToString());

                if (txtAccCode.Text == "" || txtAccName.Text == "")
                {
                    MessageBox.Show("Missing Account Code or Account Name !!");
                    return;
                }


                if (GeneralFunctions.FindRow("CustomerMainID = '" + IDS + "'", dbAccountingProjectDS.ARCustomerMaintainance))
                {
                    DataRow r = dbAccountingProjectDS.ARCustomerMaintainance.FindByCustomerMainID(IDS);


                    r.BeginEdit();
                    r["CustomerMainID"] = txtID.Text;
                    r["AccountCode"] = txtAccCode.Text;
                    r["AccoutName"] = txtAccName.Text;
                    r["Attention"] = txtAttention.Text;
                    r["City"] = txtCity.Text;
                    r["Country"] = txtCountry.Text;
                    r["County"] = txtCounty.Text;
                    r["CreditLimit"] = txtCreditL.Text;
                    r["Department"] = txtDept.Text;

                    r["Line1"] = txtLine.Text;
                    r["Line2"] = txtLine2.Text;
                    r["PostCode"] = txtPostCode.Text;
                    r["TaxIDNum"] = txtTax.Text;
                    r["Category"] = cmxAccountCat.Text;
                    r["DiscountCategory"] = cmxDisCatName.Text;
                    r["Status"] = cmxStatus.SelectedValue.ToString();
                    r["Type"] = cmxType.SelectedValue.ToString();
                    r["Created"] = DTPCreated.Value.ToShortDateString();
                    r["LastPayment"] = DTPLastP.Value.ToShortDateString();
                    r["LastStatement"] = DTPLastS.Value.ToShortDateString();
                    r["FinanceChange"] = checkBox1.Checked;
                    r["NonTaxable"] = checkBox2.Checked;
                    r["MiscType"] = cmxMiscType.Text;
                    r["MainNameTitle"] = comboBox1.Text;
                    r["LastName"] = txtLast.Text;
                    r["FirstName"] = txtFirst.Text;
                    r["Contact"] = txtContact.Text;
                    r["phone"] = txtPhone.Text;
                    r["fax"] = txtFax.Text;
                    r["Email"] = txtEmail.Text;
                    r["EmailInvoices"] = ChxEmail.Checked.ToString();
                    r["Salution"] = txtSalution.Text;
                    r["PrintBalance"] = ChXPrint.Checked.ToString();
                    r["primaryAddress"] = ChXPrimary.Checked.ToString();
                    r.EndEdit();
                    this.aRCustomerMaintainanceTableAdapter.Update(this.dbAccountingProjectDS.ARCustomerMaintainance);
                }

                this.aRCustomerMaintainanceTableAdapter.Update(this.dbAccountingProjectDS.ARCustomerMaintainance);
                dbAccountingProjectDS.AcceptChanges();
                dataGridView1.ClearSelection();
                txtAccCode.Text = "";
                txtAccName.Text = "";
                txtAttention.Text = "";
                txtCity.Text = "";
                txtCountry.Text = "";
                txtCounty.Text = "";
                txtCreditL.Text = "";
                txtDept.Text = "";
                txtID.Text = "";
                txtLine.Text = "";
                txtLine2.Text = "";
                txtPostCode.Text = "";
                txtTax.Text = "";
                cmxAccountCat.SelectedIndex = 0;
                cmxDisCatName.SelectedIndex = 0;
                cmxStatus.SelectedIndex = 0;
                cmxMiscType.SelectedIndex = 0;
                cmxType.SelectedIndex = 0;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                MessageBox.Show("Editing Successfully");
            }
            catch
            {
                MessageBox.Show("Error in Editing");
            }


            tab1groupBox.Enabled = false;
            GrXDetails.Enabled = false;

            EditBtn.Visible = true;
            EditSaveBtn.Visible = false;
            NewBtn.Enabled = true;
            DeleteBtn.Enabled = true;
                UndoBtn_Click("", e);
        
            this.aRCustomerMaintainanceTableAdapter.Update(this.dbAccountingProjectDS.ARCustomerMaintainance);
            dbAccountingProjectDS.AcceptChanges();
       


            
        }



        private void UndoBtn_Click(object sender, EventArgs e)
        {
            if (sender.ToString() != "NO")
            {
                if (GrXSettings.Enabled == true)
                {
                    DialogResult myrst;
                    myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (myrst == DialogResult.No)
                        return;
                }
            }
            txtAccCode.Text = "";
            txtAccName.Text = "";
            txtAttention.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
            txtCounty.Text = "";
            txtCreditL.Text = "";
            txtDept.Text = "";
            txtID.Text = "";
            txtLine.Text = "";
            txtLine2.Text = "";
            txtPostCode.Text = "";
            txtTax.Text = "";
            cmxAccountCat.SelectedIndex = -1;
            cmxDisCatName.SelectedIndex = -1;
            cmxStatus.SelectedIndex = -1;
            cmxMiscType.SelectedIndex = -1;
            cmxType.SelectedIndex = -1;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            NewBtn.Visible = true;
            NewSaveBtn.Visible = false;
            EditBtn.Visible = true;
            EditSaveBtn.Visible = false;
            tab1groupBox.Enabled = false;
            GrXDetails.Enabled = false;
            NewBtn.Enabled = true;
            EditBtn.Enabled = false;
            DeleteBtn.Enabled = false;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //this.aRContactsTableAdapter.FillBy(this.dbAccountingProjectDS.ARContacts, int.Parse(textBox1.Text.ToString()));
                this.aRContactsTableAdapter.Fill(this.dbAccountingProjectDS.ARContacts);
            }
            catch
            {

            }
        }

        private void txtAccCode_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = txtAccCode.Text;
        }

        private void txtAccName_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = txtAccName.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccountSearch AccF = new AccountSearch();
            AccF.ShowDialog();
            this.txtAccCode.Text = AccF.selectedAccountNumber;
            this.txtAccName.Text = AccF.selectedAccountName;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {

            DialogResult myrst;
            myrst = MessageBox.Show("Are You Sure Delete This Customer Maintainance and its Contacts ", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return;


            if (dataGridView1.SelectedRows.Count > 0 && txtID.Text.Trim() != "" && txtID.Text.Trim() != "0")
            {
                int id =int.Parse(txtID.Text);
                dbAccountingProjectDS.ARCustomerMaintainance.Rows[dataGridView1.SelectedRows[0].Index].Delete();
                SqlDataAdapter MyAdapt = new SqlDataAdapter("delete  from ARcontacts where cutomermid ='" + id + "'", GeneralFunctions.ConnectionString);
                MyAdapt.Fill(this.dbAccountingProjectDS.ARContacts);
                MyAdapt.Update(this.dbAccountingProjectDS.ARContacts);
                txtAccCode.Text = "";
                txtAccName.Text = "";
                txtID.Text = "";
                this.aRCustomerMaintainanceTableAdapter.Update(this.dbAccountingProjectDS.ARCustomerMaintainance);
            }

            else
            {
                if (txtID.Text != "")
                {
                    int IDS = int.Parse(txtID.Text.ToString());
                    SqlDataAdapter MyAdapt = new SqlDataAdapter("delete  from ARcontacts where cutomermid ='" + IDS + "'", sqlcon);
                    MyAdapt.Fill(this.dbAccountingProjectDS.ARContacts);
                    MyAdapt.Update(this.dbAccountingProjectDS.ARContacts);
                    DataRow[] rArr = dbAccountingProjectDS.ARCustomerMaintainance.Select("CustomerMainID = '" + IDS + "'");
                    if (rArr.Length != 0)
                    {

                        rArr[0].Delete();

                        txtAccCode.Text = "";
                        txtAccName.Text = "";
                        txtAttention.Text = "";
                        txtCity.Text = "";
                        txtCountry.Text = "";
                        txtCounty.Text = "";
                        txtCreditL.Text = "";
                        txtDept.Text = "";
                        txtID.Text = "";
                        txtLine.Text = "";
                        txtLine2.Text = "";
                        txtPostCode.Text = "";
                        txtTax.Text = "";
                        cmxAccountCat.SelectedIndex = 0;
                        cmxDisCatName.SelectedIndex = 0;
                        cmxStatus.SelectedIndex = 0;
                        cmxMiscType.SelectedIndex = 0;
                        cmxType.SelectedIndex = 0;
                        checkBox1.Checked = false;
                        checkBox2.Checked = false;
                        
                    }

                    

                }
            }
            dataGridView1.ClearSelection();

            this.aRCustomerMaintainanceTableAdapter.Update(this.dbAccountingProjectDS.ARCustomerMaintainance);
            dbAccountingProjectDS.AcceptChanges();
        }


        private void ExitBtn_Click(object sender, EventArgs e)
        {
            if (GrXSettings.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            this.Close();
        }

        private void cmxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmxMiscType.Text == "<new>")
            {
                TypeCategories tc = new  TypeCategories();
                tc.ShowDialog();
                cmxMiscType.Items.Clear();
                SqlDataAdapter Adapter = new SqlDataAdapter("Select * from TypeCategories", GeneralFunctions.ConnectionString);
                Adapter.Fill(this.dbAccountingProjectDS.TypeCategories);
                GeneralFunctions.FillComboBox(this.dbAccountingProjectDS.TypeCategories, this.cmxMiscType, "TypeCatName", "1");
            }
        }

        private void cmxAccountCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmxAccountCat.Text == "<new>")
            {
                ARAccountCategory ac = new  ARAccountCategory();
                ac.ShowDialog();
                cmxAccountCat.Items.Clear();
                SqlDataAdapter Adapter = new SqlDataAdapter("Select * from Ar_AccontCat", GeneralFunctions.ConnectionString);
                Adapter.Fill(this.dbAccountingProjectDS.Ar_AccontCat);
                GeneralFunctions.FillComboBox(this.dbAccountingProjectDS.Ar_AccontCat, this.cmxAccountCat, "ArAccCatCode", "0");
            }

        }

        private void cmxType_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void cmxDisCatName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmxDisCatName.Text == "<new>")
            {
                ARDiscountCategories frm = new ARDiscountCategories();
                frm.ShowDialog();
                cmxDisCatName.Items.Clear();
                SqlDataAdapter Adapter = new SqlDataAdapter("Select * from ARDiscountCategories", GeneralFunctions.ConnectionString);
                Adapter.Fill(this.dbAccountingProjectDS.ARDiscountCategories);
                GeneralFunctions.FillComboBox(this.dbAccountingProjectDS.ARDiscountCategories, this.cmxDisCatName, "CatName", "0");
            } 

        }

        private void cmxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GrXSettings_EnabledChanged(object sender, EventArgs e)
        {
            if (GrXSettings.Enabled == true)
                dataGridView1.Enabled = false;
            else
                dataGridView1.Enabled = true;
        }




       
    }
}