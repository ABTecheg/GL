namespace Accounting_GeneralLedger
{
    partial class TaxReason
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
            this.btnedit = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnundo = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.Btnsaveedit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_ReasonCodeID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ReasonDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ReasonCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_New = new System.Windows.Forms.Button();
            this.btnSavenew = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aPTaxReasonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.aPTaxReasonTableAdapter = new Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.APTaxReasonTableAdapter();
            this.Lock85 = new System.Windows.Forms.GroupBox();
            this.Lock86 = new System.Windows.Forms.GroupBox();
            this.Lock87 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPTaxReasonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            this.Lock85.SuspendLayout();
            this.Lock86.SuspendLayout();
            this.Lock87.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnedit
            // 
            this.btnedit.Enabled = false;
            this.btnedit.Location = new System.Drawing.Point(0, 6);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(64, 28);
            this.btnedit.TabIndex = 56;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(481, 152);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(64, 28);
            this.btnexit.TabIndex = 58;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnundo
            // 
            this.btnundo.Location = new System.Drawing.Point(373, 152);
            this.btnundo.Name = "btnundo";
            this.btnundo.Size = new System.Drawing.Size(64, 28);
            this.btnundo.TabIndex = 57;
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
            this.btndelete.TabIndex = 54;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // Btnsaveedit
            // 
            this.Btnsaveedit.Location = new System.Drawing.Point(0, 6);
            this.Btnsaveedit.Name = "Btnsaveedit";
            this.Btnsaveedit.Size = new System.Drawing.Size(64, 28);
            this.Btnsaveedit.TabIndex = 53;
            this.Btnsaveedit.Text = "Save";
            this.Btnsaveedit.UseVisualStyleBackColor = true;
            this.Btnsaveedit.Click += new System.EventHandler(this.Btnsaveedit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_ReasonCodeID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_ReasonDescription);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_ReasonCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(277, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 139);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.EnabledChanged += new System.EventHandler(this.groupBox1_EnabledChanged);
            // 
            // txt_ReasonCodeID
            // 
            this.txt_ReasonCodeID.Location = new System.Drawing.Point(117, 19);
            this.txt_ReasonCodeID.Name = "txt_ReasonCodeID";
            this.txt_ReasonCodeID.ReadOnly = true;
            this.txt_ReasonCodeID.Size = new System.Drawing.Size(100, 20);
            this.txt_ReasonCodeID.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Reason ID";
            // 
            // txt_ReasonDescription
            // 
            this.txt_ReasonDescription.Location = new System.Drawing.Point(117, 71);
            this.txt_ReasonDescription.MaxLength = 50;
            this.txt_ReasonDescription.Name = "txt_ReasonDescription";
            this.txt_ReasonDescription.Size = new System.Drawing.Size(160, 20);
            this.txt_ReasonDescription.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Reason Description";
            // 
            // txt_ReasonCode
            // 
            this.txt_ReasonCode.Location = new System.Drawing.Point(117, 45);
            this.txt_ReasonCode.MaxLength = 10;
            this.txt_ReasonCode.Name = "txt_ReasonCode";
            this.txt_ReasonCode.Size = new System.Drawing.Size(160, 20);
            this.txt_ReasonCode.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Reason Code";
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(0, 6);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(64, 28);
            this.btn_New.TabIndex = 51;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btnSavenew
            // 
            this.btnSavenew.Location = new System.Drawing.Point(0, 6);
            this.btnSavenew.Name = "btnSavenew";
            this.btnSavenew.Size = new System.Drawing.Size(64, 28);
            this.btnSavenew.TabIndex = 55;
            this.btnSavenew.Text = "Save";
            this.btnSavenew.UseVisualStyleBackColor = true;
            this.btnSavenew.Click += new System.EventHandler(this.btnSavenew_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgv.DataSource = this.aPTaxReasonBindingSource;
            this.dgv.Location = new System.Drawing.Point(3, 1);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 20;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(268, 138);
            this.dgv.TabIndex = 59;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID_Reason";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID_Reason";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 85;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Code_Reason";
            this.dataGridViewTextBoxColumn2.HeaderText = "Code";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 57;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Description_Reason";
            this.dataGridViewTextBoxColumn3.HeaderText = "Description";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 85;
            // 
            // aPTaxReasonBindingSource
            // 
            this.aPTaxReasonBindingSource.DataMember = "APTaxReason";
            this.aPTaxReasonBindingSource.DataSource = this.dbAccountingProjectDS;
            // 
            // dbAccountingProjectDS
            // 
            this.dbAccountingProjectDS.DataSetName = "dbAccountingProjectDS";
            this.dbAccountingProjectDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aPTaxReasonTableAdapter
            // 
            this.aPTaxReasonTableAdapter.ClearBeforeFill = true;
            // 
            // Lock85
            // 
            this.Lock85.Controls.Add(this.btn_New);
            this.Lock85.Controls.Add(this.btnSavenew);
            this.Lock85.Location = new System.Drawing.Point(49, 146);
            this.Lock85.Name = "Lock85";
            this.Lock85.Size = new System.Drawing.Size(64, 34);
            this.Lock85.TabIndex = 60;
            this.Lock85.TabStop = false;
            this.Lock85.Tag = "85";
            // 
            // Lock86
            // 
            this.Lock86.Controls.Add(this.btnedit);
            this.Lock86.Controls.Add(this.Btnsaveedit);
            this.Lock86.Location = new System.Drawing.Point(157, 146);
            this.Lock86.Name = "Lock86";
            this.Lock86.Size = new System.Drawing.Size(64, 34);
            this.Lock86.TabIndex = 61;
            this.Lock86.TabStop = false;
            this.Lock86.Tag = "86";
            // 
            // Lock87
            // 
            this.Lock87.Controls.Add(this.btndelete);
            this.Lock87.Location = new System.Drawing.Point(265, 146);
            this.Lock87.Name = "Lock87";
            this.Lock87.Size = new System.Drawing.Size(64, 34);
            this.Lock87.TabIndex = 62;
            this.Lock87.TabStop = false;
            this.Lock87.Tag = "87";
            // 
            // TaxReason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(586, 197);
            this.ControlBox = false;
            this.Controls.Add(this.Lock87);
            this.Controls.Add(this.Lock86);
            this.Controls.Add(this.Lock85);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnundo);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TaxReason";
            this.Text = "Tax Reason";
            this.Load += new System.EventHandler(this.TaxReason_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPTaxReasonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            this.Lock85.ResumeLayout(false);
            this.Lock86.ResumeLayout(false);
            this.Lock87.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnundo;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button Btnsaveedit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_ReasonCodeID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ReasonDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ReasonCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Button btnSavenew;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.BindingSource aPTaxReasonBindingSource;
        private Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.APTaxReasonTableAdapter aPTaxReasonTableAdapter;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.GroupBox Lock85;
        private System.Windows.Forms.GroupBox Lock86;
        private System.Windows.Forms.GroupBox Lock87;
    }
}