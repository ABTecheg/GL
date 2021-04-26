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
    public partial class Generate_Report_Columns : Form
    {

        public Generate_Report_Columns()
        {
            InitializeComponent();
        }
        DataTable DT_Type = new DataTable("DT_Type");
        DataTable DT_Source = new DataTable("DT_Source");
        DataTable DT_Range = new DataTable("DT_Range");
        DataTable DT_Period = new DataTable("DT_Period");
        private void Generate_Report_Columns_Load(object sender, EventArgs e)
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
                DT_Type.Rows.Add(new object[] { "GL", "G/L Account Data" });
                DT_Type.Rows.Add(new object[] { "CALC", "Calculation" });
                DT_Type.Rows.Add(new object[] { "PCT", "Percentage" });
                DT_Type.Rows.Add(new object[] { "DB", "G/L (Debits Only)" });
                DT_Type.Rows.Add(new object[] { "CR", "G/L (Credits Only)" });

                DT_Source.Columns.Add("Code");
                DT_Source.Columns.Add("Description");
                DT_Source.Rows.Add(new object[] { "CUR", "Current Year" });
                DT_Source.Rows.Add(new object[] { "LST", "Last Year" });
                DT_Source.Rows.Add(new object[] { "BGT", "Budget" });

                DT_Range.Columns.Add("Code");
                DT_Range.Columns.Add("Description");
                DT_Range.Rows.Add(new object[] { "MTD", "Month To Date" });
                DT_Range.Rows.Add(new object[] { "YTD", "Year To Date" });
                DT_Range.Rows.Add(new object[] { "DAY", "Run Date" });
                DT_Range.Rows.Add(new object[] { "BEG", "Beginning Balance" });

                DT_Period.Columns.Add("Code");
                DT_Period.Columns.Add("Description");
                DT_Period.Rows.Add(new object[] { "CUR", "Current Period (At Run Time)" });
                DT_Period.Rows.Add(new object[] { "PRD1", "Period 01 (Fixed)" });
                DT_Period.Rows.Add(new object[] { "PRD2", "Period 02 (Fixed)" });
                DT_Period.Rows.Add(new object[] { "PRD3", "Period 03 (Fixed)" });
                DT_Period.Rows.Add(new object[] { "PRD4", "Period 04 (Fixed)" });
                DT_Period.Rows.Add(new object[] { "PRD5", "Period 05 (Fixed)" });
                DT_Period.Rows.Add(new object[] { "PRD6", "Period 06 (Fixed)" });
                DT_Period.Rows.Add(new object[] { "PRD7", "Period 07 (Fixed)" });
                DT_Period.Rows.Add(new object[] { "PRD8", "Period 08 (Fixed)" });
                DT_Period.Rows.Add(new object[] { "PRD9", "Period 09 (Fixed)" });
                DT_Period.Rows.Add(new object[] { "PRD10", "Period 10 (Fixed)" });
                DT_Period.Rows.Add(new object[] { "PRD11", "Period 11 (Fixed)" });
                DT_Period.Rows.Add(new object[] { "PRD12", "Period 12 (Fixed)" });
                DT_Period.Rows.Add(new object[] { "PRD13", "Period 13 (Fixed)" });
                //DT_Period.Rows.Add(new object[] { "CUR-1", "Current Period 01" });
                //DT_Period.Rows.Add(new object[] { "CUR-2", "Current Period 02" });
                //DT_Period.Rows.Add(new object[] { "CUR-3", "Current Period 03" });
                //DT_Period.Rows.Add(new object[] { "CUR-4", "Current Period 04" });
                //DT_Period.Rows.Add(new object[] { "CUR-5", "Current Period 05" });
                //DT_Period.Rows.Add(new object[] { "CUR-6", "Current Period 06" });
                //DT_Period.Rows.Add(new object[] { "CUR-7", "Current Period 07" });
                //DT_Period.Rows.Add(new object[] { "CUR-8", "Current Period 08" });
                //DT_Period.Rows.Add(new object[] { "CUR-9", "Current Period 09" });
                //DT_Period.Rows.Add(new object[] { "CUR-10", "Current Period 10" });
                //DT_Period.Rows.Add(new object[] { "CUR-11", "Current Period 11" });
                //DT_Period.Rows.Add(new object[] { "CUR-12", "Current Period 12" });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void update_language_interface()
        {
            //this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            //this.Text = obj_interface_language.formGenerate_Report_Columns;

            //this.chkactive.Text = obj_interface_language.checkboxActive;
            //this.label7.Text = obj_interface_language.lblUserID;
            //this.lblCol_Code.Text = obj_interface_language.labelBatch;
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
            txtCol_Code.Text = "";
            txtCol_Code.Enabled = true;
            txtCol_Name.Text = "";
            chkactive.Checked = false;
            dgv.Rows.Clear();
        }

        private void FindColumn(string FColumn)
        {
            try
            {
                ClearAll();
                DataTable dt = DataClass.RetrieveData("SELECT GRC.Col_Code, GRC.Col_Name, GRC.Active, GRC.User_ID, dbo.Users.UserName, GRCT.Col_No, GRCT.Col_Type, GRCT.Col_Source, GRCT.Col_Range,  GRCT.Col_Period, GRCT.Col_Header, GRCT.Col_Calc_Formula, GRCT.Col_Prec_Source, GRCT.Col_Width, GRCT.Col_Sup, GRCT.Col_Calc_Divide FROM dbo.G_Report_Col AS GRC LEFT OUTER JOIN dbo.G_Report_Col_Det AS GRCT ON GRC.Col_Code = GRCT.Col_Code LEFT OUTER JOIN dbo.Users ON GRC.User_ID = dbo.Users.UserID WHERE (GRC.Col_Code = N'" + FColumn.Trim() + "')");
                if (dt.Rows.Count > 0)
                {
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    txtCol_Code.Text = dt.Rows[0]["Col_Code"].ToString();
                    txtCol_Name.Text = dt.Rows[0]["Col_Name"].ToString();
                    chkactive.Checked = (bool)dt.Rows[0]["Active"];
                    txt_UserID.Text = dt.Rows[0]["UserName"].ToString();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows.Add(new object[]{dt.Rows[i]["Col_No"].ToString(),
                                                    dt.Rows[i]["Col_Type"].ToString(),
                                                    dt.Rows[i]["Col_Source"].ToString(),
                                                    dt.Rows[i]["Col_Range"].ToString(),
                                                    dt.Rows[i]["Col_Period"].ToString(),
                                                    dt.Rows[i]["Col_Header"].ToString(),
                                                    dt.Rows[i]["Col_Calc_Formula"].ToString(),
                                                    dt.Rows[i]["Col_Prec_Source"].ToString(),
                                                    dt.Rows[i]["Col_Width"].ToString(),
                                                    dt.Rows[i]["Col_Sup"].ToString(),
                                                    dt.Rows[i]["Col_Calc_Divide"].ToString()});
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
            frm.MyView = new DataView(DataClass.RetrieveData("SELECT GRC.Col_Code, GRC.Col_Name, GRC.Active, GRC.User_ID, dbo.Users.UserName FROM dbo.G_Report_Col AS GRC LEFT OUTER JOIN dbo.Users ON GRC.User_ID = dbo.Users.UserID"));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                FindColumn(frm.selrow.Cells[0].FormattedValue.ToString());
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
                txtCol_Code.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool Check_Columns()
        {
            bool flage = false;
            try
            {
                if (dgv.RowCount <= 1)
                {
                    MessageBox.Show("Enter The Columns", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                for (int i = 0; i < dgv.RowCount; i++)
                {
                    if (dgv[Col_No.Index, i].FormattedValue.ToString().Trim() != "")
                    {
                        if (dgv[Col_Type.Index, i].FormattedValue.ToString().Trim() == "")
                        {
                            MessageBox.Show("Check Source Column  " + dgv[Col_No.Index, i].FormattedValue.ToString().Trim() + " Can't Choose Budget And Debit Or Credit Type", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dgv[Col_Source.Index, i].Selected = true;
                            dgv.Focus();
                            return false;
                        }
                        if (dgv[Col_Source.Index, i].FormattedValue.ToString().Trim() == "BGT" && (dgv[Col_Type.Index, i].FormattedValue.ToString().Trim() == "DB" || dgv[Col_Type.Index, i].FormattedValue.ToString().Trim() == "CR"))
                        {
                            MessageBox.Show("Check Calc Formula Column  " + dgv[Col_No.Index, i].FormattedValue.ToString().Trim(), "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dgv[Col_Calc_Formula.Index, i].Selected = true;
                            dgv.Focus();
                            return false;
                        }
                        if (int.Parse(dgv[Col_Width.Index, i].FormattedValue.ToString().Trim()) <= 0)
                        {
                            MessageBox.Show("Check Width Column  " + dgv[Col_No.Index, i].FormattedValue.ToString().Trim(), "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dgv[Col_Width.Index, i].Selected = true;
                            dgv.Focus();
                            return false;
                        }
                        if (dgv[Col_Prec_Source.Index, i].FormattedValue.ToString().Trim() == "" && dgv[Col_Type.Index, i].FormattedValue.ToString().Trim() == "PCT")
                        {
                            MessageBox.Show("Check % Source Column  " + dgv[Col_No.Index, i].FormattedValue.ToString().Trim(), "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dgv[Col_Prec_Source.Index, i].Selected = true;
                            dgv.Focus();
                            return false;
                        }
                        if (dgv[Col_Calc_Formula.Index, i].FormattedValue.ToString().Trim() == "" && dgv[Col_Type.Index, i].FormattedValue.ToString().Trim() == "CALC")
                        {
                            MessageBox.Show("Check Calc Formula Column  " + dgv[Col_No.Index, i].FormattedValue.ToString().Trim(), "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dgv[Col_Calc_Formula.Index, i].Selected = true;
                            dgv.Focus();
                            return false;
                        }
                        if (!dgv[Col_Calc_Formula.Index, i].FormattedValue.ToString().Contains("0") && dgv[Col_Type.Index, i].FormattedValue.ToString().Trim() == "CALC")
                        {
                            MessageBox.Show("Check Calc Formula Column  " + dgv[Col_No.Index, i].FormattedValue.ToString().Trim() + " You Must Add 0 For Col No ... EXP. SUM(A0:B0)", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dgv[Col_Calc_Formula.Index, i].Selected = true;
                            dgv.Focus();
                            return false;
                        }
                        if (!dgv[Col_Calc_Divide.Index, i].FormattedValue.ToString().Contains("0") && dgv[Col_Calc_Divide.Index, i].FormattedValue.ToString().Trim() != "")
                        {
                            MessageBox.Show("Check Calc Divide Column  " + dgv[Col_No.Index, i].FormattedValue.ToString().Trim() + " You Must Add 0 For Col No ... EXP. A0", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dgv[Col_Calc_Formula.Index, i].Selected = true;
                            dgv.Focus();
                            return false;
                        }
                        if (dgv[Col_Header.Index, i].FormattedValue.ToString().Trim() == "" && dgv[Col_Type.Index, i].FormattedValue.ToString().Trim() != "DESC" && dgv[Col_Type.Index, i].FormattedValue.ToString().Trim() != "PCT")
                        {
                            MessageBox.Show("Check Header Column  " + dgv[Col_No.Index, i].FormattedValue.ToString().Trim(), "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dgv[Col_Header.Index, i].Selected = true;
                            dgv.Focus();
                            return false;
                        }

                        if (dgv[Col_Type.Index, i].FormattedValue.ToString() == "GL" || dgv[Col_Type.Index, i].FormattedValue.ToString() == "DB" || dgv[Col_Type.Index, i].FormattedValue.ToString() == "CR")
                        {
                            if (dgv[Col_Source.Index, i].FormattedValue.ToString().Trim() == "")
                            {
                                MessageBox.Show("Check Source Column  " + dgv[Col_No.Index, i].FormattedValue.ToString().Trim(), "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                dgv[Col_Source.Index, i].Selected = true;
                                dgv.Focus();
                                return false;
                            }
                            if (dgv[Col_Range.Index, i].FormattedValue.ToString().Trim() == "")
                            {
                                MessageBox.Show("Check Range Column  " + dgv[Col_No.Index, i].FormattedValue.ToString().Trim(), "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                dgv[Col_Range.Index, i].Selected = true;
                                dgv.Focus();
                                return false;
                            }
                            if (dgv[Col_Period.Index, i].FormattedValue.ToString().Trim() == "")
                            {
                                MessageBox.Show("Check Period Column  " + dgv[Col_No.Index, i].FormattedValue.ToString().Trim(), "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                dgv[Col_Period.Index, i].Selected = true;
                                dgv.Focus();
                                return false;
                            }
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
                if (string.IsNullOrEmpty(txtCol_Code.Text.Trim()))
                {
                    MessageBox.Show("Enter the Code", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (!string.IsNullOrEmpty(txtCol_Code.Text.Trim()))
                {
                    if (DataClass.CheckIfPrimaryInteredBefore("G_Report_Col", "Col_Code", "Col_Code", txtCol_Code.Text.Trim()))
                    {
                        MessageBox.Show("This Code Entered Before", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
                if (string.IsNullOrEmpty(txtCol_Name.Text.Trim()))
                {
                    MessageBox.Show("Enter the Name", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (!Check_Columns())
                    return;

                ArrayList ItemsNames = new ArrayList();
                ArrayList ItemsValues = new ArrayList();

                ItemsNames.Add("Col_Code");
                ItemsValues.Add(txtCol_Code.Text.Trim());

                ItemsNames.Add("Col_Name");
                ItemsValues.Add(txtCol_Name.Text.Trim());

                ItemsNames.Add("Active");
                ItemsValues.Add(chkactive.Checked);

                ItemsNames.Add("User_ID");
                ItemsValues.Add(AaDeclrationClass.xUserCode);

                string Ins = "insert into G_Report_Col (Col_Code,Col_Name,Active,CreateDate,ModifiedDate,User_ID) values (@Col_Code,@Col_Name,@Active,GetDate(),GetDate(),@User_ID)";
                DataClass.InsertRecord(Ins, ItemsNames, ItemsValues);
                updateCol_Details(txtCol_Code.Text.Trim());

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
        private void updateCol_Details(string Col_Code)
        {
            string str = "";
            str += "Delete G_Report_Col_Det Where Col_Code = '" + Col_Code + "' ; \n ";
            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (dgv[Col_No.Index, i].FormattedValue.ToString().Trim() != "")
                {
                    str += "insert into G_Report_Col_Det (Col_Code,Col_No,Col_Type,Col_Source,Col_Range,Col_Period,Col_Header,Col_Calc_Formula,Col_Prec_Source,Col_Width,Col_Sup,Col_Calc_Divide) values (" +
                           " '" + Col_Code.Trim() + "', '" + dgv[Col_No.Index, i].FormattedValue.ToString().Trim() + "'," +
                           " '" + dgv[Col_Type.Index, i].FormattedValue.ToString().Trim() + "'," +
                           " '" + dgv[Col_Source.Index, i].FormattedValue.ToString().Trim() + "'," +
                           " '" + dgv[Col_Range.Index, i].FormattedValue.ToString().Trim() + "'," +
                           " '" + dgv[Col_Period.Index, i].FormattedValue.ToString().Trim() + "'," +
                           " '" + dgv[Col_Header.Index, i].FormattedValue.ToString().Trim() + "'," +
                           " '" + dgv[Col_Calc_Formula.Index, i].FormattedValue.ToString().Trim() + "'," +
                           " '" + dgv[Col_Prec_Source.Index, i].FormattedValue.ToString().Trim() + "'," +
                           " '" + dgv[Col_Width.Index, i].FormattedValue.ToString().Trim() + "'," +
                           " '" + dgv[Col_Sup.Index, i].FormattedValue.ToString().Trim() + "'," +
                           " '" + dgv[Col_Calc_Divide.Index, i].FormattedValue.ToString().Trim() + "') ; \n ";
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
                if (txtCol_Code.Text.Trim() == "")
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
                txtCol_Code.Enabled = false;
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
                if (string.IsNullOrEmpty(txtCol_Name.Text.Trim()))
                {
                    MessageBox.Show("Enter the Name", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (!Check_Columns())
                    return;

                ArrayList ItemsNames = new ArrayList();
                ArrayList ItemsValues = new ArrayList();

                ItemsNames.Add("Col_Code");
                ItemsValues.Add(txtCol_Code.Text.Trim());

                ItemsNames.Add("Col_Name");
                ItemsValues.Add(txtCol_Name.Text.Trim());

                ItemsNames.Add("Active");
                ItemsValues.Add(chkactive.Checked);

                ItemsNames.Add("User_ID");
                ItemsValues.Add(AaDeclrationClass.xUserCode);

                string Ins = "update G_Report_Col Set Col_Name=@Col_Name, Active=@Active, ModifiedDate=GetDate(), User_ID=@User_ID Where Col_Code=@Col_Code";
                DataClass.InsertRecord(Ins, ItemsNames, ItemsValues);
                updateCol_Details(txtCol_Code.Text.Trim());

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
                if (txtCol_Code.Text.Trim() == "")
                {
                    MessageBox.Show("Please Select The Column", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (DialogResult.No == MessageBox.Show("Are You Sure Delete This ", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    return;

                if (DataClass.isExsist("*", " Col_Code = '" + txtCol_Code.Text.Trim() + "' ", "G_Report"))
                {
                    MessageBox.Show("Can't Delete This Because Is Used In G_Report ", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                DataClass.DeleteRecord(txtCol_Code.Text.Trim(), "Col_Code", "G_Report_Col_Det", "");
                DataClass.DeleteRecord(txtCol_Code.Text.Trim(), "Col_Code", "G_Report_Col", "");
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
                if (e.ColumnIndex == Col_Type.Index)
                {
                    FrmDgv frm = new FrmDgv();
                    frm.MyView = new DataView(DT_Type);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (dgv.Rows[e.RowIndex].IsNewRow == true)
                            dgv.Rows.Add();
                        dgv[Col_Type.Index, e.RowIndex].Value = frm.selrow.Cells[0].FormattedValue.ToString();
                        for (int c = Col_Source.Index; c <= Col_Calc_Divide.Index; c++)
                            dgv[c, e.RowIndex].Value = dgv[c, e.RowIndex].DefaultNewRowValue;
                    }
                }
                else if (e.ColumnIndex == Col_Source.Index && (dgv[Col_Type.Index, e.RowIndex].FormattedValue.ToString() == "GL" || dgv[Col_Type.Index, e.RowIndex].FormattedValue.ToString() == "DB" || dgv[Col_Type.Index, e.RowIndex].FormattedValue.ToString() == "CR"))
                {
                    FrmDgv frm = new FrmDgv();
                    frm.MyView = new DataView(DT_Source);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        dgv[Col_Source.Index, e.RowIndex].Value = frm.selrow.Cells[0].FormattedValue.ToString();
                    }
                }
                else if (e.ColumnIndex == Col_Range.Index && (dgv[Col_Type.Index, e.RowIndex].FormattedValue.ToString() == "GL" || dgv[Col_Type.Index, e.RowIndex].FormattedValue.ToString() == "DB" || dgv[Col_Type.Index, e.RowIndex].FormattedValue.ToString() == "CR"))
                {
                    FrmDgv frm = new FrmDgv();
                    frm.MyView = new DataView(DT_Range);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        dgv[Col_Range.Index, e.RowIndex].Value = frm.selrow.Cells[0].FormattedValue.ToString();
                    }
                }
                else if (e.ColumnIndex == Col_Period.Index && (dgv[Col_Type.Index, e.RowIndex].FormattedValue.ToString() == "GL" || dgv[Col_Type.Index, e.RowIndex].FormattedValue.ToString() == "DB" || dgv[Col_Type.Index, e.RowIndex].FormattedValue.ToString() == "CR"))
                {
                    FrmDgv frm = new FrmDgv();
                    frm.MyView = new DataView(DT_Period);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        dgv[Col_Period.Index, e.RowIndex].Value = frm.selrow.Cells[0].FormattedValue.ToString();
                    }
                }
                if (dgv[Col_Type.Index, e.RowIndex].FormattedValue.ToString() == "CALC" && dgv[Col_Header.Index, e.RowIndex].FormattedValue.ToString().Trim() == "")
                    dgv[Col_Header.Index, e.RowIndex].Value = "Variance";
                else if ((dgv[Col_Type.Index, e.RowIndex].FormattedValue.ToString() == "GL" || dgv[Col_Type.Index, e.RowIndex].FormattedValue.ToString() == "DB" || dgv[Col_Type.Index, e.RowIndex].FormattedValue.ToString() == "CR") && dgv[Col_Header.Index, e.RowIndex].FormattedValue.ToString().Trim() == "")
                {
                    DataRow[] drs = DT_Source.Select("Code = '" + dgv[Col_Source.Index, e.RowIndex].FormattedValue.ToString() + "'");
                    if (drs.Length > 0)
                        dgv[Col_Header.Index, e.RowIndex].Value = drs[0][1].ToString();
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
                if (dgv[Col_Type.Index, e.RowIndex].FormattedValue.ToString() == "")
                    e.Cancel = true;
                if (e.ColumnIndex == Col_Header.Index)
                {
                    if (dgv[Col_Type.Index, e.RowIndex].FormattedValue.ToString() == "DESC" || dgv[Col_Type.Index, e.RowIndex].FormattedValue.ToString() == "PCT")
                        e.Cancel = true;
                }
                else if (e.ColumnIndex == Col_Calc_Formula.Index)
                {
                    if (dgv[Col_Type.Index, e.RowIndex].FormattedValue.ToString() != "CALC")
                        e.Cancel = true;
                }
                else if (e.ColumnIndex == Col_Calc_Divide.Index)
                {
                    if (dgv[Col_Type.Index, e.RowIndex].FormattedValue.ToString() != "CALC")
                        e.Cancel = true;
                }
                else if (e.ColumnIndex == Col_Prec_Source.Index)
                {
                    if (dgv[Col_Type.Index, e.RowIndex].FormattedValue.ToString() != "PCT")
                        e.Cancel = true;
                }
                else if (e.ColumnIndex == Col_Sup.Index)
                {
                    if (dgv[Col_Type.Index, e.RowIndex].FormattedValue.ToString() == "DESC")
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
                    FindColumn(txtFind.Text);
            }
        }

        private void Generate_Report_Columns_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (groupDetails.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    e.Cancel = true;
            }
        }
        private void GetExcelColumnName()
        {
            for (int i = 0; i < dgv.RowCount - 1; i++)
            {
                int dividend = i + 1;
                string columnName = String.Empty;
                int modulo;

                while (dividend > 0)
                {
                    modulo = (dividend - 1) % 26;
                    columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                    dividend = (int)((dividend - modulo) / 26);
                }
                dgv[Col_No.Index, i].Value = columnName;
            }
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            GetExcelColumnName();
        }

        private void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetExcelColumnName();
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
                if (dgv.CurrentCell.ColumnIndex == Col_Width.Index)
                {
                    if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
                else if (dgv.CurrentCell.ColumnIndex == Col_Calc_Formula.Index || dgv.CurrentCell.ColumnIndex == Col_Calc_Formula.Index)
                {
                    string S = "ABCDEFGHIJKLMNOPQRSTUVWXYZ()+-*/:0";
                    if (S.Contains(Convert.ToChar(e.KeyChar).ToString()) || e.KeyChar == 8)
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
                else if (dgv.CurrentCell.ColumnIndex == Col_Prec_Source.Index)
                {
                    string S = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
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