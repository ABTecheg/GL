using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace Accounting_GeneralLedger
{
    public partial class ChartsOfAccounts : Form
    {
        private string currentAccountNumber = "";
        private SqlConnection sqlcon;
        private SqlDataAdapter adaptertbAccounts;
        private SqlDataAdapter adaptertbAccountsChart;
        private SqlDataAdapter adaptertbAccountTypes;
        private SqlCommandBuilder cmdBuilder;
        private TreeNode parentNode;
        ArrayList folderParents;
        private ClassInterfaceLanguage obj_interface_language = null;
        private ClassOptions obj_options;
        private const string LANGUAGE_INTERFACE_DIRECTORY = "\\languages\\interface\\";
        private string exe_path = Application.StartupPath;
        private int LENAccount = 0;
        public ChartsOfAccounts()
        {
            InitializeComponent();
        }

        private void ChartsOfAccounts_Load(object sender, EventArgs e)
        {
            SqlConnection newSqlConnection = new SqlConnection(GeneralFunctions.ConnectionString);
            newSqlConnection.Open();
            SqlCommand newSqlCommand = new SqlCommand("Select CompanyName From Company", newSqlConnection);
            SqlDataReader newSqlRead = newSqlCommand.ExecuteReader();
            if (newSqlRead.HasRows)
            {
                while (newSqlRead.Read())
                {
                    GeneralFunctions.CompanyName = newSqlRead.GetString(0);
                }
            }
            SqlConnection sqlconnect = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconnect.Open();
            SqlCommand sqlcommand = new SqlCommand("Select AccountNumberFormat FROM GeneralSetup", sqlconnect);
            SqlDataReader sqlread = sqlcommand.ExecuteReader();

            LENAccount = 0;
            if (sqlread.HasRows)
            {
                while (sqlread.Read())
                {
                    LENAccount = sqlread.GetString(0).Length;
                }
            }
            sqlread.Close();
            sqlconnect.Close();

            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts where AccountTypeName <> 'Header'", sqlcon);
            adaptertbAccountTypes = new SqlDataAdapter("Select * from GLAccountTypes", sqlcon);
            adaptertbAccountsChart = new SqlDataAdapter("Select * from GLAccountsChart", sqlcon);
            adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
            if(adaptertbAccountsChart!=null)
            adaptertbAccountsChart.Fill(dbAccountingProjectDS.GLAccountsChart);
            adaptertbAccountTypes.Fill(dbAccountingProjectDS.GLAccountTypes);
            cmdBuilder = new SqlCommandBuilder(adaptertbAccountsChart);
            if (!GeneralFunctions.SubTypesloaded)
            {
                SqlConnection sqlcon10 = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlcon10.Open();
                SqlCommand command10 = new SqlCommand("Select AccountSubType From  GeneralSetup", sqlcon10);
                SqlCommand command11 = new SqlCommand("Select FirstSub From GeneralSetup", sqlcon10);
                SqlCommand command12 = new SqlCommand("Select SecondSub From GeneralSetup", sqlcon10);
                SqlCommand command13 = new SqlCommand("Select ThirdSub From GeneralSetup", sqlcon10);
                SqlCommand command14 = new SqlCommand("Select FourthSub From GeneralSetup", sqlcon10);
                int AccountSubTypeNumber;
                if (command10.ExecuteScalar() != DBNull.Value)
                {
                    AccountSubTypeNumber = Convert.ToInt32(command10.ExecuteScalar());
                    if (AccountSubTypeNumber == 2)
                    {
                        GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()), Convert.ToInt32(command12.ExecuteScalar()));
                        GeneralFunctions.SubTypesloaded = true;
                    }
                    if (AccountSubTypeNumber == 3)
                    {
                        GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()), Convert.ToInt32(command12.ExecuteScalar()), Convert.ToInt32(command13.ExecuteScalar()));
                        GeneralFunctions.SubTypesloaded = true;
                    }
                    if (AccountSubTypeNumber == 4)
                    {
                        GeneralFunctions.LoadSubtypes(Convert.ToInt32(command11.ExecuteScalar()), Convert.ToInt32(command12.ExecuteScalar()), Convert.ToInt32(command13.ExecuteScalar()), Convert.ToInt32(command14.ExecuteScalar()));
                        GeneralFunctions.SubTypesloaded = true;
                    }

                }
            }
            cb_AccountTypeName = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLAccountTypes, cb_AccountTypeName, "AccountTypeName", "AccountTypeID");
            cb_AccountTypeName.Items.Insert(0, "Any Type");
            cb_AccountTypeName.Items.Remove("<new>");
            cb_AccountTypeName.Items.Remove("Header");
            cb_AccountTypeName.Text = "Any Type";
            LoadTreeView();
            //treeView1.ExpandAll();

            if (GeneralFunctions.languagechioce != "")
            {
                this.obj_options = new ClassOptions();
                this.obj_options.report_language = GeneralFunctions.languagechioce;
                this.update_language_interface();
            }

            if (GeneralFunctions.Ckecktag("47") == "M")
                this.Menu1.Enabled = true;
            else
                this.Menu1.Enabled = false;
            if (GeneralFunctions.Ckecktag("18") == "M")
                this.btn_AddAccount.Enabled = true;
            else
                this.btn_AddAccount.Enabled = false;
            //currcet();

        }
        private void Refill()
        {
            sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            adaptertbAccounts = new SqlDataAdapter("Select * from GLAccounts where AccountTypeName <> 'Header'", sqlcon);
            adaptertbAccountTypes = new SqlDataAdapter("Select * from GLAccountTypes", sqlcon);
            adaptertbAccountsChart = new SqlDataAdapter("Select * from GLAccountsChart", sqlcon);
            cmdBuilder = new SqlCommandBuilder(adaptertbAccountsChart);
            adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
            adaptertbAccountsChart.Fill(dbAccountingProjectDS.GLAccountsChart);
            adaptertbAccountTypes.Fill(dbAccountingProjectDS.GLAccountTypes);

        }
        private void currcet()
        {
            SqlConnection sqlconnAdd = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand sqlcomUpdate;
            sqlconnAdd.Open();
            string DBAccountNumber = "";
            for (int i = 0; i < dbAccountingProjectDS.GLAccountsChart.Rows.Count; i++)
            {
                DBAccountNumber = dbAccountingProjectDS.GLAccountsChart.Rows[i]["AccountNumber"].ToString();
                sqlcomUpdate = new SqlCommand("EXEC UpdateData '" + DBAccountNumber + "'," + DateTime.Now.Year + "", sqlconnAdd);
                int x3 = sqlcomUpdate.ExecuteNonQuery();

                if (FindAccountNumber(dbAccountingProjectDS.GLAccountsChart.Rows[i]["TreeRowName"].ToString()) != "")
                    dbAccountingProjectDS.GLAccountsChart.Rows[i]["AccountNumber"] = FindAccountNumber(dbAccountingProjectDS.GLAccountsChart.Rows[i]["TreeRowName"].ToString());
                else
                    dbAccountingProjectDS.GLAccountsChart.Rows[i]["AccountNumber"] = dbAccountingProjectDS.GLAccountsChart.Rows[i]["TreeRowName"].ToString().Substring(0, 11);
            }
            adaptertbAccountsChart.Update(dbAccountingProjectDS.GLAccountsChart);
            dbAccountingProjectDS.GLAccountsChart.AcceptChanges();
            sqlconnAdd.Close();
        }
        private string FindAccountNumber(string ACCN)
        {

            string ACC = "";
            DataRow[] dracc = dbAccountingProjectDS.GLAccounts.Select("AccountName Like '" + ACCN + "'");
            if (dracc.Length != 0)
            {
                ACC = dracc[0]["AccountNumber"].ToString();
            }
            return ACC;
        }
        private void update_language_interface()
        {
            this.obj_interface_language = ClassInterfaceLanguage.load(this.exe_path + LANGUAGE_INTERFACE_DIRECTORY + this.obj_options.report_language + ".xml");
            this.Text = obj_interface_language.formChartsOfAccounts;
            this.dgv.Columns[1].HeaderText = obj_interface_language.dgvChartsOfAccountsColumn1.ToString();
            this.dgv.Columns[2].HeaderText = obj_interface_language.dgvChartsOfAccountsColumn2.ToString();
            this.dgv.Columns[3].HeaderText = obj_interface_language.dgvChartsOfAccountsColumn3.ToString();
            this.dgv.Columns[4].HeaderText = obj_interface_language.dgvChartsOfAccountsColumn4.ToString();
            this.btn_AddAccount.Text = obj_interface_language.buttonbtn_AddAccount;
            this.btnExit.Text = obj_interface_language.buttonCompanyExit;
            this.label1.Text = obj_interface_language.labelAccountNumber;
            this.label2.Text = obj_interface_language.labelAccountName;
            this.label3.Text = obj_interface_language.labelAccountTypeName;
            this.checkBox1.Text = obj_interface_language.checkboxtree;
        }

        private void LoadTreeView()
        {
            treeView1.Nodes.Clear();
            DataRow[] rArr = dbAccountingProjectDS.GLAccountsChart.Select("Root = 1");
            if (rArr.Length != 0)
            {
                parentNode = treeView1.Nodes.Add(rArr[0]["TreeRowName"].ToString());
                parentNode.Name = rArr[0]["TreeRowName"].ToString();
                folderParents = new ArrayList();
                folderParents.Add(parentNode);
                loadTreeNodes(parentNode);
            }
            else
            {

                try
                {
                    parentNode = treeView1.Nodes.Add(GeneralFunctions.CompanyName);
                    parentNode.Name = GeneralFunctions.CompanyName;
                    folderParents = new ArrayList();
                    folderParents.Add(parentNode);
                    DataRow r = dbAccountingProjectDS.GLAccountsChart.NewRow();
                    SqlConnection sqlconn2 = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlconn2.Open();
                    SqlCommand sqlcommandgettreerowid = new SqlCommand("Select max(TreeRowID) From GLAccountsChart", sqlconn2);
                    int x;
                    if (sqlcommandgettreerowid.ExecuteScalar() != DBNull.Value)
                    {
                        x = Convert.ToInt32(sqlcommandgettreerowid.ExecuteScalar());
                        GeneralFunctions.AccountsChartRow = x + 1;
                    }
                    else
                    {
                        GeneralFunctions.AccountsChartRow = 0;
                    }
                    r["TreeRowID"] = GeneralFunctions.AccountsChartRow;
                    GeneralFunctions.AccountsChartRow++;
                    r["TreeRowName"] = GeneralFunctions.CompanyName;
                    r["Root"] = 1;
                    r["ListOrder"] = 0;
                    r["TotalOrder"] = 0;
                    r["BeginningBalance"] = 0;
                    r["PeriodBalance1"] = 0;
                    r["PeriodBalance2"] = 0;
                    r["PeriodBalance3"] = 0;
                    r["PeriodBalance4"] = 0;
                    r["PeriodBalance5"] = 0;
                    r["PeriodBalance6"] = 0;
                    r["PeriodBalance7"] = 0;
                    r["PeriodBalance8"] = 0;
                    r["PeriodBalance9"] = 0;
                    r["PeriodBalance10"] = 0;
                    r["PeriodBalance11"] = 0;
                    r["PeriodBalance12"] = 0;
                    r["PeriodBalance13"] = 0;
                    r["FinalOrder"] = 0;
                    dbAccountingProjectDS.GLAccountsChart.Rows.Add(r);

                    adaptertbAccountsChart.Update(dbAccountingProjectDS.GLAccountsChart);
                    dbAccountingProjectDS.AcceptChanges();
                    folderParents = new ArrayList();
                    folderParents.Add(parentNode);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void loadTreeNodes(TreeNode parent)
        {
            TreeNode currentNode;
            DataRow[] rArr = dbAccountingProjectDS.GLAccountsChart.Select("TreeRowParent = '" + parent.Name + "'");
            if (rArr.Length != 0)
            {
                for (int i = 0; i < rArr.Length; i++)
                {
                    currentNode = parent.Nodes.Add(rArr[i]["TreeRowName"].ToString());
                    currentNode.Name = rArr[i]["TreeRowName"].ToString();
                    folderParents.Add(currentNode);
                    loadTreeNodes(currentNode);
                }
            }
        }

        private void SearchForGivenAccountNumber()
        {
            if (txt_AccountNumber.Text == "" && txt_AccountName.Text == "" && cb_AccountTypeName.Text == "")
                GridRefresh();
            else if (txt_AccountNumber.Text != "")
            {
                if (txt_AccountNumber.Text.Length <= GeneralFunctions.AccountNumberLenght)
                {
                    if (GeneralFunctions.CheckSubstring(txt_AccountNumber.Text))
                    {
                        currentAccountNumber = GeneralFunctions.ApplyAccountFormat(txt_AccountNumber.Text);
                        DataView dv = new DataView(dbAccountingProjectDS.GLAccounts);
                        dv.RowFilter = CreateFilterExpression();
                        dgv.DataSource = dv;
                        dgv.Refresh();
                    }
                    else
                        MessageBox.Show("The Account Number can only contain numeric characters \n Please Insert valid characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("The lenght of the given account exceeds the lenght of the input account format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cb_AccountTypeName.Text != "")
            {
                DataView dv = new DataView(dbAccountingProjectDS.GLAccounts);
                dv.RowFilter = CreateFilterExpression();
                dgv.DataSource = dv;
                dgv.Refresh();
            }
            else if (txt_AccountName.Text != "")
            {
                DataView dv = new DataView(dbAccountingProjectDS.GLAccounts);
                dv.RowFilter = CreateFilterExpression();
                dgv.DataSource = dv;
                dgv.Refresh();
            }
        }

        private void txt_AccountNumber_TextChanged(object sender, EventArgs e)
        {
            SearchForGivenAccountNumber();
        }

        private void txt_AccountName_TextChanged(object sender, EventArgs e)
        {
            SearchForGivenAccountNumber();
        }

        private void cb_AccountTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchForGivenAccountNumber();
            if (cb_AccountTypeName.Text == "<new>")
            {
                AccountTypes accType = new AccountTypes();
                accType.ShowDialog();
                cb_AccountTypeName.Items.Clear();
                adaptertbAccountTypes.Fill(dbAccountingProjectDS.GLAccountTypes);
                cb_AccountTypeName = GeneralFunctions.FillComboBox(dbAccountingProjectDS.GLAccountTypes, cb_AccountTypeName, "AccountTypeName", "AccountTypeID");
            }
            if (cb_AccountTypeName.Text == "Any Type")
            {
                cb_AccountTypeName.SelectedIndex = -1;
                SearchForGivenAccountNumber();
            }
        }

        private void txt_AccountNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                string modifiedAccountNumber = "";
                for (int i = 0; i < txt_AccountNumber.Text.Length - 1; i++)
                    modifiedAccountNumber += txt_AccountNumber.Text[i];
                currentAccountNumber = GeneralFunctions.ApplyAccountFormat(modifiedAccountNumber);
            }
        }

        private string CreateFilterExpression()
        {
            string filterExpression = "";
            //Account Number Only 
            if (txt_AccountNumber.Text != "" && txt_AccountName.Text == "" && cb_AccountTypeName.Text == "")
                filterExpression = "AccountNumber like '" + currentAccountNumber + "%'";
            //Account Type Only 
            else if (txt_AccountNumber.Text == "" && txt_AccountName.Text == "" && cb_AccountTypeName.Text != "")
                filterExpression = "AccountTypeName = '" + cb_AccountTypeName.Text + "'";
            //Account Name Only 
            else if (txt_AccountNumber.Text == "" && txt_AccountName.Text != "" && cb_AccountTypeName.Text == "")
                filterExpression = "AccountName like '%" + txt_AccountName.Text + "%'";
            //Account Number and Name 
            else if (txt_AccountNumber.Text != "" && txt_AccountName.Text != "" && cb_AccountTypeName.Text == "")
                filterExpression = "AccountNumber like '" + currentAccountNumber + "%' and AccountName like '%" + txt_AccountName.Text + "%'";
            //Account Number and Type 
            else if (txt_AccountNumber.Text != "" && txt_AccountName.Text == "" && cb_AccountTypeName.Text != "")
                filterExpression = "AccountNumber like '" + currentAccountNumber + "%' and AccountTypeName = '" + cb_AccountTypeName.Text + "'";
            //Account Name and Type 
            else if (txt_AccountNumber.Text == "" && txt_AccountName.Text != "" && cb_AccountTypeName.Text != "")
                filterExpression = "AccountTypeName = '" + cb_AccountTypeName.Text + "' and AccountName like '%" + txt_AccountName.Text + "%'";
            //All 
            else if (txt_AccountNumber.Text != "" && txt_AccountName.Text != "" && cb_AccountTypeName.Text != "")
                filterExpression = "AccountNumber like '" + currentAccountNumber + "%' and AccountTypeName = '" + cb_AccountTypeName.Text + "'and AccountName like '%" + txt_AccountName.Text + "%'";
            return filterExpression;
        }

        private void GridRefresh()
        {
            adaptertbAccounts.Fill(dbAccountingProjectDS.GLAccounts);
            dgv.DataSource = dbAccountingProjectDS.GLAccounts;
            dgv.Refresh();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                treeView1.SelectedNode = e.Node;
                e.Node.ContextMenuStrip = this.Menu1;
            }

        }

        private void AddFolder(string foldername, string folderparent, string getmaxOrder, string gettotalorder, string getAccountNumberFromFolder)
        {
            int Finalorder = 0;
            TreeNode node = new TreeNode(foldername);
            node.Name = foldername;
            TreeNode currentparentnode = GeneralFunctions.FindCurrentNode(folderparent, folderParents);
            currentparentnode.Nodes.Add(node);
            folderParents.Add(node);
            //treeView1.ExpandAll();
            //DataRow r = dbAccountingProjectDS.GLAccountsChart.NewRow();
            SqlConnection sqlconn2 = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconn2.Open();
            SqlCommand sqlcommandgettreerowid = new SqlCommand("Select max(TreeRowID) From GLAccountsChart", sqlconn2);
            int x;
            if (sqlcommandgettreerowid.ExecuteScalar() != DBNull.Value)
            {
                x = Convert.ToInt32(sqlcommandgettreerowid.ExecuteScalar());
                GeneralFunctions.AccountsChartRow = x + 1;
            }
            else
            {
                GeneralFunctions.AccountsChartRow = 0;
            }
            for (int L = 2; L < 5; L++)
            {
                if (getmaxOrder.Substring(getmaxOrder.Length - L, 1) == "-")
                {
                    Finalorder = int.Parse(getmaxOrder.Substring(getmaxOrder.Length - L + 1, L - 1));
                    break;
                }
            }
            SqlConnection sqlconnAdd = new SqlConnection(GeneralFunctions.ConnectionString);
            sqlconnAdd.Open();
            SqlCommand sqlcommandAdd = new SqlCommand("Insert Into GLAccountsChart (TreeRowID,TreeRowName,TreeRowParent,Root,ListOrder,TotalOrder,AccountNumber,FinalOrder) VALUES (" + GeneralFunctions.AccountsChartRow + ",'" + foldername + "','" + currentparentnode.Name + "'," + 0 + ",'" + getmaxOrder + "','" + gettotalorder + "','" + getAccountNumberFromFolder + "','" + Finalorder + "')", sqlconnAdd);
            int x2 = sqlcommandAdd.ExecuteNonQuery();
            if (x2 != 0)
            {
                // MessageBox.Show("Insert Successfully");
            }
            else
            {
                MessageBox.Show("Insert Failed");
            }

            adaptertbAccountsChart.Update(dbAccountingProjectDS.GLAccountsChart);
            dbAccountingProjectDS.AcceptChanges();
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text) || e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            SqlConnection sqlconCommand = null;
            SqlDataReader sqlreadOrder1 = null;
            SqlConnection newSqlInner = null;
            string PeriorityNumber = "";
            string getmaxOrder = "";
            string DBAccountNumber = "";
            string getPeriorityOrder = "";
            int getFinalOrder = 0;
            string getTotalOrder = "";
            int Count = 0;
            int LenChar = 0;
            TreeNode dragNode;
            int Finalorder = 0;
            string accountNumber = "";
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                accountNumber = (string)e.Data.GetData(DataFormats.Text);

                SqlConnection sqlconnAccounNumber = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand sqlcomAccountNumber = new SqlCommand("Select AccountNumberFormat From GeneralSetup", sqlconnAccounNumber);
                sqlconnAccounNumber.Open();
                SqlDataReader sqlReadAccountNumber = sqlcomAccountNumber.ExecuteReader();
                int lenghtofAccount = 0;
                if (sqlReadAccountNumber.HasRows)
                {
                    sqlReadAccountNumber.Read();
                    lenghtofAccount = Convert.ToInt32(sqlReadAccountNumber.GetString(0).Length);
                }

                Point pt = new Point(e.X, e.Y);
                Point currentPoint = treeView1.PointToClient(pt);
                TreeNode node = treeView1.GetNodeAt(currentPoint);
                if (node == null)
                    return;
                if (!node.Bounds.Contains(currentPoint))
                {
                    return;
                }
                SqlConnection sqlconnect = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlconnect.Open();
                SqlCommand sqlcommand = new SqlCommand("Select AccountNumberFormat FROM GeneralSetup", sqlconnect);
                SqlDataReader sqlread = sqlcommand.ExecuteReader();

                //int CountNumber = 0;
                //if (sqlread.HasRows)
                //{
                //    while (sqlread.Read())
                //    {
                //        CountNumber = sqlread.GetString(0).Length;
                //    }
                //}
                sqlread.Close();
                //if (node.Name.Length > CountNumber)
                //{
                    //int found = 0;
                    //if (node.Name.Substring(0,CountNumber)){

                /// hna na ghaert el account name elle kanet bayza


                sqlcommand = new SqlCommand("Select AccountNumber FROM GLAccounts WHERE AccountNumber='" + node.Name+ "'", sqlconnect);
                sqlread = sqlcommand.ExecuteReader();

                if (sqlread.HasRows)
                {
                    MessageBox.Show("You can't insert account number over account number", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                DBAccountNumber = accountNumber.Substring(0, lenghtofAccount);
                SqlConnection newsqlAccountType = new SqlConnection(GeneralFunctions.ConnectionString);
                newsqlAccountType.Open();
                SqlCommand newsqlAccountTypeCommand = new SqlCommand("Select AccountTypeName From GLAccounts WHERE AccountNumber='" + DBAccountNumber + "'", newsqlAccountType);
                SqlDataReader newsqlReadAccountType = newsqlAccountTypeCommand.ExecuteReader();
                if (newsqlReadAccountType.HasRows)
                {
                    newsqlReadAccountType.Read();
                    if (newsqlReadAccountType.GetString(0) == "Header" || newsqlReadAccountType.GetString(0) == "Statictical")
                    {

                        MessageBox.Show("You can't put header or statistical account over account number");
                        return;
                    }
                }

                    //}
                //}

                TreeNode[] n = treeView1.Nodes[0].Nodes.Find(accountNumber, true);
                if (n.Length == 0)
                {
                    dragNode = new TreeNode(accountNumber);
                    dragNode.Name = accountNumber;
                    node.Nodes.Add(dragNode);
                    //treeView1.ExpandAll();
                    SqlConnection sqlconn2 = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlconn2.Open();
                    SqlCommand sqlcommandgettreerowid = new SqlCommand("Select max(TreeRowID) From GLAccountsChart", sqlconn2);
                    int x;
                    if (sqlcommandgettreerowid.ExecuteScalar() != DBNull.Value)
                    {
                        x = Convert.ToInt32(sqlcommandgettreerowid.ExecuteScalar());
                        GeneralFunctions.AccountsChartRow = x + 1;
                    }
                    else
                    {
                        GeneralFunctions.AccountsChartRow = 0;
                    }


                    try
                    {
                        sqlconCommand = new SqlConnection(GeneralFunctions.ConnectionString);
                        SqlCommand sqlcomcommand2 = new SqlCommand("Select ListOrder,TotalOrder,FinalOrder From GLAccountsChart Where TreeRowName='" + node.Name + "'", sqlconCommand);
                        sqlconCommand.Open();
                        sqlreadOrder1 = sqlcomcommand2.ExecuteReader();

                        if (sqlreadOrder1.HasRows)
                        {
                            sqlreadOrder1.Read();
                            PeriorityNumber = sqlreadOrder1.GetString(0);
                            getPeriorityOrder = sqlreadOrder1.GetString(1);
                            getFinalOrder = sqlreadOrder1.GetInt32(2);
                            SqlConnection sqlOrderConnection = new SqlConnection(GeneralFunctions.ConnectionString);
                            sqlOrderConnection.Open();
                            SqlCommand sqlOrderCount = new SqlCommand("Select Count(TreeRowID) From GLAccountsChart Where left(TotalOrder,1) ='" + getFinalOrder + "'", sqlOrderConnection);
                            Count = Convert.ToInt32(sqlOrderCount.ExecuteScalar());
                            if (Count > 100)
                                LenChar = 3;
                            else if (Count > 10)
                                LenChar = 2;
                            else
                                LenChar = 1;
                            SqlCommand sqlOrderCommand = new SqlCommand("Select MAX(FinalOrder) From GLAccountsChart Where left(TotalOrder," + getPeriorityOrder.Length + ") ='" + getPeriorityOrder + "' AND  (LEN(TotalOrder)=" + (getPeriorityOrder.Length + LenChar) + ")", sqlOrderConnection);
                            getTotalOrder = "";
                            getTotalOrder = Convert.ToString(sqlOrderCommand.ExecuteScalar());
                            if (getTotalOrder == "")
                            {
                                getTotalOrder = getPeriorityOrder + "1";
                            }
                            else
                            {

                                getTotalOrder = getPeriorityOrder + (Convert.ToInt32(getTotalOrder) + Convert.ToInt32("1"));

                            }
                            newSqlInner = new SqlConnection(GeneralFunctions.ConnectionString);
                            newSqlInner.Open();
                            SqlCommand sqlcommandInner = new SqlCommand("SELECT MAX(ListOrder) AS MaxOrder FROM GLAccountsChart WHERE     (LEFT(ListOrder, " + PeriorityNumber.Length + ") = '" + PeriorityNumber + "') AND (LEN(ListOrder) = " + (PeriorityNumber.Length + getFinalOrder.ToString().Length + 1) + ")", newSqlInner);
                            getmaxOrder = "";
                            getmaxOrder = Convert.ToString(sqlcommandInner.ExecuteScalar());
                            if (getmaxOrder == "")
                            {
                                getmaxOrder = PeriorityNumber + "-1";
                            }
                            else
                            {
                                string[] rightvalue = new string[1000];
                                rightvalue = getmaxOrder.Split('-');
                                string rightval = rightvalue[rightvalue.Length - 1];
                                int rightintval = Convert.ToInt32(rightval) + 1;
                                getmaxOrder = "";
                                for (int i = 0; i < rightvalue.Length - 1; i++)
                                    if (i == 0)
                                        getmaxOrder = rightvalue[i];
                                    else
                                        getmaxOrder = getmaxOrder + "-" + rightvalue[i];
                                getmaxOrder = getmaxOrder + "-" + rightintval;
                            }
                        }

                    }
                    catch (Exception e4)
                    {
                        MessageBox.Show(e4.Message);
                    }
                    finally
                    {

                        newSqlInner.Close();
                    }
                    SqlConnection sqlconnAdd = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlconnAdd.Open();
                    for (int L = 2; L < 5; L++)
                    {
                        if (getmaxOrder.Substring(getmaxOrder.Length - L, 1) == "-")
                        {
                            Finalorder = int.Parse(getmaxOrder.Substring(getmaxOrder.Length - L + 1, L - 1));
                            break;
                        }
                    }

                    //DBAccountNumber = accountNumber.Substring(0, lenghtofAccount);
                    
                    
                    for (int i = 0; i < accountNumber.Length; i++)
                    {
                        if (accountNumber[i]!=' ')
                        {
                            DBAccountNumber += accountNumber[i];
                            
                        }
                        else
                        {
                            break;
                        }
                    }

                   // DBAccountNumber = accountNumber;
                    SqlCommand sqlcommandAdd = new SqlCommand("Insert Into GLAccountsChart (TreeRowID,TreeRowName,TreeRowParent,Root,ListOrder,AccountNumber,TotalOrder,FinalOrder) VALUES (" + GeneralFunctions.AccountsChartRow + ",'" + accountNumber + "','" + node.Name + "'," + 0 + ",'" + getmaxOrder + "','" + DBAccountNumber + "','" + getTotalOrder + "','" + Finalorder + "')", sqlconnAdd);
                    SqlCommand sqlcomUpdate = new SqlCommand("EXEC UpdateData '" + DBAccountNumber + "'," + DateTime.Now.Year + "", sqlconnAdd);
                    int x2 = sqlcommandAdd.ExecuteNonQuery();
                    int x3 = sqlcomUpdate.ExecuteNonQuery();
                    if (x2 != 0)
                    {
                        //MessageBox.Show("Insert Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Insert Failed");
                    }

                    adaptertbAccountsChart.Update(dbAccountingProjectDS.GLAccountsChart);
                    dbAccountingProjectDS.AcceptChanges();
                    //DataRow r = dbAccountingProjectDS.GLAccountsChart.NewRow();
                    //r["TreeRowID"] = GeneralFunctions.AccountsChartRow;
                    //GeneralFunctions.AccountsChartRow++;
                    //r["TreeRowName"] = accountNumber;
                    //r["TreeRowParent"] = node.Name;
                    //r["Root"] = 0;
                    //dbAccountingProjectDS.GLAccountsChart.Rows.Add(r);
                }
                else
                    MessageBox.Show("Account Number already exists");
            }
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (treeView1.SelectedNode != null)
                {
                    try
                    {

                        if (treeView1.SelectedNode.Parent.Name == null)
                        {
                            SqlConnection deleteConnection = new SqlConnection(GeneralFunctions.ConnectionString);
                            deleteConnection.Open();
                            SqlCommand deletecommand = new SqlCommand("Delete From GLAccountsChart ", deleteConnection);
                            SqlDataReader sqlread = deletecommand.ExecuteReader();
                            if (sqlread != null)
                            {
                                MessageBox.Show("Delete Successfully");
                            }
                            else
                            {
                                MessageBox.Show("Delete Failed");
                            }
                            treeView1.Nodes.Remove(treeView1.SelectedNode);
                            treeView1.Refresh();
                            //treeView1.ExpandAll();
                            SqlConnection sqlconn2 = new SqlConnection(GeneralFunctions.ConnectionString);
                            adaptertbAccountsChart = new SqlDataAdapter("Select * From GLAccountsChart", sqlconn2);
                            adaptertbAccountsChart.Fill(dbAccountingProjectDS.GLAccountsChart);
                            dbAccountingProjectDS.AcceptChanges();
                            //if (DialogResult.Yes == MessageBox.Show("Are you sure to delete all ChartOfAccounts", "Warrining", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) {
                            //    DataRow[] rArr2 = dbAccountingProjectDS.GLAccountsChart.Select("TreeRowName = '" + treeView1.SelectedNode.Name + "'");
                            //    if (rArr2.Length != 0) {
                            //        rArr2[0].Delete();
                            //    }
                            //    treeView1.Nodes.Remove(treeView1.SelectedNode);
                            //    return;
                            //}
                            //else {
                            //    MessageBox.Show("Node still not deleted");
                            return;
                            //}

                        }
                        //DataRow[] rArr = dbAccountingProjectDS.GLAccountsChart.Select("TreeRowName = '" + treeView1.SelectedNode.Name + "' and TreeRowParent = '" + treeView1.SelectedNode.Parent.Name + "'");
                        //if (rArr.Length != 0) {
                        //    rArr[0].Delete();
                        //}
                        //treeView1.Nodes.Remove(treeView1.SelectedNode);
                        SqlConnection deleteConnection2 = new SqlConnection(GeneralFunctions.ConnectionString);
                        deleteConnection2.Open();
                        SqlCommand deletecommand2 = new SqlCommand("Delete From GLAccountsChart Where TreeRowName='" + treeView1.SelectedNode.Text + "' OR TreeRowParent='" + treeView1.SelectedNode.Text + "'", deleteConnection2);
                        SqlDataReader sqlread2 = deletecommand2.ExecuteReader();
                        if (sqlread2 != null)
                        {
                            MessageBox.Show("Delete Successfully");
                        }
                        else
                        {
                            MessageBox.Show("Delete Failed");
                        }
                        treeView1.Nodes.Remove(treeView1.SelectedNode);
                        treeView1.Refresh();
                        //treeView1.ExpandAll();
                        SqlConnection sqlconn22 = new SqlConnection(GeneralFunctions.ConnectionString);
                        adaptertbAccountsChart = new SqlDataAdapter("Select * From GLAccountsChart", sqlconn22);
                        adaptertbAccountsChart.Fill(dbAccountingProjectDS.GLAccountsChart);
                        dbAccountingProjectDS.AcceptChanges();
                    }
                    catch (Exception e2)
                    {
                        MessageBox.Show(e2.Message);
                    }
                }
            }
        }

        private void dgv_MouseMove(object sender, MouseEventArgs e)
        {
            if (Menu1.Enabled == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    string data;
                    DataGridView dgvControl = (DataGridView)sender;
                    int count = dgvControl.SelectedRows.Count;
                    if (count > 0)
                    {
                        DataGridViewRow item = (DataGridViewRow)dgvControl.SelectedRows[0];
                        if (item.Selected)
                        {
                            data = item.Cells["ColumnAccountNumber"].Value.ToString() + "  " + item.Cells["ColumnAccountName"].Value.ToString();
                            dgvControl.DoDragDrop(data, DragDropEffects.Copy);
                        }
                    }
                }
            }
        }

        private void btn_SaveChanges_Click(object sender, EventArgs e)
        {
            adaptertbAccountsChart.Update(dbAccountingProjectDS.GLAccountsChart);
            dbAccountingProjectDS.AcceptChanges();
        }

        private void btn_AddAccount_Click(object sender, EventArgs e)
        {
            AccountsDefinition acc = new AccountsDefinition();
            acc.ShowDialog();
            adaptertbAccounts.Update(dbAccountingProjectDS.GLAccounts);
            GridRefresh();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddAFolder_Click(object sender, EventArgs e)
        {
            try
            {
                AddFolder addfold = new AddFolder();
                addfold.currentFolderOptions = folderParents;
                addfold.tv = treeView1;
                addfold.LenAcc = LENAccount;
                GeneralFunctions.ParentForm = treeView1.SelectedNode.Text;
                addfold.ShowDialog();
                if (!addfold.cancelled)
                {
                    string selectedfolder = addfold.folderName;
                    string selectedfolderparent = addfold.folderParentName;
                    string getmaxOrder = addfold.getmaxOrder;
                    string gettotalorder = addfold.getTotalOrder;
                    string getAccountNumberFromFolder = addfold.getAccountNumber;
                    AddFolder(selectedfolder, selectedfolderparent, getmaxOrder, gettotalorder, getAccountNumberFromFolder);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("There no items to delete");
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("Are you sure that you want to delete " + treeView1.SelectedNode.Text + " Node , To Accept Yes , To Reject No ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Hand))
            {
                SqlConnection sqlconnCheck = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlconnCheck.Open();
                SqlCommand sqlcommandCheck = new SqlCommand("Select TreeRowName From GLAccountsChart Where Root=1", sqlconnCheck);
                SqlDataReader sqlRead = sqlcommandCheck.ExecuteReader();
                string treeName = "";
                if (sqlRead.HasRows)
                {
                    while (sqlRead.Read())
                    {
                        treeName = sqlRead.GetString(0);
                    }
                }
                if (treeView1.SelectedNode.Text == treeName)
                {
                    MessageBox.Show("You can't delete this node because you will delete all tree of Chart Of Accounts", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    SqlConnection deleteConnection = new SqlConnection(GeneralFunctions.ConnectionString);
                    deleteConnection.Open();
                    string listOrd = "";
                    SqlCommand Listcommand = new SqlCommand("Select ListOrder From GLAccountsChart Where TreeRowName ='" + treeView1.SelectedNode.Text + "'", deleteConnection);
                    SqlDataReader DRlistOrder = Listcommand.ExecuteReader();
                    if (DRlistOrder.HasRows)
                    {
                        DRlistOrder.Read();
                        listOrd = DRlistOrder.GetString(0);
                        DRlistOrder.Close();
                        SqlCommand deletecommand = new SqlCommand("Delete From GLAccountsChart Where left(ListOrder,'" + listOrd.Length + "') = '" + listOrd + "'", deleteConnection);
                        SqlDataReader sqlread = deletecommand.ExecuteReader();
                        //SqlCommand deletecommand = new SqlCommand("Delete From GLAccountsChart Where TreeRowParent ='" + treeView1.SelectedNode.Text + "' OR TreeRowParent='" + treeView1.SelectedNode.Text + "'", deleteConnection);
                        //SqlDataReader sqlread = deletecommand.ExecuteReader();
                        if (sqlread != null)
                        {
                            MessageBox.Show("Delete Successfully");
                        }
                        else
                        {
                            MessageBox.Show("Delete Failed");
                        }
                        treeView1.Nodes.Remove(treeView1.SelectedNode);
                        sqlread.Close();
                    }
                    else
                        MessageBox.Show("Delete Failed");
                }
                this.Menu1.Close();
                treeView1.Refresh();
                Refill();
                LoadTreeView();
            }
            else
            {
                MessageBox.Show("You can't delete " + treeView1.SelectedNode.Text + " Node", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (GeneralFunctions.languagechioce == "arabic")
                    checkBox1.Text = "≈€·«ﬁ «·„Œÿÿ";
                else
                    checkBox1.Text = "Collapse Tree";
                treeView1.ExpandAll();
            }
            else
            {
                if (GeneralFunctions.languagechioce == "arabic")
                    checkBox1.Text = "⁄—÷ «·„Œÿÿ";
                else
                    checkBox1.Text = "Expand Tree";
                treeView1.CollapseAll();
            }

        }
    }
}