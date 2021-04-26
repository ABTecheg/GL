namespace Accounting_GeneralLedger
{
    partial class APTransactions
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
            this.label8 = new System.Windows.Forms.Label();
            this.dgv_Invoices = new System.Windows.Forms.DataGridView();
            this.BatchInvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupInvoice = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txt_TaxValue = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txt_AccountsCurrentBalance = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txt_DiscountValue = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txt_DueDays = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.checkBox_Tax = new System.Windows.Forms.CheckBox();
            this.cb_StartDate = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txt_SalesTaxAmount = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_NetInvoiceAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_DeliveryType = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_InvoiceAmount = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label_NonTaxableReason = new System.Windows.Forms.Label();
            this.txt_NonTaxableReason = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_DepartmentCode = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.label_Currency = new System.Windows.Forms.Label();
            this.cb_Currency = new System.Windows.Forms.ComboBox();
            this.label_CurrencyRate = new System.Windows.Forms.Label();
            this.txt_CurrencyRate = new System.Windows.Forms.TextBox();
            this.txt_VendorCode = new System.Windows.Forms.TextBox();
            this.cb_VendorTerms = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.checkBox_Currency = new System.Windows.Forms.CheckBox();
            this.cb_ProjectCode = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cb_InvoiceStatus = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_PONumber = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cb_TransactionType = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.DTP_InvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_InvoiceNumber = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_VendorName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Reference = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.dgv_InvoiceDetails = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Lock74 = new System.Windows.Forms.GroupBox();
            this.btndelete = new System.Windows.Forms.Button();
            this.Lock73 = new System.Windows.Forms.GroupBox();
            this.btnedit = new System.Windows.Forms.Button();
            this.Btnsaveedit = new System.Windows.Forms.Button();
            this.btnundo = new System.Windows.Forms.Button();
            this.Lock72 = new System.Windows.Forms.GroupBox();
            this.btn_New = new System.Windows.Forms.Button();
            this.btnSavenew = new System.Windows.Forms.Button();
            this.groupBatch = new System.Windows.Forms.GroupBox();
            this.Lock69 = new System.Windows.Forms.GroupBox();
            this.btneditbatch = new System.Windows.Forms.Button();
            this.btn_Saveeditbatch = new System.Windows.Forms.Button();
            this.Lock70 = new System.Windows.Forms.GroupBox();
            this.btndeletebatch = new System.Windows.Forms.Button();
            this.Lock71 = new System.Windows.Forms.GroupBox();
            this.btnposted = new System.Windows.Forms.Button();
            this.btnundobatch = new System.Windows.Forms.Button();
            this.btnfindbatch = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.Lock68 = new System.Windows.Forms.GroupBox();
            this.btn_newbatch = new System.Windows.Forms.Button();
            this.btn_savenewbatch = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtPostedDate = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtstats = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtBatchNum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_UserID = new System.Windows.Forms.TextBox();
            this.txt_Period = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Balance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DTP_Date = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Description = new System.Windows.Forms.TextBox();
            this.txt_APBatchNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Err = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Invoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupInvoice.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InvoiceDetails)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.Lock74.SuspendLayout();
            this.Lock73.SuspendLayout();
            this.Lock72.SuspendLayout();
            this.groupBatch.SuspendLayout();
            this.Lock69.SuspendLayout();
            this.Lock70.SuspendLayout();
            this.Lock71.SuspendLayout();
            this.Lock68.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Err)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(9, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Batch Details";
            // 
            // dgv_Invoices
            // 
            this.dgv_Invoices.AllowUserToAddRows = false;
            this.dgv_Invoices.AllowUserToDeleteRows = false;
            this.dgv_Invoices.AutoGenerateColumns = false;
            this.dgv_Invoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_Invoices.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_Invoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Invoices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BatchInvoiceID,
            this.vendorCodeDataGridViewTextBoxColumn,
            this.vendorNameDataGridViewTextBoxColumn});
            this.dgv_Invoices.DataMember = "APTrans";
            this.dgv_Invoices.DataSource = this.dbAccountingProjectDSBindingSource;
            this.dgv_Invoices.Location = new System.Drawing.Point(11, 124);
            this.dgv_Invoices.MultiSelect = false;
            this.dgv_Invoices.Name = "dgv_Invoices";
            this.dgv_Invoices.ReadOnly = true;
            this.dgv_Invoices.RowHeadersWidth = 25;
            this.dgv_Invoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Invoices.Size = new System.Drawing.Size(348, 564);
            this.dgv_Invoices.TabIndex = 16;
            this.dgv_Invoices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Invoices_CellClick);
            // 
            // BatchInvoiceID
            // 
            this.BatchInvoiceID.DataPropertyName = "BatchInvoiceID";
            this.BatchInvoiceID.HeaderText = "BatchInvoiceID";
            this.BatchInvoiceID.Name = "BatchInvoiceID";
            this.BatchInvoiceID.ReadOnly = true;
            this.BatchInvoiceID.Width = 106;
            // 
            // vendorCodeDataGridViewTextBoxColumn
            // 
            this.vendorCodeDataGridViewTextBoxColumn.DataPropertyName = "VendorCode";
            this.vendorCodeDataGridViewTextBoxColumn.HeaderText = "VendorCode";
            this.vendorCodeDataGridViewTextBoxColumn.Name = "vendorCodeDataGridViewTextBoxColumn";
            this.vendorCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorCodeDataGridViewTextBoxColumn.Width = 91;
            // 
            // vendorNameDataGridViewTextBoxColumn
            // 
            this.vendorNameDataGridViewTextBoxColumn.DataPropertyName = "VendorName";
            this.vendorNameDataGridViewTextBoxColumn.HeaderText = "VendorName";
            this.vendorNameDataGridViewTextBoxColumn.Name = "vendorNameDataGridViewTextBoxColumn";
            this.vendorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorNameDataGridViewTextBoxColumn.Width = 94;
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
            this.menuStrip1.Size = new System.Drawing.Size(1011, 24);
            this.menuStrip1.TabIndex = 44;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem,
            this.postToolStripMenuItem,
            this.toolStripSeparator1,
            this.insertToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deletToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveChangesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.findToolStripMenuItem.Text = "Find";
            // 
            // postToolStripMenuItem
            // 
            this.postToolStripMenuItem.Name = "postToolStripMenuItem";
            this.postToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.postToolStripMenuItem.Text = "Post";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(144, 6);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.insertToolStripMenuItem.Text = "Insert";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // deletToolStripMenuItem
            // 
            this.deletToolStripMenuItem.Name = "deletToolStripMenuItem";
            this.deletToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.deletToolStripMenuItem.Text = "Delete";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(144, 6);
            // 
            // saveChangesToolStripMenuItem
            // 
            this.saveChangesToolStripMenuItem.Name = "saveChangesToolStripMenuItem";
            this.saveChangesToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.saveChangesToolStripMenuItem.Text = "Save Changes";
            // 
            // groupInvoice
            // 
            this.groupInvoice.Controls.Add(this.groupBox2);
            this.groupInvoice.Controls.Add(this.groupBox1);
            this.groupInvoice.Controls.Add(this.label21);
            this.groupInvoice.Controls.Add(this.dgv_InvoiceDetails);
            this.groupInvoice.Enabled = false;
            this.groupInvoice.Location = new System.Drawing.Point(366, 164);
            this.groupInvoice.Name = "groupInvoice";
            this.groupInvoice.Size = new System.Drawing.Size(638, 526);
            this.groupInvoice.TabIndex = 71;
            this.groupInvoice.TabStop = false;
            this.groupInvoice.Text = "Invoice";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.txt_TaxValue);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.txt_AccountsCurrentBalance);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.txt_DiscountValue);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.txt_DueDays);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.checkBox_Tax);
            this.groupBox2.Controls.Add(this.cb_StartDate);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.txt_SalesTaxAmount);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.txt_NetInvoiceAmount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cb_DeliveryType);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.txt_InvoiceAmount);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label_NonTaxableReason);
            this.groupBox2.Controls.Add(this.txt_NonTaxableReason);
            this.groupBox2.Location = new System.Drawing.Point(7, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(620, 140);
            this.groupBox2.TabIndex = 71;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Invoice Payment Information";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(260, 117);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(0, 13);
            this.label28.TabIndex = 68;
            // 
            // txt_TaxValue
            // 
            this.txt_TaxValue.Location = new System.Drawing.Point(337, 113);
            this.txt_TaxValue.Name = "txt_TaxValue";
            this.txt_TaxValue.ReadOnly = true;
            this.txt_TaxValue.Size = new System.Drawing.Size(137, 20);
            this.txt_TaxValue.TabIndex = 67;
            this.txt_TaxValue.Text = "0";
            this.txt_TaxValue.TextChanged += new System.EventHandler(this.txt_TaxValue_TextChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(258, 114);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(64, 13);
            this.label27.TabIndex = 66;
            this.label27.Text = "Tax Amount";
            // 
            // txt_AccountsCurrentBalance
            // 
            this.txt_AccountsCurrentBalance.Location = new System.Drawing.Point(107, 114);
            this.txt_AccountsCurrentBalance.Name = "txt_AccountsCurrentBalance";
            this.txt_AccountsCurrentBalance.ReadOnly = true;
            this.txt_AccountsCurrentBalance.Size = new System.Drawing.Size(137, 20);
            this.txt_AccountsCurrentBalance.TabIndex = 65;
            this.txt_AccountsCurrentBalance.Text = "0";
            this.txt_AccountsCurrentBalance.TextChanged += new System.EventHandler(this.txt_AccountsCurrentBalance_TextChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(9, 114);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(46, 13);
            this.label25.TabIndex = 64;
            this.label25.Text = "Balance";
            // 
            // txt_DiscountValue
            // 
            this.txt_DiscountValue.Location = new System.Drawing.Point(107, 66);
            this.txt_DiscountValue.Name = "txt_DiscountValue";
            this.txt_DiscountValue.Size = new System.Drawing.Size(138, 20);
            this.txt_DiscountValue.TabIndex = 65;
            this.txt_DiscountValue.Text = "0";
            this.txt_DiscountValue.TextChanged += new System.EventHandler(this.txt_DiscountValue_TextChanged);
            this.txt_DiscountValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DiscountValue_KeyPress);
            this.txt_DiscountValue.Leave += new System.EventHandler(this.txt_DiscountValue_Leave);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(9, 63);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(79, 13);
            this.label26.TabIndex = 64;
            this.label26.Text = "Discount Value";
            // 
            // txt_DueDays
            // 
            this.txt_DueDays.Enabled = false;
            this.txt_DueDays.Location = new System.Drawing.Point(337, 41);
            this.txt_DueDays.Name = "txt_DueDays";
            this.txt_DueDays.Size = new System.Drawing.Size(137, 20);
            this.txt_DueDays.TabIndex = 60;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label24.Location = new System.Drawing.Point(258, 44);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(54, 13);
            this.label24.TabIndex = 59;
            this.label24.Text = "Due Days";
            // 
            // checkBox_Tax
            // 
            this.checkBox_Tax.AutoSize = true;
            this.checkBox_Tax.Location = new System.Drawing.Point(338, 64);
            this.checkBox_Tax.Name = "checkBox_Tax";
            this.checkBox_Tax.Size = new System.Drawing.Size(84, 17);
            this.checkBox_Tax.TabIndex = 61;
            this.checkBox_Tax.Text = "NonTaxable";
            this.checkBox_Tax.UseVisualStyleBackColor = true;
            this.checkBox_Tax.CheckedChanged += new System.EventHandler(this.checkBox_Tax_CheckedChanged);
            // 
            // cb_StartDate
            // 
            this.cb_StartDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_StartDate.FormattingEnabled = true;
            this.cb_StartDate.Items.AddRange(new object[] {
            "BatchTransactionDate",
            "Invoice Date"});
            this.cb_StartDate.Location = new System.Drawing.Point(337, 18);
            this.cb_StartDate.Name = "cb_StartDate";
            this.cb_StartDate.Size = new System.Drawing.Size(137, 21);
            this.cb_StartDate.TabIndex = 58;
            this.cb_StartDate.SelectedIndexChanged += new System.EventHandler(this.cb_StartDate_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label23.Location = new System.Drawing.Point(260, 19);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(51, 13);
            this.label23.TabIndex = 57;
            this.label23.Text = "Pay Date";
            // 
            // txt_SalesTaxAmount
            // 
            this.txt_SalesTaxAmount.Location = new System.Drawing.Point(107, 41);
            this.txt_SalesTaxAmount.Name = "txt_SalesTaxAmount";
            this.txt_SalesTaxAmount.Size = new System.Drawing.Size(138, 20);
            this.txt_SalesTaxAmount.TabIndex = 56;
            this.txt_SalesTaxAmount.Text = "0";
            this.txt_SalesTaxAmount.TextChanged += new System.EventHandler(this.txt_SalesTaxAmount_TextChanged);
            this.txt_SalesTaxAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SalesTaxAmount_KeyPress);
            this.txt_SalesTaxAmount.Leave += new System.EventHandler(this.txt_SalesTaxAmount_Leave);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label22.Location = new System.Drawing.Point(6, 41);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(93, 13);
            this.label22.TabIndex = 55;
            this.label22.Text = "Sales Tax Amount";
            // 
            // txt_NetInvoiceAmount
            // 
            this.txt_NetInvoiceAmount.Location = new System.Drawing.Point(107, 18);
            this.txt_NetInvoiceAmount.Name = "txt_NetInvoiceAmount";
            this.txt_NetInvoiceAmount.Size = new System.Drawing.Size(138, 20);
            this.txt_NetInvoiceAmount.TabIndex = 54;
            this.txt_NetInvoiceAmount.Text = "0";
            this.txt_NetInvoiceAmount.TextChanged += new System.EventHandler(this.txt_NetInvoiceAmount_TextChanged);
            this.txt_NetInvoiceAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_NetInvoiceAmount_KeyPress);
            this.txt_NetInvoiceAmount.Leave += new System.EventHandler(this.txt_NetInvoiceAmount_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(-1, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "Net Invoice Amount";
            // 
            // cb_DeliveryType
            // 
            this.cb_DeliveryType.FormattingEnabled = true;
            this.cb_DeliveryType.Location = new System.Drawing.Point(337, 86);
            this.cb_DeliveryType.Name = "cb_DeliveryType";
            this.cb_DeliveryType.Size = new System.Drawing.Size(137, 21);
            this.cb_DeliveryType.TabIndex = 38;
            this.cb_DeliveryType.SelectedIndexChanged += new System.EventHandler(this.cb_DeliveryType_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label19.Location = new System.Drawing.Point(258, 90);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 13);
            this.label19.TabIndex = 37;
            this.label19.Text = "Delivery Type";
            // 
            // txt_InvoiceAmount
            // 
            this.txt_InvoiceAmount.Location = new System.Drawing.Point(107, 91);
            this.txt_InvoiceAmount.MaxLength = 30;
            this.txt_InvoiceAmount.Name = "txt_InvoiceAmount";
            this.txt_InvoiceAmount.ReadOnly = true;
            this.txt_InvoiceAmount.Size = new System.Drawing.Size(137, 20);
            this.txt_InvoiceAmount.TabIndex = 32;
            this.txt_InvoiceAmount.Text = "0";
            this.txt_InvoiceAmount.TextChanged += new System.EventHandler(this.txt_InvoiceAmount_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label16.Location = new System.Drawing.Point(6, 90);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "Invoice Amount";
            // 
            // label_NonTaxableReason
            // 
            this.label_NonTaxableReason.AutoSize = true;
            this.label_NonTaxableReason.Location = new System.Drawing.Point(337, 91);
            this.label_NonTaxableReason.Name = "label_NonTaxableReason";
            this.label_NonTaxableReason.Size = new System.Drawing.Size(105, 13);
            this.label_NonTaxableReason.TabIndex = 62;
            this.label_NonTaxableReason.Text = "NonTaxable Reason";
            this.label_NonTaxableReason.Visible = false;
            // 
            // txt_NonTaxableReason
            // 
            this.txt_NonTaxableReason.FormattingEnabled = true;
            this.txt_NonTaxableReason.Location = new System.Drawing.Point(337, 112);
            this.txt_NonTaxableReason.Name = "txt_NonTaxableReason";
            this.txt_NonTaxableReason.Size = new System.Drawing.Size(137, 21);
            this.txt_NonTaxableReason.TabIndex = 69;
            this.txt_NonTaxableReason.Visible = false;
            this.txt_NonTaxableReason.SelectedIndexChanged += new System.EventHandler(this.txt_NonTaxableReason_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.cb_DepartmentCode);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.btn_Search);
            this.groupBox1.Controls.Add(this.label_Currency);
            this.groupBox1.Controls.Add(this.cb_Currency);
            this.groupBox1.Controls.Add(this.label_CurrencyRate);
            this.groupBox1.Controls.Add(this.txt_CurrencyRate);
            this.groupBox1.Controls.Add(this.txt_VendorCode);
            this.groupBox1.Controls.Add(this.cb_VendorTerms);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.checkBox_Currency);
            this.groupBox1.Controls.Add(this.cb_ProjectCode);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.cb_InvoiceStatus);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txt_PONumber);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cb_TransactionType);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.DTP_InvoiceDate);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txt_InvoiceNumber);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txt_VendorName);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txt_Reference);
            this.groupBox1.Location = new System.Drawing.Point(7, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 166);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Invoice Information";
            // 
            // cb_DepartmentCode
            // 
            this.cb_DepartmentCode.FormattingEnabled = true;
            this.cb_DepartmentCode.Location = new System.Drawing.Point(342, 115);
            this.cb_DepartmentCode.Name = "cb_DepartmentCode";
            this.cb_DepartmentCode.Size = new System.Drawing.Size(134, 21);
            this.cb_DepartmentCode.TabIndex = 67;
            this.cb_DepartmentCode.SelectedIndexChanged += new System.EventHandler(this.cb_DepartmentCode_SelectedIndexChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label32.Location = new System.Drawing.Point(251, 122);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(90, 13);
            this.label32.TabIndex = 66;
            this.label32.Text = "Department Code";
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(197, 38);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(50, 20);
            this.btn_Search.TabIndex = 52;
            this.btn_Search.Text = "Find";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // label_Currency
            // 
            this.label_Currency.AutoSize = true;
            this.label_Currency.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_Currency.Location = new System.Drawing.Point(491, 46);
            this.label_Currency.Name = "label_Currency";
            this.label_Currency.Size = new System.Drawing.Size(49, 13);
            this.label_Currency.TabIndex = 62;
            this.label_Currency.Text = "Currency";
            this.label_Currency.Visible = false;
            // 
            // cb_Currency
            // 
            this.cb_Currency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Currency.FormattingEnabled = true;
            this.cb_Currency.Location = new System.Drawing.Point(494, 69);
            this.cb_Currency.Name = "cb_Currency";
            this.cb_Currency.Size = new System.Drawing.Size(74, 21);
            this.cb_Currency.TabIndex = 63;
            this.cb_Currency.Visible = false;
            this.cb_Currency.SelectedIndexChanged += new System.EventHandler(this.cb_Currency_SelectedIndexChanged);
            // 
            // label_CurrencyRate
            // 
            this.label_CurrencyRate.AutoSize = true;
            this.label_CurrencyRate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_CurrencyRate.Location = new System.Drawing.Point(491, 95);
            this.label_CurrencyRate.Name = "label_CurrencyRate";
            this.label_CurrencyRate.Size = new System.Drawing.Size(75, 13);
            this.label_CurrencyRate.TabIndex = 64;
            this.label_CurrencyRate.Text = "Currency Rate";
            this.label_CurrencyRate.Visible = false;
            // 
            // txt_CurrencyRate
            // 
            this.txt_CurrencyRate.BackColor = System.Drawing.SystemColors.Control;
            this.txt_CurrencyRate.Location = new System.Drawing.Point(494, 112);
            this.txt_CurrencyRate.Name = "txt_CurrencyRate";
            this.txt_CurrencyRate.ReadOnly = true;
            this.txt_CurrencyRate.Size = new System.Drawing.Size(74, 20);
            this.txt_CurrencyRate.TabIndex = 65;
            this.txt_CurrencyRate.Text = "0";
            this.txt_CurrencyRate.Visible = false;
            this.txt_CurrencyRate.TextChanged += new System.EventHandler(this.txt_CurrencyRate_TextChanged);
            // 
            // txt_VendorCode
            // 
            this.txt_VendorCode.Location = new System.Drawing.Point(110, 38);
            this.txt_VendorCode.MaxLength = 4;
            this.txt_VendorCode.Name = "txt_VendorCode";
            this.txt_VendorCode.Size = new System.Drawing.Size(77, 20);
            this.txt_VendorCode.TabIndex = 50;
            this.txt_VendorCode.TextChanged += new System.EventHandler(this.txt_VendorCode_TextChanged);
            this.txt_VendorCode.Leave += new System.EventHandler(this.txt_VendorCode_Leave);
            // 
            // cb_VendorTerms
            // 
            this.cb_VendorTerms.FormattingEnabled = true;
            this.cb_VendorTerms.Location = new System.Drawing.Point(110, 139);
            this.cb_VendorTerms.Name = "cb_VendorTerms";
            this.cb_VendorTerms.Size = new System.Drawing.Size(137, 21);
            this.cb_VendorTerms.TabIndex = 40;
            this.cb_VendorTerms.SelectedIndexChanged += new System.EventHandler(this.cb_VendorTerms_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label20.Location = new System.Drawing.Point(9, 142);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(73, 13);
            this.label20.TabIndex = 39;
            this.label20.Text = "Vendor Terms";
            // 
            // checkBox_Currency
            // 
            this.checkBox_Currency.AutoSize = true;
            this.checkBox_Currency.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBox_Currency.Location = new System.Drawing.Point(494, 19);
            this.checkBox_Currency.Name = "checkBox_Currency";
            this.checkBox_Currency.Size = new System.Drawing.Size(90, 17);
            this.checkBox_Currency.TabIndex = 61;
            this.checkBox_Currency.Text = "MultiCurrency";
            this.checkBox_Currency.UseVisualStyleBackColor = false;
            this.checkBox_Currency.CheckedChanged += new System.EventHandler(this.checkBox_Currency_CheckedChanged);
            // 
            // cb_ProjectCode
            // 
            this.cb_ProjectCode.FormattingEnabled = true;
            this.cb_ProjectCode.Location = new System.Drawing.Point(325, 88);
            this.cb_ProjectCode.Name = "cb_ProjectCode";
            this.cb_ProjectCode.Size = new System.Drawing.Size(151, 21);
            this.cb_ProjectCode.TabIndex = 36;
            this.cb_ProjectCode.SelectedIndexChanged += new System.EventHandler(this.cb_ProjectCode_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label18.Location = new System.Drawing.Point(251, 95);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 13);
            this.label18.TabIndex = 35;
            this.label18.Text = "Project Code";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label17.Location = new System.Drawing.Point(8, 116);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "Reference";
            // 
            // cb_InvoiceStatus
            // 
            this.cb_InvoiceStatus.FormattingEnabled = true;
            this.cb_InvoiceStatus.Items.AddRange(new object[] {
            "Hold",
            "Active"});
            this.cb_InvoiceStatus.Location = new System.Drawing.Point(110, 90);
            this.cb_InvoiceStatus.Name = "cb_InvoiceStatus";
            this.cb_InvoiceStatus.Size = new System.Drawing.Size(137, 21);
            this.cb_InvoiceStatus.TabIndex = 30;
            this.cb_InvoiceStatus.Text = "Active";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label15.Location = new System.Drawing.Point(8, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Invoice Status";
            // 
            // txt_PONumber
            // 
            this.txt_PONumber.Location = new System.Drawing.Point(324, 62);
            this.txt_PONumber.MaxLength = 30;
            this.txt_PONumber.Name = "txt_PONumber";
            this.txt_PONumber.Size = new System.Drawing.Size(152, 20);
            this.txt_PONumber.TabIndex = 28;
            this.txt_PONumber.TextChanged += new System.EventHandler(this.txt_PONumber_TextChanged);
            this.txt_PONumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_PONumber_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label14.Location = new System.Drawing.Point(253, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "P.O Number";
            // 
            // cb_TransactionType
            // 
            this.cb_TransactionType.FormattingEnabled = true;
            this.cb_TransactionType.Items.AddRange(new object[] {
            "Invoice",
            "CreditNote",
            "AdvancedDeposit"});
            this.cb_TransactionType.Location = new System.Drawing.Point(110, 63);
            this.cb_TransactionType.Name = "cb_TransactionType";
            this.cb_TransactionType.Size = new System.Drawing.Size(137, 21);
            this.cb_TransactionType.TabIndex = 26;
            this.cb_TransactionType.SelectedIndexChanged += new System.EventHandler(this.cb_TransactionType_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Location = new System.Drawing.Point(9, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Transaction Type";
            // 
            // DTP_InvoiceDate
            // 
            this.DTP_InvoiceDate.Location = new System.Drawing.Point(324, 15);
            this.DTP_InvoiceDate.Name = "DTP_InvoiceDate";
            this.DTP_InvoiceDate.Size = new System.Drawing.Size(152, 20);
            this.DTP_InvoiceDate.TabIndex = 24;
            this.DTP_InvoiceDate.CloseUp += new System.EventHandler(this.DTP_InvoiceDate_CloseUp);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(250, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Invoice Date";
            // 
            // txt_InvoiceNumber
            // 
            this.txt_InvoiceNumber.Location = new System.Drawing.Point(110, 14);
            this.txt_InvoiceNumber.Name = "txt_InvoiceNumber";
            this.txt_InvoiceNumber.Size = new System.Drawing.Size(77, 20);
            this.txt_InvoiceNumber.TabIndex = 22;
            this.txt_InvoiceNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_InvoiceNumber_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(9, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Invoice Number";
            // 
            // txt_VendorName
            // 
            this.txt_VendorName.Location = new System.Drawing.Point(324, 39);
            this.txt_VendorName.MaxLength = 30;
            this.txt_VendorName.Name = "txt_VendorName";
            this.txt_VendorName.Size = new System.Drawing.Size(152, 20);
            this.txt_VendorName.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(250, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Vendor Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(9, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Vendor Code";
            // 
            // txt_Reference
            // 
            this.txt_Reference.Location = new System.Drawing.Point(110, 116);
            this.txt_Reference.MaxLength = 30;
            this.txt_Reference.Name = "txt_Reference";
            this.txt_Reference.Size = new System.Drawing.Size(137, 20);
            this.txt_Reference.TabIndex = 34;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(6, 334);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 13);
            this.label21.TabIndex = 69;
            this.label21.Text = "Invoice Details";
            // 
            // dgv_InvoiceDetails
            // 
            this.dgv_InvoiceDetails.AllowUserToAddRows = false;
            this.dgv_InvoiceDetails.AllowUserToDeleteRows = false;
            this.dgv_InvoiceDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_InvoiceDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_InvoiceDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_InvoiceDetails.Location = new System.Drawing.Point(3, 350);
            this.dgv_InvoiceDetails.MultiSelect = false;
            this.dgv_InvoiceDetails.Name = "dgv_InvoiceDetails";
            this.dgv_InvoiceDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_InvoiceDetails.Size = new System.Drawing.Size(629, 174);
            this.dgv_InvoiceDetails.TabIndex = 68;
            this.dgv_InvoiceDetails.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_InvoiceDetails_CellBeginEdit);
            this.dgv_InvoiceDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_InvoiceDetails_CellDoubleClick);
            this.dgv_InvoiceDetails.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_InvoiceDetails_CellEndEdit);
            this.dgv_InvoiceDetails.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_InvoiceDetails_CellValueChanged);
            this.dgv_InvoiceDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_InvoiceDetails_DataError);
            this.dgv_InvoiceDetails.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_InvoiceDetails_EditingControlShowing);
            this.dgv_InvoiceDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_InvoiceDetails_KeyDown);
            this.dgv_InvoiceDetails.Leave += new System.EventHandler(this.dgv_InvoiceDetails_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Lock74);
            this.groupBox3.Controls.Add(this.Lock73);
            this.groupBox3.Controls.Add(this.btnundo);
            this.groupBox3.Controls.Add(this.Lock72);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(365, 114);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(633, 46);
            this.groupBox3.TabIndex = 72;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Access Invoice";
            // 
            // Lock74
            // 
            this.Lock74.Controls.Add(this.btndelete);
            this.Lock74.Location = new System.Drawing.Point(327, 7);
            this.Lock74.Name = "Lock74";
            this.Lock74.Size = new System.Drawing.Size(80, 37);
            this.Lock74.TabIndex = 76;
            this.Lock74.TabStop = false;
            this.Lock74.Tag = "74";
            // 
            // btndelete
            // 
            this.btndelete.Enabled = false;
            this.btndelete.Location = new System.Drawing.Point(0, 6);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(80, 31);
            this.btndelete.TabIndex = 61;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // Lock73
            // 
            this.Lock73.Controls.Add(this.btnedit);
            this.Lock73.Controls.Add(this.Btnsaveedit);
            this.Lock73.Location = new System.Drawing.Point(213, 7);
            this.Lock73.Name = "Lock73";
            this.Lock73.Size = new System.Drawing.Size(80, 37);
            this.Lock73.TabIndex = 80;
            this.Lock73.TabStop = false;
            this.Lock73.Tag = "73";
            // 
            // btnedit
            // 
            this.btnedit.Enabled = false;
            this.btnedit.Location = new System.Drawing.Point(0, 6);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(80, 31);
            this.btnedit.TabIndex = 63;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // Btnsaveedit
            // 
            this.Btnsaveedit.Location = new System.Drawing.Point(0, 6);
            this.Btnsaveedit.Name = "Btnsaveedit";
            this.Btnsaveedit.Size = new System.Drawing.Size(80, 31);
            this.Btnsaveedit.TabIndex = 60;
            this.Btnsaveedit.Text = "Save";
            this.Btnsaveedit.UseVisualStyleBackColor = true;
            this.Btnsaveedit.Click += new System.EventHandler(this.Btnsaveedit_Click);
            // 
            // btnundo
            // 
            this.btnundo.Location = new System.Drawing.Point(441, 13);
            this.btnundo.Name = "btnundo";
            this.btnundo.Size = new System.Drawing.Size(80, 31);
            this.btnundo.TabIndex = 64;
            this.btnundo.Text = "Undo";
            this.btnundo.UseVisualStyleBackColor = true;
            this.btnundo.Click += new System.EventHandler(this.btnundo_Click);
            // 
            // Lock72
            // 
            this.Lock72.Controls.Add(this.btn_New);
            this.Lock72.Controls.Add(this.btnSavenew);
            this.Lock72.Location = new System.Drawing.Point(99, 7);
            this.Lock72.Name = "Lock72";
            this.Lock72.Size = new System.Drawing.Size(80, 37);
            this.Lock72.TabIndex = 79;
            this.Lock72.TabStop = false;
            this.Lock72.Tag = "72";
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(0, 6);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(80, 31);
            this.btn_New.TabIndex = 59;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btnSavenew
            // 
            this.btnSavenew.Location = new System.Drawing.Point(0, 6);
            this.btnSavenew.Name = "btnSavenew";
            this.btnSavenew.Size = new System.Drawing.Size(80, 31);
            this.btnSavenew.TabIndex = 62;
            this.btnSavenew.Text = "Save";
            this.btnSavenew.UseVisualStyleBackColor = true;
            this.btnSavenew.Click += new System.EventHandler(this.btnSavenew_Click);
            // 
            // groupBatch
            // 
            this.groupBatch.Controls.Add(this.Lock69);
            this.groupBatch.Controls.Add(this.Lock70);
            this.groupBatch.Controls.Add(this.Lock71);
            this.groupBatch.Controls.Add(this.btnundobatch);
            this.groupBatch.Controls.Add(this.btnfindbatch);
            this.groupBatch.Controls.Add(this.btnexit);
            this.groupBatch.Controls.Add(this.Lock68);
            this.groupBatch.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBatch.Location = new System.Drawing.Point(0, 0);
            this.groupBatch.Name = "groupBatch";
            this.groupBatch.Size = new System.Drawing.Size(1011, 40);
            this.groupBatch.TabIndex = 74;
            this.groupBatch.TabStop = false;
            // 
            // Lock69
            // 
            this.Lock69.Controls.Add(this.btneditbatch);
            this.Lock69.Controls.Add(this.btn_Saveeditbatch);
            this.Lock69.Location = new System.Drawing.Point(116, 7);
            this.Lock69.Name = "Lock69";
            this.Lock69.Size = new System.Drawing.Size(79, 27);
            this.Lock69.TabIndex = 82;
            this.Lock69.TabStop = false;
            this.Lock69.Tag = "69";
            // 
            // btneditbatch
            // 
            this.btneditbatch.Enabled = false;
            this.btneditbatch.Location = new System.Drawing.Point(0, 6);
            this.btneditbatch.Name = "btneditbatch";
            this.btneditbatch.Size = new System.Drawing.Size(79, 21);
            this.btneditbatch.TabIndex = 35;
            this.btneditbatch.Text = "Edit Batch";
            this.btneditbatch.UseVisualStyleBackColor = true;
            this.btneditbatch.Click += new System.EventHandler(this.btneditbatch_Click);
            // 
            // btn_Saveeditbatch
            // 
            this.btn_Saveeditbatch.Location = new System.Drawing.Point(0, 6);
            this.btn_Saveeditbatch.Name = "btn_Saveeditbatch";
            this.btn_Saveeditbatch.Size = new System.Drawing.Size(79, 21);
            this.btn_Saveeditbatch.TabIndex = 31;
            this.btn_Saveeditbatch.Text = "Save";
            this.btn_Saveeditbatch.UseVisualStyleBackColor = true;
            this.btn_Saveeditbatch.Click += new System.EventHandler(this.btn_Saveeditbatch_Click);
            // 
            // Lock70
            // 
            this.Lock70.Controls.Add(this.btndeletebatch);
            this.Lock70.Location = new System.Drawing.Point(220, 7);
            this.Lock70.Name = "Lock70";
            this.Lock70.Size = new System.Drawing.Size(79, 27);
            this.Lock70.TabIndex = 78;
            this.Lock70.TabStop = false;
            this.Lock70.Tag = "70";
            // 
            // btndeletebatch
            // 
            this.btndeletebatch.Enabled = false;
            this.btndeletebatch.Location = new System.Drawing.Point(0, 6);
            this.btndeletebatch.Name = "btndeletebatch";
            this.btndeletebatch.Size = new System.Drawing.Size(79, 21);
            this.btndeletebatch.TabIndex = 33;
            this.btndeletebatch.Text = "Delete Batch";
            this.btndeletebatch.UseVisualStyleBackColor = true;
            this.btndeletebatch.Click += new System.EventHandler(this.btndeletebatch_Click);
            // 
            // Lock71
            // 
            this.Lock71.Controls.Add(this.btnposted);
            this.Lock71.Location = new System.Drawing.Point(324, 7);
            this.Lock71.Name = "Lock71";
            this.Lock71.Size = new System.Drawing.Size(79, 27);
            this.Lock71.TabIndex = 77;
            this.Lock71.TabStop = false;
            this.Lock71.Tag = "71";
            // 
            // btnposted
            // 
            this.btnposted.Enabled = false;
            this.btnposted.Location = new System.Drawing.Point(0, 6);
            this.btnposted.Name = "btnposted";
            this.btnposted.Size = new System.Drawing.Size(79, 21);
            this.btnposted.TabIndex = 40;
            this.btnposted.Text = "Posted Batch";
            this.btnposted.UseVisualStyleBackColor = true;
            this.btnposted.Click += new System.EventHandler(this.btnposted_Click);
            // 
            // btnundobatch
            // 
            this.btnundobatch.Location = new System.Drawing.Point(532, 13);
            this.btnundobatch.Name = "btnundobatch";
            this.btnundobatch.Size = new System.Drawing.Size(79, 21);
            this.btnundobatch.TabIndex = 39;
            this.btnundobatch.Text = "Undo Batch";
            this.btnundobatch.UseVisualStyleBackColor = true;
            this.btnundobatch.Click += new System.EventHandler(this.btnundobatch_Click);
            // 
            // btnfindbatch
            // 
            this.btnfindbatch.Location = new System.Drawing.Point(428, 13);
            this.btnfindbatch.Name = "btnfindbatch";
            this.btnfindbatch.Size = new System.Drawing.Size(79, 21);
            this.btnfindbatch.TabIndex = 38;
            this.btnfindbatch.Text = "Find Batch";
            this.btnfindbatch.UseVisualStyleBackColor = true;
            this.btnfindbatch.Click += new System.EventHandler(this.btnfindbatch_Click);
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(636, 13);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(79, 21);
            this.btnexit.TabIndex = 37;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // Lock68
            // 
            this.Lock68.Controls.Add(this.btn_newbatch);
            this.Lock68.Controls.Add(this.btn_savenewbatch);
            this.Lock68.Location = new System.Drawing.Point(12, 7);
            this.Lock68.Name = "Lock68";
            this.Lock68.Size = new System.Drawing.Size(79, 27);
            this.Lock68.TabIndex = 65;
            this.Lock68.TabStop = false;
            this.Lock68.Tag = "68";
            // 
            // btn_newbatch
            // 
            this.btn_newbatch.Location = new System.Drawing.Point(0, 6);
            this.btn_newbatch.Name = "btn_newbatch";
            this.btn_newbatch.Size = new System.Drawing.Size(79, 21);
            this.btn_newbatch.TabIndex = 32;
            this.btn_newbatch.Text = "New Batch";
            this.btn_newbatch.UseVisualStyleBackColor = true;
            this.btn_newbatch.Click += new System.EventHandler(this.btn_newbatch_Click);
            // 
            // btn_savenewbatch
            // 
            this.btn_savenewbatch.Location = new System.Drawing.Point(0, 6);
            this.btn_savenewbatch.Name = "btn_savenewbatch";
            this.btn_savenewbatch.Size = new System.Drawing.Size(79, 21);
            this.btn_savenewbatch.TabIndex = 34;
            this.btn_savenewbatch.Text = "Save";
            this.btn_savenewbatch.UseVisualStyleBackColor = true;
            this.btn_savenewbatch.Click += new System.EventHandler(this.btn_savenewbatch_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label31);
            this.groupBox4.Controls.Add(this.txtPostedDate);
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.txtstats);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.txtBatchNum);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txt_UserID);
            this.groupBox4.Controls.Add(this.txt_Period);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txt_Balance);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.DTP_Date);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txt_Description);
            this.groupBox4.Controls.Add(this.txt_APBatchNumber);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(12, 41);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(992, 66);
            this.groupBox4.TabIndex = 75;
            this.groupBox4.TabStop = false;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(758, 42);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(52, 13);
            this.label31.TabIndex = 76;
            this.label31.Text = "Posted In";
            this.label31.Visible = false;
            // 
            // txtPostedDate
            // 
            this.txtPostedDate.Location = new System.Drawing.Point(817, 40);
            this.txtPostedDate.MaxLength = 30;
            this.txtPostedDate.Name = "txtPostedDate";
            this.txtPostedDate.ReadOnly = true;
            this.txtPostedDate.Size = new System.Drawing.Size(115, 20);
            this.txtPostedDate.TabIndex = 75;
            this.txtPostedDate.Visible = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(665, 42);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(31, 13);
            this.label30.TabIndex = 74;
            this.label30.Text = "Stats";
            // 
            // txtstats
            // 
            this.txtstats.Location = new System.Drawing.Point(703, 40);
            this.txtstats.MaxLength = 30;
            this.txtstats.Name = "txtstats";
            this.txtstats.ReadOnly = true;
            this.txtstats.Size = new System.Drawing.Size(49, 20);
            this.txtstats.TabIndex = 73;
            this.txtstats.TextChanged += new System.EventHandler(this.txtstats_TextChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(691, 12);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(45, 13);
            this.label29.TabIndex = 72;
            this.label29.Text = "Batch #";
            // 
            // txtBatchNum
            // 
            this.txtBatchNum.Location = new System.Drawing.Point(751, 12);
            this.txtBatchNum.MaxLength = 30;
            this.txtBatchNum.Name = "txtBatchNum";
            this.txtBatchNum.ReadOnly = true;
            this.txtBatchNum.Size = new System.Drawing.Size(123, 20);
            this.txtBatchNum.TabIndex = 71;
            this.txtBatchNum.TextChanged += new System.EventHandler(this.txtBatchNum_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(504, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "User ID";
            // 
            // txt_UserID
            // 
            this.txt_UserID.Location = new System.Drawing.Point(557, 40);
            this.txt_UserID.MaxLength = 30;
            this.txt_UserID.Name = "txt_UserID";
            this.txt_UserID.ReadOnly = true;
            this.txt_UserID.Size = new System.Drawing.Size(103, 20);
            this.txt_UserID.TabIndex = 24;
            // 
            // txt_Period
            // 
            this.txt_Period.Location = new System.Drawing.Point(369, 38);
            this.txt_Period.Name = "txt_Period";
            this.txt_Period.ReadOnly = true;
            this.txt_Period.Size = new System.Drawing.Size(105, 20);
            this.txt_Period.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(503, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Balance";
            // 
            // txt_Balance
            // 
            this.txt_Balance.Location = new System.Drawing.Point(557, 11);
            this.txt_Balance.MaxLength = 30;
            this.txt_Balance.Name = "txt_Balance";
            this.txt_Balance.ReadOnly = true;
            this.txt_Balance.Size = new System.Drawing.Size(102, 20);
            this.txt_Balance.TabIndex = 21;
            this.txt_Balance.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Date";
            // 
            // DTP_Date
            // 
            this.DTP_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_Date.Location = new System.Drawing.Point(369, 9);
            this.DTP_Date.Name = "DTP_Date";
            this.DTP_Date.Size = new System.Drawing.Size(105, 20);
            this.DTP_Date.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Period";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Description";
            // 
            // txt_Description
            // 
            this.txt_Description.Location = new System.Drawing.Point(103, 38);
            this.txt_Description.MaxLength = 30;
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.Size = new System.Drawing.Size(206, 20);
            this.txt_Description.TabIndex = 16;
            // 
            // txt_APBatchNumber
            // 
            this.txt_APBatchNumber.Enabled = false;
            this.txt_APBatchNumber.Location = new System.Drawing.Point(103, 9);
            this.txt_APBatchNumber.Name = "txt_APBatchNumber";
            this.txt_APBatchNumber.Size = new System.Drawing.Size(116, 20);
            this.txt_APBatchNumber.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "AP  Number";
            // 
            // Err
            // 
            this.Err.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.Err.ContainerControl = this;
            // 
            // APTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1011, 702);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBatch);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupInvoice);
            this.Controls.Add(this.dgv_Invoices);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "APTransactions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APTransactions";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.APTransactions_FormClosed);
            this.Load += new System.EventHandler(this.APTransactions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Invoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupInvoice.ResumeLayout(false);
            this.groupInvoice.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InvoiceDetails)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.Lock74.ResumeLayout(false);
            this.Lock73.ResumeLayout(false);
            this.Lock72.ResumeLayout(false);
            this.groupBatch.ResumeLayout(false);
            this.Lock69.ResumeLayout(false);
            this.Lock70.ResumeLayout(false);
            this.Lock71.ResumeLayout(false);
            this.Lock68.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgv_Invoices;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveChangesToolStripMenuItem;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchInvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem postToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupInvoice;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txt_TaxValue;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txt_AccountsCurrentBalance;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txt_DiscountValue;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txt_DueDays;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.CheckBox checkBox_Tax;
        private System.Windows.Forms.ComboBox cb_StartDate;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txt_SalesTaxAmount;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txt_NetInvoiceAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_DeliveryType;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txt_InvoiceAmount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label_NonTaxableReason;
        private System.Windows.Forms.ComboBox txt_NonTaxableReason;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label label_Currency;
        private System.Windows.Forms.ComboBox cb_Currency;
        private System.Windows.Forms.Label label_CurrencyRate;
        private System.Windows.Forms.TextBox txt_CurrencyRate;
        private System.Windows.Forms.TextBox txt_VendorCode;
        private System.Windows.Forms.ComboBox cb_VendorTerms;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox checkBox_Currency;
        private System.Windows.Forms.ComboBox cb_ProjectCode;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cb_InvoiceStatus;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_PONumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cb_TransactionType;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker DTP_InvoiceDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_InvoiceNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_VendorName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Reference;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridView dgv_InvoiceDetails;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnundo;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button Btnsaveedit;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Button btnSavenew;
        private System.Windows.Forms.GroupBox groupBatch;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btneditbatch;
        private System.Windows.Forms.Button btndeletebatch;
        private System.Windows.Forms.Button btn_newbatch;
        private System.Windows.Forms.Button btn_Saveeditbatch;
        private System.Windows.Forms.Button btn_savenewbatch;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtBatchNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_UserID;
        private System.Windows.Forms.TextBox txt_Period;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Balance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DTP_Date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Description;
        private System.Windows.Forms.TextBox txt_APBatchNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnfindbatch;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtstats;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtPostedDate;
        private System.Windows.Forms.Button btnundobatch;
        private System.Windows.Forms.Button btnposted;
        private System.Windows.Forms.GroupBox Lock68;
        private System.Windows.Forms.GroupBox Lock74;
        private System.Windows.Forms.GroupBox Lock71;
        private System.Windows.Forms.GroupBox Lock70;
        private System.Windows.Forms.GroupBox Lock72;
        private System.Windows.Forms.GroupBox Lock73;
        private System.Windows.Forms.GroupBox Lock69;
        private System.Windows.Forms.ErrorProvider Err;
        private System.Windows.Forms.ComboBox cb_DepartmentCode;
        private System.Windows.Forms.Label label32;
    }
}