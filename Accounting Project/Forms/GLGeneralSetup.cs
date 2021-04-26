using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Accounting_GeneralLedger
{
    public partial class GLGeneralSetup : Form
    {
        private string accountBalanceSheet;
        private string accountIncomeStatment;
        private SqlConnection sqlcon;
        private SqlDataAdapter adapterGeneralSetup;
        private SqlCommandBuilder cmdbuilder;
        private dbAccountingProjectDS dbAccountingProjectDS;

        public GLGeneralSetup()
        {
            InitializeComponent();
        }

        private void btn_SearchBalanceSheet_Click(object sender, EventArgs e)
        {
            SearchForAccount(txt_AccountBalanceSheet);
        }

        private void btn_SearchIncomeStatement_Click(object sender, EventArgs e)
        {
            SearchForAccount(txt_AccountIncomeStat);
        }

        private void SearchForAccount(TextBox txt)
        {
            AccountSearch accSearch = new AccountSearch();
            accSearch.ShowDialog();
            txt.Text = accSearch.selectedAccountNumber;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (GeneralFunctions.AccountNumberValidate(txt_AccountBalanceSheet.Text, out accountBalanceSheet)
               && GeneralFunctions.AccountNumberValidate(txt_AccountIncomeStat.Text, out accountIncomeStatment))
            {
                SaveGLGeneralSetup();
                this.Close();
            }
        }

        private void SaveGLGeneralSetup()
        {
            adapterGeneralSetup = new SqlDataAdapter("Select * from GLGeneralSetup", sqlcon);
            adapterGeneralSetup.Fill(dbAccountingProjectDS.GLGeneralSetup);
            cmdbuilder = new SqlCommandBuilder(adapterGeneralSetup);
            if (dbAccountingProjectDS.GLGeneralSetup.Count == 0)
            {
                DataRow r = dbAccountingProjectDS.GLGeneralSetup.NewRow();
                r["PLGeneralSetupID"] = 0;
                r["PLAccountBalanceSheet"] = accountBalanceSheet;
                r["PLAccountIncomeStatement"] = accountIncomeStatment;
                dbAccountingProjectDS.GLGeneralSetup.Rows.Add(r);
                adapterGeneralSetup.Update(dbAccountingProjectDS.GLGeneralSetup);
            }
            else
            {
                if (DialogResult.OK == MessageBox.Show("The GL settings has already been defined\n Preceed if you want to edit", "Alert", MessageBoxButtons.OKCancel))
                {
                    DataRow[] rArr = dbAccountingProjectDS.GLGeneralSetup.Select("PLGeneralSetupID = 0");
                    rArr[0]["PLAccountBalanceSheet"] = accountBalanceSheet;
                    rArr[0]["PLAccountIncomeStatement"] = accountIncomeStatment;
                    adapterGeneralSetup.Update(dbAccountingProjectDS.GLGeneralSetup);
                }
                else
                {
                    txt_AccountBalanceSheet.Text = "";
                    txt_AccountIncomeStat.Text = "";
                }
            }    
        }

        private void GLGeneralSetup_Load(object sender, EventArgs e)
        {
            dbAccountingProjectDS = new dbAccountingProjectDS();
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);

            if (!GeneralFunctions.SubTypesloaded)
            {
                SqlConnection sqlcon10 = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlcon10.Open();
                SqlCommand command10 = new SqlCommand("Select AccountSubType From  GeneralSetup", sqlcon10);
                SqlCommand command11=new SqlCommand("Select FirstSub From GeneralSetup",sqlcon10 );
                SqlCommand command12=new SqlCommand("Select SecondSub From GeneralSetup",sqlcon10 );
                SqlCommand command13=new SqlCommand("Select ThirdSub From GeneralSetup",sqlcon10 );
                SqlCommand command14=new SqlCommand("Select FourthSub From GeneralSetup",sqlcon10 );
                int AccountSubTypeNumber;
                if (command10.ExecuteScalar() != DBNull.Value) {
                    AccountSubTypeNumber = Convert.ToInt32(command10.ExecuteScalar());
                    if (AccountSubTypeNumber == 2) {
                        GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()),Convert.ToInt32(command12.ExecuteScalar()));
                        GeneralFunctions.SubTypesloaded = true;
                    }
                    if (AccountSubTypeNumber == 3) {
                        GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()), Convert.ToInt32(command12.ExecuteScalar()),Convert.ToInt32(command13.ExecuteScalar()));
                        GeneralFunctions.SubTypesloaded = true;
                    }
                    if (AccountSubTypeNumber ==4) {
                        GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()), Convert.ToInt32(command12.ExecuteScalar()), Convert.ToInt32(command13.ExecuteScalar()),Convert.ToInt32(command14.ExecuteScalar()));
                        GeneralFunctions.SubTypesloaded = true;
                    }
                    
                }
                
            }
        }
    }
}