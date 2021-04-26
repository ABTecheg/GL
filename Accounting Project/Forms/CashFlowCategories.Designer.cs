namespace Accounting_GeneralLedger
{
    partial class CashFlowCategories
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
            this.btn_New = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.CashFlowCategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cashFlowCategoryCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cashFlowCategoryDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_CashFlowID = new System.Windows.Forms.TextBox();
            this.txt_CashFlowDescription = new System.Windows.Forms.TextBox();
            this.txt_CashFlowCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnundo = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.Btnsaveedit = new System.Windows.Forms.Button();
            this.btnSavenew = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_New
            // 
            this.btn_New.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btn_New.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btn_New.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_New.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btn_New.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_New.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_New.ForeColor = System.Drawing.Color.LightGray;
            this.btn_New.Location = new System.Drawing.Point(68, 246);
            this.btn_New.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(92, 46);
            this.btn_New.TabIndex = 7;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = false;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
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
            this.CashFlowCategoryID,
            this.cashFlowCategoryCodeDataGridViewTextBoxColumn,
            this.cashFlowCategoryDescriptionDataGridViewTextBoxColumn});
            this.dgv.DataMember = "ARCashFlowCategory";
            this.dgv.DataSource = this.dbAccountingProjectDSBindingSource;
            this.dgv.Location = new System.Drawing.Point(13, 13);
            this.dgv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(314, 215);
            this.dgv.TabIndex = 8;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // CashFlowCategoryID
            // 
            this.CashFlowCategoryID.DataPropertyName = "CashFlowCategoryID";
            this.CashFlowCategoryID.HeaderText = "CashFlowCategoryID";
            this.CashFlowCategoryID.MinimumWidth = 6;
            this.CashFlowCategoryID.Name = "CashFlowCategoryID";
            this.CashFlowCategoryID.ReadOnly = true;
            this.CashFlowCategoryID.Visible = false;
            this.CashFlowCategoryID.Width = 134;
            // 
            // cashFlowCategoryCodeDataGridViewTextBoxColumn
            // 
            this.cashFlowCategoryCodeDataGridViewTextBoxColumn.DataPropertyName = "CashFlowCategoryCode";
            this.cashFlowCategoryCodeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.cashFlowCategoryCodeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cashFlowCategoryCodeDataGridViewTextBoxColumn.Name = "cashFlowCategoryCodeDataGridViewTextBoxColumn";
            this.cashFlowCategoryCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.cashFlowCategoryCodeDataGridViewTextBoxColumn.Width = 70;
            // 
            // cashFlowCategoryDescriptionDataGridViewTextBoxColumn
            // 
            this.cashFlowCategoryDescriptionDataGridViewTextBoxColumn.DataPropertyName = "CashFlowCategoryDescription";
            this.cashFlowCategoryDescriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.cashFlowCategoryDescriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cashFlowCategoryDescriptionDataGridViewTextBoxColumn.Name = "cashFlowCategoryDescriptionDataGridViewTextBoxColumn";
            this.cashFlowCategoryDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.cashFlowCategoryDescriptionDataGridViewTextBoxColumn.Width = 108;
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
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(872, 30);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem1,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(75, 26);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // insertToolStripMenuItem1
            // 
            this.insertToolStripMenuItem1.Name = "insertToolStripMenuItem1";
            this.insertToolStripMenuItem1.Size = new System.Drawing.Size(136, 26);
            this.insertToolStripMenuItem1.Text = "Insert";
            this.insertToolStripMenuItem1.Click += new System.EventHandler(this.insertToolStripMenuItem1_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_CashFlowID);
            this.groupBox1.Controls.Add(this.txt_CashFlowDescription);
            this.groupBox1.Controls.Add(this.txt_CashFlowCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(346, 57);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(483, 171);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(8, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "Cash Flow ID";
            // 
            // txt_CashFlowID
            // 
            this.txt_CashFlowID.Location = new System.Drawing.Point(209, 35);
            this.txt_CashFlowID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_CashFlowID.Name = "txt_CashFlowID";
            this.txt_CashFlowID.ReadOnly = true;
            this.txt_CashFlowID.Size = new System.Drawing.Size(97, 22);
            this.txt_CashFlowID.TabIndex = 11;
            // 
            // txt_CashFlowDescription
            // 
            this.txt_CashFlowDescription.Location = new System.Drawing.Point(209, 100);
            this.txt_CashFlowDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_CashFlowDescription.MaxLength = 30;
            this.txt_CashFlowDescription.Name = "txt_CashFlowDescription";
            this.txt_CashFlowDescription.Size = new System.Drawing.Size(259, 22);
            this.txt_CashFlowDescription.TabIndex = 10;
            // 
            // txt_CashFlowCode
            // 
            this.txt_CashFlowCode.Location = new System.Drawing.Point(209, 70);
            this.txt_CashFlowCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_CashFlowCode.MaxLength = 4;
            this.txt_CashFlowCode.Name = "txt_CashFlowCode";
            this.txt_CashFlowCode.Size = new System.Drawing.Size(97, 22);
            this.txt_CashFlowCode.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(8, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "Cash Flow Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(8, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cash Flow Code";
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnedit.Enabled = false;
            this.btnedit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnedit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnedit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnedit.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnedit.ForeColor = System.Drawing.Color.LightGray;
            this.btnedit.Location = new System.Drawing.Point(209, 246);
            this.btnedit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(92, 46);
            this.btnedit.TabIndex = 54;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnexit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnexit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnexit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.ForeColor = System.Drawing.Color.LightGray;
            this.btnexit.Location = new System.Drawing.Point(633, 246);
            this.btnexit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(92, 46);
            this.btnexit.TabIndex = 56;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnundo
            // 
            this.btnundo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnundo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnundo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnundo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnundo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnundo.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnundo.ForeColor = System.Drawing.Color.LightGray;
            this.btnundo.Location = new System.Drawing.Point(492, 246);
            this.btnundo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnundo.Name = "btnundo";
            this.btnundo.Size = new System.Drawing.Size(92, 46);
            this.btnundo.TabIndex = 55;
            this.btnundo.Text = "Undo";
            this.btnundo.UseVisualStyleBackColor = false;
            this.btnundo.Click += new System.EventHandler(this.btnundo_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btndelete.Enabled = false;
            this.btndelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btndelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btndelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelete.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.Color.LightGray;
            this.btndelete.Location = new System.Drawing.Point(346, 246);
            this.btndelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(92, 46);
            this.btndelete.TabIndex = 52;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // Btnsaveedit
            // 
            this.Btnsaveedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.Btnsaveedit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.Btnsaveedit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Btnsaveedit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.Btnsaveedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnsaveedit.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnsaveedit.ForeColor = System.Drawing.Color.LightGray;
            this.Btnsaveedit.Location = new System.Drawing.Point(209, 246);
            this.Btnsaveedit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btnsaveedit.Name = "Btnsaveedit";
            this.Btnsaveedit.Size = new System.Drawing.Size(92, 46);
            this.Btnsaveedit.TabIndex = 51;
            this.Btnsaveedit.Text = "Save";
            this.Btnsaveedit.UseVisualStyleBackColor = false;
            this.Btnsaveedit.Click += new System.EventHandler(this.Btnsaveedit_Click);
            // 
            // btnSavenew
            // 
            this.btnSavenew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnSavenew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnSavenew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnSavenew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnSavenew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavenew.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavenew.ForeColor = System.Drawing.Color.LightGray;
            this.btnSavenew.Location = new System.Drawing.Point(68, 246);
            this.btnSavenew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSavenew.Name = "btnSavenew";
            this.btnSavenew.Size = new System.Drawing.Size(92, 46);
            this.btnSavenew.TabIndex = 53;
            this.btnSavenew.Text = "Save";
            this.btnSavenew.UseVisualStyleBackColor = false;
            this.btnSavenew.Click += new System.EventHandler(this.btnSavenew_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(403, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(374, 40);
            this.label4.TabIndex = 57;
            this.label4.Text = "Cash Flow Categories";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CashFlowCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(854, 313);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnundo);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.Btnsaveedit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.btnSavenew);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CashFlowCategories";
            this.Text = "CashFlowCategories";
            this.Load += new System.EventHandler(this.CashFlowCategories_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashFlowCategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cashFlowCategoryCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cashFlowCategoryDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_CashFlowID;
        private System.Windows.Forms.TextBox txt_CashFlowDescription;
        private System.Windows.Forms.TextBox txt_CashFlowCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnundo;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button Btnsaveedit;
        private System.Windows.Forms.Button btnSavenew;
        private System.Windows.Forms.Label label4;
    }
}