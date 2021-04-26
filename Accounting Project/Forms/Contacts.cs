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
    public partial class Contacts : Form
    {
        public SqlConnection sqlcon;
        public SqlDataAdapter adapter;
        public SqlCommandBuilder cmdBuilder;
        public Contacts()
        {
            InitializeComponent();
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            GrXDetails.Enabled = true;
            

            DeleteBtn.Enabled = false;
            UndoBtn.Enabled = true;
            txtLast.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtFax.Text = "";
            txtFirst.Text = "";
            txtPhone.Text = "";
            txtSalution.Text = "";
            ChxEmail.Checked = false;
            ChXPrimary.Checked = false;
            ChXPrint.Checked = false;
            NewBtn.Visible = false;
            NewSaveBtn.Visible = true;
            NewSaveBtn.Enabled = true;
            EditSaveBtn.Visible = false;

            SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconBatch.Open();
            SqlCommand getBatch = new SqlCommand("Select Max(contantId)+1 From ARContacts", sqlconBatch);
            if (getBatch.ExecuteScalar() != DBNull.Value)
            {
                LabelID.Text = getBatch.ExecuteScalar().ToString();
            }
            else
            {
                LabelID.Text = "1";
            }
            sqlconBatch.Close();
        }

        private void Contacts_Load(object sender, EventArgs e)
        {

            //this.aRContactsTableAdapter.FillBy(this.dbAccountingProjectDS.ARContacts, int.Parse(txtID.Text.ToString()));
            this.aRContactsTableAdapter.Fill(this.dbAccountingProjectDS.ARContacts);
            // TODO: This line of code loads data into the 'dbAccountingProjectDS.ARContacts' table. You can move, or remove it, as needed.

        }

        private void NewSaveBtn_Click(object sender, EventArgs e)
        {
            
            
            DeleteBtn.Enabled = true;
            UndoBtn.Enabled = true;
            NewBtn.Visible = true;
            NewSaveBtn.Visible = false;
            NewSaveBtn.Enabled = true;
            EditSaveBtn.Visible = false;



            int id = int.Parse(txtID.Text.ToString());
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon.Open();
            SqlCommand cmdSelect = new SqlCommand(" Select contantid from ARContacts where contantid= '" + LabelID.Text.ToString() + "'", sqlcon);
            SqlDataReader dr = cmdSelect.ExecuteReader();
           
            if (!dr.HasRows )
            {

                
                DataRow r = dbAccountingProjectDS.ARContacts.NewRow();
                r["cutomermid"] = txtID.Text;
                r["primaryAddress"] = ChXPrimary.Checked;
                r["MainNameTitle"] = comboBox1.SelectedItem.ToString();
                r["LastName"] = txtLast.Text;
                r["FirstName"] = txtFirst.Text;
                r["Contact"] = txtContact.Text;
                r["phone"] = txtPhone.Text;
                r["fax"] = txtFax.Text;

                r["Email"] = txtEmail.Text;
                r["EmailInvoices"] =ChxEmail.Checked;
                r["Salution"] = txtSalution.Text;
                r["PrintBalance"] = ChXPrint.Checked;


                dbAccountingProjectDS.ARContacts.Rows.Add(r);
                
                dr.Close();
                sqlcon.Close();
               

            }

            this.aRContactsTableAdapter.Update(this.dbAccountingProjectDS.ARContacts);
            dbAccountingProjectDS.AcceptChanges();

            txtSalution.Text = "";
            txtPhone.Text = "";
            txtLast.Text = "";
            txtFirst.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            ChXPrint.Checked = false;
            ChXPrimary.Checked = false;
            ChxEmail.Checked = false;
            GrXDetails.Enabled = false;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                txtLast.Text = "";
                txtContact.Text = "";
                txtEmail.Text = "";
                txtFax.Text = "";
                txtFirst.Text = "";
                txtPhone.Text = "";
                txtSalution.Text = "";
                
                comboBox1.SelectedIndex = 0;
                ChxEmail.Checked = false;
                ChXPrimary.Checked = false;
                ChXPrint.Checked = false;

                int i;
                i = dataGridView1.CurrentRow.Index;


                LabelID.Text = dataGridView1[0, i].Value.ToString();
                txtID.Text = dataGridView1[1, i].Value.ToString();
                txtEmail.Text = dataGridView1[9, i].Value.ToString();
                txtFax.Text = dataGridView1[8, i].Value.ToString();
                txtLast.Text = dataGridView1[4, i].Value.ToString();
                txtFirst.Text = dataGridView1[5, i].Value.ToString();
                txtPhone.Text = dataGridView1[6, i].Value.ToString();
                txtContact.Text = dataGridView1[7, i].Value.ToString();
                txtSalution.Text = dataGridView1[11, i].Value.ToString();
                comboBox1.Text = dataGridView1[3, i].Value.ToString();
                ChxEmail.Checked = bool.Parse(dataGridView1[10, i].Value.ToString());
                ChXPrimary.Checked = bool.Parse(dataGridView1[2, i].Value.ToString());
                ChXPrint.Checked = bool.Parse(dataGridView1[12, i].Value.ToString());
               
                EditBtn.Enabled = true;
                DeleteBtn.Enabled = true;
            }

            catch (Exception ex)
            { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {

            if (LabelID.Text != "")
            {
                LabelID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                groupBox1.Enabled = true;
                GrXDetails.Enabled = true;
                NewBtn.Visible = true;
                NewSaveBtn.Visible = false;
                NewSaveBtn.Enabled = true;
                EditSaveBtn.Visible = true;
                EditBtn.Visible = false;
                DeleteBtn.Enabled = true;
                UndoBtn.Enabled = true;
            }
            else
            {
                MessageBox.Show("Select Row to Edit !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditSaveBtn_Click(object sender, EventArgs e)
        {
            DeleteBtn.Enabled = true;
            UndoBtn.Enabled = true;

            NewBtn.Visible = true;
            NewSaveBtn.Visible = false;
            NewSaveBtn.Enabled = true;
            EditBtn.Visible = true;
            GrXDetails.Enabled = false;

            int IDS = int.Parse(LabelID.Text.ToString());
           

                if (GeneralFunctions.FindRow("contantId = '" + IDS + "'", dbAccountingProjectDS.ARContacts))
                {
                    DataRow r = dbAccountingProjectDS.ARContacts.FindBycontantId(IDS);
                    r.BeginEdit();
                    r["cutomermid"] = txtID.Text;
                    r["primaryAddress"] = ChXPrimary.Checked;
                    r["MainNameTitle"] = comboBox1.SelectedItem.ToString();
                    r["LastName"] = txtLast.Text;
                    r["FirstName"] = txtFirst.Text;
                    r["Contact"] = txtContact.Text;
                    r["phone"] = txtPhone.Text;
                    r["fax"] = txtFax.Text;

                    r["Email"] = txtEmail.Text;
                    r["EmailInvoices"] =ChxEmail.Checked;
                    r["Salution"] = txtSalution.Text;
                    r["PrintBalance"] = ChXPrint.Checked;
                    r.EndEdit();
                    this.aRContactsTableAdapter.Update(this.dbAccountingProjectDS.ARContacts);
            }

            this.aRContactsTableAdapter.Update(this.dbAccountingProjectDS.ARContacts);
            dbAccountingProjectDS.AcceptChanges();
            dataGridView1.ClearSelection();
            txtLast.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtFax.Text = "";
            txtFirst.Text = "";
            txtPhone.Text = "";
            txtSalution.Text = "";
            ChxEmail.Checked = false;
            ChXPrimary.Checked = false;
            ChXPrint.Checked = false;
        }

        private void UndoBtn_Click(object sender, EventArgs e)
        {
            NewBtn.Visible = true;
            NewSaveBtn.Visible = false;
            EditBtn.Visible = true;

            try
            {

                txtLast.Text = "";
                txtContact.Text = "";
                txtEmail.Text = "";
                txtFax.Text = "";
                txtFirst.Text = "";
                txtPhone.Text = "";
                txtSalution.Text = "";

                comboBox1.SelectedIndex = 0;
                ChxEmail.Checked = false;
                ChXPrimary.Checked = false;
                ChXPrint.Checked = false;

                int i;
                i = dataGridView1.CurrentRow.Index;


                LabelID.Text = dataGridView1[0, i].Value.ToString();
                txtID.Text = dataGridView1[1, i].Value.ToString();
                txtEmail.Text = dataGridView1[9, i].Value.ToString();
                txtFax.Text = dataGridView1[8, i].Value.ToString();
                txtLast.Text = dataGridView1[4, i].Value.ToString();
                txtFirst.Text = dataGridView1[5, i].Value.ToString();
                txtPhone.Text = dataGridView1[6, i].Value.ToString();
                txtContact.Text = dataGridView1[7, i].Value.ToString();
                txtSalution.Text = dataGridView1[11, i].Value.ToString();
                comboBox1.Text = dataGridView1[3, i].Value.ToString();
                ChxEmail.Checked = bool.Parse(dataGridView1[10, i].Value.ToString());
                ChXPrimary.Checked = bool.Parse(dataGridView1[2, i].Value.ToString());
                ChXPrint.Checked = bool.Parse(dataGridView1[12, i].Value.ToString());

                EditBtn.Enabled = true;
                DeleteBtn.Enabled = true;
            }

            catch (Exception ex)
            { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            
            DialogResult myrst;
            myrst = MessageBox.Show("Are You Sure Delete This Allocation", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return;


            if (dataGridView1.SelectedRows.Count > 0)
            {
                dbAccountingProjectDS.ARContacts.Rows[dataGridView1.SelectedRows[0].Index].Delete();
                this.aRContactsTableAdapter.Update(this.dbAccountingProjectDS.ARContacts);
            }

            else
            {
                if (LabelID.Text != "")
                {
                    int IDS = int.Parse(LabelID.Text.ToString());
                    DataRow[] rArr = dbAccountingProjectDS.ARContacts.Select("contantId= '" + IDS + "'");
                    if (rArr.Length != 0)
                    {

                        rArr[0].Delete();
                        txtLast.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtFax.Text = "";
            txtFirst.Text = "";
            txtPhone.Text = "";
            txtSalution.Text = "";
            ChxEmail.Checked = false;
            ChXPrimary.Checked = false;
            ChXPrint.Checked = false;

        }

    }
}
dataGridView1.ClearSelection();

this.aRContactsTableAdapter.Update(this.dbAccountingProjectDS.ARContacts);
dbAccountingProjectDS.AcceptChanges();
        }

    }
}