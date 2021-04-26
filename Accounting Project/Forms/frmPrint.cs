using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Accounting_GeneralLedger
{
    public partial class frmPrint : Form
    {
        public frmPrint()
        {
            InitializeComponent();
        }

        public int Result = 0;

        private void frmPrint_Load(object sender, System.EventArgs e)
        {
        }

        private void btnClick(object sender, System.EventArgs e)
        {
            if (rb1.Checked)
            {
                Result = 1;
            }
            else if (rb2.Checked)
            {
                Result = 2;
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Result = 0;
            this.Close();
        }


    }
}