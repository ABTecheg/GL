namespace Accounting_GeneralLedger
{
    partial class Bank_Deposit_Type
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.bankDepositTypeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankDepositTypeCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankDepositTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_New = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkOverride_Fees = new System.Windows.Forms.CheckBox();
            this.chkCredit_Card_Deposit = new System.Windows.Forms.CheckBox();
            this.lbl_CC_Fees = new System.Windows.Forms.Label();
            this.txt_CC_Fees = new System.Windows.Forms.TextBox();
            this.cb_Bank_Account_ID = new System.Windows.Forms.ComboBox();
            this.lbl_Bank_Account_ID = new System.Windows.Forms.Label();
            this.txt_Cash_Short_Over_Acct = new System.Windows.Forms.MaskedTextBox();
            this.btn_Cash_Short_Over_Acct = new System.Windows.Forms.Button();
            this.lbl_Cash_Short_Over_Acct = new System.Windows.Forms.Label();
            this.txt_CC_Discount_Acct = new System.Windows.Forms.MaskedTextBox();
            this.btn_CC_Discount_Acct = new System.Windows.Forms.Button();
            this.lbl_CC_Discount_Acct = new System.Windows.Forms.Label();
            this.lbl_Bank_Deposit_Type_Name = new System.Windows.Forms.Label();
            this.txt_Bank_Deposit_Type_Name = new System.Windows.Forms.TextBox();
            this.txt_Acct_Deposit_From = new System.Windows.Forms.MaskedTextBox();
            this.btn_Acct_Deposit_From = new System.Windows.Forms.Button();
            this.lbl_Acct_Deposit_From = new System.Windows.Forms.Label();
            this.lblBank_Deposit_Type_Code = new System.Windows.Forms.Label();
            this.txt_Bank_Deposit_Type_Code = new System.Windows.Forms.TextBox();
            this.lbl_Bank_Deposit_Type_ID = new System.Windows.Forms.Label();
            this.txt_Bank_Deposit_Type_ID = new System.Windows.Forms.TextBox();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnundo = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnSavenew = new System.Windows.Forms.Button();
            this.Lock88 = new System.Windows.Forms.GroupBox();
            this.Lock90 = new System.Windows.Forms.GroupBox();
            this.Btnsaveedit = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.Lock89 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.Lock88.SuspendLayout();
            this.Lock90.SuspendLayout();
            this.Lock89.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bankDepositTypeIDDataGridViewTextBoxColumn,
            this.bankDepositTypeCodeDataGridViewTextBoxColumn,
            this.bankDepositTypeNameDataGridViewTextBoxColumn});
            this.dgv.DataMember = "Bank_Deposit_Type";
            this.dgv.DataSource = this.dbAccountingProjectDSBindingSource;
            this.dgv.Location = new System.Drawing.Point(2, 3);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(246, 282);
            this.dgv.TabIndex = 7;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseClick);
            // 
            // bankDepositTypeIDDataGridViewTextBoxColumn
            // 
            this.bankDepositTypeIDDataGridViewTextBoxColumn.DataPropertyName = "Bank_Deposit_Type_ID";
            this.bankDepositTypeIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.bankDepositTypeIDDataGridViewTextBoxColumn.Name = "bankDepositTypeIDDataGridViewTextBoxColumn";
            this.bankDepositTypeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.bankDepositTypeIDDataGridViewTextBoxColumn.Width = 43;
            // 
            // bankDepositTypeCodeDataGridViewTextBoxColumn
            // 
            this.bankDepositTypeCodeDataGridViewTextBoxColumn.DataPropertyName = "Bank_Deposit_Type_Code";
            this.bankDepositTypeCodeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.bankDepositTypeCodeDataGridViewTextBoxColumn.Name = "bankDepositTypeCodeDataGridViewTextBoxColumn";
            this.bankDepositTypeCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.bankDepositTypeCodeDataGridViewTextBoxColumn.Width = 57;
            // 
            // bankDepositTypeNameDataGridViewTextBoxColumn
            // 
            this.bankDepositTypeNameDataGridViewTextBoxColumn.DataPropertyName = "Bank_Deposit_Type_Name";
            this.bankDepositTypeNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.bankDepositTypeNameDataGridViewTextBoxColumn.Name = "bankDepositTypeNameDataGridViewTextBoxColumn";
            this.bankDepositTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.bankDepositTypeNameDataGridViewTextBoxColumn.Width = 60;
            // 
            // dbAccountingProjectDSBindingSource
            // 
            this.dbAccountingProjectDSBindingSource.DataSource = this.dbAccountingProjectDS;
            this.dbAccountingProjectDSBindingSource.Position = 0;
            // 
            // dbAccountingProjectDS
            // 
            this.dbAccountingProjectDS.DataSetName = "dbAccountingProjectDS";
            this.dbAccountingProjectDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(620, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.insertToolStripMenuItem.Text = "Insert";
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(0, 6);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(69, 31);
            this.btn_New.TabIndex = 16;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkOverride_Fees);
            this.groupBox1.Controls.Add(this.chkCredit_Card_Deposit);
            this.groupBox1.Controls.Add(this.lbl_CC_Fees);
            this.groupBox1.Controls.Add(this.txt_CC_Fees);
            this.groupBox1.Controls.Add(this.cb_Bank_Account_ID);
            this.groupBox1.Controls.Add(this.lbl_Bank_Account_ID);
            this.groupBox1.Controls.Add(this.txt_Cash_Short_Over_Acct);
            this.groupBox1.Controls.Add(this.btn_Cash_Short_Over_Acct);
            this.groupBox1.Controls.Add(this.lbl_Cash_Short_Over_Acct);
            this.groupBox1.Controls.Add(this.txt_CC_Discount_Acct);
            this.groupBox1.Controls.Add(this.btn_CC_Discount_Acct);
            this.groupBox1.Controls.Add(this.lbl_CC_Discount_Acct);
            this.groupBox1.Controls.Add(this.lbl_Bank_Deposit_Type_Name);
            this.groupBox1.Controls.Add(this.txt_Bank_Deposit_Type_Name);
            this.groupBox1.Controls.Add(this.txt_Acct_Deposit_From);
            this.groupBox1.Controls.Add(this.btn_Acct_Deposit_From);
            this.groupBox1.Controls.Add(this.lbl_Acct_Deposit_From);
            this.groupBox1.Controls.Add(this.lblBank_Deposit_Type_Code);
            this.groupBox1.Controls.Add(this.txt_Bank_Deposit_Type_Code);
            this.groupBox1.Controls.Add(this.lbl_Bank_Deposit_Type_ID);
            this.groupBox1.Controls.Add(this.txt_Bank_Deposit_Type_ID);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(254, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 295);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.EnabledChanged += new System.EventHandler(this.groupBox1_EnabledChanged);
            // 
            // chkOverride_Fees
            // 
            this.chkOverride_Fees.AutoSize = true;
            this.chkOverride_Fees.Location = new System.Drawing.Point(147, 251);
            this.chkOverride_Fees.Name = "chkOverride_Fees";
            this.chkOverride_Fees.Size = new System.Drawing.Size(92, 17);
            this.chkOverride_Fees.TabIndex = 77;
            this.chkOverride_Fees.Text = "Override Fees";
            this.chkOverride_Fees.UseVisualStyleBackColor = true;
            this.chkOverride_Fees.Visible = false;
            // 
            // chkCredit_Card_Deposit
            // 
            this.chkCredit_Card_Deposit.AutoSize = true;
            this.chkCredit_Card_Deposit.Location = new System.Drawing.Point(147, 170);
            this.chkCredit_Card_Deposit.Name = "chkCredit_Card_Deposit";
            this.chkCredit_Card_Deposit.Size = new System.Drawing.Size(123, 17);
            this.chkCredit_Card_Deposit.TabIndex = 76;
            this.chkCredit_Card_Deposit.Text = "Credit_Card_Deposit";
            this.chkCredit_Card_Deposit.UseVisualStyleBackColor = true;
            this.chkCredit_Card_Deposit.CheckedChanged += new System.EventHandler(this.chkCredit_Card_Deposit_CheckedChanged);
            // 
            // lbl_CC_Fees
            // 
            this.lbl_CC_Fees.AutoSize = true;
            this.lbl_CC_Fees.Location = new System.Drawing.Point(8, 226);
            this.lbl_CC_Fees.Name = "lbl_CC_Fees";
            this.lbl_CC_Fees.Size = new System.Drawing.Size(58, 13);
            this.lbl_CC_Fees.TabIndex = 39;
            this.lbl_CC_Fees.Text = "CC Fees %";
            this.lbl_CC_Fees.Visible = false;
            // 
            // txt_CC_Fees
            // 
            this.txt_CC_Fees.Location = new System.Drawing.Point(147, 223);
            this.txt_CC_Fees.MaxLength = 10;
            this.txt_CC_Fees.Name = "txt_CC_Fees";
            this.txt_CC_Fees.Size = new System.Drawing.Size(86, 20);
            this.txt_CC_Fees.TabIndex = 38;
            this.txt_CC_Fees.Visible = false;
            this.txt_CC_Fees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_CC_Fees_KeyPress);
            // 
            // cb_Bank_Account_ID
            // 
            this.cb_Bank_Account_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Bank_Account_ID.FormattingEnabled = true;
            this.cb_Bank_Account_ID.Location = new System.Drawing.Point(147, 107);
            this.cb_Bank_Account_ID.Name = "cb_Bank_Account_ID";
            this.cb_Bank_Account_ID.Size = new System.Drawing.Size(116, 21);
            this.cb_Bank_Account_ID.TabIndex = 37;
            // 
            // lbl_Bank_Account_ID
            // 
            this.lbl_Bank_Account_ID.AutoSize = true;
            this.lbl_Bank_Account_ID.Location = new System.Drawing.Point(8, 110);
            this.lbl_Bank_Account_ID.Name = "lbl_Bank_Account_ID";
            this.lbl_Bank_Account_ID.Size = new System.Drawing.Size(75, 13);
            this.lbl_Bank_Account_ID.TabIndex = 36;
            this.lbl_Bank_Account_ID.Text = "Bank Account";
            // 
            // txt_Cash_Short_Over_Acct
            // 
            this.txt_Cash_Short_Over_Acct.Location = new System.Drawing.Point(147, 195);
            this.txt_Cash_Short_Over_Acct.Name = "txt_Cash_Short_Over_Acct";
            this.txt_Cash_Short_Over_Acct.PromptChar = '#';
            this.txt_Cash_Short_Over_Acct.Size = new System.Drawing.Size(145, 20);
            this.txt_Cash_Short_Over_Acct.TabIndex = 35;
            // 
            // btn_Cash_Short_Over_Acct
            // 
            this.btn_Cash_Short_Over_Acct.Location = new System.Drawing.Point(298, 194);
            this.btn_Cash_Short_Over_Acct.Name = "btn_Cash_Short_Over_Acct";
            this.btn_Cash_Short_Over_Acct.Size = new System.Drawing.Size(53, 23);
            this.btn_Cash_Short_Over_Acct.TabIndex = 33;
            this.btn_Cash_Short_Over_Acct.Text = "Search";
            this.btn_Cash_Short_Over_Acct.UseVisualStyleBackColor = true;
            this.btn_Cash_Short_Over_Acct.Click += new System.EventHandler(this.btn_Cash_Short_Over_Acct_Click);
            // 
            // lbl_Cash_Short_Over_Acct
            // 
            this.lbl_Cash_Short_Over_Acct.AutoSize = true;
            this.lbl_Cash_Short_Over_Acct.Location = new System.Drawing.Point(8, 199);
            this.lbl_Cash_Short_Over_Acct.Name = "lbl_Cash_Short_Over_Acct";
            this.lbl_Cash_Short_Over_Acct.Size = new System.Drawing.Size(130, 13);
            this.lbl_Cash_Short_Over_Acct.TabIndex = 34;
            this.lbl_Cash_Short_Over_Acct.Text = "Cash Short/Over Account";
            // 
            // txt_CC_Discount_Acct
            // 
            this.txt_CC_Discount_Acct.Location = new System.Drawing.Point(147, 195);
            this.txt_CC_Discount_Acct.Name = "txt_CC_Discount_Acct";
            this.txt_CC_Discount_Acct.PromptChar = '#';
            this.txt_CC_Discount_Acct.Size = new System.Drawing.Size(145, 20);
            this.txt_CC_Discount_Acct.TabIndex = 32;
            this.txt_CC_Discount_Acct.Visible = false;
            // 
            // btn_CC_Discount_Acct
            // 
            this.btn_CC_Discount_Acct.Location = new System.Drawing.Point(298, 194);
            this.btn_CC_Discount_Acct.Name = "btn_CC_Discount_Acct";
            this.btn_CC_Discount_Acct.Size = new System.Drawing.Size(53, 23);
            this.btn_CC_Discount_Acct.TabIndex = 30;
            this.btn_CC_Discount_Acct.Text = "Search";
            this.btn_CC_Discount_Acct.UseVisualStyleBackColor = true;
            this.btn_CC_Discount_Acct.Visible = false;
            this.btn_CC_Discount_Acct.Click += new System.EventHandler(this.btn_CC_Discount_Acct_Click);
            // 
            // lbl_CC_Discount_Acct
            // 
            this.lbl_CC_Discount_Acct.AutoSize = true;
            this.lbl_CC_Discount_Acct.Location = new System.Drawing.Point(8, 198);
            this.lbl_CC_Discount_Acct.Name = "lbl_CC_Discount_Acct";
            this.lbl_CC_Discount_Acct.Size = new System.Drawing.Size(109, 13);
            this.lbl_CC_Discount_Acct.TabIndex = 31;
            this.lbl_CC_Discount_Acct.Text = "CC Discount Account";
            this.lbl_CC_Discount_Acct.Visible = false;
            // 
            // lbl_Bank_Deposit_Type_Name
            // 
            this.lbl_Bank_Deposit_Type_Name.AutoSize = true;
            this.lbl_Bank_Deposit_Type_Name.Location = new System.Drawing.Point(8, 80);
            this.lbl_Bank_Deposit_Type_Name.Name = "lbl_Bank_Deposit_Type_Name";
            this.lbl_Bank_Deposit_Type_Name.Size = new System.Drawing.Size(101, 13);
            this.lbl_Bank_Deposit_Type_Name.TabIndex = 29;
            this.lbl_Bank_Deposit_Type_Name.Text = "Deposit Type Name";
            // 
            // txt_Bank_Deposit_Type_Name
            // 
            this.txt_Bank_Deposit_Type_Name.Location = new System.Drawing.Point(147, 77);
            this.txt_Bank_Deposit_Type_Name.MaxLength = 100;
            this.txt_Bank_Deposit_Type_Name.Name = "txt_Bank_Deposit_Type_Name";
            this.txt_Bank_Deposit_Type_Name.Size = new System.Drawing.Size(204, 20);
            this.txt_Bank_Deposit_Type_Name.TabIndex = 28;
            // 
            // txt_Acct_Deposit_From
            // 
            this.txt_Acct_Deposit_From.Location = new System.Drawing.Point(147, 138);
            this.txt_Acct_Deposit_From.Name = "txt_Acct_Deposit_From";
            this.txt_Acct_Deposit_From.PromptChar = '#';
            this.txt_Acct_Deposit_From.Size = new System.Drawing.Size(145, 20);
            this.txt_Acct_Deposit_From.TabIndex = 27;
            this.txt_Acct_Deposit_From.Leave += new System.EventHandler(this.txt_AccountNumber_Leave);
            // 
            // btn_Acct_Deposit_From
            // 
            this.btn_Acct_Deposit_From.Location = new System.Drawing.Point(298, 137);
            this.btn_Acct_Deposit_From.Name = "btn_Acct_Deposit_From";
            this.btn_Acct_Deposit_From.Size = new System.Drawing.Size(53, 23);
            this.btn_Acct_Deposit_From.TabIndex = 18;
            this.btn_Acct_Deposit_From.Text = "Search";
            this.btn_Acct_Deposit_From.UseVisualStyleBackColor = true;
            this.btn_Acct_Deposit_From.Click += new System.EventHandler(this.btn_Acct_Deposit_From_Click);
            // 
            // lbl_Acct_Deposit_From
            // 
            this.lbl_Acct_Deposit_From.AutoSize = true;
            this.lbl_Acct_Deposit_From.Location = new System.Drawing.Point(8, 142);
            this.lbl_Acct_Deposit_From.Name = "lbl_Acct_Deposit_From";
            this.lbl_Acct_Deposit_From.Size = new System.Drawing.Size(112, 13);
            this.lbl_Acct_Deposit_From.TabIndex = 26;
            this.lbl_Acct_Deposit_From.Text = "Account Deposit From";
            // 
            // lblBank_Deposit_Type_Code
            // 
            this.lblBank_Deposit_Type_Code.AutoSize = true;
            this.lblBank_Deposit_Type_Code.Location = new System.Drawing.Point(8, 51);
            this.lblBank_Deposit_Type_Code.Name = "lblBank_Deposit_Type_Code";
            this.lblBank_Deposit_Type_Code.Size = new System.Drawing.Size(98, 13);
            this.lblBank_Deposit_Type_Code.TabIndex = 23;
            this.lblBank_Deposit_Type_Code.Text = "Deposit Type Code";
            // 
            // txt_Bank_Deposit_Type_Code
            // 
            this.txt_Bank_Deposit_Type_Code.Location = new System.Drawing.Point(147, 48);
            this.txt_Bank_Deposit_Type_Code.MaxLength = 20;
            this.txt_Bank_Deposit_Type_Code.Name = "txt_Bank_Deposit_Type_Code";
            this.txt_Bank_Deposit_Type_Code.Size = new System.Drawing.Size(85, 20);
            this.txt_Bank_Deposit_Type_Code.TabIndex = 22;
            // 
            // lbl_Bank_Deposit_Type_ID
            // 
            this.lbl_Bank_Deposit_Type_ID.AutoSize = true;
            this.lbl_Bank_Deposit_Type_ID.Location = new System.Drawing.Point(8, 22);
            this.lbl_Bank_Deposit_Type_ID.Name = "lbl_Bank_Deposit_Type_ID";
            this.lbl_Bank_Deposit_Type_ID.Size = new System.Drawing.Size(84, 13);
            this.lbl_Bank_Deposit_Type_ID.TabIndex = 21;
            this.lbl_Bank_Deposit_Type_ID.Text = "Deposit Type ID";
            // 
            // txt_Bank_Deposit_Type_ID
            // 
            this.txt_Bank_Deposit_Type_ID.Location = new System.Drawing.Point(147, 19);
            this.txt_Bank_Deposit_Type_ID.Name = "txt_Bank_Deposit_Type_ID";
            this.txt_Bank_Deposit_Type_ID.ReadOnly = true;
            this.txt_Bank_Deposit_Type_ID.Size = new System.Drawing.Size(86, 20);
            this.txt_Bank_Deposit_Type_ID.TabIndex = 20;
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(479, 311);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(69, 31);
            this.btnexit.TabIndex = 56;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnundo
            // 
            this.btnundo.Location = new System.Drawing.Point(371, 311);
            this.btnundo.Name = "btnundo";
            this.btnundo.Size = new System.Drawing.Size(69, 31);
            this.btnundo.TabIndex = 55;
            this.btnundo.Text = "Undo";
            this.btnundo.UseVisualStyleBackColor = true;
            this.btnundo.Click += new System.EventHandler(this.btnundo_Click);
            // 
            // btndelete
            // 
            this.btndelete.Enabled = false;
            this.btndelete.Location = new System.Drawing.Point(0, 6);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(69, 31);
            this.btndelete.TabIndex = 52;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnSavenew
            // 
            this.btnSavenew.Location = new System.Drawing.Point(0, 6);
            this.btnSavenew.Name = "btnSavenew";
            this.btnSavenew.Size = new System.Drawing.Size(69, 31);
            this.btnSavenew.TabIndex = 53;
            this.btnSavenew.Text = "Save";
            this.btnSavenew.UseVisualStyleBackColor = true;
            this.btnSavenew.Click += new System.EventHandler(this.btnSavenew_Click);
            // 
            // Lock88
            // 
            this.Lock88.Controls.Add(this.btn_New);
            this.Lock88.Controls.Add(this.btnSavenew);
            this.Lock88.Location = new System.Drawing.Point(47, 304);
            this.Lock88.Name = "Lock88";
            this.Lock88.Size = new System.Drawing.Size(69, 37);
            this.Lock88.TabIndex = 28;
            this.Lock88.TabStop = false;
            this.Lock88.Tag = "88";
            this.Lock88.Enter += new System.EventHandler(this.Lock88_Enter);
            // 
            // Lock90
            // 
            this.Lock90.Controls.Add(this.btndelete);
            this.Lock90.Location = new System.Drawing.Point(263, 304);
            this.Lock90.Name = "Lock90";
            this.Lock90.Size = new System.Drawing.Size(69, 37);
            this.Lock90.TabIndex = 57;
            this.Lock90.TabStop = false;
            this.Lock90.Tag = "90";
            this.Lock90.Enter += new System.EventHandler(this.Lock90_Enter);
            // 
            // Btnsaveedit
            // 
            this.Btnsaveedit.Location = new System.Drawing.Point(0, 6);
            this.Btnsaveedit.Name = "Btnsaveedit";
            this.Btnsaveedit.Size = new System.Drawing.Size(69, 31);
            this.Btnsaveedit.TabIndex = 51;
            this.Btnsaveedit.Text = "Save";
            this.Btnsaveedit.UseVisualStyleBackColor = true;
            this.Btnsaveedit.Click += new System.EventHandler(this.Btnsaveedit_Click);
            // 
            // btnedit
            // 
            this.btnedit.Enabled = false;
            this.btnedit.Location = new System.Drawing.Point(0, 6);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(69, 31);
            this.btnedit.TabIndex = 54;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // Lock89
            // 
            this.Lock89.Controls.Add(this.btnedit);
            this.Lock89.Controls.Add(this.Btnsaveedit);
            this.Lock89.Location = new System.Drawing.Point(155, 304);
            this.Lock89.Name = "Lock89";
            this.Lock89.Size = new System.Drawing.Size(69, 37);
            this.Lock89.TabIndex = 58;
            this.Lock89.TabStop = false;
            this.Lock89.Tag = "89";
            this.Lock89.Enter += new System.EventHandler(this.Lock89_Enter);
            // 
            // Bank_Deposit_Type
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(620, 370);
            this.ControlBox = false;
            this.Controls.Add(this.Lock89);
            this.Controls.Add(this.Lock90);
            this.Controls.Add(this.Lock88);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnundo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Bank_Deposit_Type";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Deposit Type";
            this.Load += new System.EventHandler(this.Bank_Deposit_Type_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Lock88.ResumeLayout(false);
            this.Lock90.ResumeLayout(false);
            this.Lock89.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txt_Acct_Deposit_From;
        private System.Windows.Forms.Label lbl_Acct_Deposit_From;
        private System.Windows.Forms.Label lblBank_Deposit_Type_Code;
        private System.Windows.Forms.TextBox txt_Bank_Deposit_Type_Code;
        private System.Windows.Forms.Label lbl_Bank_Deposit_Type_ID;
        private System.Windows.Forms.TextBox txt_Bank_Deposit_Type_ID;
        private System.Windows.Forms.Button btn_Acct_Deposit_From;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnundo;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnSavenew;
        private System.Windows.Forms.GroupBox Lock90;
        private System.Windows.Forms.GroupBox Lock88;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankAccountIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankAccountCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankAccountNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lbl_Bank_Deposit_Type_Name;
        private System.Windows.Forms.TextBox txt_Bank_Deposit_Type_Name;
        private System.Windows.Forms.MaskedTextBox txt_Cash_Short_Over_Acct;
        private System.Windows.Forms.Button btn_Cash_Short_Over_Acct;
        private System.Windows.Forms.Label lbl_Cash_Short_Over_Acct;
        private System.Windows.Forms.MaskedTextBox txt_CC_Discount_Acct;
        private System.Windows.Forms.Button btn_CC_Discount_Acct;
        private System.Windows.Forms.Label lbl_CC_Discount_Acct;
        private System.Windows.Forms.ComboBox cb_Bank_Account_ID;
        private System.Windows.Forms.Label lbl_Bank_Account_ID;
        private System.Windows.Forms.Label lbl_CC_Fees;
        private System.Windows.Forms.TextBox txt_CC_Fees;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankDepositTypeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankDepositTypeCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankDepositTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox chkCredit_Card_Deposit;
        private System.Windows.Forms.CheckBox chkOverride_Fees;
        private System.Windows.Forms.GroupBox Lock89;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button Btnsaveedit;
    }
}