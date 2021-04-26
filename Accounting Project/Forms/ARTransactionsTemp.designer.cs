namespace Accounting_GeneralLedger
{
    partial class ARTransactionsTemp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ARTransactionsTemp));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSaveEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.PrintDocument1 = new System.Drawing.Printing.PrintDocument();
            this.PrintDialog1 = new System.Windows.Forms.PrintDialog();
            this.PageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.checkBox_multiCurrency = new System.Windows.Forms.CheckBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.ARbatchTempBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtCountUnits = new System.Windows.Forms.TextBox();
            this.btnSaveNew = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_UserID = new System.Windows.Forms.TextBox();
            this.txt_JVDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Balance = new System.Windows.Forms.TextBox();
            this.label_Currency = new System.Windows.Forms.Label();
            this.cb_Currency = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.chkactive = new System.Windows.Forms.CheckBox();
            this.label_CurrencyRate = new System.Windows.Forms.Label();
            this.txt_CurrencyRate = new System.Windows.Forms.TextBox();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.Lock59 = new System.Windows.Forms.GroupBox();
            this.Lock58 = new System.Windows.Forms.GroupBox();
            this.Lock57 = new System.Windows.Forms.GroupBox();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ARbatchTempBindingSource)).BeginInit();
            this.groupDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Lock59.SuspendLayout();
            this.Lock58.SuspendLayout();
            this.Lock57.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(0, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(98, 46);
            this.btnEdit.TabIndex = 49;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSaveEdit
            // 
            this.btnSaveEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveEdit.Image")));
            this.btnSaveEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveEdit.Location = new System.Drawing.Point(0, 6);
            this.btnSaveEdit.Name = "btnSaveEdit";
            this.btnSaveEdit.Size = new System.Drawing.Size(98, 46);
            this.btnSaveEdit.TabIndex = 51;
            this.btnSaveEdit.Text = "Save";
            this.btnSaveEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveEdit.UseVisualStyleBackColor = true;
            this.btnSaveEdit.Visible = false;
            this.btnSaveEdit.Click += new System.EventHandler(this.btnSaveEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(0, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 46);
            this.btnDelete.TabIndex = 48;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // PrintDialog1
            // 
            this.PrintDialog1.Document = this.PrintDocument1;
            // 
            // PageSetupDialog1
            // 
            this.PageSetupDialog1.Document = this.PrintDocument1;
            // 
            // checkBox_multiCurrency
            // 
            this.checkBox_multiCurrency.AutoSize = true;
            this.checkBox_multiCurrency.Enabled = false;
            this.checkBox_multiCurrency.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_multiCurrency.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBox_multiCurrency.Location = new System.Drawing.Point(12, 64);
            this.checkBox_multiCurrency.Name = "checkBox_multiCurrency";
            this.checkBox_multiCurrency.Size = new System.Drawing.Size(90, 17);
            this.checkBox_multiCurrency.TabIndex = 37;
            this.checkBox_multiCurrency.Text = "Multicurrency";
            this.checkBox_multiCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_multiCurrency.UseVisualStyleBackColor = true;
            this.checkBox_multiCurrency.CheckedChanged += new System.EventHandler(this.checkBox_multiCurrency_CheckedChanged);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(0, 6);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(98, 46);
            this.btnNew.TabIndex = 44;
            this.btnNew.Text = "New";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtCountUnits
            // 
            this.txtCountUnits.Location = new System.Drawing.Point(98, 38);
            this.txtCountUnits.Name = "txtCountUnits";
            this.txtCountUnits.ReadOnly = true;
            this.txtCountUnits.Size = new System.Drawing.Size(49, 20);
            this.txtCountUnits.TabIndex = 74;
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNew.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveNew.Image")));
            this.btnSaveNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveNew.Location = new System.Drawing.Point(0, 6);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(98, 46);
            this.btnSaveNew.TabIndex = 43;
            this.btnSaveNew.Text = "Save";
            this.btnSaveNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveNew.UseVisualStyleBackColor = true;
            this.btnSaveNew.Visible = false;
            this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 73;
            this.label11.Text = "Count Units";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(294, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 72;
            this.label7.Text = "User ID";
            // 
            // txt_UserID
            // 
            this.txt_UserID.Location = new System.Drawing.Point(343, 38);
            this.txt_UserID.MaxLength = 30;
            this.txt_UserID.Name = "txt_UserID";
            this.txt_UserID.ReadOnly = true;
            this.txt_UserID.Size = new System.Drawing.Size(103, 20);
            this.txt_UserID.TabIndex = 71;
            // 
            // txt_JVDescription
            // 
            this.txt_JVDescription.Enabled = false;
            this.txt_JVDescription.Location = new System.Drawing.Point(273, 13);
            this.txt_JVDescription.MaxLength = 100;
            this.txt_JVDescription.Name = "txt_JVDescription";
            this.txt_JVDescription.Size = new System.Drawing.Size(331, 20);
            this.txt_JVDescription.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "AR Description";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(153, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Balance";
            // 
            // txt_Balance
            // 
            this.txt_Balance.Location = new System.Drawing.Point(207, 39);
            this.txt_Balance.Name = "txt_Balance";
            this.txt_Balance.ReadOnly = true;
            this.txt_Balance.Size = new System.Drawing.Size(81, 20);
            this.txt_Balance.TabIndex = 21;
            // 
            // label_Currency
            // 
            this.label_Currency.AutoSize = true;
            this.label_Currency.Location = new System.Drawing.Point(108, 65);
            this.label_Currency.Name = "label_Currency";
            this.label_Currency.Size = new System.Drawing.Size(49, 13);
            this.label_Currency.TabIndex = 24;
            this.label_Currency.Text = "Currency";
            this.label_Currency.Visible = false;
            // 
            // cb_Currency
            // 
            this.cb_Currency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Currency.Enabled = false;
            this.cb_Currency.FormattingEnabled = true;
            this.cb_Currency.Location = new System.Drawing.Point(181, 64);
            this.cb_Currency.Name = "cb_Currency";
            this.cb_Currency.Size = new System.Drawing.Size(76, 21);
            this.cb_Currency.TabIndex = 25;
            this.cb_Currency.Visible = false;
            this.cb_Currency.SelectedIndexChanged += new System.EventHandler(this.cb_Currency_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Code";
            // 
            // btnUndo
            // 
            this.btnUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.Image = global::Accounting_GeneralLedger.Properties.Resources.undo;
            this.btnUndo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUndo.Location = new System.Drawing.Point(428, 333);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(98, 46);
            this.btnUndo.TabIndex = 84;
            this.btnUndo.Text = "Undo";
            this.btnUndo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Image = global::Accounting_GeneralLedger.Properties.Resources.find;
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFind.Location = new System.Drawing.Point(131, 7);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(98, 31);
            this.btnFind.TabIndex = 82;
            this.btnFind.Text = "Find";
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.EnabledChanged += new System.EventHandler(this.btnFind_EnabledChanged);
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // groupDetails
            // 
            this.groupDetails.Controls.Add(this.chkactive);
            this.groupDetails.Controls.Add(this.label6);
            this.groupDetails.Controls.Add(this.txtCountUnits);
            this.groupDetails.Controls.Add(this.label11);
            this.groupDetails.Controls.Add(this.txt_JVDescription);
            this.groupDetails.Controls.Add(this.label7);
            this.groupDetails.Controls.Add(this.label2);
            this.groupDetails.Controls.Add(this.txt_UserID);
            this.groupDetails.Controls.Add(this.label8);
            this.groupDetails.Controls.Add(this.txt_Balance);
            this.groupDetails.Controls.Add(this.label_Currency);
            this.groupDetails.Controls.Add(this.cb_Currency);
            this.groupDetails.Controls.Add(this.label_CurrencyRate);
            this.groupDetails.Controls.Add(this.checkBox_multiCurrency);
            this.groupDetails.Controls.Add(this.txt_CurrencyRate);
            this.groupDetails.Controls.Add(this.txtBatch);
            this.groupDetails.Enabled = false;
            this.groupDetails.Location = new System.Drawing.Point(3, 44);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(610, 98);
            this.groupDetails.TabIndex = 95;
            this.groupDetails.TabStop = false;
            // 
            // chkactive
            // 
            this.chkactive.AutoSize = true;
            this.chkactive.Location = new System.Drawing.Point(501, 65);
            this.chkactive.Name = "chkactive";
            this.chkactive.Size = new System.Drawing.Size(56, 17);
            this.chkactive.TabIndex = 75;
            this.chkactive.Text = "Active";
            this.chkactive.UseVisualStyleBackColor = true;
            // 
            // label_CurrencyRate
            // 
            this.label_CurrencyRate.AutoSize = true;
            this.label_CurrencyRate.Location = new System.Drawing.Point(269, 65);
            this.label_CurrencyRate.Name = "label_CurrencyRate";
            this.label_CurrencyRate.Size = new System.Drawing.Size(72, 13);
            this.label_CurrencyRate.TabIndex = 26;
            this.label_CurrencyRate.Text = "CurrencyRate";
            this.label_CurrencyRate.Visible = false;
            // 
            // txt_CurrencyRate
            // 
            this.txt_CurrencyRate.Enabled = false;
            this.txt_CurrencyRate.Location = new System.Drawing.Point(349, 64);
            this.txt_CurrencyRate.Name = "txt_CurrencyRate";
            this.txt_CurrencyRate.ReadOnly = true;
            this.txt_CurrencyRate.Size = new System.Drawing.Size(75, 20);
            this.txt_CurrencyRate.TabIndex = 27;
            this.txt_CurrencyRate.Visible = false;
            // 
            // txtBatch
            // 
            this.txtBatch.Location = new System.Drawing.Point(98, 12);
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(79, 20);
            this.txtBatch.TabIndex = 30;
            this.txtBatch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBatch_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(619, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 75);
            this.pictureBox1.TabIndex = 88;
            this.pictureBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(546, 333);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 46);
            this.btnExit.TabIndex = 87;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Lock59
            // 
            this.Lock59.Controls.Add(this.btnDelete);
            this.Lock59.Location = new System.Drawing.Point(310, 327);
            this.Lock59.Name = "Lock59";
            this.Lock59.Size = new System.Drawing.Size(98, 52);
            this.Lock59.TabIndex = 91;
            this.Lock59.TabStop = false;
            this.Lock59.Tag = "59";
            // 
            // Lock58
            // 
            this.Lock58.Controls.Add(this.btnEdit);
            this.Lock58.Controls.Add(this.btnSaveEdit);
            this.Lock58.Location = new System.Drawing.Point(192, 327);
            this.Lock58.Name = "Lock58";
            this.Lock58.Size = new System.Drawing.Size(98, 52);
            this.Lock58.TabIndex = 92;
            this.Lock58.TabStop = false;
            this.Lock58.Tag = "58";
            // 
            // Lock57
            // 
            this.Lock57.Controls.Add(this.btnNew);
            this.Lock57.Controls.Add(this.btnSaveNew);
            this.Lock57.Location = new System.Drawing.Point(74, 327);
            this.Lock57.Name = "Lock57";
            this.Lock57.Size = new System.Drawing.Size(98, 52);
            this.Lock57.TabIndex = 93;
            this.Lock57.TabStop = false;
            this.Lock57.Tag = "57";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(22, 12);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(100, 20);
            this.txtFind.TabIndex = 83;
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            this.txtFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyUp);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Enabled = false;
            this.dgv.Location = new System.Drawing.Point(3, 148);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 25;
            this.dgv.Size = new System.Drawing.Size(697, 168);
            this.dgv.TabIndex = 81;
            this.dgv.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_CellBeginEdit);
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEndEdit);
            this.dgv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_DataError);
            this.dgv.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_EditingControlShowing);
            this.dgv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
            this.dgv.Leave += new System.EventHandler(this.dgv_Leave);
            this.dgv.MouseLeave += new System.EventHandler(this.dgv_MouseLeave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ARTransactionsTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(709, 389);
            this.ControlBox = false;
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.groupDetails);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.Lock59);
            this.Controls.Add(this.Lock58);
            this.Controls.Add(this.Lock57);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ARTransactionsTemp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ARTransactions Temp Maintenance";
            this.Load += new System.EventHandler(this.ARTransactionsTemp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ARbatchTempBindingSource)).EndInit();
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Lock59.ResumeLayout(false);
            this.Lock58.ResumeLayout(false);
            this.Lock57.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSaveEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Drawing.Printing.PrintDocument PrintDocument1;
        private System.Windows.Forms.PrintDialog PrintDialog1;
        private System.Windows.Forms.PageSetupDialog PageSetupDialog1;
        private System.Windows.Forms.CheckBox checkBox_multiCurrency;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.BindingSource ARbatchTempBindingSource;
        private System.Windows.Forms.TextBox txtCountUnits;
        private System.Windows.Forms.Button btnSaveNew;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_UserID;
        private System.Windows.Forms.TextBox txt_JVDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Balance;
        private System.Windows.Forms.Label label_Currency;
        private System.Windows.Forms.ComboBox cb_Currency;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.Label label_CurrencyRate;
        private System.Windows.Forms.TextBox txt_CurrencyRate;
        private System.Windows.Forms.TextBox txtBatch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox Lock59;
        private System.Windows.Forms.GroupBox Lock58;
        private System.Windows.Forms.GroupBox Lock57;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox chkactive;

    }
}