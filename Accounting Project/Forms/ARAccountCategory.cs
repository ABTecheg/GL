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
    public partial class ARAccountCategory : Form
    {
        public SqlConnection sqlcon;
        public SqlDataAdapter adapter;
        public SqlCommandBuilder cmdBuilder;



        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;

        public ARAccountCategory()
        {
            InitializeComponent();
        }

        private void ARAccountCategory_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            //cmdBuilder = new SqlCommandBuilder(ar_AccontCatTableAdapter);
            this.ar_AccontCatTableAdapter.Fill(this.dbAccountingProjectDS.Ar_AccontCat);

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
            this.Text = obj_interface_language.formAccountsDefinition;
            this.label4.Text = obj_interface_language.Code;
            this.label5.Text = obj_interface_language.Type_ID;
            this.label6.Text = obj_interface_language.Description;
            this.dgv.Columns[0].HeaderText = obj_interface_language.Type_ID;
            this.dgv.Columns[1].HeaderText = obj_interface_language.Code; 
            this.dgv.Columns[2].HeaderText = obj_interface_language.Description;
           
            this.btn_New.Text = obj_interface_language.buttonbtnNew;
            this.btnedit.Text = obj_interface_language.buttonbtnEdit;
            this.btndelete.Text = obj_interface_language.buttonbtnDelete;
            this.btnundo.Text = obj_interface_language.buttonbtnUndo;
            this.btnexit.Text = obj_interface_language.buttonCompanyExit;
            
        }


        private void btn_New_Click(object sender, EventArgs e)
        {
            txt_CatCode.Text = "";
            txt_Desc.Text="";
            groupBox1.Enabled = true;
            SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconBatch.Open();
            SqlCommand getBatch = new SqlCommand("Select Max(CatID)+1 From Ar_AccontCat", sqlconBatch);
            if (getBatch.ExecuteScalar() != DBNull.Value)
            {
                txt_ID.Text = getBatch.ExecuteScalar().ToString();
            }
            else
            {
                txt_ID.Text = "1";
            }
            sqlconBatch.Close();

            
            btn_New.Visible = false;
            btnSavenew.Visible = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
            btnundo.Enabled = true;
           
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (groupBox1.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            btnundo_Click("NO", e);

            try
            {
                if (dgv.Rows.Count == 0)
                {
                    txt_Desc.Text = "";
                    txt_CatCode.Text = "";
                    txt_ID.Text = "";
                }
                else
                {
                    int i;
                    i = dgv.CurrentRow.Index;

                    txt_ID.Text = dgv[0, i].Value.ToString();
                    txt_CatCode.Text = dgv[1, i].Value.ToString();
                    txt_Desc.Text = dgv[2, i].Value.ToString();

                    btnedit.Enabled = true;
                    btndelete.Enabled = true;
                    groupBox1.Enabled = false;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
     
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult myrst;
            myrst = MessageBox.Show("Are You Sure Delete This ARAccountCategories", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return;
            btnundo.Enabled = false;
            deleteToolStripMenuItem_Click(sender, e);

        }

        private void btnSavenew_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            insertToolStripMenuItem_Click(sender, e);
        }
        private void Btnsaveedit_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            editToolStripMenuItem_Click(sender, e);
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
            txt_CatCode.Text = "";
            txt_Desc.Text = "";
            btn_New.Visible = true;
            btnSavenew.Visible = false;
            btnedit.Visible = true;
            Btnsaveedit.Visible = false;
            groupBox1.Enabled = false;
            btn_New.Enabled = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
        }

        private void btn_SaveChanges_Click(object sender, EventArgs e)
        {

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



        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon.Open();
            SqlCommand cmdSelect = new SqlCommand("Select CatID from Ar_AccontCat where CatID = '" + txt_ID.Text + "'", sqlcon);
            SqlDataReader dr = cmdSelect.ExecuteReader();
            if (!dr.HasRows && !GeneralFunctions.FindRow("CatID = '" + txt_ID.Text + "'", dbAccountingProjectDS.Ar_AccontCat))
            {
                DataRow r = dbAccountingProjectDS.Ar_AccontCat.NewRow();
                r["CatID"] = int.Parse(txt_ID.Text);


                r["ArAccCatCode"] = txt_CatCode.Text;
                r["CatDesc"] = txt_Desc.Text;
                dbAccountingProjectDS.Ar_AccontCat.Rows.Add(r);
                MessageBox.Show("Account Category inserted successfully", "General Ledger");
                txt_ID.Text = "";
                txt_CatCode.Text = "";
                txt_Desc.Text = "";
                dr.Close();
                sqlcon.Close();
            }

            
            btn_New.Visible = true;
            btnSavenew.Visible = false;
            this.ar_AccontCatTableAdapter.Update(this.dbAccountingProjectDS.Ar_AccontCat);
            SaveChanges();


        }
        private void SaveChanges()
        {
            
      
            
          
           //adapter.Update(dbAccountingProjectDS.Ar_AccontCat);
            dbAccountingProjectDS.AcceptChanges();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int id = int.Parse(txt_ID.Text.ToString());
         
             
             if (GeneralFunctions.FindRow("CatID = '" + txt_ID.Text + "'", dbAccountingProjectDS.Ar_AccontCat))
             {
                 DataRow r = dbAccountingProjectDS.Ar_AccontCat.FindByCatID(id);

                
                 r.BeginEdit();
                 r["CatID"] = int.Parse(txt_ID.Text);
                 r["ArAccCatCode"] = txt_CatCode.Text;
                 r["CatDesc"] = txt_Desc.Text;
                 r.EndEdit();
                 this.ar_AccontCatTableAdapter.Update(this.dbAccountingProjectDS.Ar_AccontCat);
             }
                

            //  SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
            //sqlconBatch.Open();
            //ar_AccontCatTableAdapter.UpdateQuery(txt_CatCode.Text.ToString(),txt_Desc.Text.ToString(),id);
            
                MessageBox.Show("Tax  Record edited successfully", "General Ledger");

            
            btnedit.Visible = true;
            Btnsaveedit.Visible = false;
            btn_New.Enabled = true;
            btndelete.Enabled = true;
            SaveChanges();
            dgv.ClearSelection();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                dbAccountingProjectDS.Ar_AccontCat.Rows[dgv.SelectedRows[0].Index].Delete();
                MessageBox.Show(" Record deleted successfully", "General Ledger");
                txt_Desc.Text = "";
                txt_CatCode.Text = "";
                this.ar_AccontCatTableAdapter.Update(this.dbAccountingProjectDS.Ar_AccontCat);

            }
            else
            {
                if (txt_ID.Text != "")
                {
                    DataRow[] rArr = dbAccountingProjectDS.Ar_AccontCat.Select("CatID = '" + txt_ID.Text + "'");
                    if (rArr.Length != 0)
                    {
                        
                        rArr[0].Delete();
                        MessageBox.Show("Record deleted successfully", "General Ledger");
                        txt_ID.Text = "";
                        txt_CatCode.Text = "";
                        txt_Desc.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("The ID doesnt exist \n Cant perform delete operation", "General Ledger");
                    }
                }
            }
            dgv.ClearSelection();
            SaveChanges();
            btnedit.Enabled = false;
            btndelete.Enabled = false;
            this.ar_AccontCatTableAdapter.Update(this.dbAccountingProjectDS.Ar_AccontCat);

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                txt_ID.Text= dgv.SelectedRows[0].Cells[0].Value.ToString();
                groupBox1.Enabled = true;
                btnedit.Visible = false;
                Btnsaveedit.Visible = true;
                btn_New.Enabled = false;
                btndelete.Enabled = false;
                btnundo.Enabled = true;
            }

        }

        private void Btnsaveedit_Click_1(object sender, EventArgs e)
        {
            editToolStripMenuItem_Click(sender, e);
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

            try
            {
                if (dgv.Rows.Count == 0)
                {
                    txt_Desc.Text = "";
                    txt_CatCode.Text = "";
                    txt_ID.Text = "";
                }
                else
                {
                    int i;
                    i = dgv.CurrentRow.Index;

                    txt_ID.Text = dgv[0, i].Value.ToString();
                    txt_CatCode.Text = dgv[1, i].Value.ToString();
                    txt_Desc.Text = dgv[2, i].Value.ToString();

                    btnedit.Enabled = true;
                    btndelete.Enabled = true;
                    groupBox1.Enabled = false;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
     

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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