namespace Accounting_GeneralLedger
{
    partial class ARTransactionCodes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ARTransactionCodes));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.transCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aRTransactionCodesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.label3 = new System.Windows.Forms.Label();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txt_Desc = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.chxInActive = new System.Windows.Forms.CheckBox();
            this.chxPayMethod = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.UndoBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.NewBtn = new System.Windows.Forms.Button();
            this.EditSaveBtn = new System.Windows.Forms.Button();
            this.NewSaveBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aRTransactionCodesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.transCodeDataGridViewTextBoxColumn,
            this.transDescDataGridViewTextBoxColumn,
            this.accountNumberDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.aRTransactionCodesBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(305, 219);
            this.dgv.TabIndex = 558;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // transCodeDataGridViewTextBoxColumn
            // 
            this.transCodeDataGridViewTextBoxColumn.DataPropertyName = "TransCode";
            this.transCodeDataGridViewTextBoxColumn.HeaderText = "TransCode";
            this.transCodeDataGridViewTextBoxColumn.Name = "transCodeDataGridViewTextBoxColumn";
            this.transCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.transCodeDataGridViewTextBoxColumn.Width = 84;
            // 
            // transDescDataGridViewTextBoxColumn
            // 
            this.transDescDataGridViewTextBoxColumn.DataPropertyName = "TransDesc";
            this.transDescDataGridViewTextBoxColumn.HeaderText = "TransDesc";
            this.transDescDataGridViewTextBoxColumn.Name = "transDescDataGridViewTextBoxColumn";
            this.transDescDataGridViewTextBoxColumn.ReadOnly = true;
            this.transDescDataGridViewTextBoxColumn.Width = 84;
            // 
            // accountNumberDataGridViewTextBoxColumn
            // 
            this.accountNumberDataGridViewTextBoxColumn.DataPropertyName = "AccountNumber";
            this.accountNumberDataGridViewTextBoxColumn.HeaderText = "AccountNumber";
            this.accountNumberDataGridViewTextBoxColumn.Name = "accountNumberDataGridViewTextBoxColumn";
            this.accountNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.accountNumberDataGridViewTextBoxColumn.Width = 109;
            // 
            // aRTransactionCodesBindingSource
            // 
            this.aRTransactionCodesBindingSource.DataMember = "ARTransactionCodes";
            this.aRTransactionCodesBindingSource.DataSource = this.dbAccountingProjectDS;
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
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 571;
            this.label3.Text = "Account Code";
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // catDescDataGridViewTextBoxColumn
            // 
            this.catDescDataGridViewTextBoxColumn.DataPropertyName = "CatDesc";
            this.catDescDataGridViewTextBoxColumn.HeaderText = "CatDesc";
            this.catDescDataGridViewTextBoxColumn.Name = "catDescDataGridViewTextBoxColumn";
            // 
            // txtAccount
            // 
            this.txtAccount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccount.Location = new System.Drawing.Point(114, 68);
            this.txtAccount.MaxLength = 5;
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.ReadOnly = true;
            this.txtAccount.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAccount.Size = new System.Drawing.Size(120, 21);
            this.txtAccount.TabIndex = 561;
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(114, 14);
            this.txtCode.MaxLength = 10;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(120, 21);
            this.txtCode.TabIndex = 559;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Red;
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(6, 17);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(105, 13);
            this.Label2.TabIndex = 570;
            this.Label2.Text = "Transaction Code";
            // 
            // txt_Desc
            // 
            this.txt_Desc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Desc.Location = new System.Drawing.Point(114, 41);
            this.txt_Desc.MaxLength = 50;
            this.txt_Desc.Name = "txt_Desc";
            this.txt_Desc.Size = new System.Drawing.Size(227, 21);
            this.txt_Desc.TabIndex = 560;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Red;
            this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label1.Location = new System.Drawing.Point(6, 41);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(71, 13);
            this.Label1.TabIndex = 569;
            this.Label1.Text = "Description";
            // 
            // chxInActive
            // 
            this.chxInActive.AutoSize = true;
            this.chxInActive.Location = new System.Drawing.Point(114, 100);
            this.chxInActive.Name = "chxInActive";
            this.chxInActive.Size = new System.Drawing.Size(65, 17);
            this.chxInActive.TabIndex = 572;
            this.chxInActive.Text = "InActive";
            this.chxInActive.UseVisualStyleBackColor = true;
            // 
            // chxPayMethod
            // 
            this.chxPayMethod.AutoSize = true;
            this.chxPayMethod.Location = new System.Drawing.Point(234, 100);
            this.chxPayMethod.Name = "chxPayMethod";
            this.chxPayMethod.Size = new System.Drawing.Size(106, 17);
            this.chxPayMethod.TabIndex = 573;
            this.chxPayMethod.Text = "Payment Method";
            this.chxPayMethod.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(240, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 23);
            this.button1.TabIndex = 574;
            this.button1.Text = "....";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.Image = ((System.Drawing.Image)(resources.GetObject("ExitBtn.Image")));
            this.ExitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExitBtn.Location = new System.Drawing.Point(506, 177);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(75, 24);
            this.ExitBtn.TabIndex = 567;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Enabled = false;
            this.DeleteBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("DeleteBtn.Image")));
            this.DeleteBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DeleteBtn.Location = new System.Drawing.Point(561, 147);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 24);
            this.DeleteBtn.TabIndex = 566;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // UndoBtn
            // 
            this.UndoBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UndoBtn.Image = ((System.Drawing.Image)(resources.GetObject("UndoBtn.Image")));
            this.UndoBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UndoBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UndoBtn.Location = new System.Drawing.Point(381, 177);
            this.UndoBtn.Name = "UndoBtn";
            this.UndoBtn.Size = new System.Drawing.Size(75, 24);
            this.UndoBtn.TabIndex = 565;
            this.UndoBtn.Text = "Undo";
            this.UndoBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UndoBtn.UseVisualStyleBackColor = true;
            this.UndoBtn.Click += new System.EventHandler(this.UndoBtn_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.Enabled = false;
            this.EditBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditBtn.Image")));
            this.EditBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EditBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EditBtn.Location = new System.Drawing.Point(440, 147);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(75, 24);
            this.EditBtn.TabIndex = 564;
            this.EditBtn.Text = "Edit";
            this.EditBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // NewBtn
            // 
            this.NewBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewBtn.Image = ((System.Drawing.Image)(resources.GetObject("NewBtn.Image")));
            this.NewBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NewBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NewBtn.Location = new System.Drawing.Point(319, 147);
            this.NewBtn.Name = "NewBtn";
            this.NewBtn.Size = new System.Drawing.Size(75, 24);
            this.NewBtn.TabIndex = 562;
            this.NewBtn.Text = "New";
            this.NewBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NewBtn.UseVisualStyleBackColor = true;
            this.NewBtn.Click += new System.EventHandler(this.NewBtn_Click);
            // 
            // EditSaveBtn
            // 
            this.EditSaveBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditSaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditSaveBtn.Image")));
            this.EditSaveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EditSaveBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EditSaveBtn.Location = new System.Drawing.Point(440, 147);
            this.EditSaveBtn.Name = "EditSaveBtn";
            this.EditSaveBtn.Size = new System.Drawing.Size(75, 24);
            this.EditSaveBtn.TabIndex = 568;
            this.EditSaveBtn.Text = "Save";
            this.EditSaveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EditSaveBtn.UseVisualStyleBackColor = true;
            this.EditSaveBtn.Click += new System.EventHandler(this.EditSaveBtn_Click);
            // 
            // NewSaveBtn
            // 
            this.NewSaveBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewSaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("NewSaveBtn.Image")));
            this.NewSaveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NewSaveBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NewSaveBtn.Location = new System.Drawing.Point(319, 146);
            this.NewSaveBtn.Name = "NewSaveBtn";
            this.NewSaveBtn.Size = new System.Drawing.Size(75, 25);
            this.NewSaveBtn.TabIndex = 563;
            this.NewSaveBtn.Text = "Save";
            this.NewSaveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NewSaveBtn.UseVisualStyleBackColor = true;
            this.NewSaveBtn.Click += new System.EventHandler(this.NewSaveBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Desc);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Controls.Add(this.chxPayMethod);
            this.groupBox1.Controls.Add(this.Label2);
            this.groupBox1.Controls.Add(this.chxInActive);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.txtAccount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(311, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 129);
            this.groupBox1.TabIndex = 575;
            this.groupBox1.TabStop = false;
            this.groupBox1.EnabledChanged += new System.EventHandler(this.groupBox1_EnabledChanged);
            // 
            // ARTransactionCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(665, 219);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.UndoBtn);
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.NewBtn);
            this.Controls.Add(this.EditSaveBtn);
            this.Controls.Add(this.NewSaveBtn);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ARTransactionCodes";
            this.Text = "ARTransactionCodes";
            this.Load += new System.EventHandler(this.ARTransactionCodes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aRTransactionCodesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private dbAccountingProjectDS dbAccountingProjectDS;
        internal System.Windows.Forms.Button ExitBtn;
        internal System.Windows.Forms.Button DeleteBtn;
        internal System.Windows.Forms.Button UndoBtn;
        internal System.Windows.Forms.Button EditBtn;
        internal System.Windows.Forms.Button NewBtn;
        internal System.Windows.Forms.Button EditSaveBtn;
        internal System.Windows.Forms.Button NewSaveBtn;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn catDescDataGridViewTextBoxColumn;
        public System.Windows.Forms.TextBox txtAccount;
        internal System.Windows.Forms.TextBox txtCode;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txt_Desc;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.CheckBox chxInActive;
        private System.Windows.Forms.CheckBox chxPayMethod;
        private System.Windows.Forms.BindingSource aRTransactionCodesBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn transCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountNumberDataGridViewTextBoxColumn;
    }
}