namespace Accounting_GeneralLedger
{
    partial class AvailableTables
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComputerIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComputerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormLock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Table = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnunlockall = new System.Windows.Forms.Button();
            this.btnunlockselect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.ID,
            this.ComputerIP,
            this.ComputerName,
            this.FormLock,
            this.Table,
            this.State,
            this.IDRow,
            this.Date_Time});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(665, 308);
            this.dgv.TabIndex = 0;
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.Width = 43;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 43;
            // 
            // ComputerIP
            // 
            this.ComputerIP.HeaderText = "ComputerIP";
            this.ComputerIP.Name = "ComputerIP";
            this.ComputerIP.ReadOnly = true;
            this.ComputerIP.Width = 87;
            // 
            // ComputerName
            // 
            this.ComputerName.HeaderText = "ComputerName";
            this.ComputerName.Name = "ComputerName";
            this.ComputerName.ReadOnly = true;
            this.ComputerName.Width = 105;
            // 
            // FormLock
            // 
            this.FormLock.HeaderText = "FormLock";
            this.FormLock.Name = "FormLock";
            this.FormLock.ReadOnly = true;
            this.FormLock.Width = 79;
            // 
            // Table
            // 
            this.Table.HeaderText = "Table";
            this.Table.Name = "Table";
            this.Table.ReadOnly = true;
            this.Table.Width = 59;
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Width = 57;
            // 
            // IDRow
            // 
            this.IDRow.HeaderText = "IDRow";
            this.IDRow.Name = "IDRow";
            this.IDRow.ReadOnly = true;
            this.IDRow.Width = 65;
            // 
            // Date_Time
            // 
            this.Date_Time.HeaderText = "Date_Time";
            this.Date_Time.Name = "Date_Time";
            this.Date_Time.ReadOnly = true;
            this.Date_Time.Width = 84;
            // 
            // btnunlockall
            // 
            this.btnunlockall.Location = new System.Drawing.Point(505, 326);
            this.btnunlockall.Name = "btnunlockall";
            this.btnunlockall.Size = new System.Drawing.Size(129, 31);
            this.btnunlockall.TabIndex = 1;
            this.btnunlockall.Text = "UnLock All";
            this.btnunlockall.UseVisualStyleBackColor = true;
            this.btnunlockall.Click += new System.EventHandler(this.btnunlockall_Click);
            // 
            // btnunlockselect
            // 
            this.btnunlockselect.Location = new System.Drawing.Point(331, 326);
            this.btnunlockselect.Name = "btnunlockselect";
            this.btnunlockselect.Size = new System.Drawing.Size(129, 31);
            this.btnunlockselect.TabIndex = 2;
            this.btnunlockselect.Text = "UnLock Selected";
            this.btnunlockselect.UseVisualStyleBackColor = true;
            this.btnunlockselect.Click += new System.EventHandler(this.btnunlockselect_Click);
            // 
            // AvailableTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(665, 377);
            this.Controls.Add(this.btnunlockselect);
            this.Controls.Add(this.btnunlockall);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AvailableTables";
            this.Text = "AvailableTables";
            this.Load += new System.EventHandler(this.AvailableTables_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnunlockall;
        private System.Windows.Forms.Button btnunlockselect;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComputerIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComputerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormLock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Table;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_Time;
    }
}