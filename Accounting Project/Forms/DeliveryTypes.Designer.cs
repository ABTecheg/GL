namespace Accounting_GeneralLedger
{
    partial class DeliveryTypes
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
            this.deliveryTypeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.txt_AccountNumber = new System.Windows.Forms.MaskedTextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Percentage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_DeliveryTypeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_DeliveryTypeID = new System.Windows.Forms.TextBox();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnundo = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.Btnsaveedit = new System.Windows.Forms.Button();
            this.btnSavenew = new System.Windows.Forms.Button();
            this.Lock88 = new System.Windows.Forms.GroupBox();
            this.Lock90 = new System.Windows.Forms.GroupBox();
            this.Lock89 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.Lock88.SuspendLayout();
            this.Lock90.SuspendLayout();
            this.Lock89.SuspendLayout();
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
            this.deliveryTypeIDDataGridViewTextBoxColumn,
            this.deliveryTypeNameDataGridViewTextBoxColumn});
            this.dgv.DataMember = "APDeliveryType";
            this.dgv.DataSource = this.dbAccountingProjectDSBindingSource;
            this.dgv.Location = new System.Drawing.Point(2, 3);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(246, 128);
            this.dgv.TabIndex = 7;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseClick);
            // 
            // deliveryTypeIDDataGridViewTextBoxColumn
            // 
            this.deliveryTypeIDDataGridViewTextBoxColumn.DataPropertyName = "DeliveryTypeID";
            this.deliveryTypeIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.deliveryTypeIDDataGridViewTextBoxColumn.Name = "deliveryTypeIDDataGridViewTextBoxColumn";
            this.deliveryTypeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryTypeIDDataGridViewTextBoxColumn.Width = 43;
            // 
            // deliveryTypeNameDataGridViewTextBoxColumn
            // 
            this.deliveryTypeNameDataGridViewTextBoxColumn.DataPropertyName = "DeliveryTypeName";
            this.deliveryTypeNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.deliveryTypeNameDataGridViewTextBoxColumn.Name = "deliveryTypeNameDataGridViewTextBoxColumn";
            this.deliveryTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryTypeNameDataGridViewTextBoxColumn.Width = 60;
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
            this.menuStrip1.Size = new System.Drawing.Size(639, 24);
            this.menuStrip1.TabIndex = 13;
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
            this.btn_New.Size = new System.Drawing.Size(69, 31);
            this.btn_New.TabIndex = 16;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_AccountNumber);
            this.groupBox1.Controls.Add(this.btn_Search);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_Percentage);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_DeliveryTypeName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_DeliveryTypeID);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(254, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 128);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.EnabledChanged += new System.EventHandler(this.groupBox1_EnabledChanged);
            // 
            // txt_AccountNumber
            // 
            this.txt_AccountNumber.Location = new System.Drawing.Point(149, 103);
            this.txt_AccountNumber.Name = "txt_AccountNumber";
            this.txt_AccountNumber.PromptChar = '#';
            this.txt_AccountNumber.Size = new System.Drawing.Size(145, 20);
            this.txt_AccountNumber.TabIndex = 27;
            this.txt_AccountNumber.DoubleClick += new System.EventHandler(this.txt_AccountNumber_DoubleClick);
            this.txt_AccountNumber.Leave += new System.EventHandler(this.txt_AccountNumber_Leave);
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(300, 102);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(53, 23);
            this.btn_Search.TabIndex = 18;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "GL Account Number";
            // 
            // txt_Percentage
            // 
            this.txt_Percentage.Location = new System.Drawing.Point(148, 76);
            this.txt_Percentage.MaxLength = 30;
            this.txt_Percentage.Name = "txt_Percentage";
            this.txt_Percentage.Size = new System.Drawing.Size(146, 20);
            this.txt_Percentage.TabIndex = 25;
            this.txt_Percentage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Percentage_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Percentage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Delivery Type Name";
            // 
            // txt_DeliveryTypeName
            // 
            this.txt_DeliveryTypeName.Location = new System.Drawing.Point(149, 45);
            this.txt_DeliveryTypeName.MaxLength = 30;
            this.txt_DeliveryTypeName.Name = "txt_DeliveryTypeName";
            this.txt_DeliveryTypeName.Size = new System.Drawing.Size(204, 20);
            this.txt_DeliveryTypeName.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Delivery Type ID";
            // 
            // txt_DeliveryTypeID
            // 
            this.txt_DeliveryTypeID.Location = new System.Drawing.Point(148, 19);
            this.txt_DeliveryTypeID.Name = "txt_DeliveryTypeID";
            this.txt_DeliveryTypeID.ReadOnly = true;
            this.txt_DeliveryTypeID.Size = new System.Drawing.Size(146, 20);
            this.txt_DeliveryTypeID.TabIndex = 20;
            // 
            // btnedit
            // 
            this.btnedit.Enabled = false;
            this.btnedit.Location = new System.Drawing.Point(0, 6);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(69, 31);
            this.btnedit.TabIndex = 54;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(485, 141);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(69, 31);
            this.btnexit.TabIndex = 56;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnundo
            // 
            this.btnundo.Location = new System.Drawing.Point(377, 141);
            this.btnundo.Name = "btnundo";
            this.btnundo.Size = new System.Drawing.Size(69, 31);
            this.btnundo.TabIndex = 55;
            this.btnundo.Text = "Undo";
            this.btnundo.UseVisualStyleBackColor = true;
            this.btnundo.Click += new System.EventHandler(this.btnundo_Click);
            // 
            // btndelete
            // 
            this.btndelete.Enabled = false;
            this.btndelete.Location = new System.Drawing.Point(0, 6);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(69, 31);
            this.btndelete.TabIndex = 52;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // Btnsaveedit
            // 
            this.Btnsaveedit.Location = new System.Drawing.Point(0, 6);
            this.Btnsaveedit.Name = "Btnsaveedit";
            this.Btnsaveedit.Size = new System.Drawing.Size(69, 31);
            this.Btnsaveedit.TabIndex = 51;
            this.Btnsaveedit.Text = "Save";
            this.Btnsaveedit.UseVisualStyleBackColor = true;
            this.Btnsaveedit.Click += new System.EventHandler(this.Btnsaveedit_Click);
            // 
            // btnSavenew
            // 
            this.btnSavenew.Location = new System.Drawing.Point(0, 6);
            this.btnSavenew.Name = "btnSavenew";
            this.btnSavenew.Size = new System.Drawing.Size(69, 31);
            this.btnSavenew.TabIndex = 53;
            this.btnSavenew.Text = "Save";
            this.btnSavenew.UseVisualStyleBackColor = true;
            this.btnSavenew.Click += new System.EventHandler(this.btnSavenew_Click);
            // 
            // Lock88
            // 
            this.Lock88.Controls.Add(this.btn_New);
            this.Lock88.Controls.Add(this.btnSavenew);
            this.Lock88.Location = new System.Drawing.Point(53, 134);
            this.Lock88.Name = "Lock88";
            this.Lock88.Size = new System.Drawing.Size(69, 37);
            this.Lock88.TabIndex = 28;
            this.Lock88.TabStop = false;
            this.Lock88.Tag = "88";
            this.Lock88.Enter += new System.EventHandler(this.Lock88_Enter);
            // 
            // Lock90
            // 
            this.Lock90.Controls.Add(this.btndelete);
            this.Lock90.Location = new System.Drawing.Point(269, 134);
            this.Lock90.Name = "Lock90";
            this.Lock90.Size = new System.Drawing.Size(69, 37);
            this.Lock90.TabIndex = 57;
            this.Lock90.TabStop = false;
            this.Lock90.Tag = "90";
            this.Lock90.Enter += new System.EventHandler(this.Lock90_Enter);
            // 
            // Lock89
            // 
            this.Lock89.Controls.Add(this.btnedit);
            this.Lock89.Controls.Add(this.Btnsaveedit);
            this.Lock89.Location = new System.Drawing.Point(161, 134);
            this.Lock89.Name = "Lock89";
            this.Lock89.Size = new System.Drawing.Size(69, 37);
            this.Lock89.TabIndex = 58;
            this.Lock89.TabStop = false;
            this.Lock89.Tag = "89";
            this.Lock89.Enter += new System.EventHandler(this.Lock89_Enter);
            // 
            // DeliveryTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(620, 180);
            this.ControlBox = false;
            this.Controls.Add(this.Lock89);
            this.Controls.Add(this.Lock90);
            this.Controls.Add(this.Lock88);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnundo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DeliveryTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeliveryTypes";
            this.Load += new System.EventHandler(this.DeliveryTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Lock88.ResumeLayout(false);
            this.Lock90.ResumeLayout(false);
            this.Lock89.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
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
        private System.Windows.Forms.MaskedTextBox txt_AccountNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Percentage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_DeliveryTypeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_DeliveryTypeID;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnundo;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button Btnsaveedit;
        private System.Windows.Forms.Button btnSavenew;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryTypeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox Lock89;
        private System.Windows.Forms.GroupBox Lock90;
        private System.Windows.Forms.GroupBox Lock88;
    }
}