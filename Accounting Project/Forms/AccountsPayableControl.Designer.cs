namespace Accounting_GeneralLedger
{
    partial class AccountsPayableControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_AccountNumber = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.checkbox_AllowMultiCurrency = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_VendorStatus = new System.Windows.Forms.ComboBox();
            this.cb_VendorTerms = new System.Windows.Forms.ComboBox();
            this.checkBox_PrintZeroBalance = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox_PrintSummary = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_FirstPeriodDays = new System.Windows.Forms.TextBox();
            this.txt_SecondPeriodDays = new System.Windows.Forms.TextBox();
            this.txt_ThirdPeriodDays = new System.Windows.Forms.TextBox();
            this.txt_FourthPeriodDays = new System.Windows.Forms.TextBox();
            this.txt_FirstPeriodDescription = new System.Windows.Forms.TextBox();
            this.txt_SecondPeriodDescription = new System.Windows.Forms.TextBox();
            this.txt_ThirdPeriodDescription = new System.Windows.Forms.TextBox();
            this.txt_FourthPeriodDescription = new System.Windows.Forms.TextBox();
            this.btn_Done = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.checkBox_WithHoldTax = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cb_PaymentDate = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "A/P Trade GL Account Number";
            // 
            // txt_AccountNumber
            // 
            this.txt_AccountNumber.Location = new System.Drawing.Point(193, 10);
            this.txt_AccountNumber.Name = "txt_AccountNumber";
            this.txt_AccountNumber.Size = new System.Drawing.Size(157, 20);
            this.txt_AccountNumber.TabIndex = 1;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(365, 10);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(86, 22);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = "Search";
            this.btn_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // checkbox_AllowMultiCurrency
            // 
            this.checkbox_AllowMultiCurrency.AutoSize = true;
            this.checkbox_AllowMultiCurrency.Location = new System.Drawing.Point(207, 298);
            this.checkbox_AllowMultiCurrency.Name = "checkbox_AllowMultiCurrency";
            this.checkbox_AllowMultiCurrency.Size = new System.Drawing.Size(15, 14);
            this.checkbox_AllowMultiCurrency.TabIndex = 3;
            this.checkbox_AllowMultiCurrency.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Default New Vendor Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Default New Vendor Terms";
            // 
            // cb_VendorStatus
            // 
            this.cb_VendorStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_VendorStatus.FormattingEnabled = true;
            this.cb_VendorStatus.Items.AddRange(new object[] {
            "Active",
            "Hold"});
            this.cb_VendorStatus.Location = new System.Drawing.Point(194, 38);
            this.cb_VendorStatus.Name = "cb_VendorStatus";
            this.cb_VendorStatus.Size = new System.Drawing.Size(121, 21);
            this.cb_VendorStatus.TabIndex = 7;
            // 
            // cb_VendorTerms
            // 
            this.cb_VendorTerms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_VendorTerms.FormattingEnabled = true;
            this.cb_VendorTerms.Location = new System.Drawing.Point(194, 62);
            this.cb_VendorTerms.Name = "cb_VendorTerms";
            this.cb_VendorTerms.Size = new System.Drawing.Size(121, 21);
            this.cb_VendorTerms.TabIndex = 8;
            this.cb_VendorTerms.SelectedIndexChanged += new System.EventHandler(this.cb_VendorTerms_SelectedIndexChanged);
            // 
            // checkBox_PrintZeroBalance
            // 
            this.checkBox_PrintZeroBalance.AutoSize = true;
            this.checkBox_PrintZeroBalance.Location = new System.Drawing.Point(207, 322);
            this.checkBox_PrintZeroBalance.Name = "checkBox_PrintZeroBalance";
            this.checkBox_PrintZeroBalance.Size = new System.Drawing.Size(15, 14);
            this.checkBox_PrintZeroBalance.TabIndex = 9;
            this.checkBox_PrintZeroBalance.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Allow MultiCurrency Invoicy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Print Zero Balance Checks";
            // 
            // checkBox_PrintSummary
            // 
            this.checkBox_PrintSummary.AutoSize = true;
            this.checkBox_PrintSummary.Location = new System.Drawing.Point(207, 351);
            this.checkBox_PrintSummary.Name = "checkBox_PrintSummary";
            this.checkBox_PrintSummary.Size = new System.Drawing.Size(15, 14);
            this.checkBox_PrintSummary.TabIndex = 12;
            this.checkBox_PrintSummary.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 351);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Print Summarized Checks";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Aging Periods";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(204, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Days";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(376, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Description";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Start of 1st Period";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 181);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Start of 2nd Period";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 210);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Start of 3rd Period";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 236);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Start of 4th Period";
            // 
            // txt_FirstPeriodDays
            // 
            this.txt_FirstPeriodDays.Location = new System.Drawing.Point(185, 155);
            this.txt_FirstPeriodDays.MaxLength = 30;
            this.txt_FirstPeriodDays.Name = "txt_FirstPeriodDays";
            this.txt_FirstPeriodDays.Size = new System.Drawing.Size(100, 20);
            this.txt_FirstPeriodDays.TabIndex = 21;
            this.txt_FirstPeriodDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_FirstPeriodDays_KeyPress);
            // 
            // txt_SecondPeriodDays
            // 
            this.txt_SecondPeriodDays.Location = new System.Drawing.Point(185, 181);
            this.txt_SecondPeriodDays.MaxLength = 30;
            this.txt_SecondPeriodDays.Name = "txt_SecondPeriodDays";
            this.txt_SecondPeriodDays.Size = new System.Drawing.Size(100, 20);
            this.txt_SecondPeriodDays.TabIndex = 22;
            this.txt_SecondPeriodDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SecondPeriodDays_KeyPress);
            // 
            // txt_ThirdPeriodDays
            // 
            this.txt_ThirdPeriodDays.Location = new System.Drawing.Point(185, 207);
            this.txt_ThirdPeriodDays.MaxLength = 30;
            this.txt_ThirdPeriodDays.Name = "txt_ThirdPeriodDays";
            this.txt_ThirdPeriodDays.Size = new System.Drawing.Size(100, 20);
            this.txt_ThirdPeriodDays.TabIndex = 23;
            this.txt_ThirdPeriodDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ThirdPeriodDays_KeyPress);
            // 
            // txt_FourthPeriodDays
            // 
            this.txt_FourthPeriodDays.Location = new System.Drawing.Point(185, 233);
            this.txt_FourthPeriodDays.MaxLength = 30;
            this.txt_FourthPeriodDays.Name = "txt_FourthPeriodDays";
            this.txt_FourthPeriodDays.Size = new System.Drawing.Size(100, 20);
            this.txt_FourthPeriodDays.TabIndex = 24;
            this.txt_FourthPeriodDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_FourthPeriodDays_KeyPress);
            // 
            // txt_FirstPeriodDescription
            // 
            this.txt_FirstPeriodDescription.Location = new System.Drawing.Point(353, 152);
            this.txt_FirstPeriodDescription.MaxLength = 30;
            this.txt_FirstPeriodDescription.Name = "txt_FirstPeriodDescription";
            this.txt_FirstPeriodDescription.Size = new System.Drawing.Size(100, 20);
            this.txt_FirstPeriodDescription.TabIndex = 25;
            // 
            // txt_SecondPeriodDescription
            // 
            this.txt_SecondPeriodDescription.Location = new System.Drawing.Point(352, 178);
            this.txt_SecondPeriodDescription.MaxLength = 30;
            this.txt_SecondPeriodDescription.Name = "txt_SecondPeriodDescription";
            this.txt_SecondPeriodDescription.Size = new System.Drawing.Size(100, 20);
            this.txt_SecondPeriodDescription.TabIndex = 26;
            // 
            // txt_ThirdPeriodDescription
            // 
            this.txt_ThirdPeriodDescription.Location = new System.Drawing.Point(353, 204);
            this.txt_ThirdPeriodDescription.MaxLength = 30;
            this.txt_ThirdPeriodDescription.Name = "txt_ThirdPeriodDescription";
            this.txt_ThirdPeriodDescription.Size = new System.Drawing.Size(100, 20);
            this.txt_ThirdPeriodDescription.TabIndex = 27;
            // 
            // txt_FourthPeriodDescription
            // 
            this.txt_FourthPeriodDescription.Location = new System.Drawing.Point(352, 230);
            this.txt_FourthPeriodDescription.MaxLength = 30;
            this.txt_FourthPeriodDescription.Name = "txt_FourthPeriodDescription";
            this.txt_FourthPeriodDescription.Size = new System.Drawing.Size(100, 20);
            this.txt_FourthPeriodDescription.TabIndex = 28;
            // 
            // btn_Done
            // 
            this.btn_Done.Location = new System.Drawing.Point(320, 367);
            this.btn_Done.Name = "btn_Done";
            this.btn_Done.Size = new System.Drawing.Size(135, 22);
            this.btn_Done.TabIndex = 29;
            this.btn_Done.Text = "OK";
            this.btn_Done.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Done.UseVisualStyleBackColor = true;
            this.btn_Done.Click += new System.EventHandler(this.btn_Done_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(28, 273);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Use WithHold Tax";
            // 
            // checkBox_WithHoldTax
            // 
            this.checkBox_WithHoldTax.AutoSize = true;
            this.checkBox_WithHoldTax.Location = new System.Drawing.Point(207, 272);
            this.checkBox_WithHoldTax.Name = "checkBox_WithHoldTax";
            this.checkBox_WithHoldTax.Size = new System.Drawing.Size(15, 14);
            this.checkBox_WithHoldTax.TabIndex = 31;
            this.checkBox_WithHoldTax.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(136, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Default Payment Date Start";
            // 
            // cb_PaymentDate
            // 
            this.cb_PaymentDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_PaymentDate.FormattingEnabled = true;
            this.cb_PaymentDate.Items.AddRange(new object[] {
            "BatchTransactionDate",
            "Invoice Date"});
            this.cb_PaymentDate.Location = new System.Drawing.Point(194, 89);
            this.cb_PaymentDate.Name = "cb_PaymentDate";
            this.cb_PaymentDate.Size = new System.Drawing.Size(121, 21);
            this.cb_PaymentDate.TabIndex = 33;
            // 
            // AccountsPayableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(467, 399);
            this.Controls.Add(this.cb_PaymentDate);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.checkBox_WithHoldTax);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btn_Done);
            this.Controls.Add(this.txt_FourthPeriodDescription);
            this.Controls.Add(this.txt_ThirdPeriodDescription);
            this.Controls.Add(this.txt_SecondPeriodDescription);
            this.Controls.Add(this.txt_FirstPeriodDescription);
            this.Controls.Add(this.txt_FourthPeriodDays);
            this.Controls.Add(this.txt_ThirdPeriodDays);
            this.Controls.Add(this.txt_SecondPeriodDays);
            this.Controls.Add(this.txt_FirstPeriodDays);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBox_PrintSummary);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox_PrintZeroBalance);
            this.Controls.Add(this.cb_VendorTerms);
            this.Controls.Add(this.cb_VendorStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkbox_AllowMultiCurrency);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.txt_AccountNumber);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountsPayableControl";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountsPayableControl";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AccountsPayableControl_FormClosed);
            this.Load += new System.EventHandler(this.AccountsPayableControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_AccountNumber;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.CheckBox checkbox_AllowMultiCurrency;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_VendorStatus;
        private System.Windows.Forms.ComboBox cb_VendorTerms;
        private System.Windows.Forms.CheckBox checkBox_PrintZeroBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox_PrintSummary;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_FirstPeriodDays;
        private System.Windows.Forms.TextBox txt_SecondPeriodDays;
        private System.Windows.Forms.TextBox txt_ThirdPeriodDays;
        private System.Windows.Forms.TextBox txt_FourthPeriodDays;
        private System.Windows.Forms.TextBox txt_FirstPeriodDescription;
        private System.Windows.Forms.TextBox txt_SecondPeriodDescription;
        private System.Windows.Forms.TextBox txt_ThirdPeriodDescription;
        private System.Windows.Forms.TextBox txt_FourthPeriodDescription;
        private System.Windows.Forms.Button btn_Done;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox checkBox_WithHoldTax;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cb_PaymentDate;
        private System.Windows.Forms.Label label15;
    }
}