namespace Accounting_GeneralLedger
{
    partial class ARTransactions
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ARTransactions));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ARNumber = new System.Windows.Forms.TextBox();
            this.txt_JVDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DTP_JVDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Period = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Balance = new System.Windows.Forms.TextBox();
            this.label_Currency = new System.Windows.Forms.Label();
            this.cb_Currency = new System.Windows.Forms.ComboBox();
            this.label_CurrencyRate = new System.Windows.Forms.Label();
            this.txt_CurrencyRate = new System.Windows.Forms.TextBox();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PrintDialog1 = new System.Windows.Forms.PrintDialog();
            this.PrintDocument1 = new System.Drawing.Printing.PrintDocument();
            this.PageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.checkBox_multiCurrency = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_Temptran = new System.Windows.Forms.ComboBox();
            this.Lock65 = new System.Windows.Forms.GroupBox();
            this.Lock63 = new System.Windows.Forms.GroupBox();
            this.btn_Post = new System.Windows.Forms.Button();
            this.Lock62 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.Lock61 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSaveEdit = new System.Windows.Forms.Button();
            this.Lock60 = new System.Windows.Forms.GroupBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSaveNew = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_UserID = new System.Windows.Forms.TextBox();
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.batchTempBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.Lock65.SuspendLayout();
            this.Lock63.SuspendLayout();
            this.Lock62.SuspendLayout();
            this.Lock61.SuspendLayout();
            this.Lock60.SuspendLayout();
            this.groupDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchTempBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "AR Number";
            // 
            // txt_ARNumber
            // 
            this.txt_ARNumber.Enabled = false;
            this.txt_ARNumber.Location = new System.Drawing.Point(258, 13);
            this.txt_ARNumber.Name = "txt_ARNumber";
            this.txt_ARNumber.Size = new System.Drawing.Size(97, 20);
            this.txt_ARNumber.TabIndex = 2;
            // 
            // txt_JVDescription
            // 
            this.txt_JVDescription.Enabled = false;
            this.txt_JVDescription.Location = new System.Drawing.Point(83, 40);
            this.txt_JVDescription.MaxLength = 100;
            this.txt_JVDescription.Name = "txt_JVDescription";
            this.txt_JVDescription.Size = new System.Drawing.Size(272, 20);
            this.txt_JVDescription.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "AR Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "AR Date";
            // 
            // DTP_JVDate
            // 
            this.DTP_JVDate.Enabled = false;
            this.DTP_JVDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_JVDate.Location = new System.Drawing.Point(83, 66);
            this.DTP_JVDate.Name = "DTP_JVDate";
            this.DTP_JVDate.Size = new System.Drawing.Size(136, 20);
            this.DTP_JVDate.TabIndex = 8;
            this.DTP_JVDate.CloseUp += new System.EventHandler(this.DTP_JVDate_CloseUp);
            this.DTP_JVDate.ValueChanged += new System.EventHandler(this.DTP_JVDate_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(239, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Period";
            // 
            // txt_Period
            // 
            this.txt_Period.Enabled = false;
            this.txt_Period.Location = new System.Drawing.Point(282, 66);
            this.txt_Period.Name = "txt_Period";
            this.txt_Period.ReadOnly = true;
            this.txt_Period.Size = new System.Drawing.Size(81, 20);
            this.txt_Period.TabIndex = 10;
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
            this.dgv.Location = new System.Drawing.Point(12, 141);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 25;
            this.dgv.Size = new System.Drawing.Size(772, 218);
            this.dgv.TabIndex = 13;
            this.toolTip1.SetToolTip(this.dgv, "mahmoud");
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(382, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Balance";
            // 
            // txt_Balance
            // 
            this.txt_Balance.Location = new System.Drawing.Point(432, 65);
            this.txt_Balance.Name = "txt_Balance";
            this.txt_Balance.ReadOnly = true;
            this.txt_Balance.Size = new System.Drawing.Size(81, 20);
            this.txt_Balance.TabIndex = 21;
            // 
            // label_Currency
            // 
            this.label_Currency.AutoSize = true;
            this.label_Currency.Location = new System.Drawing.Point(462, 43);
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
            this.cb_Currency.Location = new System.Drawing.Point(525, 38);
            this.cb_Currency.Name = "cb_Currency";
            this.cb_Currency.Size = new System.Drawing.Size(76, 21);
            this.cb_Currency.TabIndex = 25;
            this.cb_Currency.Visible = false;
            this.cb_Currency.SelectedIndexChanged += new System.EventHandler(this.cb_Currency_SelectedIndexChanged);
            // 
            // label_CurrencyRate
            // 
            this.label_CurrencyRate.AutoSize = true;
            this.label_CurrencyRate.Location = new System.Drawing.Point(607, 43);
            this.label_CurrencyRate.Name = "label_CurrencyRate";
            this.label_CurrencyRate.Size = new System.Drawing.Size(72, 13);
            this.label_CurrencyRate.TabIndex = 26;
            this.label_CurrencyRate.Text = "CurrencyRate";
            this.label_CurrencyRate.Visible = false;
            // 
            // txt_CurrencyRate
            // 
            this.txt_CurrencyRate.Enabled = false;
            this.txt_CurrencyRate.Location = new System.Drawing.Point(690, 38);
            this.txt_CurrencyRate.Name = "txt_CurrencyRate";
            this.txt_CurrencyRate.ReadOnly = true;
            this.txt_CurrencyRate.Size = new System.Drawing.Size(75, 20);
            this.txt_CurrencyRate.TabIndex = 27;
            this.txt_CurrencyRate.Visible = false;
            // 
            // txtBatch
            // 
            this.txtBatch.Enabled = false;
            this.txtBatch.Location = new System.Drawing.Point(83, 13);
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(97, 20);
            this.txtBatch.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Batch";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(188, 15);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(100, 20);
            this.txtFind.TabIndex = 33;
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            this.txtFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyUp);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(426, 13);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(30, 20);
            this.txtStatus.TabIndex = 35;
            this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(375, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Status";
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
            this.checkBox_multiCurrency.Location = new System.Drawing.Point(366, 42);
            this.checkBox_multiCurrency.Name = "checkBox_multiCurrency";
            this.checkBox_multiCurrency.Size = new System.Drawing.Size(90, 17);
            this.checkBox_multiCurrency.TabIndex = 37;
            this.checkBox_multiCurrency.Text = "Multicurrency";
            this.checkBox_multiCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_multiCurrency.UseVisualStyleBackColor = true;
            this.checkBox_multiCurrency.CheckedChanged += new System.EventHandler(this.checkBox_multiCurrency_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "ARTransactionsTemp";
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
            // Lock65
            // 
            this.Lock65.Controls.Add(this.label10);
            this.Lock65.Controls.Add(this.cb_Temptran);
            this.Lock65.Location = new System.Drawing.Point(12, 2);
            this.Lock65.Name = "Lock65";
            this.Lock65.Size = new System.Drawing.Size(170, 39);
            this.Lock65.TabIndex = 65;
            this.Lock65.TabStop = false;
            this.Lock65.Tag = "65";
            this.Lock65.Visible = false;
            // 
            // Lock63
            // 
            this.Lock63.Controls.Add(this.btn_Post);
            this.Lock63.Location = new System.Drawing.Point(482, 367);
            this.Lock63.Name = "Lock63";
            this.Lock63.Size = new System.Drawing.Size(98, 52);
            this.Lock63.TabIndex = 67;
            this.Lock63.TabStop = false;
            this.Lock63.Tag = "63";
            // 
            // btn_Post
            // 
            this.btn_Post.Enabled = false;
            this.btn_Post.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Post.Image = ((System.Drawing.Image)(resources.GetObject("btn_Post.Image")));
            this.btn_Post.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Post.Location = new System.Drawing.Point(0, 6);
            this.btn_Post.Name = "btn_Post";
            this.btn_Post.Size = new System.Drawing.Size(98, 46);
            this.btn_Post.TabIndex = 45;
            this.btn_Post.Text = "Post";
            this.btn_Post.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Post.UseVisualStyleBackColor = true;
            this.btn_Post.Click += new System.EventHandler(this.btn_Post_Click);
            // 
            // Lock62
            // 
            this.Lock62.Controls.Add(this.btnDelete);
            this.Lock62.Location = new System.Drawing.Point(250, 367);
            this.Lock62.Name = "Lock62";
            this.Lock62.Size = new System.Drawing.Size(98, 52);
            this.Lock62.TabIndex = 68;
            this.Lock62.TabStop = false;
            this.Lock62.Tag = "62";
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
            // Lock61
            // 
            this.Lock61.Controls.Add(this.btnEdit);
            this.Lock61.Controls.Add(this.btnSaveEdit);
            this.Lock61.Location = new System.Drawing.Point(134, 367);
            this.Lock61.Name = "Lock61";
            this.Lock61.Size = new System.Drawing.Size(98, 52);
            this.Lock61.TabIndex = 69;
            this.Lock61.TabStop = false;
            this.Lock61.Tag = "61";
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
            // Lock60
            // 
            this.Lock60.Controls.Add(this.btnNew);
            this.Lock60.Controls.Add(this.btnSaveNew);
            this.Lock60.Location = new System.Drawing.Point(18, 367);
            this.Lock60.Name = "Lock60";
            this.Lock60.Size = new System.Drawing.Size(98, 52);
            this.Lock60.TabIndex = 70;
            this.Lock60.TabStop = false;
            this.Lock60.Tag = "60";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(476, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 72;
            this.label7.Text = "User ID";
            // 
            // txt_UserID
            // 
            this.txt_UserID.Location = new System.Drawing.Point(525, 12);
            this.txt_UserID.MaxLength = 30;
            this.txt_UserID.Name = "txt_UserID";
            this.txt_UserID.ReadOnly = true;
            this.txt_UserID.Size = new System.Drawing.Size(103, 20);
            this.txt_UserID.TabIndex = 71;
            // 
            // groupDetails
            // 
            this.groupDetails.Controls.Add(this.label6);
            this.groupDetails.Controls.Add(this.label1);
            this.groupDetails.Controls.Add(this.txt_ARNumber);
            this.groupDetails.Controls.Add(this.txt_JVDescription);
            this.groupDetails.Controls.Add(this.label7);
            this.groupDetails.Controls.Add(this.label2);
            this.groupDetails.Controls.Add(this.txt_UserID);
            this.groupDetails.Controls.Add(this.label4);
            this.groupDetails.Controls.Add(this.DTP_JVDate);
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
            this.groupDetails.Location = new System.Drawing.Point(12, 42);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(772, 93);
            this.groupDetails.TabIndex = 80;
            this.groupDetails.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(702, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(598, 373);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 46);
            this.btnExit.TabIndex = 50;
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
            this.btnCopy.Location = new System.Drawing.Point(714, 373);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(98, 46);
            this.btnCopy.TabIndex = 46;
            this.btnCopy.Text = "Copy";
            this.btnCopy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Visible = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.Image = global::Accounting_GeneralLedger.Properties.Resources.undo;
            this.btnUndo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUndo.Location = new System.Drawing.Point(366, 373);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(98, 46);
            this.btnUndo.TabIndex = 42;
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
            this.btnFind.Location = new System.Drawing.Point(297, 10);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(98, 31);
            this.btnFind.TabIndex = 32;
            this.btnFind.Text = "Find";
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.EnabledChanged += new System.EventHandler(this.btnFind_EnabledChanged);
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // ARTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(820, 431);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupDetails);
            this.Controls.Add(this.Lock60);
            this.Controls.Add(this.Lock61);
            this.Controls.Add(this.Lock62);
            this.Controls.Add(this.Lock63);
            this.Controls.Add(this.Lock65);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ARTransactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transactions Maintenance";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ARTransactions_FormClosed);
            this.Load += new System.EventHandler(this.ARTransactions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.Lock65.ResumeLayout(false);
            this.Lock65.PerformLayout();
            this.Lock63.ResumeLayout(false);
            this.Lock62.ResumeLayout(false);
            this.Lock61.ResumeLayout(false);
            this.Lock60.ResumeLayout(false);
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchTempBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ARNumber;
        private System.Windows.Forms.TextBox txt_JVDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DTP_JVDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Period;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txt_Balance;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_Currency;
        private System.Windows.Forms.ComboBox cb_Currency;
        private System.Windows.Forms.TextBox txt_CurrencyRate;
        private System.Windows.Forms.Label label_CurrencyRate;
        private System.Windows.Forms.TextBox txtBatch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox_multiCurrency;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btn_Post;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSaveNew;
        private System.Windows.Forms.Button btnSaveEdit;
        private System.Windows.Forms.PrintDialog PrintDialog1;
        private System.Windows.Forms.PageSetupDialog PageSetupDialog1;
        private System.Drawing.Printing.PrintDocument PrintDocument1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cb_Temptran;
        private System.Windows.Forms.BindingSource batchTempBindingSource;
        private System.Windows.Forms.GroupBox Lock60;
        private System.Windows.Forms.GroupBox Lock61;
        private System.Windows.Forms.GroupBox Lock62;
        private System.Windows.Forms.GroupBox Lock63;
        private System.Windows.Forms.GroupBox Lock65;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_UserID;
        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}