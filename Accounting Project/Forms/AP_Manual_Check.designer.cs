namespace Accounting_GeneralLedger
{
    partial class AP_Manual_Check
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AP_Manual_Check));
            this.btn_Search = new System.Windows.Forms.Button();
            this.label_Mode = new System.Windows.Forms.Label();
            this.txt_VendorCode = new System.Windows.Forms.TextBox();
            this.lblChecks_Total = new System.Windows.Forms.Label();
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.dgv_AccountCharges = new System.Windows.Forms.DataGridView();
            this.btn_Save = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Period = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DTP_JVDate = new System.Windows.Forms.DateTimePicker();
            this.lblCheck_Date = new System.Windows.Forms.Label();
            this.DTP_Check_Date = new System.Windows.Forms.DateTimePicker();
            this.cb_Bank_Account_ID = new System.Windows.Forms.ComboBox();
            this.lbl_Bank_Account_ID = new System.Windows.Forms.Label();
            this.cb_Check_Serial = new System.Windows.Forms.ComboBox();
            this.lblCheck_Serial = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txt_Checks_Total = new System.Windows.Forms.TextBox();
            this.txt_JVDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AccountCharges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(418, 12);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(93, 21);
            this.btn_Search.TabIndex = 5;
            this.btn_Search.Text = "Search";
            this.btn_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // label_Mode
            // 
            this.label_Mode.AutoSize = true;
            this.label_Mode.Location = new System.Drawing.Point(191, 16);
            this.label_Mode.Name = "label_Mode";
            this.label_Mode.Size = new System.Drawing.Size(69, 13);
            this.label_Mode.TabIndex = 6;
            this.label_Mode.Text = "Vendor Code";
            // 
            // txt_VendorCode
            // 
            this.txt_VendorCode.BackColor = System.Drawing.Color.White;
            this.txt_VendorCode.Location = new System.Drawing.Point(269, 12);
            this.txt_VendorCode.Name = "txt_VendorCode";
            this.txt_VendorCode.ReadOnly = true;
            this.txt_VendorCode.Size = new System.Drawing.Size(143, 20);
            this.txt_VendorCode.TabIndex = 7;
            this.txt_VendorCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblChecks_Total
            // 
            this.lblChecks_Total.AutoSize = true;
            this.lblChecks_Total.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.lblChecks_Total.Location = new System.Drawing.Point(557, 111);
            this.lblChecks_Total.Name = "lblChecks_Total";
            this.lblChecks_Total.Size = new System.Drawing.Size(115, 23);
            this.lblChecks_Total.TabIndex = 8;
            this.lblChecks_Total.Text = "Checks Total";
            // 
            // dbAccountingProjectDS
            // 
            this.dbAccountingProjectDS.DataSetName = "dbAccountingProjectDS";
            this.dbAccountingProjectDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgv_AccountCharges
            // 
            this.dgv_AccountCharges.AllowUserToAddRows = false;
            this.dgv_AccountCharges.AllowUserToDeleteRows = false;
            this.dgv_AccountCharges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_AccountCharges.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_AccountCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AccountCharges.Location = new System.Drawing.Point(6, 143);
            this.dgv_AccountCharges.MultiSelect = false;
            this.dgv_AccountCharges.Name = "dgv_AccountCharges";
            this.dgv_AccountCharges.RowHeadersVisible = false;
            this.dgv_AccountCharges.Size = new System.Drawing.Size(802, 318);
            this.dgv_AccountCharges.TabIndex = 17;
            this.dgv_AccountCharges.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_AccountCharges_CellBeginEdit);
            this.dgv_AccountCharges.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_AccountCharges_CellClick);
            this.dgv_AccountCharges.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_AccountCharges_CellEndEdit);
            this.dgv_AccountCharges.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_AccountCharges_EditingControlShowing);
            this.dgv_AccountCharges.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_AccountCharges_RowsAdded);
            this.dgv_AccountCharges.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgv_AccountCharges_RowsRemoved);
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.Location = new System.Drawing.Point(649, 21);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(114, 62);
            this.btn_Save.TabIndex = 13;
            this.btn_Save.Text = "Save ";
            this.btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(45, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Period";
            // 
            // txt_Period
            // 
            this.txt_Period.BackColor = System.Drawing.Color.White;
            this.txt_Period.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Period.Location = new System.Drawing.Point(96, 113);
            this.txt_Period.Name = "txt_Period";
            this.txt_Period.ReadOnly = true;
            this.txt_Period.Size = new System.Drawing.Size(81, 22);
            this.txt_Period.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Post Date";
            // 
            // DTP_JVDate
            // 
            this.DTP_JVDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_JVDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_JVDate.Location = new System.Drawing.Point(96, 76);
            this.DTP_JVDate.Name = "DTP_JVDate";
            this.DTP_JVDate.Size = new System.Drawing.Size(136, 22);
            this.DTP_JVDate.TabIndex = 19;
            this.DTP_JVDate.CloseUp += new System.EventHandler(this.DTP_JVDate_CloseUp);
            this.DTP_JVDate.ValueChanged += new System.EventHandler(this.DTP_JVDate_ValueChanged);
            // 
            // lblCheck_Date
            // 
            this.lblCheck_Date.AutoSize = true;
            this.lblCheck_Date.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheck_Date.Location = new System.Drawing.Point(19, 43);
            this.lblCheck_Date.Name = "lblCheck_Date";
            this.lblCheck_Date.Size = new System.Drawing.Size(76, 16);
            this.lblCheck_Date.TabIndex = 22;
            this.lblCheck_Date.Text = "Check Date";
            // 
            // DTP_Check_Date
            // 
            this.DTP_Check_Date.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_Check_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_Check_Date.Location = new System.Drawing.Point(96, 40);
            this.DTP_Check_Date.Name = "DTP_Check_Date";
            this.DTP_Check_Date.Size = new System.Drawing.Size(136, 22);
            this.DTP_Check_Date.TabIndex = 23;
            // 
            // cb_Bank_Account_ID
            // 
            this.cb_Bank_Account_ID.BackColor = System.Drawing.Color.White;
            this.cb_Bank_Account_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Bank_Account_ID.FormattingEnabled = true;
            this.cb_Bank_Account_ID.Location = new System.Drawing.Point(346, 44);
            this.cb_Bank_Account_ID.Name = "cb_Bank_Account_ID";
            this.cb_Bank_Account_ID.Size = new System.Drawing.Size(160, 21);
            this.cb_Bank_Account_ID.TabIndex = 45;
            this.cb_Bank_Account_ID.SelectedIndexChanged += new System.EventHandler(this.cb_Bank_Account_ID_SelectedIndexChanged);
            // 
            // lbl_Bank_Account_ID
            // 
            this.lbl_Bank_Account_ID.AutoSize = true;
            this.lbl_Bank_Account_ID.Location = new System.Drawing.Point(242, 47);
            this.lbl_Bank_Account_ID.Name = "lbl_Bank_Account_ID";
            this.lbl_Bank_Account_ID.Size = new System.Drawing.Size(75, 13);
            this.lbl_Bank_Account_ID.TabIndex = 44;
            this.lbl_Bank_Account_ID.Text = "Bank Account";
            // 
            // cb_Check_Serial
            // 
            this.cb_Check_Serial.BackColor = System.Drawing.Color.White;
            this.cb_Check_Serial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Check_Serial.FormattingEnabled = true;
            this.cb_Check_Serial.Location = new System.Drawing.Point(346, 80);
            this.cb_Check_Serial.Name = "cb_Check_Serial";
            this.cb_Check_Serial.Size = new System.Drawing.Size(160, 21);
            this.cb_Check_Serial.TabIndex = 47;
            // 
            // lblCheck_Serial
            // 
            this.lblCheck_Serial.AutoSize = true;
            this.lblCheck_Serial.Location = new System.Drawing.Point(242, 83);
            this.lblCheck_Serial.Name = "lblCheck_Serial";
            this.lblCheck_Serial.Size = new System.Drawing.Size(67, 13);
            this.lblCheck_Serial.TabIndex = 46;
            this.lblCheck_Serial.Text = "Check Serial";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txt_Checks_Total
            // 
            this.txt_Checks_Total.BackColor = System.Drawing.Color.White;
            this.txt_Checks_Total.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Checks_Total.Location = new System.Drawing.Point(678, 107);
            this.txt_Checks_Total.Name = "txt_Checks_Total";
            this.txt_Checks_Total.ReadOnly = true;
            this.txt_Checks_Total.Size = new System.Drawing.Size(122, 30);
            this.txt_Checks_Total.TabIndex = 48;
            this.txt_Checks_Total.Text = "0";
            this.txt_Checks_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_JVDescription
            // 
            this.txt_JVDescription.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_JVDescription.Location = new System.Drawing.Point(237, 113);
            this.txt_JVDescription.MaxLength = 150;
            this.txt_JVDescription.Name = "txt_JVDescription";
            this.txt_JVDescription.Size = new System.Drawing.Size(314, 22);
            this.txt_JVDescription.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(191, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 50;
            this.label2.Text = "Ref #";
            // 
            // AP_Manual_Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(812, 465);
            this.Controls.Add(this.txt_JVDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Checks_Total);
            this.Controls.Add(this.cb_Check_Serial);
            this.Controls.Add(this.lblCheck_Serial);
            this.Controls.Add(this.cb_Bank_Account_ID);
            this.Controls.Add(this.lbl_Bank_Account_ID);
            this.Controls.Add(this.lblCheck_Date);
            this.Controls.Add(this.DTP_Check_Date);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Period);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DTP_JVDate);
            this.Controls.Add(this.dgv_AccountCharges);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.lblChecks_Total);
            this.Controls.Add(this.txt_VendorCode);
            this.Controls.Add(this.label_Mode);
            this.Controls.Add(this.btn_Search);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AP_Manual_Check";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AP Manual Check";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AP_Manual_Check_FormClosed);
            this.Load += new System.EventHandler(this.AP_Manual_Check_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AccountCharges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label label_Mode;
        private System.Windows.Forms.TextBox txt_VendorCode;
        private System.Windows.Forms.Label lblChecks_Total;
        private System.Windows.Forms.Button btn_Save;
        private dbAccountingProjectDS dbAccountingProjectDS;
        //private System.Windows.Forms.DataGridViewTextBoxColumn invoiceAmountFCDataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn taxValueFCDataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn invoiceAmountFCDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn taxValueFCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dgv_AccountCharges;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Period;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DTP_JVDate;
        private System.Windows.Forms.Label lblCheck_Date;
        private System.Windows.Forms.DateTimePicker DTP_Check_Date;
        private System.Windows.Forms.ComboBox cb_Bank_Account_ID;
        private System.Windows.Forms.Label lbl_Bank_Account_ID;
        private System.Windows.Forms.ComboBox cb_Check_Serial;
        private System.Windows.Forms.Label lblCheck_Serial;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txt_Checks_Total;
        private System.Windows.Forms.TextBox txt_JVDescription;
        private System.Windows.Forms.Label label2;
    }
}