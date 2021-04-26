using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Accounting_GeneralLedger.Forms
{
    public partial class CreatBudget : Form
    {
        public CreatBudget()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckBudget f = new CheckBudget(); f.Show(); this.Close();

        }
    }
}
