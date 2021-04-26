namespace Accounting_GeneralLedger
{
    partial class Bank_Account_Setup
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
            this.bankAccountIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankAccountCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankAccountNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.lbl_Deduction_Slip_Format = new System.Windows.Forms.Label();
            this.txt_Deduction_Slip_Format = new System.Windows.Forms.TextBox();
            this.lbl_Check_Format = new System.Windows.Forms.Label();
            this.txt_Check_Format = new System.Windows.Forms.TextBox();
            this.cb_AR_Checks_Tran_code = new System.Windows.Forms.ComboBox();
            this.lbl_AR_Checks_Tran_code = new System.Windows.Forms.Label();
            this.txt_Interest_Earned_Account = new System.Windows.Forms.MaskedTextBox();
            this.btn_Interest_Earned_Account = new System.Windows.Forms.Button();
            this.lbl_Interest_Earned_Account = new System.Windows.Forms.Label();
            this.txt_Service_Charge_Account = new System.Windows.Forms.MaskedTextBox();
            this.btn_Service_Charge_Account = new System.Windows.Forms.Button();
            this.lbl_Service_Charge_Account = new System.Windows.Forms.Label();
            this.lbl_Bank_Account_Name = new System.Windows.Forms.Label();
            this.txt_Bank_Account_Name = new System.Windows.Forms.TextBox();
            this.txt_Bank_GL_Account = new System.Windows.Forms.MaskedTextBox();
            this.btn_Bank_GL_Account = new System.Windows.Forms.Button();
            this.lbl_Bank_GL_Account = new System.Windows.Forms.Label();
            this.lblBank_Account_Code = new System.Windows.Forms.Label();
            this.txt_Bank_Account_Code = new System.Windows.Forms.TextBox();
            this.lbl_Bank_Account_ID = new System.Windows.Forms.Label();
            this.txt_Bank_Account_ID = new System.Windows.Forms.TextBox();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnundo = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.Btnsaveedit = new System.Windows.Forms.Button();
            this.btnSavenew = new System.Windows.Forms.Button();
            this.Lock88 = new System.Windows.Forms.GroupBox();
            this.Lock90 = new System.Windows.Forms.GroupBox();
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
            this.bankAccountIDDataGridViewTextBoxColumn,
            this.bankAccountCodeDataGridViewTextBoxColumn,
            this.bankAccountNameDataGridViewTextBoxColumn});
            this.dgv.DataMember = "Bank_Account_Setup";
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
            // bankAccountIDDataGridViewTextBoxColumn
            // 
            this.bankAccountIDDataGridViewTextBoxColumn.DataPropertyName = "Bank_Account_ID";
            this.bankAccountIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.bankAccountIDDataGridViewTextBoxColumn.Name = "bankAccountIDDataGridViewTextBoxColumn";
            this.bankAccountIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.bankAccountIDDataGridViewTextBoxColumn.Width = 43;
            // 
            // bankAccountCodeDataGridViewTextBoxColumn
            // 
            this.bankAccountCodeDataGridViewTextBoxColumn.DataPropertyName = "Bank_Account_Code";
            this.bankAccountCodeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.bankAccountCodeDataGridViewTextBoxColumn.Name = "bankAccountCodeDataGridViewTextBoxColumn";
            this.bankAccountCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.bankAccountCodeDataGridViewTextBoxColumn.Width = 57;
            // 
            // bankAccountNameDataGridViewTextBoxColumn
            // 
            this.bankAccountNameDataGridViewTextBoxColumn.DataPropertyName = "Bank_Account_Name";
            this.bankAccountNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.bankAccountNameDataGridViewTextBoxColumn.Name = "bankAccountNameDataGridViewTextBoxColumn";
            this.bankAccountNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.bankAccountNameDataGridViewTextBoxColumn.Width = 60;
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
            this.menuStrip1.Size = new System.Drawing.Size(639, 24);
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
            this.btn_New.Location = new System.Drawing.Point(80, 311);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(69, 31);
            this.btn_New.TabIndex = 16;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_Deduction_Slip_Format);
            this.groupBox1.Controls.Add(this.txt_Deduction_Slip_Format);
            this.groupBox1.Controls.Add(this.lbl_Check_Format);
            this.groupBox1.Controls.Add(this.txt_Check_Format);
            this.groupBox1.Controls.Add(this.cb_AR_Checks_Tran_code);
            this.groupBox1.Controls.Add(this.lbl_AR_Checks_Tran_code);
            this.groupBox1.Controls.Add(this.txt_Interest_Earned_Account);
            this.groupBox1.Controls.Add(this.btn_Interest_Earned_Account);
            this.groupBox1.Controls.Add(this.lbl_Interest_Earned_Account);
            this.groupBox1.Controls.Add(this.txt_Service_Charge_Account);
            this.groupBox1.Controls.Add(this.btn_Service_Charge_Account);
            this.groupBox1.Controls.Add(this.lbl_Service_Charge_Account);
            this.groupBox1.Controls.Add(this.lbl_Bank_Account_Name);
            this.groupBox1.Controls.Add(this.txt_Bank_Account_Name);
            this.groupBox1.Controls.Add(this.txt_Bank_GL_Account);
            this.groupBox1.Controls.Add(this.btn_Bank_GL_Account);
            this.groupBox1.Controls.Add(this.lbl_Bank_GL_Account);
            this.groupBox1.Controls.Add(this.lblBank_Account_Code);
            this.groupBox1.Controls.Add(this.txt_Bank_Account_Code);
            this.groupBox1.Controls.Add(this.lbl_Bank_Account_ID);
            this.groupBox1.Controls.Add(this.txt_Bank_Account_ID);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(254, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 295);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.EnabledChanged += new System.EventHandler(this.groupBox1_EnabledChanged);
            // 
            // lbl_Deduction_Slip_Format
            // 
            this.lbl_Deduction_Slip_Format.AutoSize = true;
            this.lbl_Deduction_Slip_Format.Location = new System.Drawing.Point(8, 254);
            this.lbl_Deduction_Slip_Format.Name = "lbl_Deduction_Slip_Format";
            this.lbl_Deduction_Slip_Format.Size = new System.Drawing.Size(111, 13);
            this.lbl_Deduction_Slip_Format.TabIndex = 41;
            this.lbl_Deduction_Slip_Format.Text = "Deduction Slip Format";
            // 
            // txt_Deduction_Slip_Format
            // 
            this.txt_Deduction_Slip_Format.Location = new System.Drawing.Point(147, 251);
            this.txt_Deduction_Slip_Format.MaxLength = 50;
            this.txt_Deduction_Slip_Format.Name = "txt_Deduction_Slip_Format";
            this.txt_Deduction_Slip_Format.Size = new System.Drawing.Size(204, 20);
            this.txt_Deduction_Slip_Format.TabIndex = 40;
            // 
            // lbl_Check_Format
            // 
            this.lbl_Check_Format.AutoSize = true;
            this.lbl_Check_Format.Location = new System.Drawing.Point(8, 225);
            this.lbl_Check_Format.Name = "lbl_Check_Format";
            this.lbl_Check_Format.Size = new System.Drawing.Size(73, 13);
            this.lbl_Check_Format.TabIndex = 39;
            this.lbl_Check_Format.Text = "Check Format";
            // 
            // txt_Check_Format
            // 
            this.txt_Check_Format.Location = new System.Drawing.Point(147, 222);
            this.txt_Check_Format.MaxLength = 50;
            this.txt_Check_Format.Name = "txt_Check_Format";
            this.txt_Check_Format.Size = new System.Drawing.Size(204, 20);
            this.txt_Check_Format.TabIndex = 38;
            // 
            // cb_AR_Checks_Tran_code
            // 
            this.cb_AR_Checks_Tran_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_AR_Checks_Tran_code.FormattingEnabled = true;
            this.cb_AR_Checks_Tran_code.Location = new System.Drawing.Point(147, 193);
            this.cb_AR_Checks_Tran_code.Name = "cb_AR_Checks_Tran_code";
            this.cb_AR_Checks_Tran_code.Size = new System.Drawing.Size(116, 21);
            this.cb_AR_Checks_Tran_code.TabIndex = 37;
            // 
            // lbl_AR_Checks_Tran_code
            // 
            this.lbl_AR_Checks_Tran_code.AutoSize = true;
            this.lbl_AR_Checks_Tran_code.Location = new System.Drawing.Point(8, 196);
            this.lbl_AR_Checks_Tran_code.Name = "lbl_AR_Checks_Tran_code";
            this.lbl_AR_Checks_Tran_code.Size = new System.Drawing.Size(113, 13);
            this.lbl_AR_Checks_Tran_code.TabIndex = 36;
            this.lbl_AR_Checks_Tran_code.Text = "AR Checks Tran code";
            // 
            // txt_Interest_Earned_Account
            // 
            this.txt_Interest_Earned_Account.Location = new System.Drawing.Point(147, 164);
            this.txt_Interest_Earned_Account.Name = "txt_Interest_Earned_Account";
            this.txt_Interest_Earned_Account.PromptChar = '#';
            this.txt_Interest_Earned_Account.Size = new System.Drawing.Size(145, 20);
            this.txt_Interest_Earned_Account.TabIndex = 35;
            // 
            // btn_Interest_Earned_Account
            // 
            this.btn_Interest_Earned_Account.Location = new System.Drawing.Point(298, 163);
            this.btn_Interest_Earned_Account.Name = "btn_Interest_Earned_Account";
            this.btn_Interest_Earned_Account.Size = new System.Drawing.Size(53, 23);
            this.btn_Interest_Earned_Account.TabIndex = 33;
            this.btn_Interest_Earned_Account.Text = "Search";
            this.btn_Interest_Earned_Account.UseVisualStyleBackColor = true;
            this.btn_Interest_Earned_Account.Click += new System.EventHandler(this.btn_Interest_Earned_Account_Click);
            // 
            // lbl_Interest_Earned_Account
            // 
            this.lbl_Interest_Earned_Account.AutoSize = true;
            this.lbl_Interest_Earned_Account.Location = new System.Drawing.Point(8, 167);
            this.lbl_Interest_Earned_Account.Name = "lbl_Interest_Earned_Account";
            this.lbl_Interest_Earned_Account.Size = new System.Drawing.Size(122, 13);
            this.lbl_Interest_Earned_Account.TabIndex = 34;
            this.lbl_Interest_Earned_Account.Text = "Interest Earned Account";
            // 
            // txt_Service_Charge_Account
            // 
            this.txt_Service_Charge_Account.Location = new System.Drawing.Point(147, 135);
            this.txt_Service_Charge_Account.Name = "txt_Service_Charge_Account";
            this.txt_Service_Charge_Account.PromptChar = '#';
            this.txt_Service_Charge_Account.Size = new System.Drawing.Size(145, 20);
            this.txt_Service_Charge_Account.TabIndex = 32;
            // 
            // btn_Service_Charge_Account
            // 
            this.btn_Service_Charge_Account.Location = new System.Drawing.Point(300, 134);
            this.btn_Service_Charge_Account.Name = "btn_Service_Charge_Account";
            this.btn_Service_Charge_Account.Size = new System.Drawing.Size(53, 23);
            this.btn_Service_Charge_Account.TabIndex = 30;
            this.btn_Service_Charge_Account.Text = "Search";
            this.btn_Service_Charge_Account.UseVisualStyleBackColor = true;
            this.btn_Service_Charge_Account.Click += new System.EventHandler(this.btn_Service_Charge_Account_Click);
            // 
            // lbl_Service_Charge_Account
            // 
            this.lbl_Service_Charge_Account.AutoSize = true;
            this.lbl_Service_Charge_Account.Location = new System.Drawing.Point(8, 138);
            this.lbl_Service_Charge_Account.Name = "lbl_Service_Charge_Account";
            this.lbl_Service_Charge_Account.Size = new System.Drawing.Size(123, 13);
            this.lbl_Service_Charge_Account.TabIndex = 31;
            this.lbl_Service_Charge_Account.Text = "Service Charge Account";
            // 
            // lbl_Bank_Account_Name
            // 
            this.lbl_Bank_Account_Name.AutoSize = true;
            this.lbl_Bank_Account_Name.Location = new System.Drawing.Point(8, 80);
            this.lbl_Bank_Account_Name.Name = "lbl_Bank_Account_Name";
            this.lbl_Bank_Account_Name.Size = new System.Drawing.Size(106, 13);
            this.lbl_Bank_Account_Name.TabIndex = 29;
            this.lbl_Bank_Account_Name.Text = "Bank Account Name";
            // 
            // txt_Bank_Account_Name
            // 
            this.txt_Bank_Account_Name.Location = new System.Drawing.Point(147, 77);
            this.txt_Bank_Account_Name.MaxLength = 100;
            this.txt_Bank_Account_Name.Name = "txt_Bank_Account_Name";
            this.txt_Bank_Account_Name.Size = new System.Drawing.Size(204, 20);
            this.txt_Bank_Account_Name.TabIndex = 28;
            // 
            // txt_Bank_GL_Account
            // 
            this.txt_Bank_GL_Account.Location = new System.Drawing.Point(147, 106);
            this.txt_Bank_GL_Account.Name = "txt_Bank_GL_Account";
            this.txt_Bank_GL_Account.PromptChar = '#';
            this.txt_Bank_GL_Account.Size = new System.Drawing.Size(145, 20);
            this.txt_Bank_GL_Account.TabIndex = 27;
            this.txt_Bank_GL_Account.Leave += new System.EventHandler(this.txt_AccountNumber_Leave);
            // 
            // btn_Bank_GL_Account
            // 
            this.btn_Bank_GL_Account.Location = new System.Drawing.Point(300, 105);
            this.btn_Bank_GL_Account.Name = "btn_Bank_GL_Account";
            this.btn_Bank_GL_Account.Size = new System.Drawing.Size(53, 23);
            this.btn_Bank_GL_Account.TabIndex = 18;
            this.btn_Bank_GL_Account.Text = "Search";
            this.btn_Bank_GL_Account.UseVisualStyleBackColor = true;
            this.btn_Bank_GL_Account.Click += new System.EventHandler(this.btn_Bank_GL_Account_Click);
            // 
            // lbl_Bank_GL_Account
            // 
            this.lbl_Bank_GL_Account.AutoSize = true;
            this.lbl_Bank_GL_Account.Location = new System.Drawing.Point(8, 109);
            this.lbl_Bank_GL_Account.Name = "lbl_Bank_GL_Account";
            this.lbl_Bank_GL_Account.Size = new System.Drawing.Size(92, 13);
            this.lbl_Bank_GL_Account.TabIndex = 26;
            this.lbl_Bank_GL_Account.Text = "Bank GL Account";
            // 
            // lblBank_Account_Code
            // 
            this.lblBank_Account_Code.AutoSize = true;
            this.lblBank_Account_Code.Location = new System.Drawing.Point(8, 51);
            this.lblBank_Account_Code.Name = "lblBank_Account_Code";
            this.lblBank_Account_Code.Size = new System.Drawing.Size(103, 13);
            this.lblBank_Account_Code.TabIndex = 23;
            this.lblBank_Account_Code.Text = "Bank Account Code";
            // 
            // txt_Bank_Account_Code
            // 
            this.txt_Bank_Account_Code.Location = new System.Drawing.Point(147, 48);
            this.txt_Bank_Account_Code.MaxLength = 20;
            this.txt_Bank_Account_Code.Name = "txt_Bank_Account_Code";
            this.txt_Bank_Account_Code.Size = new System.Drawing.Size(85, 20);
            this.txt_Bank_Account_Code.TabIndex = 22;
            // 
            // lbl_Bank_Account_ID
            // 
            this.lbl_Bank_Account_ID.AutoSize = true;
            this.lbl_Bank_Account_ID.Location = new System.Drawing.Point(8, 22);
            this.lbl_Bank_Account_ID.Name = "lbl_Bank_Account_ID";
            this.lbl_Bank_Account_ID.Size = new System.Drawing.Size(89, 13);
            this.lbl_Bank_Account_ID.TabIndex = 21;
            this.lbl_Bank_Account_ID.Text = "Bank Account ID";
            // 
            // txt_Bank_Account_ID
            // 
            this.txt_Bank_Account_ID.Location = new System.Drawing.Point(147, 19);
            this.txt_Bank_Account_ID.Name = "txt_Bank_Account_ID";
            this.txt_Bank_Account_ID.ReadOnly = true;
            this.txt_Bank_Account_ID.Size = new System.Drawing.Size(86, 20);
            this.txt_Bank_Account_ID.TabIndex = 20;
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
            // Bank_Account_Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(620, 370);
            this.ControlBox = false;
            this.Controls.Add(this.btn_New);
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
            this.Name = "Bank_Account_Setup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Account Setup";
            this.Load += new System.EventHandler(this.Bank_Account_Setup_Load);
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
        private System.Windows.Forms.MaskedTextBox txt_Bank_GL_Account;
        private System.Windows.Forms.Label lbl_Bank_GL_Account;
        private System.Windows.Forms.Label lblBank_Account_Code;
        private System.Windows.Forms.TextBox txt_Bank_Account_Code;
        private System.Windows.Forms.Label lbl_Bank_Account_ID;
        private System.Windows.Forms.TextBox txt_Bank_Account_ID;
        private System.Windows.Forms.Button btn_Bank_GL_Account;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnundo;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button Btnsaveedit;
        private System.Windows.Forms.Button btnSavenew;
        private System.Windows.Forms.GroupBox Lock89;
        private System.Windows.Forms.GroupBox Lock90;
        private System.Windows.Forms.GroupBox Lock88;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankAccountIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankAccountCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankAccountNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lbl_Bank_Account_Name;
        private System.Windows.Forms.TextBox txt_Bank_Account_Name;
        private System.Windows.Forms.MaskedTextBox txt_Interest_Earned_Account;
        private System.Windows.Forms.Button btn_Interest_Earned_Account;
        private System.Windows.Forms.Label lbl_Interest_Earned_Account;
        private System.Windows.Forms.MaskedTextBox txt_Service_Charge_Account;
        private System.Windows.Forms.Button btn_Service_Charge_Account;
        private System.Windows.Forms.Label lbl_Service_Charge_Account;
        private System.Windows.Forms.ComboBox cb_AR_Checks_Tran_code;
        private System.Windows.Forms.Label lbl_AR_Checks_Tran_code;
        private System.Windows.Forms.Label lbl_Deduction_Slip_Format;
        private System.Windows.Forms.TextBox txt_Deduction_Slip_Format;
        private System.Windows.Forms.Label lbl_Check_Format;
        private System.Windows.Forms.TextBox txt_Check_Format;
    }
}