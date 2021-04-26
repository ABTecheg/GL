namespace Accounting_GeneralLedger
{
    partial class ARDiscountCategories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ARDiscountCategories));
            this.datag = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aRDiscountCategoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.UndoBtn = new System.Windows.Forms.Button();
            this.EditSaveBtn = new System.Windows.Forms.Button();
            this.NewSaveBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_Id = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txt_Desc = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.NewBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.typeCategoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aPPaymentTermsTableAdapter = new Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.APPaymentTermsTableAdapter();
            this.typeCategoriesTableAdapter = new Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.TypeCategoriesTableAdapter();
            this.aPPaymentTermsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aRDiscountCategoriesTableAdapter = new Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.ARDiscountCategoriesTableAdapter();
            this.aRDiscountCategoriesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.datag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aRDiscountCategoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typeCategoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPPaymentTermsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aRDiscountCategoriesBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // datag
            // 
            this.datag.AllowUserToAddRows = false;
            this.datag.AllowUserToDeleteRows = false;
            this.datag.AllowUserToResizeColumns = false;
            this.datag.AllowUserToResizeRows = false;
            this.datag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.datag.AutoGenerateColumns = false;
            this.datag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datag.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.CatName,
            this.catDescDataGridViewTextBoxColumn});
            this.datag.DataSource = this.aRDiscountCategoriesBindingSource;
            this.datag.Location = new System.Drawing.Point(-4, 1);
            this.datag.Name = "datag";
            this.datag.ReadOnly = true;
            this.datag.RowHeadersWidth = 20;
            this.datag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datag.Size = new System.Drawing.Size(298, 180);
            this.datag.TabIndex = 543;
            this.datag.TabStop = false;
            this.datag.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datag_CellClick);
            this.datag.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datag_CellContentClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CatName
            // 
            this.CatName.DataPropertyName = "CatName";
            this.CatName.HeaderText = "CatName";
            this.CatName.Name = "CatName";
            this.CatName.ReadOnly = true;
            // 
            // catDescDataGridViewTextBoxColumn
            // 
            this.catDescDataGridViewTextBoxColumn.DataPropertyName = "CatDesc";
            this.catDescDataGridViewTextBoxColumn.HeaderText = "CatDesc";
            this.catDescDataGridViewTextBoxColumn.Name = "catDescDataGridViewTextBoxColumn";
            this.catDescDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aRDiscountCategoriesBindingSource
            // 
            this.aRDiscountCategoriesBindingSource.DataMember = "ARDiscountCategories";
            this.aRDiscountCategoriesBindingSource.DataSource = this.dbAccountingProjectDS;
            // 
            // dbAccountingProjectDS
            // 
            this.dbAccountingProjectDS.DataSetName = "dbAccountingProjectDS";
            this.dbAccountingProjectDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.Image = ((System.Drawing.Image)(resources.GetObject("ExitBtn.Image")));
            this.ExitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExitBtn.Location = new System.Drawing.Point(621, 151);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(75, 24);
            this.ExitBtn.TabIndex = 539;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("DeleteBtn.Image")));
            this.DeleteBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DeleteBtn.Location = new System.Drawing.Point(540, 151);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 24);
            this.DeleteBtn.TabIndex = 538;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // UndoBtn
            // 
            this.UndoBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UndoBtn.Image = ((System.Drawing.Image)(resources.GetObject("UndoBtn.Image")));
            this.UndoBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UndoBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UndoBtn.Location = new System.Drawing.Point(459, 151);
            this.UndoBtn.Name = "UndoBtn";
            this.UndoBtn.Size = new System.Drawing.Size(75, 24);
            this.UndoBtn.TabIndex = 537;
            this.UndoBtn.Text = "Undo";
            this.UndoBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UndoBtn.UseVisualStyleBackColor = true;
            this.UndoBtn.Click += new System.EventHandler(this.UndoBtn_Click);
            // 
            // EditSaveBtn
            // 
            this.EditSaveBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditSaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditSaveBtn.Image")));
            this.EditSaveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EditSaveBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EditSaveBtn.Location = new System.Drawing.Point(379, 151);
            this.EditSaveBtn.Name = "EditSaveBtn";
            this.EditSaveBtn.Size = new System.Drawing.Size(75, 24);
            this.EditSaveBtn.TabIndex = 540;
            this.EditSaveBtn.Text = "Save";
            this.EditSaveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EditSaveBtn.UseVisualStyleBackColor = true;
            this.EditSaveBtn.Click += new System.EventHandler(this.EditSaveBtn_Click);
            // 
            // NewSaveBtn
            // 
            this.NewSaveBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewSaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("NewSaveBtn.Image")));
            this.NewSaveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NewSaveBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NewSaveBtn.Location = new System.Drawing.Point(298, 151);
            this.NewSaveBtn.Name = "NewSaveBtn";
            this.NewSaveBtn.Size = new System.Drawing.Size(75, 24);
            this.NewSaveBtn.TabIndex = 535;
            this.NewSaveBtn.Text = "Save";
            this.NewSaveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NewSaveBtn.UseVisualStyleBackColor = true;
            this.NewSaveBtn.Click += new System.EventHandler(this.NewSaveBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_Name);
            this.groupBox1.Controls.Add(this.txt_Id);
            this.groupBox1.Controls.Add(this.Label2);
            this.groupBox1.Controls.Add(this.txt_Desc);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(310, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 128);
            this.groupBox1.TabIndex = 545;
            this.groupBox1.TabStop = false;
            this.groupBox1.EnabledChanged += new System.EventHandler(this.groupBox1_EnabledChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 550;
            this.label3.Text = "TypeCategory Name";
            // 
            // txt_Name
            // 
            this.txt_Name.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Name.Location = new System.Drawing.Point(134, 53);
            this.txt_Name.MaxLength = 50;
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Name.Size = new System.Drawing.Size(236, 21);
            this.txt_Name.TabIndex = 547;
            // 
            // txt_Id
            // 
            this.txt_Id.Enabled = false;
            this.txt_Id.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Id.Location = new System.Drawing.Point(134, 19);
            this.txt_Id.MaxLength = 5;
            this.txt_Id.Name = "txt_Id";
            this.txt_Id.ReadOnly = true;
            this.txt_Id.Size = new System.Drawing.Size(72, 21);
            this.txt_Id.TabIndex = 545;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Red;
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(39, 19);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(51, 13);
            this.Label2.TabIndex = 549;
            this.Label2.Text = "Type ID";
            // 
            // txt_Desc
            // 
            this.txt_Desc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Desc.Location = new System.Drawing.Point(134, 91);
            this.txt_Desc.MaxLength = 50;
            this.txt_Desc.Name = "txt_Desc";
            this.txt_Desc.Size = new System.Drawing.Size(236, 21);
            this.txt_Desc.TabIndex = 546;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Red;
            this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label1.Location = new System.Drawing.Point(6, 91);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(71, 13);
            this.Label1.TabIndex = 548;
            this.Label1.Text = "Description";
            // 
            // button14
            // 
            this.button14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.Image = ((System.Drawing.Image)(resources.GetObject("button14.Image")));
            this.button14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button14.Location = new System.Drawing.Point(621, 151);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 24);
            this.button14.TabIndex = 539;
            this.button14.Text = "Exit";
            this.button14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Image = ((System.Drawing.Image)(resources.GetObject("button13.Image")));
            this.button13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button13.Location = new System.Drawing.Point(540, 151);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 24);
            this.button13.TabIndex = 538;
            this.button13.Text = "Delete";
            this.button13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Image = ((System.Drawing.Image)(resources.GetObject("button12.Image")));
            this.button12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button12.Location = new System.Drawing.Point(459, 151);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 24);
            this.button12.TabIndex = 537;
            this.button12.Text = "Undo";
            this.button12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.UndoBtn_Click);
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Image = ((System.Drawing.Image)(resources.GetObject("button11.Image")));
            this.button11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button11.Location = new System.Drawing.Point(380, 151);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 24);
            this.button11.TabIndex = 536;
            this.button11.Text = "Edit";
            this.button11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button8.Location = new System.Drawing.Point(299, 151);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 24);
            this.button8.TabIndex = 535;
            this.button8.Text = "Save";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.NewSaveBtn_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button9.Location = new System.Drawing.Point(379, 151);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 24);
            this.button9.TabIndex = 540;
            this.button9.Text = "Save";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.EditSaveBtn_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Image = ((System.Drawing.Image)(resources.GetObject("button10.Image")));
            this.button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button10.Location = new System.Drawing.Point(298, 151);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 24);
            this.button10.TabIndex = 534;
            this.button10.Text = "New";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.NewBtn_Click);
            // 
            // NewBtn
            // 
            this.NewBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewBtn.Image = ((System.Drawing.Image)(resources.GetObject("NewBtn.Image")));
            this.NewBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NewBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NewBtn.Location = new System.Drawing.Point(298, 151);
            this.NewBtn.Name = "NewBtn";
            this.NewBtn.Size = new System.Drawing.Size(75, 24);
            this.NewBtn.TabIndex = 534;
            this.NewBtn.Text = "New";
            this.NewBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NewBtn.UseVisualStyleBackColor = true;
            this.NewBtn.Click += new System.EventHandler(this.NewBtn_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditBtn.Image")));
            this.EditBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EditBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EditBtn.Location = new System.Drawing.Point(380, 151);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(75, 24);
            this.EditBtn.TabIndex = 536;
            this.EditBtn.Text = "Edit";
            this.EditBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // typeCategoriesBindingSource
            // 
            this.typeCategoriesBindingSource.DataMember = "TypeCategories";
            this.typeCategoriesBindingSource.DataSource = this.dbAccountingProjectDS;
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
            this.aPPaymentTermsBindingSource.DataSource = this.dbAccountingProjectDS;
            // 
            // aRDiscountCategoriesTableAdapter
            // 
            this.aRDiscountCategoriesTableAdapter.ClearBeforeFill = true;
            // 
            // aRDiscountCategoriesBindingSource1
            // 
            this.aRDiscountCategoriesBindingSource1.DataMember = "ARDiscountCategories";
            this.aRDiscountCategoriesBindingSource1.DataSource = this.dbAccountingProjectDS;
            // 
            // ARDiscountCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(698, 183);
            this.ControlBox = false;
            this.Controls.Add(this.button14);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.UndoBtn);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.NewBtn);
            this.Controls.Add(this.datag);
            this.Controls.Add(this.EditSaveBtn);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.NewSaveBtn);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ARDiscountCategories";
            this.Text = "ARDiscountCategories";
            this.Load += new System.EventHandler(this.ARDiscountCategories_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aRDiscountCategoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typeCategoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPPaymentTermsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aRDiscountCategoriesBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource typeCategoriesBindingSource;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.APPaymentTermsTableAdapter aPPaymentTermsTableAdapter;
        private Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.TypeCategoriesTableAdapter typeCategoriesTableAdapter;
        private System.Windows.Forms.BindingSource aPPaymentTermsBindingSource;
        internal System.Windows.Forms.Button ExitBtn;
        internal System.Windows.Forms.Button DeleteBtn;
        internal System.Windows.Forms.Button UndoBtn;
        internal System.Windows.Forms.DataGridView datag;
        internal System.Windows.Forms.Button EditSaveBtn;
        internal System.Windows.Forms.Button NewSaveBtn;
        private System.Windows.Forms.BindingSource aRDiscountCategoriesBindingSource;
        private Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.ARDiscountCategoriesTableAdapter aRDiscountCategoriesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn catCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource aRDiscountCategoriesBindingSource1;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txt_Name;
        internal System.Windows.Forms.TextBox txt_Id;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txt_Desc;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button button14;
        internal System.Windows.Forms.Button button13;
        internal System.Windows.Forms.Button button12;
        internal System.Windows.Forms.Button button11;
        internal System.Windows.Forms.Button button8;
        internal System.Windows.Forms.Button button9;
        internal System.Windows.Forms.Button button10;
        internal System.Windows.Forms.Button NewBtn;
        internal System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn catDescDataGridViewTextBoxColumn;
    }
}