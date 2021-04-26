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
    public partial class Generate_Report_Rows : Form
    {

        public Generate_Report_Rows()
        {
            InitializeComponent();
        }
        DataTable DT_Type = new DataTable("DT_Type");
        DataTable DT_Divide_By_Amt = new DataTable("DT_Divide_By_Amt");
        private void Generate_Report_Rows_Load(object sender, EventArgs e)
        {
            txt_UserID.Text = AaDeclrationClass.xUserName;
            GeneralFunctions.priviledgeGroupBox(Lock57);
            GeneralFunctions.priviledgeGroupBox(Lock58);
            GeneralFunctions.priviledgeGroupBox(Lock59);
            Load_DT();
        }
        private void Load_DT()
        {
            try
            {
                DT_Type.Columns.Add("Code");
                DT_Type.Columns.Add("Description");
                DT_Type.Rows.Add(new object[] { "DESC", "Description" });
                DT_Type.Rows.Add(new object[] { "DTL", "Details Line" });
                DT_Type.Rows.Add(new object[] { "TOT", "Total" });
                DT_Type.Rows.Add(new object[] { "HDL", "header (Left of Page)" });
                DT_Type.Rows.Add(new object[] { "HDC", "header (Center of Page)" });
                DT_Type.Rows.Add(new object[] { "HDR", "header (Right of Page)" });
                DT_Type.Rows.Add(new object[] { "TOP", "Page Break" });
                DT_Type.Rows.Add(new object[] { "---", "Single Line" });
                DT_Type.Rows.Add(new object[] { "===", "Double Line" });

                DT_Divide_By_Amt.Columns.Add("Code");
                DT_Divide_By_Amt.Columns.Add("Description");
                DT_Divide_By_Amt.Rows.Add(new object[] { "", "None" });
                DT_Divide_By_Amt.Rows.Add(new object[] { "Day", "Days in Month/Year" });
                DT_Divide_By_Amt.Rows.Add(new object[] { "Num", "Fixed Number" });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void update_language_interface()
        {
            //this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            //this.Text = obj_interface_language.formGenerate_Report_Rows;

            //this.chkactive.Text = obj_interface_language.checkboxActive;
            //this.label7.Text = obj_interface_language.lblUserID;
            //this.lblRow_Code.Text = obj_interface_language.labelBatch;
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
            txtRow_Code.Text = "";
            txtRow_Code.Enabled = true;
            txtRow_Name.Text = "";
            chkactive.Checked = false;
            dgv.Rows.Clear();
        }

        private void FindRow(string FRow)
        {
            try
            {
                ClearAll();
                DataTable dt = DataClass.RetrieveData("SELECT GRC.Row_Code, GRC.Row_Name, GRC.Active, GRC.User_ID, dbo.Users.UserName, GRCT.Row_No, GRCT.Row_Type, GRCT.Row_Accounts, GRCT.Row_Divide_By_Acc,  GRCT.Row_Desc, GRCT.Row_TOT_Formula, GRCT.Row_Prec_Row, GRCT.Row_Rev, GRCT.Row_Sup, GRCT.Row_Format, GRCT.Row_Divide_By_Amt FROM dbo.G_Report_Row AS GRC LEFT OUTER JOIN dbo.G_Report_Row_Det AS GRCT ON GRC.Row_Code = GRCT.Row_Code LEFT OUTER JOIN dbo.Users ON GRC.User_ID = dbo.Users.UserID WHERE (GRC.Row_Code = N'" + FRow.Trim() + "')");
                if (dt.Rows.Count > 0)
                {
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    txtRow_Code.Text = dt.Rows[0]["Row_Code"].ToString();
                    txtRow_Name.Text = dt.Rows[0]["Row_Name"].ToString();
                    chkactive.Checked = (bool)dt.Rows[0]["Active"];
                    txt_UserID.Text = dt.Rows[0]["UserName"].ToString();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows.Add(new object[]{dt.Rows[i]["Row_No"].ToString(),
                                                    dt.Rows[i]["Row_Type"].ToString(),
                                                    dt.Rows[i]["Row_Accounts"].ToString(),
                                                    dt.Rows[i]["Row_Divide_By_Acc"].ToString(),
                                                    dt.Rows[i]["Row_Desc"].ToString(),
                                                    dt.Rows[i]["Row_TOT_Formula"].ToString(),
                                                    dt.Rows[i]["Row_Prec_Row"].ToString(),
                                                    dt.Rows[i]["Row_Rev"].ToString(),
                                                    dt.Rows[i]["Row_Sup"].ToString(),
                                                    dt.Rows[i]["Row_Format"].ToString(),
                                                    dt.Rows[i]["Row_Divide_By_Amt"].ToString()});
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
            frm.MyView = new DataView(DataClass.RetrieveData("SELECT GRC.Row_Code, GRC.Row_Name, GRC.Active, GRC.User_ID, dbo.Users.UserName FROM dbo.G_Report_Row AS GRC LEFT OUTER JOIN dbo.Users ON GRC.User_ID = dbo.Users.UserID"));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                FindRow(frm.selrow.Cells[0].FormattedValue.ToString());
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
                txtRow_Code.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool Check_Rows()
        {
            bool flage = false;
            try
            {
                if (dgv.RowCount <= 1)
                {
                    MessageBox.Show("Enter The Rows", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                for (int i = 0; i < dgv.RowCount; i++)
                {
                    if (dgv[Row_No.Index, i].FormattedValue.ToString().Trim() != "")
                    {
                        if (dgv[Row_Type.Index, i].FormattedValue.ToString().Trim() == "")
                        {
                            MessageBox.Show("Check Type Row  " + dgv[Row_No.Index, i].FormattedValue.ToString().Trim(), "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dgv[Row_Type.Index, i].Selected = true;
                            dgv.Focus();
                            return false;
                        }
                        if (dgv[Row_Accounts.Index, i].FormattedValue.ToString().Trim() == "" && dgv[Row_Type.Index, i].FormattedValue.ToString().Trim() == "DTL")
                        {
                            MessageBox.Show("Check Accounts Row  " + dgv[Row_No.Index, i].FormattedValue.ToString().Trim(), "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dgv[Row_Accounts.Index, i].Selected = true;
                            dgv.Focus();
                            return false;
                        }
                        if (dgv[Row_TOT_Formula.Index, i].FormattedValue.ToString().Trim() == "" && dgv[Row_Type.Index, i].FormattedValue.ToString().Trim() == "TOT")
                        {
                            MessageBox.Show("Check Total Formula Row  " + dgv[Row_No.Index, i].FormattedValue.ToString().Trim(), "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dgv[Row_TOT_Formula.Index, i].Selected = true;
                            dgv.Focus();
                            return false;
                        }
                        if (!dgv[Row_TOT_Formula.Index, i].FormattedValue.ToString().Contains("A") && dgv[Row_Type.Index, i].FormattedValue.ToString().Trim() == "TOT")
                        {
                            MessageBox.Show("Check Total Formula Row  " + dgv[Row_No.Index, i].FormattedValue.ToString().Trim() + " You Must Add A For Row No ... EXP. SUM(A100:B200)", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dgv[Row_TOT_Formula.Index, i].Selected = true;
                            dgv.Focus();
                            return false;
                        }
                        if (dgv[Row_Desc.Index, i].FormattedValue.ToString().Trim() == "" && (dgv[Row_Type.Index, i].FormattedValue.ToString().Trim() == "TOT" || dgv[Row_Type.Index, i].FormattedValue.ToString().Trim() == "DTL" || dgv[Row_Type.Index, i].FormattedValue.ToString().Trim() == "HDL" || dgv[Row_Type.Index, i].FormattedValue.ToString().Trim() == "HDC" || dgv[Row_Type.Index, i].FormattedValue.ToString().Trim() == "HDR"))
                        {
                            MessageBox.Show("Check Description Row  " + dgv[Row_No.Index, i].FormattedValue.ToString().Trim(), "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dgv[Row_Desc.Index, i].Selected = true;
                            dgv.Focus();
                            return false;
                        }
                    }
                }
                flage = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flage;
        }
        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRow_Code.Text.Trim()))
                {
                    MessageBox.Show("Enter the Code", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (!string.IsNullOrEmpty(txtRow_Code.Text.Trim()))
                {
                    if (DataClass.CheckIfPrimaryInteredBefore("G_Report_Row", "Row_Code", "Row_Code", txtRow_Code.Text.Trim()))
                    {
                        MessageBox.Show("This Code Entered Before", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
                if (string.IsNullOrEmpty(txtRow_Name.Text.Trim()))
                {
                    MessageBox.Show("Enter the Name", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (!Check_Rows())
                    return;

                ArrayList ItemsNames = new ArrayList();
                ArrayList ItemsValues = new ArrayList();

                ItemsNames.Add("Row_Code");
                ItemsValues.Add(txtRow_Code.Text.Trim());

                ItemsNames.Add("Row_Name");
                ItemsValues.Add(txtRow_Name.Text.Trim());

                ItemsNames.Add("Active");
                ItemsValues.Add(chkactive.Checked);

                ItemsNames.Add("User_ID");
                ItemsValues.Add(AaDeclrationClass.xUserCode);

                string Ins = "insert into G_Report_Row (Row_Code,Row_Name,Active,CreateDate,ModifiedDate,User_ID) values (@Row_Code,@Row_Name,@Active,GetDate(),GetDate(),@User_ID)";
                DataClass.InsertRecord(Ins, ItemsNames, ItemsValues);
                updateRow_Details(txtRow_Code.Text.Trim());

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
        private void updateRow_Details(string Row_Code)
        {
            string str = "";
            str += "Delete G_Report_Row_Det Where Row_Code = '" + Row_Code + "' ; \n ";
            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (dgv[Row_No.Index, i].FormattedValue.ToString().Trim() != "")
                {
                    str += "insert into G_Report_Row_Det (Row_Code,Row_No,Row_Type,Row_Accounts,Row_Divide_By_Acc,Row_Desc,Row_TOT_Formula,Row_Prec_Row,Row_Rev,Row_Sup,Row_Format,Row_Divide_By_Amt) values (" +
                           " '" + Row_Code.Trim() + "', '" + dgv[Row_No.Index, i].FormattedValue.ToString().Trim() + "'," +
                           " '" + dgv[Row_Type.Index, i].FormattedValue.ToString().Trim() + "'," +
                           " '" + dgv[Row_Accounts.Index, i].FormattedValue.ToString().Trim() + "'," +
                           " '" + dgv[Row_Divide_By_Acc.Index, i].FormattedValue.ToString().Trim() + "'," +
                           " '" + dgv[Row_Desc.Index, i].FormattedValue.ToString().Trim() + "'," +
                           " '" + dgv[Row_TOT_Formula.Index, i].FormattedValue.ToString().Trim() + "'," +
                           " '" + dgv[Row_Prec_Row.Index, i].FormattedValue.ToString().Trim() + "'," +
                           " '" + dgv[Row_Rev.Index, i].FormattedValue.ToString().Trim() + "'," +
                           " '" + dgv[Row_Sup.Index, i].FormattedValue.ToString().Trim() + "'," +
                           " '" + dgv[Row_Format.Index, i].FormattedValue.ToString().Trim() + "'," +
                           " '" + dgv[Row_Divide_By_Amt.Index, i].FormattedValue.ToString().Trim() + "') ; \n ";
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
                if (txtRow_Code.Text.Trim() == "")
                {
                    MessageBox.Show("Please Select The Row", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                groupDetails.Enabled = true;
                btnEdit.Visible = false;
                btnSaveEdit.Visible = true;
                btnEdit.Enabled = false;
                btnSaveEdit.Enabled = true;
                btnNew.Enabled = false;
                btnDelete.Enabled = false;
                txtRow_Code.Enabled = false;
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
                if (string.IsNullOrEmpty(txtRow_Name.Text.Trim()))
                {
                    MessageBox.Show("Enter the Name", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (!Check_Rows())
                    return;

                ArrayList ItemsNames = new ArrayList();
                ArrayList ItemsValues = new ArrayList();

                ItemsNames.Add("Row_Code");
                ItemsValues.Add(txtRow_Code.Text.Trim());

                ItemsNames.Add("Row_Name");
                ItemsValues.Add(txtRow_Name.Text.Trim());

                ItemsNames.Add("Active");
                ItemsValues.Add(chkactive.Checked);

                ItemsNames.Add("User_ID");
                ItemsValues.Add(AaDeclrationClass.xUserCode);

                string Ins = "update G_Report_Row Set Row_Name=@Row_Name, Active=@Active, ModifiedDate=GetDate(), User_ID=@User_ID Where Row_Code=@Row_Code";
                DataClass.InsertRecord(Ins, ItemsNames, ItemsValues);
                updateRow_Details(txtRow_Code.Text.Trim());

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
                if (txtRow_Code.Text.Trim() == "")
                {
                    MessageBox.Show("Please Select The Row", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (DialogResult.No == MessageBox.Show("Are You Sure Delete This ", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    return;

                if (DataClass.isExsist("*", " Row_Code = '" + txtRow_Code.Text.Trim() + "' ", "G_Report"))
                {
                    MessageBox.Show("Can't Delete This Because Is Used In G_Report ", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                DataClass.DeleteRecord(txtRow_Code.Text.Trim(), "Row_Code", "G_Report_Row_Det", "");
                DataClass.DeleteRecord(txtRow_Code.Text.Trim(), "Row_Code", "G_Report_Row", "");
                ClearAll();
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == Row_Type.Index)
                {
                    FrmDgv frm = new FrmDgv();
                    frm.MyView = new DataView(DT_Type);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (dgv.Rows[e.RowIndex].IsNewRow == true)
                            dgv.Rows.Add();
                        dgv[Row_Type.Index, e.RowIndex].Value = frm.selrow.Cells[0].FormattedValue.ToString();
                        for (int c = Row_Accounts.Index; c <= Row_Divide_By_Amt.Index; c++)
                            dgv[c, e.RowIndex].Value = dgv[c, e.RowIndex].DefaultNewRowValue;
                    }
                }
                else if (dgv[Row_Type.Index, e.RowIndex].FormattedValue.ToString() == "DTL" && (e.ColumnIndex == Row_Accounts.Index || e.ColumnIndex == Row_Divide_By_Acc.Index))
                {
                    FrmGLAccount_Select frm = new FrmGLAccount_Select();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        dgv[e.ColumnIndex, e.RowIndex].Value = frm.MyValue.Trim();
                        if (dgv[Row_Desc.Index, e.RowIndex].FormattedValue.ToString().Trim() == "")
                            dgv[Row_Desc.Index, e.RowIndex].Value = DataClass.ReturnRecordNameByID("Select AccountName From GLAccounts Where AccountNumber = '" + frm.MyValue.Trim() + "'");
                    }
                }
                else if (e.ColumnIndex == Row_Divide_By_Amt.Index && dgv[Row_Type.Index, e.RowIndex].FormattedValue.ToString() == "DTL")
                {
                    FrmDgv frm = new FrmDgv();
                    frm.MyView = new DataView(DT_Divide_By_Amt);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (frm.selrow.Cells[0].FormattedValue.ToString() == "Num")
                        {
                            FrmInsertText frmNum = new FrmInsertText("double", false, false);
                            if (frmNum.ShowDialog() == DialogResult.OK)
                                dgv[Row_Divide_By_Amt.Index, e.RowIndex].Value = frmNum.MyValue.Trim();
                        }
                        else
                            dgv[Row_Divide_By_Amt.Index, e.RowIndex].Value = frm.selrow.Cells[0].FormattedValue.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (dgv[Row_Type.Index, e.RowIndex].FormattedValue.ToString() == "")
                    e.Cancel = true;
                if (e.ColumnIndex == Row_TOT_Formula.Index)
                {
                    if (dgv[Row_Type.Index, e.RowIndex].FormattedValue.ToString() != "TOT")
                        e.Cancel = true;
                }
                else if (e.ColumnIndex == Row_Prec_Row.Index)
                {
                    if (dgv[Row_Type.Index, e.RowIndex].FormattedValue.ToString() != "DTL")
                        e.Cancel = true;
                }
                else if (e.ColumnIndex == Row_Divide_By_Amt.Index)
                {
                    if (dgv[Row_Type.Index, e.RowIndex].FormattedValue.ToString() != "CALC")
                        e.Cancel = true;
                }
                else if (e.ColumnIndex == Row_Rev.Index || e.ColumnIndex == Row_Sup.Index || e.ColumnIndex == Row_Format.Index)
                {
                    if (dgv[Row_Type.Index, e.RowIndex].FormattedValue.ToString() != "DTL" && dgv[Row_Type.Index, e.RowIndex].FormattedValue.ToString() != "TOT")
                        e.Cancel = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void groupDetails_EnabledChanged(object sender, EventArgs e)
        {
            dgv.Enabled = groupDetails.Enabled;
            btnFind.Enabled = !groupDetails.Enabled;
            txtFind.Enabled = !groupDetails.Enabled;
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtFind.Text != "")
                    FindRow(txtFind.Text);
            }
        }

        private void Generate_Report_Rows_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (groupDetails.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    e.Cancel = true;
            }
        }
        private void GetExcelRowName()
        {
            for (int i = 0; i < dgv.RowCount - 1; i++)
            {
                int dividend = i + 1;
                dgv[Row_No.Index, i].Value = dividend * 100;
            }
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            GetExcelRowName();
        }

        private void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetExcelRowName();
        }

        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dgvVal_KeyPress);
            e.Control.KeyPress += new KeyPressEventHandler(dgvVal_KeyPress);
        }
        private void dgvVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (dgv.CurrentCell.ColumnIndex == Row_Prec_Row.Index)
                {
                    if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
                else if (dgv.CurrentCell.ColumnIndex == Row_TOT_Formula.Index)
                {
                    string S = "1234567890()+-*/:A";
                    if (S.Contains(Convert.ToChar(e.KeyChar).ToString()) || e.KeyChar == 8)
                        e.Handled = false;
                    else
                        e.Handled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}