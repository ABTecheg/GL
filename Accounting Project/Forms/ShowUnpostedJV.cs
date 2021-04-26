using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Accounting_GeneralLedger {
    public partial class ShowUnpostedJV : Form {
        public ShowUnpostedJV() {
            InitializeComponent();
        }
        public static string[] selectJVNumber;
        public DataTable selectedBatch;
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbBatch;

        private void ShowUnpostedJV_Load(object sender, EventArgs e) {
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            //SqlConnection sqlConnection2 = new SqlConnection(GeneralFunctions.ConnectionString);
            //sqlConnection2.Open();
            //SqlCommand sqlCommand2 = new SqlCommand("Select PeriodNumber From GLFiscalPeriod WHERE PeriodDescription='" + EndMonth.SpecificPeriod + "'", sqlConnection2);
            //SqlDataReader sqlReader2 = sqlCommand2.ExecuteReader();
            //int x = 0;
            //if (sqlReader2.HasRows) {
            //    while (sqlReader2.Read()) {
            //        x = sqlReader2.GetInt32(0);
            //    }
            //}
            //switch (x) {
            //    case 1:
            //        break;
            //    case 2:
            //        adaptertbBatch = new SqlDataAdapter("Select * From Batch WHERE BatchStat Like 'U%' AND BatchPRD IN ('" + EndMonth.SpecificPeriod + "','Period 1') AND YEAR(BatchDate)=" + EndMonth.SpecificYear + "", sqlcon);
            //        break;
            //    case 3:
            //        adaptertbBatch = new SqlDataAdapter("Select * From Batch WHERE BatchStat Like 'U%' AND BatchPRD IN ('" + EndMonth.SpecificPeriod + "','Period 1','Period 2') AND YEAR(BatchDate)=" + EndMonth.SpecificYear + "", sqlcon);
            //        break;
            //    case 4:
            //        adaptertbBatch = new SqlDataAdapter("Select * From Batch WHERE BatchStat Like 'U%' AND BatchPRD IN ('" + EndMonth.SpecificPeriod + "','Period 1','Period 2','Period 3') AND YEAR(BatchDate)=" + EndMonth.SpecificYear + "", sqlcon);
            //        break;
            //    case 5:
            //        adaptertbBatch = new SqlDataAdapter("Select * From Batch WHERE BatchStat Like 'U%' AND BatchPRD IN ('" + EndMonth.SpecificPeriod + "','Period 1','Period 2','Period 3','Period 4') AND YEAR(BatchDate)=" + EndMonth.SpecificYear + "", sqlcon);
            //        break;
            //    case 6:
            //        adaptertbBatch = new SqlDataAdapter("Select * From Batch WHERE BatchStat Like 'U%' AND BatchPRD IN ('" + EndMonth.SpecificPeriod + "','Period 1','Period 2','Period 3','Period 4','Period 5') AND YEAR(BatchDate)=" + EndMonth.SpecificYear + "", sqlcon);
            //        break;
            //    case 7:
            //        adaptertbBatch = new SqlDataAdapter("Select * From Batch WHERE BatchStat Like 'U%' AND BatchPRD IN ('" + EndMonth.SpecificPeriod + "','Period 1','Period 2','Period 3','Period 4','Period 5','Period 6') AND YEAR(BatchDate)=" + EndMonth.SpecificYear + "", sqlcon);
            //        break;
            //    case 8:
            //        adaptertbBatch = new SqlDataAdapter("Select * From Batch WHERE BatchStat Like 'U%' AND BatchPRD IN ('" + EndMonth.SpecificPeriod + "','Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7') AND YEAR(BatchDate)=" + EndMonth.SpecificYear + "", sqlcon);
            //        break;
            //    case 9:
            //        adaptertbBatch = new SqlDataAdapter("Select * From Batch WHERE BatchStat Like 'U%' AND BatchPRD IN ('" + EndMonth.SpecificPeriod + "','Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8') AND YEAR(BatchDate)=" + EndMonth.SpecificYear + "", sqlcon);
            //        break;
            //    case 10:
            //        adaptertbBatch = new SqlDataAdapter("Select * From Batch WHERE BatchStat Like 'U%' AND BatchPRD IN ('" + EndMonth.SpecificPeriod + "','Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9') AND YEAR(BatchDate)=" + EndMonth.SpecificYear + "", sqlcon);
            //        break;
            //    case 11:
            //        adaptertbBatch = new SqlDataAdapter("Select * From Batch WHERE BatchStat Like 'U%' AND BatchPRD IN ('" + EndMonth.SpecificPeriod + "','Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10') AND YEAR(BatchDate)=" + EndMonth.SpecificYear + "", sqlcon);
            //        break;
            //    case 12:
            //        adaptertbBatch = new SqlDataAdapter("Select * From Batch WHERE BatchStat Like 'U%' AND BatchPRD IN ('" + EndMonth.SpecificPeriod + "','Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11') AND YEAR(BatchDate)=" + EndMonth.SpecificYear + "", sqlcon);
            //        break;
            //    case 13:
            //        adaptertbBatch = new SqlDataAdapter("Select * From Batch WHERE BatchStat Like 'U%' AND BatchPRD IN ('" + EndMonth.SpecificPeriod + "','Period 1','Period 2','Period 3','Period 4','Period 5','Period 6','Period 7','Period 8','Period 9','Period 10','Period 11','Period 12') AND YEAR(BatchDate)=" + EndMonth.SpecificYear + "", sqlcon);
            //        break;
            //    default:
            //        MessageBox.Show("Invalid period");
            //        break;
            //}
            adaptertbBatch = new SqlDataAdapter("Select * From Batch WHERE BatchStat Like 'U%' AND BatchPRD='" + EndMonth.SpecificPeriod + "' AND YEAR(BatchDate)=" + EndMonth.SpecificYear + "", sqlcon);
            adaptertbBatch.Fill(dbAccountingProjectDS.Batch);
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e) {


        }

        private void btnClose_Click(object sender, EventArgs e) {
            //if (dgv.SelectedRows.Count > 0) {
            //    DataGridViewRow r;
            //    selectJVNumber = new string[dgv.SelectedRows.Count];
            //    for (int i = 0; i < dgv.SelectedRows.Count; i++) {
            //        r = (DataGridViewRow) dgv.SelectedRows[i];
            //        selectJVNumber[i] = r.Cells["jVNumberDataGridViewTextBoxColumn"].Value.ToString();
            //    }
            //    this.Close();
            //}
            //else
                this.Close();
        }
    }
}