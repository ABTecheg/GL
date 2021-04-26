namespace Accounting_GeneralLedger
{
    partial class BankAccountMaintenance
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SaveChanges = new System.Windows.Forms.Button();
            this.txt_BankId = new System.Windows.Forms.TextBox();
            this.btn_New = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_BankCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_BankAccountDescription = new System.Windows.Forms.TextBox();
            this.txt_BankAccountNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_Currency = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox_Active = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_ServiceAccountNumber = new System.Windows.Forms.TextBox();
            this.btn_SearchAccount = new System.Windows.Forms.Button();
            this.txt_InterestEarned = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_CashFlowCategory = new System.Windows.Forms.ComboBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.bankIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankAccountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankGLAccountNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankAccountDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankCurrencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceAccountNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cashFlowCategoryCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interestEarnedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.propertyCodeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_BankAccount = new System.Windows.Forms.TextBox();
            this.btn_SearchForAccount = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bank ID";
            // 
            // btn_SaveChanges
            // 
            this.btn_SaveChanges.Location = new System.Drawing.Point(377, 469);
            this.btn_SaveChanges.Name = "btn_SaveChanges";
            this.btn_SaveChanges.Size = new System.Drawing.Size(135, 27);
            this.btn_SaveChanges.TabIndex = 1;
            this.btn_SaveChanges.Text = "Save Changes";
            this.btn_SaveChanges.UseVisualStyleBackColor = true;
            // 
            // txt_BankId
            // 
            this.txt_BankId.Location = new System.Drawing.Point(282, 186);
            this.txt_BankId.Name = "txt_BankId";
            this.txt_BankId.ReadOnly = true;
            this.txt_BankId.Size = new System.Drawing.Size(142, 20);
            this.txt_BankId.TabIndex = 2;
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(430, 186);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(57, 20);
            this.btn_New.TabIndex = 3;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Bank Code";
            // 
            // txt_BankCode
            // 
            this.txt_BankCode.Location = new System.Drawing.Point(282, 215);
            this.txt_BankCode.MaxLength = 4;
            this.txt_BankCode.Name = "txt_BankCode";
            this.txt_BankCode.Size = new System.Drawing.Size(205, 20);
            this.txt_BankCode.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bank Account Description";
            // 
            // txt_BankAccountDescription
            // 
            this.txt_BankAccountDescription.Location = new System.Drawing.Point(282, 297);
            this.txt_BankAccountDescription.MaxLength = 30;
            this.txt_BankAccountDescription.Name = "txt_BankAccountDescription";
            this.txt_BankAccountDescription.Size = new System.Drawing.Size(205, 20);
            this.txt_BankAccountDescription.TabIndex = 7;
            // 
            // txt_BankAccountNumber
            // 
            this.txt_BankAccountNumber.Location = new System.Drawing.Point(282, 269);
            this.txt_BankAccountNumber.MaxLength = 30;
            this.txt_BankAccountNumber.Name = "txt_BankAccountNumber";
            this.txt_BankAccountNumber.Size = new System.Drawing.Size(142, 20);
            this.txt_BankAccountNumber.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Bank GL Account Number";
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(430, 268);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(57, 20);
            this.btn_Search.TabIndex = 10;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Currency";
            // 
            // cb_Currency
            // 
            this.cb_Currency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Currency.FormattingEnabled = true;
            this.cb_Currency.Location = new System.Drawing.Point(282, 323);
            this.cb_Currency.Name = "cb_Currency";
            this.cb_Currency.Size = new System.Drawing.Size(205, 21);
            this.cb_Currency.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(119, 437);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Status";
            // 
            // checkBox_Active
            // 
            this.checkBox_Active.AutoSize = true;
            this.checkBox_Active.Location = new System.Drawing.Point(282, 438);
            this.checkBox_Active.Name = "checkBox_Active";
            this.checkBox_Active.Size = new System.Drawing.Size(56, 17);
            this.checkBox_Active.TabIndex = 14;
            this.checkBox_Active.Text = "Active";
            this.checkBox_Active.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(119, 355);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Service Account Number";
            // 
            // txt_ServiceAccountNumber
            // 
            this.txt_ServiceAccountNumber.Location = new System.Drawing.Point(282, 352);
            this.txt_ServiceAccountNumber.MaxLength = 30;
            this.txt_ServiceAccountNumber.Name = "txt_ServiceAccountNumber";
            this.txt_ServiceAccountNumber.Size = new System.Drawing.Size(142, 20);
            this.txt_ServiceAccountNumber.TabIndex = 16;
            // 
            // btn_SearchAccount
            // 
            this.btn_SearchAccount.Location = new System.Drawing.Point(433, 352);
            this.btn_SearchAccount.Name = "btn_SearchAccount";
            this.btn_SearchAccount.Size = new System.Drawing.Size(57, 20);
            this.btn_SearchAccount.TabIndex = 17;
            this.btn_SearchAccount.Text = "Search";
            this.btn_SearchAccount.UseVisualStyleBackColor = true;
            // 
            // txt_InterestEarned
            // 
            this.txt_InterestEarned.Location = new System.Drawing.Point(282, 383);
            this.txt_InterestEarned.MaxLength = 30;
            this.txt_InterestEarned.Name = "txt_InterestEarned";
            this.txt_InterestEarned.Size = new System.Drawing.Size(205, 20);
            this.txt_InterestEarned.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(119, 386);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Interest Earned";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(119, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Bank Account";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(119, 407);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Cash Flow Category";
            // 
            // cb_CashFlowCategory
            // 
            this.cb_CashFlowCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CashFlowCategory.FormattingEnabled = true;
            this.cb_CashFlowCategory.Location = new System.Drawing.Point(282, 409);
            this.cb_CashFlowCategory.Name = "cb_CashFlowCategory";
            this.cb_CashFlowCategory.Size = new System.Drawing.Size(205, 21);
            this.cb_CashFlowCategory.TabIndex = 23;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bankIDDataGridViewTextBoxColumn,
            this.bankCodeDataGridViewTextBoxColumn,
            this.bankAccountDataGridViewTextBoxColumn,
            this.bankGLAccountNumberDataGridViewTextBoxColumn,
            this.bankAccountDescriptionDataGridViewTextBoxColumn,
            this.bankCurrencyDataGridViewTextBoxColumn,
            this.serviceAccountNumberDataGridViewTextBoxColumn,
            this.cashFlowCategoryCodeDataGridViewTextBoxColumn,
            this.interestEarnedDataGridViewTextBoxColumn,
            this.activeDataGridViewCheckBoxColumn,
            this.propertyCodeIDDataGridViewTextBoxColumn});
            this.dgv.DataMember = "ARBankAccounts";
            this.dgv.DataSource = this.dbAccountingProjectDSBindingSource;
            this.dgv.Location = new System.Drawing.Point(12, 33);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(573, 136);
            this.dgv.TabIndex = 24;
            // 
            // bankIDDataGridViewTextBoxColumn
            // 
            this.bankIDDataGridViewTextBoxColumn.DataPropertyName = "BankID";
            this.bankIDDataGridViewTextBoxColumn.HeaderText = "BankID";
            this.bankIDDataGridViewTextBoxColumn.Name = "bankIDDataGridViewTextBoxColumn";
            this.bankIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.bankIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // bankCodeDataGridViewTextBoxColumn
            // 
            this.bankCodeDataGridViewTextBoxColumn.DataPropertyName = "BankCode";
            this.bankCodeDataGridViewTextBoxColumn.HeaderText = "BankCode";
            this.bankCodeDataGridViewTextBoxColumn.Name = "bankCodeDataGridViewTextBoxColumn";
            this.bankCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bankAccountDataGridViewTextBoxColumn
            // 
            this.bankAccountDataGridViewTextBoxColumn.DataPropertyName = "BankAccount";
            this.bankAccountDataGridViewTextBoxColumn.HeaderText = "BankAccount";
            this.bankAccountDataGridViewTextBoxColumn.Name = "bankAccountDataGridViewTextBoxColumn";
            this.bankAccountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bankGLAccountNumberDataGridViewTextBoxColumn
            // 
            this.bankGLAccountNumberDataGridViewTextBoxColumn.DataPropertyName = "BankGLAccountNumber";
            this.bankGLAccountNumberDataGridViewTextBoxColumn.HeaderText = "BankGLAccountNumber";
            this.bankGLAccountNumberDataGridViewTextBoxColumn.Name = "bankGLAccountNumberDataGridViewTextBoxColumn";
            this.bankGLAccountNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bankAccountDescriptionDataGridViewTextBoxColumn
            // 
            this.bankAccountDescriptionDataGridViewTextBoxColumn.DataPropertyName = "BankAccountDescription";
            this.bankAccountDescriptionDataGridViewTextBoxColumn.HeaderText = "BankAccountDescription";
            this.bankAccountDescriptionDataGridViewTextBoxColumn.Name = "bankAccountDescriptionDataGridViewTextBoxColumn";
            this.bankAccountDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bankCurrencyDataGridViewTextBoxColumn
            // 
            this.bankCurrencyDataGridViewTextBoxColumn.DataPropertyName = "BankCurrency";
            this.bankCurrencyDataGridViewTextBoxColumn.HeaderText = "BankCurrency";
            this.bankCurrencyDataGridViewTextBoxColumn.Name = "bankCurrencyDataGridViewTextBoxColumn";
            this.bankCurrencyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // serviceAccountNumberDataGridViewTextBoxColumn
            // 
            this.serviceAccountNumberDataGridViewTextBoxColumn.DataPropertyName = "ServiceAccountNumber";
            this.serviceAccountNumberDataGridViewTextBoxColumn.HeaderText = "ServiceAccountNumber";
            this.serviceAccountNumberDataGridViewTextBoxColumn.Name = "serviceAccountNumberDataGridViewTextBoxColumn";
            this.serviceAccountNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cashFlowCategoryCodeDataGridViewTextBoxColumn
            // 
            this.cashFlowCategoryCodeDataGridViewTextBoxColumn.DataPropertyName = "CashFlowCategoryCode";
            this.cashFlowCategoryCodeDataGridViewTextBoxColumn.HeaderText = "CashFlowCategoryCode";
            this.cashFlowCategoryCodeDataGridViewTextBoxColumn.Name = "cashFlowCategoryCodeDataGridViewTextBoxColumn";
            this.cashFlowCategoryCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // interestEarnedDataGridViewTextBoxColumn
            // 
            this.interestEarnedDataGridViewTextBoxColumn.DataPropertyName = "InterestEarned";
            this.interestEarnedDataGridViewTextBoxColumn.HeaderText = "InterestEarned";
            this.interestEarnedDataGridViewTextBoxColumn.Name = "interestEarnedDataGridViewTextBoxColumn";
            this.interestEarnedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // activeDataGridViewCheckBoxColumn
            // 
            this.activeDataGridViewCheckBoxColumn.DataPropertyName = "Active";
            this.activeDataGridViewCheckBoxColumn.HeaderText = "Active";
            this.activeDataGridViewCheckBoxColumn.Name = "activeDataGridViewCheckBoxColumn";
            this.activeDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // propertyCodeIDDataGridViewTextBoxColumn
            // 
            this.propertyCodeIDDataGridViewTextBoxColumn.DataPropertyName = "PropertyCodeID";
            this.propertyCodeIDDataGridViewTextBoxColumn.HeaderText = "PropertyCodeID";
            this.propertyCodeIDDataGridViewTextBoxColumn.Name = "propertyCodeIDDataGridViewTextBoxColumn";
            this.propertyCodeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.propertyCodeIDDataGridViewTextBoxColumn.Visible = false;
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
            this.menuStrip1.Size = new System.Drawing.Size(597, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
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
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // txt_BankAccount
            // 
            this.txt_BankAccount.Location = new System.Drawing.Point(282, 241);
            this.txt_BankAccount.Name = "txt_BankAccount";
            this.txt_BankAccount.Size = new System.Drawing.Size(142, 20);
            this.txt_BankAccount.TabIndex = 26;
            // 
            // btn_SearchForAccount
            // 
            this.btn_SearchForAccount.Location = new System.Drawing.Point(430, 241);
            this.btn_SearchForAccount.Name = "btn_SearchForAccount";
            this.btn_SearchForAccount.Size = new System.Drawing.Size(57, 20);
            this.btn_SearchForAccount.TabIndex = 27;
            this.btn_SearchForAccount.Text = "Search";
            this.btn_SearchForAccount.UseVisualStyleBackColor = true;
            // 
            // BankAccountMaintenance
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(678, 408);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BankAccountMaintenance";
            this.Load += new System.EventHandler(this.BankAccountMaintenance_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SaveChanges;
        private System.Windows.Forms.TextBox txt_BankId;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_BankCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_BankAccountDescription;
        private System.Windows.Forms.TextBox txt_BankAccountNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_Currency;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox_Active;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_ServiceAccountNumber;
        private System.Windows.Forms.Button btn_SearchAccount;
        private System.Windows.Forms.TextBox txt_InterestEarned;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cb_CashFlowCategory;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        //private System.Windows.Forms.DataGridViewTextBoxColumn checkFormatDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txt_BankAccount;
        private System.Windows.Forms.Button btn_SearchForAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankAccountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankGLAccountNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankAccountDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankCurrencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceAccountNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cashFlowCategoryCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn interestEarnedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn propertyCodeIDDataGridViewTextBoxColumn;
    }
}