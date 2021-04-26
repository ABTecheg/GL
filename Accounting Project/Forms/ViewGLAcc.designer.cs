namespace Accounting_GeneralLedger
{
    partial class ViewGLAcc
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
            this.txt_AccountNumber = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_period = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tab = new System.Windows.Forms.TabControl();
            this.Acctran = new System.Windows.Forms.TabPage();
            this.dgvtran = new System.Windows.Forms.DataGridView();
            this.Acctotal = new System.Windows.Forms.TabPage();
            this.dgvtotal = new System.Windows.Forms.DataGridView();
            this.Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Budget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetChangeLastYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalanceLastYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_year = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tab.SuspendLayout();
            this.Acctran.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtran)).BeginInit();
            this.Acctotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtotal)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_AccountNumber
            // 
            this.txt_AccountNumber.Location = new System.Drawing.Point(158, 13);
            this.txt_AccountNumber.Name = "txt_AccountNumber";
            this.txt_AccountNumber.PromptChar = '%';
            this.txt_AccountNumber.Size = new System.Drawing.Size(131, 20);
            this.txt_AccountNumber.TabIndex = 19;
            this.txt_AccountNumber.DoubleClick += new System.EventHandler(this.txt_AccountNumber_DoubleClick);
            this.txt_AccountNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_AccountNumber_KeyPress);
            this.txt_AccountNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_AccountNumber_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Account Number";
            // 
            // cb_period
            // 
            this.cb_period.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_period.FormattingEnabled = true;
            this.cb_period.Location = new System.Drawing.Point(364, 13);
            this.cb_period.Name = "cb_period";
            this.cb_period.Size = new System.Drawing.Size(113, 21);
            this.cb_period.TabIndex = 80;
            this.cb_period.SelectedIndexChanged += new System.EventHandler(this.cb_period_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(321, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 79;
            this.label13.Text = "Period";
            // 
            // tab
            // 
            this.tab.Controls.Add(this.Acctran);
            this.tab.Controls.Add(this.Acctotal);
            this.tab.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tab.Location = new System.Drawing.Point(0, 52);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(681, 434);
            this.tab.TabIndex = 81;
            this.tab.SelectedIndexChanged += new System.EventHandler(this.tab_SelectedIndexChanged);
            // 
            // Acctran
            // 
            this.Acctran.Controls.Add(this.dgvtran);
            this.Acctran.Location = new System.Drawing.Point(4, 22);
            this.Acctran.Name = "Acctran";
            this.Acctran.Padding = new System.Windows.Forms.Padding(3);
            this.Acctran.Size = new System.Drawing.Size(673, 408);
            this.Acctran.TabIndex = 0;
            this.Acctran.Text = "Account Transactions";
            this.Acctran.UseVisualStyleBackColor = true;
            // 
            // dgvtran
            // 
            this.dgvtran.AccessibleDescription = "";
            this.dgvtran.AllowUserToAddRows = false;
            this.dgvtran.AllowUserToDeleteRows = false;
            this.dgvtran.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvtran.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvtran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtran.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvtran.Location = new System.Drawing.Point(3, 3);
            this.dgvtran.MultiSelect = false;
            this.dgvtran.Name = "dgvtran";
            this.dgvtran.ReadOnly = true;
            this.dgvtran.RowHeadersWidth = 25;
            this.dgvtran.Size = new System.Drawing.Size(667, 402);
            this.dgvtran.TabIndex = 1;
            this.dgvtran.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvtran_CellContentClick);
            // 
            // Acctotal
            // 
            this.Acctotal.Controls.Add(this.dgvtotal);
            this.Acctotal.Location = new System.Drawing.Point(4, 22);
            this.Acctotal.Name = "Acctotal";
            this.Acctotal.Padding = new System.Windows.Forms.Padding(3);
            this.Acctotal.Size = new System.Drawing.Size(673, 408);
            this.Acctotal.TabIndex = 1;
            this.Acctotal.Text = "Account Totals";
            this.Acctotal.UseVisualStyleBackColor = true;
            // 
            // dgvtotal
            // 
            this.dgvtotal.AllowUserToAddRows = false;
            this.dgvtotal.AllowUserToDeleteRows = false;
            this.dgvtotal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvtotal.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvtotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtotal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Period,
            this.NetChange,
            this.Balance,
            this.Budget,
            this.NetChangeLastYear,
            this.BalanceLastYear});
            this.dgvtotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvtotal.Location = new System.Drawing.Point(3, 3);
            this.dgvtotal.MultiSelect = false;
            this.dgvtotal.Name = "dgvtotal";
            this.dgvtotal.ReadOnly = true;
            this.dgvtotal.RowHeadersWidth = 25;
            this.dgvtotal.Size = new System.Drawing.Size(667, 402);
            this.dgvtotal.TabIndex = 2;
            // 
            // Period
            // 
            this.Period.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Period.HeaderText = "";
            this.Period.Name = "Period";
            this.Period.ReadOnly = true;
            this.Period.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Period.Width = 5;
            // 
            // NetChange
            // 
            this.NetChange.HeaderText = "Current Year  Net Change";
            this.NetChange.Name = "NetChange";
            this.NetChange.ReadOnly = true;
            this.NetChange.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NetChange.Width = 88;
            // 
            // Balance
            // 
            this.Balance.HeaderText = "Current Year  Balance";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            this.Balance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Balance.Width = 105;
            // 
            // Budget
            // 
            this.Budget.HeaderText = "Budget";
            this.Budget.Name = "Budget";
            this.Budget.ReadOnly = true;
            this.Budget.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Budget.Width = 47;
            // 
            // NetChangeLastYear
            // 
            this.NetChangeLastYear.HeaderText = "Last Year  Net Change";
            this.NetChangeLastYear.Name = "NetChangeLastYear";
            this.NetChangeLastYear.ReadOnly = true;
            this.NetChangeLastYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NetChangeLastYear.Width = 76;
            // 
            // BalanceLastYear
            // 
            this.BalanceLastYear.HeaderText = "Last Year  Balance";
            this.BalanceLastYear.Name = "BalanceLastYear";
            this.BalanceLastYear.ReadOnly = true;
            this.BalanceLastYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BalanceLastYear.Width = 58;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_year);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_AccountNumber);
            this.groupBox1.Controls.Add(this.cb_period);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(681, 48);
            this.groupBox1.TabIndex = 82;
            this.groupBox1.TabStop = false;
            // 
            // cb_year
            // 
            this.cb_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_year.FormattingEnabled = true;
            this.cb_year.Location = new System.Drawing.Point(364, 12);
            this.cb_year.Name = "cb_year";
            this.cb_year.Size = new System.Drawing.Size(55, 21);
            this.cb_year.TabIndex = 82;
            this.cb_year.Visible = false;
            this.cb_year.SelectedIndexChanged += new System.EventHandler(this.cb_year_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "Year";
            this.label1.Visible = false;
            // 
            // ViewGLAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(681, 486);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewGLAcc";
            this.Text = "View G/L Account";
            this.Load += new System.EventHandler(this.ViewGLAcc_Load);
            this.tab.ResumeLayout(false);
            this.Acctran.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvtran)).EndInit();
            this.Acctotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvtotal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txt_AccountNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_period;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage Acctran;
        private System.Windows.Forms.TabPage Acctotal;
        private System.Windows.Forms.DataGridView dgvtran;
        private System.Windows.Forms.DataGridView dgvtotal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetChange;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Budget;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetChangeLastYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalanceLastYear;
        private System.Windows.Forms.ComboBox cb_year;
        private System.Windows.Forms.Label label1;
    }
}