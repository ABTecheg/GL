namespace Accounting_GeneralLedger
{
    partial class GeneralSetup
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
            this.txtMaxAccountNo = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDecimalPoint = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cb_JVNumberFormat = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_APNumberFormat = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbMultiCurrency = new System.Windows.Forms.CheckBox();
            this.lblMultiCurrency = new System.Windows.Forms.Label();
            this.comboBox_language = new System.Windows.Forms.ComboBox();
            this.lblDefaultLanguage = new System.Windows.Forms.Label();
            this.cb_ARNumberFormat = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblJV = new System.Windows.Forms.TextBox();
            this.lblAP = new System.Windows.Forms.TextBox();
            this.lblAR = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBS = new System.Windows.Forms.ComboBox();
            this.lblBank = new System.Windows.Forms.TextBox();
            this.cb_BankNumberFormat = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaxAccountNo
            // 
            this.txtMaxAccountNo.Location = new System.Drawing.Point(176, 9);
            this.txtMaxAccountNo.Name = "txtMaxAccountNo";
            this.txtMaxAccountNo.Size = new System.Drawing.Size(162, 20);
            this.txtMaxAccountNo.TabIndex = 0;
            this.txtMaxAccountNo.Visible = false;
            this.txtMaxAccountNo.TextChanged += new System.EventHandler(this.txtMaxAccountNo_TextChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(262, 213);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(76, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Save && Exit";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Max Account Number";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Decimal Point";
            // 
            // txtDecimalPoint
            // 
            this.txtDecimalPoint.Location = new System.Drawing.Point(176, 36);
            this.txtDecimalPoint.Name = "txtDecimalPoint";
            this.txtDecimalPoint.Size = new System.Drawing.Size(162, 20);
            this.txtDecimalPoint.TabIndex = 4;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "JV Number Format";
            // 
            // cb_JVNumberFormat
            // 
            this.cb_JVNumberFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_JVNumberFormat.FormattingEnabled = true;
            this.cb_JVNumberFormat.Location = new System.Drawing.Point(176, 61);
            this.cb_JVNumberFormat.Name = "cb_JVNumberFormat";
            this.cb_JVNumberFormat.Size = new System.Drawing.Size(162, 21);
            this.cb_JVNumberFormat.TabIndex = 6;
            this.cb_JVNumberFormat.SelectedIndexChanged += new System.EventHandler(this.cb_JVNumberFormat_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "AP Number Format";
            // 
            // cb_APNumberFormat
            // 
            this.cb_APNumberFormat.FormattingEnabled = true;
            this.cb_APNumberFormat.Location = new System.Drawing.Point(176, 88);
            this.cb_APNumberFormat.Name = "cb_APNumberFormat";
            this.cb_APNumberFormat.Size = new System.Drawing.Size(162, 21);
            this.cb_APNumberFormat.TabIndex = 10;
            this.cb_APNumberFormat.SelectedIndexChanged += new System.EventHandler(this.cb_APNumberFormat_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(262, 240);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(76, 23);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbMultiCurrency
            // 
            this.cbMultiCurrency.AutoSize = true;
            this.cbMultiCurrency.Location = new System.Drawing.Point(126, 218);
            this.cbMultiCurrency.Name = "cbMultiCurrency";
            this.cbMultiCurrency.Size = new System.Drawing.Size(15, 14);
            this.cbMultiCurrency.TabIndex = 12;
            this.cbMultiCurrency.UseVisualStyleBackColor = true;
            // 
            // lblMultiCurrency
            // 
            this.lblMultiCurrency.AutoSize = true;
            this.lblMultiCurrency.Location = new System.Drawing.Point(5, 218);
            this.lblMultiCurrency.Name = "lblMultiCurrency";
            this.lblMultiCurrency.Size = new System.Drawing.Size(102, 13);
            this.lblMultiCurrency.TabIndex = 13;
            this.lblMultiCurrency.Text = "Allow Multi Currency";
            // 
            // comboBox_language
            // 
            this.comboBox_language.Location = new System.Drawing.Point(126, 184);
            this.comboBox_language.Name = "comboBox_language";
            this.comboBox_language.Size = new System.Drawing.Size(104, 21);
            this.comboBox_language.TabIndex = 14;
            // 
            // lblDefaultLanguage
            // 
            this.lblDefaultLanguage.AutoSize = true;
            this.lblDefaultLanguage.Location = new System.Drawing.Point(10, 184);
            this.lblDefaultLanguage.Name = "lblDefaultLanguage";
            this.lblDefaultLanguage.Size = new System.Drawing.Size(92, 13);
            this.lblDefaultLanguage.TabIndex = 15;
            this.lblDefaultLanguage.Text = "Default Language";
            // 
            // cb_ARNumberFormat
            // 
            this.cb_ARNumberFormat.FormattingEnabled = true;
            this.cb_ARNumberFormat.Location = new System.Drawing.Point(176, 117);
            this.cb_ARNumberFormat.Name = "cb_ARNumberFormat";
            this.cb_ARNumberFormat.Size = new System.Drawing.Size(162, 21);
            this.cb_ARNumberFormat.TabIndex = 17;
            this.cb_ARNumberFormat.SelectedIndexChanged += new System.EventHandler(this.cb_ARNumberFormat_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "AR Number Format";
            // 
            // lblJV
            // 
            this.lblJV.Location = new System.Drawing.Point(144, 62);
            this.lblJV.MaxLength = 2;
            this.lblJV.Name = "lblJV";
            this.lblJV.Size = new System.Drawing.Size(26, 20);
            this.lblJV.TabIndex = 18;
            // 
            // lblAP
            // 
            this.lblAP.Location = new System.Drawing.Point(144, 88);
            this.lblAP.MaxLength = 2;
            this.lblAP.Name = "lblAP";
            this.lblAP.Size = new System.Drawing.Size(26, 20);
            this.lblAP.TabIndex = 19;
            // 
            // lblAR
            // 
            this.lblAR.Location = new System.Drawing.Point(144, 117);
            this.lblAR.MaxLength = 2;
            this.lblAR.Name = "lblAR";
            this.lblAR.Size = new System.Drawing.Size(26, 20);
            this.lblAR.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Balance Sheet";
            this.label7.Visible = false;
            // 
            // cmbBS
            // 
            this.cmbBS.Items.AddRange(new object[] {
            "Standard",
            "Traditional",
            "T",
            "All"});
            this.cmbBS.Location = new System.Drawing.Point(126, 242);
            this.cmbBS.Name = "cmbBS";
            this.cmbBS.Size = new System.Drawing.Size(104, 21);
            this.cmbBS.TabIndex = 21;
            this.cmbBS.Visible = false;
            // 
            // lblBank
            // 
            this.lblBank.Location = new System.Drawing.Point(144, 145);
            this.lblBank.MaxLength = 2;
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(26, 20);
            this.lblBank.TabIndex = 25;
            // 
            // cb_BankNumberFormat
            // 
            this.cb_BankNumberFormat.FormattingEnabled = true;
            this.cb_BankNumberFormat.Location = new System.Drawing.Point(176, 145);
            this.cb_BankNumberFormat.Name = "cb_BankNumberFormat";
            this.cb_BankNumberFormat.Size = new System.Drawing.Size(162, 21);
            this.cb_BankNumberFormat.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Bank Number Format";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // GeneralSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(345, 290);
            this.ControlBox = false;
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.cb_BankNumberFormat);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbBS);
            this.Controls.Add(this.lblAR);
            this.Controls.Add(this.lblAP);
            this.Controls.Add(this.lblJV);
            this.Controls.Add(this.cb_ARNumberFormat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblDefaultLanguage);
            this.Controls.Add(this.comboBox_language);
            this.Controls.Add(this.lblMultiCurrency);
            this.Controls.Add(this.cbMultiCurrency);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cb_APNumberFormat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_JVNumberFormat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDecimalPoint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtMaxAccountNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "GeneralSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "General Setup";
            this.Activated += new System.EventHandler(this.GeneralSetup_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GeneralSetup_FormClosed);
            this.Load += new System.EventHandler(this.GeneralSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaxAccountNo;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDecimalPoint;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cb_JVNumberFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_APNumberFormat;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblMultiCurrency;
        private System.Windows.Forms.CheckBox cbMultiCurrency;
        private System.Windows.Forms.Label lblDefaultLanguage;
        private System.Windows.Forms.ComboBox comboBox_language;
        private System.Windows.Forms.ComboBox cb_ARNumberFormat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox lblAR;
        private System.Windows.Forms.TextBox lblAP;
        private System.Windows.Forms.TextBox lblJV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbBS;
        private System.Windows.Forms.TextBox lblBank;
        private System.Windows.Forms.ComboBox cb_BankNumberFormat;
        private System.Windows.Forms.Label label8;
    }
}

