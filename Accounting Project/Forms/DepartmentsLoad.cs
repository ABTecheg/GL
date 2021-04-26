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
    public partial class DepartmentsLoad : Form
    {
        public string ReturnValue1 { get; set; }
        public DepartmentsLoad()
        {
            InitializeComponent();
        }

        private void DepartmentsLoad_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Code FROM DepartmentCode", GeneralFunctions.ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "DepartmentCode");
            dataGridView1.DataSource = ds.Tables["DepartmentCode"].DefaultView;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Choose_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["Code"].Value);
                this.ReturnValue1 = cellValue;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Choose a Cell First");
            }
        }
    }
}
