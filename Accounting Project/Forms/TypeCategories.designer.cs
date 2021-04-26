namespace Accounting_GeneralLedger
{
    partial class TypeCategories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TypeCategories));
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_Id = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txt_Desc = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.datag = new System.Windows.Forms.DataGridView();
            this.typeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeCatNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeCategoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NewBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.aPPaymentTermsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aPPaymentTermsTableAdapter = new Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.APPaymentTermsTableAdapter();
            this.typeCategoriesTableAdapter = new Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.TypeCategoriesTableAdapter();
            this.NewSaveBtn = new System.Windows.Forms.Button();
            this.EditSaveBtn = new System.Windows.Forms.Button();
            this.UndoBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeCategoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aPPaymentTermsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Name
            // 
            this.txt_Name.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Name.Location = new System.Drawing.Point(304, 30);
            this.txt_Name.MaxLength = 10;
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Name.Size = new System.Drawing.Size(68, 21);
            this.txt_Name.TabIndex = 518;
            // 
            // txt_Id
            // 
            this.txt_Id.Enabled = false;
            this.txt_Id.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Id.Location = new System.Drawing.Point(93, 30);
            this.txt_Id.MaxLength = 5;
            this.txt_Id.Name = "txt_Id";
            this.txt_Id.ReadOnly = true;
            this.txt_Id.Size = new System.Drawing.Size(72, 21);
            this.txt_Id.TabIndex = 516;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Red;
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(15, 30);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(51, 13);
            this.Label2.TabIndex = 527;
            this.Label2.Text = "Type ID";
            // 
            // txt_Desc
            // 
            this.txt_Desc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Desc.Location = new System.Drawing.Point(93, 59);
            this.txt_Desc.MaxLength = 50;
            this.txt_Desc.Name = "txt_Desc";
            this.txt_Desc.Size = new System.Drawing.Size(279, 21);
            this.txt_Desc.TabIndex = 517;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Red;
            this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label1.Location = new System.Drawing.Point(15, 59);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(71, 13);
            this.Label1.TabIndex = 526;
            this.Label1.Text = "Description";
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
            this.typeIDDataGridViewTextBoxColumn,
            this.typeCatNameDataGridViewTextBoxColumn,
            this.tDescDataGridViewTextBoxColumn});
            this.datag.DataSource = this.typeCategoriesBindingSource;
            this.datag.Location = new System.Drawing.Point(2, 2);
            this.datag.Name = "datag";
            this.datag.ReadOnly = true;
            this.datag.RowHeadersWidth = 20;
            this.datag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datag.Size = new System.Drawing.Size(298, 134);
            this.datag.TabIndex = 529;
            this.datag.TabStop = false;
            this.datag.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datag_CellClick);
            this.datag.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datag_CellContentClick);
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
            this.typeCatNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tDescDataGridViewTextBoxColumn
            // 
            this.tDescDataGridViewTextBoxColumn.DataPropertyName = "TDesc";
            this.tDescDataGridViewTextBoxColumn.HeaderText = "TDesc";
            this.tDescDataGridViewTextBoxColumn.Name = "tDescDataGridViewTextBoxColumn";
            this.tDescDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeCategoriesBindingSource
            // 
            this.typeCategoriesBindingSource.DataMember = "TypeCategories";
            this.typeCategoriesBindingSource.DataSource = this.dbAccountingProjectDS;
            // 
            // dbAccountingProjectDS
            // 
            this.dbAccountingProjectDS.DataSetName = "dbAccountingProjectDS";
            this.dbAccountingProjectDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(176, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 530;
            this.label3.Text = "TypeCategory Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Id);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Controls.Add(this.txt_Name);
            this.groupBox1.Controls.Add(this.txt_Desc);
            this.groupBox1.Controls.Add(this.Label2);
            this.groupBox1.Location = new System.Drawing.Point(306, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 95);
            this.groupBox1.TabIndex = 531;
            this.groupBox1.TabStop = false;
            this.groupBox1.EnabledChanged += new System.EventHandler(this.groupBox1_EnabledChanged);
            // 
            // NewBtn
            // 
            this.NewBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewBtn.Image = ((System.Drawing.Image)(resources.GetObject("NewBtn.Image")));
            this.NewBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NewBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NewBtn.Location = new System.Drawing.Point(305, 113);
            this.NewBtn.Name = "NewBtn";
            this.NewBtn.Size = new System.Drawing.Size(75, 24);
            this.NewBtn.TabIndex = 519;
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
            this.EditBtn.Location = new System.Drawing.Point(387, 112);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(75, 24);
            this.EditBtn.TabIndex = 521;
            this.EditBtn.Text = "Edit";
            this.EditBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // aPPaymentTermsBindingSource
            // 
            this.aPPaymentTermsBindingSource.DataMember = "APPaymentTerms";
            this.aPPaymentTermsBindingSource.DataSource = this.dbAccountingProjectDS;
            // 
            // aPPaymentTermsTableAdapter
            // 
            this.aPPaymentTermsTableAdapter.ClearBeforeFill = true;
            // 
            // typeCategoriesTableAdapter
            // 
            this.typeCategoriesTableAdapter.ClearBeforeFill = true;
            // 
            // NewSaveBtn
            // 
            this.NewSaveBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewSaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("NewSaveBtn.Image")));
            this.NewSaveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NewSaveBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NewSaveBtn.Location = new System.Drawing.Point(306, 113);
            this.NewSaveBtn.Name = "NewSaveBtn";
            this.NewSaveBtn.Size = new System.Drawing.Size(75, 25);
            this.NewSaveBtn.TabIndex = 520;
            this.NewSaveBtn.Text = "Save";
            this.NewSaveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NewSaveBtn.UseVisualStyleBackColor = true;
            this.NewSaveBtn.Click += new System.EventHandler(this.NewSaveBtn_Click);
            // 
            // EditSaveBtn
            // 
            this.EditSaveBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditSaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditSaveBtn.Image")));
            this.EditSaveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EditSaveBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EditSaveBtn.Location = new System.Drawing.Point(386, 113);
            this.EditSaveBtn.Name = "EditSaveBtn";
            this.EditSaveBtn.Size = new System.Drawing.Size(75, 24);
            this.EditSaveBtn.TabIndex = 525;
            this.EditSaveBtn.Text = "Save";
            this.EditSaveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EditSaveBtn.UseVisualStyleBackColor = true;
            this.EditSaveBtn.Click += new System.EventHandler(this.EditSaveBtn_Click);
            // 
            // UndoBtn
            // 
            this.UndoBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UndoBtn.Image = ((System.Drawing.Image)(resources.GetObject("UndoBtn.Image")));
            this.UndoBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UndoBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UndoBtn.Location = new System.Drawing.Point(466, 113);
            this.UndoBtn.Name = "UndoBtn";
            this.UndoBtn.Size = new System.Drawing.Size(75, 24);
            this.UndoBtn.TabIndex = 522;
            this.UndoBtn.Text = "Undo";
            this.UndoBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UndoBtn.UseVisualStyleBackColor = true;
            this.UndoBtn.Click += new System.EventHandler(this.UndoBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("DeleteBtn.Image")));
            this.DeleteBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DeleteBtn.Location = new System.Drawing.Point(547, 113);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 24);
            this.DeleteBtn.TabIndex = 523;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.Image = ((System.Drawing.Image)(resources.GetObject("ExitBtn.Image")));
            this.ExitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExitBtn.Location = new System.Drawing.Point(628, 113);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(75, 24);
            this.ExitBtn.TabIndex = 524;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // TypeCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(707, 140);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.UndoBtn);
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.NewBtn);
            this.Controls.Add(this.datag);
            this.Controls.Add(this.EditSaveBtn);
            this.Controls.Add(this.NewSaveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TypeCategories";
            this.Text = "TypeCategories";
            this.Load += new System.EventHandler(this.TypeCategories_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeCategoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aPPaymentTermsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txt_Name;
        internal System.Windows.Forms.TextBox txt_Id;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txt_Desc;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DataGridView datag;
        internal System.Windows.Forms.Label label3;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.BindingSource aPPaymentTermsBindingSource;
        private Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.APPaymentTermsTableAdapter aPPaymentTermsTableAdapter;
        private System.Windows.Forms.BindingSource typeCategoriesBindingSource;
        private Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.TypeCategoriesTableAdapter typeCategoriesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeCatNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button NewSaveBtn;
        internal System.Windows.Forms.Button EditSaveBtn;
        internal System.Windows.Forms.Button NewBtn;
        internal System.Windows.Forms.Button EditBtn;
        internal System.Windows.Forms.Button UndoBtn;
        internal System.Windows.Forms.Button DeleteBtn;
        internal System.Windows.Forms.Button ExitBtn;

    }
}