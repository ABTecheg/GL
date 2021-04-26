namespace Accounting_GeneralLedger
{
    partial class TaxOffice
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
            this.taxOfficeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxOfficeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_SaveChanges = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_New = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_TaxOfficeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_TaxOfficeID = new System.Windows.Forms.TextBox();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnundo = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.Btnsaveedit = new System.Windows.Forms.Button();
            this.btnSavenew = new System.Windows.Forms.Button();
            this.Lock82 = new System.Windows.Forms.GroupBox();
            this.Lock83 = new System.Windows.Forms.GroupBox();
            this.Lock84 = new System.Windows.Forms.GroupBox();
            this.aPTaxOfficeTableAdapter = new Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.APTaxOfficeTableAdapter();
            this.aPGeneralSetupTableAdapter = new Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.APGeneralSetupTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.Lock82.SuspendLayout();
            this.Lock83.SuspendLayout();
            this.Lock84.SuspendLayout();
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
            this.taxOfficeIDDataGridViewTextBoxColumn,
            this.taxOfficeNameDataGridViewTextBoxColumn});
            this.dgv.DataMember = "APTaxOffice";
            this.dgv.DataSource = this.dbAccountingProjectDS;
            this.dgv.Location = new System.Drawing.Point(1, -1);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(246, 119);
            this.dgv.TabIndex = 0;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseClick);
            // 
            // taxOfficeIDDataGridViewTextBoxColumn
            // 
            this.taxOfficeIDDataGridViewTextBoxColumn.DataPropertyName = "TaxOfficeID";
            this.taxOfficeIDDataGridViewTextBoxColumn.HeaderText = "TaxOfficeID";
            this.taxOfficeIDDataGridViewTextBoxColumn.Name = "taxOfficeIDDataGridViewTextBoxColumn";
            this.taxOfficeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.taxOfficeIDDataGridViewTextBoxColumn.Width = 89;
            // 
            // taxOfficeNameDataGridViewTextBoxColumn
            // 
            this.taxOfficeNameDataGridViewTextBoxColumn.DataPropertyName = "TaxOfficeName";
            this.taxOfficeNameDataGridViewTextBoxColumn.HeaderText = "TaxOfficeName";
            this.taxOfficeNameDataGridViewTextBoxColumn.Name = "taxOfficeNameDataGridViewTextBoxColumn";
            this.taxOfficeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.taxOfficeNameDataGridViewTextBoxColumn.Width = 106;
            // 
            // dbAccountingProjectDS
            // 
            this.dbAccountingProjectDS.DataSetName = "dbAccountingProjectDS";
            this.dbAccountingProjectDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dbAccountingProjectDSBindingSource
            // 
            this.dbAccountingProjectDSBindingSource.DataMember = "APTaxOffice";
            this.dbAccountingProjectDSBindingSource.DataSource = this.dbAccountingProjectDS;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(515, 24);
            this.menuStrip1.TabIndex = 1;
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
            // btn_SaveChanges
            // 
            this.btn_SaveChanges.Location = new System.Drawing.Point(512, 12);
            this.btn_SaveChanges.Name = "btn_SaveChanges";
            this.btn_SaveChanges.Size = new System.Drawing.Size(75, 22);
            this.btn_SaveChanges.TabIndex = 2;
            this.btn_SaveChanges.Text = "Save Changes";
            this.btn_SaveChanges.UseVisualStyleBackColor = true;
            this.btn_SaveChanges.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(0, 6);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(64, 28);
            this.btn_New.TabIndex = 7;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_TaxOfficeName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_TaxOfficeID);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(253, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 119);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.EnabledChanged += new System.EventHandler(this.groupBox1_EnabledChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tax Office Name";
            // 
            // txt_TaxOfficeName
            // 
            this.txt_TaxOfficeName.Location = new System.Drawing.Point(110, 58);
            this.txt_TaxOfficeName.MaxLength = 50;
            this.txt_TaxOfficeName.Name = "txt_TaxOfficeName";
            this.txt_TaxOfficeName.Size = new System.Drawing.Size(115, 20);
            this.txt_TaxOfficeName.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tax Office ID";
            // 
            // txt_TaxOfficeID
            // 
            this.txt_TaxOfficeID.Location = new System.Drawing.Point(110, 32);
            this.txt_TaxOfficeID.Name = "txt_TaxOfficeID";
            this.txt_TaxOfficeID.ReadOnly = true;
            this.txt_TaxOfficeID.Size = new System.Drawing.Size(72, 20);
            this.txt_TaxOfficeID.TabIndex = 7;
            // 
            // btnedit
            // 
            this.btnedit.Enabled = false;
            this.btnedit.Location = new System.Drawing.Point(0, 6);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(64, 28);
            this.btnedit.TabIndex = 48;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(426, 132);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(64, 28);
            this.btnexit.TabIndex = 50;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnundo
            // 
            this.btnundo.Location = new System.Drawing.Point(323, 132);
            this.btnundo.Name = "btnundo";
            this.btnundo.Size = new System.Drawing.Size(64, 28);
            this.btnundo.TabIndex = 49;
            this.btnundo.Text = "Undo";
            this.btnundo.UseVisualStyleBackColor = true;
            this.btnundo.Click += new System.EventHandler(this.btnundo_Click);
            // 
            // btndelete
            // 
            this.btndelete.Enabled = false;
            this.btndelete.Location = new System.Drawing.Point(0, 6);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(64, 28);
            this.btndelete.TabIndex = 46;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // Btnsaveedit
            // 
            this.Btnsaveedit.Location = new System.Drawing.Point(0, 6);
            this.Btnsaveedit.Name = "Btnsaveedit";
            this.Btnsaveedit.Size = new System.Drawing.Size(64, 28);
            this.Btnsaveedit.TabIndex = 45;
            this.Btnsaveedit.Text = "Save";
            this.Btnsaveedit.UseVisualStyleBackColor = true;
            this.Btnsaveedit.Click += new System.EventHandler(this.Btnsaveedit_Click);
            // 
            // btnSavenew
            // 
            this.btnSavenew.Location = new System.Drawing.Point(0, 6);
            this.btnSavenew.Name = "btnSavenew";
            this.btnSavenew.Size = new System.Drawing.Size(64, 28);
            this.btnSavenew.TabIndex = 47;
            this.btnSavenew.Text = "Save";
            this.btnSavenew.UseVisualStyleBackColor = true;
            this.btnSavenew.Click += new System.EventHandler(this.btnSavenew_Click);
            // 
            // Lock82
            // 
            this.Lock82.Controls.Add(this.btn_New);
            this.Lock82.Controls.Add(this.btnSavenew);
            this.Lock82.Location = new System.Drawing.Point(14, 126);
            this.Lock82.Name = "Lock82";
            this.Lock82.Size = new System.Drawing.Size(64, 34);
            this.Lock82.TabIndex = 51;
            this.Lock82.TabStop = false;
            this.Lock82.Tag = "82";
            // 
            // Lock83
            // 
            this.Lock83.Controls.Add(this.btnedit);
            this.Lock83.Controls.Add(this.Btnsaveedit);
            this.Lock83.Location = new System.Drawing.Point(117, 126);
            this.Lock83.Name = "Lock83";
            this.Lock83.Size = new System.Drawing.Size(64, 34);
            this.Lock83.TabIndex = 52;
            this.Lock83.TabStop = false;
            this.Lock83.Tag = "83";
            // 
            // Lock84
            // 
            this.Lock84.Controls.Add(this.btndelete);
            this.Lock84.Location = new System.Drawing.Point(220, 126);
            this.Lock84.Name = "Lock84";
            this.Lock84.Size = new System.Drawing.Size(64, 34);
            this.Lock84.TabIndex = 53;
            this.Lock84.TabStop = false;
            this.Lock84.Tag = "84";
            // 
            // aPTaxOfficeTableAdapter
            // 
            this.aPTaxOfficeTableAdapter.ClearBeforeFill = true;
            // 
            // aPGeneralSetupTableAdapter
            // 
            this.aPGeneralSetupTableAdapter.ClearBeforeFill = true;
            // 
            // TaxOffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(508, 178);
            this.ControlBox = false;
            this.Controls.Add(this.Lock84);
            this.Controls.Add(this.Lock83);
            this.Controls.Add(this.Lock82);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnundo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_SaveChanges);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TaxOffice";
            this.ShowInTaskbar = false;
            this.Text = "TaxOffice";
            this.Load += new System.EventHandler(this.TaxOffice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Lock82.ResumeLayout(false);
            this.Lock83.ResumeLayout(false);
            this.Lock84.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button btn_SaveChanges;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TaxOfficeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_TaxOfficeID;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnundo;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button Btnsaveedit;
        private System.Windows.Forms.Button btnSavenew;
        private System.Windows.Forms.GroupBox Lock82;
        private System.Windows.Forms.GroupBox Lock84;
        private System.Windows.Forms.GroupBox Lock83;
        private Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.APTaxOfficeTableAdapter aPTaxOfficeTableAdapter;
        private Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.APGeneralSetupTableAdapter aPGeneralSetupTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxOfficeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxOfficeNameDataGridViewTextBoxColumn;
    }
}