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
    public partial class TypeCategories : Form
    {

        public SqlConnection sqlcon;
        public SqlDataAdapter adapter;
        public SqlCommandBuilder cmdBuilder;



        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;

        public TypeCategories()
        {
            InitializeComponent();
        }

        private void TypeCategories_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            // TODO: This line of code loads data into the 'dbAccountingProjectDS.TypeCategories' table. You can move, or remove it, as needed.
            this.typeCategoriesTableAdapter.Fill(this.dbAccountingProjectDS.TypeCategories);


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
            this.Text = obj_interface_language.formTypesCategories;
            this.Label2.Text = obj_interface_language.Type_ID;
            this.Label1.Text = obj_interface_language.Description;
            this.label3.Text = obj_interface_language.CategoryName;
            this.datag.Columns[0].HeaderText = obj_interface_language.Type_ID;
            this.datag.Columns[1].HeaderText = obj_interface_language.CategoryName;
            this.datag.Columns[2].HeaderText = obj_interface_language.Description;

            this.NewBtn.Text = obj_interface_language.buttonbtnNew;
            this.EditBtn.Text = obj_interface_language.buttonbtnEdit;
            this.DeleteBtn.Text = obj_interface_language.buttonbtnDelete;
            this.UndoBtn.Text = obj_interface_language.buttonbtnUndo;
            this.ExitBtn.Text = obj_interface_language.buttonCompanyExit;

        }
        private void NewBtn_Click(object sender, EventArgs e)
        {
            txt_Name.Text = "";
            txt_Desc.Text = "";
        

            SqlConnection sqlconBatch = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconBatch.Open();
            SqlCommand getBatch = new SqlCommand("Select Max(TypeID)+1 From typeCategories", sqlconBatch);
            if (getBatch.ExecuteScalar() != DBNull.Value)
            {
                txt_Id.Text = getBatch.ExecuteScalar().ToString();
            }
            else
            {
                txt_Id.Text = "1";
            }
            sqlconBatch.Close();

            groupBox1.Enabled = true;
            NewBtn.Visible = false;
            NewSaveBtn.Visible = true;
            EditBtn.Enabled = false;
            DeleteBtn.Enabled = false;
           
            
        }

        private void NewSaveBtn_Click(object sender, EventArgs e)
        {
           
            insertToolStripMenuItem_Click(sender, e);
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txt_Desc.Text == "" || txt_Name.Text == "")
            {
                MessageBox.Show("Required Field Missing !!", "General Ledger");
                return;
            }


            int id = int.Parse(txt_Id.Text.ToString());
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon.Open();
            SqlCommand cmdSelect = new SqlCommand(" Select TypeID from typeCategories where TypeID= '" + id + "'", sqlcon);
            SqlDataReader dr = cmdSelect.ExecuteReader();
           
            if (!dr.HasRows && !GeneralFunctions.FindRow("TypeID = '" + id + "'", dbAccountingProjectDS.TypeCategories))
            {
                DataRow r = dbAccountingProjectDS.TypeCategories.NewRow();
                r["TypeID"] = id;
                r["TypeCatName"] = txt_Name.Text;
                r["TDesc"] = txt_Desc.Text;
                dbAccountingProjectDS.TypeCategories.Rows.Add(r);

                MessageBox.Show("Type Categories Record inserted successfully", "General Ledger");

                txt_Id.Text = "";
                txt_Name.Text = "";
                txt_Desc.Text = "";
                dr.Close();
                sqlcon.Close();
            }

            groupBox1.Enabled = false;
            NewBtn.Visible = true;
            NewSaveBtn.Visible = false;
          
            SaveChanges();


        }
        private void SaveChanges()
        {
            this.typeCategoriesTableAdapter.Update(this.dbAccountingProjectDS.TypeCategories);
            dbAccountingProjectDS.AcceptChanges();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {

            groupBox1.Enabled = true;
            EditBtn.Visible = false;
            EditSaveBtn.Visible = true;
            NewBtn.Enabled = false;
            DeleteBtn.Enabled = false;


            if (datag.SelectedRows.Count > 0)
            {
                txt_Id.Text = datag.SelectedRows[0].Cells[0].Value.ToString();

            }
        }

        private void EditSaveBtn_Click(object sender, EventArgs e)
        {
            
            int id = int.Parse(txt_Id.Text.ToString());


            if (datag.SelectedRows.Count > 0)
            {
                if (GeneralFunctions.ValidateString(txt_Name.Text, "Please Enter a valid Type Categories Name"))
                {

                    if (GeneralFunctions.FindRow("TypeID = '" + id + "'", dbAccountingProjectDS.TypeCategories))
                    {
                        DataRow r = dbAccountingProjectDS.TypeCategories.FindByTypeID(id);


                        r.BeginEdit();
                        r["TypeID"] = id;
                        r["TypeCatName"] = txt_Name.Text;
                        r["TDesc"] = txt_Desc.Text;
                        r.EndEdit();
                        this.typeCategoriesTableAdapter.Update(this.dbAccountingProjectDS.TypeCategories);
                        MessageBox.Show("Type Categories Record edited successfully", "General Ledger");
                    }
                }
            }
            else 
            {
                MessageBox.Show("Please Select the row that you want to edit", "General Ledger");
            }

            

            
            SaveChanges();
            datag.ClearSelection();
            groupBox1.Enabled = false;
            EditBtn.Visible = true;
            EditSaveBtn.Visible = false;
            NewBtn.Enabled = true;
            DeleteBtn.Enabled = true;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {

            DialogResult myrst;
            myrst = MessageBox.Show("Are You Sure Delete This Type Categories", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return;
 
            if (datag.SelectedRows.Count > 0)
            {
                dbAccountingProjectDS.TypeCategories.Rows[datag.SelectedRows[0].Index].Delete();
            
                txt_Desc.Text = "";
                txt_Name.Text = "";
                this.typeCategoriesTableAdapter.Update(this.dbAccountingProjectDS.TypeCategories);

            }
            else
            {
                if (txt_Id.Text != "")
                {
                    int id = int.Parse(txt_Id.Text.ToString());
                    DataRow[] rArr = dbAccountingProjectDS.TypeCategories.Select("TypeID = '" + id + "'");
                    if (rArr.Length != 0)
                    {
                    
                        rArr[0].Delete();
                        
                        txt_Id.Text = "";
                        txt_Name.Text = "";
                        txt_Desc.Text = "";
                    }
                    
                }
            }
            datag.ClearSelection();
            SaveChanges();
 
            this.typeCategoriesTableAdapter.Update(this.dbAccountingProjectDS.TypeCategories);
           
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
            txt_Desc.Text = "";
            txt_Name.Text="";
            txt_Id.Text = "";
            NewBtn.Visible = true;
            NewSaveBtn.Visible = false;
            EditBtn.Visible = true;
            EditSaveBtn.Visible = false;
            groupBox1.Enabled = false;
            NewBtn.Enabled = true;
            EditBtn.Enabled = false;
            DeleteBtn.Enabled = false;

        }

        private void datag_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (groupBox1.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
            UndoBtn_Click("NO", e);

            try
            {
                if (datag.Rows.Count == 0)
                {
                    txt_Desc.Text = "";
                    txt_Name.Text = "";
                    txt_Id.Text = "";
                }
                else
                {
                    int i;
                    i = datag.CurrentRow.Index;

                    txt_Id.Text = datag[0, i].Value.ToString();
                    txt_Name.Text = datag[1, i].Value.ToString();
                    txt_Desc.Text = datag[2, i].Value.ToString();

                    groupBox1.Enabled = false;
                    DeleteBtn.Enabled = true;
                    EditBtn.Enabled = true;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void datag_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (datag.Rows.Count == 0)
                {
                    txt_Desc.Text = "";
                    txt_Name.Text = "";
                    txt_Id.Text = "";
                }
                else
                {
                    int i;
                    i = datag.CurrentRow.Index;

                    txt_Id.Text = datag[0, i].Value.ToString();
                    txt_Name.Text = datag[1, i].Value.ToString();
                    txt_Desc.Text = datag[2, i].Value.ToString();

                    EditBtn.Enabled = true;
                    DeleteBtn.Enabled = true;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_EnabledChanged(object sender, EventArgs e)
        {
            if (groupBox1.Enabled == true)
                datag.Enabled = false;
            else
                datag.Enabled = true;
        }

    }
}