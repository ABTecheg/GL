namespace Accounting_GeneralLedger
{
    partial class AccountTypes
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
            this.btn_SaveChanges = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_AccountTypeName = new System.Windows.Forms.TextBox();
            this.checkBox_credit = new System.Windows.Forms.CheckBox();
            this.checkBox_Debit = new System.Windows.Forms.CheckBox();
            this.checkBox_other = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dvg = new System.Windows.Forms.DataGridView();
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_AccountTypeID = new System.Windows.Forms.TextBox();
            this.btn_New = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_SaveChanges
            // 
            this.btn_SaveChanges.Location = new System.Drawing.Point(171, 97);
            this.btn_SaveChanges.Name = "btn_SaveChanges";
            this.btn_SaveChanges.Size = new System.Drawing.Size(107, 25);
            this.btn_SaveChanges.TabIndex = 1;
            this.btn_SaveChanges.Text = "Save Changes";
            this.btn_SaveChanges.UseVisualStyleBackColor = true;
            this.btn_SaveChanges.Visible = false;
            this.btn_SaveChanges.Click += new System.EventHandler(this.btn_SaveChanges_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Account Type Name";
            // 
            // txt_AccountTypeName
            // 
            this.txt_AccountTypeName.Location = new System.Drawing.Point(334, 78);
            this.txt_AccountTypeName.MaxLength = 30;
            this.txt_AccountTypeName.Name = "txt_AccountTypeName";
            this.txt_AccountTypeName.Size = new System.Drawing.Size(175, 20);
            this.txt_AccountTypeName.TabIndex = 3;
            // 
            // checkBox_credit
            // 
            this.checkBox_credit.AutoSize = true;
            this.checkBox_credit.Location = new System.Drawing.Point(23, 24);
            this.checkBox_credit.Name = "checkBox_credit";
            this.checkBox_credit.Size = new System.Drawing.Size(53, 17);
            this.checkBox_credit.TabIndex = 4;
            this.checkBox_credit.Text = "Credit";
            this.checkBox_credit.UseVisualStyleBackColor = true;
            this.checkBox_credit.CheckedChanged += new System.EventHandler(this.checkBox_credit_CheckedChanged);
            // 
            // checkBox_Debit
            // 
            this.checkBox_Debit.AutoSize = true;
            this.checkBox_Debit.Location = new System.Drawing.Point(23, 47);
            this.checkBox_Debit.Name = "checkBox_Debit";
            this.checkBox_Debit.Size = new System.Drawing.Size(51, 17);
            this.checkBox_Debit.TabIndex = 5;
            this.checkBox_Debit.Text = "Debit";
            this.checkBox_Debit.UseVisualStyleBackColor = true;
            this.checkBox_Debit.CheckedChanged += new System.EventHandler(this.checkBox_Debit_CheckedChanged);
            // 
            // checkBox_other
            // 
            this.checkBox_other.AutoSize = true;
            this.checkBox_other.Location = new System.Drawing.Point(23, 70);
            this.checkBox_other.Name = "checkBox_other";
            this.checkBox_other.Size = new System.Drawing.Size(52, 17);
            this.checkBox_other.TabIndex = 6;
            this.checkBox_other.Text = "Other";
            this.checkBox_other.UseVisualStyleBackColor = true;
            this.checkBox_other.CheckedChanged += new System.EventHandler(this.checkBox_other_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_other);
            this.groupBox1.Controls.Add(this.checkBox_Debit);
            this.groupBox1.Controls.Add(this.checkBox_credit);
            this.groupBox1.Controls.Add(this.btn_SaveChanges);
            this.groupBox1.Location = new System.Drawing.Point(225, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 128);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Types Classifications";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(606, 24);
            this.menuStrip1.TabIndex = 9;
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
            // dvg
            // 
            this.dvg.AllowUserToAddRows = false;
            this.dvg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dvg.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvg.Location = new System.Drawing.Point(12, 51);
            this.dvg.MultiSelect = false;
            this.dvg.Name = "dvg";
            this.dvg.ReadOnly = true;
            this.dvg.RowHeadersWidth = 30;
            this.dvg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvg.Size = new System.Drawing.Size(207, 204);
            this.dvg.TabIndex = 10;
            this.dvg.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvg_CellContentClick);
            this.dvg.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dvg_CellMouseClick);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Account Type ID";
            // 
            // txt_AccountTypeID
            // 
            this.txt_AccountTypeID.Location = new System.Drawing.Point(334, 48);
            this.txt_AccountTypeID.Name = "txt_AccountTypeID";
            this.txt_AccountTypeID.ReadOnly = true;
            this.txt_AccountTypeID.Size = new System.Drawing.Size(116, 20);
            this.txt_AccountTypeID.TabIndex = 12;
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(456, 46);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(53, 23);
            this.btn_New.TabIndex = 13;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Visible = false;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(389, 268);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(53, 24);
            this.btnUndo.TabIndex = 23;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(455, 268);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(53, 24);
            this.btnExit.TabIndex = 22;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(323, 268);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(53, 24);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(258, 268);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(52, 24);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(192, 268);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(53, 24);
            this.btnNew.TabIndex = 19;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // AccountTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(533, 304);
            this.ControlBox = false;
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.txt_AccountTypeID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dvg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_AccountTypeName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AccountTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountTypes";
            this.Load += new System.EventHandler(this.AccountTypes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_SaveChanges;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_AccountTypeName;
        private System.Windows.Forms.CheckBox checkBox_credit;
        private System.Windows.Forms.CheckBox checkBox_Debit;
        private System.Windows.Forms.CheckBox checkBox_other;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView dvg;
        //private System.Windows.Forms.DataGridViewTextBoxColumn accountTypeNameDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn accountTypeClassificationDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.TextBox txt_AccountTypeID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
    }
}