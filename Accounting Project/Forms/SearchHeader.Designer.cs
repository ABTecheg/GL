namespace Accounting_GeneralLedger {
    partial class SearchHeader {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchHeader));
            this.dbAccountingProjectDSBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.btn_SelectCurrentRecord = new System.Windows.Forms.Button();
            this.dbAccountingProjectDSBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.checkBox_Active = new System.Windows.Forms.CheckBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgv = new System.Windows.Forms.DataGridView();
            this.AccountNumberCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAccountTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.openingBalanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.propertyCodeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cb_AccountType = new System.Windows.Forms.ComboBox();
            this.txt_AccountName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_AccountNumber1 = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dbAccountingProjectDSBindingSource2
            // 
            this.dbAccountingProjectDSBindingSource2.DataSource = this.dbAccountingProjectDS;
            this.dbAccountingProjectDSBindingSource2.Position = 0;
            // 
            // dbAccountingProjectDS
            // 
            this.dbAccountingProjectDS.DataSetName = "dbAccountingProjectDS";
            this.dbAccountingProjectDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btn_SelectCurrentRecord
            // 
            this.btn_SelectCurrentRecord.Location = new System.Drawing.Point(442, 338);
            this.btn_SelectCurrentRecord.Name = "btn_SelectCurrentRecord";
            this.btn_SelectCurrentRecord.Size = new System.Drawing.Size(150, 24);
            this.btn_SelectCurrentRecord.TabIndex = 10;
            this.btn_SelectCurrentRecord.Text = "Select Current Records";
            this.btn_SelectCurrentRecord.UseVisualStyleBackColor = true;
            this.btn_SelectCurrentRecord.Click += new System.EventHandler(this.btn_SelectCurrentRecord_Click);
            // 
            // dbAccountingProjectDSBindingSource1
            // 
            this.dbAccountingProjectDSBindingSource1.DataSource = this.dbAccountingProjectDS;
            this.dbAccountingProjectDSBindingSource1.Position = 0;
            // 
            // checkBox_Active
            // 
            this.checkBox_Active.AutoSize = true;
            this.checkBox_Active.Location = new System.Drawing.Point(194, 91);
            this.checkBox_Active.Name = "checkBox_Active";
            this.checkBox_Active.Size = new System.Drawing.Size(150, 17);
            this.checkBox_Active.TabIndex = 9;
            this.checkBox_Active.Text = "Include Inactive Accounts";
            this.checkBox_Active.UseVisualStyleBackColor = true;
            this.checkBox_Active.CheckedChanged += new System.EventHandler(this.checkBox_Active_CheckedChanged);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(299, 338);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(120, 24);
            this.btn_Add.TabIndex = 7;
            this.btn_Add.Text = "Add New Account";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 11;
            // 
            // dbAccountingProjectDSBindingSource
            // 
            this.dbAccountingProjectDSBindingSource.DataSource = this.dbAccountingProjectDS;
            this.dbAccountingProjectDSBindingSource.Position = 0;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccountNumberCol,
            this.AccountNameCol,
            this.ColAccountTypeName,
            this.activeDataGridViewCheckBoxColumn,
            this.openingBalanceDataGridViewTextBoxColumn,
            this.propertyCodeIDDataGridViewTextBoxColumn});
            this.dgv.DataMember = "GLAccounts";
            this.dgv.DataSource = this.dbAccountingProjectDSBindingSource2;
            this.dgv.Location = new System.Drawing.Point(14, 114);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(578, 218);
            this.dgv.TabIndex = 6;
            this.dgv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseDoubleClick);
            // 
            // AccountNumberCol
            // 
            this.AccountNumberCol.DataPropertyName = "AccountNumber";
            this.AccountNumberCol.HeaderText = "AccountNumber";
            this.AccountNumberCol.Name = "AccountNumberCol";
            this.AccountNumberCol.ReadOnly = true;
            // 
            // AccountNameCol
            // 
            this.AccountNameCol.DataPropertyName = "AccountName";
            this.AccountNameCol.HeaderText = "AccountName";
            this.AccountNameCol.Name = "AccountNameCol";
            this.AccountNameCol.ReadOnly = true;
            // 
            // ColAccountTypeName
            // 
            this.ColAccountTypeName.DataPropertyName = "AccountTypeName";
            this.ColAccountTypeName.HeaderText = "AccountTypeName";
            this.ColAccountTypeName.Name = "ColAccountTypeName";
            this.ColAccountTypeName.ReadOnly = true;
            // 
            // activeDataGridViewCheckBoxColumn
            // 
            this.activeDataGridViewCheckBoxColumn.DataPropertyName = "Active";
            this.activeDataGridViewCheckBoxColumn.HeaderText = "Active";
            this.activeDataGridViewCheckBoxColumn.Name = "activeDataGridViewCheckBoxColumn";
            this.activeDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // openingBalanceDataGridViewTextBoxColumn
            // 
            this.openingBalanceDataGridViewTextBoxColumn.DataPropertyName = "OpeningBalance";
            this.openingBalanceDataGridViewTextBoxColumn.HeaderText = "OpeningBalance";
            this.openingBalanceDataGridViewTextBoxColumn.Name = "openingBalanceDataGridViewTextBoxColumn";
            this.openingBalanceDataGridViewTextBoxColumn.ReadOnly = true;
            this.openingBalanceDataGridViewTextBoxColumn.Visible = false;
            // 
            // propertyCodeIDDataGridViewTextBoxColumn
            // 
            this.propertyCodeIDDataGridViewTextBoxColumn.DataPropertyName = "PropertyCodeID";
            this.propertyCodeIDDataGridViewTextBoxColumn.HeaderText = "PropertyCodeID";
            this.propertyCodeIDDataGridViewTextBoxColumn.Name = "propertyCodeIDDataGridViewTextBoxColumn";
            this.propertyCodeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.propertyCodeIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // cb_AccountType
            // 
            this.cb_AccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_AccountType.FormattingEnabled = true;
            this.cb_AccountType.Location = new System.Drawing.Point(194, 64);
            this.cb_AccountType.Name = "cb_AccountType";
            this.cb_AccountType.Size = new System.Drawing.Size(208, 21);
            this.cb_AccountType.TabIndex = 5;
            this.cb_AccountType.SelectedIndexChanged += new System.EventHandler(this.cb_AccountType_SelectedIndexChanged);
            // 
            // txt_AccountName
            // 
            this.txt_AccountName.Location = new System.Drawing.Point(194, 38);
            this.txt_AccountName.Name = "txt_AccountName";
            this.txt_AccountName.Size = new System.Drawing.Size(208, 20);
            this.txt_AccountName.TabIndex = 4;
            this.txt_AccountName.TextChanged += new System.EventHandler(this.txt_AccountName_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(493, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 86);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Account Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Account Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(82, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Account Type Name";
            // 
            // txt_AccountNumber1
            // 
            this.txt_AccountNumber1.Location = new System.Drawing.Point(194, 12);
            this.txt_AccountNumber1.Name = "txt_AccountNumber1";
            this.txt_AccountNumber1.PromptChar = '%';
            this.txt_AccountNumber1.Size = new System.Drawing.Size(131, 20);
            this.txt_AccountNumber1.TabIndex = 17;
            this.txt_AccountNumber1.TextChanged += new System.EventHandler(this.txt_AccountNumber1_TextChanged);
            // 
            // SearchHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(606, 370);
            this.Controls.Add(this.txt_AccountNumber1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_SelectCurrentRecord);
            this.Controls.Add(this.checkBox_Active);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.cb_AccountType);
            this.Controls.Add(this.txt_AccountName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SearchHeader";
            this.Text = "Search Header";
            this.Load += new System.EventHandler(this.SearchHeader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource2;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.Button btn_SelectCurrentRecord;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource1;
        private System.Windows.Forms.CheckBox checkBox_Active;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ComboBox cb_AccountType;
        private System.Windows.Forms.TextBox txt_AccountName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txt_AccountNumber1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountNumberCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAccountTypeName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openingBalanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn propertyCodeIDDataGridViewTextBoxColumn;
    }
}