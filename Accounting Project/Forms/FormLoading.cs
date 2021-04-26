using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Accounting_GeneralLedger
{
    public partial class FormLoading : Form
    {
        public FormLoading()
        {
            InitializeComponent();
        }
        public System.Threading.Thread mythr;
        private void FormLoading_Load(object sender, EventArgs e)
        {
            lblpleasewait.Text = "Please_Wait";
            timer1.Enabled = true;
            if (Function.StateThrid == "")
                this.Close();
            else
                lblpleasewait.Text = Function.StateThrid;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Function.StateThrid == "")
                this.Close();
            else
                lblpleasewait.Text = Function.StateThrid;

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (mythr == null)
                return;
            if (DialogResult.Yes == MessageBox.Show("Are You Sure Cancel ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                mythr.Abort();
                this.Close();
            }
        }

        private void FormLoading_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}