namespace Accounting_GeneralLedger
{
    partial class ARGenerateInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ARGenerateInvoice));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkdaterange = new System.Windows.Forms.CheckBox();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.txtARCode = new System.Windows.Forms.TextBox();
            this.label_Mode = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.vouchar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TranCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Generated = new System.Windows.Forms.Button();
            this.GrpGenerat = new System.Windows.Forms.GroupBox();
            this.lbltotal = new System.Windows.Forms.Label();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnGen = new System.Windows.Forms.Button();
            this.btnGenPrint = new System.Windows.Forms.Button();
            this.dgvInv = new System.Windows.Forms.DataGridView();
            this.VoucharNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ARCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateInv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkselectall = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.GrpGenerat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkdaterange);
            this.groupBox2.Controls.Add(this.dtp_to);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtp_from);
            this.groupBox2.Location = new System.Drawing.Point(12, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 51);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date Range";
            // 
            // chkdaterange
            // 
            this.chkdaterange.AutoSize = true;
            this.chkdaterange.Location = new System.Drawing.Point(25, 18);
            this.chkdaterange.Name = "chkdaterange";
            this.chkdaterange.Size = new System.Drawing.Size(64, 17);
            this.chkdaterange.TabIndex = 36;
            this.chkdaterange.Text = "By Date";
            this.chkdaterange.UseVisualStyleBackColor = true;
            this.chkdaterange.CheckedChanged += new System.EventHandler(this.chkdaterange_CheckedChanged);
            // 
            // dtp_to
            // 
            this.dtp_to.Enabled = false;
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_to.Location = new System.Drawing.Point(302, 19);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(95, 20);
            this.dtp_to.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "From";
            // 
            // dtp_from
            // 
            this.dtp_from.Enabled = false;
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_from.Location = new System.Drawing.Point(146, 19);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(95, 20);
            this.dtp_from.TabIndex = 32;
            // 
            // txtARCode
            // 
            this.txtARCode.Location = new System.Drawing.Point(180, 12);
            this.txtARCode.Name = "txtARCode";
            this.txtARCode.Size = new System.Drawing.Size(115, 20);
            this.txtARCode.TabIndex = 40;
            this.txtARCode.DoubleClick += new System.EventHandler(this.txtARCode_DoubleClick);
            // 
            // label_Mode
            // 
            this.label_Mode.AutoSize = true;
            this.label_Mode.Location = new System.Drawing.Point(100, 14);
            this.label_Mode.Name = "label_Mode";
            this.label_Mode.Size = new System.Drawing.Size(75, 13);
            this.label_Mode.TabIndex = 39;
            this.label_Mode.Text = "Account Code";
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(322, 12);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(54, 21);
            this.btn_Search.TabIndex = 38;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.vouchar,
            this.BatchNo,
            this.InvoiceDate,
            this.Amount,
            this.TranCode,
            this.AccountCode,
            this.AccountName,
            this.InvoiceNo});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv.Location = new System.Drawing.Point(0, 100);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 20;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(677, 310);
            this.dgv.TabIndex = 41;
            // 
            // check
            // 
            this.check.HeaderText = "Check";
            this.check.Name = "check";
            this.check.Width = 44;
            // 
            // vouchar
            // 
            this.vouchar.HeaderText = "Vouchar#";
            this.vouchar.Name = "vouchar";
            this.vouchar.ReadOnly = true;
            this.vouchar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.vouchar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.vouchar.Width = 60;
            // 
            // BatchNo
            // 
            this.BatchNo.HeaderText = "Batch#";
            this.BatchNo.Name = "BatchNo";
            this.BatchNo.ReadOnly = true;
            this.BatchNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BatchNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BatchNo.Width = 48;
            // 
            // InvoiceDate
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.InvoiceDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.InvoiceDate.HeaderText = "InvoiceDate";
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.ReadOnly = true;
            this.InvoiceDate.Width = 90;
            // 
            // Amount
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Width = 68;
            // 
            // TranCode
            // 
            this.TranCode.HeaderText = "TranCode";
            this.TranCode.Name = "TranCode";
            this.TranCode.ReadOnly = true;
            this.TranCode.Visible = false;
            this.TranCode.Width = 79;
            // 
            // AccountCode
            // 
            this.AccountCode.HeaderText = "AccountCode";
            this.AccountCode.Name = "AccountCode";
            this.AccountCode.ReadOnly = true;
            this.AccountCode.Width = 97;
            // 
            // AccountName
            // 
            this.AccountName.HeaderText = "AccountName";
            this.AccountName.Name = "AccountName";
            this.AccountName.ReadOnly = true;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.HeaderText = "Invoice#";
            this.InvoiceNo.Name = "InvoiceNo";
            this.InvoiceNo.ReadOnly = true;
            this.InvoiceNo.Width = 74;
            // 
            // btn_Generated
            // 
            this.btn_Generated.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Generated.Image = ((System.Drawing.Image)(resources.GetObject("btn_Generated.Image")));
            this.btn_Generated.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Generated.Location = new System.Drawing.Point(524, 19);
            this.btn_Generated.Name = "btn_Generated";
            this.btn_Generated.Size = new System.Drawing.Size(126, 52);
            this.btn_Generated.TabIndex = 42;
            this.btn_Generated.Text = "Generate";
            this.btn_Generated.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Generated.UseVisualStyleBackColor = true;
            this.btn_Generated.Click += new System.EventHandler(this.btn_Generated_Click);
            // 
            // GrpGenerat
            // 
            this.GrpGenerat.Controls.Add(this.lbltotal);
            this.GrpGenerat.Controls.Add(this.btncancel);
            this.GrpGenerat.Controls.Add(this.btnGen);
            this.GrpGenerat.Controls.Add(this.btnGenPrint);
            this.GrpGenerat.Controls.Add(this.dgvInv);
            this.GrpGenerat.Location = new System.Drawing.Point(119, 96);
            this.GrpGenerat.Name = "GrpGenerat";
            this.GrpGenerat.Size = new System.Drawing.Size(467, 314);
            this.GrpGenerat.TabIndex = 43;
            this.GrpGenerat.TabStop = false;
            this.GrpGenerat.Text = "Invoice Generated";
            this.GrpGenerat.Visible = false;
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal.Location = new System.Drawing.Point(255, 16);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(96, 16);
            this.lbltotal.TabIndex = 4;
            this.lbltotal.Text = "Total Amount : ";
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(372, 274);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(79, 33);
            this.btncancel.TabIndex = 3;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(16, 274);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(139, 33);
            this.btnGen.TabIndex = 2;
            this.btnGen.Text = "Generated Only";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // btnGenPrint
            // 
            this.btnGenPrint.Location = new System.Drawing.Point(176, 274);
            this.btnGenPrint.Name = "btnGenPrint";
            this.btnGenPrint.Size = new System.Drawing.Size(140, 33);
            this.btnGenPrint.TabIndex = 1;
            this.btnGenPrint.Text = "Generated And Print";
            this.btnGenPrint.UseVisualStyleBackColor = true;
            // 
            // dgvInv
            // 
            this.dgvInv.AllowUserToAddRows = false;
            this.dgvInv.AllowUserToDeleteRows = false;
            this.dgvInv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvInv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VoucharNO,
            this.ARCode,
            this.DateInv,
            this.InvAmount,
            this.InvNo});
            this.dgvInv.Location = new System.Drawing.Point(6, 48);
            this.dgvInv.Name = "dgvInv";
            this.dgvInv.RowHeadersWidth = 25;
            this.dgvInv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInv.Size = new System.Drawing.Size(454, 214);
            this.dgvInv.TabIndex = 0;
            // 
            // VoucharNO
            // 
            this.VoucharNO.HeaderText = "Vouchar#";
            this.VoucharNO.Name = "VoucharNO";
            this.VoucharNO.ReadOnly = true;
            this.VoucharNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VoucharNO.Width = 60;
            // 
            // ARCode
            // 
            this.ARCode.HeaderText = "AccountCode";
            this.ARCode.Name = "ARCode";
            this.ARCode.ReadOnly = true;
            this.ARCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ARCode.Width = 78;
            // 
            // DateInv
            // 
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.DateInv.DefaultCellStyle = dataGridViewCellStyle3;
            this.DateInv.HeaderText = "DateInv.";
            this.DateInv.Name = "DateInv";
            this.DateInv.ReadOnly = true;
            this.DateInv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DateInv.Width = 54;
            // 
            // InvAmount
            // 
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.InvAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.InvAmount.HeaderText = "Inv.Amount";
            this.InvAmount.Name = "InvAmount";
            this.InvAmount.ReadOnly = true;
            this.InvAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.InvAmount.Width = 67;
            // 
            // InvNo
            // 
            this.InvNo.HeaderText = "Invoice#";
            this.InvNo.Name = "InvNo";
            this.InvNo.ReadOnly = true;
            this.InvNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.InvNo.Width = 55;
            // 
            // chkselectall
            // 
            this.chkselectall.AutoSize = true;
            this.chkselectall.Location = new System.Drawing.Point(444, 77);
            this.chkselectall.Name = "chkselectall";
            this.chkselectall.Size = new System.Drawing.Size(70, 17);
            this.chkselectall.TabIndex = 44;
            this.chkselectall.Text = "Select All";
            this.chkselectall.UseVisualStyleBackColor = true;
            this.chkselectall.CheckedChanged += new System.EventHandler(this.chkselectall_CheckedChanged);
            // 
            // ARGenerateInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(677, 410);
            this.Controls.Add(this.GrpGenerat);
            this.Controls.Add(this.chkselectall);
            this.Controls.Add(this.btn_Generated);
            this.Controls.Add(this.txtARCode);
            this.Controls.Add(this.label_Mode);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ARGenerateInvoice";
            this.Text = "ARGenerateInvoice";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ARGenerateInvoice_FormClosed);
            this.Load += new System.EventHandler(this.ARGenerateInvoice_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.GrpGenerat.ResumeLayout(false);
            this.GrpGenerat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.CheckBox chkdaterange;
        private System.Windows.Forms.TextBox txtARCode;
        private System.Windows.Forms.Label label_Mode;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn vouchar;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.Button btn_Generated;
        private System.Windows.Forms.GroupBox GrpGenerat;
        private System.Windows.Forms.DataGridView dgvInv;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Button btnGenPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn VoucharNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ARCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateInv;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvNo;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.CheckBox chkselectall;
        private System.Windows.Forms.Label lbltotal;
    }
}