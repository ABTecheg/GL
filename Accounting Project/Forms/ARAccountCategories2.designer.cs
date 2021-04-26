namespace Accounting_GeneralLedger
{
    partial class ARAccountCategories2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ARAccountCategories2));
            this.typeCatNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Desc = new System.Windows.Forms.TextBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.arAccontCatBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.catIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arAccCatCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aRAccountCat2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arAccontCatBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.txt_CatCode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnexit = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnundo = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btn_New = new System.Windows.Forms.Button();
            this.Btnsaveedit = new System.Windows.Forms.Button();
            this.btnSavenew = new System.Windows.Forms.Button();
            this.aPVendorAccountsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.typeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arAccontCatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ar_AccontCatTableAdapter = new Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.Ar_AccontCatTableAdapter();
            this.aPPaymentTermsTableAdapter = new Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.APPaymentTermsTableAdapter();
            this.aPPaymentTermsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS1 = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.typeCategoriesTableAdapter = new Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.TypeCategoriesTableAdapter();
            this.aPVendorAccountsTableAdapter = new Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.APVendorAccountsTableAdapter();
            this.typeCategoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aRAccountCat2TableAdapter = new Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.ARAccountCat2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arAccontCatBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aRAccountCat2BindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arAccontCatBindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aPVendorAccountsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arAccontCatBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPPaymentTermsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeCategoriesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // typeCatNameDataGridViewTextBoxColumn
            // 
            this.typeCatNameDataGridViewTextBoxColumn.DataPropertyName = "TypeCatName";
            this.typeCatNameDataGridViewTextBoxColumn.HeaderText = "TypeCatName";
            this.typeCatNameDataGridViewTextBoxColumn.Name = "typeCatNameDataGridViewTextBoxColumn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(164, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 543;
            this.label4.Text = "Category Code";
            // 
            // txt_Desc
            // 
            this.txt_Desc.Location = new System.Drawing.Point(86, 52);
            this.txt_Desc.MaxLength = 50;
            this.txt_Desc.Name = "txt_Desc";
            this.txt_Desc.Size = new System.Drawing.Size(324, 20);
            this.txt_Desc.TabIndex = 9;
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(85, 22);
            this.txt_ID.MaxLength = 4;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            this.txt_ID.Size = new System.Drawing.Size(79, 20);
            this.txt_ID.TabIndex = 12;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // arAccontCatBindingSource2
            // 
            this.arAccontCatBindingSource2.DataMember = "Ar_AccontCat";
            this.arAccontCatBindingSource2.DataSource = this.dbAccountingProjectDSBindingSource;
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
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.catIDDataGridViewTextBoxColumn,
            this.arAccCatCodeDataGridViewTextBoxColumn,
            this.catDescDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.aRAccountCat2BindingSource;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.Location = new System.Drawing.Point(4, 18);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(218, 128);
            this.dgv.TabIndex = 64;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // catIDDataGridViewTextBoxColumn
            // 
            this.catIDDataGridViewTextBoxColumn.DataPropertyName = "CatID";
            this.catIDDataGridViewTextBoxColumn.HeaderText = "CatID";
            this.catIDDataGridViewTextBoxColumn.Name = "catIDDataGridViewTextBoxColumn";
            this.catIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.catIDDataGridViewTextBoxColumn.Width = 59;
            // 
            // arAccCatCodeDataGridViewTextBoxColumn
            // 
            this.arAccCatCodeDataGridViewTextBoxColumn.DataPropertyName = "ArAccCatCode";
            this.arAccCatCodeDataGridViewTextBoxColumn.HeaderText = "ArAccCatCode";
            this.arAccCatCodeDataGridViewTextBoxColumn.Name = "arAccCatCodeDataGridViewTextBoxColumn";
            this.arAccCatCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.arAccCatCodeDataGridViewTextBoxColumn.Width = 102;
            // 
            // catDescDataGridViewTextBoxColumn
            // 
            this.catDescDataGridViewTextBoxColumn.DataPropertyName = "CatDesc";
            this.catDescDataGridViewTextBoxColumn.HeaderText = "CatDesc";
            this.catDescDataGridViewTextBoxColumn.Name = "catDescDataGridViewTextBoxColumn";
            this.catDescDataGridViewTextBoxColumn.ReadOnly = true;
            this.catDescDataGridViewTextBoxColumn.Width = 73;
            // 
            // aRAccountCat2BindingSource
            // 
            this.aRAccountCat2BindingSource.DataMember = "ARAccountCat2";
            this.aRAccountCat2BindingSource.DataSource = this.dbAccountingProjectDS;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(659, 24);
            this.menuStrip1.TabIndex = 66;
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
            // arAccontCatBindingSource1
            // 
            this.arAccontCatBindingSource1.DataMember = "Ar_AccontCat";
            this.arAccontCatBindingSource1.DataSource = this.dbAccountingProjectDSBindingSource;
            // 
            // txt_CatCode
            // 
            this.txt_CatCode.Location = new System.Drawing.Point(259, 19);
            this.txt_CatCode.MaxLength = 10;
            this.txt_CatCode.Name = "txt_CatCode";
            this.txt_CatCode.Size = new System.Drawing.Size(151, 20);
            this.txt_CatCode.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_ID);
            this.groupBox1.Controls.Add(this.txt_Desc);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_CatCode);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(224, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 87);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.EnabledChanged += new System.EventHandler(this.groupBox1_EnabledChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(6, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 541;
            this.label6.Text = "Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(22, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 542;
            this.label5.Text = " ID";
            // 
            // btnexit
            // 
            this.btnexit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnexit.Location = new System.Drawing.Point(551, 122);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(75, 24);
            this.btnexit.TabIndex = 539;
            this.btnexit.Text = "Exit";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btndelete
            // 
            this.btndelete.Enabled = false;
            this.btndelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.Image = ((System.Drawing.Image)(resources.GetObject("btndelete.Image")));
            this.btndelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btndelete.Location = new System.Drawing.Point(470, 122);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 24);
            this.btndelete.TabIndex = 538;
            this.btndelete.Text = "Delete";
            this.btndelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnundo
            // 
            this.btnundo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnundo.Image = ((System.Drawing.Image)(resources.GetObject("btnundo.Image")));
            this.btnundo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnundo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnundo.Location = new System.Drawing.Point(389, 122);
            this.btnundo.Name = "btnundo";
            this.btnundo.Size = new System.Drawing.Size(75, 24);
            this.btnundo.TabIndex = 537;
            this.btnundo.Text = "Undo";
            this.btnundo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnundo.UseVisualStyleBackColor = true;
            this.btnundo.Click += new System.EventHandler(this.btnundo_Click);
            // 
            // btnedit
            // 
            this.btnedit.Enabled = false;
            this.btnedit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnedit.Image = ((System.Drawing.Image)(resources.GetObject("btnedit.Image")));
            this.btnedit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnedit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnedit.Location = new System.Drawing.Point(310, 122);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(75, 24);
            this.btnedit.TabIndex = 536;
            this.btnedit.Text = "Edit";
            this.btnedit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btn_New
            // 
            this.btn_New.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_New.Image = ((System.Drawing.Image)(resources.GetObject("btn_New.Image")));
            this.btn_New.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_New.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_New.Location = new System.Drawing.Point(228, 122);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(75, 26);
            this.btn_New.TabIndex = 534;
            this.btn_New.Text = "New";
            this.btn_New.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // Btnsaveedit
            // 
            this.Btnsaveedit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnsaveedit.Image = ((System.Drawing.Image)(resources.GetObject("Btnsaveedit.Image")));
            this.Btnsaveedit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btnsaveedit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Btnsaveedit.Location = new System.Drawing.Point(309, 122);
            this.Btnsaveedit.Name = "Btnsaveedit";
            this.Btnsaveedit.Size = new System.Drawing.Size(75, 24);
            this.Btnsaveedit.TabIndex = 540;
            this.Btnsaveedit.Text = "Save";
            this.Btnsaveedit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btnsaveedit.UseVisualStyleBackColor = true;
            this.Btnsaveedit.Click += new System.EventHandler(this.Btnsaveedit_Click);
            // 
            // btnSavenew
            // 
            this.btnSavenew.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavenew.Image = ((System.Drawing.Image)(resources.GetObject("btnSavenew.Image")));
            this.btnSavenew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSavenew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSavenew.Location = new System.Drawing.Point(229, 123);
            this.btnSavenew.Name = "btnSavenew";
            this.btnSavenew.Size = new System.Drawing.Size(75, 25);
            this.btnSavenew.TabIndex = 535;
            this.btnSavenew.Text = "Save";
            this.btnSavenew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSavenew.UseVisualStyleBackColor = true;
            this.btnSavenew.Click += new System.EventHandler(this.btnSavenew_Click);
            // 
            // aPVendorAccountsBindingSource
            // 
            this.aPVendorAccountsBindingSource.DataMember = "APVendorAccounts";
            this.aPVendorAccountsBindingSource.DataSource = this.dbAccountingProjectDSBindingSource;
            // 
            // typeIDDataGridViewTextBoxColumn
            // 
            this.typeIDDataGridViewTextBoxColumn.DataPropertyName = "TypeID";
            this.typeIDDataGridViewTextBoxColumn.HeaderText = "TypeID";
            this.typeIDDataGridViewTextBoxColumn.Name = "typeIDDataGridViewTextBoxColumn";
            this.typeIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tDescDataGridViewTextBoxColumn
            // 
            this.tDescDataGridViewTextBoxColumn.DataPropertyName = "TDesc";
            this.tDescDataGridViewTextBoxColumn.HeaderText = "TDesc";
            this.tDescDataGridViewTextBoxColumn.Name = "tDescDataGridViewTextBoxColumn";
            // 
            // arAccontCatBindingSource
            // 
            this.arAccontCatBindingSource.DataMember = "Ar_AccontCat";
            // 
            // ar_AccontCatTableAdapter
            // 
            this.ar_AccontCatTableAdapter.ClearBeforeFill = true;
            // 
            // aPPaymentTermsTableAdapter
            // 
            this.aPPaymentTermsTableAdapter.ClearBeforeFill = true;
            // 
            // aPPaymentTermsBindingSource
            // 
            this.aPPaymentTermsBindingSource.DataMember = "APPaymentTerms";
            this.aPPaymentTermsBindingSource.DataSource = this.dbAccountingProjectDS1;
            // 
            // dbAccountingProjectDS1
            // 
            this.dbAccountingProjectDS1.DataSetName = "dbAccountingProjectDS";
            this.dbAccountingProjectDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // typeCategoriesTableAdapter
            // 
            this.typeCategoriesTableAdapter.ClearBeforeFill = true;
            // 
            // aPVendorAccountsTableAdapter
            // 
            this.aPVendorAccountsTableAdapter.ClearBeforeFill = true;
            // 
            // typeCategoriesBindingSource
            // 
            this.typeCategoriesBindingSource.DataMember = "TypeCategories";
            this.typeCategoriesBindingSource.DataSource = this.dbAccountingProjectDS1;
            // 
            // aRAccountCat2TableAdapter
            // 
            this.aRAccountCat2TableAdapter.ClearBeforeFill = true;
            // 
            // ARAccountCategories2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(659, 158);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btnundo);
            this.Controls.Add(this.btnSavenew);
            this.Controls.Add(this.Btnsaveedit);
            this.Controls.Add(this.btn_New);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ARAccountCategories2";
            this.Text = "ARAccountCategories2";
            this.Load += new System.EventHandler(this.ARAccountCategories2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arAccontCatBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aRAccountCat2BindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arAccontCatBindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aPVendorAccountsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arAccontCatBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPPaymentTermsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeCategoriesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn catDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn arAccCatCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.Ar_AccontCatTableAdapter ar_AccontCatTableAdapter;
        internal System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeCatNameDataGridViewTextBoxColumn;
        internal System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn catIDDataGridViewTextBoxColumn;
        internal System.Windows.Forms.Button btnundo;
        private Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.APPaymentTermsTableAdapter aPPaymentTermsTableAdapter;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Desc;
        private System.Windows.Forms.BindingSource aPPaymentTermsBindingSource;
        private dbAccountingProjectDS dbAccountingProjectDS1;
        private Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.TypeCategoriesTableAdapter typeCategoriesTableAdapter;
        private System.Windows.Forms.BindingSource arAccontCatBindingSource;
        private Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.APVendorAccountsTableAdapter aPVendorAccountsTableAdapter;
        private System.Windows.Forms.BindingSource typeCategoriesBindingSource;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.BindingSource arAccontCatBindingSource2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btnedit;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.TextBox txt_CatCode;
        internal System.Windows.Forms.Button Btnsaveedit;
        internal System.Windows.Forms.Button btnSavenew;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource arAccontCatBindingSource1;
        private System.Windows.Forms.BindingSource aPVendorAccountsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource aRAccountCat2BindingSource;
        private Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.ARAccountCat2TableAdapter aRAccountCat2TableAdapter;
    }
}