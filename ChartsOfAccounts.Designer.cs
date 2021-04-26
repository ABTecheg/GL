namespace Accounting_GeneralLedger
{
    partial class ChartsOfAccounts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btn_AddAccount = new System.Windows.Forms.Button();
            this.btn_SaveChanges = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.PropertyCodeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccountNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.openingBalanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.cb_AccountTypeName = new System.Windows.Forms.ComboBox();
            this.txt_AccountName = new System.Windows.Forms.TextBox();
            this.txt_AccountNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.Menu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddAFolder = new System.Windows.Forms.ToolStripTextBox();
            this.Delete = new System.Windows.Forms.ToolStripTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            this.Menu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(308, 499);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btn_AddAccount);
            this.panel1.Controls.Add(this.btn_SaveChanges);
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Controls.Add(this.cb_AccountTypeName);
            this.panel1.Controls.Add(this.txt_AccountName);
            this.panel1.Controls.Add(this.txt_AccountNumber);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(308, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 499);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(87, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Expand Tree";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(422, 107);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 28);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btn_AddAccount
            // 
            this.btn_AddAccount.Location = new System.Drawing.Point(422, 43);
            this.btn_AddAccount.Name = "btn_AddAccount";
            this.btn_AddAccount.Size = new System.Drawing.Size(101, 28);
            this.btn_AddAccount.TabIndex = 8;
            this.btn_AddAccount.Text = "Add Account";
            this.btn_AddAccount.UseVisualStyleBackColor = true;
            this.btn_AddAccount.Click += new System.EventHandler(this.btn_AddAccount_Click);
            // 
            // btn_SaveChanges
            // 
            this.btn_SaveChanges.Location = new System.Drawing.Point(422, 8);
            this.btn_SaveChanges.Name = "btn_SaveChanges";
            this.btn_SaveChanges.Size = new System.Drawing.Size(101, 28);
            this.btn_SaveChanges.TabIndex = 7;
            this.btn_SaveChanges.Text = "Save Changes";
            this.btn_SaveChanges.UseVisualStyleBackColor = true;
            this.btn_SaveChanges.Visible = false;
            this.btn_SaveChanges.Click += new System.EventHandler(this.btn_SaveChanges_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PropertyCodeID,
            this.ColumnAccountNumber,
            this.ColumnAccountName,
            this.accountTypeNameDataGridViewTextBoxColumn,
            this.activeDataGridViewCheckBoxColumn,
            this.openingBalanceDataGridViewTextBoxColumn});
            this.dgv.DataMember = "GLAccounts";
            this.dgv.DataSource = this.dbAccountingProjectDSBindingSource;
            this.dgv.Location = new System.Drawing.Point(2, 183);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(627, 314);
            this.dgv.TabIndex = 6;
            this.dgv.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseMove);
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // PropertyCodeID
            // 
            this.PropertyCodeID.DataPropertyName = "PropertyCodeID";
            this.PropertyCodeID.HeaderText = "PropertyCodeID";
            this.PropertyCodeID.Name = "PropertyCodeID";
            this.PropertyCodeID.ReadOnly = true;
            this.PropertyCodeID.Visible = false;
            // 
            // ColumnAccountNumber
            // 
            this.ColumnAccountNumber.DataPropertyName = "AccountNumber";
            this.ColumnAccountNumber.HeaderText = "Acc Number";
            this.ColumnAccountNumber.Name = "ColumnAccountNumber";
            this.ColumnAccountNumber.ReadOnly = true;
            // 
            // ColumnAccountName
            // 
            this.ColumnAccountName.DataPropertyName = "AccountName";
            this.ColumnAccountName.HeaderText = "Acc Name";
            this.ColumnAccountName.Name = "ColumnAccountName";
            this.ColumnAccountName.ReadOnly = true;
            this.ColumnAccountName.Width = 320;
            // 
            // accountTypeNameDataGridViewTextBoxColumn
            // 
            this.accountTypeNameDataGridViewTextBoxColumn.DataPropertyName = "AccountTypeName";
            this.accountTypeNameDataGridViewTextBoxColumn.HeaderText = "Acc Type";
            this.accountTypeNameDataGridViewTextBoxColumn.Name = "accountTypeNameDataGridViewTextBoxColumn";
            this.accountTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // activeDataGridViewCheckBoxColumn
            // 
            this.activeDataGridViewCheckBoxColumn.DataPropertyName = "Active";
            this.activeDataGridViewCheckBoxColumn.HeaderText = "Active";
            this.activeDataGridViewCheckBoxColumn.Name = "activeDataGridViewCheckBoxColumn";
            this.activeDataGridViewCheckBoxColumn.ReadOnly = true;
            this.activeDataGridViewCheckBoxColumn.Width = 40;
            // 
            // openingBalanceDataGridViewTextBoxColumn
            // 
            this.openingBalanceDataGridViewTextBoxColumn.DataPropertyName = "OpeningBalance";
            this.openingBalanceDataGridViewTextBoxColumn.HeaderText = "OpeningBalance";
            this.openingBalanceDataGridViewTextBoxColumn.Name = "openingBalanceDataGridViewTextBoxColumn";
            this.openingBalanceDataGridViewTextBoxColumn.ReadOnly = true;
            this.openingBalanceDataGridViewTextBoxColumn.Visible = false;
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
            // cb_AccountTypeName
            // 
            this.cb_AccountTypeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_AccountTypeName.FormattingEnabled = true;
            this.cb_AccountTypeName.Location = new System.Drawing.Point(248, 112);
            this.cb_AccountTypeName.Name = "cb_AccountTypeName";
            this.cb_AccountTypeName.Size = new System.Drawing.Size(160, 21);
            this.cb_AccountTypeName.TabIndex = 5;
            this.cb_AccountTypeName.SelectedIndexChanged += new System.EventHandler(this.cb_AccountTypeName_SelectedIndexChanged);
            // 
            // txt_AccountName
            // 
            this.txt_AccountName.Location = new System.Drawing.Point(248, 78);
            this.txt_AccountName.Name = "txt_AccountName";
            this.txt_AccountName.Size = new System.Drawing.Size(160, 20);
            this.txt_AccountName.TabIndex = 4;
            this.txt_AccountName.TextChanged += new System.EventHandler(this.txt_AccountName_TextChanged);
            // 
            // txt_AccountNumber
            // 
            this.txt_AccountNumber.Location = new System.Drawing.Point(248, 43);
            this.txt_AccountNumber.Name = "txt_AccountNumber";
            this.txt_AccountNumber.Size = new System.Drawing.Size(160, 20);
            this.txt_AccountNumber.TabIndex = 3;
            this.txt_AccountNumber.TextChanged += new System.EventHandler(this.txt_AccountNumber_TextChanged);
            this.txt_AccountNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_AccountNumber_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Account Type Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Account Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account Number";
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(308, 498);
            this.treeView1.TabIndex = 3;
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // Menu1
            // 
            this.Menu1.DropShadowEnabled = false;
            this.Menu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddAFolder,
            this.Delete});
            this.Menu1.Name = "Delet";
            this.Menu1.Size = new System.Drawing.Size(161, 72);
            this.Menu1.Tag = "47";
            // 
            // AddAFolder
            // 
            this.AddAFolder.AutoSize = false;
            this.AddAFolder.Name = "AddAFolder";
            this.AddAFolder.ReadOnly = true;
            this.AddAFolder.ShortcutsEnabled = false;
            this.AddAFolder.Size = new System.Drawing.Size(100, 21);
            this.AddAFolder.Text = "Add Folder";
            this.AddAFolder.Click += new System.EventHandler(this.AddAFolder_Click);
            // 
            // Delete
            // 
            this.Delete.AutoSize = false;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.ShortcutsEnabled = false;
            this.Delete.Size = new System.Drawing.Size(100, 21);
            this.Delete.Text = "Delete";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // ChartsOfAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 499);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.splitter1);
            this.Name = "ChartsOfAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChartsOfAccounts";
            this.Load += new System.EventHandler(this.ChartsOfAccounts_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            this.Menu1.ResumeLayout(false);
            this.Menu1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ComboBox cb_AccountTypeName;
        private System.Windows.Forms.TextBox txt_AccountName;
        private System.Windows.Forms.TextBox txt_AccountNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.Button btn_SaveChanges;
        private System.Windows.Forms.Button btn_AddAccount;
        private System.Windows.Forms.ContextMenuStrip Menu1;
        private System.Windows.Forms.ToolStripTextBox AddAFolder;
        private System.Windows.Forms.ToolStripTextBox Delete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyCodeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccountNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openingBalanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}