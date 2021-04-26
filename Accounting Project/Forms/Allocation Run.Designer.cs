namespace Accounting_GeneralLedger
{
    partial class Allocation_Run
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
            this.dgvallocation = new System.Windows.Forms.DataGridView();
            this.btnrun = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvsource = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvdestination = new System.Windows.Forms.DataGridView();
            this.chkpost = new System.Windows.Forms.CheckBox();
            this.lblrepeat = new System.Windows.Forms.Label();
            this.lbllastran = new System.Windows.Forms.Label();
            this.Lock67 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvallocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdestination)).BeginInit();
            this.Lock67.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvallocation
            // 
            this.dgvallocation.AllowUserToAddRows = false;
            this.dgvallocation.AllowUserToDeleteRows = false;
            this.dgvallocation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvallocation.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvallocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvallocation.Location = new System.Drawing.Point(25, 13);
            this.dgvallocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvallocation.Name = "dgvallocation";
            this.dgvallocation.ReadOnly = true;
            this.dgvallocation.RowHeadersWidth = 15;
            this.dgvallocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvallocation.Size = new System.Drawing.Size(398, 410);
            this.dgvallocation.TabIndex = 0;
            this.dgvallocation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvallocation_CellClick);
            // 
            // btnrun
            // 
            this.btnrun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnrun.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnrun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnrun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnrun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrun.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrun.ForeColor = System.Drawing.Color.LightGray;
            this.btnrun.Location = new System.Drawing.Point(16, 27);
            this.btnrun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnrun.Name = "btnrun";
            this.btnrun.Size = new System.Drawing.Size(234, 46);
            this.btnrun.TabIndex = 1;
            this.btnrun.Text = "Run Allocation";
            this.btnrun.UseVisualStyleBackColor = false;
            this.btnrun.Click += new System.EventHandler(this.btnrun_Click);
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
            this.btnexit.Location = new System.Drawing.Point(811, 458);
            this.btnexit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(92, 46);
            this.btnexit.TabIndex = 2;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // dgvsource
            // 
            this.dgvsource.AllowUserToAddRows = false;
            this.dgvsource.AllowUserToDeleteRows = false;
            this.dgvsource.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvsource.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvsource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsource.Location = new System.Drawing.Point(447, 98);
            this.dgvsource.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvsource.Name = "dgvsource";
            this.dgvsource.ReadOnly = true;
            this.dgvsource.RowHeadersWidth = 15;
            this.dgvsource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvsource.Size = new System.Drawing.Size(456, 149);
            this.dgvsource.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LightGray;
            this.label6.Location = new System.Drawing.Point(443, 256);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 21);
            this.label6.TabIndex = 7;
            this.label6.Text = "Destination Accounts";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(443, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Source Account";
            // 
            // dgvdestination
            // 
            this.dgvdestination.AllowUserToAddRows = false;
            this.dgvdestination.AllowUserToDeleteRows = false;
            this.dgvdestination.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvdestination.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvdestination.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdestination.Location = new System.Drawing.Point(447, 284);
            this.dgvdestination.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvdestination.Name = "dgvdestination";
            this.dgvdestination.ReadOnly = true;
            this.dgvdestination.RowHeadersWidth = 15;
            this.dgvdestination.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvdestination.Size = new System.Drawing.Size(456, 139);
            this.dgvdestination.TabIndex = 8;
            // 
            // chkpost
            // 
            this.chkpost.AutoSize = true;
            this.chkpost.Location = new System.Drawing.Point(283, 43);
            this.chkpost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkpost.Name = "chkpost";
            this.chkpost.Size = new System.Drawing.Size(74, 21);
            this.chkpost.TabIndex = 9;
            this.chkpost.Text = "Posted";
            this.chkpost.UseVisualStyleBackColor = true;
            // 
            // lblrepeat
            // 
            this.lblrepeat.AutoSize = true;
            this.lblrepeat.Location = new System.Drawing.Point(289, 446);
            this.lblrepeat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblrepeat.Name = "lblrepeat";
            this.lblrepeat.Size = new System.Drawing.Size(0, 17);
            this.lblrepeat.TabIndex = 10;
            // 
            // lbllastran
            // 
            this.lbllastran.AutoSize = true;
            this.lbllastran.Location = new System.Drawing.Point(463, 407);
            this.lbllastran.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllastran.Name = "lbllastran";
            this.lbllastran.Size = new System.Drawing.Size(0, 17);
            this.lbllastran.TabIndex = 11;
            // 
            // Lock67
            // 
            this.Lock67.Controls.Add(this.btnrun);
            this.Lock67.Controls.Add(this.chkpost);
            this.Lock67.Location = new System.Drawing.Point(25, 431);
            this.Lock67.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Lock67.Name = "Lock67";
            this.Lock67.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Lock67.Size = new System.Drawing.Size(391, 93);
            this.Lock67.TabIndex = 12;
            this.Lock67.TabStop = false;
            this.Lock67.Tag = "67";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(540, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 40);
            this.label1.TabIndex = 13;
            this.label1.Text = "Run Allocations";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Allocation_Run
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(925, 542);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lock67);
            this.Controls.Add(this.lbllastran);
            this.Controls.Add(this.lblrepeat);
            this.Controls.Add(this.dgvdestination);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvsource);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.dgvallocation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Allocation_Run";
            this.Text = "Run Allocation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Allocation_Run_FormClosed);
            this.Load += new System.EventHandler(this.Allocation_Run_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvallocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdestination)).EndInit();
            this.Lock67.ResumeLayout(false);
            this.Lock67.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvallocation;
        private System.Windows.Forms.Button btnrun;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private System.Windows.Forms.DataGridView dgvsource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvdestination;
        private System.Windows.Forms.CheckBox chkpost;
        private System.Windows.Forms.Label lblrepeat;
        private System.Windows.Forms.Label lbllastran;
        private System.Windows.Forms.GroupBox Lock67;
        private System.Windows.Forms.Label label1;
    }
}