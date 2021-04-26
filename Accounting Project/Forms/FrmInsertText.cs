using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Accounting_GeneralLedger
{
    public partial class FrmInsertText : Form
    {
        public FrmInsertText(string TxtType, bool Allow_Null, bool Pass)
        {
            InitializeComponent();
            _TxtType = TxtType;
            _Allow_Null = Allow_Null;
            if (Pass)
                txt.PasswordChar = '*';
        }
        private string _TxtType = "";
        private bool _Allow_Null = true;
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
            myValue = txt.Text.Trim();
            if (!_Allow_Null && (myValue == "" || (myValue == "0" && _TxtType != "")))
            {
                MessageBox.Show("Please Insert Value", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void FrmInsertText_Load(object sender, EventArgs e)
        {
            txt.Text = myValue;
            txt.Focus();
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (_TxtType)
            {
                case "int":
                    if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
                        e.Handled = false;
                    else
                        e.Handled = true;
                    break;
                case "double":
                    if (e.KeyChar == 8)
                        e.Handled = false;
                    else if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    {
                        if (txt.Text.Contains("."))
                        {
                            char c = '.';
                            string[] sc = txt.Text.Split(c);

                            if (sc[1].Length < 2 || txt.SelectedText == txt.Text.Substring(txt.Text.Length - 1, 1) || txt.SelectedText == txt.Text.Substring(txt.Text.Length - 2, 2) || txt.SelectedText == txt.Text)
                                e.Handled = false;
                            else
                                e.Handled = true;
                        }
                        else
                            e.Handled = false;
                    }
                    else if (e.KeyChar == 46)
                    {
                        if (txt.Text.Contains(".") == false)
                            e.Handled = false;
                        else
                            e.Handled = true;
                    }
                    else
                        e.Handled = true;
                    break;

            }
        }

    }
}