namespace Accounting_GeneralLedger
{
    partial class JVEndYearAdjustments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JVEndYearAdjustments));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_Temptran = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Lock103 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSaveEdit = new System.Windows.Forms.Button();
            this.Lock104 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.Lock105 = new System.Windows.Forms.GroupBox();
            this.btn_Post = new System.Windows.Forms.Button();
            this.Lock106 = new System.Windows.Forms.GroupBox();
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.DTP_JVDate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCountUnits = new System.Windows.Forms.TextBox();
            this.txt_JVNumber = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_JVDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_UserID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_JournalCode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Period = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Balance = new System.Windows.Forms.TextBox();
            this.label_Currency = new System.Windows.Forms.Label();
            this.cb_Currency = new System.Windows.Forms.ComboBox();
            this.label_CurrencyRate = new System.Windows.Forms.Label();
            this.checkBox_multiCurrency = new System.Windows.Forms.CheckBox();
            this.txt_CurrencyRate = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Lock102 = new System.Windows.Forms.GroupBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSaveNew = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.PrintDocument1 = new System.Drawing.Printing.PrintDocument();
            this.PrintDialog1 = new System.Windows.Forms.PrintDialog();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.PageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.batchTempBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Lock103.SuspendLayout();
            this.Lock104.SuspendLayout();
            this.Lock105.SuspendLayout();
            this.Lock106.SuspendLayout();
            this.groupDetails.SuspendLayout();
            this.Lock102.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchTempBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "JVTransactionsTemp";
            // 
            // cb_Temptran
            // 
            this.cb_Temptran.DisplayMember = "TemplateCodeID";
            this.cb_Temptran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Temptran.Enabled = false;
            this.cb_Temptran.FormattingEnabled = true;
            this.cb_Temptran.Location = new System.Drawing.Point(114, 12);
            this.cb_Temptran.Name = "cb_Temptran";
            this.cb_Temptran.Size = new System.Drawing.Size(52, 21);
            this.cb_Temptran.TabIndex = 54;
            this.cb_Temptran.ValueMember = "TemplateCodeID";
            this.cb_Temptran.SelectedIndexChanged += new System.EventHandler(this.cb_Temptran_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Batch";
            // 
            // Lock103
            // 
            this.Lock103.Controls.Add(this.btnEdit);
            this.Lock103.Controls.Add(this.btnSaveEdit);
            this.Lock103.Location = new System.Drawing.Point(116, 369);
            this.Lock103.Name = "Lock103";
            this.Lock103.Size = new System.Drawing.Size(92, 52);
            this.Lock103.TabIndex = 92;
            this.Lock103.TabStop = false;
            this.Lock103.Tag = "103";
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(0, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(92, 46);
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
            this.btnSaveEdit.Size = new System.Drawing.Size(92, 46);
            this.btnSaveEdit.TabIndex = 51;
            this.btnSaveEdit.Text = "Save";
            this.btnSaveEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveEdit.UseVisualStyleBackColor = true;
            this.btnSaveEdit.Visible = false;
            this.btnSaveEdit.Click += new System.EventHandler(this.btnSaveEdit_Click);
            // 
            // Lock104
            // 
            this.Lock104.Controls.Add(this.btnDelete);
            this.Lock104.Location = new System.Drawing.Point(222, 369);
            this.Lock104.Name = "Lock104";
            this.Lock104.Size = new System.Drawing.Size(92, 52);
            this.Lock104.TabIndex = 91;
            this.Lock104.TabStop = false;
            this.Lock104.Tag = "104";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(0, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 46);
            this.btnDelete.TabIndex = 48;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Lock105
            // 
            this.Lock105.Controls.Add(this.btn_Post);
            this.Lock105.Location = new System.Drawing.Point(434, 369);
            this.Lock105.Name = "Lock105";
            this.Lock105.Size = new System.Drawing.Size(92, 52);
            this.Lock105.TabIndex = 90;
            this.Lock105.TabStop = false;
            this.Lock105.Tag = "105";
            // 
            // btn_Post
            // 
            this.btn_Post.Enabled = false;
            this.btn_Post.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Post.Image = ((System.Drawing.Image)(resources.GetObject("btn_Post.Image")));
            this.btn_Post.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Post.Location = new System.Drawing.Point(0, 6);
            this.btn_Post.Name = "btn_Post";
            this.btn_Post.Size = new System.Drawing.Size(92, 46);
            this.btn_Post.TabIndex = 45;
            this.btn_Post.Text = "Post";
            this.btn_Post.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Post.UseVisualStyleBackColor = true;
            this.btn_Post.Click += new System.EventHandler(this.btn_Post_Click);
            // 
            // Lock106
            // 
            this.Lock106.Controls.Add(this.label10);
            this.Lock106.Controls.Add(this.cb_Temptran);
            this.Lock106.Location = new System.Drawing.Point(4, 4);
            this.Lock106.Name = "Lock106";
            this.Lock106.Size = new System.Drawing.Size(170, 39);
            this.Lock106.TabIndex = 89;
            this.Lock106.TabStop = false;
            this.Lock106.Tag = "106";
            // 
            // groupDetails
            // 
            this.groupDetails.Controls.Add(this.DTP_JVDate);
            this.groupDetails.Controls.Add(this.label6);
            this.groupDetails.Controls.Add(this.label1);
            this.groupDetails.Controls.Add(this.txtCountUnits);
            this.groupDetails.Controls.Add(this.txt_JVNumber);
            this.groupDetails.Controls.Add(this.label11);
            this.groupDetails.Controls.Add(this.txt_JVDescription);
            this.groupDetails.Controls.Add(this.label7);
            this.groupDetails.Controls.Add(this.label2);
            this.groupDetails.Controls.Add(this.txt_UserID);
            this.groupDetails.Controls.Add(this.label3);
            this.groupDetails.Controls.Add(this.cb_JournalCode);
            this.groupDetails.Controls.Add(this.label4);
            this.groupDetails.Controls.Add(this.label5);
            this.groupDetails.Controls.Add(this.txt_Period);
            this.groupDetails.Controls.Add(this.label8);
            this.groupDetails.Controls.Add(this.txt_Balance);
            this.groupDetails.Controls.Add(this.label_Currency);
            this.groupDetails.Controls.Add(this.cb_Currency);
            this.groupDetails.Controls.Add(this.label_CurrencyRate);
            this.groupDetails.Controls.Add(this.checkBox_multiCurrency);
            this.groupDetails.Controls.Add(this.txt_CurrencyRate);
            this.groupDetails.Controls.Add(this.txtStatus);
            this.groupDetails.Controls.Add(this.txtBatch);
            this.groupDetails.Controls.Add(this.label9);
            this.groupDetails.Enabled = false;
            this.groupDetails.Location = new System.Drawing.Point(4, 44);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(632, 124);
            this.groupDetails.TabIndex = 95;
            this.groupDetails.TabStop = false;
            // 
            // DTP_JVDate
            // 
            this.DTP_JVDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DTP_JVDate.Enabled = false;
            this.DTP_JVDate.FormattingEnabled = true;
            this.DTP_JVDate.Location = new System.Drawing.Point(249, 39);
            this.DTP_JVDate.Name = "DTP_JVDate";
            this.DTP_JVDate.Size = new System.Drawing.Size(76, 21);
            this.DTP_JVDate.TabIndex = 75;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "JV Number";
            // 
            // txtCountUnits
            // 
            this.txtCountUnits.Location = new System.Drawing.Point(256, 65);
            this.txtCountUnits.Name = "txtCountUnits";
            this.txtCountUnits.ReadOnly = true;
            this.txtCountUnits.Size = new System.Drawing.Size(49, 20);
            this.txtCountUnits.TabIndex = 74;
            // 
            // txt_JVNumber
            // 
            this.txt_JVNumber.Enabled = false;
            this.txt_JVNumber.Location = new System.Drawing.Point(80, 38);
            this.txt_JVNumber.Name = "txt_JVNumber";
            this.txt_JVNumber.Size = new System.Drawing.Size(97, 20);
            this.txt_JVNumber.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(187, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 73;
            this.label11.Text = "Count Units";
            // 
            // txt_JVDescription
            // 
            this.txt_JVDescription.Enabled = false;
            this.txt_JVDescription.Location = new System.Drawing.Point(273, 13);
            this.txt_JVDescription.Name = "txt_JVDescription";
            this.txt_JVDescription.Size = new System.Drawing.Size(275, 20);
            this.txt_JVDescription.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(452, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 72;
            this.label7.Text = "User ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "JV Description";
            // 
            // txt_UserID
            // 
            this.txt_UserID.Location = new System.Drawing.Point(501, 65);
            this.txt_UserID.MaxLength = 30;
            this.txt_UserID.Name = "txt_UserID";
            this.txt_UserID.ReadOnly = true;
            this.txt_UserID.Size = new System.Drawing.Size(103, 20);
            this.txt_UserID.TabIndex = 71;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "JV Code";
            // 
            // cb_JournalCode
            // 
            this.cb_JournalCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_JournalCode.Enabled = false;
            this.cb_JournalCode.FormattingEnabled = true;
            this.cb_JournalCode.Location = new System.Drawing.Point(102, 64);
            this.cb_JournalCode.Name = "cb_JournalCode";
            this.cb_JournalCode.Size = new System.Drawing.Size(75, 21);
            this.cb_JournalCode.TabIndex = 6;
            this.cb_JournalCode.SelectedIndexChanged += new System.EventHandler(this.cb_JournalCode_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "JV Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Period";
            // 
            // txt_Period
            // 
            this.txt_Period.Enabled = false;
            this.txt_Period.Location = new System.Drawing.Point(374, 39);
            this.txt_Period.Name = "txt_Period";
            this.txt_Period.ReadOnly = true;
            this.txt_Period.Size = new System.Drawing.Size(81, 20);
            this.txt_Period.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(311, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Balance";
            // 
            // txt_Balance
            // 
            this.txt_Balance.Location = new System.Drawing.Point(365, 66);
            this.txt_Balance.Name = "txt_Balance";
            this.txt_Balance.ReadOnly = true;
            this.txt_Balance.Size = new System.Drawing.Size(81, 20);
            this.txt_Balance.TabIndex = 21;
            // 
            // label_Currency
            // 
            this.label_Currency.AutoSize = true;
            this.label_Currency.Location = new System.Drawing.Point(112, 93);
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
            this.cb_Currency.Location = new System.Drawing.Point(185, 92);
            this.cb_Currency.Name = "cb_Currency";
            this.cb_Currency.Size = new System.Drawing.Size(76, 21);
            this.cb_Currency.TabIndex = 25;
            this.cb_Currency.Visible = false;
            this.cb_Currency.SelectedIndexChanged += new System.EventHandler(this.cb_Currency_SelectedIndexChanged);
            // 
            // label_CurrencyRate
            // 
            this.label_CurrencyRate.AutoSize = true;
            this.label_CurrencyRate.Location = new System.Drawing.Point(273, 93);
            this.label_CurrencyRate.Name = "label_CurrencyRate";
            this.label_CurrencyRate.Size = new System.Drawing.Size(72, 13);
            this.label_CurrencyRate.TabIndex = 26;
            this.label_CurrencyRate.Text = "CurrencyRate";
            this.label_CurrencyRate.Visible = false;
            // 
            // checkBox_multiCurrency
            // 
            this.checkBox_multiCurrency.AutoSize = true;
            this.checkBox_multiCurrency.Enabled = false;
            this.checkBox_multiCurrency.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_multiCurrency.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBox_multiCurrency.Location = new System.Drawing.Point(16, 92);
            this.checkBox_multiCurrency.Name = "checkBox_multiCurrency";
            this.checkBox_multiCurrency.Size = new System.Drawing.Size(90, 17);
            this.checkBox_multiCurrency.TabIndex = 37;
            this.checkBox_multiCurrency.Text = "Multicurrency";
            this.checkBox_multiCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_multiCurrency.UseVisualStyleBackColor = true;
            this.checkBox_multiCurrency.CheckedChanged += new System.EventHandler(this.checkBox_multiCurrency_CheckedChanged);
            // 
            // txt_CurrencyRate
            // 
            this.txt_CurrencyRate.Enabled = false;
            this.txt_CurrencyRate.Location = new System.Drawing.Point(353, 92);
            this.txt_CurrencyRate.Name = "txt_CurrencyRate";
            this.txt_CurrencyRate.ReadOnly = true;
            this.txt_CurrencyRate.Size = new System.Drawing.Size(75, 20);
            this.txt_CurrencyRate.TabIndex = 27;
            this.txt_CurrencyRate.Visible = false;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(510, 39);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(30, 20);
            this.txtStatus.TabIndex = 35;
            this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged);
            // 
            // txtBatch
            // 
            this.txtBatch.Enabled = false;
            this.txtBatch.Location = new System.Drawing.Point(80, 12);
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(97, 20);
            this.txtBatch.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(466, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Status";
            // 
            // Lock102
            // 
            this.Lock102.Controls.Add(this.btnNew);
            this.Lock102.Controls.Add(this.btnSaveNew);
            this.Lock102.Location = new System.Drawing.Point(10, 369);
            this.Lock102.Name = "Lock102";
            this.Lock102.Size = new System.Drawing.Size(92, 52);
            this.Lock102.TabIndex = 93;
            this.Lock102.TabStop = false;
            this.Lock102.Tag = "102";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(0, 6);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(92, 46);
            this.btnNew.TabIndex = 44;
            this.btnNew.Text = "New";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNew.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveNew.Image")));
            this.btnSaveNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveNew.Location = new System.Drawing.Point(0, 6);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(92, 46);
            this.btnSaveNew.TabIndex = 43;
            this.btnSaveNew.Text = "Save";
            this.btnSaveNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveNew.UseVisualStyleBackColor = true;
            this.btnSaveNew.Visible = false;
            this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
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
            this.dgv.Location = new System.Drawing.Point(4, 174);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 25;
            this.dgv.Size = new System.Drawing.Size(732, 187);
            this.dgv.TabIndex = 81;
            this.dgv.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_CellBeginEdit);
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEndEdit);
            this.dgv.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_EditingControlShowing);
            this.dgv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
            this.dgv.Leave += new System.EventHandler(this.dgv_Leave);
            this.dgv.MouseLeave += new System.EventHandler(this.dgv_MouseLeave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // PrintDialog1
            // 
            this.PrintDialog1.Document = this.PrintDocument1;
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(180, 17);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(100, 20);
            this.txtFind.TabIndex = 83;
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            this.txtFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyUp);
            // 
            // PageSetupDialog1
            // 
            this.PageSetupDialog1.Document = this.PrintDocument1;
            // 
            // btnUndo
            // 
            this.btnUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.Image = global::Accounting_GeneralLedger.Properties.Resources.undo;
            this.btnUndo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUndo.Location = new System.Drawing.Point(328, 375);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(92, 46);
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
            this.btnFind.Location = new System.Drawing.Point(289, 12);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(98, 31);
            this.btnFind.TabIndex = 82;
            this.btnFind.Text = "Find";
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.EnabledChanged += new System.EventHandler(this.btnFind_EnabledChanged);
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(655, 4);
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
            this.btnExit.Location = new System.Drawing.Point(646, 375);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(92, 46);
            this.btnExit.TabIndex = 87;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(540, 375);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(92, 46);
            this.btnCopy.TabIndex = 85;
            this.btnCopy.Text = "Copy";
            this.btnCopy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // JVEndYearAdjustments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(747, 432);
            this.ControlBox = false;
            this.Controls.Add(this.Lock103);
            this.Controls.Add(this.Lock104);
            this.Controls.Add(this.Lock105);
            this.Controls.Add(this.Lock106);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.groupDetails);
            this.Controls.Add(this.Lock102);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.txtFind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "JVEndYearAdjustments";
            this.Text = "JVYearEndAdjustments";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.JVEndYearAdjustments_FormClosed);
            this.Load += new System.EventHandler(this.JVEndYearAdjustments_Load);
            this.Lock103.ResumeLayout(false);
            this.Lock104.ResumeLayout(false);
            this.Lock105.ResumeLayout(false);
            this.Lock106.ResumeLayout(false);
            this.Lock106.PerformLayout();
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
            this.Lock102.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchTempBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSaveEdit;
        private System.Windows.Forms.Button btnSaveNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cb_Temptran;
        private System.Windows.Forms.Button btn_Post;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.BindingSource batchTempBindingSource;
        private System.Windows.Forms.GroupBox Lock103;
        private System.Windows.Forms.GroupBox Lock104;
        private System.Windows.Forms.GroupBox Lock105;
        private System.Windows.Forms.GroupBox Lock106;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCountUnits;
        private System.Windows.Forms.TextBox txt_JVNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_JVDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_UserID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_JournalCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Period;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Balance;
        private System.Windows.Forms.Label label_Currency;
        private System.Windows.Forms.ComboBox cb_Currency;
        private System.Windows.Forms.Label label_CurrencyRate;
        private System.Windows.Forms.CheckBox checkBox_multiCurrency;
        private System.Windows.Forms.TextBox txt_CurrencyRate;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtBatch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox Lock102;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtFind;
        private System.Drawing.Printing.PrintDocument PrintDocument1;
        private System.Windows.Forms.PrintDialog PrintDialog1;
        private System.Windows.Forms.PageSetupDialog PageSetupDialog1;
        private System.Windows.Forms.ComboBox DTP_JVDate;
    }
}