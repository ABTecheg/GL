namespace Accounting_GeneralLedger
{
    partial class VendorsCategories
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
            this.categoryCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.txt_CategoryCodeID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_CategoryDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_CategoryCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnundo = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.Btnsaveedit = new System.Windows.Forms.Button();
            this.btnSavenew = new System.Windows.Forms.Button();
            this.Lock91 = new System.Windows.Forms.GroupBox();
            this.Lock92 = new System.Windows.Forms.GroupBox();
            this.Lock93 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.Lock91.SuspendLayout();
            this.Lock92.SuspendLayout();
            this.Lock93.SuspendLayout();
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
            this.categoryCodeDataGridViewTextBoxColumn,
            this.categoryDescriptionDataGridViewTextBoxColumn});
            this.dgv.DataMember = "APVendorCategory";
            this.dgv.DataSource = this.dbAccountingProjectDSBindingSource;
            this.dgv.Location = new System.Drawing.Point(0, 1);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(280, 150);
            this.dgv.TabIndex = 4;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // categoryCodeDataGridViewTextBoxColumn
            // 
            this.categoryCodeDataGridViewTextBoxColumn.DataPropertyName = "CategoryCode";
            this.categoryCodeDataGridViewTextBoxColumn.HeaderText = "CategoryCode";
            this.categoryCodeDataGridViewTextBoxColumn.Name = "categoryCodeDataGridViewTextBoxColumn";
            this.categoryCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.categoryCodeDataGridViewTextBoxColumn.Width = 99;
            // 
            // categoryDescriptionDataGridViewTextBoxColumn
            // 
            this.categoryDescriptionDataGridViewTextBoxColumn.DataPropertyName = "CategoryDescription";
            this.categoryDescriptionDataGridViewTextBoxColumn.HeaderText = "CategoryDescription";
            this.categoryDescriptionDataGridViewTextBoxColumn.Name = "categoryDescriptionDataGridViewTextBoxColumn";
            this.categoryDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.categoryDescriptionDataGridViewTextBoxColumn.Width = 127;
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
            this.menuStrip1.Size = new System.Drawing.Size(398, 24);
            this.menuStrip1.TabIndex = 6;
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
            this.btn_New.Location = new System.Drawing.Point(0, 6);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(64, 28);
            this.btn_New.TabIndex = 9;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_CategoryCodeID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_CategoryDescription);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_CategoryCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(286, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 139);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.EnabledChanged += new System.EventHandler(this.groupBox1_EnabledChanged);
            // 
            // txt_CategoryCodeID
            // 
            this.txt_CategoryCodeID.Location = new System.Drawing.Point(117, 19);
            this.txt_CategoryCodeID.Name = "txt_CategoryCodeID";
            this.txt_CategoryCodeID.ReadOnly = true;
            this.txt_CategoryCodeID.Size = new System.Drawing.Size(100, 20);
            this.txt_CategoryCodeID.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Category Code ID";
            // 
            // txt_CategoryDescription
            // 
            this.txt_CategoryDescription.Location = new System.Drawing.Point(117, 71);
            this.txt_CategoryDescription.Name = "txt_CategoryDescription";
            this.txt_CategoryDescription.Size = new System.Drawing.Size(160, 20);
            this.txt_CategoryDescription.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Category Description";
            // 
            // txt_CategoryCode
            // 
            this.txt_CategoryCode.Location = new System.Drawing.Point(117, 45);
            this.txt_CategoryCode.Name = "txt_CategoryCode";
            this.txt_CategoryCode.Size = new System.Drawing.Size(100, 20);
            this.txt_CategoryCode.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Category Code";
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
            this.btnexit.Location = new System.Drawing.Point(460, 159);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(64, 28);
            this.btnexit.TabIndex = 50;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnundo
            // 
            this.btnundo.Location = new System.Drawing.Point(358, 159);
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
            // Lock91
            // 
            this.Lock91.Controls.Add(this.btn_New);
            this.Lock91.Controls.Add(this.btnSavenew);
            this.Lock91.Location = new System.Drawing.Point(52, 153);
            this.Lock91.Name = "Lock91";
            this.Lock91.Size = new System.Drawing.Size(64, 34);
            this.Lock91.TabIndex = 51;
            this.Lock91.TabStop = false;
            this.Lock91.Tag = "91";
            // 
            // Lock92
            // 
            this.Lock92.Controls.Add(this.btnedit);
            this.Lock92.Controls.Add(this.Btnsaveedit);
            this.Lock92.Location = new System.Drawing.Point(154, 153);
            this.Lock92.Name = "Lock92";
            this.Lock92.Size = new System.Drawing.Size(64, 34);
            this.Lock92.TabIndex = 52;
            this.Lock92.TabStop = false;
            this.Lock92.Tag = "92";
            // 
            // Lock93
            // 
            this.Lock93.Controls.Add(this.btndelete);
            this.Lock93.Location = new System.Drawing.Point(256, 153);
            this.Lock93.Name = "Lock93";
            this.Lock93.Size = new System.Drawing.Size(64, 34);
            this.Lock93.TabIndex = 53;
            this.Lock93.TabStop = false;
            this.Lock93.Tag = "93";
            // 
            // VendorsCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(581, 193);
            this.ControlBox = false;
            this.Controls.Add(this.Lock93);
            this.Controls.Add(this.Lock92);
            this.Controls.Add(this.Lock91);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnundo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VendorsCategories";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VendorsCategories";
            this.Load += new System.EventHandler(this.VendorsCategories_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Lock91.ResumeLayout(false);
            this.Lock92.ResumeLayout(false);
            this.Lock93.ResumeLayout(false);
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
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_CategoryCodeID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_CategoryDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_CategoryCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnundo;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button Btnsaveedit;
        private System.Windows.Forms.Button btnSavenew;
        private System.Windows.Forms.GroupBox Lock93;
        private System.Windows.Forms.GroupBox Lock92;
        private System.Windows.Forms.GroupBox Lock91;
    }
}