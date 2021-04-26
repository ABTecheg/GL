namespace Accounting_GeneralLedger
{
    partial class AllocationMaintenance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_SourceGLAccount = new System.Windows.Forms.TextBox();
            this.txt_SourceAccountName = new System.Windows.Forms.TextBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.btn_SaveChanges = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_AllocationCodeID = new System.Windows.Forms.TextBox();
            this.btn_New = new System.Windows.Forms.Button();
            this.btnfind = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnnew = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChkRepeat = new System.Windows.Forms.CheckBox();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.dgva = new System.Windows.Forms.DataGridView();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.cb_GLJournalCodes = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_AllocationDescription = new System.Windows.Forms.TextBox();
            this.txt_AllocationCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvallocation = new System.Windows.Forms.DataGridView();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnundo = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.Lock54 = new System.Windows.Forms.GroupBox();
            this.Lock55 = new System.Windows.Forms.GroupBox();
            this.Lock56 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvallocation)).BeginInit();
            this.Lock54.SuspendLayout();
            this.Lock55.SuspendLayout();
            this.Lock56.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(403, 289);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "G/L Account";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(404, 332);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Account Name";
            this.label5.Visible = false;
            // 
            // txt_SourceGLAccount
            // 
            this.txt_SourceGLAccount.Location = new System.Drawing.Point(939, 287);
            this.txt_SourceGLAccount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_SourceGLAccount.Name = "txt_SourceGLAccount";
            this.txt_SourceGLAccount.Size = new System.Drawing.Size(204, 22);
            this.txt_SourceGLAccount.TabIndex = 8;
            this.txt_SourceGLAccount.Visible = false;
            // 
            // txt_SourceAccountName
            // 
            this.txt_SourceAccountName.Location = new System.Drawing.Point(939, 321);
            this.txt_SourceAccountName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_SourceAccountName.MaxLength = 30;
            this.txt_SourceAccountName.Name = "txt_SourceAccountName";
            this.txt_SourceAccountName.Size = new System.Drawing.Size(204, 22);
            this.txt_SourceAccountName.TabIndex = 9;
            this.txt_SourceAccountName.Visible = false;
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(939, 251);
            this.btn_Browse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(103, 28);
            this.btn_Browse.TabIndex = 10;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Visible = false;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // btn_SaveChanges
            // 
            this.btn_SaveChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btn_SaveChanges.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btn_SaveChanges.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_SaveChanges.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btn_SaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveChanges.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SaveChanges.ForeColor = System.Drawing.Color.LightGray;
            this.btn_SaveChanges.Location = new System.Drawing.Point(0, 7);
            this.btn_SaveChanges.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_SaveChanges.Name = "btn_SaveChanges";
            this.btn_SaveChanges.Size = new System.Drawing.Size(92, 46);
            this.btn_SaveChanges.TabIndex = 14;
            this.btn_SaveChanges.Text = "Save";
            this.btn_SaveChanges.UseVisualStyleBackColor = false;
            this.btn_SaveChanges.Click += new System.EventHandler(this.btn_SaveChanges_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(704, 30);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem,
            this.toolStripSeparator1,
            this.insertToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(75, 26);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.findToolStripMenuItem.Text = "Find";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.insertToolStripMenuItem.Text = "Insert";
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.editToolStripMenuItem.Text = "Edit ";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(935, 199);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Allocation Code ID";
            this.label8.Visible = false;
            // 
            // txt_AllocationCodeID
            // 
            this.txt_AllocationCodeID.Location = new System.Drawing.Point(939, 219);
            this.txt_AllocationCodeID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_AllocationCodeID.Name = "txt_AllocationCodeID";
            this.txt_AllocationCodeID.ReadOnly = true;
            this.txt_AllocationCodeID.Size = new System.Drawing.Size(195, 22);
            this.txt_AllocationCodeID.TabIndex = 19;
            this.txt_AllocationCodeID.Visible = false;
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
            this.btn_New.Location = new System.Drawing.Point(0, 7);
            this.btn_New.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(92, 46);
            this.btn_New.TabIndex = 20;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = false;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btnfind
            // 
            this.btnfind.Location = new System.Drawing.Point(955, 513);
            this.btnfind.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnfind.Name = "btnfind";
            this.btnfind.Size = new System.Drawing.Size(79, 27);
            this.btnfind.TabIndex = 22;
            this.btnfind.Text = "Find";
            this.btnfind.UseVisualStyleBackColor = true;
            this.btnfind.Visible = false;
            this.btnfind.Click += new System.EventHandler(this.btnfind_Click);
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
            this.btndelete.Location = new System.Drawing.Point(0, 0);
            this.btndelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(92, 46);
            this.btndelete.TabIndex = 23;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnnew
            // 
            this.btnnew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnnew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnnew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnnew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnnew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnew.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnew.ForeColor = System.Drawing.Color.LightGray;
            this.btnnew.Location = new System.Drawing.Point(0, 0);
            this.btnnew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(92, 46);
            this.btnnew.TabIndex = 24;
            this.btnnew.Text = "Save";
            this.btnnew.UseVisualStyleBackColor = false;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChkRepeat);
            this.groupBox1.Controls.Add(this.lblPercentage);
            this.groupBox1.Controls.Add(this.dgva);
            this.groupBox1.Controls.Add(this.dgv);
            this.groupBox1.Controls.Add(this.cb_GLJournalCodes);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_AllocationDescription);
            this.groupBox1.Controls.Add(this.txt_AllocationCode);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(367, 63);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(531, 492);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.EnabledChanged += new System.EventHandler(this.groupBox1_EnabledChanged);
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // ChkRepeat
            // 
            this.ChkRepeat.AutoSize = true;
            this.ChkRepeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChkRepeat.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkRepeat.ForeColor = System.Drawing.Color.LightGray;
            this.ChkRepeat.Location = new System.Drawing.Point(289, 112);
            this.ChkRepeat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChkRepeat.Name = "ChkRepeat";
            this.ChkRepeat.Size = new System.Drawing.Size(219, 25);
            this.ChkRepeat.TabIndex = 33;
            this.ChkRepeat.Text = "Repeat In Same Period";
            this.ChkRepeat.UseVisualStyleBackColor = true;
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPercentage.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentage.ForeColor = System.Drawing.Color.LightGray;
            this.lblPercentage.Location = new System.Drawing.Point(272, 460);
            this.lblPercentage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(236, 21);
            this.lblPercentage.TabIndex = 32;
            this.lblPercentage.Text = "Remaining Percentage : 0%";
            // 
            // dgva
            // 
            this.dgva.AllowUserToAddRows = false;
            this.dgva.AllowUserToDeleteRows = false;
            this.dgva.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgva.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgva.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgva.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgva.Location = new System.Drawing.Point(16, 161);
            this.dgva.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgva.MultiSelect = false;
            this.dgva.Name = "dgva";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgva.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgva.RowHeadersWidth = 25;
            this.dgva.Size = new System.Drawing.Size(492, 112);
            this.dgva.TabIndex = 31;
            this.dgva.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgva_CellDoubleClick);
            this.dgva.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgva_CellEndEdit);
            this.dgva.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgva_EditingControlShowing);
            this.dgva.Leave += new System.EventHandler(this.dgva_Leave);
            this.dgva.MouseLeave += new System.EventHandler(this.dgva_MouseLeave);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle17;
            this.dgv.Location = new System.Drawing.Point(16, 300);
            this.dgv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.Size = new System.Drawing.Size(492, 156);
            this.dgv.TabIndex = 22;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEndEdit);
            this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
            this.dgv.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_EditingControlShowing);
            this.dgv.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_RowEnter);
            this.dgv.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_RowHeaderMouseClick);
            this.dgv.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_RowsAdded);
            this.dgv.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgv_RowsRemoved);
            this.dgv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
            this.dgv.Leave += new System.EventHandler(this.dgv_Leave);
            this.dgv.MouseLeave += new System.EventHandler(this.dgv_MouseLeave);
            this.dgv.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseMove);
            // 
            // cb_GLJournalCodes
            // 
            this.cb_GLJournalCodes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_GLJournalCodes.FormattingEnabled = true;
            this.cb_GLJournalCodes.Location = new System.Drawing.Point(227, 46);
            this.cb_GLJournalCodes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_GLJournalCodes.Name = "cb_GLJournalCodes";
            this.cb_GLJournalCodes.Size = new System.Drawing.Size(281, 24);
            this.cb_GLJournalCodes.TabIndex = 30;
            this.cb_GLJournalCodes.SelectedIndexChanged += new System.EventHandler(this.cb_GLJournalCodes_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightGray;
            this.label7.Location = new System.Drawing.Point(25, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 21);
            this.label7.TabIndex = 29;
            this.label7.Text = "GLJournal Code";
            // 
            // txt_AllocationDescription
            // 
            this.txt_AllocationDescription.Location = new System.Drawing.Point(227, 79);
            this.txt_AllocationDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_AllocationDescription.MaxLength = 50;
            this.txt_AllocationDescription.Name = "txt_AllocationDescription";
            this.txt_AllocationDescription.Size = new System.Drawing.Size(281, 22);
            this.txt_AllocationDescription.TabIndex = 28;
            // 
            // txt_AllocationCode
            // 
            this.txt_AllocationCode.Location = new System.Drawing.Point(227, 14);
            this.txt_AllocationCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_AllocationCode.MaxLength = 10;
            this.txt_AllocationCode.Name = "txt_AllocationCode";
            this.txt_AllocationCode.Size = new System.Drawing.Size(281, 22);
            this.txt_AllocationCode.TabIndex = 27;
            this.txt_AllocationCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_AllocationCode_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LightGray;
            this.label6.Location = new System.Drawing.Point(16, 277);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 21);
            this.label6.TabIndex = 26;
            this.label6.Text = "Destination Account(s)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(16, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 21);
            this.label3.TabIndex = 25;
            this.label3.Text = "Source Account(s)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(25, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 21);
            this.label2.TabIndex = 24;
            this.label2.Text = "Allocation Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(27, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 21);
            this.label1.TabIndex = 23;
            this.label1.Text = "Allocation Code";
            // 
            // dgvallocation
            // 
            this.dgvallocation.AllowUserToAddRows = false;
            this.dgvallocation.AllowUserToDeleteRows = false;
            this.dgvallocation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvallocation.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvallocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvallocation.Location = new System.Drawing.Point(24, 13);
            this.dgvallocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvallocation.Name = "dgvallocation";
            this.dgvallocation.ReadOnly = true;
            this.dgvallocation.RowHeadersWidth = 15;
            this.dgvallocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvallocation.Size = new System.Drawing.Size(320, 542);
            this.dgvallocation.TabIndex = 26;
            this.dgvallocation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvallocation_CellClick);
            this.dgvallocation.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvallocation_CellContentClick);
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
            this.btnedit.Location = new System.Drawing.Point(0, 0);
            this.btnedit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(92, 46);
            this.btnedit.TabIndex = 27;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
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
            this.btnundo.Location = new System.Drawing.Point(594, 588);
            this.btnundo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnundo.Name = "btnundo";
            this.btnundo.Size = new System.Drawing.Size(92, 46);
            this.btnundo.TabIndex = 29;
            this.btnundo.Text = "Undo";
            this.btnundo.UseVisualStyleBackColor = false;
            this.btnundo.Click += new System.EventHandler(this.btnundo_Click);
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
            this.btnexit.Location = new System.Drawing.Point(771, 588);
            this.btnexit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(92, 46);
            this.btnexit.TabIndex = 30;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // Lock54
            // 
            this.Lock54.Controls.Add(this.btnnew);
            this.Lock54.Controls.Add(this.btn_New);
            this.Lock54.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Lock54.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lock54.ForeColor = System.Drawing.Color.LightGray;
            this.Lock54.Location = new System.Drawing.Point(73, 588);
            this.Lock54.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Lock54.Name = "Lock54";
            this.Lock54.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Lock54.Size = new System.Drawing.Size(92, 46);
            this.Lock54.TabIndex = 31;
            this.Lock54.TabStop = false;
            this.Lock54.Tag = "54";
            // 
            // Lock55
            // 
            this.Lock55.Controls.Add(this.btnedit);
            this.Lock55.Controls.Add(this.btn_SaveChanges);
            this.Lock55.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Lock55.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lock55.ForeColor = System.Drawing.Color.LightGray;
            this.Lock55.Location = new System.Drawing.Point(249, 588);
            this.Lock55.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Lock55.Name = "Lock55";
            this.Lock55.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Lock55.Size = new System.Drawing.Size(92, 46);
            this.Lock55.TabIndex = 32;
            this.Lock55.TabStop = false;
            this.Lock55.Tag = "55";
            // 
            // Lock56
            // 
            this.Lock56.Controls.Add(this.btndelete);
            this.Lock56.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Lock56.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lock56.ForeColor = System.Drawing.Color.LightGray;
            this.Lock56.Location = new System.Drawing.Point(425, 588);
            this.Lock56.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Lock56.Name = "Lock56";
            this.Lock56.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Lock56.Size = new System.Drawing.Size(92, 46);
            this.Lock56.TabIndex = 33;
            this.Lock56.TabStop = false;
            this.Lock56.Tag = "56";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(418, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(415, 40);
            this.label9.TabIndex = 34;
            this.label9.Text = "Allocation Maintenance";
            // 
            // AllocationMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(925, 659);
            this.ControlBox = false;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Lock56);
            this.Controls.Add(this.Lock55);
            this.Controls.Add(this.Lock54);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnundo);
            this.Controls.Add(this.dgvallocation);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnfind);
            this.Controls.Add(this.txt_AllocationCodeID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.txt_SourceAccountName);
            this.Controls.Add(this.txt_SourceGLAccount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AllocationMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AllocationMaintenance";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AllocationMaintenance_FormClosed);
            this.Load += new System.EventHandler(this.AllocationMaintenance_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AllocationMaintenance_MouseMove);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvallocation)).EndInit();
            this.Lock54.ResumeLayout(false);
            this.Lock55.ResumeLayout(false);
            this.Lock56.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_SourceGLAccount;
        private System.Windows.Forms.TextBox txt_SourceAccountName;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Button btn_SaveChanges;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_AllocationCodeID;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Button btnfind;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgva;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ComboBox cb_GLJournalCodes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_AllocationDescription;
        private System.Windows.Forms.TextBox txt_AllocationCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvallocation;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnundo;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.CheckBox ChkRepeat;
        private System.Windows.Forms.GroupBox Lock54;
        private System.Windows.Forms.GroupBox Lock55;
        private System.Windows.Forms.GroupBox Lock56;
        private System.Windows.Forms.Label label9;
    }
}