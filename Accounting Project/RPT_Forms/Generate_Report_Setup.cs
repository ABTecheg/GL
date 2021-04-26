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
using JThomas.Controls;
using Accounting_GeneralLedger.Resources;
using System.Collections;
namespace Accounting_GeneralLedger
{
    public partial class Generate_Report_Setup : Form
    {

        public Generate_Report_Setup()
        {
            InitializeComponent();
        }
        private void Generate_Report_Setup_Load(object sender, EventArgs e)
        {
            GeneralFunctions.priviledgeGroupBox(Lock57);
            GeneralFunctions.priviledgeGroupBox(Lock58);
            GeneralFunctions.priviledgeGroupBox(Lock59);
            LoadDataJournal();
            ClearAll();
        }
        private void LoadDataJournal()
        {
            try
            {
                listAvilableItems.Items.Clear();
                listChosenItems.Items.Clear();

                DataTable Dt = DataClass.RetrieveData("SELECT JournalCode, JournalDescription FROM GLJournalCodes ORDER BY JournalDescription");
                if (Dt.Rows.Count > 0)
                {
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        listAvilableItems.Items.Add(Dt.Rows[i]["JournalCode"].ToString(), Dt.Rows[i]["JournalDescription"].ToString(), null);
                    }
                }
            }
            catch (Exception ex)
            {
                DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void update_language_interface()
        {
            //this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            //this.Text = obj_interface_language.formGenerate_Report_Setup;

            //this.chkactive.Text = obj_interface_language.checkboxActive;
            //this.label7.Text = obj_interface_language.lblUserID;
            //this.lblRpt_Code.Text = obj_interface_language.labelBatch;
            //this.label11.Text = obj_interface_language.lblCountUnits;
            //this.label2.Text = obj_interface_language.labelJVDescription;
            //this.label3.Text = obj_interface_language.labelJVCode;
            //this.label8.Text = obj_interface_language.labelBalance;
            //this.label_Currency.Text = obj_interface_language.currency;
            //this.label_CurrencyRate.Text = obj_interface_language.lblCurrencyRate;
            //this.checkBox_multiCurrency.Text = obj_interface_language.checkbox_multiCurrency;

            //this.btnNew.Text = obj_interface_language.buttonJVTransactionNew;
            //this.btnEdit.Text = obj_interface_language.buttonJVTransactionEdit;
            //this.btnDelete.Text = obj_interface_language.buttonJVTransactionDelete;
            //this.btnUndo.Text = obj_interface_language.buttonJVTransactionUndo;
            //this.btnExit.Text = obj_interface_language.buttonJVTransactionExit;
            //this.btnSaveNew.Text = obj_interface_language.buttonJVTransactionSaveNew;
            //this.btnSaveEdit.Text = obj_interface_language.buttonJVTransactionSaveEdit;
            //this.btnFind.Text = obj_interface_language.buttonJVTransactionsFind;

            //this.dgv.Columns[1].HeaderText = obj_interface_language.dgvJVTransactionsColumn1;
            //this.dgv.Columns[3].HeaderText = obj_interface_language.dgvJVTransactionsColumn2;
            //this.dgv.Columns[5].HeaderText = obj_interface_language.dgvJVTransactionsColumn5;
            //this.dgv.Columns[6].HeaderText = obj_interface_language.dgvJVTransactionsColumn8;
            //this.dgv.Columns[9].HeaderText = obj_interface_language.dgvJVTransactionsColumn7;
            //this.dgv.Columns[10].HeaderText = obj_interface_language.dgvJVTransactionsColumn10;
            //this.dgv.Columns[7].HeaderText = obj_interface_language.dgvJVTransactionsColumn9;
            //this.dgv.Columns[8].HeaderText = obj_interface_language.dgvJVTransactionsColumn6;
            //this.dgv.Columns[11].HeaderText = obj_interface_language.dgvJVTransactionsColumn12;


        }

        private void ClearAll()
        {
            txt_UserID.Text = AaDeclrationClass.xUserName;
            txtRpt_Code.Text = "";
            txtRpt_Code.Enabled = true;
            txtRpt_Name.Text = "";
            txtRow_Code.Text = "";
            txtCol_Code.Text = "";
            cmbPaper_Size.SelectedIndex = 0;
            cmbStylePaper.SelectedIndex = 0;
            chkactive.Checked = false;
            chkDaily_Rev.Checked = false;
            btnalltoAvlItems_Click("", null);
        }

        private void FindReport(string FReport)
        {
            try
            {
                ClearAll();
                DataTable dt = DataClass.RetrieveData("SELECT GR.Rpt_Code, GR.Rpt_Name, GR.Col_Code, GR.Row_Code, GR.Paper_Size, GR.StylePaper, GR.Rpt_Font, GR.Daily_Rev, GRJ.JournalCodeID,  GR.Active, GR.User_ID, dbo.Users.UserName, GLJ.JournalCode, GLJ.JournalDescription FROM dbo.GLJournalCodes AS GLJ RIGHT OUTER JOIN dbo.G_Report_Journal AS GRJ ON GLJ.JournalCode = GRJ.JournalCodeID RIGHT OUTER JOIN dbo.G_Report AS GR ON GRJ.Rpt_Code = GR.Rpt_Code LEFT OUTER JOIN dbo.Users ON GR.User_ID = dbo.Users.UserID WHERE (GR.Rpt_Code = N'" + FReport.Trim() + "') ORDER BY GRJ.Serial");
                if (dt.Rows.Count > 0)
                {
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    txtRpt_Code.Text = dt.Rows[0]["Rpt_Code"].ToString();
                    txtRpt_Name.Text = dt.Rows[0]["Rpt_Name"].ToString();
                    chkactive.Checked = (bool)dt.Rows[0]["Active"];
                    txt_UserID.Text = dt.Rows[0]["UserName"].ToString();
                    txtRow_Code.Text = dt.Rows[0]["Row_Code"].ToString();
                    txtCol_Code.Text = dt.Rows[0]["Col_Code"].ToString();
                    cmbPaper_Size.Text = dt.Rows[0]["Paper_Size"].ToString();
                    cmbStylePaper.Text = dt.Rows[0]["StylePaper"].ToString();
                    chkDaily_Rev.Checked = (bool)dt.Rows[0]["Daily_Rev"];
                    if (chkDaily_Rev.Checked)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ListViewItem Ky = listAvilableItems.Items[dt.Rows[i]["JournalCodeID"].ToString()];
                            listAvilableItems.Items.Remove(Ky);
                            listChosenItems.Items.Add(Ky);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FrmDgv frm = new FrmDgv();
            frm.MyView = new DataView(DataClass.RetrieveData("SELECT GR.Rpt_Code, GR.Rpt_Name, GR.Col_Code, GR.Row_Code, GR.Paper_Size, GR.StylePaper, GR.Rpt_Font, GR.Daily_Rev, GR.Active, GR.User_ID, dbo.Users.UserName FROM dbo.G_Report AS GR LEFT OUTER JOIN dbo.Users ON GR.User_ID = dbo.Users.UserID"));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                FindReport(frm.selrow.Cells[0].FormattedValue.ToString());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
                btnNew.Visible = false;
                btnSaveNew.Visible = true;
                btnNew.Enabled = false;
                btnSaveNew.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                groupDetails.Enabled = true;
                chkactive.Checked = true;
                txtRpt_Code.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRpt_Code.Text.Trim()))
                {
                    MessageBox.Show("Enter the Code", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (!string.IsNullOrEmpty(txtRpt_Code.Text.Trim()))
                {
                    if (DataClass.CheckIfPrimaryInteredBefore("G_Report", "Rpt_Code", "Rpt_Code", txtRpt_Code.Text.Trim()))
                    {
                        MessageBox.Show("This Code Entered Before", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
                if (string.IsNullOrEmpty(txtRpt_Name.Text.Trim()))
                {
                    MessageBox.Show("Enter the Name", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (string.IsNullOrEmpty(txtCol_Code.Text.Trim()))
                {
                    MessageBox.Show("Enter the Column", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (string.IsNullOrEmpty(txtRow_Code.Text.Trim()))
                {
                    MessageBox.Show("Enter the Row", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (chkDaily_Rev.Checked && listChosenItems.Items.Count == 0)
                {
                    MessageBox.Show("Enter the Journal", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                ArrayList ItemsNames = new ArrayList();
                ArrayList ItemsValues = new ArrayList();

                ItemsNames.Add("Rpt_Code");
                ItemsValues.Add(txtRpt_Code.Text.Trim());

                ItemsNames.Add("Rpt_Name");
                ItemsValues.Add(txtRpt_Name.Text.Trim());

                ItemsNames.Add("Col_Code");
                ItemsValues.Add(txtCol_Code.Text.Trim());

                ItemsNames.Add("Row_Code");
                ItemsValues.Add(txtRow_Code.Text.Trim());

                ItemsNames.Add("Paper_Size");
                ItemsValues.Add(cmbPaper_Size.Text.Trim());

                ItemsNames.Add("StylePaper");
                ItemsValues.Add(cmbStylePaper.Text.Trim());

                ItemsNames.Add("Rpt_Font");
                ItemsValues.Add(Rpt_Font.Text.Trim());

                ItemsNames.Add("Daily_Rev");
                ItemsValues.Add(chkDaily_Rev.Checked);

                ItemsNames.Add("Active");
                ItemsValues.Add(chkactive.Checked);

                ItemsNames.Add("User_ID");
                ItemsValues.Add(AaDeclrationClass.xUserCode);

                string Ins = "insert into G_Report (Rpt_Code,Rpt_Name,Col_Code,Row_Code,Paper_Size,StylePaper,Rpt_Font,Daily_Rev,Active,CreateDate,ModifiedDate,User_ID) values (@Rpt_Code,@Rpt_Name,@Col_Code,@Row_Code,@Paper_Size,@StylePaper,@Rpt_Font,@Daily_Rev,@Active,GetDate(),GetDate(),@User_ID)";
                DataClass.InsertRecord(Ins, ItemsNames, ItemsValues);
                updateRpt_Details(txtRpt_Code.Text.Trim());

                MessageBox.Show("Saved Successfully ...", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNew.Visible = true;
                btnNew.Enabled = true;
                btnSaveNew.Enabled = false;
                btnSaveNew.Visible = false;
                btnSaveEdit.Visible = false;
                btnSaveEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = true;
                groupDetails.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void updateRpt_Details(string Rpt_Code)
        {
            string str = "";
            str += "Delete G_Report_Journal Where Rpt_Code = '" + Rpt_Code + "' ; \n ";
            if (chkDaily_Rev.Checked)
            {
                if (listChosenItems.Items.Count > 0)
                {
                    foreach (ListViewItem Ky in listChosenItems.Items)
                    {
                        str += "insert into G_Report_Journal (Rpt_Code,JournalCodeID,Serial) values ('" + Rpt_Code.Trim() + "','" + Ky.Name.Trim() + "'," + (Ky.Index + 1).ToString() + ")";
                    }
                }
            }
            if (str.Trim() != "")
                DataClass.setNonQuery(str);
        }
        private void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.ToString() != "NO")
                {
                    if (groupDetails.Enabled == true)
                    {
                        DialogResult myrst;
                        myrst = MessageBox.Show("Are You Sure Exit Without Save ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (myrst == DialogResult.No)
                            return;
                    }
                }
                ClearAll();
                btnNew.Visible = true;
                btnSaveNew.Visible = false;
                btnEdit.Visible = true;
                btnSaveEdit.Visible = false;
                btnNew.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                groupDetails.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRpt_Code.Text.Trim() == "")
                {
                    MessageBox.Show("Please Select The Column", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                groupDetails.Enabled = true;
                btnEdit.Visible = false;
                btnSaveEdit.Visible = true;
                btnEdit.Enabled = false;
                btnSaveEdit.Enabled = true;
                btnNew.Enabled = false;
                btnDelete.Enabled = false;
                txtRpt_Code.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRpt_Name.Text.Trim()))
                {
                    MessageBox.Show("Enter the Name", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (string.IsNullOrEmpty(txtCol_Code.Text.Trim()))
                {
                    MessageBox.Show("Enter the Column", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (string.IsNullOrEmpty(txtRow_Code.Text.Trim()))
                {
                    MessageBox.Show("Enter the Row", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (chkDaily_Rev.Checked && listChosenItems.Items.Count == 0)
                {
                    MessageBox.Show("Enter the Journal", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                ArrayList ItemsNames = new ArrayList();
                ArrayList ItemsValues = new ArrayList();

                ItemsNames.Add("Rpt_Code");
                ItemsValues.Add(txtRpt_Code.Text.Trim());

                ItemsNames.Add("Rpt_Name");
                ItemsValues.Add(txtRpt_Name.Text.Trim());

                ItemsNames.Add("Col_Code");
                ItemsValues.Add(txtCol_Code.Text.Trim());

                ItemsNames.Add("Row_Code");
                ItemsValues.Add(txtRow_Code.Text.Trim());

                ItemsNames.Add("Paper_Size");
                ItemsValues.Add(cmbPaper_Size.Text.Trim());

                ItemsNames.Add("StylePaper");
                ItemsValues.Add(cmbStylePaper.Text.Trim());

                ItemsNames.Add("Rpt_Font");
                ItemsValues.Add(Rpt_Font.Text.Trim());

                ItemsNames.Add("Daily_Rev");
                ItemsValues.Add(chkDaily_Rev.Checked);

                ItemsNames.Add("Active");
                ItemsValues.Add(chkactive.Checked);

                ItemsNames.Add("User_ID");
                ItemsValues.Add(AaDeclrationClass.xUserCode);

                string Ins = "update G_Report Set Rpt_Name=@Rpt_Name,Col_Code=@Col_Code,Row_Code=@Row_Code,Paper_Size=@Paper_Size,StylePaper=@StylePaper,Rpt_Font=@Rpt_Font,Daily_Rev=@Daily_Rev, Active=@Active, ModifiedDate=GetDate(), User_ID=@User_ID Where Rpt_Code=@Rpt_Code";
                DataClass.InsertRecord(Ins, ItemsNames, ItemsValues);
                updateRpt_Details(txtRpt_Code.Text.Trim());

                MessageBox.Show("Saved Successfully ...", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupDetails.Enabled = false;
                btnEdit.Visible = true;
                btnEdit.Enabled = true;
                btnSaveEdit.Visible = false;
                btnSaveEdit.Enabled = false;
                btnNew.Enabled = true;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRpt_Code.Text.Trim() == "")
                {
                    MessageBox.Show("Please Select The Report", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (DialogResult.No == MessageBox.Show("Are You Sure Delete This ", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    return;


                DataClass.DeleteRecord(txtRpt_Code.Text.Trim(), "Rpt_Code", "G_Report_Journal", "");
                DataClass.DeleteRecord(txtRpt_Code.Text.Trim(), "Rpt_Code", "G_Report", "");
                ClearAll();
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupDetails_EnabledChanged(object sender, EventArgs e)
        {
            btnFind.Enabled = !groupDetails.Enabled;
            txtFind.Enabled = !groupDetails.Enabled;
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtFind.Text != "")
                    FindReport(txtFind.Text);
            }
        }

        private void Generate_Report_Setup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (groupDetails.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void listAvilableItems_DoubleClick(object sender, EventArgs e)
        {
            btntoSelItems_Click("", null);
        }

        private void listChosenItems_DoubleClick(object sender, EventArgs e)
        {
            btntoAvlItems_Click("", null);
        }

        private void btntoSelItems_Click(object sender, EventArgs e)
        {
            try
            {
                if (listAvilableItems.SelectedItems.Count > 0)
                {
                    listChosenItems.Sorting = System.Windows.Forms.SortOrder.None;
                    int I = listAvilableItems.SelectedItems[0].Index;
                    while (listAvilableItems.SelectedItems.Count > 0)
                    {
                        ListViewItem Ky = listAvilableItems.SelectedItems[0];
                        listAvilableItems.Items.Remove(Ky);
                        listChosenItems.Items.Add(Ky);
                        listChosenItems.Items[Ky.Name].Selected = false;
                    }
                    if (listAvilableItems.Items.Count > 0)
                    {
                        if (I < listAvilableItems.Items.Count)
                            listAvilableItems.Items[I].Selected = true;
                        else
                            listAvilableItems.Items[0].Selected = true;
                    }
                    listChosenItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            catch (Exception ex)
            {
                DataClass.LogError(ex); MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnalltoSelItems_Click(object sender, EventArgs e)
        {
            try
            {
                if (listAvilableItems.Items.Count > 0)
                {
                    listChosenItems.Sorting = System.Windows.Forms.SortOrder.None;
                    while (listAvilableItems.Items.Count > 0)
                    {
                        ListViewItem Ky = listAvilableItems.Items[0];
                        listAvilableItems.Items.Remove(Ky);
                        listChosenItems.Items.Add(Ky);
                        listChosenItems.Items[Ky.Name].Selected = false;
                    }
                    listChosenItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            catch (Exception ex)
            {
                DataClass.LogError(ex); MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btntoAvlItems_Click(object sender, EventArgs e)
        {
            try
            {
                if (listChosenItems.SelectedItems.Count > 0)
                {
                    listAvilableItems.Sorting = System.Windows.Forms.SortOrder.None;
                    int I = listChosenItems.SelectedItems[0].Index;
                    while (listChosenItems.SelectedItems.Count > 0)
                    {
                        ListViewItem Ky = listChosenItems.SelectedItems[0];
                        listChosenItems.Items.Remove(Ky);
                        listAvilableItems.Items.Add(Ky);
                        listAvilableItems.Items[Ky.Name].Selected = false;
                    }
                    if (listChosenItems.Items.Count > 0)
                    {
                        if (I < listChosenItems.Items.Count)
                            listChosenItems.Items[I].Selected = true;
                        else
                            listChosenItems.Items[0].Selected = true;
                    }
                    listAvilableItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            catch (Exception ex)
            {
                DataClass.LogError(ex); MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnalltoAvlItems_Click(object sender, EventArgs e)
        {
            try
            {
                if (listChosenItems.Items.Count > 0)
                {
                    listAvilableItems.Sorting = System.Windows.Forms.SortOrder.None;
                    while (listChosenItems.Items.Count > 0)
                    {
                        ListViewItem Ky = listChosenItems.Items[0];
                        listChosenItems.Items.Remove(Ky);
                        listAvilableItems.Items.Add(Ky);
                        listAvilableItems.Items[Ky.Name].Selected = false;
                    }
                    listAvilableItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            catch (Exception ex)
            {
                DataClass.LogError(ex); MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkDaily_Rev_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Enabled = chkDaily_Rev.Checked;
        }

        private void btnCol_Code_Click(object sender, EventArgs e)
        {
            FrmDgv frm = new FrmDgv();
            frm.MyView = new DataView(DataClass.RetrieveData("SELECT GRC.Col_Code, GRC.Col_Name, GRC.Active, GRC.User_ID, dbo.Users.UserName FROM dbo.G_Report_Col AS GRC LEFT OUTER JOIN dbo.Users ON GRC.User_ID = dbo.Users.UserID"));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCol_Code.Text = frm.selrow.Cells[0].FormattedValue.ToString();
            }
        }

        private void btnRow_Code_Click(object sender, EventArgs e)
        {
            FrmDgv frm = new FrmDgv();
            frm.MyView = new DataView(DataClass.RetrieveData("SELECT GRC.Row_Code, GRC.Row_Name, GRC.Active, GRC.User_ID, dbo.Users.UserName FROM dbo.G_Report_Row AS GRC LEFT OUTER JOIN dbo.Users ON GRC.User_ID = dbo.Users.UserID"));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtRow_Code.Text = frm.selrow.Cells[0].FormattedValue.ToString();
            }
        }


    }
}