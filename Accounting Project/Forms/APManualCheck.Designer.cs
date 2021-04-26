namespace Accounting_GeneralLedger
{
    partial class APManualCheck
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_VendorCode = new System.Windows.Forms.TextBox();
            this.btn_SearchVendor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DTP_CheckDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DTP_PostingDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_period = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_CheckNumber = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_CheckingAccountCode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_DiscountAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_CheckTotal = new System.Windows.Forms.TextBox();
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.dgv_AccountCharges = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AccountCharges)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(275, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vendor Code";
            // 
            // txt_VendorCode
            // 
            this.txt_VendorCode.Location = new System.Drawing.Point(362, 31);
            this.txt_VendorCode.Name = "txt_VendorCode";
            this.txt_VendorCode.Size = new System.Drawing.Size(100, 20);
            this.txt_VendorCode.TabIndex = 1;
            // 
            // btn_SearchVendor
            // 
            this.btn_SearchVendor.Location = new System.Drawing.Point(468, 31);
            this.btn_SearchVendor.Name = "btn_SearchVendor";
            this.btn_SearchVendor.Size = new System.Drawing.Size(56, 20);
            this.btn_SearchVendor.TabIndex = 2;
            this.btn_SearchVendor.Text = "Search";
            this.btn_SearchVendor.UseVisualStyleBackColor = true;
            this.btn_SearchVendor.Click += new System.EventHandler(this.btn_SearchVendor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Check Date";
            // 
            // DTP_CheckDate
            // 
            this.DTP_CheckDate.Location = new System.Drawing.Point(134, 83);
            this.DTP_CheckDate.Name = "DTP_CheckDate";
            this.DTP_CheckDate.Size = new System.Drawing.Size(200, 20);
            this.DTP_CheckDate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Posting Date";
            // 
            // DTP_PostingDate
            // 
            this.DTP_PostingDate.Location = new System.Drawing.Point(134, 113);
            this.DTP_PostingDate.Name = "DTP_PostingDate";
            this.DTP_PostingDate.Size = new System.Drawing.Size(200, 20);
            this.DTP_PostingDate.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Period";
            // 
            // txt_period
            // 
            this.txt_period.Location = new System.Drawing.Point(134, 142);
            this.txt_period.Name = "txt_period";
            this.txt_period.ReadOnly = true;
            this.txt_period.Size = new System.Drawing.Size(200, 20);
            this.txt_period.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(372, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Check Number";
            // 
            // cb_CheckNumber
            // 
            this.cb_CheckNumber.FormattingEnabled = true;
            this.cb_CheckNumber.Location = new System.Drawing.Point(500, 87);
            this.cb_CheckNumber.Name = "cb_CheckNumber";
            this.cb_CheckNumber.Size = new System.Drawing.Size(121, 21);
            this.cb_CheckNumber.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(372, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Checking Account Code";
            // 
            // cb_CheckingAccountCode
            // 
            this.cb_CheckingAccountCode.FormattingEnabled = true;
            this.cb_CheckingAccountCode.Location = new System.Drawing.Point(500, 114);
            this.cb_CheckingAccountCode.Name = "cb_CheckingAccountCode";
            this.cb_CheckingAccountCode.Size = new System.Drawing.Size(121, 21);
            this.cb_CheckingAccountCode.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(646, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Discount Account in Check";
            // 
            // txt_DiscountAmount
            // 
            this.txt_DiscountAmount.Location = new System.Drawing.Point(805, 87);
            this.txt_DiscountAmount.Name = "txt_DiscountAmount";
            this.txt_DiscountAmount.ReadOnly = true;
            this.txt_DiscountAmount.Size = new System.Drawing.Size(100, 20);
            this.txt_DiscountAmount.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(646, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Check Total";
            // 
            // txt_CheckTotal
            // 
            this.txt_CheckTotal.Location = new System.Drawing.Point(805, 117);
            this.txt_CheckTotal.Name = "txt_CheckTotal";
            this.txt_CheckTotal.ReadOnly = true;
            this.txt_CheckTotal.Size = new System.Drawing.Size(100, 20);
            this.txt_CheckTotal.TabIndex = 16;
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
            this.dgv_AccountCharges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_AccountCharges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_AccountCharges.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_AccountCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AccountCharges.Location = new System.Drawing.Point(2, 179);
            this.dgv_AccountCharges.MultiSelect = false;
            this.dgv_AccountCharges.Name = "dgv_AccountCharges";
            this.dgv_AccountCharges.RowHeadersVisible = false;
            this.dgv_AccountCharges.Size = new System.Drawing.Size(937, 322);
            this.dgv_AccountCharges.TabIndex = 18;
            // 
            // APManualCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(944, 508);
            this.Controls.Add(this.dgv_AccountCharges);
            this.Controls.Add(this.txt_CheckTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_DiscountAmount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_CheckingAccountCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cb_CheckNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_period);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DTP_PostingDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DTP_CheckDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_SearchVendor);
            this.Controls.Add(this.txt_VendorCode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "APManualCheck";
            this.Text = "APManualCheck";
            this.Load += new System.EventHandler(this.APManualCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AccountCharges)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_VendorCode;
        private System.Windows.Forms.Button btn_SearchVendor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTP_CheckDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DTP_PostingDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_period;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_CheckNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_CheckingAccountCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_DiscountAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_CheckTotal;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.DataGridView dgv_AccountCharges;
    }
}