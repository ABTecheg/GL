using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Accounting_GeneralLedger.Forms
{
    public partial class ChooseName : Form
    {
        public ChooseName()
        {
            InitializeComponent();
        }

        private void ChooseName_Load(object sender, EventArgs e)
        {
            var select = "select * from GLAccounts where AccountTypeID=6";
            var c = new SqlConnection(GeneralFunctions.ConnectionString); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dgv.ReadOnly = true;
            dgv.DataSource = ds.Tables[0];
        }


        private void btn_Add_Click(object sender, EventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_SelectCurrentRecord_Click(object sender, EventArgs e)
        {

        }
    }
}
