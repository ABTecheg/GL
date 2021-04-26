namespace Accounting_GeneralLedger
{
    partial class JVTran_Cashier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JVTran_Cashier));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_JVNumber = new System.Windows.Forms.TextBox();
            this.txt_JVDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DTP_JVDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Period = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblAmount = new System.Windows.Forms.Label();
            this.txt_Amount = new System.Windows.Forms.TextBox();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PrintDialog1 = new System.Windows.Forms.PrintDialog();
            this.PrintDocument1 = new System.Drawing.Printing.PrintDocument();
            this.PageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
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
            this.txtAccount_Credit_Name = new System.Windows.Forms.TextBox();
            this.txtAccount_Debit_Name = new System.Windows.Forms.TextBox();
            this.txtAccount_Credit = new System.Windows.Forms.MaskedTextBox();
            this.txtAccount_Debit = new System.Windows.Forms.MaskedTextBox();
            this.lblAccount_Credit = new System.Windows.Forms.Label();
            this.lblAccount_Debit = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.batchTempBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "JV Number";
            // 
            // txt_JVNumber
            // 
            this.txt_JVNumber.Enabled = false;
            this.txt_JVNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_JVNumber.Location = new System.Drawing.Point(109, 51);
            this.txt_JVNumber.Name = "txt_JVNumber";
            this.txt_JVNumber.ReadOnly = true;
            this.txt_JVNumber.Size = new System.Drawing.Size(109, 27);
            this.txt_JVNumber.TabIndex = 2;
            // 
            // txt_JVDescription
            // 
            this.txt_JVDescription.Enabled = false;
            this.txt_JVDescription.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_JVDescription.Location = new System.Drawing.Point(347, 16);
            this.txt_JVDescription.MaxLength = 100;
            this.txt_JVDescription.Name = "txt_JVDescription";
            this.txt_JVDescription.Size = new System.Drawing.Size(470, 27);
            this.txt_JVDescription.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(224, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "JV Description";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(224, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 27);
            this.label4.TabIndex = 7;
            this.label4.Text = "JV Date";
            // 
            // DTP_JVDate
            // 
            this.DTP_JVDate.Enabled = false;
            this.DTP_JVDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_JVDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_JVDate.Location = new System.Drawing.Point(347, 51);
            this.DTP_JVDate.Name = "DTP_JVDate";
            this.DTP_JVDate.Size = new System.Drawing.Size(136, 27);
            this.DTP_JVDate.TabIndex = 8;
            this.DTP_JVDate.CloseUp += new System.EventHandler(this.DTP_JVDate_CloseUp);
            this.DTP_JVDate.ValueChanged += new System.EventHandler(this.DTP_JVDate_ValueChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 27);
            this.label5.TabIndex = 9;
            this.label5.Text = "Period";
            // 
            // txt_Period
            // 
            this.txt_Period.Enabled = false;
            this.txt_Period.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Period.Location = new System.Drawing.Point(109, 86);
            this.txt_Period.Name = "txt_Period";
            this.txt_Period.ReadOnly = true;
            this.txt_Period.Size = new System.Drawing.Size(109, 27);
            this.txt_Period.TabIndex = 10;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(654, 54);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(63, 23);
            this.lblAmount.TabIndex = 20;
            this.lblAmount.Text = "Amount";
            // 
            // txt_Amount
            // 
            this.txt_Amount.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Amount.Location = new System.Drawing.Point(723, 51);
            this.txt_Amount.Name = "txt_Amount";
            this.txt_Amount.Size = new System.Drawing.Size(94, 29);
            this.txt_Amount.TabIndex = 21;
            this.txt_Amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Balance_KeyPress);
            // 
            // txtBatch
            // 
            this.txtBatch.Enabled = false;
            this.txtBatch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatch.Location = new System.Drawing.Point(109, 16);
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.ReadOnly = true;
            this.txtBatch.Size = new System.Drawing.Size(109, 27);
            this.txtBatch.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 27);
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
            this.txtStatus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(109, 156);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(109, 27);
            this.txtStatus.TabIndex = 35;
            this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 27);
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
            // Lock63
            // 
            this.Lock63.Controls.Add(this.btn_Post);
            this.Lock63.Location = new System.Drawing.Point(476, 266);
            this.Lock63.Name = "Lock63";
            this.Lock63.Size = new System.Drawing.Size(92, 52);
            this.Lock63.TabIndex = 67;
            this.Lock63.TabStop = false;
            this.Lock63.Tag = "111";
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
            // Lock62
            // 
            this.Lock62.Controls.Add(this.btnDelete);
            this.Lock62.Location = new System.Drawing.Point(244, 266);
            this.Lock62.Name = "Lock62";
            this.Lock62.Size = new System.Drawing.Size(92, 52);
            this.Lock62.TabIndex = 68;
            this.Lock62.TabStop = false;
            this.Lock62.Tag = "110";
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
            // Lock61
            // 
            this.Lock61.Controls.Add(this.btnEdit);
            this.Lock61.Controls.Add(this.btnSaveEdit);
            this.Lock61.Location = new System.Drawing.Point(128, 266);
            this.Lock61.Name = "Lock61";
            this.Lock61.Size = new System.Drawing.Size(92, 52);
            this.Lock61.TabIndex = 69;
            this.Lock61.TabStop = false;
            this.Lock61.Tag = "109";
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
            // Lock60
            // 
            this.Lock60.Controls.Add(this.btnNew);
            this.Lock60.Controls.Add(this.btnSaveNew);
            this.Lock60.Location = new System.Drawing.Point(12, 266);
            this.Lock60.Name = "Lock60";
            this.Lock60.Size = new System.Drawing.Size(92, 52);
            this.Lock60.TabIndex = 70;
            this.Lock60.TabStop = false;
            this.Lock60.Tag = "108";
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
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 27);
            this.label7.TabIndex = 72;
            this.label7.Text = "User ID";
            // 
            // txt_UserID
            // 
            this.txt_UserID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UserID.Location = new System.Drawing.Point(109, 121);
            this.txt_UserID.MaxLength = 30;
            this.txt_UserID.Name = "txt_UserID";
            this.txt_UserID.ReadOnly = true;
            this.txt_UserID.Size = new System.Drawing.Size(109, 27);
            this.txt_UserID.TabIndex = 71;
            // 
            // groupDetails
            // 
            this.groupDetails.Controls.Add(this.txtAccount_Credit_Name);
            this.groupDetails.Controls.Add(this.txtAccount_Debit_Name);
            this.groupDetails.Controls.Add(this.txtAccount_Credit);
            this.groupDetails.Controls.Add(this.txtAccount_Debit);
            this.groupDetails.Controls.Add(this.lblAccount_Credit);
            this.groupDetails.Controls.Add(this.lblAccount_Debit);
            this.groupDetails.Controls.Add(this.label6);
            this.groupDetails.Controls.Add(this.label1);
            this.groupDetails.Controls.Add(this.txt_JVNumber);
            this.groupDetails.Controls.Add(this.txt_JVDescription);
            this.groupDetails.Controls.Add(this.label7);
            this.groupDetails.Controls.Add(this.label2);
            this.groupDetails.Controls.Add(this.txt_UserID);
            this.groupDetails.Controls.Add(this.label4);
            this.groupDetails.Controls.Add(this.DTP_JVDate);
            this.groupDetails.Controls.Add(this.label5);
            this.groupDetails.Controls.Add(this.txt_Period);
            this.groupDetails.Controls.Add(this.lblAmount);
            this.groupDetails.Controls.Add(this.txt_Amount);
            this.groupDetails.Controls.Add(this.txtStatus);
            this.groupDetails.Controls.Add(this.txtBatch);
            this.groupDetails.Controls.Add(this.label9);
            this.groupDetails.Enabled = false;
            this.groupDetails.Location = new System.Drawing.Point(12, 42);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(904, 209);
            this.groupDetails.TabIndex = 80;
            this.groupDetails.TabStop = false;
            // 
            // txtAccount_Credit_Name
            // 
            this.txtAccount_Credit_Name.BackColor = System.Drawing.Color.White;
            this.txtAccount_Credit_Name.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccount_Credit_Name.Location = new System.Drawing.Point(496, 147);
            this.txtAccount_Credit_Name.MaxLength = 100;
            this.txtAccount_Credit_Name.Name = "txtAccount_Credit_Name";
            this.txtAccount_Credit_Name.ReadOnly = true;
            this.txtAccount_Credit_Name.Size = new System.Drawing.Size(402, 27);
            this.txtAccount_Credit_Name.TabIndex = 78;
            this.txtAccount_Credit_Name.Tag = " ";
            // 
            // txtAccount_Debit_Name
            // 
            this.txtAccount_Debit_Name.BackColor = System.Drawing.Color.White;
            this.txtAccount_Debit_Name.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccount_Debit_Name.Location = new System.Drawing.Point(496, 105);
            this.txtAccount_Debit_Name.MaxLength = 100;
            this.txtAccount_Debit_Name.Name = "txtAccount_Debit_Name";
            this.txtAccount_Debit_Name.ReadOnly = true;
            this.txtAccount_Debit_Name.Size = new System.Drawing.Size(402, 27);
            this.txtAccount_Debit_Name.TabIndex = 77;
            this.txtAccount_Debit_Name.Tag = " ";
            // 
            // txtAccount_Credit
            // 
            this.txtAccount_Credit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccount_Credit.Location = new System.Drawing.Point(347, 147);
            this.txtAccount_Credit.Mask = "000-0000-00";
            this.txtAccount_Credit.Name = "txtAccount_Credit";
            this.txtAccount_Credit.PromptChar = '#';
            this.txtAccount_Credit.Size = new System.Drawing.Size(143, 27);
            this.txtAccount_Credit.TabIndex = 76;
            this.txtAccount_Credit.DoubleClick += new System.EventHandler(this.txtAccount_Credit_DoubleClick);
            this.txtAccount_Credit.Leave += new System.EventHandler(this.txtAccount_Credit_Leave);
            // 
            // txtAccount_Debit
            // 
            this.txtAccount_Debit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccount_Debit.Location = new System.Drawing.Point(347, 105);
            this.txtAccount_Debit.Mask = "000-0000-00";
            this.txtAccount_Debit.Name = "txtAccount_Debit";
            this.txtAccount_Debit.PromptChar = '#';
            this.txtAccount_Debit.Size = new System.Drawing.Size(143, 27);
            this.txtAccount_Debit.TabIndex = 75;
            this.txtAccount_Debit.DoubleClick += new System.EventHandler(this.txtAccount_Debit_DoubleClick);
            this.txtAccount_Debit.Leave += new System.EventHandler(this.txtAccount_Debit_Leave);
            // 
            // lblAccount_Credit
            // 
            this.lblAccount_Credit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccount_Credit.Location = new System.Drawing.Point(224, 147);
            this.lblAccount_Credit.Name = "lblAccount_Credit";
            this.lblAccount_Credit.Size = new System.Drawing.Size(117, 27);
            this.lblAccount_Credit.TabIndex = 74;
            this.lblAccount_Credit.Text = "Account Credit";
            // 
            // lblAccount_Debit
            // 
            this.lblAccount_Debit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccount_Debit.Location = new System.Drawing.Point(224, 108);
            this.lblAccount_Debit.Name = "lblAccount_Debit";
            this.lblAccount_Debit.Size = new System.Drawing.Size(117, 27);
            this.lblAccount_Debit.TabIndex = 73;
            this.lblAccount_Debit.Text = "Account Debit";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(835, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 75);
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(824, 272);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(92, 46);
            this.btnExit.TabIndex = 50;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(592, 272);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(92, 46);
            this.btnPrint.TabIndex = 47;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(708, 272);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(92, 46);
            this.btnCopy.TabIndex = 46;
            this.btnCopy.Tag = "";
            this.btnCopy.Text = "Copy";
            this.btnCopy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.Image = global::Accounting_GeneralLedger.Properties.Resources.undo;
            this.btnUndo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUndo.Location = new System.Drawing.Point(360, 272);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(92, 46);
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
            // JVTran_Cashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(928, 333);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupDetails);
            this.Controls.Add(this.Lock60);
            this.Controls.Add(this.Lock61);
            this.Controls.Add(this.Lock62);
            this.Controls.Add(this.Lock63);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.btnFind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "JVTran_Cashier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction Maintenance Cashier";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.JVTran_Cashier_FormClosed);
            this.Load += new System.EventHandler(this.JVTran_Cashier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private System.Windows.Forms.TextBox txt_JVNumber;
        private System.Windows.Forms.TextBox txt_JVDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DTP_JVDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Period;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txt_Amount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtBatch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btn_Post;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSaveNew;
        private System.Windows.Forms.Button btnSaveEdit;
        private System.Windows.Forms.PrintDialog PrintDialog1;
        private System.Windows.Forms.PageSetupDialog PageSetupDialog1;
        private System.Drawing.Printing.PrintDocument PrintDocument1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource batchTempBindingSource;
        private System.Windows.Forms.GroupBox Lock60;
        private System.Windows.Forms.GroupBox Lock61;
        private System.Windows.Forms.GroupBox Lock62;
        private System.Windows.Forms.GroupBox Lock63;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_UserID;
        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MaskedTextBox txtAccount_Credit;
        private System.Windows.Forms.MaskedTextBox txtAccount_Debit;
        private System.Windows.Forms.Label lblAccount_Credit;
        private System.Windows.Forms.Label lblAccount_Debit;
        private System.Windows.Forms.TextBox txtAccount_Credit_Name;
        private System.Windows.Forms.TextBox txtAccount_Debit_Name;
    }
}