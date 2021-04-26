using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Accounting_GeneralLedger
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void newAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountsDefinition accounts = new AccountsDefinition();
            accounts.Owner = this;
            accounts.ShowDialog();
        }

        private void newJournalEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JVTransactions jvTransactions = new JVTransactions();
            jvTransactions.Owner = this;
            jvTransactions.ShowDialog();
        }

        private void createAllocationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllocationMaintenance allocationMaintanence = new AllocationMaintenance();
            allocationMaintanence.Owner = this;
            allocationMaintanence.ShowDialog();
        }

        private void toolStripChartOfAccounts_Click(object sender, EventArgs e)
        {
            ChartsOfAccounts accountsChart = new ChartsOfAccounts();
            accountsChart.Owner = this;
            accountsChart.ShowDialog();
        }
    }
}