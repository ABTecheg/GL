namespace Accounting_GeneralLedger
{
    partial class ProjectCodes
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
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.Button();
            this.GB1 = new System.Windows.Forms.GroupBox();
            this.txt_ProjectCodeID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Currency = new System.Windows.Forms.ComboBox();
            this.checkBox_Active = new System.Windows.Forms.CheckBox();
            this.DTP_EndDate = new System.Windows.Forms.DateTimePicker();
            this.DTP_StartDate = new System.Windows.Forms.DateTimePicker();
            this.txt_Budget = new System.Windows.Forms.TextBox();
            this.txt_ProjectDescription = new System.Windows.Forms.TextBox();
            this.txt_ProjectCode = new System.Windows.Forms.TextBox();
            this.btnUndo = new System.Windows.Forms.Button();
            this.Lock50 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.Lock48 = new System.Windows.Forms.GroupBox();
            this.btn_New = new System.Windows.Forms.Button();
            this.btnSavenew = new System.Windows.Forms.Button();
            this.Lock49 = new System.Windows.Forms.GroupBox();
            this.btnedit = new System.Windows.Forms.Button();
            this.Btnsaveedit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.GB1.SuspendLayout();
            this.Lock50.SuspendLayout();
            this.Lock48.SuspendLayout();
            this.Lock49.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewCheckBoxColumn1});
            this.dgv.DataMember = "GLProjectCodes";
            this.dgv.DataSource = this.dbAccountingProjectDSBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(727, 186);
            this.dgv.TabIndex = 0;
            this.dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ProjectCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "ProjectCode";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ProjectDescription";
            this.dataGridViewTextBoxColumn2.HeaderText = "ProjectDescription";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Budget";
            this.dataGridViewTextBoxColumn3.HeaderText = "Budget";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "BudgetCurrencyCode";
            this.dataGridViewTextBoxColumn4.HeaderText = "BudgetCurrencyCode";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "StartDate";
            this.dataGridViewTextBoxColumn5.HeaderText = "StartDate";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "EndDate";
            this.dataGridViewTextBoxColumn6.HeaderText = "EndDate";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Active";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Active";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
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
            this.menuStrip1.Size = new System.Drawing.Size(727, 24);
            this.menuStrip1.TabIndex = 15;
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
            this.btnExit.Location = new System.Drawing.Point(544, 413);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(92, 46);
            this.btnExit.TabIndex = 31;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // GB1
            // 
            this.GB1.Controls.Add(this.txt_ProjectCodeID);
            this.GB1.Controls.Add(this.label7);
            this.GB1.Controls.Add(this.label6);
            this.GB1.Controls.Add(this.label5);
            this.GB1.Controls.Add(this.label4);
            this.GB1.Controls.Add(this.label3);
            this.GB1.Controls.Add(this.label2);
            this.GB1.Controls.Add(this.label1);
            this.GB1.Controls.Add(this.cb_Currency);
            this.GB1.Controls.Add(this.checkBox_Active);
            this.GB1.Controls.Add(this.DTP_EndDate);
            this.GB1.Controls.Add(this.DTP_StartDate);
            this.GB1.Controls.Add(this.txt_Budget);
            this.GB1.Controls.Add(this.txt_ProjectDescription);
            this.GB1.Controls.Add(this.txt_ProjectCode);
            this.GB1.Enabled = false;
            this.GB1.Location = new System.Drawing.Point(159, 208);
            this.GB1.Name = "GB1";
            this.GB1.Size = new System.Drawing.Size(400, 189);
            this.GB1.TabIndex = 32;
            this.GB1.TabStop = false;
            this.GB1.EnabledChanged += new System.EventHandler(this.GB1_EnabledChanged);
            // 
            // txt_ProjectCodeID
            // 
            this.txt_ProjectCodeID.Location = new System.Drawing.Point(166, 10);
            this.txt_ProjectCodeID.Name = "txt_ProjectCodeID";
            this.txt_ProjectCodeID.ReadOnly = true;
            this.txt_ProjectCodeID.Size = new System.Drawing.Size(142, 20);
            this.txt_ProjectCodeID.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Project Code Id";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "End Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Budget";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Project Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Project Code";
            // 
            // cb_Currency
            // 
            this.cb_Currency.FormattingEnabled = true;
            this.cb_Currency.Location = new System.Drawing.Point(274, 90);
            this.cb_Currency.Name = "cb_Currency";
            this.cb_Currency.Size = new System.Drawing.Size(99, 21);
            this.cb_Currency.TabIndex = 25;
            this.cb_Currency.Visible = false;
            this.cb_Currency.SelectedIndexChanged += new System.EventHandler(this.cb_Currency_SelectedIndexChanged);
            // 
            // checkBox_Active
            // 
            this.checkBox_Active.AutoSize = true;
            this.checkBox_Active.Location = new System.Drawing.Point(166, 169);
            this.checkBox_Active.Name = "checkBox_Active";
            this.checkBox_Active.Size = new System.Drawing.Size(56, 17);
            this.checkBox_Active.TabIndex = 24;
            this.checkBox_Active.Text = "Active";
            this.checkBox_Active.UseVisualStyleBackColor = true;
            // 
            // DTP_EndDate
            // 
            this.DTP_EndDate.Location = new System.Drawing.Point(166, 142);
            this.DTP_EndDate.Name = "DTP_EndDate";
            this.DTP_EndDate.Size = new System.Drawing.Size(207, 20);
            this.DTP_EndDate.TabIndex = 23;
            // 
            // DTP_StartDate
            // 
            this.DTP_StartDate.Location = new System.Drawing.Point(166, 116);
            this.DTP_StartDate.Name = "DTP_StartDate";
            this.DTP_StartDate.Size = new System.Drawing.Size(207, 20);
            this.DTP_StartDate.TabIndex = 22;
            // 
            // txt_Budget
            // 
            this.txt_Budget.Location = new System.Drawing.Point(166, 90);
            this.txt_Budget.MaxLength = 30;
            this.txt_Budget.Name = "txt_Budget";
            this.txt_Budget.Size = new System.Drawing.Size(207, 20);
            this.txt_Budget.TabIndex = 21;
            this.txt_Budget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            // 
            // txt_ProjectDescription
            // 
            this.txt_ProjectDescription.Location = new System.Drawing.Point(166, 64);
            this.txt_ProjectDescription.MaxLength = 30;
            this.txt_ProjectDescription.Name = "txt_ProjectDescription";
            this.txt_ProjectDescription.Size = new System.Drawing.Size(207, 20);
            this.txt_ProjectDescription.TabIndex = 20;
            // 
            // txt_ProjectCode
            // 
            this.txt_ProjectCode.Location = new System.Drawing.Point(166, 38);
            this.txt_ProjectCode.MaxLength = 10;
            this.txt_ProjectCode.Name = "txt_ProjectCode";
            this.txt_ProjectCode.Size = new System.Drawing.Size(102, 20);
            this.txt_ProjectCode.TabIndex = 19;
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
            this.btnUndo.Location = new System.Drawing.Point(434, 413);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(92, 46);
            this.btnUndo.TabIndex = 33;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // Lock50
            // 
            this.Lock50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.Lock50.Controls.Add(this.btnDelete);
            this.Lock50.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Lock50.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lock50.ForeColor = System.Drawing.Color.LightGray;
            this.Lock50.Location = new System.Drawing.Point(325, 413);
            this.Lock50.Name = "Lock50";
            this.Lock50.Size = new System.Drawing.Size(92, 46);
            this.Lock50.TabIndex = 34;
            this.Lock50.TabStop = false;
            this.Lock50.Tag = "50";
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
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Lock48
            // 
            this.Lock48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.Lock48.Controls.Add(this.btn_New);
            this.Lock48.Controls.Add(this.btnSavenew);
            this.Lock48.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Lock48.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lock48.ForeColor = System.Drawing.Color.LightGray;
            this.Lock48.Location = new System.Drawing.Point(90, 414);
            this.Lock48.Name = "Lock48";
            this.Lock48.Size = new System.Drawing.Size(92, 46);
            this.Lock48.TabIndex = 35;
            this.Lock48.TabStop = false;
            this.Lock48.Tag = "48";
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
            this.btn_New.TabIndex = 56;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = false;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btnSavenew
            // 
            this.btnSavenew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
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
            this.btnSavenew.UseVisualStyleBackColor = false;
            this.btnSavenew.Click += new System.EventHandler(this.btnSavenew_Click);
            // 
            // Lock49
            // 
            this.Lock49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.Lock49.Controls.Add(this.Btnsaveedit);
            this.Lock49.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Lock49.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lock49.ForeColor = System.Drawing.Color.LightGray;
            this.Lock49.Location = new System.Drawing.Point(214, 407);
            this.Lock49.Name = "Lock49";
            this.Lock49.Size = new System.Drawing.Size(92, 46);
            this.Lock49.TabIndex = 36;
            this.Lock49.TabStop = false;
            this.Lock49.Tag = "49";
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnedit.Enabled = false;
            this.btnedit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnedit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnedit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnedit.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnedit.ForeColor = System.Drawing.Color.LightGray;
            this.btnedit.Location = new System.Drawing.Point(214, 414);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(92, 46);
            this.btnedit.TabIndex = 56;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
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
            this.Btnsaveedit.Location = new System.Drawing.Point(0, 7);
            this.Btnsaveedit.Name = "Btnsaveedit";
            this.Btnsaveedit.Size = new System.Drawing.Size(92, 46);
            this.Btnsaveedit.TabIndex = 55;
            this.Btnsaveedit.Text = "Save";
            this.Btnsaveedit.UseVisualStyleBackColor = false;
            this.Btnsaveedit.Click += new System.EventHandler(this.Btnsaveedit_Click);
            // 
            // ProjectCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(727, 480);
            this.ControlBox = false;
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.Lock49);
            this.Controls.Add(this.Lock48);
            this.Controls.Add(this.Lock50);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.GB1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ProjectCodes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProjectCodes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectCodes_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProjectCodes_FormClosed);
            this.Load += new System.EventHandler(this.ProjectCodes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.GB1.ResumeLayout(false);
            this.GB1.PerformLayout();
            this.Lock50.ResumeLayout(false);
            this.Lock48.ResumeLayout(false);
            this.Lock49.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox GB1;
        private System.Windows.Forms.TextBox txt_ProjectCodeID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Currency;
        private System.Windows.Forms.CheckBox checkBox_Active;
        private System.Windows.Forms.DateTimePicker DTP_EndDate;
        private System.Windows.Forms.DateTimePicker DTP_StartDate;
        private System.Windows.Forms.TextBox txt_Budget;
        private System.Windows.Forms.TextBox txt_ProjectDescription;
        private System.Windows.Forms.TextBox txt_ProjectCode;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.GroupBox Lock50;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox Lock48;
        private System.Windows.Forms.GroupBox Lock49;
        private System.Windows.Forms.Button btnSavenew;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Button Btnsaveedit;
        private System.Windows.Forms.Button btnedit;
    }
}