using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Accounting_GeneralLedger
{
    public partial class AvailableTables : Form
    {
        public AvailableTables()
        {
            InitializeComponent();
        }
        SqlConnection mycon;
        SqlCommand mycom;
        SqlDataReader mydr;
        private void AvailableTables_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void btnunlockall_Click(object sender, EventArgs e)
        {
            try
            {
                GeneralFunctions.UnLockAllTable();
                MessageBox.Show("Successed", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void Loaddata()
        {
            try
            {
                dgv.Rows.Clear();
                mycon = new SqlConnection(GeneralFunctions.ConnectionString);
                mycon.Open();
                mycom = new SqlCommand("Select * From AvailableTable", mycon);
                mydr = mycom.ExecuteReader();
                while (mydr.Read())
                {
                    dgv.Rows.Add(new object[]{false,
                                          mydr["ID"],
                                          mydr["ComputerIP"],
                                          mydr["ComputerName"],
                                          mydr["FormLock"],
                                          mydr["TableLock"],
                                          mydr["State"],
                                          mydr["IDRow"],
                                          mydr["DateLock"]});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                mycon.Close();
            }
        }

        private void btnunlockselect_Click(object sender, EventArgs e)
        {
            try
            {
                string s2 = "('";
                string s = "";
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells[0].Value.ToString() == "True")
                    {
                        s2 = s2 + s + dgv.Rows[i].Cells["ID"].Value.ToString() + "'";
                        s = ",'";
                    }
                }
                s2 = s2 + ")";
                if (s2 == "(')")
                {
                    MessageBox.Show("Please Select One Row At Least", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                GeneralFunctions.UnLockTablesSelect(s2);
                MessageBox.Show("Successed", "General Ledger", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    }
}