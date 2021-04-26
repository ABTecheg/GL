namespace Accounting_GeneralLedger {
    partial class SearchARTemp {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblOrderBy = new System.Windows.Forms.Label();
            this.cb_choose = new System.Windows.Forms.ComboBox();
            this.GBStatus = new System.Windows.Forms.GroupBox();
            this.rbP = new System.Windows.Forms.RadioButton();
            this.rbU = new System.Windows.Forms.RadioButton();
            this.GBNumber = new System.Windows.Forms.GroupBox();
            this.txtJV = new System.Windows.Forms.TextBox();
            this.GBDescription = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.aRBatchTempBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aRBatchTempTableAdapter = new Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.ARBatchTempTableAdapter();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GBStatus.SuspendLayout();
            this.GBNumber.SuspendLayout();
            this.GBDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aRBatchTempBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(297, 279);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblOrderBy
            // 
            this.lblOrderBy.AutoSize = true;
            this.lblOrderBy.Location = new System.Drawing.Point(11, 15);
            this.lblOrderBy.Name = "lblOrderBy";
            this.lblOrderBy.Size = new System.Drawing.Size(44, 13);
            this.lblOrderBy.TabIndex = 2;
            this.lblOrderBy.Text = "Filter By";
            // 
            // cb_choose
            // 
            this.cb_choose.FormattingEnabled = true;
            this.cb_choose.Items.AddRange(new object[] {
            "Number",
            "Description",
            "Status"});
            this.cb_choose.Location = new System.Drawing.Point(62, 12);
            this.cb_choose.Name = "cb_choose";
            this.cb_choose.Size = new System.Drawing.Size(121, 21);
            this.cb_choose.TabIndex = 3;
            this.cb_choose.SelectedIndexChanged += new System.EventHandler(this.cb_choose_SelectedIndexChanged);
            // 
            // GBStatus
            // 
            this.GBStatus.Controls.Add(this.rbP);
            this.GBStatus.Controls.Add(this.rbU);
            this.GBStatus.Location = new System.Drawing.Point(189, 6);
            this.GBStatus.Name = "GBStatus";
            this.GBStatus.Size = new System.Drawing.Size(164, 50);
            this.GBStatus.TabIndex = 6;
            this.GBStatus.TabStop = false;
            this.GBStatus.Text = "Status";
            this.GBStatus.Visible = false;
            // 
            // rbP
            // 
            this.rbP.AutoSize = true;
            this.rbP.Location = new System.Drawing.Point(89, 19);
            this.rbP.Name = "rbP";
            this.rbP.Size = new System.Drawing.Size(69, 17);
            this.rbP.TabIndex = 7;
            this.rbP.TabStop = true;
            this.rbP.Text = "Disactive";
            this.rbP.UseVisualStyleBackColor = true;
            this.rbP.CheckedChanged += new System.EventHandler(this.rbP_CheckedChanged);
            // 
            // rbU
            // 
            this.rbU.AutoSize = true;
            this.rbU.Location = new System.Drawing.Point(15, 19);
            this.rbU.Name = "rbU";
            this.rbU.Size = new System.Drawing.Size(55, 17);
            this.rbU.TabIndex = 6;
            this.rbU.TabStop = true;
            this.rbU.Text = "Active";
            this.rbU.UseVisualStyleBackColor = true;
            this.rbU.CheckedChanged += new System.EventHandler(this.rbU_CheckedChanged);
            // 
            // GBNumber
            // 
            this.GBNumber.Controls.Add(this.txtJV);
            this.GBNumber.Location = new System.Drawing.Point(189, 6);
            this.GBNumber.Name = "GBNumber";
            this.GBNumber.Size = new System.Drawing.Size(112, 50);
            this.GBNumber.TabIndex = 7;
            this.GBNumber.TabStop = false;
            this.GBNumber.Text = "Number";
            this.GBNumber.Visible = false;
            // 
            // txtJV
            // 
            this.txtJV.Location = new System.Drawing.Point(6, 19);
            this.txtJV.Name = "txtJV";
            this.txtJV.Size = new System.Drawing.Size(100, 20);
            this.txtJV.TabIndex = 0;
            this.txtJV.TextChanged += new System.EventHandler(this.txtJV_TextChanged);
            // 
            // GBDescription
            // 
            this.GBDescription.Controls.Add(this.txtDescription);
            this.GBDescription.Location = new System.Drawing.Point(189, 6);
            this.GBDescription.Name = "GBDescription";
            this.GBDescription.Size = new System.Drawing.Size(157, 50);
            this.GBDescription.TabIndex = 8;
            this.GBDescription.TabStop = false;
            this.GBDescription.Text = "Description";
            this.GBDescription.Visible = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(6, 19);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(145, 20);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // dbAccountingProjectDS
            // 
            this.dbAccountingProjectDS.DataSetName = "dbAccountingProjectDS";
            this.dbAccountingProjectDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aRBatchTempBindingSource
            // 
            this.aRBatchTempBindingSource.DataMember = "ARBatchTemp";
            this.aRBatchTempBindingSource.DataSource = this.dbAccountingProjectDS;
            // 
            // aRBatchTempTableAdapter
            // 
            this.aRBatchTempTableAdapter.ClearBeforeFill = true;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.UserID});
            this.dgv.DataSource = this.aRBatchTempBindingSource;
            this.dgv.Location = new System.Drawing.Point(6, 62);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(389, 211);
            this.dgv.TabIndex = 11;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TempID";
            this.dataGridViewTextBoxColumn1.HeaderText = "TempID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DescTemp";
            this.dataGridViewTextBoxColumn2.HeaderText = "DescTemp";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 84;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "active";
            this.dataGridViewTextBoxColumn3.HeaderText = "active";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 61;
            // 
            // UserID
            // 
            this.UserID.DataPropertyName = "UserID";
            this.UserID.HeaderText = "UserID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            this.UserID.Width = 65;
            // 
            // SearchARTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(396, 306);
            this.ControlBox = false;
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.GBStatus);
            this.Controls.Add(this.GBNumber);
            this.Controls.Add(this.GBDescription);
            this.Controls.Add(this.cb_choose);
            this.Controls.Add(this.lblOrderBy);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SearchARTemp";
            this.Text = "SearchARTemp";
            this.Load += new System.EventHandler(this.SearchARTemp_Load);
            this.GBStatus.ResumeLayout(false);
            this.GBStatus.PerformLayout();
            this.GBNumber.ResumeLayout(false);
            this.GBNumber.PerformLayout();
            this.GBDescription.ResumeLayout(false);
            this.GBDescription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aRBatchTempBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblOrderBy;
        private System.Windows.Forms.ComboBox cb_choose;
        private System.Windows.Forms.GroupBox GBStatus;
        private System.Windows.Forms.RadioButton rbP;
        private System.Windows.Forms.RadioButton rbU;
        private System.Windows.Forms.GroupBox GBNumber;
        private System.Windows.Forms.TextBox txtJV;
        private System.Windows.Forms.GroupBox GBDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.BindingSource aRBatchTempBindingSource;
        private Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.ARBatchTempTableAdapter aRBatchTempTableAdapter;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
    }
}