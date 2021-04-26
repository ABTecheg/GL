namespace Accounting_GeneralLedger
{
    partial class GeneralLadger_GeneralSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralLadger_GeneralSetup));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_Tran_Cashier = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_payroll = new System.Windows.Forms.ComboBox();
            this.cb_BankDepost = new System.Windows.Forms.ComboBox();
            this.cb_Systeminterface = new System.Windows.Forms.ComboBox();
            this.cb_Payable = new System.Windows.Forms.ComboBox();
            this.cb_Receivable = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRetained = new System.Windows.Forms.MaskedTextBox();
            this.txtIncome = new System.Windows.Forms.MaskedTextBox();
            this.txtbalanceSheet = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_Tran_Cashier);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cb_payroll);
            this.groupBox1.Controls.Add(this.cb_BankDepost);
            this.groupBox1.Controls.Add(this.cb_Systeminterface);
            this.groupBox1.Controls.Add(this.cb_Payable);
            this.groupBox1.Controls.Add(this.cb_Receivable);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.LightGray;
            this.groupBox1.Location = new System.Drawing.Point(17, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 230);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Default Journal";
            // 
            // cb_Tran_Cashier
            // 
            this.cb_Tran_Cashier.FormattingEnabled = true;
            this.cb_Tran_Cashier.Location = new System.Drawing.Point(158, 183);
            this.cb_Tran_Cashier.Name = "cb_Tran_Cashier";
            this.cb_Tran_Cashier.Size = new System.Drawing.Size(138, 25);
            this.cb_Tran_Cashier.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.LightGray;
            this.label9.Location = new System.Drawing.Point(11, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 17);
            this.label9.TabIndex = 12;
            this.label9.Text = "JNL Tran Cashier";
            // 
            // cb_payroll
            // 
            this.cb_payroll.FormattingEnabled = true;
            this.cb_payroll.Location = new System.Drawing.Point(158, 153);
            this.cb_payroll.Name = "cb_payroll";
            this.cb_payroll.Size = new System.Drawing.Size(138, 25);
            this.cb_payroll.TabIndex = 11;
            this.cb_payroll.SelectedIndexChanged += new System.EventHandler(this.cb_payroll_SelectedIndexChanged);
            // 
            // cb_BankDepost
            // 
            this.cb_BankDepost.FormattingEnabled = true;
            this.cb_BankDepost.Location = new System.Drawing.Point(158, 123);
            this.cb_BankDepost.Name = "cb_BankDepost";
            this.cb_BankDepost.Size = new System.Drawing.Size(138, 25);
            this.cb_BankDepost.TabIndex = 10;
            this.cb_BankDepost.SelectedIndexChanged += new System.EventHandler(this.cb_BankDepost_SelectedIndexChanged);
            // 
            // cb_Systeminterface
            // 
            this.cb_Systeminterface.FormattingEnabled = true;
            this.cb_Systeminterface.Location = new System.Drawing.Point(158, 93);
            this.cb_Systeminterface.Name = "cb_Systeminterface";
            this.cb_Systeminterface.Size = new System.Drawing.Size(138, 25);
            this.cb_Systeminterface.TabIndex = 9;
            this.cb_Systeminterface.SelectedIndexChanged += new System.EventHandler(this.cb_Systeminterface_SelectedIndexChanged);
            // 
            // cb_Payable
            // 
            this.cb_Payable.FormattingEnabled = true;
            this.cb_Payable.Location = new System.Drawing.Point(158, 63);
            this.cb_Payable.Name = "cb_Payable";
            this.cb_Payable.Size = new System.Drawing.Size(138, 25);
            this.cb_Payable.TabIndex = 8;
            this.cb_Payable.SelectedIndexChanged += new System.EventHandler(this.cb_Payable_SelectedIndexChanged);
            // 
            // cb_Receivable
            // 
            this.cb_Receivable.FormattingEnabled = true;
            this.cb_Receivable.Location = new System.Drawing.Point(158, 32);
            this.cb_Receivable.Name = "cb_Receivable";
            this.cb_Receivable.Size = new System.Drawing.Size(138, 25);
            this.cb_Receivable.TabIndex = 7;
            this.cb_Receivable.SelectedIndexChanged += new System.EventHandler(this.cb_Receivable_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LightGray;
            this.label5.Location = new System.Drawing.Point(10, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Pay Roll";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightGray;
            this.label4.Location = new System.Drawing.Point(10, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Bank Depost";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(10, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "System Interface";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(10, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Accounts Payable";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(10, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Accounts Receivable";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtRetained);
            this.groupBox2.Controls.Add(this.txtIncome);
            this.groupBox2.Controls.Add(this.txtbalanceSheet);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Enabled = false;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.LightGray;
            this.groupBox2.Location = new System.Drawing.Point(346, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 145);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "P/L Accounts";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtRetained
            // 
            this.txtRetained.Location = new System.Drawing.Point(140, 92);
            this.txtRetained.Mask = "000-0000-00";
            this.txtRetained.Name = "txtRetained";
            this.txtRetained.PromptChar = '#';
            this.txtRetained.Size = new System.Drawing.Size(148, 23);
            this.txtRetained.TabIndex = 6;
            this.txtRetained.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtRetained_MaskInputRejected);
            this.txtRetained.DoubleClick += new System.EventHandler(this.txtRetained_DoubleClick);
            // 
            // txtIncome
            // 
            this.txtIncome.Location = new System.Drawing.Point(140, 63);
            this.txtIncome.Mask = "000-0000-00";
            this.txtIncome.Name = "txtIncome";
            this.txtIncome.PromptChar = '#';
            this.txtIncome.Size = new System.Drawing.Size(148, 23);
            this.txtIncome.TabIndex = 5;
            this.txtIncome.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtIncome_MaskInputRejected);
            this.txtIncome.DoubleClick += new System.EventHandler(this.txtIncome_DoubleClick);
            // 
            // txtbalanceSheet
            // 
            this.txtbalanceSheet.Location = new System.Drawing.Point(140, 34);
            this.txtbalanceSheet.Mask = "000-0000-00";
            this.txtbalanceSheet.Name = "txtbalanceSheet";
            this.txtbalanceSheet.PromptChar = '#';
            this.txtbalanceSheet.Size = new System.Drawing.Size(148, 23);
            this.txtbalanceSheet.TabIndex = 4;
            this.txtbalanceSheet.DoubleClick += new System.EventHandler(this.txtbalanceSheet_DoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.LightGray;
            this.label8.Location = new System.Drawing.Point(11, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "Retained Earnings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightGray;
            this.label7.Location = new System.Drawing.Point(11, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Income Statment";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LightGray;
            this.label6.Location = new System.Drawing.Point(11, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Balance Sheet";
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnedit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnedit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnedit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnedit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnedit.ForeColor = System.Drawing.Color.LightGray;
            this.btnedit.Location = new System.Drawing.Point(398, 250);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(69, 37);
            this.btnedit.TabIndex = 28;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.LightGray;
            this.btnExit.Location = new System.Drawing.Point(520, 250);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(69, 37);
            this.btnExit.TabIndex = 27;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.LightGray;
            this.btnOk.Location = new System.Drawing.Point(398, 250);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(69, 37);
            this.btnOk.TabIndex = 26;
            this.btnOk.Text = "Save ";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(202, 7);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(231, 31);
            this.label10.TabIndex = 29;
            this.label10.Text = "GL General Setup";
            // 
            // GeneralLadger_GeneralSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(650, 318);
            this.ControlBox = false;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GeneralLadger_GeneralSetup";
            this.Text = "GeneralLadger_GeneralSetup";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GeneralLadger_GeneralSetup_FormClosed);
            this.Load += new System.EventHandler(this.GeneralLadger_GeneralSetup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Receivable;
        private System.Windows.Forms.ComboBox cb_payroll;
        private System.Windows.Forms.ComboBox cb_BankDepost;
        private System.Windows.Forms.ComboBox cb_Systeminterface;
        private System.Windows.Forms.ComboBox cb_Payable;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtRetained;
        private System.Windows.Forms.MaskedTextBox txtIncome;
        private System.Windows.Forms.MaskedTextBox txtbalanceSheet;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cb_Tran_Cashier;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}