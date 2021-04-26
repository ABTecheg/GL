using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Accounting_GeneralLedger
{
    public partial class CurrencyConversionTable : Form
    {
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbCurrency;
        private SqlDataAdapter adaptertbCurrencyConversion;
        private SqlCommandBuilder cmdBuilder;
        private int currencyconversionNumber;
        private double ExchangeRate;
        private SqlDataAdapter adaptertbGeneralSetup;
        private int decmal = 1;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        public CurrencyConversionTable()
        {
            InitializeComponent();
        }

        private void CurrencyConversionTable_Load(object sender, EventArgs e)
        {
            GeneralFunctions.priviledgeGroupBox(Lock41);
            GeneralFunctions.priviledgeGroupBox(Lock42);
            GeneralFunctions.priviledgeGroupBox(Lock43);
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbCurrencyConversion = new SqlDataAdapter("Select * from GLCurrencyConversion", sqlcon);
            adaptertbCurrency = new SqlDataAdapter("Select * from GLCurrency", sqlcon);
            cmdBuilder = new SqlCommandBuilder(adaptertbCurrencyConversion);
            adaptertbGeneralSetup = new SqlDataAdapter("Select * from GeneralSetup", sqlcon);

            adaptertbGeneralSetup.Fill(dbAccountingProjectDS.GeneralSetup);
            dgv.ClearSelection();
            foreach (DataRow dr in dbAccountingProjectDS.GeneralSetup.Rows)
            {
                decmal = int.Parse(dr["DecimalPointsNumber"].ToString());
            }
            adaptertbCurrencyConversion.Fill(dbAccountingProjectDS.GLCurrencyConversion);
            adaptertbCurrency.Fill(dbAccountingProjectDS.GLCurrency);
            dgv.ClearSelection();
            FillComboBox(cb_currencycode1);
            SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon3.Open();
            SqlCommand GetCurrencyConversionId = new SqlCommand("Select MAX(CurrencyConversionId)+1 From GLCurrencyConversion", sqlcon3);
            if (GetCurrencyConversionId.ExecuteScalar() != DBNull.Value)
            {
                GeneralFunctions.CurrencyconversionID = Convert.ToInt32(GetCurrencyConversionId.ExecuteScalar());
            }
            else
                GeneralFunctions.CurrencyconversionID = 1;

            currencyconversionNumber = GeneralFunctions.CurrencyconversionID;
            txt_CurrencyCodeID.Text = currencyconversionNumber.ToString();

            if (GeneralFunctions.languagechioce != "")
            {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }

            btndelete.Enabled = false;
            btnedit.Enabled = false;
        }

        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.formCurrencyConversionTable;
            this.dgv.Columns[0].HeaderText = obj_interface_language.dgvCurrencyConvCodeColumn1.ToString();
            this.dgv.Columns[1].HeaderText = obj_interface_language.dgvCurrencyConvCodeColumn2.ToString();
            this.dgv.Columns[2].HeaderText = obj_interface_language.dgvCurrencyConvCodeColumn3.ToString();
            this.dgv.Columns[3].HeaderText = obj_interface_language.dgvCurrencyConvCodeColumn4.ToString();

            this.label2.Text = obj_interface_language.labelCurrencyConvCodeID;
            this.label1.Text = obj_interface_language.labelCurrencyConvCode;
            this.label3.Text = obj_interface_language.labelExchangeRate;
            this.label5.Text = obj_interface_language.labelExchangeDate;
            this.btn_New.Text = obj_interface_language.buttonbtnNew;
            this.btnedit.Text = obj_interface_language.buttonbtnEdit;
            this.btndelete.Text = obj_interface_language.buttonbtnDelete;
            this.btnundo.Text = obj_interface_language.buttonbtnUndo;
            this.btnexit.Text = obj_interface_language.buttonCompanyExit;
            this.btnSavenew.Text = obj_interface_language.buttonJVTransactionSaveNew;
            this.Btnsaveedit.Text = obj_interface_language.buttonJVTransactionSaveEdit;
        }

        private void FillComboBox(ComboBox cb)
        {
            if (dbAccountingProjectDS.GLCurrency.Rows.Count != 0)
            {
                foreach (DataRow dr in dbAccountingProjectDS.GLCurrency.Rows)
                {
                    if (dr["Active"].ToString() == "True")
                    {
                        cb.Items.Add(dr["CurrencyCode"].ToString());
                    }
                }
            }
            if (GeneralFunctions.Ckecktag("15") == "M")
                cb.Items.Add("<new>");
            cb = GeneralFunctions.RemoveBaseCurrency(cb);
        }

        //private void btn_SaveChanges_Click(object sender, EventArgs e) {
        //    adaptertbCurrencyConversion.Update(dbAccountingProjectDS.GLCurrencyConversion);
        //    dbAccountingProjectDS.AcceptChanges();
        //}

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataRow r = dbAccountingProjectDS.GLCurrencyConversion.Rows[dgv.SelectedRows[0].Index];
                txt_CurrencyCodeID.Text = r["CurrencyConversionId"].ToString();
                cb_currencycode1.Text = r["CurrencyCode"].ToString();
                txt_ExchangeRate.Text = r["ExchangeRate"].ToString();
                dateTimePicker1.Text = r["EffectiveDate"].ToString();
            }
            GB1.Enabled = false;
            btnedit.Enabled = true;
            btndelete.Enabled = true;

        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GeneralFunctions.ValidateDouble(txt_ExchangeRate.Text, "Please Specify the Buying Rate", out ExchangeRate)
                && GeneralFunctions.ValidateComboBox(cb_currencycode1, "Please Specify the Currency Code"))
            {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select CurrencyConversionId from GLCurrencyConversion where CurrencyConversionId = '" + txt_CurrencyCodeID.Text + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("CurrencyConversionId = '" + txt_CurrencyCodeID.Text + "'", dbAccountingProjectDS.GLCurrencyConversion))
                {
                    DataRow r = dbAccountingProjectDS.GLCurrencyConversion.NewRow();
                    r["CurrencyConversionId"] = currencyconversionNumber;
                    GeneralFunctions.CurrencyconversionID++;
                    currencyconversionNumber = GeneralFunctions.CurrencyconversionID;
                    r["CurrencyCode"] = cb_currencycode1.Text;
                    r["ExchangeRate"] = ExchangeRate;
                    r["EffectiveDate"] = dateTimePicker1.Text;
                    dbAccountingProjectDS.GLCurrencyConversion.Rows.Add(r);
                    ClearAll();
                    dr.Close();
                    sqlcon.Close();
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Currency Conversion is already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.GLCurrencyConversion.Select("CurrencyConversionId = '" + txt_CurrencyCodeID.Text + "'");
                        rArr[0]["CurrencyCode"] = cb_currencycode1.Text;
                        rArr[0]["ExchangeRate"] = ExchangeRate;
                        rArr[0]["EffectiveDate"] = dateTimePicker1.Text;
                        ClearAll();
                    }
                    else
                        ClearAll();
                    dr.Close();
                    sqlcon.Close();
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (GeneralFunctions.ValidateDouble(txt_ExchangeRate.Text, "Please Specify the Buying Rate", out ExchangeRate)
                     && GeneralFunctions.ValidateComboBox(cb_currencycode1, "Please Specify the Currency Code"))
                {
                    DataRow r = dbAccountingProjectDS.GLCurrencyConversion.Rows[dgv.SelectedRows[0].Index];
                    r["CurrencyCode"] = cb_currencycode1.Text;
                    r["ExchangeRate"] = ExchangeRate;
                    r["EffectiveDate"] = dateTimePicker1.Text;
                    ClearAll();
                }
            }
            dgv.ClearSelection();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                dbAccountingProjectDS.GLCurrencyConversion.Rows[dgv.SelectedRows[0].Index].Delete();
                ClearAll();
            }
            else
            {
                MessageBox.Show("Please Select the row that you want to delete");
            }
            dgv.ClearSelection();
        }



        private void ClearAll()
        {
            txt_CurrencyCodeID.Text = currencyconversionNumber.ToString();
            ;
            cb_currencycode1.SelectedIndex = -1;
            txt_ExchangeRate.Text = "";
        }


        private void cb_currencycode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_currencycode1.Text == "<new>")
            {
                Currency curren = new Currency();
                curren.ShowDialog();
                cb_currencycode1.Items.Clear();
                adaptertbCurrency.Fill(dbAccountingProjectDS.GLCurrency);
                FillComboBox(cb_currencycode1);
            }
        }


        private void txt_ExchangeRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                if (txt_ExchangeRate.Text.Contains("."))
                {
                    char c = '.';
                    string[] sc = txt_ExchangeRate.Text.Split(c);

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
                if (txt_ExchangeRate.Text.Contains(".") == false)
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CurrencyConversionTable_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GB1.Enabled == true)
            {
                DialogResult myrst;
                myrst = MessageBox.Show("Are You Sure Exit Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (myrst == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void btnundo_Click(object sender, EventArgs e)
        {
            if (sender.ToString() != "NO")
            {
                if (GB1.Enabled == true)
                {
                    DialogResult myrst;
                    myrst = MessageBox.Show("Are You Sure Undo Without Save", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (myrst == DialogResult.No)
                        return;
                }
            }
            SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon3.Open();
            SqlCommand GetCurrencyConversionId = new SqlCommand("Select MAX(CurrencyConversionId)+1 From GLCurrencyConversion", sqlcon3);
            if (GetCurrencyConversionId.ExecuteScalar() != DBNull.Value)
            {
                GeneralFunctions.CurrencyID = Convert.ToInt32(GetCurrencyConversionId.ExecuteScalar());
            }
            else
                GeneralFunctions.CurrencyID = 1;

            currencyconversionNumber = GeneralFunctions.CurrencyID;
            txt_CurrencyCodeID.Text = currencyconversionNumber.ToString();
            ClearAll();
            btn_New.Visible = true;
            btnSavenew.Visible = false;
            btnedit.Visible = true;
            Btnsaveedit.Visible = false;
            GB1.Enabled = false;
            btn_New.Enabled = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult myrst;
            myrst = MessageBox.Show("Are You Sure Delete This Currency Conversion", "General Ledger", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myrst == DialogResult.No)
                return;
            if (dgv.SelectedRows.Count > 0)
                {
                    dbAccountingProjectDS.GLCurrencyConversion.Rows[dgv.SelectedRows[0].Index].Delete();
                    ClearAll();
                    dgv.ClearSelection();
                    btnedit.Enabled = false;
                    btndelete.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please Select the row that you want to delete");
                }


                adaptertbCurrencyConversion.Update(dbAccountingProjectDS.GLCurrencyConversion);
                dbAccountingProjectDS.AcceptChanges();
                SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlcon3.Open();
                SqlCommand GetCurrencyConversionId = new SqlCommand("Select MAX(CurrencyConversionId)+1 From GLCurrencyConversion", sqlcon3);
                if (GetCurrencyConversionId.ExecuteScalar() != DBNull.Value)
                {
                    GeneralFunctions.CurrencyconversionID = Convert.ToInt32(GetCurrencyConversionId.ExecuteScalar());
                }
                else
                    GeneralFunctions.CurrencyconversionID = 1;

                currencyconversionNumber = GeneralFunctions.CurrencyconversionID;
                txt_CurrencyCodeID.Text = currencyconversionNumber.ToString();
        }

        private void Btnsaveedit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (GeneralFunctions.ValidateDouble(txt_ExchangeRate.Text, "Please Specify the Buying Rate", out ExchangeRate)
                     && GeneralFunctions.ValidateComboBox(cb_currencycode1, "Please Specify the Currency Code"))
                {
                    DataRow r = dbAccountingProjectDS.GLCurrencyConversion.Rows[dgv.SelectedRows[0].Index];
                    r["CurrencyCode"] = cb_currencycode1.Text;
                    r["ExchangeRate"] = ExchangeRate;
                    r["EffectiveDate"] = dateTimePicker1.Text;
                    ClearAll();
                    dgv.ClearSelection();
                    GB1.Enabled = false;
                    btnedit.Visible = true;
                    Btnsaveedit.Visible = false;
                    btn_New.Enabled = true;
                    btndelete.Enabled = false;
                    btnedit.Enabled = false;
                }
            }
            dgv.ClearSelection();
            dgv.ClearSelection();
            GB1.Enabled = false;
            btnedit.Visible = true;
            Btnsaveedit.Visible = false;
            btn_New.Enabled = true;
            btndelete.Enabled = false;
            btnedit.Enabled = false;
            adaptertbCurrencyConversion.Update(dbAccountingProjectDS.GLCurrencyConversion);
            dbAccountingProjectDS.AcceptChanges();
            SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon3.Open();
            SqlCommand GetCurrencyConversionId = new SqlCommand("Select MAX(CurrencyConversionId)+1 From GLCurrencyConversion", sqlcon3);
            if (GetCurrencyConversionId.ExecuteScalar() != DBNull.Value)
            {
                GeneralFunctions.CurrencyconversionID = Convert.ToInt32(GetCurrencyConversionId.ExecuteScalar());
            }
            else
                GeneralFunctions.CurrencyconversionID = 1;

            currencyconversionNumber = GeneralFunctions.CurrencyconversionID;
            txt_CurrencyCodeID.Text = currencyconversionNumber.ToString();
        }

        private void GB1_EnabledChanged(object sender, EventArgs e)
        {
            if (GB1.Enabled == true)
                dgv.Enabled = false;
            else
                dgv.Enabled = true;
        }

        private void btnSavenew_Click(object sender, EventArgs e)
        {

            if (GeneralFunctions.ValidateDouble(txt_ExchangeRate.Text, "Please Specify the Buying Rate", out ExchangeRate)
           && GeneralFunctions.ValidateComboBox(cb_currencycode1, "Please Specify the Currency Code"))
            {
                sqlcon.Open();
                SqlCommand cmdSelect = new SqlCommand("Select CurrencyConversionId from GLCurrencyConversion where CurrencyConversionId = '" + txt_CurrencyCodeID.Text + "'", sqlcon);
                SqlDataReader dr = cmdSelect.ExecuteReader();
                if (!dr.HasRows && !GeneralFunctions.FindRow("CurrencyConversionId = '" + txt_CurrencyCodeID.Text + "'", dbAccountingProjectDS.GLCurrencyConversion))
                {
                    DataRow r = dbAccountingProjectDS.GLCurrencyConversion.NewRow();
                    r["CurrencyConversionId"] = currencyconversionNumber;
                    GeneralFunctions.CurrencyconversionID++;
                    currencyconversionNumber = GeneralFunctions.CurrencyconversionID;
                    r["CurrencyCode"] = cb_currencycode1.Text;
                    r["ExchangeRate"] = ExchangeRate;
                    r["EffectiveDate"] = dateTimePicker1.Text;
                    dbAccountingProjectDS.GLCurrencyConversion.Rows.Add(r);
                    ClearAll();
                    GB1.Enabled = false;
                    btn_New.Visible = true;
                    btnSavenew.Visible = false;
                    dr.Close();
                    sqlcon.Close();
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("The given Currency Conversion is already exists \n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                    {
                        DataRow[] rArr = dbAccountingProjectDS.GLCurrencyConversion.Select("CurrencyConversionId = '" + txt_CurrencyCodeID.Text + "'");
                        rArr[0]["CurrencyCode"] = cb_currencycode1.Text;
                        rArr[0]["ExchangeRate"] = ExchangeRate;
                        rArr[0]["EffectiveDate"] = dateTimePicker1.Text;
                        ClearAll();
                        GB1.Enabled = false;
                        btn_New.Visible = true;
                        btnSavenew.Visible = false;
                    }
                    else
                        ClearAll();
                    GB1.Enabled = false;
                    btn_New.Visible = true;
                    btnSavenew.Visible = false;
                    dr.Close();
                    sqlcon.Close();
                }
            }
            adaptertbCurrencyConversion.Update(dbAccountingProjectDS.GLCurrencyConversion);
            dbAccountingProjectDS.AcceptChanges();
            SqlConnection sqlcon4 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon4.Open();
            SqlCommand GetCurrencyConversionId4 = new SqlCommand("Select MAX(CurrencyConversionId)+1 From GLCurrencyConversion", sqlcon4);
            if (GetCurrencyConversionId4.ExecuteScalar() != DBNull.Value)
            {
                GeneralFunctions.CurrencyconversionID = Convert.ToInt32(GetCurrencyConversionId4.ExecuteScalar());
            }
            else
                GeneralFunctions.CurrencyconversionID = 1;

            currencyconversionNumber = GeneralFunctions.CurrencyconversionID;
            txt_CurrencyCodeID.Text = currencyconversionNumber.ToString();
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon3 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon3.Open();
            SqlCommand GetCurrencyConversionId = new SqlCommand("Select MAX(CurrencyConversionId)+1 From GLCurrencyConversion", sqlcon3);
            if (GetCurrencyConversionId.ExecuteScalar() != DBNull.Value)
            {
                GeneralFunctions.CurrencyconversionID = Convert.ToInt32(GetCurrencyConversionId.ExecuteScalar());
            }
            else
                GeneralFunctions.CurrencyconversionID = 1;

            currencyconversionNumber = GeneralFunctions.CurrencyconversionID;
            txt_CurrencyCodeID.Text = currencyconversionNumber.ToString();
            ClearAll();
            GB1.Enabled = true;
            btn_New.Visible = false;
            btnSavenew.Visible = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            GB1.Enabled = true;
            btnedit.Visible = false;
            Btnsaveedit.Visible = true;
            btn_New.Enabled = false;
            btndelete.Enabled = false;
        }

    }
}