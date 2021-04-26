using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Accounting_GeneralLedger
{
    public partial class SearchProjectCode : Form
    {
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.formspc;
            this.gLProjectCodesDataGridView.Columns[0].HeaderText = obj_interface_language.dgvspc_code.ToString();
            this.gLProjectCodesDataGridView.Columns[1].HeaderText = obj_interface_language.dgvspc_desc.ToString();
            this.btnok.Text  = obj_interface_language.btnpro_code;
            this.btnexit.Text = obj_interface_language.buttonCompanyExit;
        }
        public SearchProjectCode()
        {
            InitializeComponent();
        }

        private void gLProjectCodesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.gLProjectCodesBindingSource.EndEdit();
            this.gLProjectCodesTableAdapter.Update(this.dbAccountingProjectDS.GLProjectCodes);

        }

        private void SearchProjectCode_Load(object sender, EventArgs e)
        {
            try
            {
                if (GeneralFunctions.languagechioce != "")
                {
                    this.obj_options = new ClassOptions();
                    this.obj_options.report_language = GeneralFunctions.languagechioce;
                    this.update_language_interface();
                }  // TODO: This line of code loads data into the 'dbAccountingProjectDS.GLProjectCodes' table. You can move, or remove it, as needed.
                this.gLProjectCodesTableAdapter.Fill(this.dbAccountingProjectDS.GLProjectCodes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            ClassOptions.Idpro = "";
            this.Close();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            try
            {
                if (gLProjectCodesDataGridView.CurrentRow.Cells[0].Value != null)
                    ClassOptions.Idpro = (string)gLProjectCodesDataGridView.CurrentRow.Cells[0].Value;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void gLProjectCodesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gLProjectCodesDataGridView.CurrentRow.Cells[0].Value != null)
                    ClassOptions.Idpro = (string)gLProjectCodesDataGridView.CurrentRow.Cells[0].Value;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "General Ledger");
            }
        }

        private void gLProjectCodesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}