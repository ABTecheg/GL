using System; using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Accounting_GeneralLedger {
    public partial class AddFolder : Form {
        public string folderName;
        public string PeriorityNumber;
        public string folderParentName;
        public string getmaxOrder;
        public string getTotalOrder;
        public string getPeriorityOrder;
        public string getFinalOrder;
        public string getAccountNumber;
        public ArrayList currentFolderOptions;
        public bool cancelled = false;
        public TreeView tv;
        private int currentlevelNumber;
        public int LenAcc = 0;

        public AddFolder() {
            InitializeComponent();
        }

        private void AddFolder_Load(object sender, EventArgs e) {
            LoadComboBox();
            //LoadNames();
        }


        //private void LoadNames()
        //{

        //    using (SqlConnection sqlConnection =new SqlConnection(GeneralFunctions.ConnectionString))
        //    {
        //        SqlCommand sqlcmd = new SqlCommand("select * from GLAccounts where AccountTypeID = 6",sqlConnection);
        //        sqlConnection.Open();
        //        SqlDataReader sqlReader = sqlcmd.ExecuteReader();
        //        while (sqlReader.Read())
        //        {
        //            NamesItems.Items.Add(sqlReader["AccountName"].ToString());
        //        }

        //                         sqlReader.Close();

        //    }


        //}


        private void LoadComboBox() {
            foreach (TreeNode n in currentFolderOptions) {
                if (!CheckAcc(n.Name))
                    cb_FolderParent.Items.Add(n.Name);
            }
            cb_FolderParent.Text = GeneralFunctions.ParentForm;
        }
        private bool CheckAcc(string Acc)
        {
            bool flage = false;
            if (Acc.Length > LenAcc)
            {
                Acc = Acc.Substring(0, LenAcc);
                SqlConnection sqlconnect = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlconnect.Open();
                SqlCommand sqlcommand = new SqlCommand("Select * FROM GLAccounts Where AccountTypeName <> 'Header' AND AccountNumber = '" + Acc + "'", sqlconnect);
                SqlDataReader sqlread = sqlcommand.ExecuteReader();
                if (sqlread.HasRows)
                {
                    flage = true;
                }
                sqlread.Close();
                sqlconnect.Close();
            }
            return flage;
        }
        private void cb_FolderParent_SelectedIndexChanged(object sender, EventArgs e) {
            folderParentName = cb_FolderParent.Text;
        }

        private bool ValidateParentNode() {
            bool validLevel = true;
            if (folderParentName != "") {
                TreeNode n = GeneralFunctions.FindCurrentNode(folderParentName, currentFolderOptions);
                if (n != null) {
                    ValidateTreeNodeLevel(n, 0);
                    SqlConnection sqlconLevels = new SqlConnection(GeneralFunctions.ConnectionString);
                    sqlconLevels.Open();
                    SqlCommand sqlcomLevels = new SqlCommand("Select AccountsChartSubLevels From GeneralSetup", sqlconLevels);
                    SqlDataReader sqlreadLevels = sqlcomLevels.ExecuteReader();
                    if (sqlreadLevels.HasRows) { 
                        while(sqlreadLevels.Read()){
                            GeneralFunctions.maxSublevelNumber = sqlreadLevels.GetInt32(0);
                        }
                    }
                    if (currentlevelNumber > GeneralFunctions.maxSublevelNumber) {
                        validLevel = false;
                        MessageBox.Show("You have exceeded the max number of sublevels, Please Choose another parent ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else {
                    validLevel = false;
                    MessageBox.Show("Please Specify the parent Node", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                validLevel = false;
                MessageBox.Show("Please Specify the parent node", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return validLevel;
        }

        private void btn_Add_Click(object sender, EventArgs e) {
            if (txt_FolderName.Text.Trim() == "")
            {
                MessageBox.Show("Please Insert Folder Name", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            SqlConnection sqlcon=null;
            SqlConnection newSqlInner=null;
            SqlDataReader sqlreadOreder=null;
            SqlDataReader sqlread=null;
            int Count = 0;
            int LenChar = 0;
            try
            {
            if (ValidateParentNode() && GeneralFunctions.ValidateString(txt_FolderName.Text, "Please Specify a valid folder name")) {
                sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlcon.Open();
                SqlCommand sqlcommand = new SqlCommand("Select * From   GLAccounts WHere AccountName='" + txt_FolderName.Text + "' AND AccountTypeName='Header'", sqlcon);
                SqlConnection sqlconn4 = new SqlConnection(GeneralFunctions.ConnectionString);
                sqlconn4.Open();
                SqlCommand sqlCheck = new SqlCommand("Select * FROM GLAccountsChart WHERE TreeRowName='" + txt_FolderName.Text + "'", sqlconn4);
                SqlDataReader sqlreadCheck = sqlCheck.ExecuteReader();
                if (sqlreadCheck.HasRows) {
                    MessageBox.Show("This folder name is exists please try with another name","Information",MessageBoxButtons.OK,MessageBoxIcon.Stop);

                    return;
                }
                SqlConnection newsqlconnection22 = new SqlConnection(GeneralFunctions.ConnectionString);
                SqlCommand sqlcommand2 = new SqlCommand("Select ListOrder,TotalOrder,FinalOrder From GLAccountsChart Where TreeRowName='" + cb_FolderParent.Text + "'", newsqlconnection22);
                newsqlconnection22.Open();
                sqlreadOreder = sqlcommand2.ExecuteReader();
                                
                if (sqlreadOreder.HasRows) {
                    sqlreadOreder.Read();
                    PeriorityNumber = sqlreadOreder.GetString(0);
                    getPeriorityOrder = sqlreadOreder.GetString(1);
                    getFinalOrder = sqlreadOreder.GetInt32(2).ToString();
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
                    SqlCommand sqlOrderCommand = new SqlCommand("Select MAX(FinalOrder) From GLAccountsChart Where left(TotalOrder," + getPeriorityOrder.Length + ") ='" + getPeriorityOrder + "' AND  (LEN(TotalOrder)=" + (getPeriorityOrder.Length + LenChar) + ") ", sqlOrderConnection); // 
                    getTotalOrder = "";
                    getTotalOrder = Convert.ToString(sqlOrderCommand.ExecuteScalar());
                    if (getTotalOrder == "")
                    {
                        getTotalOrder = getPeriorityOrder + "1";
                    }
                    else
                    {
                        //if getPeriorityOrder.Length=
                        getTotalOrder = getPeriorityOrder + (Convert.ToInt32( getTotalOrder) + Convert.ToInt32( "1"));
                        //string[] rightvalue1 = new string[1000];
                        //rightvalue1 = getTotalOrder.Split('');
                        //string rightval = rightvalue[rightvalue.Length - 1];
                        //int rightintval = Convert.ToInt32(rightval) + 1;
                        //getmaxOrder = "";
                        //for (int i = 0; i < rightvalue.Length - 1; i++)
                        //    if (i == 0)
                        //        getmaxOrder = rightvalue[i];
                        //    else
                        //        getmaxOrder = getmaxOrder + "-" + rightvalue[i];
                        //getmaxOrder = getmaxOrder + "-" + rightintval;
                    }
                    newSqlInner=new SqlConnection(GeneralFunctions.ConnectionString);
                    SqlCommand sqlcommandInner = new SqlCommand("SELECT MAX(ListOrder) AS MaxOrder FROM GLAccountsChart WHERE     (LEFT(ListOrder, " + PeriorityNumber.Length + ") = '" + PeriorityNumber + "') AND (LEN(ListOrder) = " + (PeriorityNumber.Length + getFinalOrder.Length + 1) + ")", newSqlInner);
                    newSqlInner.Open();
                    getmaxOrder="";
                    
                    getmaxOrder = Convert.ToString( sqlcommandInner.ExecuteScalar());
                    if (getmaxOrder == "")
                    {
                        getmaxOrder = PeriorityNumber + "-1";
                    }
                    else { 
                        string[] rightvalue=new string[1000];
                        rightvalue = getmaxOrder.Split('-');
                        string rightval = rightvalue[rightvalue.Length - 1];
                        int rightintval = Convert.ToInt32(rightval) +1;
                        getmaxOrder = "";
                        for (int i = 0; i < rightvalue.Length - 1; i++)
                            if (i == 0)
                                getmaxOrder = rightvalue[i];
                            else 
                                getmaxOrder = getmaxOrder +"-"+ rightvalue[i];
                        getmaxOrder = getmaxOrder +"-"+ rightintval;
                    }
                }
                sqlreadOreder.Close();

                sqlread = sqlcommand.ExecuteReader();
                
                if (sqlread.HasRows) {
                    folderName = txt_FolderName.Text;
                    this.Close();
                }
                else {
                    if (DialogResult.Yes == MessageBox.Show("You should name folder with name of header account from database ,yes to continue anyway,no to check name again?", "Choose", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) {
                        folderName = txt_FolderName.Text;
                        this.Close();
                    }
                    else {
                        return;
                    }
                }
                sqlread.Close();
            }
        }
        catch (Exception e3)
        {
            MessageBox.Show(e3.Message.ToString());
        }
        finally
        {
            //if (sqlreadOreder.Read()==true) sqlreadOreder.Close();
           // if (sqlread.Read()==true) sqlread.Close();
            if (sqlcon.State==ConnectionState.Open ) sqlcon.Close();
            //if (newSqlInner.State==ConnectionState.Open) newSqlInner.Close();
        }
            
        }

        private void btn_Cancel_Click(object sender, EventArgs e) {
            cancelled = true;
            this.Close();
        }

        private void ValidateTreeNodeLevel(TreeNode n, int currentNumber) {
            SqlConnection sqlcon = new SqlConnection(GeneralFunctions.ConnectionString);
            SqlCommand sqlcom = new SqlCommand("Select * From Company ", sqlcon);
            sqlcon.Open();
            SqlDataReader sqlread = sqlcom.ExecuteReader();
            if (sqlread.HasRows) {
                while (sqlread.Read()) {
                    GeneralFunctions.CompanyName = sqlread.GetString(1);
                }
            }
            TreeNode currentParent;
            if (n.Name == GeneralFunctions.CompanyName) {
                currentlevelNumber = currentNumber + 1;
            }
            else {
                currentParent = n.Parent;
                currentNumber++;
                ValidateTreeNodeLevel(currentParent, currentNumber);
            }

        }

        private void txt_FolderName_Click(object sender, EventArgs e) {

        }

        private void txt_FolderName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_FolderName_DoubleClick(object sender, EventArgs e)
        {
            SearchHeader sf = new SearchHeader();
            sf.ShowDialog();
            if (sf.selectedAccountType == "Header")
            {
                txt_FolderName.Text = sf.selectedAccountName;
                getAccountNumber = sf.selectedAccountNumber;
            }
        }
    }
}