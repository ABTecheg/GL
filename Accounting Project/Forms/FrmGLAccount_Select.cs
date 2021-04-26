using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Accounting_GeneralLedger
{
    public partial class FrmGLAccount_Select : Form
    {
        public FrmGLAccount_Select()
        {
            InitializeComponent();
        }
        private string myValue = "";
        public string MyValue
        {
            get { return myValue; }
            set { myValue = value; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!txt_FAccountNumber.MaskFull)
            {
                MessageBox.Show("Please Completed Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txt_TAccountNumber.MaskFull)
            {
                if (!DataClass.isExsist("*", "AccountNumber = '" + txt_FAccountNumber.Text.Trim() + "' AND AccountTypeName <> 'Header' ", "GLAccounts"))
                {
                    MessageBox.Show("From Account Number Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                myValue = txt_FAccountNumber.Text.Trim();
            }
            else
            {
                if (!DataClass.isExsist("*", "AccountNumber = '" + txt_FAccountNumber.Text.Trim() + "' AND AccountTypeName <> 'Header' ", "GLAccounts"))
                {
                    MessageBox.Show("From Account Number Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txt_FAccountNumber.Text.Trim() == txt_TAccountNumber.Text.Trim())
                    myValue = txt_FAccountNumber.Text.Trim();
                else
                {
                    if (!DataClass.isExsist("*", "AccountNumber = '" + txt_TAccountNumber.Text.Trim() + "' AND AccountTypeName <> 'Header' ", "GLAccounts"))
                    {
                        MessageBox.Show("To Account Number Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    myValue = "(" + txt_FAccountNumber.Text.Trim() + " TO " + txt_TAccountNumber.Text.Trim() + ")";
                }
            }
            if (myValue.Trim() == "")
            {
                MessageBox.Show("Please Insert Value", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void FrmGLAccount_Select_Load(object sender, EventArgs e)
        {
            try
            {
                string str = DataClass.ReturnRecordNameByID("Select AccountNumberFormat From GeneralSetup");
                if (str.Trim() != "")
                {
                    txt_FAccountNumber.Mask = str.Trim();
                    txt_TAccountNumber.Mask = str.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_FAccountNumber_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                AccountSearch accSearch = new AccountSearch();
                accSearch.filter = " AND AccountTypeName <> 'Header'";
                accSearch.ShowDialog();
                if (accSearch.selectedAccountName != null && accSearch.selectedAccountNumber != null && accSearch.selectedAccountType != null && accSearch.selectedAccountType != "Header")
                {
                    txt_FAccountNumber.Text = accSearch.selectedAccountNumber;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_TAccountNumber_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                AccountSearch accSearch = new AccountSearch();
                accSearch.filter = " AND AccountTypeName <> 'Header'";
                accSearch.ShowDialog();
                if (accSearch.selectedAccountName != null && accSearch.selectedAccountNumber != null && accSearch.selectedAccountType != null && accSearch.selectedAccountType != "Header")
                {
                    txt_TAccountNumber.Text = accSearch.selectedAccountNumber;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}