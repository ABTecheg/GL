namespace Accounting_GeneralLedger
{
    partial class PaymentTerms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentTerms));
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.btn_SaveChanges = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_New = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_PaymentCodeID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_DueDays = new System.Windows.Forms.TextBox();
            this.txt_TermDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_TermCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnundo = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.Btnsaveedit = new System.Windows.Forms.Button();
            this.btnSavenew = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.paymentTermCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentTermDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentDueDaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lock96 = new System.Windows.Forms.GroupBox();
            this.Lock95 = new System.Windows.Forms.GroupBox();
            this.Lock94 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.Lock96.SuspendLayout();
            this.Lock95.SuspendLayout();
            this.Lock94.SuspendLayout();
            this.SuspendLayout();
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
            // btn_SaveChanges
            // 
            this.btn_SaveChanges.Location = new System.Drawing.Point(511, 132);
            this.btn_SaveChanges.Name = "btn_SaveChanges";
            this.btn_SaveChanges.Size = new System.Drawing.Size(96, 26);
            this.btn_SaveChanges.TabIndex = 7;
            this.btn_SaveChanges.Text = "Save Changes";
            this.btn_SaveChanges.UseVisualStyleBackColor = true;
            this.btn_SaveChanges.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(529, 24);
            this.menuStrip1.TabIndex = 8;
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
            this.btn_New.TabIndex = 10;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_PaymentCodeID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_DueDays);
            this.groupBox1.Controls.Add(this.txt_TermDescription);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_TermCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(0, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 152);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.EnabledChanged += new System.EventHandler(this.groupBox1_EnabledChanged);
            // 
            // txt_PaymentCodeID
            // 
            this.txt_PaymentCodeID.Location = new System.Drawing.Point(151, 9);
            this.txt_PaymentCodeID.Name = "txt_PaymentCodeID";
            this.txt_PaymentCodeID.ReadOnly = true;
            this.txt_PaymentCodeID.Size = new System.Drawing.Size(120, 20);
            this.txt_PaymentCodeID.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Payment Term Code ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Due Days";
            // 
            // txt_DueDays
            // 
            this.txt_DueDays.Location = new System.Drawing.Point(151, 123);
            this.txt_DueDays.MaxLength = 30;
            this.txt_DueDays.Name = "txt_DueDays";
            this.txt_DueDays.Size = new System.Drawing.Size(59, 20);
            this.txt_DueDays.TabIndex = 16;
            this.txt_DueDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DueDays_KeyPress);
            // 
            // txt_TermDescription
            // 
            this.txt_TermDescription.Location = new System.Drawing.Point(151, 84);
            this.txt_TermDescription.MaxLength = 50;
            this.txt_TermDescription.Name = "txt_TermDescription";
            this.txt_TermDescription.Size = new System.Drawing.Size(179, 20);
            this.txt_TermDescription.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Payment Term Description";
            // 
            // txt_TermCode
            // 
            this.txt_TermCode.Location = new System.Drawing.Point(151, 48);
            this.txt_TermCode.MaxLength = 10;
            this.txt_TermCode.Name = "txt_TermCode";
            this.txt_TermCode.Size = new System.Drawing.Size(120, 20);
            this.txt_TermCode.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Payment Term Code";
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(431, 323);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(64, 28);
            this.btnexit.TabIndex = 44;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnundo
            // 
            this.btnundo.Location = new System.Drawing.Point(329, 323);
            this.btnundo.Name = "btnundo";
            this.btnundo.Size = new System.Drawing.Size(64, 28);
            this.btnundo.TabIndex = 43;
            this.btnundo.Text = "Undo";
            this.btnundo.UseVisualStyleBackColor = true;
            this.btnundo.Click += new System.EventHandler(this.btnundo_Click);
            // 
            // btnedit
            // 
            this.btnedit.Enabled = false;
            this.btnedit.Location = new System.Drawing.Point(0, 6);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(64, 28);
            this.btnedit.TabIndex = 42;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btndelete
            // 
            this.btndelete.Enabled = false;
            this.btndelete.Location = new System.Drawing.Point(0, 6);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(64, 28);
            this.btndelete.TabIndex = 40;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // Btnsaveedit
            // 
            this.Btnsaveedit.Location = new System.Drawing.Point(0, 6);
            this.Btnsaveedit.Name = "Btnsaveedit";
            this.Btnsaveedit.Size = new System.Drawing.Size(64, 28);
            this.Btnsaveedit.TabIndex = 38;
            this.Btnsaveedit.Text = "Save";
            this.Btnsaveedit.UseVisualStyleBackColor = true;
            this.Btnsaveedit.Click += new System.EventHandler(this.Btnsaveedit_Click);
            // 
            // btnSavenew
            // 
            this.btnSavenew.Location = new System.Drawing.Point(0, 6);
            this.btnSavenew.Name = "btnSavenew";
            this.btnSavenew.Size = new System.Drawing.Size(64, 28);
            this.btnSavenew.TabIndex = 41;
            this.btnSavenew.Text = "Save";
            this.btnSavenew.UseVisualStyleBackColor = true;
            this.btnSavenew.Click += new System.EventHandler(this.btnSavenew_Click);
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
            this.paymentTermCodeDataGridViewTextBoxColumn,
            this.paymentTermDescriptionDataGridViewTextBoxColumn,
            this.paymentDueDaysDataGridViewTextBoxColumn});
            this.dgv.DataMember = "APPaymentTerms";
            this.dgv.DataSource = this.dbAccountingProjectDSBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(529, 161);
            this.dgv.TabIndex = 45;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // paymentTermCodeDataGridViewTextBoxColumn
            // 
            this.paymentTermCodeDataGridViewTextBoxColumn.DataPropertyName = "PaymentTermCode";
            this.paymentTermCodeDataGridViewTextBoxColumn.HeaderText = "PaymentTermCode";
            this.paymentTermCodeDataGridViewTextBoxColumn.Name = "paymentTermCodeDataGridViewTextBoxColumn";
            this.paymentTermCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.paymentTermCodeDataGridViewTextBoxColumn.Width = 122;
            // 
            // paymentTermDescriptionDataGridViewTextBoxColumn
            // 
            this.paymentTermDescriptionDataGridViewTextBoxColumn.DataPropertyName = "PaymentTermDescription";
            this.paymentTermDescriptionDataGridViewTextBoxColumn.HeaderText = "PaymentTermDescription";
            this.paymentTermDescriptionDataGridViewTextBoxColumn.Name = "paymentTermDescriptionDataGridViewTextBoxColumn";
            this.paymentTermDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.paymentTermDescriptionDataGridViewTextBoxColumn.Width = 150;
            // 
            // paymentDueDaysDataGridViewTextBoxColumn
            // 
            this.paymentDueDaysDataGridViewTextBoxColumn.DataPropertyName = "PaymentDueDays";
            this.paymentDueDaysDataGridViewTextBoxColumn.HeaderText = "PaymentDueDays";
            this.paymentDueDaysDataGridViewTextBoxColumn.Name = "paymentDueDaysDataGridViewTextBoxColumn";
            this.paymentDueDaysDataGridViewTextBoxColumn.ReadOnly = true;
            this.paymentDueDaysDataGridViewTextBoxColumn.Width = 117;
            // 
            // Lock96
            // 
            this.Lock96.Controls.Add(this.btndelete);
            this.Lock96.Location = new System.Drawing.Point(227, 317);
            this.Lock96.Name = "Lock96";
            this.Lock96.Size = new System.Drawing.Size(64, 34);
            this.Lock96.TabIndex = 46;
            this.Lock96.TabStop = false;
            this.Lock96.Tag = "96";
            // 
            // Lock95
            // 
            this.Lock95.Controls.Add(this.btnedit);
            this.Lock95.Controls.Add(this.Btnsaveedit);
            this.Lock95.Location = new System.Drawing.Point(125, 317);
            this.Lock95.Name = "Lock95";
            this.Lock95.Size = new System.Drawing.Size(64, 34);
            this.Lock95.TabIndex = 47;
            this.Lock95.TabStop = false;
            this.Lock95.Tag = "95";
            // 
            // Lock94
            // 
            this.Lock94.Controls.Add(this.btn_New);
            this.Lock94.Controls.Add(this.btnSavenew);
            this.Lock94.Location = new System.Drawing.Point(23, 317);
            this.Lock94.Name = "Lock94";
            this.Lock94.Size = new System.Drawing.Size(64, 34);
            this.Lock94.TabIndex = 48;
            this.Lock94.TabStop = false;
            this.Lock94.Tag = "94";
            // 
            // PaymentTerms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(529, 359);
            this.ControlBox = false;
            this.Controls.Add(this.Lock94);
            this.Controls.Add(this.Lock95);
            this.Controls.Add(this.Lock96);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnundo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_SaveChanges);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PaymentTerms";
            this.Text = "PaymentTerms";
            this.Load += new System.EventHandler(this.PaymentTerms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.Lock96.ResumeLayout(false);
            this.Lock95.ResumeLayout(false);
            this.Lock94.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_SaveChanges;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_PaymentCodeID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_DueDays;
        private System.Windows.Forms.TextBox txt_TermDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TermCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnundo;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button Btnsaveedit;
        private System.Windows.Forms.Button btnSavenew;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentTermCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentTermDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentDueDaysDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox Lock94;
        private System.Windows.Forms.GroupBox Lock95;
        private System.Windows.Forms.GroupBox Lock96;
    }
}