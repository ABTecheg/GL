using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Accounting_GeneralLedger;

namespace Accounting_GeneralLedger
{
    public partial class FrmDgv : Form
    {
        public FrmDgv()
        {
            InitializeComponent();
        }
        public DataView MyView;
        public DataGridViewRow selrow;

        private void FrmDgv_Load(object sender, EventArgs e)
        {
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = MyView;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selrow = dataGridView1.SelectedRows[0];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}