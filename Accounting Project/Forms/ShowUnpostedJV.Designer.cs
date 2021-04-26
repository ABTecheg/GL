namespace Accounting_GeneralLedger {
    partial class ShowUnpostedJV {
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
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.BatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jVNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchDSCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchStatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchSRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
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
            this.btnClose.Location = new System.Drawing.Point(403, 228);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 46);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = " Exit";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.batchDSCDataGridViewTextBoxColumn,
            this.BatchDate,
            this.batchStatDataGridViewTextBoxColumn,
            this.BatchSRC});
            this.dgv.DataMember = "Batch";
            this.dgv.DataSource = this.dbAccountingProjectDSBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(523, 205);
            this.dgv.TabIndex = 10;
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
            // batchDSCDataGridViewTextBoxColumn
            // 
            this.batchDSCDataGridViewTextBoxColumn.DataPropertyName = "BatchDSC";
            this.batchDSCDataGridViewTextBoxColumn.HeaderText = "JV Description";
            this.batchDSCDataGridViewTextBoxColumn.Name = "batchDSCDataGridViewTextBoxColumn";
            this.batchDSCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BatchDate
            // 
            this.BatchDate.DataPropertyName = "BatchDate";
            this.BatchDate.HeaderText = "Batch Date";
            this.BatchDate.Name = "BatchDate";
            this.BatchDate.ReadOnly = true;
            this.BatchDate.Width = 86;
            // 
            // batchStatDataGridViewTextBoxColumn
            // 
            this.batchStatDataGridViewTextBoxColumn.DataPropertyName = "BatchStat";
            this.batchStatDataGridViewTextBoxColumn.HeaderText = "Status";
            this.batchStatDataGridViewTextBoxColumn.Name = "batchStatDataGridViewTextBoxColumn";
            this.batchStatDataGridViewTextBoxColumn.ReadOnly = true;
            this.batchStatDataGridViewTextBoxColumn.Width = 62;
            // 
            // BatchSRC
            // 
            this.BatchSRC.DataPropertyName = "BatchSRC";
            this.BatchSRC.HeaderText = "BatchSRC";
            this.BatchSRC.Name = "BatchSRC";
            this.BatchSRC.ReadOnly = true;
            this.BatchSRC.Width = 82;
            // 
            // ShowUnpostedJV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(523, 297);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowUnpostedJV";
            this.Text = "ShowUnpostedJV";
            this.Load += new System.EventHandler(this.ShowUnpostedJV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn jVNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchDSCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchStatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchSRC;

    }
}