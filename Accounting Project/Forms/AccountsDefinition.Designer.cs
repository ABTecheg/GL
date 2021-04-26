namespace Accounting_GeneralLedger
{
    partial class AccountsDefinition
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
            this.AccountTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAccountNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.propertyCodeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.Button();
            this.Gb1 = new System.Windows.Forms.GroupBox();
            this.ChkSubLvl = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_AccountARName = new System.Windows.Forms.TextBox();
            this.txtAccountNumbers = new System.Windows.Forms.MaskedTextBox();
            this.cb_AccountTypes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_OpeningBalance = new System.Windows.Forms.TextBox();
            this.txt_AccountName = new System.Windows.Forms.TextBox();
            this.checkBox_Active = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape5 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.btnUndo = new System.Windows.Forms.Button();
            this.Lock38 = new System.Windows.Forms.GroupBox();
            this.btn_New = new System.Windows.Forms.Button();
            this.btnSavenew = new System.Windows.Forms.Button();
            this.Lock39 = new System.Windows.Forms.GroupBox();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.Btnsaveedit = new System.Windows.Forms.Button();
            this.Lock40 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.Gb1.SuspendLayout();
            this.Lock38.SuspendLayout();
            this.Lock39.SuspendLayout();
            this.Lock40.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccountTypeName,
            this.ColAccountNumber,
            this.ColAccountName,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn4,
            this.propertyCodeIDDataGridViewTextBoxColumn});
            this.dgv.DataMember = "GLAccounts";
            this.dgv.DataSource = this.dbAccountingProjectDSBindingSource;
            this.dgv.Location = new System.Drawing.Point(15, 12);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(421, 306);
            this.dgv.TabIndex = 0;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseClick);
            // 
            // AccountTypeName
            // 
            this.AccountTypeName.HeaderText = "AccountTypeName";
            this.AccountTypeName.Name = "AccountTypeName";
            this.AccountTypeName.ReadOnly = true;
            this.AccountTypeName.Visible = false;
            // 
            // ColAccountNumber
            // 
            this.ColAccountNumber.DataPropertyName = "AccountNumber";
            this.ColAccountNumber.HeaderText = "AccountNumber";
            this.ColAccountNumber.Name = "ColAccountNumber";
            this.ColAccountNumber.ReadOnly = true;
            // 
            // ColAccountName
            // 
            this.ColAccountName.DataPropertyName = "AccountName";
            this.ColAccountName.HeaderText = "AccountName";
            this.ColAccountName.Name = "ColAccountName";
            this.ColAccountName.ReadOnly = true;
            this.ColAccountName.Width = 300;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Active";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Active";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "OpeningBalance";
            this.dataGridViewTextBoxColumn4.HeaderText = "OpeningBalance";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // propertyCodeIDDataGridViewTextBoxColumn
            // 
            this.propertyCodeIDDataGridViewTextBoxColumn.DataPropertyName = "PropertyCodeID";
            this.propertyCodeIDDataGridViewTextBoxColumn.HeaderText = "PropertyCodeID";
            this.propertyCodeIDDataGridViewTextBoxColumn.Name = "propertyCodeIDDataGridViewTextBoxColumn";
            this.propertyCodeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.propertyCodeIDDataGridViewTextBoxColumn.Visible = false;
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(661, 24);
            this.menuStrip1.TabIndex = 12;
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
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.LightGray;
            this.btnExit.Location = new System.Drawing.Point(895, 272);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(92, 46);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Gb1
            // 
            this.Gb1.Controls.Add(this.ChkSubLvl);
            this.Gb1.Controls.Add(this.label6);
            this.Gb1.Controls.Add(this.txt_AccountARName);
            this.Gb1.Controls.Add(this.txtAccountNumbers);
            this.Gb1.Controls.Add(this.cb_AccountTypes);
            this.Gb1.Controls.Add(this.label5);
            this.Gb1.Controls.Add(this.txt_OpeningBalance);
            this.Gb1.Controls.Add(this.txt_AccountName);
            this.Gb1.Controls.Add(this.checkBox_Active);
            this.Gb1.Controls.Add(this.label4);
            this.Gb1.Controls.Add(this.label3);
            this.Gb1.Controls.Add(this.label2);
            this.Gb1.Controls.Add(this.label1);
            this.Gb1.Controls.Add(this.shapeContainer1);
            this.Gb1.Location = new System.Drawing.Point(474, 45);
            this.Gb1.Name = "Gb1";
            this.Gb1.Size = new System.Drawing.Size(513, 213);
            this.Gb1.TabIndex = 17;
            this.Gb1.TabStop = false;
            this.Gb1.EnabledChanged += new System.EventHandler(this.Gb1_EnabledChanged);
            // 
            // ChkSubLvl
            // 
            this.ChkSubLvl.AutoSize = true;
            this.ChkSubLvl.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkSubLvl.ForeColor = System.Drawing.Color.Silver;
            this.ChkSubLvl.Location = new System.Drawing.Point(386, 180);
            this.ChkSubLvl.Name = "ChkSubLvl";
            this.ChkSubLvl.Size = new System.Drawing.Size(87, 21);
            this.ChkSubLvl.TabIndex = 30;
            this.ChkSubLvl.Text = "Sub Level";
            this.ChkSubLvl.UseVisualStyleBackColor = true;
            this.ChkSubLvl.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(6, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "Account Arabic Name";
            // 
            // txt_AccountARName
            // 
            this.txt_AccountARName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.txt_AccountARName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_AccountARName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_AccountARName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_AccountARName.Location = new System.Drawing.Point(168, 121);
            this.txt_AccountARName.MaxLength = 50;
            this.txt_AccountARName.Name = "txt_AccountARName";
            this.txt_AccountARName.Size = new System.Drawing.Size(200, 16);
            this.txt_AccountARName.TabIndex = 3;
            this.txt_AccountARName.Enter += new System.EventHandler(this.txt_AccountARName_Enter);
            this.txt_AccountARName.Leave += new System.EventHandler(this.txt_AccountARName_Leave);
            // 
            // txtAccountNumbers
            // 
            this.txtAccountNumbers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.txtAccountNumbers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAccountNumbers.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNumbers.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtAccountNumbers.Location = new System.Drawing.Point(168, 61);
            this.txtAccountNumbers.Name = "txtAccountNumbers";
            this.txtAccountNumbers.PromptChar = '#';
            this.txtAccountNumbers.Size = new System.Drawing.Size(200, 16);
            this.txtAccountNumbers.TabIndex = 1;
            this.txtAccountNumbers.Enter += new System.EventHandler(this.txtAccountNumbers_Enter);
            // 
            // cb_AccountTypes
            // 
            this.cb_AccountTypes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.cb_AccountTypes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_AccountTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_AccountTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_AccountTypes.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_AccountTypes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.cb_AccountTypes.FormattingEnabled = true;
            this.cb_AccountTypes.Location = new System.Drawing.Point(168, 26);
            this.cb_AccountTypes.Name = "cb_AccountTypes";
            this.cb_AccountTypes.Size = new System.Drawing.Size(308, 25);
            this.cb_AccountTypes.TabIndex = 0;
            this.cb_AccountTypes.SelectedIndexChanged += new System.EventHandler(this.cb_AccountTypes_SelectedIndexChanged);
            this.cb_AccountTypes.DropDownClosed += new System.EventHandler(this.cb_AccountTypes_DropDownClosed);
            this.cb_AccountTypes.Click += new System.EventHandler(this.cb_AccountTypes_Click);
            this.cb_AccountTypes.MouseCaptureChanged += new System.EventHandler(this.cb_AccountTypes_MouseCaptureChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(6, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "Account Name";
            // 
            // txt_OpeningBalance
            // 
            this.txt_OpeningBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.txt_OpeningBalance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_OpeningBalance.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_OpeningBalance.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_OpeningBalance.Location = new System.Drawing.Point(168, 153);
            this.txt_OpeningBalance.MaxLength = 30;
            this.txt_OpeningBalance.Name = "txt_OpeningBalance";
            this.txt_OpeningBalance.Size = new System.Drawing.Size(200, 16);
            this.txt_OpeningBalance.TabIndex = 4;
            this.txt_OpeningBalance.TextChanged += new System.EventHandler(this.txt_OpeningBalance_TextChanged);
            this.txt_OpeningBalance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_OpeningBalance_KeyDown);
            this.txt_OpeningBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_OpeningBalance_KeyPress);
            // 
            // txt_AccountName
            // 
            this.txt_AccountName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.txt_AccountName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_AccountName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_AccountName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_AccountName.Location = new System.Drawing.Point(168, 91);
            this.txt_AccountName.MaxLength = 50;
            this.txt_AccountName.Name = "txt_AccountName";
            this.txt_AccountName.Size = new System.Drawing.Size(200, 16);
            this.txt_AccountName.TabIndex = 2;
            // 
            // checkBox_Active
            // 
            this.checkBox_Active.AutoSize = true;
            this.checkBox_Active.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Active.ForeColor = System.Drawing.Color.Silver;
            this.checkBox_Active.Location = new System.Drawing.Point(62, 180);
            this.checkBox_Active.Name = "checkBox_Active";
            this.checkBox_Active.Size = new System.Drawing.Size(68, 21);
            this.checkBox_Active.TabIndex = 9;
            this.checkBox_Active.Text = "Active";
            this.checkBox_Active.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(6, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Opening Balance";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(6, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(7, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Account Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "Account Type";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(3, 16);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape4,
            this.lineShape5,
            this.lineShape1,
            this.lineShape3,
            this.lineShape2});
            this.shapeContainer1.Size = new System.Drawing.Size(507, 194);
            this.shapeContainer1.TabIndex = 31;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape4
            // 
            this.lineShape4.BorderColor = System.Drawing.Color.DarkGray;
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 161;
            this.lineShape4.X2 = 469;
            this.lineShape4.Y1 = 92;
            this.lineShape4.Y2 = 92;
            // 
            // lineShape5
            // 
            this.lineShape5.BorderColor = System.Drawing.Color.DarkGray;
            this.lineShape5.Name = "lineShape5";
            this.lineShape5.X1 = 161;
            this.lineShape5.X2 = 469;
            this.lineShape5.Y1 = 122;
            this.lineShape5.Y2 = 122;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.DarkGray;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 161;
            this.lineShape1.X2 = 469;
            this.lineShape1.Y1 = 153;
            this.lineShape1.Y2 = 153;
            // 
            // lineShape3
            // 
            this.lineShape3.BorderColor = System.Drawing.Color.DarkGray;
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 161;
            this.lineShape3.X2 = 469;
            this.lineShape3.Y1 = 63;
            this.lineShape3.Y2 = 63;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.Color.DarkGray;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 161;
            this.lineShape2.X2 = 469;
            this.lineShape2.Y1 = 33;
            this.lineShape2.Y2 = 33;
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnUndo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnUndo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnUndo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.ForeColor = System.Drawing.Color.LightGray;
            this.btnUndo.Location = new System.Drawing.Point(786, 272);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(92, 46);
            this.btnUndo.TabIndex = 7;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // Lock38
            // 
            this.Lock38.Controls.Add(this.btn_New);
            this.Lock38.Controls.Add(this.btnSavenew);
            this.Lock38.Location = new System.Drawing.Point(474, 272);
            this.Lock38.Name = "Lock38";
            this.Lock38.Size = new System.Drawing.Size(92, 46);
            this.Lock38.TabIndex = 18;
            this.Lock38.TabStop = false;
            this.Lock38.Tag = "38";
            // 
            // btn_New
            // 
            this.btn_New.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btn_New.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btn_New.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_New.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btn_New.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_New.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_New.ForeColor = System.Drawing.Color.LightGray;
            this.btn_New.Location = new System.Drawing.Point(0, 0);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(92, 46);
            this.btn_New.TabIndex = 54;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = false;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btnSavenew
            // 
            this.btnSavenew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnSavenew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnSavenew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnSavenew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavenew.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavenew.ForeColor = System.Drawing.Color.LightGray;
            this.btnSavenew.Location = new System.Drawing.Point(0, 0);
            this.btnSavenew.Name = "btnSavenew";
            this.btnSavenew.Size = new System.Drawing.Size(92, 46);
            this.btnSavenew.TabIndex = 55;
            this.btnSavenew.Text = "Save";
            this.btnSavenew.Click += new System.EventHandler(this.btnSavenew_Click);
            // 
            // Lock39
            // 
            this.Lock39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.Lock39.Controls.Add(this.btn_Edit);
            this.Lock39.Controls.Add(this.Btnsaveedit);
            this.Lock39.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Lock39.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lock39.ForeColor = System.Drawing.Color.LightGray;
            this.Lock39.Location = new System.Drawing.Point(579, 272);
            this.Lock39.Name = "Lock39";
            this.Lock39.Size = new System.Drawing.Size(92, 46);
            this.Lock39.TabIndex = 19;
            this.Lock39.TabStop = false;
            this.Lock39.Tag = "39";
            // 
            // btn_Edit
            // 
            this.btn_Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btn_Edit.Enabled = false;
            this.btn_Edit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btn_Edit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_Edit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btn_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Edit.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Edit.ForeColor = System.Drawing.Color.LightGray;
            this.btn_Edit.Location = new System.Drawing.Point(0, 0);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(92, 46);
            this.btn_Edit.TabIndex = 56;
            this.btn_Edit.Text = "Edit";
            this.btn_Edit.UseVisualStyleBackColor = false;
            this.btn_Edit.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btnsaveedit
            // 
            this.Btnsaveedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.Btnsaveedit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.Btnsaveedit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Btnsaveedit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.Btnsaveedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnsaveedit.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnsaveedit.ForeColor = System.Drawing.Color.LightGray;
            this.Btnsaveedit.Location = new System.Drawing.Point(0, 0);
            this.Btnsaveedit.Name = "Btnsaveedit";
            this.Btnsaveedit.Size = new System.Drawing.Size(92, 46);
            this.Btnsaveedit.TabIndex = 55;
            this.Btnsaveedit.Text = "Save";
            this.Btnsaveedit.UseVisualStyleBackColor = false;
            this.Btnsaveedit.Click += new System.EventHandler(this.Btnsaveedit_Click);
            // 
            // Lock40
            // 
            this.Lock40.Controls.Add(this.btnDelete);
            this.Lock40.Location = new System.Drawing.Point(680, 272);
            this.Lock40.Name = "Lock40";
            this.Lock40.Size = new System.Drawing.Size(92, 46);
            this.Lock40.TabIndex = 20;
            this.Lock40.TabStop = false;
            this.Lock40.Tag = "40";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.LightGray;
            this.btnDelete.Location = new System.Drawing.Point(0, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 46);
            this.btnDelete.TabIndex = 53;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(609, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(259, 33);
            this.label7.TabIndex = 21;
            this.label7.Text = "Account Definition";
            // 
            // AccountsDefinition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1017, 343);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Lock40);
            this.Controls.Add(this.Lock39);
            this.Controls.Add(this.Lock38);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.Gb1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AccountsDefinition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountsDefinition";
            this.Load += new System.EventHandler(this.ChartOfAccounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Gb1.ResumeLayout(false);
            this.Gb1.PerformLayout();
            this.Lock38.ResumeLayout(false);
            this.Lock39.ResumeLayout(false);
            this.Lock40.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        //private System.Windows.Forms.DataGridViewTextBoxColumn accountNumberDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn accountNameDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn accountTypeNameDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewCheckBoxColumn activeDataGridViewCheckBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn openingBalanceDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private dbAccountingProjectDS dbAccountingProjectDS;
        //private System.Windows.Forms.DataGridViewTextBoxColumn ColAccountTypeID;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox Gb1;
        private System.Windows.Forms.MaskedTextBox txtAccountNumbers;
        private System.Windows.Forms.ComboBox cb_AccountTypes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_OpeningBalance;
        private System.Windows.Forms.TextBox txt_AccountName;
        private System.Windows.Forms.CheckBox checkBox_Active;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAccountNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAccountName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn propertyCodeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox Lock40;
        private System.Windows.Forms.GroupBox Lock39;
        private System.Windows.Forms.GroupBox Lock38;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_AccountARName;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Button btnSavenew;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button Btnsaveedit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox ChkSubLvl;
        private System.Windows.Forms.Label label7;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape5;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
    }
}