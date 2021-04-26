using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace Accounting_GeneralLedger.Forms
{
    public partial class DepartmentAccounts : Form
    {
        SqlConnection sqlcon;
       public static  List<string> accnum = new List<string>();
        public DepartmentAccounts()
        {
            InitializeComponent();
        }


        private void DepartmentAccounts_Load(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlcon.Open();
            SqlDataAdapter adapt;
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from GLAccounts", sqlcon);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(chk);
            chk.HeaderText = "Selected";
            chk.Name = "chk";
            sqlcon.Close();
            this.dataGridView1.Columns["OpeningBalance"].Visible = false;
            this.dataGridView1.Columns["PropertyCodeID"].Visible = false;
            this.dataGridView1.Columns["AccountNameArabic"].Visible = false;
            this.dataGridView1.Columns["SubLvl"].Visible = false;
        }

        private void Done_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["chk"].Value))
                {
                    accnum.Add((String)row.Cells["AccountNumber"].Value);
                }
            }
            this.Close();
        }
    }
}
