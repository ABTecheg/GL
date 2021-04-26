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
    public partial class ARDiscountCategories : Form
    {

        public SqlConnection sqlcon;
        public SqlDataAdapter adapter;
        public SqlCommandBuilder cmdBuilder;



        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;

        public ARDiscountCategories()
        {
            InitializeComponent();
        }

        private void ARDiscountCategories_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbAccountingProjectDS.ARDiscountCategories' table. You can move, or remove it, as needed.
            this.aRDiscountCategoriesTableAdapter.Fill(this.dbAccountingProjectDS.ARDiscountCategories);
            this.aRDiscountCategoriesTableAdapter.Fill(this.dbAccountingProjectDS.ARDiscountCategories);


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
            this.Text = obj_interface_language.formARDiscountCategories;
            this.Label2.Text = obj_interface_language.Disc_ID;
            this.Label1.Text = obj_interface_language.Disc_Desc;
            this.label3.Text = obj_interface_language.Disc_Name;
            this.datag.Columns[0].HeaderText = obj_interface_language.Disc_ID;
            this.datag.Columns[1].HeaderText = obj_interface_language.Disc_Name;
            this.datag.Columns[2].HeaderText = obj_interface_language.Disc_Desc;

           
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
            SqlCommand getBatch = new SqlCommand("Select Max(ID)+1 From ARDiscountCategories", sqlconBatch);
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
            groupBox1.Enabled = false;
            insertToolStripMenuItem_Click(sender, e);
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            



            string id = txt_Id.Text.ToString();
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon.Open();
            SqlCommand cmdSelect = new SqlCommand(" Select ID from ARDiscountCategories where ID= '" + id + "'", sqlcon);
            SqlDataReader dr = cmdSelect.ExecuteReader();

            if (!dr.HasRows && !GeneralFunctions.FindRow("ID = '" + id + "'", dbAccountingProjectDS.ARDiscountCategories))
            {
                DataRow r = dbAccountingProjectDS.ARDiscountCategories.NewRow();
                r["ID"] = id;
                r["CatName"] = txt_Name.Text;
                r["CatDesc"] = txt_Desc.Text;
                dbAccountingProjectDS.ARDiscountCategories.Rows.Add(r);



                txt_Id.Text = "";
                txt_Name.Text = "";
                txt_Desc.Text = "";
                dr.Close();
                sqlcon.Close();
            }



            SaveChanges();

            groupBox1.Enabled = false;
            NewBtn.Visible = true;
            NewSaveBtn.Visible = false;
        }
        private void SaveChanges()
        {
            this.aRDiscountCategoriesTableAdapter.Update(this.dbAccountingProjectDS.ARDiscountCategories);
            dbAccountingProjectDS.AcceptChanges();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            EditBtn.Visible = false;
            EditSaveBtn.Visible = true;
            NewBtn.Enabled = false;
            DeleteBtn.Enabled = false;
            //txt_Name.Text = "";
            //txt_Desc.Text = "";
         


            if (datag.SelectedRows.Count > 0)
            {
                txt_Id.Text = datag.SelectedRows[0].Cells[0].Value.ToString();

            }
        }

        private void EditSaveBtn_Click(object sender, EventArgs e)
        {
            

            string id = txt_Id.Text.ToString();


            if (GeneralFunctions.FindRow("ID = '" + id + "'", dbAccountingProjectDS.ARDiscountCategories))
            {
                DataRow r = dbAccountingProjectDS.ARDiscountCategories.FindByID(id);


                r.BeginEdit();
                r["ID"] = id;
                r["CatName"] = txt_Name.Text;
                r["CatDesc"] = txt_Desc.Text;
                r.EndEdit();
                this.aRDiscountCategoriesTableAdapter.Update(this.dbAccountingProjectDS.ARDiscountCategories);
            }




            SaveChanges();
            datag.ClearSelection();
            groupBox1.Enabled = false;
            EditBtn.Visible = true;
            EditSaveBtn.Visible = false;
            NewBtn.Enabled = true;
            DeleteBtn.Enabled = true;
            txt_Name.Text = "";
            txt_Desc.Text = "";
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {

            DialogResult myrst;
            myrst = MessageBox.Show("Are You Sure Delete This Discount Categories", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return;






            if (datag.SelectedRows.Count > 0)
            {
                dbAccountingProjectDS.ARDiscountCategories.Rows[datag.SelectedRows[0].Index].Delete();

                txt_Desc.Text = "";
                txt_Name.Text = "";
                this.aRDiscountCategoriesTableAdapter.Update(this.dbAccountingProjectDS.ARDiscountCategories);

            }
            else
            {
                if (txt_Id.Text != "")
                {
                    int id = int.Parse(txt_Id.Text.ToString());
                    DataRow[] rArr = dbAccountingProjectDS.ARDiscountCategories.Select("ID = '" + id + "'");
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

            this.aRDiscountCategoriesTableAdapter.Update(this.dbAccountingProjectDS.ARDiscountCategories);

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
            txt_Name.Text = "";
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
                    NewBtn.Visible = true;
                    EditBtn.Enabled = true;
                    DeleteBtn.Enabled = true;
                    groupBox1.Enabled = false;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void datag_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (groupBox1.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    return;
            }
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
                    groupBox1.Enabled = false;
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