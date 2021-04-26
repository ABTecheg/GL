namespace Accounting_GeneralLedger
{
    partial class SearchProjectCode
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
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.gLProjectCodesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gLProjectCodesTableAdapter = new Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.GLProjectCodesTableAdapter();
            this.gLProjectCodesDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gLProjectCodesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gLProjectCodesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dbAccountingProjectDS
            // 
            this.dbAccountingProjectDS.DataSetName = "dbAccountingProjectDS";
            this.dbAccountingProjectDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gLProjectCodesBindingSource
            // 
            this.gLProjectCodesBindingSource.DataMember = "GLProjectCodes";
            this.gLProjectCodesBindingSource.DataSource = this.dbAccountingProjectDS;
            // 
            // gLProjectCodesTableAdapter
            // 
            this.gLProjectCodesTableAdapter.ClearBeforeFill = true;
            // 
            // gLProjectCodesDataGridView
            // 
            this.gLProjectCodesDataGridView.AutoGenerateColumns = false;
            this.gLProjectCodesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.gLProjectCodesDataGridView.DataSource = this.gLProjectCodesBindingSource;
            this.gLProjectCodesDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.gLProjectCodesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.gLProjectCodesDataGridView.Name = "gLProjectCodesDataGridView";
            this.gLProjectCodesDataGridView.ReadOnly = true;
            this.gLProjectCodesDataGridView.RowHeadersWidth = 25;
            this.gLProjectCodesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gLProjectCodesDataGridView.Size = new System.Drawing.Size(267, 160);
            this.gLProjectCodesDataGridView.TabIndex = 1;
            this.gLProjectCodesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gLProjectCodesDataGridView_CellContentClick);
            this.gLProjectCodesDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gLProjectCodesDataGridView_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ProjectCode";
            this.dataGridViewTextBoxColumn2.HeaderText = "ProjectCode";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 75;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ProjectDescription";
            this.dataGridViewTextBoxColumn3.HeaderText = "ProjectDescription";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnexit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnexit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnexit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.ForeColor = System.Drawing.Color.LightGray;
            this.btnexit.Location = new System.Drawing.Point(150, 183);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(92, 46);
            this.btnexit.TabIndex = 2;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnok
            // 
            this.btnok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnok.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnok.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnok.ForeColor = System.Drawing.Color.LightGray;
            this.btnok.Location = new System.Drawing.Point(24, 183);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(92, 46);
            this.btnok.TabIndex = 3;
            this.btnok.Text = "OK";
            this.btnok.UseVisualStyleBackColor = false;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // SearchProjectCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(267, 241);
            this.ControlBox = false;
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.gLProjectCodesDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SearchProjectCode";
            this.Text = "SearchProjectCode";
            this.Load += new System.EventHandler(this.SearchProjectCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gLProjectCodesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gLProjectCodesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.BindingSource gLProjectCodesBindingSource;
        private Accounting_GeneralLedger.dbAccountingProjectDSTableAdapters.GLProjectCodesTableAdapter gLProjectCodesTableAdapter;
        private System.Windows.Forms.DataGridView gLProjectCodesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnok;
    }
}