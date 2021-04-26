namespace Accounting_GeneralLedger
{
    partial class ARAccountCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ARAccountCategory));
            this.txt_CatCode = new System.Windows.Forms.TextBox();
            this.txt_Desc = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.catIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arAccCatCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arAccontCatBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.arAccontCatBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPVendorAccountsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeCatNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ar_AccontCatTableAdapter = new Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.Ar_AccontCatTableAdapter();
            this.aPVendorAccountsTableAdapter = new Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.APVendorAccountsTableAdapter();
            this.arAccontCatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.typeCategoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS1 = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.aPPaymentTermsTableAdapter = new Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.APPaymentTermsTableAdapter();
            this.typeCategoriesTableAdapter = new Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.TypeCategoriesTableAdapter();
            this.aPPaymentTermsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnexit = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnundo = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btn_New = new System.Windows.Forms.Button();
            this.Btnsaveedit = new System.Windows.Forms.Button();
            this.btnSavenew = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arAccontCatBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arAccontCatBindingSource1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aPVendorAccountsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arAccontCatBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeCategoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPPaymentTermsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_CatCode
            // 
            this.txt_CatCode.Location = new System.Drawing.Point(246, 19);
            this.txt_CatCode.MaxLength = 10;
            this.txt_CatCode.Name = "txt_CatCode";
            this.txt_CatCode.Size = new System.Drawing.Size(145, 20);
            this.txt_CatCode.TabIndex = 7;
            // 
            // txt_Desc
            // 
            this.txt_Desc.Location = new System.Drawing.Point(73, 52);
            this.txt_Desc.MaxLength = 50;
            this.txt_Desc.Name = "txt_Desc";
            this.txt_Desc.Size = new System.Drawing.Size(318, 20);
            this.txt_Desc.TabIndex = 9;
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
            this.groupBox1.Location = new System.Drawing.Point(233, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 88);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.EnabledChanged += new System.EventHandler(this.groupBox1_EnabledChanged);
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(151, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 543;
            this.label4.Text = "Category Code";
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(72, 22);
            this.txt_ID.MaxLength = 4;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            this.txt_ID.Size = new System.Drawing.Size(79, 20);
            this.txt_ID.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(3, 55);
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
            this.label5.Location = new System.Drawing.Point(9, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 542;
            this.label5.Text = "Type ID";
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
            this.catIDDataGridViewTextBoxColumn,
            this.arAccCatCodeDataGridViewTextBoxColumn,
            this.catDescDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.arAccontCatBindingSource2;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.Location = new System.Drawing.Point(3, 12);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(224, 128);
            this.dgv.TabIndex = 54;
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // arAccontCatBindingSource1
            // 
            this.arAccontCatBindingSource1.DataMember = "Ar_AccontCat";
            this.arAccontCatBindingSource1.DataSource = this.dbAccountingProjectDSBindingSource;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(653, 24);
            this.menuStrip1.TabIndex = 63;
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
            // aPVendorAccountsBindingSource
            // 
            this.aPVendorAccountsBindingSource.DataMember = "APVendorAccounts";
            this.aPVendorAccountsBindingSource.DataSource = this.dbAccountingProjectDSBindingSource;
            // 
            // tDescDataGridViewTextBoxColumn
            // 
            this.tDescDataGridViewTextBoxColumn.DataPropertyName = "TDesc";
            this.tDescDataGridViewTextBoxColumn.HeaderText = "TDesc";
            this.tDescDataGridViewTextBoxColumn.Name = "tDescDataGridViewTextBoxColumn";
            // 
            // typeIDDataGridViewTextBoxColumn
            // 
            this.typeIDDataGridViewTextBoxColumn.DataPropertyName = "TypeID";
            this.typeIDDataGridViewTextBoxColumn.HeaderText = "TypeID";
            this.typeIDDataGridViewTextBoxColumn.Name = "typeIDDataGridViewTextBoxColumn";
            this.typeIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeCatNameDataGridViewTextBoxColumn
            // 
            this.typeCatNameDataGridViewTextBoxColumn.DataPropertyName = "TypeCatName";
            this.typeCatNameDataGridViewTextBoxColumn.HeaderText = "TypeCatName";
            this.typeCatNameDataGridViewTextBoxColumn.Name = "typeCatNameDataGridViewTextBoxColumn";
            // 
            // ar_AccontCatTableAdapter
            // 
            this.ar_AccontCatTableAdapter.ClearBeforeFill = true;
            // 
            // aPVendorAccountsTableAdapter
            // 
            this.aPVendorAccountsTableAdapter.ClearBeforeFill = true;
            // 
            // arAccontCatBindingSource
            // 
            this.arAccontCatBindingSource.DataMember = "Ar_AccontCat";
            // 
            // typeCategoriesBindingSource
            // 
            this.typeCategoriesBindingSource.DataMember = "TypeCategories";
            this.typeCategoriesBindingSource.DataSource = this.dbAccountingProjectDS1;
            // 
            // dbAccountingProjectDS1
            // 
            this.dbAccountingProjectDS1.DataSetName = "dbAccountingProjectDS";
            this.dbAccountingProjectDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aPPaymentTermsTableAdapter
            // 
            this.aPPaymentTermsTableAdapter.ClearBeforeFill = true;
            // 
            // typeCategoriesTableAdapter
            // 
            this.typeCategoriesTableAdapter.ClearBeforeFill = true;
            // 
            // aPPaymentTermsBindingSource
            // 
            this.aPPaymentTermsBindingSource.DataMember = "APPaymentTerms";
            this.aPPaymentTermsBindingSource.DataSource = this.dbAccountingProjectDS1;
            // 
            // btnexit
            // 
            this.btnexit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnexit.Location = new System.Drawing.Point(555, 111);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(75, 24);
            this.btnexit.TabIndex = 546;
            this.btnexit.Text = "Exit";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btndelete
            // 
            this.btndelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.Image = ((System.Drawing.Image)(resources.GetObject("btndelete.Image")));
            this.btndelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btndelete.Location = new System.Drawing.Point(474, 111);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 24);
            this.btndelete.TabIndex = 545;
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
            this.btnundo.Location = new System.Drawing.Point(393, 111);
            this.btnundo.Name = "btnundo";
            this.btnundo.Size = new System.Drawing.Size(75, 24);
            this.btnundo.TabIndex = 544;
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
            this.btnedit.Location = new System.Drawing.Point(313, 112);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(75, 24);
            this.btnedit.TabIndex = 543;
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
            this.btn_New.Location = new System.Drawing.Point(233, 112);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(75, 24);
            this.btn_New.TabIndex = 541;
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
            this.Btnsaveedit.Location = new System.Drawing.Point(313, 111);
            this.Btnsaveedit.Name = "Btnsaveedit";
            this.Btnsaveedit.Size = new System.Drawing.Size(75, 24);
            this.Btnsaveedit.TabIndex = 547;
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
            this.btnSavenew.Location = new System.Drawing.Point(233, 111);
            this.btnSavenew.Name = "btnSavenew";
            this.btnSavenew.Size = new System.Drawing.Size(75, 25);
            this.btnSavenew.TabIndex = 542;
            this.btnSavenew.Text = "Save";
            this.btnSavenew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSavenew.UseVisualStyleBackColor = true;
            this.btnSavenew.Click += new System.EventHandler(this.btnSavenew_Click);
            // 
            // ARAccountCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(653, 147);
            this.ControlBox = false;
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnundo);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.Btnsaveedit);
            this.Controls.Add(this.btnSavenew);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ARAccountCategory";
            this.Text = "ARAccountCategory";
            this.Load += new System.EventHandler(this.ARAccountCategory_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arAccontCatBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arAccontCatBindingSource1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aPVendorAccountsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arAccontCatBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeCategoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPPaymentTermsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.TextBox txt_CatCode;
        private System.Windows.Forms.TextBox txt_Desc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource arAccontCatBindingSource;
        private Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.Ar_AccontCatTableAdapter ar_AccontCatTableAdapter;
        private System.Windows.Forms.BindingSource arAccontCatBindingSource1;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.BindingSource aPVendorAccountsBindingSource;
        private Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.APVendorAccountsTableAdapter aPVendorAccountsTableAdapter;
        private System.Windows.Forms.BindingSource arAccontCatBindingSource2;
        private System.Windows.Forms.DataGridViewTextBoxColumn catIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn arAccCatCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn catDescDataGridViewTextBoxColumn;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn tDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource typeCategoriesBindingSource;
        private dbAccountingProjectDS dbAccountingProjectDS1;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeCatNameDataGridViewTextBoxColumn;
        private Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.APPaymentTermsTableAdapter aPPaymentTermsTableAdapter;
        private Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.TypeCategoriesTableAdapter typeCategoriesTableAdapter;
        private System.Windows.Forms.BindingSource aPPaymentTermsBindingSource;
        internal System.Windows.Forms.Button btnexit;
        internal System.Windows.Forms.Button btndelete;
        internal System.Windows.Forms.Button btnundo;
        internal System.Windows.Forms.Button btnedit;
        internal System.Windows.Forms.Button btn_New;
        internal System.Windows.Forms.Button Btnsaveedit;
        internal System.Windows.Forms.Button btnSavenew;
    }
}