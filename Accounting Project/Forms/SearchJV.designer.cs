namespace Accounting_GeneralLedger {
    partial class SearchJV {
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.BatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jVNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchDSCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchStatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
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
            this.GBDate = new System.Windows.Forms.GroupBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.DTTo = new System.Windows.Forms.DateTimePicker();
            this.DTFrom = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            this.GBStatus.SuspendLayout();
            this.GBNumber.SuspendLayout();
            this.GBDescription.SuspendLayout();
            this.GBDate.SuspendLayout();
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
            this.BatchNo,
            this.jVNumberDataGridViewTextBoxColumn,
            this.BatchDate,
            this.batchDSCDataGridViewTextBoxColumn,
            this.batchStatDataGridViewTextBoxColumn});
            this.dgv.DataMember = "Batch";
            this.dgv.DataSource = this.dbAccountingProjectDSBindingSource;
            this.dgv.Location = new System.Drawing.Point(12, 68);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(471, 205);
            this.dgv.TabIndex = 0;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseDoubleClick);
            // 
            // BatchNo
            // 
            this.BatchNo.DataPropertyName = "BatchNo";
            this.BatchNo.HeaderText = "BatchNo";
            this.BatchNo.Name = "BatchNo";
            this.BatchNo.ReadOnly = true;
            this.BatchNo.Width = 74;
            // 
            // jVNumberDataGridViewTextBoxColumn
            // 
            this.jVNumberDataGridViewTextBoxColumn.DataPropertyName = "JVNumber";
            this.jVNumberDataGridViewTextBoxColumn.HeaderText = "JV Number";
            this.jVNumberDataGridViewTextBoxColumn.Name = "jVNumberDataGridViewTextBoxColumn";
            this.jVNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.jVNumberDataGridViewTextBoxColumn.Width = 84;
            // 
            // BatchDate
            // 
            this.BatchDate.DataPropertyName = "BatchDate";
            this.BatchDate.HeaderText = "Batch Date";
            this.BatchDate.Name = "BatchDate";
            this.BatchDate.ReadOnly = true;
            this.BatchDate.Width = 86;
            // 
            // batchDSCDataGridViewTextBoxColumn
            // 
            this.batchDSCDataGridViewTextBoxColumn.DataPropertyName = "BatchDSC";
            this.batchDSCDataGridViewTextBoxColumn.HeaderText = "JV Description";
            this.batchDSCDataGridViewTextBoxColumn.Name = "batchDSCDataGridViewTextBoxColumn";
            this.batchDSCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // batchStatDataGridViewTextBoxColumn
            // 
            this.batchStatDataGridViewTextBoxColumn.DataPropertyName = "BatchStat";
            this.batchStatDataGridViewTextBoxColumn.HeaderText = "Status";
            this.batchStatDataGridViewTextBoxColumn.Name = "batchStatDataGridViewTextBoxColumn";
            this.batchStatDataGridViewTextBoxColumn.ReadOnly = true;
            this.batchStatDataGridViewTextBoxColumn.Width = 62;
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
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.LightGray;
            this.btnClose.Location = new System.Drawing.Point(391, 295);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 46);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = false;
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
            "Date",
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
            this.GBStatus.Size = new System.Drawing.Size(153, 50);
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
            this.rbP.Size = new System.Drawing.Size(58, 17);
            this.rbP.TabIndex = 7;
            this.rbP.TabStop = true;
            this.rbP.Text = "Posted";
            this.rbP.UseVisualStyleBackColor = true;
            this.rbP.CheckedChanged += new System.EventHandler(this.rbP_CheckedChanged);
            // 
            // rbU
            // 
            this.rbU.AutoSize = true;
            this.rbU.Location = new System.Drawing.Point(15, 19);
            this.rbU.Name = "rbU";
            this.rbU.Size = new System.Drawing.Size(72, 17);
            this.rbU.TabIndex = 6;
            this.rbU.TabStop = true;
            this.rbU.Text = "UnPosted";
            this.rbU.UseVisualStyleBackColor = true;
            this.rbU.CheckedChanged += new System.EventHandler(this.rbU_CheckedChanged);
            // 
            // GBNumber
            // 
            this.GBNumber.Controls.Add(this.txtJV);
            this.GBNumber.Location = new System.Drawing.Point(359, 6);
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
            this.GBDescription.Location = new System.Drawing.Point(359, 6);
            this.GBDescription.Name = "GBDescription";
            this.GBDescription.Size = new System.Drawing.Size(112, 50);
            this.GBDescription.TabIndex = 8;
            this.GBDescription.TabStop = false;
            this.GBDescription.Text = "Description";
            this.GBDescription.Visible = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(6, 19);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(100, 20);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // GBDate
            // 
            this.GBDate.Controls.Add(this.lblTo);
            this.GBDate.Controls.Add(this.lblFrom);
            this.GBDate.Controls.Add(this.DTTo);
            this.GBDate.Controls.Add(this.DTFrom);
            this.GBDate.Location = new System.Drawing.Point(195, 6);
            this.GBDate.Name = "GBDate";
            this.GBDate.Size = new System.Drawing.Size(284, 50);
            this.GBDate.TabIndex = 9;
            this.GBDate.TabStop = false;
            this.GBDate.Text = "Date";
            this.GBDate.Visible = false;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(155, 20);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(13, 20);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "From";
            // 
            // DTTo
            // 
            this.DTTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTTo.Location = new System.Drawing.Point(180, 16);
            this.DTTo.Name = "DTTo";
            this.DTTo.Size = new System.Drawing.Size(92, 20);
            this.DTTo.TabIndex = 1;
            this.DTTo.ValueChanged += new System.EventHandler(this.DTTo_ValueChanged);
            // 
            // DTFrom
            // 
            this.DTFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFrom.Location = new System.Drawing.Point(50, 16);
            this.DTFrom.Name = "DTFrom";
            this.DTFrom.Size = new System.Drawing.Size(90, 20);
            this.DTFrom.TabIndex = 0;
            this.DTFrom.ValueChanged += new System.EventHandler(this.DTFrom_ValueChanged);
            // 
            // SearchJV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(498, 353);
            this.ControlBox = false;
            this.Controls.Add(this.GBDate);
            this.Controls.Add(this.GBDescription);
            this.Controls.Add(this.GBNumber);
            this.Controls.Add(this.GBStatus);
            this.Controls.Add(this.cb_choose);
            this.Controls.Add(this.lblOrderBy);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SearchJV";
            this.Text = "SearchJV";
            this.Load += new System.EventHandler(this.SearchJV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            this.GBStatus.ResumeLayout(false);
            this.GBStatus.PerformLayout();
            this.GBNumber.ResumeLayout(false);
            this.GBNumber.PerformLayout();
            this.GBDescription.ResumeLayout(false);
            this.GBDescription.PerformLayout();
            this.GBDate.ResumeLayout(false);
            this.GBDate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private dbAccountingProjectDS dbAccountingProjectDS;
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
        private System.Windows.Forms.GroupBox GBDate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker DTTo;
        private System.Windows.Forms.DateTimePicker DTFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn jVNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchDSCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchStatDataGridViewTextBoxColumn;
    }
}